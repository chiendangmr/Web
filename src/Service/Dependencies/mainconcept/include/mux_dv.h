/**
@file: mux_dv.h
@brief DV Muxer API

@verbatim
File: mux_dv.h
Desc: DV Muxer API
 
 Copyright (c) 2015 MainConcept GmbH or its affiliates.  All rights reserved.

 MainConcept and its logos are registered trademarks of MainConcept GmbH or its affiliates.  
 This software is protected by copyright law and international treaties.  Unauthorized 
 reproduction or distribution of any portion is prohibited by law.
@endverbatim
 **/

#if !defined (__MUX_DV_API_INCLUDED__)
#define __MUX_DV_API_INCLUDED__

#include "dv_info.h"
#include "mcapiext.h"

#ifdef __cplusplus
extern "C" 
{
#endif

// dv_muxaudio
//
// call to mux audio data to given DV video frame 
// 
//  parameters:
//	pDifDst		I/O: a pointer to DV video frame
//	src_len		I: size of the DV video frame in bytes
//	pAudioSrc	I: pointer to buffer of PCM audio 
//	numSamples	I: number of PCM audio samples to be muxed into DV frame (overall, not per channel) 
//	ai			I: dv_audio_info_ex structure	
//	vi			I: dv_video_info_ex structure 
//
//  returns:
//    DVA_ERROR_NONE if successfull, one of the DVA_ERROR codes otherwise

int32_t MC_EXPORT_API dv_muxaudio(
    uint8_t *pDifDst,
    uint32_t src_len,
    uint8_t* pAudioSrc,
    uint32_t numSamples,
    dv_audio_info_ex* ai,
	dv_video_info_ex* vi
	);

APIEXTFUNC MC_EXPORT_API dv_muxGetAPIExt(uint32_t func);

#ifdef __cplusplus
}
#endif

#endif // #if !defined (__MUX_DV_API_INCLUDED__)


