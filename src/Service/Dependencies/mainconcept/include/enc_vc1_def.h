/**
@file: enc_vc1_def.h
@brief VC1 Encoder API defines

@verbatim
File: enc_vc1_def.h
Desc: VC1 Encoder API defines
 
 Copyright (c) 2015 MainConcept GmbH or its affiliates.  All rights reserved.

 MainConcept and its logos are registered trademarks of MainConcept GmbH or its affiliates.  
 This software is protected by copyright law and international treaties.  Unauthorized 
 reproduction or distribution of any portion is prohibited by law.
@endverbatim
 **/

#if !defined (__ENC_VC1_DEF_INCLUDED__)
#define __ENC_VC1_DEF_INCLUDED__

/**
@def PROFILES 
@name Profile defines
@{
**/
#define VC1_PROFILE_SIMPLE                                  0   /**<@brief Simple profile @hideinitializer   */
#define VC1_PROFILE_MAIN                                    1   /**<@brief Main profile @hideinitializer     */
#define VC1_PROFILE_ADVANCED                                3   /**<@brief Advanced profile @hideinitializer */
/**@}*/

/**
@def LEVELS 
@name Level defines
@{
**/
#define VC1_LEVEL_LOW                                       0	/**<@brief Low level (used with Simple and Main profiles) 		@hideinitializer */
#define VC1_LEVEL_MEDIUM                                    1   /**<@brief Medium level (used with Simple and Main profiles)    @hideinitializer */
#define VC1_LEVEL_HIGH                                      2   /**<@brief High level (used with Main profile only)             @hideinitializer */

#define VC1_LEVEL0                                          0   /**<@brief  Level 0 (used with advanced profile)                @hideinitializer */
#define VC1_LEVEL1                                          1   /**<@brief  Level 1 (used with advanced profile)                @hideinitializer */
#define VC1_LEVEL2                                          2   /**<@brief  Level 2 (used with advanced profile)                @hideinitializer */
#define VC1_LEVEL3                                          3   /**<@brief  Level 3 (used with advanced profile)                @hideinitializer */
#define VC1_LEVEL4                                          4   /**<@brief  Level 4 (used with advanced profile)                @hideinitializer */
#define VC1_LEVEL_AUTO                                      100 /**<@brief  Auto level (used with advanced profile)             @hideinitializer */
/**@}*/

/**
@def INTERLACED_MODES 
@name Video sequence coding mode (interlace / progressive)
@{
**/
#define VC1_PROGRESSIVE                                     0   /**<@brief Progressive @hideinitializer */
#define VC1_INTERLACE_FIELD                                 1   /**<@brief Interlaced - encode every frame as 2 field pictures @hideinitializer */
#define VC1_INTERLACE_MBAFF                                 2   /**<@brief Interlaced - macroblock-adaptive frame-field coding @hideinitializer */
#define VC1_INTERLACE_PAFF                                  3   /**<@brief 		@hideinitializer */
/**@}*/

/**
@def FIELD_ORDER 
@name Field order defines
@{
**/
#define VC1_TOPFIELD_FIRST                                  0   /**<@brief Top field is first 		@hideinitializer */
#define VC1_BOTTOMFIELD_FIRST                               1   /**<@brief Bottom field is first    @hideinitializer */
/**@}*/

/**
@def RATE_CONTROL_MODES 
@name Bit rate control defines
@{
**/
#define VC1_CQT                                             0   /**<@brief Constant Quantization */
#define VC1_VBR                                             1   /**<@brief Variable Bitrate      */
#define VC1_CBR                                             2   /**<@brief Constant Bitrate      */
/**@}*/
/**
@def ADAPTIVE_QUANTIZATION_MODES
@name Adaptive quantization mode defines
@{
**/
#define VC1_AQUANT_MODE_BRIGHTNESS                          0   /**<@brief 			@hideinitializer */
#define VC1_AQUANT_MODE_CONTRAST                            1   /**<@brief 			@hideinitializer */
#define VC1_AQUANT_MODE_COMPLEXITY                          2   /**<@brief 			@hideinitializer */
/**@}*/
/**
@def CLOSED_ENTRY_CONTROL
@name Closed entry control defines
@{
**/
#define VC1_CLOSED_ENTRY_OFF                                0   /**<@brief Indicates that the entry point segment may contain B pictures that require reference to an I or P picture in the previous entry point segment to decode. @hideinitializer */
#define VC1_CLOSED_ENTRY_ON                                 1   /**<@brief Indicates that the current entry point segment does not contain any B pictures that require reference to an I or P picture in the previous entry point segment to decode (default). @hideinitializer */
/**@}*/
/**
@def HRD_BUFFER_UNITS
@name HRD buffer fullness units defines
@{
**/
#define VC1_HRD_UNIT_PERCENTS                               0  /**<@brief In percents      @hideinitializer */
#define VC1_HRD_UNIT_BITS                                   1  /**<@brief In bits          @hideinitializer */
#define VC1_HRD_UNIT_TIME                                   2  /**<@brief In 90 kHz units  @hideinitializer */
/**@}*/
/**
@def VIDEO_STANDARTS
@name Video standart defines
@{
**/
#define VC1_PAL                                             1  /**< @brief   @hideinitializer */
#define VC1_NTSC                                            2  /**< @brief   @hideinitializer */
/**@}*/
/**
@def ME_MODES
@name Motion estimation mode defines
@{
**/
#define VC1_ME_ZERO                                         0  /**<@brief    @hideinitializer */
#define VC1_ME_FAST                                         1  /**<@brief    @hideinitializer */
#define VC1_ME_FULL                                         2  /**<@brief    @hideinitializer */
/**@}*/

/**
@def SUBPEL
@name Subpixel mode defines
@{
**/
#define VC1_FULL_PEL                                        0   /**<@brief Only full pixel position will be examined @hideinitializer */
#define VC1_HALF_PEL                                        1   /**<@brief Half-pixels positions will be added to the search @hideinitializer */
#define VC1_QUARTER_PEL                                     2   /**<@brief Both half and quarter pixel positions will be added @hideinitializer */
/**@}*/

/**
@def DEBLOCK
@name Deblock filtering defines
@{
**/
#define VC1_DEBLOCK_OFF                                     0  /**<@brief Disable deblock filter @hideinitializer */
#define VC1_DEBLOCK_ON                                      1  /**<@brief Enable deblock filter  @hideinitializer */
/**@}*/
/**
@def VAR_SIZED_TRANSFORM
@name Variable sized transform defines
@{
**/
#define VC1_VSTRANS_OFF                                     0  /**<@brief                         @hideinitializer */
#define VC1_VSTRANS_ON                                      1  /**<@brief						  @hideinitializer */
/**@}*/
/**
@def STARTCODES
@name Disable startcodes defines
@{
**/
#define VC1_STARTCODES_ON                                   0  /**<@brief Use EBDU start codes, output is HD DVD and Bluray compatible stream and can be played back without any multiplexing layer (default). @hideinitializer */
#define VC1_STARTCODES_OFF                                  1  /**<@brief Do not use EBDU start codes, this mode is utilized when using ASF multiplexing. @hideinitializer */
/**@}*/
/**
@def ASF
@name ASF binding defines
@{
**/
#define VC1_ASF_BINDING_OFF                                 0  /**<@brief Do not use ASF binding byte (default). @hideinitializer */
#define VC1_ASF_BINDING_ON                                  1  /**<@brief Use ASF binding byte to be compatible with Microsoft WMVideo Decoder. @hideinitializer */
/**@}*/
/**
@def VCSCD
@name Visual content scene detection mode defines
@{
**/
#define VC1_VCSD_MODE_OFF                                   0  /**<@brief No scene detection @hideinitializer */
#define VC1_VCSD_MODE_ON                                    1  /**<@brief Set an I frame on scene change @hideinitializer */
/**@}*/
/**
@def PSNR
@name PSNR calculation defines
@{
**/
#define VC1_PSNR_OFF                                        0 /**<@brief Do not calculate PSNR @hideinitializer */
#define VC1_PSNR_ON                                         1 /**<@brief Calculate PSNR @hideinitializer */
/**@}*/

/**
@def VIDEO_TYPE
@name Video type defines
@{
**/
#define VC1_BASELINE                                        0  /**<@brief Similar to ISO/IEC 11172-1/2             @hideinitializer */
#define VC1_CIF                                             1  /**<@brief Similar to MPEG1 VideoCD                 @hideinitializer */
#define VC1_MAIN                                            2  /**<@brief Similar to ISO/IEC 13818-1/2             @hideinitializer */
#define VC1_SVCD                                            3  /**<@brief Similar to MPEG2 SuperVCD                @hideinitializer */
#define VC1_D1                                              4  /**<@brief Similar to MPEG2 DVD                     @hideinitializer */
#define VC1_HIGH                                            5  /**<@brief 										   @hideinitializer */
#define VC1_DVD                                             6  /**<@brief                                          @hideinitializer */
#define VC1_HD_DVD                                          7  /**<@brief                                          @hideinitializer */
#define VC1_BD                                              8  /**<@brief Blu-ray Disc							   @hideinitializer */
#define VC1_BD_HDMV                                         9  /**<@brief Blu-ray Disc (Main Video)                @hideinitializer */
#define VC1_SILVERLIGHT                                    10  /**<@brief Microsoft Silverlight Profile            @hideinitializer */
#define VC1_LAST_VC1_TYPE                                  11  /**<@brief 										   @hideinitializer */
/**@}*/

/**
@def PULLDOWN_FLAGS
@name Pulldown flag defines
@{
**/
#define VC1_VIDEO_PULLDOWN_NONE                             0  /**<@brief 												@hideinitializer */
#define VC1_VIDEO_PULLDOWN_23                               1  /**<@brief 23.976/24 played as 29.97/30              	@hideinitializer */
#define VC1_VIDEO_PULLDOWN_32                               2  /**<@brief 23.976/24 played as 29.97/30              	@hideinitializer */
#define VC1_VIDEO_PULLDOWN_23_P                             4  /**<@brief 23.976/24 played as 59.94/60              	@hideinitializer */
#define VC1_VIDEO_PULLDOWN_32_P                             5  /**<@brief 23.976/24 played as 59.94/60              	@hideinitializer */
#define VC1_VIDEO_PULLDOWN_AUTO                             6  /**<@brief User defined pulldown flags on every picture  @hideinitializer */
/**@}*/
/**
@def DISPLAY_MODE
@name Display mode defines
@{
**/
#define VC1_DISPLAY_FRAME                                   0  /**< @brief  Display as progressive frame 			@hideinitializer */
#define VC1_DISPLAY_TOPFIELD                                1  /**< @brief  Top field 								@hideinitializer */
#define VC1_DISPLAY_BOTFIELD                                2  /**< @brief  Bottom field 							@hideinitializer */
#define VC1_DISPLAY_TOPBOT                                  3  /**< @brief  Top field, bottom field 				@hideinitializer */
#define VC1_DISPLAY_BOTTOP                                  4  /**< @brief  Bottom field, top field 				@hideinitializer */
#define VC1_DISPLAY_TOPBOTTOP                               5  /**< @brief  Top field, bottom field, top field 		@hideinitializer */
#define VC1_DISPLAY_BOTTOPBOT                               6  /**< @brief  Bottom field, top field, bottom field 	@hideinitializer */
#define VC1_DISPLAY_DOUBLING                                7  /**< @brief  Display frame twice 					@hideinitializer */
#define VC1_DISPLAY_TRIPLING                                8  /**< @brief  Display frame three times 				@hideinitializer */
/**@}*/
/**
@def CPU_OPT
@name CPU optimization mode defines
@{
**/
#define VC1_CPU_OPT_AUTO                                    0  /**< @brief   @hideinitializer */
#define VC1_CPU_OPT_UNKNOWN                                 1  /**< @brief   @hideinitializer */
#define VC1_CPU_OPT_MMX                                     2  /**< @brief   @hideinitializer */
#define VC1_CPU_OPT_MMX_EXT                                 3  /**< @brief   @hideinitializer */
#define VC1_CPU_OPT_SSE                                     4  /**< @brief   @hideinitializer */
#define VC1_CPU_OPT_SSE2                                    5  /**< @brief   @hideinitializer */
#define VC1_CPU_OPT_SSE3                                    6  /**< @brief   @hideinitializer */
/**@}*/


////////// defines for VC-1 conformance check

/**
@def CHECK_DEFINES
@name Defines for options of vc1OutVideoChkSettings() function
@{
**/
#define VC1_CHECK_AND_ADJUST                                0x00000001 /**<@brief Check and adjust @hideinitializer */
#define VC1_CHECK_FOR_LEVEL                                 0x00000002 /**<@brief Check for level  @hideinitializer */
/**@}*/

/**
@def PERFORMANCE_DEFINES
@name Defines for options of vc1OutVideoPerformance() function
@{
**/
#define VC1_PERF_FASTEST                                    0   /**<@brief Fastest performance 							  @hideinitializer */
#define VC1_PERF_BALANCED                                   9   /**<@brief Balanced performance.Recommended default value @hideinitializer */
#define VC1_PERF_BEST_Q                                     15  /**<@brief Best quality									  @hideinitializer */
/**@}*/

/**
@def ERRORS
@name Error defines
@{
**/

/**
@def GENERAL_ERRORS
@name General error defines
@{
**/
#define VC1ERROR_NONE                                       0
#define VC1ERROR_FAILED                                     1
#define VC1ERROR_NOT_SUPPORTED                              2
#define VC1ERROR_PARAM_UNKNOWN                              3
/**@}*/
/**
@def PARAMETER_ERRORS
@name Defines for parameter set errors
@{
**/
#define VC1ERROR_PARAM_SET                                  1000
#define VC1ERROR_PROFILE_ID                                 VC1ERROR_PARAM_SET + 1
#define VC1ERROR_LEVEL_ID                                   VC1ERROR_PARAM_SET + 2
#define VC1ERROR_KEY_FRAME_INTERVAL                         VC1ERROR_PARAM_SET + 3
#define VC1ERROR_B_FRAME_DISTANCE                           VC1ERROR_PARAM_SET + 4
#define VC1ERROR_CLOSED_ENTRY                               VC1ERROR_PARAM_SET + 5
#define VC1ERROR_INTERLACE_MODE                             VC1ERROR_PARAM_SET + 6
#define VC1ERROR_FIELD_ORDER                                VC1ERROR_PARAM_SET + 7
#define VC1ERROR_DEF_HORIZONTAL_SIZE                        VC1ERROR_PARAM_SET + 8
#define VC1ERROR_DEF_VERTICAL_SIZE                          VC1ERROR_PARAM_SET + 9
#define VC1ERROR_FRAME_RATE                                 VC1ERROR_PARAM_SET + 10
#define VC1ERROR_BIT_RATE_MODE                              VC1ERROR_PARAM_SET + 11
#define VC1ERROR_BIT_RATE_BUFFER_SIZE                       VC1ERROR_PARAM_SET + 12
#define VC1ERROR_BIT_RATE                                   VC1ERROR_PARAM_SET + 13
#define VC1ERROR_MAX_BIT_RATE                               VC1ERROR_PARAM_SET + 14
#define VC1ERROR_VBV_BUFFER_FULLNESS                        VC1ERROR_PARAM_SET + 15
#define VC1ERROR_VBV_BUFFER_FULLNESS_TRG                    VC1ERROR_PARAM_SET + 16
#define VC1ERROR_VBV_BUFFER_UNITS                           VC1ERROR_PARAM_SET + 17
#define VC1ERROR_QUANT_PI                                   VC1ERROR_PARAM_SET + 18
#define VC1ERROR_QUANT_PP                                   VC1ERROR_PARAM_SET + 19
#define VC1ERROR_QUANT_PB                                   VC1ERROR_PARAM_SET + 20
#define VC1ERROR_SAR_WIDTH                                  VC1ERROR_PARAM_SET + 21
#define VC1ERROR_SAR_HEIGHT                                 VC1ERROR_PARAM_SET + 22
#define VC1ERROR_PIC_AR_X                                   VC1ERROR_PARAM_SET + 23
#define VC1ERROR_PIC_AR_Y                                   VC1ERROR_PARAM_SET + 24
#define VC1ERROR_WRITE_ASP_RATIO_INFO                       VC1ERROR_PARAM_SET + 25
#define VC1ERROR_WRITE_FRAME_RATE_INFO                      VC1ERROR_PARAM_SET + 26
#define VC1ERROR_WRITE_HRD_PARAMS                           VC1ERROR_PARAM_SET + 27
#define VC1ERROR_VIDEO_FORMAT                               VC1ERROR_PARAM_SET + 28
#define VC1ERROR_VIDEO_FULL_RANGE                           VC1ERROR_PARAM_SET + 29
#define VC1ERROR_COLOR_FORMAT_FLAG                          VC1ERROR_PARAM_SET + 30
#define VC1ERROR_COLOR_PRIMARIES                            VC1ERROR_PARAM_SET + 31
#define VC1ERROR_TRANSFER_CHARACTERISTICS                   VC1ERROR_PARAM_SET + 32
#define MATRIX_COEFFICIENTS                                 VC1ERROR_PARAM_SET + 33
// reserved space for 27 parameters
#define VC1ERROR_CALC_QUALITY                               VC1ERROR_PARAM_SET + 61
#define VC1ERROR_VCSD_MODE                                  VC1ERROR_PARAM_SET + 62
#define VC1ERROR_VCSD_SENSIBILITY                           VC1ERROR_PARAM_SET + 63
#define VC1ERROR_MIN_KEY_FRAME_INTERVAL                     VC1ERROR_PARAM_SET + 64
#define VC1ERROR_USE_DEBLOCKING_FILTER                      VC1ERROR_PARAM_SET + 65
#define VC1ERROR_ME_MODE                                    VC1ERROR_PARAM_SET + 66
#define VC1ERROR_ME_SUBPEL                                  VC1ERROR_PARAM_SET + 67
#define VC1ERROR_ME_SEARCH_RANGE                            VC1ERROR_PARAM_SET + 68
#define VC1ERROR_ME_USE_4MV                                 VC1ERROR_PARAM_SET + 69
#define VC1ERROR_ME_USE_INTENSITY_COMP                      VC1ERROR_PARAM_SET + 70
#define VC1ERROR_WRITE_SEQ_END_CODE                         VC1ERROR_PARAM_SET + 71
// reserved space for 374 parameters
#define VC1ERROR_VIDEO_TYPE                                 VC1ERROR_PARAM_SET + 446
#define VC1ERROR_VIDEO_PULLDOWN                             VC1ERROR_PARAM_SET + 447
#define VC1ERROR_TIMESTAMP_OFFSET                           VC1ERROR_PARAM_SET + 448
#define VC1ERROR_FIXED_I_POSITION                           VC1ERROR_PARAM_SET + 449

#define VC1PARAM_DISABLED                                   -10000000
/**@}*/ 
/**@}*/ 
#endif // #if !defined (__ENC_VC1_DEF_INCLUDED__)

