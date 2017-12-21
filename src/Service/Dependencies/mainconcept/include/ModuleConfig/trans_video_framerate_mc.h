/** 
 @file  trans_video_framerate_mc.h
 @brief  Property GUIDs for MainConcept Frame Rate Converter parameters.
 
 @verbatim
 File: trans_video_framerate_mc.h

 Desc: Property GUIDs for MainConcept Frame Rate Converter parameters.
 
 Copyright (c) 2015 MainConcept GmbH or its affiliates.  All rights reserved.

 MainConcept and its logos are registered trademarks of MainConcept GmbH or its affiliates.  
 This software is protected by copyright law and international treaties.  Unauthorized 
 reproduction or distribution of any portion is prohibited by law.
 @endverbatim
 **/

//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
//	GUID						Value Type	Available range		Default Val		Note
//	CLSID_FRCInPlace_InFR		VT_UINT		[0 - 10 000]			0			Input Frame Rate  as  trunc (float_frame_rate*100)
//	CLSID_FRCInPlace_OutFR		VT_UINT		[0 - 10 000]			0			OutputFrame Rate    trunc (float_frame_rate*100)
//	CLSID_FRCInPlace_InProg		VT_UINT		[0 - 2]				0			Progressive/Interlace input  /0 - "Auto" / 1 - "Progressive" /	2 - "Interlaced"
//	CLSID_FRCInPlace_OutProg 	VT_UINT		[0 - 1]			1				Progressive/Interlace output / 	0 - "Interlaced" /	1 - "Progressive"   
//	CLSID_FRCInPlace_OddFF		VT_UINT		[0 - 1]			0			 Field's order switch /  0 -- Odd Field First /  1 -- Even Field First
//	CLSID_FRC_FD_Switch		VT_UINT		[0 - 1]					0				Behaviour switch (Frame rate converter or Line doubler) / Available range: 0-1 /  1 -- Line Doubler /  0 -- Frame Rate Converter
//	CLSID_FRC_SpatialPlcmntPrsrv	VT_UINT		[0 - 1]					0				 Define do we need to keep spatial placement of fields during Interlaced->Interlaced conversion /  1 -- Keep spatial placement /  0 -- Do not need to keep spatial placement
//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////


#ifndef __FRC_INTERFACEGUIDS_H__
#define __FRC_INTERFACEGUIDS_H__


///@brief Input Frame Rate. The CLSID used by InputRate PropPage's element.
// {738C368C-E349-45ad-B359-C2D6BF7C71C0}
static const GUID CLSID_FRCInPlace_InFR = {0x738c368c, 0xe349, 0x45ad, {0xb3, 0x59, 0xc2, 0xd6, 0xbf, 0x7c, 0x71, 0xc0}};


///@brief Output Frame Rate. The CLSID used by OutputRate PropPage's element
// {7CFA24E9-81FC-41a5-928E-66B9F781B6DC}
static const GUID CLSID_FRCInPlace_OutFR = {0x7cfa24e9, 0x81fc, 0x41a5, {0x92, 0x8e, 0x66, 0xb9, 0xf7, 0x81, 0xb6, 0xdc}};


///@brief Progressive/Interlace input
// {D9250A28-8A79-46aa-A297-374499404359}
static const GUID CLSID_FRCInPlace_InProg = { 0xd9250a28, 0x8a79, 0x46aa, { 0xa2, 0x97, 0x37, 0x44, 0x99, 0x40, 0x43, 0x59 } };


///@brief Progressive/Interlace output
// {9DF52E06-511C-4e61-BE41-94EE3DAC787A}
static const GUID CLSID_FRCInPlace_OutProg = { 0x9df52e06, 0x511c, 0x4e61, { 0xbe, 0x41, 0x94, 0xee, 0x3d, 0xac, 0x78, 0x7a } };


///@brief Field's order switch
// {DF91C1B7-E494-441e-9A80-8E02265100BA}
static const GUID CLSID_FRCInPlace_OddFF =  { 0xdf91c1b7, 0xe494, 0x441e, { 0x9a, 0x80, 0x8e, 0x2, 0x26, 0x51, 0x0, 0xba } };


///@brief Behaviour switch (Frame rate converter or Line doubler)
// {F73B70D0-9FCD-4828-BC67-CEC7629FC47E}
static const GUID CLSID_FRC_FD_Switch = { 0xf73b70d0, 0x9fcd, 0x4828, { 0xbc, 0x67, 0xce, 0xc7, 0x62, 0x9f, 0xc4, 0x7e } };


///@brief Define do we need to keep spatial placement of fields during Interlaced->Interlaced conversion
// {18598C3C-4256-4871-BC07-D2C80848A883}
static const GUID CLSID_FRC_SpatialPlcmntPrsrv  = { 0x18598c3c, 0x4256, 0x4871, { 0xbc, 0x7, 0xd2, 0xc8, 0x8, 0x48, 0xa8, 0x83 } };


//
// {734ECF4A-3F35-460e-95EB-68EC7A9CAA5B}
//
///Special mode for ROXIO decoder which insert gaps in timeline instead of modifying frame's timestamps 
static const GUID CLSID_FRC_AddTimeGapsToFrame = { 0x734ecf4a, 0x3f35, 0x460e, { 0x95, 0xeb, 0x68, 0xec, 0x7a, 0x9c, 0xaa, 0x5b } };


#endif //__FRC_INTERFACEGUIDS_H__
