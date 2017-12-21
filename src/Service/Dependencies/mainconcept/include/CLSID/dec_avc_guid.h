/********************************************************************
 Created: 2003/12/29 
 File name: dec_avc_guid_demo.h
 Purpose: Demo GUIDs for AVC/H.264 Decoder DS Filter

 Copyright (c) 2003-2009 MainConcept GmbH. All rights reserved.

 This software is the confidential and proprietary information of
 MainConcept GmbH and may be used only in accordance with the terms of
 your license from MainConcept GmbH.

*********************************************************************/

#ifndef __AVCDEC_GUIDS_H__
#define __AVCDEC_GUIDS_H__


#ifndef MCBUILD_BROADCAST
////////////////////////////////////////////////////////////

#undef  H264COMPANY_HIDEICON

#define H264COMPANY_DS_MERIT_DECODER   (MERIT_NORMAL-1)


////////////////////////////////////////////////////////////
#ifndef RC_INVOKED // don't let resource compiler see this part

// {535FD577-2F68-4FDC-934D-CEB0642D0D33}
static const GUID CLSID_EH264VD = 
{ 0x535fd577, 0x2f68, 0x4fdc, { 0x93, 0x4d, 0xce, 0xb0, 0x64, 0x2d, 0x0d, 0x33 } };

// {535FD577-14BD-4454-A619-96BA665B0992}
static const GUID CLSID_EH264VD_SettingsPropertyPage = 
{ 0x535fd577, 0x14bd, 0x4454, { 0xa6, 0x19, 0x96, 0xba, 0x66, 0x5b, 0x09, 0x92 } };

// {535FD577-6558-4327-AE70-E693767C40A0}
static const GUID CLSID_EH264VD_AboutPropertyPage = 
{ 0x535fd577, 0x6558, 0x4327, { 0xae, 0x70, 0xe6, 0x93, 0x76, 0x7c, 0x40, 0xa0 } };

#endif // RC_INVOKED
////////////////////////////////////////////////////////////



#else

/********************************************************************
 Created: 2007/08/28 
 File name: dec_avc_guid_demo_broadcast.h
 Purpose: Demo Broadcast GUIDs for AVC/H.264 Decoder DS Filter

 Copyright (c) 2008-2009 MainConcept GmbH. All rights reserved.

 This software is the confidential and proprietary information of
 MainConcept GmbH and may be used only in accordance with the terms of
 your license from MainConcept GmbH.

*********************************************************************/


////////////////////////////////////////////////////////////

#undef  H264COMPANY_HIDEICON

#define H264COMPANY_DS_MERIT_DECODER   (MERIT_NORMAL-1)


////////////////////////////////////////////////////////////
#ifndef RC_INVOKED // don't let resource compiler see this part

// {C274FA78-1F05-4EBB-85A7-F89363B9B3EA}
static const GUID CLSID_EH264VD = 
{ 0xc274fa78, 0x1f05, 0x4ebb, { 0x85, 0xa7, 0xf8, 0x93, 0x63, 0xb9, 0xb3, 0xea } };

// {C9A8C151-55B6-4721-A404-5E6AF535071E}
static const GUID CLSID_EH264VD_SettingsPropertyPage = 
{ 0xc9a8c151, 0x55b6, 0x4721, { 0xa4, 0x4, 0x5e, 0x6a, 0xf5, 0x35, 0x7, 0x1e } };

// {CAD047D4-EE82-42F2-8341-D3A86CAE7569}
static const GUID CLSID_EH264VD_AboutPropertyPage = 
{ 0xcad047d4, 0xee82, 0x42f2, { 0x83, 0x41, 0xd3, 0xa8, 0x6c, 0xae, 0x75, 0x69 } };

#endif // RC_INVOKED
////////////////////////////////////////////////////////////

#endif


#endif //__AVCDEC_GUIDS_H__


