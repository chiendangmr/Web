/**
\file dec_mjpg_mc.h
\brief Property GUIDs for MainConcept MJPG decoder parameters.

\verbatim
File: dec_mjpg_mc.h

Desc: Property GUIDs forMainConcept MJPG decoder parameters.

 Copyright (c) 2015 MainConcept GmbH or its affiliates.  All rights reserved.

 MainConcept and its logos are registered trademarks of MainConcept GmbH or its affiliates.  
 This software is protected by copyright law and international treaties.  Unauthorized 
 reproduction or distribution of any portion is prohibited by law.
\endverbatim
*/

#if !defined(__MJPEGDEC_MODULECONFIG_INCLUDED__)
#define __MJPEGDEC_MODULECONFIG_INCLUDED__
#include "common_mc.h"

///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
// Parameters GUIDs for Decoder         Type        Available range     Default Val     Note
// MJPGDEC_DisableYUV                   VT_I4       [0, 1]              [0]             disable all YUV color spaces
// MJPGDEC_IgnoreITU601                 VT_I4       [0, 1]              [0]             ignore ITU601 clamping (i.e. use full range)
// MJPGDEC_OneFieldOnly                 VT_I4       [0, 1]              [0]             decode one field only
// MJPGDEC_InvertFieldOrder             VT_I4       [0, 1]              [0]             swap fields
/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

/**
The decoder currently supports RGB16, RGB24, YUY2 and UYVY color spaces as input formats. It is possible to disable the YUY2 and UYUY color spaces by activating the Disable YUV parameter.
\details <dl><dt><b>  Type: </b></dt><dd> 
VT_I4 </dd></dl>
<dl><dt><b>  Available Values: </b></dt><dd>
0 - Enable YUV color spaces. <br>
1 - Disable YUV color spaces.
</dd></dl> \hideinitializer */ // {D996B608-1A84-4376-9C23-E725199A8E72}
static const GUID MJPGDEC_DisableYUV = 
{ 0xd996b608, 0x1a84, 0x4376, { 0x9c, 0x23, 0xe7, 0x25, 0x19, 0x9a, 0x8e, 0x72 } };

/**
The option specifies whether the ITU601 recommendations should be ignored or not.
\details <dl><dt><b>  Type: </b></dt><dd> 
VT_I4 </dd></dl>
<dl><dt><b>  Available Values: </b></dt><dd>
0 - Ignore ITU601. <br>
1 - Do not ignore ITU601.
</dd></dl> \hideinitializer */ // {E9C5E7FF-B408-4dfa-B525-4FA203940115}
static const GUID MJPGDEC_IgnoreITU601 = 
{ 0xe9c5e7ff, 0xb408, 0x4dfa, { 0xb5, 0x25, 0x4f, 0xa2, 0x3, 0x94, 0x1, 0x15 } };

/**
The option specifies whether only one field should be decoded
\details <dl><dt><b>  Type: </b></dt><dd> 
VT_I4 </dd></dl>
<dl><dt><b>  Available Values: </b></dt><dd>
0 - Decode whole frames. <br>
1 - Decode only one field.
</dd></dl> \hideinitializer */ // {FB6EDA01-504B-4fcb-810A-67AFAEC606E3}
static const GUID MJPGDEC_OneFieldOnly = 
{ 0xfb6eda01, 0x504b, 0x4fcb, { 0x81, 0xa, 0x67, 0xaf, 0xae, 0xc6, 0x6, 0xe3 } };

/**
The option specifies whether the field order of the MJPG video should be changed
\details <dl><dt><b>  Type: </b></dt><dd> 
VT_I4 </dd></dl>
<dl><dt><b>  Available Values: </b></dt><dd>
0 - Do not invert the original field order. <br>
1 - Invert field order, upper and lower fields are switched.
</dd></dl> \hideinitializer */ // {FF02BB6F-74CB-491f-ABC8-FE54F6C67F73}
static const GUID MJPGDEC_InvertFieldOrder = 
{ 0xff02bb6f, 0x74cb, 0x491f, { 0xab, 0xc8, 0xfe, 0x54, 0xf6, 0xc6, 0x7f, 0x73 } };

/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////


#endif // __MJPEGDEC_MODULECONFIG_INCLUDED__