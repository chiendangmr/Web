/********************************************************************
 Created: 2008/10/01 
 File name: dec_vc3_guid_demo.h
 Purpose: Demo GUIDs for VC-3 Decoder DS Filter

 Copyright (c) 2005-2009 MainConcept GmbH. All rights reserved.

 This software is the confidential and proprietary information of
 MainConcept GmbH and may be used only in accordance with the terms of
 your license from MainConcept GmbH.
*********************************************************************/

#ifndef __DEC_VC3_GUID_H__
#define __DEC_VC3_GUID_H__

////////////////////////////////////////////////////////////

#undef  COMPANY_HIDEICON

#define COMPANY_DS_MERIT_VC3DECODER (MERIT_NORMAL-1)

///////////////////////////////////////////////////////////////
#ifndef RC_INVOKED // don't let resource compiler see this part

// {D8DDD6E8-5792-4ECA-8DE2-D0D143D59859}
static const GUID CLSID_VC3VideoDecoder = 
{ 0xd8ddd6e8, 0x5792, 0x4eca, { 0x8d, 0xe2, 0xd0, 0xd1, 0x43, 0xd5, 0x98, 0x59 } };

// {FC22566F-19A2-49F2-ACD7-CADE1BF9AFC9}
static const GUID CLSID_VC3DecPropPageAbout = 
{ 0xfc22566f, 0x19a2, 0x49f2, { 0xac, 0xd7, 0xca, 0xde, 0x1b, 0xf9, 0xaf, 0xc9 } };

// {B6E435D8-F82C-44F3-BF16-5C96830B6B2E}
static const GUID CLSID_VC3DecPropPageSettings = 
{ 0xb6e435d8, 0xf82c, 0x44f3, { 0xbf, 0x16, 0x5c, 0x96, 0x83, 0xb, 0x6b, 0x2e } };

#endif // RC_INVOKED
////////////////////////////////////////////////////

#endif //__DEC_VC3_GUID_H__
