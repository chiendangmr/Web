/********************************************************************
 Created: 2006/11/15 
 File name: enc_j2k_guid_demo.h
 Purpose: Demo GUIDs for MJPEG-2000 video encoder DS Filter

 Copyright (c) 2005-2010 MainConcept GmbH. All rights reserved.

 This software is the confidential and proprietary information of
 MainConcept GmbH and may be used only in accordance with the terms of
 your license from MainConcept GmbH.

*********************************************************************/

#define MJECOMPANY_DS_MERIT   (MERIT_DO_NOT_USE-1)
#undef	MJECOMPANY_HIDEICON

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


// {BCB97381-D9CA-47D5-A28D-7C7CF82FCD54}
static const GUID CLSID_MainConceptMJ2_VideoEncoder = 
{ MJ2_GB_DW+0x1, MJ2_GB_W0, MJ2_GB_W1, { MJ2_GB_B0, MJ2_GB_B1, MJ2_GB_B2, MJ2_GB_B3, MJ2_GB_B4, MJ2_GB_B5, MJ2_GB_B6, MJ2_GB_B7 } };

// {BCB97383-D9CA-47D5-A28D-7C7CF82FCD54}
static const GUID CLSID_MainConceptMJ2_VideoEncoderProp = 
{ MJ2_GB_DW+0x3, MJ2_GB_W0, MJ2_GB_W1, { MJ2_GB_B0, MJ2_GB_B1, MJ2_GB_B2, MJ2_GB_B3, MJ2_GB_B4, MJ2_GB_B5, MJ2_GB_B6, MJ2_GB_B7 } };

// {BCB97385-D9CA-47D5-A28D-7C7CF82FCD54}
static const GUID IID_IMCMJ2_EncoderFilter = 
{ MJ2_GB_DW+0x5, MJ2_GB_W0, MJ2_GB_W1, { MJ2_GB_B0, MJ2_GB_B1, MJ2_GB_B2, MJ2_GB_B3, MJ2_GB_B4, MJ2_GB_B5, MJ2_GB_B6, MJ2_GB_B7 } };

// {9CDD11E3-C19F-4207-A180-07EC14EC40DC}
static const GUID CLSID_MainConceptMJ2_EncPropAbout = 
{ 0x9cdd11e3, 0xc19f, 0x4207, { 0xa1, 0x80, 0x7, 0xec, 0x14, 0xec, 0x40, 0xdc } };
