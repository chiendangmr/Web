/**
\file   enc_j2k.h
\brief  Motion JPEG2000 Encoder API

\verbatim
File: enc_j2k.h
Desc: Motion JPEG2000 Encoder API

 Copyright (c) 2015 MainConcept GmbH or its affiliates.  All rights reserved.

 MainConcept and its logos are registered trademarks of MainConcept GmbH or its affiliates.  
 This software is protected by copyright law and international treaties.  Unauthorized 
 reproduction or distribution of any portion is prohibited by law.
\endverbatim
**/

#if !defined (__ENC_J2K_API_INCLUDED__)
#define __ENC_J2K_API_INCLUDED__

#include "mctypes.h"
#include "mcprofile.h"
#include "bufstrm.h"
#include "mcapiext.h"
#include "mcdefs.h"

#define ENABLE_COC_QCC_TLM
#define ENABLE_TILE_PARTS

/** \name optins flags */
#define ACCELERATION_LEVEL_NONE     0 /**< \brief no acceleration \hideinitializer  */
#define ACCELERATION_LEVEL_LIGHT    1 /**< \brief acceleration: skip HH, HL, LH of last reslevel for chroma \hideinitializer  */
#define ACCELERATION_LEVEL_NORMAL   2 /**< \brief acceleration: skip HH, HL, LH of last two reslevel for chroma \hideinitializer  */
#define ACCELERATION_LEVEL_STRONG   3 /**< \brief acceleration: skip HH, HL, LH of last two reslevel for chroma + skip HH, HL, LH of last level of luma \hideinitializer  */
#define ACCELERATION_LEVEL_DEFAULT ACCELERATION_LEVEL_NORMAL  /**< \brief default acceleration level \hideinitializer  */

#define MAX_NUM_COMPS       4 /**< \brief Maximum supported components \hideinitializer  */
#define MAX_NUM_SUBBANDS    3 /**< \brief Maximum supported subbands \hideinitializer  */
#define MAX_NUM_DWT_LEVELS  6 /**< \brief Maximum supported decomposition levels  \hideinitializer  */
#define MAX_NUM_LAYERS      6 /**< \brief Maximum supported quality layers  \hideinitializer  */
#define MIN_BIT_DEPTH       4 /**< \brief Minimum supported bit-depth  \hideinitializer  */
#define MAX_BIT_DEPTH       16 /**< \brief Maximum supported bit-depth  \hideinitializer  */


#define MCT_NONE    0 /**< \brief no MCT \hideinitializer  */
#define MCT_RCT     1 /**< \brief Reveresible MCT \hideinitializer  */
#define MCT_ICT     2 /**< \brief Irreversible MCT \hideinitializer  */
/** \} */

/** \name encoder return codes */
#define MJ2KE_OK                    (uint32_t) 0x00000001 /**< \brief No error \hideinitializer  */
#define MJ2KE_ERROR                 (uint32_t) 0xFFFFFFFF /**< \brief Unknown error \hideinitializer  */
#define MJ2KE_ERR_INPUT_COLOR_SPACE (uint32_t) 0xFFFFFFFE /**< \brief Unknown input color space \hideinitializer  */
#define MJ2KE_ERR_NumRates          (uint32_t) 0xFFFFFFF8 /**< \brief Unsupported number of layers \hideinitializer  */
#define MJ2KE_ERR_dRates            (uint32_t) 0xFFFFFFF7 /**< \brief Unsupported rate \hideinitializer  */
#define MJ2KE_ERR_iDecomplevels     (uint32_t) 0xFFFFFFF6 /**< \brief Unsupported number of decomposition layers \hideinitializer  */
#define MJ2KE_ERR_ixcb              (uint32_t) 0xFFFFFFF4 /**< \brief Unsupported code-block width \hideinitializer  */
#define MJ2KE_ERR_iycb              (uint32_t) 0xFFFFFFF3 /**< \brief Unsupported code-block height \hideinitializer  */
#define MJ2KE_ERR_BitDepth          (uint32_t) 0xFFFFFFE5 /**< \brief Unsupported maximal bit-depth value \hideinitializer  */
#define MJ2KE_ERR_CPRLSubsample     (uint32_t) 0xFFFFFFE4 /**< \brief Subsampling factor too large for selected number of DWT levels \hideinitializer  */
#define MJ2KE_ERR_DCI_9_7_Error     (uint32_t) 0xFFFFFFE3 /**< \brief 9/7 transform should be used for D-Cinema \hideinitializer  */
#define MJ2KE_ERR_DCI_DWT_Error     (uint32_t) 0xFFFFFFE2 /**< \brief There should be no more then 5 dwt levels for D-Cinema 2k, between 1 and 6 dwt levels for D-Cinema 4k \hideinitializer  */
#define MJ2KE_ERR_DCI_CB_Size_Error (uint32_t) 0xFFFFFFE1 /**< \brief Code block size should be 2^5 for D-Cinema \hideinitializer  */
#define MJ2KE_ERR_DCI_Prc_Siz_Error (uint32_t) 0xFFFFFFE0 /**< \brief Precincts should be 2^8 for D-Cinema \hideinitializer  */
#define MJ2KE_ERR_DCI_Prgrs_Error   (uint32_t) 0xFFFFFFDF /**< \brief Progression should be CPRL for D-Cinema \hideinitializer  */
#define MJ2KE_ERR_DCI_NumLyrs_Error (uint32_t) 0xFFFFFFDE /**< \brief Fps value should be 24 or 48 for D-Cinema 2k, 24 for D-Cinema 4k \hideinitializer  */
#define MJ2KE_ERR_DCI_Bitrate_Error (uint32_t) 0xFFFFFFDD /**< \brief If bit rate is given in absolute values, it should be: < 1.302.083 for 24 fps <   651.041 for 48 fps \hideinitializer  */
#define MJ2KE_ERR_DCI_Fps_Error     (uint32_t) 0xFFFFFFDC /**< \brief Fps value should be 24 or 48 for D-Cinema 2k, 24 for D-Cinema 4k \hideinitializer  */
#define MJ2KE_ERR_PrecSize          (uint32_t) 0xFFFFFFDB /**< \brief Precinct size should be between 2^5 and 2^15 \hideinitializer  */
#define MJ2KE_ERR_DCI_Subsmpl_Error (uint32_t) 0xFFFFFFDA /**< \brief Subsampling factor should be 0 for D-Cinema 2k, 1 for D-Cinema 4k \hideinitializer  */
#define MJ2KE_ERR_DWT_Type          (uint32_t) 0xFFFFFFD9 /**< \brief Only one transformation type should be selected \hideinitializer  */
#define MJ2KE_ERR_ImgSize           (uint32_t) 0xFFFFFFD8 /**< \brief Image size out of limits \hideinitializer  */
#define MJ2KE_ERR_UNEXPECTED        (uint32_t) 0xFFFFFFD7 /**< \brief removed error message \hideinitializer  */
#define MJ2KE_ERR_ProgOrder         (uint32_t) 0xFFFFFFD6 /**< \brief Unknown progression order \hideinitializer  */
#define MJ2KE_ERR_OutOfMemory       (uint32_t) 0xFFFFFFD5 /**< \brief Not enough memory \hideinitializer  */
#define MJ2KE_ERR_OutOfMemory_1     (uint32_t) 0xFFFFFFD4 /**< \brief Not enough memory \hideinitializer  */
#define MJ2KE_ERR_OutOfMemory_2     (uint32_t) 0xFFFFFFD3 /**< \brief Not enough memory \hideinitializer  */
#define MJ2KE_ERR_OutOfMemory_3     (uint32_t) 0xFFFFFFD2 /**< \brief Not enough memory \hideinitializer  */
/** \} */

//reserved values
#define MJ2KE_ERR_Internal1         (uint32_t) 0xFFFFFFCF
#define MJ2KE_ERR_Internal2         (uint32_t) 0xFFFFFFCE
#define MJ2KE_ERR_Internal3         (uint32_t) 0xFFFFFFCD
#define MJ2KE_ERR_Internal4         (uint32_t) 0xFFFFFFCC
#define MJ2KE_ERR_Internal5         (uint32_t) 0xFFFFFFCB
#define MJ2KE_ERR_Internal6         (uint32_t) 0xFFFFFFCA
#define MJ2KE_ERR_Internal7         (uint32_t) 0xFFFFFFC9
#define MJ2KE_ERR_Internal8         (uint32_t) 0xFFFFFFC8
#define MJ2KE_ERR_Internal9         (uint32_t) 0xFFFFFFC7
#define MJ2KE_ERR_MT_INIT           (uint32_t) 0xFFFFFFC6
#define MJ2KE_ERR_MT_NO_E           (uint32_t) 0xFFFFFFC5
#define MJ2KE_ERR_MT_NO_O           (uint32_t) 0xFFFFFFC4
#define MJ2KE_ERR_Internal10        (uint32_t) 0xFFFFFFC3
#define MJ2KE_ERR_Internal11        (uint32_t) 0xFFFFFFC2

#define MJ2KE_MIN_ERRNO             (uint32_t) 0xFFFFFF01

#define RESERVED_SIZE               995


/** \brief Compression parameters */
typedef struct
{
  int32_t  CBxSize; /**< \brief Width of code block [5|6], 5 => 32, 6 => 64, in pixels*/
  int32_t  CBySize; /**< \brief Height of code block [5|6] , 5 => 32, 6 => 64, in pixels*/
  int32_t  PrecSizeX; /**< \brief Precinct width, [7|8|15], 7 => 128, 8 => 256, 15 => maximal, except for resolution 0 where 7 => 64, 8 => 128, in pixels*/
  int32_t  PrecSizeY; /**< \brief Precinct height, [7|8|15], 7 => 128, 8 => 256, 15 => maximal, except for resolution 0 where 7 => 64, 8 => 128, in pixels*/
  int32_t  NumLayers; /**< \brief Number of quality layersp*/
  int32_t  MaxBitDepth; /**< \brief Maximal number of bit planes to encode, value between 4 and 16*/
  int32_t  NumDWTLevels; /**< \brief Number of levels of discrete wavelet transformation*/
  /** \brief  Subsampling factor when CPRL progression order is used. This parameter can be used for producing stream that can be decoded in both original (1/1) and lower (1/2 | 1/4 | 1/8) resolutions with no need to subsample at decoder side.
	\arg 0 - encoded stream is not optimized for subsampling
	\arg 1 - encoded stream is optimized for 1/2 subsampling
	\arg 2 - encoded stream is optimized for 1/4 subsampling
	\arg 3 - encoded stream is optimized for 1/8 subsampling
  */
  int32_t  CPRL_SubsampleFactor;
  uint32_t ulFlags; /**< \brief Low-level flags*/
  uint32_t iSrcWidth; /**< \brief source frame width*/
  uint32_t iSrcHeight; /**< \brief source frame height*/
  uint32_t num_threads; /**< \brief Encoder is multithreaded and will start one working thread for each available CPU core or Hyperthreading. This should give optimal CPU usage for most use cases. Using this parameter one can explicitly instruct encoder how many encoding threads to create.*/
  uint32_t ColorSpaceFourcc; /**< \brief source frame colorspace*/
  /**\brief Encoder acceleration level, one of following:
	\arg ACCELERATION_NONE - no acceleration
	\arg ACCELERATION_LIGHT - light acceleration
	\arg ACCELERATION_NORMAL  - default acceleration
	\arg ACCELERATION_STRONG - strong acceleration
  Higher acceleration level activates less precise bit-rate estimation, thus may give lower quality (depending on target bit rate). Default acceleration level is set to ACCELERATION_NORMAL, as it gives optimal quality/speed results. If lossless encoding is required, acceleration must be set to ACCELERATION_NONE.*/
  uint32_t AccelerationLevel;
  double   dLayerRates[MAX_NUM_LAYERS+1]; /**< \brief Bit-rate distribution through layers, given as percent value of raw image size*/
  int32_t  framerate_code; /**< \brief frame rate code for D-Cinema. one of FRAMERATExx (mcdefs.h).
                                \arg allowed frame rates D-Cinema 2K: 24, 25, 30, 48, 50, 60fps
                                \arg allowed frame rates D-Cinema 4K: 24, 25, 30 fps */
  //reserved for future settings, sizeof(MJ2_CompParams_t) must be 4096 bytes
  int32_t  reserved[RESERVED_SIZE]; /**< \brief reserved for future use*/
}MJ2_CompParams_t;


/** \name Compression flags */
#define fMJ2E_JP2_OUTPUT        (uint32_t)0x00000001 /**< \brief encoder outputs jp2 stream \hideinitializer  */
#define fMJ2E_J2C_OUTPUT        (uint32_t)0x00000002 /**< \brief encoder outputs jpc stream \hideinitializer  */
#define fMJ2E_PROGRESSION_LRCP  (uint32_t)0x00000004 /**< \brief Layer-resolution-component-position progression \hideinitializer  */
#define fMJ2E_PROGRESSION_CPRL  (uint32_t)0x00000008 /**< \brief Component-position-resolution-layer progression \hideinitializer  */
#define fMJ2E_MODE_INT_5_3      (uint32_t)0x00000010 /**< \brief use 5-3 DWT filter, RCT, integer mode \hideinitializer  */
#define fMJ2E_MODE_REAL_9_7     (uint32_t)0x00000020 /**< \brief use 9-7 DWT filter, ICT, fixed-point mode \hideinitializer  */
#define fMJ2E_BitRateAbsolute   (uint32_t)0x00000040 /**< \brief True  - Parameter dLayerRates is given in bytes, False - Parameter dLayerRates is given as relative percent value of input \hideinitializer  */
#define fMJ2E_DCI_2K			(uint32_t)0x00000080 /**< \brief input parameters restricted to D-cinema 2K distribution \hideinitializer  */
#define fMJ2E_DCI_4K			(uint32_t)0x00000100 /**< \brief input parameters restricted to D-cinema 4K distribution \hideinitializer  */
#define fMJ2E_DCI_24fps			(uint32_t)0x00000200 /**< \brief input parameters restricted to D-cinema 24 fps - outdated, use MJ2_CompParams_t framerate_code  \hideinitializer  */
#define fMJ2E_DCI_48fps			(uint32_t)0x00000400 /**< \brief input parameters restricted to D-cinema 2K@48 fps - outdated, use MJ2_CompParams_t framerate_code \hideinitializer  */
#define fMJ2E_Lossless			(uint32_t)0x00001000 /**< \brief enable lossless compression in 5/3 mode \hideinitializer  */
#define fMJ2E_CBR				(uint32_t)0x00002000 /**< \brief constant bit-rate \hideinitializer  */
#define fMJ2E_DCI_weak_compl	(uint32_t)0x00004000 /**< \brief don't force full DCI compliance, some decoders can't decode it\hideinitializer  */
#define fMJ2E_DCI_XYZ2RGB		(uint32_t)0x00008000 /**< \brief transform XYZ->RGB prior to ICT (D-cinema mode only) \hideinitializer  */
#define fMJ2E_HALF_THREADS_NUMBER (uint32_t)0x00010000 /**< \brief transform XYZ->RGB prior to ICT (D-cinema mode only) \hideinitializer  */
#define fMJ2E_SubsampleYUV422   (uint32_t)0x00001000
#define fMJ2E_SubsampleYUV420   (uint32_t)0x00002000
/** \} */

// For all extended option define flags OPT_EXT_PARAM_... please see "mcdefs.h" now.

#ifdef __cplusplus
extern "C" {
#endif

/**
\brief Create a new encoder
\return  The video encoder instance on success,  on fail - NULL
\param[in] Mj2_CompParams initialization parameters
\param[in] get_rc  Callback for functions that may be provided by external app, optional
 */
void* MC_EXPORT_API MJ2_EncoderNew (void             *(MC_EXPORT_API * get_rc)(const char* name),
                                    MJ2_CompParams_t *Mj2_CompParams);


/**
\brief Initialize encoder
\return  MJ2KE_OK
\param[in] instance encoder instance
\param[in] buffer Output bufstream for encoder, depending of the application. It can be for example file bufstream if output is to be written to a file, or a muxer input bufstream if output is to be muxed.
\param[in] option_flags reserved
\param[in] opt_ptr reserved
 */
int32_t MC_EXPORT_API MJ2_EncoderInit(void              *instance,
                                      struct bufstream  *buffer,
                                      uint32_t           options_flags,
                                      void             **opt_ptr);

/**
\brief Encode single frame (returns: no. of output bytes)
\return On successful completion, encoder returns MJ2KE_OK, otherwise it returns one of MJ2KE_ERR_... codes.
\param[in] instance	Encoder instance
\param[in] pbSrc	Pointer to the source buffer
\param[in] wRealLineSize	Size of one line in source buffer (stride), in bytes. If stride is negative, pbSrc 	should point to the first byte of the last line of the source buffer.
\param[in] SrcWidth	width of input image in pixel
\param[in] SrcHeight	height of input image in pixel
\param[in] ColorSpaceFourcc	source  buffer color space
\param[in] ext_info	reserved parameter
*/
uint32_t MC_EXPORT_API MJ2_CompressBuffer(void          *instance,
                                          unsigned char *pb_src,
                                          int32_t        stride,
                                          uint32_t       width,
                                          uint32_t       height,
                                          uint32_t       fourcc,
                                          uint32_t       opt_flags,
                                          void         **ext_info);

/**
\brief De-initialize instance of j2k encoder
\return  MJ2KE_OK
\param[in] instance 		encoder instance
\param[in] abort should encoding be aborted immediately
 \arg true - abort encoding immediately, all encoding threads are forced to exit, even  if encoding is still in progress. Output stream may not be valid.
 \arg false - finish encoding normally, allow still working encoding threads to finish
 */
int32_t MC_EXPORT_API MJ2_EncoderDone(void *instance, int32_t abort);

/**
\brief Release instance of j2k encoder.
\param[in] instance encoder instance
 */
void  MC_EXPORT_API MJ2_EncoderRelease(void *instance);


/**
\brief Fill Mj2_CompParams with default parameter values
\return Function always returns NULL.
\param[out] set		return value
\param[in] profileID	one of the available profiles:
				\arg MCPROFILE_DEFAULT
				\arg MCPROFILE_JP2K_LOSSY
				\arg MCPROFILE_JP2K_LOSSLESS
				\arg MCPROFILE_JP2K_DCI_2K
				\arg MCPROFILE_JP2K_DCI_4K
				\arg MCPROFILE_MJ2
\param[in] videomode reserved
*/
char* MC_EXPORT_API MJ2_OutVideoDefaults(MJ2_CompParams_t *set, int32_t profileID, int32_t videomode);

/************************************************************\
    Encoding is done in 5 steps

    1. MJ2_EncoderNew
    2. MJ2_EncoderInit
    3. MJ2_CompressBuffer
    4. MJ2_EncoderDone
    5. MJ2_EncoderRelease

    1 - creates new encoder, returns its instance
    2 - initializes encoder for a group of frames
    3 - encodes single frame
    4 - releases encoder after encoding a group of frames
    5 - destroys encoder

    Encoding may go like this:
    1-2-3-3-3-3-4-2-3-4-2-3-4-2-3-3-3-3-4-5
\************************************************************/

/**
\brief Provides access to extended module API.
\return  pointer to requested function or NULL
\param[in] func identifier of module extended function
 */
APIEXTFUNC  MC_EXPORT_API MJ2_EncoderGetAPIExt(uint32_t func);


#ifdef __cplusplus
}
#endif


#endif // #if !defined (__ENC_J2K_API_INCLUDED__)
