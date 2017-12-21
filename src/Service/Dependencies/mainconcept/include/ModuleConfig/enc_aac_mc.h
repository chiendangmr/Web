/** 
 @file  enc_aac_mc.h
 @brief Property GUIDs for MainConcept AAC encoder parameters.
 
 @verbatim
 File: enc_aac_mc.h

 Desc: Property GUIDs for MainConcept AAC encoder parameters.
 
 Copyright (c) 2015 MainConcept GmbH or its affiliates.  All rights reserved.

 MainConcept and its logos are registered trademarks of MainConcept GmbH or its affiliates.  
 This software is protected by copyright law and international treaties.  Unauthorized 
 reproduction or distribution of any portion is prohibited by law.
 @endverbatim
 **/

#if !defined(MC_AAC_ENCODER_CONFIG)
#define MC_AAC_ENCODER_CONFIG

//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
//  IModuleConfig GUIDs
//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

///Sets the output format (MPEG-2, MPEG-4 or MPEG-4 for Sony PSP).
static const GUID ELAACENC_MPEG_Version =
{0xfd882e86, 0xdcc2, 0x4120, {0xa6, 0xef, 0xe6, 0xe8, 0x5b, 0xc2, 0xd0, 0x59}};

///Sets the audio object type. Obsolete.
static const GUID ELAACENC_Object_Type =
{0x49c7eb31, 0x2e21, 0x41ef, {0x92, 0xbe, 0x46, 0xc9, 0x10, 0x47, 0x45, 0xde}};

///Sets the output bit stream format (raw or with ADTS or LATM headers).
static const GUID ELAACENC_Output_Format =
{0xeeae27e3, 0xd553, 0x4db0, { 0xa8, 0x3e, 0xe7, 0x28, 0x80, 0x33, 0xa0, 0xb7}};

///Enables/disables high frequency cut-off.
static const GUID ELAACENC_HF_Cutoff =
{0x553936e3, 0xd553, 0x4db0, { 0xa8, 0x3e, 0xe7, 0x28, 0x80, 0x33, 0xa0, 0x00}};

///Enables/disables variable bit rate encoding mode.
static const GUID ELAACENC_VBR =
{0x553936e3, 0xd553, 0x4db0, { 0xa8, 0x3e, 0xe7, 0x28, 0x80, 0x33, 0xa0, 0x01}};

///Sets variable bit rate mode quality.
static const GUID ELAACENC_VBR_Mode =
{0x553936e3, 0xd553, 0x4db0, { 0xa8, 0x3e, 0xe7, 0x28, 0x80, 0x33, 0xa0, 0x02}};

///Enables/disables spectral band replication (HE AAC v1).
static const GUID ELAACENC_SBR =
{0x553936e3, 0xd553, 0x4db0, { 0xa8, 0x3e, 0xe7, 0x28, 0x80, 0x33, 0xa0, 0x03}};

///Retrieves the number of encoded AAC frames.
static const GUID ELAACENC_Frame_Count =
{0x553936e3, 0xd553, 0x4db0, { 0xa8, 0x3e, 0xe7, 0x28, 0x80, 0x33, 0xa0, 0x04}};

///Retrieves the number of output bytes.
static const GUID ELAACENC_Byte_Count =
{0x553936e3, 0xd553, 0x4db0, { 0xa8, 0x3e, 0xe7, 0x28, 0x80, 0x33, 0xa0, 0x05}};

static const GUID ELAACENC_Byte_Count_Long = 
{ 0xad86ebf, 0x5fe3, 0x48bc, { 0xb8, 0xe0, 0xe2, 0x97, 0x78, 0x1d, 0x95, 0xae } };

///Retrieves the output sample rate.
static const GUID ELAACENC_Sample_Rate =
{0x553936e3, 0xd553, 0x4db0, { 0xa8, 0x3e, 0xe7, 0x28, 0x80, 0x33, 0xa0, 0x06}};

///Retrieves the SBR core sample rate.
static const GUID ELAACENC_Core_Sample_Rate =
{0x553936e3, 0xd553, 0x4db0, { 0xa8, 0x3e, 0xe7, 0x28, 0x80, 0x33, 0xa0, 0x07}};

///Enables/disables parametric stereo (HE AAC v2).
static const GUID ELAACENC_PS =
{0x553936e3, 0xd553, 0x4db0, { 0xa8, 0x3e, 0xe7, 0x28, 0x80, 0x33, 0xa0, 0x08}};

///Retrieves the output channel configuration.
static const GUID ELAACENC_Channel_Config =
{0x553936e3, 0xd553, 0x4db0, { 0xa8, 0x3e, 0xe7, 0x28, 0x80, 0x33, 0xa0, 0x09}};

///Retrieves the PS core channel configuration.
static const GUID ELAACENC_Core_Channel_Config =
{0x553936e3, 0xd553, 0x4db0, { 0xa8, 0x3e, 0xe7, 0x28, 0x80, 0x33, 0xa0, 0x0a}};

///Retrieves availability of spectral band replication (HE AAC v1).
static const GUID AACENC_SBR_Available =
{0x553936e3, 0xd553, 0x4db0, { 0xa8, 0x3e, 0xe7, 0x28, 0x80, 0x33, 0xa0, 0x0b}};

///Retrieves availability of parametric stereo (HE AAC v2).
static const GUID AACENC_PS_Available =
{0x553936e3, 0xd553, 0x4db0, { 0xa8, 0x3e, 0xe7, 0x28, 0x80, 0x33, 0xa0, 0x0c}};

///Specifies if audio stream contains CRC protection.
static const GUID ELAACENC_Protect_ADTS_Stream = 
{0xb3a79c4c, 0xea47, 0x4ccb, { 0xbe, 0xb5, 0x76, 0xaa, 0xb0, 0xa3, 0x49, 0xf9}};

// {A8051FCA-6613-46d1-904D-3062E395D755}
static const GUID ELAACENC_TNS= 
{ 0xa8051fca, 0x6613, 0x46d1, { 0x90, 0x4d, 0x30, 0x62, 0xe3, 0x95, 0xd7, 0x55 } };

///Sets default settings for the selected preset.
static const GUID ELAACENC_SetDefValues = 
{ 0x237776cf, 0x191b, 0x41e8, { 0xb7, 0x7d, 0x75, 0xd9, 0x60, 0x84, 0xf0, 0x1f } };



////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
// GUID                         Type        Available range     Default value   Note
// MC_BITRATE_AVG               VT_I4       [0, 27]             [19]            Sets average output bit rate
// ELAACENC_MPEG_Version        VT_I4       [0, 1]              [0]             Sets the output format (MPEG-2 or MPEG-4)
// ELAACENC_Object_Type         VT_I4       [0, 1]              [1]             Sets the audio object type (Main or Low Complexity)
// ELAACENC_Output_Format       VT_I4       [0, 1]              [1]             Sets the output bit stream format (raw or with ADTS headers)
// ELAACENC_HF_Cutoff           VT_I4       [0, 1]              [1]             Enables/disables high frequency cut-off
// ELAACENC_VBR                 VT_I4       [0, 1]              [0]             Enables/disables variable bit rate encoding mode
// ELAACENC_VBR_Mode            VT_I4       [1, 9]              [6]             Sets variable bit rate mode quality
// ELAACENC_SBR                 VT_I4       [0, 1]              [0]             Enables/disables spectral band replication (HE AAC v1)
// ELAACENC_PS                  VT_I4       [0, 1]              [0]             Enables/disables parametric stereo (HE AAC v2)
// ELAACENC_Frame_Count         VT_I4                           Read only       Retrieves the number of encoded AAC frames
// ELAACENC_Byte_Count          VT_I4                           Read only       Retrieves the number of output bytes
// ELAACENC_Byte_Count_Long     VT_I8                           Read only       Retrieves the number of output bytes
// ELAACENC_Sample_Rate         VT_I4                           Read only       Retrieves the output sample rate
// ELAACENC_Core_Sample_Rate    VT_I4                           Read only       Retrieves the SBR core sample rate
// ELAACENC_Channel_Config      VT_I4                           Read only       Retrieves the output channel config
// ELAACENC_Core_Channel_Config VT_I4                           Read only       Retrieves the PS core channel config
// AACENC_SBR_Available         VT_I4                           Read only       Retrieves whether SBR encoding is available
// AACENC_PS_Available          VT_I4                           Read only       Retrieves whether PS encoding is available
////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

/**
* namespace EAACENC
* @brief AAC Encoder DS Filter namespace
**/
namespace EAACENC
{

    /// bit rate
    enum aacenc_bit_rate_e
    {
        IMC_AACENC_BR_6 = 0,		///< 6 kbps
        IMC_AACENC_BR_7,		///< 7 kbps
        IMC_AACENC_BR_8,		///< 8 kbps
        IMC_AACENC_BR_10,		///< 10 kbps
        IMC_AACENC_BR_12,		///< 12 kbps
        IMC_AACENC_BR_14,		///< 14 kbps
        IMC_AACENC_BR_16,		///< 16 kbps
        IMC_AACENC_BR_20,		///< 20 kbps
        IMC_AACENC_BR_24,		///< 24 kbps
        IMC_AACENC_BR_28,		///< 28 kbps
        IMC_AACENC_BR_32,		///< 32 kbps
        IMC_AACENC_BR_40,		///< 40 kbps
        IMC_AACENC_BR_48,		///< 48 kbps
        IMC_AACENC_BR_56,		///< 56 kbps
        IMC_AACENC_BR_64,		///< 64 kbps
        IMC_AACENC_BR_80,		///< 80 kbps
        IMC_AACENC_BR_96,		///< 96 kbps
        IMC_AACENC_BR_112,		///< 112 kbps
        IMC_AACENC_BR_128,		///< 128 kbps
        IMC_AACENC_BR_160,		///< 160 kbps
        IMC_AACENC_BR_192,		///< 192 kbps
        IMC_AACENC_BR_224,		///< 224 kbps
        IMC_AACENC_BR_256,		///< 256 kbps
        IMC_AACENC_BR_320,		///< 320 kbps
        IMC_AACENC_BR_384,		///< 384 kbps
        IMC_AACENC_BR_448,		///< 448 kbps
        IMC_AACENC_BR_512,		///< 512 kbps
        IMC_AACENC_BR_1024,		///< 1024 kbps
        IMC_AACENC_BR_END		
    };

	///table for conversion bit rate index to value in kbps
    const int idx2bit_rate[] =
    {
        6,
        7,
        8,
        10,
        12,
        14,
        16,
        20,
        24,
        28,
        32,
        40,
        48,
        56,
        64,
        80,
        96,
        112,
        128,
        160,
        192,
        224,
        256,
        320,
        384,
        448,
        512,
        1024
    };


    /// MPEG version
    enum aacenc_mpeg_version_e
    {
        IMC_AACENC_MV_M4 = 0,		///< MPEG-4
        IMC_AACENC_MV_M2,			///< MPEG-2
        IMC_AACENC_MV_M4_PSP,		///< MPEG-4 (Sony PSP compatible)
        IMC_AACENC_MV_END			
    };

    /// audio object type
    enum aacenc_aot_e
    {
        IMC_AACENC_AOT_MAIN = 0,  // forbidden from now on
        IMC_AACENC_AOT_LC,			///< Low Complexity
        IMC_AACENC_AOT_END
    };


    /// output format
    enum aacenc_output_mode_e
    {
        IMC_AACENC_OUT_RAW = 0,			///< Raw output
        IMC_AACENC_OUT_ADTS = 1,		///< Output with ADTS headers
        IMC_AACENC_OUT_LATM = 2,		///< Output with LATM headers
        IMC_AACENC_OUT_END
    };


    /// VBR quality
    enum aacenc_vbr_mode_e
    {
        IMC_AACENC_VBR_LOW1     = 1,		///<  low quality vbr mode 1 (worst quality)
        IMC_AACENC_VBR_LOW2     = 2,		///<  low quality vbr mode 2
        IMC_AACENC_VBR_LOW3     = 3,		///<  low quality vbr mode 3
        IMC_AACENC_VBR_MEDIUM1  = 4,		///<  medium quality vbr mode 1	
        IMC_AACENC_VBR_MEDIUM2  = 5,		///<  medium quality vbr mode 2 
        IMC_AACENC_VBR_MEDIUM3  = 6,		///<  medium quality vbr mode 3
        IMC_AACENC_VBR_HIGH1    = 7,		///<  high quality vbr mode 1
        IMC_AACENC_VBR_HIGH2    = 8,		///<  high quality vbr mode 2
        IMC_AACENC_VBR_HIGH3    = 9			///<  high quality vbr mode 3 (best quality)
    };

    enum aacenc_trigger_e
    {
        IMC_AACENC_OFF = 0,
        IMC_AACENC_ON = 1
    };

    enum aacenc_preset_e
    {
        IMC_AACENC_PRESET_DEFAULT       = 0,
        IMC_AACENC_PRESET_PSP           = 0x00004000,
        IMC_AACENC_PRESET_IPOD          = 0x00005000,
        IMC_AACENC_PRESET_3GPP          = 0x00006000,
        IMC_AACENC_PRESET_3GPP2         = 0x00006100,
        IMC_AACENC_PRESET_ISMA          = 0x00006200,
        IMC_AACENC_PRESET_FLASH_LOWRES  = 0x00011010,
        IMC_AACENC_PRESET_FLASH_HIGHRES = 0x00011011,
        IMC_AACENC_PRESET_SILVERLIGHT   = 0x00012000
    };
};

#endif // MC_AAC_ENCODER_CONFIG

