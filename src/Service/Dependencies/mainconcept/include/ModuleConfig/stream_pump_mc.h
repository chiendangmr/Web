/**
@file stream_pump_mc.h
@brief Property GUIDs for MainConcept Stream Pump parameters.

@verbatim
 File: stream_pump_mc.h
 
 Desc: Property GUIDs for MainConcept Stream Pump parameters.
 
 Copyright (c) 2014 MainConcept GmbH or its affiliates.  All rights reserved.

 MainConcept and its logos are registered trademarks of MainConcept GmbH or its affiliates.
 This software is protected by copyright law and international treaties.  Unauthorized
 reproduction or distribution of any portion is prohibited by law.
@endverbatim
*/

#if !defined(__STREAM_PUMP_PROPID_HEADER__)
#define __STREAM_PUMP_PROPID_HEADER__

/**
@var MCSP_LoopPlayback		  
@brief Enable loop playback of given file
@details  

<dl><dt>Type         : </dt>    <dd>VT_BOOL		</dd></dl>      
<dl><dt>Available range	: </dt>	        <dd>TRUE, FALSE  		</dd></dl>      
<dl><dt>Default value: </dt>         <dd>    FALSE				</dd></dl>     
@hideinitializer
*/
static const GUID MCSP_LoopPlayback = { 0x4b2b6cc4, 0x1b8f, 0x45b2, { 0x94, 0xb9, 0xfc, 0x5c, 0x3a, 0x2f, 0x9, 0x8c } };

#endif //__STREAM_PUMP_PROPID_HEADER__
