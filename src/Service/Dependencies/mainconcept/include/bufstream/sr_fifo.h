#pragma once

#include <mctypes.h>

typedef struct fifo_struct fifo_tt;

#ifdef __cplusplus
extern "C"
{
#endif
	__declspec(dllexport) fifo_tt  *fifo_new(uint32_t sampcached, uint32_t sampchunk, size_t sampsize);
	__declspec(dllexport) uint32_t  fifo_free(fifo_tt *fifo);

	__declspec(dllexport) uint32_t  fifo_r_filled(fifo_tt *fifo);
	//uint32_t  fifo_r_sampget(fifo_tt *fifo, uint8_t *src, uint32_t numSamples);
	__declspec(dllexport) uint8_t  *fifo_r_sampbuf(fifo_tt *fifo, uint32_t numSamples);
	__declspec(dllexport) uint32_t  fifo_r_remove(fifo_tt *fifo, uint32_t numSamples);

	__declspec(dllexport) uint32_t  fifo_w_empty(fifo_tt *fifo);
	__declspec(dllexport) uint32_t  fifo_w_sampput(fifo_tt *fifo, uint8_t *src, uint32_t numSamples);
	__declspec(dllexport) uint8_t  *fifo_w_sampbuf(fifo_tt *fifo, uint32_t numSamples);
	__declspec(dllexport) uint32_t  fifo_w_commit(fifo_tt *fifo, uint32_t numSamples);
#ifdef __cplusplus
}
#endif

struct fifo_struct
{
	uint8_t *buf;
	size_t   bufsize;
	size_t   sampsize;
	uint32_t sampchunk;

	uint32_t sampbegin;
	uint32_t sampend;
	uint32_t sampmax;
	uint32_t samptoput;
};