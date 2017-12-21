/********************************************************************
 Created: 2003/12/29 
 File name: enc_avc_guid_demo.h
 Purpose: Demo GUIDs for AVC/H.264 Encoder DS Filter

 Copyright (c) 2003-2009 MainConcept GmbH. All rights reserved.

 This software is the confidential and proprietary information of
 MainConcept GmbH and may be used only in accordance with the terms of
 your license from MainConcept GmbH.

*********************************************************************/

#ifndef __AVCENC_GUIDS_H__
#define __AVCENC_GUIDS_H__


#ifndef MCBUILD_CONSUMER
#ifndef MCBUILD_BROADCAST

////////////////////////////////////////////////////////////

#undef  H264VE_HIDEICON

////////////////////////////////////////////////////////////

// {669EB16A-BBC0-4416-9909-33C8E1DEC617}
static const GUID CLSID_H264VideoEncoder = 
{ 0x669eb16a, 0xbbc0, 0x4416, { 0x99, 0x9, 0x33, 0xc8, 0xe1, 0xde, 0xc6, 0x17 } };

// {667E458C-858F-48cf-99B9-2A2828BC0E1D}
static const GUID CLSID_H264VideoEncAboutPropertyPage = 
{ 0x667e458c, 0x858f, 0x48cf, { 0x99, 0xb9, 0x2a, 0x28, 0x28, 0xbc, 0xe, 0x1d } };

// {CBA49054-9920-4be5-9A35-C073E9CF0C1A}
static const GUID CLSID_H264VideoEncMainPropertyPage = 
{ 0xcba49054, 0x9920, 0x4be5, { 0x9a, 0x35, 0xc0, 0x73, 0xe9, 0xcf, 0xc, 0x1a } };

// {FA025EBD-0E43-4ce6-8E52-C1086B1B01B1}
static const GUID CLSID_H264VideoEncAdvancedPropertyPage = 
{ 0xfa025ebd, 0xe43, 0x4ce6, { 0x8e, 0x52, 0xc1, 0x8, 0x6b, 0x1b, 0x1, 0xb1 } };

////////////////////////////////////////////////////////////

#else

/********************************************************************
 Created: 2008/11/10 
 File name: enc_avc_guid_demo_broadcast.h
 Purpose: Demo Broadcast GUIDs for AVC/H.264 Encoder DS Filter

 Copyright (c) 2008-2009 MainConcept GmbH. All rights reserved.

 This software is the confidential and proprietary information of
 MainConcept GmbH and may be used only in accordance with the terms of
 your license from MainConcept GmbH.

*********************************************************************/


////////////////////////////////////////////////////////////

#undef  H264VE_HIDEICON

////////////////////////////////////////////////////////////

// {B05B006C-7069-4bc8-A3F5-BA0BAA37E154}
static const GUID CLSID_H264VideoEncoder = 
{ 0xb05b006c, 0x7069, 0x4bc8, { 0xa3, 0xf5, 0xba, 0xb, 0xaa, 0x37, 0xe1, 0x54 } };

// {BFB60150-924A-4252-9CE2-1D858940E868}
static const GUID CLSID_H264VideoEncAboutPropertyPage = 
{ 0xbfb60150, 0x924a, 0x4252, { 0x9c, 0xe2, 0x1d, 0x85, 0x89, 0x40, 0xe8, 0x68 } };

// {BADF4994-A580-4d98-A22A-640FA98B8A41}
static const GUID CLSID_H264VideoEncMainPropertyPage = 
{ 0xbadf4994, 0xa580, 0x4d98, { 0xa2, 0x2a, 0x64, 0xf, 0xa9, 0x8b, 0x8a, 0x41 } };

// {BDC73D29-CC7F-4197-B14B-2209AF558878}
static const GUID CLSID_H264VideoEncAdvancedPropertyPage = 
{ 0xbdc73d29, 0xcc7f, 0x4197, { 0xb1, 0x4b, 0x22, 0x9, 0xaf, 0x55, 0x88, 0x78 } };

////////////////////////////////////////////////////////////

#endif
#else
/********************************************************************
 Created: 2007/02/22 
 File name: enc_avc_guid_demo_consumer.h
 Purpose: Demo Consumer GUIDs for AVC/H.264 Encoder DS Filter

 Copyright (c) 2005-2009 MainConcept GmbH. All rights reserved.

 This software is the confidential and proprietary information of
 MainConcept GmbH and may be used only in accordance with the terms of
 your license from MainConcept GmbH.

*********************************************************************/


////////////////////////////////////////////////////////////

#undef  H264VE_HIDEICON

////////////////////////////////////////////////////////////

// {160F2530-4020-4b38-B1C6-E79B646CD7FC}
static const GUID CLSID_H264VideoEncoder = 
{ 0x160f2530, 0x4020, 0x4b38, { 0xb1, 0xc6, 0xe7, 0x9b, 0x64, 0x6c, 0xd7, 0xfc } };

// {2D6964E0-5D9A-47fb-80A2-48002336F3EB}
static const GUID CLSID_H264VideoEncAboutPropertyPage = 
{ 0x2d6964e0, 0x5d9a, 0x47fb, { 0x80, 0xa2, 0x48, 0x0, 0x23, 0x36, 0xf3, 0xeb } };

// {69437DB9-6CAF-4c20-AB6E-DA7B20D0727D}
static const GUID CLSID_H264VideoEncMainPropertyPage = 
{ 0x69437db9, 0x6caf, 0x4c20, { 0xab, 0x6e, 0xda, 0x7b, 0x20, 0xd0, 0x72, 0x7d } };

// {94E37740-8A94-4586-8D79-2C8139395ADC}
static const GUID CLSID_H264VideoEncAdvancedPropertyPage = 
{ 0x94e37740, 0x8a94, 0x4586, { 0x8d, 0x79, 0x2c, 0x81, 0x39, 0x39, 0x5a, 0xdc } };

////////////////////////////////////////////////////////////

#endif
#endif // __AVCENC_GUIDS_H__ 
