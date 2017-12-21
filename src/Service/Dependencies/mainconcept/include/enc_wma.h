/* ----------------------------------------------------------------------------
 * File: enc_wma.h
 *
 * Desc: WMA Encoder API
 *
 * Copyright (c) 2015 MainConcept GmbH or its affiliates.  All rights reserved.
 *
 * MainConcept and its logos are registered trademarks of MainConcept GmbH or its affiliates.  
 * This software is protected by copyright law and international treaties.  Unauthorized 
 * reproduction or distribution of any portion is prohibited by law.
 * ----------------------------------------------------------------------------
 */

#if !defined (__ENC_WMA_API_INCLUDED__)
#define __ENC_WMA_API_INCLUDED__

#include "bufstrm.h"
#include "mcdefs.h"
#include "mcprofile.h"
#include "mcapiext.h"

typedef struct wma_a_encoder wmaaenc_tt;

#ifdef __GNUC__
#pragma pack(push,1)
#else
#pragma pack(push)
#pragma pack(1)
#endif

struct wma_a_settings 
{
    unsigned int input_channels;
    unsigned int audio_bitrate_index;

    unsigned int reserved[62];
};

#pragma pack(pop)

/////////////////////////////////////////////////////////////////////////////
// audio routines in wmaaout.dll
/////////////////////////////////////////////////////////////////////////////

#ifdef __cplusplus
extern "C" {
#endif

// call to fill an wma_a_settings-structure with defaults values
// based on one of the PROFILE preset values
// 
//  inputs:
//    set - pointer to an wma_a_settings structure
//    video_type - one of the PROFILE constants
// output:
//    modified wma_a_settings structure
//  return:
//    short description if the ID is valid, otherwise NULL

char* MC_EXPORT_API wmaOutAudioDefaults(struct wma_a_settings *set, int video_type);


// call to create an wma audio encoder object
//
//  inputs:
//    get_rc - pointer to a get resource function 
//    set - pointer to a filled in wma_a_settings structure
//    options - reserved, set to 0
//    CPU - set to 0xFFFFFFFF for autodetect (reserved for CPU-flags)
//    sampleRate - sample rate of the input audio, must be:
//                 32, 44.1, or 48 kHz
// outputs:
//    none
//  return:
//    pointer to a wmaaenc_tt object if succesful
//    NULL if unsuccesful

wmaaenc_tt* MC_EXPORT_API wmaOutAudioNew( void *(MC_EXPORT_API *get_rc)(const char* name),const struct wma_a_settings *set,int options,int CPU,int sampleRate);


// call to free an wma audio encoder object
//
//  inputs:
//    instance - audio encoder object to free
// outputs:
//    none
//  return:
//    none

void MC_EXPORT_API wmaOutAudioFree(wmaaenc_tt* instance);


// call to initialize the audio encoder for an encoding session, this 
// function must be called before the PutBytes function is called
//
//  inputs:
//    instance - pointer to an wma audio encoder object
//    audiobs - pointer to a bufstream_tt object for the compressed data
// outputs:
//    none
//  return:
//    wmaOutErrNone if successful
//    wmaOutError if not

int MC_EXPORT_API wmaOutAudioInit(wmaaenc_tt *instance, bufstream_tt *audiobs);


// call to encode some audio samples
//
//  inputs:
//    instance - pointer to an wma audio encode object
//    audioBuffer - pointer to a buffer of PCM audio samples
//    numAudioBytes - number of bytes of data in the audio buffer  
// outputs:
//    encoded samples to the audiobs object
//  return:
//    wmaOutErrNone if successful
//    wmaOutError if not

int MC_EXPORT_API wmaOutAudioPutBytes(wmaaenc_tt *instance, unsigned char *audioBuffer, uint32_t numAudioBytes);


// call to finish encoding session, set abort non-zero if encoding is being
// aborted.
//
//  inputs:
//    instance - pointer to an wma audio encoder object
//    abort - set to 0 to finish any leftover audio and clean up,
//            else just clean up
// outputs:
//    encoded samples to the audiobs object if needed
//  return:
//    wmaOutErrNone if successful
//    wmaOutError if not

int MC_EXPORT_API wmaOutAudioDone(wmaaenc_tt *instance, int abort);


// call to get the setting errors/warnings in a wma_a_settings structure
// use with the get_rc parameter to supply an err_printf callback to get error
// messages that can be localized
//
//  inputs:
//    get_rc - pointer to a get_rc function 
//    set - pointer to an wma_a_settings structure
//    mpeg_type - one of the MPEG_* constants to check for VCD/SVCD/DVD
//                audio conformance, use 0 for no VCD/SVCD/DVD conformance checks
//    sample_rate - sampling rate to check
//    options - check options, one or more of the CHECK_* defines in mcdefs.h
//    app - reserved
// outputs:
//    none
//  return:
//    wmaOutErrNone if no errors found
//    one of the INV_* error codes if an error is found

int MC_EXPORT_API wmaOutAudioChkSettings(void *(MC_EXPORT_API *get_rc)(const char* name), const struct wma_a_settings *set, int mpeg_type, int sample_rate, unsigned int options, void *app);


// call to get extended API function
//
//  inputs: 
//    func - function ID
//  return: 
//    function pointer or NULL

APIEXTFUNC MC_EXPORT_API wmaOutAudioGetAPIExt(uint32_t func);


#ifdef __cplusplus
}
#endif

//--------------------------------------------------------------------------

#endif // #if !defined (__ENC_WMA_API_INCLUDED__)

