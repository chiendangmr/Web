/********************************************************************
 Created: 2006/11/15 
 File name: dec_j2k_guid_demo.h
 Purpose: Demo GUIDs for JPEG-2000 video decoder DS Filter

 Copyright (c) 2005-2010 MainConcept GmbH. All rights reserved.

 This software is the confidential and proprietary information of
 MainConcept GmbH and may be used only in accordance with the terms of
 your license from MainConcept GmbH.

*********************************************************************/

#define MJ2DCOMPANY_DS_MERIT   MERIT_UNLIKELY
#undef	MJ2DCOMPANY_HIDEICON

// guid base number {BCB97380-D9CA-47D5-A28D-7C7CF82FCD54}
#define MJ2_GB_DW 0xBCB97380
#define MJ2_GB_W0 0xD9CA
#define MJ2_GB_W1 0x47D5
#define MJ2_GB_B0 0xA2
#define MJ2_GB_B1 0x8D
#define MJ2_GB_B2 0x7C
#define MJ2_GB_B3 0x7C
#define MJ2_GB_B4 0xF8
#define MJ2_GB_B5 0x2F
#define MJ2_GB_B6 0xCD
#define MJ2_GB_B7 0x54


// {BCB97380-D9CA-47D5-A28D-7C7CF82FCD54}
static const GUID CLSID_MainConceptMJ2_VideoDecoder = 
{ MJ2_GB_DW+0x0, MJ2_GB_W0, MJ2_GB_W1, { MJ2_GB_B0, MJ2_GB_B1, MJ2_GB_B2, MJ2_GB_B3, MJ2_GB_B4, MJ2_GB_B5, MJ2_GB_B6, MJ2_GB_B7 } };

// {BCB97382-D9CA-47D5-A28D-7C7CF82FCD54}
static const GUID CLSID_MainConceptMJ2_VideoDecoderProp = 
{ MJ2_GB_DW+0x2, MJ2_GB_W0, MJ2_GB_W1, { MJ2_GB_B0, MJ2_GB_B1, MJ2_GB_B2, MJ2_GB_B3, MJ2_GB_B4, MJ2_GB_B5, MJ2_GB_B6, MJ2_GB_B7 } };

// {BCB9738C-D9CA-47D5-A28D-7C7CF82FCD54}
static const GUID CLSID_MainConceptMJ2_VideoDecoderAdvProp = 
{ MJ2_GB_DW+0xC, MJ2_GB_W0, MJ2_GB_W1, { MJ2_GB_B0, MJ2_GB_B1, MJ2_GB_B2, MJ2_GB_B3, MJ2_GB_B4, MJ2_GB_B5, MJ2_GB_B6, MJ2_GB_B7 } };

// {BCB97384-D9CA-47D5-A28D-7C7CF82FCD54}
static const GUID IID_IMCMJ2_DecoderFilter = 
{ MJ2_GB_DW+0x4, MJ2_GB_W0, MJ2_GB_W1, { MJ2_GB_B0, MJ2_GB_B1, MJ2_GB_B2, MJ2_GB_B3, MJ2_GB_B4, MJ2_GB_B5, MJ2_GB_B6, MJ2_GB_B7 } };

// {2A023603-27B7-44D2-8523-91829841E52E}
static const GUID CLSID_MainConceptMJ2_DecPropPageAbout = 
{ 0x2a023603, 0x27b7, 0x44d2, { 0x85, 0x23, 0x91, 0x82, 0x98, 0x41, 0xe5, 0x2e } };
