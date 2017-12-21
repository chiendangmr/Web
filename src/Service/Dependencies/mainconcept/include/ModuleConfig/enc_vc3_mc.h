/** 
 @file  enc_vc3_mc.h
 @brief  Property GUIDs for MainConcept VC-3 encoder parameters.
 
 @verbatim
 File: enc_vc3_mc.h

 Desc: Property GUIDs for MainConcept VC-3 encoder parameters.
 
 Copyright (c) 2015 MainConcept GmbH or its affiliates.  All rights reserved.

 MainConcept and its logos are registered trademarks of MainConcept GmbH or its affiliates.  
 This software is protected by copyright law and international treaties.  Unauthorized 
 reproduction or distribution of any portion is prohibited by law.
 @endverbatim
 **/

#if !defined(__PROPID_ENC_VC3_HEADER__)
#define __PROPID_ENC_VC3_HEADER__

#ifdef DEMO_LOGO
#include "enc_vc3_guid_demo.h"
#else
#include "enc_vc3_guid.h"
#endif

// {DC25BFE5-9D59-4d7c-8657-CE185F85C373}
static const GUID MCVC3VE_def_horizontal_size = 
{ 0xdc25bfe5, 0x9d59, 0x4d7c, { 0x86, 0x57, 0xce, 0x18, 0x5f, 0x85, 0xc3, 0x73 } };

// {E9E53BD7-546C-46e4-8154-483D2787DC63}
static const GUID MCVC3VE_def_vertical_size = 
{ 0xe9e53bd7, 0x546c, 0x46e4, { 0x81, 0x54, 0x48, 0x3d, 0x27, 0x87, 0xdc, 0x63 } };

// {E926800A-E7A2-4792-ABB0-ABFE7D82CF8D}
static const GUID MCVC3VE_OriginalFramerate = 
{ 0xe926800a, 0xe7a2, 0x4792, { 0xab, 0xb0, 0xab, 0xfe, 0x7d, 0x82, 0xcf, 0x8d } };

// {358441E8-C72E-4c0e-99B8-66D6A32F915C}
static const GUID MCVC3VE_OriginalInterlace = 
{ 0x358441e8, 0xc72e, 0x4c0e, { 0x99, 0xb8, 0x66, 0xd6, 0xa3, 0x2f, 0x91, 0x5c } };

// {4EB15F92-624B-47a6-986A-0305AA73061F}
static const GUID MCVC3VE_OriginalColorSpace = 
{ 0x4eb15f92, 0x624b, 0x47a6, { 0x98, 0x6a, 0x3, 0x5, 0xaa, 0x73, 0x6, 0x1f } };

// {13804B8E-5105-4225-94A0-781D28117D45}
static const GUID MCVC3VE_OriginalBitDepth = 
{ 0x13804b8e, 0x5105, 0x4225, { 0x94, 0xa0, 0x78, 0x1d, 0x28, 0x11, 0x7d, 0x45 } };

// {A084D6E6-A63A-4f15-8D9A-FAACEC87AFDD}
static const GUID MCVC3VE_num_threads = 
{ 0xa084d6e6, 0xa63a, 0x4f15, { 0x8d, 0x9a, 0xfa, 0xac, 0xec, 0x87, 0xaf, 0xdd } };

// {52AEE424-A493-4ae7-A97E-329E04535195}
static const GUID MCVC3VE_SetDefValues = 
{ 0x52aee424, 0xa493, 0x4ae7, { 0xa9, 0x7e, 0x32, 0x9e, 0x4, 0x53, 0x51, 0x95 } };

// {1095B117-FE22-4d7d-8CE3-8327BA39AC73}
static const GUID MCVC3VE_IsRunning = 
{ 0x1095b117, 0xfe22, 0x4d7d, { 0x8c, 0xe3, 0x83, 0x27, 0xba, 0x39, 0xac, 0x73 } };

// {BB0461DE-8DA5-4B23-972C-7D4938EDE31E}
static const GUID MCVC3VE_Width = 
{ 0xbb0461de, 0x8da5, 0x4b23, { 0x97, 0x2c, 0x7d, 0x49, 0x38, 0xed, 0xe3, 0x1e } };

// {FCBA7F71-3BFE-4AF3-A258-6876409518ED}
static const GUID MCVC3VE_Height = 
{ 0xfcba7f71, 0x3bfe, 0x4af3, { 0xa2, 0x58, 0x68, 0x76, 0x40, 0x95, 0x18, 0xed } };

// {1D8DD301-266F-4D53-A230-10378BBA3258}
static const GUID MCVC3VE_BitDepth =
{ 0x1d8dd301, 0x266f, 0x4d53,{ 0xa2, 0x30, 0x10, 0x37, 0x8b, 0xba, 0x32, 0x58 } };

// {BF86F154-52E1-402B-917B-110467D15485}
static const GUID MCVC3VE_Quality = 
{ 0xbf86f154, 0x52e1, 0x402b, { 0x91, 0x7b, 0x11, 0x4, 0x67, 0xd1, 0x54, 0x85 } };

// {EFBCAB4A-DB42-4EB1-A517-0E5ECA382967}
static const GUID MCVC3VE_ColorSpace = 
{ 0xefbcab4a, 0xdb42, 0x4eb1, { 0xa5, 0x17, 0xe, 0x5e, 0xca, 0x38, 0x29, 0x67 } };

// {7428C7A7-B554-4284-8C58-EB074017ED31}
static const GUID MCVC3VE_ScanType = 
{ 0x7428c7a7, 0xb554, 0x4284, { 0x8c, 0x58, 0xeb, 0x7, 0x40, 0x17, 0xed, 0x31 } };

// {82898664-BC38-4A02-9796-ECBB47375FFC}
static const GUID MCVC3VE_Colorimetry = 
{ 0x82898664, 0xbc38, 0x4a02, { 0x97, 0x96, 0xec, 0xbb, 0x47, 0x37, 0x5f, 0xfc } };

// {E38E66F1-EDFA-4BD7-AA2E-95FF9DBD050A}
static const GUID MCVC3VE_SrcSignalRange = 
{ 0xe38e66f1, 0xedfa, 0x4bd7, { 0xaa, 0x2e, 0x95, 0xff, 0x9d, 0xbd, 0x5, 0xa } };

// {2C0E7D78-CE41-4C63-BEEB-9080B98A3EB4}
static const GUID MCVC3VE_DstSignalRange = 
{ 0x2c0e7d78, 0xce41, 0x4c63, { 0xbe, 0xeb, 0x90, 0x80, 0xb9, 0x8a, 0x3e, 0xb4 } };


/**
* namespace VC3
* @brief VC3 specific namespace
**/
namespace MC_VC3VE
{
    /**
    * @brief Describes Encoder presets.
    **/
    enum Preset
    {
        Preset_SQ_720p_TR  = 0x00015000,
        Preset_SQ_720p     = 0x00015001,
        Preset_HQ_720p     = 0x00015002,
        Preset_HQX_720p    = 0x00015003,

        Preset_LB_1080p    = 0x00015010,
        Preset_SQ_1080p_TR = 0x00015011,
        Preset_SQ_1080p    = 0x00015012,
        Preset_HQ_1080p    = 0x00015013,
        Preset_HQX_1080p   = 0x00015014,
        Preset_444_1080p   = 0x00015015,

        Preset_SQ_1080i_TR = 0x00015020,
        Preset_SQ_1080i    = 0x00015021,
        Preset_HQ_1080i_TR = 0x00015022,
        Preset_HQ_1080i    = 0x00015023,
        Preset_HQX_1080i   = 0x00015024,

        Preset_HQ_DCI_2K   = 0x00015030,
        Preset_HQX_DCI_2K  = 0x00015031,
        Preset_444_DCI_2K  = 0x00015032,

        Preset_HQ_DCI_4K   = 0x00015040,
        Preset_HQX_DCI_4K  = 0x00015041,
        Preset_444_DCI_4K  = 0x00015042,

        Preset_LB          = 0x00015050,
        Preset_SQ          = 0x00015051,
        Preset_HQ          = 0x00015052,
        Preset_HQX         = 0x00015053,
        Preset_444         = 0x00015054
    };

    /**
    * @brief Describes available bit depth values.
    **/
    enum BitDepth
    {
        BitDepth_8  = 8,
        BitDepth_10 = 10,
        BitDepth_12 = 12
    };

    /**
    * @brief Describes available quality modes.
    **/
    enum Quality
    {
        Quality_LB  = 0,
        Quality_SQ  = 1,
        Quality_HQ  = 2,
        Quality_HQX = 3,
        Quality_444 = 4
    };

    /**
    * @brief Describes available color space types.
    **/
    enum ColorSpaceFamily
    {
        ColorSpaceFamily_YUV = 0,
        ColorSpaceFamily_RGB = 1
    };

    /**
    * @brief Describes available scan types.
    **/
    enum ScanType
    {
        ScanType_Progressive = 0,
        ScanType_Interlaced  = 1
    };

    /**
    * @brief Describes available colorimetry modes.
    **/
    enum Colorimetry
    {
        Colorimetry_Auto   = 0,
        Colorimetry_BT709  = 1,
        Colorimetry_BT2020 = 2
    };

    /**
    * @brief Describes available signal ranges.
    **/
    enum SignalRange
    {
        SignalRange_PC     = 0,
        SignalRange_Studio = 1
    };
}

#endif // __PROPID_ENC_VC3_HEADER__