/********************************************************************
 Created: 2010/11/13 
 File name: enc_avc_mfx_guid_demo.h
 Purpose: Demo GUIDs for AVC/H.264 Encoder DS Filter

 Copyright (c) 2003-2011 MainConcept GmbH. All rights reserved.

 This software is the confidential and proprietary information of
 MainConcept GmbH and may be used only in accordance with the terms of
 your license from MainConcept GmbH.

*********************************************************************/

#ifndef __AVCENC_MFX_GUIDS_H__
#define __AVCENC_MFX_GUIDS_H__ 

////////////////////////////////////////////////////////////

#undef  H264VE_HIDEICON

////////////////////////////////////////////////////////////

// {A6CE9A50-1C7D-401F-9392-72942A70C602}
static const GUID CLSID_H264MfxVideoEncoder = 
{ 0xa6ce9a50, 0x1c7d, 0x401f, { 0x93, 0x92, 0x72, 0x94, 0x2a, 0x70, 0xc6, 0x2 } };

// {71DC334B-E953-45E4-92BC-34077B9874EF}
static const GUID CLSID_H264MfxVideoEncAboutPropertyPage = 
{ 0x71dc334b, 0xe953, 0x45e4, { 0x92, 0xbc, 0x34, 0x7, 0x7b, 0x98, 0x74, 0xef } };

// {5E0AC636-2267-4545-8A82-742F8D6F26B8}
static const GUID CLSID_H264MfxVideoEncMainPropertyPage = 
{ 0x5e0ac636, 0x2267, 0x4545, { 0x8a, 0x82, 0x74, 0x2f, 0x8d, 0x6f, 0x26, 0xb8 } };

// {5B5A99D8-F5BD-43BD-A49E-63F6EC780CED}
static const GUID CLSID_H264MfxVideoEncAdvancedPropertyPage = 
{ 0x5b5a99d8, 0xf5bd, 0x43bd, { 0xa4, 0x9e, 0x63, 0xf6, 0xec, 0x78, 0xc, 0xed } };

////////////////////////////////////////////////////////////

#endif // __AVCENC_MFX_GUIDS_H__ 
