/**
@file: enc_avc.h
@brief AVC/H.264 Encoder API

@verbatim
File: enc_avc.h
Desc: AVC/H.264 Encoder API

Copyright (c) 2014 MainConcept GmbH or its affiliates.  All rights reserved.

MainConcept and its logos are registered trademarks of MainConcept GmbH or its affiliates.
This software is protected by copyright law and international treaties.  Unauthorized
reproduction or distribution of any portion is prohibited by law.
@endverbatim
 **/

#if !defined (__ENC_AVC_API_INCLUDED__)
#define __ENC_AVC_API_INCLUDED__

#include "mctypes.h"
#include "mcprofile.h"
#include "mcapiext.h"
#include "mcdefs.h"

#include "bufstrm.h"

#include "enc_avc_def.h"
#include "v_frame.h"


typedef struct h264_v_encoder  h264venc_tt;             /**<@brief AVC/H.264 Video Encoder instance type */
typedef struct h264_v_settings h264_v_settings_tt;
typedef struct avc_mastering_display_metadata avc_mastering_display_metadata_tt;
typedef struct avc_content_light_level        avc_content_light_level_tt;

/**
* @brief SMPTE ST 2086 Mastering display colour volume primaries
* @{
**/
struct avc_mastering_display_metadata
{
    int32_t display_primaries_x[3];                     /**<@brief The normalized x-coordinate chromaticity of the mastering display in increments of 0.00002 for 3 colour components. Please refer D.3.27 section of Rec. ITU-T H.264 for more information.*/
    int32_t display_primaries_y[3];                     /**<@brief The normalized y-coordinate chromaticity of the mastering display in increments of 0.00002 for 3 colour components. Please refer D.3.27 section of Rec. ITU-T H.264 for more information. */
    int32_t white_point_x;                              /**<@brief The normalized x-coordinate chromaticity of the white point of the mastering display in normalized increments of 0.00002. Please refer D.3.27 section of Rec. ITU-T H.264 for more information. */
    int32_t white_point_y;                              /**<@brief The normalized y-coordinate chromaticity of the white point of the mastering display in normalized increments of 0.00002. Please refer D.3.27 section of Rec. ITU-T H.264 for more information. */
    int64_t max_display_mastering_luminance;            /**<@brief The nominal maximum display luminance of the mastering display in units of 0.0001 candelas per square metre. Please refer D.3.27 section of Rec. ITU-T H.264 for more information.*/
    int64_t min_display_mastering_luminance;            /**<@brief The nominal minimum display luminance of the mastering display in units of 0.0001 candelas per square metre. Please refer D.3.27 section of Rec. ITU-T H.264 for more information.*/
};
/** @} */

/**
* @brief Content Light Level is an additional Static Metadata item that applies to HDR Content only.
* @{
**/
struct avc_content_light_level
{
    int32_t max_content_light_level;                    /**<@brief Maximum Content Light Level (MaxCLL). */
    int32_t max_pic_average_light_level;                /**<@brief Maximum Picture-Average Light Level (MaxPALL, also mentioned as MaxFALL). */
};
/** @} */
/**
*@brief Custom settings
**/
typedef enum
{
    SHOW_BREF_FRAMES = 1  /**<@brief  If set, the encoder outputs B reference frames with pict_type == 4 (default pict_type == 3 for B and B referenced frames) @hideinitializer */
} CUSTOM_FLAGS;

#pragma pack(push,1)

/**
 * @name h264_v_settings
 * Settings Structure
 * @{
 **/

 /**
 *@details These parameters are used to configure the encoder.
 */
struct h264_v_settings
{
  int32_t   profile_id;                 /**<@brief H.264/AVC Profile used to encode. */
  int32_t   level_id;                   /**<@brief H.264/AVC Level (times ten) used to maintain conformance of encoded file. */
  int32_t   idr_interval;               /**<@brief Maximum distance between two I frames. */
  int32_t   reordering_delay;           /**<@brief Maximum distance between two P frames. */
  int32_t   use_b_slices;               /**<@brief Obsolete. */
  int32_t   interlace_mode;             /**<@brief Specifies whether video is encoded frame-based or field-based.*/
  int32_t   def_horizontal_size;        /**<@brief Width of the encoded video frame. */
  int32_t   def_vertical_size;          /**<@brief Height of the encoded video frame. */
  double    frame_rate;                 /**<@brief Frame rate of the encoded video. */

 /**
 * @name Motion search settings
 * @{
 **/
  int32_t   num_reference_frames;       /**<@brief Number of reference pictures used. */
  int32_t   search_range;               /**<@brief Motion vector search range. */
  int32_t   rd_optimization;            /**<@brief Enables rate-distortion optimization. */
  int32_t   max_l0_active;              /**<@brief Maximum index of reference frames in List0. */
  int32_t   max_l1_active;              /**<@brief Maximum index of reference frames in List1. */
  /** @} */

 /**
 * @name Quantization parameters
 * @{
 **/
  int32_t   quant_pI;                   /**<@brief Macroblock quantization parameter value for I slices to use in constant quantization bitrate mode.*/
  int32_t   quant_pP;                   /**<@brief Macroblock quantization parameter value for P slices to use in constant quantization bitrate mode.*/
  int32_t   quant_pB;                   /**<@brief Macroblock quantization parameter value for B slices to use in constant quantization bitrate mode.*/
/** @} */

 /**
 * @name Bit rate stuff
 * @{
 **/
  int32_t   bit_rate_mode;              /**<@brief Bitrate control mode. */
  int32_t   bit_rate_buffer_size;       /**<@brief VBV size. */
  int32_t   bit_rate;                   /**<@brief Target bitrate (bits per second) of encoded video sequence. */
  int32_t   max_bit_rate;               /**<@brief Hypothetical Stream Scheduler (HSS) delivery rate or the rate at which VBV buffer is filled, not real maximum peak rate. */
/** @} */

/**
 * @name Prediction
 * @{
 **/
  int32_t   inter_search_shape;         /**<@brief Type of subblock search for macroblocks. */
/** @} */

 /**
 * @name Coding mode
 * @{
 **/
  int32_t   entropy_coding_mode;        /**<@brief Entropy coding mode. */
  int32_t   use_hadamard_transform;     /**<@brief Use Hadamard transformation to get higher compression ratio. */
/** @} */

 /**
  * @name VUI parameters
  * @{
  **/
  int32_t   sar_width;                  /**<@brief Sample aspect ratio: horizontal sample size in arbitrary units. */
  int32_t   sar_height;                 /**<@brief Sample aspect ratio: vertical sample size in arbitrary units. */
  int32_t   video_format;               /**<@brief Type of video representation. */
  int32_t   video_full_range;           /**<@brief Independent setting of video_full_range_flag in VUI parameters. */
  int32_t   num_units_in_tick;          /**<@brief Number of time units of a clock operating at the frequency @ref time_scale Hz that corresponds to one clock tick. */
  int32_t   time_scale;                 /**<@brief Number of time units that pass in one second. */
/** @} */

/**
 * @name Advanced settings
 * @{
 **/
  int32_t   vbv_buffer_fullness;        /**<@brief Initial VBV fullness. */
  int32_t   vbv_buffer_fullness_trg;    /**<@brief Target VBV fullness when decoding is done. */
  int32_t   vbv_buffer_units;           /**<@brief Units of VBV-fullness and buffer size. */
  int32_t   cpb_removal_delay;          /**<@brief CPB removal delay for the first picture (needed for segment merging). */
/** @cond */
  int32_t   reserved_1[3];
/** @endcond */
  int32_t   bit_rate_scale;             /**<@brief  External setting of bit_rate_scale (avoids recalculation of bitrate) */
  int32_t   cpb_size_scale;             /**<@brief  External setting of cpb_size_scale (avoids recalculation of bitrate) */

  int32_t   max_frame_size[4];          /**<@brief  Maximum byte size for I, P, B-reference and B frames. */
  int32_t   hrd_maintain;               /**<@brief  0 = HRD model disabled, 1 = HRD model enabled. */
  int32_t   min_frame_size[4];          /**<@brief  Minimum byte size for I, P, B-reference, B frames. */
  int32_t   hrd_low_delay;              /**<@brief  0 = low delay HRD disabled, 1 = low delay HRD enabled. */
  int32_t   smooth_factor;              /**<@brief  Quantizer curve compression smooth factor, 0 = disabled. */
  int32_t   hrd_preview;                /**<@brief  Quality feature, turned on by default. Encoder performs preliminary analysis on defined frame window. Frame window is set by the means of @ref encoding_buffering and should be at least 3 seconds and be less or equal to @ref buffering. Frames are delivered with expected delay in this case. */
/** @} */

/**
* @name Cropping offset parameters
* @{
**/
  int32_t   frame_crop_left_offset;     /**<@brief Cropping offset from the left side of a picture in pixels. */
  int32_t   frame_crop_right_offset;    /**<@brief Cropping offset from the right side of a picture in pixels. @ref frame_crop_left_offset "More..." */
  int32_t   frame_crop_top_offset;      /**<@brief Cropping offset from the top of a picture in pixels. @ref frame_crop_left_offset "More..." */
  int32_t   frame_crop_bottom_offset;   /**<@brief Cropping offset from the bottom of a picture in pixels. @ref frame_crop_left_offset "More..." */
/** @} */

/**
* @name Advanced reference control
* @{
**/
  int32_t   allow_override_max_l0_l1;   /**<@brief Writes the values specified by @ref max_l0_active and @ref max_l1_active to a PPS and writes actual reference count on slice headers. */
/** @cond */
  int32_t   reserved_1_1[7];
/** @endcond */
/** @} */

/**
 * @name In-loop filter
 * @{
 **/
  int32_t   use_deblocking_filter;      /**<@brief Indicates whether to use deblocking for smoothing video frames. */
  int32_t   deblocking_alphaC0_offset;  /**<@brief Specifies the offset used in accessing alpha deblocking filter table for filtering operations controlled by the macroblocks within a slice. */
  int32_t   deblocking_beta_offset;     /**<@brief Specifies the offset used in accessing beta deblocking filter table for filtering operations controlled by the macroblocks within a slice. */
/** @cond */
  int32_t   reserved_2_1[3];
/** @endcond */
  int32_t   adaptive_deblocking;        /**<@brief Enables the usage of deblocking filter with alternative offsets related to the quantizer or with standard ones. */
/** @cond */
  int32_t   reserved_2[380];
/** @endcond */
/** @} */

 /**
 * @name Type issues
 * @{
 **/
  int32_t   video_type;                 /**<@brief Encoder preset. */
  int32_t   video_pulldown_flag;        /**<@brief Specifies the NTSC pulldown generated in the video stream. */
/** @cond */
  int32_t   reserved_3[30];
/** @endcond */
/** @} */

/**
 * @name Additional vui parameters
 * @{
 **/
  int32_t   overscan_appropriate_flag;  /**<@brief Indicates whether the cropped decoded pictures output are suitable for display using overscan. */
  int32_t   colour_primaries;           /**<@brief Indicates the chromaticity coordinates of the source primaries. */
  int32_t   transfer_characteristics;   /**<@brief Indicates transfer characteristics of the source primaries, defines formula for the gamma correction that wasn't implemented yet in UCC. */
  int32_t   matrix_coefficients;        /**<@brief Indicates matrix coefficients of the source primaries. */
  int32_t   extended_sar;               /**<@brief Enables writing extended sample aspect ratio in a stream. */
/** @cond */
  int32_t   reserved_3_0[65];
/** @endcond */
/** @} */

 /**
 * @name File/stream issues
 * @{
 **/
  int32_t   stream_type;                /**<@brief Defines the sort of NALU types being written into stream. */
  int32_t   frame_mbs_mode;             /**<@brief Obsolete. */
/** @cond */
  int32_t   reserved_3_1[6];
/** @endcond */
  int32_t   bit_depth_luma;             /**<@brief Specifies the bit depth of encoded luminance samples. */
  int32_t   bit_depth_chroma;           /**<@brief Specifies the bit depth of encoded chrominance samples. */
  int32_t   chroma_format;              /**<@brief Chrominance sampling. */
/** @cond */
  int32_t   reserved_3_2[12];
/** @endcond */
  int32_t   pic_init_qp;                /**<@brief Corresponds to field pic_init_qp_minus26 in PPS. By default it has value of 26 and there is no significant reason to change it. Parameter is available via API only. */
  int32_t   pic_init_qs;                /**<@brief Corresponds to field pic_init_qs_minus26 in PPS. As long as the encoder doesn't support SI and SP slices this field affects only PPS. Parameter is available via API only. */
  uint32_t  vui_presentation;           /**<@brief Configures video usability information (VUI) parameters header appearing in SPS. */
  int32_t   write_au_delimiters;        /**<@brief Write access unit delimiters. */
  int32_t   write_seq_end_code;         /**<@brief Write sequence end code. */
  int32_t   write_timestamps;           /**<@brief Write picture timing information into Picture Timing SEI of the encoded stream. */
  int32_t   timestamp_offset;           /**<@brief Frame based offset (in number of frames) for timestamps (i.e DTS/PTS). */
  int32_t   drop_frame_timecode;        /**<@brief Use NTSC drop frame timecode notation for 29.97 and 59.94 target frame rates. */
  int32_t   write_single_sei_per_nalu;  /**<@brief Encapsulates each SEI message into its own NAL unit. */
  int32_t   write_seq_par_set;          /**<@brief Controls writing of sequence parameter set (SPS) into a stream. */
  int32_t   write_pic_par_set;          /**<@brief Controls writing of picture parameter set (PPS) into a stream. */
  int32_t   log2_max_poc;               /**<@brief Specifies custom log2_max_pic_order_cnt_lsb_minus4 value. */
  int32_t   log2_max_frame_num;         /**<@brief Specifies custom log2_max_frame_num_minus4 value. */
  int32_t   pic_order_cnt_type;         /**<@brief Specifies custom pic_order_cnt_type value. */
  int32_t   pic_order_present_flag;     /**<@brief Controls bottom_field_pic_order_in_frame_present_flag value in PPS (e.g. for SBTVD-T). */
  int32_t   fixed_frame_rate;           /**<@brief Controls fixed_frame_rate_flag in VUI. */
  int32_t   frame_based_timing;         /**<@brief Write frame rate in VUI (instead of field rate by default). */
  int32_t   frame_packing_arrangement_mode; /**<@brief Defines a mode for Frame packing arrangement SEI messages writing. */
  int32_t   stream_creation_product_info;   /**<@brief Enables writing product name and version number in a stream. */
  int32_t   write_pic_timing_sei;       /**<@brief Enables writing of Picture timing SEI message. */
  int32_t   write_settings_info;        /**<@brief Enables writing encoder settings in a stream. */
  int32_t   frame_num_gaps_allowed_flag;/**<@brief Sets gaps_in_frame_num_value_allowed_flag for decoder to create "dummy" decoded frames to fill gap. */
  CUSTOM_FLAGS custom_bit_flags;        /**<@brief Set of flags for customer needs. */
  int32_t   normalize_dts;              /**<@brief Make decoded timestamp (DTS) start with 0. */
  avc_mastering_display_metadata mastering_display_metadata;/**<@brief SMPTE ST 2086 Mastering display metadata. Please see @ref HDR_SMPTE_ST_2086_SIGNALLING "Mastering display colour volume signalling" */
  avc_content_light_level        content_light_level;       /**<@brief Content Light Level metadata. */
/** @cond */
  int32_t   reserved_4[95];
/** @endcond */
/** @} */

/**
 * @name Scene detection
 * @{
 **/
  int32_t   vcsd_mode;                  /**<@brief Visual content scene detection. */
  int32_t   vcsd_sensibility;           /**<@brief Obsolete. */
/** @} */

/**
 * @name Advanced settings
 * @{
 **/
  int32_t   slice_mode;                 /**<@brief Currently only fixed number of slices per picture is implemented. */
  int32_t   slice_arg;                  /**<@brief Number of slices per picture. */
  int32_t   b_slice_reference;          /**<@brief Enables usage B pictures as a reference pictures. */
  int32_t   b_slice_pyramid;            /**<@brief Enables usage of pyramidal GOP structure  (...B Br B...). */
  int32_t   cb_offset;                  /**<@brief Chroma quality offset (-X -> increase quality, +X -> decrease quality). */
  int32_t   cr_offset;                  /**<@brief Chroma quality offset (-X -> increase quality, +X -> decrease quality). */
  int32_t   me_subpel_mode;             /**<@brief Describes subpixel motion search depth. */
  int32_t   me_weighted_p_mode;         /**<@brief Enables explicit weighted prediction usage for P-frames. */
  int32_t   me_weighted_b_mode;         /**<@brief Currently not used. */
  int32_t   enable_fast_intra_decisions;/**<@brief Enables fast intra coding decision metrics usage to speed up encoding process. */
  int32_t   enable_fast_inter_decisions;/**<@brief Enables fast inter coding decision metrics usage to speed up encoding process. */
  int32_t   pic_ar_x;                   /**<@brief Picture (display) aspect ratio width. */
  int32_t   pic_ar_y;                   /**<@brief Picture (display) aspect ratio height. @ref pic_ar_x "More..."*/
  int32_t   calc_quality;               /**<@brief Enables quality metrics calculation. */
  int32_t   cpu_opt;                    /**<@brief Defines CPU acceleration to be used during encoding. */
  int32_t   num_threads;                /**<@brief Number of threads to be used during encoding. */
  int32_t   live_mode;                  /**<@brief Hint for encoder to process input frames with less delay. Not yet implemented. */
  int32_t   buffering;                  /**<@brief Defines the encoder input queue length in seconds. */
  int32_t   min_quant;                  /**<@brief Minimum quantization parameter to use. */
  int32_t   max_quant;                  /**<@brief Maximum quantization parameter to use. */
  int32_t   max_slice_size;             /**<@brief Maximum slice size in bits. */
  int32_t   min_qp_delta;               /**<@brief Lowest value for slice_qp_delta. */
  int32_t   max_qp_delta;               /**<@brief Highest value for slice_qp_delta. */
/** @cond */
  int32_t   reserved_5[1];
/** @endcond */
  int32_t   encoding_buffering;         /**<@brief Maximum number of seconds to buffer encoding queue. */
  int32_t   low_delay;                  /**<@brief Forces minimum encoding delay if needed. Not yet implemented. */
  int32_t   air_mode;                   /**<@brief Defines adaptive intra refresh mode. */
  int32_t   detach_thread;              /**<@brief Runs encoder core in a new thread. */
  int32_t   constrained_intra_pred;     /**<@brief Constrained intra prediction for improving error resilience. */
  int32_t   air_split_frequency;        /**<@brief Frequency of intra lines for adaptive air mode split. */
  int32_t   air_qp_offset;              /**<@brief QP offset for adaptive intra mode lines. */
  int32_t   convert_pixel_range;        /**<@brief Specifies pre-encoding color range conversion. */
  int32_t   deinterlacing_mode;         /**<@brief Specifies the mode of pre-encoding deinterlacing of a source stream. */
  int32_t   num_parallel_pics;          /**<@brief Number of pictures for parallel encoding. */
/** @cond */
  int32_t   reserved_5_1[280];
/** @endcond */
/** @} */

/**
 * @name Advanced GOP settings
 * @{
 **/
  int32_t   min_idr_interval;           /**<@brief Minimum number of frames between I frames. */
  int32_t   adaptive_b_frames;          /**<@brief Enables adaptive B-frames placement. */
  int32_t   idr_frequency;              /**<@brief Defines how often I frames are IDRs. */
  int32_t   field_order;                /**<@brief Sets field order. */
  int32_t   fixed_i_position;           /**<@brief Sets I frame at multiple of @ref idr_interval positions. */
  int32_t   isolated_gops;              /**<@brief Allows to limit referencing for frames come after non-IDR I frame to frames before non-IDR I picture. */
  int32_t   leading_b_frames;           /**<@brief Enables placement of B-frames before an I-frame in display order. */
  int32_t   hierar_p_frames;            /**<@brief Hierarchically coded P frames (for temporal scalability with out using B frames). Not supported yet. */
/** @cond */
  int32_t   reserved_6[46];
/** @endcond */
/** @} */

/**
 * @name Advanced me settings
 * @{
 **/
  int32_t   fast_multi_ref_me;          /**<@brief Enables fast decisions for multi-ref motion estimation. */
  int32_t   fast_sub_block_me;          /**<@brief Enables fast decisions for sub-block motion estimation. */
  int32_t   allow_out_of_pic_mvs;       /**<@brief Controls using pixels beyond the picture boundaries for motion compensation. */
  int32_t   constrained_ref_list;       /**<@brief Use constrained reference picture list. */
  int32_t   motion_search_pattern;      /**<@brief Motion search pattern. */
/** @cond */
  int32_t   reserved_7[95];
/** @endcond */
/** @} */

/**
 * @name Advanced intra settings
 * @{
 **/
  int32_t   enable_intra_big;           /**<@brief Allows to use 16x16 intra prediction modes in intra slices. */
  int32_t   enable_intra_8x8;           /**<@brief Allows to use 8x8 intra prediction modes in intra slices. */
  int32_t   enable_intra_4x4;           /**<@brief Allows to use 4x4 intra prediction modes in intra slices. */
  int32_t   enable_intra_pcm;           /**<@brief Allows to use PCM intra prediction mode in intra slices. */
  int32_t   enable_inter_big;           /**<@brief Allows to use 16x16 intra prediction modes in inter slices. */
  int32_t   enable_inter_8x8;           /**<@brief Allows to use 8x8 intra prediction modes in inter slices. */
  int32_t   enable_inter_4x4;           /**<@brief Allows to use 4x4 intra prediction modes in inter slices. */
  int32_t   enable_inter_pcm;           /**<@brief Allows to use PCM intra prediction mode in inter slices. */
/** @cond */
  int32_t   reserved_8[92];
/** @endcond */
/** @} */

/**
 * @name Advanced RDO (Rate Distortion Optimization) settings
 * @{
 **/
  int32_t   fast_rd_optimization;       /**<@brief Allows fast rate-distortion optimization. */
  int32_t   quant_mode;                 /**<@brief Specifies quantization optimization mode. */
  int32_t   grain_mode;                 /**<@brief Granular noise optimization mode. Currently not used. */
  int32_t   grain_opt_strength;         /**<@brief Scalable film grain optimization. */
/** @cond */
  int32_t   reserved_9[90];
/** @endcond */
/** @} */

/**
 * @name Psycho-visual enhancement
 * @{
 **/
  int32_t   adaptive_quant_strength[8]; /**<@brief Specifies the strengths for every mode of adaptive quantization. */
  int32_t   denoise_strength_y;         /**<@brief Denoise strength for luma [0..100]. */
  int32_t   denoise_strength_c;         /**<@brief Denoise strength for chroma [0..100]. */
  int32_t   black_norm_level;           /**<@brief Specifies pre-encoding black normalization level. */
  int32_t   pulse_reduction;            /**<@brief Specifies strength of key frame pulsing reduction. */
/** @cond */
  int32_t   reserved_9_1[127];
/** @endcond */
/** @} */

/**
 * @name Alpha plane
 * @{
 **/
  int32_t   aux_format_idc;
  int32_t   bit_depth_aux;
  uint32_t  alpha_incr_flag;
  uint32_t  alpha_opaque_value;
  uint32_t  alpha_transparent_value;
/** @cond */
  int32_t   reserved_9_2[100];
/** @endcond */
/** @} */

 /**
 * @name Scaling lists
 * @{
 **/
  uint32_t  seq_scaling_matrix_present_flag;  /**<@brief Specifies that one or more flags @ref seq_scaling_list_present_flag[i] are present. */
  uint32_t  seq_scaling_list_present_flag[8]; /**<@brief Specifies that the syntax structure for scaling list i is present in the sequence parameter set (SPS). */
  uint8_t   intra_y_4x4_scaling_list[16];
  uint8_t   intra_cb_4x4_scaling_list[16];
  uint8_t   intra_cr_4x4_scaling_list[16];
  uint8_t   inter_y_4x4_scaling_list[16];
  uint8_t   inter_cb_4x4_scaling_list[16];
  uint8_t   inter_cr_4x4_scaling_list[16];
  uint8_t   intra_y_8x8_scaling_list[64];
  uint8_t   inter_y_8x8_scaling_list[64];
/** @cond */
  int32_t   reserved_10[128];
/** @endcond */
/** @} */

/**
 * @name GPU encoder stuff
 * @{
 **/
  int32_t   device_idx;        /**<@brief  GPU device index to run encoder on. */
  int32_t   input_format;      /**<@brief  NVCUVID Decoder format. */
/** @cond */
  int32_t   reserved_11[267];
/** @endcond */
/** @} */
};

/** @} */


#pragma pack(pop)



#ifdef __cplusplus
extern "C" {
#endif

/**
 * @brief Fills @ref h264_v_settings structure with preset default values according to resolution, frame rate and interlace mode
 * @param[in] video_type     encoder preset
 * @param[in] width          specifies width of the encoded video
 * @param[in] height         specifies height of the encoded video
 * @param[in] frame_rate     specifies the frame rate of the encoded video
 * @param[in] pic_struct     specifies the picture structure of the encoded video: @ref H264_PROGRESSIVE, @ref H264_INTERLACED or @ref H264_MBAFF
 * @param[in] get_rc         a pointer to an application-defined callback function. If get_rc is NULL default handlers are used. For more information see @ref GET_RC_PAGE "get_rc"
 * @param[out] set           destination for encoder settings
  *@param[out] string_ptr    pointer to string with encoder preset description
 * @return @ref H264ERROR_NONE, @ref H264ERROR_FAILED or @ref H264ERROR_PARAM_ADJUSTED
 */
int32_t MC_EXPORT_API h264OutVideoDefaultSettings(int32_t                  video_type,
                                                  int32_t                  width,
                                                  int32_t                  height,
                                                  double                   frame_rate,
                                                  int32_t                  pic_struct,
                                                  get_rc_t                 get_rc,
                                                  h264_v_settings_tt      *set,
                                                  const char             **string_ptr);

/**
 * @brief Changes performance-related part of @ref h264_v_settings structure
 * @param[in,out] set       encoder settings to adjust
 * @param[in] reserved      reserved
 * @param[in] level         performance level, from @ref H264_PERF_FASTEST to @ref H264_PERF_BEST_Q
 * @param[in] reserved2     reserved
 */
void MC_EXPORT_API h264OutVideoPerformance(h264_v_settings_tt *     set,
                                           int32_t                  reserved,
                                           int32_t                  level,
                                           int32_t                  reserved2);

/**
 * @brief Creates a new AVC/H.264 video encoder instance.
 * @param[in] get_rc        a pointer to an application-defined callback function. If get_rc is NULL default handlers are used. For more information see @ref GET_RC_PAGE "get_rc"
 * @param[in] set           @ref h264_v_settings structure defines characteristics for the new instance of encoder.
 * @param[in] reserved1     unused
 * @param[in] reserved2     unused
 * @param[in] reserved3     unused
 * @param[in] reserved4     unused
 * @return a pointer to video encoder instance or NULL in case of memory allocation failure
 */
h264venc_tt * MC_EXPORT_API h264OutVideoNew(get_rc_t                       get_rc,
                                            h264_v_settings_tt *           set,
                                            int32_t                        reserved1,
                                            int32_t                        reserved2,
                                            int32_t                        reserved3,
                                            int32_t                        reserved4);

/**
 * @brief Destroys the H.264/AVC Encoder instance.
 * @param[in] instance      the video encoder instance.
 */
void MC_EXPORT_API h264OutVideoFree(h264venc_tt * instance);

//////////////////// multi-pass API ////////////////////
#define INIT_OPT_VBR_PASS2_PARAM 0x00000400	/**<@brief Enables 2-pass encoding with internal metadata storage */
#define INIT_OPT_VBR_TWO_PASSES  0x00000800	/**<@brief Enables 2-pass encoding with external metadata storage */
#define INIT_OPT_VBR_ANALYSE     0x00000900	/**<@brief Quick first encoding pass performing only analysis */
#define INIT_OPT_VBR_ENCODING    0x00000F00   /**<@brief Real encoding pass */
/** @cond */
#define INIT_OPT_VBR_PASSES_MASK 0x00000F00   /**< @brief  @hideinitializer */
/** @endcond */
#define INIT_OPT_VBR_EXT_STORAGE 0x00000100   /**<@brief Used to specify external metadata storage */

/**
 * @name Pass2 settings Structure
 * @{
 **/
 /**
 * @brief These parameters are used to configure the second pass.
 */
struct h264_pass2_parameters
{
  int32_t start;
  int32_t count;
/** @cond */
  int32_t reserved[10];
/** @endcond */
};
/** @} */

#define INIT_OPT_CHAPTER_LIST   0x00001000		/**<@brief This option can be passed via opt_ptr in @ref h264OutVideoInit to force I-Frames at certain points in the stream. @ref ENC_AVC_CHAPTER_LIST_PAGE*/

//////////////////// chapterlist API ////////////////////
#define CHAPTER_REARRANGE_GOPS (0x00000010L) 	/**<@brief rearrange preceding GOPs for getting gop length as equal as possible */
#define CHAPTER_FORCE_IDR      (0x00000020L) 	/**<@brief put IDR at the start of the chapter even if idr_frequency is 0 */
#define CHAPTER_END_OF_LIST    (~0L)			/**<@brief Denotes the last entry of a chapter list */

/**
* @name chapter_list 
* Chapter list entry structure
* @{
**/
/**
* @brief These parameters are used to set chapter position. See @ref ENC_AVC_CHAPTER_LIST_PAGE for details.
*/
struct h264_chapter_position
{
  int32_t frame_nr;                             /**<@brief Number of frame to set a chapter point (I or IDR frame) */
  int32_t flags;                                /**<@brief Could be the single flag or combination of @ref CHAPTER_REARRANGE_GOPS or @ref CHAPTER_FORCE_IDR */
};

#define INIT_OPT_SET_PREVIEW   0x00002000       /**<@brief Sets preview callback routine for Smart rendering */

/**
 * @brief Initializes the video encoder. An existing bufstream object must be passed to this function, the video encoder will output the encoded data to the bufstream object.
 * @param[in] instance          the video encoder instance
 * @param[in] videobs           @ref bufstream object for the compressed data output stream
 * @param[in] options_flags     flags allow @ref ENC_AVC_TWO_PASS_PAGE, @ref ENC_AVC_CHAPTER_LIST_PAGE or setting preview callback for Smart rendering (see @ref INIT_OPT_SET_PREVIEW)<br>
                                (ordering is fixed in the following way)
							        @li 2PASS options (internal meta_data storage) @ref INIT_OPT_VBR_TWO_PASSES
							        @li 2PASS options (external meta_data storage) @ref INIT_OPT_VBR_ANALYSE, @ref INIT_OPT_VBR_ENCODING
							        @li chapter list options @ref INIT_OPT_CHAPTER_LIST
 * @param[in] opt_ptr           pointer to additional option data (like chapter list structure)
 * @return one of defined errors (@ref H264ERROR_NONE if successful, @ref H264ERROR_OUT_OF_MEM if memory allocation fails or @ref H264ERROR_FAILED if an error occurs)
 */
int32_t MC_EXPORT_API h264OutVideoInit(h264venc_tt *      instance,
                                       struct bufstream * videobs,
                                       uint32_t           options_flags,
                                       void **            opt_ptr);


/**
 * @brief Finishes encoding session. Prints encoding info.
 * @param[in]                   instance the video encoder instance.
 * @param[in]                   abort If abort equals 0, encoder finishes any leftover video and cleans up, otherwise just cleans up.
 * @return one of defined errors (@ref H264ERROR_NONE or @ref H264ERROR_FAILED)
*/
int32_t MC_EXPORT_API h264OutVideoDone(h264venc_tt * instance, int32_t abort);

// For all extended option define flags OPT_EXT_PARAM_... please see "mcdefs.h" now.

/**
 * @name VBV_struct Target VBV data structure
 * @{
 **/
 /**
 * @brief These parameters are used to define target VBV settings
 */
typedef struct tag_h264_target_VBV_data
{
  uint32_t API_version;  /**<@brief Used to detect version and size of struct in future */
  uint32_t vbv_fullness; /**<@brief VBV fullness (in %) to achieve within specified number of frames */
  uint32_t frames_togo;  /**<@brief Number of frames till VBV state specified above should be reached */
/** @cond */
  uint32_t reserved[13];
/** @endcond */

} h264_target_VBV_data_tt;
/** @} */


 /**
 *@brief Structure to insert registered/unregistered user data SEI message in H.264 bitstream.
 */
typedef struct h264_user_data
{
  uint32_t        type;         /**< @brief @ref H264_UD_REGISTERED  or @ref H264_UD_UNREGISTERED. */
  uint32_t        size;         /**< @brief Size of the user data */
  unsigned char  *data;         /**< @brief User data */
  uint32_t        lock;         /**< @brief If 0, data/pointer can be destroyed again */
  void           *next;         /**< @brief Pointer to @ref h264_user_data_tt structure (0 = no more data) */
  uint32_t        field;        /**< @brief Field number for interlace mode. Available values stored in @ref ud_field_t enum. */
  uint32_t        reserved[14]; /**< @brief Reserved, should be zeroed */

} h264_user_data_tt;

 /**
 * @details Alpha plane data structure
 */
typedef struct h264_alpha_plane_data
{
  int32_t   aux_format_idc;               /**<@brief -1 = no sps_extension,
                                                      1 = auxiliary coded pictures should be multiplied,
                                                      2 = auxiliary coded pictures should not be multiplied,
                                                      3 = usage of auxiliary coded pictures is unspecified. */
  int32_t   bit_depth_aux;                /**<@brief bit depth of the sample array of the auxiliary coded picture. */
  uint32_t  alpha_incr_flag;              /**<@brief s. 7.4.2.1.2 */
  uint32_t  alpha_opaque_value;           /**<@brief s. 7.4.2.1.2 */
  uint32_t  alpha_transparent_value;      /**<@brief s. 7.4.2.1.2 */

  uint8_t * data;                         /**<@brief alpha plane data */

} h264_alpha_plane_data_tt;

//////////////////// smartrender API ////////////////////
/**
 * @name sr_mode Smart renderer mode flags
 * @{
 **/
/** @cond */
#define SR_MODE_MASK           (0xFFFF0000L)
/** @endcond */
#define SR_MODE_AUTO           (0x00000000L)
#define SR_MODE_COPY           (0x00010000L)
#define SR_MODE_FULL           (0x00020000L)
#define SR_MODE_SMART          (0x00030000L)
/** @} */

/**
 * @name sr_data_type Smart renderer data type flags
 * @{
 **/
/** @cond */
#define SR_DATA_TYPE_MASK      (0x0000FFFFL)
/** @endcond */
#define SR_DATA_TYPE_PAYLOAD   (0x00000001L)
#define SR_DATA_TYPE_AVC_INTRA (0x00000009L)
#define SR_DATA_TYPE_ORG_FRAME (0x00000002L)
//#define SR_DATA_TYPE_META      (0x00000100L) // Unsupported mode.
/** @} */


 /**
 * @brief These parameters are used by smart renderer
 */
typedef struct h264_sr_data
{
  uint32_t    data_flags;    /**<@brief Describes mode flags and data type. */
  uint32_t    data_size;     /**<@brief Size of data in bytes. */
  void *      data;          /**<@brief Pointer to the data */
  void *      next;          /**<@brief Pointer to additional data. */
/** @cond */
  uint32_t    reserved[12];
/** @endcond */
} h264_sr_data_tt;
/** @} */

/**
 * @brief Encodes one video frame.
 * @param[in] instance 		the video encoder instance.
 * @param[in] pb_src 		pointer to a frame buffer to be encoded
 * @param[in] src_line_size	stride of source frame
 * @param[in] src_width 	width of source frame
 * @param[in] src_height 	height of source frame
 * @param[in] fourcc 		source colorspace
 * @param[in] opt_flags 	options flags
 * @param[in] ext_info 		extended info
 * @return    @ref H264ERROR_NONE if successful or @ref H264ERROR_AVC_INTRA_SKIPPED_FRAME or @ref H264ERROR_FAILED if an error occurs.
 */
int32_t MC_EXPORT_API h264OutVideoPutFrame(h264venc_tt *   instance,
                                           uint8_t *       pb_src,
                                           int32_t         src_line_size,
                                           int32_t         src_width,
                                           int32_t         src_height,
                                           uint32_t        fourcc,
                                           uint32_t        opt_flags,
                                           void **         ext_info);

/**
 * @brief Encodes one video frame. Similar to @ref h264OutVideoPutFrame. Difference is in parameters only
 * @param[in] instance 		the video encoder instance
 * @param[in] pframe_v 		frame to be encoded
 * @param[in] opt_flags 	options flags
 * @param[in] ext_info 		extended info
 * @return    @ref H264ERROR_NONE if successful or @ref H264ERROR_AVC_INTRA_SKIPPED_FRAME or @ref H264ERROR_FAILED if an error occurs.
 */
int32_t MC_EXPORT_API h264OutVideoPutFrameV(h264venc_tt *    instance,
                                            video_frame_tt * pframe_v,
                                            uint32_t         opt_flags,
                                            void **          ext_info);

/**
 * @remark This function is not supported for now
 */
int32_t MC_EXPORT_API h264OutVideoGetMaxBitrate(h264venc_tt * instance);


/**
 * @brief Changes settings on-the-fly.
 * @param[in]               instance the video encoder instance
 * @param[in]               set new encoder settings
 * @remarks This is only possible for some specific settings like bitrate.
 * @return one of defined errors (@ref H264ERROR_NONE or @ref H264ERROR_FAILED)
 */
int32_t MC_EXPORT_API h264OutVideoUpdateSettings(h264venc_tt *        instance,
                                                 h264_v_settings_tt * set);


/**
 * @brief Checks encoder settings for any conformance violation.
 * @param[in] get_rc 	a pointer to an application-defined callback function. If get_rc is NULL default handlers are used. For more information see @ref GET_RC_PAGE "get_rc"
 * @param[in] set 		encoder settings structure
 * @param[in] options 	can be used to modify the function's behavior<br><br>
 * @parblock
 * The h264OutVideoChkSettings function can not only check settings. It also can adjust the settings to match preset, 
 * profile and level limitations.<br>
 * Available options are:<br><br>
 * <table>
 * <tr><th>Value</th>                       <th>Description</th></tr>
 * <tr><td>0</td>                           <td>No adjustment. The function returns @ref H264ERROR_FAILED if settings violate any limitations.</td>
 * <tr><td>@ref H264_CHECK_AND_ADJUST</td>  <td>The function adjusts parameters to satisfy preset, profile and level limitations. If adjustments were made the function returns @ref H264ERROR_PARAM_ADJUSTED.</td>
 * <tr><td>@ref H264_CHECK_FOR_LEVEL</td>   <td>The function adjusts the level to allow encoding with the given parameters. Should be combined with @ref H264_CHECK_AND_ADJUST to have a meaningful effect (@ref H264_CHECK_AND_ADJUST | @ref H264_CHECK_FOR_LEVEL).</td>
 * </table>
 * @endparblock
 * @param[in] reserved 	not used
 * @return Returns one of the defined errors (@ref H264ERROR_NONE, @ref H264ERROR_FAILED or @ref H264ERROR_PARAM_ADJUSTED)
 */
int32_t MC_EXPORT_API h264OutVideoChkSettings(get_rc_t                 get_rc_t,
                                              h264_v_settings_tt *     set,
                                              uint32_t                 options,
                                              void *                   reserved);


/**
 * @brief Gets current VBV state (VBV buffer fullness in %) during encoding session.
 * @param[in] instance      the video encoder instance
 * @return fullness of coded picture buffer in %
 */
int32_t MC_EXPORT_API h264OutVideoGetVBVState(h264venc_tt * instance);


/**
 * @brief Returns buffer with parameter sets and its length
 * @param[in]           reserved
 * @param[in]           set the encoder settings
 * @param[in]           buffer buffer which will be used for writing of parameter sets, buffer can be NULL, in this case the encoder just calculates and returns length required to store parameter sets
 * @param[in,out]       length a length of the buffer, initially should contain the actual length of the buffer, when the function returns length will contain the actual number of bytes written into the buffer
 * @return one of defined errors (@ref H264ERROR_NONE or @ref H264ERROR_FAILED)
 * @remarks If function returns @ref H264ERROR_FAILED and returns -1 in length it means that some internal error is happened.
 */
int32_t MC_EXPORT_API h264OutVideoGetParSets(void *                   reserved,
                                             h264_v_settings_tt *     set,
                                             uint8_t *                buffer,
                                             int32_t *                length);


/**
 * @brief Flushes encoder queue
 * @param[in]           instance the video encoder instance
 * @param[in]           abort If abort equals 0, encoder finishes to encode any leftover pictures and flushes, otherwise just flushes pictures that are ready
 * @return one of defined errors (@ref H264ERROR_NONE or @ref H264ERROR_FAILED)
 **/
int32_t MC_EXPORT_API h264OutVideoFlush(h264venc_tt * instance, int32_t abort);


/**
* @brief Fills @ref h264_v_settings structure with the settings extracted from SPS and PPS of another Video Elementary Stream.
* @param[in] get_rc         a pointer to an application-defined callback function. If get_rc is NULL default handlers are used. For more information see @ref GET_RC_PAGE "get_rc"
* @param[in] headers_buffer byte buffer containing SPS and PPS
* @param[in] buffer_size    size of the buffer in bytes
* @param[in] set            pointer to the settings structure to be filled with parameters extracted from SPS and PPS
* @return one of defined errors (@ref H264ERROR_NONE or @ref H264ERROR_FAILED)
**/
int32_t MC_EXPORT_API h264OutVideoConfigureFromHeaders(get_rc_t                 get_rc,
                                                       const uint8_t *          headers_buffer,
                                                       uint32_t                 buffer_size,
                                                       h264_v_settings_tt * set);

/**
* @brief Get extended API function pointers.
* @details The AVC/H.264 Video Encoder supports only @ref MCAPI_GetModuleInfo.
* @param[in] func           the identifier of the function to return
* @return the pointer to the @ref APIEXTFUNC "extended API function" or NULL if the requested function was not found.
**/
APIEXTFUNC MC_EXPORT_API h264OutVideoGetAPIExt(uint32_t func);


#ifdef __cplusplus
}
#endif

/** @} */

#endif // #if !defined (__ENC_AVC_API_INCLUDED__)

