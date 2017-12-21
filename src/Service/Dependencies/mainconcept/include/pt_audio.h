/* ----------------------------------------------------------------------------
 * File: pt_audio.h
 *
 * Desc: Audio Pass Through Wrapper API
 *
 * Copyright (c) 2009, MainConcept GmbH. All rights reserved.
 *
 * This software is the confidential and proprietary information of
 * MainConcept GmbH and may be used only in accordance with the terms of
 * your license from MainConcept GmbH.
 * ----------------------------------------------------------------------------
 */

#if !defined (__PT_AUDIO_API_INCLUDED__)
#define __PT_AUDIO_API_INCLUDED__

#include "mfimport.h"


// return codes for ptAudioInputCheck

typedef enum ptAudioCheckFailCode
{
    ptAudioOk = 0,
    ptAudioInvalidParameter = 1,
    ptAudioUnknownAudio = 2,
    ptAudioUnknownSettings = 3,

    // general mismatch codes
    ptAudioFreqMismatch = 16,
    ptAudioChanMismatch = 17,
    ptAudioBitrateMismatch = 18,
    ptAudioCopyrightMismatch = 19,
    ptAudioOriginalMismatch = 20,

    // Dolby Digital mismatch codes
    ptAudioDDBSIDMismatch = 32,
    ptAudioDDComprMismatch = 33,
    ptAudioDDCompr2Mismatch = 34,
    ptAudioDDLFEMismatch = 35,
    ptAudioDDDialnormMismatch = 36,
    ptAudioDDLineModeMismatch = 37,
    ptAudioDDRFModeMismatch = 38,
    ptAudioDDLineMode2Mismatch = 39,
    ptAudioDDRFMode2Mismatch = 40,
    ptAudioDDAltBitstreamMismatch = 41,
    ptAudioDDStereoDMixMismatch = 42,
    ptAudioDDLtRtCMixMismatch = 43,
    ptAudioDDLtRtSMixMismatch = 44,
    ptAudioDDLoRoCMixMismatch = 45,
    ptAudioDDLoRoSMixMismatch = 46,
    ptAudioDDSurEXModeMismatch = 47,
    ptAudioDDBSMODMismatch = 48,
    ptAudioDDProductionInfoMismatch = 49,
    ptAudioDDAudioMixLvlMismatch = 50,
    ptAudioDDRoomTypeMismatch = 51,
    ptAudioDDCMixLevelMismatch = 52,
    ptAudioDDSMixLevelMismatch = 53,
    ptAudioDDSurroundModeMismatch = 54,
    ptAudioDDEncoderModeMismatch = 55,
    ptAudioDDSubstreamIDMismatch = 56,

} ptAudioCheckFailCode_t;

// audio pass through wrapper object
typedef struct pt_audio_wrapper pt_audio_tt;


#ifdef __GNUC__
#pragma pack(push,1)
#else
#pragma pack(push)
#pragma pack(1)
#endif

typedef struct pt_audio_info_s
{
    int64_t number_of_frames;
    int32_t samples_per_frame;

} pt_audio_info_t;


typedef struct pt_audio_seek_s
{
    int64_t frame_number;
    int64_t next_timestamp;

} pt_audio_seek_t;


typedef struct pt_audio_send_s
{
    int64_t timestamp;
    int64_t next_timestamp;

} pt_audio_send_t;

#pragma pack(pop)


#ifdef __cplusplus
extern "C" {
#endif

//------------------- general routines -----------------

//////////////////////////////////////////////////////////////////////////
// check if the audio an input file and the export audio settings are
// compatible for pass through
// 
//  inputs:
//    in_info - an existing mfimport instance
//    audio_settings - a pointer to an audio settings structure
//    audio_settings_size - the size of the audio settings structure
//    deep_check - 0 = only main settings are checked (frequency, bitrate, channels...)
//                 1 = all available settings are checked
//
// outputs:
//    none
//
//  return:
//    one of the ptAudioCheckFailCode_t enums

ptAudioCheckFailCode_t MC_EXPORT_API ptAudioCheckSettings(struct mpegInInfo *in_info,
                                                          void *audio_settings,
                                                          int32_t audio_settings_size,
                                                          uint8_t deep_check);


//////////////////////////////////////////////////////////////////////////
// create a pt_audio_tt instance
// 
//  inputs:
//    get_rc_ex - a pointer to a get_rc_ex resource function
//    rc_app_ptr - an application supplied pointer that will be passed back with any get_rc_ex calls
//    in_info - an existing mfimport instance
//    out_bs - a bufstream for the output of the wrapper
//
// outputs:
//    none
//
//  return:
//    pt_audio_tt instance if successful, else NULL

pt_audio_tt * MC_EXPORT_API ptAudioNew(void *(*get_rc_ex)(void *rc_app_ptr, const char* name),
                                       void *rc_app_ptr,
                                       struct mpegInInfo *in_info,
                                       bufstream_tt *out_bs,
                                       const char* pCustomDllPrefix);


//////////////////////////////////////////////////////////////////////////
// free a pt_audio_tt instance
// 
//  inputs:
//    pt_audio - a pt_audio_tt instance
//
// outputs:
//    none
//
//  return:
//    none

void MC_EXPORT_API ptAudioFree(pt_audio_tt *pt_audio);


//////////////////////////////////////////////////////////////////////////
// get information about the audio stream
// 
//  inputs:
//    pt_audio - a pt_audio_tt instance
//    audio_info - a pointer to a pt_audio_info_t structure
//
// outputs:
//    none
//
//  return:
//    0 if compatible, else non-zero

int32_t MC_EXPORT_API ptAudioGetInfo(pt_audio_tt *pt_audio,
                                     pt_audio_info_t *audio_info);


//////////////////////////////////////////////////////////////////////////
// seek to an audio frame
// 
//  inputs:
//    pt_audio - a pt_audio_tt instance
//    seek_info - a pointer to a pt_audio_seek_t structure
//
// outputs:
//    none
//
//  return:
//    0 if compatible, else non-zero

int32_t MC_EXPORT_API ptAudioSeek(pt_audio_tt *pt_audio,
                                  pt_audio_seek_t *seek_info);


//////////////////////////////////////////////////////////////////////////
// deliver the next audio frame to the output fifo
// 
//  inputs:
//    pt_audio - a pt_audio_tt instance
//    send_info - a pointer to a pt_audio_send_t structure
//
// outputs:
//    none
//
//  return:
//    0 if successful, -1 on end of stream, else non-zero

int32_t MC_EXPORT_API ptAudioSendNextFrame(pt_audio_tt *pt_audio,
                                           pt_audio_send_t *send_info);



//////////////////////////////////////////////////////////////////////////
// the API extension control
// 
//  inputs:
//    func - an API identifier
//
// outputs:
//    none
//
//  return:
//    pointer to the requested API function or NULL, if not supported

APIEXTFUNC MC_EXPORT_API ptAudioGetAPIExt(uint32_t func);


#ifdef __cplusplus
}
#endif

#endif // #if !defined (__PT_AUDIO_API_INCLUDED__)

