/**
\file demux_dv_mc.h
\brief Property GUIDs for MainConcept DV demuxer parameters.

\verbatim
File: demux_dv_mc.h

Desc: Property GUIDs forMainConcept DV demuxer parameters.

 Copyright (c) 2015 MainConcept GmbH or its affiliates.  All rights reserved.

 MainConcept and its logos are registered trademarks of MainConcept GmbH or its affiliates.  
 This software is protected by copyright law and international treaties.  Unauthorized 
 reproduction or distribution of any portion is prohibited by law.
\endverbatim
*/


#if !defined(__PropID_DVSplitter_h__)
#define __PropID_DVSplitter_h__


/**
Enable/disable Dynamic format change on Audio output pin.
\details <dl><dt><b>  Type: </b></dt><dd> 
VT_UINT </dd></dl>
<dl><dt><b>  Available Values: </b></dt><dd>
0 - Disable dynamic format change. <br>
1 - Enable dynamic format change.
</dd></dl> \hideinitializer */ // {0016CE58-2BF9-4899-8B7E-0E50C0CB9C94}
static const GUID DVSplitter_DynFormatChange = 
{ 0x16ce58, 0x2bf9, 0x4899, { 0x8b, 0x7e, 0xe, 0x50, 0xc0, 0xcb, 0x9c, 0x94 } };

/**
Mask of channels available in input stream. For each available channel an adequate bit is set. LSB is first channel MSB last oneMask of channels available in input stream. For each available channel an adequate bit is set. LSB is first channel MSB last one.
\details <dl><dt><b>  Type: </b></dt><dd> 
VT_UINT </dd></dl>
<dl><dt><b>  Available Values: </b></dt><dd>
Read-only
</dd></dl> \hideinitializer */ // {9CFEB48F-0E40-437c-8BEE-2B5B9AB5B21D}
static const GUID DVSplitter_AvailableChannelsMask = 
{ 0x9cfeb48f, 0xe40, 0x437c, { 0x8b, 0xee, 0x2b, 0x5b, 0x9a, 0xb5, 0xb2, 0x1d } };

/**
Select channel to demux. For each channels to demux appropriate bit is set. At least one channel should be selected.
\details <dl><dt><b>  Type: </b></dt><dd> 
VT_UINT </dd></dl>
<dl><dt><b>  Available Values: </b></dt><dd>
0 – 255
</dd></dl> \hideinitializer */ // {09D3D818-CB1C-4dea-97E8-FA3C8FECDEB4}
static const GUID DVSplitter_DemuxChannelsMask = 
{ 0x9d3d818, 0xcb1c, 0x4dea, { 0x97, 0xe8, 0xfa, 0x3c, 0x8f, 0xec, 0xde, 0xb4 } };


#endif //__PropID_DVSplitter_h__
