/********************************************************************
 Created: 2006/11/15 
 File name: dec_vc1_guid_demo.h
 Purpose: Demo GUIDs for VC-1 Decoder DS Filter

 Copyright (c) 2005-2009 MainConcept GmbH. All rights reserved.

 This software is the confidential and proprietary information of
 MainConcept GmbH and may be used only in accordance with the terms of
 your license from MainConcept GmbH.
*********************************************************************/

#ifndef __DEC_VC1_GUID_H__
#define __DEC_VC1_GUID_H__

#ifndef MCBUILD_CONSUMER

////////////////////////////////////////////////////////////

#undef  COMPANY_HIDEICON

#define COMPANY_DS_MERIT_VC1DECODER (MERIT_NORMAL-1)

///////////////////////////////////////////////////////////////
#ifndef RC_INVOKED // don't let resource compiler see this part

// {837DFB21-869A-11DB-96AC-00E08161165F}
static const GUID CLSID_VC1DecoderFilter = 
{ 0x837dfb21, 0x869a, 0x11db, { 0x96, 0xac, 0x0, 0xe0, 0x81, 0x61, 0x16, 0x5f } };

// {837DFB22-869A-11DB-96AC-00E08161165F}
static const GUID CLSID_VC1AnalyzerDecoder = 
{ 0x837dfb22, 0x869a, 0x11db, { 0x96, 0xac, 0x0, 0xe0, 0x81, 0x61, 0x16, 0x5f } };

// {837DFB23-869A-11DB-96AC-00E08161165F}
static const GUID CLSID_VC1Decoder_PropertyPageAbout = 
{ 0x837dfb23, 0x869a, 0x11db, { 0x96, 0xac, 0x0, 0xe0, 0x81, 0x61, 0x16, 0x5f } };

// {837DFB24-869A-11DB-96AC-00E08161165F}
static const GUID CLSID_VC1Decoder_PropertyPage = 
{ 0x837dfb24, 0x869a, 0x11db, { 0x96, 0xac, 0x0, 0xe0, 0x81, 0x61, 0x16, 0x5f } };


#endif // RC_INVOKED
////////////////////////////////////////////////////


#else


/********************************************************************
 Created: 2007/05/11 
 File name: dec_vc1_guid_demo_consumer.h
 Purpose: Demo Consumer GUIDs for VC-1 Decoder DS Filter

 Copyright (c) 2005-2009 MainConcept GmbH. All rights reserved.

 This software is the confidential and proprietary information of
 MainConcept GmbH and may be used only in accordance with the terms of
 your license from MainConcept GmbH.
*********************************************************************/

////////////////////////////////////////////////////////////

#undef  COMPANY_HIDEICON

#define COMPANY_DS_MERIT_VC1DECODER (MERIT_NORMAL-1)

///////////////////////////////////////////////////////////////
#ifndef RC_INVOKED // don't let resource compiler see this part

// {E0DEA4D2-66CA-48a2-9249-3A76335F67A0}
static const GUID CLSID_VC1DecoderFilter = 
{ 0xe0dea4d2, 0x66ca, 0x48a2, { 0x92, 0x49, 0x3a, 0x76, 0x33, 0x5f, 0x67, 0xa0 } };

// {E0DEA4D4-66CA-48a2-9249-3A76335F67A0}
static const GUID CLSID_VC1AnalyzerDecoder = 
{ 0xe0dea4d4, 0x66ca, 0x48a2, { 0x92, 0x49, 0x3a, 0x76, 0x33, 0x5f, 0x67, 0xa0 } };

// {E0DEA4D8-66CA-48a2-9249-3A76335F67A0}
static const GUID CLSID_VC1Decoder_PropertyPageAbout = 
{ 0xe0dea4d8, 0x66ca, 0x48a2, { 0x92, 0x49, 0x3a, 0x76, 0x33, 0x5f, 0x67, 0xa0 } };

// {E0DEA4DA-66CA-48a2-9249-3A76335F67A0}
static const GUID CLSID_VC1Decoder_PropertyPage = 
{ 0xe0dea4da, 0x66ca, 0x48a2, { 0x92, 0x49, 0x3a, 0x76, 0x33, 0x5f, 0x67, 0xa0 } };


#endif // RC_INVOKED
////////////////////////////////////////////////////


#endif

#endif //__DEC_VC1_GUID_H__

