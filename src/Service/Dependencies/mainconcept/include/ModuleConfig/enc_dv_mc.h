/**
\file enc_dv_mc.h
\brief Property GUIDs for MainConcept DV encoder parameters.

\verbatim
File: enc_dv_mc.h

Desc: Property GUIDs forMainConcept DV encoder parameters.

 Copyright (c) 2015 MainConcept GmbH or its affiliates.  All rights reserved.

 MainConcept and its logos are registered trademarks of MainConcept GmbH or its affiliates.  
 This software is protected by copyright law and international treaties.  Unauthorized 
 reproduction or distribution of any portion is prohibited by law.
\endverbatim
*/

#if !defined(__ENC_DV_HEADER__)
#define __ENC_DV_HEADER__
#include "common_mc.h"

/*****************************************
	Parameters GUIDs for DV-encoder
*****************************************/

/**
Specifies format of output stream.
\details <dl><dt><b>  Type: </b></dt><dd> 
VT_INT </dd></dl>
<dl><dt><b>  Available Values: </b></dt><dd>
DV25 - Create DV25 and normal DV output.<br>
DVCPRO25 - Create DVCPRO 25 MBit output (default).<br>
DVCPRO50 - Create DVCPRO 50 MBit output.<br>
DVCPRO100 - Create DVCPRO HD, 100 MBit output
</dd></dl> \hideinitializer */ // {AA599D0D-47BD-4035-8865-242AB1F1594B}
static const GUID DVVE_EncodingMode = 
{ 0xaa599d0d, 0x47bd, 0x4035, { 0x88, 0x65, 0x24, 0x2a, 0xb1, 0xf1, 0x59, 0x4b } };

/**
Specifies inverting of upper and lower field.
\details <dl><dt><b>  Type: </b></dt><dd> 
VT_INT </dd></dl>
<dl><dt><b>  Available Values: </b></dt><dd>
 1 - Invert fields <br>
 0 - Do not invert fields (default)
</dd></dl> \hideinitializer */ // {7539D7E1-93D4-44f0-83D0-578F7897F830}
static const GUID DVVE_InvFieldsOrder = 
{ 0x7539d7e1, 0x93d4, 0x44f0, { 0x83, 0xd0, 0x57, 0x8f, 0x78, 0x97, 0xf8, 0x30 } };

/**
Specifies using of fast encoding mode, like hardware encoder in FAST-mode.
\details <dl><dt><b>  Type: </b></dt><dd> 
VT_INT </dd></dl>
<dl><dt><b>  Available Values: </b></dt><dd>
 1 - Use fast encoding mode <br>
 0 - Do not use fast encoding mode (default)
</dd></dl> \hideinitializer */ // {FBDC48DC-6F19-4bf0-985A-B4492A1F26ED}
static const GUID DVVE_FastMode = 
{ 0xfbdc48dc, 0x6f19, 0x4bf0, { 0x98, 0x5a, 0xb4, 0x49, 0x2a, 0x1f, 0x26, 0xed } };

/**
Specifies forcing of 16:9 flag in the output
\details <dl><dt><b>  Type: </b></dt><dd> 
VT_INT </dd></dl>
<dl><dt><b>  Available Values: </b></dt><dd>
 1 - Always set the 16:9 flag in the output <br>
 0 - Do not force 16:9 flag (default)
</dd></dl> \hideinitializer */ // {9A84A202-81E9-4a76-8464-DD7D29365EBE}
static const GUID DVVE_16x9FLAG = 
{ 0x9a84a202, 0x81e9, 0x4a76, { 0x84, 0x64, 0xdd, 0x7d, 0x29, 0x36, 0x5e, 0xbe } };

/**
Specifies forcing of 4:3 flag in the output
\details <dl><dt><b>  Type: </b></dt><dd> 
VT_INT </dd></dl>
<dl><dt><b>  Available Values: </b></dt><dd>
 1 - Always clear the 16:9 flag in the output <br>
 0 - Do not clear 16:9 flag (default)
</dd></dl> \hideinitializer */ // {23719068-5854-4135-B449-AD2BA5B85579}
static const GUID DVVE_4x3FLAG = 
{ 0x23719068, 0x5854, 0x4135, { 0xb4, 0x49, 0xad, 0x2b, 0xa5, 0xb8, 0x55, 0x79 } };

/**
Do not create DIF-block with H0 header.
\details <dl><dt><b>  Type: </b></dt><dd> 
VT_INT </dd></dl>
<dl><dt><b>  Available Values: </b></dt><dd>
 1 - Suppress DIF-Pack header <br>
 0 - Create DIF-Pack header (default)
</dd></dl> \hideinitializer */ // {66E332C7-443F-4ab9-950B-782B9588BF4B}
static const GUID DVVE_Headerless = 
{ 0x66e332c7, 0x443f, 0x4ab9, { 0x95, 0xb, 0x78, 0x2b, 0x95, 0x88, 0xbf, 0x4b } };

/**
Used if input has top-field first.
\details <dl><dt><b>  Type: </b></dt><dd> 
VT_INT </dd></dl>
<dl><dt><b>  Available Values: </b></dt><dd>
 1 - Input has top-field first <br>
 0 - Input has bottom-field first (default)
</dd></dl> \hideinitializer */ // {41C85664-5DAC-4005-85CE-549F5C4BD6FD}
static const GUID DVVE_TopFieldInput = 
{ 0x41c85664, 0x5dac, 0x4005, { 0x85, 0xce, 0x54, 0x9f, 0x5c, 0x4b, 0xd6, 0xfd } };

/**
Use RGB format as clamped format: (16,16, 16) is black, (235,235,235) is white
\details <dl><dt><b>  Type: </b></dt><dd> 
VT_INT </dd></dl>
<dl><dt><b>  Available Values: </b></dt><dd>
 1 - Yes <br>
 0 - No (default)</dd></dl> \hideinitializer */ // {C75C0B1D-6E9E-4972-AC7E-5DDEC6C28771}
static const GUID DVVE_ClampRGB = 
{ 0xc75c0b1d, 0x6e9e, 0x4972, { 0xac, 0x7e, 0x5d, 0xde, 0xc6, 0xc2, 0x87, 0x71 } };

/**
Clamp YUV values to ITU601R legal values.
\details <dl><dt><b>  Type: </b></dt><dd> 
VT_INT </dd></dl>
<dl><dt><b>  Available Values: </b></dt><dd>
 1 - Yes <br>
 0 - No (default)</dd></dl> \hideinitializer */ // {6B710467-F502-4dad-BFC0-C124A530FEFF}
static const GUID DVVE_ClampYUV = 
{ 0x6b710467, 0xf502, 0x4dad, { 0xbf, 0xc0, 0xc1, 0x24, 0xa5, 0x30, 0xfe, 0xff } };

// {C3FDF778-E783-4482-A1D0-6F9C8E917027}
//static const GUID DVVE_InputConnected = 
//{ 0xc3fdf778, 0xe783, 0x4482, { 0xa1, 0xd0, 0x6f, 0x9c, 0x8e, 0x91, 0x70, 0x27 } };
//
//// {8A6F1B92-0636-4aa9-B7C7-74C5997B602F}
//static const GUID DVVE_OutputConnected = 
//{ 0x8a6f1b92, 0x636, 0x4aa9, { 0xb7, 0xc7, 0x74, 0xc5, 0x99, 0x7b, 0x60, 0x2f } };

namespace DV_ENCODER
{
	/** \brief  encoder modes*/
    enum EncodingMode_t
    {
        DV25 = 0, /**< DV25 mode  */
        DVCPRO25 = 1, /**< DVCPRO 25 mode */
        DVCPRO50 = 2, /**< DVCPRO 50 mode */ 
        DVCPRO100 = 3 /**< DVCPRO HD 100 mode  */
    };
}

#endif // __ENC_DV_HEADER__