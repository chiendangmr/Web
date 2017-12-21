/** 
 @file  enc_avc_wrap.h
 @brief  AVC/H.264 Encoder Wrapper API
 
 @verbatim
 File: enc_avc_wrap.h

 Desc: AVC/H.264 Encoder Wrapper API
 
 Copyright (c) 2015 MainConcept GmbH or its affiliates.  All rights reserved.

 MainConcept and its logos are registered trademarks of MainConcept GmbH or its affiliates.  
 This software is protected by copyright law and international treaties.  Unauthorized 
 reproduction or distribution of any portion is prohibited by law.
 @endverbatim
 **/

#if !defined (__ENC_AVC_WRAP_API_INCLUDED__)
#define __ENC_AVC_WRAP_API_INCLUDED__

#include "enc_avc.h"
#include "mctypes.h"

/**
 * @brief encoder instance type
 */
typedef struct h264_v_wrap_encoder  h264_v_wrap_enc_tt;
typedef struct h264_v_wrap_settings h264_v_wrap_settings_tt;


#pragma pack(push,1)

/**
 * @name Settings Structure
 * @{
 */
 
 /**
 * @brief These parameters are used to configure the encoder.
 */
struct h264_v_wrap_settings
{
  uint32_t  enc_mask;				/**< @brief bitmask of allowed encoders
									  * @brief set of @ref ENCODE_AVC_INTEL_QSV ... @ref ENCODE_AVC_SOFTWARE */

  struct h264_v_settings base;		/**< @brief base settings of H.264/AVC Encoder */

  /**
 * @name Intel QSV specific parameters
 * @{
 **/
  int32_t   performance;			/**< @brief CPU performance 
										 @brief Available values:  0..15*/
  int32_t   impl;					/**< @brief reserved  */
  /** @} */
  //int32_t	device_idx;
  //uint32_t	input_format;
     
  uint8_t  	 reserved[1024];
};

/** @} */
#pragma pack(pop)



#ifdef __cplusplus
extern "C" {
#endif



/** @brief Intel QSV implementation flag */
#define ENCODE_AVC_INTEL_QSV    0x00000001
/** @brief CUDA implementation flag */
#define ENCODE_AVC_CUDA		    0x00000002
/** @brief OpenCL implementation flag */
#define ENCODE_AVC_OPENCL	    0x00000004
/** @brief MC Software Broadcast implementation flag */
#define ENCODE_AVC_SOFTWARE_BROADCAST  0x00000008 
/** @brief MC Software implementation flag */
#define ENCODE_AVC_SOFTWARE  0x00000010 




/**
* @brief Fills @ref h264_v_wrap_settings structure with preset default values according to resolution, frame rate and interlace mode
* @param[in] video_type     encoder preset
* @param[in] width          specifies width of the encoded video
* @param[in] height         specifies height of the encoded video
* @param[in] frame_rate     specifies the frame rate of the encoded video
* @param[in] interlace_mode specifies the frame type of the encoded video: @ref H264_PROGRESSIVE, @ref H264_INTERLACED or @ref H264_MBAFF
* @param[in] get_rc         the get_rc callback to provide an err_printf callback to get error messages
* @param[out] set           destination for encoder settings
* @param[out] string_ptr    pointer to string with encoder preset description
* @return Returns @ref H264ERROR_NONE, @ref H264ERROR_FAILED or @ref H264ERROR_PARAM_ADJUSTED
*/
int32_t MC_EXPORT_API h264WrapOutVideoDefaultSettings(int32_t                  video_type,
                                                      int32_t                  width,
                                                      int32_t                  height,
                                                      double                   frame_rate,
                                                      int32_t                  pic_struct,
                                                      void * (MC_EXPORT_API   *get_rc)(const char* name),
                                                      h264_v_wrap_settings_tt *set,
                                                      const char             **string_ptr);


/**
 * @brief Change performance-related part of @ref h264_v_wrap_settings structure
 * @param[in] set       - encoder settings to adjust
 * @param[in] mode      - performance mode (irrelevant for now)
 * @param[in] level     - performance level, from @ref H264_PERF_FASTEST to @ref H264_PERF_BEST_Q
 */

void MC_EXPORT_API h264WrapOutVideoPerformance(struct h264_v_wrap_settings * set,
                                           int32_t                  mode,
                                           int32_t                  level,
                                           int32_t                  reserved);


/**
 * @brief Creates a new H264-Video-Encoder instance.
 * @param[in] get_rc 	pointer to get resource function
 * @param[in] options	reserved, set to 0
 * @param[in] CPU		set to 0xFFFFFFFF for autodetect (reserved for CPU-flags)
 * @param[in] frame0	first frame number to encode
 * @param[in] nframes	number of frames to encode, can be 0 for streaming mode
 * @return 	pointer to a video encoder instance if successful
 * @return  NULL if unsuccessful
 */
h264_v_wrap_enc_tt * MC_EXPORT_API h264WrapOutVideoNew(void * (MC_EXPORT_API * get_rc)(const char * name),
                                            const struct h264_v_wrap_settings * set,
                                            int32_t                        options,
                                            int32_t                        CPU,
                                            int32_t                        frame0,
                                            int32_t                        nframes);

/**
 * @brief Destroys the H264-Video-Encoder instance.
 * @param[in] instance the video encoder instance.
 */
void MC_EXPORT_API h264WrapOutVideoFree(h264_v_wrap_enc_tt * instance);


/**
 * @brief Call to initialize the video encoder for an encoding session.
 *        Must be called before the PutFrame function.
 * @param[in] instance the video encoder instance.
 * @param[in] videobs bitstream object for writing data. Must be initialized before.
 * @param[in] options_flags not used.
 * @param[in] opt_ptr not used.
 * @return 	@ref H264ERROR_NONE if successful.
 * @return  @ref H264ERROR_FAILED if not.
 */
int32_t MC_EXPORT_API h264WrapOutVideoInit(h264_v_wrap_enc_tt *      instance,
                                       struct bufstream * videobs,
                                       uint32_t           options_flags,
                                       void **            opt_ptr);


/**
 * @brief call to finish encoding session. 
 * @param[in] instance the video encoder instance.
 * @param[in] abort If abort equals 0, finish any leftover video and clean up, else just clean up.
 */
int32_t MC_EXPORT_API h264WrapOutVideoDone(h264_v_wrap_enc_tt * instance, int32_t abort);


/**
 * @brief Call to encode one video frame.
 * @param[in] instance the video encoder instance.
 * @param[in] pb_src pointer to the frame buffer to be encoded.
 * @param[in] src_line_size number of bytes in scan line.
 * @param[in] src_width number of pixels in scan line.
 * @param[in] src_height number of scan lines in the frame.
 * @param[in] fourcc one of the supported colorspace id's.
 * @param[in] opt_flags @ref OPT_EXT_PARAM_TIMESTAMPS - passing frame timestamps through encoder.
 * @param[in] ext_info pointer to array of extended information, depends on @ref OPT_EXT_PARAM_TIMESTAMPS.
 * @return 	@ref H264ERROR_NONE if successful.
 * @return  @ref H264ERROR_FAILED if not.
 */
int32_t MC_EXPORT_API h264WrapOutVideoPutFrame(h264_v_wrap_enc_tt *   instance,
                                           uint8_t *       pb_src,
                                           int32_t         src_line_size,
                                           int32_t         src_width,
                                           int32_t         src_height,
                                           uint32_t        fourcc,
                                           uint32_t        opt_flags,
                                           void **         ext_info);

/**
 * @brief Checks encoder settings for any conformance invalidation.
 * @param[in] get_rc the get_rc callback to provide an err_printf callback to get error messages that can be localized.
 * @param[in] set the encoder settings.
 * @param[in] options use @ref H264_CHECK_AND_ADJUST to adjust settings to be conform.
 * @return 	@ref H264ERROR_NONE if successful
 * @return  @ref H264ERROR_FAILED if not
 */
int32_t MC_EXPORT_API h264WrapOutVideoChkSettings(void * (MC_EXPORT_API * get_rc)(const char * name), 
                                              h264_v_wrap_settings * set,
                                              uint32_t                 options,
                                              void *                   app);


/**
 * @brief Returns buffer with parameter sets and its length
 * @param[in] instance the video encoder instance.
 * @param[in] set the encoder settings.
 * @param[out] buffer be sure to allocate enough memory for buffer (1024 bytes should be more than enough)
 * @param[out] length actual size of the data after calling this function
 * @return 	@ref H264ERROR_NONE if successful
 * @return  @ref H264ERROR_FAILED if not
 */
int32_t MC_EXPORT_API h264WrapOutVideoGetParSets(h264_v_wrap_enc_tt *instance,
                                             struct h264_v_wrap_settings * set,
                                             uint8_t *                buffer,
                                             int32_t *                length);

/**
 * @brief Call to change settings on-the-fly.
 * @param[in] instance the video encoder instance.
 * @param[in] set the encoder settings.
 * @return 	@ref H264ERROR_NONE if successful
 * @return  @ref H264ERROR_FAILED if not
 * @remarks This is only possible for some specific settings like bitrate.
 */
int32_t MC_EXPORT_API h264WrapOutVideoUpdateSettings(h264_v_wrap_enc_tt * instance, h264_v_wrap_settings_tt * set);

/**
* @brief Returns a list of available Encoders
* @return bitmask of @ref ENCODE_AVC_INTEL_QSV ... @ref ENCODE_AVC_SOFTWARE
*/
int32_t MC_EXPORT_API h264WrapOutVideoEncoders();



/**
 * @brief Call to get a description of  devices available.
 * @param[in] enc_mask bitmask of available Encoders, set of @ref ENCODE_AVC_INTEL_QSV ... @ref ENCODE_AVC_SOFTWARE
 * @param[out] description array of string to store description in.
 * @return number of devices available.
 * @remarks if you pass NULL to function, it returns count of devices available.
 */
int32_t MC_EXPORT_API h264WrapGetDeviceDescription(int enc_mask, char *description[256]);

/**
 * @brief Returns an actually used encoder.
 * @param[in] enc_mask bitmask of allowed encoders, set of @ref ENCODE_AVC_INTEL_QSV ... @ref ENCODE_AVC_SOFTWARE
 * @return one of @ref ENCODE_AVC_INTEL_QSV ... @ref ENCODE_AVC_SOFTWARE.
 */
int32_t MC_EXPORT_API h264WrapGetUsedVideoEncoder(int enc_mask);


APIEXTFUNC MC_EXPORT_API h264WrapOutVideoGetAPIExt(uint32_t func);

#ifdef __cplusplus
}
#endif


#endif // #if !defined (__ENC_AVC_WRAP_API_INCLUDED__)

