/********************************************************************
 Created: 2007/05/21 
 File name: mux_dv_guid_demo.h
 Purpose: Demo GUIDs for DV Muxer Filter

 Copyright (c) 2007-2009 MainConcept GmbH. All rights reserved.

 This software is the confidential and proprietary information of
 MainConcept GmbH and may be used only in accordance with the terms of
 your license from MainConcept GmbH.

*********************************************************************/

#ifndef __MUX_DV_GUID_H__
#define __MUX_DV_GUID_H__

#define DV_MUXER_MERIT          (MERIT_DO_NOT_USE-1)

////////////////////////////////////////////////////////////

// {74B02B41-042E-40fe-9F36-64E5CFFF0E01}
static const GUID CLSID_MainConceptDVMuxer = 
{ 0x74b02b41, 0x42e, 0x40fe, { 0x9f, 0x36, 0x64, 0xe5, 0xcf, 0xff, 0xe, 0x1 } };

// {7EFFF560-D503-4f38-BCEB-04C69863F947}
static const GUID CLSID_MCDVMuxerAboutPage = 
{ 0x7efff560, 0xd503, 0x4f38, { 0xbc, 0xeb, 0x4, 0xc6, 0x98, 0x63, 0xf9, 0x47 } };

// {7F023443-FB49-4601-8FE0-EFC48FCA1C87}
static const GUID CLSID_MCDVMuxerPropPage = 
{ 0x7f023443, 0xfb49, 0x4601, { 0x8f, 0xe0, 0xef, 0xc4, 0x8f, 0xca, 0x1c, 0x87 } };

#endif //__MUX_DV_GUID_H__
