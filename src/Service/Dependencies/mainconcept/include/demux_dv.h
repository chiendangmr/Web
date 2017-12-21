/* ----------------------------------------------------------------------------
 * File: demux_dv.h
 *
 * Desc: DV Demuxer API
 *
 * Copyright (c) 2015 MainConcept GmbH or its affiliates.  All rights reserved.
 *
 * MainConcept and its logos are registered trademarks of MainConcept GmbH or its affiliates.  
 * This software is protected by copyright law and international treaties.  Unauthorized 
 * reproduction or distribution of any portion is prohibited by law.
 * ----------------------------------------------------------------------------
 */

#if !defined (__DEMUX_DV_API_INCLUDED__)
#define __DEMUX_DV_API_INCLUDED__

#include "dv_info.h"
#include "mcapiext.h"

#ifdef __cplusplus
extern "C" 
{
#endif

// dv_getaudioinfo
//
// call to get information about the audio data 
// present inside given DV video frame
// 
//  parameters:
//    psrc			I: pointer to DV video frame
//    src_len		I: size of the DV video frame in bytes
//    audio_info	O: pointer to dv_audio_info_ex structure to be filled 
//
//  returns:
//    DVA_ERROR_NONE if successfull, one of the DVA_ERROR codes otherwise

int32_t MC_EXPORT_API dv_getaudioinfo(
	uint8_t *psrc,	
    uint32_t src_len,
    dv_audio_info_ex *audio_info
    ); 

// dv_demuxaudio
//
// call to demux audio data from given DV video frame 
// 
//  parameters:
//    pDifSrc		I: pointer to DV video frame
//    src_len		I: Isize of the DV video frame in bytes
//    pAudioDst		O: pointer to buffer to be filled with demuxed PCM audio  
//    numSamples	O: number of PCM audio samples demuxed (per channel)
//    ai			I: dv_audio_info_ex structure
//    vi			I: dv_video_info_ex structure  (set to NULL, currently not needed)
//
//  returns:
//    DVA_ERROR_NONE if successfull, one of the DVA_ERROR codes otherwise

int32_t MC_EXPORT_API dv_demuxaudio(
	uint8_t *pDifSrc,
    uint32_t src_len,
    uint8_t *pAudioDst,
    uint32_t* numSamples,
	dv_audio_info_ex *ai,
	dv_video_info_ex* vi
	);


APIEXTFUNC MC_EXPORT_API dv_demuxGetAPIExt(uint32_t func);


#ifdef __cplusplus
}
#endif

#endif //#if !defined (__DEMUX_DV_API_INCLUDED__)


