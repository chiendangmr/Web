/********************************************************************
 Created: 2006/11/15 
 File name: stream_pump_guid_demo.h
 Purpose: Demo GUIDs for Stream Pump DS Filter

 Copyright (c) 2005-2011 MainConcept GmbH. All rights reserved.

 This software is the confidential and proprietary information of
 MainConcept GmbH and may be used only in accordance with the terms of
 your license from MainConcept GmbH.

*********************************************************************/

#ifndef __STREAMPUMP_GUIDS_H__
#define __STREAMPUMP_GUIDS_H__

////////////////////////////////////////////////////////////

#undef  STREAMPUMP_COMPANY_HIDEICON

#define STREAMPUMP_COMPANY_DS_MERIT    MERIT_DO_NOT_USE

////////////////////////////////////////////////////////////

// {B1A66AB0-ABD3-456C-86E3-2B1B0E05FBBB}
static const GUID CLSID_MCStreamPump = 
{ 0xb1a66ab0, 0xabd3, 0x456c, { 0x86, 0xe3, 0x2b, 0x1b, 0xe, 0x5, 0xfb, 0xbb } };

// {9F1D76A1-6188-4C99-8B71-8F745EE4E9C1}
static const GUID CLSID_MCStreamPump_AboutPropertyPage = 
{ 0x9f1d76a1, 0x6188, 0x4c99, { 0x8b, 0x71, 0x8f, 0x74, 0x5e, 0xe4, 0xe9, 0xc1 } };

// {C331DC8C-6D80-4746-8560-DDA5BB2C4869}
static const GUID CLSID_MCStreamPump_SettingsPropertyPage = 
{ 0xc331dc8c, 0x6d80, 0x4746, { 0x85, 0x60, 0xdd, 0xa5, 0xbb, 0x2c, 0x48, 0x69 } };

#endif //__STREAMPUMP_GUIDS_H__
