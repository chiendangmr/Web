/* ----------------------------------------------------------------------------
 * File: mux_mp4_guid_demo.h
 *
 * Desc: Demo GUIDs for MP4 Muxer DS Filter
 *
 * Copyright (c) 2015 MainConcept GmbH or its affiliates.  All rights reserved.
 *
 * MainConcept and its logos are registered trademarks of MainConcept GmbH or its affiliates.  
 * This software is protected by copyright law and international treaties.  Unauthorized 
 * reproduction or distribution of any portion is prohibited by law.
 * ----------------------------------------------------------------------------
 */

#ifndef __MP4MUX_GUID_H__
#define __MP4MUX_GUID_H__

#ifndef MCBUILD_BROADCAST

////////////////////////////////////////////////////////////

#undef  COMPANY_HIDEICON

#define MP4MUXER_FILTER_MERIT 	(MERIT_DO_NOT_USE-1)

///////////////////////////////////////////////////////////////
#ifndef RC_INVOKED // don't let resource compiler see this part

// {B4633EA7-2795-4120-8DB1-55A3B1510B61}
static const GUID CLSID_EMP4Mux = 
{ 0xb4633ea7, 0x2795, 0x4120, { 0x8d, 0xb1, 0x55, 0xa3, 0xb1, 0x51, 0xb, 0x61 } };

// {A7580C5B-4A94-434F-A0E3-BC3429D77009}
static const GUID CLSID_EMP4MuxPropertyPage = 
{ 0xa7580c5b, 0x4a94, 0x434f, { 0xa0, 0xe3, 0xbc, 0x34, 0x29, 0xd7, 0x70, 0x9 } };

// {1D48FC72-A414-4F7D-8D89-6C5D7038AB12}
static const GUID CLSID_EMP4MuxAboutPage = 
{ 0x1d48fc72, 0xa414, 0x4f7d, { 0x8d, 0x89, 0x6c, 0x5d, 0x70, 0x38, 0xab, 0x12 } };

// {96CE47E3-0211-4EE9-B4A3-DD490845E485}
static const GUID CLSID_EMP4MuxAdvancedPropertyPage = 
{ 0x96ce47e3, 0x211, 0x4ee9, { 0xb4, 0xa3, 0xdd, 0x49, 0x8, 0x45, 0xe4, 0x85 } };

#endif // RC_INVOKED
///////////////////////////////////////////////////////////////

#else // MCBUILD_BROADCAST

////////////////////////////////////////////////////////////

#undef  COMPANY_HIDEICON

#define MP4MUXER_FILTER_MERIT 	(MERIT_DO_NOT_USE-1)

///////////////////////////////////////////////////////////////
#ifndef RC_INVOKED // don't let resource compiler see this part

// {8886E2AD-EFFE-42AD-8299-318D049CC5A5}
static const GUID CLSID_EMP4Mux = 
{ 0x8886e2ad, 0xeffe, 0x42ad, { 0x82, 0x99, 0x31, 0x8d, 0x4, 0x9c, 0xc5, 0xa5 } };

// {32E6AAA1-7ECB-4800-815F-21CA6AC63A82}
static const GUID CLSID_EMP4MuxPropertyPage = 
{ 0x32e6aaa1, 0x7ecb, 0x4800, { 0x81, 0x5f, 0x21, 0xca, 0x6a, 0xc6, 0x3a, 0x82 } };

// {E7CA8D6E-9A4A-493B-95CB-3149463D700C}
static const GUID CLSID_EMP4MuxAboutPage = 
{ 0xe7ca8d6e, 0x9a4a, 0x493b, { 0x95, 0xcb, 0x31, 0x49, 0x46, 0x3d, 0x70, 0xc } };

// {708D44A5-9817-4F76-A4FA-A275C4B01D7A}
static const GUID CLSID_EMP4MuxAdvancedPropertyPage = 
{ 0x708d44a5, 0x9817, 0x4f76, { 0xa4, 0xfa, 0xa2, 0x75, 0xc4, 0xb0, 0x1d, 0x7a } };

#endif // RC_INVOKED
///////////////////////////////////////////////////////////////

#endif // MCBUILD_BROADCAST

#endif //__MP4MUX_GUID_H__
