/* ----------------------------------------------------------------------------
 * File: config_divx.h
 *
 * Desc: DivX Video Encoder Configuration API
 *
 * Copyright (c) 2014 MainConcept GmbH or its affiliates.  All rights reserved.
 *
 * MainConcept and its logos are registered trademarks of MainConcept GmbH or its affiliates.  
 * This software is protected by copyright law and international treaties.  Unauthorized 
 * reproduction or distribution of any portion is prohibited by law.
 * ----------------------------------------------------------------------------
 */

#if !defined (__DIVX_CONFIG_API_INCLUDED__)
#define __DIVX_CONFIG_API_INCLUDED__

#include "mcapiext.h"

#include "enc_divx.h"
#include "enc_divx_def.h"


// dialog pages available
#define DIVXV_PAGES_BASIC								0x00000001  // display the basic settings page
#define DIVXV_PAGES_ADVANCED							0x00000002  // display the advanced settings page
#define DIVXV_PAGES_ALL									0x00000007  // display all of the above pages

// dialog options
#define DIVXV_PAGES_LOADSAVE							0x00000010  // display the load/save buttons
#define DIVXV_PAGES_NOINITCHECK					0x00000020  // do not check the validity of the setting at function start
#define DIVXV_PAGES_REDWARNINGS					0x00000040  // display any validation warnings & errors

#define DIVXV_PAGES_BANNER_OFF						0x00001000  // do not display codec banner              
#define DIVXV_PAGES_DISABLE_PRESET				0x00002000  // disable preset gui (used e.g. in Encoder Application)
#define DIVXV_PAGES_DISABLE_FRAMESIZE		0x00004000  // disable framesize gui (used e.g. in Encoder Application)
#define DIVXV_PAGES_DISABLE_FRAMERATE		0x00008000  // disable framerate gui (used e.g. in Encoder Application)
#define DIVXV_PAGES_DISABLE_PIXELASPECT	0x00010000  // disable pixel aspect ratio gui 

#define DIVXV_PAGES_QT_APPLICATION                0x10000000  // caller application is QT (not MFC)


struct divx_param_set
{
  struct divx_v_settings params;

  int32_t reserved[1024];
};

#ifdef __cplusplus
extern "C" {
#endif

/**
 * The API Extension control.
 * @param func one of the defined API function identifiers.
 * @return pointer to the requested API function or NULL, if not supported.
 */
APIEXTFUNC MC_EXPORT_API DIVXConfigGetAPIExt(uint32_t func);

#ifdef __cplusplus
}
#endif

#endif // __DIVX_CONFIG_API_INCLUDED__
