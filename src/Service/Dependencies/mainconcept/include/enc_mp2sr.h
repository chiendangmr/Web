/**
@file: enc_mp2sr.h
@brief MPEG-2 Smart Rendering API

@verbatim
File: enc_mp2sr.h
Desc: MPEG-2 Smart Rendering API
 
 Copyright (c) 2015 MainConcept GmbH or its affiliates.  All rights reserved.

 MainConcept and its logos are registered trademarks of MainConcept GmbH or its affiliates.  
 This software is protected by copyright law and international treaties.  Unauthorized 
 reproduction or distribution of any portion is prohibited by law.
@endverbatim
**/

#if !defined (__ENC_MP2SR_API_INCLUDED__)
#define __ENC_MP2SR_API_INCLUDED__

#if !defined (API_EXT_PARAM_LIST)
#define API_EXT_PARAM_LIST
#endif

#include "enc_mp2v.h"
#include "enc_mpa.h"
#include "mfimport.h"

/**
 * @defgroup ENC_MP2SR_ERROR_FLAGS  Smart Rendering Error Flags
 * @{
 * @brief Additional error flags for Smart Rendering.
 *
 * @details Some of API functions may return combinations of these flags and describe if and why Smart Rendering is available or not. 
 * In case of errors additional information may be provided via @ref GET_RC_PAGE "Get Resource Callbacks"
 */
#define mpegOutVidSR           0x00000010   /**<@brief Video can be smart-rendered @hideinitializer*/
#define mpegOutAudSR           0x00000020   /**<@brief Audio can be smart-rendered @hideinitializer*/
#define mpegOutVidSRRequant    0x00000040   /**<@brief Video will be requantized (bitrates do not match) @hideinitializer*/

#define mpegOutVidError        0x00000100  /**<@brief Video error flag @hideinitializer*/
#define mpegOutVidNoVid        0x00000300  /**<@brief No video available @hideinitializer*/
#define mpegOutVidHSize        0x00000500  /**<@brief Horizontal sizes do not match @hideinitializer*/
#define mpegOutVidVSize        0x00000900  /**<@brief Vertical sizes do not match @hideinitializer*/
#define mpegOutVidM            0x00001100  /**<@brief MPEG M's do not match @hideinitializer*/
#define mpegOutVidN            0x00002100  /**<@brief MPEG N's do not match @hideinitializer*/
#define mpegOutVidType         0x00004100  /**<@brief MPEG type (1 or 2) do not match @hideinitializer*/
#define mpegOutVidBitrateType  0x00008100  /**<@brief The bitrate types (constant/variable) do not match @hideinitializer*/
#define mpegOutVidBitrate      0x00010100  /**<@brief The bitrates do not match @hideinitializer*/
#define mpegOutVidFieldOrder   0x00020100  /**<@brief The progressive frame or field order does not match @hideinitializer*/
#define mpegOutVidFrameRate    0x00040100  /**<@brief The framerate does not match @hideinitializer*/
#define mpegOutChromaFormat    0x00080100  /**<@brief Chroma format does not match @hideinitializer*/

#define mpegOutAudError        0x00100000  /**<@brief Audio error flag @hideinitializer*/
#define mpegOutAudNoAud        0x00300000  /**<@brief No audio available @hideinitializer*/
#define mpegOutAudLayer        0x00500000  /**<@brief Layer types do not match @hideinitializer*/
#define mpegOutAudFreq         0x00900000  /**<@brief Frequencies do not match @hideinitializer*/
#define mpegOutAudBitrate      0x01100000  /**<@brief Audio bitrates do not match @hideinitializer*/
#define mpegOutAudCRC          0x02100000  /**<@brief CRC's (enabled/disabled) do not match @hideinitializer*/
#define mpegOutAudMode         0x04100000  /**<@brief Audio modes (stereo, mono, etc.) do not match @hideinitializer*/
/** @} */

// Smart Rendering object
/**
 * @name ENC_MP2SR_INST Smart Rendering Instance
 * This type is used as handle for the Smart Rendering instance.
 * @{
 */
typedef struct sr_wrapper srwrapper_tt;
/** @} */


#ifdef __cplusplus
extern "C" {
#endif


/**
* @defgroup ENC_MP2SR_API_FUNCTIONS  MPEG-2 Smart Rendering API Functions
* @{
* @brief API functions for MPEG-2 Smart Rendering usage
*/


/**
 * @brief Check if an input file and output settings are compatible to enable Smart Rendering.
 * @param[in] v_settings        - pointer to a filled @ref mpeg_v_settings structure with output video settings
 * @param[in] a_settings        - pointer to a filled @ref mpeg_a_settings structure with output audio settings
 * @param[in] in_info           - pointer to an @ref mpegInInfo structure with input stream information received from @ref MFIMPORT_PAGE "Media File Importer"
 * @param[in] audio_rate        - output audio frequency
 * @return               Returns a combination of @ref ENC_MP2SR_ERROR_FLAGS "Smart Rendering Error Flags"
 */
int32_t MC_EXPORT_API srWrapperInputCheck(struct mpeg_v_settings *v_settings,
                                          struct mpeg_a_settings *a_settings,
                                          struct mpegInInfo      *in_info,
                                          uint32_t                audio_rate);

/**
 * @brief Attach a new input file to the Smart Rendering module.
 *                             Must be called before any frame is passed to the encoder.
 * @param[in] instance         - pointer to the @ref sr_wrapper "Smart Rendering instance" which was created by srWrapperVideoNew().
 * @param[in] in_info          - pointer to an @ref mpegInInfo structure with input stream information received from the @ref MFIMPORT_PAGE "Media File Importer"
 * @return               Returns a combination of @ref ENC_MP2SR_ERROR_FLAGS "Smart Rendering Error Flags"
 */
int32_t MC_EXPORT_API srWrapperInputAttach(srwrapper_tt      *instance,
                                           struct mpegInInfo *in_info);

/**
 * @brief Detach the current input file from the Smart Rendering module. The same functionality can also be achieved by calling @ref srWrapperDone().
 * @param[in] instance         - pointer to the @ref  sr_wrapper "Smart Rendering instance" which was created by srWrapperVideoNew().
 * @return                     NONE
 *
 */
void MC_EXPORT_API srWrapperInputDetach(srwrapper_tt *instance);

/**
 * @brief Finish a Smart Rendering session.
 * @param[in] instance         - pointer to the @ref  sr_wrapper "Smart Rendering instance" which was created by srWrapperVideoNew().
 * @param[in] abort            - 0 = finish any leftover video and clean up, else just clean up
 * @return mpegOutErrNone if everything is ok, or one of @ref mpegOutErrNone " MPEG output return codes"
 */
int32_t MC_EXPORT_API srWrapperDone(srwrapper_tt *instance,
                                    int32_t       abort);

/**
 * @brief srWrapperFree destroy a Smart Rendering instance.
 * @param[in] instance         - pointer to the @ref  sr_wrapper "Smart Rendering instance" which was created by srWrapperVideoNew().
 * @return                     NONE
 */
void MC_EXPORT_API srWrapperFree(srwrapper_tt *instance);

/**
 * @brief Fill an @ref mpeg_v_settings settings structure with default values.
 * @param[out] set               - pointer to a filled @ref mpeg_v_settings structure with output video settings
 * @param[in]  video_type        - preset used for loading default values (it may be one of the @ref MPEG2_PRESETS_AND_PROFILES "MPEG-2 Profiles or Presets")
 * @param[in]  PAL               - video format, 1 = PAL, 0 = NTSC
 * @return   type describing character string or NULL if video type is not supported.
 */
char * MC_EXPORT_API srWrapperVideoDefaults(struct mpeg_v_settings *set,
                                            int32_t                 video_type,
                                            int32_t                 PAL);
/**
 * @brief Check if settings are valid.
 * @param[in] get_rc              - pointer to @ref GET_RC_PAGE "Get Resource Callback"
 * @param[in] set                 - pointer to filled @ref mpeg_v_settings structure with output video settings
 * @param[in] options             - options (@ref CHECK_MPEG_ONLY or @ref CHECK_ALL) for MPEG-2 encoder which will be used with @ref mpegOutVideoChkSettings() calling
 * @param[in] app                 - reserved pointer (not used at this time)
 * @return  Any combination of @ref ENC_MP2SR_ERROR_FLAGS  "Smart Rendering Error Flags".
 */
int32_t MC_EXPORT_API srWrapperVideoChkSettings(void                         *(MC_EXPORT_API *get_rc)(const char* name),
                                                const struct mpeg_v_settings *set,
                                                uint32_t                      options,
                                                void                         *app);

/**
 * @brief Adjust the settings for quality/perfornace related purposes
 * @param[out] set                  - pointer to filled @ref mpeg_v_settings structure with output video settings
 * @param[in]  mode                 - one of the @ref PERF_OFFLINE "Performance modes"
 * @param[in]  level                - performance/quality level 
 * @return   NONE
 * @note                            This function should be called immediately before calling @ref srWrapperVideoNew
 *
 */
void MC_EXPORT_API srWrapperVideoPerformance(struct mpeg_v_settings *set,
                                             int32_t                 mode,
                                             int32_t                 level,
                                             int32_t                 reserved);

/**
 * @brief Create a Smart Rendering object. Only video is setup for
 *                          Smart Rendering with this function, for adding audio Smart Rendering
 *                          the @ref srWrapperAudioNew() function must be called as well.
 * @param[in] get_rc        - pointer to a @ref GET_RC_PAGE "Callback" which will provide additional information, warning and error messages
 * @param[in] set           - pointer to a filled @ref mpeg_v_settings structure with output video settings
 * @param[in] options       - options for the MPEG-2 encoder which will be used with mpegOutVideoNew() calling
 * @param[in] cpu           - enable/disable CPU optimization mode\n
 *                              1 - up to MMX mode           \n
 *                              2 - up to 3DNOW mode         \n
 *                              3 - up to SSE mode           \n
 *                              4 - up to AMD 3DNOWEXT mode  \n
 *                              5 - up to SSE2 mode          \n
 *                              0xFFFFFFFF - autodetect available optimization mode \n
 *                              In other cases CPU optimization will be disabled (Plain C/C++ will be used)
 * @return                  Returns a pointer to a Smart Rendering instance.
 */
srwrapper_tt * MC_EXPORT_API srWrapperVideoNew(void                         *(MC_EXPORT_API *get_rc)(const char* name),
                                               const struct mpeg_v_settings *set,
                                               int32_t                       options,
                                               int32_t                       cpu,
                                               int32_t                       frame0,
                                               int32_t                       nframes);

/**
 * @brief Initialize the Smart Rendering module for an encoding session, this 
 *                           function must be called before the @ref srWrapperVideoPutFrame or @ref srWrapperAudioPutBytes functions are called.
 *                           Only video is setup for Smart Rendering with this function, for initializing
 *                           audio smart rendering the @ref srWrapperAudioInit function must be called.
 * @param[in] instance      - pointer to the @ref  sr_wrapper "Smart Rendering instance" which was created by srWrapperVideoNew().
 * @param[in] videoobs      - a pointer to a @ref bufstream_tt object for the compressed data output stream
 * @param[in] options_flags - either of
 * 							  @li @ref INIT_OPT_EXTERN_FRM_BUF - use external frame buffer (I420 and YV12 only)
 *                            @li @ref INIT_OPT_NR_FILT - use preprocessing filter
 *                            @li @ref INIT_OPT_VBR_TWO_PASSES - use internal metadata for 2-pass encoding
 *                            @li @ref INIT_OPT_VBR_ANALYSE - init for analyze pass (see chapter @ref ENC_MPEG_TWO_PASS_PAGE "2-pass Encoding")
 *                            @li @ref INIT_OPT_VBR_ENCODING - init for encoding pass
 *                            @li @ref INIT_OPT_CHAPTER_LIST - use to set chapter marks (starts a new GOP)
 *                            @li @ref INIT_OPT_UD_FIRST_SEQHDR - put user data after the first sequence hdr
 *                            @li @ref INIT_OPT_UD_ALL_SEQHDR - put user data after all sequence headers
 * @param[in] opt_ptr       - array of pointers for options set in @ref option_flags
 *
 * @return @ref mpegOutErrNone if successful, @ref mpegOutError if an error occurs
 */
int32_t MC_EXPORT_API srWrapperVideoInit(srwrapper_tt  *instance,
                                         bufstream_tt  *bs,
                                         int32_t        options,
                                         void         **opt_ptr);

/**
 * @brief Pass a new video frame to the Smart Rendering module.
 * @param[in] instance           - pointer to the @ref  sr_wrapper "Smart Rendering instance" which was created by srWrapperVideoNew().
 * @param[in] frame_num          - if @ref rendered option is 1 and this frame is not from the source
 *                               file (i.e. this frame is being inserted between frames
 *                               of the source file), set this to -1. Else set this to
 *                               the source file frame number
 * @param[in] rendered           - if 0, frame is smart-rendered if possible. If 1, frame is re-encoded.
 * @param[in] pb_src             - source buffer, used if frame_num = -1     
 * @param[in] stride             - stride of source picture     
 * @param[in] width              - width of source picture     
 * @param[in] height             - height of source picture     
 * @param[in] fourcc             - colorspace of source picture (FOURCC)     
 * @param[in] options            - options flag     
 * @param[in] opt_ptr            - pointer to options data     
 * @return                       @ref mpegOutErrNone if successful, @ref mpegOutError or mpegOutDecline if not       
 */
int32_t MC_EXPORT_API srWrapperVideoPutFrame(srwrapper_tt   *instance,
                                             int32_t         frame_num,
                                             int32_t         rendered,
                                             unsigned char  *pb_src,
                                             int32_t         stride,
                                             uint32_t        width,
                                             uint32_t        height, 
                                             uint32_t        fourcc,
                                             uint32_t        options,
                                             void          **opt_ptr);

/**
 * @brief Pass a new video frame to the Smart Rendering module (using the built-in FOURCC_BGR4 colorspace).
 * @param[in] instance      - pointer to the @ref  sr_wrapper "Smart Rendering instance" which was created by srWrapperVideoNew().
 * @param[in] frame_num     - if @ref rendered is 1 and this frame is not from the source
 *                          file (i.e. this frame is being inserted between frames
 *                          of the source file), set this to -1. Else set this to
 *                          the source file frame number
 * @param[in] rendered      - if 0, frame is smart-rendered if possible. If 1, frame is re-encoded.
 * @param[in] pb_src        - source buffer, used if frame_num = -1     
 * @return                  @ref mpegOutErrNone if successful, @ref mpegOutError or @ref mpegOutDecline if not       
 */
int32_t MC_EXPORT_API srWrapperVideoPut(srwrapper_tt  *instance,
                                        int32_t        frame_num,
                                        int32_t        rendered,
                                        unsigned char *pb_src);


/**
 * @brief Pass a new video frame to the Smart Rendering module (using a frame structure).
 * @param[in] instance            - pointer to the @ref  sr_wrapper "Smart Rendering instance" which was created by srWrapperVideoNew().
 * @param[in] frame_num           - if @ref rendered is 1 and this frame is not from the source
 *                                file (i.e. this frame is being inserted between frames
 *                                of the source file), set this to -1. Else set this to
 *                                the source file frame number
 * @param[in] rendered            - if 0, frame is smart-rendered if possible. If 1, frame is re-encoded.
 * @param[in] pframe_v            - pointer to object @ref frame_v_tt
 * @return                        @ref mpegOutErrNone if successful, @ref mpegOutError or @ref mpegOutDecline if not       
 */
int32_t MC_EXPORT_API srWrapperVideoPutFrameV(srwrapper_tt *instance,
                                              int32_t       frame_num,
                                              int32_t       rendered,
                                              pframe_v_tt   pframe_v);

/**
 * @brief Get the maximum bitrate achieved during a session.
 * @param[in] instance                - pointer to the @ref  sr_wrapper "Smart Rendering instance" which was created by srWrapperVideoNew().
 * @return                            Returns the maximum bitrate achieved until now.
 */
int32_t MC_EXPORT_API srWrapperVideoGetMaxBitrate(srwrapper_tt *instance);

/**
 * The API Extension control.
 * @param func one of the following API function identifiers:
 *    MCAPI_GetModuleInfo
 * @return pointer to the requested API function or NULL, if not supported.
 */
APIEXTFUNC MC_EXPORT_API srWrapperGetAPIExt(uint32_t func);


/**@}*/

#ifdef __cplusplus
}
#endif

#endif // #if !defined (__ENC_MP2SR_API_INCLUDED__)

