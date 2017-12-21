/********************************************************************
 Created: 2006/11/15 
 File name: dec_mpa_guid_demo.h
 Purpose: Demo GUIDs for MPEG audio decoder DS Filter

 Copyright (c) 2005-2008 MainConcept GmbH. All rights reserved.

 This software is the confidential and proprietary information of
 MainConcept GmbH and may be used only in accordance with the terms of
 your license from MainConcept GmbH.

*********************************************************************/

#ifndef __MPEG2AUDIO_GUID_H__
#define __MPEG2AUDIO_GUID_H__

////////////////////////////////////////////////////////////

#undef  L2ADCOMPANY_HIDEICON
#define L2ADCOMPANY_DS_MERIT   (MERIT_NORMAL-1)

////////////////////////////////////////////////////////////
#ifndef RC_INVOKED // don't let resource compiler see this part

// {2BE4D130-6F2E-4B3A-B0BD-E880917238DC}
static const GUID CLSID_ELMPGLayer2AudioDecoder =
{ 0x2BE4D130, 0x6F2E, 0x4B3A, { 0xB0, 0xBD, 0xE8, 0x80, 0x91, 0x72, 0x38, 0xDC } };

// {2BE4D138-6F2E-4B3A-B0BD-E880917238DC}
static const GUID CLSID_ELMPGLayer2AudioDecoder_SettingsPropertyPage =
{ 0x2BE4D138, 0x6F2E, 0x4B3A, { 0xB0, 0xBD, 0xE8, 0x80, 0x91, 0x72, 0x38, 0xDC } };

// {FB0BD7FD-29C0-468E-AB6B-CEC0609C7DFA}
static const GUID CLSID_ELMPGLayer2AudioDecoder_AboutPropertyPage =
{ 0xFB0BD7FD, 0x29C0, 0x468E, { 0xAB, 0x6B, 0xCE, 0xC0, 0x60, 0x9C, 0x7D, 0xFA } };

#endif // RC_INVOKED
#endif //__MPEG2AUDIO_GUID_H__
