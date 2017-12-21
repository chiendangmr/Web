/** 
 @file  enc_avc_mfx.h
 @brief H.264/AVC Encoder for Intel QSV API
 
 @verbatim
 File: enc_avc_mfx.h 
 Desc: H.264/AVC Encoder for Intel QSV API 
 
 Copyright (c) 2015 MainConcept GmbH or its affiliates.  All rights reserved.

 MainConcept and its logos are registered trademarks of MainConcept GmbH or its affiliates.  
 This software is protected by copyright law and international treaties.  Unauthorized 
 reproduction or distribution of any portion is prohibited by law.
 @endverbatim
 **/

#if !defined (__ENC_AVC_mfx_API_INCLUDED__)
#define __ENC_AVC_mfx_API_INCLUDED__

#include "mctypes.h"
#include "mcprofile.h"
#include "mcapiext.h"

#include "bufstrm.h"

#include "enc_avc.h"

/**
 * @brief encoder instance type
 */
typedef struct h264_v_mfx_encoder  h264_mfx_v_enc_tt;
typedef struct h264_v_mfx_settings 	h264_v_mfx_settings_tt;

/**
 * @brief MFX encoder implementation flag - auto
 */
#define H264_IMPL_AUTO                                    0
/**
 * @brief MFX encoder software implementation flag
 */
#define H264_IMPL_SW                                      1
/**
 * @brief MFX encoder hardware implementation flag
 */
#define H264_IMPL_HW                                      2

#pragma pack(push,1)

/**
 * @name Settings Structure
 * @{
 */
 
 /**
 * @brief These parameters are used to configure the encoder.
 */
struct h264_v_mfx_settings
{
  struct h264_v_settings base;		/**<@brief Base settings of H.264/AVC Encoder */
  int32_t   performance;			/**<@brief CPU performance 
										@brief Available values:  0..15*/
  int32_t   impl;					/**<@brief Not used */
  int32_t   reserved_10[395];
};

/** @} */
#pragma pack(pop)
 
#ifdef __cplusplus
extern "C" {
#endif


/**
 * @brief Change performance-related part of @ref h264_v_mfx_settings structure
 * @param[in] set       encoder settings to adjust
 * @param[in] mode      performance mode (irrelevant for now)
 * @param[in] level     performance level, from @ref H264_PERF_FASTEST to @ref H264_PERF_BEST_Q
 */
void MC_EXPORT_API h264MfxOutVideoPerformance(struct h264_v_mfx_settings * set,
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
 * @return 	pointer to a video encoder instance if successful, NULL if unsuccessful
 */

h264_mfx_v_enc_tt* MC_EXPORT_API h264MfxOutVideoNew(void *                  (MC_EXPORT_API * get_rc)(const char * name),
													const h264_v_mfx_settings * set,
													int32_t                        options,
													int32_t                        CPU,
													int32_t                        frame0,
													int32_t                        nframes);

/**
* @brief Fills @ref h264_v_mfx_settings_tt structure with preset default values according to resolution, frame rate and interlace mode
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
int32_t MC_EXPORT_API h264MfxOutVideoDefaultSettings(int32_t                  video_type,
                                                     int32_t                  width,
                                                     int32_t                  height,
                                                     double                   frame_rate,
                                                     int32_t                  pic_struct,
                                                     void * (MC_EXPORT_API   *get_rc)(const char* name),
                                                     h264_v_mfx_settings_tt  *set,
                                                     const char              **string_ptr);

/**
 * @brief Destroys the H264-Video-Encoder instance.
 * @param[in] instance the video encoder instance.
 */
void MC_EXPORT_API h264MfxOutVideoFree(h264_mfx_v_enc_tt* instance);


/**
 * @brief Call to initialize the video encoder for an encoding session.
 *        Must be called before the PutFrame function.
 * @param[in] instance the video encoder instance.
 * @param[in] videobs bitstream object for writing data. Must be initialized before.
 * @param[in] options_flags not used
 * @param[in] opt_ptr not used
 * @return 	@ref H264ERROR_NONE if successful
 * @return  @ref H264ERROR_FAILED if not
 */

int32_t MC_EXPORT_API h264MfxOutVideoInit(h264_mfx_v_enc_tt *instance,
                                       struct bufstream * videobs,
                                       uint32_t           options_flags,
                                       void **            opt_ptr);



/**
 * @brief Checks encoder settings for any conformance invalidation.
 * @param[in] get_rc the get_rc callback to provide an err_printf callback to get error messages that can be localized.
 * @param[in] set the encoder settings.
 * @param[in] options use @ref H264_CHECK_AND_ADJUST to adjust settings to be conform.
 * @return 	@ref H264ERROR_NONE if successful
 * @return  @ref H264ERROR_FAILED if not
 */
int32_t MC_EXPORT_API h264MfxOutVideoChkSettings(void * (MC_EXPORT_API * get_rc)(const char * name), 
                                              h264_v_mfx_settings_tt * set,
                                              uint32_t                 options,
                                              void *                   app);

/**
 * @brief call to finish encoding session. 
 * @param[in] instance the video encoder instance.
 * @param[in] abort If abort equals 0, finish any leftover video and clean up, else just clean up.
 * @return 	@ref H264ERROR_NONE if successful
 * @return  @ref H264ERROR_FAILED if not
 */
int32_t MC_EXPORT_API h264MfxOutVideoDone(h264_mfx_v_enc_tt * instance, int32_t abort);


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
 * @return 	@ref H264ERROR_NONE if successful
 * @return  @ref H264ERROR_FAILED if not
 * @remarks The src_width and src_line_size must be greater than or equal to the H.264 width and height settings.  
 * If they are greater than the H.264 width and height, the encoder will effectively crop the upper (or lower, 
 * depending on src_line_size) left portion of the frame at no speed cost.  Assuming the top line of a frame is 
 * at pb_src and src_line_size is positive, the encoder will retrieve the rectangle bounded by (0, 0) to 
 * (H.264 width - 1, H.264 height - 1) disregarding the H.264 width .. src_width and H.264 height .. src_height portions of the frame.
 */
int32_t MC_EXPORT_API h264MfxOutVideoPutFrame(h264_mfx_v_enc_tt *   instance,
                                           uint8_t *       pb_src,
                                           int32_t         src_line_size,
                                           int32_t         src_width,
                                           int32_t         src_height,
                                           uint32_t        fourcc,
                                           uint32_t        opt_flags,
                                           void **         ext_info);

/**
 * @brief Call to encode one video frame. Similar to above method.
 * @param[in] instance the video encoder instance.
 * @param[in] pframe_v the frame to be encoded.
 */
int32_t MC_EXPORT_API h264MfxOutVideoPutFrameV(h264_mfx_v_enc_tt *    instance,
                                            video_frame_tt * pframe_v,
                                            uint32_t         opt_flags,
                                            void **          ext_info);


/**
 * @brief Call to change settings on-the-fly.
 * @param[in] instance the video encoder instance.
 * @param[in] set the encoder settings.
 * @return 	@ref H264ERROR_NONE if successful
 * @return  @ref H264ERROR_FAILED if not
 * @remarks This is only possible for some specific settings like bitrate.
 */
int32_t MC_EXPORT_API h264MfxOutVideoUpdateSettings(h264_mfx_v_enc_tt *                  instance,
                                                 const struct h264_v_mfx_settings * set);


/**
 * @brief Call to get number of GPU devices available to use and their descripton.
 * @return number of GPU devices
 *
  @code
   printf("Available devices are:\n");
 	int n = h264MfxGetDeviceDescription(0);
 	char **str = new char*[n];
 	for(int i = 0; i < n; i++){
 		str[i] = new char[256];
 	}
 	h264MfxGetDeviceDescription(str);
 	for(int i = 0; i < n; i++){
 		printf("%d: %s\n",i,str[i]);
 		delete[] str[i];
 	}
 	delete[] str;
  @endcode
 */
int32_t MC_EXPORT_API h264MfxGetDeviceDescription(char *description[256]);



/**
 * @brief Returns buffer with parameter sets and its length
 * @param[in] instance the video encoder instance.
 * @param[in] set the encoder settings.
 * @param[out] buffer be sure to allocate enough memory for buffer (1024 bytes should be more than enough)
 * @param[out] length actual size of the data after calling this function
 * @return 	@ref H264ERROR_NONE if successful
 * @return  @ref H264ERROR_FAILED if not
 */
int32_t MC_EXPORT_API h264MfxOutVideoGetParSets(h264_mfx_v_enc_tt *            instance,
                                             struct h264_v_mfx_settings * set,
                                             uint8_t *                buffer,
                                             int32_t *                length);


APIEXTFUNC  MC_EXPORT_API h264MfxOutVideoGetAPIExt(uint32_t func);

#ifdef __cplusplus
}
#endif


#endif // #if !defined (__ENC_AVC_API_INCLUDED__)

