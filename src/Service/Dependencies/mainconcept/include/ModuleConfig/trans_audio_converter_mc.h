/** 
 @file trans_audio_converter_mc.h
 @brief  Property GUIDs for MainConcept Audio Converter parameters.
 
 @verbatim
 File: trans_audio_converter_mc.h

 Desc: Property GUIDs for MainConcept Audio Converter parameters.
 
 Copyright (c) 2015 MainConcept GmbH or its affiliates.  All rights reserved.

 MainConcept and its logos are registered trademarks of MainConcept GmbH or its affiliates.  
 This software is protected by copyright law and international treaties.  Unauthorized 
 reproduction or distribution of any portion is prohibited by law.
 @endverbatim
 **/


#if !defined(MC_AUDIO_CONVERTER_CONFIG)
#define MC_AUDIO_CONVERTER_CONFIG

// {BB882F03-FA3B-45c6-845B-B82F5B79F57D}
/// Specifies number of the output channels.
static const GUID AC_OutputChannels = 
{ 0xbb882f03, 0xfa3b, 0x45c6, { 0x84, 0x5b, 0xb8, 0x2f, 0x5b, 0x79, 0xf5, 0x7d } };

// {3B05F1D5-1FCD-481f-B17E-8358DEBC56CD}
/// Specifies the output bits per sample parameter.
static const GUID AC_OutputBPS = 
{ 0x3b05f1d5, 0x1fcd, 0x481f, { 0xb1, 0x7e, 0x83, 0x58, 0xde, 0xbc, 0x56, 0xcd } };

// {27A6EC3C-73DE-4b36-9EA8-8236C8EDE1E9}
/// Specifies the output audio format.
static const GUID AC_OutputFormat = 
{ 0x27a6ec3c, 0x73de, 0x4b36, { 0x9e, 0xa8, 0x82, 0x36, 0xc8, 0xed, 0xe1, 0xe9 } };

// {F80B58A0-253B-42b9-AD1C-3878C213FD0D}
/// Specifies the output channel mask.
static const GUID AC_OutputChannelMask = 
{ 0xf80b58a0, 0x253b, 0x42b9, { 0xad, 0x1c, 0x38, 0x78, 0xc2, 0x13, 0xfd, 0xd } };

// {CB0FD7C1-DBA2-493a-A9AB-CEA5AA157622}
/// Specifies the output sample rate.
static const GUID AC_OutputSampleRate = 
{ 0xcb0fd7c1, 0xdba2, 0x493a, { 0xa9, 0xab, 0xce, 0xa5, 0xaa, 0x15, 0x76, 0x22 } };

// {D0A2CE7F-35F5-43fa-A4B2-C6D893F44D67}
/// Displays number of the input channels.
static const GUID AC_InputChannels = 
{ 0xd0a2ce7f, 0x35f5, 0x43fa, { 0xa4, 0xb2, 0xc6, 0xd8, 0x93, 0xf4, 0x4d, 0x67 } };

// {514133D4-2E1E-4906-BB2A-0F2DB1D0B403}
/// Displays input bits per sample parameter.
static const GUID AC_InputBPS = 
{ 0x514133d4, 0x2e1e, 0x4906, { 0xbb, 0x2a, 0xf, 0x2d, 0xb1, 0xd0, 0xb4, 0x3 } };

// {4A2173E8-DBCD-4589-B3C1-1AD459A9BF6E}
/// Displays the input audio format.
static const GUID AC_InputFormat = 
{ 0x4a2173e8, 0xdbcd, 0x4589, { 0xb3, 0xc1, 0x1a, 0xd4, 0x59, 0xa9, 0xbf, 0x6e } };

// {2D08D2B4-9F5A-4276-9872-DC4FED62ACCF}
/// Displays the input channels mask.
static const GUID AC_InputChannelMask = 
{ 0x2d08d2b4, 0x9f5a, 0x4276, { 0x98, 0x72, 0xdc, 0x4f, 0xed, 0x62, 0xac, 0xcf } };

// {191B6FA0-99F1-426e-9A06-3707D134B9DC}
/// Displays the input sample rate.
static const GUID AC_InputSampleRate = 
{ 0x191b6fa0, 0x99f1, 0x426e, { 0x9a, 0x6, 0x37, 0x7, 0xd1, 0x34, 0xb9, 0xdc } };

// {FA1D4B68-2CA4-42A0-A24C-40C332923CFD}
/// Enables/disables multiple input pins.
static const GUID AC_MultipleInputPins = 
{ 0xfa1d4b68, 0x2ca4, 0x42a0, { 0xa2, 0x4c, 0x40, 0xc3, 0x32, 0x92, 0x3c, 0xfd } };

// {37F0F3C2-1A52-464C-B81C-2086D5B7498B}
/// Enables/disables multiple output pins.
static const GUID AC_MultipleOutputPins = 
{ 0x37f0f3c2, 0x1a52, 0x464c, { 0xb8, 0x1c, 0x20, 0x86, 0xd5, 0xb7, 0x49, 0x8b } };

/**
* namespace AUDIO_CONVERTER
* @brief Audio Converter namespace
**/
namespace AUDIO_CONVERTER
{

	/// Data format defines
    enum DataFormat_t
    {
        FORMAT_AUTO = 0,		///< Auto (the same as input)
        FORMAT_PCM = 1,			///< PCM 
        FORMAT_DVD_LPCM = 2,	///< DVD LPCM 
        FORMAT_HDMV_LPCM = 3,	///< HDMV LPCM 
        FORMAT_AES3 = 4,		///< AES3 audio 
        FORMAT_FLOAT = 5		///< Float
    };

	/// Flags for channel mask
    enum AudioFlag_t
    {
        CHANNEL_L   =   0x1,		///< left channel
        CHANNEL_R   =   0x2,		///< right channel
        CHANNEL_C   =   0x4,		///< center channel
        CHANNEL_LFE =   0x8,		///< LFE channel
        CHANNEL_Ls  =   0x10,		///< left surround channel
        CHANNEL_Rs  =   0x20,		///< right surround channel
        CHANNEL_Lrs  =   0x40,		///< left back surround channel
        CHANNEL_Rrs  =   0x80		///< left back surround channel
    };
};

#endif