/********************************************************************
 Created: 2006/11/15 
 File name: net_renderer_guid_demo.h
 Purpose: Demo GUIDs for Network Renderer DS Filter

 Copyright (c) 2005-2009 MainConcept GmbH. All rights reserved.

 This software is the confidential and proprietary information of
 MainConcept GmbH and may be used only in accordance with the terms of
 your license from MainConcept GmbH.

*********************************************************************/

#ifndef __NETRENDERER_GUIDS_H__
#define __NETRENDERER_GUIDS_H__

////////////////////////////////////////////////////////////

#undef  NETRENDERER_COMPANY_HIDEICON

#define NETRENDERER_COMPANY_DS_MERIT    (MERIT_DO_NOT_USE-1)

////////////////////////////////////////////////////////////

#if defined(MC_NET_RENDER_BROADCAST)

// {86B4D81E-5B48-489B-8231-4D09A5E2D9DB}
static const GUID CLSID_MCNetRenderer = 
{ 0x86b4d81e, 0x5b48, 0x489b, { 0x82, 0x31, 0x4d, 0x9, 0xa5, 0xe2, 0xd9, 0xdb } };

// {E545AC77-33E8-41C3-8961-8F2DE87F94D4}
static const GUID CLSID_MCNetRenderer_PropertyPage = 
{ 0xe545ac77, 0x33e8, 0x41c3, { 0x89, 0x61, 0x8f, 0x2d, 0xe8, 0x7f, 0x94, 0xd4 } };

// {307361DD-4116-4042-905C-D622BAC9ABCF}
static const GUID CLSID_MCNetRenderer_AboutPropertyPage = 
{ 0x307361dd, 0x4116, 0x4042, { 0x90, 0x5c, 0xd6, 0x22, 0xba, 0xc9, 0xab, 0xcf } };

// {9CB260D3-B801-4AA9-92B7-61F55F91BEB6}
static const GUID CLSID_MCNetRenderer_InfoPropertyPage = 
{ 0x9cb260d3, 0xb801, 0x4aa9, { 0x92, 0xb7, 0x61, 0xf5, 0x5f, 0x91, 0xbe, 0xb6 } };
#else

// {80003695-B858-4CF5-9E67-1DACA28E702D}
static const GUID CLSID_MCNetRenderer = 
{ 0x80003695, 0xb858, 0x4cf5, { 0x9e, 0x67, 0x1d, 0xac, 0xa2, 0x8e, 0x70, 0x2d } };

// {E8575D50-51E9-4A0D-AA77-45B1C6002AD9}
static const GUID CLSID_MCNetRenderer_PropertyPage = 
{ 0xe8575d50, 0x51e9, 0x4a0d, { 0xaa, 0x77, 0x45, 0xb1, 0xc6, 0x0, 0x2a, 0xd9 } };

// {E497BE2E-CEAD-4E5D-8AE5-93F768B07B8C}
static const GUID CLSID_MCNetRenderer_AboutPropertyPage = 
{ 0xe497be2e, 0xcead, 0x4e5d, { 0x8a, 0xe5, 0x93, 0xf7, 0x68, 0xb0, 0x7b, 0x8c } };

// {E497BE2E-7757-412C-8B34-62A98F1BD6A9}
static const GUID CLSID_MCNetRenderer_InfoPropertyPage = 
{ 0xe497be2e, 0x7757, 0x412c, { 0x8b, 0x34, 0x62, 0xa9, 0x8f, 0x1b, 0xd6, 0xa9 } };
#endif

#endif //__NETRENDERER_GUIDS_H__
