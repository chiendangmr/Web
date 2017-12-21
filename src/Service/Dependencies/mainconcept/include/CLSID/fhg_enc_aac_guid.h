/********************************************************************
 Created: 2013/03/12 
 File name: fhg_enc_aac_guid_demo.h
 Purpose: Demo GUIDs for Fraunhofer AAC Encoder DS Filter

 Copyright (c) 2015 MainConcept GmbH or its affiliates.  All rights reserved.

 MainConcept and its logos are registered trademarks of MainConcept GmbH or its affiliates.  
 This software is protected by copyright law and international treaties.  Unauthorized 
 reproduction or distribution of any portion is prohibited by law.

*********************************************************************/

#ifndef __FHGAACENC_GUID_H__
#define __FHGAACENC_GUID_H__


////////////////////////////////////////////////////////////

#undef  COMPANY_HIDEICON

#define COMPANY_DS_MERIT_FHGAACENCODER (MERIT_SW_COMPRESSOR-1)


///////////////////////////////////////////////////////////////
#ifndef RC_INVOKED // don't let resource compiler see this part

// {EDE34AF1-C4BE-472B-8135-012142326CA5}
static const GUID CLSID_FHGAACEncoder = 
{ 0xede34af1, 0xc4be, 0x472b, { 0x81, 0x35, 0x1, 0x21, 0x42, 0x32, 0x6c, 0xa5 } };

// {215E2B0A-E063-472E-AA21-059C742A724F}
static const GUID CLSID_FHGAACEncoderPropPageSettings = 
{ 0x215e2b0a, 0xe063, 0x472e, { 0xaa, 0x21, 0x5, 0x9c, 0x74, 0x2a, 0x72, 0x4f } };

// {832958D6-35DC-44B7-89AE-1CED26079C0E}
static const GUID CLSID_FHGAACEncoderPropPageAbout = 
{ 0x832958d6, 0x35dc, 0x44b7, { 0x89, 0xae, 0x1c, 0xed, 0x26, 0x7, 0x9c, 0xe } };

#endif // RC_INVOKED
////////////////////////////////////////////////////

#endif //__FHGAACENC_GUID_H__


