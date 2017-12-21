/********************************************************************
 Created: 2008/06/01 
 File name: dec_divx.h
 Purpose: DivX Video Decoder API declaration

 Copyright (c) 2008 MainConcept GmbH. All rights reserved.

 This software is the confidential and proprietary information of
 MainConcept GmbH and may be used only in accordance with the terms of
 your license from MainConcept GmbH.

*********************************************************************/

#ifndef __DEC_DIVX_H__
#define __DEC_DIVX_H__

#include "mcdefs.h"
#include "bufstrm.h"
#include "mcapiext.h"
#include "mcmediatypes.h"

#if !defined (MC_EXPORT_API)
	#if defined(WIN32)
		#define MC_EXPORT_API __cdecl
	#else
		#if !defined(__SYMBIAN32__)
			#define MC_EXPORT_API
		#else
			#define MC_EXPORT_API	EXPORT_C
		#endif
	#endif
#endif //!defined (MC_EXPORT_API)

#ifdef __cplusplus
extern "C" {
#endif

// typecast one of the mcmediatypes_t enums to mcmediatype to
// specify stream type if known. If unknown the decoder is setup
// for DivX 5 only.
bufstream_tt * MC_EXPORT_API open_divxin_Video_stream_ex(void *(*get_rc)(char* name), long mcmediatype, long reserved2);
bufstream_tt * MC_EXPORT_API open_divxin_Video_stream(void);

APIEXTFUNC     MC_EXPORT_API divxin_Video_GetAPIExt(uint32_t func);


#define M4D_UNSUPPORTED  -1


#define DIVX_PAR_OUTPUT 0            ///< Used with a #LibQDecoreFunction and #DEC_OPT_SET to specify a different decoder output format. pParam2 will point to a DecInit structure
#define DIVX_PAR_POSTPROCESSING 1    ///< Used with a #LibQDecoreFunction and #DEC_OPT_SET to set the postprocessing level.
#define DIVX_PAR_POSTPROCDEBLOC 2    ///< Used with a #LibQDecoreFunction and #DEC_OPT_SET to set the deblocking level.
#define DIVX_PAR_POSTPROCDERING 3    ///< Used with a #LibQDecoreFunction and #DEC_OPT_SET to set deringing level.
#define DIVX_PAR_WARMTHLEVEL 4   ///< Used with a #LibQDecoreFunction and #DEC_OPT_SET to set the level for the warmth filter (film effect).
#define DIVX_PAR_CONTRAST 5      ///< Used with a #LibQDecoreFunction and #DEC_OPT_SET to set the contrast of the output image.
#define DIVX_PAR_BRIGHTNESS 6    ///< Used with a #LibQDecoreFunction and #DEC_OPT_SET to set the brightness of the output image.
#define DIVX_PAR_SATURATION 7    ///< Used with a #LibQDecoreFunction and #DEC_OPT_SET to set the saturation of the output image.
#define DIVX_PAR_SMOOTH 9        ///< Used with a #LibQDecoreFunction and #DEC_OPT_SET to enable or disable "smooth" decoding. Set the parameter to 1 to enable smooth decoding or 0 to disable it.
#define DIVX_PAR_SHOWPP 10       ///< Used with a #LibQDecoreFunction and #DEC_OPT_SET to overlay the postprocessing level in use on the top left corner of the output image. Set the parameter to 1 to enable the overlay or 0 to disable it.
#define DIVX_PAR_NEWARCH 11      ///< Deprecated.
#define DIVX_PAR_NUM_THREADS 12
#define DIVX_PAR_DEINTERLACE 13


#ifdef __GNUC__
#pragma pack(push,1)
#else
#pragma pack(push)
#pragma pack(1)
#endif

typedef struct TimeStamp {
    int64_t tPTS[2];
    int64_t tMediaTime[2];
    int32_t bPTS;
    int32_t bMediaTime;
}TimeStamp;

#pragma pack(pop)


#ifdef __cplusplus
}
#endif


#endif // __DEC_DIVX_H__
