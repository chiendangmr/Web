/********************************************************************
 Created: 2006/11/15 
 File name: trans_video_framerate_guid_demo.h
 Purpose: Demo GUIDs for Framerate Converter DS Filter

 Copyright (c) 2005-2009 MainConcept GmbH. All rights reserved.

 This software is the confidential and proprietary information of
 MainConcept GmbH and may be used only in accordance with the terms of
 your license from MainConcept GmbH.

*********************************************************************/

#ifndef __FRC_GUIDS_H__
#define __FRC_GUIDS_H__ 

////////////////////////////////////////////////////////////

#undef FRCCOMPANY_HIDEICON

#define FRCCOMPANY_DS_MERIT   (MERIT_UNLIKELY-1)
#define FRCREGISTRY_SETTINGS_KEY		TEXT("Software\\MainConcept\\")

////////////////////////////////////////////////////////////
#ifndef RC_INVOKED // don't let resource compiler see this part

// The CLSID used by Transform FrameRate  filter
// {C05003D8-B727-4d4c-B8D5-B1625CE9320A}
static const GUID CLSID_FRCInPlace = 
{ 0xc05003d8, 0xb727, 0x4d4c, { 0xb8, 0xd5, 0xb1, 0x62, 0x5c, 0xe9, 0x32, 0xa } };

// The CLSID used by Transform FrameRate PropPage
// {7CB95EB8-6139-4a46-8AD6-6F93F0C3FD9C}
static const GUID CLSID_FRCInPlacePropPage = 
{ 0x7cb95eb8, 0x6139, 0x4a46, { 0x8a, 0xd6, 0x6f, 0x93, 0xf0, 0xc3, 0xfd, 0x9c } };

// {9B871588-CEE9-4213-BE9C-3535734675D2}
static const GUID CLSID_FRC_ABOUTPAGE = 
{ 0x9b871588, 0xcee9, 0x4213, { 0xbe, 0x9c, 0x35, 0x35, 0x73, 0x46, 0x75, 0xd2 } };

#endif // RC_INVOKED
////////////////////////////////////////////////////////////

#endif //__FRC_GUIDS_H__
