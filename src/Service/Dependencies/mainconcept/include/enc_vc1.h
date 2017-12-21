/**
@file: enc_vc1.h
@brief VC1 Encoder API

@verbatim
File: enc_vc1.h
Desc: VC1 Encoder API

 Copyright (c) 2015 MainConcept GmbH or its affiliates.  All rights reserved.

 MainConcept and its logos are registered trademarks of MainConcept GmbH or its affiliates.  
 This software is protected by copyright law and international treaties.  Unauthorized 
 reproduction or distribution of any portion is prohibited by law.
@endverbatim
 **/

#if !defined (__ENC_VC1_API_INCLUDED__)
#define __ENC_VC1_API_INCLUDED__

#include "mctypes.h"
#include "mcprofile.h"
#include "mcapiext.h"
#include "mcdefs.h"

#include "v_frame.h"
#include "bufstrm.h"
#include "auxinfo.h"


typedef struct vc1_v_encoder  vc1venc_tt;
typedef struct vc1_v_settings vc1_v_settings_tt;


#pragma pack(push,1)

/**
 * @name Settings Structure
 * @{
 **/

 /**
 *@brief These parameters are used to configure the encoder.
 */
struct vc1_v_settings
{
    int32_t profile_id;                 /**<@brief This field specifies the profile used to encode(@ref VC1_PROFILE_SIMPLE, @ref VC1_PROFILE_MAIN, @ref VC1_PROFILE_ADVANCED) */
    int32_t level_id;                   /**<@brief This field specifies the level_id used to maintain conformance of encoded file. */

    int32_t key_frame_interval;         /**<@brief GOP length (distance between consecutive I-frames) */
    int32_t b_frame_distance;           /**<@brief Number of B frames between two anchor frames, 0 - no B-frames */
    int32_t closed_entry;               /**<@brief This field specifies whether encoded video may contain B pictures referencing anchor pictures from different entry point segments. */

    int32_t interlace_mode;             /**<@brief Interlace mode (@ref VC1_PROGRESSIVE,@ref VC1_INTERLACE_FIELD,@ref VC1_INTERLACE_MBAFF,@ref VC1_INTERLACE_PAFF) */
    int32_t field_order;                /**<@brief Field order (@ref VC1_TOPFIELD_FIRST,@ref VC1_BOTTOMFIELD_FIRST) */

    int32_t def_horizontal_size;        /**<@brief Coded frame width */
    int32_t def_vertical_size;          /**<@brief Coded frame height */

    double frame_rate;                  /**<@brief This field specifies the frame rate of the encoded video. */

/**
 * @name Bit rate stuff
 * @{
 **/
    int32_t bit_rate_mode;              /**<@brief Bit rate mode (0: constant quantization scale, 1: VBR, 2: CBR ) */
    int32_t bit_rate_buffer_size;       /**<@brief Bit rate buffer size */
    int32_t bit_rate;                   /**<@brief Average output bit rate */
    int32_t max_bit_rate;               /**<@brief HRD peak transmission rate */

    int32_t vbv_buffer_fullness;        /**<@brief Initial HRD buffer fullness */
    int32_t vbv_buffer_fullness_trg;    /**<@brief Target HRD buffer fullness */
    int32_t vbv_buffer_units;           /**<@brief HRD fullness units (for vbv_buffer_fullness and vbv_buffer_fullness_trg). 0: percents, 1: bits, 2: 90kHz clock ticks. */

    int32_t quant_i;                    /**<@brief  Quantization parameter for I frames */
    int32_t quant_p;                    /**<@brief  Quantization parameter for P frames */
    int32_t quant_b;                    /**<@brief  Quantization parameter for B frames */
/**@}*/

/**
 * @name Display extension parameters
 * @{
 **/
    int32_t sar_width;                  /**<@brief Sample aspect ratio: horizonal size in arbitrary units */
    int32_t sar_height;                 /**<@brief Sample aspect ratio: vertical size in arbitrary units  */

    int32_t pic_ar_x;                   /**<@brief */
    int32_t pic_ar_y;                   /**<@brief Picture aspect ratio */

    int32_t write_asp_ratio_info;       /**<@brief Write aspect ratio info (via sequence header / display extension) */
    int32_t write_frame_rate_info;      /**<@brief Write frame rate info (via sequence header / display extension)   */
    int32_t write_hrd_params;           /**<@brief Write hypothetical reference decoder params (via sequence header) */
/**<@}*/

    int32_t video_format;                /**<@brief @ref VC1_PAL, @ref VC1_NTSC */
    int32_t video_full_range;            /**<@brief Whether to use full range (0..255) or not (16..235 for Y, 16..240 for Cb, Cr) */

    int32_t color_format_flag;           /**<@brief 1: the following 3 values are valid, 0: use defaults */
    int32_t color_primaries;
    int32_t transfer_characteristics;
    int32_t matrix_coefficients;

    int32_t max_qp;                      /**<@brief Maximum allowed quantization scale */

    uint32_t precise_time;

    int32_t hrd_maintain;               /**<@brief 0 = hrd model disabled, 1 = hrd model enabled */

    int32_t reserved_1[24];             /**<@brief Reserved for any other settings concerning vbv state or rate control */

    int32_t calc_quality;

/**
 * @name Scene detection
 * @{
 **/
    int32_t vcsd_mode;                  /**<@brief Visual content scene detection, 0: off, 1: set an I frame on a new scene */
    int32_t vcsd_sensibility;           /**<@brief Describes sensibility of scene detector (0: high, 100: 0) */
    int32_t min_key_frame_interval;     /**<@brief Min gop length */
/**@}*/

    int32_t use_deblocking_filter;      /**<@brief Enable / disable in-loop deblock filtering */

/**
 * @name Motion estimation parameters
 * @{
 **/
    int32_t me_mode;                    /**<@brief Motion estimation mode. 0: zero MVs, 1: fast ME, 2: full search ME. */
    int32_t me_subpel;                  /**<@brief Subpixel motion estimation. 0: full pixel locations, 1: half pixel, 2: quarter pixel */
    int32_t me_search_range;            /**<@brief Motion estimation search range */
    int32_t me_use_4mv;                 /**<@brief Use 4MV mode for P frames */
    int32_t me_use_intensity_comp;      /**<@brief Use intensity compensation tool for P frames */
/**@}*/
    int32_t write_seq_end_code;         /**<@brief Enable / disable writing sequence end codes */

    int32_t use_vs_trans;               /**<@brief Enable / disable using variable sized transform */

    int32_t slice_arg;                  /**<@brief Number of slices per picture */

    int32_t reserved_1_1;

    int32_t input_queue_length;         /**<@brief Size of the input frame buffer of the encoder (frame units) */

    int32_t disable_startcodes;         /**<@brief Disable / enable EBDU startcodes (Encapsulated Bitstream Decodable Unit, 00 00 01 + BDU type) */
    int32_t enable_asf_binding;         /**<@brief Enable / disable 1-byte ASF binding before Seq Hdr and Entry Point Hdr */

    int32_t black_norm_level;           /**<@brief Black normalization level, any luma less than or equal to black_norm_level will be set to 16 */

    int32_t cpu_opt;                    /**<@brief Allowed CPU optimization */
    int32_t num_threads;                /**<@brief Number of encoding threads */

    int32_t adaptive_quant_strength[8]; /**<@brief Adaptive quantization strength [-100..100] for every mode (from VC1_AQUANT_MODE_BRIGHTNESS to COMPLEXITY), last 5 strengths are not used at the moment */

    int32_t grain_opt_strength;         /**<@brief Scalable film grain optimization [0..100], use 0 to turn it off */

    int32_t disable_adapt_fcm;          /**<@brief Disable adaptive frame coding mode - progressive / interlaced */

    int32_t pulse_reduction;            /**<@brief key frame pulsing reduction */

    // reserved for future
    int32_t reserved_2[354];

    int32_t video_type;                 /**<@brief @ref VC1_BASELINE .. @ref VC1_BD_HDMV */
    int32_t video_pulldown_flag;        /**<@brief Pulldown type (3:2, etc.) */

    int32_t timestamp_offset;           /**<@brief Frame offset (in number of frames) for timestamps (default = 0) */

    int32_t fixed_i_position;           /**<@brief Fixed position of I frames */

    int32_t reserved_3[254];            //

    int32_t reserved[1368];             //
}; // end of vc1_v_settings
/**@}*/

#pragma pack(pop)

//////////////////////////////////////////////////////////////////////////////
//////////////////////////////////////////////////////////////////////////////


#ifdef __cplusplus
extern "C" {
#endif


/**
 * @brief Fill vc1_v_settings-structure with defaults values.
 * @param[out] set         - pointer to vc1_v_settings structure to be initialized
 * @param[in] video_type   - one of the VC1_* preset values
 * @param[in] PAL          - one of the VM_* constants indicating whether to use NTSC or PAL defaults
 * @return NONE
 */
char * MC_EXPORT_API vc1OutVideoDefaults(struct vc1_v_settings *set, int32_t video_type, int32_t PAL);


/**
 * @brief Change performance-related part of vc1_v_settings-structure
 * @param[out] set
 * @param[in] mode
 * @param[in] level
 */
void MC_EXPORT_API vc1OutVideoPerformance(struct vc1_v_settings * set,
                                          int32_t                 mode,
                                          int32_t                 level,
                                          int32_t                 reserved);


/**
 * @brief Creates a new VC1-Video-Encoder instance.
 * @param[in] get_rc
 * @param[in] set
 */
vc1venc_tt * MC_EXPORT_API vc1OutVideoNew(void *                        (MC_EXPORT_API *get_rc)(const char* name),
                                          const struct vc1_v_settings * set,
                                          int32_t                       options,
                                          int32_t                       CPU,
                                          int32_t                       frame0,
                                          int32_t                       nframes);

/**
 * @brief Call this function to free an vc1venc_tt object created with the vc1OutVideoNew function.
 * @param[in] instance  - pointer to vc1venc_tt object created with vc1OutVideoNew call
 * @return NONE
 */
void MC_EXPORT_API vc1OutVideoFree(vc1venc_tt *instance);


#define INIT_OPT_AUTHENT         0x00000010

#ifdef RC_2VBR
#if !defined(INIT_OPT_VBR_TWO_PASSES)
#define INIT_OPT_VBR_TWO_PASSES  0x00000800
#define INIT_OPT_VBR_ANALYSE     0x00000900
#define INIT_OPT_VBR_ENCODING    0x00000F00
#define INIT_OPT_VBR_PASSES_MASK 0x00000F00
#define INIT_OPT_VBR_EXT_STORAGE 0x00000100
#endif
#endif

#if !defined(INIT_OPT_CHAPTER_LIST)
#define INIT_OPT_CHAPTER_LIST    0x00001000
#endif
/**
 * @name Chapter position settings structure
 * @{
 **/

 /**
 *@brief These parameters are used to configure the chapter position.
 */
struct vc1_chapter_position
{
  int32_t frame_nr;
  int32_t flags;
};
/**@}*/
#if !defined(CHAPTER_FRAME_NR)
#define CHAPTER_FRAME_NR       (0x00000004L) //change the timecode at this point of the stream to the timecode corresponding to the given frame_nr
#define CHAPTER_FRAME_NR_MASK  (0xFFFFFF00L)
#define CHAPTER_REARRANGE_GOPS (0x00000010L) // rearrange preceding GOPs for getting gop length as equal as possible
#define CHAPTER_END_OF_LIST    (~0L)
#endif

/**
 * @brief Call to initialize the video encoder for an encoding session.
 *        Must be called before the PutFrame function.
 * @param[in] instance the video encoder instance.
 * @param[in] videobs bitstream object for writing data. Must be initialized before.
 * @param[in] options_flags
 * @param[in] opt_ptr
 */
int32_t MC_EXPORT_API vc1OutVideoInit(vc1venc_tt       * instance,
                                      struct bufstream * videobs,
                                      uint32_t           options_flags,
                                      void            ** opt_ptr);


/**
 * @brief Call to finish a video encoding session, set the abort flag to a non-zero if video encoding is being aborted.
 * @param[in] instance - pointer to vc1venc_tt object created with vc1OutVideoNew call
 * @param[in] abort    - flag, set to a non-zero value to abort encoding
 * @return @ref VC1ERROR_NONE if successful, @ref VC1ERROR_FAILED if not successful
 */
int32_t MC_EXPORT_API vc1OutVideoDone(vc1venc_tt * instance, int32_t abort);


int32_t MC_EXPORT_API vc1OutVideoFlush(vc1venc_tt * instance, int32_t abort);


// For all extended option define flags OPT_EXT_PARAM_... please see "mcdefs.h" now.


/**
 * @name Target VBV data structure
 * @{
 **/
 /**
 * @brief These parameters are used to configure VBV.
 */
typedef struct tag_vc1_target_VBV_data
{
  uint32_t API_version;  /**<@brief Used to detect version and size of struct in future */
  uint32_t vbv_fullness; /**<@brief VBV fullness (in %) to achieve within specified number of frames */
  uint32_t frames_togo;  /**<@brief Number of frames till VBV state specified above should be reached */

  uint32_t reserved[13];
} vc1_target_VBV_data_tt;
/**@}*/
/**
 * @brief Call to encode one video frame.
 * @param[in] instance the video encoder instance.
 * @param[in] pbSrc pointer to the frame buffer to be encoded.
 */
int32_t MC_EXPORT_API vc1OutVideoPutFrame(vc1venc_tt * instance,
                                          uint8_t    * pb_src,
                                          int32_t      src_line_size,
                                          int32_t      src_width,
                                          int32_t      src_height,
                                          uint32_t     fourcc,
                                          uint32_t     opt_flags,
                                          void      ** ext_info);



/**
 * @brief Call this function to get the maximum bit rate achieved during the last encoding session.
 * @param[in] instance  - pointer to vc1venc_tt object created with vc1OutVideoNew call
 * @return maximum bit rate achieved in bits per second if successful, 0 if unsuccessful
 */
int32_t MC_EXPORT_API vc1OutVideoGetMaxBitrate(vc1venc_tt *instance);



/**
 * @brief Call to encode one video frame.
 * @param[in] instance the video encoder instance.
 * @param[in] pframe_v the frame to be encoded.
 */
int32_t MC_EXPORT_API vc1OutVideoPutFrameV(vc1venc_tt     * instance,
                                           video_frame_tt * pframe_v,
                                           uint32_t         opt_flags,
                                           void          ** ext_info);


/**
 * @brief Call to change settings on-the-fly.
 * @param[in] instance the video encoder instance.
 * @param[in] set the encoder settings.
 * @remarks This is only possible for some specific settings like bitrate.
 */
int32_t MC_EXPORT_API vc1OutVideoUpdateSettings(vc1venc_tt                  * instance,
                                                const struct vc1_v_settings * set);

/**
 * @brief Checks encoder settings for any conformance invalidation.
 * @param[in] get_rc the get_rc callback to provide an err_printf callback to get error messages that can be localized.
 * @param[in] set the encoder settings.
 * @param[in] options use VC1_CHECK_AND_ADJUST to adjust settings to be conform.
 */
int32_t MC_EXPORT_API vc1OutVideoChkSettings(void *                  (MC_EXPORT_API *get_rc)(const char* name),
                                             struct vc1_v_settings * set,
                                             uint32_t                options,
                                             void                  * app);

/**
 * @brief Call this function to get the current vbv state (vbv fullness in %) during encoding session.
 * @param[in] instance  - pointer to vc1venc_tt object created with vc1OutVideoNew call
 */
int32_t MC_EXPORT_API vc1OutVideoGetVBVState(vc1venc_tt *instance);

/**
 * @brief Fills buffer with parameter sets (ASF binding + SeqHdr + EntryHdr)
 * @param[in] instance the video encoder instance.
 * @param[in] set the encoder settings.
 */
int32_t MC_EXPORT_API vc1OutVideoGetParSets(vc1venc_tt *            instance,
                                            struct vc1_v_settings * set,
                                            uint8_t *               buffer,
                                            int32_t *               length);


APIEXTFUNC MC_EXPORT_API vc1OutVideoGetAPIExt(uint32_t func);



#ifdef __cplusplus
}
#endif


#endif // #if !defined (__ENC_VC1_API_INCLUDED__)

