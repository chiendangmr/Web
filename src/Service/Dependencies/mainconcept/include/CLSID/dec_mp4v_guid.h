/********************************************************************
 Created: 2006/11/15 
 File name: dec_mpv4_guid_demo.h
 Purpose: Demo GUIDs for MPEG-4 video decoder DS Filter

 Copyright (c) 2005-2008 MainConcept GmbH. All rights reserved.

 This software is the confidential and proprietary information of
 MainConcept GmbH and may be used only in accordance with the terms of
 your license from MainConcept GmbH.

*********************************************************************/

#ifndef __MPEG4DEC_GUID_H__
#define __MPEG4DEC_GUID_H__

////////////////////////////////////////////////////////////

#undef  COMPANY_HIDEICON

#define M4COMPANY_DS_MERIT_DECODER   (MERIT_NORMAL-1)

////////////////////////////////////////////////////////////
#ifndef RC_INVOKED // don't let resource compiler see this part

// {B4FB22A2-3856-4785-85CB-1EBA558E7FAA}
static const GUID CLSID_MPEG4VideoDecoder = 
{ 0xb4fb22a2, 0x3856, 0x4785, { 0x85, 0xcb, 0x1e, 0xba, 0x55, 0x8e, 0x7f, 0xaa } };

// {64FBC089-B802-490f-B297-B9FF27BC49D1}
static const GUID CLSID_MPEG4DecPropPageSettings = 
{ 0x64fbc089, 0xb802, 0x490f, { 0xb2, 0x97, 0xb9, 0xff, 0x27, 0xbc, 0x49, 0xd1 } };

// {5231536B-247B-4f80-8C76-82E8827C4393}
static const GUID CLSID_MPEG4DecPropPageAbout = 
{ 0x5231536b, 0x247b, 0x4f80, { 0x8c, 0x76, 0x82, 0xe8, 0x82, 0x7c, 0x43, 0x93 } };


#endif // RC_INVOKED
////////////////////////////////////////////////////////////

#endif //__MPEG4DEC_GUID_H__


