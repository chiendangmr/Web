/********************************************************************
 Created: 2006/11/15 
 File name: enc_mp2v_guid_demo.h
 Purpose: Demo GUIDs for MPEG-2 video encoder DS Filter

 Copyright (c) 2005-2008 MainConcept GmbH. All rights reserved.

 This software is the confidential and proprietary information of
 MainConcept GmbH and may be used only in accordance with the terms of
 your license from MainConcept GmbH.

*********************************************************************/

////////////////////////////////////////////////////////////

#undef  COMPANY_HIDEICON
#undef  STD_EDITION

#define M2VECOMPANY_DS_MERIT    (MERIT_DO_NOT_USE-1)

////////////////////////////////////////////////////////////
#ifndef RC_INVOKED // don't let resource compiler see this part

#ifndef __M2VE_FILTER_GUIDS_H__
#define __M2VE_FILTER_GUIDS_H__

/*****************************************
	Demo-edition Filter GUIDs
*****************************************/

// {E5948F2D-5701-404e-92A6-4D746C94F31C}
static const GUID CLSID_EM2VE = 
	{ 0xe5948f2d, 0x5701, 0x404e, { 0x92, 0xa6, 0x4d, 0x74, 0x6c, 0x94, 0xf3, 0x1c } };

// {45E9A8E4-352D-4b90-9197-C491ECE6C831}
static const GUID CLSID_EM2VE_AboutPropertyPage = 
	{ 0x45e9a8e4, 0x352d, 0x4b90, { 0x91, 0x97, 0xc4, 0x91, 0xec, 0xe6, 0xc8, 0x31 } };

// {3AFEE91D-255D-4eff-B8EA-8BCB6B4AC610}
static const GUID CLSID_EM2VE_MainPropertyPage = 
	{ 0x3afee91d, 0x255d, 0x4eff, { 0xb8, 0xea, 0x8b, 0xcb, 0x6b, 0x4a, 0xc6, 0x10 } };

// {A4BC60A0-E8EA-4f03-913A-14E325B4EEC9}
static const GUID CLSID_EM2VE_AdvancedPropertyPage = 
	{ 0xa4bc60a0, 0xe8ea, 0x4f03, { 0x91, 0x3a, 0x14, 0xe3, 0x25, 0xb4, 0xee, 0xc9 } };

#endif __M2VE_FILTER_GUIDS_H__

#endif // RC_INVOKED

