/** 
 @file  enc_mp4v_mc.h
 @brief  Property GUIDs for MainConcept MPEG-4 video encoder parameters.
 
 @verbatim
 File: enc_mp4v_mc.h

 Desc: Property GUIDs for MainConcept MPEG-4 video encoder parameters.
 
 Copyright (c) 2015 MainConcept GmbH or its affiliates.  All rights reserved.

 MainConcept and its logos are registered trademarks of MainConcept GmbH or its affiliates.  
 This software is protected by copyright law and international treaties.  Unauthorized 
 reproduction or distribution of any portion is prohibited by law.
 @endverbatim
 **/


#ifndef __MPEG4Enc_FILTER_PROPID__
#define __MPEG4Enc_FILTER_PROPID__

/**
* namespace MPEG4VE
* @brief MPEG4VE specific namespace
**/
namespace MPEG4VE
{
/**
* @brief Describes Encoder presets.
**/
	typedef enum EncoderPreset
	{
		EncPreset_SP_L0		    =   0,
		EncPreset_SP_L1		    =   1,
		EncPreset_SP_L2		    =   2,
		EncPreset_SP_L3		    =   3,
        EncPreset_SP_L4a        =   20,
        EncPreset_SP_L5         =   21,
		EncPreset_ASP_L0	    =   4,
		EncPreset_ASP_L1	    =   5,
		EncPreset_ASP_L2	    =   6,
		EncPreset_ASP_L3	    =   7,
		EncPreset_ASP_L4	    =   8,
        EncPreset_ASP_L5	    =   9,
		EncPreset_QCIF		    =   10,
		EncPreset_CIF		    =   11,
		EncPreset_halfD1	    =   12,
		EncPreset_D1		    =   13,
		EncPreset_720p		    =   14,
		EncPreset_IPOD		    =	15,
		EncPreset_PSP		    =	16,
        EncPreset_IPOD_640	    =	17,
        EncPreset_ShortHeader   =	30,
        EncPreset_H263_P3_L10   =   33,
        EncPreset_H263_P3_L20   =   34,
        EncPreset_H263_P3_L30   =   35,
        EncPreset_H263_P3_L40   =   36,
        EncPreset_H263_P3_L45   =   37,
        EncPreset_H263_P3_L50   =   38,
        EncPreset_H263_P3_L60   =   39,
        EncPreset_H263_P3_L70   =   40,
		EncPreset_Custom	    =   100

	} EncoderPreset_t;

/**
* @brief Describes Encoder profile.
**/
	typedef enum Profile
	{
		Profile_Simple      = 0,
		Profile_AdvSimple   = 1,

	} Profile_t;

/**
* @brief Describes H263 profile.
**/
  typedef enum ProfileH263
    {
        H263_Profile_0   = 0,
        H263_Profile_3   = 3,

    } ProfileH263_t;

/**
* @brief Describes Encoder level.
**/	
	typedef enum Level
	{
		Level_0     = 0,
		Level_1     = 1,
		Level_2     = 2,
		Level_3     = 3,
		Level_4     = 4,
		Level_5     = 5,
		Level_4a    = 10
	} Level_t;
 
/**
* @brief Describes H263 level.
**/ 
    typedef enum LevelH263
    {
        Level_10     = 10,
        Level_20     = 20,
        Level_30     = 30,
        Level_40     = 40,
        Level_45     = 45,
        Level_50     = 50,
        Level_60     = 60,
        Level_70     = 70,
    } LevelH263_t;

/**
* @brief Describes bit rate mode
**/
	typedef enum bitrate_mode_e
	{
		bitrate_mode_cbr		= 0,
		bitrate_mode_vbr		= 1,
		bitrate_mode_c_quality	= 2,
		bitrate_mode_c_quantizer= 3,

	} bitrate_mode_t;

/**
* @brief Describes encoding pass mode.
**/
    typedef enum bit_rate_pass_e
    {
        bit_rate_pass_simple  = 0,
        bit_rate_pass_analyse = 1,
        bit_rate_pass_encode  = 2

    } bit_rate_pass_t;

/**
* @brief Describes pulldown mode.
**/	
	typedef enum pulldown_flag_e
	{
		pulldown_flag_none	= 0,
		pulldown_flag_23	= 1,
		pulldown_flag_32	= 2,
		pulldown_flag_auto	= 10
	} pulldown_flag_t;

/**
* @brief Describes quantization type mode.
**/	
	typedef enum quant_type_e
	{
		quant_h263 = 0,
		quant_mpeg = 1

	} quant_type_t;
	

/**
* @brief Describes input colorspace.
**/	
	typedef enum ColorSpace_e
	{
		ColorSpace_NA      = -1,
		ColorSpace_YUV_420 = 0,
		ColorSpace_YUV_422 = 1,
		ColorSpace_YUV_444 = 2,
		ColorSpace_RGB_24  = 3,
		ColorSpace_RGB_32  = 4

	} ColorSpace_t;

/**
* @brief Describes pixel aspect ratio mode.
**/	
	typedef enum par_mode_e
	{
		par_mode_square		= 1,
		par_mode_4_3_pal	= 2,
		par_mode_4_3_ntsc	= 3,
		par_mode_16_9_pal	= 4,
		par_mode_16_9_ntsc	= 5,
		par_mode_custom		= 15,
        par_mode_auto		= 20

	} par_mode_t;

	/**
* @brief Describes h263 mode.
**/	
    typedef enum h263_mode_e
    {
        h263_off            = 0,
        h263_short_header   = 1,
        h263_full           = 2

    } h263_mode_t;
};

////////////////////////////////////////////////////////////////////////////////
//  GUID                            Value Type    Available range      Default Value             Note

//  MC_PRESET                         VT_INT      see EncoderPreset_t  [EncPreset_SP_L0]         Switching between presets

//  MC_PROFILE                        VT_INT      see Profile_t        [Profile_Simple]          Switching between Profiles
//  MC_LEVEL                          VT_INT      see Level_t          [Level_0]                 Switching between Levels

//  EM4VE_InterlaceMode               VT_INT      [0, 1]               [0]                       Switching between sequence modes
//  EM4VE_FieldOrder                  VT_INT      [0, 1]               [0]                       Field order (0 - TFF, 1 - BFF)
//  EM4VE_VideoPulldownFlag           VT_INT      see pulldown_flag_t  [pulldown_flag_auto]      Switching between Video PullDown Flag

//  EM4VE_SliceCount                  VT_INT      [0,number of MB rows][1]                       Slice count (0-auto)

//  GOP structure parameters
//  MC_GOP_LENGTH                     VT_INT      [1 - 300]            [30]                      Distance between key frames (I-pictures).
//  MC_GOP_BCOUNT                     VT_INT      [0 - 3]              [0]                       Number of B-pictures between reference frames.
//  EM4VE_SceneChange                 VT_BOOL     [0, 1]               [1]                       Enable/Disable scene change detector (0 - Off, 1 - on)
//  EM4VE_AdaptiveBVopCount           VT_BOOL     [0, 1]               [0]                       Enable/Disable mode for auto calculating of B-vop`s count

//  Rate parameters
//  EM4VE_InFps                       VT_R8       [1 - 60]             [25]                      Frame rate if input frame rate is fixed
//  EM4VE_OutFps                      VT_R8       [1 - 60]             [25]                      Frame rate if output frame rate is fixed
//  EM4VE_ChangeFps                   VT_BOOL     [0, 1]               [0]                       Is output frame rate fixed or not

//  Rate Control
//  MC_BITRATE_MODE                   VT_INT      see bitrate_mode_t   [bitrate_mode_c_quality]  Switching between bit-rate modes
//  MC_BITRATE_AVG                    VT_INT      [0 - 38400000]       [64000]                   Average Bit rate in bits
//  EM4VE_VBVBuffer                   VT_INT      [1024 - 288000000]   [655360]                  VBV Buffer size
//  EM4VE_write_vbv_params            VT_INT      [0, 1]               [0]                       Write or not custom VBV parameters
//  EM4VE_dont_limit_bitrate_by_level VT_INT      [0, 1]               [0]                       Disable restriction of target bit-rate by level
//  EM4VE_Quant_type                  VT_BOOL     see quant_type_t     [quant_h263]              Switching between quantization types
//  EM4VE_Quantizer_i                 VT_INT      [2 - 31]             [4]                       Quantizer for I-VOP
//  EM4VE_Quantizer_p                 VT_INT      [2 - 31]             [5]                       Quantizer for P-VOP
//  EM4VE_Quantizer_b                 VT_INT      [2 - 31]             [6]                       Quantizer for B-VOP
//  EM4VE_Min_quantizer               VT_INT      [2 - 30]             [2]                       Minimum Quantizer for all VOPs
//  EM4VE_Max_quantizer               VT_INT      [3 - 31]             [31]                      Maximum Quantizer for all VOPs
//  EM4VE_Quality                     VT_INT      [0 - 15]             [13]                      Quality index (0 - low quality, 15 - high quality)

//  Motion Estimation Parameters
//  EM4VE_ME_4MV                      VT_BOOL     [0, 1]               [1]                       Switching between vector numbers (0 - only 1 motion vector per macroblock, 1 - 4 mvs)
//  EM4VE_ME_HalfPixel                VT_BOOL     [0, 1]               [1]                       Subpixel depth ( 0 - full pixel motion vectors, 1 - half pixel)

//  Deinterlace parameter
//  EM4VE_Deinterlacing_enable        VT_BOOL     [0, 1]               [0]                       Switching between deinterlacing modes( 0 - Progressive stream, 1 - Inerlaced)
//  EM4VE_Alternate_scan              VT_BOOL     [0, 1]               [0]                       Enable/Disable the using of alternate vertical scan for interlaced VOPs

//  Bitstream parameters
//  EM4VE_H263Compatible              VT_BOOL     [0, 1]               [0]                       Switching between bitstream modes (0 - MPEG4, 1 - H263 bitstream)
//  EM4VE_ResyncMarker                VT_BOOL     [0, 1]               [0]                       Write or not resync marker for every slice
//  EM4VE_ClosedGov                   VT_BOOL     [0, 1]               [0]                       Makes or not makes all GOPs Closed.
//  EM4VE_VOL_every_IVOP              VT_BOOL     [0, 1]               [1]                       Write or not VOL header for every I-VOP
//  EM4VE_Send_Bvop_Mode              VT_BOOL     [0, 1]               [0]                       Switching between B-VOPs times( 0 - coding order, B-VOPs with own time, 1 - coding order, but time monotone increasing)
//  EM4VE_PadSkippedFrames            VT_INT      [0, 1]               [0]                       Pad skipped frames or not

//  MC_ASPECT_RATIO                   VT_INT      see par_mode_t       [1]                       Switching between pixel aspect ratio modes
//  EM4VE_aspect_ratio_x              VT_INT      [1, 1048576]         [1]                       Pixel aspect ratio x
//  EM4VE_aspect_ratio_y              VT_INT      [1, 1048576]         [1]                       Pixel aspect ratio y

//  EM4VE_num_threads                 VT_INT      [0, 16]              [0]                       Specifies maximum number of threads to be used

//  Statistic (Read only)
//  EM4VE_IsRunning                   VT_INT      [0, 1]               READONLY                  Is encoder running
//  EM4VE_ActQuant                    VT_INT      [2-31]               READONLY                  Actual quantizer
//  EM4VE_BitCount                    VT_I4       [0, limit of LONG]   READONLY                  Current sample size in bits
//  EM4VE_OriginalColorSpace          VT_INT      see ColorSpace_t     READONLY                  Original color space
//  EM4VE_OriginalInterlace           VT_INT      [-1, 1]              READONLY                  (0 - progressive, 1 - interlaced, -1 - not available)
//  MC_ENCODED_FRAMES                 VT_INT      [0, limit of INT]    READONLY                  Encoded frames
//  MC_FPS                            VT_R8       [0, limit of DOUBLE] READONLY                  Average speed
//  MC_CALC_PSNR                      VT_INT      [0, 1]               [0]                       Calculate overall PSNR or not
//  MC_OVERALL_PSNR                   VT_R8       [0, limit of DOUBLE] READONLY                  Overall PSNR (luma and chroma)
//  MC_BITRATE_REAL                   VT_R8       [0, limit of DOUBLE] READONLY                  Real average bitrate
//  EM4VE_OriginalFramerate           VT_R8       [0, limit of DOUBLE] READONLY                  Source stream declared frame rate
//  EM4VE_def_horizontal_size         VT_INT      [0, limit of INT]    READONLY                  Horizontal size
//  EM4VE_def_vertical_size           VT_INT      [0, limit of INT]    READONLY                  Vertical size

//  Common parameters
//  MC_OUT_SAMPLE_SIZE                VT_UI4      [0, limit of unsigned long] 1000000            Output sample size


// {082A8417-AC18-46cd-BABB-BE6CB244DA63}
static const GUID EM4VE_PerformancePreset = 
{ 0x82a8417, 0xac18, 0x46cd, { 0xba, 0xbb, 0xbe, 0x6c, 0xb2, 0x44, 0xda, 0x63 } };

// {CDDF7E32-4079-48c4-A4B3-8BD078E091F3}
static const GUID EM4VE_VBVBuffer = 
{ 0xcddf7e32, 0x4079, 0x48c4, { 0xa4, 0xb3, 0x8b, 0xd0, 0x78, 0xe0, 0x91, 0xf3 } };

// {54014978-4B9A-447f-AA40-7B8F99A4FB56}
static const GUID EM4VE_write_vbv_params = 
{ 0x54014978, 0x4b9a, 0x447f, { 0xaa, 0x40, 0x7b, 0x8f, 0x99, 0xa4, 0xfb, 0x56 } };

// {9FA038EA-2595-44c5-990C-CC90A974A31A}
static const GUID EM4VE_dont_limit_bitrate_by_level = 
{ 0x9fa038ea, 0x2595, 0x44c5, { 0x99, 0xc, 0xcc, 0x90, 0xa9, 0x74, 0xa3, 0x1a } };

// {4A462B7A-F79F-4630-B592-4220101D3920}
static const GUID EM4VE_SliceCount = 
{ 0x4a462b7a, 0xf79f, 0x4630, { 0xb5, 0x92, 0x42, 0x20, 0x10, 0x1d, 0x39, 0x20 } };

// {DC88F616-9D35-4247-8088-860BF69CE2C2}
static const GUID EM4VE_InterlaceMode = 
{ 0xdc88f616, 0x9d35, 0x4247, { 0x80, 0x88, 0x86, 0xb, 0xf6, 0x9c, 0xe2, 0xc2 } };

// {CE9A7412-84F9-4183-B15C-F287EF4D7F4E}
static const GUID EM4VE_FieldOrder = 
{ 0xce9a7412, 0x84f9, 0x4183, { 0xb1, 0x5c, 0xf2, 0x87, 0xef, 0x4d, 0x7f, 0x4e } };

// {23172A9D-EA10-4082-9498-A3BAF1E562CB}
static const GUID EM4VE_VideoPulldownFlag = 
{ 0x23172a9d, 0xea10, 0x4082, { 0x94, 0x98, 0xa3, 0xba, 0xf1, 0xe5, 0x62, 0xcb } };

// {ADDE6E00-F3DF-412a-A4DD-17E69EC014E6}
static const GUID EM4VE_Deinterlacing_enable = 
{ 0xadde6e00, 0xf3df, 0x412a, { 0xa4, 0xdd, 0x17, 0xe6, 0x9e, 0xc0, 0x14, 0xe6 } };

// {8F95EA13-E8EA-4297-9067-DAE3A06F1BDC}
static const GUID EM4VE_Alternate_scan = 
{ 0x8f95ea13, 0xe8ea, 0x4297, { 0x90, 0x67, 0xda, 0xe3, 0xa0, 0x6f, 0x1b, 0xdc } };

// {9A9A59A5-3F5B-4b74-B27F-CAF9F06E6E84}
static const GUID EM4VE_Quant_type = 
{ 0x9a9a59a5, 0x3f5b, 0x4b74, { 0xb2, 0x7f, 0xca, 0xf9, 0xf0, 0x6e, 0x6e, 0x84 } };

// {785674EA-7CEA-4322-875C-2CC840777078}
static const GUID EM4VE_Min_quantizer = 
{ 0x785674ea, 0x7cea, 0x4322, { 0x87, 0x5c, 0x2c, 0xc8, 0x40, 0x77, 0x70, 0x78 } };

// {E6AF6F1B-BC9A-45f8-A728-2C11CC2FFCAF}
static const GUID EM4VE_Max_quantizer = 
{ 0xe6af6f1b, 0xbc9a, 0x45f8, { 0xa7, 0x28, 0x2c, 0x11, 0xcc, 0x2f, 0xfc, 0xaf } };

// {6030610C-26DB-4594-B681-1B6D6BA0A7A8}
static const GUID EM4VE_Quantizer_i = 
{ 0x6030610c, 0x26db, 0x4594, { 0xb6, 0x81, 0x1b, 0x6d, 0x6b, 0xa0, 0xa7, 0xa8 } };

// {581C9A7E-E989-46c1-8EC1-2FEAF8B08852}
static const GUID EM4VE_Quantizer_p = 
{ 0x581c9a7e, 0xe989, 0x46c1, { 0x8e, 0xc1, 0x2f, 0xea, 0xf8, 0xb0, 0x88, 0x52 } };

// {614ECEDD-EF41-49b9-A2BB-AFE807391CCE}
static const GUID EM4VE_Quantizer_b = 
{ 0x614ecedd, 0xef41, 0x49b9, { 0xa2, 0xbb, 0xaf, 0xe8, 0x7, 0x39, 0x1c, 0xce } };

// {71E16043-9EAD-4f3a-8FF2-B5EE60D67EE2}
static const GUID EM4VE_AdaptiveQuantization = 
{ 0x71e16043, 0x9ead, 0x4f3a, { 0x8f, 0xf2, 0xb5, 0xee, 0x60, 0xd6, 0x7e, 0xe2 } };

// {EBD4C0CC-8B78-4f24-BD72-10B1B811DF6A}
static const GUID EM4VE_Quality = 
{ 0xebd4c0cc, 0x8b78, 0x4f24, { 0xbd, 0x72, 0x10, 0xb1, 0xb8, 0x11, 0xdf, 0x6a } };

// {A794A2C0-D826-462f-A5FE-444637017271}
static const GUID EM4VE_SceneChange = 
{ 0xa794a2c0, 0xd826, 0x462f, { 0xa5, 0xfe, 0x44, 0x46, 0x37, 0x1, 0x72, 0x71 } };

// {725D6176-D5B3-4945-941B-0422BA20AD87}
static const GUID EM4VE_AdaptiveBVopCount = 
{ 0x725d6176, 0xd5b3, 0x4945, { 0x94, 0x1b, 0x4, 0x22, 0xba, 0x20, 0xad, 0x87 } };

// {B15CF531-C30A-4bca-839D-FC3CA99552AD}
static const GUID EM4VE_H263Compatible = 
{ 0xb15cf531, 0xc30a, 0x4bca, { 0x83, 0x9d, 0xfc, 0x3c, 0xa9, 0x95, 0x52, 0xad } };

// {29DEDC65-DBA7-4cba-AB1D-F18BAB85EECF}
static const GUID EM4VE_DataPartitioned = 
{ 0x29dedc65, 0xdba7, 0x4cba, { 0xab, 0x1d, 0xf1, 0x8b, 0xab, 0x85, 0xee, 0xcf } };

// {5EF9DB2F-6A93-487b-B2A6-C82BA9F09E55}
static const GUID EM4VE_ResyncMarker = 
{ 0x5ef9db2f, 0x6a93, 0x487b, { 0xb2, 0xa6, 0xc8, 0x2b, 0xa9, 0xf0, 0x9e, 0x55 } };

// {5A393E13-4AE9-4bbc-BB29-E787D1A33200}
static const GUID EM4VE_ClosedGov = 
{ 0x5a393e13, 0x4ae9, 0x4bbc, { 0xbb, 0x29, 0xe7, 0x87, 0xd1, 0xa3, 0x32, 0x0 } };

// {FB5C642D-8EB5-498c-81B8-A4957792970E}
static const GUID EM4VE_VOL_every_IVOP = 
{ 0xfb5c642d, 0x8eb5, 0x498c, { 0x81, 0xb8, 0xa4, 0x95, 0x77, 0x92, 0x97, 0xe } };

// {0FE386FF-247E-4f52-8DE9-87ED2989DF4E}
static const GUID EM4VE_ME_4MV = 
{ 0xfe386ff, 0x247e, 0x4f52, { 0x8d, 0xe9, 0x87, 0xed, 0x29, 0x89, 0xdf, 0x4e } };

// {0B14FB90-D4D0-4696-9C33-322622FB0D70}
static const GUID EM4VE_ME_HalfPixel = 
{ 0xb14fb90, 0xd4d0, 0x4696, { 0x9c, 0x33, 0x32, 0x26, 0x22, 0xfb, 0xd, 0x70 } };

// {54DA179A-8416-43e2-A6E8-FB91046A7007}
static const GUID EM4VE_InFps = 
{ 0x54da179a, 0x8416, 0x43e2, { 0xa6, 0xe8, 0xfb, 0x91, 0x4, 0x6a, 0x70, 0x7 } };

// {88943C6C-6616-4b5b-B57D-A57C2231FC2C}
static const GUID EM4VE_OutFps = 
{ 0x88943c6c, 0x6616, 0x4b5b, { 0xb5, 0x7d, 0xa5, 0x7c, 0x22, 0x31, 0xfc, 0x2c } };

// {729B449D-C871-4b2a-ADF9-10854242FDFB}
static const GUID EM4VE_ChangeFps = 
{ 0x729b449d, 0xc871, 0x4b2a, { 0xad, 0xf9, 0x10, 0x85, 0x42, 0x42, 0xfd, 0xfb } };

// {065DD61A-FB5A-40bd-B6B9-B8D13B039891}
static const GUID EM4VE_Send_Bvop_Mode = 
{ 0x65dd61a, 0xfb5a, 0x40bd, { 0xb6, 0xb9, 0xb8, 0xd1, 0x3b, 0x3, 0x98, 0x91 } };

// {AE5405A1-94BF-4671-AABC-B3CD28F21292}
static const GUID EM4VE_PadSkippedFrames = 
{ 0xae5405a1, 0x94bf, 0x4671, { 0xaa, 0xbc, 0xb3, 0xcd, 0x28, 0xf2, 0x12, 0x92 } };

// {134A00C5-F2B6-4f62-81EF-005243513E46}
static const GUID EM4VE_AdvancedIntraCoding = 
{ 0x134a00c5, 0xf2b6, 0x4f62, { 0x81, 0xef, 0x0, 0x52, 0x43, 0x51, 0x3e, 0x46 } };

// {1699D6A0-55F2-4d80-BC02-B4426A6A6204}
static const GUID EM4VE_ACPrediction = 
{ 0x1699d6a0, 0x55f2, 0x4d80, { 0xbc, 0x2, 0xb4, 0x42, 0x6a, 0x6a, 0x62, 0x4 } };

// {39CEAB46-B95D-4f2b-9754-4F79CE74DBF6}
static const GUID EM4VE_UnrestrictedMV = 
{ 0x39ceab46, 0xb95d, 0x4f2b, { 0x97, 0x54, 0x4f, 0x79, 0xce, 0x74, 0xdb, 0xf6 } };

// {3BC5ACB3-1D4E-4662-A922-543AA2A60972}
static const GUID EM4VE_SliceStructured= 
{ 0x3bc5acb3, 0x1d4e, 0x4662, { 0xa9, 0x22, 0x54, 0x3a, 0xa2, 0xa6, 0x9, 0x72 } };

// {E0BB15BB-744F-4e27-9C40-3F39E3D29A07}
static const GUID EM4VE_ModifiedQuantization = 
{ 0xe0bb15bb, 0x744f, 0x4e27, { 0x9c, 0x40, 0x3f, 0x39, 0xe3, 0xd2, 0x9a, 0x7 } };

// {F7D69E4C-5273-4559-9D7A-94F2A6BF2DA7}
static const GUID EM4VE_DeblockingFilter = 
{ 0xf7d69e4c, 0x5273, 0x4559, { 0x9d, 0x7a, 0x94, 0xf2, 0xa6, 0xbf, 0x2d, 0xa7 } };


// Statistic parameters Read only

// {06A7B14C-20BB-4944-B6D0-C4AC83FE507F}
static const GUID EM4VE_def_horizontal_size = 
{ 0x6a7b14c, 0x20bb, 0x4944, { 0xb6, 0xd0, 0xc4, 0xac, 0x83, 0xfe, 0x50, 0x7f } };

// {BCF9C2B3-A1AA-4009-8655-4B5E314117A4}
static const GUID EM4VE_def_vertical_size = 
{ 0xbcf9c2b3, 0xa1aa, 0x4009, { 0x86, 0x55, 0x4b, 0x5e, 0x31, 0x41, 0x17, 0xa4 } };

// {BB074DF6-0358-4f88-9509-78B1B2C6A291}
static const GUID EM4VE_OriginalFramerate = 
{ 0xbb074df6, 0x358, 0x4f88, { 0x95, 0x9, 0x78, 0xb1, 0xb2, 0xc6, 0xa2, 0x91 } };

// {F3DCB25F-482F-4def-9055-EDED1BF51182}
static const GUID EM4VE_ActQuant = 
{ 0xf3dcb25f, 0x482f, 0x4def, { 0x90, 0x55, 0xed, 0xed, 0x1b, 0xf5, 0x11, 0x82 } };

// {B47273D2-8E5A-434d-9FFF-D8D697A614AE}
static const GUID EM4VE_BitCount = 
{ 0xb47273d2, 0x8e5a, 0x434d, { 0x9f, 0xff, 0xd8, 0xd6, 0x97, 0xa6, 0x14, 0xae } };

// {25A8700A-C326-4052-BDF7-223AA11193E5}
static const GUID EM4VE_OriginalColorSpace = 
{ 0x25a8700a, 0xc326, 0x4052, { 0xbd, 0xf7, 0x22, 0x3a, 0xa1, 0x11, 0x93, 0xe5 } };

// {FEA7C0FB-F152-4ce3-A994-2E80FE5EFD3D}
static const GUID EM4VE_OriginalInterlace = 
{ 0xfea7c0fb, 0xf152, 0x4ce3, { 0xa9, 0x94, 0x2e, 0x80, 0xfe, 0x5e, 0xfd, 0x3d } };

// {97EEE7C2-369D-46af-AFD5-2D19C25A5D2B}
static const GUID EM4VE_IsRunning = 
{ 0x97eee7c2, 0x369d, 0x46af, { 0xaf, 0xd5, 0x2d, 0x19, 0xc2, 0x5a, 0x5d, 0x2b } };

// {DE580597-4F6B-4458-84D2-6BE547B6A541}
static const GUID EM4VE_SetDefValues = 
{ 0xde580597, 0x4f6b, 0x4458, { 0x84, 0xd2, 0x6b, 0xe5, 0x47, 0xb6, 0xa5, 0x41 } };

// {bcc3c2dd-fcec-49c8-8d5e-af0389b0a2b6}
static const GUID EM4VE_num_threads = 
{ 0xbcc3c2dd, 0xfcec, 0x49c8, { 0x8d, 0x5e, 0xaf, 0x03, 0x89, 0xb0, 0xa2, 0xb6 } };

// {0326C2ED-E9EF-4179-8882-FA5C2C413844}
static const GUID EM4VE_aspect_ratio_x = 
{ 0x326c2ed, 0xe9ef, 0x4179, { 0x88, 0x82, 0xfa, 0x5c, 0x2c, 0x41, 0x38, 0x44 } };

// {B5C4ABC0-6582-44b8-B6FE-30F24239EA83}
static const GUID EM4VE_aspect_ratio_y = 
{ 0xb5c4abc0, 0x6582, 0x44b8, { 0xb6, 0xfe, 0x30, 0xf2, 0x42, 0x39, 0xea, 0x83 } };

// {61CD7814-F9F9-46E9-BA89-9946024CB8B9}
static const GUID EM4VE_PixRangeFlag = 
{ 0x61cd7814, 0xf9f9, 0x46e9, { 0xba, 0x89, 0x99, 0x46, 0x2, 0x4c, 0xb8, 0xb9 } };


#endif //__MPEG4Enc_FILTER_PROPID__

