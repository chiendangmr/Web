/** 
 @file  enc_mpa_mc.h
 @brief Property GUIDs for MainConcept MPEG audio encoder parameters.
 
 @verbatim
 File: enc_mpa_mc.h

 Desc: Property GUIDs for MainConcept MPEG audio encoder parameters.
 
 Copyright (c) 2015 MainConcept GmbH or its affiliates.  All rights reserved.

 MainConcept and its logos are registered trademarks of MainConcept GmbH or its affiliates.  
 This software is protected by copyright law and international treaties.  Unauthorized 
 reproduction or distribution of any portion is prohibited by law.
 @endverbatim
 **/
#if !defined(MC_L2_ENCODER_CONFIG)
#define MC_L2_ENCODER_CONFIG

//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
//  IModuleConfig GUIDs
//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

/// Sets output bitrate for sample rates defined in ISO/IEC 11172-3.
// {43662000-6552-4f28-81C7-4227048B0A41}
static const GUID EL2ENC_BITRATE_MPEG1 =
{ 0x43662000, 0x6552, 0x4f28, { 0x81, 0xc7, 0x42, 0x27, 0x4, 0x8b, 0xa, 0x41}};

/// Sets output bitrate for sampling rates defined in ISO/IEC 13818-3.
// {43662001-6552-4f28-81C7-4227048B0A41}
static const GUID EL2ENC_BITRATE_MPEG2 =
{ 0x43662001, 0x6552, 0x4f28, { 0x81, 0xc7, 0x42, 0x27, 0x4, 0x8b, 0xa, 0x41}};

/// Sets the Copyright flag.
// {A5FF8C33-56F6-423d-B668-26078B5BEC6C}
static const GUID EL2ENC_COPYRIGHT =
{ 0xa5ff8c33, 0x56f6, 0x423d, { 0xb6, 0x68, 0x26, 0x7, 0x8b, 0x5b, 0xec, 0x6c}};

/// Sets the Original flag.
// {436DCDBA-6552-4f28-81C7-4227048B0A41}
static const GUID EL2ENC_ORIGINAL =
{ 0x436dcdba, 0x6552, 0x4f28, { 0x81, 0xc7, 0x42, 0x27, 0x4, 0x8b, 0xa, 0x41}};

/// Specifies the active MPEG Layer (depends on input sample rate).
// {CEE43546-6CBB-41d6-BA5E-DE038DDCE7D0}
static const GUID EL2ENC_MPEG_VERSION =
{ 0xcee43546, 0x6cbb, 0x41d6, { 0xba, 0x5e, 0xde, 0x3, 0x8d, 0xdc, 0xe7, 0xd0}};

/// Retrieves the number of input channels (readonly).
// {111F8C33-A702-423d-B668-26078B5BEC88}
static const GUID EL2ENC_INPUT_CHANNELS =
{ 0x111f8c33, 0xa702, 0x423d, { 0xb6, 0x68, 0x26, 0x7, 0x8b, 0x5b, 0xec, 0x88}};

/// Retrieves the number of output channels (readonly).
// {111F8C34-A7C2-423d-B668-26078B5BEC88}
static const GUID EL2ENC_OUTPUT_CHANNELS =
{ 0x111f8c34, 0xa7c2, 0x423d, { 0xb6, 0x68, 0x26, 0x7, 0x8b, 0x5b, 0xec, 0x88}};

/// Retrieves the input sample rate (read-only).
// {C2778C34-A7C2-423d-B668-26078B5BEC09}
static const GUID EL2ENC_SAMPLE_RATE =
{ 0xc2778c34, 0xa7c2, 0x423d, { 0xb6, 0x68, 0x26, 0x7, 0x8b, 0x5b, 0xec, 0x09}};

/// Specifies the MPEG psychoacoustic model to use for encoding.
// {23648FA1-4848-48eb-A50F-39881AAB25B7}
static const GUID EL2ENC_PSYCH_MODEL = 
{ 0x23648fa1, 0x4848, 0x48eb, { 0xa5, 0xf, 0x39, 0x88, 0x1a, 0xab, 0x25, 0xb7 } };

/// Flag to the player specifying what kind of de-emphasis to perform on the audio.
// {B7974B53-1BBC-48ff-B1CA-D31B898E1860}
static const GUID EL2ENC_EMPHASIS = 
{ 0xb7974b53, 0x1bbc, 0x48ff, { 0xb1, 0xca, 0xd3, 0x1b, 0x89, 0x8e, 0x18, 0x60 } };

/// Specifies the state of the private bit in the audio sync headers.
// {B443BDA7-B30F-4765-A97C-8BC65EB22445}
static const GUID EL2ENC_EXTENSION = 
{ 0xb443bda7, 0xb30f, 0x4765, { 0xa9, 0x7c, 0x8b, 0xc6, 0x5e, 0xb2, 0x24, 0x45 } };

/// Retrieves the encoder state.
// {5CDA3E8D-199D-4626-A05B-42F55B1AA36A}
static const GUID EL2ENC_IS_RUNNING = 
{ 0x5cda3e8d, 0x199d, 0x4626, { 0xa0, 0x5b, 0x42, 0xf5, 0x5b, 0x1a, 0xa3, 0x6a } };


/**
* namespace EL2AENC
* @brief MPEG Audio Encoder DS Filter namespace
**/
namespace EL2AENC
{
	/// Audio mode
	enum AudioMode_t
	{
		EL2E_MPEG_MD_STEREO	=	0,			///< Standard stereo
		EL2E_MPEG_MD_JOINT_STEREO	=	1,	///< Joint stereo
		EL2E_MPEG_MD_DUAL_CHANNEL	=	2,	///< Dual channel
		EL2E_MPEG_MD_MONO	=	3			///< Mono
	};

	/// Audio layer
	enum AudioLayer_t
	{
		EL2E_MPEG_AUDIO_LAYER1	=	1,      ///< ISO/IEC 11172-3 layer 1
		EL2E_MPEG_AUDIO_LAYER2	=	2      ///< ISO/IEC 11172-3 layer 2		
	};

	/// Psychoacoustic model
	enum PsychModel_t
	{
		EL2E_MPEG_PSYCH_MODEL1 = 1,			///< Psychoacoustic model 1
		EL2E_MPEG_PSYCH_MODEL2 = 2			///< Psychoacoustic model 2
	};

	/// Layer 1 bit rates
	enum AudioBitrateLayer1_t 
	{
		EL2E_L1_AUDIOBITRATE96	  =	3,		///< 96 kbit/sec
		EL2E_L1_AUDIOBITRATE128   =	4,		///< 128 kbit/sec
		EL2E_L1_AUDIOBITRATE160   =	5,		///< 160 kbit/sec
		EL2E_L1_AUDIOBITRATE192   =	6,		///< 192 kbit/sec
		EL2E_L1_AUDIOBITRATE224   =	7,		///< 224 kbit/sec
		EL2E_L1_AUDIOBITRATE256   =	8,		///< 256 kbit/sec
		EL2E_L1_AUDIOBITRATE288   =	9,		///< 288 kbit/sec
		EL2E_L1_AUDIOBITRATE320   =	10,		///< 320 kbit/sec
		EL2E_L1_AUDIOBITRATE352   =	11,		///< 352 kbit/sec
		EL2E_L1_AUDIOBITRATE384   =	12,		///< 384 kbit/sec
		EL2E_L1_AUDIOBITRATE416   =	13,		///< 416 kbit/sec
		EL2E_L1_AUDIOBITRATE448   =	14		///< 448 kbit/sec
	};

	/// Layer 2 bit rates
	enum AudioBitrateLayer2_t
	{
		EL2E_L2_AUDIOBITRATE32	  =	1,		///< 32 kbit/sec
		EL2E_L2_AUDIOBITRATE48	  =	2,		///< 48 kbit/sec
		EL2E_L2_AUDIOBITRATE56	  =	3,		///< 56 kbit/sec
		EL2E_L2_AUDIOBITRATE64    =	4,		///< 64 kbit/sec
		EL2E_L2_AUDIOBITRATE80    =	5,		///< 80 kbit/sec
		EL2E_L2_AUDIOBITRATE96    =	6,		///< 96 kbit/sec
		EL2E_L2_AUDIOBITRATE112	  =	7,		///< 112 kbit/sec
		EL2E_L2_AUDIOBITRATE128   =	8,		///< 128 kbit/sec
		EL2E_L2_AUDIOBITRATE160   =	9,		///< 160 kbit/sec
		EL2E_L2_AUDIOBITRATE192   =	10,		///< 192 kbit/sec
		EL2E_L2_AUDIOBITRATE224   =	11,		///< 224 kbit/sec
		EL2E_L2_AUDIOBITRATE256   =	12,		///< 256 kbit/sec
		EL2E_L2_AUDIOBITRATE320   =	13,		///< 320 kbit/sec
		EL2E_L2_AUDIOBITRATE384   =	14		///< 384 kbit/sec
	};

	/// Kind of de-emphasis
	enum EmphasisMode_t
	{
		EL2E_L2_NO_EMPHASIS	=	0,	///< no emphasis 
		EL2E_L2_EMPHASIS_50	=	1,	///< 50/15 microsec emphasis
		EL2E_L2_EMPHASIS_17 = 3		///< CCITT J.17
	};
};

#endif // MC_L2_ENCODER_CONFIG