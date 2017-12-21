/********************************************************************
 Created: 2006/11/15 
 File name: enc_mpa_guid_demo.h
 Purpose: Demo GUIDs for MPEG Layer2 audio encoder DS Filter

 Copyright (c) 2005-2008 MainConcept GmbH. All rights reserved.

 This software is the confidential and proprietary information of
 MainConcept GmbH and may be used only in accordance with the terms of
 your license from MainConcept GmbH.

*********************************************************************/

////////////////////////////////////////////////////////////

#undef  COMPANY_HIDEICON

#define L2AECOMPANY_DS_MERIT   (MERIT_SW_COMPRESSOR-1)

////////////////////////////////////////////////////////////
#ifndef RC_INVOKED // don't let resource compiler see this part

#if !defined(L2_ENCODER_GUID)
#define L2_ENCODER_GUID

// {4017B706-7E3E-4cd2-93CB-31F366822D7B}
static const GUID CLSID_EL2AudioEncoder = 
{ 0x4017b706, 0x7e3e, 0x4cd2, { 0x93, 0xcb, 0x31, 0xf3, 0x66, 0x82, 0x2d, 0x7b } };

// {0D88E159-5EBC-4f77-9F81-309BBC9C528C}
static const GUID CLSID_EL2AudioEncoder_About = 
{ 0xd88e159, 0x5ebc, 0x4f77, { 0x9f, 0x81, 0x30, 0x9b, 0xbc, 0x9c, 0x52, 0x8c } };

// {11EA8C27-B335-4951-8231-044978819B0C}
static const GUID CLSID_EL2AudioEncoder_PropertyPageSettings = 
{ 0x11ea8c27, 0xb335, 0x4951, { 0x82, 0x31, 0x4, 0x49, 0x78, 0x81, 0x9b, 0xc } };

#endif // L2_ENCODER_GUID
#endif // RC_INVOKED
