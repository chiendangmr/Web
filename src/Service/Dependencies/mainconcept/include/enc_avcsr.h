/**
@file: enc_avcsr.h
@brief AVC Smartrender Wrapper API

@verbatim
File: enc_avcsr.h
Desc: AVC Smartrender Wrapper API
 
 Copyright (c) 2015 MainConcept GmbH or its affiliates.  All rights reserved.

 MainConcept and its logos are registered trademarks of MainConcept GmbH or its affiliates.  
 This software is protected by copyright law and international treaties.  Unauthorized 
 reproduction or distribution of any portion is prohibited by law.
@endverbatim
 **/

#if !defined (__ENC_AVCSR_API_INCLUDED__)
#define __ENC_AVCSR_API_INCLUDED__

#if !defined (API_EXT_PARAM_LIST)
#define API_EXT_PARAM_LIST
#endif

#define AVC_SR_SUPPORTED
#include "enc_avc.h"
#include "mfimport.h"

/**
 * @name Smartrender Error Flags
 * Additional error flags for smart rendering. They are returned by the
 * @ref avcSRInputCheck and @ref avcSRInputAttach functions and describe if
 * smartrendering is available or why not.
 * @{
 */
#define avcSRAvail           0x00000010  /**<@brief Video can be smart rendered @hideinitializer*/
#define avcSRRequant         0x00000040  /**<@brief Video will be requantized (bitrates do not match) @hideinitializer*/

#define avcSRError           0x00000100  /**<@brief Error flag @hideinitializer*/
#define avcSRNoVid           0x00000300  /**<@brief No video available @hideinitializer*/
#define avcSRHSize           0x00000500  /**<@brief Horizontal sizes do not match @hideinitializer*/
#define avcSRVSize           0x00000900  /**<@brief Vertical sizes do not match @hideinitializer*/
#define avcSRGOPLength       0x00001100  /**<@brief GOP lengths do not match @hideinitializer*/
#define avcSRReordering      0x00002100  /**<@brief Reordering delays do not match @hideinitializer*/
#define avcSRBitrateType     0x00008100  /**<@brief The bitrate types (constant/variable) do not match @hideinitializer*/
#define avcSRBitrate         0x00010100  /**<@brief The bitrates do not match @hideinitializer*/
#define avcSRFieldOrder      0x00020100  /**<@brief The progressive frame or field orders do not match @hideinitializer*/
#define avcSRFrameRate       0x00040100  /**<@brief The frame rates dos not match @hideinitializer*/
#define avcSRChromaFormat    0x00080100  /**<@brief Chroma formats do not match @hideinitializer*/
#define avcSRProfile         0x00100100  /**<@brief Profiles do not match @hideinitializer*/
#define avcSRLevel           0x00200100  /**<@brief Levels do not match @hideinitializer*/
/** @} */


/**
 * @name Smartrender Option Flags
 * Options when attaching an input file
 * @{
 */
#define avcSROptionsSmartMode      0x00000010  /**<@brief Use encoder SMART mode, default is COPY mode @hideinitializer*/
#define avcSROptionsNoBitrateCheck 0x00000020  /**<@brief Do not perform bitrate conformance check @hideinitializer*/

#define avcSROptionsSwitchIFrame   0x00000040  /**<@brief Allow SR <-> non-SR switch at an I frame if not specified, switch can only occur at an IDR frame\n
                                                   Normally this option should be enabled, but it may cause problems in some files where true dependence
                                                   on a distant IDR frame is present.\n
                                                   The default is to allow switch at IDR frames only as it is the safest option and for files with IDR frames at 
                                                   regular intervals this is not a problem.\n
                                                   Some files have a single IDR frame at the start, if this option is not enabled for these files any
                                                   SR -> non SR switch after the IDR frame is permanent to the end of the stream and any non SR -> SR switches
                                                   after the IDR frame are not allowed  @hideinitializer*/
/** @} */


/**
 * @name AVC Smartrender Wrapper Instance
 * This type is used as handle for the smartrender wrapper instance.
 * @{
 */
typedef struct avcsr_wrapper_s avcsr_wrapper_tt;
/** @} */


#ifdef __cplusplus
extern "C" {
#endif


/**
 * @name AVC Smartrender Wrapper Settings
 * This type is used as declaration of AVC Smart Render Wrapper creation settings.
 * @{
 */
typedef struct avcsr_wrapper_settings_s
{
  int32_t                 api_version;               /**< API version */
  void                  * app_ptr;                   /**< Application pointer */
  void * (MC_EXPORT_API * get_rc)(const char *name); /**< Pointer to set of callbacks used for memory allocation, printing messages etc. */
  int32_t                 reserved[64];              /**< Reserved for future */
} avcsr_wrapper_settings_tt;
/** @} */


/**
 * @brief avcSRWrapperNew Create new AVC SR wrapper instance.
 * @param[in] set         pointer to wrapper settings structure.
 * @return                returns pointer to a new wrapper instance or NULL on failure.
 * @remark                The settings data should be filled before the function call.
 *
 * @code
 * ...
 * @endcode
 */
avcsr_wrapper_tt* MC_EXPORT_API avcSRWrapperNew(avcsr_wrapper_settings_tt * set);


/**
 * @brief avcSRWrapperFree Destroys AVC SR wrapper instance.
 * @param[in] instance     pointer to SR wrapper instance.
 * @return                 returns 0 on success or error code on failure.
 * @remark                 The SR wrapper should not be used after this function call.
 *
 * @code
 * ...
 * @endcode
 */
int32_t MC_EXPORT_API avcSRWrapperFree(avcsr_wrapper_tt * instance);


/**
 * @brief avcSRWrapperInit Initialize the smartrender wrapper for an encoding session, this 
 *                         function must be called before the PutFrame or PutByte functions are called.
 *                         Only video is setup for smart rendering with this function, for initializing
 *                         audio smartrenderer the srWrapperAudioInit function must be called.
 * @param[in] instance     pointer to the smartrender instance.
 * @param[in] bs           pointer to a bufstream object.
 * @param[in] options      option flags.
 * @param[in] opt_ptr      pointer to option list.
 * @return
 *
 * @code
 * ...
 * @endcode
 */
int32_t MC_EXPORT_API avcSRWrapperInit(avcsr_wrapper_tt  * instance,
                                       bufstream_tt      * bs,
                                       uint32_t            options,
                                       void             ** opt_ptr);


/**
 * @brief avcSRWrapperDone Finish a smartrender session.
 * @param[in] instance  pointer to the smartrender instance.
 * @param[in] abort
 * @return
 *
 * @code
 * ...
 * @endcode
 */
int32_t MC_EXPORT_API avcSRWrapperDone(avcsr_wrapper_tt * instance,
                                       int32_t            abort);



int32_t MC_EXPORT_API avcSRWrapperGetDefaultSettings(int32_t                  preset,
                                                     int32_t                  width,
                                                     int32_t                  height,
                                                     double                   frame_rate,
                                                     int32_t                  interlace_mode,
                                                     void * (MC_EXPORT_API   *get_rc)(const char* name),
                                                     h264_v_settings_tt      *set,
                                                     const char             **string_ptr);

/**
 * @brief avcSRWrapperGetDefaultSettings Fill settings structure with default values according to preset and input resolution, frame rate and picture mode.
 * @param[in]  preset                       type used for loading default values (e.g. MCPROFILE_AVCHD)
 * @param[in]  width
 * @param[in]  height
 * @param[in]  frame_rate
 * @param[in]  interlace_mode
 * @param[out] set                          pointer to the settings structure.
 * @param[out] string_ptr                   type description character string or NULL if preset is not supported
 * @return                                  returns 0 on success, 1 for failure, and 4 on adjusted state(if some of input parameters were changed).
 */

void MC_EXPORT_API avcSRWrapperTuneSettings(struct h264_v_settings * set,
                                            int32_t                  mode,
                                            int32_t                  level,
                                            int32_t                  reserved);


/**
 * @brief avcSRWrapperCheckSettings Check if settings are valid.
 * @param[in] get_rc
 * @param[in] set                   pointer to the settings structure.
 * @param[in] options
 * @param[in] app
 * @code
 * ...
 * @endcode
 */
int32_t MC_EXPORT_API avcSRWrapperCheckSettings(void                   * (MC_EXPORT_API * get_rc)(const char * name),
                                                struct h264_v_settings * set,
                                                uint32_t                 options,
                                                void                   * app);


/**
 * @brief avcSRWrapperGetSettings Fill a h264_v_settings structure with current encoding settings.
 *                                
 * @param[in] instance            pointer to SR wrapper instance.
 * @param[in] set                 pointer to settings structure to be filled.
 * @param[in] in_info             pointer to input stream info.
 * @return                        returns 0 on success or error code on failure.
 * @remark                        in_info used when encoding settings are not initialized.
 *
 * @code
 * ...
 * @endcode
 */
int32_t MC_EXPORT_API avcSRWrapperGetSettings(avcsr_wrapper_tt       * instance,
                                              struct h264_v_settings * set,
                                              struct mpegInInfo      * in_info);


/**
 * @brief avcSRWrapperSetSettings Set/update current encoder settings.
 * @param[in] instance            pointer to the SR wrapper instance.
 * @param[in] set                 pointer to h264_v_settings structure.
 * @return                        returns 0 on success or error code on failure.
 * @remark                        Settings are not checked and should be initially received by avcSRWrapperGetSettings().
 *
 * @code
 * ...
 * @endcode
 */
int32_t MC_EXPORT_API avcSRWrapperSetSettings(avcsr_wrapper_tt       * instance,
                                              struct h264_v_settings * set);


/**
 * @brief avcSRWrapperInputCheck Check if an input file and export settings are compatible to enable smartrendering.
 * @param[in] set
 * @param[in] in_info
 * @param[in] options            option flags, zero or more of the avcSROptionsXXX flags
 * @return                       returns a combination of codes defined above.
 *
 * @code
 * ...
 * @endcode
 */
int32_t MC_EXPORT_API avcSRWrapperInputCheck(struct h264_v_settings * set,
                                             struct mpegInInfo      * in_info,
                                             uint32_t                 options);


/**
 * @brief avcSRWrapperInputAttach Attach new input file to the AVC SR wrapper.
 * @param[in] instance            pointer to SR wrapper instance.
 * @param[in] in_info             pointer to input stream info to be attached.
 * @param[in] options             a set of avcSROptionsXXX flags.
 * @return                        returns a combination of codes defined above.
 * @remark                        Must be called before any frame of attached stream is passed to the SR wrapper.
 *
 * @code
 * ...
 * @endcode
 */
int32_t MC_EXPORT_API avcSRWrapperInputAttach(avcsr_wrapper_tt  * instance,
                                              struct mpegInInfo * in_info,
                                              uint32_t            options);


/**
 * @brief avcSRWrapperInputDetach Detach current input file from the smartrender wrapper.
 *                                Also be used by calling avcSRWrapperFree or avcSRWrapperInputAttach to detach current file.
 * @param[in] instance            pointer to the smartrender instance.
 *
 * @code
 * ...
 * @endcode
 */
void MC_EXPORT_API avcSRWrapperInputDetach(avcsr_wrapper_tt * instance);


/**
 * @brief avcSRWrapperPutFrame Pass a new video frame to the AVC SR wrapper.
 * @param[in] instance         pointer to SR wrapper instance.
 * @param[in] frame_num        if rendered is 1 and this frame is not from the source
 *                             file (i.e. this frame is being inserted between frames
 *                             of the source file), set this to -1 if video is passed
 *                             through pb_src or to source file frame number if video
 *                             should be extracted by mfimport. In case rendered is 0,
 *                             set this to the source file frame number to be encoded.
 * @param[in] rendered         if 0, frame is smartrendered if possible. If 1, frame is completely new encoded.
 * @param[in] pb_src           pointer to frame buffer.
 * @param[in] stride           frame stride in bytes.
 * @param[in] width            frame width.
 * @param[in] height           frame height.
 * @param[in] fourcc           frame colorspace.
 * @param[in] opt_flags        option flags.
 * @param[in] opt_ptr          pointer to option list.
 * @return                     returns 0 on success or error code on failure.
 *
 * @code
 * ...
 * @endcode
 */
int32_t MC_EXPORT_API avcSRWrapperPutFrame(avcsr_wrapper_tt * instance,
                                           int32_t            frame_num,
                                           int32_t            rendered,
                                           uint8_t*           pb_src,
                                           int32_t            stride,
                                           uint32_t           width,
                                           uint32_t           height, 
                                           uint32_t           fourcc,
                                           uint32_t           options,
                                           void             **opt_ptr);


/**
 * The API Extension control.
 * @param func one of the following API function identifiers:
 *    MCAPI_GetModuleInfo
 * @return pointer to the requested API function or NULL, if not supported.
 */
APIEXTFUNC MC_EXPORT_API avcSRWrapperGetAPIExt(uint32_t func);



#ifdef __cplusplus
}
#endif

#endif // #if !defined (__ENC_AVCSR_API_INCLUDED__)

