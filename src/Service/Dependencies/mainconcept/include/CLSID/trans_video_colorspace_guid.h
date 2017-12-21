/********************************************************************
 Created: 2006/11/15 
 File name: trans_video_colorspace_guid_demo.h
 Purpose: Demo GUIDs for Color Space Converter DS Filter

 Copyright (c) 2005-2009 MainConcept GmbH. All rights reserved.

 This software is the confidential and proprietary information of
 MainConcept GmbH and may be used only in accordance with the terms of
 your license from MainConcept GmbH.

*********************************************************************/

#ifndef __COLORSPACECONVERTER_GUID_H__
#define __COLORSPACECONVERTER_GUID_H__

////////////////////////////////////////////////////////////

#undef  COMPANY_HIDEICON

#define CSCCOMPANY_DS_MERIT  (MERIT_NORMAL-1)

////////////////////////////////////////////////////////////
#ifndef RC_INVOKED // don't let resource compiler see this part

// {EE461DF8-E76D-499b-A0FC-1E2EDC235E07}
static const GUID CLSID_ECSC = 
{ 0xee461df8, 0xe76d, 0x499b, { 0xa0, 0xfc, 0x1e, 0x2e, 0xdc, 0x23, 0x5e, 0x7 } };

// {6509D39F-7CCE-4237-9CED-6A79C51AA28A}
static const GUID CLSID_ECSC_SettingsPropertyPage = 
{ 0x6509d39f, 0x7cce, 0x4237, { 0x9c, 0xed, 0x6a, 0x79, 0xc5, 0x1a, 0xa2, 0x8a } };

// {18AB26F6-0D11-4d2a-8412-6D573A57F367}
static const GUID CLSID_ECSC_AboutPropertyPage = 
{ 0x18ab26f6, 0xd11, 0x4d2a, { 0x84, 0x12, 0x6d, 0x57, 0x3a, 0x57, 0xf3, 0x67 } };

#endif // RC_INVOKED
////////////////////////////////////////////////////////////

#endif //__COLORSPACECONVERTER_GUID_H__

