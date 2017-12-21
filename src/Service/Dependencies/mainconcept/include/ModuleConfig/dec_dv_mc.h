/**
\file dec_dv_mc.h
\brief Property GUIDs for MainConcept DV decoder parameters.

\verbatim
File: dec_dv_mc.h

Desc: Property GUIDs forMainConcept DV decoder parameters.

 Copyright (c) 2015 MainConcept GmbH or its affiliates.  All rights reserved.

 MainConcept and its logos are registered trademarks of MainConcept GmbH or its affiliates.  
 This software is protected by copyright law and international treaties.  Unauthorized 
 reproduction or distribution of any portion is prohibited by law.
\endverbatim
*/

#if !defined(__DV_HEADER__)
#define __DV_HEADER__
#include "common_mc.h"

/*****************************************
	Parameters GUIDs for DV-decoder
*****************************************/
/**
Specifies inverting of upper and lower field.
\details <dl><dt><b>  Type: </b></dt><dd> 
VT_INT </dd></dl>
<dl><dt><b>  Available Values: </b></dt><dd>
 1 - Invert fields <br>
 0 - Do not invert fields (default)
</dd></dl> \hideinitializer */ // {E9657C57-4FB0-4646-BD1D-A017C58A4577}
static const GUID DVVD_InvFieldsOrder = 
{ 0xe9657c57, 0x4fb0, 0x4646, { 0xbd, 0x1d, 0xa0, 0x17, 0xc5, 0x8a, 0x45, 0x77 } };

/**
Use fast decoding method, i.e. lower quality.
\details <dl><dt><b>  Type: </b></dt><dd> 
VT_INT </dd></dl>
<dl><dt><b>  Available Values: </b></dt><dd>
 1 - Yes <br>
 0 - No (default)</dd></dl> \hideinitializer */ // {607DF169-83D6-4b32-97A3-E3CAC68617D6}
static const GUID DVVD_Preview = 
{ 0x607df169, 0x83d6, 0x4b32, { 0x97, 0xa3, 0xe3, 0xca, 0xc6, 0x86, 0x17, 0xd6 } };

/**
Ignore 16x9 flag in DV (CIF only).
\details <dl><dt><b>  Type: </b></dt><dd> 
VT_INT </dd></dl>
<dl><dt><b>  Available Values: </b></dt><dd>
 1 - Yes <br>
 0 - No (default)</dd></dl> \hideinitializer */ // {59BF7B02-7508-4a9f-A702-5CA32B16EFAE}
static const GUID DVVD_DisableLetterFormat = 
{ 0x59bf7b02, 0x7508, 0x4a9f, { 0xa7, 0x2, 0x5c, 0xa3, 0x2b, 0x16, 0xef, 0xae } };

/**
Use RGB format as clamped format: (16,16, 16) is black, (235,235,235) is white
\details <dl><dt><b>  Type: </b></dt><dd> 
VT_INT </dd></dl>
<dl><dt><b>  Available Values: </b></dt><dd>
 1 - Yes <br>
 0 - No (default)</dd></dl> \hideinitializer */ // {B396ADC7-24E1-44d2-9C91-8C50D93CE1E3}
static const GUID DVVD_ClampRGB = 
{ 0xb396adc7, 0x24e1, 0x44d2, { 0x9c, 0x91, 0x8c, 0x50, 0xd9, 0x3c, 0xe1, 0xe3 } };

/**
Clamp YUV values to ITU601R legal values.
\details <dl><dt><b>  Type: </b></dt><dd> 
VT_INT </dd></dl>
<dl><dt><b>  Available Values: </b></dt><dd>
 1 - Yes <br>
 0 - No (default)</dd></dl> \hideinitializer */ // {3F8B4E91-1779-4265-AD0B-D63D6DF53872}
static const GUID DVVD_ClampYUV = 
{ 0x3f8b4e91, 0x1779, 0x4265, { 0xad, 0xb, 0xd6, 0x3d, 0x6d, 0xf5, 0x38, 0x72 } };

/**
Decode to half resolution for both dimensions. (quarter size)
\details <dl><dt><b>  Type: </b></dt><dd> 
VT_INT </dd></dl>
<dl><dt><b>  Available Values: </b></dt><dd>
 1 - Decode to quarter size <br>
 0 - Do not decode to quarter size (default)</dd></dl> \hideinitializer */ // {DED3CD83-E1D1-45fa-9B5F-5BC7E40E089A}
static const GUID DVVD_DecodeToCif = 
{ 0xded3cd83, 0xe1d1, 0x45fa, { 0x9b, 0x5f, 0x5b, 0xc7, 0xe4, 0xe, 0x8, 0x9a } };

// {5EEE3F38-052C-4946-89E9-B0C53BEDFCDB}
static const GUID DVVD_InterlaceFlags = 
{ 0x5eee3f38, 0x52c, 0x4946, { 0x89, 0xe9, 0xb0, 0xc5, 0x3b, 0xed, 0xfc, 0xdb } };


/*****************************************
	Parameters GUIDs for DV-encoder
*****************************************/

// {AA599D0D-47BD-4035-8865-242AB1F1594B}
static const GUID DVVE_EncodingMode = 
{ 0xaa599d0d, 0x47bd, 0x4035, { 0x88, 0x65, 0x24, 0x2a, 0xb1, 0xf1, 0x59, 0x4b } };

// {7539D7E1-93D4-44f0-83D0-578F7897F830}
static const GUID DVVE_InvFieldsOrder = 
{ 0x7539d7e1, 0x93d4, 0x44f0, { 0x83, 0xd0, 0x57, 0x8f, 0x78, 0x97, 0xf8, 0x30 } };

// {FBDC48DC-6F19-4bf0-985A-B4492A1F26ED}
static const GUID DVVE_FastMode = 
{ 0xfbdc48dc, 0x6f19, 0x4bf0, { 0x98, 0x5a, 0xb4, 0x49, 0x2a, 0x1f, 0x26, 0xed } };

// {9A84A202-81E9-4a76-8464-DD7D29365EBE}
static const GUID DVVE_16x9FLAG = 
{ 0x9a84a202, 0x81e9, 0x4a76, { 0x84, 0x64, 0xdd, 0x7d, 0x29, 0x36, 0x5e, 0xbe } };

// {23719068-5854-4135-B449-AD2BA5B85579}
static const GUID DVVE_4x3FLAG = 
{ 0x23719068, 0x5854, 0x4135, { 0xb4, 0x49, 0xad, 0x2b, 0xa5, 0xb8, 0x55, 0x79 } };

// {66E332C7-443F-4ab9-950B-782B9588BF4B}
static const GUID DVVE_Headerless = 
{ 0x66e332c7, 0x443f, 0x4ab9, { 0x95, 0xb, 0x78, 0x2b, 0x95, 0x88, 0xbf, 0x4b } };

// {41C85664-5DAC-4005-85CE-549F5C4BD6FD}
static const GUID DVVE_TopFieldInput = 
{ 0x41c85664, 0x5dac, 0x4005, { 0x85, 0xce, 0x54, 0x9f, 0x5c, 0x4b, 0xd6, 0xfd } };

// {C75C0B1D-6E9E-4972-AC7E-5DDEC6C28771}
static const GUID DVVE_ClampRGB = 
{ 0xc75c0b1d, 0x6e9e, 0x4972, { 0xac, 0x7e, 0x5d, 0xde, 0xc6, 0xc2, 0x87, 0x71 } };

// {6B710467-F502-4dad-BFC0-C124A530FEFF}
static const GUID DVVE_ClampYUV = 
{ 0x6b710467, 0xf502, 0x4dad, { 0xbf, 0xc0, 0xc1, 0x24, 0xa5, 0x30, 0xfe, 0xff } };

// {C3FDF778-E783-4482-A1D0-6F9C8E917027}
//static const GUID DVVE_InputConnected = 
//{ 0xc3fdf778, 0xe783, 0x4482, { 0xa1, 0xd0, 0x6f, 0x9c, 0x8e, 0x91, 0x70, 0x27 } };
//
//</dd></dl> \hideinitializer */ // {8A6F1B92-0636-4aa9-B7C7-74C5997B602F}
//static const GUID DVVE_OutputConnected = 
//{ 0x8a6f1b92, 0x636, 0x4aa9, { 0xb7, 0xc7, 0x74, 0xc5, 0x99, 0x7b, 0x60, 0x2f } };

namespace DV_ENCODER
{
    enum EncodingMode_t
    {
        DV25 = 0,
        DVCPRO25 = 1,
        DVCPRO50 = 2,
        DVCPRO100 = 3
    };
}

#endif