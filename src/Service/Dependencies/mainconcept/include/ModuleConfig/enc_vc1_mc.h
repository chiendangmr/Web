/** 
 @file  enc_vc1_mc.h
 @brief  Property GUIDs for MainConcept VC-1 encoder parameters.
 
 @verbatim
 File: enc_vc1_mc.h

 Desc: Property GUIDs for MainConcept VC-1 encoder parameters.
 
 Copyright (c) 2015 MainConcept GmbH or its affiliates.  All rights reserved.

 MainConcept and its logos are registered trademarks of MainConcept GmbH or its affiliates.  
 This software is protected by copyright law and international treaties.  Unauthorized 
 reproduction or distribution of any portion is prohibited by law.
 @endverbatim
 **/


#if !defined(__PROPID_VC1ENC_HEADER__)
#define __PROPID_VC1ENC_HEADER__

/**
* namespace VC1VE
* @brief VC1VE specific namespace
**/
    
namespace VC1VE
{
/**
* @brief Describes encoder profile.
**/
	typedef enum Profile
    {
        Profile_Simple      = 0,
        Profile_Main        = 1,
        Profile_Advanced    = 3

    } Profile_t;

/**
* @brief Describes pixel aspect ratio modes.
**/
    typedef enum PicAspRatio
    {
        Par_Auto            = 0,
        Par_DontUse         = 1,
        Par_1_1             = 3,
        Par_125_100         = 4,
        Par_4_3             = 5,
        Par_15_10           = 6,
        Par_16_9            = 7,
        Par_185_100         = 8,
        Par_2_1             = 9,
        Par_221_100         = 10,
        Par_235_100         = 11,
        Par_239_100         = 12,
        Par_Custom          = 13

    } PicAspRatio_t;

/**
* @brief Describes sample aspect ratio modes.
**/
    typedef enum SampleAspRatio
    {
        Sar_Auto            = 0,
        Sar_DontUse         = 1,
        Sar_1_1             = 3,
        Sar_12_11           = 4,
        Sar_10_11           = 5,
        Sar_16_11           = 6,
        Sar_40_33           = 7,
        Sar_24_11           = 8,
        Sar_20_11           = 9,
        Sar_32_11           = 10,
        Sar_80_33           = 11,
        Sar_18_11           = 12,
        Sar_15_11           = 13,
        Sar_64_33           = 14,
        Sar_160_99          = 15,
        Sar_Custom          = 16

    } SampleAspRatio_t;

/**
* @brief Describes encoder levels.
**/
    typedef enum Level
    {
        Level_0     = 0,
        Level_1     = 1,
        Level_2     = 2,
        Level_3     = 3,
        Level_4     = 4,
        Level_Auto  = 100

    } Level_t;

/**
* @brief Describes coding bit rate modes.
**/	
    typedef enum BitRateMode
    {
        BitRateMode_CQT = 0,
        BitRateMode_VBR = 1,
        BitRateMode_CBR = 2

    } BitRateMode_t;

/**
* @brief Describes encoding pass modes.
**/
    typedef enum BitRatePass
    {
        BitRatePass_Single  = 0,
        BitRatePass_Analyse = 1,
        BitRatePass_Encode  = 2

    } BitRatePass_t;

/**
* @brief Describes adaptive quantization modes.
**/
    typedef enum AdaptQuantMode
    {
        AdaptQuant_Luminance    = 0,
        AdaptQuant_Contrast     = 1,
        AdaptQuant_Complexity   = 2

    } AdaptQuantMode_t;

/**
* @brief Describes encoder presets.
**/
    typedef enum VideoType
    {
        VideoType_BASELINE    = 0,
        VideoType_CIF         = 1,
        VideoType_MAIN        = 2,
        VideoType_SVCD        = 3,
        VideoType_D1          = 4,
        VideoType_HIGH        = 5,
        VideoType_DVD         = 6,
        VideoType_HD_DVD      = 7,
        VideoType_BD          = 8,
        VideoType_BD_HDMV     = 9,
        VideoType_Silverlight = 10

    } VideoType_t;

/**
* @brief Describes field order modes.
**/
    typedef enum FieldOrder
    {
        FieldOrder_TFF      = 0,
        FieldOrder_BFF      = 1

    } FieldOrder_t;

/**
* @brief Describes interlace coding modes.
**/	
    typedef enum InterlaceMode
    {
        Mode_Progressive    = 0,
        Mode_FieldPicture   = 1,
        Mode_MBAFF          = 2,
        Mode_PAFF           = 3

    } InterlaceMode_t;

/**
* @brief Describes video pulldown flags.
**/	
    typedef enum VideoPullDownFlag
    {
        VideoPullDownFlag_None  = 0,
        VideoPullDownFlag_23    = 1,
        VideoPullDownFlag_32    = 2,
        VideoPullDownFlag_23_p  = 4,
        VideoPullDownFlag_32_p  = 5,
        VideoPullDownFlag_Auto  = 6

    } VideoPullDownFlag_t;

/**
* @brief Describes motion estimation modes.
**/	
    typedef enum MEMode
    {
        MEMode_Zero = 0,
        MEMode_Fast = 1,
        MEMode_HiQ  = 2

    } MEMode_t;

/**
* @brief Describes subpixel modes for motion estimation.
**/	
    typedef enum MESubpelMode
    {
        MESubpelMode_FullPel    = 0,
        MESubpelMode_HalfPel    = 1,
        MESubpelMode_QuarterPel = 2

    } MESubpelMode_t;

/**
* @brief Enables/disables video scene change detection mode.
**/	
    typedef enum VSCDMode
    {
        VSCDMode_OFF    = 0,
        VSCDMode_IDR    = 1

    } VSCDMode_t;
/**
* @brief Describes video format.
**/
    typedef enum VideoFormat
    {
        VideoFormat_Auto        = 0,
        VideoFormat_PAL         = 1,
        VideoFormat_NTSC        = 2,
        VideoFormat_SECAM       = 3,
        VideoFormat_MAC         = 4,
        VideoFormat_Unspecified = 5

    } VideoFormat_t;
/**
* @brief Describes picture format.
**/
    typedef enum PictureFormat
    {
        PicFormat_NA            = 0,
        PicFormat_ProgFrame     = 1,
        PicFormat_IntrFrame     = 2,
        PicFormat_Field         = 3

    } PictureFormat_t;
/**
* @brief Describes colorspace.
**/
    typedef enum ColorSpace
    {
        ColorSpace_NA      = -1,
        ColorSpace_YUV_420 = 0,
        ColorSpace_YUV_422 = 1,
        ColorSpace_YUV_444 = 2,
        ColorSpace_RGB_24  = 3,
        ColorSpace_RGB_32  = 4

    } ColorSpace_t;
/**
* @brief Describes CPU optimazation modes.
**/
    typedef enum CpuOptimization
    {
        CPU_Auto = 0,
        CPU_PlainC = 1,
        CPU_MMX = 2,
        CPU_MMX_Ext = 3,
        CPU_SSE = 4,
        CPU_SSE2 = 5,
        CPU_SSE3 = 6

    } CpuOptimization_t;

};


//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
//GUID                                    Type        Available range                     Default Val         Note
//MC_PROFILE                              VT_INT      see Profile_t                       [Profile_Advanced]  Switching between Profiles
//MC_LEVEL                                VT_INT      see Level_t                         [Level_Auto]        Switching between Levels
//VC1VE_performance_preset                VT_INT      [0, 15]                             [9]                 Switching between Performance Presets
//MC_GOP_LENGTH                           VT_INT      [0, 300]                            [30]                GOP length
//MC_GOP_BCOUNT                           VT_INT      [0, 7]                              [0]                 Reordering delay (number of b-frames + 1)
//VC1VE_interlace_mode                    VT_INT      [0, 1]                              [1]                 Switching between Sequence modes
//VC1VE_def_horizontal_size               VT_INT      [0, limit of INT]                   [320]               Horizontal size
//VC1VE_def_vertical_size                 VT_INT      [0, limit of INT]                   [240]               Vertical size
//VC1VE_search_range                      VT_INT      [0, 256]                            [64]                Motion Estimation Search range
//VC1VE_rd_optimization                   VT_INT      [0, 1]                              [1]                 Enable/Disable RD optimization
//VC1VE_quant_I                           VT_INT      [2, 62]                             [4]                 Quantizer for I-slice
//VC1VE_quant_P                           VT_INT      [2, 62]                             [6]                 Quantizer for P-slice
//VC1VE_quant_B                           VT_INT      [2, 62]                             [8]                 Quantizer for B-slice
//MC_BITRATE_MODE                         VT_INT      see BitRateMode_t                   [BitRateMode_VBR]   Switching between Bitrate modes
//MC_BITRATE_PASS                         VT_INT      see BitRatePass_t                   [BitRatePass_Simple] Multipass encoding mode
//VC1VE_bit_rate_buffer_size              VT_INT      [0, limit of INT]                   98868000            Bitrate buffer size (bits)
//MC_BITRATE_AVG                          VT_INT      [0, 288000000]                      600000              Average Bitrate size
//MC_BITRATE_MAX                          VT_INT      [VC1VE_bit_rate, 288000000]         1150000             Maximum Bitrate size
//VC1VE_inter_search_shape                VT_INT      [0, 1]                              [1]                 Use or not subblock search
//VC1VE_video_full_range                  VT_INT      [0, 1]                              [0]                 Enable/Disable Full range colors
//VC1VE_vbv_buffer_fullness               VT_INT      [0, 100]                            [50]                Initial VBV buffer fullness (%)
//VC1VE_use_deblocking_filter             VT_INT      [0, 1]                              [1]                 Use or not deblocking filter
//VC1VE_deblocking_alphaC0_offset         VT_INT      [-6, 6]                             [0]                 Deblocking alpha c0 offset
//VC1VE_deblocking_beta_offset            VT_INT      [-6, 6]                             [0]                 Deblocking beta offset
//MC_PRESET                               VT_INT      see VideoType_t                     [VideoType_BASELINE] Switching between Video Types
//VC1VE_video_pulldown_flag               VT_INT      see VideoPullDownFlag_t             [VideoPullDownFlag_NONE] Switching between Video PullDown Flag
//VC1VE_slice_arg                         VT_INT      [0, 8100]                           [1]                 Slice count
//VC1VE_me_subpel_mode                    VT_INT      see MESubpelMode_t                  [MESubpelMode_QuarterPel] Subpixel depth
//VC1VE_write_seq_end_code                VT_INT      [0, 1]                              [0]                 Enable/Disable writing end of sequence code
//VC1VE_vcsd_mode                         VT_INT      see VSCDMode_t                      [VSCDMode_IDR]      Enable/Disable scene change detector
//VC1VE_SetDefValues                      VT_INT      [0, 1]                              [0]                 Set default values
//VC1VE_VideoFormat                       VT_INT      see VideoFormat_t                   [VideoFormat_Auto]  Switching between Video formats
//VC1VE_FixedRate                         VT_INT      [0, 1]                              [0]                 Is sources frame rate fixed or not
//VC1VE_Framerate                         VT_R8       (1, 100)                            [in frame rate]     Frame rate if source frame rate is fixed
//VC1VE_OutFixedRate                      VT_INT      [0, 1]                              [0]                 Is output frame rate fixed or not
//VC1VE_OutFramerate                      VT_R8       (1, 100)                            [out frame rate]    Frame rate if output frame rate is fixed
//VC1VE_IsRunning                         VT_INT      [0, 1]                              [0]                 Is encoder running
//MC_ENCODED_FRAMES                       VT_INT      [0, limit of INT]                   READONLY            Encoded frames
//MC_FPS                                  VT_R8       [0, limit of DOUBLE]                READONLY            Average speed
//VC1VE_OriginalFramerate                 VT_R8       [0, limit of DOUBLE]                READONLY            Source stream declared frame rate
//MC_CALC_PSNR                            VT_INT      [0, 1]                              [0]                 Calculate overall PSNR or not
//MC_OVERALL_PSNR                         VT_R8       [0, limit of DOUBLE]                READONLY            Overall PSNR (luma and chroma)
//MC_BITRATE_REAL                         VT_R8       [0, limit of DOUBLE]                READONLY            Real average bitrate
//VC1VE_auto_aspect_ratio                 VT_INT      [0, 1]                              [1]                 Auto picture aspect ratio
//VC1VE_aspect_ratioX                     VT_INT      [1, limit of INT]                   [4]                 Picture aspect ratio x
//VC1VE_aspect_ratioY                     VT_INT      [1, limit of INT]                   [3]                 Picture aspect ratio y

//////////////////////////////////////////////////////////////////////////
//    Parameters GUIDs
//////////////////////////////////////////////////////////////////////////

/**
* @name Parameters GUIDs
* @brief Describes parameters GUIDs.
* @{
**/
// {07D0CFC4-C109-4e63-A274-3AA6647C0BF3}
static const GUID VC1VE_performance_preset = 
{ 0x7d0cfc4, 0xc109, 0x4e63, { 0xa2, 0x74, 0x3a, 0xa6, 0x64, 0x7c, 0xb, 0xf3 } };

// {7CD6EF75-4420-4b77-BC22-4158B3F98956}
static const GUID VC1VE_interlace_mode =
{0x7cd6ef75, 0x4420, 0x4b77, { 0xbc, 0x22, 0x41, 0x58, 0xb3, 0xf9, 0x89, 0x56}};

// {DE6D6008-1A49-428a-B2ED-E760FF32909E}
static const GUID VC1VE_def_horizontal_size =
{0xde6d6008, 0x1a49, 0x428a, { 0xb2, 0xed, 0xe7, 0x60, 0xff, 0x32, 0x90, 0x9e}};

// {D44C9617-C618-4d57-A992-DB8101911B4A}
static const GUID VC1VE_def_vertical_size =
{0xd44c9617, 0xc618, 0x4d57, { 0xa9, 0x92, 0xdb, 0x81, 0x1, 0x91, 0x1b, 0x4a}};

// {79686095-968E-4ce8-9247-6633F6F8DA3C}
static const GUID VC1VE_num_reference_frames =
{0x79686095, 0x968e, 0x4ce8, { 0x92, 0x47, 0x66, 0x33, 0xf6, 0xf8, 0xda, 0x3c}};

// {24A9A884-C4A0-4b5c-ACB3-212B3DBD7E04}
static const GUID VC1VE_search_range =
{0x24a9a884, 0xc4a0, 0x4b5c, { 0xac, 0xb3, 0x21, 0x2b, 0x3d, 0xbd, 0x7e, 0x4}};

// {9E63E1BB-08E3-42be-87CE-05D2F770361E}
static const GUID VC1VE_rd_optimization =
{0x9e63e1bb, 0x8e3, 0x42be, { 0x87, 0xce, 0x5, 0xd2, 0xf7, 0x70, 0x36, 0x1e}};

// {F630A138-8661-4e3a-BF03-955F973AB110}
static const GUID VC1VE_quant_I =
{0xf630a138, 0x8661, 0x4e3a, { 0xbf, 0x3, 0x95, 0x5f, 0x97, 0x3a, 0xb1, 0x10}};

// {10E2FDCC-1FB5-4cbc-BB5E-75567AB39F69}
static const GUID VC1VE_quant_P =
{0x10e2fdcc, 0x1fb5, 0x4cbc, { 0xbb, 0x5e, 0x75, 0x56, 0x7a, 0xb3, 0x9f, 0x69}};

// {901DA7FD-F639-493F-8AD0-9492AEA72E1F}
static const GUID VC1VE_quant_B =
{0x901da7fd, 0xf639, 0x493f, { 0x8a, 0xd0, 0x94, 0x92, 0xae, 0xa7, 0x2e, 0x1f}};

// {8D9B7175-1EB3-4f8d-A290-9415AC5BCBED}
static const GUID VC1VE_max_quant =
{0x8d9b7175, 0x1eb3, 0x4f8d, { 0xa2, 0x90, 0x94, 0x15, 0xac, 0x5b, 0xcb, 0xed}};

// {01FC9A21-B67C-43cb-9C14-11D452F49904}
static const GUID VC1VE_aq_strength_luminance = 
{ 0x1fc9a21, 0xb67c, 0x43cb, { 0x9c, 0x14, 0x11, 0xd4, 0x52, 0xf4, 0x99, 0x4 } };

// {9FC0F011-CFFD-4f89-B567-F44DEA725A28}
static const GUID VC1VE_aq_strength_contrast = 
{ 0x9fc0f011, 0xcffd, 0x4f89, { 0xb5, 0x67, 0xf4, 0x4d, 0xea, 0x72, 0x5a, 0x28 } };

// {FCB46931-6D3E-4365-822D-35BADB06D1D4}
static const GUID VC1VE_aq_strength_complexity = 
{ 0xfcb46931, 0x6d3e, 0x4365, { 0x82, 0x2d, 0x35, 0xba, 0xdb, 0x6, 0xd1, 0xd4 } };

// {76B17FDA-A1DA-45a3-B50E-4A2A2B35D108}
static const GUID VC1VE_hrd_buffer_size =
{0x76b17fda, 0xa1da, 0x45a3, { 0xb5, 0xe, 0x4a, 0x2a, 0x2b, 0x35, 0xd1, 0x8}};

// {8BC69F4F-6BE5-4fd7-90AE-D58DB21851A3}
static const GUID VC1VE_inter_search_shape =
{0x8bc69f4f, 0x6be5, 0x4fd7, { 0x90, 0xae, 0xd5, 0x8d, 0xb2, 0x18, 0x51, 0xa3}};

// {80B714D9-EDCD-4cd5-AED7-20FC376B1DA5}
static const GUID VC1VE_sample_aspect_ratioX =
{0x80b714d9, 0xedcd, 0x4cd5, { 0xae, 0xd7, 0x20, 0xfc, 0x37, 0x6b, 0x1d, 0xa5}};

// {603B2F96-C82F-4610-ADE3-4F2BA9C7BD33}
static const GUID VC1VE_sample_aspect_ratioY =
{0x603b2f96, 0xc82f, 0x4610, { 0xad, 0xe3, 0x4f, 0x2b, 0xa9, 0xc7, 0xbd, 0x33}};

// {4E9B99A5-A388-452a-9B2D-C26B1230B210}
static const GUID VC1VE_video_full_range =
{0x4e9b99a5, 0xa388, 0x452a, { 0x9b, 0x2d, 0xc2, 0x6b, 0x12, 0x30, 0xb2, 0x10}};

// {770776A5-76AF-4aa7-A7DA-CCB700945ABE}
static const GUID VC1VE_hrd_buffer_fullness =
{0x770776a5, 0x76af, 0x4aa7, { 0xa7, 0xda, 0xcc, 0xb7, 0x0, 0x94, 0x5a, 0xbe}};

// {B419761A-839F-4df7-85F8-E0FB2CC5D81F}
static const GUID VC1VE_hrd_buffer_fullness_trg =
{0xb419761a, 0x839f, 0x4df7, { 0x85, 0xf8, 0xe0, 0xfb, 0x2c, 0xc5, 0xd8, 0x1f}};

// {770776A5-76AF-4aa7-A7DA-CCB700945AC0}
static const GUID VC1VE_write_hrd_params =
{0x770776a5, 0x76af, 0x4aa7, { 0xa7, 0xda, 0xcc, 0xb7, 0x0, 0x94, 0x5a, 0xc0}};

// {5589AE1B-8F0D-4a82-B3C5-CC32A6084ABD}
static const GUID VC1VE_use_hrd = 
{ 0x5589ae1b, 0x8f0d, 0x4a82, { 0xb3, 0xc5, 0xcc, 0x32, 0xa6, 0x8, 0x4a, 0xbd } };

// {5FB3CC3C-67D6-42f6-AA9C-6AC05093661E}
static const GUID VC1VE_use_deblocking_filter =
{0x5fb3cc3c, 0x67d6, 0x42f6, { 0xaa, 0x9c, 0x6a, 0xc0, 0x50, 0x93, 0x66, 0x1e}};

// {6DFB21B7-9F43-4ccb-81BF-5723B10E0533}
static const GUID VC1VE_video_pulldown_flag =
{0x6dfb21b7, 0x9f43, 0x4ccb, { 0x81, 0xbf, 0x57, 0x23, 0xb1, 0xe, 0x5, 0x33}};

// {F519F267-3B17-481f-9F35-43CCA48FD098}
static const GUID VC1VE_slice_arg =
{0xf519f267, 0x3b17, 0x481f, { 0x9f, 0x35, 0x43, 0xcc, 0xa4, 0x8f, 0xd0, 0x98}};

// {5c1932D3-8860-454a-8A5B-4AE914AFE601}
static const GUID VC1VE_me_mode =
{0x5c1932d3, 0x8860, 0x454a, { 0x8a, 0x5b, 0x4a, 0xe9, 0x14, 0xaf, 0xe6, 0x01}};

// {8A5932D3-8860-454a-8A5B-4AE914AFE6E5}
static const GUID VC1VE_me_subpel_mode =
{0x8a5932d3, 0x8860, 0x454a, { 0x8a, 0x5b, 0x4a, 0xe9, 0x14, 0xaf, 0xe6, 0xe5}};

// {8A511FD3-8860-454a-8A5B-4AE914AFE6E5}
static const GUID VC1VE_me_use_4mv =
{0x8a511fd3, 0x8860, 0x454a, { 0x8a, 0x5b, 0x4a, 0xe9, 0x14, 0xaf, 0xe6, 0xe5}};

// {FED84B7F-2006-4c6d-A49B-F1C0FE6A4F6F}
static const GUID VC1VE_me_use_intensity_comp =
{0xfed84b7f, 0x2006, 0x4c6d, { 0xa4, 0x9b, 0xf1, 0xc0, 0xfe, 0x6a, 0x4f, 0x6f}};

// {8A511FD3-8330-454a-8A5B-4AE914AFE6E5}
static const GUID VC1VE_use_vs_trans =
{0x8a511fd3, 0x8330, 0x454a, { 0x8a, 0x5b, 0x4a, 0xe9, 0x14, 0xaf, 0xe6, 0xe5}};

// {CBFC3E4B-4E06-4ce1-9088-866CC96433FE}
static const GUID VC1VE_vcsd_mode = 
{0xcbfc3e4b, 0x4e06, 0x4ce1, { 0x90, 0x88, 0x86, 0x6c, 0xc9, 0x64, 0x33, 0xfe}};

// {B1E3E1BF-6225-4351-862C-66989AEE22B4}
static const GUID VC1VE_SetDefValues =
{0xb1e3e1bf, 0x6225, 0x4351, { 0x86, 0x2c, 0x66, 0x98, 0x9a, 0xee, 0x22, 0xb4}};

// {F8A1E96D-A489-4ec1-9418-8B7D048364EF}
static const GUID VC1VE_video_format =
{0xf8a1e96d, 0xa489, 0x4ec1, { 0x94, 0x18, 0x8b, 0x7d, 0x4, 0x83, 0x64, 0xef}};

// {D02685C0-0946-4740-A6E7-504D750FE4F1}
static const GUID VC1VE_OriginalFramerate =
{0xd02685c0, 0x946, 0x4740, { 0xa6, 0xe7, 0x50, 0x4d, 0x75, 0xf, 0xe4, 0xf1}};

// {413AA8BB-F85C-4768-B8F6-91AA7BCE3DE6}
static const GUID VC1VE_OriginalColorSpace =
{0x413aa8bb, 0xf85c, 0x4768, { 0xb8, 0xf6, 0x91, 0xaa, 0x7b, 0xce, 0x3d, 0xe6}};

// {654207C6-ECAD-4e8f-86F1-7819148D518A}
static const GUID VC1VE_OriginalPicFormat =
{0x654207c6, 0xecad, 0x4e8f, { 0x86, 0xf1, 0x78, 0x19, 0x14, 0x8d, 0x51, 0x8a}};

// {3F3F4E8F-07BA-4a0d-86B7-FA79907B373E}
static const GUID VC1VE_Framerate =
{0x3f3f4e8f, 0x7ba, 0x4a0d, { 0x86, 0xb7, 0xfa, 0x79, 0x90, 0x7b, 0x37, 0x3e}};

// {ACAC1419-D3D0-47ff-AC9F-889B1D143981}
static const GUID VC1VE_FixedRate =
{0xacac1419, 0xd3d0, 0x47ff, { 0xac, 0x9f, 0x88, 0x9b, 0x1d, 0x14, 0x39, 0x81}};

// {8F8A8859-A4C2-46c5-8043-18DA54F7034E}
static const GUID VC1VE_OutFramerate =
{0x8f8a8859, 0xa4c2, 0x46c5, { 0x80, 0x43, 0x18, 0xda, 0x54, 0xf7, 0x3, 0x4e}};

// {0CD0C8F4-2AE6-4c2c-A8A7-99967F2E12F2}
static const GUID VC1VE_OutFixedRate =
{0xcd0c8f4, 0x2ae6, 0x4c2c, { 0xa8, 0xa7, 0x99, 0x96, 0x7f, 0x2e, 0x12, 0xf2}};

// {D0D2A38C-8DF6-47b5-A662-47E6D39BCFA7}
static const GUID VC1VE_IsRunning =
{0xd0d2a38c, 0x8df6, 0x47b5, { 0xa6, 0x62, 0x47, 0xe6, 0xd3, 0x9b, 0xcf, 0xa7}};

// {34788FA2-8C41-4b97-9DA8-6B142377AED4}
static const GUID VC1VE_EncodedFrames =
{0x34788fa2, 0x8c41, 0x4b97, { 0x9d, 0xa8, 0x6b, 0x14, 0x23, 0x77, 0xae, 0xd4}};

// {E3ABEECF-D068-41bc-8FC2-A99A5EAA08C1}
static const GUID VC1VE_use_sample_aspect_ratio =
{0xe3abeecf, 0xd068, 0x41bc, { 0x8f, 0xc2, 0xa9, 0x9a, 0x5e, 0xaa, 0x8, 0xc1}};

// {72A90CC1-5DE1-4676-9D3C-2F9B5D074444}
static const GUID VC1VE_pic_aspect_ratio =
{0x72a90cc1, 0x5de1, 0x4676, { 0x9d, 0x3c, 0x2f, 0x9b, 0x5d, 0x7, 0x44, 0x44}};

// {72A90CC1-5DE1-4676-9D3C-2F9B5D074445}
static const GUID VC1VE_sample_aspect_ratio =
{0x72a90cc1, 0x5de1, 0x4676, { 0x9d, 0x3c, 0x2f, 0x9b, 0x5d, 0x7, 0x44, 0x45}};

// {93055399-DC58-4917-B206-88976B7BADEA}
static const GUID VC1VE_pic_aspect_ratioX =
{0x93055399, 0xdc58, 0x4917, { 0xb2, 0x6, 0x88, 0x97, 0x6b, 0x7b, 0xad, 0xea}};

// {4B844BD8-5B63-44df-9FF7-EE544AC19D85}
static const GUID VC1VE_pic_aspect_ratioY =
{0x4b844bd8, 0x5b63, 0x44df, { 0x9f, 0xf7, 0xee, 0x54, 0x4a, 0xc1, 0x9d, 0x85}};

// {749C8599-F66A-4161-B640-9B8B75D62EBD}
static const GUID VC1VE_field_order =
{0x749c8599, 0xf66a, 0x4161, { 0xb6, 0x40, 0x9b, 0x8b, 0x75, 0xd6, 0x2e, 0xbd}};

// {10AD7FE6-D3ED-4238-803B-630DBF7E8B0A}
static const GUID VC1VE_write_seq_end_code =
{0x10ad7fe6, 0xd3ed, 0x4238, { 0x80, 0x3b, 0x63, 0xd, 0xbf, 0x7e, 0x8b, 0xa}};

// {1220FF77-5B63-0002-9FF7-EE544AC19D85}
static const GUID VC1VE_disable_startcodes =
{0x1220ff77, 0x5b63, 0x0002, { 0x9f, 0xf7, 0xee, 0x54, 0x4a, 0xc1, 0x9d, 0x85}};

// {BAC16342-5B63-0002-9FF7-EE544AC19D85}
static const GUID VC1VE_enable_asf_binding =
{0xbac16342, 0x5b63, 0x0002, { 0x9f, 0xf7, 0xee, 0x54, 0x4a, 0xc1, 0x9d, 0x85}};

// {E47A1731-5B63-0002-9FF7-EE544AC19D85}
static const GUID VC1VE_black_norm_level =
{0xe47a1731, 0x5b63, 0x0002, { 0x9f, 0xf7, 0xee, 0x54, 0x4a, 0xc1, 0x9d, 0x85}};

// {0670ACD2-5113-0002-9FF7-EE544AC19D85}
static const GUID VC1VE_asf_compatible_timing =
{0x0670acd2, 0x5113, 0x0002, { 0x9f, 0xf7, 0xee, 0x54, 0x4a, 0xc1, 0x9d, 0x85}};

// {034BA1AF-5B63-0002-9FF7-EE5433019D85}
static const GUID VC1VE_input_queue_length =
{0x034ba1af, 0x5b63, 0x0002, { 0x9f, 0xf7, 0xee, 0x54, 0x33, 0x01, 0x9d, 0x85}};

// {899CF012-5B63-0002-9FF7-EE5433019D85}
static const GUID VC1VE_closed_entry =
{0x899cf012, 0x5b63, 0x0002, { 0x9f, 0xf7, 0xee, 0x54, 0x33, 0x01, 0x9d, 0x85}};

// {5E431140-B9E4-424f-A90F-F067EBFEC28F}
static const GUID VC1VE_cpu_optimization =
{0x5e431140, 0xb9e4, 0x424f, { 0xa9, 0xf, 0xf0, 0x67, 0xeb, 0xfe, 0xc2, 0x8f}};

// {39108716-B2F5-491c-9E9B-C2ABF38475B4}
static const GUID VC1VE_num_threads =
{0x39108716, 0xb2f5, 0x491c, { 0x9e, 0x9b, 0xc2, 0xab, 0xf3, 0x84, 0x75, 0xb4}};
/**@}**/

#endif // __PROPID_VC1ENC_HEADER__
