/**
@file: enc_dv.h
@brief DV Encoder API

@verbatim
File: enc_dv.h
Desc: DV Encoder API
 
 Copyright (c) 2015 MainConcept GmbH or its affiliates.  All rights reserved.

 MainConcept and its logos are registered trademarks of MainConcept GmbH or its affiliates.  
 This software is protected by copyright law and international treaties.  Unauthorized 
 reproduction or distribution of any portion is prohibited by law.
@endverbatim
 **/

#if !defined (__ENC_DV_API_INCLUDED__)
#define __ENC_DV_API_INCLUDED__

#include "dv_info.h"
#include "mcfourcc.h"
#include "mcapiext.h"

#ifdef __cplusplus
extern "C" {
#endif

/**
@def COF
@name Compressor options flags
@{
*/

#define UL_COMP_INV_FIELDS_ORDER            0x00000001        /**<@brief Invert fields @hideinitializer*/
#define UL_COMP_FASTEST                     0x00000002        /**<@brief Fast encoding mode @hideinitializer*/
#define UL_COMP_16x9FLAG                    0x00000004        /**<@brief Set 16x9-flag in Video-SourceControl Pack of DV-frame @hideinitializer*/
#define UL_COMP_16x9_LETTERBOX              0x00001000        /**<@brief Set 16x9-letterbox in Video-SourceControl Pack of DV-frame @hideinitializer*/
#define UL_COMP_DVC_PRO                     0x00000008        /**<@brief Create SMPTE-314M 25 MBit @hideinitializer*/
#define UL_COMP_DVC_PRO50                   0x00000108        /**<@brief Create SMPTE-314M 50 MBit @hideinitializer*/
#define UL_COMP_DV_HD                       0x00000200        /**<@brief Create DV HD 50 MBit (not implemented) @hideinitializer*/
#define UL_COMP_HEADERLESS                  0x00000010        /**<@brief Don't create H0 header (DIF-H0) @hideinitializer*/
                                                              
#define UL_COMP_TEMPLATE                    0x00000020        /**<@brief Reuse existing DIF-frame as template @hideinitializer*/
#define UL_COMP_SINGLE_THREAD               0x00010000        /**<@brief Disable multiprocessing support in encoder @hideinitializer*/
                                                              
#define UL_COMP_BLEND_TO_BLACK              0x00100000        /**<@brief Do blending to black frame if alpha-channel is present @hideinitializer*/

#define UL_COMP_DV100                       0x00000400        /**<@brief Create SMPTE-370M 100 MBit @hideinitializer*/
#define UL_COMP_DV100_720P_SECOND_FRAME     0x00000800        /**<@brief Add 2*DIF-block size offset (720P only) @hideinitializer */
#define UL_COMP_DV100_50HZ_MODE             0x00000040        /**<@brief DVCPRO 100 PAL mode @hideinitializer */
#define UL_COMP_DV_PRO                      UL_COMP_DVC_PRO   /**<@brief Create SMPTE-314M 25 MBit @hideinitializer */
/**@}*/

// Creation and destruction of instance
/**
Call this function to create instance of DV encoder.
@return NONE
*/
void* MC_EXPORT_API DVNewEnc   (void);

/**
Release instance of DV encoder.
@param[in] instance - pointer to the object created by DVNewEnc   (void)
@return NONE
*/
void  MC_EXPORT_API DVDoneEnc  (void *instance);

/**
With DVCompressBuffer a DV frame is encoded from the specified input color format
@param[in] pbSrc            - Pointer to source buffer
@param[in] wRealLineSize    - Size of one line in byte (stride) in source buffer, could be negative
@param[in] pbDst            - Pointer to destination buffer
@param[in] ulDstBufLen      - Length of destination buffer
@param[in] SrcWidth         - Width of input image in pixel
@param[in] SrcHeight        - Height of input image in pixel
@param[in] reserved1        - Reserved, set to 0
@param[in] ulFlags          - Combination of the Compressor options flags (@ref UL_COMP_INV_FIELDS_ORDER .. @ref UL_COMP_DV_PRO)
@param[in] ColorSpaceFourcc - Source buffer color space, one of the FOURCC_xxx 
@param[in] reserved2        - Reserved, set to 0
@param[in] reserved3        - Reserved, set to NULL
@note Internal Resampling can be switched off (for speed and quality preservation when decompressing from DV100, editing, then compressing back to DV100):
 @li 960x720 50/59.94 fps progressive
 @li 1280x1080 29.97 fps interlaced
 @li 1440x1080 25 fps interlaced
*/
uint32_t MC_EXPORT_API DVCompressBuffer   (void     *instance,
                                  uint8_t  *pbSrc,       int32_t   wRealLineSize,
                                  uint8_t  *pbDst,       uint32_t  ulDstBufLen,
                                  uint32_t  SrcWidth,    uint32_t  SrcHeight, 
                                  uint32_t  quality,
                                  uint32_t  ulFlags,     uint32_t  ColorSpaceFourcc,
                                  uint32_t  reserved2,   uint8_t  *reserved3);


/**
\brief Provides access to extended module API.
\return  pointer to requested function or NULL
\param[in] func identifier of module extended function
 */								  
APIEXTFUNC MC_EXPORT_API DVEncGetAPIExt     (uint32_t func);


#ifdef __cplusplus
}
#endif

#endif // #if !defined (__ENC_DV_API_INCLUDED__)

