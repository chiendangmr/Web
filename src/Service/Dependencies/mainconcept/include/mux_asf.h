/* ----------------------------------------------------------------------------
 * File: mux_asf.h
 *
 * Desc: ASF Muxer API
 *
 * Copyright (c) 2015 MainConcept GmbH or its affiliates.  All rights reserved.
 *
 * MainConcept and its logos are registered trademarks of MainConcept GmbH or its affiliates.  
 * This software is protected by copyright law and international treaties.  Unauthorized 
 * reproduction or distribution of any portion is prohibited by law.
 * ----------------------------------------------------------------------------
 */

#if !defined (__MUX_ASF_API_INCLUDED__)
#define __MUX_ASF_API_INCLUDED__

#include "mctypes.h"
#include "bufstrm.h"
#include "mcmediatypes.h"
#include "mcapiext.h"


typedef struct asf_m_settings      asf_m_settings;

//settings flags
//request writing of timecode info
#define WRITE_TIMECODE_VIDEO           0x00000001
//request timecode info in drop-frame format
#define USE_DROP_FRAME_TIMECODE        0x00000002


#ifdef __GNUC__
  #pragma pack(push,1)
#else
  #pragma pack(push)
  #pragma pack(1)
#endif

//TIMECODE_INFO
struct sample_timecode_info_struct
{
    int16_t timecodeRange;           // Timecode Range (if multiple sources are used)
    uint8_t reserved1[2];            // Reserved
    int32_t timecode;                // Timecode: BCD, from LSB to MSB: hh:mm:ss:ff
    int32_t userDefinedBits;         // User-defined bits
    int32_t reserved;                // Reserved, must be 0
};


struct asf_m_settings
{
    uint64_t preroll;                // the amount of time (in ms) to buffer data before starting to play
    uint32_t packet_size;            // specify a packet size in bytes, set to 0 to have the muxer compute a value (highly recommended)
    uint32_t timecodeFlags;          // enable for SMPTE Timecodes when using the TIMECODE_INFO auxinfo message

    // reserved for future use, sizeof(asf_m_settings) must be 4096 bytes
    uint8_t  reserved[4080]; 
};


#define ASF_STREAM_SETTINGS_VIDEO_FLAG   0x00000001  // stream is a video stream
#define ASF_STREAM_SETTINGS_AUDIO_FLAG   0x00000002  // stream is an audio stream

struct asf_stream_settings
{
    double dFrameRate;               // depreciated, use the mc_stream_format_t field below
    uint32_t flags;                  // zero or more of the ASF_STREAM_SETTINGS_xxx constants
                                     // use one of VIDEO or AUDIO constants if the 
                                     // mc_stream_format_t below information is not known

    uint32_t title_id;               // title id for stream if input is ASF container
    uint32_t stream_id;              // stream id for stream if input is ASF container

	mc_stream_format_t format;       // preferred method of stream identification

    // reserved for future use, sizeof(asf_stream_settings) must be 1000 bytes
    uint8_t reserved[980 - sizeof(mc_stream_format_t)];
};

#pragma pack(pop)


#ifdef __cplusplus
extern "C" {
#endif

void    MC_EXPORT_API asfMuxDefaults   (asf_m_settings *set);
void*   MC_EXPORT_API asfMuxNew        (void *(MC_EXPORT_API*get_rc)(const char* name), asf_m_settings *set);
int32_t MC_EXPORT_API asfMuxInitStream (void *instance, void *reserved, bufstream_tt *output);
int32_t MC_EXPORT_API asfMuxInitFile   (void *instance, void *reserved, char *output);
int32_t MC_EXPORT_API asfMuxAddStream  (void *instance, asf_stream_settings *s_set, bufstream_tt *input);
int32_t MC_EXPORT_API asfMuxAddFile    (void *instance, char *input);	// not implemented!
int32_t MC_EXPORT_API asfMuxAddFileEx  (void *instance, asf_stream_settings *s_set, char *input);
int32_t MC_EXPORT_API asfMuxFileMux    (void *instance);
void    MC_EXPORT_API asfMuxDone       (void *instance, int32_t abort);
void    MC_EXPORT_API asfMuxFree       (void *instance);
int32_t MC_EXPORT_API asfMuxChkSettings(void*(MC_EXPORT_API*get_rc)(const char* name), const struct asf_m_settings *set,
                                        uint32_t options, void *app);

APIEXTFUNC    asfMuxGetAPIExt(uint32_t func);

#ifdef __cplusplus
}
#endif

#endif // #if !defined (__MUX_ASF_API_INCLUDED__)

