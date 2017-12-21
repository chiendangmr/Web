/********************************************************************
 Created: 2010/04/14 
 File name: enc_vc3_guid_demo.h
 Purpose: Demo GUIDs for VC-3 Encoder DS Filter

 Copyright (c) 2009-2011 MainConcept GmbH. All rights reserved.

 This software is the confidential and proprietary information of
 MainConcept GmbH and may be used only in accordance with the terms of
 your license from MainConcept GmbH.
*********************************************************************/

#ifndef __ENC_VC3_GUID_H__
#define __ENC_VC3_GUID_H__

////////////////////////////////////////////////////////////

#undef  COMPANY_HIDEICON

#define COMPANY_DS_MERIT_VC3ENCODER (MERIT_SW_COMPRESSOR-1)

///////////////////////////////////////////////////////////////
#ifndef RC_INVOKED // don't let resource compiler see this part

// {E98E83E2-AD70-43FC-8E79-B056B0F6FF64}
static const GUID CLSID_VC3VideoEncoder = 
{ 0xe98e83e2, 0xad70, 0x43fc, { 0x8e, 0x79, 0xb0, 0x56, 0xb0, 0xf6, 0xff, 0x64 } };

// {E1604E93-B46F-4E6B-8EA3-124E855F506B}
static const GUID CLSID_VC3VEncAboutPage = 
{ 0xe1604e93, 0xb46f, 0x4e6b, { 0x8e, 0xa3, 0x12, 0x4e, 0x85, 0x5f, 0x50, 0x6b } };

// {44E3A4FA-7C18-4BD2-8DE0-354547EDAB9F}
static const GUID CLSID_VC3EncPropPageMain =
{ 0x44e3a4fa, 0x7c18, 0x4bd2, { 0x8d, 0xe0, 0x35, 0x45, 0x47, 0xed, 0xab, 0x9f } };

#endif // RC_INVOKED
////////////////////////////////////////////////////

#endif //__ENC_VC3_GUID_H__
