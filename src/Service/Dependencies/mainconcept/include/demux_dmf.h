/* ----------------------------------------------------------------------------
 * File: demux_dmf.h
 *
 * Desc: DMF Demuxer API
 *
 * Copyright (c) 2015 MainConcept GmbH or its affiliates.  All rights reserved.
 *
 * MainConcept and its logos are registered trademarks of MainConcept GmbH or its affiliates.  
 * This software is protected by copyright law and international treaties.  Unauthorized 
 * reproduction or distribution of any portion is prohibited by law.
 * ----------------------------------------------------------------------------
 */

#ifndef _DEMUX_DMF_H_
#define _DEMUX_DMF_H_

#include "mcapiext.h"
#include "mcmediatypes.h" 
#include "bufstrm.h"

#define DMF_MAKE_FOURCC(A, B, C, D) ( ((uint8_t) A) | (((uint8_t) B)<<8) | \
    (((uint8_t) C) <<16) | (((uint8_t) D)<<24) )

#define DMF_CONTAINER_TYPE_UNKNOWN        0
#define DMF_CONTAINER_TYPE_AVI1           1
#define DMF_CONTAINER_TYPE_AVI2           2
#define DMF_CONTAINER_TYPE_MKV            3

#define DMF_STREAM_TYPE_UNKNOWN           0x00000000    //unknown
#define DMF_STREAM_TYPE_A                 0x00000001    //audio
#define DMF_STREAM_TYPE_V                 0x00000002    //video
#define DMF_STREAM_TYPE_S                 0x00000003    //subtitle

#define DMF_STREAM_CODEC_UNKNOWN          0x00000000    // unknown
#define DMF_STREAM_CODEC_DIVX             DMF_MAKE_FOURCC('d','i','v','x')

// some possible video stream types in dmf_stream_info_t.stream_compression
#define DMF_STREAM_COMPRESSION_UNKNOWN    0x00000000    // unknown
#define DMF_STREAM_COMPRESSION_DIVX       DMF_MAKE_FOURCC('D','I','V','X')
#define DMF_STREAM_COMPRESSION_DIV3       DMF_MAKE_FOURCC('D','I','V','3')
#define DMF_STREAM_COMPRESSION_DIV4       DMF_MAKE_FOURCC('D','I','V','4')
#define DMF_STREAM_COMPRESSION_DX50       DMF_MAKE_FOURCC('D','X','5','0')
#define DMF_STREAM_COMPRESSION_XVID       DMF_MAKE_FOURCC('X','V','I','D')
#define DMF_STREAM_COMPRESSION_xvid       DMF_MAKE_FOURCC('x','v','i','d')
#define DMF_STREAM_COMPRESSION_MP4V       DMF_MAKE_FOURCC('M','P','4','V')
#define DMF_STREAM_COMPRESSION_H264       DMF_MAKE_FOURCC('H','2','6','4')
#define DMF_STREAM_COMPRESSION_h264       DMF_MAKE_FOURCC('h','2','6','4')
#define DMF_STREAM_COMPRESSION_HEVC       DMF_MAKE_FOURCC('H','E','V','C')
#define DMF_STREAM_COMPRESSION_MPV2       DMF_MAKE_FOURCC('M','P','G','2')
#define DMF_STREAM_COMPRESSION_3IV2       DMF_MAKE_FOURCC('3','I','V','2')
#define DMF_STREAM_COMPRESSION_3iv2       DMF_MAKE_FOURCC('3','i','v','2')
#define DMF_STREAM_COMPRESSION_MP42       DMF_MAKE_FOURCC('M','P','4','2')
#define DMF_STREAM_COMPRESSION_MJPG       DMF_MAKE_FOURCC('M','J','P','G')

// some possible audio stream types in dmf_stream_info_t.stream_format_tag
#define DMF_FORMAT_TAG_UNKNOWN            0x0000        // Microsoft Corporation
#define DMF_FORMAT_TAG_PCM                0x0001        // Microsoft Corporation
#define DMF_FORMAT_TAG_ADPCM              0x0002        // Microsoft Corporation
#define DMF_FORMAT_TAG_IEEE_FLOAT         0x0003        // Microsoft Corporation
#define DMF_FORMAT_TAG_ALAW               0x0006        // Microsoft Corporation
#define DMF_FORMAT_TAG_MULAW              0x0007        // Microsoft Corporation
#define DMF_FORMAT_TAG_DTS_MS             0x0008        // Microsoft Corporation
#define DMF_FORMAT_TAG_WMAS               0x000A        // WMA 9 Speech
#define DMF_FORMAT_TAG_IMA_ADPCM          0x0011        // Intel Corporation
#define DMF_FORMAT_TAG_GSM610             0x0031        // Microsoft Corporation
#define DMF_FORMAT_TAG_MSNAUDIO           0x0032        // Microsoft Corporation
#define DMF_FORMAT_TAG_G726               0x0045        // ITU-T standard
#define DMF_FORMAT_TAG_MPEG               0x0050        // MPEG Layer 1/2
#define DMF_FORMAT_TAG_MPEGLAYER3         0x0055        // MPEG Layer 3
#define DMF_FORMAT_TAG_DOLBY_AC3_SPDIF    0x0092        // Sonic Foundry
#define DMF_FORMAT_TAG_A52                0x2000        //
#define DMF_FORMAT_TAG_EAC3               0x0027        //
#define DMF_FORMAT_TAG_DTS                0x2001        //
#define DMF_FORMAT_TAG_WMA1               0x0160        // WMA version 1
#define DMF_FORMAT_TAG_WMA2               0x0161        // WMA (v2) 7, 8, 9 Series
#define DMF_FORMAT_TAG_WMAP               0x0162        // WMA 9 Professional
#define DMF_FORMAT_TAG_WMAL               0x0163        // WMA 9 Lossless
#define DMF_FORMAT_TAG_DIVIO_AAC          0x4143        // 
#define DMF_FORMAT_TAG_AAC                0x00FF        // 
#define DMF_FORMAT_TAG_FFMPEG_AAC         0x706D        // 
#define DMF_FORMAT_TAG_EXTENSIBLE         0xFFFE        // 

// some possible subtitle stream types in dmf_stream_info_t.stream_compression
#define DMF_STREAM_COMPRESSION_DXSA       DMF_MAKE_FOURCC('D','X','S','A')
#define DMF_STREAM_COMPRESSION_DXSB       DMF_MAKE_FOURCC('D','X','S','B')
#define DMF_STREAM_COMPRESSION_UTF8       DMF_MAKE_FOURCC('U','T','F','8')
#define DMF_STREAM_COMPRESSION_SSA        DMF_MAKE_FOURCC('S','S','A', 0 )
#define DMF_STREAM_COMPRESSION_ASS        DMF_MAKE_FOURCC('A','S','S', 0 )
#define DMF_STREAM_COMPRESSION_USF        DMF_MAKE_FOURCC('U','S','F', 0 )
#define DMF_STREAM_COMPRESSION_BMP        DMF_MAKE_FOURCC('B','M','P', 0 )
#define DMF_STREAM_COMPRESSION_VSUB       DMF_MAKE_FOURCC('V','S','U','B')

// demuxer instance
typedef struct dmf_demuxer dmfdmux_tt;


#ifdef __GNUC__
#pragma pack(push,1)
#else
#pragma pack(push)
#pragma pack(1)
#endif


typedef struct dmf_stream_info_s
{
    uint32_t stream_type;             // one of the DMF_STREAM_TYPE_xxx above
    int16_t  stream_title;            // title number that owns the stream
    int16_t  stream_number;           // stream number in the title

    // these are the fourcc/format codes from the stream
    uint32_t stream_codec;            // video and subtitle streams
    uint32_t stream_compression;      // video and subtitle streams
    uint32_t stream_format_tag;       // audio streams

    int64_t duration;                 // 10,000,000 ticks/sec
    
    mc_stream_format_t format;        // stream format information

    int32_t codec_private_data_len;   // codec private data length
    uint8_t *codec_private_data;      // codec private data

    uint8_t  reserved[56];

}dmf_stream_info_t;


typedef struct dmf_title_info_s
{
    int16_t num_streams_a;            // number of audio streams in the title
    int16_t num_streams_v;            // number of video streams in the title
    int16_t num_streams_st;           // number of subtitle streams in the title

    uint8_t reserved[64];

}dmf_title_info_t;


typedef struct dmf_file_info_s
{
    int16_t num_titles;               // the number of titles in the input file
    int64_t file_size;                // total size of the input file
    uint8_t container_type;           // one of the DMF_CONTAINER_XXX defines

    uint8_t reserved[64];

}dmf_file_info_t;


typedef struct dmfdmux_stream_settings_s
{
    bufstream_tt *bs_out;             // output bufstream for the stream
    int16_t stream_num;               // the stream number in the title

    uint8_t add_headers;              // add headers to stream
                                      // - for AVC it adds annexB headers
                                      // - for AAC it adds ADTS headers
	uint8_t format_pcm_output_flag;   // if this value is 1, the demuxer will output any PCM type streams as standard PCM format for the platform

    uint8_t reserved1[63];

}dmfdmux_stream_settings_t;


typedef struct dmfdmux_parser_settings_s
{
    uint32_t requested_buffer_size;  // requested buffer size (in bytes) for the parser
    int16_t title_num;               // the title the parser will operate on

    uint8_t reserved[64];

}dmfdmux_parser_settings_t;


typedef struct dmfdmux_settings_s
{
    uint8_t reserved[64];

}dmfdmux_settings_t;


typedef struct dmfdmux_seek_info_s
{
    int32_t parser_num;              // the parser number for the seek
    int32_t stream_num;              // the stream number for the seek

    int64_t seek_time;               // the time to seek to, set to -1 to use next/prev key_frame
    uint8_t seek_next_key_frame;     // seek to the next key frame
    uint8_t seek_prev_key_frame;     // seek to the prev key frame

    int64_t ref_time;                // output, the resulting time of the seek operation

    uint8_t reserved[16];

} dmfdmux_seek_info_t;


#pragma pack(pop)


#ifdef __cplusplus
extern "C" {
#endif

// call to create a demuxer instance
// 
//    inputs:
//        get_rc_ex - pointer to a get_rc_ex function
//        rc_app_ptr - application supplied pointer passed back to the get_rc_ex functions
//        set - pointer to an dmfdmux_settings_t structure
//    output:
//        none
//    return:
//        pointer to a dmfdmux_tt object if succesful
//        NULL if unsuccesful

dmfdmux_tt *dmfDemuxNew(void *(MC_EXPORT_API *get_rc_ex)(void *rc_app_ptr, const char* name),
                        void *rc_app_ptr,
                        dmfdmux_settings_t *dmfdmux_settings);

// call to free a demuxer instance
// 
//    inputs:
//        demuxer - pointer to a demuxer instance
//    output:
//        none
//    return:
//        none

void dmfDemuxFree(dmfdmux_tt *demuxer);


// call to open a file for demuxing
// 
//    inputs:
//        demuxer - pointer to a demuxer instance
//        infilename - pointer to the filename to open
//    output:
//        none
//    return:
//        0 if successful, else non-zero

int32_t dmfDemuxOpen(dmfdmux_tt *demuxer,
                     void* reserved,
                     char *infilename);

// unicode version
#if !defined(__APPLE__) && !defined(__linux__) && !defined(__vxworks) && !defined(__QNX__)
int32_t dmfDemuxOpenW(dmfdmux_tt *demuxer,
                      void* reserved,
                      wchar_t *infilename);
#else // !defined(__APPLE__) && !defined(__linux__) && !defined(__vxworks) && !defined(__QNX__)
// this version will currently return an error!
int32_t    dmfDemuxOpenW(dmfdmux_tt *demuxer,
                      void* reserved,
                      unsigned short *infilename);
#endif // !defined(__APPLE__) && !defined(__linux__) && !defined(__vxworks) && !defined(__QNX__)


// call to close a file
// 
//    inputs:
//        demuxer - pointer to a demuxer instance
//    output:
//        none
//    return:
//        none

void dmfDemuxClose(dmfdmux_tt *demuxer);


// call to retrieve information about the input file
// 
//    inputs:
//        demuxer - pointer to a demuxer instance
//        dmf_file_info - pointer to a dmf_file_info_t structure
//    output:
//        none
//    return:
//        0 if successful, else non-zero

int32_t dmfDemuxGetFileInfo(dmfdmux_tt *demuxer,
                            dmf_file_info_t* dmf_file_info);


// call to retrieve information about a title
// 
//    inputs:
//        demuxer - pointer to a demuxer instance
//        title_num - title number (0 based)
//        dmf_title_info - pointer to a dmf_title_info_t structure
//    output:
//        none
//    return:
//        0 if successful, else non-zero

int32_t dmfDemuxGetTitleInfo(dmfdmux_tt *demuxer,
                             int16_t title_num,
                             dmf_title_info_t* dmf_title_info);


// call to retrieve information about a stream in a title
// 
//    inputs:
//        demuxer - pointer to a demuxer instance
//        title_num - title number (0 based)
//        stream_num - stream number (0 based)
//        dmf_stream_info - pointer to a dmf_stream_info_t structure
//    output:
//        none
//    return:
//        0 if successful, else non-zero

int32_t dmfDemuxGetStreamInfo(dmfdmux_tt *demuxer,
                              int16_t title_num,
                              int16_t stream_num,
                              dmf_stream_info_t* dmf_stream_info);


// call to create a parser
// 
//    inputs:
//        demuxer - pointer to a demuxer instance
//        dmfdmux_parser_settings - pointer to a dmfdmux_parser_settings_t structure
//    output:
//        none
//    return:
//        a non-zero parser number if successful, else 0

int32_t dmfDemuxNewParser(dmfdmux_tt *demuxer,
                          dmfdmux_parser_settings_t *dmfdmux_parser_settings);



// call to free a parser
// 
//    inputs:
//        demuxer - pointer to a demuxer instance
//        parser_num - the parser number to free
//    output:
//        none
//    return:
//        none

void dmfDemuxFreeParser(dmfdmux_tt *demuxer,
                        int32_t parser_num);


// call to add a stream to a parser
// 
//    inputs:
//        demuxer - pointer to a demuxer instance
//        parser_num - parser number
//        sinfo - pointer to a dmfdmux_stream_settings_t structure
//    output:
//        none
//    return:
//        0 if successful, else non-zero

int32_t dmfDemuxAddStream(dmfdmux_tt *demuxer,
                          int32_t parser_num,
                          dmfdmux_stream_settings_t *sinfo);

// call to seek to a specific time
// 
//    inputs:
//        demuxer - pointer to a demuxer instance
//        seek_info - pointer to a dmfdmux_seek_info_t structure
//    output:
//        none
//    return:
//        0 if successful, else non-zero

int32_t dmfDemuxSeek(dmfdmux_tt *demuxer,
                     dmfdmux_seek_info_t *seek_info);


// call to push some data through the demuxer
// 
//    inputs:
//        demuxer - pointer to a demuxer instance
//        parser_num - parser number
//    output:
//        none
//    return:
//        non-zero if successful, the number of bytes consumed
//          0 if EOF
//        -1 if an error occurs

int32_t dmfDemuxPush(dmfdmux_tt *demuxer,
                     int32_t parser_num);



// call to wake a parser
// 
//    inputs:
//        demuxer - pointer to a demuxer instance
//        parser_num - parser number
//    output:
//        none
//    return:
//        0 if successful, else non-zero

int32_t dmfDemuxWakeParser(dmfdmux_tt *demuxer,
                           int32_t parser_num);


// call to put a parser to sleep (close file handles, free memory)
// 
//    inputs:
//        demuxer - pointer to a demuxer instance
//        parser_num - parser number
//    output:
//        none
//    return:
//        0 if successful, else non-zero

int32_t dmfDemuxSleepParser(dmfdmux_tt *demuxer,
                            int32_t parser_num);


APIEXTFUNC dmfDemuxGetAPIExt(uint32_t func);

#ifdef __cplusplus
}
#endif

#endif //_DEMUX_DMF_H_
