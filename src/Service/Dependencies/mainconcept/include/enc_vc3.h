/**
@file: enc_vc3.h
@brief VC-3 Encoder API

@verbatim
File: enc_vc3.h
Desc: VC-3 Encoder API

Copyright (c) 2015 MainConcept GmbH or its affiliates.  All rights reserved.

MainConcept and its logos are registered trademarks of MainConcept GmbH or its affiliates.  
This software is protected by copyright law and international treaties.  Unauthorized 
reproduction or distribution of any portion is prohibited by law.
@endverbatim
**/

#if !defined (__ENC_VC3_API_INCLUDED__)
#define __ENC_VC3_API_INCLUDED__

#include "mctypes.h"
#include "bufstrm.h"
#include "mcapiext.h"
#include "mcdefs.h"
#include "v_frame.h"

#include "enc_vc3_def.h"

typedef struct vc3_v_encoder  vc3_v_enc_tt; /**<@brief The encoder instance type */
typedef struct vc3_v_settings vc3_v_set_tt; 

/**
* @name Settings structure
* @brief These parameters are used to configure output format of the encoder. 
* @{
*/

/** @brief These parameters are used to configure output format of the encoder.
    @details See @ref VC3_VIDEO_TYPES to get one of predefined settings set with @ref vc3OutVideoDefaults.  
    @note Please use multiplexer settings to specify framerate.
 */

#pragma pack(push, 1)

struct vc3_v_settings
{
    uint32_t preset;             /**<@brief Predefined set of general settings @see VC3_VIDEO_TYPES */

    uint32_t width;              /**<@brief Width of output image. Should be an even number greater than or equal to @ref VC3_MIN_WIDTH.*/
    uint32_t height;             /**<@brief Height of output image. Should be an even number greater than or equal to @ref VC3_MIN_HEIGHT.*/
    uint32_t bit_depth;          /**<@brief Target bit depth should be 8 for [LB](@ref VC3_QUALITY_LB), [SQ](@ref VC3_QUALITY_SQ), [HQ](@ref VC3_QUALITY_HQ) qualities and 10 or 12 for [HQX](@ref VC3_QUALITY_HQX) and [444](@ref VC3_QUALITY_444) */

    uint32_t chroma_format;      /**<@brief Reserved for future usage. Should be 0 */

    uint32_t color_space;        /**<@brief Output colorspace. Should be @ref VC3_COLOR_SPACE_YUV or @ref VC3_COLOR_SPACE_RGB */
    uint32_t scan_type;          /**<@brief Output scan type. Should be either @ref VC3_PROGRESSIVE or @ref VC3_INTERLACED */   

    uint32_t quality;            /**<@brief Should be one of [VC3_QUALITY_*](@ref VC3_QUALITY_LB) values. Specify output quality, chroma format and also possible colorspace and color bits. */
    uint32_t num_threads;        /**<@brief Number of threads (0 = auto detection) */

    uint32_t colorimetry;        /**<@brief Colorimetry. Should be @ref VC3_COLORIMETRY_AUTO or @ref VC3_COLORIMETRY_BT709 or @ref VC3_COLORIMETRY_BT2020 */
    uint32_t src_signal_range;   /**<@brief Full-range or clamped signal range of source video. Should be @ref VC3_SIGNAL_RANGE_PC or @ref VC3_SIGNAL_RANGE_STUDIO */
    uint32_t dst_signal_range;   /**<@brief Full-range or clamped signal range of output video. Should be @ref VC3_SIGNAL_RANGE_PC or @ref VC3_SIGNAL_RANGE_STUDIO */

    uint32_t reserved_int32[116];  /**<@brief Reserved */
};

#pragma pack(pop)

/** @} */

#ifdef __cplusplus
extern "C" {
#endif


/**
* @brief Fills settings structure provided with predefined values.
* @param[out] set         Pointer to vc3_v_set_tt structure
* @param[in]  video_type  Video profile ID. Should be one of the following list: @ref VC3_VIDEO_TYPES
* @param[in]  reserved    Reserved for future usage
* @return Profile name string or NULL in case wrong set pointer provided
*/
const char * MC_EXPORT_API vc3OutVideoDefaults(vc3_v_set_tt * set, int32_t video_type, int32_t reserved);

/**
* @brief Checks encoder settings for any conformance invalidation.
* @param[in] get_rc  The [get_rc](@ref GET_RC_PAGE) callback to provide an err_printf callback to get error messages that can be localized. 
* @param[in] set     The encoder settings.
* @param[in] options Not supported
* @param[in] app     Not supported
* @return @ref VC3_ERROR_NONE if successful, @ref VC3_ERROR_FAILED if not
* @see @ref GET_RC_PAGE.
*/
int32_t MC_EXPORT_API vc3OutVideoChkSettings(void * (MC_EXPORT_API * get_rc)(const char* name),
                                             vc3_v_set_tt *          set,
                                             uint32_t                options,
                                             void *                  app);

/**
* @brief Creates a new encoder instance.
* @param[in] get_rc  The [get_rc](@ref GET_RC_PAGE) callback to provide an err_printf callback to get error messages that can be localized.
* @param[in] set     The encoder settings.
* @param[in] options Not supported
* @param[in] CPU     CPU optimization flag (Not supported)
* @param[in] frame0  Start frame (Not supported)
* @param[in] nframes Number of frames (Not supported)
* @return @ref VC3_ERROR_NONE if successful, @ref VC3_ERROR_FAILED if not
* @see @ref GET_RC_PAGE.
*/

vc3_v_enc_tt * MC_EXPORT_API vc3OutVideoNew(void * (MC_EXPORT_API * get_rc)(const char* name),
                                            const vc3_v_set_tt *    set,
                                            int32_t                 options,
                                            int32_t                 CPU,
                                            int32_t                 frame0,
                                            int32_t                 nframes);

/**
* @brief Initializes the encoder for a new session. Must be called before the @ref vc3OutVideoPutFrame function.
* @param[in] instance  The encoder instance.
* @param[in] bs        Bufstream object for writing data. Must be initialized before.
* @param[in] opt_flags options use @ref VC3_CHECK_AND_ADJUST to adjust settings to be conform.
* @param[in] opt_ptr   Pointer to options (Not supported)
* @return @ref VC3_ERROR_NONE if successful, @ref VC3_ERROR_FAILED if not
*/
int32_t MC_EXPORT_API vc3OutVideoInit(vc3_v_enc_tt * instance,
                                      bufstream_tt * bs,
                                      uint32_t       opt_flags,
                                      void **        opt_ptr);


/**
* @brief Destroys the encoder instance.
* @param[in] instance the encoder instance.
*/
void MC_EXPORT_API vc3OutVideoFree(vc3_v_enc_tt * instance);

/**
* @brief Finish encoding session.
* @param[in] instance The encoder instance.
* @param[in] abort    Specifies how to finish the encoder (0 = finish leftover frames and clean up, else just clean up).
* @return @ref VC3_ERROR_NONE if successful, @ref VC3_ERROR_FAILED if not
*/
int32_t MC_EXPORT_API vc3OutVideoDone(vc3_v_enc_tt * instance, int32_t abort);

/**
* @brief Encodes one video frame.
* @param[in] instance       The encoder instance.
* @param[in] pb_src         Pointer to the frame buffer to be encoded.
* @param[in] src_line_size  The number of bytes per (luma) line.
* @param[in] src_width      The horizontal resolution.
* @param[in] src_height     The vertical resolution.
* @param[in] fourcc         The colorspace of the input frame (see mcfourcc.h).
* @param[in] option_flags   Options flags. Not supported. Should be 0
* @param[in] ext_info       An array of extended info pointers. Not supported. Should be NULL 
* @return @ref VC3_ERROR_NONE if successful, @ref VC3_ERROR_FAILED if not
*/

int32_t MC_EXPORT_API vc3OutVideoPutFrame(vc3_v_enc_tt * instance,
                                          uint8_t *      pb_src,
                                          int32_t        src_line_size,
                                          int32_t        src_width,
                                          int32_t        src_height,
                                          uint32_t       fourcc,
                                          uint32_t       option_flags,
                                          void **        ext_info);

/**
 * @brief Encodes one video frame.
 * @param[in] instance   A pointer to the encoder instance created by @ref vc3OutVideoNew
 * @param[in] frame      A pointer to the picture buffer to be encoded
 * @param[in] opt_flags  Options flags. Not supported. Should be 0
 * @param[in] ext_info   An array of extended info pointers. Not supported. Should be NULL 
 * @return @ref VC3_ERROR_NONE if successful, @ref VC3_ERROR_FAILED if not
 */
int32_t MC_EXPORT_API vc3OutVideoPutFrameV(vc3_v_enc_tt *   instance,
                                           video_frame_tt * frame,
                                           uint32_t         option_flags,
                                           void **          ext_info);

/**
* @brief Returns buffer with parameter sets and its length.
* @param[in]  instance The encoder instance.
* @param[in]  set      The encoder settings.
* @param[out] buffer   Buffer which will be used for writing of parameter sets, buffer can be NULL, in this case the encoder just calculates and returns length required to store parameter sets.
* @param[out] length   A length of the buffer, initially should contain the actual length of the buffer, when the function returns length will contain the actual number of bytes written into the buffer
* @return @ref VC3_ERROR_NONE if successful, @ref VC3_ERROR_FAILED if not
*/
int32_t MC_EXPORT_API vc3OutVideoGetParSets(vc3_v_enc_tt * instance,
                                            vc3_v_set_tt * set,
                                            uint8_t *      buffer,
                                            uint32_t *     length);


/**
* @brief Flushes the encoders input and output queues. This function will wait (block) until all encoder queues are empty. Optionally the abort parameter can force it to drop queued frames.
* @param[in] instance  The video encoder instance.
* @param[in] abort     Specifies how to flush the encoder.  0 - waits (blocks) until all queued frames are processed. 1 - drop waiting frames, and return after the current frame has completed processing.
* @return @ref VC3_ERROR_NONE if successful, @ref VC3_ERROR_FAILED if not
*/
int32_t MC_EXPORT_API vc3OutVideoFlush(vc3_v_enc_tt * instance, int32_t abort);

/**
* @brief Get extended API function pointers.
* @param[in] Func the ID of the requested API function @see mcapiext.h
* @return Function identifier of module extended function. 
* @remarks Single valid value is @ref MCAPI_GetModuleInfo.
*/
APIEXTFUNC  MC_EXPORT_API vc3OutVideoGetAPIExt(uint32_t func);


#ifdef __cplusplus
}
#endif

#endif // #if !defined (__ENC_VC3_API_INCLUDED__)

