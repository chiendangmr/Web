 /**
@file  dec_vc3.h
@brief VC-3 Decoder API

@verbatim
File: dec_vc3.h 
Desc: VC-3 Decoder API

 Copyright (c) 2015 MainConcept GmbH or its affiliates.  All rights reserved.

 MainConcept and its logos are registered trademarks of MainConcept GmbH or its affiliates.  
 This software is protected by copyright law and international treaties.  Unauthorized 
 reproduction or distribution of any portion is prohibited by law.
@endverbatim
**/

#if !defined (__DEC_VC3_API_INCLUDED__)
#define __DEC_VC3_API_INCLUDED__

#include "bufstrm.h"
#include "mcapiext.h"


/** @name Auxiliary commands of VC-3 decoder
 *  @{
 */
#define VC3_GET_SEQ_PARAMSP_SET_EXT 0x00010091 /**<@brief Get extended information */
/** @} */

/** @name Extended VC-3 stream parameters
 *  @{
 */
typedef struct vc3_seq_params_ext_s {
    int32_t bit_depth;                         /**<@brief bit depth */
    int32_t chroma_format;                     /**<@brief chroma format (one of @ref CHROMA400 .. @ref CHROMA810 defines) */
} vc3_seq_params_ext_t;
/** @} */


/** @name VC-3 decoder API functions
 *  @{
 */

#ifdef __cplusplus
extern "C" {
#endif

/**
 * @brief Call this function to get a bufstream interface for the VC-3 video decoder.
 * @return The video decoder instance.
 */
bufstream_tt *  MC_EXPORT_API open_vc3in_Video_stream(void);

/**
 * @brief Call this function to get a bufstream interface for the VC-3 video decoder.
 * @param[in] get_rc  callbacks to external message handler and memory manager functions
 * @param[in] reserved1 reserved parameter
 * @param[in] reserved2 reserved parameter
 * @return The video decoder instance.
 */
bufstream_tt *  MC_EXPORT_API open_vc3in_Video_stream_ex(void *(MC_EXPORT_API *get_rc)(const char* name), long reserved1, long reserved2);

/**
 * @brief Provides access to extended module API.
 * @param[in] function identifier of module extended function. Single valid value is @ref MCAPI_GetModuleInfo.
 * @return Pointer to requested function or NULL.
 */
APIEXTFUNC      MC_EXPORT_API vc3in_Video_GetAPIExt(uint32_t func);

#ifdef __cplusplus
}
#endif

/** @} */

#endif // #if !defined (__DEC_VC3_API_INCLUDED__)
