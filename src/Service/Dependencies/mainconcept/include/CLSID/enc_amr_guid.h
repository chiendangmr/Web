/********************************************************************
 Created: 2006/11/15 
 File name: enc_amr_guid_demo.h
 Purpose: Demo GUIDs for AMR Encoder DS Filter

 Copyright (c) 2005-2008 MainConcept GmbH. All rights reserved.

 This software is the confidential and proprietary information of
 MainConcept GmbH and may be used only in accordance with the terms of
 your license from MainConcept GmbH.

*********************************************************************/

#ifndef __AMRENC_GUID_H__
#define __AMRENC_GUID_H__


#undef COMPANY_HIDEICON

#define AMRCOMPANY_DS_MERIT_ENCODER   (MERIT_DO_NOT_USE-1)


///////////////////////////////////////////////////////////////
#ifndef RC_INVOKED // don't let resource compiler see this part


// {2FC69D60-52B8-444D-8353-EB5AC03876A6}
static const GUID CLSID_AMRAudioEncoder = 
{ 0x2fc69d60, 0x52b8, 0x444d, { 0x83, 0x53, 0xeb, 0x5a, 0xc0, 0x38, 0x76, 0xa6 } };

// {D585D06F-FD1D-4ED0-8AB7-DBBB899D3E68}
static const GUID CLSID_AMRAudioEncoderAboutPage =
{ 0xd585d06f, 0xfd1d, 0x4ed0, { 0x8a, 0xb7, 0xdb, 0xbb, 0x89, 0x9d, 0x3e, 0x68 } };

// {9A6DE136-72F5-42AE-880B-A7162F2A3AD7}
static const GUID CLSID_AMRAudioEncoderMainPropPage =
{ 0x9a6de136, 0x72f5, 0x42ae, { 0x88, 0xb, 0xa7, 0x16, 0x2f, 0x2a, 0x3a, 0xd7 } };

#endif // RC_INVOKED
///////////////////////////////////////////////////////////////

#endif //__AMRENC_GUID_H__

