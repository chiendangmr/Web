/**
@file: enc_vc3_def.h
@brief VC-3 Encoder API defines

@verbatim
File: enc_vc3_def.h
Desc: VC-3 Encoder API defines

Copyright (c) 2015 MainConcept GmbH or its affiliates.  All rights reserved.

MainConcept and its logos are registered trademarks of MainConcept GmbH or its affiliates.  
This software is protected by copyright law and international treaties.  Unauthorized 
reproduction or distribution of any portion is prohibited by law.
@endverbatim
**/

#if !defined (__ENC_VC3_DEF_INCLUDED__)
#define __ENC_VC3_DEF_INCLUDED__

/**
* @name VC3 encoder constants
  @brief Resolution restrictions
* @{
*/
#define VC3_MIN_WIDTH             256    /**<@brief Minimum possible width of encoded stream @hideinitializer*/
#define VC3_MIN_HEIGHT            120    /**<@brief Minimum possible height of encoded stream @hideinitializer*/
/** @} */


/**
* @name Error Codes
* @brief These codes are used by API functions.
* @{
*/
#define VC3_ERROR_NONE            0    /**<@brief Success @hideinitializer*/
#define VC3_ERROR_FAILED          1    /**<@brief Failed @hideinitializer*/
/** @} */

/**
* @name Interlace Modes
* @brief These modes are used to specify field order.
* @{
*/
#define VC3_PROGRESSIVE           0    /**<@brief Progressive scan type @hideinitializer*/
#define VC3_INTERLACED            1    /**<@brief Interlaced scan type @hideinitializer*/
/** @} */

/**
* @name Target quality
* @brief These modes are used to specify compression quality.
* @{
*/
#define VC3_QUALITY_LB            0    /**<@brief Low bitrate      4:2:2 8 bit @hideinitializer*/
#define VC3_QUALITY_SQ            1    /**<@brief Standard quality 4:2:2 8 bit @hideinitializer*/
#define VC3_QUALITY_HQ            2    /**<@brief High quality     4:2:2 8 bit @hideinitializer*/
#define VC3_QUALITY_HQX           3    /**<@brief High quality     4:2:2 10/12 bit @hideinitializer*/
#define VC3_QUALITY_444           4    /**<@brief High quality     4:4:4 10/12 bit @hideinitializer*/
/** @} */

/**
* @name Target colorspaces
* @brief These modes are used to specify target colorspace
* @{
*/
#define VC3_COLOR_SPACE_YUV       0    /**<@brief Default colorspace for almost presets @hideinitializer*/
#define VC3_COLOR_SPACE_RGB       1    /**<@brief Use it together with @ref VC3_QUALITY_444 to choose RGB colorspace @hideinitializer*/
/** @} */

/**
* @name Chroma format defines
* @brief These chroma values are currently unused and reserved for future use.
* @{
*/
#define VC3_CHROMA_420            0    /**<@brief 4:2:0 colour sampling; currently is not used (reserved for future usage) @hideinitializer*/
#define VC3_CHROMA_422            1    /**<@brief 4:2:2 colour sampling @hideinitializer*/
#define VC3_CHROMA_444            2    /**<@brief 4:4:4 colour sampling @hideinitializer*/
/** @} */

/**
* @name Colorimetry
* @brief These types are used to specify colorimetry.
* @{
*/
#define VC3_COLORIMETRY_AUTO      0    /**<@brief Automatically detect. Equals BT.2020 when resolution > 4K (width>=3840 and height>=2160) @hideinitializer*/
#define VC3_COLORIMETRY_BT709     1    /**<@brief Use BT.709 @hideinitializer*/
#define VC3_COLORIMETRY_BT2020    2    /**<@brief Use BT.2020 @hideinitializer*/
/** @} */

/**
* @name Signal range
* @brief These types are used to specify source/destination signal range.
* @{
*/
#define VC3_SIGNAL_RANGE_PC       0    /**<@brief PC signal range (full range - 0..255) @hideinitializer*/
#define VC3_SIGNAL_RANGE_STUDIO   1    /**<@brief Studio signal range (short range - 16..235) @hideinitializer*/
/** @} */

/**
 * @name Options flags.
 * @brief This flag can be passed to \ref vc3OutVideoChkSettings in options param.
 * @{
 */
#define VC3_CHECK_AND_ADJUST      0x0001 /** @brief Pass this options flag to \ref vc3OutVideoChkSettings to adjust settings to be conform. @hideinitializer*/
/** @} */

#endif // #if !defined (__ENC_VC3_DEF_INCLUDED__)

