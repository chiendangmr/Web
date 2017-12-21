/* ----------------------------------------------------------------------------
 * File: demo_company.h
 *
 * Desc: Company header
 *
 * Copyright (c) 2015 MainConcept GmbH or its affiliates.  All rights reserved.
 *
 * MainConcept and its logos are registered trademarks of MainConcept GmbH or its affiliates.  
 * This software is protected by copyright law and international treaties.  Unauthorized 
 * reproduction or distribution of any portion is prohibited by law.
 *
 * ----------------------------------------------------------------------------
 */

#define NAME_PREFIX         demo_
#define COMPANY_PREFIX      "demo_"
#define COMPANY_NAME        "MainConcept GmbH"
#define COMPANY_WNAME       L"MainConcept GmbH"
#ifdef MCBUILD_BROADCAST
#define COMPANY_SHORTNAME   "MainConcept (Broadcast Demo)"
#define COMPANY_WSHORTNAME  L"MainConcept (Broadcast Demo)"
#else
#ifdef MCBUILD_CONSUMER
#define COMPANY_SHORTNAME   "MainConcept (Consumer Demo)"
#define COMPANY_WSHORTNAME  L"MainConcept (Consumer Demo)"
#else
#define COMPANY_SHORTNAME   "MainConcept (Demo)"
#define COMPANY_WSHORTNAME  L"MainConcept (Demo)"
#endif
#endif

#define COMPANY_WWW_        "www.mainconcept.com"
#define COMPANY_WWW_L       L"www.mainconcept.com"
#define COMPANY_WWW_T       TEXT(COMPANY_WWW_)
#define VENDOR_INFO_STRING  L"MainConcept GmbH http://www.mainconcept.com"

#define COMPANY_MARKER_NAME " "
#define COMPANY_MARKER_KEY  {0}

#define COMPLCNFG_REGFREE_NOLIMITS
#undef  COMPLCNFG_REGFREE_NOLOGO

#ifndef DEMO_LOGO
#define DEMO_LOGO
#endif


#ifndef MCBUILD_BROADCAST

// AVC encoder
#define H264_FUNCTIONAL_LIMIT_BASELINE_MAIN_HIGH

// AVC decoder_v3
#define H264_FUNCTIONAL_LIMIT_BASELINE_MAIN_HIGH

// MP4 muxer
#define MP4_FUNCTIONAL_LIMIT_NO_ULTRAVIOLET

#endif

#ifdef MCBUILD_CONSUMER
// VC1 encoder
#define FUNCTIONAL_LIMIT_SINGLE_INSTANCE
#define FUNCTIONAL_LIMIT_ONE_PHYSICAL_PROCESSOR
#define FUNCTIONAL_LIMIT_MAX_BIT_RATE

// AVC encoder
#define H264_FUNCTIONAL_LIMIT_SINGLE_INSTANCE
#define H264_FUNCTIONAL_LIMIT_ONE_PHYSICAL_PROCESSOR
#define H264_FUNCTIONAL_LIMIT_MAX_BIT_RATE
#define H264_FUNCTIONAL_LIMIT_BASELINE_MAIN_HIGH

// AVC decoder_v3
#define H264_FUNCTIONAL_LIMIT_BASELINE_MAIN_HIGH
#endif
