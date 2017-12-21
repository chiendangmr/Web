/** 
 @file  fhg_enc_aac_mc.h
 @brief Property GUIDs for MainConcept Fraunhofer AAC encoder parameters.
 
 @verbatim
 File: fhg_enc_aac_mc.h

 Desc: Property GUIDs for MainConcept Fraunhofer AAC encoder parameters.
 
 Copyright (c) 2015 MainConcept GmbH or its affiliates.  All rights reserved.

 MainConcept and its logos are registered trademarks of MainConcept GmbH or its affiliates.  
 This software is protected by copyright law and international treaties.  Unauthorized 
 reproduction or distribution of any portion is prohibited by law.
 @endverbatim
 **/

#if !defined(MC_FHG_AAC_ENCODER_CONFIG)
#define MC_FHG_AAC_ENCODER_CONFIG

//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
//  IModuleConfig GUIDs
//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

///Sets the output format (MPEG-2, MPEG-4 or MPEG-4 for Sony PSP).
static const GUID FHGAACENC_MPEG_Version =
{0xfd882e86, 0xdcc2, 0x4120, {0xa6, 0xef, 0xe6, 0xe8, 0x5b, 0xc2, 0xd0, 0x59}};

///Sets the audio object type.
static const GUID FHGAACENC_Object_Type =
{0x49c7eb31, 0x2e21, 0x41ef, {0x92, 0xbe, 0x46, 0xc9, 0x10, 0x47, 0x45, 0xde}};

///Sets the output bit stream format (raw or with ADTS or LATM headers).
static const GUID FHGAACENC_Output_Format =
{0xeeae27e3, 0xd553, 0x4db0, { 0xa8, 0x3e, 0xe7, 0x28, 0x80, 0x33, 0xa0, 0xb7}};

///Enables/disables variable bit rate encoding mode.
static const GUID FHGAACENC_VBR =
{0x553936e3, 0xd553, 0x4db0, { 0xa8, 0x3e, 0xe7, 0x28, 0x80, 0x33, 0xa0, 0x01}};

///Sets variable bit rate mode quality.
static const GUID FHGAACENC_VBR_Mode =
{0x553936e3, 0xd553, 0x4db0, { 0xa8, 0x3e, 0xe7, 0x28, 0x80, 0x33, 0xa0, 0x02}};

///Channel mode
// {4C278FF5-C43B-4DD7-807F-5AD7137E97F0}
static const GUID FHGAACENC_Channel_Mode =
{0x4c278ff5, 0xc43b, 0x4dd7, { 0x80, 0x7f, 0x5a, 0xd7, 0x13, 0x7e, 0x97, 0xf0}};

///Spectral band replication value.
// {F44FAC80-AB55-444B-B86B-5EED52DE22BB}
static const GUID FHGAACENC_SBR_Signaling =
{0xf44fac80, 0xab55, 0x444b, { 0xb8, 0x6b, 0x5e, 0xed, 0x52, 0xde, 0x22, 0xbb}};

///Retrieves the number of encoded FHGAAC frames.
static const GUID FHGAACENC_Frame_Count =
{0x553936e3, 0xd553, 0x4db0, { 0xa8, 0x3e, 0xe7, 0x28, 0x80, 0x33, 0xa0, 0x04}};

///Retrieves the number of output bytes.
static const GUID FHGAACENC_Byte_Count =
{0x553936e3, 0xd553, 0x4db0, { 0xa8, 0x3e, 0xe7, 0x28, 0x80, 0x33, 0xa0, 0x05}};

static const GUID FHGAACENC_Byte_Count_Long = 
{ 0xad86ebf, 0x5fe3, 0x48bc, { 0xb8, 0xe0, 0xe2, 0x97, 0x78, 0x1d, 0x95, 0xae } };

///Retrieves the output sample rate.
static const GUID FHGAACENC_Sample_Rate =
{0x553936e3, 0xd553, 0x4db0, { 0xa8, 0x3e, 0xe7, 0x28, 0x80, 0x33, 0xa0, 0x06}};

///Retrieves the SBR core sample rate.
static const GUID FHGAACENC_Core_Sample_Rate =
{0x553936e3, 0xd553, 0x4db0, { 0xa8, 0x3e, 0xe7, 0x28, 0x80, 0x33, 0xa0, 0x07}};

///Retrieves the output channel configuration.
static const GUID FHGAACENC_Channel_Config =
{0x553936e3, 0xd553, 0x4db0, { 0xa8, 0x3e, 0xe7, 0x28, 0x80, 0x33, 0xa0, 0x09}};

///Retrieves the PS core channel configuration.
static const GUID FHGAACENC_Core_Channel_Config =
{0x553936e3, 0xd553, 0x4db0, { 0xa8, 0x3e, 0xe7, 0x28, 0x80, 0x33, 0xa0, 0x0a}};

///Specifies if audio stream contains CRC protection.
static const GUID FHGAACENC_Protect_ADTS_Stream = 
{0xb3a79c4c, 0xea47, 0x4ccb, { 0xbe, 0xb5, 0x76, 0xaa, 0xb0, 0xa3, 0x49, 0xf9}};

///Sets default settings for the selected preset.
static const GUID FHGAACENC_SetDefValues = 
{ 0x237776cf, 0x191b, 0x41e8, { 0xb7, 0x7d, 0x75, 0xd9, 0x60, 0x84, 0xf0, 0x1f } };

// {94F903FD-2A0C-480E-B78A-4F7CF2D3FA3C}
static const GUID FHGAACENC_PTS_Units = 
{    0x94f903fd, 0x2a0c, 0x480e, { 0xb7, 0x8a, 0x4f, 0x7c, 0xf2, 0xd3, 0xfa, 0x3c } };

// {3D490E66-7CFD-4351-8AD9-3F8F2CD51289}
static const GUID FHGAACENC_MetadataMode = 
{    0x3d490e66, 0x7cfd, 0x4351, { 0x8a, 0xd9, 0x3f, 0x8f, 0x2c, 0xd5, 0x12, 0x89 } };

// {86DAA5AF-1AA9-4997-BCD1-D596A10B8021}
static const GUID FHGAACENC_GranuleLength = 
{    0x86daa5af, 0x1aa9, 0x4997, { 0xbc, 0xd1, 0xd5, 0x96, 0xa1, 0xb, 0x80, 0x21 } };

// {8B59EE07-BB79-4858-9772-C2C4C45E6055}
static const GUID FHGAACENC_Quality = 
{    0x8b59ee07, 0xbb79, 0x4858, { 0x97, 0x72, 0xc2, 0xc4, 0xc4, 0x5e, 0x60, 0x55 } };

// {61241091-9F47-4F64-AD75-97CBD3771537}
static const GUID FHGAACENC_RestartInterval = 
{    0x61241091, 0x9f47, 0x4f64, { 0xad, 0x75, 0x97, 0xcb, 0xd3, 0x77, 0x15, 0x37 } };

// {4E0B00C9-F069-4F69-9041-053C26CEFE40}
static const GUID FHGAACENC_DashSegmentationFlag =
{    0x4e0b00c9, 0xf069, 0x4f69, { 0x90, 0x41, 0x5, 0x3c, 0x26, 0xce, 0xfe, 0x40 } };

// {7E9F1C9E-9108-49B9-B01A-19D6FB3E4E7F}
static const GUID FHGAACENC_UseSbrCrc =
{    0x7e9f1c9e, 0x9108, 0x49b9, { 0xb0, 0x1a, 0x19, 0xd6, 0xfb, 0x3e, 0x4e, 0x7f } };

// {ED720EA3-E6B6-4498-B5BB-E8A52A4E8F88}
static const GUID FHGAACENC_SbrHeaderTimeInterval = 
{    0xed720ea3, 0xe6b6, 0x4498, { 0xb5, 0xbb, 0xe8, 0xa5, 0x2a, 0x4e, 0x8f, 0x88 } };

// {29DEA6B3-A925-405D-B4B5-29D6441143E7}
static const GUID FHGAACENC_LatmSmcTimeInterval = 
{ 0x29dea6b3, 0xa925, 0x405d, { 0xb4, 0xb5, 0x29, 0xd6, 0x44, 0x11, 0x43, 0xe7 } };


// Metadata parameters

// {E0E6FA7E-6F07-43B2-ACEB-785D5B5C62D9}
static const GUID FHGAACENC_MetadataUpdate = 
{     0xe0e6fa7e, 0x6f07, 0x43b2, { 0xac, 0xeb, 0x78, 0x5d, 0x5b, 0x5c, 0x62, 0xd9 } };

// {D9699C56-A7DE-42C5-9476-A67D59B4641E}
static const GUID FHGAACENC_MetadataWrite = 
{     0xd9699c56, 0xa7de, 0x42c5, { 0x94, 0x76, 0xa6, 0x7d, 0x59, 0xb4, 0x64, 0x1e } };

// {2182791F-B2C6-45C1-889E-066E9D2C2B9D}
static const GUID FHGAACENC_DRC_Profile = 
{     0x2182791f, 0xb2c6, 0x45c1, { 0x88, 0x9e, 0x6, 0x6e, 0x9d, 0x2c, 0x2b, 0x9d } };

// {3DDEEE25-8510-4AB8-B9FC-6F935D1FE882}
static const GUID FHGAACENC_Comp_profile = 
{     0x3ddeee25, 0x8510, 0x4ab8, { 0xb9, 0xfc, 0x6f, 0x93, 0x5d, 0x1f, 0xe8, 0x82 } };

// {E4539C69-F615-4611-A2BF-C98398F18E5A}
static const GUID FHGAACENC_Drc_target_ref_level = 
{     0xe4539c69, 0xf615, 0x4611, { 0xa2, 0xbf, 0xc9, 0x83, 0x98, 0xf1, 0x8e, 0x5a } };

// {8C583948-C140-4A8E-AC83-8545BC79F88A}
static const GUID FHGAACENC_Comp_target_ref_level = 
{     0x8c583948, 0xc140, 0x4a8e, { 0xac, 0x83, 0x85, 0x45, 0xbc, 0x79, 0xf8, 0x8a } };

// {CF2818A8-1C6F-46A7-8043-28241274905B}
static const GUID FHGAACENC_Drc_ext =
{    0xcf2818a8, 0x1c6f, 0x46a7, 0x80, 0x43, 0x28, 0x24, 0x12, 0x74, 0x90, 0x5b};

// {255EA8AC-4905-4865-8F21-C24D9CAE1122}
static const GUID FHGAACENC_Comp_ext =
{    0x255ea8ac, 0x4905, 0x4865, 0x8f, 0x21, 0xc2, 0x4d, 0x9c, 0xae, 0x11, 0x22};

// {204956A0-72D5-4CCF-8511-162662E626F4}
static const GUID FHGAACENC_Prog_ref_level_present =
{    0x204956a0, 0x72d5, 0x4ccf, 0x85, 0x11, 0x16, 0x26, 0x62, 0xe6, 0x26, 0xf4};

// {636E525A-3DBC-4C7B-9F4A-2DD5F91A7A42}
static const GUID FHGAACENC_Prog_ref_level = 
{     0x636e525a, 0x3dbc, 0x4c7b, { 0x9f, 0x4a, 0x2d, 0xd5, 0xf9, 0x1a, 0x7a, 0x42 } };

// {2B2C9D2F-B871-42CC-AB32-FFEA461EDA21}
static const GUID FHGAACENC_Pce_mixdown_idx_present =
{    0x2b2c9d2f, 0xb871, 0x42cc, 0xab, 0x32, 0xff, 0xea, 0x46, 0x1e, 0xda, 0x21};

// {ECE44D49-1753-4963-868D-34B06F489AFA}
static const GUID FHGAACENC_Etsi_dmx_level_present =
{    0xece44d49, 0x1753, 0x4963, 0x86, 0x8d, 0x34, 0xb0, 0x6f, 0x48, 0x9a, 0xfa};

// {08FE1957-4A03-45E0-BFF9-16038F19AC59}
static const GUID FHGAACENC_Center_mix_level =
{    0x8fe1957, 0x4a03, 0x45e0, 0xbf, 0xf9, 0x16, 0x3, 0x8f, 0x19, 0xac, 0x59};

// {D5162559-807B-4970-8F57-4040A0F9EEB4}
static const GUID FHGAACENC_Surround_mix_level = 
{    0xd5162559, 0x807b, 0x4970, 0x8f, 0x57, 0x40, 0x40, 0xa0, 0xf9, 0xee, 0xb4};

// {16F645A8-EFC1-4467-BA6D-6339E4BCBFA5}
static const GUID FHGAACENC_Dolby_surround_mode = 
{    0x16f645a8, 0xefc1, 0x4467, 0xba, 0x6d, 0x63, 0x39, 0xe4, 0xbc, 0xbf, 0xa5};

// {ABB131BB-D1CF-468B-B9B5-D7BD973322E1}
static const GUID FHGAACENC_Drc_presentation_mode = 
{    0xabb131bb, 0xd1cf, 0x468b, 0xb9, 0xb5, 0xd7, 0xbd, 0x97, 0x33, 0x22, 0xe1};

// {51EC0A06-8254-4A25-86C7-B6E29C83487E}
static const GUID FHGAACENC_Dc_filter = 
{    0x51ec0a06, 0x8254, 0x4a25, 0x86, 0xc7, 0xb6, 0xe2, 0x9c, 0x83, 0x48, 0x7e};

// {432CA2AE-E876-479A-9791-87827C0EA117}
static const GUID FHGAACENC_Lfe_lowpass_filter = 
{    0x432ca2ae, 0xe876, 0x479a, 0x97, 0x91, 0x87, 0x82, 0x7c, 0xe, 0xa1, 0x17};

// {20A5405F-CE19-4FB6-83F6-EC0E33B07595}
static const GUID FHGAACENC_Sur_phase_90 = 
{    0x20a5405f, 0xce19, 0x4fb6, 0x83, 0xf6, 0xec, 0xe, 0x33, 0xb0, 0x75, 0x95};

// {2A1A5165-70FB-4D76-BE2F-2719E1C642A0}
static const GUID FHGAACENC_Sur_att_3dB =
{    0x2a1a5165, 0x70fb, 0x4d76, 0xbe, 0x2f, 0x27, 0x19, 0xe1, 0xc6, 0x42, 0xa0};

// {BB809627-16A3-4428-B974-E6A593D05ACB}
static const GUID FHGAACENC_Bitrate_custom = 
{ 0xbb809627, 0x16a3, 0x4428, { 0xb9, 0x74, 0xe6, 0xa5, 0x93, 0xd0, 0x5a, 0xcb } };


////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
// GUID                             Type        Available range     Default value   Note
// MC_BITRATE_AVG                   VT_I4       [0, 27; 255]         [19]            Sets average output bit rate
// FHGAACENC_MPEG_Version            VT_I4       [0, 1]              [0]             Sets the output format (MPEG-2 or MPEG-4)
// FHGAACENC_Object_Type             VT_I4       [0, 1]              [1]             Sets the audio object type (Main or Low Complexity)
// FHGAACENC_Output_Format           VT_I4       [0, 1]              [1]             Sets the output bit stream format (raw or with ADTS headers)
// FHGAACENC_VBR                     VT_I4       [0, 1]              [0]             Enables/disables variable bit rate encoding mode
// FHGAACENC_VBR_Mode                VT_I4       [1, 9]              [6]             Sets variable bit rate mode quality
// FHGAACENC_Protect_ADTS_Stream     VT_I4       [0, 1]              [0]             Specifies if audio stream contains CRC protection
// FHGAACENC_PTS_Units               VT_I4                           [27000000]      This field specifies the units for the time stamp offset
// FHGAACENC_Quality                 VT_I4       [0, 3]              [1]             This field specifies the desired level of audio quality
// FHGAACENC_RestartInterval         VT_I8                           [0]             Restart interval
// FHGAACENC_MetadataWrite           VT_I4       [0, 1]              [0]             Indication flag for metadata write in first frame
// FHGAACENC_MetadataUpdate          VT_I4       [0, 1]              [0]             Indication flag for write of updated metadata
// FHGAACENC_MetadataMode            VT_I4       [0, 2]              [0]             This field specifies the program metadata mode
// FHGAACENC_GranuleLength           VT_I4       [960; 1024]         [1024]          This field specifies the granule length used for the MDCT in samples
// FHGAACENC_DRC_Profile             VT_I4       [-1, 5]             [0]             This field specifies the AAC DRC compression profile
// FHGAACENC_Comp_profile            VT_I4       [-2, 5]             [0]             This field specifies the AAC extended DRC (ETSI) compression profile
// FHGAACENC_Drc_target_ref_level    VT_R4                           [0.0]           This field specifies the expected target reference level at decoder side
// FHGAACENC_Comp_target_ref_level   VT_R4                           [0.0]           This field specifies the expected target reference level at decoder side
// FHGAACENC_Drc_ext                 VT_R4                           [0.0]           This field specifies the AAC DRC compression value
// FHGAACENC_Comp_ext                VT_R4                           [0.0]           This field specifies the extended DRC compression value
// FHGAACENC_Prog_ref_level_present  VT_I4       [0, 1]              [0]             This flag indicates whether prog_ref_level is present
// FHGAACENC_Prog_ref_level          VT_R4       [-31.75, 0.0]       [0.0]           This field specifies the program reference level or dialog level
// FHGAACENC_Pce_mixdown_idx_present VT_I4       [0, 1]              [0]             This flag indicates whether a downmix index should be written into the program configuration element (PCE) of the bit stream
// FHGAACENC_Etsi_dmx_level_present  VT_I4       [0, 1]              [0]             This flag indicates whether a downmix level should be written into the ancillary data (ETSI)
// FHGAACENC_Center_mix_level        VT_I4       [0, 7]              [0]             This field specifies an index representing the center downmix level
// FHGAACENC_Surround_mix_level      VT_I4       [0, 7]              [0]             This field specifies an index denoting the surround downmix level
// FHGAACENC_Dolby_surround_mode     VT_I4       [0, 2]              [0]             This field indicates whether 2-channel content is Dolby Surround encoded
// FHGAACENC_Drc_presentation_mode   VT_I4       [0, 2]              [0]             This field specifies the DRC presentation mode of ETST TS 101 154, annex C.5
// FHGAACENC_Dc_filter               VT_I4       [0, 1]              [0]             This flag indicates whether a DC blocking filter (-3dB at 1Hz IIR high-pass) should be applied to all channels of the input signal before encoding
// FHGAACENC_Lfe_lowpass_filter      VT_I4       [0, 1]              [0]             This flag indicates whether a 120Hz low-pass filter (8th order IIR) should be applied to the LFE channel of the input signal before encoding
// FHGAACENC_Sur_phase_90            VT_I4       [0, 1]              [0]             This flag indicates whether a 90 degree phase shift (long FIR filter) should be applied to the surround channel(s) of the input signal before encoding
// FHGAACENC_Sur_att_3dB             VT_I4       [0, 1]              [0]             This flag indicates whether the surround channel(s) of the input signal should be attenuated by 3dB before encoding
// FHGAACENC_DashSegmentationFlag    VT_UI4      [0, 1]              [0]             This flag indicates DASH segmentation
// FHGAACENC_Bitrate_custom          VT_UI4      [0, LONG_MAX]       [0]             This field indicates custom bitrate in kbits per second
// FHGAACENC_Frame_Count             VT_I4                           Read only       Retrieves the number of encoded AAC frames
// FHGAACENC_Byte_Count              VT_I4                           Read only       Retrieves the number of output bytes
// FHGAACENC_Byte_Count_Long         VT_I8                           Read only       Retrieves the number of output bytes
// FHGAACENC_Sample_Rate             VT_I4                           Read only       Retrieves the output sample rate
// FHGAACENC_Core_Sample_Rate        VT_I4                           Read only       Retrieves the SBR core sample rate
// FHGAACENC_Channel_Config          VT_I4                           Read only       Retrieves the output channel config
// FHGAACENC_Core_Channel_Config     VT_I4                           Read only       Retrieves the PS core channel config
////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

/**
* namespace EFHGAACENC
* @brief Fraunhofer AAC Encoder DS Filter namespace
**/
namespace EFHGAACENC
{

    /// bit rate
    enum fhg_aacenc_bit_rate_e
    {
        IMC_FHGAACENC_BR_6 = 0,		    ///< 6 kbps
        IMC_FHGAACENC_BR_7,		        ///< 7 kbps
        IMC_FHGAACENC_BR_8,		        ///< 8 kbps
        IMC_FHGAACENC_BR_10,		    ///< 10 kbps
        IMC_FHGAACENC_BR_12,		    ///< 12 kbps
        IMC_FHGAACENC_BR_14,		    ///< 14 kbps
        IMC_FHGAACENC_BR_16,		    ///< 16 kbps
        IMC_FHGAACENC_BR_20,		    ///< 20 kbps
        IMC_FHGAACENC_BR_24,		    ///< 24 kbps
        IMC_FHGAACENC_BR_28,		    ///< 28 kbps
        IMC_FHGAACENC_BR_32,		    ///< 32 kbps
        IMC_FHGAACENC_BR_40,		    ///< 40 kbps
        IMC_FHGAACENC_BR_48,		    ///< 48 kbps
        IMC_FHGAACENC_BR_56,		    ///< 56 kbps
        IMC_FHGAACENC_BR_64,		    ///< 64 kbps
        IMC_FHGAACENC_BR_80,		    ///< 80 kbps
        IMC_FHGAACENC_BR_96,		    ///< 96 kbps
        IMC_FHGAACENC_BR_112,		    ///< 112 kbps
        IMC_FHGAACENC_BR_128,		    ///< 128 kbps
        IMC_FHGAACENC_BR_160,		    ///< 160 kbps
        IMC_FHGAACENC_BR_192,		    ///< 192 kbps
        IMC_FHGAACENC_BR_224,		    ///< 224 kbps
        IMC_FHGAACENC_BR_256,		    ///< 256 kbps
        IMC_FHGAACENC_BR_320,		    ///< 320 kbps
        IMC_FHGAACENC_BR_384,		    ///< 384 kbps
        IMC_FHGAACENC_BR_448,		    ///< 448 kbps
        IMC_FHGAACENC_BR_512,		    ///< 512 kbps
        IMC_FHGAACENC_BR_1024,		    ///< 1024 kbps
        IMC_FHGAACENC_BR_END,
        IMC_FHGAACENC_BR_CUSTOM = 255	///< Custom bitrate        		
    };

	///table for conversion bit rate index to value in kbps
    const int idx2bit_rate[] =
    {
        6,      ///<    6   kbps
        7,      ///<    7   kbps
        8,      ///<    8   kbps
        10,     ///<    10  kbps
        12,     ///<    12  kbps
        14,     ///<    14  kbps
        16,     ///<    16  kbps
        20,     ///<    20  kbps
        24,     ///<    24  kbps
        28,     ///<    28  kbps
        32,     ///<    32  kbps
        40,     ///<    40  kbps
        48,     ///<    48  kbps
        56,     ///<    56  kbps
        64,     ///<    64  kbps
        80,     ///<    80  kbps
        96,     ///<    96  kbps
        112,    ///<    112 kbps
        128,    ///<    128 kbps
        160,    ///<    160 kbps
        192,    ///<    192 kbps
        224,    ///<    224 kbps
        256,    ///<    256 kbps
        320,    ///<    320 kbps
        384,    ///<    384 kbps
        448,    ///<    448 kbps
        512,    ///<    512 kbps
        1024    ///<    1024kbps
    };

    // channel mode
    enum fhg_aacenc_ch_mode_e
    {
        IMC_FHGAACENC_CH_MODE_AUTO                =  0, ///< auto
        IMC_FHGAACENC_CH_MODE_MONO                =  1, ///< 1   channel mono
        IMC_FHGAACENC_CH_MODE_STEREO              =  2, ///< 2   channel stereo
        IMC_FHGAACENC_CH_MODE_3                   =  3, ///< 3   channel audio ( center + left/right front) not supported
        IMC_FHGAACENC_CH_MODE_4                   =  4, ///< 4   channel audio ( center + left/right front +     rear   surround speaker       )  not supported
        IMC_FHGAACENC_CH_MODE_5                   =  5, ///< 5   channel audio ( center + left/right front + left/right surround speaker       )
        IMC_FHGAACENC_CH_MODE_5_1                 =  6, ///< 5.1 channel audio ( center + left/right front + left/right surround speaker + LFE )
        IMC_FHGAACENC_CH_MODE_7_1                 =  7, ///< 7.1 channel audio ( center + left/right front + left/right outside front + left/right surround speakers + LFE )
        IMC_FHGAACENC_CH_MODE_7_1_SIDE_CHANNEL    =  8, ///< 7.1 channel audio ( center + left/right front + left/right side channels + left/right surround speakers + LFE )
        IMC_FHGAACENC_CH_MODE_7_1_REAR_SURROUND   =  9, ///< 7.1 channel audio ( center + left/right front + left/right rear surround speakers  + left/right surround speakers + LFE )
        IMC_FHGAACENC_CH_MODE_7_1_FRONT_CENTER    = 10, ///< 7.1 channel audio ( center + left/right front + left/right frontal center speakers + left/right surround speakers + LFE )
        IMC_FHGAACENC_CH_MODE_DUAL_MONO           = 11, ///< 2   independent channels
        IMC_FHGAACENC_CH_MODE_4TIMES1             = 12, ///< 4   independent channels
        IMC_FHGAACENC_CH_MODE_6TIMES1             = 13, ///< 6   independent channels
        IMC_FHGAACENC_CH_MODE_8TIMES1             = 14, ///< 8   independent channels
        IMC_FHGAACENC_CH_MODE_12TIMES1            = 15, ///< 12  independent channels
        IMC_FHGAACENC_CH_MODE_2TIMES2             = 16, ///< 2   stereo channel pairs
        IMC_FHGAACENC_CH_MODE_3TIMES2             = 17, ///< 3   stereo channel pairs
        IMC_FHGAACENC_CH_MODE_4TIMES2             = 18 ///< 4   stereo channel pairs
    };

    /// MPEG version
    enum fhg_aacenc_mpeg_version_e
    {
        IMC_FHGAACENC_MV_M4 = 0,	                ///< MPEG-4
        IMC_FHGAACENC_MV_M2,		                ///< MPEG-2
        IMC_FHGAACENC_MV_END			
    };

    /// audio object type
    enum fhg_aacenc_aot_e
    {
        IMC_FHGAACENC_AOT_LC                = 2,  ///< Low Complexity
        IMC_FHGAACENC_AOT_HEAAC             = 5,  ///< AAC LC + SBR
        IMC_FHGAACENC_AOT_PS                = 29, ///< AAC LC + SBR + PS
        IMC_FHGAACENC_AOT_END
    };

    /// output format
    enum fhg_aacenc_output_mode_e
    {
        IMC_FHGAACENC_OUT_RAW = 0,			///< Raw output
        IMC_FHGAACENC_OUT_ADTS = 1,		    ///< Output with ADTS headers
        IMC_FHGAACENC_OUT_LATM = 2,		    ///< Output with LATM headers
        IMC_FHGAACENC_OUT_END
    };

    /// VBR quality
    enum fhg_aacenc_vbr_mode_e
    {
        IMC_FHGAACENC_VBR_LOW1     = 1,		///<  low quality vbr mode 1 (worst quality)
        IMC_FHGAACENC_VBR_LOW2     = 2,		///<  low quality vbr mode 2
        IMC_FHGAACENC_VBR_LOW3     = 3,		///<  low quality vbr mode 3
        IMC_FHGAACENC_VBR_MEDIUM1  = 4,		///<  medium quality vbr mode 1	
        IMC_FHGAACENC_VBR_MEDIUM2  = 5,		///<  medium quality vbr mode 2 
        IMC_FHGAACENC_VBR_MEDIUM3  = 6,		///<  medium quality vbr mode 3
        IMC_FHGAACENC_VBR_HIGH1    = 7,		///<  high quality vbr mode 1
        IMC_FHGAACENC_VBR_HIGH2    = 8,		///<  high quality vbr mode 2
        IMC_FHGAACENC_VBR_HIGH3    = 9		///<  high quality vbr mode 3 (best quality)
    };

    // trigger
    enum fhg_aacenc_trigger_e
    {
        IMC_FHGAACENC_OFF = 0,               ///<  do not apply default settings
        IMC_FHGAACENC_ON = 1                 ///<  apply default settings
    };
    
    // metadata mode
    enum fhg_aacenc_metadata_e
    {
        IMC_FHGAACENC_METADATA_NONE        = 0,  ///<    do not embed any metadata
        IMC_FHGAACENC_METADATA_MPEG        = 1,  ///<    embed MPEG defined metadata only
        IMC_FHGAACENC_METADATA_MPEG_ETSI   = 2,  ///<    embed all metadata (MPEG DRC and ETSI ancillary data)
    };

    // granule length
    enum fhg_aacenc_granule_len_e
    {
        IMC_FHGAACENC_GRANULE_960          = 960,    ///<    960 samples
        IMC_FHGAACENC_GRANULE_1024         = 1024,   ///<    1024 samples
    };

    // quality
    enum fhg_aacenc_quality_e
    {
        IMC_FHGAACENC_QUAL_FAST            = 0,      ///<    Fastest operation, some quality compromises
        IMC_FHGAACENC_QUAL_MEDIUM          = 1,      ///<    Good quality, slightly slower operation
        IMC_FHGAACENC_QUAL_HIGH            = 2,      ///<    Very good quality, notably slower operation
        IMC_FHGAACENC_QUAL_HIGHEST         = 3       ///<    Highest quality, forces preferred sampling rate
    };

    // SBR signaling
    enum fhg_aacenc_sbr_signal_e
    {
        IMC_FHGAACENC_SBR_SIG_IMPLICIT      = 0,     ///<    Implicit backward compatible signaling
        IMC_FHGAACENC_SBR_SIG_EXPL_BC       = 1,     ///<    Explicit backward compatible signaling
        IMC_FHGAACENC_SBR_SIG_EXPL_HIER     = 2      ///<    Explicit hierarchical signaling, non backward compatible
    };

    // compression profile
    enum fhg_aacenc_compres_profile_e
    {
        IMC_FHGAACENC_DRC_NONE              = 0,     ///<    No compression, but active limiter functionality
        IMC_FHGAACENC_DRC_FILMSTANDARD      = 1,     ///<    Compression as known in broadcast applications (plus overloaded limiter)
        IMC_FHGAACENC_DRC_FILMLIGHT         = 2,     ///<    Compression as known in broadcast applications (plus overloaded limiter)
        IMC_FHGAACENC_DRC_MUSICSTANDARD     = 3,     ///<    Compression as known in broadcast applications (plus overloaded limiter)
        IMC_FHGAACENC_DRC_MUSICLIGHT        = 4,     ///<    Compression as known in broadcast applications (plus overloaded limiter)
        IMC_FHGAACENC_DRC_SPEECH            = 5,     ///<    Compression as known in broadcast applications (plus overloaded limiter)
        IMC_FHGAACENC_DRC_EMBED_EXTERN      = -1,    ///<    Embed externally fed values (mainly used if values were transcoded)
        IMC_FHGAACENC_DRC_NOT_PRESENT       = -2     ///<    Disable writing gain factor
    };

    // downmix level
    enum fhg_aacenc_downmix_level_e
    {
        IMC_FHGAACENC_DMX_GAIN_0_dB         = 0,     ///<    0.0 dB  /   -3.0 dB (ETSI)
        IMC_FHGAACENC_DMX_GAIN_1_5_dB       = 1,     ///<    -1.5 dB /   -3.0 dB (ETSI)
        IMC_FHGAACENC_DMX_GAIN_3_dB         = 2,     ///<    -3.0 dB /   -3.0 dB (ETSI)
        IMC_FHGAACENC_DMX_GAIN_4_5_dB       = 3,     ///<    -4.5 dB /   -6.0 dB (ETSI)
        IMC_FHGAACENC_DMX_GAIN_6_dB         = 4,     ///<    -6.0 dB /   -6.0 dB (ETSI)
        IMC_FHGAACENC_DMX_GAIN_7_5_dB       = 5,     ///<    -7.5 dB /   -9.0 dB (ETSI)
        IMC_FHGAACENC_DMX_GAIN_9_dB         = 6,     ///<    -9.0 dB /   -9.0 dB (ETSI)
        IMC_FHGAACENC_DMX_GAIN_INF          = 7      ///<    -INF dB /   -INF dB (ETSI)
    };

    // dolby surround mode
    enum fhg_aacenc_dolby_surround_ind_e
    {
        IMC_FHGAACENC_DSUR_NOT_INDICATED    = 0,     ///<    Dolby Surround mode not indicated
        IMC_FHGAACENC_DSUR_NOT_USED         = 1,     ///<    2-ch audio part is not Dolby surround encoded 
        IMC_FHGAACENC_DSUR_IS_USED          = 2,     ///<    2-ch audio part is Dolby surround encoded
    };

    // drc present mode
    enum fhg_aacenc_drc_present_mode_ind_e
    {
        IMC_FHGAACENC_DRC_PRESENTATION_NOT_INDICATED = 0,    ///<    DRC presentation mode not indicated
        IMC_FHGAACENC_DRC_PRESENTATION_MODE_1        = 1,    ///<    DRC presentation mode 1
        IMC_FHGAACENC_DRC_PRESENTATION_MODE_2        = 2     ///<    DRC presentation mode 2
    };
};

#endif // MC_FHG_AAC_ENCODER_CONFIG

