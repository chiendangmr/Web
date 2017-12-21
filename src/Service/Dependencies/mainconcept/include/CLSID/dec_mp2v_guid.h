/********************************************************************
 Created: 2006/11/15 
 File name: dec_mp2v_guid_demo.h
 Purpose: Demo GUIDs for MPEG-2 video decoder DS Filter

 Copyright (c) 2005-2008 MainConcept GmbH. All rights reserved.

 This software is the confidential and proprietary information of
 MainConcept GmbH and may be used only in accordance with the terms of
 your license from MainConcept GmbH.

*********************************************************************/

#ifndef __MPEG2DEC_GUID_H__
#define __MPEG2DEC_GUID_H__

////////////////////////////////////////////////////////////

#undef  COMPANY_HIDEICON

#define M2COMPANY_DS_MERIT_DECODER   (MERIT_NORMAL-1)

////////////////////////////////////////////////////////////
#ifndef RC_INVOKED // don't let resource compiler see this part

// {BC4EB322-771F-4E9F-AF67-37C631ECA107}
static const GUID CLSID_EM2VD =
{ 0xbc4eb322, 0x771f, 0x4e9f, { 0xaf, 0x67, 0x37, 0xc6, 0x31, 0xec, 0xa1, 0x7 } };

// {5611AC6F-60BD-4C61-B1B2-793037310CA8}
static const GUID CLSID_EM2VD_SettingsPropertyPage =
{ 0x5611ac6f, 0x60bd, 0x4c61, { 0xb1, 0xb2, 0x79, 0x30, 0x37, 0x31, 0xc, 0xa8 } };

// {D677B968-820F-4E84-B43A-118270FFFB81}
static const GUID CLSID_EM2VD_AboutPropertyPage =
{ 0xd677b968, 0x820f, 0x4e84, { 0xb4, 0x3a, 0x11, 0x82, 0x70, 0xff, 0xfb, 0x81 } };

#endif // RC_INVOKED
////////////////////////////////////////////////////////////

#endif //__MPEG2VIDEO_GUID_H__
