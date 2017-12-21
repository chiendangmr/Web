/** 
 @file  enc_amr_mc.h
 @brief Property GUIDs for MainConcept AMR encoder parameters.
 
 @verbatim
 File: enc_amr_mc.h

 Desc: Property GUIDs for MainConcept AMR encoder parameters.
 
 Copyright (c) 2015 MainConcept GmbH or its affiliates.  All rights reserved.

 MainConcept and its logos are registered trademarks of MainConcept GmbH or its affiliates.  
 This software is protected by copyright law and international treaties.  Unauthorized 
 reproduction or distribution of any portion is prohibited by law.
 @endverbatim
 **/
#ifndef __AMRENCODER_TYPES_UIDS__
#define __AMRENCODER_TYPES_UIDS__


/**
 * @name TYPES UIDS
 * @{
 */

/// Be compatible with ffdshow
#define WAVE_FORMAT_AMR		0x7A21

/////////////////
// OUTPUT PIN
/////////////////

#ifndef MEDIASUBTYPE_AMR_DEF
#define MEDIASUBTYPE_AMR_DEF

/// AMR media subtype
// {99C00BDC-3BF1-4889-9873-F1178D3C5679}
static const GUID MEDIASUBTYPE_AMR = 
{ 0x99c00bdc, 0x3bf1, 0x4889, { 0x98, 0x73, 0xf1, 0x17, 0x8d, 0x3c, 0x56, 0x79 } };
#endif

#ifndef MEDIASUBTYPE_AMR_MPEGABLE_DEF
#define MEDIASUBTYPE_AMR_MPEGABLE_DEF

// {CA9A0EDC-38B0-4FA6-B34A-3019543A0C57}
static const GUID MEDIASUBTYPE_AMR_MPEGABLE = 
{ 0xca9a0edc, 0x38b0, 0x4fa6, { 0xb3, 0x4a, 0x30, 0x19, 0x54, 0x3a, 0x0c, 0x57 } };
#endif

/** @} */

/**
* namespace AMRAE
* @brief AMR encoder namespace
**/
namespace AMRAE
{
	///@brief Bit Rate. Input sample rate = 8000 Hz (NB-mode).
	typedef enum NB_BitRate
	{
		BitRate_475	= 0,	///< 4,75 kbit/s
		BitRate_515 = 1,	///< 5,15 kbit/s
		BitRate_590 = 2,	///< 5,90 kbit/s
		BitRate_670	= 3,	///< 6,70 kbit/s (PDC-EFR)
		BitRate_740 = 4,	///< 7,40 kbit/s (IS-641)
		BitRate_795 = 5,	///< 7,95 kbit/s
		BitRate_102 = 6,	///< 10,20 kbit/s
		BitRate_122 = 7,	///< 12,20 kbit/s (GSM EFR)
		BitRate_DTX = 8		///< DTX
	};

	///@brief Bit Rate. Input sample rate = 16000 Hz (WB-mode).
    typedef enum WB_BitRate
    {
        BitRate_660	= 0,	///< 6,6 kbit/s
        BitRate_885	= 1,	///< 8,85 kbit/s
        BitRate_1265 = 2,	///< 12,65 kbit/s
        BitRate_1425 = 3,	///< 14,25 kbit/s
        BitRate_1585 = 4,	///< 15,85 kbit/s
        BitRate_1825 = 5,	///< 18,25 kbit/s
        BitRate_1985 = 6,	///< 19,85 kbit/s
        BitRate_2305 = 7, 	///< 23,05 kbit/s
		BitRate_2385 = 8 	///< 23,85 kbit/s
    };

	///@brief Interface format
    typedef enum InterfaceFormat_t
    {
        INTERFACE_FORMAT1 = 1,		///< Interface format 1 (IF1).
        INTERFACE_FORMAT2 = 2		///< Interface format 2 (IF2).
    };

    typedef enum Preset_t
    {
        AMRE_PRESET_DEFAULT = 0,
        AMRE_PRESET_3GPP = 0x00006000
    };
};

//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
//    GUID                                  Type        Available range                     Default Val         Note
//MC_BITRATE_AVG                           VT_INT      see BitRate_t                       [4]                Average Bitrate size
//EAMRAE_IsRunning	                        VT_INT      [0, 1]                              [0]                Is encoder running


//////////////////////////////////////////////////////////////////////////
//    Parameters GUIDs
//////////////////////////////////////////////////////////////////////////

/// Retrieves the encoder state.
// {A7C6504A-FBF5-4179-9A03-14EEC259D330}
static const GUID EAMRAE_IsRunning = 
{ 0xa7c6504a, 0xfbf5, 0x4179, { 0x9a, 0x3, 0x14, 0xee, 0xc2, 0x59, 0xd3, 0x30 } };

/// Displays the sample rate of the input stream.
// {3302D773-5C59-43be-99AD-C82DF33E69D0}
static const GUID EAMRAE_Samplerate = 
{ 0x3302d773, 0x5c59, 0x43be, { 0x99, 0xad, 0xc8, 0x2d, 0xf3, 0x3e, 0x69, 0xd0 } };

/// Specifies whether a file header is written or not.
// {3031B529-7038-44a7-A872-0C1CF12CFAA6}
static const GUID EAMRAE_FileHeader = 
{ 0x3031b529, 0x7038, 0x44a7, { 0xa8, 0x72, 0xc, 0x1c, 0xf1, 0x2c, 0xfa, 0xa6 } };

/// Specifies output interface format.
// {B667BD23-5B39-40fc-A7A4-60D7E5067834}
static const GUID EAMRAE_InterfaceFormat = 
{ 0xb667bd23, 0x5b39, 0x40fc, { 0xa7, 0xa4, 0x60, 0xd7, 0xe5, 0x6, 0x78, 0x34 } };

/// Sets default settings for the selected preset.
// {A1B87DA7-9AC3-4d43-AEFD-B33F928460A7}
static const GUID EAMRAE_SetDefValues = 
{ 0xa1b87da7, 0x9ac3, 0x4d43, { 0xae, 0xfd, 0xb3, 0x3f, 0x92, 0x84, 0x60, 0xa7 } };

#endif // #ifndef __AMRENCODER_TYPES_UIDS__