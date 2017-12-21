/** 
 @file  dec_amr_mc.h
 @brief  Property GUIDs for MainConcept AMR decoder parameters.
 
 @verbatim
 File: dec_amr_mc.h

 Desc: Property GUIDs for MainConcept AMR decoder parameters.
 
 Copyright (c) 2015 MainConcept GmbH or its affiliates.  All rights reserved.

 MainConcept and its logos are registered trademarks of MainConcept GmbH or its affiliates.  
 This software is protected by copyright law and international treaties.  Unauthorized 
 reproduction or distribution of any portion is prohibited by law.
 @endverbatim
 **/
 
#ifndef __AMRDECODER_TYPES_UIDS__
#define __AMRDECODER_TYPES_UIDS__


/**
 * @name TYPES UIDS
 * @{
 **/
 
#ifndef MEDIASUBTYPE_AMR_DEF
#define MEDIASUBTYPE_AMR_DEF
///@brief Media Subtype AMR
// {99C00BDC-3BF1-4889-9873-F1178D3C5679}
static const GUID MEDIASUBTYPE_AMR = 
{ 0x99c00bdc, 0x3bf1, 0x4889, { 0x98, 0x73, 0xf1, 0x17, 0x8d, 0x3c, 0x56, 0x79 } };
#endif

#ifndef MEDIASUBTYPE_AMR_MPEGABLE_DEF
#define MEDIASUBTYPE_AMR_MPEGABLE_DEF

///@brief Media Subtype AMR MPEGABLE
// {CA9A0EDC-38B0-4FA6-B34A-3019543A0C57}
static const GUID MEDIASUBTYPE_AMR_MPEGABLE = 
{ 0xca9a0edc, 0x38b0, 0x4fa6, { 0xb3, 0x4a, 0x30, 0x19, 0x54, 0x3a, 0x0c, 0x57 } };
#endif

///@brief Media Subtype Nero Digital Parser
// {726D6173-0000-0010-8000-00AA00389B71}
static const GUID MEDIASUBTYPE_NERO_DIGITAL_PARSER = 
{ 0x726D6173, 0x0000, 0x0010, { 0x80, 0x00, 0x00, 0xAA, 0x00, 0x38, 0x9B, 0x71 } };

/** @} */
 
///@brief Mutes the output if necessary
// {5CF453D9-7F4C-4b33-AA40-2F3830CBCE50}
static const GUID AMRDEC_Mute = 
{ 0x5cf453d9, 0x7f4c, 0x4b33, { 0xaa, 0x40, 0x2f, 0x38, 0x30, 0xcb, 0xce, 0x50 } };

///@brief Enables/disables transcoding phase shift decreasing feature
// {440E8353-70A2-4bb1-9F38-4444F3836641}
static const GUID AMRDEC_DelayRemoval = 
{ 0x440e8353, 0x70a2, 0x4bb1, { 0x9f, 0x38, 0x44, 0x44, 0xf3, 0x83, 0x66, 0x41 } };

///@brief Specifies output bitstream interface
// {5E1D8BA6-1364-4F69-9AAF-234081AD2F62}
static const GUID AMRDEC_InterfaceFormat = 
{ 0x5e1d8ba6, 0x1364, 0x4f69, { 0x9a, 0xaf, 0x23, 0x40, 0x81, 0xad, 0x2f, 0x62 } };

#endif // #ifndef __AMRDECODER_TYPES_UIDS__