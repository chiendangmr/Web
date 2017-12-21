/** 
\file   dec_dv.h
\brief  DV Decoder API

\verbatim
File: dec_dv.h
Desc: DV Decoder API

 Copyright (c) 2015 MainConcept GmbH or its affiliates.  All rights reserved.

 MainConcept and its logos are registered trademarks of MainConcept GmbH or its affiliates.  
 This software is protected by copyright law and international treaties.  Unauthorized 
 reproduction or distribution of any portion is prohibited by law.
\endverbatim
*/

#if !defined (__DEC_DV_API_INCLUDED__)
#define __DEC_DV_API_INCLUDED__

#include "dv_info.h"
#include "mcfourcc.h"
#include "mcapiext.h"

#ifdef __cplusplus
extern "C" {
#endif


#define EXT_DV_ID_TRANSITION                0x20545845 /**< \brief Reserved  \hideinitializer */
#define EXT_DV_ID_ADJUSTCOLOR               0x30545845 /**< \brief Reserved  \hideinitializer */
#define EXT_DV_ID_ADJUST_EXT                0x31545845 /**< \brief Reserved  \hideinitializer */

 /**\brief Reserved */
struct adjust_color
{
  int32_t Y_offset;
  int32_t Y_factor;
  int32_t Cb_offset;
  int32_t Cb_factor;
  int32_t Cr_offset;
  int32_t Cr_factor;
};
/** \} */

//Decompressor option flags
#define UL_DCOMP_INV_FIELDS_ORDER           0x00000001 /**< \brief invert fields  \hideinitializer */
#define UL_DCOMP_PREVIEW                    0x00000002 /**< \brief fast decoding mode  \hideinitializer */
#define UL_DCOMP_DISABLE_16x9               0x00000004 /**< \brief disable letter format (only for CIF format)  \hideinitializer */
#define UL_DCOMP_SINGLE_THREAD              0x00010000 /**< \brief disable multiprocessing support in decoder  \hideinitializer */
//#define UL_DCOMP_EXTRA_QUALITY            0x00000008        // not yet supported

//Decompressor error codes
#define MC_DV_DEC_ERROR_NONE                1 /**< \brief Everything is OK \hideinitializer */
#define MC_DV_DEC_MB_FAILURE                2 /**< \brief Some MBs had the error flag set \hideinitializer */
#define MC_DV_DEC_ERROR                     0 /**< \brief All MBs had error flag set \hideinitializer */



/**
\brief Call this function to create instance of DV decoder.
\return  The video decoder instance.
 */
void* MC_EXPORT_API DVNewDec              (void);

/**
\brief Release instance of DV decoder.
\param[in] instance decoder instance
 */
void  MC_EXPORT_API DVDoneDec             (void* instance);

/**
 \brief decompress a DV buffer to uncompressed buffer
 \return  error code
 \param[in]     pbSrc            pointer to DV source buffer
 \param[in]     SrcBufLen        length of source buffer
 \param[out]      pbDst            pointer to destination buffer
 \param[in]     wRealLineSize    size of one line in byte (stride) in destination buffer, could be negative
 \param[in]     DstWidth         width of output image in pixel
 \param[in]     DstHeight        height of output image in pixel
 \param[in]      ulFlags          combination of the UL_DCOMP_xxx flags
 \param[in]     ColorSpaceFourcc destination buffer color spaceone of the FOURCC_xxx 
 \param[in]     reserved1        reserved, set to 0
 \param[in]    reserved2        reserved, set to NULL
 \note set output frame size (DstWidth, DstHeight) to 360x288 (PAL,NTSC) or 360x240 (NTSC only) to create CIF format
 */
uint32_t MC_EXPORT_API DVDecompressBuffer (void* instance,
                                  uint8_t* pbSrc,       uint32_t SrcBufLen, 
                                  uint8_t* pbDst,       int32_t wRealLineSize,
                                  uint32_t DstWidth,    uint32_t DstHeight,
                                  uint32_t ulFlags,     uint32_t ColorSpaceFourcc,
                                  uint32_t reserved1,   uint8_t* reserved2);


/**
 \warning deprecated, do not use!! will be removed - use DVGetInfoEx instead
 \brief get DV information from a given buffer
 \return  returns 1 when an error occured, otherwise 0
 \param[in]  pbSrc            pointer to DV source buffer
 \param[in]  srcBufLen        length of the source buffer valid values are: 120000, 144000, 120000*2, 144000*2, 120000*4, 144000*4
 \param[out]  pVideoInfo       pointer to a 'dv_video_info' structure which will receive the video info
 \param[out]  pAudioInfo       pointer to a 'dv_audio_info' structure which will receive the audio info
 \param[out]   pAudioAvail      pointer to a variable which will be set to 1 when audio was found
 */
uint32_t MC_EXPORT_API DVGetInfo          (uint8_t *pbSrc, int32_t srcBufLen,
                                  dv_video_info *pVideoInfo,
                                  dv_audio_info *pAudioInfo,
                                  int32_t *pAudioAvail);

/**
 \brief get DV information from a given buffer
 \return  returns 1 when an error occured, otherwise 0
 \param[in]  pbSrc            pointer to DV source buffer
 \param[in]  srcBufLen        length of the source buffer valid values are: 120000, 144000, 120000*2, 144000*2, 120000*4, 144000*4
 \param[out]  pVideoInfo       pointer to a 'dv_video_info' structure which will receive the video info
 \param[out]  pAudioInfo       pointer to a 'dv_audio_info' structure which will receive the audio info
 \param[out]   pAudioAvail      pointer to a variable which will be set to 1 when audio was found
 \note to get valid audio info filled in a complete dif frame must be provided as source buffer who's size must match the video formats dif frame_size. If you do not know the size in advance, e.g reading from raw dif file, first read and pass 120k which is minumum allowed dif frame size but enough to get the video format parameters. Then call the function again with a buffer of matching frame size to get the audio info filled also.
 */
uint32_t MC_EXPORT_API DVGetInfoEx        (uint8_t *pbSrc, int32_t srcBufLen,
                                  dv_video_info_ex *pVideoInfo,
                                  dv_audio_info_ex *pAudioInfo,
                                  int32_t *pAudioAvail);


/**
\brief Provides access to extended module API.
\return  pointer to requested function or NULL
\param[in] func identifier of module extended function
 */
APIEXTFUNC MC_EXPORT_API DVDecGetAPIExt        (uint32_t func);


#ifdef __cplusplus
}
#endif

#endif // #if !defined (__DEC_DV_API_INCLUDED__)


