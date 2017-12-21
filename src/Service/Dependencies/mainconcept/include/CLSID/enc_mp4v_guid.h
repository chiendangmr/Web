/********************************************************************
 Created: 2006/11/15 
 File name: enc_mp4v_guid_demo.h
 Purpose: Demo GUIDs for MPEG-4 video encoder DS Filter

 Copyright (c) 2005-2008 MainConcept GmbH. All rights reserved.

 This software is the confidential and proprietary information of
 MainConcept GmbH and may be used only in accordance with the terms of
 your license from MainConcept GmbH.

*********************************************************************/

#ifndef __MPEG4ENC_GUID_H__
#define __MPEG4ENC_GUID_H__

////////////////////////////////////////////////////////////

#undef  COMPANY_HIDEICON

#define M4COMPANY_DS_MERIT_ENCODER   (MERIT_DO_NOT_USE-1)

////////////////////////////////////////////////////////////
#ifndef RC_INVOKED // don't let resource compiler see this part

// {5294B79E-9E25-4205-80A5-C6898294329A}
static const GUID CLSID_MPEG4VideoEncoder = 
{ 0x5294b79e, 0x9e25, 0x4205, { 0x80, 0xa5, 0xc6, 0x89, 0x82, 0x94, 0x32, 0x9a } };

// {D4455946-DCBE-4516-A276-BBC890AB501A}
static const GUID CLSID_MPEG4EncPropPageMain = 
{ 0xd4455946, 0xdcbe, 0x4516, { 0xa2, 0x76, 0xbb, 0xc8, 0x90, 0xab, 0x50, 0x1a } };

// {022BE816-8104-4570-BCDF-5E2C4BDCA404}
static const GUID CLSID_MPEG4EncPropPageAdv = 
{ 0x22be816, 0x8104, 0x4570, { 0xbc, 0xdf, 0x5e, 0x2c, 0x4b, 0xdc, 0xa4, 0x4 } };

// {2D25CB24-C062-4119-93E4-C562EDB3F1E0}
static const GUID CLSID_MPEG4EncPropPageAbout = 
{ 0x2d25cb24, 0xc062, 0x4119, { 0x93, 0xe4, 0xc5, 0x62, 0xed, 0xb3, 0xf1, 0xe0 } };


#endif // RC_INVOKED
////////////////////////////////////////////////////////////

#endif //__MPEG4ENC_GUID_H__
