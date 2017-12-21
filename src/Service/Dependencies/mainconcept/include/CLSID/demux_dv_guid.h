/********************************************************************
 Created: 2007/05/21 
 File name: demux_dv_guid_demo.h
 Purpose: Demo GUIDs for DV Splitter Filter

 Copyright (c) 2007-2009 MainConcept GmbH. All rights reserved.

 This software is the confidential and proprietary information of
 MainConcept GmbH and may be used only in accordance with the terms of
 your license from MainConcept GmbH.

*********************************************************************/

#ifndef __DEMUX_DV_GUID_H__
#define __DEMUX_DV_GUID_H__

#define DV_SPLITTER_MERIT          (MERIT_PREFERRED)

////////////////////////////////////////////////////////////

// {22FDCEBB-C4B0-4c69-BA1B-0EB3BF0DDDB4}
static const GUID CLSID_MainConceptDVSplitter = 
{ 0x22fdcebb, 0xc4b0, 0x4c69, { 0xba, 0x1b, 0xe, 0xb3, 0xbf, 0xd, 0xdd, 0xb4 } };

// {2DA9F3A2-1780-4c34-89A8-B1E858AEB2D3}
static const GUID CLSID_MCDVSplitterAboutPage = 
{ 0x2da9f3a2, 0x1780, 0x4c34, { 0x89, 0xa8, 0xb1, 0xe8, 0x58, 0xae, 0xb2, 0xd3 } };

// {2E59037A-A9BE-4427-B0B5-4B126ABB7992}
static const GUID CLSID_MCDVSplitterPropPage = 
{ 0x2e59037a, 0xa9be, 0x4427, { 0xb0, 0xb5, 0x4b, 0x12, 0x6a, 0xbb, 0x79, 0x92 } };

#endif //__DEMUX_DV_GUID_H__
