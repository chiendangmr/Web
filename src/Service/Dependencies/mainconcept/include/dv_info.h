/* ----------------------------------------------------------------------------
 * File: dv_info.h
 *
 * Desc: DV Info Structures
 *
 * Copyright (c) 2015 MainConcept GmbH or its affiliates.  All rights reserved.
 *
 * MainConcept and its logos are registered trademarks of MainConcept GmbH or its affiliates.  
 * This software is protected by copyright law and international treaties.  Unauthorized 
 * reproduction or distribution of any portion is prohibited by law.
 * ----------------------------------------------------------------------------
 */
 
#if !defined (__DV_INFO_INCLUDED__)
#define __DV_INFO_INCLUDED__

#include "mctypes.h"

// compression modes                 
#define DV_MODE_DV_25                   1   // IEC 
#define DV_MODE_DVCPRO_25               2
#define DV_MODE_DVCPRO_50               3
#define DV_MODE_DV100_720P              4   // 720 60p 
#define DV_MODE_DV100_1080I             5

// frame sizes
#define DV_DIF_CHANNEL_SIZE_50          144000
#define DV_DIF_CHANNEL_SIZE_60          120000
#define DV_25_FRM_SIZE_50               DV_DIF_CHANNEL_SIZE_50
#define DV_25_FRM_SIZE_60               DV_DIF_CHANNEL_SIZE_60
#define DV_50_FRM_SIZE_50               DV_DIF_CHANNEL_SIZE_50 * 2
#define DV_50_FRM_SIZE_60               DV_DIF_CHANNEL_SIZE_60 * 2
#define DV_100_FRM_SIZE_50              DV_DIF_CHANNEL_SIZE_50 * 4
#define DV_100_FRM_SIZE_60              DV_DIF_CHANNEL_SIZE_60 * 4

// frame rate codes
#define DV_FPS_CODE_24                  0x24  // 24p         - 24000 / 1001 fps 
#define DV_FPS_CODE_25                  0x25  // 25p or 50i  - 25 fps
#define DV_FPS_CODE_30                  0x30  // 30p or 60i  - 30000 / 1001 fps
#define DV_FPS_CODE_50                  0x50  // 50p         - 50 fps
#define DV_FPS_CODE_60                  0x60  // 60p         - 60000 / 1001 fps

// field types                       
#define DV_FT_PROGRESSIVE               1
#define DV_FT_BOTTOM_FIRST              2
#define DV_FT_TOP_FIRST                 3

// pulldown modes                    
#define DV_PULLDOWN_NONE                0
#define DV_PULLDOWN_23                  1   // 2:3
#define DV_PULLDOWN_ADV                 2   // 2:3:3:2 panasonic advanced pulldown (576/480 or 1080 only)
#define DV_PULLDOWN_22                  3   // 2:2 (720p only)

// error codes for DV audio muxer and demuxer:
#define DVA_ERRORS							0x00000000

#define DVA_ERROR_NONE                    DVA_ERRORS +  0
#define DVA_ERR_NO_AUDIO_BLOCK            DVA_ERRORS +  1
#define DVA_ERR_FRAME_SIZE                DVA_ERRORS +  2
#define DVA_ERR_BITSTREAM                 DVA_ERRORS +  3
#define DVA_ERR_STRUCT_MEMBERS            DVA_ERRORS +  4
#define DVA_ERR_NO_AUDIO_IN_SOURCE        DVA_ERRORS +  5
#define DVA_ERR_NO_AUDIO_CHOSEN           DVA_ERRORS +  6
#define	DVA_ERR_NO_AUDIO_IN_MONO          DVA_ERRORS +  7
#define	DVA_ERR_NUMBER_OF_INPUT_SAMPLES   DVA_ERRORS +  8
#define	DVA_ERR_WRONG_VIDEO_TYPE          DVA_ERRORS +  9
#define	DVA_ERR_WRONG_CHANNEL_NUMBER      DVA_ERRORS +  10
#define	DVA_ERR_NUM_CHS_VS_ENC_CHS        DVA_ERRORS +  11
#define	DVA_ERR_NUMBER_OF_INPUT_CHANNELS  DVA_ERRORS +  12
#define	DVA_ERR_SAMPLE_RATE               DVA_ERRORS +  13
#define	DVA_ERR_BITS_PER_SAMPLE           DVA_ERRORS +  14
#define	DVA_ERR_WRONG_TARGET_CHANNEL      DVA_ERRORS +  15
#define	DVA_ERR_LOCKED_MODE               DVA_ERRORS +  16
#define	DVA_ERR_SAMPLE_STRIDE             DVA_ERRORS +  17

// deprecated, do not use!! will be removed
// dv info - video system parameters - retreived by DVGetInfo
typedef struct
{
  int32_t hor_size;
  int32_t vert_size;
  int32_t aspectX;
  int32_t aspectY;
  int32_t frame_rate_hex;                   // framerate as hex value, upper nibble 10s of rate eg. 0x25 = 25fps
                                            // you can also use the DV_FPS_CODE_XXX values to set/read them
  int32_t fps_rate;                         // the frame rate is val(fps_rate / fps_scale), e.g. (30000/1001)
  int32_t fps_scale;                        // see fps_rate
  int32_t pulldown;                         // pulldown method
  int32_t pulldown_seq_start;               // first frames sequence no. in pulldown (0 ... 4) usualy 0
  int32_t vfr_flag;                         // panasonic variable framerate
  int32_t field_type;                       // one of the DV_FT_XXX values
  int32_t frame_size;                       // size of compressed dif frame
  int64_t stream_size;                      
  uint32_t total_dif_frames;                // number of dif frames
  uint32_t total_v_frames;                  // number of video frames. NOTE: one 720p dif frame contains 2 video frames
  int32_t headerless;                       // doesn't have H0 header - always 0, not supported
  int32_t comp_mode;                        // one of DV_MODE_XX   
} dv_video_info;


// extended dv info - video system parameters - retreived by DVGetInfoEx
typedef struct
{  
  int32_t this_size;                        // size of this struct to keep it extendable, 
                                            // always set to sizeof(dv_video_info_ex)before use

  int32_t hor_size;                         // horizontal image size
  int32_t vert_size;                        // vertical image size
  int32_t aspectX;                          // horizontal aspect ratio value e.g. 16
  int32_t aspectY;                          // vertical aspect ratio value e.g. 9
  // recording frame rate - source/display frame rate in case of pulldown e.g. 24fps, otherwise same as encoding frame rate
  int32_t rec_frame_rate_hex;               // recording framerate as hex value, upper nibble 10s of rate eg. 0x25 = 25fps
  int32_t rec_fps_nominator;                // recording frame rate nominator
                                            // the frame rate is val((double)rec_fps_nominator / (double)fps_denominator), e.g. (30000.0/1001.0)
  // encoding frame rate - depending on compression mode - see also notes below
  int32_t enc_frame_rate_hex;               // encoding framerate as hex value, upper nibble 10s of rate eg. 0x25 = 25fps
  int32_t enc_fps_nominator;                // encoding frame rate nominator
                                            // the frame rate is val(enc_fps_nominator / fps_denominator), e.g. (30000/1001)
  int32_t precise_rate;                     // 1: xx_frame_rate_hex represents real rate (PAL), 
                                            // 0: xx_frame_rate_hex value must be devided by 1.001 (NTSC) e.g 30/1.001 = 29.97  
  int32_t fps_denominator;                  // see xx_fps_nominator

  int32_t pulldown;                         // pulldown method, one of DV_PULLDOWN_xx
  int32_t pulldown_seq_number;              // frames sequence no. (0 ... 4) in 2:3 and advanced pulldown modes - 0xf when not pulldown
                                            // when the analized frame is first frame in a stream this represents a possible pulldown
                                            // sequence offset if not 0
  int32_t vfr_flag;                         // Panasonic variable framerate
  int32_t field_type;                       // one of the DV_FT_XXX values
  int32_t frame_size;                               // size of compressed dif frame (NOTE: one 720p dif frame contains 2 video frames)                       
  int32_t headerless;                       // doesn't have H0 header - always 0, not supported
  int32_t comp_mode;                        // compression mode, one of DV_MODE_XX

} dv_video_info_ex;

// Note about encoding frame rate:
//
// Encoding rates mean the rates based on the DV System (for details refer to SMPTE 134M and SMPTE 370M). 
// The rate for 480/576 and 1080 is 29.97 fps in case of 60Hz system or 25.0 fps in case of 50Hz system. 
//
// For 720p the rate is 59,94 or 50fps, with the exception of Panasonic's native framerate modes 24.97, 25.0, 29.97 without pulldown,
// where source rate equals encoding rate with the benefit of reduced bitrate.



#define DV_PCM_AUDIO                        4  // PCM


// deprecated, do not use!! will be removed
typedef struct
{
  int32_t type;                             // PCM 
  int64_t duration;                         // in samples
  int32_t sample_rate;
  int32_t bits_per_sample;
  int32_t channels; 
  int32_t block_align;
  int32_t avg_bytes;
  int32_t bytes_per_sample;
} dv_audio_info;


typedef struct
{
  int32_t mono_channel[4][2][2]; // [channels in dif block][audio blocks in channel][mono channels in audio block]
} channel_info;

// audio information
typedef struct
{
  int32_t this_size;                        // size of this struct to keep it extendable, 
                                            // always set to sizeof(dv_audio_info_ex)before use
  int32_t type;                             // PCM 
  int32_t channels;                         // number of available channels
  int32_t sample_rate;                      // sample rate eg. 48000
  int32_t bits_per_sample;                  // quantization eg. 16
  int32_t bytes_per_sample;                 // bytes per sample (all channels)
  int32_t max_channels;                     // maximum possible number of channels (DV 25: 2, DV 50: 4, DV 100: 8)
  int32_t audio_in_dif[4];                  // obsolete, don't use
  channel_info channel_available;           // info on available mono channels

  // set by the user if user wants more control:
  channel_info channel_demux;               // which mono channels user wants decoded
  int32_t demux_all;                        // decode all available, channel_decode doesn't matter in this case
  
  channel_info channel_mux;                 // which mono channels user wants encoded
  int32_t mux_all;                          // encode all available, channel_encode doesn't matter in this case
    
  // input parameter
  int32_t locked_mode;                      // number of audio samples per frame "constant" (audio in sync with video) or not
  int32_t sample_stride;                    // number of locations in memory between successive samples in bytes the user can change it

  // output
  channel_info num_pcm_samples;             //returns number of PCM samples in every existing mono channel

} dv_audio_info_ex;


#endif // #if !defined (__DV_INFO_INCLUDED__)

