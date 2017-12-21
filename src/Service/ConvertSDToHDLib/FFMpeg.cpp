#include "stdafx.h"
#include "FFMpeg.h"

#include "video_filter.h"

extern "C"
{
#define __STDC_CONSTANT_MACROS
#define __STDC_LIMIT_MACROS
#include <libavformat/avformat.h>
#include <libavfilter/avfilter.h>
#include <libswresample\swresample.h>
#include <libavutil/imgutils.h>
#include <libavutil\parseutils.h>
}

#include <atomic>
#include <string>
#include <sstream>
#include <memory>
#include <vector>
#include <array>
#include <queue>
#include <map>

#include <mux_mxf.h>
#include <auxinfo.h>
#include <bufstream/buf_file.h>
#include <bufstream/buf_fifo.h>
#include <bufstream/buf_seek.h>
#include <mcmediatypes.h>
#include <mctypes.h>
#include <mcfourcc.h>
#include <mcdefs.h>
#include <config_mp2v.h>
#include <enc_mp2v.h>
#include <mcprofile.h>
#include <enc_avc.h>
#include <enc_avc_def.h>
#include <enc_aac.h>
#include <mux_mp4.h>

using namespace System;
using namespace System::Runtime::InteropServices;

namespace HDConvert
{
#define LOG_LEVEL AV_LOG_INFO
	void add_log(std::string log)
	{
		auto logPtr = reinterpret_cast<const unsigned char*>(log.c_str());
		auto message = System::Text::Encoding::UTF8->GetString(const_cast<unsigned char*>(logPtr), static_cast<int>(log.length()));
		FFMpeg::AddLog(message);
	}

	void log_callback(void *ptr, int level, const char* fmt, va_list vl)
	{
		static std::atomic<std::string*> prev_log_tss;
		auto prev_log = prev_log_tss.load();
		if (!prev_log)
		{
			prev_log = new std::string();
			prev_log_tss = prev_log;
		}

		static std::atomic<std::stringstream*> last_log_tss;
		auto last_log = last_log_tss.load();
		if (!last_log)
		{
			last_log = new std::stringstream();
			last_log_tss = last_log;
		}

		char line[1024] = "\0";
		if (level > LOG_LEVEL)
			return;
		std::vsnprintf(line, sizeof(line) - 1, fmt, vl);
		if (strlen(line))
		{
			auto prefix = line[strlen(line) - 1] == '\n';
			if (prefix)
				line[strlen(line) - 1] = 0;
			*last_log << line;
			if (prefix)
			{
				std::stringstream log;
				log << "[ffmpeg]";
				if (level == AV_LOG_WARNING)
					log << " [warning]";
				else if (level == AV_LOG_ERROR)
					log << " [error]";
				else if (level == AV_LOG_FATAL)
					log << " [fatal]";
				log << " " << last_log->str();

				auto log_str = log.str();
				if (level > AV_LOG_WARNING || log_str.compare(*prev_log) != 0)
				{
					add_log(log_str);
					*prev_log = log_str;
				}
				last_log->str("");
			}
		}
	}

	void FFMpeg::Init()
	{
		if (!hasInit_)
		{
			hasInit_ = true;

			av_log_set_level(LOG_LEVEL);
			av_log_set_callback(log_callback);

			avfilter_register_all();
			av_register_all();
			avformat_network_init();
			avcodec_register_all();
		}
	}

	void FFMpeg::AddLog(String ^message)
	{
		OnLog(nullptr, gcnew FFMpegLogArgs(message));
	}

	std::string utf8_to_cstr(String^ str)
	{
		if (String::IsNullOrWhiteSpace(str))
			return std::string();

		auto strData = System::Text::Encoding::UTF8->GetBytes(str);
		pin_ptr<unsigned char> strDataPtr = &strData[0];
		return std::string(reinterpret_cast<char*>(strDataPtr));
	}

	std::wstring utf8_to_cwstr(String^ str)
	{
		if (String::IsNullOrWhiteSpace(str))
			return std::wstring();

		auto strPtr = Marshal::StringToHGlobalUni(str);

		std::wstring cwstr(reinterpret_cast<wchar_t*>(strPtr.ToPointer()));
		Marshal::FreeHGlobal(strPtr);
		return cwstr;
	}

	struct av_frame_format
	{
		int										pix_format;
		std::array<int, AV_NUM_DATA_POINTERS>	line_sizes;
		int										width;
		int										height;

		av_frame_format(const AVFrame& frame)
			: pix_format(frame.format)
			, width(frame.width)
			, height(frame.height)
		{
			for (int i = 0; i < AV_NUM_DATA_POINTERS; ++i)
				line_sizes.at(i) = frame.linesize[i];
		}

		bool operator==(const av_frame_format& other) const
		{
			return pix_format == other.pix_format
				&& line_sizes == other.line_sizes
				&& width == other.width
				&& height == other.height;
		}

		bool operator!=(const av_frame_format& other) const
		{
			return !(*this == other);
		}
	};

#pragma region Old input
	//class input_file
	//{
	//	const AVRational					output_framerate_;

	//	const bool							toHighres_;
	//	const int							highresWidth_;
	//	const int							highresHeight_;
	//	const bool							highresInterlace_;
	//	const bool							highresTopFieldFirst_;

	//	const bool							toLowres_;
	//	const int							lowresWidth_;
	//	const int							lowresHeight_;
	//	const std::string					lowresFilter_;

	//	std::shared_ptr<AVFormatContext>	format_ctx_;
	//	std::shared_ptr<AVCodecContext>		video_codec_ctx_;
	//	int									video_stream_index_;
	//	std::shared_ptr<AVCodecContext>		audio_codec_ctx_;
	//	int									audio_stream_index_;

	//	AVRational							in_framerate_;

	//	// Video filter
	//	std::shared_ptr<av_frame_format>	previously_input_format_;

	//	int									highres_width_;
	//	int									highres_height_;
	//	int									lowres_width_;
	//	int									lowres_height_;

	//	std::shared_ptr<filter>				change_pixel_format_filter_;

	//	bool								highres_from_deinterlace_;
	//	bool								lowres_from_deinterlace_;
	//	std::shared_ptr<filter>				deinterlace_filter_;

	//	bool								lowres_from_framerate_;
	//	std::shared_ptr<filter>				change_highres_framerate_filter_;

	//	std::shared_ptr<filter>				scale_highres_filter_;

	//	std::shared_ptr<filter>				interlace_highres_filter_;

	//	std::shared_ptr<filter>				change_lowres_framerate_;

	//	std::shared_ptr<filter>				scale_lowres_filter_;

	//	int64_t								last_draw_lowres_filter_frame_ = 0;
	//	std::shared_ptr<filter>				draw_lowres_filter_;

	//	uint32_t							number_frames_;
	//	uint32_t							num_input_frame_;
	//	uint32_t							num_output_frame_;

	//	// Audio convert
	//	std::shared_ptr<SwrContext>			swr_;
	//	float								volume_ = 1.0;

	//	bool								is_eof_;
	//public:
	//	input_file(std::string file, AVRational output_framerate, float minVolume, float maxVolume,
	//		bool toHighres, int highresWidth, int highresHeight, bool highresInterlace, bool highresTopFieldFirst,
	//		bool toLowres, int lowresWidth, int lowresHeight, const std::string& lowresFilter)
	//		: output_framerate_({ output_framerate.num, output_framerate.den })
	//		, toHighres_(toHighres)
	//		, highresWidth_(highresWidth)
	//		, highresHeight_(highresHeight)
	//		, highresInterlace_(highresInterlace)
	//		, highresTopFieldFirst_(highresTopFieldFirst)
	//		, toLowres_(toLowres)
	//		, lowresWidth_(lowresWidth)
	//		, lowresHeight_(lowresHeight)
	//		, lowresFilter_(lowresFilter)
	//	{
	//		if (!toHighres && !toLowres)
	//			throw gcnew Exception("Don't output to highres or lowres");

	//		AVFormatContext *weak_context = nullptr;
	//		if (avformat_open_input(&weak_context, file.c_str(), nullptr, nullptr) < 0)
	//			throw gcnew Exception("Failed to open input file");
	//		format_ctx_.reset(weak_context, [](AVFormatContext *p)
	//		{
	//			avformat_close_input(&p);
	//		});
	//		if (avformat_find_stream_info(format_ctx_.get(), nullptr))
	//			throw gcnew Exception("Failed to find input stream info");

	//		AVCodec *decoder = NULL;

	//		// Video stream
	//		video_stream_index_ = av_find_best_stream(format_ctx_.get(), AVMEDIA_TYPE_VIDEO, -1, -1, NULL, 0);
	//		if (video_stream_index_ < 0)
	//			throw gcnew Exception("Video stream not found");
	//		auto vstream = format_ctx_->streams[video_stream_index_];
	//		decoder = avcodec_find_decoder(vstream->codecpar->codec_id);
	//		if (!decoder)
	//			throw gcnew Exception("Failed to find decoder for video stream");
	//		video_codec_ctx_.reset(avcodec_alloc_context3(decoder), [](AVCodecContext *p)
	//		{
	//			if (p)
	//				avcodec_free_context(&p);
	//		});
	//		if (!video_codec_ctx_)
	//			throw gcnew Exception("Failed to allocate the decoder context for video stream");
	//		if (avcodec_parameters_to_context(video_codec_ctx_.get(), vstream->codecpar) < 0)
	//			throw gcnew Exception("Failed to copy decoder parameters to input decoder context");
	//		video_codec_ctx_->framerate = av_guess_frame_rate(format_ctx_.get(), vstream, NULL);
	//		if (avcodec_open2(video_codec_ctx_.get(), decoder, nullptr) < 0)
	//			throw gcnew Exception("Failed to open decoder for video stream");
	//		av_reduce(&in_framerate_.num, &in_framerate_.den, vstream->r_frame_rate.num, vstream->r_frame_rate.den, 1024 * 1024);
	//		number_frames_ = static_cast<uint32_t>(vstream->duration);

	//		// Audio stream
	//		decoder = NULL;
	//		audio_stream_index_ = av_find_best_stream(format_ctx_.get(), AVMEDIA_TYPE_AUDIO, -1, -1, NULL, 0);
	//		if (audio_stream_index_ < 0)
	//			throw gcnew Exception("Audio stream not found");
	//		auto astream = format_ctx_->streams[audio_stream_index_];
	//		decoder = avcodec_find_decoder(astream->codecpar->codec_id);
	//		if (!decoder)
	//			throw gcnew Exception("Failed to find decoder for audio stream");
	//		audio_codec_ctx_.reset(avcodec_alloc_context3(decoder), [](AVCodecContext *p)
	//		{
	//			if (p)
	//				avcodec_free_context(&p);
	//		});
	//		if (!audio_codec_ctx_)
	//			throw gcnew Exception("Failed to allocate the decoder context for audio stream");
	//		if (avcodec_parameters_to_context(audio_codec_ctx_.get(), astream->codecpar) < 0)
	//			throw gcnew Exception("Failed to copy decoder parameters to input decoder context");
	//		if (avcodec_open2(audio_codec_ctx_.get(), decoder, nullptr) < 0)
	//			throw gcnew Exception("Failed to open decoder for audio stream");

	//		av_dump_format(format_ctx_.get(), 0, file.c_str(), 0);

	//		// Detect volume
	//		if (maxVolume != 0.0)
	//		{
	//			if (minVolume == 0 || minVolume >= maxVolume)
	//				minVolume = -40;

	//			weak_context = nullptr;
	//			if (avformat_open_input(&weak_context, file.c_str(), nullptr, nullptr) < 0)
	//				throw gcnew Exception("Failed to open input file to detect volume");
	//			std::shared_ptr<AVFormatContext> tmp_context(weak_context, [](AVFormatContext *p)
	//			{
	//				avformat_close_input(&p);
	//			});
	//			if (avformat_find_stream_info(tmp_context.get(), nullptr))
	//				throw gcnew Exception("Failed to find input to detect volume stream info");

	//			decoder = NULL;
	//			auto tmp_astream = tmp_context->streams[audio_stream_index_];
	//			decoder = avcodec_find_decoder(tmp_astream->codecpar->codec_id);
	//			if (!decoder)
	//				throw gcnew Exception("Failed to find decoder for audio stream for detect volume");
	//			std::shared_ptr<AVCodecContext> tmp_audio_codec_ctx(avcodec_alloc_context3(decoder), [](AVCodecContext*p)
	//			{
	//				if (p)
	//					avcodec_free_context(&p);
	//			});
	//			if (!tmp_audio_codec_ctx)
	//				throw gcnew Exception("Failed to allocate the decoder context for audio stream for detect volume");
	//			if (avcodec_parameters_to_context(tmp_audio_codec_ctx.get(), tmp_astream->codecpar) < 0)
	//				throw gcnew Exception("Failed to copy decoder parameters to input decoder context for detect volume");
	//			if (avcodec_open2(tmp_audio_codec_ctx.get(), decoder, nullptr) < 0)
	//				throw gcnew Exception("Failed to open decoder for audio stream for detect volume");
	//			int64_t layout = tmp_audio_codec_ctx->channel_layout;
	//			if (layout == 0)
	//				layout = av_get_default_channel_layout(tmp_audio_codec_ctx->channels);
	//			std::shared_ptr<SwrContext> tmp_swr_(swr_alloc_set_opts(NULL,
	//				AV_CH_LAYOUT_MONO, AV_SAMPLE_FMT_S16, tmp_audio_codec_ctx->sample_rate,
	//				layout, tmp_audio_codec_ctx->sample_fmt, tmp_audio_codec_ctx->sample_rate, 0, nullptr), [](SwrContext *p)
	//			{
	//				if (p)
	//					swr_free(&p);
	//			});
	//			if (!tmp_swr_)
	//				throw gcnew Exception("Failed to allocate the swresample for detect volume");
	//			if (swr_init(tmp_swr_.get()) < 0)
	//				throw gcnew Exception("Failed to init the swresample for detect volume");

	//			int16_t max_sample = 0;
	//			std::vector<int16_t> last_samples;
	//			while (true)
	//			{
	//				std::shared_ptr<AVPacket> pkt(av_packet_alloc(), [](AVPacket *p)
	//				{
	//					av_packet_free(&p);
	//				});
	//				pkt->size = 0;
	//				pkt->data = NULL;
	//				av_init_packet(pkt.get());
	//				if (av_read_frame(tmp_context.get(), pkt.get()) >= 0)
	//				{
	//					if (pkt->stream_index == audio_stream_index_)
	//					{
	//						auto size = pkt->size;
	//						auto data = pkt->data;
	//						pkt = std::shared_ptr<AVPacket>(pkt.get(), [pkt, size, data](AVPacket*)
	//						{
	//							pkt->size = size;
	//							pkt->data = data;
	//						});
	//						avcodec_send_packet(tmp_audio_codec_ctx.get(), pkt.get());
	//						while (true)
	//						{
	//							std::shared_ptr<AVFrame> frame(av_frame_alloc(), [](AVFrame *p)
	//							{
	//								if (p)
	//									av_frame_free(&p);
	//							});
	//							if (!frame)
	//								throw gcnew Exception("Failed to create frame to decode audio");
	//							if (avcodec_receive_frame(tmp_audio_codec_ctx.get(), frame.get()) < 0)
	//								break;
	//							const uint8_t **in = const_cast<const uint8_t**>(frame->extended_data);
	//							std::vector<int16_t> out_samples(frame->nb_samples); // 1 channels
	//							uint8_t* out[] = { reinterpret_cast<uint8_t*>(out_samples.data()) };
	//							const auto channel_samples = swr_convert(
	//								tmp_swr_.get(),
	//								out,
	//								frame->nb_samples,
	//								in,
	//								frame->nb_samples);
	//							if (channel_samples > 0)
	//							{
	//								out_samples.resize(channel_samples, 0);
	//								if (!last_samples.empty())
	//								{
	//									for (auto sample : last_samples)
	//										max_sample = std::max(max_sample, (int16_t)std::abs(sample));
	//								}
	//								last_samples = std::move(out_samples);
	//							}
	//						}
	//					}
	//				}
	//				else
	//					break;
	//			}

	//			float dbFS = 20 * std::log10(static_cast<float>(max_sample) / static_cast<float>(std::numeric_limits<int16_t>::max()));
	//			if (dbFS > minVolume && std::abs(dbFS - maxVolume) > 1.0f)
	//			{
	//				auto maxSampleNeed = static_cast<int16_t>(std::pow(10, maxVolume / 20.0f) * static_cast<float>(std::numeric_limits<int16_t>::max() + 0.5));
	//				volume_ = static_cast<float>(maxSampleNeed) / static_cast<float>(max_sample);
	//			}
	//		}

	//		is_eof_ = false;
	//		num_input_frame_ = 0;
	//		num_output_frame_ = 0;
	//	}

	//	bool is_eof()
	//	{
	//		return is_eof_;
	//	}

	//	// Video Highres, Video Lowres, Audio
	//	std::pair<std::pair<std::queue<std::shared_ptr<AVFrame>>, std::queue<std::shared_ptr<AVFrame>>>, std::queue<std::vector<int16_t>>> try_get_frame()
	//	{
	//		if (is_eof_)
	//			return std::pair<std::pair<std::queue<std::shared_ptr<AVFrame>>, std::queue<std::shared_ptr<AVFrame>>>, std::queue<std::vector<int16_t>>>();

	//		std::shared_ptr<AVPacket> pkt(av_packet_alloc(), [](AVPacket *p)
	//		{
	//			av_packet_free(&p);
	//		});
	//		pkt->size = 0;
	//		pkt->data = NULL;
	//		av_init_packet(pkt.get());
	//		if (av_read_frame(format_ctx_.get(), pkt.get()) < 0)
	//			is_eof_ = true;

	//		std::shared_ptr<AVPacket> vpacket;
	//		std::shared_ptr<AVPacket> apacket;
	//		if (!is_eof_)
	//		{
	//			auto size = pkt->size;
	//			auto data = pkt->data;
	//			if (pkt->stream_index == video_stream_index_)
	//			{
	//				vpacket = std::shared_ptr<AVPacket>(pkt.get(), [pkt, size, data](AVPacket*)
	//				{
	//					pkt->size = size;
	//					pkt->data = data;
	//				});
	//			}
	//			else if (pkt->stream_index == audio_stream_index_)
	//			{
	//				apacket = std::shared_ptr<AVPacket>(pkt.get(), [pkt, size, data](AVPacket*)
	//				{
	//					pkt->size = size;
	//					pkt->data = data;
	//				});
	//			}
	//		}

	//		std::pair<std::pair<std::queue<std::shared_ptr<AVFrame>>, std::queue<std::shared_ptr<AVFrame>>>, std::queue<std::vector<int16_t>>> result_frames;

	//		// Decode video
	//		if (is_eof_ || vpacket)
	//		{
	//			avcodec_send_packet(video_codec_ctx_.get(), vpacket.get());
	//			while (true)
	//			{
	//				std::shared_ptr<AVFrame> frame(av_frame_alloc(), [](AVFrame *p)
	//				{
	//					if (p)
	//						av_frame_free(&p);
	//				});
	//				if (!frame)
	//					throw gcnew Exception("Failed to create frame to decode video");
	//				if (avcodec_receive_frame(video_codec_ctx_.get(), frame.get()) < 0)
	//					break;

	//				num_input_frame_++;

	//				frame->pts = av_frame_get_best_effort_timestamp(frame.get());
	//				update_display_mode(frame);

	//				auto video_frames = process_video_frame(frame);
	//				while (video_frames.first.size() > 0)
	//				{
	//					auto oframe = video_frames.first.front();
	//					video_frames.first.pop();
	//					result_frames.first.first.push(oframe);
	//				}
	//				while (video_frames.second.size() > 0)
	//				{
	//					auto oframe = video_frames.second.front();
	//					video_frames.second.pop();
	//					result_frames.first.second.push(oframe);
	//				}
	//			}
	//		}

	//		// Decode audio
	//		if (is_eof_ || apacket)
	//		{
	//			avcodec_send_packet(audio_codec_ctx_.get(), apacket.get());
	//			while (true)
	//			{
	//				std::shared_ptr<AVFrame> frame(av_frame_alloc(), [](AVFrame *p)
	//				{
	//					if (p)
	//						av_frame_free(&p);
	//				});
	//				if (!frame)
	//					throw gcnew Exception("Failed to create frame to decode audio");
	//				if (avcodec_receive_frame(audio_codec_ctx_.get(), frame.get()) < 0)
	//					break;

	//				if (!swr_)
	//				{
	//					int in_channels = frame->channels;
	//					int64_t in_layout = frame->channel_layout;
	//					if (in_layout == 0)
	//						in_layout = av_get_default_channel_layout(in_channels);

	//					swr_.reset(swr_alloc_set_opts(NULL, AV_CH_LAYOUT_STEREO, AV_SAMPLE_FMT_S16, 48000,
	//						in_layout, (AVSampleFormat)frame->format, frame->sample_rate, 0, NULL), [](SwrContext *p)
	//					{
	//						if (p)
	//							swr_free(&p);
	//					});
	//					if (!swr_)
	//						throw gcnew Exception("Failed to create swresample");
	//					if (swr_init(swr_.get()) < 0)
	//						throw gcnew Exception("Failed to init swresample");
	//				}

	//				const uint8_t **in = const_cast<const uint8_t**>(frame->extended_data);
	//				int max_out_samples = frame->nb_samples * 2;
	//				std::vector<int16_t> out_samples(max_out_samples * 2); // 2 channels
	//				uint8_t* out[] = { reinterpret_cast<uint8_t*>(out_samples.data()) };
	//				const auto channel_samples = swr_convert(
	//					swr_.get(),
	//					out,
	//					max_out_samples,
	//					in,
	//					frame->nb_samples);
	//				if (channel_samples > 0)
	//				{
	//					out_samples.resize(channel_samples * 2, 0); // 2 channel
	//					result_frames.second.push(out_samples);
	//				}
	//			}
	//		}

	//		if (is_eof_)
	//		{
	//			auto video_frames = process_video_frame(std::shared_ptr<AVFrame>());
	//			while (video_frames.first.size() > 0)
	//			{
	//				auto oframe = video_frames.first.front();
	//				video_frames.first.pop();
	//				result_frames.first.first.push(oframe);
	//			}
	//			while (video_frames.second.size() > 0)
	//			{
	//				auto oframe = video_frames.second.front();
	//				video_frames.second.pop();
	//				result_frames.first.second.push(oframe);
	//			}
	//		}

	//		if (toHighres_)
	//		{
	//			if (result_frames.first.first.size())
	//				num_output_frame_ += static_cast<uint32_t>(result_frames.first.first.size());
	//		}
	//		else if (toLowres_)
	//		{
	//			if (result_frames.first.second.size())
	//				num_output_frame_ += static_cast<uint32_t>(result_frames.first.second.size());
	//		}

	//		return result_frames;
	//	}

	//	uint32_t number_frames()
	//	{
	//		return std::max(number_frames_, num_input_frame_);
	//	}

	//	uint32_t num_input_frame()
	//	{
	//		return num_input_frame_;
	//	}

	//	uint32_t num_output_frame()
	//	{
	//		return num_output_frame_;
	//	}

	//	float sample_multiplier()
	//	{
	//		return volume_;
	//	}
	//private:
	//	void update_display_mode(std::shared_ptr<AVFrame> new_frame)
	//	{
	//		std::shared_ptr<av_frame_format> current_frame_format(new av_frame_format(*new_frame));
	//		if (!previously_input_format_ || *previously_input_format_ != *current_frame_format)
	//		{
	//			bool only_change_format = false;
	//			if (previously_input_format_)
	//			{
	//				av_log(nullptr, AV_LOG_INFO, "Frame format has changed. Resetting display mode.");

	//				change_pixel_format_filter_.reset();
	//				if (previously_input_format_->width == current_frame_format->width
	//					&& previously_input_format_->height == current_frame_format->height
	//					&& previously_input_format_->line_sizes == current_frame_format->line_sizes)
	//					only_change_format = true;
	//				else
	//				{
	//					deinterlace_filter_.reset();
	//					highres_from_deinterlace_ = false;
	//					lowres_from_deinterlace_ = false;

	//					change_highres_framerate_filter_.reset();
	//					lowres_from_framerate_ = false;

	//					scale_highres_filter_.reset();

	//					interlace_highres_filter_.reset();

	//					change_lowres_framerate_.reset();

	//					scale_lowres_filter_.reset();

	//					if (draw_lowres_filter_)
	//						last_draw_lowres_filter_frame_ = draw_lowres_filter_->nb_frames();
	//					draw_lowres_filter_.reset();
	//				}
	//			}

	//			if (new_frame->format != AV_PIX_FMT_YUV422P)
	//			{
	//				change_pixel_format_filter_.reset(new filter(new_frame->width, new_frame->height,
	//				{ in_framerate_.den, in_framerate_.num },
	//					in_framerate_,
	//					new_frame->sample_aspect_ratio,
	//					(AVPixelFormat)new_frame->format,
	//					{ AV_PIX_FMT_YUV422P },
	//					""));
	//				if (!change_pixel_format_filter_)
	//					throw gcnew Exception("Failed to create video change pixel format filter");
	//			}

	//			if (!only_change_format)
	//			{
	//				highres_width_ = highresWidth_ ? highresWidth_ : new_frame->width;
	//				highres_height_ = highresHeight_ ? highresHeight_ : new_frame->height;
	//				lowres_width_ = lowresWidth_ ? lowresWidth_ : new_frame->width;
	//				lowres_height_ = lowresHeight_ ? lowresHeight_ : new_frame->height;

	//				bool highresOK = !toHighres_ ||
	//					(
	//						highres_width_ == new_frame->width && highres_height_ == new_frame->height // Video size
	//						&& (highresInterlace_ == !!new_frame->interlaced_frame) // Interlace or progressive
	//						&& ((highresInterlace_ && highresTopFieldFirst_) == (new_frame->interlaced_frame && new_frame->top_field_first)) // Field order
	//						&& (output_framerate_.num == in_framerate_.num && output_framerate_.den == in_framerate_.den) // Frame rate ok
	//						);
	//				bool lowresOK = !toLowres_ ||
	//					(
	//						lowres_width_ == new_frame->width && lowres_height_ == new_frame->height // Video size
	//						&& !new_frame->interlaced_frame // Progressive frame
	//						&& (output_framerate_.num == in_framerate_.num && output_framerate_.den == in_framerate_.den) // Frame rate ok
	//						&& lowresFilter_.empty()
	//						);

	//				AVRational rate_after_framerate;
	//				if (!highresOK)
	//				{
	//					AVRational cur_rate{ in_framerate_.num, in_framerate_.den };
	//					// Deinterlace
	//					if (new_frame->interlaced_frame)
	//					{
	//						deinterlace_filter_.reset(new filter(new_frame->width, new_frame->height,
	//						{ cur_rate.den, cur_rate.num },
	//							cur_rate,
	//							new_frame->sample_aspect_ratio,
	//							AV_PIX_FMT_YUV422P,
	//							{ AV_PIX_FMT_YUV422P },
	//							"yadif=1:-1"));
	//						if (!deinterlace_filter_)
	//							throw gcnew Exception("Failed to create video deinterlace filter");

	//						highres_from_deinterlace_ = true;
	//						cur_rate.num *= 2;
	//					}

	//					// Framerate
	//					AVRational rate_need{ output_framerate_.num, output_framerate_.den };
	//					if (highresInterlace_)
	//						rate_need.num *= 2;
	//					if (cur_rate.num != rate_need.num || cur_rate.den != rate_need.den)
	//					{
	//						std::stringstream filter_str;
	//						filter_str << "framerate=fps=" << rate_need.num << "/" << rate_need.den;

	//						change_highres_framerate_filter_.reset(new filter(new_frame->width, new_frame->height,
	//						{ cur_rate.den, cur_rate.num },
	//							cur_rate,
	//							new_frame->sample_aspect_ratio,
	//							AV_PIX_FMT_YUV422P,
	//							{ AV_PIX_FMT_YUV422P },
	//							filter_str.str()));
	//						if (!change_highres_framerate_filter_)
	//							throw gcnew Exception("Failed to create video framerate filter");

	//						cur_rate = rate_need;
	//						rate_after_framerate = AVRational{ cur_rate.num, cur_rate.den };
	//					}

	//					auto cur_width = new_frame->width;
	//					auto cur_height = new_frame->height;
	//					// Scale
	//					if (cur_width != highres_width_ || cur_height != highres_height_)
	//					{
	//						std::stringstream filter_str;
	//						filter_str << "scale=" << highres_width_ << "x" << highres_height_;
	//						scale_highres_filter_.reset(new filter(new_frame->width, new_frame->height,
	//						{ cur_rate.den, cur_rate.num },
	//							cur_rate,
	//							new_frame->sample_aspect_ratio,
	//							AV_PIX_FMT_YUV422P,
	//							{ AV_PIX_FMT_YUV422P },
	//							filter_str.str()));
	//						if (!scale_highres_filter_)
	//							throw gcnew Exception("Failed to create video scale filter for highres");

	//						cur_width = highres_width_;
	//						cur_height = highres_height_;
	//					}

	//					// Interlace
	//					if (highresInterlace_)
	//					{
	//						AVRational aspect;
	//						av_reduce(&aspect.num, &aspect.den, cur_height * 16, cur_width * 9, 1024 * 1024);
	//						std::stringstream filter_str;
	//						filter_str << "interlace=" << (highresTopFieldFirst_ ? "tff" : "bff");
	//						interlace_highres_filter_.reset(new filter(cur_width, cur_height,
	//						{ cur_rate.den, cur_rate.num },
	//							cur_rate,
	//							aspect,
	//							AV_PIX_FMT_YUV422P,
	//							{ AV_PIX_FMT_YUV422P },
	//							filter_str.str()));
	//						if (!interlace_highres_filter_)
	//							throw gcnew Exception("Failed to create video interlace filter for highres");

	//						cur_rate.num /= 2;
	//					}
	//				}

	//				// Lowres
	//				if (!lowresOK)
	//				{
	//					AVRational cur_rate{ in_framerate_.num, in_framerate_.den };
	//					// Deinterlace
	//					if (new_frame->interlaced_frame)
	//					{
	//						if (!deinterlace_filter_)
	//						{
	//							deinterlace_filter_.reset(new filter(new_frame->width, new_frame->height,
	//							{ cur_rate.den, cur_rate.num },
	//								cur_rate,
	//								new_frame->sample_aspect_ratio,
	//								AV_PIX_FMT_YUV422P,
	//								{ AV_PIX_FMT_YUV422P },
	//								"yadif=1:-1"));
	//							if (!deinterlace_filter_)
	//								throw gcnew Exception("Failed to create video deinterlace filter");
	//						}
	//						lowres_from_deinterlace_ = true;
	//						cur_rate.num *= 2;
	//					}

	//					// Framerate
	//					if (cur_rate.num != output_framerate_.num || cur_rate.den != output_framerate_.den)
	//					{
	//						if ((!deinterlace_filter_ || lowres_from_deinterlace_)
	//							&& change_highres_framerate_filter_
	//							&& output_framerate_.den == rate_after_framerate.den
	//							&& (rate_after_framerate.num % output_framerate_.num) == 0)
	//						{
	//							lowres_from_framerate_ = true;
	//							cur_rate = AVRational{ rate_after_framerate.num, rate_after_framerate.den };
	//						}

	//						if (cur_rate.num != output_framerate_.num || cur_rate.den != output_framerate_.den)
	//						{
	//							std::stringstream filter_str;
	//							filter_str << "framerate=fps=" << output_framerate_.num << "/" << output_framerate_.den;
	//							change_lowres_framerate_.reset(new filter(new_frame->width, new_frame->height,
	//							{ cur_rate.den, cur_rate.num },
	//								cur_rate,
	//								new_frame->sample_aspect_ratio,
	//								AV_PIX_FMT_YUV422P,
	//								{ AV_PIX_FMT_YUV422P },
	//								filter_str.str()));
	//							if (!change_lowres_framerate_)
	//								throw gcnew Exception("Failed to create video framerate filter for lowres");

	//							cur_rate = AVRational{ output_framerate_.num, output_framerate_.den };
	//						}
	//					}

	//					auto cur_width = new_frame->width;
	//					auto cur_height = new_frame->height;
	//					// Scale
	//					if (cur_width != lowres_width_ || cur_height != lowres_height_)
	//					{
	//						std::stringstream filter_str;
	//						filter_str << "scale=" << lowres_width_ << "x" << lowres_height_;
	//						scale_lowres_filter_.reset(new filter(new_frame->width, new_frame->height,
	//						{ cur_rate.den, cur_rate.num },
	//							cur_rate,
	//							new_frame->sample_aspect_ratio,
	//							AV_PIX_FMT_YUV422P,
	//							{ AV_PIX_FMT_YUV422P },
	//							filter_str.str()));
	//						if (!scale_lowres_filter_)
	//							throw gcnew Exception("Failed to create video scale filter for lowres");

	//						cur_width = lowres_width_;
	//						cur_height = lowres_height_;
	//					}

	//					// Draw
	//					if (!lowresFilter_.empty())
	//					{
	//						AVRational aspect;
	//						av_reduce(&aspect.num, &aspect.den, cur_height * 16, cur_width * 9, 1024 * 1024);
	//						draw_lowres_filter_.reset(new filter(cur_width, cur_height,
	//						{ cur_rate.den, cur_rate.num },
	//							cur_rate,
	//							aspect,
	//							AV_PIX_FMT_YUV422P,
	//							{ AV_PIX_FMT_YUV422P },
	//							lowresFilter_));
	//						if (!draw_lowres_filter_)
	//							throw gcnew Exception("Failed to create video draw filter for lowres");
	//						draw_lowres_filter_->nb_frames(last_draw_lowres_filter_frame_);
	//					}
	//				}
	//			}

	//			previously_input_format_ = current_frame_format;
	//		}
	//	}

	//	void push_video_ok(const std::vector<std::shared_ptr<AVFrame>>& out_frames,
	//		std::queue<std::shared_ptr<AVFrame>>& result_highres,
	//		std::queue<std::shared_ptr<AVFrame>>& result_lowres,
	//		bool highresOK, bool lastHighresOK, bool lowresOK, bool lastLowresOK)
	//	{
	//		if (!lastHighresOK && highresOK && toHighres_)
	//		{
	//			for (auto& oframe : out_frames)
	//			{
	//				if (lowresOK)
	//					result_highres.push(oframe);
	//				else
	//				{
	//					std::shared_ptr<AVFrame> cpy(av_frame_clone(oframe.get()), [](AVFrame *p)
	//					{
	//						if (p)
	//							av_frame_free(&p);
	//					});
	//					if (!cpy)
	//						throw gcnew Exception("Failed to clone video frame");
	//					result_highres.push(cpy);
	//				}
	//			}
	//		}

	//		if (!lastLowresOK && lowresOK && toLowres_)
	//		{
	//			for (auto& oframe : out_frames)
	//			{
	//				if (highresOK)
	//					result_lowres.push(oframe);
	//				else
	//				{
	//					std::shared_ptr<AVFrame> cpy(av_frame_clone(oframe.get()), [](AVFrame *p)
	//					{
	//						if (p)
	//							av_frame_free(&p);
	//					});
	//					if (!cpy)
	//						throw gcnew Exception("Failed to clone video frame");
	//					result_lowres.push(cpy);
	//				}
	//			}
	//		}
	//	}

	//	std::pair<std::queue<std::shared_ptr<AVFrame>>, std::queue<std::shared_ptr<AVFrame>>> process_video_frame(std::shared_ptr<AVFrame> in_frame)
	//	{
	//		std::pair<std::queue<std::shared_ptr<AVFrame>>, std::queue<std::shared_ptr<AVFrame>>> result_frames;

	//		bool is_flush = !in_frame;
	//		std::vector<std::shared_ptr<AVFrame>> cur_frames;
	//		if (!is_flush)
	//			cur_frames.push_back(in_frame);

	//		std::queue<std::shared_ptr<filter>> highres_filters;
	//		std::queue<std::shared_ptr<filter>> lowres_filters;
	//		// Change pixel format
	//		if (change_pixel_format_filter_)
	//		{
	//			if (toHighres_)
	//				highres_filters.push(change_pixel_format_filter_);
	//			if (toLowres_)
	//				lowres_filters.push(change_pixel_format_filter_);
	//		}
	//		// Deinterlace
	//		if (deinterlace_filter_)
	//		{
	//			if (toHighres_ && highres_from_deinterlace_)
	//				highres_filters.push(deinterlace_filter_);
	//			if (toLowres_ && lowres_from_deinterlace_)
	//				lowres_filters.push(deinterlace_filter_);
	//		}
	//		// Framerate
	//		if (change_highres_framerate_filter_)
	//		{
	//			highres_filters.push(change_highres_framerate_filter_);
	//			if (toLowres_ && lowres_from_framerate_)
	//				lowres_filters.push(change_highres_framerate_filter_);
	//		}
	//		// Scale highres
	//		if (scale_highres_filter_)
	//			highres_filters.push(scale_highres_filter_);
	//		// Interlace highres
	//		if (interlace_highres_filter_)
	//			highres_filters.push(interlace_highres_filter_);
	//		// Lowres framerate
	//		if (change_lowres_framerate_)
	//			lowres_filters.push(change_lowres_framerate_);
	//		// Lowres scale
	//		if (scale_lowres_filter_)
	//			lowres_filters.push(scale_lowres_filter_);
	//		// Lowres draw
	//		if (draw_lowres_filter_)
	//			lowres_filters.push(draw_lowres_filter_);

	//		bool lastHighresOK = !toHighres_;
	//		bool lastLowresOK = !toLowres_;

	//		bool highresOK = !highres_filters.size();
	//		bool lowresOK = !lowres_filters.size();

	//		if (highresOK != lastHighresOK || lowresOK != lastLowresOK)
	//		{
	//			push_video_ok(cur_frames, result_frames.first, result_frames.second, highresOK, lastHighresOK, lowresOK, lastLowresOK);
	//			lastHighresOK = highresOK;
	//			lastLowresOK = lowresOK;
	//		}

	//		if (!highresOK || !lowresOK)
	//		{
	//			// Change pixel format
	//			if (change_pixel_format_filter_)
	//			{
	//				cur_frames = process_video_filter(change_pixel_format_filter_, cur_frames, is_flush);

	//				if (highres_filters.size() && highres_filters.front() == change_pixel_format_filter_)
	//					highres_filters.pop();
	//				if (lowres_filters.size() && lowres_filters.front() == change_pixel_format_filter_)
	//					lowres_filters.pop();

	//				highresOK = !highres_filters.size();
	//				lowresOK = !lowres_filters.size();
	//				if (highresOK != lastHighresOK || lowresOK != lastLowresOK)
	//				{
	//					push_video_ok(cur_frames, result_frames.first, result_frames.second, highresOK, lastHighresOK, lowresOK, lastLowresOK);
	//					lastHighresOK = highresOK;
	//					lastLowresOK = lowresOK;
	//				}
	//			}

	//			if (!highresOK || !lowresOK)
	//			{
	//				std::vector<std::shared_ptr<AVFrame>> cur_highres_frames;
	//				std::vector<std::shared_ptr<AVFrame>> cur_lowres_frames;

	//				// Deinterlace
	//				if (deinterlace_filter_)
	//				{
	//					// Clone frame first
	//					if (!highres_from_deinterlace_ && !highresOK)
	//					{
	//						for (auto& oframe : cur_frames)
	//						{
	//							std::shared_ptr<AVFrame> cpy(av_frame_clone(oframe.get()), [](AVFrame *p)
	//							{
	//								if (p)
	//									av_frame_free(&p);
	//							});
	//							if (!cpy)
	//								throw gcnew Exception("Failed to clone video frame");
	//							cur_highres_frames.push_back(cpy);
	//						}
	//					}
	//					if (!lowres_from_deinterlace_ && !lowresOK)
	//					{
	//						for (auto& oframe : cur_frames)
	//						{
	//							std::shared_ptr<AVFrame> cpy(av_frame_clone(oframe.get()), [](AVFrame *p)
	//							{
	//								if (p)
	//									av_frame_free(&p);
	//							});
	//							if (!cpy)
	//								throw gcnew Exception("Failed to clone video frame");
	//							cur_lowres_frames.push_back(cpy);
	//						}
	//					}

	//					cur_frames = process_video_filter(deinterlace_filter_, cur_frames, is_flush);

	//					if (highres_filters.size() && highres_filters.front() == deinterlace_filter_)
	//						highres_filters.pop();
	//					if (lowres_filters.size() && lowres_filters.front() == deinterlace_filter_)
	//						lowres_filters.pop();
	//				}

	//				// Highres framerate
	//				if (change_highres_framerate_filter_)
	//				{
	//					// Clone for lowres
	//					if (!lowresOK && !lowres_from_framerate_ && !cur_lowres_frames.size())
	//					{
	//						for (auto& oframe : cur_frames)
	//						{
	//							std::shared_ptr<AVFrame> cpy(av_frame_clone(oframe.get()), [](AVFrame *p)
	//							{
	//								if (p)
	//									av_frame_free(&p);
	//							});
	//							if (!cpy)
	//								throw gcnew Exception("Failed to clone video frame");
	//							cur_lowres_frames.push_back(cpy);
	//						}
	//					}

	//					cur_frames = process_video_filter(change_highres_framerate_filter_, cur_frames, is_flush);
	//					if (highres_filters.size() && highres_filters.front() == change_highres_framerate_filter_)
	//						highres_filters.pop();
	//					if (lowres_filters.size() && lowres_filters.front() == change_highres_framerate_filter_)
	//						lowres_filters.pop();
	//				}

	//				bool push_to_highres = false;
	//				if (!lastHighresOK && !cur_highres_frames.size())
	//				{
	//					push_to_highres = true;
	//					for (auto& oframe : cur_frames)
	//					{
	//						cur_highres_frames.push_back(oframe);
	//					}
	//				}
	//				if (!lastLowresOK && !cur_lowres_frames.size())
	//				{
	//					for (auto& oframe : cur_frames)
	//					{
	//						// Chua push vao highres hoac ca 2 cung xong
	//						if (!push_to_highres
	//							|| (!highres_filters.size() && !lowres_filters.size()))
	//							cur_lowres_frames.push_back(oframe);
	//						else
	//						{
	//							std::shared_ptr<AVFrame> cpy(av_frame_clone(oframe.get()), [](AVFrame *p)
	//							{
	//								if (p)
	//									av_frame_free(&p);
	//							});
	//							if (!cpy)
	//								throw gcnew Exception("Failed to clone video frame");
	//							cur_lowres_frames.push_back(cpy);
	//						}
	//					}
	//				}

	//				// Highres filter
	//				while (highres_filters.size())
	//				{
	//					auto filter = highres_filters.front();
	//					cur_highres_frames = process_video_filter(filter, cur_highres_frames, is_flush);
	//					highres_filters.pop();
	//				}
	//				// Lowres filter
	//				while (lowres_filters.size())
	//				{
	//					auto filter = lowres_filters.front();
	//					cur_lowres_frames = process_video_filter(filter, cur_lowres_frames, is_flush);
	//					lowres_filters.pop();
	//				}

	//				for (auto& oframe : cur_highres_frames)
	//					result_frames.first.push(oframe);
	//				for (auto& oframe : cur_lowres_frames)
	//					result_frames.second.push(oframe);
	//			}
	//		}

	//		return result_frames;
	//	}

	//	std::vector<std::shared_ptr<AVFrame>> process_video_filter(std::shared_ptr<filter> filter, std::vector<std::shared_ptr<AVFrame>> in_frames, bool is_flush = false)
	//	{
	//		if (!filter)
	//			return in_frames;

	//		if (is_flush)
	//			in_frames.push_back(std::shared_ptr<AVFrame>());
	//		std::vector<std::shared_ptr<AVFrame>> result_frames;
	//		for (auto& frame : in_frames)
	//		{
	//			filter->push(frame);
	//			for (auto& av_frame : filter->poll_all())
	//			{
	//				result_frames.push_back(av_frame);
	//			}
	//		}
	//		return result_frames;
	//	}
	//};
#pragma endregion

	class input_file
	{
		const AVRational					output_framerate_;

		const bool							toHighres_;
		const int							highresWidth_;
		const int							highresHeight_;
		const bool							highresInterlace_;
		const bool							highresTopFieldFirst_;

		const bool							toLowres_;
		const int							lowresWidth_;
		const int							lowresHeight_;
		const std::string					lowresFilter_;

		std::shared_ptr<AVFormatContext>	format_ctx_;
		std::shared_ptr<AVCodecContext>		video_codec_ctx_;
		int									video_stream_index_;
		std::shared_ptr<AVCodecContext>		audio_codec_ctx_;
		int									audio_stream_index_;

		AVRational							in_framerate_;

		// Video filter
		std::shared_ptr<av_frame_format>	previously_input_format_;

		int									highres_width_;
		int									highres_height_;
		int									lowres_width_;
		int									lowres_height_;

		std::shared_ptr<filter>				highres_filter_;
		std::shared_ptr<filter>				lowres_filter_;

		int64_t								last_draw_lowres_filter_frame_ = 0;
		std::shared_ptr<filter>				draw_lowres_filter_;

		uint32_t							number_frames_;
		uint32_t							num_input_frame_;
		uint32_t							num_output_frame_;

		// Audio convert
		std::shared_ptr<SwrContext>			swr_;
		float								volume_ = 1.0;

		bool								is_eof_;
	public:
		input_file(std::string file, AVRational output_framerate, float minVolume, float maxVolume,
			bool toHighres, int highresWidth, int highresHeight, bool highresInterlace, bool highresTopFieldFirst,
			bool toLowres, int lowresWidth, int lowresHeight, const std::string& lowresFilter)
			: output_framerate_({ output_framerate.num, output_framerate.den })
			, toHighres_(toHighres)
			, highresWidth_(highresWidth)
			, highresHeight_(highresHeight)
			, highresInterlace_(highresInterlace)
			, highresTopFieldFirst_(highresTopFieldFirst)
			, toLowres_(toLowres)
			, lowresWidth_(lowresWidth)
			, lowresHeight_(lowresHeight)
			, lowresFilter_(lowresFilter)
		{
			if (!toHighres && !toLowres)
				throw gcnew Exception("Don't output to highres or lowres");

			if (toHighres_)
			{
				if (highresWidth_ < 0 && highresWidth_ != -1)
					throw gcnew Exception("Highres width invalid");

				if (highresHeight_ < 0 && highresHeight_ != -1)
					throw gcnew Exception("Highres height invalid");

				if (highresWidth_ == -1 && highresHeight_ == -1)
					throw gcnew Exception("Highres size invalid");
			}

			if (toLowres_)
			{
				if (lowresWidth_ < 0 && lowresWidth_ != -1)
					throw gcnew Exception("Lowres width invalid");

				if (lowresHeight_ < 0 && lowresHeight_ != -1)
					throw gcnew Exception("Lowres height invalid");

				if (lowresWidth_ == -1 && lowresHeight_ == -1)
					throw gcnew Exception("Lowres size invalid");
			}

			AVFormatContext *weak_context = nullptr;
			if (avformat_open_input(&weak_context, file.c_str(), nullptr, nullptr) < 0)
				throw gcnew Exception("Failed to open input file");
			format_ctx_.reset(weak_context, [](AVFormatContext *p)
			{
				avformat_close_input(&p);
			});
			if (avformat_find_stream_info(format_ctx_.get(), nullptr))
				throw gcnew Exception("Failed to find input stream info");

			AVCodec *decoder = NULL;

			// Video stream
			video_stream_index_ = av_find_best_stream(format_ctx_.get(), AVMEDIA_TYPE_VIDEO, -1, -1, NULL, 0);
			if (video_stream_index_ < 0)
				throw gcnew Exception("Video stream not found");
			auto vstream = format_ctx_->streams[video_stream_index_];
			decoder = avcodec_find_decoder(vstream->codecpar->codec_id);
			if (!decoder)
				throw gcnew Exception("Failed to find decoder for video stream");
			video_codec_ctx_.reset(avcodec_alloc_context3(decoder), [](AVCodecContext *p)
			{
				if (p)
					avcodec_free_context(&p);
			});
			if (!video_codec_ctx_)
				throw gcnew Exception("Failed to allocate the decoder context for video stream");
			if (avcodec_parameters_to_context(video_codec_ctx_.get(), vstream->codecpar) < 0)
				throw gcnew Exception("Failed to copy decoder parameters to input decoder context");
			video_codec_ctx_->framerate = av_guess_frame_rate(format_ctx_.get(), vstream, NULL);
			if (avcodec_open2(video_codec_ctx_.get(), decoder, nullptr) < 0)
				throw gcnew Exception("Failed to open decoder for video stream");
			av_reduce(&in_framerate_.num, &in_framerate_.den, vstream->r_frame_rate.num, vstream->r_frame_rate.den, 1024 * 1024);
			number_frames_ = static_cast<uint32_t>(vstream->duration);

			// Audio stream
			decoder = NULL;
			audio_stream_index_ = av_find_best_stream(format_ctx_.get(), AVMEDIA_TYPE_AUDIO, -1, -1, NULL, 0);
			if (audio_stream_index_ < 0)
				throw gcnew Exception("Audio stream not found");
			auto astream = format_ctx_->streams[audio_stream_index_];
			decoder = avcodec_find_decoder(astream->codecpar->codec_id);
			if (!decoder)
				throw gcnew Exception("Failed to find decoder for audio stream");
			audio_codec_ctx_.reset(avcodec_alloc_context3(decoder), [](AVCodecContext *p)
			{
				if (p)
					avcodec_free_context(&p);
			});
			if (!audio_codec_ctx_)
				throw gcnew Exception("Failed to allocate the decoder context for audio stream");
			if (avcodec_parameters_to_context(audio_codec_ctx_.get(), astream->codecpar) < 0)
				throw gcnew Exception("Failed to copy decoder parameters to input decoder context");
			if (avcodec_open2(audio_codec_ctx_.get(), decoder, nullptr) < 0)
				throw gcnew Exception("Failed to open decoder for audio stream");

			av_dump_format(format_ctx_.get(), 0, file.c_str(), 0);

			// Detect volume
			if (maxVolume != 0.0)
			{
				if (minVolume == 0 || minVolume >= maxVolume)
					minVolume = -40;

				weak_context = nullptr;
				if (avformat_open_input(&weak_context, file.c_str(), nullptr, nullptr) < 0)
					throw gcnew Exception("Failed to open input file to detect volume");
				std::shared_ptr<AVFormatContext> tmp_context(weak_context, [](AVFormatContext *p)
				{
					avformat_close_input(&p);
				});
				if (avformat_find_stream_info(tmp_context.get(), nullptr))
					throw gcnew Exception("Failed to find input to detect volume stream info");

				decoder = NULL;
				auto tmp_astream = tmp_context->streams[audio_stream_index_];
				decoder = avcodec_find_decoder(tmp_astream->codecpar->codec_id);
				if (!decoder)
					throw gcnew Exception("Failed to find decoder for audio stream for detect volume");
				std::shared_ptr<AVCodecContext> tmp_audio_codec_ctx(avcodec_alloc_context3(decoder), [](AVCodecContext*p)
				{
					if (p)
						avcodec_free_context(&p);
				});
				if (!tmp_audio_codec_ctx)
					throw gcnew Exception("Failed to allocate the decoder context for audio stream for detect volume");
				if (avcodec_parameters_to_context(tmp_audio_codec_ctx.get(), tmp_astream->codecpar) < 0)
					throw gcnew Exception("Failed to copy decoder parameters to input decoder context for detect volume");
				if (avcodec_open2(tmp_audio_codec_ctx.get(), decoder, nullptr) < 0)
					throw gcnew Exception("Failed to open decoder for audio stream for detect volume");
				int64_t layout = tmp_audio_codec_ctx->channel_layout;
				if (layout == 0)
					layout = av_get_default_channel_layout(tmp_audio_codec_ctx->channels);
				std::shared_ptr<SwrContext> tmp_swr_(swr_alloc_set_opts(NULL,
					AV_CH_LAYOUT_MONO, AV_SAMPLE_FMT_S16, tmp_audio_codec_ctx->sample_rate,
					layout, tmp_audio_codec_ctx->sample_fmt, tmp_audio_codec_ctx->sample_rate, 0, nullptr), [](SwrContext *p)
				{
					if (p)
						swr_free(&p);
				});
				if (!tmp_swr_)
					throw gcnew Exception("Failed to allocate the swresample for detect volume");
				if (swr_init(tmp_swr_.get()) < 0)
					throw gcnew Exception("Failed to init the swresample for detect volume");

				int16_t max_sample = 0;
				std::vector<int16_t> last_samples;
				while (true)
				{
					std::shared_ptr<AVPacket> pkt(av_packet_alloc(), [](AVPacket *p)
					{
						av_packet_free(&p);
					});
					pkt->size = 0;
					pkt->data = NULL;
					av_init_packet(pkt.get());
					if (av_read_frame(tmp_context.get(), pkt.get()) >= 0)
					{
						if (pkt->stream_index == audio_stream_index_)
						{
							auto size = pkt->size;
							auto data = pkt->data;
							pkt = std::shared_ptr<AVPacket>(pkt.get(), [pkt, size, data](AVPacket*)
							{
								pkt->size = size;
								pkt->data = data;
							});
							avcodec_send_packet(tmp_audio_codec_ctx.get(), pkt.get());
							while (true)
							{
								std::shared_ptr<AVFrame> frame(av_frame_alloc(), [](AVFrame *p)
								{
									if (p)
										av_frame_free(&p);
								});
								if (!frame)
									throw gcnew Exception("Failed to create frame to decode audio");
								if (avcodec_receive_frame(tmp_audio_codec_ctx.get(), frame.get()) < 0)
									break;
								const uint8_t **in = const_cast<const uint8_t**>(frame->extended_data);
								std::vector<int16_t> out_samples(frame->nb_samples); // 1 channels
								uint8_t* out[] = { reinterpret_cast<uint8_t*>(out_samples.data()) };
								const auto channel_samples = swr_convert(
									tmp_swr_.get(),
									out,
									frame->nb_samples,
									in,
									frame->nb_samples);
								if (channel_samples > 0)
								{
									out_samples.resize(channel_samples, 0);
									if (!last_samples.empty())
									{
										for (auto sample : last_samples)
											max_sample = std::max(max_sample, (int16_t)std::abs(sample));
									}
									last_samples = std::move(out_samples);
								}
							}
						}
					}
					else
						break;
				}

				float dbFS = 20 * std::log10(static_cast<float>(max_sample) / static_cast<float>(std::numeric_limits<int16_t>::max()));
				if (dbFS > minVolume && std::abs(dbFS - maxVolume) > 1.0f)
				{
					auto maxSampleNeed = static_cast<int16_t>(std::pow(10, maxVolume / 20.0f) * static_cast<float>(std::numeric_limits<int16_t>::max() + 0.5));
					volume_ = static_cast<float>(maxSampleNeed) / static_cast<float>(max_sample);
				}
			}

			is_eof_ = false;
			num_input_frame_ = 0;
			num_output_frame_ = 0;
		}

		bool is_eof()
		{
			return is_eof_;
		}

		// Video Highres, Video Lowres, Audio
		std::pair<std::pair<std::queue<std::shared_ptr<AVFrame>>, std::queue<std::shared_ptr<AVFrame>>>, std::queue<std::vector<int16_t>>> try_get_frame()
		{
			if (is_eof_)
				return std::pair<std::pair<std::queue<std::shared_ptr<AVFrame>>, std::queue<std::shared_ptr<AVFrame>>>, std::queue<std::vector<int16_t>>>();

			std::shared_ptr<AVPacket> pkt(av_packet_alloc(), [](AVPacket *p)
			{
				av_packet_free(&p);
			});
			pkt->size = 0;
			pkt->data = NULL;
			av_init_packet(pkt.get());
			if (av_read_frame(format_ctx_.get(), pkt.get()) < 0)
				is_eof_ = true;

			std::shared_ptr<AVPacket> vpacket;
			std::shared_ptr<AVPacket> apacket;
			if (!is_eof_)
			{
				auto size = pkt->size;
				auto data = pkt->data;
				if (pkt->stream_index == video_stream_index_)
				{
					vpacket = std::shared_ptr<AVPacket>(pkt.get(), [pkt, size, data](AVPacket*)
					{
						pkt->size = size;
						pkt->data = data;
					});
				}
				else if (pkt->stream_index == audio_stream_index_)
				{
					apacket = std::shared_ptr<AVPacket>(pkt.get(), [pkt, size, data](AVPacket*)
					{
						pkt->size = size;
						pkt->data = data;
					});
				}
			}

			std::pair<std::pair<std::queue<std::shared_ptr<AVFrame>>, std::queue<std::shared_ptr<AVFrame>>>, std::queue<std::vector<int16_t>>> result_frames;

			// Decode video
			if (is_eof_ || vpacket)
			{
				avcodec_send_packet(video_codec_ctx_.get(), vpacket.get());
				while (true)
				{
					std::shared_ptr<AVFrame> frame(av_frame_alloc(), [](AVFrame *p)
					{
						if (p)
							av_frame_free(&p);
					});
					if (!frame)
						throw gcnew Exception("Failed to create frame to decode video");
					if (avcodec_receive_frame(video_codec_ctx_.get(), frame.get()) < 0)
						break;

					num_input_frame_++;

					frame->pts = av_frame_get_best_effort_timestamp(frame.get());
					update_display_mode(frame);

					auto video_frames = process_video_frame(frame);
					while (video_frames.first.size() > 0)
					{
						auto oframe = video_frames.first.front();
						video_frames.first.pop();
						result_frames.first.first.push(oframe);
					}
					while (video_frames.second.size() > 0)
					{
						auto oframe = video_frames.second.front();
						video_frames.second.pop();
						result_frames.first.second.push(oframe);
					}
				}
			}

			// Decode audio
			if (is_eof_ || apacket)
			{
				avcodec_send_packet(audio_codec_ctx_.get(), apacket.get());
				while (true)
				{
					std::shared_ptr<AVFrame> frame(av_frame_alloc(), [](AVFrame *p)
					{
						if (p)
							av_frame_free(&p);
					});
					if (!frame)
						throw gcnew Exception("Failed to create frame to decode audio");
					if (avcodec_receive_frame(audio_codec_ctx_.get(), frame.get()) < 0)
						break;

					if (!swr_)
					{
						int in_channels = frame->channels;
						int64_t in_layout = frame->channel_layout;
						if (in_layout == 0)
							in_layout = av_get_default_channel_layout(in_channels);

						swr_.reset(swr_alloc_set_opts(NULL, AV_CH_LAYOUT_STEREO, AV_SAMPLE_FMT_S16, 48000,
							in_layout, (AVSampleFormat)frame->format, frame->sample_rate, 0, NULL), [](SwrContext *p)
						{
							if (p)
								swr_free(&p);
						});
						if (!swr_)
							throw gcnew Exception("Failed to create swresample");
						if (swr_init(swr_.get()) < 0)
							throw gcnew Exception("Failed to init swresample");
					}

					const uint8_t **in = const_cast<const uint8_t**>(frame->extended_data);
					int max_out_samples = frame->nb_samples * 2;
					std::vector<int16_t> out_samples(max_out_samples * 2); // 2 channels
					uint8_t* out[] = { reinterpret_cast<uint8_t*>(out_samples.data()) };
					const auto channel_samples = swr_convert(
						swr_.get(),
						out,
						max_out_samples,
						in,
						frame->nb_samples);
					if (channel_samples > 0)
					{
						out_samples.resize(channel_samples * 2, 0); // 2 channel
						result_frames.second.push(out_samples);
					}
				}
			}

			if (is_eof_)
			{
				auto video_frames = process_video_frame(std::shared_ptr<AVFrame>());
				while (video_frames.first.size() > 0)
				{
					auto oframe = video_frames.first.front();
					video_frames.first.pop();
					result_frames.first.first.push(oframe);
				}
				while (video_frames.second.size() > 0)
				{
					auto oframe = video_frames.second.front();
					video_frames.second.pop();
					result_frames.first.second.push(oframe);
				}
			}

			if (toHighres_)
			{
				if (result_frames.first.first.size())
					num_output_frame_ += static_cast<uint32_t>(result_frames.first.first.size());
			}
			else if (toLowres_)
			{
				if (result_frames.first.second.size())
					num_output_frame_ += static_cast<uint32_t>(result_frames.first.second.size());
			}

			return result_frames;
		}

		uint32_t number_frames()
		{
			return std::max(number_frames_, num_input_frame_);
		}

		uint32_t num_input_frame()
		{
			return num_input_frame_;
		}

		uint32_t num_output_frame()
		{
			return num_output_frame_;
		}

		float sample_multiplier()
		{
			return volume_;
		}
	private:
		void update_display_mode(std::shared_ptr<AVFrame> new_frame)
		{
			std::shared_ptr<av_frame_format> current_frame_format(new av_frame_format(*new_frame));
			if (!previously_input_format_ || *previously_input_format_ != *current_frame_format)
			{
				if (previously_input_format_)
				{
					av_log(nullptr, AV_LOG_INFO, "Frame format has changed. Resetting display mode.");

					highres_filter_.reset();
					lowres_filter_.reset();
					if (draw_lowres_filter_)
						last_draw_lowres_filter_frame_ = draw_lowres_filter_->nb_frames();
					draw_lowres_filter_.reset();
				}

				AVRational sample_aspect_ratio{ new_frame->sample_aspect_ratio.num, new_frame->sample_aspect_ratio.den };
				if (sample_aspect_ratio.num == 0 || sample_aspect_ratio.den == 0)
					sample_aspect_ratio.num = sample_aspect_ratio.den = 1;

				if (toHighres_)
				{
					highres_width_ = highresWidth_ ? highresWidth_ : new_frame->width;
					highres_height_ = highresHeight_ ? highresHeight_ : new_frame->height;
					if (highres_width_ == -1)
						highres_width_ = static_cast<int>(std::ceil(highres_height_ * new_frame->width * av_q2d(sample_aspect_ratio) / new_frame->height));
					if (highres_height_ == -1)
						highres_height_ = static_cast<int>(std::ceil(highres_width_ * new_frame->height / av_q2d(sample_aspect_ratio) / new_frame->width));

					bool needConvertImage = highres_width_ != new_frame->width || highres_height_ != new_frame->height
						|| highresInterlace_ != (!!new_frame->interlaced_frame)
						|| ((highresInterlace_ && highresTopFieldFirst_) != (new_frame->interlaced_frame && new_frame->top_field_first))
						|| output_framerate_.num != in_framerate_.num
						|| output_framerate_.den != in_framerate_.den;

					std::stringstream filter_str;
					bool has_filter = false;
					if (needConvertImage)
					{
						AVRational cur_rate{ in_framerate_.num, in_framerate_.den };
						
						// Deinterlace
						if (new_frame->interlaced_frame)
						{
							filter_str << "yadif=1:-1";
							cur_rate.num *= 2;
							av_reduce(&cur_rate.num, &cur_rate.den, cur_rate.num, cur_rate.den, 1025 * 1024);
							has_filter = true;
						}

						// framerate
						AVRational rate_need{ output_framerate_.num, output_framerate_.den };
						if (highresInterlace_)
						{
							rate_need.num *= 2;
							av_reduce(&rate_need.num, &rate_need.den, rate_need.num, rate_need.den, 1024 * 1024);
						}

						if (cur_rate.num != rate_need.num || cur_rate.den != rate_need.den)
						{
							if (has_filter)
								filter_str << ",";
							filter_str << "framerate=fps=" << rate_need.num << "/" << rate_need.den;
							has_filter = true;
							cur_rate = rate_need;
						}

						// Scale
						if (new_frame->width != highres_width_ || new_frame->height != highres_height_)
						{
							if (has_filter)
								filter_str << ",";
							filter_str << "scale=" << highres_width_ << "x" << highres_height_;
							has_filter = true;
						}

						// Interlace
						if (highresInterlace_)
						{
							if (has_filter)
								filter_str << ",";
							filter_str << "interlace=" << (highresTopFieldFirst_ ? "tff" : "bff");
							cur_rate.num /= 2;
							av_reduce(&cur_rate.num, &cur_rate.den, cur_rate.num, cur_rate.den, 1024 * 1024);
							has_filter = true;
						}
					}

					if (has_filter || new_frame->format != AV_PIX_FMT_YUV422P)
					{
						highres_filter_.reset(new filter(new_frame->width, new_frame->height,
							{ in_framerate_.den, in_framerate_.num },
							in_framerate_,
							sample_aspect_ratio,
							(AVPixelFormat)new_frame->format,
							{ AV_PIX_FMT_YUV422P },
							filter_str.str()));
						if (!highres_filter_)
							throw gcnew Exception("Failed to create video filter for highres");
					}
				}

				if (toLowres_)
				{
					lowres_width_ = lowresWidth_ ? lowresWidth_ : new_frame->width;
					lowres_height_ = lowresHeight_ ? lowresHeight_ : new_frame->height;
					if (lowres_width_ == -1)
						lowres_width_ = static_cast<int>(std::ceil(lowres_height_ * new_frame->width * av_q2d(sample_aspect_ratio) / new_frame->height));
					if (lowres_height_ == -1)
						lowres_height_ = static_cast<int>(std::ceil(lowres_width_ * new_frame->height / av_q2d(sample_aspect_ratio) / new_frame->width));

					bool needConvertImage = lowres_width_ != new_frame->width || lowres_height_ != new_frame->height
						|| new_frame->interlaced_frame
						|| output_framerate_.num != in_framerate_.num
						|| output_framerate_.den != in_framerate_.den;

					std::stringstream filter_str;
					bool has_filter = false;

					if (needConvertImage)
					{
						// Deinterlace
						AVRational cur_rate{ in_framerate_.num, in_framerate_.den };
						if (new_frame->interlaced_frame)
						{
							filter_str << "yadif=1:-1";
							cur_rate.num *= 2;
							av_reduce(&cur_rate.num, &cur_rate.den, cur_rate.num, cur_rate.den, 1025 * 1024);
							has_filter = true;
						}

						// framerate
						if (cur_rate.num != output_framerate_.num || cur_rate.den != output_framerate_.den)
						{
							if (has_filter)
								filter_str << ",";
							filter_str << "framerate=fps=" << output_framerate_.num << "/" << output_framerate_.den;
							has_filter = true;
							cur_rate = output_framerate_;
						}

						// Scale
						if (new_frame->width != lowres_width_ || new_frame->height != lowres_height_)
						{
							if (has_filter)
								filter_str << ",";
							filter_str << "scale=" << lowres_width_ << "x" << lowres_height_;
							has_filter = true;
						}
					}

					if (has_filter || new_frame->format != AV_PIX_FMT_YUV422P)
					{
						lowres_filter_.reset(new filter(new_frame->width, new_frame->height,
						{ in_framerate_.den, in_framerate_.num },
							in_framerate_,
							sample_aspect_ratio,
							(AVPixelFormat)new_frame->format,
							{ AV_PIX_FMT_YUV422P },
							filter_str.str()));
						if (!lowres_filter_)
							throw gcnew Exception("Failed to create video filter for lowres");
					}

					// Overlay
					if (!lowresFilter_.empty())
					{
						AVRational aspect;
						av_reduce(&aspect.num, &aspect.den, new_frame->width * sample_aspect_ratio.num, new_frame->height * sample_aspect_ratio.den, 1024 * 1024);
						av_reduce(&aspect.num, &aspect.den, lowres_height_ * aspect.num, lowres_width_ * aspect.den, 1024 * 1024);
						draw_lowres_filter_.reset(new filter(lowres_width_, lowres_height_,
							{ output_framerate_.den, output_framerate_.num },
							output_framerate_,
							aspect,
							AV_PIX_FMT_YUV422P,
							{ AV_PIX_FMT_YUV422P },
							lowresFilter_));
						if (!draw_lowres_filter_)
							throw gcnew Exception("Failed to create video draw filter for lowres");
						draw_lowres_filter_->nb_frames(last_draw_lowres_filter_frame_);
					}
				}

				previously_input_format_ = current_frame_format;
			}
		}

		void push_video_ok(const std::vector<std::shared_ptr<AVFrame>>& out_frames,
			std::queue<std::shared_ptr<AVFrame>>& result_highres,
			std::queue<std::shared_ptr<AVFrame>>& result_lowres,
			bool highresOK, bool lastHighresOK, bool lowresOK, bool lastLowresOK)
		{
			if (!lastHighresOK && highresOK && toHighres_)
			{
				for (auto& oframe : out_frames)
				{
					if (lowresOK)
						result_highres.push(oframe);
					else
					{
						std::shared_ptr<AVFrame> cpy(av_frame_clone(oframe.get()), [](AVFrame *p)
						{
							if (p)
								av_frame_free(&p);
						});
						if (!cpy)
							throw gcnew Exception("Failed to clone video frame");
						result_highres.push(cpy);
					}
				}
			}

			if (!lastLowresOK && lowresOK && toLowres_)
			{
				for (auto& oframe : out_frames)
				{
					if (highresOK)
						result_lowres.push(oframe);
					else
					{
						std::shared_ptr<AVFrame> cpy(av_frame_clone(oframe.get()), [](AVFrame *p)
						{
							if (p)
								av_frame_free(&p);
						});
						if (!cpy)
							throw gcnew Exception("Failed to clone video frame");
						result_lowres.push(cpy);
					}
				}
			}
		}

		std::pair<std::queue<std::shared_ptr<AVFrame>>, std::queue<std::shared_ptr<AVFrame>>> process_video_frame(std::shared_ptr<AVFrame> in_frame)
		{
			std::pair<std::queue<std::shared_ptr<AVFrame>>, std::queue<std::shared_ptr<AVFrame>>> result_frames;

			bool is_flush = !in_frame;
			std::vector<std::shared_ptr<AVFrame>> cur_frames;
			if (!is_flush)
				cur_frames.push_back(in_frame);

			bool lastHighresOK = !toHighres_;
			bool lastLowresOK = !toLowres_;

			bool highresOK = !highres_filter_;
			bool lowresOK = !lowres_filter_ && !draw_lowres_filter_;

			if (highresOK != lastHighresOK || lowresOK != lastLowresOK)
			{
				push_video_ok(cur_frames, result_frames.first, result_frames.second, highresOK, lastHighresOK, lowresOK, lastLowresOK);
				lastHighresOK = highresOK;
				lastLowresOK = lowresOK;
			}

			if (!highresOK || !lowresOK)
			{
				if (!highresOK || !lowresOK)
				{
					std::vector<std::shared_ptr<AVFrame>> cur_highres_frames;
					std::vector<std::shared_ptr<AVFrame>> cur_lowres_frames;
					
					if (!highresOK && !lowresOK)
					{
						for (auto& frame : cur_frames)
						{
							std::shared_ptr<AVFrame> cpy(av_frame_clone(frame.get()), [](AVFrame *p)
							{
								if (p)
									av_frame_free(&p);
							});
							if (!cpy)
								throw gcnew Exception("Failed to clone video frame");
							cur_lowres_frames.push_back(cpy);
							cur_highres_frames.push_back(frame);
						}
					}
					else if (!highresOK)
						cur_highres_frames = cur_frames;
					else
						cur_lowres_frames = cur_frames;

					if (!highresOK)
					{
						cur_highres_frames = process_video_filter(highres_filter_, cur_highres_frames, is_flush);
						for (auto& oframe : cur_highres_frames)
							result_frames.first.push(oframe);
					}

					if (!lowresOK)
					{
						cur_lowres_frames = process_video_filter(lowres_filter_, cur_lowres_frames, is_flush);
						cur_lowres_frames = process_video_filter(draw_lowres_filter_, cur_lowres_frames, is_flush);
						for (auto& oframe : cur_lowres_frames)
							result_frames.second.push(oframe);
					}
				}
			}

			return result_frames;
		}

		std::vector<std::shared_ptr<AVFrame>> process_video_filter(std::shared_ptr<filter> filter, std::vector<std::shared_ptr<AVFrame>> in_frames, bool is_flush = false)
		{
			if (!filter)
				return in_frames;

			if (is_flush)
				in_frames.push_back(std::shared_ptr<AVFrame>());
			std::vector<std::shared_ptr<AVFrame>> result_frames;
			for (auto& frame : in_frames)
			{
				filter->push(frame);
				for (auto& av_frame : filter->poll_all())
				{
					result_frames.push_back(av_frame);
				}
			}
			return result_frames;
		}
	};

	static void inf_printf(const char *fmt, ...)
	{
		va_list marker;
		va_start(marker, fmt);
		char lst[2048];
		vsprintf(lst, fmt, marker);
		add_log(std::string("[mainconcept] ") + lst);
		va_end(marker);
	}

	static void err_printf(const char *fmt, ...)
	{
		va_list marker;
		va_start(marker, fmt);
		char lst[2048];
		vsprintf(lst, fmt, marker);
		add_log(std::string("[mainconcept] [error] ") + lst);
		va_end(marker);
	}

	static void wrn_printf(const char *fmt, ...)
	{
		va_list marker;
		va_start(marker, fmt);
		char lst[2048];
		vsprintf(lst, fmt, marker);
		std::string str(lst);
		if (str.rfind("M104:Video MB") != 0)
		{
			add_log(std::string("[mainconcept] [warning] ") + str);
		}
		va_end(marker);
	}

	static void progress_printf(int32_t percent, const char * fmt, ...)
	{
		char lst[256];
		va_list marker;

		va_start(marker, fmt);
		vsnprintf(lst, sizeof(lst), fmt, marker);
		va_end(marker);

		add_log(std::string("[mainconcept] ") + lst);
	}

	static void *mc_get_rc(const char *name)
	{
		if (!strcmp(name, "err_printf"))
			return (void*)err_printf;
		else if (!strcmp(name, "prg_printf"))
			return (void*)progress_printf;
		else if (!strcmp(name, "wrn_printf"))
			return (void*)wrn_printf;
		else if (!strcmp(name, "inf_printf"))
			return (void*)inf_printf;
		return NULL;
	}

#define MXF_SAMPLE_CHUNK_SIZE	120000
#define DEFAULT_BUF_SIZE	18000000

	class output_file
	{
		std::shared_ptr<mxf_muxer_tt> muxer_;
		std::shared_ptr<bufstream_tt> fstream_;
		std::shared_ptr<bufstream_tt> fseek_;

		std::shared_ptr<mpegvenc_tt>	video_encoder_;
		std::shared_ptr<fifo_stream_tt> video_fifo_;
		std::vector<uint8_t>			video_buffer_;

		std::shared_ptr<fifo_stream_tt> audio_fifo_;
	public:
		output_file(std::wstring file, AVRational framerate, int width, int height, int gopN, int gopM, int closeGop, bool interlace, bool top_field_first, bool is_420, int bitrate)
		{
			static std::map<double, std::pair<uint32_t, int>> support_fps{ std::make_pair(23.98, std::make_pair(FRAMERATE23, 0)), // NTSC 24000 /  1001
				std::make_pair(24.0, std::make_pair(FRAMERATE24, 1)), // Standard international cinema
				std::make_pair(25.0, std::make_pair(FRAMERATE25, 1)), // PAL 25fps
				std::make_pair(29.97, std::make_pair(FRAMERATE29, 0)), // NTSC 30000 / 1001
				std::make_pair(30, std::make_pair(FRAMERATE30, 0)), // NTSC 30
				std::make_pair(50, std::make_pair(FRAMERATE50, 1)), // PAL 50
				std::make_pair(59.94, std::make_pair(FRAMERATE59, 0)), // NTSC 60000 / 1001
				std::make_pair(60, std::make_pair(FRAMERATE60, 0)), // NTSC 60
				std::make_pair(48, std::make_pair(FRAMERATE48, 1)) }; // DCI

			uint32_t framerate_code = FRAMERATE0;
			int isPAL = 0;
			auto fps = std::round(av_q2d(framerate) * 100.0) / 100.0;
			auto fps_code = support_fps.find(fps);
			if (fps_code != support_fps.end())
			{
				framerate_code = fps_code->second.first;
				isPAL = fps_code->second.second;
			}

			// Muxer
			mxf_m_settings mux_set{ 0 };
			mxfMuxDefaults(&mux_set, MCPROFILE_DEFAULT);
			mux_set.video_framerate = framerate_code;
			mux_set.profile = MXF_PROF_DEFAULT;
			mux_set.mplex_type = MXF_MUX_TYPE_DEFAULT;
			mux_set.operational_pattern = OPERATIONAL_PATTERN_OP1A;

			// set product info for header meta data Identifications Set
			mxf_product_info prod_info;
			memset(&prod_info, 0, sizeof(mxf_product_info));

			const uint8_t DummyProductUIDKey[16] = { 0x06, 0x0e, 0x2b, 0x34, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00 };

			prod_info.size = sizeof(mxf_product_info);
			// mind the terminating 0 for the strings length
			sprintf(prod_info.company_name, "HDVietNam");
			sprintf(prod_info.product_name, "HDConvert");
			sprintf(prod_info.product_version, "1.0.0.0");
			memcpy(&prod_info.productUID, DummyProductUIDKey, 16);

			mux_set.product_info = &prod_info;

			mux_set.flags |= MXF_MUX_FLAG_INCR_INDEX_WRITE;

			std::shared_ptr<bufstream_tt> fst(open_file_buf_write(file.c_str(), MXF_SAMPLE_CHUNK_SIZE, NULL), [](bufstream_tt *p)
			{
				if (p)
					close_file_buf(p, 0);
			});
			if (!fst)
				throw gcnew Exception("Failed to create output file");
			fstream_.reset(fst.get(), [fst](bufstream_tt*) {});

			std::shared_ptr<bufstream_tt> fs(bseek_open_file_buf(fstream_.get(), NULL), [fst](bufstream_tt *p)
			{
				if (p)
					bseek_close_file_buf(p, 0);
			});
			if (!fs)
				throw gcnew Exception("Failed to create output file seek");
			fseek_.reset(fs.get(), [fs](bufstream_tt*) {});

			std::shared_ptr<mxf_muxer_tt> mux(mxfMuxNew(mc_get_rc, &mux_set), [fs](mxf_muxer_tt *p)
			{
				if (p)
				{
					mxfMuxDone(p, 0);
					mxfMuxFree(p);
				}
			});
			if (!mux)
				throw gcnew Exception("Failed to create mxf muxer");
			muxer_.reset(mux.get(), [mux](mxf_muxer_tt*) {});

			if (mxfMuxAddOutputStream(muxer_.get(), NULL, fseek_.get()))
				throw gcnew Exception("Failed to add mxf output stream");

			// Video
			mpeg_v_settings v_settings{ 0 };
			mpegOutVideoDefaults(&v_settings, MPEG_MPEG2, isPAL);
			v_settings.def_horizontal_size = width;
			v_settings.def_vertical_size = height;
			v_settings.aspectratio = 3;
			v_settings.max_bit_rate = bitrate;
			v_settings.avg_bit_rate = v_settings.max_bit_rate / 1.2;
			v_settings.min_bit_rate = v_settings.avg_bit_rate / 1.2;
			v_settings.frame_rate = av_q2d(framerate);
			v_settings.frame_rate_code = -1;
			v_settings.N = v_settings.min_N = gopN;
			v_settings.M = gopM;
			v_settings.ClosedGOP_Interval = closeGop;
			v_settings.level = LEVEL_HIGH;
			if (is_420)
			{
				v_settings.chroma_format = CHROMA420;
				v_settings.profile = PROFILE_MAIN;
			}
			else
			{
				v_settings.chroma_format = CHROMA422;
				v_settings.profile = PROFILE_422;
			}
			int size = av_image_get_buffer_size(AV_PIX_FMT_YUV422P, width, height, 1);
			video_buffer_.resize(size, 0);

			v_settings.color_primaries = AVColorPrimaries::AVCOL_PRI_BT709;
			v_settings.prog_frame = interlace ? 0 : 1;
			v_settings.topfirst = top_field_first ? 1 : 0;
			mpegOutVideoPerformance(&v_settings, PERF_OFFLINE, 31, 0);
			if (mpegOutVideoChkSettings(mc_get_rc, &v_settings, NULL, NULL))
				throw gcnew Exception("MPEG2 Video encoder setting error");

			std::shared_ptr<fifo_stream_tt> vst(new_fifo_buf(DEFAULT_BUF_SIZE, MXF_SAMPLE_CHUNK_SIZE), [mux](fifo_stream_tt *p)
			{
				if (p)
					free_fifo_buf(p);
			});
			if (!vst)
				throw gcnew Exception("Failed to create video fifo stream");
			video_fifo_.reset(vst.get(), [vst](fifo_stream_tt*) {});

			std::shared_ptr<mpegvenc_tt> ven(mpegOutVideoNew(mc_get_rc, &v_settings, 0, 0xFFFFFFFF, 0, 0), [vst](mpegvenc_tt *p)
			{
				if (p)
				{
					mpegOutVideoDone(p, 0);
					mpegOutVideoFree(p);
				}
			});
			if (!ven)
				throw gcnew Exception("Failed to create video encoder");
			video_encoder_.reset(ven.get(), [ven](mpegvenc_tt *) {});

			if (mpegOutVideoInit(video_encoder_.get(), &video_fifo_->input, 0))
				throw gcnew Exception("Failed to init video fifo stream");

			mxf_stream_set_struct vstream_sets{ 0 };
			if (mxfMuxAddInputStream(muxer_.get(), &vstream_sets, &video_fifo_->output))
				throw gcnew Exception("Failed to add video stream to mxf muxer");

			// Audio
			std::shared_ptr<fifo_stream_tt> ast(new_fifo_buf(DEFAULT_BUF_SIZE, MXF_SAMPLE_CHUNK_SIZE), [mux](fifo_stream_tt *p)
			{
				if (p)
					free_fifo_buf(p);
			});
			if (!ast)
				throw gcnew Exception("Failed to create audio fifo stream");
			audio_fifo_.reset(ast.get(), [ast](fifo_stream_tt*) {});

			mxf_stream_set_struct astream_sets{ 0 };
			if (mxfMuxAddInputStream(muxer_.get(), &astream_sets, &audio_fifo_->output))
				throw gcnew Exception("Failed to add audio stream to mxf muxer");

			mc_audio_format_t a_format{ 0 };
			a_format.bits_per_sample = 16;
			a_format.channels = 2;
			a_format.samples_per_sec = 48000;
			a_format.flags = MC_AUDIO_FORMAT_FLAG_PCM_IS_SIGNED;

			mc_stream_format_t a_stream_format;
			memset(&a_stream_format, 0, sizeof(a_stream_format));
			a_stream_format.stream_mediatype = mctPCM;
			a_stream_format.stream_majortype = mcmjtElementary;
			a_stream_format.pFormat = &a_format;

			audio_fifo_->output.auxinfo(&audio_fifo_->output, 0, STREAM_FORMAT_INFO, &a_stream_format, sizeof(mc_stream_format_t));
		}

		void push_video_frame(std::shared_ptr<AVFrame> frame)
		{
			if (av_image_copy_to_buffer(video_buffer_.data(), video_buffer_.size(), frame->data, frame->linesize, (AVPixelFormat)frame->format, frame->width, frame->height, 1) < 0)
				throw gcnew Exception("Failed to copy video frame to buffer");

			if (mpegOutVideoPutFrame(video_encoder_.get(), video_buffer_.data(), frame->linesize[0], frame->width, frame->height, FOURCC_I422, 0))
				throw gcnew Exception("Failed to encode video frame");
		}

		void push_audio_samples(std::vector<int16_t> samples)
		{
			int size = static_cast<int>(samples.size()) * 2;
			if (audio_fifo_->input.copybytes(&audio_fifo_->input, reinterpret_cast<uint8_t*>(samples.data()), size) != size)
				throw gcnew Exception("Failed to copy audio data to fifo");

			// push the data to the muxer
			sample_struct au;
			memset(&au, 0, sizeof(sample_struct));
			au.cbSize = size;
			if (audio_fifo_->input.auxinfo(&audio_fifo_->input, 0, SAMPLE_INFO, &au, sizeof(au)) != BS_OK)
				throw gcnew Exception("Failed to push audio data to muxer");
		}
	};

	enum mp4_format
	{
		format_mp4 = MP4_FORMAT,
		format_3gp = FILE_FORMAT_3GP,
		format_mj2 = FILE_FORMAT_MJ2,
		format_uvu = FILE_FORMAT_UVU
	};

	enum mp4_compatibility
	{
		com_standard = COMP_STANDARD,
		com_sony_psp = COMP_SONY_PSP,
		com_ipod = COMP_IPOD,
		com_isma = COMP_ISMA,
		com_qt = COMP_QT,
		com_sony_pmc = COMP_SONY_PMC,
		com_flash = COMP_FLASH,
		com_iphone = COMP_IPHONE,
		com_ipad = COMP_IPAD
	};

	class mp4_output_file
	{
		std::shared_ptr<mp4_muxer_tt>		muxer_;
		std::shared_ptr<bufstream_tt>		fstream_;
		std::shared_ptr<bufstream_tt>		fseek_;

		std::shared_ptr<h264_v_encoder>		video_encoder_;
		std::shared_ptr<fifo_stream_tt>		video_fifo_;
		std::vector<uint8_t>				video_buffer_;

		std::shared_ptr<aacaenc_tt>			audio_encoder_;
		std::shared_ptr<fifo_stream_tt>		audio_fifo_;
	public:
		mp4_output_file(std::wstring file, AVRational framerate, int width, int height, int bitrate, int gopN, int gopM)
		{
			int format = mp4_format::format_mp4;
			int stream_compatibility = mp4_compatibility::com_ipod;
			int fragmented = 0;
			unsigned int video_sequence_length = 10;

			mp4_m_settings mset = { 0 };
			// standard = 0, Sony PSP = 1, iPod = 2, ISMA = 3, QT = 4, COMP_SONY_PMC = 5, 6 = flash, 7 = iPhone, 8 = iPad
			const int StreamCompatibility[9] = { 0x00000000, 0x00004000, 0x00005000, 0x00006200, 0x4, 0x5, 0x6, 0x7, 0x00005010 };
			if (!mp4MuxDefaults(&mset, StreamCompatibility[stream_compatibility]))
				throw gcnew Exception("Could not set mp4 muxer default file format mp4");

			// setup the settings structure	
			if (format != FILE_FORMAT_UVU)
			{
				mset.stream_compatibility = stream_compatibility;
				mset.format = format;
				mset.fragmented = fragmented;
			}
			mset.sync_mode = 2; // set reconstruct time calculation mode
			mset.video_sequence_length = video_sequence_length;

			std::shared_ptr<bufstream_tt> fst(open_file_buf_write(file.c_str(), MXF_SAMPLE_CHUNK_SIZE, NULL), [](bufstream_tt *p)
			{
				if (p)
					close_file_buf(p, 0);
			});
			if (!fst)
				throw gcnew Exception("Failed to create output file");
			fstream_.reset(fst.get(), [fst](bufstream_tt*) {});

			std::shared_ptr<bufstream_tt> fs(bseek_open_file_buf(fstream_.get(), NULL), [fst](bufstream_tt *p)
			{
				if (p)
					bseek_close_file_buf(p, 0);
			});
			if (!fs)
				throw gcnew Exception("Failed to create output file seek");
			fseek_.reset(fs.get(), [fs](bufstream_tt*) {});

			// create muxer
			std::shared_ptr<mp4_muxer_tt> mux(mp4MuxNew(mc_get_rc, &mset), [fs](mp4_muxer_tt *p)
			{
				if (p)
				{
					mp4MuxDone(p, 0);
					mp4MuxFree(p);
				}
			});
			if (!mux)
				throw gcnew Exception("Could not create mp4 muxer");
			muxer_.reset(mux.get(), [mux](mp4_muxer_tt*) {});

			if (mp4MuxInitStream(muxer_.get(), nullptr, fseek_.get()))
				throw gcnew Exception("Could not init output stream");

			// Video
			auto fps = av_q2d(framerate);
			h264_v_settings vsettings = { 0 };
			if (h264OutVideoDefaultSettings(H264_MAIN, width, height, fps, H264_PROGRESSIVE, mc_get_rc, &vsettings, nullptr) != H264ERROR_NONE)
				throw gcnew Exception("Could not ger default h264 settings");

			vsettings.profile_id = H264PROFILE_MAIN;
			vsettings.level_id = 40;
			vsettings.interlace_mode = H264_PROGRESSIVE;
			vsettings.field_order = H264_TOPFIELD_FIRST;
			//vsettings.;
			//vsettings.detach_thread = 0; // **LOW_DELAY**: set this flag to keep h264OutVideoPutFrame calls synchronous
			vsettings.slice_arg = 0;
			vsettings.reordering_delay = Math::Max(1, Math::Min(gopM, 11));
			vsettings.idr_interval = (gopN / vsettings.reordering_delay) * vsettings.reordering_delay;;
			vsettings.min_idr_interval = vsettings.idr_interval;
			vsettings.vcsd_mode = 1;
			vsettings.adaptive_b_frames = 1;
			vsettings.bit_rate_mode = H264_VBR;
			vsettings.bit_rate = bitrate;
			vsettings.max_bit_rate = vsettings.bit_rate * 1.2;
			vsettings.vbv_buffer_units = 1; // buffer size in bits
			vsettings.bit_rate_buffer_size = vsettings.max_bit_rate * 2; // buffer for 2 secs of encoded video
			vsettings.vbv_buffer_fullness = 0;
			vsettings.vbv_buffer_fullness_trg = vsettings.bit_rate_buffer_size;
			vsettings.cpb_size_scale = 0;
			vsettings.hrd_low_delay = 1;
			vsettings.num_units_in_tick = -1;
			vsettings.time_scale = -1;
			vsettings.frame_mbs_mode = 0;
			vsettings.def_horizontal_size = width;
			vsettings.def_vertical_size = height;
			AVRational sar;
			av_reduce(&sar.num, &sar.den, 16 * height, 9 * width, 1024 * 1024);
			vsettings.sar_width = sar.num;
			vsettings.sar_height = sar.den;
			vsettings.chroma_format = CHROMA420;
			h264OutVideoPerformance(&vsettings, 0, H264_PERF_BALANCED, 0);
			if (h264OutVideoChkSettings(mc_get_rc, &vsettings, H264_CHECK_AND_ADJUST | H264_CHECK_FOR_LEVEL, NULL) == H264ERROR_FAILED)
				throw gcnew Exception("H264 setting error");

			std::shared_ptr<fifo_stream_tt> vst(new_fifo_buf(10 * 65536, 65536), [mux](fifo_stream_tt *p)
			{
				if (p)
					free_fifo_buf(p);
			});
			if (!vst)
				throw gcnew Exception("Failed to create video fifo stream");
			video_fifo_.reset(vst.get(), [vst](fifo_stream_tt*) {});

			std::shared_ptr<h264_v_encoder> venc(h264OutVideoNew(mc_get_rc, &vsettings, 0, 0xFFFFFFFF, 0, 0), [vst](h264_v_encoder *p)
			{
				h264OutVideoDone(p, 0);
				h264OutVideoFree(p);
			});
			if (!venc)
				throw gcnew Exception("Could not create H264 encode");
			video_encoder_.reset(venc.get(), [venc](h264_v_encoder *) {});

			if (h264OutVideoInit(video_encoder_.get(), &video_fifo_->input, 0, NULL))
				throw gcnew Exception("Could not init H264 output stream");

			mp4mux_stream_settings_t stream_info;
			memset(&stream_info, 0, sizeof(stream_info));
			stream_info._format.stream_majortype = mcmjtElementary;
			stream_info._format.stream_mediatype = mctH264;   // Set up correct media type

			if (mp4MuxAddStream(muxer_.get(), &stream_info, &video_fifo_->output))
				throw gcnew Exception("Could not add video stream");

			int size = av_image_get_buffer_size(AV_PIX_FMT_YUV422P, width, height, 1);
			video_buffer_.resize(size, 0);

			// Audio
			std::shared_ptr<fifo_stream_tt> ast(new_fifo_buf(2 * 65536, 65536), [mux](fifo_stream_tt *p)
			{
				if (p)
					free_fifo_buf(p);
			});
			if (!ast)
				throw gcnew Exception("Failed to create audio fifo stream");
			audio_fifo_.reset(ast.get(), [ast](fifo_stream_tt*) {});

			aac_a_settings asettings = { 0 };
			aacOutAudioDefaults(&asettings, MCPROFILE_DEFAULT);
			asettings.bits_per_sample = 16;
			asettings.input_channels = 2;
			asettings.audio_bitrate_index = AAC_AUDIOBITRATE_128;
			asettings.vbr = 0;
			asettings.header_type = AAC_HEADER_ADTS;
			asettings.mpeg_version = MPEG4_AAC_AUDIO;
			if (aacOutAudioChkSettings(mc_get_rc, &asettings, MCPROFILE_DEFAULT, 48000, 0, nullptr) != aacOutErrNone)
				throw gcnew Exception("AAC audio encode settings error");
			std::shared_ptr<aacaenc_tt> aenc(aacOutAudioNew(mc_get_rc, &asettings, 0, 0, 48000), [ast](aacaenc_tt *p)
			{
				aacOutAudioDone(p, 0);
				aacOutAudioFree(p);
			});
			if (!aenc)
				throw gcnew Exception("Could not create aac audio encoder");
			audio_encoder_.reset(aenc.get(), [aenc](aacaenc_tt *p) {});

			if (aacOutAudioInit(audio_encoder_.get(), &audio_fifo_->input) != aacOutErrNone)
				throw gcnew Exception("Could not init aac audio stream");

			mp4mux_stream_settings_t stream_set;
			memset(&stream_set, 0, sizeof(mp4mux_stream_settings_t));
			stream_set._format.stream_majortype = mcmjtElementary;
			stream_set._format.stream_mediatype = mctAAC_ADTS;
			mc_audio_format_t audio_format = { 0 };
			audio_format.channels = 2;
			audio_format.samples_per_sec = 48000;
			audio_format.bits_per_sample = 16;
			stream_set._format.pFormat = &audio_format;

			if (mp4MuxAddStream(muxer_.get(), &stream_set, &audio_fifo_->output))
				throw gcnew Exception("Could not add audio stream");
		}

		void push_video_frame(std::shared_ptr<AVFrame> frame)
		{
			if (av_image_copy_to_buffer(video_buffer_.data(), video_buffer_.size(), frame->data, frame->linesize, (AVPixelFormat)frame->format, frame->width, frame->height, 1) < 0)
				throw gcnew Exception("Failed to copy video frame to buffer");

			if (h264OutVideoPutFrame(video_encoder_.get(), video_buffer_.data(), frame->linesize[0], frame->width, frame->height, FOURCC_I422, 0, nullptr))
				throw gcnew Exception("Failed to encode video frame");
		}

		void push_audio_samples(std::vector<int16_t> samples)
		{
			int size = static_cast<int>(samples.size()) * 2;
			if (aacOutAudioPutBytes(audio_encoder_.get(), reinterpret_cast<uint8_t*>(samples.data()), size) != aacOutErrNone)
				throw gcnew Exception(L"Could not encode audio frame");
		}
	};

	bool FFMpeg::Convert(String ^input, int out_framerate_num, int out_framerate_den, int minVolumeDBFS, int maxVolumeDBFS, long long startMilliseconds, long long durationMilliseconds,
		bool toHighres, String ^highresPath, int highresWidth, int highresHeight, bool highresInterlace, bool highresTopFieldFirst, int highresGopN, int highresGopM, int highresCloseGop, bool highresIs420, int highresBitrate,
		bool toLowres, String ^lowresPath, int lowresWidth, int lowresHeight, String ^lowresFilter, int lowresBitrate, int lowresGopN, int lowresGopM,
		bool toHighres2, String ^highresPath2, int highresGopN2, int highresGopM2, int highresCloseGop2, bool highresIs4202, int highresBitrate2)
	{
		try
		{
			Init();

			AVRational out_framerate;
			av_reduce(&out_framerate.num, &out_framerate.den, out_framerate_num, out_framerate_den, 1024 * 1024);
			std::shared_ptr<input_file> input_file(new input_file(utf8_to_cstr(input), out_framerate, minVolumeDBFS, maxVolumeDBFS,
				toHighres, highresWidth, highresHeight, highresInterlace, highresTopFieldFirst,
				toLowres, lowresWidth, lowresHeight, utf8_to_cstr(lowresFilter)));
			std::shared_ptr<output_file> output_highres_file;
			std::shared_ptr<output_file> output_highres_file2;
			std::shared_ptr<mp4_output_file> output_lowres_file;

			std::queue<std::vector<int16_t>> last_highres_audios;
			std::queue<std::vector<int16_t>> last_lowres_audios;

			bool okHighres = !toHighres;
			bool  okLowres = !toLowres;
			bool okAudio = false;
			uint32_t nb_highres_frames = 0;
			uint32_t nb_lowres_frames = 0;
			uint32_t nb_samples = 0;

			uint32_t start_video_frames = 0;
			uint32_t end_video_frames = std::numeric_limits<uint32_t>::max();
			uint32_t start_samples = 0;
			uint32_t end_samples = std::numeric_limits<uint32_t>::max();

			if (startMilliseconds > 0)
			{
				start_video_frames = static_cast<uint32_t>(startMilliseconds / 1000.0 * av_q2d(out_framerate));
				start_samples = startMilliseconds * 48;
			}
			if (durationMilliseconds)
			{
				end_video_frames = start_video_frames + static_cast<uint32_t>(ceil(durationMilliseconds / 1000.0 * av_q2d(out_framerate)));
				end_samples = start_samples + durationMilliseconds * 48;
			}

			uint32_t nb_highres_frame_push = 0;
			uint32_t nb_lowres_frame_push = 0;
			uint32_t nb_samples_push = 0;
			std::vector<int16_t> last_samples;
			while (true)
			{
				auto frames = input_file->try_get_frame();
				if (frames.first.first.size() == 0 && frames.first.second.size() == 0 && frames.second.size() == 0 && input_file->is_eof())
					break;

				while (frames.first.first.size() > 0 || frames.first.second.size() > 0 || frames.second.size() > 0)
				{
					if (frames.first.first.size() > 0)
					{
						auto frame = frames.first.first.front();
						frames.first.first.pop();

						if (toHighres && !okHighres)
						{
							if (!output_highres_file)
							{
								auto file_name = utf8_to_cwstr(highresPath);
								output_highres_file.reset(new output_file(file_name, out_framerate, frame->width, frame->height, highresGopN, highresGopM, highresCloseGop, highresInterlace, highresTopFieldFirst, highresIs420, highresBitrate));
							}
							if (toHighres2 && !output_highres_file2)
							{
								auto file_name = utf8_to_cwstr(highresPath2);
								output_highres_file2.reset(new output_file(file_name, out_framerate, frame->width, frame->height, highresGopN2, highresGopM2, highresCloseGop2, highresInterlace, highresTopFieldFirst, highresIs4202, highresBitrate2));
							}

							if (nb_highres_frames >= start_video_frames && nb_highres_frames < end_video_frames)
							{
								++nb_highres_frame_push;

								output_highres_file->push_video_frame(frame);
								if (toHighres2)
									output_highres_file2->push_video_frame(frame);
								while (!last_highres_audios.empty())
								{
									auto samples = last_highres_audios.front();
									last_highres_audios.pop();
									output_highres_file->push_audio_samples(samples);
									if (toHighres2)
										output_highres_file2->push_audio_samples(samples);
								}
							}
							else if (nb_highres_frames >= end_video_frames)
								okHighres = true;

							++nb_highres_frames;
						}
					}

					if (frames.first.second.size() > 0)
					{
						auto frame = frames.first.second.front();
						frames.first.second.pop();

						if (toLowres && !okLowres)
						{
							if (!output_lowres_file)
							{
								auto file_name = utf8_to_cwstr(lowresPath);
								output_lowres_file.reset(new mp4_output_file(file_name, out_framerate, frame->width, frame->height, lowresBitrate, lowresGopN, lowresGopM));
							}

							if (nb_lowres_frames >= start_video_frames && nb_lowres_frames < end_video_frames)
							{
								++nb_lowres_frame_push;

								if (output_lowres_file)
									output_lowres_file->push_video_frame(frame);

								while (!last_lowres_audios.empty())
								{
									auto samples = last_lowres_audios.front();
									last_lowres_audios.pop();
									output_lowres_file->push_audio_samples(samples);
								}
							}
							else if (nb_lowres_frames >= end_video_frames)
								okLowres = true;

							++nb_lowres_frames;
						}
					}

					if (frames.second.size() > 0)
					{
						auto samples = frames.second.front();
						frames.second.pop();

						if (!okAudio)
						{
							if (last_samples.size())
							{
								if (input_file->sample_multiplier() != 1.0f)
								{
									auto multiplier = input_file->sample_multiplier();
									for (int n = 0; n < last_samples.size(); ++n)
										last_samples.at(n) = static_cast<int16_t>(last_samples.at(n) * multiplier + 0.5);
								}
								auto next_samples = nb_samples + static_cast<uint32_t>(last_samples.size()) / 2;

								if (nb_samples < end_samples && next_samples > start_samples)
								{
									if (nb_samples < start_samples)
									{
										last_samples.erase(last_samples.begin(), last_samples.begin() + (start_samples - nb_samples) * 2);
										nb_samples = start_samples;
									}
									if (next_samples > end_samples)
										last_samples.resize(last_samples.size() - (next_samples - end_samples) * 2);

									if (last_samples.size())
									{
										nb_samples_push += static_cast<uint32_t>(last_samples.size()) / 2;

										if (toHighres)
										{
											if (output_highres_file)
											{
												output_highres_file->push_audio_samples(last_samples);
												if (output_highres_file2)
													output_highres_file2->push_audio_samples(last_samples);
											}
											else
												last_highres_audios.push(last_samples);
										}

										if (toLowres)
										{
											if (output_lowres_file)
												output_lowres_file->push_audio_samples(last_samples);
											else
												last_lowres_audios.push(last_samples);
										}
									}
								}
								else if (nb_samples >= end_samples)
									okAudio = true;

								nb_samples = next_samples;
							}
							last_samples = samples;
						}
					}
				}

				OnTranscodeProgress(nullptr, gcnew TranscodeProgressArgs(input_file->number_frames(), input_file->num_input_frame()));

				if (okHighres && okLowres && okAudio)
					break;
			}

			if (!okAudio)
			{
				if (last_samples.size())
				{
					int i = last_samples.size() - 1;
					for (; i >= last_samples.size() - 10; --i)
					{
						if (std::abs(last_samples.at(i) - last_samples.at(i - 2)) < 100)
							break;
					}
					if (i < last_samples.size() - 1)
						last_samples.resize(last_samples.size() - 1 - i);
				}

				auto samples_need = std::max(nb_highres_frame_push, nb_lowres_frame_push) * 48000 * out_framerate.den / out_framerate.num;
				if (nb_samples_push < samples_need)
				{
					last_samples.resize((samples_need - nb_samples_push) * 2, 0);
					if (input_file->sample_multiplier() != 1.0f)
					{
						auto multiplier = input_file->sample_multiplier();
						for (int n = 0; n < last_samples.size(); ++n)
							last_samples.at(n) = static_cast<int16_t>(last_samples.at(n) * multiplier + 0.5);
					}
					if (output_highres_file)
						output_highres_file->push_audio_samples(last_samples);
					if (output_highres_file2)
						output_highres_file2->push_audio_samples(last_samples);
					if (output_lowres_file)
						output_lowres_file->push_audio_samples(last_samples);
				}
			}

			return true;
		}
		catch (Exception ^ex)
		{
			OnLog(nullptr, gcnew FFMpegLogArgs("[error]" + ex->Message));
		}
		return false;
	}

	bool FFMpeg::ParseFramerate(String^ str, [Out] int% num, [Out] int% den)
	{
		num = 0;
		den = 0;
		try
		{
			AVRational rate;
			if (av_parse_video_rate(&rate, utf8_to_cstr(str).c_str()) >= 0)
			{
				num = rate.num;
				den = rate.den;
				return true;
			}
		}
		catch (...) {}
		return false;
	}

	bool FFMpeg::ParseVideoSize(String^ str, [Out] int% width, [Out] int% height)
	{
		width = 0;
		height = 0;
		try
		{
			int w, h;
			if (av_parse_video_size(&w, &h, utf8_to_cstr(str).c_str()) >= 0)
			{
				width = w;
				height = h;
				return true;
			}
		}
		catch (...) {}
		return false;
	}
}
