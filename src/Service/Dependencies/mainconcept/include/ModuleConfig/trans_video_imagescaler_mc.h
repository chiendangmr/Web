 /** 
 @file  trans_video_imagescaler_mc.h
 @brief  Property GUIDs for MainConcept ImageScaler parameters.
 
 @verbatim
 File: trans_video_imagescaler_mc.h

 Desc: Property GUIDs for MainConcept ImageScaler parameters.
 
 Copyright (c) 2015 MainConcept GmbH or its affiliates.  All rights reserved.

 MainConcept and its logos are registered trademarks of MainConcept GmbH or its affiliates.  
 This software is protected by copyright law and international treaties.  Unauthorized 
 reproduction or distribution of any portion is prohibited by law.
 @endverbatim
 **/

#if !defined(__PropID_ImageScaler_h__)
#define __PropID_ImageScaler_h__

//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
//	GUID						Value Type	Available range		Default Val		Note
//	ImScaler_CropImage			VT_UINT		1,0			        0			    1 - crop is needed    
//	ImScaler_ResizeImage		VT_UINT		1,0			        0			    1 - resize is needed    
//	ImScaler_ResizeType			VT_UI1		[0 - 3]				Mitchel			0 - BSpline simple, 1 - Notch, 2 - CatmullRom spline, 3 - Mitchell-Netravali
//	ImScaler_AppendixMode		VT_UINT		2,1,0			    0			    1 - addition stripes are needed   0 - do not add 2 - Add black stripes to keep picture proportions
//	ImScaler_CropImageXLeft		VT_I4							0				Left top X coordinate of crop rectangle (in pixels)
//	ImScaler_CropImageYTop		VT_I4							0				Left top Y coordinate of crop rectangle (in pixels)
//	ImScaler_CropImageXRight	VT_I4							0				Right bottom X coordinate of crop rectangle (in pixels)
//	ImScaler_CropImageYBot		VT_I4							0				Right bottom Y coordinate of crop rectangle (in pixels)
//	ImScaler_DestHeight			VT_I4					        0				Destinatiom height of video (if resize is needed) 			
//	ImScaler_DestWidth			VT_I4					        0				Destinatiom width of video (if resize is needed) 			
//	ImScaler_StripeSizeValueTop	VT_I4						0				Size of top additional stripe (in pixels)
//	ImScaler_StripeSizeValueBottom	VT_I4						0				Size of bottom additional stripe (in pixels)
//	ImScaler_StripeSizeValueLeft	VT_I4						0				Size of left additional stripe (in pixels)
//	ImScaler_StripeSizeValueRight	VT_I4						0				Size of right additional stripe (in pixels)
//	ImScaler_PictureType		VT_UINT		[0 - 2]				AutoDetecting	Type of input Video Interlaced / Progressive or auto detecting(see "PictureType" enum)
//	ImScaler_LowLevel   		VT_UINT		1,0				    0           	Type of scaling method
//	ImScaler_SourceWidth		VT_I4											Width of input frame 
//	ImScaler_SourceHeight		VT_I4											Height of input frame
//	ImScaler_Align				VT_UINT											Align value (read only)
//	ImScaler_MaxResizeWidth		VT_UINT											Maximum resize size by width value (read only)
//	ImScaler_MaxResizeHeight	VT_UINT											Maximum resize size by height value (read only)
//	ImScaler_MinResizeWidth		VT_UINT											Minimum resize size by width value (read only)
//	ImScaler_MinResizeHeight	VT_UINT											Minimum resize size by height value (read only)
//	ImScaler_FilterState        VT_UINT											Filter state (read only)
//	ImScaler_SetAspectRatio		VT_BOOL		TRUE,FALSE			FALSE			TRUE - set current picture aspect ratio 
//	ImScaler_BindCrop			VT_BOOL		TRUE,FALSE			FALSE			TRUE - bind crop values to source picture size
//	ImScaler_CropDefinitionMode	VT_UINT		0,1,2				0				Crop parameters definition mode
//  ImScaler_UseAspectRatio		VT_BOOL		TRUE,FALSE			FALSE			TRUE - Use aspect ratio for resizing with "Keep picture proportions" mode
//  ImScaler_ImScaler_SetAspect4_3		VT_BOOL		TRUE,FALSE			FALSE			TRUE - Use aspect ratio 3:4
//  ImScaler_ImScaler_SetAspect16_9		VT_BOOL		TRUE,FALSE			FALSE			TRUE - Use aspect ratio 16:9
//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

namespace ImageScaler
{
    enum PictureType
	{
	Interlaced    = 0,				 // type of input video is interlaced
	Progressive   = Interlaced  + 1, // type of input video is progressive
	AutoDetecting = Progressive + 1  // auto detecting input video type
	};
	
	
	enum ResizeType
	{
		eSpline			= 0,			
		eNotch			= eSpline +1,	
		eCatmullRom		= eNotch + 1,
		eMitchel		= eCatmullRom + 1
	};
    
}
//
// {EDD0D20C-D35E-4da8-B9F9-E6F07E0FE861}
//
///@brief Crop Image
static const GUID ImScaler_CropImage = 
{ 0xedd0d20c, 0xd35e, 0x4da8, { 0xb9, 0xf9, 0xe6, 0xf0, 0x7e, 0xf, 0xe8, 0x61 } };

//
// {A68F13F1-CC33-436a-BCBF-0A5C95EBE27F}
//
///@brief Resize Image
static const GUID ImScaler_ResizeImage = 
{ 0xa68f13f1, 0xcc33, 0x436a, { 0xbc, 0xbf, 0xa, 0x5c, 0x95, 0xeb, 0xe2, 0x7f } };


//
// {B102C6E1-DCF7-441b-8890-B884B0949902}
//
// Resize Type
//
// Available range: [0-3]
//
// Type: VT_UI1 (BYTE)
//
// DEPRECATED
static const GUID ImScaler_ResizeType = 
{ 0xb102c6e1, 0xdcf7, 0x441b, { 0x88, 0x90, 0xb8, 0x84, 0xb0, 0x94, 0x99, 0x2 } };


//
// {E0CAC972-450E-44ae-9825-BC6E2448CD67}
//
///@brief Appendix Mode
static const GUID  ImScaler_AppendixMode = 
{ 0xe0cac972, 0x450e, 0x44ae, { 0x98, 0x25, 0xbc, 0x6e, 0x24, 0x48, 0xcd, 0x67 } };


//
// {57F15B02-E645-4d90-8834-31AEEF960A07}
//
///@brief Crop Image From Left
static const GUID ImScaler_CropImageXLeft = 
{ 0x57f15b02, 0xe645, 0x4d90, { 0x88, 0x34, 0x31, 0xae, 0xef, 0x96, 0xa, 0x7 } };


// {C2F3CF68-417F-413b-926C-A09D67AAB84D}
//
///@brief Crop Image From Top
static const GUID ImScaler_CropImageYTop = 
{ 0xc2f3cf68, 0x417f, 0x413b, { 0x92, 0x6c, 0xa0, 0x9d, 0x67, 0xaa, 0xb8, 0x4d } };



// {C038AA00-17DC-4c5b-A3FE-F31B0F68A75A}
//
///@brief Crop Image From Right
static const GUID ImScaler_CropImageXRight = 
{ 0xc038aa00, 0x17dc, 0x4c5b, { 0xa3, 0xfe, 0xf3, 0x1b, 0xf, 0x68, 0xa7, 0x5a } };



//
// {9DC1C8D4-0870-40bc-B78B-F00190E03112}
//
///@brief Crop Image From Bottom
static const GUID ImScaler_CropImageYBot = 
{ 0x9dc1c8d4, 0x870, 0x40bc, { 0xb7, 0x8b, 0xf0, 0x1, 0x90, 0xe0, 0x31, 0x12 } };


//
// {32A5E96D-2AC3-4d46-BF70-431BEE62DF35}
///@brief Resize Height
static const GUID ImScaler_DestHeight = 
{ 0x32a5e96d, 0x2ac3, 0x4d46, { 0xbf, 0x70, 0x43, 0x1b, 0xee, 0x62, 0xdf, 0x35 } };




//
// {04B86B7E-C04B-448f-BFF5-2A50F1945ACD}
///@brief Resize Width
static const GUID ImScaler_DestWidth = 
{ 0x4b86b7e, 0xc04b, 0x448f, { 0xbf, 0xf5, 0x2a, 0x50, 0xf1, 0x94, 0x5a, 0xcd } };

//
// {BFC35D7A-B763-439a-89CE-4E20F6192B99}

///@brief Size Top Appendix Stripe
static const GUID ImScaler_StripeSizeValueTop = 
{ 0xbfc35d7a, 0xb763, 0x439a, { 0x89, 0xce, 0x4e, 0x20, 0xf6, 0x19, 0x2b, 0x99 } };

// {E9F189CB-5ACB-4916-94CA-498D2A92E9E6}
///@brief Size Bottom Appendix Stripe
static const GUID ImScaler_StripeSizeValueBottom = 
{ 0xe9f189cb, 0x5acb, 0x4916, { 0x94, 0xca, 0x49, 0x8d, 0x2a, 0x92, 0xe9, 0xe6 } };

// {61D30459-0F67-456c-B481-D97869D21DED}
///@brief Size Left Appendix Stripe
static const GUID ImScaler_StripeSizeValueLeft =
{ 0x61d30459, 0xf67, 0x456c, { 0xb4, 0x81, 0xd9, 0x78, 0x69, 0xd2, 0x1d, 0xed } };

// {AF300681-EEEB-453c-B9DC-5B30A306B11A}
///@brief Size Right Appendix Stripe
static const GUID ImScaler_StripeSizeValueRight = 
{ 0xaf300681, 0xeeeb, 0x453c, { 0xb9, 0xdc, 0x5b, 0x30, 0xa3, 0x6, 0xb1, 0x1a } };


//
// {2E1DD59C-78B4-4f17-A0BA-41DEC7756EE1}
// Pictyre type
//
// Type: VT_UINT
//
// Available range: AutoDetecing(0), Interlaced(1), Progressive(2)
// 

static const GUID ImScaler_PictureType = 
{ 0x2e1dd59c, 0x78b4, 0x4f17, { 0xa0, 0xba, 0x41, 0xde, 0xc7, 0x75, 0x6e, 0xe1 } };


//
// {D680D3A9-05B4-4492-87AB-0A0561759DB3}
// LowLevel
//
// Type: VT_UINT
//
// Available range: Predefined filters(0), Bicubic interpolation(1)
// 
// DEPRECATED
static const GUID ImScaler_LowLevel = 
{ 0xd680d3a9, 0x5b4, 0x4492, { 0x87, 0xab, 0xa, 0x5, 0x61, 0x75, 0x9d, 0xb3 } };



//
// {0F414B44-5B63-43cd-8813-4B34A9A84C67}
///@brief Filter State
static const GUID ImScaler_FilterState = 
{ 0xf414b44, 0x5b63, 0x43cd, { 0x88, 0x13, 0x4b, 0x34, 0xa9, 0xa8, 0x4c, 0x67 } };

// {E35D983E-2004-45e2-A5FB-59AE94FCC258}
//
///@brief Source Frame Width
static const GUID ImScaler_SourceWidth = 
{ 0xe35d983e, 0x2004, 0x45e2, { 0xa5, 0xfb, 0x59, 0xae, 0x94, 0xfc, 0xc2, 0x58 } };

//
// {ECCA3864-E79E-4e77-A46E-D823CA882309}
///@brief Source Frame Height
static const GUID ImScaler_SourceHeight = 
{ 0xecca3864, 0xe79e, 0x4e77, { 0xa4, 0x6e, 0xd8, 0x23, 0xca, 0x88, 0x23, 0x9 } };


// {8803E341-A76D-4874-B5CC-711C92BC385D}
///@brief Align for resize and crop values. For appendix stripes - align / 2 (Read only)
static const GUID ImScaler_Align = 
{ 0x8803e341, 0xa76d, 0x4874, { 0xb5, 0xcc, 0x71, 0x1c, 0x92, 0xbc, 0x38, 0x5d } };

//
// {A7767F9E-F2DD-4b51-BFDE-626852DD8DA3}
///@brief Maximum resize size by Width
static const GUID ImScaler_MaxResizeWidth = 
{ 0xa7767f9e, 0xf2dd, 0x4b51, { 0xbf, 0xde, 0x62, 0x68, 0x52, 0xdd, 0x8d, 0xa3 } };


// {97A2B1E2-EB2E-469c-A3BF-61E287578E38}
//
///@brief Maximum resize size by Height
static const GUID ImScaler_MaxResizeHeight = 
{ 0x97a2b1e2, 0xeb2e, 0x469c, { 0xa3, 0xbf, 0x61, 0xe2, 0x87, 0x57, 0x8e, 0x38 } };


//
// {4FE96158-A190-44e1-BF99-599E292FD999}
///@brief Minimum resize size by Height
static const GUID ImScaler_MinResizeWidth = 
{ 0x4fe96158, 0xa190, 0x44e1, { 0xbf, 0x99, 0x59, 0x9e, 0x29, 0x2f, 0xd9, 0x99 } };

// {69189676-63D0-4b5c-8BEB-FAD9A6775B6B}
//
///@brief Minimum resize size by Height
static const GUID ImScaler_MinResizeHeight = 
{ 0x69189676, 0x63d0, 0x4b5c, { 0x8b, 0xeb, 0xfa, 0xd9, 0xa6, 0x77, 0x5b, 0x6b } };


//
// {5CE39F30-35B9-4953-A23A-0FA6B1F356D1}
//
///@brief Set Picture Aspect Ratio
static const GUID ImScaler_SetAspectRatio = 
{ 0x5ce39f30, 0x35b9, 0x4953, { 0xa2, 0x3a, 0xf, 0xa6, 0xb1, 0xf3, 0x56, 0xd1 } };


//
// {B14F5971-1EA7-46e8-9B6E-42B0F3E37F7E}
//
///@brief Bind crop values to source picture size
static const GUID ImScaler_BindCrop = 
{ 0xb14f5971, 0x1ea7, 0x46e8, { 0x9b, 0x6e, 0x42, 0xb0, 0xf3, 0xe3, 0x7f, 0x7e } };

//
// {1F9739D4-EAC4-40e2-9BF5-97A618073785}
//
///@brief Crop parameters definition mode
static const GUID ImScaler_CropDefinitionMode = 
{ 0x1f9739d4, 0xeac4, 0x40e2, { 0x9b, 0xf5, 0x97, 0xa6, 0x18, 0x7, 0x37, 0x85 } };

//
// {D70EC5EF-C271-4728-A5BF-C0B6BD4F6D3E}
//
// Set Aspect Ratio 4:3
// Type: VT_BOOL
//
static const GUID ImScaler_SetAspect4_3 = 
{ 0xd70ec5ef, 0xc271, 0x4728, { 0xa5, 0xbf, 0xc0, 0xb6, 0xbd, 0x4f, 0x6d, 0x3e } };


//
// {6E7CFA3C-7395-4df9-A3D2-7E1DBE442B42}
//
///@brief Set Aspect Ratio 16:9
static const GUID ImScaler_SetAspect16_9 = 
{ 0x6e7cfa3c, 0x7395, 0x4df9, { 0xa3, 0xd2, 0x7e, 0x1d, 0xbe, 0x44, 0x2b, 0x42 } };

//
// {E0248902-C2ED-4633-B3F5-3CBC5BFC80F7}
//
///@brief Use aspect ratio for resizing with "Keep picture proportions" mode
static const GUID ImScaler_UseAspectRatio = 
{ 0xe0248902, 0xc2ed, 0x4633, { 0xb3, 0xf5, 0x3c, 0xbc, 0x5b, 0xfc, 0x80, 0xf7 } };


//Define obsolete names of GUIDs for compability with aplication that used preceding versions of the filter
#pragma deprecated(ImScaler_AppendixStripes) //The name of GUID is obsolete, use ImScaler_AppendixMode
#define	ImScaler_AppendixStripes	ImScaler_AppendixMode
#pragma deprecated(ImScaler_AppendixVerticalStripes) //The name of GUID is obsolete, use ImScaler_AppendixStripesType
#define	ImScaler_AppendixVerticalStripes	ImScaler_AppendixStripesType
#pragma deprecated(ImScaler_SizeAppendStripes) //The name of GUID is obsolete, use ImScaler_StripesSizeValue
#define	ImScaler_SizeAppendStripes	ImScaler_StripesSizeValue

#endif //__PropID_ImageScaler_h__
