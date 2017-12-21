 /**
\file dec_vc1_mc.h
\brief Property GUIDs for MainConcept VC-1 decoder parameters.

\verbatim
File: dec_vc1_mc.h

Desc: Property GUIDs forMainConcept AVC decoder parameters.

 Copyright (c) 2015 MainConcept GmbH or its affiliates.  All rights reserved.

 MainConcept and its logos are registered trademarks of MainConcept GmbH or its affiliates.  
 This software is protected by copyright law and international treaties.  Unauthorized 
 reproduction or distribution of any portion is prohibited by law.
\endverbatim
*/

/////////////////////////////////////////////////////////////////////////////////////////////////
//  GUID                    Value Type      Available range                     Default Value           Note
//
//  MCVC1VD_SkipMode        VT_UINT         vc1dec_skip_mode_none               vc1dec_skip_mode_none
//                                          vc1dec_skip_mode_decode_reference
//                                          vc1dec_skip_mode_decode_intra
//                                          vc1dec_skip_mode_auto
//
//  MCVC1VD_ErrorResilienceMode             vc1dec_error_resilience_mode_proceed_anyway
//                          VT_UINT         vc1dec_error_resilience_mode_skip_till_intra
//                                                                              vc1dec_error_resilience_mode_skip_till_intra
//
//  MCVC1VD_TreatVUIPictureTimingAsFrameRate
//                          VT_BOOL       false, true                         false
//
//  MCVC1VD_EnableVideoInfo VT_BOOL       false, true                         false
//
//
//  MCVC1VD_OutputYUY2      VT_BOOL       false, true                         true                    DirectShow filter only
//
//  MCVC1VD_OutputUYVY      VT_BOOL       false, true                         true                    DirectShow filter only
//
//  MCVC1VD_OutputYV12      VT_BOOL       false, true                         true                    DirectShow filter only
//
//  MCVC1VD_OutputRGB32     VT_BOOL       false, true                         true                    DirectShow filter only
//
//  MCVC1VD_OutputRGB24     VT_BOOL       false, true                         true                    DirectShow filter only
//
//  MCVC1VD_OutputRGB565    VT_BOOL       false, true                         true                    DirectShow filter only
//
//  MCVC1VD_OutputRGB555    VT_BOOL       false, true                         true                    DirectShow filter only
//  MCVC1VD_Deinterlace     VT_UI4        [0, 3]                              [0]             Selecting output deinterlace mode
//  MCVC1VD_HQUpsample      VT_UI4        [0, 1]                              [1]             Enable/disable chroma vertical upsample (only software decode mode)
//  MCVC1VD_DoubleRate      VT_UI4        [0, 1]                              [0]             Enable/disable output double rate (avalible only if software decode mode and video is interlaced)
//  MCVC1VD_FieldsReordering VT_UI4       [0, 2]                              [0]             Sets the mode of fields reordering
//  MCVC1VD_FieldsReorderingCondition VT_UI4 </dd></dl> [0, 2]                             [0]             Sets the condition of fields reordering
//  MCVC1VD_MediaTimeStart  VT_I8           []                                                  Media time of current frame (it may be a byte offset of current frame)
//  MCVC1VD_MediaTimeStop   VT_I8           []	
//  MCVC1VD_FramesDisplayed VT_UI4        []                                  [0]             Count of displayed frames
//  MCVC1VD_FramesSkipped   VT_UI4        []                                  [0]             Count of skipped frames
//  
//  MCVC1VD_SYNCHRONIZING   VT_UI4        [0, 2]                              [0]
//
/////////////////////////////////////////////////////////////////////////////////////////////////

#if !defined(__PROPID_MCVC1DEC_HEADER__)
#define __PROPID_MCVC1DEC_HEADER__

typedef enum vc1dec_skip_mode_e {
	vc1dec_skip_mode_none = 0,
	vc1dec_skip_mode_decode_reference,
	vc1dec_skip_mode_decode_intra,
	vc1dec_skip_mode_auto
} vc1dec_skip_mode_t, *p_vc1dec_skip_mode_t;

typedef enum vc1dec_error_resilience_mode_e {
	vc1dec_error_resilience_mode_proceed_anyway = 0,
	vc1dec_error_resilience_mode_skip_till_intra
} vc1dec_error_resilience_mode_t, *p_vc1dec_error_resilience_mode_t;

typedef enum vc1dec_state_e {
    vc1dec_state_off = 0,
    vc1dec_state_on = 1
} vc1dec_state_t;
	
typedef enum vc1dec_field_reordering_mode_e {
    vc1dec_field_reordering_off = 0,
    vc1dec_field_reordering_invert_flags = 1,
    vc1dec_field_reordering_xchg_fields = 2,
    vc1dec_field_reordering_auto = 3
} vc1dec_field_reordering_mode_t;

typedef enum vc1dec_field_reordering_condition_e {
    vc1dec_field_reordering_always = 0,
    vc1dec_field_reordering_top_first_true = 1,
    vc1dec_field_reordering_top_first_false = 2
} vc1dec_field_reordering_condition_t;

typedef enum vc1dec_deinterlace_mode_e {
    vc1dec_deinterlace_weave = 0,
	vc1dec_deinterlace_field_interpolation = 1,
    vc1dec_deinterlace_vertical_filter = 2,
    vc1dec_deinterlace_VMR = 3,
    vc1dec_deinterlace_auto = 4
} vc1dec_deinterlace_mode_t;

typedef enum vc1dec_synchronizing_mode_e {
    vc1dec_synchronizing_PTS = 0,
    vc1dec_synchronizing_ignore_PTS_non_ref = 1,
    vc1dec_synchronizing_ignore_PTS_all = 2
} vc1dec_synchronizing_mode_t;


/**  
Specifies types of frames that decoder will skip. In case of field pictures frame type is determined by the type of first coded slice of complimentary field pair.
\details <dl><dt><b>  Type: </b></dt><dd> 
VT_UI4 </dd></dl>
<dl><dt><b>  Available Values: </b></dt><dd>
vc1dec_skip_mode_auto - Respect quality messages from downstream filter and choose frame types to skip automatically to maintain synchronized playback.<br>
vc1dec_skip_mode_none - Decode all frames, do not skip.<br>
vc1dec_skip_mode_decode_reference - Skip all non-reference frames (B frames).<br>
vc1dec_skip_mode_decode_intra - Skip P and B, decode I frames only. </dd></dl> \hideinitializer */ // {4B0A9190-A6AE-41f6-BF58-8321D76E1661}
static const GUID MCVC1VD_SkipMode = 
{0x4b0a9190, 0xa6ae, 0x41f6, {0xbf, 0x58, 0x83, 0x21, 0xd7, 0x6e, 0x16, 0x61}};

/**  
Specifies the way decoder recovers from bit stream errors.
\details <dl><dt><b>  Type: </b></dt><dd> 
VT_UI4 </dd></dl>
<dl><dt><b>  Available Values: </b></dt><dd>
vc1dec_error_resilience_mode_skip_till_intra - If bit stream error is detected, skip all pictures until first intra frame.<br>
vc1dec_error_resilience_mode_proceed_anyway - Ignore bit stream errors. </dd></dl> \hideinitializer */ // {4B0A9191-A6AE-41f6-BF58-8321D76E1661}
static const GUID MCVC1VD_ErrorResilienceMode = 
{0x4b0a9191, 0xa6ae, 0x41f6, {0xbf, 0x58, 0x83, 0x21, 0xd7, 0x6e, 0x16, 0x61}};

// {4B0A9192-A6AE-41f6-BF58-8321D76E1661}
static const GUID MCVC1VD_Reserved = 
{0x4b0a9192, 0xa6ae, 0x41f6, {0xbf, 0x58, 0x83, 0x21, 0xd7, 0x6e, 0x16, 0x61}};

// {4B0A919C-A6AE-41f6-BF58-8321D76E1661}
static const GUID MCVC1VD_SMPMode =
{0x4b0a919c, 0xa6ae, 0x41f6, {0xbf, 0x58, 0x83, 0x21, 0xd7, 0x6e, 0x16, 0x61}};

/**  
Enables or disables using of VIDEOINFOHEADER format structure along with VIDEOINFOHEADER2.
\details <dl><dt><b>  Type: </b></dt><dd> 
VT_BOOL </dd></dl>
<dl><dt><b>  Available Values: </b></dt><dd>
false - Use VIDEOINFOHEADER2 structure only.<br>
true - Use both VIDEOINFOHEADER and VIDEOINFOHEADER2 structures (default).
 </dd></dl> \hideinitializer */ // {4B0A9193-A6AE-41f6-BF58-8321D76E1661}
static const GUID MCVC1VD_EnableVideoInfo =
{0x4b0a9193, 0xa6ae, 0x41f6, {0xbf, 0x58, 0x83, 0x21, 0xd7, 0x6e, 0x16, 0x61}};

/**  
Enables or disables YUY2 color space output.
\details <dl><dt><b>  Type: </b></dt><dd> 
VT_BOOL </dd></dl>
<dl><dt><b>  Available Values: </b></dt><dd>
false - YUY2 output is disabled.<br>
true - YUY2 output is enabled (default). </dd></dl> \hideinitializer */ // {4B0A9195-A6AE-41f6-BF58-8321D76E1661}
static const GUID MCVC1VD_OutputYUY2 =
{0x4b0a9195, 0xa6ae, 0x41f6, {0xbf, 0x58, 0x83, 0x21, 0xd7, 0x6e, 0x16, 0x61}};

/**  Enables or disables YUYV color space output.details <dl><dt><b>  Type: </b></dt><dd> VT_BOOL </dd></dl> <dl><dt><b>  Available Values: </b></dt><dd> false - YUYV output is disabled.<br> true - YUYV output is enabled (default).</dd></dl> \hideinitializer */
 // {4B0A9196-A6AE-41f6-BF58-8321D76E1661}
static const GUID MCVC1VD_OutputUYVY =
{0x4b0a9196, 0xa6ae, 0x41f6, {0xbf, 0x58, 0x83, 0x21, 0xd7, 0x6e, 0x16, 0x61}};

/**  
Enables or disables YV12 color space output.
\details <dl><dt><b>  Type: </b></dt><dd> 
VT_BOOL </dd></dl>
<dl><dt><b>  Available Values: </b></dt><dd>
false - YV12 output is disabled.<br>
true - YV12 output is enabled (default). </dd></dl> \hideinitializer */ // {4B0A9197-A6AE-41f6-BF58-8321D76E1661}
static const GUID MCVC1VD_OutputYV12 =
{0x4b0a9197, 0xa6ae, 0x41f6, {0xbf, 0x58, 0x83, 0x21, 0xd7, 0x6e, 0x16, 0x61}};

/**  
Enables or disables RGB32 color space output.
\details <dl><dt><b>  Type: </b></dt><dd> 
VT_BOOL </dd></dl>
<dl><dt><b>  Available Values: </b></dt><dd>
false - RGB32 output is disabled.<br>
true - RGB32 output is enabled (default). </dd></dl> \hideinitializer */ // {4B0A9198-A6AE-41f6-BF58-8321D76E1661}
static const GUID MCVC1VD_OutputRGB32 =
{0x4b0a9198, 0xa6ae, 0x41f6, {0xbf, 0x58, 0x83, 0x21, 0xd7, 0x6e, 0x16, 0x61}};

/**  
Enables or disables RGB24 color space output.
\details <dl><dt><b>  Type: </b></dt><dd> 
VT_BOOL </dd></dl>
<dl><dt><b>  Available Values: </b></dt><dd>
false - RGB24 output is disabled.<br>
true - RGB24 output is enabled (default). </dd></dl> \hideinitializer */ // {4B0A9199-A6AE-41f6-BF58-8321D76E1661}
static const GUID MCVC1VD_OutputRGB24 =
{0x4b0a9199, 0xa6ae, 0x41f6, {0xbf, 0x58, 0x83, 0x21, 0xd7, 0x6e, 0x16, 0x61}};

/**  
Enables or disables RGB565 color space output.
\details <dl><dt><b>  Type: </b></dt><dd> 
VT_BOOL </dd></dl>
<dl><dt><b>  Available Values: </b></dt><dd>
false - RGB565 output is disabled.<br>
true - RGB565 output is enabled (default). </dd></dl> \hideinitializer */ // {4B0A919A-A6AE-41f6-BF58-8321D76E1661}
static const GUID MCVC1VD_OutputRGB565 =
{0x4b0a919a, 0xa6ae, 0x41f6, {0xbf, 0x58, 0x83, 0x21, 0xd7, 0x6e, 0x16, 0x61}};

/**  
Enables or disables RGB555 color space output.
\details <dl><dt><b>  Type: </b></dt><dd> 
VT_BOOL </dd></dl>
<dl><dt><b>  Available Values: </b></dt><dd>
false - RGB555 output is disabled.<br>
true - RGB555 output is enabled (default). </dd></dl> \hideinitializer */ // {4B0A919B-A6AE-41f6-BF58-8321D76E1661}
static const GUID MCVC1VD_OutputRGB555 =
{0x4b0a919b, 0xa6ae, 0x41f6, {0xbf, 0x58, 0x83, 0x21, 0xd7, 0x6e, 0x16, 0x61}};

/**  Enables or disables IYUV color space output.details <dl><dt><b>  Type: </b></dt><dd> VT_BOOL </dd></dl> <dl><dt><b>  Available Values: </b></dt><dd> false - IYUV output is disabled.<br> true - IYUV output is enabled (default).</dd></dl> \hideinitializer */ // {B3887200-B24F-4B13-813B-14BACB723A25}
static const GUID MCVC1VD_OutputIYUV = 
{ 0xb3887200, 0xb24f, 0x4b13, { 0x81, 0x3b, 0x14, 0xba, 0xcb, 0x72, 0x3a, 0x25 } };


/**  Enables or disables NV12 color space output.details <dl><dt><b>  Type: </b></dt><dd> VT_BOOL </dd></dl> <dl><dt><b>  Available Values: </b></dt><dd> false - NV12 output is disabled.<br> true - NV12 output is enabled (default).</dd></dl> \hideinitializer */ // {4441E6B4-B490-40F4-AD8F-0E0EBBB6D846}
static const GUID MCVC1VD_OutputNV12 = 
{ 0x4441e6b4, 0xb490, 0x40f4, { 0xad, 0x8f, 0xe, 0xe, 0xbb, 0xb6, 0xd8, 0x46 } };

/**  Enables or disables NV21 color space output.details <dl><dt><b>  Type: </b></dt><dd> VT_BOOL </dd></dl> <dl><dt><b>  Available Values: </b></dt><dd> false - NV21 output is disabled.<br> true - NV21 output is enabled (default).</dd></dl> \hideinitializer */ // {BD681216-A95E-41AB-83E4-7846B0EBA4E6}
static const GUID MCVC1VD_OutputNV21 = 
{ 0xbd681216, 0xa95e, 0x41ab, { 0x83, 0xe4, 0x78, 0x46, 0xb0, 0xeb, 0xa4, 0xe6 } };

/**  Enables or disables IMC1 color space output.details <dl><dt><b>  Type: </b></dt><dd> VT_BOOL </dd></dl> <dl><dt><b>  Available Values: </b></dt><dd> false - IMC1 output is disabled.<br> true - IMC1 output is enabled (default).</dd></dl> \hideinitializer */ // {01C99425-FB90-4E34-8605-752E92877B7C}
static const GUID MCVC1VD_OutputIMC1 = 
{ 0x1c99425, 0xfb90, 0x4e34, { 0x86, 0x5, 0x75, 0x2e, 0x92, 0x87, 0x7b, 0x7c } };

/**  Enables or disables IMC2 color space output.details <dl><dt><b>  Type: </b></dt><dd> VT_BOOL </dd></dl> <dl><dt><b>  Available Values: </b></dt><dd> false - IMC2 output is disabled.<br> true - IMC2 output is enabled (default).</dd></dl> \hideinitializer */ // {92BD468B-4E4A-4CB8-96A0-76880D7CB888}
static const GUID MCVC1VD_OutputIMC2 = 
{ 0x92bd468b, 0x4e4a, 0x4cb8, { 0x96, 0xa0, 0x76, 0x88, 0xd, 0x7c, 0xb8, 0x88 } };

/**  Enables or disables IMC3 color space output.details <dl><dt><b>  Type: </b></dt><dd> VT_BOOL </dd></dl> <dl><dt><b>  Available Values: </b></dt><dd> false - IMC3 output is disabled.<br> true - IMC3 output is enabled (default).</dd></dl> \hideinitializer */ // {D8A2BE4B-D858-48AE-8E7E-FB68F4942CAD}
static const GUID MCVC1VD_OutputIMC3 = 
{ 0xd8a2be4b, 0xd858, 0x48ae, { 0x8e, 0x7e, 0xfb, 0x68, 0xf4, 0x94, 0x2c, 0xad } };


/**  Enables or disables IMC4 color space output.details <dl><dt><b>  Type: </b></dt><dd> VT_BOOL </dd></dl> <dl><dt><b>  Available Values: </b></dt><dd> false - IMC4 output is disabled.<br> true - IMC4 output is enabled (default).</dd></dl> \hideinitializer */ // {E4FDB0F1-F617-437A-8D90-A888E8B5BC8B}
static const GUID MCVC1VD_OutputIMC4 = 
{ 0xe4fdb0f1, 0xf617, 0x437a, { 0x8d, 0x90, 0xa8, 0x88, 0xe8, 0xb5, 0xbc, 0x8b } };


/**  Enables or disables YV16 color space output.details <dl><dt><b>  Type: </b></dt><dd> VT_BOOL </dd></dl> <dl><dt><b>  Available Values: </b></dt><dd> false - YV16 output is disabled.<br> true - YV16 output is enabled (default).</dd></dl> \hideinitializer */ // {17032E86-9677-4CDE-808E-F3BB97B9C6BD}
static const GUID MCVC1VD_OutputYV16 = 
{ 0x17032e86, 0x9677, 0x4cde, { 0x80, 0x8e, 0xf3, 0xbb, 0x97, 0xb9, 0xc6, 0xbd } };

/**  Enables or disables YV24 color space output.details <dl><dt><b>  Type: </b></dt><dd> VT_BOOL </dd></dl> <dl><dt><b>  Available Values: </b></dt><dd> false - YV24 output is disabled.<br> true - YV24 output is enabled (default).</dd></dl> \hideinitializer */ // {CB8B3C66-7241-491B-B470-C1AEAA71A72C}
static const GUID MCVC1VD_OutputYV24 = 
{ 0xcb8b3c66, 0x7241, 0x491b, { 0xb4, 0x70, 0xc1, 0xae, 0xaa, 0x71, 0xa7, 0x2c } };

/**  Enables or disables NV24 color space output.details <dl><dt><b>  Type: </b></dt><dd> VT_BOOL </dd></dl> <dl><dt><b>  Available Values: </b></dt><dd> false - NV24 output is disabled.<br> true - NV24 output is enabled (default).</dd></dl> \hideinitializer */ // {7B3B1064-F30D-4228-A485-AED2805CE05E}
static const GUID MCVC1VD_OutputNV24 = 
{ 0x7b3b1064, 0xf30d, 0x4228, { 0xa4, 0x85, 0xae, 0xd2, 0x80, 0x5c, 0xe0, 0x5e } };

/**  Enables or disables YUYV color space output.details <dl><dt><b>  Type: </b></dt><dd> VT_BOOL </dd></dl> <dl><dt><b>  Available Values: </b></dt><dd> false - YUYV output is disabled.<br> true - YUYV output is enabled (default).</dd></dl> \hideinitializer */ // {4AF4781C-A3A2-4B13-9183-F81382840114}
static const GUID MCVC1VD_OutputYUYV = 
{ 0x4af4781c, 0xa3a2, 0x4b13, { 0x91, 0x83, 0xf8, 0x13, 0x82, 0x84, 0x1, 0x14 } };

/**  Enables or disables YVYU color space output.details <dl><dt><b>  Type: </b></dt><dd> VT_BOOL </dd></dl> <dl><dt><b>  Available Values: </b></dt><dd> false - YVYU output is disabled.<br> true - YVYU output is enabled (default).</dd></dl> \hideinitializer */ // {51DA1793-6E24-47EB-8FB6-9915FF1D9FB6}
static const GUID MCVC1VD_OutputYVYU = 
{ 0x51da1793, 0x6e24, 0x47eb, { 0x8f, 0xb6, 0x99, 0x15, 0xff, 0x1d, 0x9f, 0xb6 } };

/**  Enables or disables VYUY color space output.details <dl><dt><b>  Type: </b></dt><dd> VT_BOOL </dd></dl> <dl><dt><b>  Available Values: </b></dt><dd> false - VYUY output is disabled.<br> true - VYUY output is enabled (default).</dd></dl> \hideinitializer */  // {5B408631-1755-49D5-A2BE-46FFF49F31D9}
static const GUID MCVC1VD_OutputVYUY = 
{ 0x5b408631, 0x1755, 0x49d5, { 0xa2, 0xbe, 0x46, 0xff, 0xf4, 0x9f, 0x31, 0xd9 } };

/**  Enables or disables AYUV color space output.details <dl><dt><b>  Type: </b></dt><dd> VT_BOOL </dd></dl> <dl><dt><b>  Available Values: </b></dt><dd> false - AYUV output is disabled.<br> true - AYUV output is enabled (default).</dd></dl> \hideinitializer */
// {41D96FDF-C0BF-4803-8BB5-43A820CB109E}
static const GUID MCVC1VD_OutputAYUV = 
{ 0x41d96fdf, 0xc0bf, 0x4803, { 0x8b, 0xb5, 0x43, 0xa8, 0x20, 0xcb, 0x10, 0x9e } };

/**  Enables or disables VUYA color space output.details <dl><dt><b>  Type: </b></dt><dd> VT_BOOL </dd></dl> <dl><dt><b>  Available Values: </b></dt><dd> false - VUYA output is disabled.<br> true - VUYA output is enabled (default).</dd></dl> \hideinitializer */ // {37505C8D-F5CE-4D5F-B19E-D727314D4564}
static const GUID MCVC1VD_OutputVUYA = 
{ 0x37505c8d, 0xf5ce, 0x4d5f, { 0xb1, 0x9e, 0xd7, 0x27, 0x31, 0x4d, 0x45, 0x64 } };

/**  Enables or disables YVU9 color space output.details <dl><dt><b>  Type: </b></dt><dd> VT_BOOL </dd></dl> <dl><dt><b>  Available Values: </b></dt><dd> false - YVU9 output is disabled.<br> true - YVU9 output is enabled (default).</dd></dl> \hideinitializer */ // {903517E0-DD4A-4A0C-A480-6700D680052B}
static const GUID MCVC1VD_OutputYVU9 = 
{ 0x903517e0, 0xdd4a, 0x4a0c, { 0xa4, 0x80, 0x67, 0x0, 0xd6, 0x80, 0x5, 0x2b } };

/**  Enables or disables YUV9 color space output.details <dl><dt><b>  Type: </b></dt><dd> VT_BOOL </dd></dl> <dl><dt><b>  Available Values: </b></dt><dd> false - YUV9 output is disabled.<br> true - YUV9 output is enabled (default).</dd></dl> \hideinitializer */ // {A1B9FB07-E4FE-4143-B4B4-10725E2ADE81}
static const GUID MCVC1VD_OutputYUV9 = 
{ 0xa1b9fb07, 0xe4fe, 0x4143, { 0xb4, 0xb4, 0x10, 0x72, 0x5e, 0x2a, 0xde, 0x81 } };

/**  Enables or disables Y41P color space output.details <dl><dt><b>  Type: </b></dt><dd> VT_BOOL </dd></dl> <dl><dt><b>  Available Values: </b></dt><dd> false - Y41P output is disabled.<br> true - Y41P output is enabled (default).</dd></dl> \hideinitializer */ // {84EFC9A4-A6DF-49B4-91D4-632F8A83D9D5}
static const GUID MCVC1VD_OutputY41P = 
{ 0x84efc9a4, 0xa6df, 0x49b4, { 0x91, 0xd4, 0x63, 0x2f, 0x8a, 0x83, 0xd9, 0xd5 } };

/**  Enables or disables Y211 color space output.details <dl><dt><b>  Type: </b></dt><dd> VT_BOOL </dd></dl> <dl><dt><b>  Available Values: </b></dt><dd> false - Y211 output is disabled.<br> true - Y211 output is enabled (default).</dd></dl> \hideinitializer */ // {003A36D2-BA9B-4C47-9381-5C7F3064735D}
static const GUID MCVC1VD_OutputY211 = 
{ 0x3a36d2, 0xba9b, 0x4c47, { 0x93, 0x81, 0x5c, 0x7f, 0x30, 0x64, 0x73, 0x5d } };

/**  Enables or disables CLJR color space output.details <dl><dt><b>  Type: </b></dt><dd> VT_BOOL </dd></dl> <dl><dt><b>  Available Values: </b></dt><dd> false - CLJR output is disabled.<br> true - CLJR output is enabled (default).</dd></dl> \hideinitializer */ // {F4DD644F-783D-417C-A8A6-E132EF435B61}
static const GUID MCVC1VD_OutputCLJR = 
{ 0xf4dd644f, 0x783d, 0x417c, { 0xa8, 0xa6, 0xe1, 0x32, 0xef, 0x43, 0x5b, 0x61 } };

/**  Enables or disables v210 color space output.details <dl><dt><b>  Type: </b></dt><dd> VT_BOOL </dd></dl> <dl><dt><b>  Available Values: </b></dt><dd> false - v210 output is disabled.<br> true - v210 output is enabled (default).</dd></dl> \hideinitializer */ // {ACA92E14-0BC5-4D21-9DBC-AAD05A0741EA}
static const GUID MCVC1VD_Outputv210 = 
{ 0xaca92e14, 0xbc5, 0x4d21, { 0x9d, 0xbc, 0xaa, 0xd0, 0x5a, 0x7, 0x41, 0xea } };

/**  Enables or disables Y210 color space output.details <dl><dt><b>  Type: </b></dt><dd> VT_BOOL </dd></dl> <dl><dt><b>  Available Values: </b></dt><dd> false - Y210 output is disabled.<br> true - Y210 output is enabled (default). </dd></dl> \hideinitializer */ // {649D02A6-EF52-4C3F-AE8B-6339CE0194EF}
static const GUID MCVC1VD_OutputY210 = 
{ 0x649d02a6, 0xef52, 0x4c3f, { 0xae, 0x8b, 0x63, 0x39, 0xce, 0x1, 0x94, 0xef } };

/**  Enables or disables Y216 color space output.details <dl><dt><b>  Type: </b></dt><dd> VT_BOOL </dd></dl> <dl><dt><b>  Available Values: </b></dt><dd> false - Y216 output is disabled.<br> true - Y216 output is enabled (default).</dd></dl> \hideinitializer */ // {F084F74A-BFCF-4D9C-BF4C-CA9D12EE30A8}
static const GUID MCVC1VD_OutputY216 = 
{ 0xf084f74a, 0xbfcf, 0x4d9c, { 0xbf, 0x4c, 0xca, 0x9d, 0x12, 0xee, 0x30, 0xa8 } };

/**  Enables or disables Y410 color space output.details <dl><dt><b>  Type: </b></dt><dd> VT_BOOL </dd></dl> <dl><dt><b>  Available Values: </b></dt><dd> false - Y410 output is disabled.<br> true - Y410 output is enabled (default).</dd></dl> \hideinitializer */ // {AF1E8B98-7FBB-49A9-819C-2ECAF074EB66}
static const GUID MCVC1VD_OutputY410 = 
{ 0xaf1e8b98, 0x7fbb, 0x49a9, { 0x81, 0x9c, 0x2e, 0xca, 0xf0, 0x74, 0xeb, 0x66 } };

/**  Enables or disables Y416 color space output.details <dl><dt><b>  Type: </b></dt><dd> VT_BOOL </dd></dl> <dl><dt><b>  Available Values: </b></dt><dd> false - Y416 output is disabled.<br> true - Y416 output is enabled (default).</dd></dl> \hideinitializer */ // {6D1247D5-45FD-4E52-ABFE-10AE54F1A138}
static const GUID MCVC1VD_OutputY416 = 
{ 0x6d1247d5, 0x45fd, 0x4e52, { 0xab, 0xfe, 0x10, 0xae, 0x54, 0xf1, 0xa1, 0x38 } };

/**  Enables or disables P010 color space output.details <dl><dt><b>  Type: </b></dt><dd> VT_BOOL </dd></dl> <dl><dt><b>  Available Values: </b></dt><dd> false - P010 output is disabled.<br> true - P010 output is enabled (default).</dd></dl> \hideinitializer */ // {9485DC78-EFF9-450A-AF9C-E8A8BDAD1B7F}
static const GUID MCVC1VD_OutputP010 = 
{ 0x9485dc78, 0xeff9, 0x450a, { 0xaf, 0x9c, 0xe8, 0xa8, 0xbd, 0xad, 0x1b, 0x7f } };

/**  Enables or disables P016 color space output.details <dl><dt><b>  Type: </b></dt><dd> VT_BOOL </dd></dl> <dl><dt><b>  Available Values: </b></dt><dd> false - P016 output is disabled.<br> true - P016 output is enabled (default).</dd></dl> \hideinitializer */ // {17A6528F-D383-4B75-A895-2200C54B1F73}
static const GUID MCVC1VD_OutputP016 = 
{ 0x17a6528f, 0xd383, 0x4b75, { 0xa8, 0x95, 0x22, 0x0, 0xc5, 0x4b, 0x1f, 0x73 } };

/**  Enables or disables P210 color space output.details <dl><dt><b>  Type: </b></dt><dd> VT_BOOL </dd></dl> <dl><dt><b>  Available Values: </b></dt><dd> false - P210 output is disabled.<br> true - P210 output is enabled (default).</dd></dl> \hideinitializer */ // {58BC2418-5386-4B4A-B972-DE011984AEE0}
static const GUID MCVC1VD_OutputP210 = 
{ 0x58bc2418, 0x5386, 0x4b4a, { 0xb9, 0x72, 0xde, 0x1, 0x19, 0x84, 0xae, 0xe0 } };

/**  Enables or disables P216 color space output.details <dl><dt><b>  Type: </b></dt><dd> VT_BOOL </dd></dl> <dl><dt><b>  Available Values: </b></dt><dd> false - P216 output is disabled.<br> true - P216 output is enabled (default).</dd></dl> \hideinitializer */ // {0184FAB6-FF1C-442E-8357-D696B50D8B56}
static const GUID MCVC1VD_OutputP216 = 
{ 0x184fab6, 0xff1c, 0x442e, { 0x83, 0x57, 0xd6, 0x96, 0xb5, 0xd, 0x8b, 0x56 } };

/**  Enables or disables ARGB32 color space output.details <dl><dt><b>  Type: </b></dt><dd> VT_BOOL </dd></dl> <dl><dt><b>  Available Values: </b></dt><dd> false - ARGB32 output is disabled.<br> true - ARGB32 output is enabled (default). </dd></dl> \hideinitializer */ // {1BA1491E-4ED8-4DFE-8FF8-E40A05B7FE33}
static const GUID MCVC1VD_OutputARGB32 = 
{ 0x1ba1491e, 0x4ed8, 0x4dfe, { 0x8f, 0xf8, 0xe4, 0xa, 0x5, 0xb7, 0xfe, 0x33 } };

/**  
Sets the deinterlacing mode.
\details <dl><dt><b>  Type: </b></dt><dd> 
VT_UI4 </dd></dl>
<dl><dt><b>  Available Values: </b></dt><dd>
vc1dec_deinterlace_weave - Do not deinterlace - output interleaved fields.<br>
vc1dec_deinterlace_vertical_filter - Select vertical deinterlace function.<br>
vc1dec_deinterlace_field_interpolation - Deinterlace by interpolation.<br>
vc1dec_deinterlace_VMR - Put correct interlacing flags on output samples and let VMR (Video Mixing Renderer) decide how to deinterlace. </dd></dl> \hideinitializer */ // {9CF1A332-E72B-4a6d-BBE8-199595944546}
static const GUID MCVC1VD_Deinterlace = 
{0x9cf1a332, 0xe72b, 0x4a6d, {0xbb, 0xe8, 0x19, 0x95, 0x95, 0x94, 0x45, 0x46 }};

/** </dd></dl> \hideinitializer */ // {9CF1A333-E72B-4a6d-BBE8-199595944546}
static const GUID MCVC1VD_HQUpsample = 
{0x9cf1a333, 0xe72b, 0x4a6d, {0xbb, 0xe8, 0x19, 0x95, 0x95, 0x94, 0x45, 0x46 }};

/**  
Enables/disables the generation of one progressive frame from every field.
\details <dl><dt><b>  Type: </b></dt><dd> 
VT_UI4 </dd></dl>
<dl><dt><b>  Available Values: </b></dt><dd>
0 - Feature is disabled (default).<br>
1 - Feature is enabled. </dd></dl> \hideinitializer */ // {9CF1A339-E72B-4a6d-BBE8-199595944546}
static const GUID MCVC1VD_DoubleRate = 
{0x9cf1a339, 0xe72b, 0x4a6d, {0xbb, 0xe8, 0x19, 0x95, 0x95, 0x94, 0x45, 0x46 }};

/**  
Sets the fields reordering mode.
\details <dl><dt><b>  Type: </b></dt><dd> 
VT_UI4 </dd></dl>
<dl><dt><b>  Available Values: </b></dt><dd>
vc1dec_field_reordering_off - Feature is disabled (default).<br>
vc1dec_field_reordering_invert_flags - Fields are reordered by inverting the specific media sample flags.<br>
vc1dec_field_reordering_xchg_fields - Fields are reordered by exchanging the fields in picture. </dd></dl> \hideinitializer */ // {9951682E-0F78-4924-92A4-BD7BFBA30063}
static const GUID MCVC1VD_FieldsReordering = 
{0x9951682e, 0xf78, 0x4924, {0x92, 0xa4, 0xbd, 0x7b, 0xfb, 0xa3, 0x0, 0x63 }};

/**  
Specifies the condition when fields must be reordered.
\details <dl><dt><b>  Type: </b></dt><dd> 
VT_UI4 </dd></dl>
<dl><dt><b>  Available Values: </b></dt><dd>
vc1dec_field_reordering_always - Always (default).<br>
vc1dec_field_reordering_top_first_true - If TopFirst flag is TRUE.<br>
vc1dec_field_reordering_top_first_false - If TopFirst flag is FALSE.
 </dd></dl> \hideinitializer */ // {8AE4A3D8-240B-427d-B845-5474965CBB48}
static const GUID MCVC1VD_FieldsReorderingCondition = 
{ 0x8ae4a3d8, 0x240b, 0x427d, { 0xb8, 0x45, 0x54, 0x74, 0x96, 0x5c, 0xbb, 0x48 } };

/**  
Retrieves the MediaTimeStart value of the last delivered frame (it may be a byte offset of the current frame as set by upstream demultiplexer/splitter in the media sample parameters). Typically application queries this parameter after receiving notification on parameter change from the filter (see Module Configuration Programmer Guide).
\details <dl><dt><b>  Type: </b></dt><dd> 
VT_I8 </dd></dl>
<dl><dt><b>  Available Values: </b></dt><dd>
I64_MIN – I64_MAX
  </dd></dl> \hideinitializer */ // {3903A73E-6A89-4e09-8E9F-95E8A56F614D}
static const GUID MCVC1VD_MediaTimeStart = 
{ 0x3903a73e, 0x6a89, 0x4e09, { 0x8e, 0x9f, 0x95, 0xe8, 0xa5, 0x6f, 0x61, 0x4d } };

/**  
Retrieves the MediaTimeStop value of the last delivered frame (it may be a byte offset of the current frame as set by upstream demultiplexer/splitter in the media sample parameters). Typically application queries this parameter after receiving notification on parameter change from the filter (see Module Configuration Programmer Guide).
\details <dl><dt><b>  Type: </b></dt><dd> 
VT_I8 </dd></dl>
<dl><dt><b>  Available Values: </b></dt><dd>
I64_MIN – I64_MAX
  </dd></dl> \hideinitializer */ // {BCF5D243-B80E-400a-9B60-035A1D3E5C38}
static const GUID MCVC1VD_MediaTimeStop = 
{ 0xbcf5d243, 0xb80e, 0x400a, { 0x9b, 0x60, 0x3, 0x5a, 0x1d, 0x3e, 0x5c, 0x38 } };

/**  
Retrieves the counter of displayed frames. Typically application queries this parameter after receiving notification on parameter change from the filter (see Module Configuration Programmer Guide).
\details <dl><dt><b>  Type: </b></dt><dd> 
VT_UI4 </dd></dl>
<dl><dt><b>  Available Values: </b></dt><dd>
0 - UI32_MAX </dd></dl> \hideinitializer */ // {575BA759-6F13-4a84-A126-005A5523D203}
static const GUID MCVC1VD_FramesDisplayed = 
{0x575ba759, 0x6f13, 0x4a84, {0xa1, 0x26, 0x0, 0x5a, 0x55, 0x23, 0xd2, 0x3 }};

/**  
Retrieves the counter of skipped frames. Typically application queries this parameter after receiving notification on parameter change from the filter (see Module Configuration Programmer Guide).
\details <dl><dt><b>  Type: </b></dt><dd> 
VT_UI4 </dd></dl>
<dl><dt><b>  Available Values: </b></dt><dd>
0 - UI32_MAX </dd></dl> \hideinitializer */ // {592A9FAB-CBF8-4592-A0B2-21D0C79DACE4}
static const GUID MCVC1VD_FramesSkipped = 
{0x592a9fab, 0xcbf8, 0x4592, {0xa0, 0xb2, 0x21, 0xd0, 0xc7, 0x9d, 0xac, 0xe4 }};

/**  
Enables or disables the displaying of frame statistical information on output images. Useful for debugging.
\details <dl><dt><b>  Type: </b></dt><dd> 
VT_UI4 </dd></dl>
<dl><dt><b>  Available Values: </b></dt><dd>
0 - Feature is disabled (default).<br>
1 - Feature is enabled. </dd></dl> \hideinitializer */ // {F5C51906-ED89-4c6e-9C37-A5CCB34F5389}
static const GUID MCVC1VD_OSD = 
{0xf5c51906, 0xed89, 0x4c6e, {0x9c, 0x37, 0xa5, 0xcc, 0xb3, 0x4f, 0x53, 0x89 }};

/**  
Sets the synchronization mode used by decoder:
Use PTS - Transfer incoming PTS from input bit stream to output frames.
Ignore PTS on non-reference frames - Transfer PTS only for reference frames, interpolate PTS for non-reference frames based on frame rate.
Ignore all PTS - Interpolate all output PTS based on frame count and frame rate.
\details <dl><dt><b>  Type: </b></dt><dd> 
VT_UI4 </dd></dl>
<dl><dt><b>  Available Values: </b></dt><dd>
vc1dec_synchronizing_PTS - Transfer incoming PTS from input bit stream to output frames.<br>
vc1dec_synchronizing_ignore_PTS_non_ref - Transfer PTS only for reference frames, interpolate PTS for non-reference frames based on frame rate.<br>
vc1dec_synchronizing_ignore_PTS_all - Interpolate all output PTS based on frame count and frame rate. </dd></dl> \hideinitializer */ // {24F62768-7740-437f-9651-9ED347C0CAD6}
static const GUID MCVC1VD_SYNCHRONIZING = 
{ 0x24f62768, 0x7740, 0x437f, { 0x96, 0x51, 0x9e, 0xd3, 0x47, 0xc0, 0xca, 0xd6 } };

#endif // __PROPID_MCVC1DEC_HEADER__
