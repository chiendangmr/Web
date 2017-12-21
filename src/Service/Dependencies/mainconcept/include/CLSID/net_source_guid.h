/********************************************************************
 Created: 2006/11/15 
 File name: net_source_guid_demo.h
 Purpose: Demo GUIDs for Network Source DS Filter

 Copyright (c) 2005-2009 MainConcept GmbH. All rights reserved.

 This software is the confidential and proprietary information of
 MainConcept GmbH and may be used only in accordance with the terms of
 your license from MainConcept GmbH.

*********************************************************************/

#ifndef __NETSOURCE_GUIDS_H__
#define __NETSOURCE_GUIDS_H__

////////////////////////////////////////////////////////////

#undef  NETSOURCE_COMPANY_HIDEICON

#define NETSOURCE_COMPANY_DS_MERIT    (MERIT_DO_NOT_USE-1)

////////////////////////////////////////////////////////////

#if defined(MC_NET_SOURCE_BROADCAST)

// {F79EBFEC-AAE0-4F0D-8166-F1309E94338D}
static const GUID CLSID_NetworkSource = 
{ 0xf79ebfec, 0xaae0, 0x4f0d, { 0x81, 0x66, 0xf1, 0x30, 0x9e, 0x94, 0x33, 0x8d } };

// {DE5465FD-50A5-42DD-A89C-E03F6A03643C}
static const GUID CLSID_NetworkSourcePropPage_Announcemets = 
{ 0xde5465fd, 0x50a5, 0x42dd, { 0xa8, 0x9c, 0xe0, 0x3f, 0x6a, 0x3, 0x64, 0x3c } };

// {AD5E596D-91C3-4CA0-97EB-B83FF0273C64}
static const GUID CLSID_NetworkSourcePropPage_SDP_URI = 
{ 0xad5e596d, 0x91c3, 0x4ca0, { 0x97, 0xeb, 0xb8, 0x3f, 0xf0, 0x27, 0x3c, 0x64 } };

// {83FBA875-6557-4B29-B77F-085DB0E7A613}
static const GUID CLSID_NetworkSourcePropPage_UPNP = 
{ 0x83fba875, 0x6557, 0x4b29, { 0xb7, 0x7f, 0x8, 0x5d, 0xb0, 0xe7, 0xa6, 0x13 } };

// {F6C4B536-815A-46B6-8268-4B04F8404F3F}
static const GUID CLSID_NetworkSourcePropPage_About = 
{ 0xf6c4b536, 0x815a, 0x46b6, { 0x82, 0x68, 0x4b, 0x4, 0xf8, 0x40, 0x4f, 0x3f } };

// {9722AAF5-001F-4A1A-9E11-30C36DFED2B7}
static const GUID CLSID_NetworkSourcePropertyPage_Settings = 
{ 0x9722aaf5, 0x001f, 0x4a1a, { 0x9e, 0x11, 0x30, 0xc3, 0x6d, 0xfe, 0xd2, 0xb7 } };

// {D157A12C-6B5C-480E-9DB6-71E65BBA64D2}
static const GUID CLSID_NetworkSourcePropPage_NetQualityInfo = 
{ 0xd157a12c, 0x6b5c, 0x480e, { 0x9d, 0xb6, 0x71, 0xe6, 0x5b, 0xba, 0x64, 0xd2 } };

// {ADE1CFAE-9BA8-4937-8CE3-60C3EAF1776B}
static const GUID CLSID_NetworkSourcePin = 
{ 0xade1cfae, 0x9ba8, 0x4937, { 0x8c, 0xe3, 0x60, 0xc3, 0xea, 0xf1, 0x77, 0x6b } };

#else

// {2236CBF6-B0B4-439D-8161-9F7103FDEBB6}
static const GUID CLSID_NetworkSource = 
{ 0x2236cbf6, 0xb0b4, 0x439d, { 0x81, 0x61, 0x9f, 0x71, 0x3, 0xfd, 0xeb, 0xb6 } };

// {BB082378-0069-4346-A62E-089778D191A5}
static const GUID CLSID_NetworkSourcePropPage_Announcemets = 
{ 0xbb082378, 0x0069, 0x4346, { 0xa6, 0x2e, 0x8, 0x97, 0x78, 0xd1, 0x91, 0xa5 } };

// {ABA04F9D-4293-478D-B986-8025295080D3}
static const GUID CLSID_NetworkSourcePropPage_SDP_URI = 
{ 0xaba04f9d, 0x4293, 0x478d, { 0xb9, 0x86, 0x80, 0x25, 0x29, 0x50, 0x80, 0xd3 } };

// {75E716F1-24E3-4971-A2CD-413AF780916A}
static const GUID CLSID_NetworkSourcePropPage_About = 
{ 0x75e716f1, 0x24e3, 0x4971, { 0xa2, 0xcd, 0x41, 0x3a, 0xf7, 0x80, 0x91, 0x6a } };

// {E60A7F1A-8C2B-4EBA-A000-CB472FAE2270}
static const GUID CLSID_NetworkSourcePropertyPage_Settings = 
{ 0xe60a7f1a, 0x8c2b, 0x4eba, { 0xa0, 0x0, 0xcb, 0x47, 0x2f, 0xae, 0x22, 0x70 } };

// {FD968CCD-E4BB-443E-AEB1-CD156D249764}
static const GUID CLSID_NetworkSourcePropPage_NetQualityInfo = 
{ 0xfd968ccd, 0xe4bb, 0x443e, { 0xae, 0xb1, 0xcd, 0x15, 0x6d, 0x24, 0x97, 0x64 } };

// {7EDF8EF1-9846-46FD-ABFA-F65D040D883E}
static const GUID CLSID_NetworkSourcePin = 
{ 0x7edf8ef1, 0x9846, 0x46fd, { 0xab, 0xfa, 0xf6, 0x5d, 0x4, 0xd, 0x88, 0x3e } };


#endif

#endif //__NETSOURCE_GUIDS_H__
