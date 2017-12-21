/*!
 * @file mux_mp4_mc.h
 * @brief Property GUIDs for MainConcept MP4 demuxer parameters.
 * File: mux_mp4_mc.h
 *
 * Desc: Property GUIDs for MainConcept MP4 demuxer parameters.
 *
 * Copyright (c) 2015 MainConcept GmbH or its affiliates.  All rights reserved.
 *
 * MainConcept and its logos are registered trademarks of MainConcept GmbH or its affiliates.  
 * This software is protected by copyright law and international treaties.  Unauthorized 
 * reproduction or distribution of any portion is prohibited by law.
 * 
 */

#if !defined(__EMP4MUX_HEADER__)
#define __EMP4MUX_HEADER__

/*!
@brief Specifies the Output file format (mp4, 3gpp, mj2, mov)
@details
<dl><dt>Type:           </dt>   <dd>  VT_INT  </dd></dl>
<dl><dt>Available range:</dt>   <dd> see EMP4Muxer::OutputFormats </dd></dl>
<dl><dt>Default value:  </dt>   <dd>  EMP4Muxer::OutputFormats::FF_MP4       </dd></dl>
@hideinitializer
*/
// {67F699AE-4856-4292-99F1-BB6FDB596E43}
static const GUID EMP4Mux_OutputFormat = 
{ 0x67f699ae, 0x4856, 0x4292, { 0x99, 0xf1, 0xbb, 0x6f, 0xdb, 0x59, 0x6e, 0x43 } };

/*!
@brief Specifies the Stream compatibility format
@details
<dl><dt>Type:           </dt>   <dd>  VT_INT  </dd></dl>
<dl><dt>Available range:</dt>   <dd>  see EMP4Muxer::CompatibilityFormat, BC DS MP4 Muxer doesn't support encrypted UVU. It requires external callbacks for IV changing and Keys management </dd></dl>
<dl><dt>Default value:  </dt>   <dd>  EMP4Muxer::CompatibilityFormat::CF_Default       </dd></dl>
@hideinitializer
*/
// {AB50A92F-1AF8-4f03-A35B-7EDEF95AE1F0}
static const GUID EMP4Mux_Compatibility = 
{ 0xab50a92f, 0x1af8, 0x4f03, { 0xa3, 0x5b, 0x7e, 0xde, 0xf9, 0x5a, 0xe1, 0xf0 } };

/*!
@brief Current muxer time
@details
<dl><dt>Type:           </dt>   <dd>  VT_I8     </dd></dl>
<dl><dt>Available range:</dt>   <dd>  0-MAX_I8  </dd></dl>
<dl><dt>Default value:  </dt>   <dd>  0       </dd></dl>
<dl><dt>Read only </dt>   <dd>  yes       </dd></dl>
@hideinitializer
*/
// {895E4A88-2F56-4503-97E4-F9E6C35070AF}
static const GUID EMP4Mux_MuxTime = 
{ 0x895e4a88, 0x2f56, 0x4503, { 0x97, 0xe4, 0xf9, 0xe6, 0xc3, 0x50, 0x70, 0xaf } };

/*! @name For Sony PSP files
 @{*/
/*!
@brief Output file name for SonyPSP
@details
<dl><dt>Type:           </dt>   <dd>  VT_BSTR     </dd></dl>
<dl><dt>Available range:</dt>   <dd>  0..255 Unicode chars  </dd></dl>
<dl><dt>Default value:  </dt>   <dd>  0       </dd></dl>
@hideinitializer
*/
// {9ABE6978-4304-42b6-9C55-EC6A62D311E3}
static const GUID EMP4Mux_OutputFileName = 
{ 0x9abe6978, 0x4304, 0x42b6, { 0x9c, 0x55, 0xec, 0x6a, 0x62, 0xd3, 0x11, 0xe3 } };
///@}
/*!
@brief Deletes the SEI messages in the H.264/AVC stream, because
 some decoders might have problems with them.
@details
<dl><dt>Type:           </dt>   <dd>  VT_LONG     </dd></dl>
<dl><dt>Available range:</dt>   <dd>  0,1     </dd></dl>
<dl><dt>Default value:  </dt>   <dd>  0       </dd></dl>
@hideinitializer
*/
// {2CA7BE73-585F-4d80-AB96-770FE2A6C935}
static const GUID EMP4Mux_RemoveSEI = 
{ 0x2ca7be73, 0x585f, 0x4d80, { 0xab, 0x96, 0x77, 0xf, 0xe2, 0xa6, 0xc9, 0x35 } };

/*!
@brief Setting this to 1, keeps the AU delimiter for H.264/AVC muxing.
@details
<dl><dt>Type:           </dt>   <dd>  VT_LONG     </dd></dl>
<dl><dt>Available range:</dt>   <dd>  0,1     </dd></dl>
<dl><dt>Default value:  </dt>   <dd>  0       </dd></dl>
@hideinitializer
*/
// {26E31D9E-228A-4ace-A05E-C01B4E89DFB2}
static const GUID EMP4Mux_KeepAUD = 
{ 0x26e31d9e, 0x228a, 0x4ace, { 0xa0, 0x5e, 0xc0, 0x1b, 0x4e, 0x89, 0xdf, 0xb2 } };

/*!
@brief  Setting this to 1, keeps the SPS and PPS for H.264/AVC muxing.
@details
<dl><dt>Type:           </dt>   <dd>  VT_LONG     </dd></dl>
<dl><dt>Available range:</dt>   <dd>  0,1     </dd></dl>
<dl><dt>Default value:  </dt>   <dd>  0       </dd></dl>
@hideinitializer
*/
// {FFDEA675-B47C-458e-A0EB-403EC8FD5058}
static const GUID EMP4Mux_KeepPS = 
{ 0xffdea675, 0xb47c, 0x458e, { 0xa0, 0xeb, 0x40, 0x3e, 0xc8, 0xfd, 0x50, 0x58 } };

/*! @name For Sony PSP files
 @{*/
/*!
@brief Set format version for Sony PSP files
@details
<dl><dt>Type:           </dt>   <dd>  VT_INT     </dd></dl>
<dl><dt>Available range:</dt>   <dd>  0..INT16MAX  </dd></dl>
<dl><dt>Default value:  </dt>   <dd>  0       </dd></dl>
@hideinitializer
*/
// {277AA7A4-CF30-4c84-89BF-5DFECE9AAE57}
static const GUID EMP4Mux_FormatVersion = 
{ 0x277aa7a4, 0xcf30, 0x4c84, { 0x89, 0xbf, 0x5d, 0xfe, 0xce, 0x9a, 0xae, 0x57 } };
/*!
@brief Set owner code for Sony PSP files
@details
<dl><dt>Type:           </dt>   <dd>  VT_INT     </dd></dl>
<dl><dt>Available range:</dt>   <dd>  0..INT16MAX  </dd></dl>
<dl><dt>Default value:  </dt>   <dd>  0       </dd></dl>
@hideinitializer
*/
// {427CD7D8-C6EC-4620-BAFF-41F088346BAB}
static const GUID EMP4Mux_OwnerCode = 
{ 0x427cd7d8, 0xc6ec, 0x4620, { 0xba, 0xff, 0x41, 0xf0, 0x88, 0x34, 0x6b, 0xab } };
///@}

/*!
@brief  Set number of frames in chunk
@details
<dl><dt>Type:           </dt>   <dd>  VT_INT     </dd></dl>
<dl><dt>Available range:</dt>   <dd>  1-300     </dd></dl>
<dl><dt>Default value:  </dt>   <dd>  10       </dd></dl>
@hideinitializer
*/
// {43BE713B-6699-425c-B847-21B7D5B8AD85}
static const GUID MP4Mux_VideoLen = 
{ 0x43be713b, 0x6699, 0x425c, { 0xb8, 0x47, 0x21, 0xb7, 0xd5, 0xb8, 0xad, 0x85 } };


/*!
@brief  Set number of frames in chunk
@details
<dl><dt>Type:           </dt>   <dd>  VT_INT     </dd></dl>
<dl><dt>Available range:</dt>   <dd>  
- 0 (direct timestamps - use input pts)
- 1 (auto adjusting    - correct input pts if needed)
- 2 (get pts from elementary stream headers)
    </dd></dl>
<dl><dt>Default value:  </dt>   <dd>  0 (direct timestamps - use input pts)   </dd></dl>
@hideinitializer
*/
// {9878201C-2E51-41F2-BEC2-0B4A1E26E62D}
static const GUID MP4Mux_SyncMode = 
{ 0x9878201c, 0x2e51, 0x41f2, { 0xbe, 0xc2, 0xb, 0x4a, 0x1e, 0x26, 0xe6, 0x2d } };


/*!
@brief The option enables/disables the atom reordering
@details
<dl><dt>Type:           </dt>   <dd>  VT_LONG     </dd></dl>
<dl><dt>Available range:</dt>   <dd>  see EMP4Muxer::atom_order_t
</dd></dl>
<dl><dt>Default value:  </dt>   <dd>  0       </dd></dl>
@hideinitializer
*/
// {BBED4372-BE86-4437-A59E-1A800D4812C3}
static const GUID EMP4Mux_AtomOrder =
{ 0xbbed4372, 0xbe86, 0x4437, { 0xa5, 0x9e, 0x1a, 0x80, 0xd, 0x48, 0x12, 0xc3 } };

/*!
@brief Setting it to On, a 32-bit field size for mdat atom is used. By
default used large presentations(64-bit), it may be desirable to
@details
<dl><dt>Type:           </dt>   <dd>  VT_LONG     </dd></dl>
<dl><dt>Available range:</dt>   <dd>
- 0 (use 64-bit)
- 1 (use 32-bit)     </dd></dl>
<dl><dt>Default value:  </dt>   <dd>  0       </dd></dl>
@hideinitializer
*/
// {E0B99FCA-404E-44b3-AF22-9E49986C59D4}
static const GUID MP4Mux_SmallAtoms = 
{ 0xe0b99fca, 0x404e, 0x44b3, { 0xaf, 0x22, 0x9e, 0x49, 0x98, 0x6c, 0x59, 0xd4 } };

/*!
@brief Maximum interval to wait for input data on all pins
@details
<dl><dt>Type:           </dt>   <dd>  VT_INT     </dd></dl>
<dl><dt>Available range:</dt>   <dd>  0,INT32_MAX</dd></dl>
<dl><dt>Default value:  </dt>   <dd>  15000      </dd></dl>
@hideinitializer
*/
// {946DD99E-9A46-4402-BCBF-8C9C2DDEA8A6}
static const GUID MP4Mux_InitTimeout = 
{ 0x946dd99e, 0x9a46, 0x4402, { 0xbc, 0xbf, 0x8c, 0x9c, 0x2d, 0xde, 0xa8, 0xa6 } };

/*!
@brief UVU metadata file
@details
<dl><dt>Type:           </dt>   <dd>  VT_BSTR     </dd></dl>
<dl><dt>Default value:  </dt>   <dd>  15000      </dd></dl>
@hideinitializer
*/
// {81BFBD1A-2C88-4D01-AE59-B51569FAD9AE}
static const GUID MP4Mux_UvuMetadataFile = 
{ 0x81bfbd1a, 0x2c88, 0x4d01, { 0xae, 0x59, 0xb5, 0x15, 0x69, 0xfa, 0xd9, 0xae } };

/*!
@brief temporary path
@details
<dl><dt>Type:           </dt>   <dd>  VT_BSTR     </dd></dl>
<dl><dt>Default value:  </dt>   <dd>        </dd></dl>
@hideinitializer
*/
// {313D80A7-BF32-409F-AE74-98B0FBAE728D}
static const GUID MP4Mux_TemporaryPath = 
{ 0x313d80a7, 0xbf32, 0x409f, { 0xae, 0x74, 0x98, 0xb0, 0xfb, 0xae, 0x72, 0x8d } };

/*!@brief namespace for MP4 Muxer specific enums
*/
namespace EMP4Muxer
{
    /*!@brief Available file formats*/
    typedef enum tagOutputFormats {
        FF_MP4      = 0,  //!< ISO/IEC 14496-14
        FF_JPEG2000 = 1,  //!< JPEG2000 file format
        FF_3GPP     = 2,  //!< 3GPP file format
        FF_UVU      = 3,  //!< UltraViolet file format

    } OutputFormats;
    
    /*!@brief Available format compatibility options */
    typedef enum tagCompatibilityFormat {
        CF_Default  = 0, //!< MP4 Standard
        CF_ISMA,         //!< ISMA (Internet Media Streaming Alliance)
        CF_SonyPSP,      //!< Sony PSP
        CF_iPod,         //!< Apple iPod
        CF_QT,           //!< QuickTime
        CF_FLASH,        //!< Adobe Flash
        CF_iPhone,       //!< Apple iPhone
        CF_SONY_PMC,     //!< Sony XDCAM-EX
        CF_iPad,         //!< Apple iPad
        CF_UVUNEnc,      //!< Ultraviolet, unencrypted
        CF_DASH,         //!< MPEG DASH
        CF_Fragmented,   //!< Fragmented MP4
        CF_SONY_XAVC_S   //!< Sony XAVC-S
    } CompatibilityFormat;

    /*!@brief Atom ordering options */
    typedef enum atom_order_e {
        AO_None = 0,  //!< MDAT before MOOV - Atom reordering disabled.
        AO_MoovFirst  //!< MOOV before MDAT - Atom reordering enabled.

    } atom_order_t;
};

#endif //#if !defined(__EMP4MUX_HEADER__)
