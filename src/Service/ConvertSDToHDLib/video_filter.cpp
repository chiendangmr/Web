#include "Stdafx.h"
#include "video_filter.h"

extern "C"
{
#define __STDC_CONSTANT_MACROS
#define __STDC_LIMIT_MACROS
#include <libavformat/avformat.h>
#include <libswscale/swscale.h>
#include <libavutil/avutil.h>
#include <libavfilter/avfilter.h>
#include <libavutil/opt.h>
#include <libavfilter/buffersrc.h>
#include <libavfilter/buffersink.h>
}

#include <cstdio>
#include <sstream>
#include <string>
#include <queue>

using namespace System;

namespace HDConvert
{
	struct filter::impl
	{
		const AVRational						in_time_base_;
		const AVRational						in_frame_rate_;
		std::string								filtergraph_;
		bool									can_bypass_;

		std::shared_ptr<AVFilterGraph>			video_graph_;
		AVFilterContext*						video_graph_in_;
		AVFilterContext*						video_graph_out_;

		int64_t									nb_frame_ = 0;
		std::queue<std::shared_ptr<AVFrame>>	fast_path_;

		impl(
			int in_width,
			int in_height,
			AVRational in_time_base,
			AVRational in_frame_rate,
			AVRational in_sample_aspect_ratio,
			AVPixelFormat in_pix_fmt,
			std::vector<AVPixelFormat> out_pix_fmts,
			const std::string& filtergraph,
			bool multithreaded)
			: in_time_base_(in_time_base)
			, in_frame_rate_(in_frame_rate)
			, filtergraph_(filtergraph)
		{
			char args[512];

			if (out_pix_fmts.empty())
			{
				out_pix_fmts = {
					AV_PIX_FMT_YUVA420P,
					AV_PIX_FMT_YUV444P,
					AV_PIX_FMT_YUV422P,
					AV_PIX_FMT_YUV420P,
					AV_PIX_FMT_YUV411P,
					AV_PIX_FMT_BGRA,
					AV_PIX_FMT_ARGB,
					AV_PIX_FMT_RGBA,
					AV_PIX_FMT_ABGR,
					AV_PIX_FMT_GRAY8
				};
			}

			out_pix_fmts.push_back(AV_PIX_FMT_NONE);

			can_bypass_ = std::find(out_pix_fmts.begin(), out_pix_fmts.end(), in_pix_fmt) != out_pix_fmts.end();

			video_graph_.reset(
				avfilter_graph_alloc(),
				[](AVFilterGraph* p)
			{
				avfilter_graph_free(&p);
			});

			if (multithreaded)
			{
				video_graph_->nb_threads = 0;
				video_graph_->thread_type = AVFILTER_THREAD_SLICE;
			}
			else
			{
				video_graph_->nb_threads = 1;
			}

			snprintf(args, sizeof(args),
				"video_size=%dx%d:pix_fmt=%d:time_base=%d/%d:pixel_aspect=%d/%d:frame_rate=%d/%d",
				in_width, in_height,
				in_pix_fmt,
				in_time_base.num, in_time_base.den,
				in_sample_aspect_ratio.num, in_sample_aspect_ratio.den,
				in_frame_rate.num, in_frame_rate.den);
			const std::string vsrc_options(args);

			AVFilterContext* filt_vsrc = nullptr;
			if (avfilter_graph_create_filter(
				&filt_vsrc,
				avfilter_get_by_name("buffer"),
				"filter_buffer",
				vsrc_options.c_str(),
				nullptr,
				video_graph_.get()) < 0)
				throw gcnew Exception("Failed to create filter_buffer of filter");

			AVFilterContext* filt_vsink = nullptr;
			if (avfilter_graph_create_filter(
				&filt_vsink,
				avfilter_get_by_name("buffersink"),
				"filter_buffersink",
				nullptr,
				nullptr,
				video_graph_.get()) < 0)
				throw gcnew Exception("Failed to create filter_buffersink of filter");

#pragma warning (push)
#pragma warning (disable : 4245)

			if (av_opt_set_int_list(
				filt_vsink,
				"pix_fmts",
				out_pix_fmts.data(),
				-1,
				AV_OPT_SEARCH_CHILDREN) < 0)
				throw gcnew Exception("Failed to set pix_fmts");

#pragma warning (pop)

			configure_filtergraph(
				*video_graph_,
				filtergraph_,
				*filt_vsrc,
				*filt_vsink);

			video_graph_in_ = filt_vsrc;
			video_graph_out_ = filt_vsink;

			std::string filter_graph_log(avfilter_graph_dump(video_graph_.get(), nullptr));
			av_log(nullptr, AV_LOG_INFO, filter_graph_log.c_str());
		}

		void configure_filtergraph(
			AVFilterGraph& graph,
			const std::string& filtergraph,
			AVFilterContext& source_ctx,
			AVFilterContext& sink_ctx)
		{
			if (!filtergraph.empty())
			{
				auto outputs = avfilter_inout_alloc();
				auto inputs = avfilter_inout_alloc();

				if (!outputs || !inputs)
					throw gcnew Exception("Failed to create inputs and outputs for filter");

				outputs->name = av_strdup("in");
				outputs->filter_ctx = &source_ctx;
				outputs->pad_idx = 0;
				outputs->next = nullptr;

				inputs->name = av_strdup("out");
				inputs->filter_ctx = &sink_ctx;
				inputs->pad_idx = 0;
				inputs->next = nullptr;

				if (avfilter_graph_parse(
					&graph,
					filtergraph.c_str(),
					inputs,
					outputs,
					nullptr) < 0)
					throw gcnew Exception("Failed to parse filter graph");
			}
			else
			{
				if (avfilter_link(
					&source_ctx,
					0,
					&sink_ctx,
					0) < 0)
					throw gcnew Exception("Failed to link filter");
			}

			if (avfilter_graph_config(&graph, nullptr) < 0)
				throw gcnew Exception("Failed to config filter graph");
		}

		bool fast_path() const
		{
			return filtergraph_.empty() && can_bypass_;
		}

		void push(const std::shared_ptr<AVFrame>& src_av_frame)
		{
			if (fast_path())
				fast_path_.push(src_av_frame);
			else
			{
				if (src_av_frame)
				{
					src_av_frame->pts = av_rescale_q(nb_frame_, { in_frame_rate_.den, in_frame_rate_.num }, in_time_base_);
					++nb_frame_;
				}
				if (av_buffersrc_add_frame(
					video_graph_in_,
					src_av_frame.get()) < 0)
					throw gcnew Exception("Failed to add frame to filter");
			}
		}

		std::shared_ptr<AVFrame> poll()
		{
			if (fast_path())
			{
				if (fast_path_.empty())
					return nullptr;

				auto result = fast_path_.front();
				fast_path_.pop();
				return result;
			}

			auto filt_frame = std::shared_ptr<AVFrame>(av_frame_alloc(), [](AVFrame *p)
			{
				if (p)
					av_frame_free(&p);
			});
			if (!filt_frame)
				throw gcnew Exception("Failed to create frame for output filter");

			const auto ret = av_buffersink_get_frame(
				video_graph_out_,
				filt_frame.get());

			if (ret == AVERROR_EOF || ret == AVERROR(EAGAIN))
				return nullptr;

			if (ret < 0)
				throw gcnew Exception("Failed to poll frame");

			return filt_frame;
		}
	};

	filter::filter(
		int in_width,
		int in_height,
		AVRational in_time_base,
		AVRational in_frame_rate,
		AVRational in_sample_aspect_ration,
		AVPixelFormat in_pix_fmt,
		std::vector<AVPixelFormat> out_pix_fmts,
		const std::string& filtergraph,
		bool multithread)
		: impl_(new impl(in_width, in_height,
			in_time_base, in_frame_rate,
			in_sample_aspect_ration,
			in_pix_fmt,
			out_pix_fmts,
			filtergraph,
			multithread))
	{

	}

	void filter::push(const std::shared_ptr<AVFrame>& frame)
	{
		impl_->push(frame);
	}

	std::shared_ptr<AVFrame> filter::poll()
	{
		return impl_->poll();
	}

	std::vector<std::shared_ptr<AVFrame>> filter::poll_all()
	{
		std::vector<std::shared_ptr<AVFrame>> frames;
		for (auto frame = poll(); frame; frame = poll())
			frames.push_back(frame);
		return frames;
	}

	std::string filter::filter_str() const
	{
		return impl_->filtergraph_;
	}

	int64_t filter::nb_frames() const
	{
		return impl_->nb_frame_;
	}

	void filter::nb_frames(int64_t val)
	{
		impl_->nb_frame_ = val;
	}
}