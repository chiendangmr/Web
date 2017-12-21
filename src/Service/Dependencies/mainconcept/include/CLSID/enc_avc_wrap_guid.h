/********************************************************************
 Created: 2010/04/08 
 File name: enc_avc_wrap_guid_demo.h
 Purpose: GUIDs for AVC/H.264 Encoder DS Demo Filter

 Copyright (c) 2003-2010 MainConcept GmbH. All rights reserved.

 This software is the confidential and proprietary information of
 MainConcept GmbH and may be used only in accordance with the terms of
 your license from MainConcept GmbH.

*********************************************************************/

#ifndef __AVCENC_WRAP_GUIDS_H__
#define __AVCENC_WRAP_GUIDS_H__ 

////////////////////////////////////////////////////////////

#undef  H264VE_HIDEICON

////////////////////////////////////////////////////////////


// {E13A31F3-1531-4793-81C3-4FF3B2A78DF5}
static const GUID CLSID_H264WrapVideoEncoder = 
{ 0xe13a31f3, 0x1531, 0x4793, { 0x81, 0xc3, 0x4f, 0xf3, 0xb2, 0xa7, 0x8d, 0xf5 } };


// {F18849E4-5925-49AA-9D37-D8C2B11E3D72}
static const GUID CLSID_H264WrapVideoEncAboutPropertyPage = 
{ 0xf18849e4, 0x5925, 0x49aa, { 0x9d, 0x37, 0xd8, 0xc2, 0xb1, 0x1e, 0x3d, 0x72 } };


// {5F962FF6-FFD9-4D18-96CA-084506C2106D}
static const GUID CLSID_H264WrapVideoEncMainPropertyPage = 
{ 0x5f962ff6, 0xffd9, 0x4d18, { 0x96, 0xca, 0x8, 0x45, 0x6, 0xc2, 0x10, 0x6d } };


// {619EA28F-7101-47F9-8FF0-BCB6FDD85826}
static const GUID CLSID_H264WrapVideoEncAdvancedPropertyPage = 
{ 0x619ea28f, 0x7101, 0x47f9, { 0x8f, 0xf0, 0xbc, 0xb6, 0xfd, 0xd8, 0x58, 0x26 } };


////////////////////////////////////////////////////////////

#endif // __AVCENC_WRAP_GUIDS_H__ 
