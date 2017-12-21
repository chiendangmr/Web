/********************************************************************
 Created: 2006/11/15 
 File name: mux_mp2_guid_demo.h
 Purpose: Demo GUIDs for MPEG-2 Multiplexer DS Filter

 Copyright (c) 2005-2008 MainConcept GmbH. All rights reserved.

 This software is the confidential and proprietary information of
 MainConcept GmbH and may be used only in accordance with the terms of
 your license from MainConcept GmbH.

*********************************************************************/

#ifndef __MPG2MUX_GUID_H__
#define __MPG2MUX_GUID_H__

////////////////////////////////////////////////////////////

#undef COMPANY_HIDEICON
#undef STD_EDITION

/*****************************************
	Demo-edition Filter GUIDs
*****************************************/

// {DD01EDDB-8942-4632-A3FB-4E30A59FF8F2}
static const GUID CLSID_EM2Mux = 
{ 0xdd01eddb, 0x8942, 0x4632, { 0xa3, 0xfb, 0x4e, 0x30, 0xa5, 0x9f, 0xf8, 0xf2 } };

// {E7DA8BD0-F06F-4fcc-B636-DF3CB8CF0866}
static const GUID CLSID_EM2Mux_AboutPropertyPage = 
{ 0xe7da8bd0, 0xf06f, 0x4fcc, { 0xb6, 0x36, 0xdf, 0x3c, 0xb8, 0xcf, 0x8, 0x66 } };

// {EE3FA65A-BEFE-4a2a-B03C-AE2BF092BA29}
static const GUID CLSID_EM2Mux_MainPropertyPage = 
{ 0xee3fa65a, 0xbefe, 0x4a2a, { 0xb0, 0x3c, 0xae, 0x2b, 0xf0, 0x92, 0xba, 0x29 } };

#endif // __MPG2MUX_GUID_H__

