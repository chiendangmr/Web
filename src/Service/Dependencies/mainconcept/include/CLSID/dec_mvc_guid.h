/********************************************************************
 Created: 2010/04/08 
 File name: dec_mvc_guid_demo.h
 Purpose: Demo GUIDs for MVC/AVC/H.264 Decoder DS Filter

 Copyright (c) 2003-2010 MainConcept GmbH. All rights reserved.

 This software is the confidential and proprietary information of
 MainConcept GmbH and may be used only in accordance with the terms of
 your license from MainConcept GmbH.

*********************************************************************/

#ifndef __MVCDEC_GUIDS_H__
#define __MVCDEC_GUIDS_H__

////////////////////////////////////////////////////////////

#undef  MVCCOMPANY_HIDEICON

#define MVCCOMPANY_DS_MERIT_DECODER   (MERIT_NORMAL-1)


////////////////////////////////////////////////////////////
#ifndef RC_INVOKED // don't let resource compiler see this part

// {4B3A32C0-EA5C-43E9-80D6-4928A087E2A6}
static const GUID CLSID_MVCVD = 
{ 0x4b3a32c0, 0xea5c, 0x43e9, { 0x80, 0xd6, 0x49, 0x28, 0xa0, 0x87, 0xe2, 0xa6 } };

// {6400D1B9-0344-48F4-99FC-3C7FF360526D}
static const GUID CLSID_MVCVD_SettingsPropertyPage = 
{ 0x6400d1b9, 0x0344, 0x48f4, { 0x99, 0xfc, 0x3c, 0x7f, 0xf3, 0x60, 0x52, 0x6d } };

// {F4CD2F24-B9E5-42A7-B26C-F95F04206584}
static const GUID CLSID_MVCVD_AboutPropertyPage = 
{ 0xf4cd2f24, 0xb9e5, 0x42a7, { 0xb2, 0x6c, 0xf9, 0x5f, 0x4, 0x20, 0x65, 0x84 } };


#endif // RC_INVOKED
////////////////////////////////////////////////////////////


#endif //__MVCDEC_GUIDS_H__


