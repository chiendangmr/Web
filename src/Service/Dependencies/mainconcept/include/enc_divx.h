/**
@file: enc_divx.h
@brief DivX ASP Video Encoder API

@verbatim
File: enc_divx.h
Desc: DivX ASP Video Encoder Encoder API

 Copyright (c) 2014 MainConcept GmbH or its affiliates.  All rights reserved.
 
 MainConcept and its logos are registered trademarks of MainConcept GmbH or its affiliates.  
 This software is protected by copyright law and international treaties.  Unauthorized 
 reproduction or distribution of any portion is prohibited by law.
@endverbatim
 **/

#ifndef __DIVXVOUT_H__
#define __DIVXVOUT_H__

#include "mctypes.h"
#include "mcprofile.h"
#include "v_frame.h"
#include "bufstrm.h"
#include "mcapiext.h"
#include "mcdefs.h"

typedef struct bufstream        bufstrm_tt;
typedef struct divx_v_encoder   divxvenc_tt;
typedef struct divx_v_settings  divx_v_settings_tt;

#pragma pack(push,1)

struct divx_v_settings
{
  ////////// General Parameters
  int32_t   profile;                    /**<@brief Profile */

  int32_t   reserved[3];

  int32_t   width;                      /**<@brief Default horizontal size */
  int32_t   height;                     /**<@brief Default vertical size */
  double    frame_rate;                 /**<@brief Frames per second */

  int32_t   reserved_0[7];              /**<@brief Reserved for general parameters */

  int32_t   use_presets;
  int32_t   preset;

  ////////// Preprocessor Parameters
  int32_t   reserved_1[29];

  int32_t   pixel_aspect_ratio;         /**<@brief value of pixel aspect ratio */
  int32_t   pixel_ar_width;             /**<@brief horizontal size of pixel aspect ratio */
  int32_t   pixel_ar_height;            /**<@brief vertical size of pixel aspect ratio */

  int32_t   deinterlace;                /**<@brief deinterlace the input video as a first step */
  int32_t   deinterlace_top_field;      /**<@brief selects a ‘master’ field for the deinterlace algorithm */

  int32_t   reserved_2[15];

  ////////// Rate Control and Frame Decision Parameters
  int32_t   rc_mode;                    /**<@brief rate control mode */
  int32_t   target_bitrate;             /**<@brief average target bitrate */
  int32_t   vbv_bitrate;                /**<@brief max bitrate, used in VBR mode */
  int32_t   vbv_buffer;                 /**<@brief vbv buffer size */
  int32_t   vbv_occupancy;              /**<@brief initial fullness of VBV buffer */
  int32_t   quantizer;                  /**<@brief quantization parameter */
  int32_t   reserved_3[4];
  int32_t   max_key_interval;           /**<@brief the maximum interval between key frames */
  int32_t   bvop_count;
  int32_t   force_bs;


  int32_t   reserved_4[23];


  ////////// Core Encoder Parameters
  int32_t   performance;                /**<@brief Performance / quality modes */
                                        /**<@brief MPEG4_PERFORMANCE_FASTEST */
                                        /**<@brief MPEG4_PERFORMANCE_FASTER */
                                        /**<@brief MPEG4_PERFORMANCE_FAST */
                                        /**<@brief MPEG4_PERFORMANCE_STANDARD */
                                        /**<@brief MPEG4_PERFORMANCE_SLOW */
                                        /**<@brief MPEG4_PERFORMANCE_VERYSLOW */
  int32_t   interlace;
  int32_t   top_field_first;
  int32_t   use_gmc;                    /**<@brief Global Motion Compensation */
  int32_t   me_quarter_pel;             /**<@brief subpixel motion estimation. 0: half pixel, 1: quarter pixel */
  int32_t   me_4mv;
  int32_t   reserved_5[16];
  int32_t   quant_type;                 /**<@brief MPEG4_QUANT_H263 - H.263 quantization algorithm  */
                                        /**<@brief MPEG4_QUANT_MPEG - MPEG quantization algorithm */
                                        /**<@brief MPEG4_QUANT_H263_OPT - optimized H.263 quantization algorithm  */

  int32_t   reserved_6[6];
  int32_t   psychovisual;               /**<@brief MPEG4_PSYCHOVISUAL_OFF - No psychovisual enhancements will be performed by the encoder (best PSNR), */
                                        /**<@brief MPEG4_PSYCHOVISUAL_SHAPING - Selects the noise-shaping psychovisual algorithm (fast) */
                                        /**<@brief MPEG4_PSYCHOVISUAL_MASKING - Selects the noise-masking psychovisual algorithm (slow) */

  int32_t   data_partitioned;
  int32_t   reserved_7[64];


  ////////// Advanced settings
  int32_t   num_threads;

  int32_t   reserved_8[6];

  int32_t   psnr_mode;

  int32_t   avi_compatible_bitstream;

  int32_t   reserved_9[502];


}; // end of divx_v_settings

#pragma pack(pop)

#ifdef __cplusplus
extern "C" {
#endif

/**
 * @brief Fill divx_v_settings-structure with defaults values.
 * @param[out] set
 * @param[in] video_type
 * @param[in] PAL
 */
char *MC_EXPORT_API divxOutVideoDefaults(struct divx_v_settings *set,
                                           int32_t                 video_type, 
                                           int32_t                 PAL);

/**
 * @brief Change performance-related part of divx_v_settings-structure
 */

void MC_EXPORT_API divxOutVideoPerformance(struct divx_v_settings *set,
                                           int32_t                 mode,
                                           int32_t                 level,
                                           int32_t                 reserved);

/**
 * @brief Creates a new DivX Video Encoder instance.
 * @param[in] get_rc
 * @param[in] set
 */
divxvenc_tt *MC_EXPORT_API divxOutVideoNew(void                         *(MC_EXPORT_API *get_rc)(char *name),
                                           const struct divx_v_settings *set,
                                           int32_t                       options,
                                           int32_t                       CPU,
                                           int32_t                       frame0,
                                           int32_t                       nframes);

/**
 * @brief Destroys the DivX Video Encoder instance.
 * @param[in] instance the video encoder instance.
 */
void MC_EXPORT_API divxOutVideoFree(divxvenc_tt * instance);


#define INIT_OPT_MULTIPASS_WORKFOLDER    (0x00000001L)
#define INIT_OPT_MULTIPASS_LOGFILE       (0x00000002L)

/**
 * @brief Call to initialize the video encoder for an encoding session.
 *        Must be called before the PutFrame function.
 * @param[in] instance the video encoder instance.
 * @param[in] videobs bitstream object for writing data. Must be initialized before.
 * @param[in] options_flags
 * @param[in] opt_ptr
 */

int32_t MC_EXPORT_API divxOutVideoInit(divxvenc_tt      *instance,
                                       struct bufstream *videobs,
                                       uint32_t          options_flags,
                                       void            **opt_ptr);

/**
 * @brief call to finish encoding session. 
 * @param[in] instance the video encoder instance.
 * @param[in] abort If abort equals 0, finish any leftover video and clean up, else just clean up.
 */
int32_t MC_EXPORT_API divxOutVideoDone(divxvenc_tt * instance, int abort);

/**
 * @brief Call to encode one video frame.
 * @param[in] instance the video encoder instance.
 * @param[in] pbSrc pointer to the frame buffer to be encoded.
 */                  

// For all extended option define flags OPT_EXT_PARAM_... please see "mcdefs.h" now.

int32_t MC_EXPORT_API divxOutVideoPutFrame(divxvenc_tt *instance,
                                           uint8_t     *pb_src,
                                           int32_t      src_line_size,
                                           int32_t      src_width,
                                           int32_t      src_height,
                                           uint32_t     fourcc,
                                           uint32_t     opt_flags,
                                           void       **ext_info);

/**
 * @brief Call to encode one video frame. Similar to above method.
 * @param[in] instance the video encoder instance.
 * @param[in] pframe_v the frame to be encoded.
 */
int32_t MC_EXPORT_API divxOutVideoPutFrameV(divxvenc_tt    *instance,
                                            video_frame_tt *pframe_v,
                                            uint32_t        opt_flags,
                                            void          **ext_info);

/**
 * @brief Call to change settings on-the-fly.
 * @param[in] instance the video encoder instance.
 * @param[in] set the encoder settings.
 * @remarks This is only possible for some specific settings like bitrate.
 */
int32_t MC_EXPORT_API divxOutVideoUpdateSettings(divxvenc_tt                  *instance,
                                                 const struct divx_v_settings *set);

/**
 * @brief Checks encoder settings for any conformance invalidation.
 * @param[in] get_rc the get_rc callback to provide an err_printf callback to get error messages that can be localized.
 * @param[in] set the encoder settings.
  */
int32_t MC_EXPORT_API divxOutVideoChkSettings(void                   *(MC_EXPORT_API *get_rc)(char *name), 
                                              struct divx_v_settings *set,
                                              uint32_t                options,
                                              void                   *app);


/**
* @brief Returns buffer with parameter sets and its length
* @param[in] instance the video encoder instance.
* @param[in] set the encoder settings.
* @param[out] output buffer
* @param[in/out] the size of the buffer "buffer" / fullness of the buffer
*/
int32_t MC_EXPORT_API divxOutVideoGetParSets(divxvenc_tt            *instance,
                                             struct divx_v_settings *set,
                                             uint8_t                *buffer,
                                             int32_t                *length);                     

/**
 * @brief flushes encoder queue
 * @param[in] instance the video encoder instance.
 */
int32_t MC_EXPORT_API divxOutVideoFlush(divxvenc_tt *instance, int abort);


APIEXTFUNC  MC_EXPORT_API divxOutVideoGetAPIExt(uint32_t func);


#ifdef __cplusplus
}
#endif


#endif // __DIVXVOUT_H__