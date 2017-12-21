#pragma once

#include <bufstrm.h>

#ifdef __cplusplus
extern "C"
{
#endif // __cplusplus

	__declspec(dllexport) int32_t init_file_buf_write(bufstream_tt *bs,
		const wchar_t *bs_filename,
		uint32_t bufsize,
		void(*DisplayError)(char *txt));

	__declspec(dllexport) int32_t init_file_buf_write_flushable(bufstream_tt *bs,
		const wchar_t *bs_filename,
		uint32_t bufsize,
		void(*DisplayError)(char *txt));

	__declspec(dllexport) int32_t init_file_buf_write_existing(bufstream_tt *bs,
		const wchar_t *bs_filename,
		uint32_t bufsize,
		void(*DisplayError)(char *txt));

	__declspec(dllexport) int32_t init_file_buf_read(bufstream_tt *bs,
		const wchar_t *bs_filename,
		uint32_t bufsize,
		void(*DisplayError)(char *txt));

	__declspec(dllexport) bufstream_tt *open_file_buf_write(const wchar_t *bs_filename,
		uint32_t bufsize,
		void(*DisplayError)(char *txt));

	// opens a file so it can be flushed
	__declspec(dllexport) bufstream_tt *open_file_buf_write_flushable(const wchar_t *bs_filename,
		uint32_t bufsize,
		void(*DisplayError)(char *txt));

	__declspec(dllexport) bufstream_tt *open_file_buf_write_existing(const wchar_t *bs_filename,
		uint32_t bufsize,
		void(*DisplayError)(char *txt));

	__declspec(dllexport) bufstream_tt *open_file_buf_read(const wchar_t *bs_filename,
		uint32_t bufsize,
		void(*DisplayError)(char *txt));

	__declspec(dllexport) void close_file_buf(bufstream_tt* bs, int32_t Abort);
#ifdef __cplusplus
}
#endif // __cplusplus