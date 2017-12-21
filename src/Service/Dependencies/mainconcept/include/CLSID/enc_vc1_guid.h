/********************************************************************
 Created: 2006/11/15 
 File name: enc_vc1_guid_demo.h
 Purpose: Demo GUIDs for VC-1 Encoder DS Filter

 Copyright (c) 2005-2009 MainConcept GmbH. All rights reserved.

 This software is the confidential and proprietary information of
 MainConcept GmbH and may be used only in accordance with the terms of
 your license from MainConcept GmbH.
*********************************************************************/

#ifndef __ENC_VC1_GUID_H__
#define __ENC_VC1_GUID_H__

#ifndef MCBUILD_CONSUMER

////////////////////////////////////////////////////////////

#undef  COMPANY_HIDEICON

#define COMPANY_DS_MERIT_VC1ENCODER (MERIT_SW_COMPRESSOR-1)

///////////////////////////////////////////////////////////////
#ifndef RC_INVOKED // don't let resource compiler see this part

// {5C105008-A2D6-431A-9252-1F05EA2F3364}
static const GUID CLSID_VC1VideoEncoder =
{ 0x5c105008, 0xa2d6, 0x431a, {0x92, 0x52, 0x1f, 0x5, 0xea, 0x2f, 0x33, 0x64}};

// {5C19C008-2BE5-4F4F-A0AF-7164C3E54867}
static const GUID CLSID_VC1VideoEncAboutPropertyPage =
{ 0x5c19c008, 0x2be5, 0x4f4f, {0xa0, 0xaf, 0x71, 0x64, 0xc3, 0xe5, 0x48, 0x67}};

// {5C15C008-5D4F-4BB8-833D-E43ED16D1A9D}
static const GUID CLSID_VC1VideoEncMainPropertyPage =
{ 0x5c15c008, 0x5d4f, 0x4bb8, {0x83, 0x3d, 0xe4, 0x3e, 0xd1, 0x6d, 0x1a, 0x9d}};

// {5C1BA008-4773-428E-9F29-3FAB2AB70B6F}
static const GUID CLSID_VC1VideoEncAdvancedPropertyPage =
{ 0x5c1ba008, 0x4773, 0x428e, { 0x9f, 0x29, 0x3f, 0xab, 0x2a, 0xb7, 0xb, 0x6f}};


#endif // RC_INVOKED
////////////////////////////////////////////////////

#else // MCBUILD_CONSUMER

///////////////////////////////////////////////////////////

#undef  COMPANY_HIDEICON

#define COMPANY_DS_MERIT_VC1ENCODER (MERIT_SW_COMPRESSOR-1)

///////////////////////////////////////////////////////////////
#ifndef RC_INVOKED // don't let resource compiler see this part

// {778DF930-8F7B-4267-AB54-6C39742690D0}
static const GUID CLSID_VC1VideoEncoder = 
{ 0x778df930, 0x8f7b, 0x4267, { 0xab, 0x54, 0x6c, 0x39, 0x74, 0x26, 0x90, 0xd0 } };

// {778DF932-8F7B-4267-AB54-6C39742690D0}
static const GUID CLSID_VC1VideoEncAboutPropertyPage = 
{ 0x778df932, 0x8f7b, 0x4267, { 0xab, 0x54, 0x6c, 0x39, 0x74, 0x26, 0x90, 0xd0 } };

// {778DF934-8F7B-4267-AB54-6C39742690D0}
static const GUID CLSID_VC1VideoEncMainPropertyPage = 
{ 0x778df934, 0x8f7b, 0x4267, { 0xab, 0x54, 0x6c, 0x39, 0x74, 0x26, 0x90, 0xd0 } };

// {778DF938-8F7B-4267-AB54-6C39742690D0}
static const GUID CLSID_VC1VideoEncAdvancedPropertyPage = 
{ 0x778df938, 0x8f7b, 0x4267, { 0xab, 0x54, 0x6c, 0x39, 0x74, 0x26, 0x90, 0xd0 } };


#endif // RC_INVOKED
////////////////////////////////////////////////////

#endif // MCBUILD_CONSUMER

#endif //__ENC_VC1_GUID_H__