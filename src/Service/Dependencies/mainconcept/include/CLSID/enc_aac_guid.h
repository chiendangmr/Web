/********************************************************************
 Created: 2004/11/03 
 File name: enc_aac_guid_demo.h
 Purpose: Demo GUIDs for AAC Encoder DS Filter

 Copyright (c) 2004-2008 MainConcept GmbH. All rights reserved.

 This software is the confidential and proprietary information of
 MainConcept GmbH and may be used only in accordance with the terms of
 your license from MainConcept GmbH.

*********************************************************************/

#ifndef __AACENC_GUID_H__
#define __AACENC_GUID_H__


////////////////////////////////////////////////////////////

#undef  COMPANY_HIDEICON

#define COMPANY_DS_MERIT_AACENCODER (MERIT_SW_COMPRESSOR-1)


///////////////////////////////////////////////////////////////
#ifndef RC_INVOKED // don't let resource compiler see this part

// {3584BA08-5B83-4E6A-BC91-4586972AE239}
static const GUID CLSID_AACEncoder = 
{ 0x3584ba08, 0x5b83, 0x4e6a, { 0xbc, 0x91, 0x45, 0x86, 0x97, 0x2a, 0xe2, 0x39 } };

// {3584BA08-013E-42AC-A58A-71B1F32801FB}
static const GUID CLSID_AACEncoderPropPageSettings = 
{ 0x3584ba08, 0x013e, 0x42ac, { 0xa5, 0x8a, 0x71, 0xb1, 0xf3, 0x28, 0x1, 0xfb } };

// {3584BA08-5C89-487B-8236-08098EE45709}
static const GUID CLSID_AACEncoderPropPageAbout = 
{ 0x3584ba08, 0x5c89, 0x487b, { 0x82, 0x36, 0x8, 0x9, 0x8e, 0xe4, 0x57, 0x9 } };

#endif // RC_INVOKED
////////////////////////////////////////////////////

#endif //__AACENC_GUID_H__


