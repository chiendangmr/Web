/********************************************************************
 Created: 2008/08/01
 File name: dec_mjpg_guid_demo.h
 Purpose: Demo GUIDs for MJPEG Decoder DS Filter

 Copyright (c) 2008-2011 MainConcept GmbH. All rights reserved.

 This software is the confidential and proprietary information of
 MainConcept GmbH and may be used only in accordance with the terms of
 your license from MainConcept GmbH.

*********************************************************************/

#ifndef __MJPEGDEC_GUIDS_H__
#define __MJPEGDEC_GUIDS_H__

#define MJPG_DECODER_MERIT (MERIT_NORMAL-1)

// guid base number {9B555E70-EC89-449C-A6B1-85023E50E370}
#define MJPGGB_DW 0x9b555e70
#define MJPGGB_W0 0xec89
#define MJPGGB_W1 0x449c
#define MJPGGB_B0 0xa6
#define MJPGGB_B1 0xb1
#define MJPGGB_B2 0x85
#define MJPGGB_B3 0x02
#define MJPGGB_B4 0x3e
#define MJPGGB_B5 0x50
#define MJPGGB_B6 0xe3
#define MJPGGB_B7 0x70

// {9B555E70-EC89-449C-A6B1-85023E50E370}
static const GUID CLSID_MainConceptMJPGVideoDecoder = 
{ MJPGGB_DW+0x0, MJPGGB_W0, MJPGGB_W1, { MJPGGB_B0, MJPGGB_B1, MJPGGB_B2, MJPGGB_B3, MJPGGB_B4, MJPGGB_B5, MJPGGB_B6, MJPGGB_B7 } };

// {9B555E72-EC89-449C-A6B1-85023E50E370}
static const GUID CLSID_MainConceptMJPGVideoDecoderProp = 
{ MJPGGB_DW+0x2, MJPGGB_W0, MJPGGB_W1, { MJPGGB_B0, MJPGGB_B1, MJPGGB_B2, MJPGGB_B3, MJPGGB_B4, MJPGGB_B5, MJPGGB_B6, MJPGGB_B7 } };

// {9B555E74-EC89-449C-A6B1-85023E50E370}
static const GUID IID_IMCMJPGDecoderFilter = 
{ MJPGGB_DW+0x4, MJPGGB_W0, MJPGGB_W1, { MJPGGB_B0, MJPGGB_B1, MJPGGB_B2, MJPGGB_B3, MJPGGB_B4, MJPGGB_B5, MJPGGB_B6, MJPGGB_B7 } };

#endif // __MJPEGDEC_GUIDS_H__