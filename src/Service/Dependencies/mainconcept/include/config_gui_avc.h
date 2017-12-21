/* ----------------------------------------------------------------------------
 * File: gui_avc.h
 *
 * Desc: AVC Video Encoder GUI
 *
 * Copyright (c) 2015 MainConcept GmbH or its affiliates.  All rights reserved.
 *
 * MainConcept and its logos are registered trademarks of MainConcept GmbH or its affiliates.  
 * This software is protected by copyright law and international treaties.  Unauthorized 
 * reproduction or distribution of any portion is prohibited by law.
 * ----------------------------------------------------------------------------
 */

#if !defined (__AVCENCODER_PAGES_INCLUDED__)
#define __AVCENCODER_PAGES_INCLUDED__

#include "config_avc.h"

#ifdef __cplusplus
extern "C" {
#endif

/** 
 * Displays settings dialog.
 * @param set current settings being displayed in dialog.
 * @param options any combination of above flags.
 * @param option_ptr should be:
 *        @li pointer to @ref avc_dialog_set object if options contains @ref AVC_PAGES_USE_DLG_SET_STRUCT flag.
 *        @li HWND handle for MFC applications if options doesn't contain @ref AVC_PAGES_USE_DLG_SET_STRUCT flag.
 *        @li pointer to QApplication if options doesn't contain @ref AVC_PAGES_USE_DLG_SET_STRUCT flag and contain @ref AVC_PAGES_QT_APPLICATION flag.
 *        In other words, you have two ways of using this parameter: 1. (old style) just pass HWND or QApplication via @ref option_ptr.
 *        2) (new way, relates to branding API) fill up @ref avc_dialog_set structure (HWND or QApplication can be set via @ref avc_dialog_set::parent_ptr), 
 *        add @ref AVC_PAGES_USE_DLG_SET_STRUCT flag and pass the new structure via @ref option_ptr.
 * @return MCAPI_ACCEPTED if accepted, else MCAPI_REJECTED.
 */
int32_t showAVCEncoderPages(struct avc_param_set *set,
                             uint32_t               options,
                             void                  *option_ptr);

#ifdef __cplusplus
    }
#endif

#endif // __AVCENCODER_PAGES_INCLUDED__
