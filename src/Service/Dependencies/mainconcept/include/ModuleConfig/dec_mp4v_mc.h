 /**
\file dec_mp4v_mc.h
\brief Property GUIDs for MainConcept mp4v decoder parameters.

\verbatim
File: dec_mp4v_mc.h

Desc: Property GUIDs forMainConcept MPEG-4 Part 2/H.263 decoder parameters.

 Copyright (c) 2015 MainConcept GmbH or its affiliates.  All rights reserved.

 MainConcept and its logos are registered trademarks of MainConcept GmbH or its affiliates.  
 This software is protected by copyright law and international treaties.  Unauthorized 
 reproduction or distribution of any portion is prohibited by law.
\endverbatim
*/

#ifndef __MPEG4Dec_FILTER_PROPID__
#define __MPEG4Dec_FILTER_PROPID__

#include "common_mc.h"

// Decoder config

// GUID                     Value Type      Available range   Default Value	    Note


// EM4VD_PostProcessing         VT_INT          0,1                 0           0 - dont't apply deblocking filter
// EM4VD_DeblockStrength        VT_INT          0 - 200           100           Specifies the percentage rate of the deblocking filter's usage
// EM4VD_Brightness             VT_I4		    0 - 255           128			Sets the brightness level.    
// EM4VD_Contrast               VT_I4	    	0 - 255           128          	Sets the contrast.
// EM4VD_DisplayOSD             VT_INT          0,1                 0           1 - display some statistics, decodeing frame type, frame number 
// EM4VD_Deinterlace            VT_UI4          0-4                 0           0 - off, 1 - Vertical Filter, 2 - Field Interpolation, 3 - VMR, 4 - Auto mode, if stream interlace - field interpolation
// EM4VD_ErrorRecilienceMode    VT_UI4          0-1                 0           0 - skip till intra, 1 - decode anyway
// EM4VD_SkipMode           	VT_UI4          0-3   				0	        0 - decode all, 1 - decode I,P, 2 - decode I only, 3 - obey quality messages (skip out of time B-frames) 
// EM4VD_IDCTPrecision			VT_UI4		    0, 1			    0   		Selecting precision of inverse DCT procedure


enum SkipMode {
    skip_mode_none = 0,
    skip_mode_decode_reference,
    skip_mode_decode_intra,
    skip_mode_obey_quality_messages
};

// EM4VD_LTMode values
enum	LTMode{
	LTMode_not_activate =0,
    LTMode_demo =1,
    LTMode_evaluation =2,
    LTMode_evaluation_expired =3,
    LTMode_full =4
};

enum DeinterlaceMode{
	Deinterlace_Weave = 0,
	Deinterlace_VerticalFilter = 1,
	Deinterlace_FieldInterpolation = 2,
	Deinterlace_VMR = 3,
	Deinterlace_Auto = 4
};


enum ErrorResilienceMode {
    Error_resilience_mode_skip_till_intra = 0,
    Error_resilience_mode_proceed_anyway
} ;


enum IDCTPrecisionMode{
    IDCTPrecision_Integer = 0,
    IDCTPrecision_Float  = 1
};


/** \note This option is obsolete now and does not have any effect anymore.  \hideinitializer */ // {0AD063C4-70C2-42f4-B1C2-41E20FFC33FC}
static const GUID EM4VD_OEMName = 
{ 0xad063c4, 0x70c2, 0x42f4, { 0xb1, 0xc2, 0x41, 0xe2, 0xf, 0xfc, 0x33, 0xfc } };

/** \note This option is obsolete now and does not have any effect anymore. \hideinitializer */ // {1CFA86FE-8F92-4780-B574-8D894D808703}
static const GUID EM4VD_GetTimeFromStream = 
{ 0x1cfa86fe, 0x8f92, 0x4780, { 0xb5, 0x74, 0x8d, 0x89, 0x4d, 0x80, 0x87, 0x3 } };

/** \note This option is obsolete now and does not have any effect anymore.  \hideinitializer */ // {EAEF287C-DBB7-41a4-AFC7-C0AE1D068052}
static const GUID EM4VD_SkipMode = 
{ 0xeaef287c, 0xdbb7, 0x41a4, { 0xaf, 0xc7, 0xc0, 0xae, 0x1d, 0x6, 0x80, 0x52 } };

/** \note This option is obsolete now and does not have any effect anymore.  \hideinitializer */ // {1C6CB2A1-F5B1-444f-874B-421AEE6F070A}
static const GUID EM4VD_PostProcessing = 
{ 0x1c6cb2a1, 0xf5b1, 0x444f, { 0x87, 0x4b, 0x42, 0x1a, 0xee, 0x6f, 0x7, 0xa } };

/** 
Specifies the percentage rate of the deblocking filter's usage, takes effect when MC_PostProcess option sets to 1. Default value is 100% that means middle level of applying deblock algorithm. 200% is maximum post processing intensity.
\details <dl><dt><b>  Type: </b></dt><dd> 
VT_INT </dd></dl>
<dl><dt><b>  Available Values: </b></dt><dd>
0 - 200
\note This option is obsolete now and does not have any effect anymore. 
</dd></dl>  \hideinitializer */ // {6961D126-9D2C-4dcf-978A-35F3DED742EC}
static const GUID EM4VD_DeblockStrength = 
{ 0x6961d126, 0x9d2c, 0x4dcf, { 0x97, 0x8a, 0x35, 0xf3, 0xde, 0xd7, 0x42, 0xec } };

/** \note This option is obsolete now and does not have any effect anymore.  \hideinitializer */ // {6FE0B202-139C-477a-8C4E-F4C90E0F10E2}
static const GUID EM4VD_Brightness = 
{ 0x6fe0b202, 0x139c, 0x477a, { 0x8c, 0x4e, 0xf4, 0xc9, 0xe, 0xf, 0x10, 0xe2 } };

/** \note This option is obsolete now and does not have any effect anymore.  \hideinitializer */ // {23E2776D-3BB5-4aa5-9563-4DBE5AF9539E}
static const GUID EM4VD_Contrast = 
{ 0x23e2776d, 0x3bb5, 0x4aa5, { 0x95, 0x63, 0x4d, 0xbe, 0x5a, 0xf9, 0x53, 0x9e } };

/** \note This option is obsolete now and does not have any effect anymore.  \hideinitializer */ // {1AA0B563-97A0-4a86-BB67-1E011FCFB027}
static const GUID EM4VD_DisplayOSD = 
{ 0x1aa0b563, 0x97a0, 0x4a86, { 0xbb, 0x67, 0x1e, 0x1, 0x1f, 0xcf, 0xb0, 0x27 } };

/** \note This option is obsolete now and does not have any effect anymore. \hideinitializer */ // {9FD4B881-4E34-4290-AC21-D3EF555BE308}
static const GUID EM4VD_Deinterlace = 
{ 0x9fd4b881, 0x4e34, 0x4290, { 0xac, 0x21, 0xd3, 0xef, 0x55, 0x5b, 0xe3, 0x8 } };


/** \note This option is obsolete now and does not have any effect anymore.  \hideinitializer */ // {2A75B92C-4254-492f-89C7-7D15526A3EB6}
static const GUID EM4VD_ErrorResilienceMode = 
{ 0x2a75b92c, 0x4254, 0x492f, { 0x89, 0xc7, 0x7d, 0x15, 0x52, 0x6a, 0x3e, 0xb6 } };


/** \note This option is obsolete now and does not have any effect anymore.  \hideinitializer */ // {6FFE2A6B-777A-45fb-BB84-19C370B7E0CF}
static const GUID EM4VD_LTMode = 
{ 0x6ffe2a6b, 0x777a, 0x45fb, { 0xbb, 0x84, 0x19, 0xc3, 0x70, 0xb7, 0xe0, 0xcf } };

// Guid is equal to Mpeg-2 decoder EM2VD_IDCTPrecision
/** 
The option forces the decoder to use the double precision reference IDCT algorithm. By default, the decoder uses the optimized CPU-specific IEEE-1180 compliant integer IDCT. As a reference, the double precision IDCT algorithm from the IEEE 1180-test was used. This algorithm is useful for editing applications due to the high precision, though it is quite slow regarding the order of magnitude.
\details <dl><dt><b>  Type: </b></dt><dd> 
VT_UI4 </dd></dl>
<dl><dt><b>  Available Values: </b></dt><dd>
0 - Fast integer. <br>
1 - Double precision. 
</dd></dl> \hideinitializer */ // {9CF1A333-E72B-4a6d-BBE8-199595944546}
static const GUID EM4VD_IDCTPrecision = 
{0x9cf1a333, 0xe72b, 0x4a6d, {0xbb, 0xe8, 0x19, 0x95, 0x95, 0x94, 0x45, 0x46 }};

/**
Forces decoder to assume that every sample buffer contains a complete frame  to process it and send ready frames to renderer immediately.
\details <dl><dt><b>  Type: </b></dt><dd> 
VT_INT</dd></dl>
<dl><dt><b>  Available Values: </b></dt><dd>
0 - Decoder sends  ready frames with delay because it has to get next start code to process whole access unit. <br>
1 - Decoder assumes that every sample buffer has whole frame and it can process it immediately. 
</dd></dl> \hideinitializer */ // {2F9C2BA1-39F8-4ae7-BC94-46D26A948FF2}
static const GUID EM4VD_WholeFramePerSample = 
{ 0x2f9c2ba1, 0x39f8, 0x4ae7, { 0xbc, 0x94, 0x46, 0xd2, 0x6a, 0x94, 0x8f, 0xf2 } };




/**
Forces decoder to use saturation for inverse quantized DC coefficient accordance to standard
\details <dl><dt><b>  Type: </b></dt><dd>
VT_INT</dd></dl>
<dl><dt><b>  Available Values: </b></dt><dd>
0 - Disable saturation <br>
1 - Enable saturation
</dd></dl> \hideinitializer */ // {7C23DEDA-9E79-47D8-B539-8BCB80B2A1C9}
static const GUID EM4VD_EnableSaturationDequantizedDC =
{ 0x7c23deda, 0x9e79, 0x47d8,{ 0xb5, 0x39, 0x8b, 0xcb, 0x80, 0xb2, 0xa1, 0xc9 } };


#endif //__MPEG4Dec_FILTER_PROPID__

