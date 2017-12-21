/**
\file mux_dv_mc.h
\brief Property GUIDs for MainConcept DV muxer parameters.

\verbatim
File: mux_dv_mc.h

Desc: Property GUIDs forMainConcept DV muxer parameters.

 Copyright (c) 2015 MainConcept GmbH or its affiliates.  All rights reserved.

 MainConcept and its logos are registered trademarks of MainConcept GmbH or its affiliates.  
 This software is protected by copyright law and international treaties.  Unauthorized 
 reproduction or distribution of any portion is prohibited by law.
\endverbatim
*/


#if !defined(__PropID_DVMuxer_h__)
#define __PropID_DVMuxer_h__

/**
Setup of sensitivity to jumps of time. See DV Muxer chapter Features for details.
\details <dl><dt><b>  Type: </b></dt><dd> 
VT_UINT </dd></dl>
<dl><dt><b>  Available Values: </b></dt><dd>
Full range
</dd></dl> \hideinitializer */ // {F9EF34A6-23C8-4bf3-9D76-B1F4FD784DF7}
static const GUID DVMuxer_GapThreshold = 
{ 0xf9ef34a6, 0x23c8, 0x4bf3, { 0x9d, 0x76, 0xb1, 0xf4, 0xfd, 0x78, 0x4d, 0xf7 } };

#endif //__PropID_DVMuxer_h__
