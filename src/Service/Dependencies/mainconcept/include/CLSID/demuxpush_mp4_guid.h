/********************************************************************
 Created: 2006/11/15 
 File name: demuxpush_mp4_guid_demo.h
 Purpose: Demo GUIDs for MP4 Demuxer DS Filter

 Copyright (c) 2005-2008 MainConcept GmbH. All rights reserved.

 This software is the confidential and proprietary information of
 MainConcept GmbH and may be used only in accordance with the terms of
 your license from MainConcept GmbH.

*********************************************************************/

#ifndef __MP4DEMUXPUSH_GUID_H__
#define __MP4DEMUXPUSH_GUID_H__


////////////////////////////////////////////////////////////

#undef  COMPANY_HIDEICON

#define MP4DEMUXERPUSH_FILTER_MERIT   (MERIT_DO_NOT_USE)

///////////////////////////////////////////////////////////////
#ifndef RC_INVOKED // don't let resource compiler see this part

// {C58673A3-646B-4BD6-BD34-4AEC2698C82D}
static const GUID CLSID_EMP4DemuxPush = 
{ 0xc58673a3, 0x646b, 0x4bd6, { 0xbd, 0x34, 0x4a, 0xec, 0x26, 0x98, 0xc8, 0x2d } };

// {7971B851-9AC3-4DE6-B871-F105A7C4CC02}
static const GUID CLSID_EMP4DemuxPushOutputPin = 
{ 0x7971b851, 0x9ac3, 0x4de6, { 0xb8, 0x71, 0xf1, 0x5, 0xa7, 0xc4, 0xcc, 0x2 } };

// {6A53ACE0-D709-4327-9BCC-B4E8A66B5C68}
static const GUID CLSID_EMP4DemuxPush_PropertyPage = 
{ 0x6a53ace0, 0xd709, 0x4327, { 0x9b, 0xcc, 0xb4, 0xe8, 0xa6, 0x6b, 0x5c, 0x68 } };

// {358EB0F5-AB25-4345-8C71-C69B7137CE3B}
static const GUID CLSID_EMP4DemuxPush_AboutPropertyPage = 
{ 0x358eb0f5, 0xab25, 0x4345, { 0x8c, 0x71, 0xc6, 0x9b, 0x71, 0x37, 0xce, 0x3b } };

#endif // RC_INVOKED 
///////////////////////////////////////////////////////////////

#endif __MP4DEMUXPUSH_GUID_H__
