/********************************************************************
 Created: 2002/02/22
 File name: dec_dv_guid_demo.h
 Purpose: Demo GUIDs for DV DS Decoder Filter

 Copyright (c) 2000-2011 MainConcept GmbH. All rights reserved.

 This software is the confidential and proprietary information of
 MainConcept GmbH and may be used only in accordance with the terms of
 your license from MainConcept GmbH.

*********************************************************************/

#ifndef __DEC_DV_GUID_H__
#define __DEC_DV_GUID_H__

#if defined (MCGUID_DVDEC_DVCPRO100)

/********************************************************************
 Created: 2002/02/22
 File name: dec_dv100_guid_demo.h
 Purpose: Demo GUIDs for DVCProHD DS Decoder Filter

 Copyright (c) 2000-2011 MainConcept GmbH. All rights reserved.

 This software is the confidential and proprietary information of
 MainConcept GmbH and may be used only in accordance with the terms of
 your license from MainConcept GmbH.

*********************************************************************/

#define DV_DECODER_MERIT          (MERIT_NORMAL-1)

#define COMPANY_DVDECODERFILTER_NAME         "demo_dec_dv100_ds.ax"
#define COMPANY_DVDECODERFILTER_INTERNALNAME "demo_dec_dv100_ds"
#define COMPANY_DVDECODERFILTER_DESCRIPTION  "DirectShow DVCProHD Video Decoder Demo"
#define COMPANY_DVDECODERFILTER_PRODUCTNAME  COMPANY_SHORTNAME "\256 DVCProHD Video Decoder Demo"

#define DVCPRO100_SUPPORT
#define DVCPRO50_SUPPORT
#define CANOPUS_SUPPORT

// {9A84F1E8-2659-4A45-AC66-CEDE0A15241F}
static const GUID CLSID_MainConceptDVVideoDecoder =
{ 0x9A84F1E8, 0x2659, 0x4a45, { 0xac, 0x66, 0xce, 0xde, 0x0a, 0x15, 0x24, 0x1f } };

// {9A84F1EA-2659-4A45-AC66-CEDE0A15241F}
static const GUID CLSID_MainConceptDVVideoDecoderProp =
{ 0x9A84F1EA, 0x2659, 0x4a45, { 0xac, 0x66, 0xce, 0xde, 0x0a, 0x15, 0x24, 0x1f } };

// {9A84F1EC-2659-4A45-AC66-CEDE0A15241F}
static const GUID IID_IMCDVDecoderFilter =
{ 0x9A84F1EC, 0x2659, 0x4a45, { 0xac, 0x66, 0xce, 0xde, 0x0a, 0x15, 0x24, 0x1f } };

#elif defined (MCGUID_DVDEC_DVCPRO50)

/********************************************************************
 Created: 2002/02/22
 File name: dec_dv50_guid_demo.h
 Purpose: Demo GUIDs for DVCPro50 DS Decoder Filter

 Copyright (c) 2000-2011 MainConcept GmbH. All rights reserved.

 This software is the confidential and proprietary information of
 MainConcept GmbH and may be used only in accordance with the terms of
 your license from MainConcept GmbH.

*********************************************************************/

#define DV_DECODER_MERIT          (MERIT_NORMAL-1)

#define COMPANY_DVDECODERFILTER_NAME         "demo_dec_dv50_ds.ax"
#define COMPANY_DVDECODERFILTER_INTERNALNAME "demo_dec_dv50_ds"
#define COMPANY_DVDECODERFILTER_DESCRIPTION  "DirectShow DVCPro50 Video Decoder Demo"
#define COMPANY_DVDECODERFILTER_PRODUCTNAME  COMPANY_SHORTNAME "\256 DVCPro50 Video Decoder Demo"

#define DVCPRO50_SUPPORT
#define CANOPUS_SUPPORT

// {670D4200-007C-455E-B4D2-F64C77EAAB09}
static const GUID CLSID_MainConceptDVVideoDecoder =
{ 0x670d4200, 0x007c, 0x455e, { 0xb4, 0xd2, 0xf6, 0x4c, 0x77, 0xea, 0xab, 0x09 } };

// {670D4202-007C-455E-B4D2-F64C77EAAB09}
static const GUID CLSID_MainConceptDVVideoDecoderProp =
{ 0x670d4202, 0x007c, 0x455e, { 0xb4, 0xd2, 0xf6, 0x4c, 0x77, 0xea, 0xab, 0x09 } };

// {670D4204-007C-455E-B4D2-F64C77EAAB09}
static const GUID IID_IMCDVDecoderFilter =
{ 0x670d4204, 0x007c, 0x455e, { 0xb4, 0xd2, 0xf6, 0x4c, 0x77, 0xea, 0xab, 0x09 } };

#else // default DV support

#define DV_DECODER_MERIT          (MERIT_NORMAL-1)

#define COMPANY_DVDECODERFILTER_NAME         "demo_dec_dv_ds.ax"
#define COMPANY_DVDECODERFILTER_INTERNALNAME "demo_dec_dv_ds"
#define COMPANY_DVDECODERFILTER_DESCRIPTION  "DirectShow DVCPro Video Decoder Demo"
#define COMPANY_DVDECODERFILTER_PRODUCTNAME  COMPANY_SHORTNAME "\256 DVCPro Video Decoder Demo"

// {941B1780-09B7-4498-98BD-7E0F6C881183}
static const GUID CLSID_MainConceptDVVideoDecoder =
{ 0x941b1780, 0x09b7, 0x4498, { 0x98, 0xbd, 0x7e, 0x0f, 0x6c, 0x88, 0x11, 0x83 } };

// {941B1782-09B7-4498-98BD-7E0F6C881183}
static const GUID CLSID_MainConceptDVVideoDecoderProp =
{ 0x941b1782, 0x09b7, 0x4498, { 0x98, 0xbd, 0x7e, 0x0f, 0x6c, 0x88, 0x11, 0x83 } };

// {941B1784-09B7-4498-98BD-7E0F6C881183}
static const GUID IID_IMCDVDecoderFilter =
{ 0x941b1784, 0x09b7, 0x4498, { 0x98, 0xbd, 0x7e, 0x0f, 0x6c, 0x88, 0x11, 0x83 } };

#endif // MCGUID_DVDEC_DVCPRO100, MCGUID_DVDEC_DVCPRO50, ...

#endif //__DEC_DV_GUID_H__
