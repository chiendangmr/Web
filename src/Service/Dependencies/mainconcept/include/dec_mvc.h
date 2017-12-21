/** 
\file  dec_mvc.h
\brief  MVC/AVC/H.264 Decoder API

\verbatim
File: dec_mvc.h
Desc: MVC/AVC/H.264 Decoder API

 Copyright (c) 2015 MainConcept GmbH or its affiliates.  All rights reserved.

 MainConcept and its logos are registered trademarks of MainConcept GmbH or its affiliates.  
 This software is protected by copyright law and international treaties.  Unauthorized 
 reproduction or distribution of any portion is prohibited by law.
\endverbatim
**/


#if !defined (__DEC_MVC_API_INCLUDED__)
#define __DEC_MVC_API_INCLUDED__

#include "dec_avc.h"

/** \name MVC auxiliary commands */
#define GET_VIEW_ID 0x00010303	/**< \brief get specified view id \hideinitializer */
#define ENABLE_VIEW 0x00010304	/**< \brief enable view   \hideinitializer */
#define DISABLE_VIEW 0x00010305	/**< \brief disable view  \hideinitializer */
#define GET_VIEW_IDX_NUM 0x00010306	/**< \brief get specified view index number \hideinitializer */
#define GET_VIEW_COUNT 0x00010307	/**< \brief get specified view index number \hideinitializer */
/** \} */

#define DEC_AVC_MAX_OPERATION_POINTS	128 /**< \brief Maximum supported operation points  \hideinitializer */
#define DEC_AVC_MAX_VIEWS				128 /**< \brief Maximum supported views  \hideinitializer */

/** \brief View scalability information SEI message. See See ISO/IEC 14496-10 Annex H for reference . */
typedef struct h264_sei_view_scalability_info_s {
	uint16_t num_operation_point_minus1;
	uint16_t operation_point_id[DEC_AVC_MAX_OPERATION_POINTS];
	uint16_t priority_id[DEC_AVC_MAX_OPERATION_POINTS];
	uint16_t temporal_id[DEC_AVC_MAX_OPERATION_POINTS];
	uint16_t num_target_output_views_minus1[DEC_AVC_MAX_OPERATION_POINTS];
	uint16_t view_id[DEC_AVC_MAX_OPERATION_POINTS][DEC_AVC_MAX_VIEWS];
	uint8_t profile_level_info_present_flag[DEC_AVC_MAX_OPERATION_POINTS];
	uint8_t bitrate_info_present_flag[DEC_AVC_MAX_OPERATION_POINTS];
	uint8_t frm_rate_info_present_flag[DEC_AVC_MAX_OPERATION_POINTS];
	uint8_t view_dependency_info_present_flag[DEC_AVC_MAX_OPERATION_POINTS];
	uint8_t parameter_sets_info_present_flag[DEC_AVC_MAX_OPERATION_POINTS];
	uint8_t bitstream_restriction_info_present_flag[DEC_AVC_MAX_OPERATION_POINTS];
	uint8_t op_profile_level_idc[DEC_AVC_MAX_OPERATION_POINTS];
	uint8_t profile_level_info_src_op_id_delta[DEC_AVC_MAX_OPERATION_POINTS];
	uint32_t avg_bitrate[DEC_AVC_MAX_OPERATION_POINTS];
	uint32_t max_bitrate[DEC_AVC_MAX_OPERATION_POINTS];
	uint16_t max_bitrate_calc_window[DEC_AVC_MAX_OPERATION_POINTS];
	uint8_t constant_frm_rate_idc[DEC_AVC_MAX_OPERATION_POINTS];
	uint8_t avg_frm_rate[DEC_AVC_MAX_OPERATION_POINTS];
	uint8_t num_directly_dependent_views[DEC_AVC_MAX_OPERATION_POINTS];
	uint16_t directly_dependent_view_id[DEC_AVC_MAX_OPERATION_POINTS][DEC_AVC_MAX_VIEWS];
	uint16_t view_dependency_info_src_op_id[DEC_AVC_MAX_OPERATION_POINTS];
	uint8_t num_seq_parameter_set_minus1[DEC_AVC_MAX_OPERATION_POINTS];
	uint8_t seq_parameter_set_id_delta[DEC_AVC_MAX_OPERATION_POINTS][32];
	uint8_t num_subset_seq_parameter_set_minus1[DEC_AVC_MAX_OPERATION_POINTS];
	uint8_t subset_seq_parameter_set_id_delta[DEC_AVC_MAX_OPERATION_POINTS][32];
	uint8_t num_pic_parameter_set_minus1[DEC_AVC_MAX_OPERATION_POINTS];
	uint16_t pic_parameter_set_id_delta[DEC_AVC_MAX_OPERATION_POINTS][256];
	uint16_t parameter_sets_info_src_op_id[DEC_AVC_MAX_OPERATION_POINTS];
	uint8_t motion_vectors_over_pic_boundaries_flag[DEC_AVC_MAX_OPERATION_POINTS];
	uint8_t max_bytes_per_pic_denom[DEC_AVC_MAX_OPERATION_POINTS];
	uint8_t max_bits_per_mb_denom[DEC_AVC_MAX_OPERATION_POINTS];
	uint8_t log2_max_mv_length_horizontal[DEC_AVC_MAX_OPERATION_POINTS];
	uint8_t log2_max_mv_length_vertical[DEC_AVC_MAX_OPERATION_POINTS];
	uint8_t num_reorder_frames[DEC_AVC_MAX_OPERATION_POINTS];
	uint8_t	max_dec_frame_buffering[DEC_AVC_MAX_OPERATION_POINTS];
}h264_sei_view_scalability_info_t;
/** \} */

#ifdef __cplusplus
extern "C" {
#endif

/**
 \brief Call this function to get a bufstream interface for the MVC video decoder.
 \return  The video decoder instance.
 */
	bufstream_tt *  MC_EXPORT_API open_MVCin_Video_stream(void); //quick and dirty default initialization
/**
 \brief Call this function to get a bufstream interface for the MVC video decoder.
 \return  The video decoder instance.
 \param[in] get_rc  callbacks to external message handler and memory manager functions
 \param[in] reserved1 reserved parameter
 \param[in] reserved2 reserved parameter
 */	
	bufstream_tt *  MC_EXPORT_API open_MVCin_Video_stream_ex(void *(MC_EXPORT_API *get_rc)(const char* name), long reserved1, long reserved2);
/**
\brief Provides access to extended module API.
\return  pointer to requested function or NULL
\param[in] func identifier of module extended function
 */
	APIEXTFUNC      MC_EXPORT_API MVCin_Video_GetAPIExt(uint32_t func);

#ifdef __cplusplus
}
#endif

#endif  // #if !defined (__DEC_MVC_API_INCLUDED__)
