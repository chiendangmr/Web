/** 
 @file  enc_avc_mc.h
 @brief  Property GUIDs for MainConcept AVC/H.264 encoder parameters.
 
 @verbatim
 File: enc_avc_mc.h

 Desc: Property GUIDs for MainConcept AVC/H.264 encoder parameters.
 
 Copyright (c) 2015 MainConcept GmbH or its affiliates.  All rights reserved.

 MainConcept and its logos are registered trademarks of MainConcept GmbH or its affiliates.  
 This software is protected by copyright law and international treaties.  Unauthorized 
 reproduction or distribution of any portion is prohibited by law.
 @endverbatim
 **/


#if !defined(__PROPID_H264ENC_HEADER__)
#define __PROPID_H264ENC_HEADER__

//////////////////////////////////////////////////////////////////////////
//    Filter GUIDs
//////////////////////////////////////////////////////////////////////////

/**
* name Filter GUIDs
*@{
**/

/**@}*/

#define H264VE_MAX_CHAPTER_LIST 1023



/**
* namespace H264VE
* @brief H264VE specific namespace
**/
namespace H264VE
{

/**
* @brief Describes encoder profile.
**/
    typedef enum Profile
    {
        Profile_Baseline    = 0,        /**< @brief  Baseline Profile   (analogue @ref H264PROFILE_BASELINE)*/
        Profile_Main        = 1,        /**< @brief  Main Profile       (analogue @ref H264PROFILE_MAIN)    */
        Profile_High        = 3,        /**< @brief  High Profile       (analogue @ref H264PROFILE_HIGH)    */
        Profile_High10      = 4,        /**< @brief  High 10 Profile    (analogue @ref H264PROFILE_HIGH_10) */
        Profile_High422     = 5,        /**< @brief  High 4:2:2 Profile (analogue @ref H264PROFILE_HIGH_422)*/
/** @cond */
        Profile_High444     = 6         /**< @brief  NOT USED FOR NOW   (analogue @ref H264PROFILE_HIGH_444)*/
/** @endcond */

    } Profile_t;

/**
* @brief Describes level.
* These standard levels described in Recommendation ITU-T H.264 (Annex A.3)
**/
    typedef enum Level
    {
        Level_1     = 10,               /**< @brief - H.264 Level 1 */
        Level_1b    = 16,               /**< @brief - H.264 Level 1b */
        Level_11    = 11,               /**< @brief - H.264 Level 1.1 */
        Level_12    = 12,               /**< @brief - H.264 Level 1.2 */
        Level_13    = 13,               /**< @brief - H.264 Level 1.3 */
        Level_2     = 20,               /**< @brief - H.264 Level 2 */
        Level_21    = 21,               /**< @brief - H.264 Level 2.1 */
        Level_22    = 22,               /**< @brief - H.264 Level 2.2 */
        Level_3     = 30,               /**< @brief - H.264 Level 3 */
        Level_31    = 31,               /**< @brief - H.264 Level 3.1 */
        Level_32    = 32,               /**< @brief - H.264 Level 3.2 */
        Level_4     = 40,               /**< @brief - H.264 Level 4 */
        Level_41    = 41,               /**< @brief - H.264 Level 4.1 */
        Level_42    = 42,               /**< @brief - H.264 Level 4.2 */
        Level_5     = 50,               /**< @brief - H.264 Level 5 */
        Level_51    = 51,               /**< @brief - H.264 Level 5.1 */
        Level_52    = 52,               /**< @brief - H.264 Level 5.2 */
        Level_6     = 60,               /**< @brief - H.264 Level 6 */
        Level_61    = 61,               /**< @brief - H.264 Level 6.1 */
        Level_62    = 62,               /**< @brief - H.264 Level 6.2 */
        Level_Auto  = 100               /**< @brief - Auto level. Encoder will set this automatically.*/
    } Level_t;
/**
* @brief Describes chroma sampling.
**/
    typedef enum ColourSampling
    {
/** @cond */
        Chroma_400  = 1,                /**< @brief - Chroma 4:0:0 (analogue @ref H264_CHROMA_400) */
/** @endcond */
        Chroma_420  = 2,                /**< @brief - Chroma 4:2:0 (analogue @ref H264_CHROMA_420) */
        Chroma_422  = 3,                /**< @brief - Chroma 4:2:2 (analogue @ref H264_CHROMA_422) */
/** @cond */
        Chroma_444  = 4                 /**< @brief - Chroma 4:4:4 (analogue @ref H264_CHROMA_444) */
/** @endcond */

    } ColourSampling_t;
 
/**
* @brief Describes bit rate mode.
**/
    typedef enum BitRateMode
    {
        BitRateMode_CBR = 0,            /**< @brief Constant bitrate mode (analogue @ref H264_CBR)*/
        BitRateMode_CQT = 1,            /**< @brief Constant quantizers mode (analogue @ref H264_CQT)*/
        BitRateMode_VBR = 2,            /**< @brief Variable bitrate mode (analogue @ref H264_VBR)*/
        BitRateMode_TQM = 3,            /**< @brief Target quality mode (analogue @ref H264_TQM)*/
/** @cond */
        BitRateMode_INTRA = 4           /**< @brief Intra ratecontrol mode. Cannot be set manually */
/** @endcond */
    } BitRateMode_t;

/**
* @brief Describes encoding pass mode.
**/
    typedef enum BitRatePass
    {
        BitRatePass_Simple = 0,                 /**< @brief - Singlepass encoding */
        BitRatePass_Analyse = 1,                /**< @brief - Analyze pass for Multypass encoding  */
        BitRatePass_Encode = 2                  /**< @brief - Encoding pass for Multypass encoding */
    } BitRatePass_t;

/**
* @brief Describes entropy coding mode.
**/
    typedef enum EntropyCodingMode
    {
        EntropyCodingMode_CAVLC = 0,            /**< @brief Context-adaptive variable-length coding (analogue @ref H264_CAVLC) */
        EntropyCodingMode_CABAC = 1             /**< @brief Context-adaptive binary arithmetic coding (analogue @ref H264_CABAC) */

    } EntropyCodingMode_t;

/**
* @brief Describes encoder presets.
**/
    typedef enum VideoType
    {
        VideoType_BASELINE          = 0,                /**< @brief  - Baseline Profile                                                                 (analogue @ref H264_BASELINE)                    */
        VideoType_CIF               = 1,                /**< @brief  - Similar to MPEG1 VideoCD                                                         (analogue @ref H264_CIF)                         */
        VideoType_MAIN              = 2,                /**< @brief  - Similar to ISO/IEC 13818-1/2                                                     (analogue @ref H264_MAIN)                        */
        VideoType_D1                = 4,                /**< @brief  - Similar to MPEG2 DVD                                                             (analogue @ref H264_D1)                          */
        VideoType_HIGH              = 5,                /**< @brief  - High Profile 1920x1080i                                                          (analogue @ref H264_HIGH)                        */
        VideoType_HIGH_10           = 6,                /**< @brief  - High 10 Profile generic preset                                                   (analogue @ref H264_HIGH_10)                     */
        VideoType_HIGH_422          = 7,                /**< @brief  - High 422 Profile generic preset                                                  (analogue @ref H264_HIGH_422)                    */
        VideoType_BD                = 8,                /**< @brief  - Blu-ray Disc                                                                     (analogue @ref H264_BD)                          */
        VideoType_BD_HDMV           = 9,                /**< @brief  - Blu-ray Disc (Main Video)                                                        (analogue @ref H264_BD_HDMV)                     */
        VideoType_HDV_HD1           = 11,               /**< @brief  - 1280x720p                                                                        (analogue @ref H264_HDTV_720p)                   */
        VideoType_HDV_HD2           = 12,               /**< @brief  - 1440x1080i                                                                       (analogue @ref H264_HDTV_1080i)                  */
        VideoType_AVCHD             = 14,               /**< @brief  - AVCHD                                                                            (analogue @ref H264_AVCHD)                       */
        VideoType_1SEG              = 16,               /**< @brief  - 1seg compatible                                                                  (analogue @ref H264_1SEG)                        */
        VideoType_INTRA_CLASS_50    = 18,               /**< @brief  - H.264 intra frame coding (Class 50)                                              (analogue @ref H264_INTRA_CLASS_50)              */
        VideoType_INTRA_CLASS_100   = 19,               /**< @brief  - H.264 intra frame coding (Class 100)                                             (analogue @ref H264_INTRA_CLASS_100)             */
        VideoType_DIVXPLUS          = 22,               /**< @brief  - DivX PLUS preset                                                                 (analogue @ref H264_DIVX)                        */
        VideoType_3GP               = 25,               /**< @brief  - 3GP                                                                              (analogue @ref H264_3GP)                         */
        VideoType_Silverlight       = 26,               /**< @brief  - Microsoft Silverlight Profile                                                    (analogue @ref H264_SILVERLIGHT)                 */
        VideoType_INTRA_CLASS_50_RP2027  = 33,          /**< @brief  - RP2027 H.264 intra frame coding (Class 50)                                       (analogue @ref H264_INTRA_CLASS_50_RP2027)       */
        VideoType_INTRA_CLASS_100_RP2027 = 34,          /**< @brief  - RP2027 H.264 intra frame coding (Class 100)                                      (analogue @ref H264_INTRA_CLASS_100_RP2027)      */
        VideoType_INTRA_CLASS_200_RP2027 = 72,          /**< @brief  - RP2027-2012 H.264 intra frame coding (Class 200)                                 (analogue @ref H264_INTRA_CLASS_200_RP2027)      */
        VideoType_AVCHD_20               = 75,          /**< @brief  - AVCHD 2.0 1080/50p 1080/60p                                                      (analogue @ref H264_AVCHD_20)                    */
        VideoType_DASH264                = 76,          /**< @brief  - DASH264                                                                          (analogue @ref H264_DASH264)                     */
        VideoType_AVC_LONG_GOP_CLASS_G50 = 78,          /**< @brief  - Panasonic AVC-LongG 4:2:2 Classes G50 (50 Mbps)                                  (analogue @ref H264_LONG_GOP_422_CLASS_G50)      */
        VideoType_AVC_LONG_GOP_CLASS_G25 = 79,          /**< @brief  - Panasonic AVC-LongG 4:2:2 Classes G25 (25 Mbps)                                  (analogue @ref H264_LONG_GOP_422_CLASS_G25)      */
        VideoType_AVC_LONG_GOP_CLASS_G12 = 80,          /**< @brief  - Panasonic AVC-LongG 4:2:0 Classes G12 (12 Mbps)                                  (analogue @ref H264_LONG_GOP_420_CLASS_G12)      */
        VideoType_AVC_LONG_GOP_CLASS_G6  = 81,          /**< @brief  - Panasonic AVC-LongG 4:2:0 Classes G6 (6 Mbps)                                    (analogue @ref H264_LONG_GOP_420_CLASS_G6)       */
        VideoType_INTRA_CLASS_200        = 82,          /**< @brief  - H.264 intra frame coding (Class 200)                                             (analogue @ref H264_INTRA_CLASS_200)             */
        VideoType_XAVC_4K                     = 83,     /**< @brief  - SONY XAVC Long GOP 4K Profile for M4 and XD Style (MP4 and MXF file formats)     (analogue @ref H264_XAVC_4K)                     */
        VideoType_XAVC_HD_MP4                 = 84,     /**< @brief  - SONY XAVC Long GOP HD Profile for M4 Style (MP4 file format)                     (analogue @ref H264_XAVC_HD_MP4)                 */
        VideoType_XAVC_HD_MXF                 = 85,     /**< @brief  - SONY XAVC Long GOP HD Profile for XD Style (MXF file format)                     (analogue @ref H264_XAVC_HD_MXF)                 */
        VideoType_XAVC_HD_INTRA_VBR           = 86,     /**< @brief  - SONY XAVC HD Intra VBR Profile for M4 Style (MP4 file format)                    (analogue @ref H264_XAVC_HD_INTRA_VBR)           */
        VideoType_XAVC_HD_INTRA_CLASS_50_CBG  = 87,     /**< @brief  - SONY XAVC HD Intra CBG Profile Class 50 for XD Style (MXF file format)           (analogue @ref H264_XAVC_HD_INTRA_CLASS_50_CBG)  */
        VideoType_XAVC_HD_INTRA_CLASS_100_CBG = 88,     /**< @brief  - SONY XAVC HD Intra CBG Profile Class 100 for XD Style (MXF file format)          (analogue @ref H264_XAVC_HD_INTRA_CLASS_100_CBG) */
        VideoType_XAVC_HD_INTRA_CLASS_200_CBG = 89,     /**< @brief  - SONY XAVC HD Intra CBG Profile Class 200 for XD Style (MXF file format)          (analogue @ref H264_XAVC_HD_INTRA_CLASS_200_CBG) */
        VideoType_XAVC_4K_INTRA_CLASS_100_CBG = 90,     /**< @brief  - SONY XAVC 4K Intra CBG Class 100 for XD Style (MXF file format)                  (analogue @ref H264_XAVC_4K_INTRA_CLASS_100_CBG) */
        VideoType_XAVC_4K_INTRA_CLASS_300_CBG = 91,     /**< @brief  - SONY XAVC 4K Intra CBG Class 300 for XD Style (MXF file format)                  (analogue @ref H264_XAVC_4K_INTRA_CLASS_300_CBG) */
        VideoType_XAVC_4K_INTRA_CLASS_480_CBG = 92,     /**< @brief  - SONY XAVC 4K Intra CBG Class 480 for XD Style (MXF file format)                  (analogue @ref H264_XAVC_4K_INTRA_CLASS_480_CBG) */
        VideoType_XAVC_4K_INTRA_CLASS_100_VBR = 93,     /**< @brief  - SONY XAVC 4K Intra VBR Class 100 for XD Style (MXF file format)                  (analogue @ref H264_XAVC_4K_INTRA_CLASS_100_VBR) */
        VideoType_XAVC_4K_INTRA_CLASS_300_VBR = 94,     /**< @brief  - SONY XAVC 4K Intra VBR Class 300 for XD Style (MXF file format)                  (analogue @ref H264_XAVC_4K_INTRA_CLASS_300_VBR) */
        VideoType_XAVC_4K_INTRA_CLASS_480_VBR = 95,     /**< @brief  - SONY XAVC 4K Intra VBR Class 480 for XD Style (MXF file format)                  (analogue @ref H264_XAVC_4K_INTRA_CLASS_480_VBR) */
        VideoType_P2_2K_INTRA_422 = 104,                /**< @brief  - Panasonic 2K Intra 4:2:2 Profile                                                 (analogue @ref H264_P2_2K_INTRA_422)             */
        VideoType_P2_4K_INTRA_422 = 105,                /**< @brief  - Panasonic 4K Intra 4:2:2 Profile                                                 (analogue @ref H264_P2_4K_INTRA_422)             */
        VideoType_P2_HD_INTRA_422 = 106,                /**< @brief  - Panasonic HD Intra 4:2:2 Profile                                                 (analogue @ref H264_P2_HD_INTRA_422)             */
        VideoType_XAVC_4K_422     = 131                 /**< @brief  - SONY XAVC Long GOP 4K 4:2:2 10-bit Profile (MXF file format)                     (analogue @ref H264_XAVC_4K_422)                 */
    } VideoType_t;

/**
* @brief Describes video pull down flags.
**/
    typedef enum VideoPullDownFlag
    {
        VideoPullDownFlag_NONE  = 0,
        VideoPullDownFlag_23    = 1,                /** @brief 23.976/24 played as 29.97/30             */
        VideoPullDownFlag_32    = 2,                /** @brief 23.976/24 played as 29.97/30             */
        VideoPullDownFlag_23_p  = 4,                /** @brief 23.976/24 played as 59.94/60             */
        VideoPullDownFlag_32_p  = 5,                /** @brief 23.976/24 played as 59.94/60             */
        VideoPullDownFlag_Auto  = 6,                /** @brief adaptive mode                            */
        VideoPullDownFlag_22_p  = 7,                /** @brief every frame is displayed twice           */
        VideoPullDownFlag_33_p  = 8                 /** @brief every frame is displayed three times     */

    } VideoPullDownFlag_t;

/**
* @brief Describes intra refresh mode.
**/	
    typedef enum IntraRefreshMode
    {
        IntraRefreshMode_Off    = 0,                 /**< @brief  do not use AIR (default analogue @ref H264_AIR_OFF)   */
        IntraRefreshMode_Slow   = 1,                 /**< @brief  1 (SD) or 2 (HD) rows (analogue @ref H264_AIR_SLOW)   */
        IntraRefreshMode_Medium = 2,                 /**< @brief  2 (SD) or 4 (HD) rows (analogue @ref H264_AIR_MEDIUM  */
        IntraRefreshMode_Fast   = 3                  /**< @brief  3 (SD) or 6 (HD) rows (analogue @ref H264_AIR_FAST)   */
    } IntraRefreshMode_t;

    /**
    * @brief Describes format of output frame
    **/
    typedef enum InterlaceMode
    {
        Progressive_frame = 0,                                  /**< @brief - Progressive frame                                      (analogue @ref H264_PROGRESSIVE)*/
        Interlaced_fields = 1,                                  /**< @brief - Interlaced - encode every frame as 2 field pictures    (analogue @ref H264_INTERLACED) */
        Interlaced_frame = 2                                    /**< @brief - Interlaced - macroblock-adaptive frame-field coding    (analogue @ref H264_MBAFF)      */

    } InterlaceMode_t;

/**
* @brief Describes motion estimation subpixel mode.
**/
    typedef enum MESubpelMode                               
    {
        MESubpelMode_FullPel    = 0,                            /**< @brief  only full pixel position will be examined (analogue @ref  H264_FULL_PEL)*/
        MESubpelMode_HalfPel    = 1,                            /**< @brief  half-pixels positions will be added to the search (analogue @ref  H264_HALF_PEL)*/
        MESubpelMode_QuarterPel = 2,                            /**< @brief  both half and quarter pixel positions will be added (analogue @ref H264_QUARTER_PEL)*/
        MESubpelMode_QuarterPelOnRef = 3                        /**< @brief  both half and quarter pixel positions will be added for reference pictures, no quarter pixel positions for non-reference pictures (analogue  @ref H264_QUARTER_PEL_ON_REF)*/

    } MESubpelMode_t;

/**
* @brief Enable/disable video scene change detection.
**/
    typedef enum VSCDMode
    {
        VSCDMode_OFF    = 0,                                    /**< @brief Disable Scene Change Detection algorithm (analogue @ref VCSD_MODE_OFF)*/
        VSCDMode_IDR    = 1                                     /**< @brief Enable  Scene Change Detection algorithm (analogue @ref VCSD_MODE_IDR)*/

    } VSCDMode_t;

/**
* @brief Describes video formats.
**/
    typedef enum VideoFormat
    {
        VideoFormat_Auto        = 0,                        /**< @brief   Auto */
        VideoFormat_PAL         = 1,                        /**< @brief   Pal (analogue to @ref H264_VF_PAL) */
        VideoFormat_NTSC        = 2,                        /**< @brief   NTSC (analogue to @ref H264_VF_NTSC) */
        VideoFormat_SECAM       = 3,                        /**< @brief   SECAM (analogue to @ref H264_VF_SECAM) */
        VideoFormat_MAC         = 4,                        /**< @brief   MAC (analogue to @ref H264_VF_MAC) */
        VideoFormat_Unspecified = 5                         /**< @brief   Unspecified   (analogue to @ref H264_VF_UNSPECIFIED) */
    } VideoFormat_t;


/**
* @brief Describes streaming type.
**/
    typedef enum StreamType
    {
        StreamTypeI = 0,                                    /**< @brief  VCL NALUs + filler data                (analogue @ref H264_STREAM_TYPE_I         ) */
        StreamTypeIplusSEI = 1,                             /**< @brief  VCL NALUs + filler data + SEI messages (analogue @ref H264_STREAM_TYPE_I_SEI     ) */
        StreamTypeII = 2,                                   /**< @brief  all NALU types                         (analogue @ref H264_STREAM_TYPE_II        ) */
        StreamTypeIIminusSEI = 3                            /**< @brief  all NALU types except SEI              (analogue @ref H264_STREAM_TYPE_II_NO_SEI ) */

    } StreamType_t;


/**
* @brief Describes CPU optimization mode.
**/
    typedef enum CpuOptimization
    {
        CPU_Auto = 0,                                       /**< @brief  SIMD instruction usage based on CPUID      (analogue @ref H264_CPU_OPT_AUTO    ) */
        CPU_PlainC = 1,                                     /**< @brief  Disables SIMD instruction usage            (analogue @ref H264_CPU_OPT_UNKNOWN ) */
        CPU_MMX = 2,                                        /**< @brief  Limits SIMD instruction usage to MMX       (analogue @ref H264_CPU_OPT_MMX     ) */
        CPU_MMX_Ext = 3,                                    /**< @brief  Limits SIMD instruction usage to MMXEXT    (analogue @ref H264_CPU_OPT_MMX_EXT ) */
        CPU_SSE = 4,                                        /**< @brief  Limits SIMD instruction usage to SSE       (analogue @ref H264_CPU_OPT_SSE     ) */
        CPU_SSE2 = 5,                                       /**< @brief  Limits SIMD instruction usage to SSE 2     (analogue @ref H264_CPU_OPT_SSE2    ) */
        CPU_SSE3 = 6,                                       /**< @brief  Limits SIMD instruction usage to SSSE 3    (analogue @ref H264_CPU_OPT_SSE3    ) */
        CPU_SSE4 = 7,                                       /**< @brief  Limits SIMD instruction usage to SSE4.1    (analogue @ref H264_CPU_OPT_SSE4    ) */
        CPU_AVX = 8,                                        /**< @brief  Limits SIMD instruction usage to AVX       (analogue @ref H264_CPU_OPT_AVX     ) */
        CPU_AVX2 = 9                                        /**< @brief  Limits SIMD instruction usage to AVX 2     (analogue @ref H264_CPU_OPT_AVX2    ) */

    } CpuOptimization_t;


/**
* @brief Describes Frame Packing Arrangement Mode.
**/
    typedef enum FPAMode
    {
        FPA_Diasable = 0,                                       /**< @brief Don`t write frame packing arrangement SEI messages  (analogue @ref H264_FPAM_DONT_WRITE         ) */
        FPA_Checkboard = 1,                                     /**< @brief Checkboard                                          (analogue @ref H264_FPAM_CHECKBOARD         ) */
        FPA_Column = 2,                                         /**< @brief Column based interleaving                           (analogue @ref H264_FPAM_COLUMN_INTERLEAVING) */
        FPA_Row = 3,                                            /**< @brief Row based interleaving                              (analogue @ref H264_FPAM_ROW_INTERLEAVING   ) */
        FPA_Side_by_syde = 4,                                   /**< @brief Side-by-Side packing arrangement                    (analogue @ref H264_FPAM_SIDE_BY_SIDE       ) */
        FPA_Tob_buttom = 5                                      /**< @brief Top-Bottom packing arrangement                      (analogue @ref H264_FPAM_TOP_BOTTOM         ) */
    } FPAMode_t;

/**
* @brief Describes quantization mode. (affect quantization matrices)
**/
    typedef enum QuantMode
    {
        QuantMode_Ref = 0,                                      /**< Reference quantization */
        QuantMode_Mode1 = 1,                                    /**< Do not change reference quantization matrices (it is the same as QuantMode_Ref now)  */
        QuantMode_Mode2 = 2                                     /**< @brief Deadzoning of inter coeffs for higher QPs */
    } QuantMode_t;


/**
* @brief Describes FPS conversion types.
**/
    typedef enum FpsConvType
    {
        FpscType_Fps        = 0,                                   /**< @brief Based on frame rate information from connection media type  */
        FpscType_Timestamps = 1                                    /**< @brief Based on sample time stamps                                 */

    } FpsConvType_t;

/**
* @brief Describes parameter writing for HRD.
**/
    typedef enum HrdParamWriting
    {
        HRD_None    = 0,                                            /**< @brief Do not write HRD parameters */
        HRD_NAL     = 1,                                            /**< @brief Write NAL HRD parameters only*/
        HRD_VCL     = 2,                                            /**< @brief Write VCL HRD parameters only*/
        HRD_Both    = 3                                             /**< @brief NAL and VCL HRD parameters */

    } HrdParamWriting_t;

/**
* @brief Describes Time stamp mode.
**/
    typedef enum TimestampMode
    {
        TSMode_Original = 0,    /**< @brief Do not adjust, use exact input timestamps                                                       */
        TSMode_AVI      = 1     /**< @brief AVI-compatibility mode - ascending, non-overlapping timestamps (must exist for every sample)    */

    } TimestampMode_t;

/**
* @brief Describes encoder output media type.
**/
    typedef enum OutputMediatype
    {
        OutMT_Original = 0,     /**< @brief regular one */
        OutMT_VSS      = 1      /**< @brief VSSH fourCC */

    } OutputMediatype_t;


    typedef int (* setMediaTypeCallback)(PIN_DIRECTION direction, const CMediaType * pmt);
    typedef int (* startCallback)(h264_v_settings * enc_settings);
    typedef int (* receiveCallback)(IMediaSample * psample, h264_user_data_tt ** seq_ud, h264_user_data_tt ** pic_ud);

/**
* @brief Describes Callback methods.
**/
    typedef struct
    {
        setMediaTypeCallback    onSetMediaType;
        startCallback           onStartStreaming;
        receiveCallback         onReceive;

    } h264_dshow_callback_t;

};


/**
* @brief Describes SPS write method
**/
typedef enum SPSWriting
{
    SPS_IDR     = 0,             /**< @brief SPS once per IDR     */
    SPS_I       = 1              /**< @brief SPS once per I-frame */

} SPSWriting_t;


/**
* @brief Describes PPS write method
**/
typedef enum PPSWriting
{
    PPS_IDR     = 0,             /**< @brief PPS once per IDR       */
    PPS_I       = 1,             /**< @brief PPS once per I picture */
    PPS_PIC     = 2              /**< @brief PPS once per picture   */

} PPSWriting_t;


/**
* @brief Describes pixel color range conversion
**/
typedef enum pix_range_conversion_e
{
    CC_Pix_Undef = 0,            /**< @brief Auto. */
    CC_Pix_Clamp,                /**< @brief Clamp. A clamping process will be applied for a source picture. */
    CC_Pix_Declamp,              /**< @brief Declamp. A range extension process will be applied for a source picture. */
    CC_Pix_LeaveClamped,         /**< @brief Leave clamped. No range conversion process will be applied for a source picture. */
    CC_Pix_LeaveFullRange        /**< @brief Leave full. No range conversion process will be applied for a source picture. */
} pix_range_conversion_t;

//////////////////////////////////////////////////////////////////////////
//    Parameters GUIDs
//////////////////////////////////////////////////////////////////////////
/**
* @name Parameters GUIDs
* @{
**/

/**
<dl><dt><b>GUID:</b></dt><dd>
{F8A1E96D-A489-4ec1-9418-8B7D048364EF}
</dd></dl>
<dl><dt><b>Description:</b></dt><dd>
Specifies video format.
</dd></dl>
<dl><dt><b>Type:</b></dt><dd>
VT_INT
</dd></dl>
*/
static const GUID EH264VE_VideoFormat =
{0xf8a1e96d, 0xa489, 0x4ec1, {0x94, 0x18, 0x8b, 0x7d, 0x4, 0x83, 0x64, 0xef}};


/**
<dl><dt><b>GUID:</b></dt><dd>
{7CD6EF75-4420-4b77-BC22-4158B3F98956}
</dd></dl>
<dl><dt><b>Description:</b></dt><dd>
Interlace mode. Value should be equal one of H264VE::InterlaceMode_t value.
</dd></dl>
<dl><dt><b>Type:</b></dt><dd>
VT_INT
</dd></dl>
*/
static const GUID EH264VE_interlace_mode =
{0x7cd6ef75, 0x4420, 0x4b77, {0xbc, 0x22, 0x41, 0x58, 0xb3, 0xf9, 0x89, 0x56}};


/**
<dl><dt><b>GUID:</b></dt><dd>
{749C8599-F66A-4161-B640-9B8B75D62EBD}
</dd></dl>
<dl><dt><b>Description:</b></dt><dd>
Specifies field order in output video stream.
</dd></dl>
<dl><dt><b>Type:</b></dt><dd>
VT_INT
</dd></dl>
*/
static const GUID EH264VE_field_order =
{0x749c8599, 0xf66a, 0x4161, {0xb6, 0x40, 0x9b, 0x8b, 0x75, 0xd6, 0x2e, 0xbd}};


/**
<dl><dt><b>GUID:</b></dt><dd>
{6DFB21B7-9F43-4ccb-81BF-5723B10E0533}
</dd></dl>
<dl><dt><b>Description:</b></dt><dd>
Specifies video pulldown mode
</dd></dl>
<dl><dt><b>Type:</b></dt><dd>
VT_INT
</dd></dl>
*/
static const GUID EH264VE_video_pulldown_flag =
{0x6dfb21b7, 0x9f43, 0x4ccb, {0x81, 0xbf, 0x57, 0x23, 0xb1, 0xe, 0x5, 0x33}};


/**
<dl><dt><b>GUID:</b></dt><dd>
{F519F267-3B17-481f-9F35-43CCA48FD098}
</dd></dl>
<dl><dt><b>Description:</b></dt><dd>
Number of slices per picture.
</dd></dl>
<dl><dt><b>Type:</b></dt><dd>
VT_INT
</dd></dl>
*/
static const GUID EH264VE_slice_arg =
{0xf519f267, 0x3b17, 0x481f, {0x9f, 0x35, 0x43, 0xcc, 0xa4, 0x8f, 0xd0, 0x98}};


/**
<dl><dt><b>GUID:</b></dt><dd>
{EECB285C-BDE6-4da5-9A9E-4C366BCACD94}
</dd></dl>
<dl><dt><b>Description:</b></dt><dd>
Specifies IDR frames frequency.
</dd></dl>
<dl><dt><b>Type:</b></dt><dd>
VT_INT
</dd></dl>
*/
static const GUID EH264VE_idr_frequency =
{0xeecb285c, 0xbde6, 0x4da5, {0x9a, 0x9e, 0x4c, 0x36, 0x6b, 0xca, 0xcd, 0x94}};

/**
<dl><dt><b>GUID:</b></dt><dd>
{9EAFCA29-42F3-4ca5-B40C-6B87B2AD4483}
</dd></dl>
<dl><dt><b>Description:</b></dt><dd>
Specifies minimal distance between I-frames
</dd></dl>
<dl><dt><b>Type:</b></dt><dd>
VT_INT
</dd></dl>
*/
static const GUID EH264VE_gop_min_length =
{0x9eafca29, 0x42f3, 0x4ca5, {0xb4, 0xc, 0x6b, 0x87, 0xb2, 0xad, 0x44, 0x83}};


/**
<dl><dt><b>GUID:</b></dt><dd>
{90E40368-D85C-4139-8540-82A58C12B4C8}
</dd></dl>
<dl><dt><b>Description:</b></dt><dd>
Enable/Disable reference B-frames
</dd></dl>
<dl><dt><b>Type:</b></dt><dd>
VT_INT
</dd></dl>
*/
static const GUID EH264VE_b_slice_reference =
{0x90e40368, 0xd85c, 0x4139, {0x85, 0x40, 0x82, 0xa5, 0x8c, 0x12, 0xb4, 0xc8}};


/**
<dl><dt><b>GUID:</b></dt><dd>
{A3A30C66-9B00-44b0-827E-ABBC3BB0E4F4}
</dd></dl>
<dl><dt><b>Description:</b></dt><dd>
Enable/Disable pyramid encoding
</dd></dl>
<dl><dt><b>Type:</b></dt><dd>
VT_INT
</dd></dl>
*/
static const GUID EH264VE_b_slice_pyramid =
{0xa3a30c66, 0x9b00, 0x44b0, {0x82, 0x7e, 0xab, 0xbc, 0x3b, 0xb0, 0xe4, 0xf4}};

/**
<dl><dt><b>GUID:</b></dt><dd>
{956A704B-00FC-436c-921E-BC6158955A82}
</dd></dl>
<dl><dt><b>Description:</b></dt><dd>
Enables / disables adaptive using of B frames in order to provide the best compression
</dd></dl>
<dl><dt><b>Type:</b></dt><dd>
VT_INT
</dd></dl>
*/
static const GUID EH264VE_adapt_b =
{0x956a704b, 0xfc, 0x436c, {0x92, 0x1e, 0xbc, 0x61, 0x58, 0x95, 0x5a, 0x82}};

/**
<dl><dt><b>GUID:</b></dt><dd>
{CBFC3E4B-4E06-4ce1-9088-866CC96433FE}
</dd></dl>
<dl><dt><b>Description:</b></dt><dd>
Enable/Disable Scene Change Detection algorithm
</dd></dl>
<dl><dt><b>Type:</b></dt><dd>
VT_INT
</dd></dl>
*/
static const GUID EH264VE_vcsd_mode =
{0xcbfc3e4b, 0x4e06, 0x4ce1, {0x90, 0x88, 0x86, 0x6c, 0xc9, 0x64, 0x33, 0xfe}};


/**
<dl><dt><b>GUID:</b></dt><dd>
{F630A138-8661-4e3a-BF03-955F973AB110}
</dd></dl>
<dl><dt><b>Description:</b></dt><dd>
Specifies quantizers for I-frames
</dd></dl>
<dl><dt><b>Type:</b></dt><dd>
VT_INT
</dd></dl>
*/
static const GUID EH264VE_quant_pI =
{0xf630a138, 0x8661, 0x4e3a, {0xbf, 0x3, 0x95, 0x5f, 0x97, 0x3a, 0xb1, 0x10}};


/**
<dl><dt><b>GUID:</b></dt><dd>
{10E2FDCC-1FB5-4cbc-BB5E-75567AB39F69}
</dd></dl>
<dl><dt><b>Description:</b></dt><dd>
Specifies quantizers for P-frames
</dd></dl>
<dl><dt><b>Type:</b></dt><dd>
VT_INT
</dd></dl>
*/
static const GUID EH264VE_quant_pP =
{0x10e2fdcc, 0x1fb5, 0x4cbc, {0xbb, 0x5e, 0x75, 0x56, 0x7a, 0xb3, 0x9f, 0x69}};


/**
<dl><dt><b>GUID:</b></dt><dd>
{901DA7FD-F639-493f-8AD0-9492AEA72E1F}
</dd></dl>
<dl><dt><b>Description:</b></dt><dd>
Specifies quantizers for B-frames
</dd></dl>
<dl><dt><b>Type:</b></dt><dd>
VT_INT
</dd></dl>
*/
static const GUID EH264VE_quant_pB =
{0x901da7fd, 0xf639, 0x493f, {0x8a, 0xd0, 0x94, 0x92, 0xae, 0xa7, 0x2e, 0x1f}};

/**
<dl><dt><b>GUID:</b></dt><dd>
{522E3FE7-BED0-4bfa-B085-5ECE0B692CD0}
</dd></dl>
<dl><dt><b>Description:</b></dt><dd>
Specifies minimal values for quantizers
</dd></dl>
<dl><dt><b>Type:</b></dt><dd>
VT_INT
</dd></dl>
*/
static const GUID EH264VE_quant_min =
{0x522e3fe7, 0xbed0, 0x4bfa, {0xb0, 0x85, 0x5e, 0xce, 0xb, 0x69, 0x2c, 0xd0}};


/**
<dl><dt><b>GUID:</b></dt><dd>
{8D9B7175-1EB3-4f8d-A290-9415AC5BCBED}
</dd></dl>
<dl><dt><b>Description:</b></dt><dd>
Specifies maximal values for quantizers
</dd></dl>
<dl><dt><b>Type:</b></dt><dd>
VT_INT
</dd></dl>
*/
static const GUID EH264VE_quant_max =
{0x8d9b7175, 0x1eb3, 0x4f8d, {0xa2, 0x90, 0x94, 0x15, 0xac, 0x5b, 0xcb, 0xed}};


/**
<dl><dt><b>GUID:</b></dt><dd>
{7EAD13ED-47B2-4030-8C14-1BAB66A02BA3}
</dd></dl>
<dl><dt><b>Description:</b></dt><dd>
Specifies the chroma Cb quantization offset. Used only for High profiles.
</dd></dl>
<dl><dt><b>Type:</b></dt><dd>
VT_INT
</dd></dl>
*/
static const GUID EH264VE_cb_offset =
{0x7ead13ed, 0x47b2, 0x4030, {0x8c, 0x14, 0x1b, 0xab, 0x66, 0xa0, 0x2b, 0xa3}};


/**
<dl><dt><b>GUID:</b></dt><dd>
{B4B009D0-E793-43e9-95A5-6D5D5C86E093}
</dd></dl>
<dl><dt><b>Description:</b></dt><dd>
Specifies the chroma Cr quantization offset. Used only for High profiles.
</dd></dl>
<dl><dt><b>Type:</b></dt><dd>
VT_INT
</dd></dl>
*/
static const GUID EH264VE_cr_offset =
{0xb4b009d0, 0xe793, 0x43e9, {0x95, 0xa5, 0x6d, 0x5d, 0x5c, 0x86, 0xe0, 0x93}};

/**
<dl><dt><b>GUID:</b></dt><dd>
{76B17FDA-A1DA-45a3-B50E-4A2A2B35D108}
</dd></dl>
<dl><dt><b>Description:</b></dt><dd>
Specifies the bitrate buffer size (in bytes)
</dd></dl>
<dl><dt><b>Type:</b></dt><dd>
VT_INT
</dd></dl>
*/
static const GUID EH264VE_bit_rate_buffer_size =
{0x76b17fda, 0xa1da, 0x45a3, {0xb5, 0xe, 0x4a, 0x2a, 0x2b, 0x35, 0xd1, 0x8}};

/**
<dl><dt><b>GUID:</b></dt><dd>
{770776A5-76AF-4aa7-A7DA-CCB700945ABE}
</dd></dl>
<dl><dt><b>Description:</b></dt><dd>
Specifies the initial state of the HRD buffer.
</dd></dl>
<dl><dt><b>Type:</b></dt><dd>
VT_INT
</dd></dl>
*/
static const GUID EH264VE_vbv_buffer_fullness =
{0x770776a5, 0x76af, 0x4aa7, {0xa7, 0xda, 0xcc, 0xb7, 0x0, 0x94, 0x5a, 0xbe}};

/**
<dl><dt><b>GUID:</b></dt><dd>
{B419761A-839F-4df7-85F8-E0FB2CC5D81F}
</dd></dl>
<dl><dt><b>Description:</b></dt><dd>
Specifies the desired state of the HRD buffer in the end of encoding.
</dd></dl>
<dl><dt><b>Type:</b></dt><dd>
VT_INT
</dd></dl>
*/
static const GUID EH264VE_vbv_buffer_fullness_trg =
{0xb419761a, 0x839f, 0x4df7, {0x85, 0xf8, 0xe0, 0xfb, 0x2c, 0xc5, 0xd8, 0x1f}};

/**
<dl><dt><b>GUID:</b></dt><dd>
{C783DD2B-610E-4c4d-B7C6-93EAA66B6100}
</dd></dl>
<dl><dt><b>Description:</b></dt><dd>
Specifies the maximal allowed size of encoded I-frame.
</dd></dl>
<dl><dt><b>Type:</b></dt><dd>
VT_INT
</dd></dl>
*/
static const GUID EH264VE_max_frame_size_i =
{0xc783dd2b, 0x610e, 0x4c4d, {0xb7, 0xc6, 0x93, 0xea, 0xa6, 0x6b, 0x61, 0x00}};

/**
<dl><dt><b>GUID:</b></dt><dd>
{C783DD2B-610E-4c4d-B7C6-93EAA66B6101}
</dd></dl>
<dl><dt><b>Description:</b></dt><dd>
Specifies the maximal allowed size of encoded P-frame.
</dd></dl>
<dl><dt><b>Type:</b></dt><dd>
VT_INT
</dd></dl>
*/
static const GUID EH264VE_max_frame_size_p =
{0xc783dd2b, 0x610e, 0x4c4d, {0xb7, 0xc6, 0x93, 0xea, 0xa6, 0x6b, 0x61, 0x01}};

/**
<dl><dt><b>GUID:</b></dt><dd>
{C783DD2B-610E-4c4d-B7C6-93EAA66B6102}
</dd></dl>
<dl><dt><b>Description:</b></dt><dd>
Specifies the maximal allowed size of encoded B-frame.
</dd></dl>
<dl><dt><b>Type:</b></dt><dd>
VT_INT
</dd></dl>
*/
static const GUID EH264VE_max_frame_size_b =
{0xc783dd2b, 0x610e, 0x4c4d, {0xb7, 0xc6, 0x93, 0xea, 0xa6, 0x6b, 0x61, 0x02}};


/**
<dl><dt><b>GUID:</b></dt><dd>
{C783DD2B-610E-4c4d-B7C6-93EAA66B6103}
</dd></dl>
<dl><dt><b>Description:</b></dt><dd>
Specifies the maximal allowed size of encoded reference B-frame.
</dd></dl>
<dl><dt><b>Type:</b></dt><dd>
VT_INT
</dd></dl>
*/
static const GUID EH264VE_max_frame_size_bref =
{0xc783dd2b, 0x610e, 0x4c4d, {0xb7, 0xc6, 0x93, 0xea, 0xa6, 0x6b, 0x61, 0x03}};


/**
<dl><dt><b>GUID:</b></dt><dd>
{24A9A884-C4A0-4b5c-ACB3-212B3DBD7E04}
</dd></dl>
<dl><dt><b>Description:</b></dt><dd>
Specifies the maximal allowed range for motion estimation algorithm
</dd></dl>
<dl><dt><b>Type:</b></dt><dd>
VT_INT
</dd></dl>
*/
static const GUID EH264VE_search_range =
{0x24a9a884, 0xc4a0, 0x4b5c, {0xac, 0xb3, 0x21, 0x2b, 0x3d, 0xbd, 0x7e, 0x4}};


/**
<dl><dt><b>GUID:</b></dt><dd>
{79686095-968E-4ce8-9247-6633F6F8DA3C}
</dd></dl>
<dl><dt><b>Description:</b></dt><dd>
Specifies the maximal number of reference frames in DPB
</dd></dl>
<dl><dt><b>Type:</b></dt><dd>
VT_INT
</dd></dl>
*/
static const GUID EH264VE_num_reference_frames =
{0x79686095, 0x968e, 0x4ce8, {0x92, 0x47, 0x66, 0x33, 0xf6, 0xf8, 0xda, 0x3c}};

/**
<dl><dt><b>GUID:</b></dt><dd>
{8BC69F4F-6BE5-4fd7-90AE-D58DB21851A3}
</dd></dl>
<dl><dt><b>Description:</b></dt><dd>
Specifies whether to use sub-block search in motion estimation or not.
</dd></dl>
<dl><dt><b>Type:</b></dt><dd>
VT_INT
</dd></dl>
*/
static const GUID EH264VE_inter_search_shape =
{0x8bc69f4f, 0x6be5, 0x4fd7, {0x90, 0xae, 0xd5, 0x8d, 0xb2, 0x18, 0x51, 0xa3}};


/**
<dl><dt><b>GUID:</b></dt><dd>
{8A5932D3-8860-454a-8A5B-4AE914AFE6E5}
</dd></dl>
<dl><dt><b>Description:</b></dt><dd>
Specifies motion estimation sub-pixel depth. 
</dd></dl>
<dl><dt><b>Type:</b></dt><dd>
VT_INT
</dd></dl>
*/
static const GUID EH264VE_me_subpel_mode =
{0x8a5932d3, 0x8860, 0x454a, {0x8a, 0x5b, 0x4a, 0xe9, 0x14, 0xaf, 0xe6, 0xe5}};


/**
<dl><dt><b>GUID:</b></dt><dd>
{FED84B7F-2006-4c6d-A49B-F1C0FE6A4F6F}
</dd></dl>
<dl><dt><b>Description:</b></dt><dd>
Enable/Disable weighted prediction for P-frames
</dd></dl>
<dl><dt><b>Type:</b></dt><dd>
VT_INT
</dd></dl>
*/
static const GUID EH264VE_me_weighted_p_mode =
{0xfed84b7f, 0x2006, 0x4c6d, {0xa4, 0x9b, 0xf1, 0xc0, 0xfe, 0x6a, 0x4f, 0x6f}};

/**
<dl><dt><b>GUID:</b></dt><dd>
{4DBD1CCE-6777-410E-9DCE-01600FBD4CE6}
</dd></dl>
<dl><dt><b>Description:</b></dt><dd>
Enable/Disable weighted prediction for B-frames
</dd></dl>
<dl><dt><b>Type:</b></dt><dd>
VT_INT
</dd></dl>
*/
static const GUID EH264VE_me_weighted_b_mode = 
{ 0x4dbd1cce, 0x6777, 0x410e, { 0x9d, 0xce, 0x1, 0x60, 0xf, 0xbd, 0x4c, 0xe6 } };


/**
<dl><dt><b>GUID:</b></dt><dd>
{52FD80EF-B814-4696-AB6A-F0BF188EAC1E}
</dd></dl>
<dl><dt><b>Description:</b></dt><dd>
Specifies the multi-reference motion estimation mode.
</dd></dl>
<dl><dt><b>Type:</b></dt><dd>
VT_INT
</dd></dl>
*/
static const GUID EH264VE_fast_multi_ref_me =
{0x52fd80ef, 0xb814, 0x4696, {0xab, 0x6a, 0xf0, 0xbf, 0x18, 0x8e, 0xac, 0x1e}};


/**
<dl><dt><b>GUID:</b></dt><dd>
{62AEEF4F-C52A-47c2-8F73-1CE7AF1B84E0}
</dd></dl>
<dl><dt><b>Description:</b></dt><dd>
Specifies the sub-block motion estimation mode.
</dd></dl>
<dl><dt><b>Type:</b></dt><dd>
VT_INT
</dd></dl>
*/
static const GUID EH264VE_fast_sub_block_me =
{0x62aeef4f, 0xc52a, 0x47c2, {0x8f, 0x73, 0x1c, 0xe7, 0xaf, 0x1b, 0x84, 0xe0}};


/**
<dl><dt><b>GUID:</b></dt><dd>
{3FCFB0A8-92B0-4273-AB86-55F8918AA64B}
</dd></dl>
<dl><dt><b>Description:</b></dt><dd>
Enables/disables the out of picture motion vectors.
</dd></dl>
<dl><dt><b>Type:</b></dt><dd>
VT_INT
</dd></dl>
*/
static const GUID EH264VE_allow_out_of_pic_mvs =
{0x3fcfb0a8, 0x92b0, 0x4273, {0xab, 0x86, 0x55, 0xf8, 0x91, 0x8a, 0xa6, 0x4b}};


/**
<dl><dt><b>GUID:</b></dt><dd>
{DE932BFB-3D4B-4b27-B81C-371560C23541}
</dd></dl>
<dl><dt><b>Description:</b></dt><dd>
Enables/disables the Intra 16x16 mode in intra slices.
</dd></dl>
<dl><dt><b>Type:</b></dt><dd>
VT_INT
</dd></dl>
*/
static const GUID EH264VE_enable_intra_big =
{0xde932bfb, 0x3d4b, 0x4b27, {0xb8, 0x1c, 0x37, 0x15, 0x60, 0xc2, 0x35, 0x41}};


/**
<dl><dt><b>GUID:</b></dt><dd>
{446D663D-161F-4c3a-8A0B-72BA3096FB2A}
</dd></dl>
<dl><dt><b>Description:</b></dt><dd>
Enables/disables the Intra 8x8 mode in intra slices.
</dd></dl>
<dl><dt><b>Type:</b></dt><dd>
VT_INT
</dd></dl>
*/
static const GUID EH264VE_enable_intra_8x8 =
{0x446d663d, 0x161f, 0x4c3a, {0x8a, 0xb, 0x72, 0xba, 0x30, 0x96, 0xfb, 0x2a}};


/**
<dl><dt><b>GUID:</b></dt><dd>
{0A4AAC0E-F7E0-4060-8C57-C290E7383E5E}
</dd></dl>
<dl><dt><b>Description:</b></dt><dd>
Enables/disables the Intra 4x4 mode in intra slices.
</dd></dl>
<dl><dt><b>Type:</b></dt><dd>
VT_INT
</dd></dl>
*/
static const GUID EH264VE_enable_intra_4x4 =
{0xa4aac0e, 0xf7e0, 0x4060, {0x8c, 0x57, 0xc2, 0x90, 0xe7, 0x38, 0x3e, 0x5e}};


/**
<dl><dt><b>GUID:</b></dt><dd>
{055AF531-B06A-4927-B029-1472067DDDFF}
</dd></dl>
<dl><dt><b>Description:</b></dt><dd>
Enables/disables the PCM mode in intra slices.
</dd></dl>
<dl><dt><b>Type:</b></dt><dd>
VT_INT
</dd></dl>
*/
static const GUID EH264VE_enable_intra_pcm =
{0x55af531, 0xb06a, 0x4927, {0xb0, 0x29, 0x14, 0x72, 0x6, 0x7d, 0xdd, 0xff}};


/**
<dl><dt><b>GUID:</b></dt><dd>
{FDCF749C-64F8-4e43-9299-6A3ED103F9FF}
</dd></dl>
<dl><dt><b>Description:</b></dt><dd>
Enables/disables the Intra 16x16 mode in inter slices.
</dd></dl>
<dl><dt><b>Type:</b></dt><dd>
VT_INT
</dd></dl>
*/
static const GUID EH264VE_enable_inter_big =
{0xfdcf749c, 0x64f8, 0x4e43, {0x92, 0x99, 0x6a, 0x3e, 0xd1, 0x3, 0xf9, 0xff}};


/**
<dl><dt><b>GUID:</b></dt><dd>
{412E3E96-0C95-4ec4-83A8-1FA4D82CE155}
</dd></dl>
<dl><dt><b>Description:</b></dt><dd>
Enables/disables the Intra 8x8 mode in inter slices.
</dd></dl>
<dl><dt><b>Type:</b></dt><dd>
VT_INT
</dd></dl>
*/
static const GUID EH264VE_enable_inter_8x8 =
{0x412e3e96, 0xc95, 0x4ec4, {0x83, 0xa8, 0x1f, 0xa4, 0xd8, 0x2c, 0xe1, 0x55}};


/**
<dl><dt><b>GUID:</b></dt><dd>
{28F1BC58-A32E-4bfd-855E-CA460634E44E}
</dd></dl>
<dl><dt><b>Description:</b></dt><dd>
Enables/disables the Intra 4x4 mode in inter slices.
</dd></dl>
<dl><dt><b>Type:</b></dt><dd>
VT_INT
</dd></dl>
*/
static const GUID EH264VE_enable_inter_4x4 =
{0x28f1bc58, 0xa32e, 0x4bfd, {0x85, 0x5e, 0xca, 0x46, 0x6, 0x34, 0xe4, 0x4e}};


/**
<dl><dt><b>GUID:</b></dt><dd>
{AED18519-8B8B-4676-88C3-1E6A136F767D}
</dd></dl>
<dl><dt><b>Description:</b></dt><dd>
Enables/disables the PCM mode in inter slices.
</dd></dl>
<dl><dt><b>Type:</b></dt><dd>
VT_INT
</dd></dl>
*/
static const GUID EH264VE_enable_inter_pcm =
{0xaed18519, 0x8b8b, 0x4676, {0x88, 0xc3, 0x1e, 0x6a, 0x13, 0x6f, 0x76, 0x7d}};


/**
<dl><dt><b>GUID:</b></dt><dd>
{5FB3CC3C-67D6-42f6-AA9C-6AC05093661E}
</dd></dl>
<dl><dt><b>Description:</b></dt><dd>
Enables/disables deblocking filter
</dd></dl>
<dl><dt><b>Type:</b></dt><dd>
VT_INT
</dd></dl>
*/
static const GUID EH264VE_use_deblocking_filter =
{0x5fb3cc3c, 0x67d6, 0x42f6, {0xaa, 0x9c, 0x6a, 0xc0, 0x50, 0x93, 0x66, 0x1e}};


/**
<dl><dt><b>GUID:</b></dt><dd>
{37882133-CAF5-4373-8F52-BA30068A704A}
</dd></dl>
<dl><dt><b>Description:</b></dt><dd>
In-loop deblocking alpha c0 offset
</dd></dl>
<dl><dt><b>Type:</b></dt><dd>
VT_INT
</dd></dl>
*/
static const GUID EH264VE_deblocking_alphaC0_offset =
{0x37882133, 0xcaf5, 0x4373, {0x8f, 0x52, 0xba, 0x30, 0x6, 0x8a, 0x70, 0x4a}};


/**
<dl><dt><b>GUID:</b></dt><dd>
{F3049DC2-D2AD-484a-B2B9-4208051AFCB2}
</dd></dl>
<dl><dt><b>Description:</b></dt><dd>
In-loop deblocking beta offset
</dd></dl>
<dl><dt><b>Type:</b></dt><dd>
VT_INT
</dd></dl>
*/
static const GUID EH264VE_deblocking_beta_offset =
{0xf3049dc2, 0xd2ad, 0x484a, {0xb2, 0xb9, 0x42, 0x8, 0x5, 0x1a, 0xfc, 0xb2}};


/**
<dl><dt><b>GUID:</b></dt><dd>
{39178668-4FF1-4991-A76B-1B6D54F709B2}
</dd></dl>
<dl><dt><b>Description:</b></dt><dd>
Specifies entropy coding mode (CABAC or CAVLC)
</dd></dl>
<dl><dt><b>Type:</b></dt><dd>
VT_INT
</dd></dl>
*/
static const GUID EH264VE_entropy_coding_mode =
{0x39178668, 0x4ff1, 0x4991, {0xa7, 0x6b, 0x1b, 0x6d, 0x54, 0xf7, 0x9, 0xb2}};


/**
<dl><dt><b>GUID:</b></dt><dd>
{9E63E1BB-08E3-42be-87CE-05D2F770361E}
</dd></dl>
<dl><dt><b>Description:</b></dt><dd>
Enable/Disable rate-distortion optimization
</dd></dl>
<dl><dt><b>Type:</b></dt><dd>
VT_INT
</dd></dl>
*/
static const GUID EH264VE_rd_optimization =
{0x9e63e1bb, 0x8e3, 0x42be, {0x87, 0xce, 0x5, 0xd2, 0xf7, 0x70, 0x36, 0x1e}};

/**
<dl><dt><b>GUID:</b></dt><dd>
{48698A0E-D675-46b6-86EF-3D4E2C3ECAC3}
</dd></dl>
<dl><dt><b>Description:</b></dt><dd>
Enable/Disable fast rate-dostortion optimization mode
</dd></dl>
<dl><dt><b>Type:</b></dt><dd>
VT_INT
</dd></dl>
*/
static const GUID EH264VE_fast_rd_optimization =
{0x48698a0e, 0xd675, 0x46b6, {0x86, 0xef, 0x3d, 0x4e, 0x2c, 0x3e, 0xca, 0xc3}};


/**
<dl><dt><b>GUID:</b></dt><dd>
{29D87C71-49A4-4f67-B90D-BA821B58FE22}
</dd></dl>
<dl><dt><b>Description:</b></dt><dd>
Enable/Disable hadamard transform
</dd></dl>
<dl><dt><b>Type:</b></dt><dd>
VT_INT
</dd></dl>
*/
static const GUID EH264VE_use_hadamard_transform =
{0x29d87c71, 0x49a4, 0x4f67, {0xb9, 0xd, 0xba, 0x82, 0x1b, 0x58, 0xfe, 0x22}};


/**
<dl><dt><b>GUID:</b></dt><dd>
{2FE6D1AB-E54C-4afe-9566-44EEFBDFE321}
</dd></dl>
<dl><dt><b>Description:</b></dt><dd>
Enable/Disable fast inter decisions
</dd></dl>
<dl><dt><b>Type:</b></dt><dd>
VT_INT
</dd></dl>
*/
static const GUID EH264VE_enable_fast_inter_decisions =
{0x2fe6d1ab, 0xe54c, 0x4afe, {0x95, 0x66, 0x44, 0xee, 0xfb, 0xdf, 0xe3, 0x21}};


/**
<dl><dt><b>GUID:</b></dt><dd>
{51BB55A6-D4AA-4d3a-AED4-D3DC2C61851C}
</dd></dl>
<dl><dt><b>Description:</b></dt><dd>
Enable/Disable fast intra decisions
</dd></dl>
<dl><dt><b>Type:</b></dt><dd>
VT_INT
</dd></dl>
*/
static const GUID EH264VE_enable_fast_intra_decisions =
{0x51bb55a6, 0xd4aa, 0x4d3a, {0xae, 0xd4, 0xd3, 0xdc, 0x2c, 0x61, 0x85, 0x1c}};


/**
<dl><dt><b>GUID:</b></dt><dd>
{BBE49AA7-8ABA-4fd6-804D-00D129DCC458}
</dd></dl>
<dl><dt><b>Description:</b></dt><dd>
Specifies quantization mode
</dd></dl>
<dl><dt><b>Type:</b></dt><dd>
VT_INT
</dd></dl>
*/
static const GUID EH264VE_quant_mode =
{0xbbe49aa7, 0x8aba, 0x4fd6, {0x80, 0x4d, 0x0, 0xd1, 0x29, 0xdc, 0xc4, 0x58}};


/**
<dl><dt><b>GUID:</b></dt><dd>
{11716019-B4C8-4947-A1CF-49D373CDBEAE}
</dd></dl>
<dl><dt><b>Description:</b></dt><dd>
Specifies film-grain optimization algorithm streng 
</dd></dl>
<dl><dt><b>Type:</b></dt><dd>
VT_INT
</dd></dl>
*/
static const GUID EH264VE_fgo_strength =
{0x11716019, 0xb4c8, 0x4947, {0xa1, 0xcf, 0x49, 0xd3, 0x73, 0xcd, 0xbe, 0xae}};

/**
<dl><dt><b>GUID:</b></dt><dd>
{E3ABEECF-D068-41bc-8FC2-A99A5EAA08C1}
</dd></dl>
<dl><dt><b>Description:</b></dt><dd>
Enable/Disable Sample Aspect Ratio
</dd></dl>
<dl><dt><b>Type:</b></dt><dd>
VT_INT
</dd></dl>
*/
static const GUID EH264VE_use_sample_aspect_ratio =
{0xe3abeecf, 0xd068, 0x41bc, {0x8f, 0xc2, 0xa9, 0x9a, 0x5e, 0xaa, 0x8, 0xc1}};


/**
<dl><dt><b>GUID:</b></dt><dd>
{B80A21B6-5DE1-4676-9D3C-2F9B5D074444}
</dd></dl>
<dl><dt><b>Description:</b></dt><dd>
Enable/Disable automatic values of Picture Aspect Ratio
</dd></dl>
<dl><dt><b>Type:</b></dt><dd>
VT_INT
</dd></dl>
*/
static const GUID EH264VE_auto_aspect_ratio =
{0xb80a21b6, 0x5de1, 0x4676, {0x9d, 0x3c, 0x2f, 0x9b, 0x5d, 0x7, 0x44, 0x44}};

/**
<dl><dt><b>GUID:</b></dt><dd>
{93055399-DC58-4917-B206-88976B7BADEA}
</dd></dl>
<dl><dt><b>Description:</b></dt><dd>
Specifies Picture Aspect Ratio width
</dd></dl>
<dl><dt><b>Type:</b></dt><dd>
VT_INT
</dd></dl>
*/
static const GUID EH264VE_aspect_ratioX =
{0x93055399, 0xdc58, 0x4917, {0xb2, 0x6, 0x88, 0x97, 0x6b, 0x7b, 0xad, 0xea}};

/**
<dl><dt><b>GUID:</b></dt><dd>
{4B844BD8-5B63-44df-9FF7-EE544AC19D85}
</dd></dl>
<dl><dt><b>Description:</b></dt><dd>
Specifies Picture Aspect Ratio height
</dd></dl>
<dl><dt><b>Type:</b></dt><dd>
VT_INT
</dd></dl>
*/
static const GUID EH264VE_aspect_ratioY =
{0x4b844bd8, 0x5b63, 0x44df, {0x9f, 0xf7, 0xee, 0x54, 0x4a, 0xc1, 0x9d, 0x85}};

/**
<dl><dt><b>GUID:</b></dt><dd>
{598C7279-6AE2-4b3e-947C-6DA0C69F3A01}
</dd></dl>
<dl><dt><b>Description:</b></dt><dd>
Enable/Disable automatic values of Sample Aspect Ratio
</dd></dl>
<dl><dt><b>Type:</b></dt><dd>
VT_INT
</dd></dl>
*/
static const GUID EH264VE_auto_sample_aspect_ratio =
{0x598c7279, 0x6ae2, 0x4b3e, {0x94, 0x7c, 0x6d, 0xa0, 0xc6, 0x9f, 0x3a, 0x1}};


/**
<dl><dt><b>GUID:</b></dt><dd>
{80B714D9-EDCD-4cd5-AED7-20FC376B1DA5}
</dd></dl>
<dl><dt><b>Description:</b></dt><dd>
Specifies Sample Aspect Ratio width
</dd></dl>
<dl><dt><b>Type:</b></dt><dd>
VT_INT
</dd></dl>
*/
static const GUID EH264VE_sample_aspect_ratioX =
{0x80b714d9, 0xedcd, 0x4cd5, {0xae, 0xd7, 0x20, 0xfc, 0x37, 0x6b, 0x1d, 0xa5}};


/**
<dl><dt><b>GUID:</b></dt><dd>
{603B2F96-C82F-4610-ADE3-4F2BA9C7BD33}
</dd></dl>
<dl><dt><b>Description:</b></dt><dd>
Specifies Sample Aspect Ratio height
</dd></dl>
<dl><dt><b>Type:</b></dt><dd>
VT_INT
</dd></dl>
*/
static const GUID EH264VE_sample_aspect_ratioY =
{0x603b2f96, 0xc82f, 0x4610, {0xad, 0xe3, 0x4f, 0x2b, 0xa9, 0xc7, 0xbd, 0x33}};

/**
<dl><dt><b>GUID:</b></dt><dd>
{87149611-0FA3-469C-9903-8C759EB26169}
</dd></dl>
<dl><dt><b>Description:</b></dt><dd>
Enable/Disable extended values of Sample Aspect Ratio
</dd></dl>
<dl><dt><b>Type:</b></dt><dd>
VT_INT
</dd></dl>
*/
static const GUID EH264VE_enable_extended_sample_aspect_ratio = 
{ 0x87149611, 0xfa3, 0x469c, { 0x99, 0x3, 0x8c, 0x75, 0x9e, 0xb2, 0x61, 0x69 } };


/**
<dl><dt><b>GUID:</b></dt><dd>
{A541970F-4E41-4c81-9CC7-0B2BE385691C}
</dd></dl>
<dl><dt><b>Description:</b></dt><dd>
Specifies stream type
</dd></dl>
<dl><dt><b>Type:</b></dt><dd>
VT_INT
</dd></dl>
*/
static const GUID EH264VE_stream_type =
{0xa541970f, 0x4e41, 0x4c81, {0x9c, 0xc7, 0xb, 0x2b, 0xe3, 0x85, 0x69, 0x1c}};


/**
<dl><dt><b>GUID:</b></dt><dd>
{4E9B99A5-A388-452a-9B2D-C26B1230B210}
</dd></dl>
<dl><dt><b>Description:</b></dt><dd>
Specifies color full range flag
</dd></dl>
<dl><dt><b>Type:</b></dt><dd>
VT_INT
</dd></dl>
*/
static const GUID EH264VE_video_full_range =
{0x4e9b99a5, 0xa388, 0x452a, {0x9b, 0x2d, 0xc2, 0x6b, 0x12, 0x30, 0xb2, 0x10}};


/**
<dl><dt><b>GUID:</b></dt><dd>
{4586F612-A991-4010-8414-14763B3527F4}
</dd></dl>
<dl><dt><b>Description:</b></dt><dd>
Enables/Disables access units writing in output stream
</dd></dl>
<dl><dt><b>Type:</b></dt><dd>
VT_INT
</dd></dl>
*/
static const GUID EH264VE_write_au_delimiters =
{0x4586f612, 0xa991, 0x4010, {0x84, 0x14, 0x14, 0x76, 0x3b, 0x35, 0x27, 0xf4}};


/**
<dl><dt><b>GUID:</b></dt><dd>
{10AD7FE6-D3ED-4238-803B-630DBF7E8B0A}
</dd></dl>
<dl><dt><b>Description:</b></dt><dd>
Enables/Disables end of sequence code writing in output stream
</dd></dl>
<dl><dt><b>Type:</b></dt><dd>
VT_INT
</dd></dl>
*/
static const GUID EH264VE_write_seq_end_code =
{0x10ad7fe6, 0xd3ed, 0x4238, {0x80, 0x3b, 0x63, 0xd, 0xbf, 0x7e, 0x8b, 0xa}};


/**
<dl><dt><b>GUID:</b></dt><dd>
{C8CA406B-8220-4070-B5BE-1E27E4079147}
</dd></dl>
<dl><dt><b>Description:</b></dt><dd>
Enables/Disables timestamp SEI message writing in output stream
</dd></dl>
<dl><dt><b>Type:</b></dt><dd>
VT_INT
</dd></dl>
*/
static const GUID EH264VE_write_timestamps =
{0xc8ca406b, 0x8220, 0x4070, {0xb5, 0xbe, 0x1e, 0x27, 0xe4, 0x7, 0x91, 0x47}};


/**
<dl><dt><b>GUID:</b></dt><dd>
{6A5C8A0A-9FEB-4935-B0F1-76594E742852}
</dd></dl>
<dl><dt><b>Description:</b></dt><dd>
Specifies timestamp offset for Timestamp SEI message
</dd></dl>
<dl><dt><b>Type:</b></dt><dd>
VT_INT
</dd></dl>
*/
static const GUID EH264VE_timestamp_offset = 
{ 0x6a5c8a0a, 0x9feb, 0x4935, { 0xb0, 0xf1, 0x76, 0x59, 0x4e, 0x74, 0x28, 0x52 } };


/**
<dl><dt><b>GUID:</b></dt><dd>
{1F051492-621D-45B5-9E03-D7FCFE479442}
</dd></dl>
<dl><dt><b>Description:</b></dt><dd>
Enables/Disables drop frame mode for timecode
</dd></dl>
<dl><dt><b>Type:</b></dt><dd>
VT_INT
</dd></dl>
*/
static const GUID EH264VE_drop_frame_timecode = 
{ 0x1f051492, 0x621d, 0x45b5, { 0x9e, 0x3, 0xd7, 0xfc, 0xfe, 0x47, 0x94, 0x42 } };


/**
<dl><dt><b>GUID:</b></dt><dd>
{DC02D1DD-7D42-4BE9-AC76-26C1C3F4E185}
</dd></dl>
<dl><dt><b>Description:</b></dt><dd>
Specifies the frame packing arrangement mode for FPA SEI messages
</dd></dl>
<dl><dt><b>Type:</b></dt><dd>
VT_INT
</dd></dl>
*/
static const GUID EH264VE_frame_packing_arrangement_mode = 
{ 0xdc02d1dd, 0x7d42, 0x4be9, { 0xac, 0x76, 0x26, 0xc1, 0xc3, 0xf4, 0xe1, 0x85 } };


/**
<dl><dt><b>GUID:</b></dt><dd>
{5E431140-B9E4-424f-A90F-F067EBFEC28F}
</dd></dl>
<dl><dt><b>Description:</b></dt><dd>
Specifies the optimization CPU instruction set.
</dd></dl>
<dl><dt><b>Type:</b></dt><dd>
VT_INT
</dd></dl>
*/
static const GUID EH264VE_cpu_optimization =
{0x5e431140, 0xb9e4, 0x424f, {0xa9, 0xf, 0xf0, 0x67, 0xeb, 0xfe, 0xc2, 0x8f}};


/**
<dl><dt><b>GUID:</b></dt><dd>
{39108716-B2F5-491c-9E9B-C2ABF38475B4}
</dd></dl>
<dl><dt><b>Description:</b></dt><dd>
Specifies maximal number of threads
</dd></dl>
<dl><dt><b>Type:</b></dt><dd>
VT_INT
</dd></dl>
*/
static const GUID EH264VE_num_threads =
{0x39108716, 0xb2f5, 0x491c, {0x9e, 0x9b, 0xc2, 0xab, 0xf3, 0x84, 0x75, 0xb4}};


/**
<dl><dt><b>GUID:</b></dt><dd>
{ACAC1419-D3D0-47ff-AC9F-889B1D143981}
</dd></dl>
<dl><dt><b>Description:</b></dt><dd>
Enables/disables the use of the user defined frame rate for input stream.
</dd></dl>
<dl><dt><b>Type:</b></dt><dd>
VT_INT
</dd></dl>
*/
static const GUID EH264VE_FixedRate =
{0xacac1419, 0xd3d0, 0x47ff, {0xac, 0x9f, 0x88, 0x9b, 0x1d, 0x14, 0x39, 0x81}};


/**
<dl><dt><b>GUID:</b></dt><dd>
{3F3F4E8F-07BA-4a0d-86B7-FA79907B373E}
</dd></dl>
<dl><dt><b>Description:</b></dt><dd>
Specifies the input frame rate if the fixed input frame rate is enabled.
</dd></dl>
<dl><dt><b>Type:</b></dt><dd>
VT_INT
</dd></dl>
*/
static const GUID EH264VE_Framerate =
{0x3f3f4e8f, 0x7ba, 0x4a0d, {0x86, 0xb7, 0xfa, 0x79, 0x90, 0x7b, 0x37, 0x3e}};


/**
<dl><dt><b>GUID:</b></dt><dd>
{0CD0C8F4-2AE6-4c2c-A8A7-99967F2E12F2}
</dd></dl>
<dl><dt><b>Description:</b></dt><dd>
Enables/disables the use of the user defined frame rate for output stream.
</dd></dl>
<dl><dt><b>Type:</b></dt><dd>
VT_INT
</dd></dl>
*/
static const GUID EH264VE_OutFixedRate =
{0xcd0c8f4, 0x2ae6, 0x4c2c, {0xa8, 0xa7, 0x99, 0x96, 0x7f, 0x2e, 0x12, 0xf2}};


/**
<dl><dt><b>GUID:</b></dt><dd>
{8F8A8859-A4C2-46c5-8043-18DA54F7034E}
</dd></dl>
<dl><dt><b>Description:</b></dt><dd>
Specifies the output frame rate if the fixed input frame rate is enabled.
</dd></dl>
<dl><dt><b>Type:</b></dt><dd>
VT_INT
</dd></dl>
*/
static const GUID EH264VE_OutFramerate =
{0x8f8a8859, 0xa4c2, 0x46c5, {0x80, 0x43, 0x18, 0xda, 0x54, 0xf7, 0x3, 0x4e}};


/**
<dl><dt><b>GUID:</b></dt><dd>
{838A8859-A4C2-46c5-8043-38DA54F00355}
</dd></dl>
<dl><dt><b>Description:</b></dt><dd>
Specifies the frame rate conversion type
</dd></dl>
<dl><dt><b>Type:</b></dt><dd>
VT_INT
</dd></dl>
*/
static const GUID EH264VE_FpsConvType =
{0x838a8859, 0xa4c2, 0x46c5, {0x80, 0x43, 0x38, 0xda, 0x54, 0xf0, 0x3, 0x55}};


/**
<dl><dt><b>GUID:</b></dt><dd>
{0670ACD2-5113-0002-9FF7-EE544AC19D85}
</dd></dl>
<dl><dt><b>Description:</b></dt><dd>
Specifies whether to keep original DirectShow timestamps (from input samples) or not.
</dd></dl>
<dl><dt><b>Type:</b></dt><dd>
VT_INT
</dd></dl>
*/
static const GUID EH264VE_TimestampMode =
{0x0670acd2, 0x5113, 0x0002, { 0x9f, 0xf7, 0xee, 0x54, 0x4a, 0xc1, 0x9d, 0x85}};


/**
<dl><dt><b>GUID:</b></dt><dd>
{28C447DD-6581-4324-8A95-A62DF867379D}
</dd></dl>
<dl><dt><b>Description:</b></dt><dd>
Specifies the fourCC for the encoder to use for the output mediatype.
</dd></dl>
<dl><dt><b>Type:</b></dt><dd>
VT_INT
</dd></dl>
*/
static const GUID EH264VE_OutputMediatype =
{0x28c447dd, 0x6581, 0x4324, { 0x8a, 0x95, 0xa6, 0x2d, 0xf8, 0x67, 0x37, 0x9d}};


/**
<dl><dt><b>GUID:</b></dt><dd>
{B1E3E1BF-6225-4351-862C-66989AEE22B4}
</dd></dl>
<dl><dt><b>Description:</b></dt><dd>
Specifies the defaults flag. Restores all properties to the default state for selected H.264 Preset.
</dd></dl>
<dl><dt><b>Type:</b></dt><dd>
VT_INT
</dd></dl>
*/
static const GUID EH264VE_SetDefValues =
{0xb1e3e1bf, 0x6225, 0x4351, {0x86, 0x2c, 0x66, 0x98, 0x9a, 0xee, 0x22, 0xb4}};


/**
<dl><dt><b>GUID:</b></dt><dd>
{D02685C0-0946-4740-A6E7-504D750FE4F1}
</dd></dl>
<dl><dt><b>Description:</b></dt><dd>
Specifies the original input frame rate
</dd></dl>
<dl><dt><b>Type:</b></dt><dd>
VT_INT
</dd></dl>
*/
static const GUID EH264VE_OriginalFramerate =
{0xd02685c0, 0x946, 0x4740, {0xa6, 0xe7, 0x50, 0x4d, 0x75, 0xf, 0xe4, 0xf1}};


/**
<dl><dt><b>GUID:</b></dt><dd>
{654207C6-ECAD-4e8f-86F1-7819148D518A}
</dd></dl>
<dl><dt><b>Description:</b></dt><dd>
Specifies the interlace mode of input frames
</dd></dl>
<dl><dt><b>Type:</b></dt><dd>
VT_INT
</dd></dl>
*/
static const GUID EH264VE_OriginalInterlace =
{0x654207c6, 0xecad, 0x4e8f, {0x86, 0xf1, 0x78, 0x19, 0x14, 0x8d, 0x51, 0x8a}};


/**
<dl><dt><b>GUID:</b></dt><dd>
{413AA8BB-F85C-4768-B8F6-91AA7BCE3DE6}
</dd></dl>
<dl><dt><b>Description:</b></dt><dd>
Specifies colorspace layout of input frames
</dd></dl>
<dl><dt><b>Type:</b></dt><dd>
VT_INT
</dd></dl>
*/
static const GUID EH264VE_OriginalColorSpace =
{0x413aa8bb, 0xf85c, 0x4768, {0xb8, 0xf6, 0x91, 0xaa, 0x7b, 0xce, 0x3d, 0xe6}};

/**
<dl><dt><b>GUID:</b></dt><dd>
{413AA8BB-F85C-4768-B8F6-91AA7BCE3DE7}
</dd></dl>
<dl><dt><b>Description:</b></dt><dd>
Specifies pixel bit depth of input frames
</dd></dl>
<dl><dt><b>Type:</b></dt><dd>
VT_INT
</dd></dl>
*/
static const GUID EH264VE_OriginalBitDepth =
{0x413aa8bb, 0xf85c, 0x4768, {0xb8, 0xf6, 0x91, 0xaa, 0x7b, 0xce, 0x3d, 0xe7}};



/**
<dl><dt><b>GUID:</b></dt><dd>
{5C6C1DF4-7F98-4E32-BF3C-9541E98F269B}
</dd></dl>
<dl><dt><b>Description:</b></dt><dd>
Specifies width of input frames
</dd></dl>
<dl><dt><b>Type:</b></dt><dd>
VT_INT
</dd></dl>
*/
static const GUID EH264VE_OriginalHorizontalSize =
{ 0x5c6c1df4, 0x7f98, 0x4e32,{ 0xbf, 0x3c, 0x95, 0x41, 0xe9, 0x8f, 0x26, 0x9b } };

/**
<dl><dt><b>GUID:</b></dt><dd>
{D5B001EE-CEA9-41A7-8B13-3E8C8E87D6A7}
</dd></dl>
<dl><dt><b>Description:</b></dt><dd>
Specifies height of input frames
</dd></dl>
<dl><dt><b>Type:</b></dt><dd>
VT_INT
</dd></dl>
*/
static const GUID EH264VE_OriginalVerticalSize =
{ 0xd5b001ee, 0xcea9, 0x41a7,{ 0x8b, 0x13, 0x3e, 0x8c, 0x8e, 0x87, 0xd6, 0xa7 } };

// {D0D2A38C-8DF6-47b5-A662-47E6D39BCFA7}
static const GUID EH264VE_IsRunning =
{0xd0d2a38c, 0x8df6, 0x47b5, {0xa6, 0x62, 0x47, 0xe6, 0xd3, 0x9b, 0xcf, 0xa7}};

/**
<dl><dt><b>GUID:</b></dt><dd>
{DE6D6008-1A49-428a-B2ED-E760FF32909E}
</dd></dl>
<dl><dt><b>Description:</b></dt><dd>
Specifies width of output encoded frames
</dd></dl>
<dl><dt><b>Type:</b></dt><dd>
VT_INT
</dd></dl>
*/
static const GUID EH264VE_def_horizontal_size =
{0xde6d6008, 0x1a49, 0x428a, {0xb2, 0xed, 0xe7, 0x60, 0xff, 0x32, 0x90, 0x9e}};


/**
<dl><dt><b>GUID:</b></dt><dd>
{D44C9617-C618-4d57-A992-DB8101911B4A}
</dd></dl>
<dl><dt><b>Description:</b></dt><dd>
Specifies height of output encoded frames
</dd></dl>
<dl><dt><b>Type:</b></dt><dd>
VT_INT
</dd></dl>
*/
static const GUID EH264VE_def_vertical_size =
{0xd44c9617, 0xc618, 0x4d57, {0xa9, 0x92, 0xdb, 0x81, 0x1, 0x91, 0x1b, 0x4a}};


/**
<dl><dt><b>GUID:</b></dt><dd>
{1A043FA3-E46A-4B91-BFCD-AAE752205717}
</dd></dl>
<dl><dt><b>Description:</b></dt><dd>
Enables/Disables writing settings to output stream
</dd></dl>
<dl><dt><b>Type:</b></dt><dd>
VT_INT
</dd></dl>
*/
static const GUID EH264VE_write_settings_info = 
{ 0x1a043fa3, 0xe46a, 0x4b91, { 0xbf, 0xcd, 0xaa, 0xe7, 0x52, 0x20, 0x57, 0x17 } };


/**
<dl><dt><b>GUID:</b></dt><dd>
{0302F75C-B885-411D-A970-8863208F1ABC}
</dd></dl>
<dl><dt><b>Description:</b></dt><dd>
Specifies closed captions format
</dd></dl>
<dl><dt><b>Type:</b></dt><dd>
VT_INT
</dd></dl>
*/
static const GUID EH264VE_ClosedCaption_format =
{ 0x302f75c, 0xb885, 0x411d, { 0xa9, 0x70, 0x88, 0x63, 0x20, 0x8f, 0x1a, 0xbc } };


/**
<dl><dt><b>GUID:</b></dt><dd>
{D307B417-C618-4d57-A992-DB8101911B4A}
</dd></dl>
<dl><dt><b>Description:</b></dt><dd>
Specifies pointer to structure with @ref ENC_AVC_DS_CHAPTER_LIST_PAGE "chapters"
</dd></dl>
<dl><dt><b>Type:</b></dt><dd>
VT_INT
</dd></dl>
*/
static const GUID EH264VE_chapter_list =
{0xd307b417, 0xc618, 0x4d57, {0xa9, 0x92, 0xdb, 0x81, 0x1, 0x91, 0x1b, 0x4a}};


/**
<dl><dt><b>GUID:</b></dt><dd>
{3BDEAC38-3761-4a0a-92BD-F65828139E2E}
</dd></dl>
<dl><dt><b>Description:</b></dt><dd>
Specifies the value of pic_order_present_flag of the picture parameter set.
</dd></dl>
<dl><dt><b>Type:</b></dt><dd>
VT_INT
</dd></dl>
*/
static const GUID EH264VE_pic_order_present_flag =
{0x3bdeac38, 0x3761, 0x4a0a, {0x92, 0xbd, 0xf6, 0x58, 0x28, 0x13, 0x9e, 0x2e}};


/**
<dl><dt><b>GUID:</b></dt><dd>
{35BEBA77-A591-43c4-A1AA-A7B63041157A}
</dd></dl>
<dl><dt><b>Description:</b></dt><dd>
Specifies the value of fixed_frame_rate_flag of the sequence parameter set.
</dd></dl>
<dl><dt><b>Type:</b></dt><dd>
VT_INT
</dd></dl>
*/
static const GUID EH264VE_fixed_frame_rate =
{0x35beba77, 0xa591, 0x43c4, { 0xa1, 0xaa, 0xa7, 0xb6, 0x30, 0x41, 0x15, 0x7a}};


/**
<dl><dt><b>GUID:</b></dt><dd>
{22A03E42-6DCC-4597-B788-E059B4D79338}
</dd></dl>
<dl><dt><b>Description:</b></dt><dd>
Specifies whether num_units_in_tick/time_scale ratio represents the frame or field rate.
</dd></dl>
<dl><dt><b>Type:</b></dt><dd>
VT_INT
</dd></dl>
*/
static const GUID EH264VE_frame_based_timing =
{0x22a03e42, 0x6dcc, 0x4597, { 0xb7, 0x88, 0xe0, 0x59, 0xb4, 0xd7, 0x93, 0x38}};


/**
<dl><dt><b>GUID:</b></dt><dd>
{DDE74F7E-4260-47e1-B83C-BC9A52EB4E9D}
</dd></dl>
<dl><dt><b>Description:</b></dt><dd>
Enables/Disables HRD parameters SEI message writing
</dd></dl>
<dl><dt><b>Type:</b></dt><dd>
VT_INT
</dd></dl>
*/
static const GUID EH264VE_hrd_param_writing =
{0xdde74f7e, 0x4260, 0x47e1, { 0xb8, 0x3c, 0xbc, 0x9a, 0x52, 0xeb, 0x4e, 0x9d}};


/**
<dl><dt><b>GUID:</b></dt><dd>
{2ED5EEA4-8E70-449c-9407-F1D232D32320}
</dd></dl>
<dl><dt><b>Description:</b></dt><dd>
Enables/disables writing the picture structure information in picture timing SEI.
</dd></dl>
<dl><dt><b>Type:</b></dt><dd>
VT_INT
</dd></dl>
*/
static const GUID EH264VE_write_pic_struct =
{0x2ed5eea4, 0x8e70, 0x449c, { 0x94, 0x07, 0xf1, 0xd2, 0x32, 0xd3, 0x23, 0x20}};


/**
<dl><dt><b>GUID:</b></dt><dd>
{79078EA9-167B-46e6-8DCC-6ED492B9271D}
</dd></dl>
<dl><dt><b>Description:</b></dt><dd>
Enables/disables writing the picture timing SEI.
</dd></dl>
<dl><dt><b>Type:</b></dt><dd>
VT_INT
</dd></dl>
*/
static const GUID EH264VE_write_pic_timing_sei =
{0x79078ea9, 0x167b, 0x46e6, { 0x8d, 0xcc, 0x6e, 0xd4, 0x92, 0xb9, 0x27, 0x1d}};


/**
<dl><dt><b>GUID:</b></dt><dd>
{00078EA9-167B-46e6-8DCC-6ED492B9271D}
</dd></dl>
<dl><dt><b>Description:</b></dt><dd>
Specifies the value of log2_max_frame_num_minus4 of the sequence parameter set.
</dd></dl>
<dl><dt><b>Type:</b></dt><dd>
VT_INT
</dd></dl>
*/
static const GUID EH264VE_log2_max_frame_num =
{0x00078ea9, 0x167b, 0x46e6, { 0x8d, 0xcc, 0x6e, 0xd4, 0x92, 0xb9, 0x27, 0x1d}};


/**
<dl><dt><b>GUID:</b></dt><dd>
{00178EA9-167B-46e6-8DCC-6ED492B9271D}
</dd></dl>
<dl><dt><b>Description:</b></dt><dd>
Specifies the value of pic_order_cnt_type of the sequence parameter set.
</dd></dl>
<dl><dt><b>Type:</b></dt><dd>
VT_INT
</dd></dl>
*/
static const GUID EH264VE_pic_order_cnt_type =
{0x00178ea9, 0x167b, 0x46e6, { 0x8d, 0xcc, 0x6e, 0xd4, 0x92, 0xb9, 0x27, 0x1d}};


/**
<dl><dt><b>GUID:</b></dt><dd>
{D92A3497-97A0-41ac-9F3C-42D5B238D500}
</dd></dl>
<dl><dt><b>Description:</b></dt><dd>
Specifies the weight of the macroblock luminance in the process of calculation of the quantizer.
</dd></dl>
<dl><dt><b>Type:</b></dt><dd>
VT_INT
</dd></dl>
*/
static const GUID EH264VE_aq_strength_luminance =
{0xd92a3497, 0x97a0, 0x41ac, {0x9f, 0x3c, 0x42, 0xd5, 0xb2, 0x38, 0xd5, 0x00}};


/**
<dl><dt><b>GUID:</b></dt><dd>
{D92A3497-97A0-41ac-9F3C-42D5B238D501}
</dd></dl>
<dl><dt><b>Description:</b></dt><dd>
Specifies the weight of the macroblock contrast in the process of calculation of the quantizer.
</dd></dl>
<dl><dt><b>Type:</b></dt><dd>
VT_INT
</dd></dl>
*/
static const GUID EH264VE_aq_strength_contrast =
{0xd92a3497, 0x97a0, 0x41ac, {0x9f, 0x3c, 0x42, 0xd5, 0xb2, 0x38, 0xd5, 0x01}};


/**
<dl><dt><b>GUID:</b></dt><dd>
{D92A3497-97A0-41ac-9F3C-42D5B238D502}
</dd></dl>
<dl><dt><b>Description:</b></dt><dd>
Specifies the weight of the macroblock complexity in the process of calculation of the quantizer.
</dd></dl>
<dl><dt><b>Type:</b></dt><dd>
VT_INT
</dd></dl>
*/
static const GUID EH264VE_aq_strength_complexity =
{0xd92a3497, 0x97a0, 0x41ac, {0x9f, 0x3c, 0x42, 0xd5, 0xb2, 0x38, 0xd5, 0x02}};


/**
<dl><dt><b>GUID:</b></dt><dd>
{BAD62D94-3737-48e8-85CC-226FBE9BB894}
</dd></dl>
<dl><dt><b>Description:</b></dt><dd>
Specifies the chrominance data sampling.
</dd></dl>
<dl><dt><b>Type:</b></dt><dd>
VT_INT
</dd></dl>
*/
static const GUID EH264VE_chroma_sampling =
{0xbad62d94, 0x3737, 0x48e8, {0x85, 0xcc, 0x22, 0x6f, 0xbe, 0x9b, 0xb8, 0x94}};


/**
<dl><dt><b>GUID:</b></dt><dd>
{87136EBC-2ABA-47f3-B82C-003F0D5ED074}
</dd></dl>
<dl><dt><b>Description:</b></dt><dd>
Specifies the depth of luminance data samples.
</dd></dl>
<dl><dt><b>Type:</b></dt><dd>
VT_INT
</dd></dl>
*/
static const GUID EH264VE_luma_bit_depth =
{0x87136ebc, 0x2aba, 0x47f3, {0xb8, 0x2c, 0x0, 0x3f, 0xd, 0x5e, 0xd0, 0x74}};


/**
<dl><dt><b>GUID:</b></dt><dd>
{87136EBC-2ABA-47f3-B82C-003F0D5ED075}
</dd></dl>
<dl><dt><b>Description:</b></dt><dd>
Specifies the depth of chrominance data samples.
</dd></dl>
<dl><dt><b>Type:</b></dt><dd>
VT_INT
</dd></dl>
*/
static const GUID EH264VE_chroma_bit_depth =
{0x87136ebc, 0x2aba, 0x47f3, {0xb8, 0x2c, 0x0, 0x3f, 0xd, 0x5e, 0xd0, 0x75}};

/**
<dl><dt><b>GUID:</b></dt><dd>
{1c39c6cb-6fec-48fb-aff6-f8439ce6e60b}
</dd></dl>
<dl><dt><b>Description:</b></dt><dd>
Enable/disable HRD flag. 0 - Disable, 1 - Enable
</dd></dl>
<dl><dt><b>Type:</b></dt><dd>
VT_INT
</dd></dl>
*/
static const GUID EH264VE_use_hrd =
{0x1c39c6cb, 0x6fec, 0x48fb, {0xaf, 0xf6, 0xf8, 0x43, 0x9c, 0xe6, 0xe6, 0xb}};


/**
<dl><dt><b>GUID:</b></dt><dd>
{a27f3c3a-853e-4c03-a9a3-a55f47e82956}
</dd></dl>
<dl><dt><b>Description:</b></dt><dd>
Specifies intra refresh mode.
</dd></dl>
<dl><dt><b>Type:</b></dt><dd>
VT_INT
</dd></dl>
*/
static const GUID EH264VE_intra_refresh_mode =
{0xa27f3c3a, 0x853e, 0x4c03, {0xa9, 0xa3, 0xa5, 0x5f, 0x47, 0xe8, 0x29, 0x56}};


/**
<dl><dt><b>GUID:</b></dt><dd>
{40513cf3-853e-4c03-a9a3-a55f47e82956}
</dd></dl>
<dl><dt><b>Description:</b></dt><dd>
Enables/Disables constrained intra prediction
</dd></dl>
<dl><dt><b>Type:</b></dt><dd>
VT_INT
</dd></dl>
*/
static const GUID EH264VE_constr_intra_pred =
{0x40513cf3, 0x853e, 0x4c03, {0xa9, 0xa3, 0xa5, 0x5f, 0x47, 0xe8, 0x29, 0x56}};


/**
<dl><dt><b>GUID:</b></dt><dd>
{11093431-74c1-4d37-beb8-3a4dc9bb0119}
</dd></dl>
<dl><dt><b>Description:</b></dt><dd>
Performance preset. A number of Performance level.
</dd></dl>
<dl><dt><b>Type:</b></dt><dd>
VT_INT
</dd></dl>
*/
static const GUID EH264VE_performance_preset =
{0x11093431, 0x74c1, 0x4d37, {0xbe, 0xb8, 0x3a, 0x4d, 0xc9, 0xbb, 0x1, 0x19}};


/**
<dl><dt><b>GUID:</b></dt><dd>
{8307B321-C618-4d57-A992-DB8101911Bf0}
</dd></dl>
<dl><dt><b>Description:</b></dt><dd>
Pointer to DS callback
</dd></dl>
<dl><dt><b>Type:</b></dt><dd>
VT_PTR
</dd></dl>
*/
static const GUID EH264VE_ds_callback =
{0x8307b321, 0xc618, 0x4d57, {0xa9, 0x92, 0xdb, 0x81, 0x1, 0x91, 0x1b, 0xf0}};


/**
<dl><dt><b>GUID:</b></dt><dd>
{ECE79FBE-F373-4949-B978-1862FB648ABE}
</dd></dl>
<dl><dt><b>Description:</b></dt><dd>
Enable/Disable HRD preview algorithm
</dd></dl>
<dl><dt><b>Type:</b></dt><dd>
VT_INT
</dd></dl>
*/
  static const GUID EH264VE_HRD_preview = 
{ 0xece79fbe, 0xf373, 0x4949, { 0xb9, 0x78, 0x18, 0x62, 0xfb, 0x64, 0x8a, 0xbe } };


/**
<dl><dt><b>GUID:</b></dt><dd>
{1E7EFA98-8822-40E6-B93C-A425B0C19204}
</dd></dl>
<dl><dt><b>Description:</b></dt><dd>
Specifies buffering of source queue
</dd></dl>
<dl><dt><b>Type:</b></dt><dd>
VT_INT
</dd></dl>
*/
static const GUID EH264VE_Buffering = 
{ 0x1e7efa98, 0x8822, 0x40e6, { 0xb9, 0x3c, 0xa4, 0x25, 0xb0, 0xc1, 0x92, 0x4 } };


/**
<dl><dt><b>GUID:</b></dt><dd>
{B01FEB2C-9E20-4546-8EEA-F91391C06908}
</dd></dl>
<dl><dt><b>Description:</b></dt><dd>
Specifies encoding buffering
</dd></dl>
<dl><dt><b>Type:</b></dt><dd>
VT_INT
</dd></dl>
*/
static const GUID EH264VE_Encoding_Buffering = 
{ 0xb01feb2c, 0x9e20, 0x4546, { 0x8e, 0xea, 0xf9, 0x13, 0x91, 0xc0, 0x69, 0x8 } };


/**
<dl><dt><b>GUID:</b></dt><dd>
{E2726C09-6A75-4158-8E41-7FA44753450A}
</dd></dl>
<dl><dt><b>Description:</b></dt><dd>
Enables/Disables writing product information in SEI message
</dd></dl>
<dl><dt><b>Type:</b></dt><dd>
VT_INT
</dd></dl>
*/
static const GUID EH264VE_Product_info_in_SEI = 
{ 0xe2726c09, 0x6a75, 0x4158, { 0x8e, 0x41, 0x7f, 0xa4, 0x47, 0x53, 0x45, 0xa } };


/**
<dl><dt><b>GUID:</b></dt><dd>
{C7C330C7-3531-4314-AB9E-8615BC2E4D8D}
</dd></dl>
<dl><dt><b>Description:</b></dt><dd>
Enables/Disables writing color description information in stream.
</dd></dl>
<dl><dt><b>Type:</b></dt><dd>
VT_INT
</dd></dl>
*/
static const GUID EH264VE_Colour_description_flag = 
{ 0xc7c330c7, 0x3531, 0x4314, { 0xab, 0x9e, 0x86, 0x15, 0xbc, 0x2e, 0x4d, 0x8d } };


/**
<dl><dt><b>GUID:</b></dt><dd>
{E89A8BF6-FACA-45C0-8045-2A109F19A5CC}
</dd></dl>
<dl><dt><b>Description:</b></dt><dd>
Specifies the chromaticity coordinates of the source primaries.
</dd></dl>
<dl><dt><b>Type:</b></dt><dd>
VT_INT
</dd></dl>
*/
static const GUID EH264VE_Colour_primaries = 
{ 0xe89a8bf6, 0xfaca, 0x45c0, { 0x80, 0x45, 0x2a, 0x10, 0x9f, 0x19, 0xa5, 0xcc } };


/**
<dl><dt><b>GUID:</b></dt><dd>
{AFE730BD-962B-4695-855C-28FC496097AF}
</dd></dl>
<dl><dt><b>Description:</b></dt><dd>
Specifies transfer characteristics of the source primaries.
</dd></dl>
<dl><dt><b>Type:</b></dt><dd>
VT_INT
</dd></dl>
*/
static const GUID EH264VE_Transfer_characteristics = 
{ 0xafe730bd, 0x962b, 0x4695, { 0x85, 0x5c, 0x28, 0xfc, 0x49, 0x60, 0x97, 0xaf } };


/**
<dl><dt><b>GUID:</b></dt><dd>
{8FB275BE-2675-4EBA-A268-FA7099EEC392}
</dd></dl>
<dl><dt><b>Description:</b></dt><dd>
Specifies transfer characteristics of the source primaries.
</dd></dl>
<dl><dt><b>Type:</b></dt><dd>
VT_INT
</dd></dl>
*/
static const GUID EH264VE_Pixel_Range = 
{ 0x8fb275be, 0x2675, 0x4eba, { 0xa2, 0x68, 0xfa, 0x70, 0x99, 0xee, 0xc3, 0x92 } };


/**
<dl><dt><b>GUID:</b></dt><dd>
{998B6205-2BF9-4B88-BDD4-7AD03D796685}
</dd></dl>
<dl><dt><b>Description:</b></dt><dd>
Specifies matrix coefficients of the source primaries.
</dd></dl>
<dl><dt><b>Type:</b></dt><dd>
VT_INT
</dd></dl>
*/
static const GUID EH264VE_Matrix_coefficients = 
{ 0x998b6205, 0x2bf9, 0x4b88, { 0xbd, 0xd4, 0x7a, 0xd0, 0x3d, 0x79, 0x66, 0x85 } };


/**
<dl><dt><b>GUID:</b></dt><dd>
{EDC87D2F-66DF-4CF3-8188-01009F66C079}
</dd></dl>
<dl><dt><b>Description:</b></dt><dd>
Specifies how SPS should be written.
</dd></dl>
<dl><dt><b>Type:</b></dt><dd>
VT_INT
</dd></dl>
*/
static const GUID EH264VE_WriteSPS = 
{ 0xedc87d2f, 0x66df, 0x4cf3, { 0x81, 0x88, 0x1, 0x0, 0x9f, 0x66, 0xc0, 0x79 } };


/**
<dl><dt><b>GUID:</b></dt><dd>
{7D9285DA-74FD-4E42-8005-072B495815B0}
</dd></dl>
<dl><dt><b>Description:</b></dt><dd>
Specifies how PPS should be written.
</dd></dl>
<dl><dt><b>Type:</b></dt><dd>
VT_INT
</dd></dl>
*/
static const GUID EH264VE_WritePPS = 
{ 0x7d9285da, 0x74fd, 0x4e42, { 0x80, 0x5, 0x7, 0x2b, 0x49, 0x58, 0x15, 0xb0 } };


/**
<dl><dt><b>GUID:</b></dt><dd>
{7A66E1A5-702D-49B8-B583-E6B12D413039}
</dd></dl>
<dl><dt><b>Description:</b></dt><dd>
Enables/Disables gaps_in_frame_num_value_allowed_flag in SPS.
</dd></dl>
<dl><dt><b>Type:</b></dt><dd>
VT_INT
</dd></dl>
*/
static const GUID EH264VE_FrameNumGapsAllowed = 
{ 0x7a66e1a5, 0x702d, 0x49b8, { 0xb5, 0x83, 0xe6, 0xb1, 0x2d, 0x41, 0x30, 0x39 } };


/**
<dl><dt><b>GUID:</b></dt><dd>
{83A59375-8FAF-4E92-9994-02D9F2023F9B}
</dd></dl>
<dl><dt><b>Description:</b></dt><dd>
Specifies number of parallel encoded pictures.
</dd></dl>
<dl><dt><b>Type:</b></dt><dd>
VT_INT
</dd></dl>
*/
static const GUID EH264VE_NumParallelPic =
{ 0x83a59375, 0x8faf, 0x4e92, { 0x99, 0x94, 0x2, 0xd9, 0xf2, 0x2, 0x3f, 0x9b } };


/**
<dl><dt><b>GUID:</b></dt><dd>
{CE81F1D7-E42E-404E-B329-0C51184621AA}
</dd></dl>
<dl><dt><b>Description:</b></dt><dd>
For Intra presets only, including Panasonic P2, XAVC Intra and RP2027. Set this flag after picture mode is changed, i.e. from progressive to MBAFF, to set default scaling matrices correctly.
</dd></dl>
<dl><dt><b>Type:</b></dt><dd>
VT_INT
</dd></dl>
*/
static const GUID EH264VE_ResetScalingMatrices = 
{ 0xce81f1d7, 0xe42e, 0x404e,{ 0xb3, 0x29, 0xc, 0x51, 0x18, 0x46, 0x21, 0xaa } };


/**
<dl><dt><b>GUID:</b></dt><dd>
{9E108905-771A-4FFE-B494-4281BDA3D4BC}
</dd></dl>
<dl><dt><b>Description:</b></dt><dd>
Mastering display colour volume SEI: display_primaries_x[0]
</dd></dl>
<dl><dt><b>Type:</b></dt><dd>
VT_INT
</dd></dl>
*/
static const GUID EH264VE_SMPTE_ST_2086_PRIM_X0 =
{ 0x9e108905, 0x771a, 0x4ffe,{ 0xb4, 0x94, 0x42, 0x81, 0xbd, 0xa3, 0xd4, 0xbc } };

/**
<dl><dt><b>GUID:</b></dt><dd>
{DAF74230-B858-4099-AE09-DBF9074C5D2D}
</dd></dl>
<dl><dt><b>Description:</b></dt><dd>
Mastering display colour volume SEI: display_primaries_x[1]
</dd></dl>
<dl><dt><b>Type:</b></dt><dd>
VT_INT
</dd></dl>
*/
static const GUID EH264VE_SMPTE_ST_2086_PRIM_X1 =
{ 0xdaf74230, 0xb858, 0x4099,{ 0xae, 0x9, 0xdb, 0xf9, 0x7, 0x4c, 0x5d, 0x2d } };

/**
<dl><dt><b>GUID:</b></dt><dd>
{B750FDF9-EA1D-4B34-92E9-AB59A2AAD7AA}
</dd></dl>
<dl><dt><b>Description:</b></dt><dd>
Mastering display colour volume SEI: display_primaries_x[2]
</dd></dl>
<dl><dt><b>Type:</b></dt><dd>
VT_INT
</dd></dl>
*/
static const GUID EH264VE_SMPTE_ST_2086_PRIM_X2 =
{ 0xb750fdf9, 0xea1d, 0x4b34,{ 0x92, 0xe9, 0xab, 0x59, 0xa2, 0xaa, 0xd7, 0xaa } };

/**
<dl><dt><b>GUID:</b></dt><dd>
{BBB30416-57DE-4958-B2E3-6A6CD5B60F30}
</dd></dl>
<dl><dt><b>Description:</b></dt><dd>
Mastering display colour volume SEI: display_primaries_y[0]
</dd></dl>
<dl><dt><b>Type:</b></dt><dd>
VT_INT
</dd></dl>
*/
static const GUID EH264VE_SMPTE_ST_2086_PRIM_Y0 =
{ 0xbbb30416, 0x57de, 0x4958,{ 0xb2, 0xe3, 0x6a, 0x6c, 0xd5, 0xb6, 0xf, 0x30 } };

/**
<dl><dt><b>GUID:</b></dt><dd>
{2FE4E99E-5AF5-419B-ACD7-357163796B81}
</dd></dl>
<dl><dt><b>Description:</b></dt><dd>
Mastering display colour volume SEI: display_primaries_y[1]
</dd></dl>
<dl><dt><b>Type:</b></dt><dd>
VT_INT
</dd></dl>
*/
static const GUID EH264VE_SMPTE_ST_2086_PRIM_Y1 =
{ 0x2fe4e99e, 0x5af5, 0x419b,{ 0xac, 0xd7, 0x35, 0x71, 0x63, 0x79, 0x6b, 0x81 } };

/**
<dl><dt><b>GUID:</b></dt><dd>
{233DF2D0-95C5-48C2-A240-3BB756246343}
</dd></dl>
<dl><dt><b>Description:</b></dt><dd>
Mastering display colour volume SEI: display_primaries_y[2]
</dd></dl>
<dl><dt><b>Type:</b></dt><dd>
VT_INT
</dd></dl>
*/
static const GUID EH264VE_SMPTE_ST_2086_PRIM_Y2 =
{ 0x233df2d0, 0x95c5, 0x48c2,{ 0xa2, 0x40, 0x3b, 0xb7, 0x56, 0x24, 0x63, 0x43 } };

/**
<dl><dt><b>GUID:</b></dt><dd>
{C4BDFAD0-2DE6-49FE-A250-67706E029B0B}
</dd></dl>
<dl><dt><b>Description:</b></dt><dd>
Mastering display colour volume SEI: white_point_x
</dd></dl>
<dl><dt><b>Type:</b></dt><dd>
VT_INT
</dd></dl>
*/
static const GUID EH264VE_SMPTE_ST_2086_WHITE_POINT_X =
{ 0xc4bdfad0, 0x2de6, 0x49fe,{ 0xa2, 0x50, 0x67, 0x70, 0x6e, 0x2, 0x9b, 0xb } };

/**
<dl><dt><b>GUID:</b></dt><dd>
{6B2BACD0-D67A-4491-B020-4CC8F6D8230E}
</dd></dl>
<dl><dt><b>Description:</b></dt><dd>
Mastering display colour volume SEI: white_point_y
</dd></dl>
<dl><dt><b>Type:</b></dt><dd>
VT_INT
</dd></dl>
*/
static const GUID EH264VE_SMPTE_ST_2086_WHITE_POINT_Y =
{ 0x6b2bacd0, 0xd67a, 0x4491,{ 0xb0, 0x20, 0x4c, 0xc8, 0xf6, 0xd8, 0x23, 0xe } };

/**
<dl><dt><b>GUID:</b></dt><dd>
{5B2B1433-3457-463C-A794-8A338395D110}
</dd></dl>
<dl><dt><b>Description:</b></dt><dd>
Mastering display colour volume SEI: max_display_mastering_luminance
</dd></dl>
<dl><dt><b>Type:</b></dt><dd>
VT_I8
</dd></dl>
*/
static const GUID EH264VE_SMPTE_ST_2086_MAX_LUMINANCE =
{ 0x5b2b1433, 0x3457, 0x463c,{ 0xa7, 0x94, 0x8a, 0x33, 0x83, 0x95, 0xd1, 0x10 } };

/**
<dl><dt><b>GUID:</b></dt><dd>
{390810EB-B4B7-416D-AA8B-D26136767D4D}
</dd></dl>
<dl><dt><b>Description:</b></dt><dd>
Mastering display colour volume SEI: min_display_mastering_luminance
</dd></dl>
<dl><dt><b>Type:</b></dt><dd>
VT_I8
</dd></dl>
*/
static const GUID EH264VE_SMPTE_ST_2086_MIN_LUMINANCE =
{ 0x390810eb, 0xb4b7, 0x416d,{ 0xaa, 0x8b, 0xd2, 0x61, 0x36, 0x76, 0x7d, 0x4d } };

/**
<dl><dt><b>GUID:</b></dt><dd>
{05EB4581-BDF3-4750-A61F-0A25D028D12F}
</dd></dl>
<dl><dt><b>Description:</b></dt><dd>
Content Light Level SEI: Maximum Content Light Level (MaxCLL)
</dd></dl>
<dl><dt><b>Type:</b></dt><dd>
VT_INT
</dd></dl>
*/
static const GUID EH264VE_MAX_CLL =
{ 0x5eb4581, 0xbdf3, 0x4750,{ 0xa6, 0x1f, 0xa, 0x25, 0xd0, 0x28, 0xd1, 0x2f } };

/**
<dl><dt><b>GUID:</b></dt><dd>
{16E6F444-E37A-42C0-B3A4-603FED21BF20}
</dd></dl>
<dl><dt><b>Description:</b></dt><dd>
Content Light Level SEI: Maximum Picture-Average Light Level (MaxPALL, also mentioned as MaxFALL)
</dd></dl>
<dl><dt><b>Type:</b></dt><dd>
VT_INT
</dd></dl>
*/
static const GUID EH264VE_MAX_PALL =
{ 0x16e6f444, 0xe37a, 0x42c0,{ 0xb3, 0xa4, 0x60, 0x3f, 0xed, 0x21, 0xbf, 0x20 } };

/**@}*/
#endif // __PROPID_H264ENC_HEADER__
