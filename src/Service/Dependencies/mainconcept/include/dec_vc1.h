/** 
\file   dec_vc1.h
\brief  VC-1 Decoder API

\verbatim
File: dec_vc1.h
Desc: VC-1 Decoder API

 Copyright (c) 2015 MainConcept GmbH or its affiliates.  All rights reserved.

 MainConcept and its logos are registered trademarks of MainConcept GmbH or its affiliates.  
 This software is protected by copyright law and international treaties.  Unauthorized 
 reproduction or distribution of any portion is prohibited by law.
\endverbatim
**/


#if !defined (__DEC_VC1_API_INCLUDED__)
#define __DEC_VC1_API_INCLUDED__

#include "bufstrm.h"
#include "mcdefs.h"
#include "mcdefs.h"
#include "mcapiext.h"


#define SET_ERROR_RESILIENCE_MODE          0x00010081 /**< \brief Set error resilince mode \hideinitializer */

/** \brief Loop filter modes enumeration */
enum error_resilience_mode {
	VC1VD_ER_PROCESS_ANYWAY = 0,	/**< In case of bit stream errors, skips all slices till next intra slice. */
	VC1VD_ER_WAIT_I_SLICE,			/**< Ignores bit stream errors */
};
/** \} */

#define VC1_DECODER_AUTH                   0x00011082 /** \brief \hideinitializer */

/** \name auxinfo options */
#define SET_SEQ_PARAMS						0x00011085	/**< \brief Set entry point header \hideinitializer */
#define SET_DECODER_PARAMS					0x00011086	/**< \brief Reserved \hideinitializer */
#define SET_IMG_SIZE						0x00011087	/**< \brief Set image sizes \hideinitializer */
#define SET_ACC_MODE						0x00011088	/**< \brief Reserved \hideinitializer */
#define	CHROMA_UPSAMPLE						0x00011000	/**< \brief Reserved \hideinitializer */
#define	DOUBLE_RATE							0x00011001	/**< \brief Reserved \hideinitializer */
#define	FIELDS_REORDERING					0x00011002	/**< \brief Reserved \hideinitializer */
#define	FIELDS_REORDERING_CONDITION			0x00011003	/**< \brief Reserved \hideinitializer */
#define	ERROR_RESILIENCE					0x00011004	/**< \brief Set error resilince mode \hideinitializer */
#define	DISPLAY_OSD							0x00011005	/**< \brief Display frame statistical information on output images \hideinitializer */
/** \} */

/** \brief VC-1 profiles. See SMPTE 421M-2006 for reference */
typedef enum
{
	vc1_PROFILE_Simple = 0,  /**< Simple profile */
	vc1_PROFILE_Main,        /**< Main profile */
	vc1_PROFILE_Reserved,    /**< Reserved */
	vc1_PROFILE_Advanced     /**< Advanced profile */
} vc1_profile;
/** \} */


/** \brief Profile level enumeration. See SMPTE 421M-2006 for reference */
typedef enum
{
	vc1_LEVEL_Low    = 0,    /**< Simple/Main profile low level */
	vc1_LEVEL_Medium = 1,    /**< Simple/Main profile medium level */
	vc1_LEVEL_High   = 2,    /**< Simple/Main profile high level */

	vc1_LEVEL_L0     = 0,    /**< Advanced profile level 0 */
	vc1_LEVEL_L1     = 1,    /**< Advanced profile level 1 */
	vc1_LEVEL_L2     = 2,    /**< Advanced profile level 2 */
	vc1_LEVEL_L3     = 3,    /**< Advanced profile level 3 */
	vc1_LEVEL_L4     = 4,    /**< Advanced profile level 4 */

	/* 5 to 7 reserved */

	vc1_LEVEL_Unknown = 255  /**< Unknown profile */
} vc1_level;
/** \} */

/** \brief Chroma formats */
typedef enum
{
	vc1_CHROMA_FORMAT_Reserved = 0,	/**< Reserved */
	vc1_CHROMA_FORMAT_420,			/**< 4:2:0 YCbCr colourspace */
	vc1_CHROMA_FORMAT_Reserved2,	/**< Reserved */
	vc1_CHROMA_FORMAT_Reserved3		/**< Reserved */
} vc1_chroma_format;
/** \} */

/** \brief Colour primaries enumeration. See SMPTE 421M-2006 for reference. */
typedef enum
{
	vc1_COLOR_PRIMARIES_Forbidden = 0,
	vc1_COLOR_PRIMARIES_ITU_R_BT_709,
	vc1_COLOR_PRIMARIES_Unspecified,		
	vc1_COLOR_PRIMARIES_Reserved1,			
	vc1_COLOR_PRIMARIES_Reserved2,			
	vc1_COLOR_PRIMARIES_EBU_Tech_3213,		
	vc1_COLOR_PRIMARIES_SMPTE_C,			
	vc1_COLOR_PRIMARIES_Reserved3
	/* values 7 - 255 reserved */
} vc1_color_primaries;
/** \} */


/** \brief Transfer Characteristics types for source picture. See SMPTE 421M-2006 for reference */
typedef enum
{
	vc1_TRANSFER_CHARACTERISTICS_Forbidden = 0,		
	vc1_TRANSFER_CHARACTERISTICS_ITU_R_BT_709,		
	vc1_TRANSFER_CHARACTERISTICS_Unspecified,	
	vc1_TRANSFER_CHARACTERISTICS_Reserved1,			
	vc1_TRANSFER_CHARACTERISTICS_Reserved2,			
	vc1_TRANSFER_CHARACTERISTICS_Reserved3,			
	vc1_TRANSFER_CHARACTERISTICS_Reserved4,			
	vc1_TRANSFER_CHARACTERISTICS_SMPTE_240M,		
	vc1_TRANSFER_CHARACTERISTICS_Reserved5	
	/* values 8 - 255 reserved */
} vc1_transfer_characteristics;
/** \} */

/** \brief The matrix coefficients used to derive Y, Cb, Cr signals from the color primaries. See SMPTE 421M-2006 for reference */
typedef enum
{
	vc1_MATRIX_COEFFICIENTS_Forbidden = 0,
	vc1_MATRIX_COEFFICIENTS_ITU_R_BT_709,
	vc1_MATRIX_COEFFICIENTS_Unspecified,
	vc1_MATRIX_COEFFICIENTS_Reserved1,		
	vc1_MATRIX_COEFFICIENTS_Reserved2,		
	vc1_MATRIX_COEFFICIENTS_Reserved3,		
	vc1_MATRIX_COEFFICIENTS_SMPTE_170M,		
	vc1_MATRIX_COEFFICIENTS_SMPTE_240M,	
	vc1_MATRIX_COEFFICIENTS_Reserved4		
	/* values 8 - 255 reserved */
} vc1_matrix_coefficients;
/** \} */

/** \brief Quantizer mode enumeration. See SMPTE 421M-2006 for reference */
typedef enum
{
	vc1_QUANTIZER_Implicit   = 0,    /**< Quantizer implied by quantizer step size */
	vc1_QUANTIZER_Explicit   = 1,    /**< Quantizer explicitly signaled */
	vc1_QUANTIZER_NonUniform = 2,    /**< Non-uniform quantizer */
	vc1_QUANTIZER_Uniform    = 3     /**< Uniform quantizer */
} vc1_quantizer;
/** \} */


/** \brief Sequence and Layer parameters. . See SMPTE 421M-2006 for reference */
typedef struct
{
	vc1_profile			    		profile;                    /**< \brief See standard */
	uint16_t                		max_coded_width;              /**< \brief Maximum coded width  */
	uint16_t                		max_coded_height;             /**< \brief Maximum coded height */
	uint16_t                		coded_width;                 /**< \brief Coded width or 0 if not specified */
	uint16_t                		coded_height;                /**< \brief Coded height or 0 if not specified */
	uint16_t                		display_width;               /**< \brief Display width or 0 if not specified */
	uint16_t                		display_height;              /**< \brief Display height or 0 if not specified */
	uint16_t                		aspect_width;                /**< \brief Aspect width or 0 if not specified */
	uint16_t                		aspect_height;               /**< \brief Aspect height or 0 if not specified */
	vc1_level						level;                     /**< \brief See standard */
	uint8_t                 		interlace;                  /**< \brief See standard */
	uint32_t                		frame_rate_numerator;         /**< \brief 0 if not specified */
	uint16_t                		frame_rate_denominator;       /**< \brief 1000, 1001, or 32 (0 if not specified) */
	uint8_t                 		color_format_indicator_flag;   /**< \brief See standard */
	vc1_chroma_format				chroma_format;              /**< \brief See standard */
	vc1_color_primaries				color_primaries;            /**< \brief See standard */
	vc1_transfer_characteristics	transfer_characteristics;                 /**< \brief See standard */
	vc1_matrix_coefficients			matrix_coefficients;        /**< \brief See standard */
	uint8_t                 		loop_filter;                 /**< \brief See standard */
	uint8_t                 		multi_res_coding;             /**< \brief See standard */
	uint8_t                 		fast_uvmc;                   /**< \brief See standard */
	uint8_t                 		extended_mv;                 /**< \brief See standard */
	uint8_t                 		extended_dmv;                /**< \brief See standard */
	uint8_t                 		d_quant;                     /**< \brief See standard */
	uint8_t                 		vs_transform;                /**< \brief See standard */
	uint8_t                 		overlapped_transform_flag;    /**< \brief See standard */
	uint8_t                 		syncmarker_flag;             /**< \brief See standard */
	uint8_t                 		range_red_flag;               /**< \brief See standard */
	uint8_t                 		max_b_frames;                 /**< \brief See standard */
	vc1_quantizer         			quantizer;                 /**< \brief See standard */
	uint8_t                 		post_processing_flag;         /**< \brief See standard */
	uint8_t                 		frame_counter_flag;           /**< \brief See standard */
	uint8_t                 		pulldown_flag;               /**< \brief See standard */
	uint8_t                 		psf;                        /**< \brief See standard */
	uint8_t                 		q_frame_rate_for_post_proc;      /**< \brief See standard */
	uint8_t                 		q_bit_rate_for_post_proc;        /**< \brief See standard */
	uint8_t                 		pan_scan_flag;                /**< \brief See standard */
	uint8_t                 		reserved_rtm_flag;            /**< \brief See standard */
	uint8_t                 		frame_interpolation_flag;     /**< \brief See standard */
	uint8_t                 		range_y_scale;                /**< \brief Scale value times 8 */
	uint8_t                 		range_uv_scale;               /**< \brief Scale value times 8 */
	uint8_t                 		num_pan_scan_win;              /**< \brief Number of pan scan windows */
	uint8_t                 		broken_link;                 /**< \brief Broken link flag */
	uint8_t                 		closed_entry;                /**< \brief Closed Entry flag */
	uint8_t                 		ref_dist_flag;                /**< \brief RefDist flag */
	uint8_t                 		frame_user_data_flag;          /**< \brief Frame user data present flag */
	uint8_t                 		end_of_sequence;              /**< \brief End of sequence marker present */
	uint8_t                 		hrd_num_leaky_buckets;
} vc1_sequence_layer;
/** \} */


/** \brief Motion vector range enumeration. */
typedef enum
{
	vc1_MVRange64_32    = 0,	/**< \brief x=-64 to 63.f by y=-32 to 31.f */
	vc1_MVRange128_64   = 1,	/**< \brief x=-128 to 127.f by y=-64 to 63.f */
	vc1_MVRange512_128  = 2,	/**< \brief x=-512 to 511.f by y=-128 to 127.f */
	vc1_MVRange1024_256 = 3		/**< \brief x=-1024 to 1023.f by y=-256 to 255.f */
} vc1_mv_range;
/** \} */

/** \brief Motion vector modes enumeration. */
typedef enum
{
	vc1_MV_MODE_1MVHalfPelBilinear = 0,   /**< \brief 1MV     0.50 pel bilinear */
	vc1_MV_MODE_1MVHalfPel         = 1,   /**< \brief 1MV     0.50 pel bicubic  */
	vc1_MV_MODE_1MV                = 2,   /**< \brief 1MV     0.25 pel bicubic  */
	vc1_MV_MODE_MixedMV            = 3,   /**< \brief MixedMV 0.25 pel bicubic  */
	vc1_MV_MODE_IntensityCompensation     /**< \brief Variable length code escape flag */
} vc1_mv_mode;
/** \} */

/** \brief Motion vector scaling information. */
typedef struct {
	uint16_t			scale;				/**< \brief Down scale factor * 256  */
	uint16_t			scale1;				/**< \brief Up scale factor * 256 if in Zone1  */
	uint16_t			scale2;				/**< \brief Up scale factor * 256 if not in Zone1  */
	uint16_t			scale_zone1_x;		/**< \brief Zone1 X size  */
	uint16_t			scale_zone1_y;		/**< \brief Zone1 Y size  */
	uint16_t			zone1_offset_x;		/**< \brief Zone1 X offset  */
	uint16_t			zone1_offset_y;		/**< \brief Zone1 Y offset  */
	uint8_t				scale_up_opp;		/**< \brief 0=ScaleDownForOpposite 1=ScaleUpForOpposite  */
	uint8_t				bottom_field;		/**< \brief 0=Top Field 1=Bottom Field  */
	vc1_mv_range		mv_range;			/**< \brief Permitted range  */
	vc1_mv_mode			mv_mode;			/**< \brief Motion vector mode */
} vc1_scale_mv;
/** \} */

/** \brief field/frame picture type enumeration. */
typedef enum
{
	vc1_PROGRESSIVE_FRAME = 0,   /**< \brief Picture is a progressive frame */
	vc1_INTERLACED_FRAME  = 1,   /**< \brief Picture is an interlaced frame */
	vc1_INTERLACED_FIELD  = 2,   /**< \brief Picture is two interlaced fields */
	vc1_PICTURE_FORMAT_NONE      /**< \brief Picture format not yet set */
} vc1_picture_format;
/** \} */

/** \brief Picture resolution scaling enumeration. */
typedef enum
{
	vc1_PICTURE_RES_1x1=0,    /**< \brief No scaling */
	vc1_PICTURE_RES_2x1,      /**< \brief Scale horizontally */
	vc1_PICTURE_RES_1x2,      /**< \brief Scale vertically */
	vc1_PICTURE_RES_2x2       /**< \brief Scale horizontally and vertically */
} vc1_picture_res;
/** \} */

/** \brief Picture type enumeration. */
typedef enum
{
	vc1_PICTURE_TypeI        = 0,    /**< \brief I Picture / Field - can be used as a reference */
	vc1_PICTURE_TypeP        = 1,    /**< \brief P Picture / Field - can be used as a reference */
	vc1_PICTURE_TypeB        = 2,    /**< \brief B Picture / Field */
	vc1_PICTURE_TypeBI       = 3,    /**< \brief BI Picture / Field */
	vc1_PICTURE_TypeSkipped  = 4     /**< \brief Skipped Frame */
} vc1_picture_type;
/** \} */

/** \brief Picture state information structure. Reserved. \{ */
typedef struct
{
	vc1_scale_mv        p_scale_mv[2];			/**< \brief MV scaling (forward, backward) */

	uint32_t            coded_width;			/**< \brief Width in pixels of coded picture  */
	uint32_t            coded_height;			/**< \brief Height in pixels of coded picture  */
	uint32_t            max_coded_width;  		/**< \brief Max Width in pixels of coded picture  */
	uint32_t            max_coded_height; 		/**< \brief Max Height in pixels of coded picture  */
	uint32_t            size_mb;         		/**< \brief Circular buffer size in macroblocks  */
	uint16_t            width_mb;        		/**< \brief Width in macroblocks of coded picture  */
	uint16_t            height_mb;       		/**< \brief Height in macroblocks of coded picture  */
	uint8_t				ref_dist;

	vc1_picture_type	picture_type;			/**< \brief Picture type: I, P, B or BI  */
	vc1_picture_format	picture_format;			/**< \brief Picture format: Progressive, Interlace Field/frame  */
	vc1_profile			profile;       			/**< \brief Profile Simple/Main/Advanced  */
	vc1_mv_mode			mv_mode;        		/**< \brief Motion vector mode for this picture  */
	vc1_mv_range		mv_range;       		/**< \brief Motion vector range setting for this picture */
	uint8_t             bottom_field;    		/**< \brief 0=Top Field, 1=Bottom Field  */
	uint8_t             second_field;    		/**< \brief 0=First Field, 1=Second Field  */

	uint8_t             b_fraction;      		/**< \brief BFRACTION syntax element */
	uint8_t             num_ref;         		/**< \brief Number of reference fields-1  */
	uint8_t             ref_field;       		/**< \brief Reference field when NumRef==0  */
	uint8_t             intra_bias;      		/**< \brief Bias to add to intra blocks post transform */
	uint8_t             range_y_scale;    		/**< \brief Y scaling factor times 8  */
	uint8_t             range_uv_scale;   		/**< \brief UV scaling factor times 8  */
	uint8_t             fast_uvmc;				/**< \brief Fast U,V motion compensation flag  */
	vc1_picture_res		picture_res;			/**< \brief Picture resolution scale mode */
} vc1_picture_state;
/** \} */


/** \brief Reserved. \{ */
typedef struct _vc1_stream_tag {
	int64_t reference_time;
	int64_t media_time;
	uint32_t flags;
} vc1_stream_tag;
/** \} */

/** \brief Reserved. \{ */
typedef struct
{
	vc1_picture_type		field[2];			/**< \brief  Field information, First then Second */
	uint8_t                 TFF;				/**< \brief  Top Field First flag */
	uint8_t                 RFF;				/**< \brief  Repeat First Field flag */
	uint8_t                 RPTFRM;				/**< \brief  Repeat Frame Count field */
	int32_t					skipped;			/**< \brief  picture decoding has been skipped */
	vc1_stream_tag			tag;
} vc1_image_info;
/** \} */

/** \brief Reserved. \{ */
typedef struct
{
	uint32_t frame_num;
	int32_t picture_valid;
	vc1_stream_tag tag;
} vc1_decoder_info;
/** \} */

/** \brief Reserved. \{ */
typedef struct vc1_ref_pic_s {
	int32_t id;
	int32_t bottom_field_flag;
	uint32_t user_data;
} vc1_ref_pic_t;
/** \} */

/** \brief Reserved. \{ */
typedef struct vc1_dpb_s {
	vc1_ref_pic_t ref_pic[16];
} vc1_dpb_t;
/** \} */

/** \brief Reserved. \{ */
typedef struct vc1_bitstream_s {
	uint8_t *data;
	uint32_t bits;
} vc1_bitstream_t;
/** \} */

/** \brief Reserved. \{ */
typedef struct
{
	uint8_t intensity_comp_flag;     /**< \brief Intensity Compensation Enable */
	uint8_t luminance_scale;         /**< \brief Intensity Compensation Scale */
	uint8_t luminance_shift;         /**< \brief Intensity Compensation Shift */
} vc1_intensity_comp;
/** \} */

/** \brief Reserved. \{ */
typedef struct vc1_picture_s {

	int32_t		id;
	uint32_t	user_data;
	int32_t		slice_count;
	int32_t		poc;

/*	vc1_macroblock_t	*mb;

	int8_t		*ipred;
	h264_mv_t	*mvd[2];
	h264_mv_t	*mv[2];
	int8_t		*ref_idx[2];
	void		*level[3];
	void		*coeff[3];
	void		*residual[3];

	void	*samples_predicted[3];
	int32_t	stride_samples_predicted[3];

	void	*samples_restored[3];
	int32_t	stride_samples_restored[3];

	void	*samples[3];
	int32_t	stride_samples[3];*/

	int32_t ref_count;
	vc1_picture_state   *pic_state;
	vc1_ref_pic_t ref_pic[16];
	vc1_bitstream_t	*bs_slice;
	vc1_intensity_comp	ic[2];   /**< \brief Intensity compensation for 0=Top 1=Bottom fields */

	uint8_t	reserved[510];
} vc1_picture_t;
/** \} */

/** \brief Reserved. \{ */
typedef struct vc1_frame_s {
	vc1_sequence_layer	*seq_header;
	vc1_picture_t		*pic[2];

	int32_t	id;
	uint32_t user_data;
	int32_t	interlaced_frame_flag;
	int32_t	frame_num;
	int32_t	poc[2];

	int32_t	short_term_reference_flags;
	int32_t	long_term_reference_flags;

	uint8_t	reserved[512];
} vc1_frame_t;
/** \} */

#ifdef __cplusplus
extern "C" {
#endif

/**
\brief Call this function to get a bufstream interface for the VC-1 video decoder.
\return  The video decoder instance.
*/
	 bufstream_tt * MC_EXPORT_API open_vc1in_Video_stream(void); //quick and dirty default initialization

/**
\brief Call this function to get a bufstream interface for the VC-1 video decoder.
\return  The video decoder instance.
\param[in] get_rc  callbacks to external message handler and memory manager functions
\param[in] reserved1 reserved parameter
\param[in] reserved2 reserved parameter
*/
	 bufstream_tt * MC_EXPORT_API open_vc1in_Video_stream_ex(void *(MC_EXPORT_API *get_rc)(const char* name), long reserved1, long reserved2);
/**
\brief Provides access to extended module API.
\return  pointer to requested function or NULL
\param[in] func	identifier of module extended function
*/
	 APIEXTFUNC     MC_EXPORT_API vc1in_Video_GetAPIExt(uint32_t func);

#ifdef __cplusplus
}
#endif

#endif // #if !defined (__DEC_VC1_API_INCLUDED__)

