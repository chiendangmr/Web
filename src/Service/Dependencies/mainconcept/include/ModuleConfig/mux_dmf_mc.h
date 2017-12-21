//////////////////////////////////////////////////////////////////////////
//
//	file name:	mux_dmf_mc.h
//
///////////////////////////////////////////////////////////////////////////////
//
//  Copyright (c) 2008-2009 MainConcept GmbH
//  All rights are reserved.  Reproduction  in whole or  in part is  prohibited
//  without the written consent of the copyright owner.
//
//  MainConcept GmbH reserves the right  to make changes to this software program
//  without notice  at any time.  MainConcept GmbH makes no warranty,  expressed,
//  implied or statutory, including but not limited to  any implied warranty of
//  merchantability of fitness for any particular purpose.
//  MainConcept GmbH  does not represent  or warrant that  the programs furnished
//  hereunder are free of infringement of any third-party patents, copyright or
//  trademark.
//  In no event shall MainConcept GmbH be liable for any incidental, punitive, or
//  consequential damages of any kind  whatsoever arising from the use of these
//  programs.
//
///////////////////////////////////////////////////////////////////////////////
//
//  Purpose: The definition of the MainConcept DMF Multiplexer parameter CLSIDs
//
///////////////////////////////////////////////////////////////////////////////

#if !defined(__DMFMUX_HEADER__)
#define __DMFMUX_HEADER__


//========================================================================
//						FILTER PARAMETERS UIDS
//========================================================================

///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
//	GUID								Value Type	Available range		Default Value	Note


// {8A8A6C32-0AC4-48f6-A1EE-7D97B975FC35}
static const GUID DMFMux_ModuleID = 
{ 0x8a8a6c32, 0xac4, 0x48f6, { 0xa1, 0xee, 0x7d, 0x97, 0xb9, 0x75, 0xfc, 0x35 } };

// {D558327D-BE76-480e-9F7A-45381A51A9C9}
static const GUID DMFMux_CoreMemorySize = 
{ 0xd558327d, 0xbe76, 0x480e, { 0x9f, 0x7a, 0x45, 0x38, 0x1a, 0x51, 0xa9, 0xc9 } };


namespace DMFMuxer
{
    typedef enum tagModuleID {
        AVI1    = 0,
        AVI2    = 1,
        MKV     = 2
    };       
};

#endif 
