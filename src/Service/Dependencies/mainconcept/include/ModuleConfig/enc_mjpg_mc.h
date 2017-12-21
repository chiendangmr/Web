/**
\file enc_mjpg_mc.h
\brief Property GUIDs for MainConcept MJPG encoder parameters.

\verbatim
File: enc_mjpg_mc.h

Desc: Property GUIDs forMainConcept MJPG encoder parameters.

 Copyright (c) 2015 MainConcept GmbH or its affiliates.  All rights reserved.

 MainConcept and its logos are registered trademarks of MainConcept GmbH or its affiliates.  
 This software is protected by copyright law and international treaties.  Unauthorized 
 reproduction or distribution of any portion is prohibited by law.
\endverbatim
*/

#if !defined(__MJPEGENC_MODULECONFIG_INCLUDED__)
#define __MJPEGENC_MODULECONFIG_INCLUDED__
#include "common_mc.h"

/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
// Parameters GUIDs for Encoder         Type        Available range     Default Val     Note
// MJPGENC_UseInterlace                 VT_I4       [0, 1]              [0]             use interlaced encoding, must be used for ITU601R source
// MJPGENC_OneFieldOnly                 VT_I4       [0, 1]              [0]             use one field only
// MJPGENC_InvertFieldOrder             VT_I4       [0, 1]              [0]             swap fields
// MJPGENC_InvertAVI1Order              VT_I4       [0, 1]              [0]             change the order of AVI1 markers
// MJPGENC_EnableBitrateControl         VT_I4       [0, 1]              [0]             try to keep the bitrate
// MJPGENC_StrongBitrateControl         VT_I4       [0, 1]              [0]             enables reencoding if codec frame gets too big or too small
// MJPGENC_Quality                      VT_I4       [1, 100]            [75]            compression quality
/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
/**
Activates encoding in interlace mode. We recommend only using this option if you want to encode MJPEG files in a hardware compliant way. Must be used for ITU601R source.
\details <dl><dt><b>  Type: </b></dt><dd> 
VT_I4 </dd></dl>
<dl><dt><b>  Available Values: </b></dt><dd>
0 - Disable interlace mode. <br>
1 - Enable interlace mode.
</dd></dl> \hideinitializer */ // {8EEB3F0D-D356-4cfc-A348-FC18E45A7472}
static const GUID MJPGENC_UseInterlace = 
{ 0x8eeb3f0d, 0xd356, 0x4cfc, { 0xa3, 0x48, 0xfc, 0x18, 0xe4, 0x5a, 0x74, 0x72 } };

/**
Encodes only one field. This is very useful for fast moving video segments.
\details <dl><dt><b>  Type: </b></dt><dd> 
VT_I4 </dd></dl>
<dl><dt><b>  Available Values: </b></dt><dd>
0 - Disable one field encoding. <br>
1 - Enable one field encoding.
</dd></dl> \hideinitializer */ // {89E12524-4EE6-480b-A60C-B42768309BAF}
static const GUID MJPGENC_OneFieldOnly = 
{ 0x89e12524, 0x4ee6, 0x480b, { 0xa6, 0xc, 0xb4, 0x27, 0x68, 0x30, 0x9b, 0xaf } };

/**
The option simply reverses the field order.
\details <dl><dt><b>  Type: </b></dt><dd> 
VT_I4 </dd></dl>
<dl><dt><b>  Available Values: </b></dt><dd>
0 - Do not invert field order. <br>
1 - Invert field order.
</dd></dl> \hideinitializer */ // {81D9A586-107A-436b-A547-7BCC11255BF1}
static const GUID MJPGENC_InvertFieldOrder = 
{ 0x81d9a586, 0x107a, 0x436b, { 0xa5, 0x47, 0x7b, 0xcc, 0x11, 0x25, 0x5b, 0xf1 } };

/**
The second field will be encoded first. This option is very useful because there are bugs in some hardware decoders. By adjusting this setting these bugs can be avoided.
\details <dl><dt><b>  Type: </b></dt><dd> 
VT_I4 </dd></dl>
<dl><dt><b>  Available Values: </b></dt><dd>
0 - Do not encode second field first. <br>
1 - Encode second field first.
</dd></dl> \hideinitializer */ // {856EA852-E9C4-4ea0-AEE5-3F03FB79C6EF}
static const GUID MJPGENC_InvertAVI1Order = 
{ 0x856ea852, 0xe9c4, 0x4ea0, { 0xae, 0xe5, 0x3f, 0x3, 0xfb, 0x79, 0xc6, 0xef } };

/**
Use this option to activate bitrate control. It must be enabled to set the bitrate.
\details <dl><dt><b>  Type: </b></dt><dd> 
VT_I4 </dd></dl>
<dl><dt><b>  Available Values: </b></dt><dd>
0 - Disable bitrate control.<br>
1 - Enable bitrate control.
</dd></dl> \hideinitializer */ // {84DC3254-80EF-42eb-A9F6-38F21051201C}
static const GUID MJPGENC_EnableBitrateControl = 
{ 0x84dc3254, 0x80ef, 0x42eb, { 0xa9, 0xf6, 0x38, 0xf2, 0x10, 0x51, 0x20, 0x1c } };

/**
Activates the two-pass encoding mode. It is useful when the necessary picture size has not been reached during the first round. The tolerance is normally around 15%.
\details <dl><dt><b>  Type: </b></dt><dd> 
VT_I4 </dd></dl>
<dl><dt><b>  Available Values: </b></dt><dd>
0 - Disable 2-pass encoding mode. <br>
1 - Enable 2-pass bitrate encoding mode.
</dd></dl> \hideinitializer */ // {8C32595F-02DD-41f0-8782-B6B49EB54FF9}
static const GUID MJPGENC_StrongBitrateControl = 
{ 0x8c32595f, 0x2dd, 0x41f0, { 0x87, 0x82, 0xb6, 0xb4, 0x9e, 0xb5, 0x4f, 0xf9 } };

/**
Specifies the compression rate. A high value leads to a better quality but also to a higher file size as well.
\details <dl><dt><b>  Type: </b></dt><dd> 
VT_I4 </dd></dl>
<dl><dt><b>  Available Values: </b></dt><dd>
Range from 1 (lowest quality) to 100 (highest quality).
</dd></dl> \hideinitializer */ // {83B288CE-BF4E-48cf-B18A-BE367A706D18}
static const GUID MJPGENC_Quality = 
{ 0x83b288ce, 0xbf4e, 0x48cf, { 0xb1, 0x8a, 0xbe, 0x36, 0x7a, 0x70, 0x6d, 0x18 } };
/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

#endif // __MJPEGENC_MODULECONFIG_INCLUDED__