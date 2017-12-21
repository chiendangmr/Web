/* ----------------------------------------------------------------------------
 * File: config_aac.h
 *
 * Desc: Fraunhofer AAC Encoder Configuration API
 *
 * Copyright (c) 2014 MainConcept GmbH or its affiliates.  All rights reserved.
 *
 * MainConcept and its logos are registered trademarks of MainConcept GmbH or its affiliates.  
 * This software is protected by copyright law and international treaties.  Unauthorized 
 * reproduction or distribution of any portion is prohibited by law.
 * ----------------------------------------------------------------------------
 */

#if !defined (__FHG_AAC_CONFIG_API_INCLUDED__)
#define __FHG_AAC_CONFIG_API_INCLUDED__

#include "mcapiext.h"

#include "enc_aac.h"
#include "fhg_enc_aac.h"


#if !defined (__FHG_AAC_CONFIG_DEF_API_INCLUDED__)
#define __FHG_AAC_CONFIG_DEF_API_INCLUDED__


#define FHG_AAC_PAGES_BASIC               0x00000001  /**< display the basic settings page */
#define FHG_AAC_PAGES_ADVANCED            0x00000002  /**< display the advanced settings page */
//#define FHG_AAC_PAGES_MISC                0x00000004  /**< display the miscellaneous page */
#define FHG_AAC_PAGES_ALL                 0x00000007  /**< display all of the above pages */

#define FHG_AAC_PAGES_LOADSAVE            0x00000010  /**< display the load/save buttons */
#define FHG_AAC_PAGES_NOINITCHECK         0x00000020  /**< do not check the validity of the setting at function start */
#define FHG_AAC_PAGES_REDWARNINGS         0x00000040  /**< display any validation warnings & errors */

#define FHG_AAC_PAGES_BANNER_OFF          0x00001000  /**< do not display codec banner */
#define FHG_AAC_PAGES_DISABLE_PRESET      0x00002000  /**< disable preset list (used e.g. in Encoder Application) */
#define FHG_AAC_PAGES_DISABLE_BITRATE     0x00004000  /**< disable Bitrate selector */
#define FHG_AAC_PAGES_DISABLE_AAC_TYPE    0x00008000  /**< disable AAC type selector */

#define FHG_AAC_PAGES_QT_APPLICATION      0x10000000  /**< caller application is QT (not MFC) */
#define FHG_AAC_PAGES_USE_DLG_SET_STRUCT  0x20000000  /**< pass @ref aac_dialog_set or fhg_aac_dialog_set via @ref opt_ptr parameter in @ref showAACEncoderPages function */

#endif  // __FHG_AAC_CONFIG_DEF_API_INCLUDED__

struct aac_param_set
{
    struct aac_a_settings params;
    uint32_t sample_rate;  // sample_rate the audio frequency, either 8000, 11025, 12000, 16000, 22050, 24000, 32000, 44100, 48000, 64000, 88200 or 96000
    uint32_t mpeg_type;  // mpeg_type the MPEG version type, valid values are @ref MPEG_MPEG1 .. @ref MPEG_LAST_MPEG_TYPE)
    uint32_t profile;    // current selected audio profile. For supported profile list please see enc_aac.h (setDefaults func description)
    int32_t reserved[1024 - sizeof(uint32_t) * 3];
};

struct fhg_aac_param_set
{
    struct fhg_aac_a_settings params;
    fhg_aac_a_metadata metadata;
    uint32_t sample_rate;  // sample_rate the audio frequency, either 8000, 11025, 12000, 16000, 22050, 24000, 32000, 44100, 48000, 64000, 88200 or 96000
    uint32_t profile;    // current selected audio profile. For supported profile list please see enc_aac.h (setDefaults func description)
    uint32_t mpeg_type;  // mpeg_type the MPEG version type, valid values are @ref MPEG_MPEG1 .. @ref MPEG_LAST_MPEG_TYPE)

    int32_t reserved[1024 - sizeof(uint32_t) * 3];
};




#ifdef __cplusplus
extern "C" {
#endif


APIEXTFUNC MC_EXPORT_API AACConfigGetAPIExt(uint32_t func);

APIEXTFUNC MC_EXPORT_API FHGAACConfigGetAPIExt(uint32_t func);

#ifdef __cplusplus
}
#endif

#endif // __FHG_AAC_CONFIG_API_INCLUDED__
