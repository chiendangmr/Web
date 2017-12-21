/********************************************************************
Created: 2008/06/03 
File name: mux_mxf_guid_demo.h
Purpose: GUIDs for MXF Muxer Demo version

Copyright (c) 2007-2011 MainConcept GmbH. All rights reserved.

This software is the confidential and proprietary information of
MainConcept GmbH and may be used only in accordance with the terms of
your license from MainConcept GmbH.

*********************************************************************/

#ifndef _mxfmux_guid_h_
#define _mxfmux_guid_h_

#define MXFMUXER_FILTER_MERIT	MERIT_DO_NOT_USE

// {CEAC810E-594C-405C-87C3-23736F7AE274}
static const GUID CLSID_MainConceptMXFMuxer =  
{ 0xceac810e, 0x594c, 0x405c, { 0x87, 0xc3, 0x23, 0x73, 0x6f, 0x7a, 0xe2, 0x74 } };

// {88E47825-B27F-4626-92A8-0A74E3139C8D}
static const GUID CLSID_MainConceptMXFMuxer_AboutPage = 
{ 0x88e47825, 0xb27f, 0x4626, { 0x92, 0xa8, 0xa, 0x74, 0xe3, 0x13, 0x9c, 0x8d } };

// {983F0138-E6A4-4E38-A03A-61F2F364430B}
static const GUID CLSID_MainConceptMXFMuxer_PropertyPage = 
{ 0x983f0138, 0xe6a4, 0x4e38, { 0xa0, 0x3a, 0x61, 0xf2, 0xf3, 0x64, 0x43, 0xb } };

#endif // _mxfmux_guid_h_