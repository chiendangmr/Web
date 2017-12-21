#pragma once

#include <vector>
#include <string>
#include <memory>
#include <algorithm>

struct AVRational;
enum AVPixelFormat;
struct AVFrame;

namespace HDConvert
{
	class filter
	{
	public:
		filter(
			int in_width,
			int in_height,
			AVRational in_time_base,
			AVRational in_frame_rate,
			AVRational in_sample_aspect_ration,
			AVPixelFormat in_pix_fmt,
			std::vector<AVPixelFormat> out_pix_fmts,
			const std::string& filtergraph,
			bool multithread = true);

		void push(const std::shared_ptr<AVFrame>& frame);
		std::shared_ptr<AVFrame> poll();
		std::vector<std::shared_ptr<AVFrame>> poll_all();

		std::string filter_str() const;

		int64_t nb_frames() const;

		void nb_frames(int64_t val);

		static bool is_double_rate(const std::string& filter)
		{
			std::string str(filter);
			std::transform(str.begin(), str.end(), str.begin(), ::toupper);

			if (str.find("YADIF=1") != std::string::npos)
				return true;

			if (str.find("YADIF=3") != std::string::npos)
				return true;

			if (str.find("SEPARATEFIELDS") != std::string::npos)
				return true;

			return false;
		}

		static bool is_deinterlacing(const std::string& filter)
		{
			std::string str(filter);
			std::transform(str.begin(), str.end(), str.begin(), ::toupper);

			if (str.find("YADIF") != std::string::npos)
				return true;

			if (str.find("SEPARATEFIELDS") != std::string::npos)
				return true;

			return false;
		}
	private:
		struct impl;
		std::shared_ptr<impl> impl_;
	};
}