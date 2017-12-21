/**
@file: enc_avc_def.h
@brief AVC/H.264 Encoder API defines

@verbatim
File: enc_avc_def.h
Desc: AVC/H.264 Encoder API defines

Copyright (c) 2014 MainConcept GmbH or its affiliates.  All rights reserved.

MainConcept and its logos are registered trademarks of MainConcept GmbH or its affiliates.
This software is protected by copyright law and international treaties.  Unauthorized
reproduction or distribution of any portion is prohibited by law.
@endverbatim
 **/


#if !defined (__ENC_AVC_DEF_INCLUDED__)
#define __ENC_AVC_DEF_INCLUDED__

/**
@addtogroup H264_VIDEO_TYPES AVC/H.264 Presets and MCProfiles
@{
@name AVC/H.264 Preset defines
@{
**/

#define H264_BASELINE                      0   /**< @brief  Preset based on @ref H264PROFILE_BASELINE, generic preset @hideinitializer*/
#define H264_CIF                           1   /**< @brief  Similar to MPEG1 VideoCD @hideinitializer*/
#define H264_MAIN                          2   /**< @brief  Similar to ISO/IEC 13818-1/2 @hideinitializer*/
#define H264_D1                            4   /**< @brief  Similar to MPEG2 DVD @hideinitializer */
#define H264_HIGH                          5   /**< @brief  Preset based on @ref H264PROFILE_HIGH, generic preset @hideinitializer */
#define H264_HIGH_10                       6   /**< @brief  Preset based on @ref H264PROFILE_HIGH_10, generic preset @hideinitializer */
#define H264_HIGH_422                      7   /**< @brief  Preset based on @ref H264PROFILE_HIGH_422, generic preset @hideinitializer */
#define H264_BD                            8   /**< @brief  Blu-ray Disc @hideinitializer */
#define H264_BD_HDMV                       9   /**< @brief  Blu-ray Disc (Main Video) @hideinitializer */
#define H264_HDTV_720p                    11   /**< @brief  HDTV 1280x720p @hideinitializer */
#define H264_HDTV_1080i                   12   /**< @brief  HDTV 1440x1080i @hideinitializer */
#define H264_AVCHD                        14   /**< @brief  AVCHD @hideinitializer */
#define H264_1SEG                         16   /**< @brief  1seg compatible @hideinitializer */
#define H264_INTRA_HIGH_10                17   /**< @brief  Preset based on @ref H264PROFILE_HIGH_10, generic Intra preset@hideinitializer */
#define H264_INTRA_CLASS_50               18   /**< @brief  H.264 intra frame coding (Class 50). Please refer to @ref P2_RP2027_INTRA_PRESETS for details. @hideinitializer */
#define H264_INTRA_CLASS_100              19   /**< @brief  H.264 intra frame coding (Class 100). Please refer to @ref P2_RP2027_INTRA_PRESETS for details. @hideinitializer */
#define H264_DIVX                         22   /**< @brief  DIVX Plus preset @hideinitializer */
#define H264_3GP                          25   /**< @brief  3GP @hideinitializer */
#define H264_SILVERLIGHT                  26   /**< @brief  Microsoft Silverlight Preset @hideinitializer */
#define H264_DVB_SD                       27   /**< @brief  ETSI TS 101 154 V1.9.1, paragraph 5.6 @hideinitializer */
#define H264_DVB_HD                       28   /**< @brief  ETSI TS 101 154 V1.9.1, paragraph 5.7 @hideinitializer */
#define H264_IPTV_480i                    30   /**< @brief  IPTVFJ STD-0004 [Appendix A] @hideinitializer */
#define H264_IPTV_720p                    31   /**< @brief  IPTVFJ STD-0004 [Appendix A] @hideinitializer */
#define H264_IPTV_1080i                   32   /**< @brief  IPTVFJ STD-0004 [Appendix A] @hideinitializer */
#define H264_INTRA_CLASS_50_RP2027        33   /**< @brief  RP2027 H.264 intra frame coding (Class 50). Please refer to @ref P2_RP2027_INTRA_PRESETS for details. @hideinitializer */
#define H264_INTRA_CLASS_100_RP2027       34   /**< @brief  RP2027 H.264 intra frame coding (Class 100). Please refer to @ref P2_RP2027_INTRA_PRESETS for details. @hideinitializer */
#define H264_PIFF                         36   /**< @brief  Fragmented MP4 PIFF (as part of ISOFF), not yet supported @hideinitializer */
#define H264_IIS_SMOOTHSTREAMING          37   /**< @brief  Fragmented MP4 IIS Smooth Streaming Transport Protocol, treat like @ref H264_SILVERLIGHT for now @hideinitializer */
#define H264_HD_DVD_BD_MV                 64   /**< @brief  Redundant HD DVD & BD MV (external script needed to convert to target application) @hideinitializer */
#define H264_INTRA_CLASS_200_RP2027       72   /**< @brief  RP2027-2012 H.264 intra frame coding (Class 200). Please refer to @ref P2_RP2027_INTRA_PRESETS for details. @hideinitializer */
#define H264_AVCHD_20                     75   /**< @brief  AVCHD 2.0 1080/50p 1080/60p @hideinitializer */
#define H264_DASH264                      76   /**< @brief  DASH264 @hideinitializer */
#define H264_LONG_GOP_422_CLASS_G50       78   /**< @brief  Panasonic AVC-LongG 4:2:2 Classes G50 (50 Mbps). Please refer to @ref LONG_P2_PRESETS for details. @hideinitializer */
#define H264_LONG_GOP_422_CLASS_G25       79   /**< @brief  Panasonic AVC-LongG 4:2:2 Classes G25 (25 Mbps). Please refer to @ref LONG_P2_PRESETS for details. @hideinitializer */
#define H264_LONG_GOP_420_CLASS_G12       80   /**< @brief  Panasonic AVC-LongG 4:2:0 Classes G12 (12 Mbps). Please refer to @ref LONG_P2_PRESETS for details. @hideinitializer */
#define H264_LONG_GOP_420_CLASS_G6        81   /**< @brief  Panasonic AVC-LongG 4:2:0 Classes G6 (6 Mbps). Please refer to @ref LONG_P2_PRESETS for details. @hideinitializer */
#define H264_INTRA_CLASS_200              82   /**< @brief  H.264 intra frame coding (Class 200). Please refer to @ref P2_RP2027_INTRA_PRESETS for details. @hideinitializer */
#define H264_XAVC_4K                      83   /**< @brief  SONY XAVC Long GOP 4K Preset for M4 and XD Style (MP4 and MXF file formats). Please refer to @ref XAVC_LONG_PRESETS for details. @hideinitializer */
#define H264_XAVC_HD_MP4                  84   /**< @brief  SONY XAVC Long GOP HD Preset for M4 Style (MP4 file format) Please refer to @ref XAVC_LONG_PRESETS for details. @hideinitializer */
#define H264_XAVC_HD_MXF                  85   /**< @brief  SONY XAVC Long GOP HD Preset for XD Style (MXF file format) Please refer to @ref XAVC_LONG_PRESETS for details. @hideinitializer */
#define H264_XAVC_HD_INTRA_VBR            86   /**< @brief  SONY XAVC HD Intra VBR Preset for M4 Style (MP4 file format). Please refer to @ref XAVC_INTRA_PRESETS for details. @hideinitializer */
#define H264_XAVC_HD_INTRA_CLASS_50_CBG   87   /**< @brief  SONY XAVC HD Intra CBG Preset Class 50 for XD Style (MXF file format). Please refer to @ref XAVC_INTRA_PRESETS for details. @hideinitializer */
#define H264_XAVC_HD_INTRA_CLASS_100_CBG  88   /**< @brief  SONY XAVC HD Intra CBG Preset Class 100 for XD Style (MXF file format). Please refer to @ref XAVC_INTRA_PRESETS for details. @hideinitializer */
#define H264_XAVC_HD_INTRA_CLASS_200_CBG  89   /**< @brief  SONY XAVC HD Intra CBG Preset Class 200 for XD Style (MXF file format). Please refer to @ref XAVC_INTRA_PRESETS for details. @hideinitializer */
#define H264_XAVC_4K_INTRA_CLASS_100_CBG  90   /**< @brief  SONY XAVC 4K Intra CBG Class 100 for XD Style (MXF file format). Please refer to @ref XAVC_INTRA_PRESETS for details. @hideinitializer */
#define H264_XAVC_4K_INTRA_CLASS_300_CBG  91   /**< @brief  SONY XAVC 4K Intra CBG Class 300 for XD Style (MXF file format). Please refer to @ref XAVC_INTRA_PRESETS for details. @hideinitializer */
#define H264_XAVC_4K_INTRA_CLASS_480_CBG  92   /**< @brief  SONY XAVC 4K Intra CBG Class 480 for XD Style (MXF file format). Please refer to @ref XAVC_INTRA_PRESETS for details. @hideinitializer */
#define H264_XAVC_4K_INTRA_CLASS_100_VBR  93   /**< @brief  SONY XAVC 4K Intra VBR Class 100 for XD Style (MXF file format). Please refer to @ref XAVC_INTRA_PRESETS for details. @hideinitializer */
#define H264_XAVC_4K_INTRA_CLASS_300_VBR  94   /**< @brief  SONY XAVC 4K Intra VBR Class 300 for XD Style (MXF file format). Please refer to @ref XAVC_INTRA_PRESETS for details. @hideinitializer */
#define H264_XAVC_4K_INTRA_CLASS_480_VBR  95   /**< @brief  SONY XAVC 4K Intra VBR Class 480 for XD Style (MXF file format). Please refer to @ref XAVC_INTRA_PRESETS for details. @hideinitializer */
#define H264_P2_2K_INTRA_422             104   /**< @brief  Panasonic 2K Intra 4:2:2 Preset. Please refer to @ref P2_422_INTRA_PRESETS for details. @hideinitializer */
#define H264_P2_4K_INTRA_422             105   /**< @brief  Panasonic 4K Intra 4:2:2 Preset. Please refer to @ref P2_422_INTRA_PRESETS for details. @hideinitializer */
#define H264_P2_HD_INTRA_422             106   /**< @brief  Panasonic HD Intra 4:2:2 Preset. Please refer to @ref P2_422_INTRA_PRESETS for details. @hideinitializer */
#define H264_DASH_L1                     107   /**< @brief  DASH 768x432, 400kb     @hideinitializer */
#define H264_DASH_L2                     108   /**< @brief  DASH 768x432, 600kb     @hideinitializer */
#define H264_DASH_L3                     109   /**< @brief  DASH 768x432, 800kb     @hideinitializer */
#define H264_DASH_L4                     110   /**< @brief  DASH 768x432, 1200kb    @hideinitializer */
#define H264_DASH_L5                     111   /**< @brief  DASH 1280x720, 1750kb   @hideinitializer */
#define H264_DASH_L6                     112   /**< @brief  DASH 1280x720, 2400kb   @hideinitializer */
#define H264_DASH_L7                     113   /**< @brief  DASH 1920x1080, 3500kb  @hideinitializer */
#define H264_DASH_L8                     114   /**< @brief  DASH 1920x1080, 5300kb  @hideinitializer */
#define H264_DASH_L9                     115   /**< @brief  DASH 1920x1080, 8400kb  @hideinitializer */
#define H264_DASH_L10                    116   /**< @brief  DASH 3840x2160, 15 Mbit @hideinitializer */
#define H264_DASH_L11                    117   /**< @brief  DASH 3840x2160, 20 Mbit @hideinitializer */
#define H264_DASH_L12                    118   /**< @brief  DASH 3840x2160, 25 Mbit @hideinitializer */
#define H264_HLS_L1                      119   /**< @brief  HTTP Live Streaming over cellular network. Please refer to @ref HLS_PRESETS for details. @hideinitializer */
#define H264_HLS_L2                      120   /**< @brief  HTTP Live Streaming over cellular network/ATV. Please refer to @ref HLS_PRESETS for details. @hideinitializer */
#define H264_HLS_L3                      121   /**< @brief  HTTP Live Streaming over Wi-Fi network/ cellular network/ ATV. Please refer to @ref HLS_PRESETS for details. @hideinitializer */
#define H264_HLS_L4                      122   /**< @brief  HTTP Live Streaming over Wi-Fi network/ cellular network/ ATV. Please refer to @ref HLS_PRESETS for details. @hideinitializer */
#define H264_HLS_L5                      123   /**< @brief  HTTP Live Streaming over Wi-Fi network/ ATV. Please refer to @ref HLS_PRESETS for details. @hideinitializer */
#define H264_HLS_L6                      124   /**< @brief  HTTP Live Streaming over Wi-Fi network/ ATV. Please refer to @ref HLS_PRESETS for details. @hideinitializer */
#define H264_HLS_L7                      125   /**< @brief  HTTP Live Streaming over Wi-Fi network/ ATV. Please refer to @ref HLS_PRESETS for details. @hideinitializer */
#define H264_HLS_L8                      126   /**< @brief  HTTP Live Streaming over Wi-Fi network/ ATV. Please refer to @ref HLS_PRESETS for details. @hideinitializer */
#define H264_HLS_L9                      127   /**< @brief  HTTP Live Streaming over Wi-Fi network/ ATV. Please refer to @ref HLS_PRESETS for details. @hideinitializer */
#define H264_XAVC_4K_422                 131   /**< @brief  SONY XAVC Long GOP 4K 4:2:2 10-bit Preset (MXF file format). Please refer to @ref XAVC_LONG_PRESETS for details. @hideinitializer */
/**@cond */
#define H264_LAST_H264_TYPE              132
/**@endcond */
/** @}*/
/** @}*/

/**
@def SETTINGS_UNKNOWN_PARAMETERS
@name h264OutVideoDefaultSettings unknown parameters
@{
**/
#define H264_UNDEFINED_PIC_STRUCT                          -1   /**< @brief Undefined picture structure @hideinitializer */
#define H264_UNDEFINED_FRAME_WIDTH                          0   /**< @brief Undefined frame width @hideinitializer */
#define H264_UNDEFINED_FRAME_HEIGHT                         0   /**< @brief Undefined frame height@hideinitializer */
#define H264_UNDEFINED_FPS                                  0   /**< @brief Undefined frame rate @hideinitializer */
/** @}*/

/**
@def VSCD_MODES
@name Scene change detection modes
@{
**/
#define VCSD_MODE_OFF        0        /**< @brief No scene detection @hideinitializer */
#define VCSD_MODE_IDR        1        /**< @brief Set IDR on scene change @hideinitializer */
/** @}*/

/**
@def PULLDOWN_FLAGS
@name Pulldown flags
@{
**/
#define VIDEO_PULLDOWN_NONE  0        /**< @brief No pulldown effect. @hideinitializer */
#define VIDEO_PULLDOWN_23    1        /**< @brief Encode 2:3 pulldown (frame 1 is 2 fields, frame 2 is 3 fields, ...) 23.97 and 24 played as 29.97 and 30 respectively. @hideinitializer */
#define VIDEO_PULLDOWN_32    2        /**< @brief Encode 3:2 pulldown (frame 1 is 3 fields, frame 2 is 2 fields, ...) 23.97 and 24 played as 29.97 and 30 respectively. @hideinitializer */
#define VIDEO_PULLDOWN_23_P  4        /**< @brief Encode 2:3 pulldown (frame doubling, frame tripling, ...) 23.97/24 played as 59.94 and 60 respectively. @hideinitializer */
#define VIDEO_PULLDOWN_32_P  5        /**< @brief Encode 2:3 pulldown (frame tripling, frame doubling, ...) 23.97/24 played as 59.94 and 60 respectively. @hideinitializer */
#define VIDEO_PULLDOWN_AUTO  6        /**< @brief Adaptive mode, display modes for every frame is delivered via @ref OPT_EXT_PARAM_DISPLAY_MODE. @hideinitializer */
#define VIDEO_PULLDOWN_22    7        /**< @brief Every frame is displayed twice @hideinitializer. */
#define VIDEO_PULLDOWN_33    8        /**< @brief Every frame is displayed three times @hideinitializer. */
/** @}*/

/**
@def H264_PROFILE_TYPES
@name Profile type defines
@{
**/
#define H264PROFILE_BASELINE                                0   /**< @brief Baseline Profile @hideinitializer */
#define H264PROFILE_MAIN                                    1   /**< @brief Main Profile @hideinitializer */
#define H264PROFILE_EXTENDED                                2   /**< @brief Extended Profile (not supported by now) @hideinitializer */
#define H264PROFILE_HIGH                                    3   /**< @brief High Profile @hideinitializer */
#define H264PROFILE_HIGH_10                                 4   /**< @brief High 10 Profile @hideinitializer */
#define H264PROFILE_HIGH_422                                5   /**< @brief High 4:2:2 Profile @hideinitializer */
/** @cond @brief Currently unsupported */
#define H264PROFILE_HIGH_444                                6
/** @endcond */
/** @}*/

/**
@def CHROMA_FORMATS
@name Chroma format defines
@{
**/
/** @cond @brief 4:0:0 colour sampling, luma only */
#define H264_CHROMA_400                                     1
/** @endcond */
#define H264_CHROMA_420                                     2   /**< @brief 4:2:0 colour sampling @hideinitializer */
#define H264_CHROMA_422                                     3   /**< @brief 4:2:2 colour sampling @hideinitializer */
/** @cond @brief 4:4:4 colour sampling */
#define H264_CHROMA_444                                     4
/** @endcond */
/** @}*/

/**
@def STREAM_TYPES
@name Stream types defines
@{
**/
#define H264_STREAM_TYPE_I                                  0   /**< @brief VCL NALUs + filler data. @hideinitializer */
#define H264_STREAM_TYPE_I_SEI                              1   /**< @brief VCL NALUs + filler data + SEI messages. @hideinitializer */
#define H264_STREAM_TYPE_II                                 2   /**< @brief All NALU types. @hideinitializer */
#define H264_STREAM_TYPE_II_NO_SEI                          3   /**< @brief All NALU types except SEI messages. @hideinitializer */
/** @}*/

/**
@def VUI_CONFIG
@name VUI configuration flags
@{
**/
#define H264_VUI_PRESENTATION_AUTO                 0x00000000   /**< @brief Configures the video usability information appearing in the SPS header automatically (depending on the other encoder settings)  @hideinitializer */
#define H264_VUI_PRESENTATION_CUSTOMIZE            0x00000001   /**< @brief Enable combination of the following flags for configure the video usability information appearing in the SPS header@hideinitializer */
#define H264_VUI_ASPECT_RATIO_INFO_PRESENT_FLAG    0x00000002   /**< @brief Enable aspect_ratio_info_present_flag @hideinitializer */
#define H264_VUI_OVERSCAN_INFO_PRESENT_FLAG        0x00000004   /**< @brief Enable overscan_info_present_flag @hideinitializer */
#define H264_VUI_VIDEO_SIGNAL_TYPE_PRESENT_FLAG    0x00000008   /**< @brief Enable video_signal_type_present_flag @hideinitializer */
#define H264_VUI_COLOUR_DESCRIPTION_PRESENT_FLAG   0x00000010   /**< @brief Enable colour_description_present_flag (@ref H264_VUI_VIDEO_SIGNAL_TYPE_PRESENT_FLAG "video_signal_type_present_flag" should be enabled as well) @hideinitializer */
#define H264_VUI_CHROMA_LOC_INFO_PRESENT_FLAG      0x00000020   /**< @brief Enable chroma_loc_info_present_flag (not supported) @hideinitializer */
#define H264_VUI_TIMING_INFO_PRESENT_FLAG          0x00000040   /**< @brief Enable timing_info_present_flag @hideinitializer */
#define H264_VUI_NAL_HRD_PARAMETERS_PRESENT_FLAG   0x00000080   /**< @brief Enable nal_hrd_parameters_present_flag @hideinitializer */
#define H264_VUI_VCL_HRD_PARAMETERS_PRESENT_FLAG   0x00000100   /**< @brief Enable vcl_hrd_parameters_present_flag @hideinitializer */
#define H264_VUI_PIC_STRUCT_PRESENT_FLAG           0x00000200   /**< @brief Enable pic_struct_present_flag @hideinitializer */
#define H264_VUI_BISTREAM_RESTRICTION_FLAG         0x00000400   /**< @brief Enable bitstream_restriction_flag @hideinitializer */
/** @}*/

/**
@def VIDEO_FORMATS
@name Video format defines
@{
**/
#define H264_VF_AUTO                                       -1   /**< @brief Auto video format detection @hideinitializer */
#define H264_VF_COMPONENT                                   0   /**< @brief Component format @hideinitializer */
#define H264_VF_PAL                                         1   /**< @brief PAL format @hideinitializer */
#define H264_VF_NTSC                                        2   /**< @brief NTSC format @hideinitializer */
#define H264_VF_SECAM                                       3   /**< @brief SECAM format @hideinitializer */
#define H264_VF_MAC                                         4   /**< @brief MAC format @hideinitializer */
#define H264_VF_UNSPECIFIED                                 5   /**< @brief Unspecified video format @hideinitializer */
/** @}*/

/**
@def INTERLACED_MODES
@name Interlaced mode defines
@{
**/
#define H264_PROGRESSIVE                                    0   /**< @brief Frame-based encoding. @hideinitializer */
#define H264_INTERLACED                                     1   /**< @brief Field-based - encode every frame as 2 field pictures. @hideinitializer */
#define H264_MBAFF                                          2   /**< @brief Macroblock-adaptive frame-field coding. @hideinitializer */
/** @}*/


/**
@def FIELD_ORDER
@name Field order defines
**/
#define H264_TOPFIELD_FIRST                                 0   /**< @brief  Interlaced encoding when top field is encoded first @hideinitializer */
#define H264_BOTTOMFIELD_FIRST                              1   /**< @brief  Interlaced encoding when bottom field is encoded first @hideinitializer */
/** @}*/

/**
@def RATE_CONTROL_MODES
@name Bit rate control mode defines
**/
#define H264_CBR                                            0   /**< @brief Constant bit rate mode.@hideinitializer */
#define H264_CQT                                            1   /**< @brief Constant quantization mode. @hideinitializer */
#define H264_VBR                                            2   /**< @brief Variable bit rate mode. @hideinitializer */
#define H264_TQM                                            3   /**< @brief Target quality mode. @hideinitializer */
/** @cond @brief  Special mode for Intra-only presets. @hideinitializer */
#define H264_INTRARC                                        4
/** @endcond */
/** @}*/

/**
@def HRD_BUFFER_UNITS
@name HRD buffer units defines
@{
**/
#define H264_HRD_UNIT_BYTE_PERCENT                          0   /**< @brief Original units (@ref h264_v_settings::bit_rate_buffer_size "bit_rate_buffer_size" in bytes, @ref h264_v_settings::vbv_buffer_fullness "vbv_buffer_fullness", @ref h264_v_settings::vbv_buffer_fullness_trg "vbv_buffer_fullness_trg" in percent). @hideinitializer */
#define H264_HRD_UNIT_BIT                                   1   /**< @brief All parameters are in bits. @hideinitializer */
#define H264_HRD_UNIT_BIT_90K                               2   /**< @brief @ref h264_v_settings::bit_rate_buffer_size "bit_rate_buffer_size" in bits, @ref h264_v_settings::vbv_buffer_fullness "vbv_buffer_fullness", @ref h264_v_settings::vbv_buffer_fullness_trg "vbv_buffer_fullness_trg" in 90 kHz clock units. @hideinitializer */
/** @}*/

/**
@def ADAPTIVE_QUANTIZATION_MODES
@name Adaptive quantization mode defines
@{
**/
#define H264_AQUANT_MODE_BRIGHTNESS                         0   /**< @brief Adaptive quantization mode is driven by macroblocks' brightness @hideinitializer */
#define H264_AQUANT_MODE_CONTRAST                           1   /**< @brief Adaptive quantization mode is driven by macroblocks' contrast @hideinitializer */
#define H264_AQUANT_MODE_COMPLEXITY                         2   /**< @brief Adaptive quantization mode is driven by macroblocks' complexity @hideinitializer */
/** @}*/

/**
@def ENTROPY_CODING
@name Entropy coding mode defines
@{
**/
#define H264_CAVLC                                          0 /**< @brief Context-based adaptive variable-length coding. @hideinitializer */
#define H264_CABAC                                          1 /**< @brief Context-based adaptive binary arithmetic coding (not allowed for @ref h264_v_settings::profile_id "profile_id" equal to @ref H264PROFILE_BASELINE). @hideinitializer */
/** @}*/

/**
@def CPU_TYPE
@name CPU type defines
@{
**/
#define H264_CPU_OPT_AUTO                                   0   /**< @brief SIMD instruction usage based on CPUID. @hideinitializer */
#define H264_CPU_OPT_UNKNOWN                                1   /**< @brief Disables SIMD instruction usage, pure C. @hideinitializer */
#define H264_CPU_OPT_MMX                                    2   /**< @brief Limits SIMD instruction usage to Intel MMX. @hideinitializer */
#define H264_CPU_OPT_MMX_EXT                                3   /**< @brief Limits SIMD instruction usage to Intel MMXEXT. @hideinitializer */
#define H264_CPU_OPT_SSE                                    4   /**< @brief Limits SIMD instruction usage to Intel SSE. @hideinitializer */
#define H264_CPU_OPT_SSE2                                   5   /**< @brief Limits SIMD instruction usage to Intel SSE2. @hideinitializer */
#define H264_CPU_OPT_SSE3                                   6   /**< @brief Limits SIMD instruction usage to Intel SSSE3. @hideinitializer */
#define H264_CPU_OPT_SSE4                                   7   /**< @brief Limits SIMD instruction usage to Intel SSE4.1. @hideinitializer */
#define H264_CPU_OPT_AVX                                    8   /**< @brief Limits SIMD instruction usage to Intel AVX. @hideinitializer */
#define H264_CPU_OPT_AVX2                                   9   /**< @brief Limits SIMD instruction usage to Intel AVX2. @hideinitializer */
/** @}*/

/**
@def INTER_SEARCH
@name Inter search defines
@{
**/
#define H264_INTERSEARCH_16x16  0                               /**< @brief Motion estimation block partitions will have size 16x16 only. @hideinitializer */
#define H264_INTERSEARCH_8x8    1                               /**< @brief Motion estimation block partitions will have size 8x8, 8x16, 16x8 or 16x16. @hideinitializer */
/** @}*/

/**
@def SUBPEL
@name Subpixel mode defines
@{
**/
#define H264_FULL_PEL           0                             /**< @brief Only full pixel position will be examined. @hideinitializer */
#define H264_HALF_PEL           1                             /**< @brief Half-pixels positions will be added to the search. @hideinitializer */
#define H264_QUARTER_PEL        2                             /**< @brief Both half and quarter pixel positions will be added. @hideinitializer */
#define H264_QUARTER_PEL_ON_REF 3                             /**< @brief Both half and quarter pixel positions will be added for reference pictures, no quarter pixel positions for non-reference pictures. @hideinitializer */

/** @}*/

/**
@def TIME_STAMP
@name Time stamp
@{
**/
#define H264_TIMESTAMP_100NS    0                             /**< @brief  DirectShow style, 100 ns units (10 Mhz clock). @hideinitializer */
#define H264_TIMESTAMP_27MHZ    1                             /**< @brief  MPEG style, 27 Mhz clock @hideinitializer */
/** @}*/

/**
@def DISPLAY_MODE
@name Display mode defines
**/
#define H264_DISPLAY_FRAME      0                             /**< @brief Display as progressive frame @hideinitializer. */
#define H264_DISPLAY_TF         1                             /**< @brief Top field @hideinitializer */
#define H264_DISPLAY_BF         2                             /**< @brief Bottom field @hideinitializer */
#define H264_DISPLAY_TF_BF      3                             /**< @brief Top field, bottom field @hideinitializer */
#define H264_DISPLAY_BF_TF      4                             /**< @brief Bottom field, top field @hideinitializer */
#define H264_DISPLAY_TF_BF_TF   5                             /**< @brief Top field, bottom field, top field @hideinitializer */
#define H264_DISPLAY_BF_TF_BF   6                             /**< @brief Bottom field, top field, bottom field @hideinitializer */
#define H264_DISPLAY_DOUBLE     7                             /**< @brief Display frame twice @hideinitializer */
#define H264_DISPLAY_TRIPLE     8                             /**< @brief Display frame three times @hideinitializer */
/** @}*/

/**
@def USER_DATA_TYPES
@name User data type defines (h264_user_data_tt's type)
@{
**/
#define H264_UD_REGISTERED      1                             /**< @brief user data registered by ITU-T Rec. T.35 SEI message @hideinitializer */
#define H264_UD_UNREGISTERED    2                             /**< @brief user data unregistered SEI message @hideinitializer */
/** @}*/

/**
@def AIR_MODES
@name Adaptive intra refresh modes
@{
**/
#define H264_AIR_OFF            0                             /**< @brief Do not use AIR. @hideinitializer */
#define H264_AIR_SLOW           1                             /**< @brief 1 (SD) or 2 (HD) rows of intra macroblocks in every P frame. @hideinitializer */
#define H264_AIR_MEDIUM         2                             /**< @brief 2 (SD) or 4 (HD) rows of intra macroblocks in every P frame. @hideinitializer */
#define H264_AIR_FAST           3                             /**< @brief 3 (SD) or 6 (HD) rows of intra macroblocks in every P frame. @hideinitializer */
#define H264_AIR_SPLIT          4                             /**< @brief Adjust intra_line_offset for this mode.  @hideinitializer */
/** @}*/

/**
@def ME_SEARCH_MODES
@name Motion search algorithms
@{
**/
#define H264_DIAMOND          0                             /**< @brief Diamond shaped search algorithm with 9 points to check @hideinitializer */
#define H264_HEX_HORZ         1                             /**< @brief Thick horizontal hexagonal motion search algorithm, 7 points to check @hideinitializer */
#define H264_HEX_HORZ_FLAT    2                             /**< @brief Flat horizontal hexagonal motion search algorithm, 7 points to check @hideinitializer */
#define H264_HEX_VERT         3                             /**< @brief Thick vertical hexagonal motion search algorithm, 7 points to check @hideinitializer */
#define H264_HEX_VERT_FLAT    4                             /**< @brief Flat vertical hexagonal motion search algorithm, 7 points to check @hideinitializer */
/** @}*/

////////// defines for h264 conformance check

/**
@def CHK_OPTIONS
@name Options for the h264OutVideoChkSettings function
@{
**/
#define H264_CHECK_AND_ADJUST   0x00000001   /**< @brief Adjust parameters to satisfy preset, profile and level limitations @hideinitializer */
#define H264_CHECK_FOR_LEVEL    0x00000002   /**< @brief Adjust level to allow encoding with given parameters @hideinitializer */
/** @}*/

/**
@def DEINTERLACING_MODES
@name Deinterlacing modes
@{
**/
#define H264_DEINTERLACE_NONE            0 /**<@brief Disable deinterlacing. @hideinitializer*/
#define H264_DEINTERLACE_ON              1 /**<@brief Keep first field unchanged, interpolate the other. @hideinitializer*/
#define H264_DEINTERLACE_USETOPFIELD     2 /**<@brief Keep top field unchanged interpolate the other. @hideinitializer*/
#define H264_DEINTERLACE_USEBOTTOMFIELD  3 /**<@brief Keep bottom field unchanged interpolate the other. @hideinitializer*/
#define H264_DEINTERLACE_USEBOTHFIELDS   4 /**<@brief Blend fields. @hideinitializer*/
/** @}*/

/**
@def PERFORMANCE_OPTIONS
@name Options for the h264OutVideoPerformance function
@{
**/
#define H264_PERF_FASTEST       0                             /**< @brief Fastest mode. @hideinitializer */
#define H264_PERF_BALANCED      9                             /**< @brief Recommended default value. @hideinitializer */
#define H264_PERF_BEST_Q        15                            /**< @brief Best quality mode. @hideinitializer */
/** @}*/

/**
@def FPAM_MODES
@name Defines for Frame packing arrangement mode definition
@{
**/
#define H264_FPAM_DONT_WRITE            0                   /**< @brief Don`t write frame packing arrangement SEI messages. @hideinitializer */
#define H264_FPAM_CHECKBOARD            1                   /**< @brief Write SEI messages with frame_packing_arrangement_type = 0. Each component plane of the decoded frames contains a "checkerboard" based interleaving of corresponding planes of two constituent frames. @hideinitializer */
#define H264_FPAM_COLUMN_INTERLEAVING   2                   /**< @brief Write SEI messages with frame_packing_arrangement_type = 1. Each component plane of the decoded frames contains a column based interleaving of corresponding planes of two constituent frames.@hideinitializer */
#define H264_FPAM_ROW_INTERLEAVING      3                   /**< @brief Write SEI messages with frame_packing_arrangement_type = 2. Each component plane of the decoded frames contains a row based interleaving of corresponding planes of two constituent frames.@hideinitializer */
#define H264_FPAM_SIDE_BY_SIDE          4                   /**< @brief Write SEI messages with frame_packing_arrangement_type = 3. Each component plane of the decoded frames contains a side-by-side packing arrangement of corresponding planes of two constituent frames. @hideinitializer */
#define H264_FPAM_TOP_BOTTOM            5                   /**< @brief Write SEI messages with frame_packing_arrangement_type = 4. Each component plane of the decoded frames contains a top-bottom packing arrangement of corresponding planes of two constituent frames. @hideinitializer */
/** @}*/

/**
@def PRODUCT_INFO
@name Defines for Stream creation product info
@{
**/
#define H264_NO_MESSAGE_IN_SEI          0                  /**< @brief Do not write. @hideinitializer */
#define H264_LL_MESSAGE_IN_SEI          1                  /**< @brief Write as for LL component. @hideinitializer */
#define H264_DS_MESSAGE_IN_SEI          2                  /**< @brief Write as for DS component. @hideinitializer */
/** @}*/

/**
@def RETURN_CODES
@name API functions return codes.
@cond
Error codes for new API settings is to added to the end of this list.
@endcond
@{
**/
#define H264ERROR_NONE                                  0   /**< @brief No error. @hideinitializer */
#define H264ERROR_FAILED                                1   /**< @brief General error. @hideinitializer @hideinitializer */
#define H264ERROR_NOT_SUPPORTED                         2   /**< @brief Attempt to use an unsupported function. @hideinitializer */
#define H264ERROR_PARAM_UNKNOWN                         3   /**< @brief Unknown parameter. @hideinitializer */
#define H264ERROR_PARAM_ADJUSTED                        4   /**< @brief Parameter adjusted by validation routine. @hideinitializer */
#define H264ERROR_AVC_INTRA_SKIPPED_FRAME               5   /**< @brief Frame cannot be encoded (applicable only for Intra-preset encoding). @hideinitializer */
#define H264ERROR_OUT_OF_MEM                            6   /**< @brief Not enough memory. @hideinitializer */
/** @}*/

/**
@brief Error codes for incorrect API settings
**/
typedef enum param_set_errors_e
{
    Error_param_set  = 0,
    Error_profile_id = 1,
    Error_level_id,
    Error_idr_interval,
    Error_reordering_delay,
    Error_interlace_mode,
    Error_def_horizontal_size,
    Error_def_vertical_size,
    Error_frame_rate,
    Error_num_reference_frames,
    Error_search_range,
    Error_rd_optimization,
    Error_max_l0_active,
    Error_max_l1_active,
    Error_quant_pI,
    Error_quant_pP,
    Error_quant_pB,
    Error_bit_rate_mode,
    Error_bit_rate_buffer_size,
    Error_bit_rate,
    Error_max_bit_rate,
    Error_inter_search_shape,
    Error_entropy_coding_mode,
    Error_use_hadamard_transform,
    Error_sar_width,
    Error_sar_height,
    Error_video_format,
    Error_video_full_range,
    Error_num_units_in_tick,
    Error_time_scale,
    Error_vbv_fullness,
    Error_vbv_fullness_trg,
    Error_vbv_units,
    Error_cpb_removal_delay,
    Error_br_scale,
    Error_cpb_size_scale,
    Error_max_frame_size,
    Error_hrd_maintain,
    Error_min_frame_size,
    Error_hrd_low_delay,
    Error_smooth_factor,
    Error_hrd_preview,
    Error_use_deblocking_filter,
    Error_deblocking_alphac0_offset,
    Error_deblocking_beta_offset,
    Error_adaptive_deblocking,
    Error_video_type,
    Error_video_pulldown,
    Error_overscan_appropriate_flag,
    Error_colour_primaries,
    Error_transfer_characteristics,
    Error_matrix_coefficients,
    Error_extended_sar,
    Error_stream_type,
    Error_bit_depth_luma,
    Error_bit_depth_chroma,
    Error_chroma_format,
    Error_pic_init_qp,
    Error_pic_init_qs,
    Error_vui_presentation,
    Error_write_au_delimiters,
    Error_write_seq_end_code,
    Error_write_timestamps,
    Error_timestamp_offset,
    Error_drop_frame_timecode,
    Error_write_single_sei_per_nalu,
    Error_write_seq_par_set,
    Error_write_pic_par_set,
    Error_log2_max_poc,
    Error_log2_max_frame_num,
    Error_pic_order_cnt_type,
    Error_pic_order_present_flag,
    Error_fixed_frame_rate,
    Error_frame_based_timing,
    Error_frame_packing_arrangement,
    Error_stream_creation_product_info,
    Error_write_pic_timing_sei,
    Error_write_settings_info,
    Error_frame_num_gaps_allowed_flag,
    Error_vcsd_mode,
    Error_slice_mode,
    Error_slice_arg,
    Error_b_slice_ref,
    Error_b_slice_pyramid,
    Error_cb_offset,
    Error_cr_offset,
    Error_subpel_mode,
    Error_weighted_p_mode,
    Error_weighted_b_mode,
    Error_fast_intra,
    Error_fast_inter,
    Error_pic_ar_x,
    Error_pic_ar_y,
    Error_calc_quality,
    Error_cpu_opt,
    Error_num_threads,
    Error_live_modeE,
    Error_buffering,
    Error_max_quant,
    Error_min_quant,
    Error_max_slice_size,
    Error_encoding_buffering,
    Error_air_mode,
    Error_detach_thread,
    Error_constrained_intra_pred,
    Error_air_split_frequency,
    Error_air_qp_offset,
    Error_convert_pixel_range,
    Error_deinterlacing_mode,
    Error_min_idr_interval,
    Error_adaptive_b_frames,
    Error_idr_frequency,
    Error_field_order,
    Error_fixed_i_position,
    Error_isolated_gops,
    Error_leading_b,
    Error_fast_multi_ref_me,
    Error_fast_sub_block_me,
    Error_allow_out_of_pic_mvs,
    Error_constrained_ref_list,
    Error_enable_intra_big,
    Error_enable_intra_8x8,
    Error_enable_intra_4x4,
    Error_enable_intra_pcm,
    Error_enable_inter_big,
    Error_enable_inter_8x8,
    Error_enable_inter_4x4,
    Error_enable_inter_pcm,
    Error_fast_rd_optimization,
    Error_quant_mode,
    Error_grain_mode,
    Error_grain_opt_strength,
    Error_adaptive_quant_strength,
    Error_denoise_strength_y,
    Error_black_norm_level,
    Error_denoise_strength_c,
    Error_pulse_reduction,
    Error_aux_format_idc,
    Error_bit_depth_aux,
    Error_alpha_incr_flag,
    Error_alpha_opaque_value,
    Error_alpha_transparent_value,
    Error_seq_scaling_matrix_present_flag,
    Error_seq_scaling_list_present_flag,
    Error_intra_y_4x4_scaling_list,
    Error_intra_cb_4x4_scaling_list,
    Error_intra_cr_4x4_scaling_list,
    Error_inter_y_4x4_scaling_list,
    Error_inter_cb_4x4_scaling_list,
    Error_inter_cr_4x4_scaling_list,
    Error_intra_y_8x8_scaling_list,
    Error_inter_y_8x8_scaling_list,
    Error_num_parallel_pics,
    Error_enable_fast_intra_decisions,
    Error_enable_fast_inter_decisions,
    Error_crop_params,
    Error_motion_search_pattern,
    Error_mastering_display_metadata,
    Error_content_light_level,
    Error_param_set_last
} param_set_errors_t;

/**
@brief Table A1 Error codes.
**/
typedef enum table_a1_error_e
{
    Level_err_table_a1     = 0,
    Level_err_mb_proc_rate = 1,
    Level_err_frame_size,
    Level_err_dpb,
    Level_err_br,
    Level_err_cpb,
    Level_err_search_range
} table_a1_error_t;

/**
@brief Primary check error codes.
**/
typedef enum primary_check_errors_e
{
    Primary_check_error = 0,
    Invalid_picture_mode = 1,
    Invalid_resolution,
    Invalid_frame_rate
}primary_check_errors_t;

/**
@def INTRA_4x4_FLAGS
@name Flags to disable certain 4x4 intra prediction modes. DC mode cannot be disabled.
@{
**/
#define H264_4x4_ENABLED      0x00000001 /**<@brief Enable 4x4 intra prediction modes usage. @hideinitializer */
#define H264_DISABLE_4x4_V    0x00000002 /**<@brief Disable vertical 4x4 intra prediction mode. @hideinitializer */
#define H264_DISABLE_4x4_H    0x00000004 /**<@brief Disable horizontal 4x4 intra prediction mode. @hideinitializer */
#define H264_DISABLE_4x4_DDL  0x00000010 /**<@brief Disable diagonal down left 4x4 intra prediction mode. @hideinitializer */
#define H264_DISABLE_4x4_DDR  0x00000020 /**<@brief Disable diagonal down right 4x4 intra prediction mode. @hideinitializer */
#define H264_DISABLE_4x4_VR   0x00000040 /**<@brief Disable vertical right 4x4 intra prediction mode. @hideinitializer */
#define H264_DISABLE_4x4_HD   0x00000080 /**<@brief Disable horizontal down 4x4 intra prediction mode. @hideinitializer */
#define H264_DISABLE_4x4_VL   0x00000100 /**<@brief Disable vertical left 4x4 intra prediction mode. @hideinitializer */
#define H264_DISABLE_4x4_HU   0x00000200 /**<@brief Disable horizontal up 4x4 intra prediction mode. @hideinitializer */
/** @}*/

/**
@def INTRA_8x8_FLAGS
@name Flags to disable certain 8x8 intra prediction modes. DC mode cannot be disabled.
@{
**/
#define H264_8x8_ENABLED      0x00000001 /**<@brief Enable 8x8 intra prediction modes usage. @hideinitializer */
#define H264_DISABLE_8x8_V    0x00000002 /**<@brief Disable vertical 8x8 intra prediction mode. @hideinitializer */
#define H264_DISABLE_8x8_H    0x00000004 /**<@brief Disable horizontal 8x8 intra prediction mode. @hideinitializer */
#define H264_DISABLE_8x8_DDL  0x00000010 /**<@brief Disable diagonal down left 8x8 intra prediction mode. @hideinitializer */
#define H264_DISABLE_8x8_DDR  0x00000020 /**<@brief Disable diagonal down right 8x8 intra prediction mode. @hideinitializer */
#define H264_DISABLE_8x8_VR   0x00000040 /**<@brief Disable vertical right 8x8 intra prediction mode. @hideinitializer */
#define H264_DISABLE_8x8_HD   0x00000080 /**<@brief Disable horizontal down 8x8 intra prediction mode. @hideinitializer */
#define H264_DISABLE_8x8_VL   0x00000100 /**<@brief Disable vertical left 8x8 intra prediction mode. @hideinitializer */
#define H264_DISABLE_8x8_HU   0x00000200 /**<@brief Disable horizontal up 8x8 intra prediction mode. @hideinitializer */
/** @}*/

/**
@def INTRA_BIG_FLAGS
@name Flags to disable certain 16x16 intra prediction modes. DC mode cannot be disabled.
@{
**/
#define H264_16x16_ENABLED    0x00000001 /**<@brief Enable 16x16 intra prediction modes usage. @hideinitializer */
#define H264_DISABLE_16x16_V  0x00000002 /**<@brief Disable vertical 16x16 intra prediction mode. @hideinitializer */
#define H264_DISABLE_16x16_H  0x00000004 /**<@brief Disable horizontal 16x16 intra prediction mode. @hideinitializer */
#define H264_DISABLE_16x16_P  0x00000010 /**<@brief Disable plane 16x16 intra prediction mode. @hideinitializer */
/** @}*/

/**
@brief Enum to set field number for user data
**/
typedef enum ud_field_e {
    ud_first_field,  /**<@brief Attach UD to first field(use for progressive). @hideinitializer */
    ud_second_field, /**<@brief Attach UD to second field. @hideinitializer */
    ud_both_fields   /**<@brief Attach UD to both fields. */
}ud_field_t;

#endif // #if !defined (__ENC_AVC_DEF_INCLUDED__)

