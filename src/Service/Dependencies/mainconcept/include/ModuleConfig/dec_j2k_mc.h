 /**
\file dec_j2k_mc.h
\brief Property GUIDs for MainConcept AVC decoder parameters.

\verbatim
File: dec_j2k_mc.h

Desc: Property GUIDs forMainConcept Motion JPEG2000 decoder parameters.

 Copyright (c) 2015 MainConcept GmbH or its affiliates.  All rights reserved.

 MainConcept and its logos are registered trademarks of MainConcept GmbH or its affiliates.  
 This software is protected by copyright law and international treaties.  Unauthorized 
 reproduction or distribution of any portion is prohibited by law.
\endverbatim
*/

#if !defined(__PROPID_MJ2D_HEADER__)
#define __PROPID_MJ2D_HEADER__

//////////////////////////////////////////////////////////////////////////
//	Filter GUIDs
//////////////////////////////////////////////////////////////////////////

#include "common_mc.h"

//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
//	GUID								Type		Available range		Default Val		Note
// colour settings:
// MCMJ2D_DISABLERGB3					VT_UI4		[0, 1]				[0]				Enable/disable RGB3 output.
// MCMJ2D_DISABLERGB4					VT_UI4		[0, 1]				[0]				Enable/disable RGB4 output.
// MCMJ2D_DISABLERGBA					VT_UI4		[0, 1]				[0]				Enable/disable RGBA output.
// MCMJ2D_DISABLEYUYV					VT_UI4		[0, 1]				[0]				Enable/disable YUYV output.
// MCMJ2D_DISABLEUYVY					VT_UI4		[0, 1]				[0]				Enable/disable UYVY output.
// MCMJ2D_DISABLEV210					VT_UI4		[0, 1]				[0]				Enable/disable V210 output.
// MCMJ2D_DISABLEY416					VT_UI4		[0, 1]				[0]				Enable/disable Y416 output.
// MCMJ2D_DISABLEV216					VT_UI4		[0, 1]				[0]				Enable/disable V216 output.
// MCMJ2D_DISABLEXYZ12					VT_UI4		[0, 1]				[0]				Enable/disable XYZC output.
// MCMJ2D_TRANSFORM_XYZ					VT_UI4		[0, 1]				[0]				Enable/disable interpretation of stream as DCI XYZ format.
// MCMJ2D_CLIP_RANGE					VT_UI4		[0, 1]				[0]				Sets PC/STUDIO clip range.

//	quality settings:
// MCMJ2D_NUMDECOMPLAYERS				VT_UI4		[0, 8]				[0]				Sets maximum number of layers to decode.
// MCMJ2D_NEWDOWNSAMPLEFCTR				VT_UI4		[0, 2]				[0]				Sets downsample rate, depends on number of decomposition levels present in stream.
// MCMJ2D_ACCELERATION					VT_UI4		[0, 3]				[1]				Sets acceleration mode, reduces quality.
// MCMJ2D_DWT_PRECISION					VT_UI4		[0, 1]				[0]				Sets float/integer precision cores to use for lossy stream decoding.
// MCMJ2D_OBEYQM						VT_UI4		[0, 1]				[0]				Enable/Disable reaction on quality messages.
// MCMJ2D_SKIP_TYPE						VT_UI4		[0, 2]				[0]				Sets skip \details <dl><dt><b>  Type: </b></dt><dd>  by Frames, by codepassses, both. Make sense only when obeying quality messages enabled.
// MCMJ2D_SKIPPASSES					VT_UI4		[0, 64]				[3]				Sets numbers of codepasses to skip during entropy steps. 3 passes equal to skipping decoding of 1 bit-plane.
																					
// general settings:
// MCMJ2D_THREADS_NUM					VT_UI4		[0, 32]				[1]				Sets number of threads used for decoding.
// MCMJ2D_LOWDELAYMODE					VT_UI4		[0, 1]				[1]				Sets parallelization mode: inside frame or per frames.
// MCMJ2D_OUTPUTBUFFERS					VT_UI4		[1, 128]			[16]			Sets number of output buffers to use.
// MCMJ2D_STEREO_FORMAT					VT_UI4		[0, 2]				[0]				Sets output of top-bottom stereo image from to consecutive frames.
// MCMJ2D_FLIP							VT_UI4		[0, 1]				[0]				Enable/disable image flip.
// MCMJ2D_HIDEERRORS						VT_UI4		[0, 1]				[0]				Hide/show broken frames.
// MCMJ2D_DOUBLE_RATE					VT_UI4		[0, 1]				[0]				Enable/disable double rate, usable for interlace streams.
// MCMJ2D_DEINTERLACE					VT_UI4		[0, 2]				[1]				Sets deinterlace mode: VMR or Weave, usable for interlace streams.
// MCMJ2D_FIELD_REORDER				VT_UI4		[0, 1]				[0]				Enable/disable field reordering.
// deprecated:
// MCMJ2D_GAMMAFACTOR					VT_UI4		[18, 30]			[20]			Not used anymore.
// MCMJ2D_XYZ_COLUR_FORMAT				VT_UI4		[0, 15]      		[14]			Not used anymore.

/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

//acceleration modes
#define ACCELERATION_QUALITY	0x0000 /**< \hideinitializer */
#define ACCELERATION_NORMAL		0x0001 /**< \hideinitializer */
#define ACCELERATION_MEDIUM		0x0002 /**< \hideinitializer */
#define ACCELERATION_STRONG		0x0003 /**< \hideinitializer */

//deinterlace modes
#define DISPLAY_MODE_DEFAULT	0x0000 /**< \hideinitializer */
#define DISPLAY_MODE_WEAVE		0x0001 /**< \hideinitializer */
#define DISPLAY_MODE_VMR		0x0002 /**< \hideinitializer */

//stereo formats
#define STEREO_NONE						0x0000 /**< \hideinitializer */
#define STEREO_OVER_UNDER_LEFT_FIRST	0x0001 /**< \hideinitializer */
#define STERRO_OVER_UNDER_RIGHT_FIRST	0x0002 /**< \hideinitializer */


//skip types
#define SKIP_TYPE_BY_FRAMES		0x0000 /**< \hideinitializer */
#define SKIP_TYPE_BY_PASSES		0x0001 /**< \hideinitializer */
#define SKIP_TYPE_BOTH			0x0002 /**< \hideinitializer */

//Reorder Modes
#define FieldReordering_Off 0
#define FieldReordering_FlagsInverting 1
#define FieldReordering_FieldsInverting 2
#define FieldReordering_Auto 3

/**  
Sets the number of layers for decoding.
\details <dl><dt><b>  Type: </b></dt><dd> 
VT_UINT </dd></dl>
<dl><dt><b>  Available Values: </b></dt><dd>
0 - All layers
1 - Layer 1 only <br>
2 - Layers 1 through 2 <br>
3 - Layers 1 through 3 <br>
etc.
</dd></dl> \hideinitializer */ // {0DCBDB67-48DC-480a-BA63-CFB8C349B340}
static const GUID MCMJ2D_NUMDECOMPLAYERS = 
{ 0xdcbdb67, 0x48dc, 0x480a, { 0xba, 0x63, 0xcf, 0xb8, 0xc3, 0x49, 0xb3, 0x40 } };

/**  
Specifies whether the decoder should use inter frame or intra frame multithreading.
\details <dl><dt><b>  Type: </b></dt><dd> 
VT_UINT </dd></dl>
<dl><dt><b>  Available Values: </b></dt><dd>
0 - Enables inter frame multithreading.
1 - Enables intra frame multithreading.
</dd></dl> \hideinitializer */ // {F4A8E8FB-B9FD-4e25-AFCA-5188DD425DED}
static const GUID MCMJ2D_LOWDELAYMODE = 
{ 0xf4a8e8fb, 0xb9fd, 0x4e25, { 0xaf, 0xca, 0x51, 0x88, 0xdd, 0x42, 0x5d, 0xed } };

/**  
Disables the RGB3 output.
\details <dl><dt><b>  Type: </b></dt><dd> 
VT_UINT </dd></dl>
<dl><dt><b>  Available Values: </b></dt><dd>
0, 1
</dd></dl> \hideinitializer */ // {1CA85273-0144-4b1a-B298-9CD30CFE6135}
static const GUID MCMJ2D_DISABLERGB3 = 
{ 0x1ca85273, 0x144, 0x4b1a, { 0xb2, 0x98, 0x9c, 0xd3, 0xc, 0xfe, 0x61, 0x35 } };

/**  
Disables the RGB4 output.
\details <dl><dt><b>  Type: </b></dt><dd> 
VT_UINT </dd></dl>
<dl><dt><b>  Available Values: </b></dt><dd>
0, 1
</dd></dl> \hideinitializer */ // {050BEC8F-AA9C-410e-A6A8-5B69D81C1401}
static const GUID MCMJ2D_DISABLERGB4 = 
{ 0x50bec8f, 0xaa9c, 0x410e, { 0xa6, 0xa8, 0x5b, 0x69, 0xd8, 0x1c, 0x14, 0x1 } };

/**  
Disables the RGBA output.
\details <dl><dt><b>  Type: </b></dt><dd> 
VT_UINT </dd></dl>
<dl><dt><b>  Available Values: </b></dt><dd>
0, 1	
</dd></dl> \hideinitializer */ // {4A457385-56B2-4f48-852C-2A26BE7F89E7}
static const GUID MCMJ2D_DISABLERGBA = 
{ 0x4a457385, 0x56b2, 0x4f48, { 0x85, 0x2c, 0x2a, 0x26, 0xbe, 0x7f, 0x89, 0xe7 } };


/**  
Disables the YUYV output.
\details <dl><dt><b>  Type: </b></dt><dd> 
VT_UINT </dd></dl>
<dl><dt><b>  Available Values: </b></dt><dd>
0, 1
</dd></dl> \hideinitializer */ // {183C0490-5AE6-4d6f-8820-A1BD507E3134}
static const GUID MCMJ2D_DISABLEYUYV = 
{ 0x183c0490, 0x5ae6, 0x4d6f, { 0x88, 0x20, 0xa1, 0xbd, 0x50, 0x7e, 0x31, 0x34 } };

/**  
Disables the UYVY output.
\details <dl><dt><b>  Type: </b></dt><dd> 
VT_UINT </dd></dl>
<dl><dt><b>  Available Values: </b></dt><dd>
0, 1
</dd></dl> \hideinitializer */ // {DCE585F6-55BD-46f1-A8AF-392A2771695A}
static const GUID MCMJ2D_DISABLEUYVY = 
{ 0xdce585f6, 0x55bd, 0x46f1, { 0xa8, 0xaf, 0x39, 0x2a, 0x27, 0x71, 0x69, 0x5a } };

/**  
Disables the V210 output.
\details <dl><dt><b>  Type: </b></dt><dd> 
VT_UINT </dd></dl>
<dl><dt><b>  Available Values: </b></dt><dd>
0, 1
</dd></dl> \hideinitializer */ // {72794C7B-0822-4184-8E8D-89B9A9739979}
static const GUID MCMJ2D_DISABLEV210 = 
{ 0x72794c7b, 0x822, 0x4184, { 0x8e, 0x8d, 0x89, 0xb9, 0xa9, 0x73, 0x99, 0x79 } };


/**  
Retrieves the used FOURCC. Read-only.
\details <dl><dt><b>  Type: </b></dt><dd> 
VT_UINT </dd></dl>
</dd></dl> \hideinitializer */ // {DCF56E93-AB55-4d22-BD62-05FB0C10BC47}
static const GUID MCMJ2D_UsedFourCC = 
{ 0xdcf56e93, 0xab55, 0x4d22, { 0xbd, 0x62, 0x5, 0xfb, 0xc, 0x10, 0xbc, 0x47 } };

/**  
Sets the downsampling factor exponent.
\details <dl><dt><b>  Type: </b></dt><dd> 
VT_UINT </dd></dl>
<dl><dt><b>  Available Values: </b></dt><dd>
0 - Downsampling factor 1. <br>
1 - Downsampling factor 2. <br>
2 - Downsampling factor 4.
</dd></dl> \hideinitializer */ // {FC97F965-5417-4acc-B866-7675E210A016}
static const GUID MCMJ2D_NEWDOWNSAMPLEFCTR = 
{ 0xfc97f965, 0x5417, 0x4acc, { 0xb8, 0x66, 0x76, 0x75, 0xe2, 0x10, 0xa0, 0x16 } };

/**  
Flips the image.
\details <dl><dt><b>  Type: </b></dt><dd> 
VT_UINT </dd></dl>
<dl><dt><b>  Available Values: </b></dt><dd>
0, 1
</dd></dl> \hideinitializer */ // {886D90CC-93F4-4f6e-A634-AFF78AA245E8}
static const GUID MCMJ2D_FLIP = 
{ 0x886d90cc, 0x93f4, 0x4f6e, { 0xa6, 0x34, 0xaf, 0xf7, 0x8a, 0xa2, 0x45, 0xe8 } };

/**
Hide frames with errors.
\details <dl><dt><b>  Type: </b></dt><dd>
VT_UINT </dd></dl>
<dl><dt><b>  Available Values: </b></dt><dd>
0, 1
</dd></dl> \hideinitializer */ // {886D90CC-93F4-4f6e-A634-AFF78AA245E8}
// {2D1CFFF7-9E15-45CA-9448-9734775781C0}
static const GUID MCMJ2D_HIDEERRORS =
{ 0x2d1cfff7, 0x9e15, 0x45ca, { 0x94, 0x48, 0x97, 0x34, 0x77, 0x57, 0x81, 0xc0 } };

/**  
If this parameter value is equal to 1, the filter handles the quality messages generated with the video renderer.
\details <dl><dt><b>  Type: </b></dt><dd> 
VT_UINT </dd></dl>
<dl><dt><b>  Available Values: </b></dt><dd>
0, 1
</dd></dl> \hideinitializer */ // {67D7A35B-E7E7-496b-A77E-C03759D3D7A4}
static const GUID MCMJ2D_OBEYQM = 
{ 0x67d7a35b, 0xe7e7, 0x496b, { 0xa7, 0x7e, 0xc0, 0x37, 0x59, 0xd3, 0xd7, 0xa4 } };

/**  
The filter uses this parameter to adjust level of quality degradation in favor of faster playback. the parameter sets the number of codepasses to skip at bit level decoding of the bitstream.
\details <dl><dt><b>  Type: </b></dt><dd> 
VT_UINT  </dd></dl>
<dl><dt><b>  Available Values: </b></dt><dd>
0 - 31
</dd></dl> \hideinitializer */ // {AD2FAABE-F4F6-4cbd-8C1E-97DF335778E1}
static const GUID MCMJ2D_SKIPPASSES = 
{ 0xad2faabe, 0xf4f6, 0x4cbd, { 0x8c, 0x1e, 0x97, 0xdf, 0x33, 0x57, 0x78, 0xe1 } };

/**  
Sets the deinterlace mode.
\details <dl><dt><b>  Type: </b></dt><dd> 
VT_UINT </dd></dl>
<dl><dt><b>  Available Values: </b></dt><dd>
0 - None<br>
1 - Weave (Does not deinterlace - output interleaved fields).<br>
2 - VMR (Puts correct interlacing flags on output samples and lets VMR (Video Mixing Renderer) decide on deinterlacing)
</dd></dl> \hideinitializer */ // {26DBAB70-C3F9-488c-BD0F-02CF41D66E86}
static const GUID MCMJ2D_DEINTERLACE = 
{ 0x26dbab70, 0xc3f9, 0x488c, { 0xbd, 0xf, 0x2, 0xcf, 0x41, 0xd6, 0x6e, 0x86 } };

/**  
Sets the acceleration mode.
\details <dl><dt><b>  Type: </b></dt><dd> 
VT_UINT </dd></dl>
<dl><dt><b>  Available Values: </b></dt><dd>

ACCELERATION_QUALITY  Real decoding of all data <br>
ACCELERATION_NORMAL    Skip decoding of last chrominance decompostion levels. Do interpolation instead  <br>
ACCELERATION_MEDIUM As previous, plus skip last but one chrominance decompostion level.  <br>
ACCELERATION_STRONG As previous, plus skip last luminance decompostion level. 
</dd></dl> \hideinitializer */ // {1D11E137-1863-4500-9499-26791D580B73}
static const GUID MCMJ2D_ACCELERATION = 
{ 0x1d11e137, 0x1863, 0x4500, { 0x94, 0x99, 0x26, 0x79, 0x1d, 0x58, 0xb, 0x73 } };

/**  
Specifies the number of threads that should be used for decoding.
\details <dl><dt><b>  Type: </b></dt><dd> 
VT_UINT </dd></dl>
<dl><dt><b>  Available Values: </b></dt><dd>
 1 - 16
</dd></dl> \hideinitializer */ // {5FFF5D78-E58E-4f7f-B042-1DEBCC4CA3F1}
static const GUID MCMJ2D_THREADS_NUM = 
{ 0x5fff5d78, 0xe58e, 0x4f7f, { 0xb0, 0x42, 0x1d, 0xeb, 0xcc, 0x4c, 0xa3, 0xf1 } };

/** Deprecacted \hideinitializer */ // {726CD9CF-3937-4d2f-9EFC-B0F00E7BF967}
static const GUID MCMJ2D_INPUTPIN_CONNECTED = 
{ 0x726cd9cf, 0x3937, 0x4d2f, { 0x9e, 0xfc, 0xb0, 0xf0, 0xe, 0x7b, 0xf9, 0x67 } };

/** Deprecacted \hideinitializer */ // {B4172E82-4C45-49af-A1CF-ED022AD86FCB}
static const GUID MCMJ2D_OUTPUTPIN_CONNECTED = 
{ 0xb4172e82, 0x4c45, 0x49af, { 0xa1, 0xcf, 0xed, 0x2, 0x2a, 0xd8, 0x6f, 0xcb } };

/**  
Enables transform from DCI's xyz format.
\details <dl><dt><b>  Type: </b></dt><dd> 
VT_UINT </dd></dl>
<dl><dt><b>  Available Values: </b></dt><dd>
0 - Do not convert XYZ output to RGB.<br>
1 - Convert XYZ output to RGB.
</dd></dl> \hideinitializer */ // {43C3FB8C-A548-4112-B1C5-A830B8D1F2D3}
static const GUID MCMJ2D_TRANSFORM_XYZ = 
{ 0x43c3fb8c, 0xa548, 0x4112, { 0xb1, 0xc5, 0xa8, 0x30, 0xb8, 0xd1, 0xf2, 0xd3 } };

/**  
Sets number of output buffers to use.
\details <dl><dt><b>  Type: </b></dt><dd> 
VT_UINT </dd></dl>
<dl><dt><b>  Available Values: </b></dt><dd>
0, 128
</dd></dl> \hideinitializer */ // {7A404DC2-A591-4f3a-AC93-D473BB38C93A}
static const GUID MCMJ2D_OUTPUTBUFFERS = 
{ 0x7a404dc2, 0xa591, 0x4f3a, { 0xac, 0x93, 0xd4, 0x73, 0xbb, 0x38, 0xc9, 0x3a } };

/**  Deprecacted \hideinitializer */ // {C71999F4-E0BB-4575-A45B-45AD308BA8CC}
static const GUID MCMJ2D_USEDOUTPUTBUFFERS = 
{ 0xc71999f4, 0xe0bb, 0x4575, { 0xa4, 0x5b, 0x45, 0xad, 0x30, 0x8b, 0xa8, 0xcc } };

/**  Deprecacted \hideinitializer */ // {6722FCFB-E259-4912-9827-2CFDAC560824}
static const GUID MCMJ2D_GAMMAFACTOR = 
{ 0x6722fcfb, 0xe259, 0x4912, { 0x98, 0x27, 0x2c, 0xfd, 0xac, 0x56, 0x8, 0x24 } };

/** Deprecacted  \hideinitializer */ // {8C599A11-76EC-44fd-B12D-999E4BC90081}
static const GUID MCMJ2D_XYZ_COLUR_FORMAT = 
{ 0x8c599a11, 0x76ec, 0x44fd, { 0xb1, 0x2d, 0x99, 0x9e, 0x4b, 0xc9, 0x0, 0x81 } };

/**  
Sets skip type. Make sense only when quality message listening enabled.  
\details <dl><dt><b>  Type: </b></dt><dd> 
VT_UINT </dd></dl>
<dl><dt><b>  Available Values: </b></dt><dd>
 - SKIP_TYPE_BY_FRAMES skip frames until sync happens <br>
 - SKIP_TYPE_BY_PASSES  adaptivly increase number of codepasses to skip until sync happens. The maximum allowed value is selected based on stream complexity to avoid significant quality degradation. <br>
 - SKIP_TYPE_BOTH skip frames and increase number of codepasses to skip until sync happens 
</dd></dl> \hideinitializer */ // {EBCD03D7-AB20-4604-889B-ACB947BC0652}
static const GUID MCMJ2D_SKIP_TYPE = 
{ 0xebcd03d7, 0xab20, 0x4604, { 0x88, 0x9b, 0xac, 0xb9, 0x47, 0xbc, 0x6, 0x52 } };

/**  
Disables the Y416 output.
\details <dl><dt><b>  Type: </b></dt><dd> 
VT_UINT </dd></dl>
<dl><dt><b>  Available Values: </b></dt><dd>
0, 1
</dd></dl> \hideinitializer */ // {221B79CB-1A22-4a6a-A4A4-FA54287860C7}
static const GUID MCMJ2D_DISABLEY416 = 
{ 0x221b79cb, 0x1a22, 0x4a6a, { 0xa4, 0xa4, 0xfa, 0x54, 0x28, 0x78, 0x60, 0xc7 } };

/**  
Disables the V216 output.
\details <dl><dt><b>  Type: </b></dt><dd> 
VT_UINT </dd></dl>
<dl><dt><b>  Available Values: </b></dt><dd>
0, 1
</dd></dl> \hideinitializer */ // {2076CEDE-DA58-47db-A8B1-49D550C49B15}
static const GUID MCMJ2D_DISABLEV216 = 
{ 0x2076cede, 0xda58, 0x47db, { 0xa8, 0xb1, 0x49, 0xd5, 0x50, 0xc4, 0x9b, 0x15 } };

/**  
Disables the Y16 output.
\details <dl><dt><b>  Type: </b></dt><dd> 
VT_UINT </dd></dl>
<dl><dt><b>  Available Values: </b></dt><dd>
0, 1
</dd></dl> \hideinitializer */ // {56F9AFE9-08E5-4ec5-8ECE-393F899AEC2D}
static const GUID MCMJ2D_DISABLEY16 = 
{ 0x56f9afe9, 0x8e5, 0x4ec5, { 0x8e, 0xce, 0x39, 0x3f, 0x89, 0x9a, 0xec, 0x2d } };

/**  
Set output signal clipping range
\details <dl><dt><b>  Type: </b></dt><dd> 
VT_UINT </dd></dl>
<dl><dt><b>  Available Values: </b></dt><dd>
0 - PC full range (0..255)
1 - Studio/TV reduced range(16..235)
</dd></dl> \hideinitializer */ // {7AAD04D5-FD63-4a47-8D72-801E70F2E63C}
static const GUID MCMJ2D_CLIP_RANGE = 
{ 0x7aad04d5, 0xfd63, 0x4a47, { 0x8d, 0x72, 0x80, 0x1e, 0x70, 0xf2, 0xe6, 0x3c } };

/**  
Interpet to consecutive frames as views of stereoscopic image and do apporiate over/under frame bonding.
\details <dl><dt><b>  Type: </b></dt><dd> 
VT_UINT </dd></dl>
<dl><dt><b>  Available Values: </b></dt><dd>
STEREO_NONE	- do nothing<br>
STEREO_OVER_UNDER_LEFT_FIRST  - do over/under frame bonding, left view is top frame <br>	
STERRO_OVER_UNDER_RIGHT_FIRST - do over/under frame bonding, right view is top frame
</dd></dl> \hideinitializer */ // {608F4F68-5F31-4e23-BA5B-A5B26B78606C}
static const GUID MCMJ2D_STEREO_FORMAT = 
{ 0x608f4f68, 0x5f31, 0x4e23, { 0xba, 0x5b, 0xa5, 0xb2, 0x6b, 0x78, 0x60, 0x6c } };

/**  
Set decoder's core engine
\details <dl><dt><b>  Type: </b></dt><dd> 
VT_UINT </dd></dl>
<dl><dt><b>  Available Values: </b></dt><dd>
0 - use integer approximated core. <br>
1 - use fare float precision core.
</dd></dl> \hideinitializer */ // {C92875B3-237B-4eb5-BE45-5BE0E02410F9}
static const GUID MCMJ2D_DWT_PRECISION = 
{ 0xc92875b3, 0x237b, 0x4eb5, { 0xbe, 0x45, 0x5b, 0xe0, 0xe0, 0x24, 0x10, 0xf9 } };

/**  
Enable/Disable frame rate increase by factor of 2.
\details <dl><dt><b>  Type: </b></dt><dd> 
VT_UINT </dd></dl>
<dl><dt><b>  Available Values: </b></dt><dd>
0, 1
</dd></dl> \hideinitializer */ // {87CD9662-486E-4A25-8E42-C4B6A5370BE4}
static const GUID MCMJ2D_DOUBLE_RATE = 
{ 0x87cd9662, 0x486e, 0x4a25, { 0x8e, 0x42, 0xc4, 0xb6, 0xa5, 0x37, 0xb, 0xe4 } };

/**  
Disables the XYZC output.
\details <dl><dt><b>  Type: </b></dt><dd> 
VT_UINT </dd></dl>
<dl><dt><b>  Available Values: </b></dt><dd>
0, 1
</dd></dl> \hideinitializer */ // {78B53C78-A0AE-4B05-8C43-65AB27D07F2D}
static const GUID MCMJ2D_DISABLEXYZ12 = 
{ 0x78b53c78, 0xa0ae, 0x4b05, { 0x8c, 0x43, 0x65, 0xab, 0x27, 0xd0, 0x7f, 0x2d } };

/**  
Enable/Disable field reordering. Make sense only for interlace content.
\details <dl><dt><b>  Type: </b></dt><dd> 
VT_UINT </dd></dl>
<dl><dt><b>  Available Values: </b></dt><dd>
0, 1
</dd></dl> \hideinitializer */ // {2B7F9793-7D50-465B-8897-6708E6BFB74C}
static const GUID MCMJ2D_FIELD_REORDER = 
{ 0x2b7f9793, 0x7d50, 0x465b, { 0x88, 0x97, 0x67, 0x8, 0xe6, 0xbf, 0xb7, 0x4c } };


#endif // __PROPID_MJ2D_HEADER__