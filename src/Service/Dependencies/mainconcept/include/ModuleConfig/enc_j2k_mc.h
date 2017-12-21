/**
\file enc_j2k_mc.h
\brief Property GUIDs for MainConcept JPEG-2000 encoder parameters.

\verbatim
File: enc_j2k_mc.h

Desc: Property GUIDs forMainConcept JPEG-2000 encoder parameters.

 Copyright (c) 2015 MainConcept GmbH or its affiliates.  All rights reserved.

 MainConcept and its logos are registered trademarks of MainConcept GmbH or its affiliates.  
 This software is protected by copyright law and international treaties.  Unauthorized 
 reproduction or distribution of any portion is prohibited by law.
\endverbatim
*/

#if !defined(__PROPID_MJ2E_HEADER__)
#define __PROPID_MJ2E_HEADER__

#include "common_mc.h"
//////////////////////////////////////////////////////////////////////////
//	Filter GUIDs
//////////////////////////////////////////////////////////////////////////

//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
//	GUID								Type		Available range			  Default Val		Note
//
// MC_OPERATION_MODE              VT_INT													Operation mode (see MC_COMMON::OperationMode)
// MCMJ2E_ESETTING_NUMDWTLEVELS   VT_UINT </dd></dl>													number of DWT levels used for decomposition
// MCMJ2E_ESETTING_NUMLAYERS			VT_UINT </dd></dl>													number of layers in output image. Bit-rate is proportionally distributed through layers
// MCMJ2E_ESETTING_CBXSIZE				VT_UINT </dd></dl>		[5,6]										Code-block width, 5 - 32 pixels, 6 - 64 pixels
// MCMJ2E_ESETTING_CBYSIZE				VT_UINT </dd></dl>		[5,6]										Code-block height, 5 - 32 pixels, 6 - 64 pixels
// MC_BITRATE_AVG                 VT_INT													target bit-rate x100, given as percent of original frame size
// MCMJ2E_ESETTING_DISABLERGB3			VT_UINT </dd></dl>,												disable RGB3 output format, T-true, F-false
// MCMJ2E_ESETTING_DISABLERGB4			VT_UINT </dd></dl>													disable RGB4 output format, T-true, F-false
// MCMJ2E_ESETTING_DISABLERGBA			VT_UINT </dd></dl>													disable RGBA output format, T-true, F-false
// MCMJ2E_ESETTING_UsedFourCC			VT_UINT </dd></dl>													read-only, selected output color space, [FOURCC_BGR3|FOURCC_BGR4|FOURCC_BGRA]
// MCMJ2E_ESETTING_LowLevelFlags		VT_UINT </dd></dl>													fMJ2E_JP2_OUTPUT  	encoder outputs jp2 stream
//																								fMJ2E_JPC_OUTPUT  	encoder outputs jpc stream
//																								fMJ2E_PROGRESSION_LRCP	Layer-resolution-component-position progression
//																								fMJ2E_PROGRESSION_CPRL	Component, position, resolution, layer progression
//																								fMJ2E_MODE_INT_5_3 	use 5-3 DWT filter, RCT, integer mode
//																								fMJ2E_MODE_REAL_9_7 	use 9-7 DWT filter, ICT, fixed-point mode
//																								fMJ2E_BitRateAbsolute	TRUE - bit rates are given as absolute values, 
//																														FALSE - bit rates are given as relative values (percent of input bit-rate)
//																								fMJ2E_DCI_2K	input parameters restricted to DCI's 2K distribution
//																								fMJ2E_DCI_4K	input parameters restricted to DCI's 4K distribution
// MCMJ2E_ESETTING_FRAMERATECODE		VT_UINT </dd></dl>		[0-5]							Input frame rate codes for DCI
//																								0 - 24 fps
//																								1 - 25 fps
//																								2 - 30 fps
//																								3 - 48 fps
//																								4 - 50 fps
//																								5 - 60 fps
// MCMJ2E_ESETTING_PRECSIZE				VT_UINT </dd></dl>		[7,8,15]									precinct size coefficient 
//																								7 - 128x128 precincts, 64x64 for resolution 0
//																								8 - 256x256 precincts, 128x128 for resolution 0
//																								15 - maximal precincts
// MCMJ2E_ESETTING_DISABLEYUY2			VT_UINT </dd></dl>													disable YUY2 output format, T-true, F-false
// MCMJ2E_ESETTING_MaxBitDepth			VT_UINT </dd></dl>		[4-16]										Maximal bit-depth for encoding
// MCMJ2E_ESETTING_Layer1BitRate		VT_UINT </dd></dl>													bit-rate for layer 1
// MCMJ2E_ESETTING_Layer2BitRate		VT_UINT </dd></dl>													bit-rate for layer 2
// MCMJ2E_ESETTING_Layer3BitRate		VT_UINT </dd></dl>													bit-rate for layer 3
// MCMJ2E_ESETTING_Layer4BitRate		VT_UINT </dd></dl>													bit-rate for layer 4
// MCMJ2E_ESETTING_Layer5BitRate		VT_UINT </dd></dl>													bit-rate for layer 5
// MCMJ2E_ESETTING_Layer6BitRate		VT_UINT </dd></dl>													bit-rate for layer 6
// MCMJ2E_ESETTING_CPRLSubsamplFactor	VT_UINT </dd></dl>		[0-3]										Subsampling factor when CPRL progression order is used. This parameter can be used for producing 
//																								stream that can be decoded in both original (1/1) and lower (1/2 | 1/4 | 1/8 ) resolution. By 
//																								sumbsampling at decoder side, any stream can be decoded in lower resolution, but not at optimal 
//																								speed. By using this feature, you get much faster downsampling at decoder side. 
//																								0 - encoded stream is not optimized for subsampling 
//																								1 - encoded stream is optimized for 1/2 subsampling
//																								2 - encoded stream is optimized for 1/4 subsampling
//																								3 - encoded stream is optimized for 1/8 subsampling
// MCMJ2E_DFSETTING_INPUTPIN_CONNECTED	VT_UINT </dd></dl>													read-only, indicates that input pin is connected
// MCMJ2E_DFSETTING_OUTPUTPIN_CONNECTED	VT_UINT </dd></dl>													read-only, indicates that output pin is connected


/**
Sets the number of DWT levels used for decomposition.
\details <dl><dt><b>  Type: </b></dt><dd> 
VT_UINT </dd></dl> 
</dd></dl> \hideinitializer */ // {76817CBF-3F36-4187-B5FD-A159725248B0}
static const GUID MCMJ2E_ESETTING_NUMDWTLEVELS = 
{ 0x76817cbf, 0x3f36, 0x4187, { 0xb5, 0xfd, 0xa1, 0x59, 0x72, 0x52, 0x48, 0xb0 } };

/**
Sets the number of layers in output image. Bitrate is proportionally distributed through layers.
\details <dl><dt><b>  Type: </b></dt><dd> 
VT_UINT </dd></dl>
<dl><dt><b>  Available Values: </b></dt><dd>
0, 1
</dd></dl> \hideinitializer */ // {C2279F94-6B4D-43a0-BF69-660BC2E654F1}
static const GUID MCMJ2E_ESETTING_NUMLAYERS = 
{ 0xc2279f94, 0x6b4d, 0x43a0, { 0xbf, 0x69, 0x66, 0xb, 0xc2, 0xe6, 0x54, 0xf1 } };

/**
Sets the code-block width.
\details <dl><dt><b>  Type: </b></dt><dd> 
VT_UINT </dd></dl>
<dl><dt><b>  Available Values: </b></dt><dd>
5 - 32 pixels. <br>
6 - 64 pixels.
</dd></dl> \hideinitializer */ // {BCAC0929-029A-481c-8774-69E58E28FF83}
static const GUID MCMJ2E_ESETTING_CBXSIZE = 
{ 0xbcac0929, 0x29a, 0x481c, { 0x87, 0x74, 0x69, 0xe5, 0x8e, 0x28, 0xff, 0x83 } };

/**
Sets the code-block height.
\details <dl><dt><b>  Type: </b></dt><dd> 
VT_UINT </dd></dl>
<dl><dt><b>  Available Values: </b></dt><dd>
5 - 32 pixels. <br>
6 - 64 pixels.
</dd></dl> \hideinitializer */ // {923D05FF-94B1-43db-A0BF-4A7A6F5110BC}
static const GUID MCMJ2E_ESETTING_CBYSIZE = 
{ 0x923d05ff, 0x94b1, 0x43db, { 0xa0, 0xbf, 0x4a, 0x7a, 0x6f, 0x51, 0x10, 0xbc } };

/**
Disables the RGB3 output.
\details <dl><dt><b>  Type: </b></dt><dd> 
VT_UINT </dd></dl>
<dl><dt><b>  Available Values: </b></dt><dd>
0, 1
</dd></dl> \hideinitializer */ // {27941349-5268-40c5-9142-A2ABCA8EAFD7}
static const GUID MCMJ2E_ESETTING_DISABLERGB3 = 
{ 0x27941349, 0x5268, 0x40c5, { 0x91, 0x42, 0xa2, 0xab, 0xca, 0x8e, 0xaf, 0xd7 } };

/**
Disables the RGB4 output.
\details <dl><dt><b>  Type: </b></dt><dd> 
VT_UINT </dd></dl>
<dl><dt><b>  Available Values: </b></dt><dd>
0, 1
</dd></dl> \hideinitializer */ // {6D76C533-8E36-42cd-8EEB-69FE59AB2564}
static const GUID MCMJ2E_ESETTING_DISABLERGB4 = 
{ 0x6d76c533, 0x8e36, 0x42cd, { 0x8e, 0xeb, 0x69, 0xfe, 0x59, 0xab, 0x25, 0x64 } };

/**
Disables the RGBA output.
\details <dl><dt><b>  Type: </b></dt><dd> 
VT_UINT </dd></dl>
<dl><dt><b>  Available Values: </b></dt><dd>
0, 1
</dd></dl> \hideinitializer */ // {E628F4D0-ACBD-40e2-885E-8B736B71A635}
static const GUID MCMJ2E_ESETTING_DISABLERGBA = 
{ 0xe628f4d0, 0xacbd, 0x40e2, { 0x88, 0x5e, 0x8b, 0x73, 0x6b, 0x71, 0xa6, 0x35 } };

/**
Retrieves the used FOURCC. Read-only.
\details <dl><dt><b>  Type: </b></dt><dd> 
VT_UINT </dd></dl>
</dd></dl> \hideinitializer */ // {1EBE82B5-597F-4594-94CF-6AF73A83279C}
static const GUID MCMJ2E_ESETTING_UsedFourCC = 
{ 0x1ebe82b5, 0x597f, 0x4594, { 0x94, 0xcf, 0x6a, 0xf7, 0x3a, 0x83, 0x27, 0x9c } };

// {8B0E624A-4886-40f6-9E73-125DBD7378D5}
static const GUID MCMJ2E_EPARAM_RAWBPS = 
{ 0x8b0e624a, 0x4886, 0x40f6, { 0x9e, 0x73, 0x12, 0x5d, 0xbd, 0x73, 0x78, 0xd5 } };

/**
Sets the low-level flags.
\details <dl><dt><b>  Type: </b></dt><dd> 
VT_UINT </dd></dl>
<dl><dt><b>  Available Values: </b></dt><dd>
fMJ2E_JP2_OUTPUT - Encoder outputs jp2 stream. <br>
fMJ2E_JPC_OUTPUT - Encoder outputs jpc stream. <br>
fMJ2E_PROGRESSION_LRCP - Layer-resolution-component-position progression. <br>
fMJ2E_PROGRESSION_CPRL - Component-position-resolution-layer progression. <br>
fMJ2E_MODE_INT_5_3 - Use 5-3 DWT filter, RCT, integer mode. <br>
fMJ2E_MODE_REAL_9_7 - Use 9-7 DWT filter, ICT, fixed-point mode. <br>
fMJ2E_BitRateAbsolute - TRUE - bit rates are given as absolute values; FALSE - bitrates are given as relative values (percentage of input bitrate). <br>
fMJ2E_DCI_2K - Input parameters restricted to DCI's 2K distribution.<br>
fMJ2E_DCI_4K - Input parameters restricted to DCI's 4K distribution. <br>
</dd></dl> \hideinitializer */ // {CA19F4A5-4846-4f7b-B103-142F494A4003}
static const GUID MCMJ2E_ESETTING_LowLevelFlags = 
{ 0xca19f4a5, 0x4846, 0x4f7b, { 0xb1, 0x3, 0x14, 0x2f, 0x49, 0x4a, 0x40, 0x3 } };

/**
Sets the frame rate codes for DCI.
\details <dl><dt><b>  Type: </b></dt><dd> 
VT_UINT </dd></dl>
<dl><dt><b>  Available Values: </b></dt><dd>
0 - value for 24 fps <br>
1 - value for 25 fps <br>
2 - value for 30 fps <br>
3 - value for 48 fps <br>
4 - value for 50 fps <br>
5 - value for 60 fps <br>
</dd></dl> \hideinitializer */ // {D03A7091-44EF-44F5-81D8-C344D0DD24B5}
static const GUID MCMJ2E_ESETTING_FRAMERATECODE = 
{ 0xd03a7091, 0x44ef, 0x44f5, { 0x81, 0xd8, 0xc3, 0x44, 0xd0, 0xdd, 0x24, 0xb5 } };

/**
Sets the precinct size coefficient.
\details <dl><dt><b>  Type: </b></dt><dd> 
VT_UINT </dd></dl>
<dl><dt><b>  Available Values: </b></dt><dd>
7 - 128x128 precincts, 64x64 for resolution 0. <br>
8 - 256x256 precincts, 128x128 for resolution 0. <br>
15 - maximal precincts.
</dd></dl> \hideinitializer */ // {13B5CECB-F6FA-43cc-9421-B48A90D13872}
static const GUID MCMJ2E_ESETTING_PRECSIZE = 
{ 0x13b5cecb, 0xf6fa, 0x43cc, { 0x94, 0x21, 0xb4, 0x8a, 0x90, 0xd1, 0x38, 0x72 } };

/**
Disables the YUY2 output.
\details <dl><dt><b>  Type: </b></dt><dd> 
VT_UINT </dd></dl>
<dl><dt><b>  Available Values: </b></dt><dd>
0, 1
</dd></dl> \hideinitializer */ // {D788D8ED-0135-4ad4-A4EB-A0A866569DFD}
static const GUID MCMJ2E_ESETTING_DISABLEYUY2 = 
{ 0xd788d8ed, 0x135, 0x4ad4, { 0xa4, 0xeb, 0xa0, 0xa8, 0x66, 0x56, 0x9d, 0xfd } };

/**
Disables the UYVY output.
\details <dl><dt><b>  Type: </b></dt><dd> 
VT_UINT </dd></dl>
<dl><dt><b>  Available Values: </b></dt><dd>
0, 1
</dd></dl> \hideinitializer */ // {4F0DEA4D-C5C1-4f96-BE72-173A6AE040B1}
static const GUID MCMJ2E_ESETTING_DISABLEUYVY = 
{ 0x4f0dea4d, 0xc5c1, 0x4f96, { 0xbe, 0x72, 0x17, 0x3a, 0x6a, 0xe0, 0x40, 0xb1 } };


/**
Sets the maximal bit-depth for encoding.
\details <dl><dt><b>  Type: </b></dt><dd> 
VT_UINT </dd></dl>
<dl><dt><b>  Available Values: </b></dt><dd>
4 - 16
</dd></dl> \hideinitializer */ // {0B3964CC-4188-4af4-B49E-9C833B9DDB09}
static const GUID MCMJ2E_ESETTING_MaxBitDepth = 
{ 0xb3964cc, 0x4188, 0x4af4, { 0xb4, 0x9e, 0x9c, 0x83, 0x3b, 0x9d, 0xdb, 0x9 } };

/**
Bitrate for layer 1.
\details <dl><dt><b>  Type: </b></dt><dd> 
VT_UINT </dd></dl>
</dd></dl> \hideinitializer */ // {C6BCF04E-4786-4367-A20B-D8585144489A}
static const GUID MCMJ2E_ESETTING_Layer1BitRate = 
{ 0xc6bcf04e, 0x4786, 0x4367, { 0xa2, 0xb, 0xd8, 0x58, 0x51, 0x44, 0x48, 0x9a } };

/**
Bitrate for layer 2.
\details <dl><dt><b>  Type: </b></dt><dd> 
VT_UINT </dd></dl>
</dd></dl> \hideinitializer */ // {502A7148-2F9F-44df-8AC6-5EDA31912CF7}
static const GUID MCMJ2E_ESETTING_Layer2BitRate = 
{ 0x502a7148, 0x2f9f, 0x44df, { 0x8a, 0xc6, 0x5e, 0xda, 0x31, 0x91, 0x2c, 0xf7 } };

/**
Bitrate for layer 3.
\details <dl><dt><b>  Type: </b></dt><dd> 
VT_UINT </dd></dl>
</dd></dl> \hideinitializer */ // {DD743E4F-8BBA-4d63-8D16-ABE82DE8B81B}
static const GUID MCMJ2E_ESETTING_Layer3BitRate = 
{ 0xdd743e4f, 0x8bba, 0x4d63, { 0x8d, 0x16, 0xab, 0xe8, 0x2d, 0xe8, 0xb8, 0x1b } };

/**
Bitrate for layer 4.
\details <dl><dt><b>  Type: </b></dt><dd> 
VT_UINT </dd></dl>
</dd></dl> \hideinitializer */ // {C65F63D7-0741-46cb-BB10-ABE45FCA6123}
static const GUID MCMJ2E_ESETTING_Layer4BitRate = 
{ 0xc65f63d7, 0x741, 0x46cb, { 0xbb, 0x10, 0xab, 0xe4, 0x5f, 0xca, 0x61, 0x23 } };

/**
Bitrate for layer 5.
\details <dl><dt><b>  Type: </b></dt><dd> 
VT_UINT </dd></dl>
</dd></dl> \hideinitializer */ // {2207D38F-DA8E-486c-9E3D-C6F15BA637E1}
static const GUID MCMJ2E_ESETTING_Layer5BitRate = 
{ 0x2207d38f, 0xda8e, 0x486c, { 0x9e, 0x3d, 0xc6, 0xf1, 0x5b, 0xa6, 0x37, 0xe1 } };

/**
Bitrate for layer 6.
\details <dl><dt><b>  Type: </b></dt><dd> 
VT_UINT </dd></dl>
</dd></dl> \hideinitializer */ // {297D59B7-2CC6-4115-AA71-5673570FE3E7}
static const GUID MCMJ2E_ESETTING_Layer6BitRate = 
{ 0x297d59b7, 0x2cc6, 0x4115, { 0xaa, 0x71, 0x56, 0x73, 0x57, 0xf, 0xe3, 0xe7 } };

/**
Sets the subsampling factor, if CPRL progression order is used. This parameter can be used to produce the stream that can be decoded in both original (1/1) and lower (1/2 | 1/4 | 1/8 ) resolution. By subsampling at decoder side, any stream can be decoded in lower resolution, but not at optimal speed. Using this feature, you get much faster downsampling at decoder side.
\details <dl><dt><b>  Type: </b></dt><dd> 
VT_UINT </dd></dl>
<dl><dt><b>  Available Values: </b></dt><dd>
0 - Encoded stream is not optimized for subsampling. <br>
1 - Encoded stream is optimized for 1/2 subsampling. <br>
2 - Encoded stream is optimized for 1/4 subsampling. <br>
3 - Encoded stream is optimized for 1/8 subsampling.
</dd></dl> \hideinitializer */ // {4C6D9D4B-BEC6-44b5-B525-D7734C3B0946}
static const GUID MCMJ2E_ESETTING_CPRLSubsamplFactor = 
{ 0x4c6d9d4b, 0xbec6, 0x44b5, { 0xb5, 0x25, 0xd7, 0x73, 0x4c, 0x3b, 0x9, 0x46 } };

// {2706A9F1-A504-45f6-A07E-E551B4BD0563}
static const GUID MCMJ2E_ESETTING_ACCELERATION = 
{ 0x2706a9f1, 0xa504, 0x45f6, { 0xa0, 0x7e, 0xe5, 0x51, 0xb4, 0xbd, 0x5, 0x63 } };

// {C21F3B78-442F-4731-B0F9-0A6B0A0DADAF}
static const GUID MCMJ2E_ESETTING_TARGET_BITRATE = 
{ 0xc21f3b78, 0x442f, 0x4731, { 0xb0, 0xf9, 0xa, 0x6b, 0xa, 0xd, 0xad, 0xaf } };

// {92407330-7B15-4a2b-92B8-A1ED6CA5B94F}
static const GUID MCMJ2E_ESETTING_2K4K_FLAG = 
{ 0x92407330, 0x7b15, 0x4a2b, { 0x92, 0xb8, 0xa1, 0xed, 0x6c, 0xa5, 0xb9, 0x4f } };

// {838B048E-AF6D-4ee0-AB49-0980BD3F299D}
static const GUID MCMJ2E_ESETTING_MAX_CPU_NUM = 
{ 0x838b048e, 0xaf6d, 0x4ee0, { 0xab, 0x49, 0x9, 0x80, 0xbd, 0x3f, 0x29, 0x9d } };


/**
Indicates whether the input pin is connected. Read-only.
\details <dl><dt><b>  Type: </b></dt><dd> 
VT_UINT </dd></dl>
</dd></dl> \hideinitializer */ // {41B7DFCD-920B-430a-B2CD-3538F0C5E297}
static const GUID MCMJ2E_DFSETTING_INPUTPIN_CONNECTED = 
{ 0x41b7dfcd, 0x920b, 0x430a, { 0xb2, 0xcd, 0x35, 0x38, 0xf0, 0xc5, 0xe2, 0x97 } };

/**
Indicates whether the output pin is connected. Read-only.
\details <dl><dt><b>  Type: </b></dt><dd> 
VT_UINT </dd></dl>
</dd></dl> \hideinitializer */ // {CA295980-2B83-40fe-9C1D-53496D4E3827}
static const GUID MCMJ2E_DFSETTING_OUTPUTPIN_CONNECTED = 
{ 0xca295980, 0x2b83, 0x40fe, { 0x9c, 0x1d, 0x53, 0x49, 0x6d, 0x4e, 0x38, 0x27 } };



#endif // __PROPID_MJ2E_HEADER__