#pragma once

#include <bufstrm.h>
#include "sr_fifo.h"

typedef struct fifo_buf_struct fifo_stream_tt;

struct fifo_buf_struct
{
	bufstream_tt  input;  // used on place of init_file_buf_write
	bufstream_tt  output; // used on place of init_file_buf_read
	fifo_tt      *fifo;
};

#ifdef __cplusplus
extern "C"
{
#endif // __cplusplus
	__declspec(dllexport) void free_fifo_buf(fifo_stream_tt *buf_fifo);
	__declspec(dllexport) fifo_stream_tt *new_fifo_buf(uint32_t buf_size, uint32_t chunk_size);
#ifdef __cplusplus
}
#endif // __cplusplus