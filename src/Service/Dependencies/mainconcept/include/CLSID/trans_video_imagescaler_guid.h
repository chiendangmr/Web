/********************************************************************
 Created: 2006/11/15 
 File name: trans_video_imagescaler_guid_demo.h
 Purpose: Demo GUIDs for Image Scaler DS Filter

 Copyright (c) 2005-2009 MainConcept GmbH. All rights reserved.

 This software is the confidential and proprietary information of
 MainConcept GmbH and may be used only in accordance with the terms of
 your license from MainConcept GmbH.

*********************************************************************/

#ifndef __ID_ImageScaler_h__
#define __ID_ImageScaler_h__

////////////////////////////////////////////////////////////

#undef ISCALERCOMPANY_HIDEICON

#define ISCALERCOMPANY_DS_MERIT   (MERIT_UNLIKELY-1)
#define ISCREGISTRY_SETTINGS_KEY		TEXT("Software\\Mainconcept\\") 

////////////////////////////////////////////////////////////
#ifndef RC_INVOKED // don't let resource compiler see this part

// {EDFA3447-C355-4960-986A-CCBCE9B974BE}
static const GUID CLSID_ImageScaler = 
{ 0xedfa3447, 0xc355, 0x4960, { 0x98, 0x6a, 0xcc, 0xbc, 0xe9, 0xb9, 0x74, 0xbe } };

// {3F9C91B4-AEBA-4426-871F-59107807AEB8}
static const GUID CLSID_ImageScalerPPage = 
{ 0x3f9c91b4, 0xaeba, 0x4426, { 0x87, 0x1f, 0x59, 0x10, 0x78, 0x7, 0xae, 0xb8 } };

// {97C06211-BB97-4d4e-A460-36052F26C67B}
static const GUID CLSID_ImageScalerAboutPage = 
{ 0x97c06211, 0xbb97, 0x4d4e, { 0xa4, 0x60, 0x36, 0x5, 0x2f, 0x26, 0xc6, 0x7b } };

#endif //RC_INVOKED

////////////////////////////////////////////////////////////

#endif //__ID_ImageScaler_h__

