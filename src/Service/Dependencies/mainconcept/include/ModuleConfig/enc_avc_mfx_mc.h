/** 
 @file  enc_avc_mfx_mc.h
 @brief Property GUIDs for MainConcept AVC/H.264 encoder for Intel QSV parameters.
 
 @verbatim
 File: enc_avc_mfx_mc.h

 Desc: Property GUIDs for MainConcept AVC/H.264 encoder for Intel QSV parameters.
 
 Copyright (c) 2015 MainConcept GmbH or its affiliates.  All rights reserved.

 MainConcept and its logos are registered trademarks of MainConcept GmbH or its affiliates.  
 This software is protected by copyright law and international treaties.  Unauthorized 
 reproduction or distribution of any portion is prohibited by law.

 @endverbatim
 **/

#if !defined(__PROPID_H264ENC_HEADER__)
#define __PROPID_H264ENC_HEADER__

/**
* namespace H264VE
* @brief H264VE specific namespace
**/

namespace H264VE
{
    typedef enum Profile
/**
* @brief Describes encoder profile.
**/
    {
        Profile_Baseline    = 0,
        Profile_Main        = 1,
        Profile_High        = 3,

    } Profile_t;

/**
* @brief Describes level.
**/	
    typedef enum Level
    {
        Level_1     = 10,
        Level_1b    = 16,
        Level_11    = 11,
        Level_12    = 12,
        Level_13    = 13,
        Level_2     = 20,
        Level_21    = 21,
        Level_22    = 22,
        Level_3     = 30,
        Level_31    = 31,
        Level_32    = 32,
        Level_4     = 40,
        Level_41    = 41,
        Level_42    = 42,
        Level_5     = 50,
        Level_51    = 51,
        Level_Auto  = 100

    } Level_t;


/**
* @brief Describes bit rate mode.
**/	
    typedef enum BitRateMode
    {
        BitRateMode_CBR = 0,
        BitRateMode_CQT = 1,
        BitRateMode_VBR = 2

    } BitRateMode_t;


/**
* @brief Describes encoder presets.
**/
    typedef enum VideoType
    {
        VideoType_BASELINE          = 0,
        VideoType_CIF               = 1,
        VideoType_MAIN              = 2,
        VideoType_SVCD              = 3,
        VideoType_D1                = 4,
        VideoType_HIGH              = 5,
        VideoType_DVD               = 6,
        VideoType_HD_DVD            = 7,
        VideoType_BD                = 8,
        VideoType_BD_HDMV           = 9,
        VideoType_PSP               = 10,
        VideoType_HDV_HD1           = 11,
        VideoType_HDV_HD2           = 12,
        VideoType_iPOD              = 15,
        VideoType_AVCHD             = 14,
        VideoType_1SEG              = 16,
        VideoType_DIVXPLUS          = 22,
        VideoType_3GP               = 25,
        VideoType_Silverlight       = 26

    } VideoType_t;

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
* @brief Describes colorspaces.
**/	
    typedef enum ColorSpace
    {
        ColorSpace_NA      = -1,
        ColorSpace_YUV_420 = 0

    } ColorSpace_t;

/**
* @brief Describes FPS conversion types.
**/
    typedef enum FpsConvType
    {
        FpscType_Fps        = 0,
        FpscType_Timestamps = 1

    } FpsConvType_t;


/**
* @brief Describes Time stamp mode.
**/	
    typedef enum TimestampMode
    {
        TSMode_Original = 0,    // do not adjust, use exact input timestamps
        TSMode_AVI      = 1     // AVI-compatibility mode - ascending, non-overlapping timestamps (must exist for every sample)

    } TimestampMode_t;

/**
* @brief Describes encoder output media type.
**/	
    typedef enum OutputMediatype
    {
        OutMT_Original = 0,     // regular one
        OutMT_VSS      = 1      // VSSH fourCC

    } OutputMediatype_t;

    typedef enum ImplementationType
    {
        Impl_Auto = 0,     
        Impl_Software   = 1,
        Impl_Hardware   = 2 
    } ImplementationType_t;
};


//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
//    GUID                                  Type        Available range                     Default Val         Note
//MC_PRESET                                VT_INT      see VideoType_t                     [VideoType_BASELINE] Switching between presets
//EH264VE_VideoFormat                       VT_INT      see VideoFormat_t                   [VideoFormat_Auto]  Switching between Video formats

//MC_PROFILE                               VT_INT      see Profile_t                       [Profile_Baseline]  Switching between Profiles
//MC_LEVEL                                 VT_INT      see Level_t                         [Level_Auto]        Switching between Levels

//EH264VE_interlace_mode                    VT_INT      [0, 1]                              [0]                 Switching between sequence modes
//EH264VE_field_order                       VT_INT      [0, 1]                              [0]                 Field order (0 - TFF, 1 - BFF)
//EH264VE_slice_arg                         VT_INT      [0, number of MB rows]              [1]                 Slice count

//MC_GOP_LENGTH                            VT_INT      [1, 300]                            [33]                Max GOP length
//MC_GOP_BCOUNT                            VT_INT      [0, 3]                              [0]                 Max number of b-frames
//EH264VE_idr_frequency                     VT_INT      [0, limit of INT]                   [1]                 Frequency of IDR-pictures
//EH264VE_adapt_b                           VT_INT      [0, 1]                              [0]                 Enable/Disable adaptive B-frames placement

//MC_BITRATE_MODE                          VT_INT      see BitRateMode_t                   [BitRateMode_VBR]   Switching between rate control modes
//EH264VE_quant_pI                          VT_INT      [0, 51]                             [25]                Quantizer for I-slices
//EH264VE_quant_pP                          VT_INT      [0, 51]                             [25]                Quantizer for P-slices
//EH264VE_quant_pB                          VT_INT      [0, 51]                             [27]                Quantizer for B-slices
//MC_BITRATE_AVG                           VT_INT      [1024, 288000000]                   [600000]            Average bit rate (bits per second)
//MC_BITRATE_MAX                           VT_INT      [EH264VE_bit_rate, 288000000]       [1149952]           Hypothetical stream scheduler rate (bits per second)
//EH264VE_bit_rate_buffer_size              VT_INT      [1024, 288000000]                   [1149984]           Bit-rate buffer size (bytes)
//EH264VE_vbv_buffer_fullness               VT_INT      [1, limit of INT]                   [67500]             Initial VBV buffer fullness (90 kHz)

//EH264VE_num_reference_frames              VT_INT      [0, 16]                             [1]                 Number of reference frames

//EH264VE_fast_rd_optimization              VT_INT      [0, 1]                              [1]                 Enable/Disable fast RD optimization

//EH264VE_use_sample_aspect_ratio           VT_INT      [0, 1]                              [0]                 Indicates whether to use sample or picture AR
//EH264VE_auto_aspect_ratio                 VT_INT      [0, 1]                              [1]                 Auto picture aspect ratio
//EH264VE_aspect_ratioX                     VT_INT      [1, 1048576]                        [4]                 Picture aspect ratio x
//EH264VE_aspect_ratioY                     VT_INT      [1, 1048576]                        [3]                 Picture aspect ratio y
//EH264VE_auto_sample_aspect_ratio          VT_INT      [0, 1]                              [1]                 Auto sample aspect ratio
//EH264VE_sample_aspect_ratioX              VT_INT      [1, 1048576]                        [1]                 Sample aspect ratio x
//EH264VE_sample_aspect_ratioY              VT_INT      [1, 1048576]                        [1]                 Sample aspect ratio y

//EH264VE_num_threads                       VT_INT      [0, 16]                             [0]                 Specifies maximum number of threads to be used

//EH264VE_FixedRate                         VT_INT      [0, 1]                              [0]                 Is sources frame rate fixed or not
//EH264VE_Framerate                         VT_R8       [1, 100]                            [in frame rate]     Frame rate if source frame rate is fixed
//EH264VE_OutFixedRate                      VT_INT      [0, 1]                              [0]                 Is output frame rate fixed or not
//EH264VE_OutFramerate                      VT_R8       [1, 100]                            [in frame rate]     Frame rate if output frame rate is fixed

//EH264VE_SetDefValues                      VT_INT      [0, 1]                              [0]                 Set default values

//EH264VE_OriginalFramerate                 VT_R8       [0, limit of DOUBLE]                READONLY            Source stream declared frame rate
//EH264VE_OriginalInterlace                 VT_INT      [-1, 1]                             READONLY            (0 - progressive, 1 - interlaced, -1 - not available)
//EH264VE_OriginalColorSpace                VT_INT      see ColorSpace_t                    READONLY            Original colour space
//EH264VE_IsRunning                         VT_INT      [0, 1]                              READONLY            Is encoder running
//EH264VE_def_horizontal_size               VT_INT      [0, limit of INT]                   READONLY            Horizontal size
//EH264VE_def_vertical_size                 VT_INT      [0, limit of INT]                   READONLY            Vertical size


/**
* @name Parameters GUIDs
* @{
**/

/** 
<dl><dt><b>GUID:</b></dt><dd>{F8A1E96D-A489-4ec1-9418-8B7D048364EF}</dd></dl>
<dl><dt><b>Description:</b></dt><dd>This parameter specifies the video format.</dd></dl>
<dl><dt><b>Type:</b></dt><dd>VT_INT</dd></dl>
<dl><dt><b>Available Values:</b></dt>
<dd>
	@li VideoFormat_Auto
	@li VideoFormat_PAL
	@li VideoFormat_NTSC
	@li VideoFormat_SECAM
	@li VideoFormat_MAC
	@li VideoFormat_Unspecified
</dd></dl>*/
// {F8A1E96D-A489-4ec1-9418-8B7D048364EF}
static const GUID EH264VE_VideoFormat =
{0xf8a1e96d, 0xa489, 0x4ec1, {0x94, 0x18, 0x8b, 0x7d, 0x4, 0x83, 0x64, 0xef}};

/** 
<dl><dt><b>GUID:</b></dt><dd>{7CD6EF75-4420-4b77-BC22-4158B3F98956}</dd></dl>
<dl><dt><b>Description:</b></dt><dd>This parameter specifies the picture coding mode – field or frame.</dd></dl>
<dl><dt><b>Type:</b></dt><dd>VT_INT</dd></dl>
<dl><dt><b>Available Values:</b></dt>
<dd>
@li Frame
@li Field
@li MBAFF
</dd></dl>
*/
// {7CD6EF75-4420-4b77-BC22-4158B3F98956}
static const GUID EH264VE_interlace_mode =
{0x7cd6ef75, 0x4420, 0x4b77, {0xbc, 0x22, 0x41, 0x58, 0xb3, 0xf9, 0x89, 0x56}};

/** 
<dl><dt><b>GUID:</b></dt><dd>{749C8599-F66A-4161-B640-9B8B75D62EBD}</dd></dl>
<dl><dt><b>Description:</b></dt><dd>This parameter specifies the field order.</dd></dl>
<dl><dt><b>Type:</b></dt><dd>VT_INT</dd></dl>
<dl><dt><b>Available Values:</b></dt>
<dd>
@li Top Field First
@li Bottom Field First
</dd></dl>
*/
// {749C8599-F66A-4161-B640-9B8B75D62EBD}
static const GUID EH264VE_field_order =
{0x749c8599, 0xf66a, 0x4161, {0xb6, 0x40, 0x9b, 0x8b, 0x75, 0xd6, 0x2e, 0xbd}};

/** 
<dl><dt><b>GUID:</b></dt><dd>
{F519F267-3B17-481f-9F35-43CCA48FD098}
</dd></dl>
<dl><dt><b>Description:</b></dt><dd>
This parameter specifies the number of slices per picture.
</dd></dl>
<dl><dt><b>Type:</b></dt><dd>
VT_INT
</dd></dl>
<dl><dt><b>Available Values:</b></dt>
<dd>
From 0 up to number of MB rows in picture
</dd></dl>
*/
// {F519F267-3B17-481f-9F35-43CCA48FD098}
static const GUID EH264VE_slice_arg =
{0xf519f267, 0x3b17, 0x481f, {0x9f, 0x35, 0x43, 0xcc, 0xa4, 0x8f, 0xd0, 0x98}};

/** 
<dl><dt><b>GUID:</b></dt><dd>
{EECB285C-BDE6-4da5-9A9E-4C366BCACD94}
</dd></dl>
<dl><dt><b>Description:</b></dt><dd>
This parameter specifies the frequency of IDR pictures.
</dd></dl>
<dl><dt><b>Type:</b></dt><dd>
VT_INT
</dd></dl>
<dl><dt><b>Available Values:</b></dt>
<dd>
From 0 up to limit of INT.
</dd></dl>
*/
// {EECB285C-BDE6-4da5-9A9E-4C366BCACD94}
static const GUID EH264VE_idr_frequency =
{0xeecb285c, 0xbde6, 0x4da5, {0x9a, 0x9e, 0x4c, 0x36, 0x6b, 0xca, 0xcd, 0x94}};

/**
<dl><dt><b>GUID:</b></dt><dd>
{956A704B-00FC-436c-921E-BC6158955A82}
</dd></dl>
<dl><dt><b>Description:</b></dt><dd>
This parameter enables/disables the adaptive B-frames placement.
</dd></dl>
<dl><dt><b>Type:</b></dt><dd>
VT_INT
</dd></dl>
<dl><dt><b>Available Values:</b></dt>
<dd>
@li Disable
@li Enable
</dd></dl>
*/
// {956A704B-00FC-436c-921E-BC6158955A82}
static const GUID EH264VE_adapt_b =
{0x956a704b, 0xfc, 0x436c, {0x92, 0x1e, 0xbc, 0x61, 0x58, 0x95, 0x5a, 0x82}};

/** 
<dl><dt><b>GUID:</b></dt><dd>
{F630A138-8661-4e3a-BF03-955F973AB110}
</dd></dl>
<dl><dt><b>Description:</b></dt><dd>
This parameter specifies the quantization parameter for I-slices.
</dd></dl>
<dl><dt><b>Type:</b></dt><dd>
VT_INT
</dd></dl>
<dl><dt><b>Available Values:</b></dt>
<dd>
From 0 up to 51.
</dd></dl>
*/
// {F630A138-8661-4e3a-BF03-955F973AB110}
static const GUID EH264VE_quant_pI =
{0xf630a138, 0x8661, 0x4e3a, {0xbf, 0x3, 0x95, 0x5f, 0x97, 0x3a, 0xb1, 0x10}};

/** 
<dl><dt><b>GUID:</b></dt><dd>
{10E2FDCC-1FB5-4cbc-BB5E-75567AB39F69}
</dd></dl>
<dl><dt><b>Description:</b></dt><dd>
This parameter specifies the quantization parameter for P-slices.
</dd></dl>
<dl><dt><b>Type:</b></dt><dd>
VT_INT
</dd></dl>
<dl><dt><b>Available Values:</b></dt>
<dd>
From 0 up to 51.
</dd></dl>
*/
// {10E2FDCC-1FB5-4cbc-BB5E-75567AB39F69}
static const GUID EH264VE_quant_pP =
{0x10e2fdcc, 0x1fb5, 0x4cbc, {0xbb, 0x5e, 0x75, 0x56, 0x7a, 0xb3, 0x9f, 0x69}};

/** 
<dl><dt><b>GUID:</b></dt><dd>
{901DA7FD-F639-493f-8AD0-9492AEA72E1F}
</dd></dl>
<dl><dt><b>Description:</b></dt><dd>
This parameter specifies the quantization parameter for B-slices.
</dd></dl>
<dl><dt><b>Type:</b></dt><dd>
VT_INT
</dd></dl>
<dl><dt><b>Available Values:</b></dt>
<dd>
From 0 up to 51.
</dd></dl>
*/
// {901DA7FD-F639-493f-8AD0-9492AEA72E1F}
static const GUID EH264VE_quant_pB =
{0x901da7fd, 0xf639, 0x493f, {0x8a, 0xd0, 0x94, 0x92, 0xae, 0xa7, 0x2e, 0x1f}};

/** 
<dl><dt><b>GUID:</b></dt><dd>
{76B17FDA-A1DA-45a3-B50E-4A2A2B35D108}
</dd></dl>
<dl><dt><b>Description:</b></dt><dd>
This parameter specifies the coded picture buffer size in bytes.
</dd></dl>
<dl><dt><b>Type:</b></dt><dd>
VT_INT
</dd></dl>
<dl><dt><b>Available Values:</b></dt>
<dd>
From 1024 up to 36000000.
</dd></dl>
*/
// {76B17FDA-A1DA-45a3-B50E-4A2A2B35D108}
static const GUID EH264VE_bit_rate_buffer_size =
{0x76b17fda, 0xa1da, 0x45a3, {0xb5, 0xe, 0x4a, 0x2a, 0x2b, 0x35, 0xd1, 0x8}};

/** 
<dl><dt><b>GUID:</b></dt><dd>
{770776A5-76AF-4aa7-A7DA-CCB700945ABE}
</dd></dl>
<dl><dt><b>Description:</b></dt><dd>
This parameter specifies the initial HRD buffer fullness in percent units. Note that the value is actually inverted, e.g. if one sets EH264VE_vbv_buffer_fullness to 10, initial CPB removal delay will be 0.9 * CPB size / HSS rate.
</dd></dl>
<dl><dt><b>Type:</b></dt><dd>
VT_INT
</dd></dl>
<dl><dt><b>Available Values:</b></dt>
<dd>
From 1 to 99.
</dd></dl>
*/
// {770776A5-76AF-4aa7-A7DA-CCB700945ABE}
static const GUID EH264VE_vbv_buffer_fullness =
{0x770776a5, 0x76af, 0x4aa7, {0xa7, 0xda, 0xcc, 0xb7, 0x0, 0x94, 0x5a, 0xbe}};

/** 
<dl><dt><b>GUID:</b></dt><dd>
{79686095-968E-4CE8-9247-6633F6F8DA3C}
</dd></dl>
<dl><dt><b>Description:</b></dt><dd>
This parameter specifies the number of reference frames.
</dd></dl>
<dl><dt><b>Type:</b></dt><dd>
VT_INT
</dd></dl>
<dl><dt><b>Available Values:</b></dt>
<dd>
From 0 up to 16.
</dd></dl>
*/
// {79686095-968E-4ce8-9247-6633F6F8DA3C}
static const GUID EH264VE_num_reference_frames =
{0x79686095, 0x968e, 0x4ce8, {0x92, 0x47, 0x66, 0x33, 0xf6, 0xf8, 0xda, 0x3c}};

/** 
<dl><dt><b>GUID:</b></dt><dd>
{48698A0E-D675-46B6-86EF-3D4E2C3ECAC3}
</dd></dl>
<dl><dt><b>Description:</b></dt><dd>
This parameter enables/disables the fast rate-distortion optimization method.
</dd></dl>
<dl><dt><b>Type:</b></dt><dd>
VT_INT
</dd></dl>
<dl><dt><b>Available Values:</b></dt>
<dd>
@li Disable
@li Enable
@li Enable fast rate-distortion optimization on non-reference frames
</dd></dl>
*/
// {48698A0E-D675-46b6-86EF-3D4E2C3ECAC3}
static const GUID EH264VE_fast_rd_optimization =
{0x48698a0e, 0xd675, 0x46b6, {0x86, 0xef, 0x3d, 0x4e, 0x2c, 0x3e, 0xca, 0xc3}};

/** 
<dl><dt><b>GUID:</b></dt><dd>
{E3ABEECF-D068-41bc-8FC2-A99A5EAA08C1}
</dd></dl>
<dl><dt><b>Description:</b></dt><dd>
This parameter selects the use of sample or picture aspect ratio.
</dd></dl>
<dl><dt><b>Type:</b></dt><dd>
VT_INT
</dd></dl>
<dl><dt><b>Available Values:</b></dt>
<dd>
@li Use sample aspect ratio
@li Use picture aspect ratio
</dd></dl>
*/
// {E3ABEECF-D068-41bc-8FC2-A99A5EAA08C1}
static const GUID EH264VE_use_sample_aspect_ratio =
{0xe3abeecf, 0xd068, 0x41bc, {0x8f, 0xc2, 0xa9, 0x9a, 0x5e, 0xaa, 0x8, 0xc1}};

/** 
<dl><dt><b>GUID:</b></dt><dd>
{B80A21B6-5DE1-4676-9D3C-2F9B5D074444}
</dd></dl>
<dl><dt><b>Description:</b></dt><dd>
This parameter selects the use of automatic aspect ratio or the user-defined one.
</dd></dl>
<dl><dt><b>Type:</b></dt><dd>
VT_INT
</dd></dl>
<dl><dt><b>Available Values:</b></dt>
<dd>
@li Auto
@li User-defined
</dd></dl>
*/
// {B80A21B6-5DE1-4676-9D3C-2F9B5D074444}
static const GUID EH264VE_auto_aspect_ratio =
{0xb80a21b6, 0x5de1, 0x4676, {0x9d, 0x3c, 0x2f, 0x9b, 0x5d, 0x7, 0x44, 0x44}};

/** 
<dl><dt><b>GUID:</b></dt><dd>
{93055399-DC58-4917-B206-88976B7BADEA}
</dd></dl>
<dl><dt><b>Description:</b></dt><dd>
This parameter specifies the picture aspect ratio X (width) and is only applied if the user-defined aspect ratio is enabled.
</dd></dl>
<dl><dt><b>Type:</b></dt><dd>
VT_INT
</dd></dl>
<dl><dt><b>Available Values:</b></dt>
<dd>
From 1 up to 1048576.
</dd></dl>
*/
// {93055399-DC58-4917-B206-88976B7BADEA}
static const GUID EH264VE_aspect_ratioX =
{0x93055399, 0xdc58, 0x4917, {0xb2, 0x6, 0x88, 0x97, 0x6b, 0x7b, 0xad, 0xea}};

/** 
<dl><dt><b>GUID:</b></dt><dd>
{4B844BD8-5B63-44df-9FF7-EE544AC19D85}
</dd></dl>
<dl><dt><b>Description:</b></dt><dd>
The parameter specifies the picture aspect ratio Y (height) and is only applied if the user-defined aspect ratio is enabled. 
</dd></dl>
<dl><dt><b>Type:</b></dt><dd>
VT_INT
</dd></dl>
<dl><dt><b>Available Values:</b></dt>
<dd>
From 1 up to 1048576.
</dd></dl>
*/
// {4B844BD8-5B63-44df-9FF7-EE544AC19D85}
static const GUID EH264VE_aspect_ratioY =
{0x4b844bd8, 0x5b63, 0x44df, {0x9f, 0xf7, 0xee, 0x54, 0x4a, 0xc1, 0x9d, 0x85}};

/** 
<dl><dt><b>GUID:</b></dt><dd>
{598C7279-6AE2-4b3e-947C-6DA0C69F3A01}
</dd></dl>
<dl><dt><b>Description:</b></dt><dd>
This parameter specifies selects the use of automatic aspect ratio or the user-defined one.
</dd></dl>
<dl><dt><b>Type:</b></dt><dd>
VT_INT
</dd></dl>
<dl><dt><b>Available Values:</b></dt>
<dd>
@li Auto
@li User-defined
</dd></dl>
*/
// {598C7279-6AE2-4b3e-947C-6DA0C69F3A01}
static const GUID EH264VE_auto_sample_aspect_ratio =
{0x598c7279, 0x6ae2, 0x4b3e, {0x94, 0x7c, 0x6d, 0xa0, 0xc6, 0x9f, 0x3a, 0x1}};

/** 
<dl><dt><b>GUID:</b></dt><dd>
{80B714D9-EDCD-4cd5-AED7-20FC376B1DA5}
</dd></dl>
<dl><dt><b>Description:</b></dt><dd>
This parameter specifies the sample aspect ratio X (width) and is only applied if the user-defined aspect ratio is enabled.
</dd></dl>
<dl><dt><b>Type:</b></dt><dd>
VT_INT
</dd></dl>
<dl><dt><b>Available Values:</b></dt>
<dd>
From 1 up to 1048576.
</dd></dl>
*/
// {80B714D9-EDCD-4cd5-AED7-20FC376B1DA5}
static const GUID EH264VE_sample_aspect_ratioX =
{0x80b714d9, 0xedcd, 0x4cd5, {0xae, 0xd7, 0x20, 0xfc, 0x37, 0x6b, 0x1d, 0xa5}};

/** 
<dl><dt><b>GUID:</b></dt><dd>
{603B2F96-C82F-4610-ADE3-4F2BA9C7BD33}
</dd></dl>
<dl><dt><b>Description:</b></dt><dd>
The parameter specifies the sample aspect ratio Y (height) and is only applied if the user-defined aspect ratio is enabled. 
</dd></dl>
<dl><dt><b>Type:</b></dt><dd>
VT_INT
</dd></dl>
<dl><dt><b>Available Values:</b></dt>
<dd>
From 1 up to 1048576.
</dd></dl>
*/
// {603B2F96-C82F-4610-ADE3-4F2BA9C7BD33}
static const GUID EH264VE_sample_aspect_ratioY =
{0x603b2f96, 0xc82f, 0x4610, {0xad, 0xe3, 0x4f, 0x2b, 0xa9, 0xc7, 0xbd, 0x33}};

/** 
<dl><dt><b>GUID:</b></dt><dd>
{39108716-B2F5-491c-9E9B-C2ABF38475B4}
</dd></dl>
<dl><dt><b>Description:</b></dt><dd>
This parameter specifies the maximum number of threads.
</dd></dl>
<dl><dt><b>Type:</b></dt><dd>
VT_INT
</dd></dl>
<dl><dt><b>Available Values:</b></dt>
<dd>
From 0 (automatic selection) up to 16.
</dd></dl>
*/
// {39108716-B2F5-491c-9E9B-C2ABF38475B4}
static const GUID EH264VE_num_threads =
{0x39108716, 0xb2f5, 0x491c, {0x9e, 0x9b, 0xc2, 0xab, 0xf3, 0x84, 0x75, 0xb4}};

/** 
<dl><dt><b>GUID:</b></dt><dd>
{ACAC1419-D3D0-47ff-AC9F-889B1D143981}
</dd></dl>
<dl><dt><b>Description:</b></dt><dd>
This parameter enables/disables the use of the fixed source frame rate.
</dd></dl>
<dl><dt><b>Type:</b></dt><dd>
VT_INT
</dd></dl>
<dl><dt><b>Available Values:</b></dt>
<dd>
@li Enable
@li Disable
</dd></dl>
*/
// {ACAC1419-D3D0-47ff-AC9F-889B1D143981}
static const GUID EH264VE_FixedRate =
{0xacac1419, 0xd3d0, 0x47ff, {0xac, 0x9f, 0x88, 0x9b, 0x1d, 0x14, 0x39, 0x81}};

/** 
<dl><dt><b>GUID:</b></dt><dd>
{3F3F4E8F-07BA-4a0d-86B7-FA79907B373E}
</dd></dl>
<dl><dt><b>Description:</b></dt><dd>
This parameter specifies the frame rate if the fixed source frame rate is enabled.
</dd></dl>
<dl><dt><b>Type:</b></dt><dd>
VT_INT
</dd></dl>
<dl><dt><b>Available Values:</b></dt>
<dd>
From 1 up to 100.
</dd></dl>
*/
// {3F3F4E8F-07BA-4a0d-86B7-FA79907B373E}
static const GUID EH264VE_Framerate =
{0x3f3f4e8f, 0x7ba, 0x4a0d, {0x86, 0xb7, 0xfa, 0x79, 0x90, 0x7b, 0x37, 0x3e}};

/** 
<dl><dt><b>GUID:</b></dt><dd>
{0CD0C8F4-2AE6-4c2c-A8A7-99967F2E12F2}
</dd></dl>
<dl><dt><b>Description:</b></dt><dd>
This parameter enables/disables the use of a fixed output frame rate.
</dd></dl>
<dl><dt><b>Type:</b></dt><dd>
VT_INT
</dd></dl>
<dl><dt><b>Available Values:</b></dt>
<dd>
@li Enable
@li Disable
</dd></dl>
*/
// {0CD0C8F4-2AE6-4c2c-A8A7-99967F2E12F2}
static const GUID EH264VE_OutFixedRate =
{0xcd0c8f4, 0x2ae6, 0x4c2c, {0xa8, 0xa7, 0x99, 0x96, 0x7f, 0x2e, 0x12, 0xf2}};

/** 
<dl><dt><b>GUID:</b></dt><dd>
{8F8A8859-A4C2-46C5-8043-18DA54F7034E}
</dd></dl>
<dl><dt><b>Description:</b></dt><dd>
This parameter specifies the frame rate if the fixed output frame rate is enabled.
</dd></dl>
<dl><dt><b>Type:</b></dt><dd>
VT_R8
</dd></dl>
<dl><dt><b>Available Values:</b></dt>
<dd>
From 1 up to 100.
</dd></dl>
*/
// {8F8A8859-A4C2-46c5-8043-18DA54F7034E}
static const GUID EH264VE_OutFramerate =
{0x8f8a8859, 0xa4c2, 0x46c5, {0x80, 0x43, 0x18, 0xda, 0x54, 0xf7, 0x3, 0x4e}};

// {838A8859-A4C2-46c5-8043-38DA54F00355}
static const GUID EH264VE_FpsConvType =
{0x838a8859, 0xa4c2, 0x46c5, {0x80, 0x43, 0x38, 0xda, 0x54, 0xf0, 0x3, 0x55}};

/** 
<dl><dt><b>GUID:</b></dt><dd>
{0670ACD2-5113-0002-9FF7-EE544AC19D85}
</dd></dl>
<dl><dt><b>Description:</b></dt><dd>
This parameter specifies whether to keep original DirectShow timestamps (from input samples) or not.
</dd></dl>
<dl><dt><b>Type:</b></dt><dd>
VT_INT
</dd></dl>
<dl><dt><b>Available Values:</b></dt>
<dd>
@li 0 - TSMode_Original – Keep original timestamps (default)
@li 1 - TSMode_AVI – Rearrange timestamps, in order to be compatible with AVI container (non-overlapping, non-descending timestamps)
</dd></dl>
*/
// {0670ACD2-5113-0002-9FF7-EE544AC19D85}
static const GUID EH264VE_TimestampMode =
{0x0670acd2, 0x5113, 0x0002, { 0x9f, 0xf7, 0xee, 0x54, 0x4a, 0xc1, 0x9d, 0x85}};

/** 
<dl><dt><b>GUID:</b></dt><dd>
{28C447DD-6581-4324-8A95-A62DF867379D}
</dd></dl>
<dl><dt><b>Description:</b></dt><dd>
This parameter specifies the fourCC for the encoder to use for the output mediatype.
</dd></dl>
<dl><dt><b>Type:</b></dt><dd>
VT_INT
</dd></dl>
<dl><dt><b>Available Values:</b></dt>
<dd>
@li OutMT_Original – Use “H264” fourCC (default)
@li OutMT_VSS – Use “VSSH” fourCC
</dd></dl>
*/
// {28C447DD-6581-4324-8A95-A62DF867379D}
static const GUID EH264VE_OutputMediatype =
{0x28c447dd, 0x6581, 0x4324, { 0x8a, 0x95, 0xa6, 0x2d, 0xf8, 0x67, 0x37, 0x9d}};

/** 
<dl><dt><b>GUID:</b></dt><dd>
{B1E3E1BF-6225-4351-862C-66989AEE22B4}
</dd></dl>
<dl><dt><b>Description:</b></dt><dd>
This parameter adjusts default settings. The value of this parameter will be reset to zero immediately after default settings are set.
</dd></dl>
<dl><dt><b>Type:</b></dt><dd>
VT_INT
</dd></dl>
<dl><dt><b>Available Values:</b></dt>
<dd>
@li Yes
@li No
</dd></dl>
*/
// {B1E3E1BF-6225-4351-862C-66989AEE22B4}
static const GUID EH264VE_SetDefValues =
{0xb1e3e1bf, 0x6225, 0x4351, {0x86, 0x2c, 0x66, 0x98, 0x9a, 0xee, 0x22, 0xb4}};

/** 
<dl><dt><b>GUID:</b></dt><dd>
{D02685C0-0946-4740-A6E7-504D750FE4F1}
</dd></dl>
<dl><dt><b>Description:</b></dt><dd>
This parameter indicates the source stream frame rate.
</dd></dl>
<dl><dt><b>Type:</b></dt><dd>
VT_R8
</dd></dl>
<dl><dt><b>Available Values:</b></dt>
<dd>
Read-only.
</dd></dl>
*/
// {D02685C0-0946-4740-A6E7-504D750FE4F1}
static const GUID EH264VE_OriginalFramerate =
{0xd02685c0, 0x946, 0x4740, {0xa6, 0xe7, 0x50, 0x4d, 0x75, 0xf, 0xe4, 0xf1}};

/** 
<dl><dt><b>GUID:</b></dt><dd>
{654207C6-ECAD-4E8F-86F1-7819148D518A}
</dd></dl>
<dl><dt><b>Description:</b></dt><dd>
This parameter indicates the source stream picture type.
</dd></dl>
<dl><dt><b>Type:</b></dt><dd>
VT_INT
</dd></dl>
<dl><dt><b>Available Values:</b></dt>
<dd>
Read-only.
</dd></dl>
*/
// {654207C6-ECAD-4e8f-86F1-7819148D518A}
static const GUID EH264VE_OriginalInterlace =
{0x654207c6, 0xecad, 0x4e8f, {0x86, 0xf1, 0x78, 0x19, 0x14, 0x8d, 0x51, 0x8a}};

/** 
<dl><dt><b>GUID:</b></dt><dd>
{413AA8BB-F85C-4768-B8F6-91AA7BCE3DE6}
</dd></dl>
<dl><dt><b>Description:</b></dt><dd>
This parameter indicates the source stream color space.
</dd></dl>
<dl><dt><b>Type:</b></dt><dd>
VT_INT
</dd></dl>
<dl><dt><b>Available Values:</b></dt>
<dd>
Read-only.
</dd></dl>
*/
// {413AA8BB-F85C-4768-B8F6-91AA7BCE3DE6}
static const GUID EH264VE_OriginalColorSpace =
{0x413aa8bb, 0xf85c, 0x4768, {0xb8, 0xf6, 0x91, 0xaa, 0x7b, 0xce, 0x3d, 0xe6}};

/** 
<dl><dt><b>GUID:</b></dt><dd>
{D0D2A38C-8DF6-47B5-A662-47E6D39BCFA7}
</dd></dl>
<dl><dt><b>Description:</b></dt><dd>
This parameter indicates whether the encoder is in running state or not.
</dd></dl>
<dl><dt><b>Type:</b></dt><dd>
VT_INT
</dd></dl>
<dl><dt><b>Available Values:</b></dt>
<dd>
Read-only.
</dd></dl>
*/
// {D0D2A38C-8DF6-47b5-A662-47E6D39BCFA7}
static const GUID EH264VE_IsRunning =
{0xd0d2a38c, 0x8df6, 0x47b5, {0xa6, 0x62, 0x47, 0xe6, 0xd3, 0x9b, 0xcf, 0xa7}};

/** 
<dl><dt><b>GUID:</b></dt><dd>
{DE6D6008-1A49-428A-B2ED-E760FF32909E}
</dd></dl>
<dl><dt><b>Description:</b></dt><dd>
This parameter indicates the horizontal size of the input picture.
</dd></dl>
<dl><dt><b>Type:</b></dt><dd>
VT_INT
</dd></dl>
<dl><dt><b>Available Values:</b></dt>
<dd>
Read-only.
</dd></dl>
*/
// {DE6D6008-1A49-428a-B2ED-E760FF32909E}
static const GUID EH264VE_def_horizontal_size =
{0xde6d6008, 0x1a49, 0x428a, {0xb2, 0xed, 0xe7, 0x60, 0xff, 0x32, 0x90, 0x9e}};

/** 
<dl><dt><b>GUID:</b></dt><dd>
{D44C9617-C618-4D57-A992-DB8101911B4A}
</dd></dl>
<dl><dt><b>Description:</b></dt><dd>
This parameter indicates the vertical size of the input picture.
</dd></dl>
<dl><dt><b>Type:</b></dt><dd>
VT_INT
</dd></dl>
<dl><dt><b>Available Values:</b></dt>
<dd>
Read-only.
</dd></dl>
*/
// {D44C9617-C618-4d57-A992-DB8101911B4A}
static const GUID EH264VE_def_vertical_size =
{0xd44c9617, 0xc618, 0x4d57, {0xa9, 0x92, 0xdb, 0x81, 0x1, 0x91, 0x1b, 0x4a}};

/** 
<dl><dt><b>GUID:</b></dt><dd>
{11093431-74C1-4D37-BEB8-3A4DC9BB0119}
</dd></dl>
<dl><dt><b>Description:</b></dt><dd>
This parameter specifies the speed/quality encoding preset.
</dd></dl>
<dl><dt><b>Type:</b></dt><dd>
VT_INT
</dd></dl>
<dl><dt><b>Available Values:</b></dt>
<dd>
From 0 (fastest encoding speed) to 15 (best quality); default value is 9.
</dd></dl>
*/
// {11093431-74c1-4d37-beb8-3a4dc9bb0119}
static const GUID EH264VE_performance_preset =
{0x11093431, 0x74c1, 0x4d37, {0xbe, 0xb8, 0x3a, 0x4d, 0xc9, 0xbb, 0x1, 0x19}};

// {B9983CB7-CECD-41e0-A133-5E35AA5E7752}
static const GUID EH264VE_Implementation = 
{ 0xb9983cb7, 0xcecd, 0x41e0, { 0xa1, 0x33, 0x5e, 0x35, 0xaa, 0x5e, 0x77, 0x52 } };
/**@}*/
#endif // __PROPID_H264ENC_HEADER__