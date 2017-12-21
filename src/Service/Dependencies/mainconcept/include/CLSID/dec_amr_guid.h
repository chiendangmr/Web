/********************************************************************
 Created: 2006/11/15 
 File name: dec_amr_guid_demo.h
 Purpose: Demo GUIDs for AMR Decoder DS Filter

 Copyright (c) 2005-2008 MainConcept GmbH. All rights reserved.

 This software is the confidential and proprietary information of
 MainConcept GmbH and may be used only in accordance with the terms of
 your license from MainConcept GmbH.

*********************************************************************/

#ifndef __AMRDEC_GUID_H__
#define __AMRDEC_GUID_H__


#undef COMPANY_HIDEICON

#define AMRCOMPANY_DS_MERIT_DECODER   (MERIT_PREFERRED-1)


///////////////////////////////////////////////////////////////
#ifndef RC_INVOKED // don't let resource compiler see this part

// {18CAD714-24C4-474E-97D4-4C5A50046791}
static const GUID CLSID_AMRAudioDecoder =
{ 0x18cad714, 0x24c4, 0x474e, { 0x97, 0xd4, 0x4c, 0x5a, 0x50, 0x4, 0x67, 0x91 } };

// {DA363D06-0224-45A0-98CF-1B04C90796DE}
static const GUID CLSID_AMRAudioDecoderPropPage =
{ 0xda363d06, 0x0224, 0x45a0, { 0x98, 0xcf, 0x1b, 0x4, 0xc9, 0x7, 0x96, 0xde } };

// {C195E022-262A-4306-A4D2-4B497F048514}
static const GUID CLSID_AMRAudioDecoderAboutPage =
{ 0xc195e022, 0x262a, 0x4306, { 0xa4, 0xd2, 0x4b, 0x49, 0x7f, 0x4, 0x85, 0x14 } };

#endif // RC_INVOKED
///////////////////////////////////////////////////////////////

#endif //__AMRDEC_GUID_H__

