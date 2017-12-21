#pragma once

#include <bufstrm.h>

#ifdef __cplusplus
extern "C" {
#endif

	__declspec(dllexport) bufstream_tt *bseek_open_file_buf(bufstream_tt *main_bs,
		void(*DisplayError)(char *txt));

	__declspec(dllexport) void bseek_close_file_buf(bufstream_tt* bs, int32_t Abort);

	__declspec(dllexport) bufstream_tt *bseek_open_fifo_buf(bufstream_tt *main_bs,
		void(*DisplayError)(char *txt));

	__declspec(dllexport) void bseek_close_fifo_buf(bufstream_tt* bs, int32_t Abort);

#ifdef __cplusplus
}
#endif