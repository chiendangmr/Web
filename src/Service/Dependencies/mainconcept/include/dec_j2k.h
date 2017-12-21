/** 
\file   dec_j2k.h
\brief  Motion JPEG2000 Decoder API

\verbatim
File: dec_j2k.h
Desc: Motion JPEG2000 Decoder API

 Copyright (c) 2015 MainConcept GmbH or its affiliates.  All rights reserved.

 MainConcept and its logos are registered trademarks of MainConcept GmbH or its affiliates.  
 This software is protected by copyright law and international treaties.  Unauthorized 
 reproduction or distribution of any portion is prohibited by law.
\endverbatim
**/

#if !defined (__DEC_J2K_INCLUDED__)
#define __DEC_J2K_INCLUDED__

#include "mcfourcc.h"
#include "mctypes.h"
#include "bufstrm.h"
#include "mcapiext.h"
#include "mcdefs.h"

/** \name Decoder return codes */
#define MJ2KD_OK                        (uint32_t)  1   /**< \brief No errors \hideinitializer  */
#define MJ2KD_ERR_INVALID_COLOR_SPACE   (uint32_t) -1   /**< \brief Input colour space not supported \hideinitializer  */
#define MJ2KD_ERR_INPUT_BUFFER          (uint32_t) -2   /**< \brief Bad input buffer \hideinitializer  */
#define MJ2KD_ERR_OUTPUT_BUFFER         (uint32_t) -3   /**< \brief Bad output buffer \hideinitializer  */
#define MJ2KD_ERR_INPUT_FORMAT          (uint32_t) -4   /**< \brief Bad input stream \hideinitializer */
#define MJ2KD_ERR_NO_MEM_1              (uint32_t) -5   /**< \brief not enough memory \hideinitializer */
#define MJ2KD_ERR_NO_MEM_2              (uint32_t) -6   /**< \brief reserved \hideinitializer */
#define MJ2KD_ERR_NO_MEM_3              (uint32_t) -7   /**< \brief reserved \hideinitializer */
#define MJ2KD_ERR_NO_MEM_4              (uint32_t) -8   /**< \brief reserved \hideinitializer */
#define MJ2KD_INVALIDARG                (uint32_t) -9   /**< \brief bad input parameters \hideinitializer */
#define MJ2KD_NODATA                    (uint32_t) -10  /**< \brief no data to decoder \hideinitializer */
#define MJ2KD_BITSTREAM_ERROR           (uint32_t) -11  /**< \brief error during bitstream parsing \hideinitializer */
/** \} */

/** \name Acceleration defines */
#define ACCELERATION_QUALITY    0       /**< \brief Real decoding of all data \hideinitializer */
#define ACCELERATION_NORMAL     1       /**< \brief Skip decoding of last chrominance decomposition levels. Do interpolation instead \hideinitializer */
#define ACCELERATION_MEDIUM     2       /**< \brief As previous, plus skip last but one chrominance decomposition level. \hideinitializer */
#define ACCELERATION_STRONG     3       /**< \brief As previous, plus skip last luminance decomposition level.  \hideinitializer */
/** \} */


#define MAX_NUM_THREADS        32       /**< \brief Reserved \hideinitializer */

/** @cond */
/** \name AUX info options */
#define MJ2D_SET_AUTO_SKIP_MODE 1       /**< \brief Reserved \hideinitializer */
#define MJ2D_SET_FINISHED       2       /**< \brief Reserved \hideinitializer */
#define MJ2D_GET_COLOUR_INFO    3       /**< \brief Get colour information mj2_colour_par_set structure \hideinitializer */
/** \} */
/** @endcond */

/** \name Signal ranges */
#define CLIP_TYPE_PC            0       /**< \brief Full range \hideinitializer */
#define CLIP_TYPE_BROADCAST     1       /**< \brief TV/Broadcast signal range  \hideinitializer */
/** \} */

/** \name Type of decoder core */
#define TRANSFORM_PRECISION_FLOAT   0   /**< \brief Fare decoding using floating point precision. \hideinitializer */
#define TRANSFORM_PRECISION_INTEGER 1   /**< \brief Use integer approximated core for decoding.   \hideinitializer */
/** \} */


#define MAX_NUM_COMPS            4      /**< \brief  Maximum number of components supported by decoder \hideinitializer */
#define MAX_DECOMP_LAYERS       32

#define MJ2KD_INTERLACE         0x00000001L	/**< \brief Treat two consecutive fields as pair of interlaced frame.  \hideinitializer */

/** \brief Decoding options structure */
typedef struct
{
    uint32_t skip_passes;       /**< \brief Quality setting: Number of code passes to skip. Available values are from 0 to 24. */
    uint32_t acceleration;      /**< \brief Quality setting: Acceleration profile: @ref ACCELERATION_QUALITY, @ref ACCELERATION_NORMAL, @ref ACCELERATION_MEDIUM or @ref ACCELERATION_STRONG */

    uint32_t max_layers;        /**< \brief Scalable decoding parameters: Maximum number of layers to decode (0 - All). */
    uint32_t downsample_coef;   /**< \brief Scalable decoding parameters: Downsampling coefficient. Available values are 1, 2, 4, 8, 16. */

    int32_t transform_precision;/**< \brief Decoding core: @ref TRANSFORM_PRECISION_FLOAT or @ref TRANSFORM_PRECISION_INTEGER */
/** @cond */
    uint32_t reserved[1024 * 8];
/** @endcond */
} mj2_decode_params_t;

/** @cond */
/** \brief Decoder's initialization parameters structure */
typedef struct
{
    int32_t image_width;        /**< \brief Reserved */
    int32_t image_height;       /**< \brief Reserved */
    int32_t num_threads;        /**< \brief Number of threads */
    uint32_t low_delay_mode;    /**< \brief Low delay mode: 0 - per frame SMP, 1 - intra frame SMP */
    int32_t interlace;          /**< \brief Interpret two consecutive j2k images as field of one progressive frame. Only for streaming decoding */

    void* (*alloc)(size_t);
    void(*free)(void*);

    uint32_t reserved[1024 * 8];
} mj2_init_params_t;
/** @endcond */


/** \brief Structure to get resolution from elementary stream */
typedef struct
{
    uint8_t *input_buffer;
    uint32_t data_length;
    uint32_t width;
    uint32_t height;

    uint8_t reserved[1024];
} J2K_GetInfoStruct;


/** @cond */
/** \brief Colour information structure */
typedef struct
{
    uint32_t comp_num;                          /**< \brief Actual number of components */
    uint32_t colour_depth[MAX_NUM_COMPS];       /**< \brief Bitdepth of each component */
    uint32_t ver_subsampling[MAX_NUM_COMPS];    /**< \brief Vertical subsampling of each component */
    uint32_t hor_subsampling[MAX_NUM_COMPS];    /**< \brief Horizontal subsampling of each component */
    uint32_t is_signed[MAX_NUM_COMPS];          /**< \brief Signed/Unsigned pixel values of each component*/
    uint32_t mct_used;                          /**< \brief Usage of component transform prior coding*/
    uint32_t is_rct;                            /**< \brief Reversible/Irreversible transform used*/
    uint32_t reserved[1024];
} mj2_colour_par_set;
/** @endcond */


/** \brief Parameters of elementary stream */
typedef struct
{
    uint32_t caps;                          /**< \brief Denotes capabilities of the coded stream.                                                     */
    uint32_t width;                         /**< \brief Image size or reference grid size (width and height)                                          */
    uint32_t height;                        /**< \brief Image size or reference grid size (width and height)                                          */
    uint32_t origin_hor_offset;             /**< \brief Horizontal offset from the origin of the reference grid to the left side of the image area.   */
    uint32_t origin_ver_offset;             /**< \brief Vertical offset from the origin of the reference grid to the top side of the image area.      */
    uint32_t tile_width;                    /**< \brief Tile size (width and height)                                                                  */
    uint32_t tile_height;                   /**< \brief Tile size (width and height)                                                                  */
    uint32_t tile_hor_offset;               /**< \brief Horizontal offset from the origin of the reference grid to the left side of the first tile.   */
    uint32_t tile_ver_offset;               /**< \brief Vertical offset from the origin of the reference grid to the top side of the first tile.      */
    uint32_t components_num;                /**< \brief Number of components                                                                          */
    uint32_t comp_prec[MAX_NUM_COMPS];      /**< \brief Precision (depth) in bits and sign of the i-th component                                      */
    uint32_t comp_sgnd[MAX_NUM_COMPS];
    uint32_t sub_sample_x[MAX_NUM_COMPS];   /**< \brief Horizontal separation of a sample of i-th component with respect to the reference grid. There is one occurrence of this parameter for each component.*/
    uint32_t sub_sample_y[MAX_NUM_COMPS];   /**< \brief Vertical separation of a sample of i-th component with respect to the reference grid. */

    uint32_t lossless;                      /**< \brief Lossless stream or not (wavelet_transform) */
    uint32_t code_style;
    uint32_t progression_order;
    uint32_t layers_num;
    uint32_t num_decomposition_lvls;
    uint32_t code_block_size_width;
    uint32_t code_block_size_height;
    uint32_t code_block_style;
    uint32_t multi_comp_transform;
    uint32_t num_resolution_lvls;
    uint32_t resolution_lvl_width[MAX_DECOMP_LAYERS + 1];
    uint32_t resolution_lvl_height[MAX_DECOMP_LAYERS + 1];

    uint32_t quant_style;
    uint32_t num_stepsizes;
    uint32_t stepsizes[MAX_DECOMP_LAYERS + 1];
    uint32_t guard_bits;
    uint32_t qcc_present;
    uint32_t roi_present;
    uint32_t roi_scale;
/** @cond */
    uint32_t reserved[1024 * 8];
/** @endcond */
} mj2_decoder_config;

//----------------------------------------------------------------------------
// others
//----------------------------------------------------------------------------


#ifdef __cplusplus
extern "C" {
#endif

    /**
    \brief Call this function to get a bufstream interface for the J2K video decoder.
    \return  The video decoder instance.
    \param[in] get_rc  callbacks to external message handler and memory manager functions
    \param[in] reserved1 reserved parameter
    \param[in] reserved2 reserved parameter
    */
    bufstream_tt *  MC_EXPORT_API open_mj2in_Video_stream_ex(void *(MC_EXPORT_API *get_rc)(const int8_t* name), long reserved1, long reserved2);

    /**
    \brief Provides access to extended module API.
    \return  pointer to requested function or NULL
    \param[in] func identifier of module extended function
    */
    APIEXTFUNC      MC_EXPORT_API MJ2_DecoderGetAPIExt(uint32_t func);

#ifdef __cplusplus
}
#endif
//----------------------------------------------------------------------------
#endif // #if !defined (__DEC_J2K_INCLUDED__)
