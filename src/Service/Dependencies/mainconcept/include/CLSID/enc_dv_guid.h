/********************************************************************
 Created: 2002/02/22
 File name: enc_dv_guid_demo.h
 Purpose: Demo GUIDs for DV DS Encoder Filter

 Copyright (c) 2000-2011 MainConcept GmbH. All rights reserved.

 This software is the confidential and proprietary information of
 MainConcept GmbH and may be used only in accordance with the terms of
 your license from MainConcept GmbH.

*********************************************************************/

#ifndef __ENC_DV_GUID_H__
#define __ENC_DV_GUID_H__

#if defined (MCGUID_DVENC_DVCPRO100)

/********************************************************************
 Created: 2002/02/22
 File name: enc_dv100_guid_demo.h
 Purpose: Demo GUIDs for DVCProHD DS Encoder Filter

 Copyright (c) 2000-2011 MainConcept GmbH. All rights reserved.

 This software is the confidential and proprietary information of
 MainConcept GmbH and may be used only in accordance with the terms of
 your license from MainConcept GmbH.

*********************************************************************/

#define DV_ENCODER_MERIT          (MERIT_DO_NOT_USE)

#define COMPANY_DVENCODERFILTER_NAME         "demo_enc_dv100_ds.ax"
#define COMPANY_DVENCODERFILTER_INTERNALNAME "demo_enc_dv100_ds"
#define COMPANY_DVENCODERFILTER_DESCRIPTION  "DirectShow DVCProHD Video Encoder Demo"
#define COMPANY_DVENCODERFILTER_PRODUCTNAME  COMPANY_SHORTNAME "\256 DVCProHD Video Encoder Demo"

#define DVCPRO100_SUPPORT
#define DVCPRO50_SUPPORT
#define CANOPUS_SUPPORT

// {9A84F1E9-2659-4A45-AC66-CEDE0A15241F}
static const GUID CLSID_MainConceptDVVideoEncoder =
{ 0x9A84F1E9, 0x2659, 0x4a45, { 0xac, 0x66, 0xce, 0xde, 0x0a, 0x15, 0x24, 0x1f } };

// {9A84F1EB-2659-4A45-AC66-CEDE0A15241F}
static const GUID CLSID_MainConceptDVVideoEncoderProp =
{ 0x9A84F1EB, 0x2659, 0x4a45, { 0xac, 0x66, 0xce, 0xde, 0x0a, 0x15, 0x24, 0x1f } };

// {9A84F1ED-2659-4A45-AC66-CEDE0A15241F}
static const GUID IID_IMCDVEncoderFilter =
{ 0x9A84F1ED, 0x2659, 0x4a45, { 0xac, 0x66, 0xce, 0xde, 0x0a, 0x15, 0x24, 0x1f } };

#elif defined (MCGUID_DVENC_DVCPRO50)

/********************************************************************
 Created: 2002/02/22
 File name: enc_dv50_guid_demo.h
 Purpose: Demo GUIDs for DVCPro50 DS Encoder Filter

 Copyright (c) 2000-2011 MainConcept GmbH. All rights reserved.

 This software is the confidential and proprietary information of
 MainConcept GmbH and may be used only in accordance with the terms of
 your license from MainConcept GmbH.

*********************************************************************/

#define DV_ENCODER_MERIT          (MERIT_DO_NOT_USE)

#define COMPANY_DVENCODERFILTER_NAME         "demo_enc_dv50_ds.ax"
#define COMPANY_DVENCODERFILTER_INTERNALNAME "demo_enc_dv50_ds"
#define COMPANY_DVENCODERFILTER_DESCRIPTION  "DirectShow DVCPro50 Video Encoder Demo"
#define COMPANY_DVENCODERFILTER_PRODUCTNAME  COMPANY_SHORTNAME "\256 DVCPro50 Video Encoder Demo"

#define DVCPRO50_SUPPORT
#define CANOPUS_SUPPORT

// {670D4201-007C-455E-B4D2-F64C77EAAB09}
static const GUID CLSID_MainConceptDVVideoEncoder =
{ 0x670d4201, 0x007c, 0x455e, { 0xb4, 0xd2, 0xf6, 0x4c, 0x77, 0xea, 0xab, 0x09 } };

// {670D4203-007C-455E-B4D2-F64C77EAAB09}
static const GUID CLSID_MainConceptDVVideoEncoderProp =
{ 0x670d4203, 0x007c, 0x455e, { 0xb4, 0xd2, 0xf6, 0x4c, 0x77, 0xea, 0xab, 0x09 } };

// {670D4205-007C-455E-B4D2-F64C77EAAB09}
static const GUID IID_IMCDVEncoderFilter =
{ 0x670d4205, 0x007c, 0x455e, { 0xb4, 0xd2, 0xf6, 0x4c, 0x77, 0xea, 0xab, 0x09 } };

#else // default DV support

#define DV_ENCODER_MERIT          (MERIT_DO_NOT_USE)

#define COMPANY_DVENCODERFILTER_NAME         "demo_enc_dv_ds.ax"
#define COMPANY_DVENCODERFILTER_INTERNALNAME "demo_enc_dv_ds"
#define COMPANY_DVENCODERFILTER_DESCRIPTION  "DirectShow DVCPro Video Encoder Demo"
#define COMPANY_DVENCODERFILTER_PRODUCTNAME  COMPANY_SHORTNAME "\256 DVCPro Video Encoder Demo"

// {941B1781-09B7-4498-98BD-7E0F6C881183}
static const GUID CLSID_MainConceptDVVideoEncoder =
{ 0x941b1781, 0x09b7, 0x4498, { 0x98, 0xbd, 0x7e, 0x0f, 0x6c, 0x88, 0x11, 0x83 } };

// {941B1783-09B7-4498-98BD-7E0F6C881183}
static const GUID CLSID_MainConceptDVVideoEncoderProp =
{ 0x941b1783, 0x09b7, 0x4498, { 0x98, 0xbd, 0x7e, 0x0f, 0x6c, 0x88, 0x11, 0x83 } };

// {941B1785-09B7-4498-98BD-7E0F6C881183}
static const GUID IID_IMCDVEncoderFilter =
{ 0x941b1785, 0x09b7, 0x4498, { 0x98, 0xbd, 0x7e, 0x0f, 0x6c, 0x88, 0x11, 0x83 } };

#endif // MCGUID_DVENC_DVCPRO100, MCGUID_DVENC_DVCPRO50, ...

#endif //__ENC_DV_GUID_H__
