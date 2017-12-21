/********************************************************************
 Created: 2010/04/14
 File name: mux_dmf_guid_demo.h
 Purpose: Demo GUIDs for DMF Muxer DS Filter

 Copyright (c) 2008-2010 MainConcept GmbH. All rights reserved.

 This software is the confidential and proprietary information of
 MainConcept GmbH and may be used only in accordance with the terms of
 your license from MainConcept GmbH.

*********************************************************************/

#ifndef __MUX_DMF_GUID_H__
#define __MUX_DMF_GUID_H__

////////////////////////////////////////////////////////////

#undef  COMPANY_HIDEICON

#define DMFMUXER_FILTER_MERIT   (MERIT_DO_NOT_USE-1)

///////////////////////////////////////////////////////////////
#ifndef RC_INVOKED // don't let resource compiler see this part

// {900C9909-1DE6-469B-AA96-82CED6BC6646}
static const GUID CLSID_DMFMux = 
{ 0x900c9909, 0x1de6, 0x469b, { 0xaa, 0x96, 0x82, 0xce, 0xd6, 0xbc, 0x66, 0x46 } };

// {71472B9B-EB53-4ED0-A805-06A20631E408}
static const GUID CLSID_DMFMuxPropertyPage = 
{ 0x71472b9b, 0xeb53, 0x4ed0, { 0xa8, 0x5, 0x6, 0xa2, 0x6, 0x31, 0xe4, 0x8 } };

// {4BC2FD63-2BA3-4004-9967-264A292EA1B3}
static const GUID CLSID_DMFMuxAboutPage = 
{ 0x4bc2fd63, 0x2ba3, 0x4004, { 0x99, 0x67, 0x26, 0x4a, 0x29, 0x2e, 0xa1, 0xb3 } };

#endif // RC_INVOKED 
///////////////////////////////////////////////////////////////

#endif __MUX_DMF_GUID_H__
