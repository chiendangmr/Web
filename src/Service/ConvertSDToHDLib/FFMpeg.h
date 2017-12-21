#pragma once

using namespace System;
using namespace System::Runtime::InteropServices;

namespace HDConvert
{
	public ref class FFMpegLogArgs : EventArgs
	{
	public:
		property String^ Message;

		FFMpegLogArgs()
		{

		}

		FFMpegLogArgs(String ^mess)
		{
			this->Message = mess;
		}
	};

	public ref class TranscodeProgressArgs : EventArgs
	{
	public:
		property unsigned int TotalFrames;

		property unsigned int CurrentFrames;

		TranscodeProgressArgs()
		{

		}

		TranscodeProgressArgs(unsigned int totalFrames, unsigned int currentFrames)
		{
			TotalFrames = totalFrames;

			CurrentFrames = currentFrames;
		}
	};

	public ref class FFMpeg abstract sealed
	{
		static bool hasInit_ = false;
	public:
		static event EventHandler<FFMpegLogArgs^> ^OnLog;

		static event EventHandler<TranscodeProgressArgs^> ^OnTranscodeProgress;

		static void Init();

		static void AddLog(String ^message);

		static bool Convert(String ^input, int out_framerate_num, int out_framerate_den, int minVolumeDBFS, int maxVolumeDBFS, long long startMilliseconds, long long durationMilliseconds,
			bool toHighres, String ^highresPath, int highresWidth, int highresHeight, bool highresInterlace, bool highresTopFieldFirst, int gopN, int gopM, int closeGop, bool highresIs420, int highresBitrate,
			bool toLowres, String ^lowresPath, int lowresWidth, int lowresHeight, String ^lowresFilter, int lowresBitrate, int lowresGopN, int lowresGopM,
			bool toHighres2, String ^highresPath2, int highresGopN2, int highresGopM2, int highresCloseGop2, bool highresIs4202, int highresBitrate2);

		static bool ParseFramerate(String^ str, [Out] int% num, [Out] int% den);

		static bool ParseVideoSize(String^ str, [Out] int% width, [Out] int% height);
	};
}

