/** 
 @file trans_video_colorspace_mc.h
 @brief  Property GUIDs for MainConcept Color Space Converter parameters.
 
 @verbatim
 File: trans_video_colorspace_mc.h

 Desc: Property GUIDs for MainConcept Color Space Converter parameters.
 
 Copyright (c) 2015 MainConcept GmbH or its affiliates.  All rights reserved.

 MainConcept and its logos are registered trademarks of MainConcept GmbH or its affiliates.  
 This software is protected by copyright law and international treaties.  Unauthorized 
 reproduction or distribution of any portion is prohibited by law.
 @endverbatim
 **/

#ifndef __PropID_CSC__H__02_06_2003_13_24_
#define __PropID_CSC__H__02_06_2003_13_24_


///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
// Property GUID for MainConcept Color Space Cpnverte DirectX filter,
// available throw IModuleConfig interface.
///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
//	GUID							Value Type	     Available range				Default Value			Note
//
//	ECSC_FIX_INPUT_MEDIA_TYPE			VT_UI4		 [0x00000000 - 0xFFFFFFFF]		 0x00000000			FOURCC code of output media type
//
//																										
//	ECSC_FIX_OUTPUT_MEDIA_TYPE			VT_UI4		 [0x00000000 - 0xFFFFFFFF]       0x00000000			FOURCC code of input media type
//																										
//
//	ECSC_FIX_INPUT_VIDEOINFO2_TYPE		VT_UI4			 0, 1					0			Set "1" if input media type is VideoInfo2 
//																										Set  "0" if input media type is VideoInfo 
//
//	ECSC_FIX_OUTPUT_VIDEOINFO2_TYPE		VT_UI4			 0, 1					0			Set "1" if output media type is VideoInfo2
//																										Set "0" if output media type is VideoInfo
//	
//  ECSC_USE_FIX_INPUT_MEDIA_TYPE      VT_UI4			 0, 1					0			Set "1" then filter must use fix input media type
//																										Set "0" if filter not must use fix input media type
//
//  ECSC_USE_FIX_OUTPUT_MEDIA_TYPE     VT_UI4			 0, 1					0			Set "1" then filter must use fix output media type
//																										Set "0" if filter not must use fix output media type
//  ECSC_PICTURE_TYPE					VT_UI4				[0 - 2]						  0				Set video format - interlaced, progressive or auto detecting
//
///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
//
//	FOURCC of media type get as follows:
//	
//			DWORD dwFourcc_yv12 = FOURCCMap(&MEDIASUBTYPE_YV12).GetFOURCC();
//
///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

/**
	  * @name Old API
	  * @{
**/

// {2B58E1BA-19DA-4baa-9A9F-F9677F18C6D0}
static const GUID ECSC_FIX_OUTPUT_MEDIA_TYPE = 
{ 0x2b58e1ba, 0x19da, 0x4baa, { 0x9a, 0x9f, 0xf9, 0x67, 0x7f, 0x18, 0xc6, 0xd0 } };

// {595D3585-21B1-4056-B0C7-2D7E4A9BD006}
static const GUID ECSC_FIX_INPUT_MEDIA_TYPE = 
{ 0x595d3585, 0x21b1, 0x4056, { 0xb0, 0xc7, 0x2d, 0x7e, 0x4a, 0x9b, 0xd0, 0x6 } };

// {9877AE81-D659-4bc9-8ADE-4BE1DB13C7AD}
static const GUID ECSC_FIX_OUTPUT_VIDEOINFO2_TYPE = 
{ 0x9877ae81, 0xd659, 0x4bc9, { 0x8a, 0xde, 0x4b, 0xe1, 0xdb, 0x13, 0xc7, 0xad } };

// {59448DA0-95B9-4777-A43A-D065D87AC415}
static const GUID ECSC_FIX_INPUT_VIDEOINFO2_TYPE = 
{ 0x59448da0, 0x95b9, 0x4777, { 0xa4, 0x3a, 0xd0, 0x65, 0xd8, 0x7a, 0xc4, 0x15 } };

// {01556216-C1DF-4a93-93D8-6BBC4C7627FD}
static const GUID ECSC_USE_FIX_INPUT_MEDIA_TYPE = 
{ 0x1556216, 0xc1df, 0x4a93, { 0x93, 0xd8, 0x6b, 0xbc, 0x4c, 0x76, 0x27, 0xfd } };

// {38E52AC6-50EA-4aaa-8E50-020A9AAE8A48}
static const GUID ECSC_USE_FIX_OUTPUT_MEDIA_TYPE = 
{ 0x38e52ac6, 0x50ea, 0x4aaa, { 0x8e, 0x50, 0x2, 0xa, 0x9a, 0xae, 0x8a, 0x48 } };

// {E9880528-0032-4c66-B442-7F8A6E7FE2C5}
static const GUID ECSC_PICTURE_TYPE = 
{ 0xe9880528, 0x32, 0x4c66, { 0xb4, 0x42, 0x7f, 0x8a, 0x6e, 0x7f, 0xe2, 0xc5 } };

/** @} */

// {CF00AC84-56F5-4bf1-A4FB-3A16D53F8CE3}
/// Specifies the color space formats of the source frame.
static const GUID CSC_Format_Source = 
{ 0xcf00ac84, 0x56f5, 0x4bf1, { 0xa4, 0xfb, 0x3a, 0x16, 0xd5, 0x3f, 0x8c, 0xe3 } };

static const GUID CSC_PixelFormat_Source = CSC_Format_Source;

// {C69A0DB4-D9F5-4e31-93AE-46F63829BA55}
/// Specifies the color space formats of the destination frame.
static const GUID CSC_Format_Dest = 
{ 0xc69a0db4, 0xd9f5, 0x4e31, { 0x93, 0xae, 0x46, 0xf6, 0x38, 0x29, 0xba, 0x55 } };

static const GUID CSC_PixelFormat_Dest = CSC_Format_Dest;

// {A24929F0-3130-4d75-A474-1731C08F30BE}
/// Specifies the formats of video info header of input mediatype.
static const GUID CSC_FormatVideoInfo_Source = 
{ 0xa24929f0, 0x3130, 0x4d75, { 0xa4, 0x74, 0x17, 0x31, 0xc0, 0x8f, 0x30, 0xbe } };

// {F0DA179F-8C30-4ba0-A539-9FF5F7C9756E}
/// Specifies the formats of video info header of output mediatype.
static const GUID CSC_FormatVideoInfo_Dest = 
{ 0xf0da179f, 0x8c30, 0x4ba0, { 0xa5, 0x39, 0x9f, 0xf5, 0xf7, 0xc9, 0x75, 0x6e } };

// {389B80E3-8764-45a8-A2E0-23C251409F29}
/// Describes the chrominance coordinates of the source primaries.
static const GUID CSC_ColorPrimaries_Source = 
{ 0x389b80e3, 0x8764, 0x45a8, { 0xa2, 0xe0, 0x23, 0xc2, 0x51, 0x40, 0x9f, 0x29 } };

// {2032FA8C-540A-4ee5-8C1F-5D0B4DD76924}
/// Describes the chrominance coordinates of the destination primaries.
static const GUID CSC_ColorPrimaries_Dest = 
{ 0x2032fa8c, 0x540a, 0x4ee5, { 0x8c, 0x1f, 0x5d, 0xb, 0x4d, 0xd7, 0x69, 0x24 } };

// {0BCF1B5B-A0E2-472e-ADD0-62C53400F93D}
/// Describes the gamma correction function for source frame.
static const GUID CSC_TransferCharacteristics_Source = 
{ 0xbcf1b5b, 0xa0e2, 0x472e, { 0xad, 0xd0, 0x62, 0xc5, 0x34, 0x0, 0xf9, 0x3d } };

// {79024AEE-B43A-4cbf-B17F-5E2BF1B1CE2C}
/// Describes the gamma correction function for destination frame.
static const GUID CSC_TransferCharacteristics_Dest = 
{ 0x79024aee, 0xb43a, 0x4cbf, { 0xb1, 0x7f, 0x5e, 0x2b, 0xf1, 0xb1, 0xce, 0x2c } };

// {B4288827-D8EA-4b12-941D-59F4EB7FCCF4}
/** @brief Describes the matrix coefficients used in deriving luma signal from RGB 
  * signal in the source frame. */
static const GUID CSC_MatrixCoefficients_Source = 
{ 0xb4288827, 0xd8ea, 0x4b12, { 0x94, 0x1d, 0x59, 0xf4, 0xeb, 0x7f, 0xcc, 0xf4 } };

// {5F320D5C-8BE3-4213-AF30-082FB7EFFAEA}
/** @brief Describes the matrix coefficients used in deriving luma signal from RGB 
  * signal in the destination frame. */
static const GUID CSC_MatrixCoefficients_Dest = 
{ 0x5f320d5c, 0x8be3, 0x4213, { 0xaf, 0x30, 0x8, 0x2f, 0xb7, 0xef, 0xfa, 0xea } };

// {E5C9E525-792A-4585-B35D-6F0FE69C1EFF}
/// Describes the frame type of the video sequence.
static const GUID CSC_FrameType = 
{ 0xe5c9e525, 0x792a, 0x4585, { 0xb3, 0x5d, 0x6f, 0xf, 0xe6, 0x9c, 0x1e, 0xff } };

// {F88A3587-CEAC-48bd-BECF-D58BE1C225F0}
/// Describes the range of input signal.
static const GUID CSC_SignalRange_Source = 
{ 0xf88a3587, 0xceac, 0x48bd, { 0xbe, 0xcf, 0xd5, 0x8b, 0xe1, 0xc2, 0x25, 0xf0 } };

// {58D7BB10-BB66-43c3-9430-01ACAF92005A}
/// Describes the range of output signal.
static const GUID CSC_SignalRange_Dest = 
{ 0x58d7bb10, 0xbb66, 0x43c3, { 0x94, 0x30, 0x1, 0xac, 0xaf, 0x92, 0x0, 0x5a } };

// {61374C4D-0ADD-45d3-8B05-BD2FA49719B8}
/// Enables/disables cacheable memory for source frame.
static const GUID CSC_CacheableMemory_Source = 
{ 0x61374c4d, 0xadd, 0x45d3, { 0x8b, 0x5, 0xbd, 0x2f, 0xa4, 0x97, 0x19, 0xb8 } };

// {D0612942-34B4-461f-948A-234B8FA52953}
/// Enables/disables cacheable memory for destination frame.
static const GUID CSC_CacheableMemory_Dest = 
{ 0xd0612942, 0x34b4, 0x461f, { 0x94, 0x8a, 0x23, 0x4b, 0x8f, 0xa5, 0x29, 0x53 } };

// {14770158-A3F1-4270-BD33-26DB930E937E}
/// Specifies whether field reordering is turned on or turned off
static const GUID CSC_FieldReordering = 
{ 0x14770158, 0xa3f1, 0x4270, { 0xbd, 0x33, 0x26, 0xdb, 0x93, 0xe, 0x93, 0x7e } };

// {44232629-BE19-4C28-AD90-8AE8AFD7CEBF}
/// Specifies the type of deinterlacing
static const GUID CSC_Deinterlacing = 
{ 0x44232629, 0xbe19, 0x4c28, { 0xad, 0x90, 0x8a, 0xe8, 0xaf, 0xd7, 0xce, 0xbf } };

// {CF4BB014-5CE6-42F9-A859-2F8DECF7295E}
/// Specifies the brightness change coefficient
static const GUID CSC_Brightness = 
{ 0xcf4bb014, 0x5ce6, 0x42f9, { 0xa8, 0x59, 0x2f, 0x8d, 0xec, 0xf7, 0x29, 0x5e } };

// {9BF72C1B-CBEE-4415-A5F5-A11F99B5C87A}
/// Specifies the sharpness change coefficient
static const GUID CSC_Sharpness = 
{ 0x9bf72c1b, 0xcbee, 0x4415, { 0xa5, 0xf5, 0xa1, 0x1f, 0x99, 0xb5, 0xc8, 0x7a } };

// {EC8FF5D2-9BFD-4A1F-9D85-0063D0144B4D}
/// Specifies the width of the destination frame
static const GUID CSC_Width_Dest = 
{ 0xec8ff5d2, 0x9bfd, 0x4a1f, { 0x9d, 0x85, 0x0, 0x63, 0xd0, 0x14, 0x4b, 0x4d } };

// {E9198CE5-D333-4B53-B84B-040B93E5D309}
/// Specifies the height of the destination frame
static const GUID CSC_Height_Dest = 
{ 0xe9198ce5, 0xd333, 0x4b53, { 0xb8, 0x4b, 0x4, 0xb, 0x93, 0xe5, 0xd3, 0x9 } };

// {78091DB0-76E6-4A24-9D71-5D832B254FF8}
/// Specifies the picture aspect ratio
static const GUID CSC_Aspect_Ratio = 
{ 0x78091db0, 0x76e6, 0x4a24, { 0x9d, 0x71, 0x5d, 0x83, 0x2b, 0x25, 0x4f, 0xf8 } };

// {3F2D48C1-F023-4C95-84A7-0961A403E090}
/// Specifies the custom picture aspect ratio for width
static const GUID CSC_Custom_Aspect_Ratio_X = 
{ 0x3f2d48c1, 0xf023, 0x4c95, { 0x84, 0xa7, 0x9, 0x61, 0xa4, 0x3, 0xe0, 0x90 } };

// {676A45B2-89CF-4A3B-95F8-614635A3A283}
/// Specifies the custom picture aspect ratio for height
static const GUID CSC_Custom_Aspect_Ratio_Y = 
{ 0x676a45b2, 0x89cf, 0x4a3b, { 0x95, 0xf8, 0x61, 0x46, 0x35, 0xa3, 0xa2, 0x83 } };

// {02ACB65F-0ED1-4A66-BB31-FC21B2BFD27B}
/// Enables/disables keeping input picture proportions
static const GUID CSC_Keep_Picture_Proportions = 
{ 0x2acb65f, 0xed1, 0x4a66, { 0xbb, 0x31, 0xfc, 0x21, 0xb2, 0xbf, 0xd2, 0x7b } };



/**
* namespace MC_ColorSpaceConverter
* @brief Color Space Converter namespace
**/
namespace MC_ColorSpaceConverter {
	enum {
		UCCDS_PIXEL_FORMAT_Any = 0,
			UCCDS_FORMAT_Any = 0,
		UCCDS_PIXEL_FORMAT_AYUV = 1,
			UCCDS_FORMAT_AYUV = 1,
		UCCDS_PIXEL_FORMAT_YUY2 = 2,
			UCCDS_FORMAT_YUY2 = 2,
		UCCDS_PIXEL_FORMAT_YVYU = 3,
			UCCDS_FORMAT_YVYU = 3,
		UCCDS_PIXEL_FORMAT_UYVY = 4,
			UCCDS_FORMAT_UYVY = 4,
		UCCDS_PIXEL_FORMAT_Y211 = 5,
			UCCDS_FORMAT_Y211 = 5,
		UCCDS_PIXEL_FORMAT_Y41P = 6,
			UCCDS_FORMAT_Y41P = 6,
		UCCDS_PIXEL_FORMAT_CLJR = 7,
			UCCDS_FORMAT_CLJR = 7,
		UCCDS_PIXEL_FORMAT_YV12 = 8,
			UCCDS_FORMAT_YV12 = 8,
		UCCDS_PIXEL_FORMAT_YVU9 = 9,
			UCCDS_FORMAT_YVU9 = 9,
		UCCDS_PIXEL_FORMAT_NV24 = 10,
			UCCDS_FORMAT_NV24 = 10,
		UCCDS_PIXEL_FORMAT_NV12 = 11,
			UCCDS_FORMAT_NV12 = 11,
		UCCDS_PIXEL_FORMAT_IMC1 = 12,
			UCCDS_FORMAT_IMC1 = 12,
		UCCDS_PIXEL_FORMAT_IMC2 = 13,
			UCCDS_FORMAT_IMC2 = 13,
		UCCDS_PIXEL_FORMAT_IMC3 = 14,
			UCCDS_FORMAT_IMC3 = 14,
		UCCDS_PIXEL_FORMAT_IMC4 = 15,
			UCCDS_FORMAT_IMC4 = 15,
		UCCDS_PIXEL_FORMAT_v210 = 16,
			UCCDS_FORMAT_v210 = 16,
		UCCDS_PIXEL_FORMAT_Y210 = 17,
			UCCDS_FORMAT_Y210 = 17,
		UCCDS_PIXEL_FORMAT_Y216 = 18,
			UCCDS_FORMAT_Y216 = 18,
		UCCDS_PIXEL_FORMAT_Y410 = 19,
			UCCDS_FORMAT_Y410 = 19,
		UCCDS_PIXEL_FORMAT_Y416 = 20,
			UCCDS_FORMAT_Y416 = 20,
		UCCDS_PIXEL_FORMAT_P010 = 21,
			UCCDS_FORMAT_P010 = 21,
		UCCDS_PIXEL_FORMAT_P016 = 22,
			UCCDS_FORMAT_P016 = 22,
		UCCDS_PIXEL_FORMAT_P210 = 23,
			UCCDS_FORMAT_P210 = 23,
		UCCDS_PIXEL_FORMAT_P216 = 24,
			UCCDS_FORMAT_P216 = 24,
		UCCDS_PIXEL_FORMAT_ARGB32 = 25,
			UCCDS_FORMAT_ARGB32 = 25,
		UCCDS_PIXEL_FORMAT_RGB32 = 26,
			UCCDS_FORMAT_RGB32 = 26,
		UCCDS_PIXEL_FORMAT_RGB24 = 27,
			UCCDS_FORMAT_RGB24 = 27,
		UCCDS_PIXEL_FORMAT_RGB565 = 28,
			UCCDS_FORMAT_RGB565 = 28,
		UCCDS_PIXEL_FORMAT_RGB555 = 29,
			UCCDS_FORMAT_RGB555 = 29,
		UCCDS_PIXEL_FORMAT_VUYA = 30,
		UCCDS_PIXEL_FORMAT_VYUY = 31,
		UCCDS_PIXEL_FORMAT_IYUV = 32,
		UCCDS_PIXEL_FORMAT_YV16 = 33,
		UCCDS_PIXEL_FORMAT_YV24 = 34,
		UCCDS_PIXEL_FORMAT_NV21 = 35,
		UCCDS_PIXEL_FORMAT_YUV9 = 36,
		UCCDS_PIXEL_FORMAT_YUYV = 37,
		UCCDS_PIXEL_FORMAT_A2R10G10B10 = 38,
		UCCDS_PIXEL_FORMAT_A2B10G10R10 = 39,
        UCCDS_PIXEL_FORMAT_W009 = 40,
        UCCDS_PIXEL_FORMAT_W010 = 41,
        UCCDS_PIXEL_FORMAT_W011 = 42,
        UCCDS_PIXEL_FORMAT_W012 = 43,
        UCCDS_PIXEL_FORMAT_W014 = 44,
        UCCDS_PIXEL_FORMAT_W016 = 45,
        UCCDS_PIXEL_FORMAT_W209 = 46,
        UCCDS_PIXEL_FORMAT_W210 = 47,
        UCCDS_PIXEL_FORMAT_W211 = 48,
        UCCDS_PIXEL_FORMAT_W212 = 49,
        UCCDS_PIXEL_FORMAT_W214 = 50,
        UCCDS_PIXEL_FORMAT_W216 = 51,
        UCCDS_PIXEL_FORMAT_W409 = 52,
        UCCDS_PIXEL_FORMAT_W410 = 53,
        UCCDS_PIXEL_FORMAT_W411 = 54,
        UCCDS_PIXEL_FORMAT_W412 = 55,
        UCCDS_PIXEL_FORMAT_W414 = 56,
        UCCDS_PIXEL_FORMAT_W416 = 57,
        UCCDS_PIXEL_FORMAT_X8Y8Z8_24 = 58,
        UCCDS_PIXEL_FORMAT_X12Y12Z12_48 = 59,
        UCCDS_PIXEL_FORMAT_PL_X8Y8Z8_24 = 60,
        UCCDS_PIXEL_FORMAT_PL_X12Y12Z12_48 = 61,
        UCCDS_PIXEL_FORMAT_X009 = 62,
        UCCDS_PIXEL_FORMAT_X010 = 63,
        UCCDS_PIXEL_FORMAT_X011 = 64,
        UCCDS_PIXEL_FORMAT_X012 = 65,
        UCCDS_PIXEL_FORMAT_X014 = 66,
        UCCDS_PIXEL_FORMAT_X016 = 67,
        UCCDS_PIXEL_FORMAT_X209 = 68,
        UCCDS_PIXEL_FORMAT_X210 = 69,
        UCCDS_PIXEL_FORMAT_X211 = 70,
        UCCDS_PIXEL_FORMAT_X212 = 71,
        UCCDS_PIXEL_FORMAT_X214 = 72,
        UCCDS_PIXEL_FORMAT_X216 = 73,
        UCCDS_PIXEL_FORMAT_X409 = 74,
        UCCDS_PIXEL_FORMAT_X410 = 75,
        UCCDS_PIXEL_FORMAT_X411 = 76,
        UCCDS_PIXEL_FORMAT_X412 = 77,
        UCCDS_PIXEL_FORMAT_X414 = 78,
        UCCDS_PIXEL_FORMAT_X416 = 79,
        UCCDS_PIXEL_FORMAT_B10G10R10X2_32 = 80,
        UCCDS_PIXEL_FORMAT_PL_R8G8B8_24 = 81,
        UCCDS_PIXEL_FORMAT_PL_R16G16B16_48 = 82,
        UCCDS_PIXEL_FORMAT_B16G16R16A16_64 = 83,
        UCCDS_PIXEL_FORMAT_PL_R12G12B12_48 = 84,
        UCCDS_PIXEL_FORMAT_PL_R14G14B14_48 = 85,
        UCCDS_PIXEL_FORMAT_PL_R10G10B10_48 = 86,
        UCCDS_PIXEL_FORMAT_v216 = 87,
        UCCDS_PIXEL_FORMAT_VUYAFP = 88,
        UCCDS_PIXEL_FORMAT_UyVy = 89,
        UCCDS_PIXEL_FORMAT_YuYv = 90,
        UCCDS_PIXEL_FORMAT_I444 = 91,
        UCCDS_PIXEL_FORMAT_I422 = 92,
        UCCDS_PIXEL_FORMAT_GRAY = 93,
        UCCDS_PIXEL_FORMAT_Y16 = 94,
        UCCDS_PIXEL_FORMAT_Y10 = 95,
        UCCDS_PIXEL_FORMAT_410P = 96,
        UCCDS_PIXEL_FORMAT_411P = 97,
        UCCDS_PIXEL_FORMAT_211P = 98,
        UCCDS_PIXEL_FORMAT_BGRAFP = 99,
        UCCDS_PIXEL_FORMAT_RGBA = 100,
        UCCDS_PIXEL_FORMAT_argb = 101,
        UCCDS_PIXEL_FORMAT_R555 = 102,              // not used
        UCCDS_PIXEL_FORMAT_R565 = 103,              // not used
        UCCDS_PIXEL_FORMAT_RGB3 = 104,
        UCCDS_PIXEL_FORMAT_R32C = 105,
        UCCDS_PIXEL_FORMAT_R24C = 106,
        UCCDS_PIXEL_FORMAT_PL_X09Y09Z09_48 = 107,
        UCCDS_PIXEL_FORMAT_PL_X10Y10Z10_48 = 108,
        UCCDS_PIXEL_FORMAT_PL_X11Y11Z11_48 = 109,
        UCCDS_PIXEL_FORMAT_PL_X14Y14Z14_48 = 110,
        UCCDS_PIXEL_FORMAT_PL_X16Y16Z16_48 = 111,
        UCCDS_PIXEL_FORMAT_PL_R09G09B09_48 = 112,
        UCCDS_PIXEL_FORMAT_PL_R11G11B11_48 = 113,
        UCCDS_PIXEL_FORMAT_Y411 = 114,
        UCCDS_PIXEL_FORMAT_W013 = 115,
        UCCDS_PIXEL_FORMAT_W015 = 116,
        UCCDS_PIXEL_FORMAT_X013 = 117,
        UCCDS_PIXEL_FORMAT_X015 = 118,
        UCCDS_PIXEL_FORMAT_I420 = 119,
        UCCDS_PIXEL_FORMAT_W213 = 120,
        UCCDS_PIXEL_FORMAT_W215 = 121,
        UCCDS_PIXEL_FORMAT_X213 = 122,
        UCCDS_PIXEL_FORMAT_X215 = 123,
        UCCDS_PIXEL_FORMAT_W413 = 124,
        UCCDS_PIXEL_FORMAT_W415 = 125,
        UCCDS_PIXEL_FORMAT_X413 = 126,
        UCCDS_PIXEL_FORMAT_X415 = 127,
        UCCDS_PIXEL_FORMAT_PL_X13Y13Z13_48 = 128,
        UCCDS_PIXEL_FORMAT_PL_X15Y15Z15_48 = 129,
        UCCDS_PIXEL_FORMAT_PL_R13G13B13_48 = 130,
        UCCDS_PIXEL_FORMAT_PL_R15G15B15_48 = 131,
        UCCDS_PIXEL_FORMAT_Y09 = 132,
        UCCDS_PIXEL_FORMAT_Y11 = 133,
        UCCDS_PIXEL_FORMAT_Y12 = 134,
        UCCDS_PIXEL_FORMAT_Y13 = 135,
        UCCDS_PIXEL_FORMAT_Y14 = 136,
        UCCDS_PIXEL_FORMAT_Y15 = 137,

		UCCDS_PIXEL_FORMAT_COUNT,
		UCCDS_FORMAT_COUNT = UCCDS_PIXEL_FORMAT_COUNT
	};

	enum {
		UCCDS_FORMATTYPE_Any = 0,
		UCCDS_FORMATTYPE_VideoInfo = 1,
		UCCDS_FORMATTYPE_VideoInfo2 = 2
	};

	enum {
		UCCDS_MATRIX_COEFFICIENTS_BT709_5_System_1125 = 0,
		UCCDS_MATRIX_COEFFICIENTS_BT709_5_System_1250 = 1,
		UCCDS_MATRIX_COEFFICIENTS_SMPTE_240M = 2,
        UCCDS_MATRIX_COEFFICIENTS_BT2020 = 3,
        UCCDS_MATRIX_COEFFICIENTS_BT2020_NON_CONST = UCCDS_MATRIX_COEFFICIENTS_BT2020,
        UCCDS_MATRIX_COEFFICIENTS_BT2020_CONST = 4,
        UCCDS_MATRIX_COEFFICIENTS_FCC
	};

	enum {
		UCCDS_COLOR_PRIMARIES_BT709_5 = 0,
		UCCDS_COLOR_PRIMARIES_BT470_6_System_M = 1,
		UCCDS_COLOR_PRIMARIES_BT470_6_System_B_G = 2,
		UCCDS_COLOR_PRIMARIES_SMPTE_170M = 3,
        UCCDS_COLOR_PRIMARIES_BT2020 = 4,
        UCCDS_COLOR_PRIMARIES_SMPTE_RP_431_2 = 5,
        UCCDS_COLOR_PRIMARIES_SMPTE_EG_432_1 = 6,
        UCCDS_COLOR_PRIMARIES_EBU_Tech_3213_E = 7
	};

	enum {
		UCCDS_TRANSFER_CHARACTERISTICS_BT709_5 = 0,
		UCCDS_TRANSFER_CHARACTERISTICS_BT470_6_System_M = 1,
		UCCDS_TRANSFER_CHARACTERISTICS_BT470_6_System_B_G = 2,
		UCCDS_TRANSFER_CHARACTERISTICS_SMPTE_240M = 3,
		UCCDS_TRANSFER_CHARACTERISTICS_Linear = 4,
        UCCDS_TRANSFER_CHARACTERISTICS_BT2020 = 5,
        UCCDS_TRANSFER_CHARACTERISTICS_BT2020_10BIT = UCCDS_TRANSFER_CHARACTERISTICS_BT2020,
        UCCDS_TRANSFER_CHARACTERISTICS_BT2020_12BIT = 6,
        UCCDS_TRANSFER_CHARACTERISTICS_SMPTE_ST_2084 = 7,
        UCCDS_TRANSFER_CHARACTERISTICS_SMPTE_ST_428_1 = 8,
        UCCDS_TRANSFER_CHARACTERISTICS_BT2100_HLG = 9
	};

	enum {
		UCCDS_SIGNALRANGE_PC = 0,
		UCCDS_SIGNALRANGE_Studio = 1
	};

	enum {
		UCCDS_FRAMETYPE_Auto = 0,
		UCCDS_FRAMETYPE_Progressive = 1,
		UCCDS_FRAMETYPE_Interlaced = 2
	};

	enum {
		UCCDS_FIELD_REORDERING_Off = 0,
		UCCDS_FIELD_REORDERING_On = 1
	};

	enum {
		UCCDS_DEINTERLACING_None = 0,
		UCCDS_DEINTERLACING_Interfield_Interpolation = 1,
		UCCDS_DEINTERLACING_Intrafield_Interpolation_Top = 2,
		UCCDS_DEINTERLACING_Intrafield_Interpolation_Bottom = 3
	};

    enum {
        UCCDS_ASPECT_RATIO_Keep_input_ratio = 0,
        UCCDS_ASPECT_RATIO_4_3 = 1,
        UCCDS_ASPECT_RATIO_16_9 = 2,
        UCCDS_ASPECT_RATIO_Custom = 3
    };
};

#endif//#ifndef __PropID_CSC__H__02_06_2003_13_24_