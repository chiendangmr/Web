/* ----------------------------------------------------------------------------
 * File: config_avc_wrap.h
 *
 * Desc: H.264/AVC Encoder Wrapper Configuration API
 *
 * Copyright (c) 2015 MainConcept GmbH or its affiliates.  All rights reserved.
 *
 * MainConcept and its logos are registered trademarks of MainConcept GmbH or its affiliates.  
 * This software is protected by copyright law and international treaties.  Unauthorized 
 * reproduction or distribution of any portion is prohibited by law.
 * ----------------------------------------------------------------------------
 */

#if !defined (__AVC_WRAP_CONFIG_API_INCLUDED__)
#define __AVC_WRAP_CONFIG_API_INCLUDED__

#include "mcapiext.h"

#include "config_avc_def.h"

#include "enc_avc_wrap.h"

struct avc_wrap_param_set
{
  struct h264_v_wrap_settings params;
  int32_t reserved[1024];
};

#ifdef __cplusplus
extern "C" {
#endif


APIEXTFUNC MC_EXPORT_API AVCWrapConfigGetAPIExt(uint32_t func);

#ifdef __cplusplus
}
#endif

#endif // __AVC_WRAP_CONFIG_API_INCLUDED__
