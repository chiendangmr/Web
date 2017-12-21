/**
@file mux_mxf_mc.h
@brief Property GUIDs for MainConcept MXF muxer parameters.

@verbatim
File: mux_mxf_mc.h

Desc: Property GUIDs for MainConcept MXF muxer parameters.

 Copyright (c) 2015 MainConcept GmbH or its affiliates.  All rights reserved.

 MainConcept and its logos are registered trademarks of MainConcept GmbH or its affiliates.  
 This software is protected by copyright law and international treaties.  Unauthorized 
 reproduction or distribution of any portion is prohibited by law.
@endverbatim
*/

#ifndef __MXFMUX_HEADER__
#define __MXFMUX_HEADER__

/**
namespace EMXFMuxer
*/
namespace EMXFMuxer
{
    /**
     @brief Map between the DS and LL profiles 
    */
	typedef enum tagProfiles {
		PROFILE_DEFAULT = 0,                  //!< Generic profile
		PROFILE_SONY_XDCAM_HD,                //!< Sony XDCAM HD profile (SMPTE RDD-9)
		PROFILE_SONY_XDCAM_IMX,               //!< Sony XDCAM IMX profile
		PROFILE_SONY_XDCAM_DV,                //!< Sony XDCAM DV profile
		PROFILE_SONY_XDCAM_SXS_HD,            //!< Sony XDCAM SxS HD profile
		PROFILE_SONY_XDCAM_SXS_IMX,           //!< Sony XDCAM SxS IMX profile
		PROFILE_SONY_XDCAM_SXS_DV,            //!< Sony XDCAM SxS DV profile
		PROFILE_SONY_XAVC_4K,                 //!< Sony XAVC profile, HD/4K, Intra VBR/CBG and LongGOP, Single Essence Location style. (SMPTE RDD-32 7.3.1)
		PROFILE_PANASONIC_P2_DVCPRO,          //!< Panasonic P2 DVCPRO profile
		PROFILE_PANASONIC_P2_AVCI,            //!< Panasonic P2 AVCI profile
    PROFILE_PANASONIC_P2_AVC_ULTRA,       //!< Panasonic P2 AVC-Ultra profile, Intra and LongGOP
    PROFILE_PANASONIC_P2_AVC_LG = 10,     //!< Deprecated, use PROFILE_PANASONIC_P2_AVC_ULTRA
		PROFILE_DCI_2K,                       //!< J2K DCI 2K profile
		PROFILE_DCI_4K,                       //!< J2K DCI 4K profile
    PROFILE_SONY_XAVC_MEL,                //!< Sony XAVC profile, HD/4K, Intra VBR (only) and LongGOP, Multiple Essence Location style. (SMPTE RDD-32 7.3.2)
	} Profiles;

    /**
     @brief Map between the DS and LL operational patterns 
    */
	typedef enum tagOperationalPatterns {
		OP_PATTERN_ATOM,					//!< OPATOM operational pattern
		OP_PATTERN_1A,						//!< OP1A operational pattern
		OP_PATTERN_1B						  //!< OP1A operational pattern
	} OperationalPatterns;

  typedef enum tagXAVCIntraClasses {
    XAVC_INTRA_CLASS_100 = 100,
    XAVC_INTRA_CLASS_300 = 300,
    XAVC_INTRA_CLASS_480 = 480,
  }XAVCIntraClasses;

	/** 
	 @brief Metadata types passed to the application through callback function or to the muxer
	 */
	typedef enum tagContainerDescriptiveMetadataType {
		METADATA_UNKNOWN,					  //!< unknown metadata type
		METADATA_XML_DARK,					//!< XML-based dark metadata specified in SMPTE 377M,			
		METADATA_SONY_XML_DARK,		  //!< Sony NRT metadata
		METADATA_DMS1,						  //!< descriptive metadata scheme1 specified SMPTE 380M. do not use, for future abilities
		METADATA_DMS_P2_XML,				//!< P2 AVC-LongGOP descriptive metadata, XML meta data 
		METADATA_DMS_P2_BMP					//!< P2 AVC-LongGOP descriptive metadata, BMP Thumbnail 
	} ContainerDMType;

	/** 
	 @brief Structure which describes metadata passed to the muxer using @ref EMXFMux_ContainerMetadata parameter
	 */	
	typedef struct tagContainerDescriptiveMetadata {
		EMXFMuxer::ContainerDMType type;    //!< one of @ref EMXFMuxer::ContainerDMType values
		unsigned int uiSize;                //!< metadata buffer size
		void * pBuffer;                     //!< pointer to metadata buffer
	} ContainerDescriptiveMetadata;

	/** 
	 @brief Callback function prototype. Pointer to the function of such type should be passed to the filter (using @ref EMXFMux_MetadataCallback parameter) for metadata interception at EOS.
	 */	
	typedef HRESULT (*METADATA_CALLBACK) (EMXFMuxer::ContainerDMType metadataType, void *pBuffer, uint32_t &uiBufferSize);
};

/**
@brief Specifies Mux Profile type
@details 
<dl><dt><b> Type:             </b></dt><dd>  VT_INT                      </dd></dl>        
<dl><dt><b> Available values: </b></dt><dd>  PROFILE_DEFAULT <br> PROFILE_SONY_XDCAM_HD    <br> PROFILE_SONY_XDCAM_IMX    <br> PROFILE_SONY_XDCAM_DV    <br> PROFILE_SONY_XDCAM_SXS_HD    <br> PROFILE_SONY_XDCAM_SXS_IMX    <br> PROFILE_SONY_XDCAM_SXS_DV    <br> PROFILE_SONY_XAVC_4K  <br> PROFILE_SONY_XAVC_MEL  <br> PROFILE_PANASONIC_P2_DVCPRO    <br> PROFILE_PANASONIC_P2_AVCI    <br> PROFILE_DCI_2K    <br> PROFILE_DCI_4K   <br>PROFILE_PANASONIC_P2_AVC_ULTRA </dd></dl>
<dl><dt><b> Default values:   </b></dt><dd>  PROFILE_DEFAULT            </dd></dl>
@hideinitializer
*/
static const GUID EMXFMux_Profile = 
{ 0xa904dcd9, 0xb615, 0x4530, { 0xa9, 0x62, 0x67, 0xcb, 0x2, 0x4, 0xf2, 0x4a } };


/**
@brief Specifies Operational Pattern type
@details 
<dl><dt><b> Type:             </b></dt><dd>  VT_UINT                      </dd></dl>        
<dl><dt><b> Available values: </b></dt><dd>  OP_PATTERN_ATOM    <br> OP_PATTERN_1A    <br> OP_PATTERN_1B </dd></dl>
<dl><dt><b> Default values:   </b></dt><dd>  OP_PATTERN_1A            </dd></dl>
@hideinitializer
*/
static const GUID EMXFMux_OperationalPattern = 
{ 0x2ec680d4, 0xad04, 0x40eb, { 0xb0, 0x36, 0xb0, 0xb, 0x70, 0xf0, 0xc, 0xf3 } };


/**
@brief Specifies Frame Rate code (mcedefs.h), mandatory for VC3 and JPEG2000 input streams
@details 
<dl><dt><b> Type:             </b></dt><dd>  VT_UINT                      </dd></dl>        
<dl><dt><b> Available values: </b></dt><dd>  FRAMERATE0    <br> FRAMERATE23    <br> FRAMERATE24    <br> FRAMERATE25    <br> FRAMERATE29    <br> FRAMERATE30   <br> FRAMERATE48   <br> FRAMERATE50   <br> FRAMERATE59   <br> FRAMERATE60   </dd></dl>
<dl><dt><b> Default values:   </b></dt><dd>  FRAMERATE0            </dd></dl>
@hideinitializer
*/
static const GUID EMXFMux_FrameRate = 
{ 0xa277fc73, 0xf0d8, 0x4c51, { 0x8e, 0x11, 0xa4, 0xa2, 0xb0, 0x20, 0x85, 0xdb } };


/**
@brief Specifies Clip Name in case of Panasonic P2 profile, 8 characters for AVC Long GOP, 6 for AVC-Intra and DVCPRO, following the P2 naming rules.
@details 
<dl><dt><b> Type:             </b></dt><dd>  VT_BSTR                      </dd></dl>        
<dl><dt><b> Available values: </b></dt><dd>  Any text </dd></dl>
@hideinitializer
*/
static const GUID EMXFMux_P2UserClipName = 
{ 0xf7ed0cf5, 0xf5ff, 0x4498, { 0xa3, 0xf, 0x24, 0x24, 0x8, 0x6, 0xea, 0xa2 } };


/**
@brief Specifies the start time code in frames
@details 
<dl><dt><b> Type:             </b></dt><dd>  VT_UINT                      </dd></dl>        
<dl><dt><b> Available values: </b></dt><dd>  Correct number of frames  </dd></dl>
@hideinitializer
*/
static const GUID EMXFMux_StartTimecode = 
{ 0x073edb56, 0x4a83, 0x4a69, { 0xb2, 0x54, 0x19, 0xff, 0xfc, 0xb7, 0xfc, 0xdf } };


/**
@brief Specifies the start video duration in frames of all previous linked clips - 0 if fist of spanned clips. Used for P2 only actualy
@details 
<dl><dt><b> Type:             </b></dt><dd>  VT_UINT	</dd></dl>        
<dl><dt><b> Available values: </b></dt><dd>  Correct number of video frames	</dd></dl>
@hideinitializer
*/
static const GUID EMXFMux_StartVideoDuration = 
{ 0x84cd0131, 0x9330, 0x4955, { 0xb6, 0x27, 0xba, 0x20, 0x69, 0x7, 0xdc, 0x8 } };


/**
@brief Specifies the start audio duration in frames of all previous linked clips - 0 if fist of spanned clips. Used for P2 only actualy
@details 
<dl><dt><b> Type:             </b></dt><dd>  VT_UI8                      </dd></dl>        
<dl><dt><b> Available values: </b></dt><dd>  Correct number of audio samples	</dd></dl>
@hideinitializer
*/
static const GUID EMXFMux_StartAudioDuration = 
{ 0x0e15a0ad, 0xb78a, 0x431f, { 0x94, 0x6e, 0x17, 0x73, 0xf, 0x85, 0x96, 0xee } };


/**
@brief Specifies if the drop frame timecode is used (in case of DV essence, if embedded timecode is found, it will be overwritten with DF flag found there)
@details 
<dl><dt><b> Type: </b></dt><dd>VT_BOOL </dd></dl>  
<dl><dt><b> Available values:</b></dt><dd> FALSE <br> TRUE </dd></dl> 
<dl><dt><b> Default values: </b></dt><dd> FALSE</dd></dl>
@hideinitializer
*/
static const GUID EMXFMux_DropFrameTimecode = 
{ 0x6b210d0a, 0x2dcd, 0x4138, { 0xa1, 0x6a, 0x87, 0xdc, 0x9d, 0x25, 0x3d, 0x5a } };

/**
@brief Specifies wether for PCM wrapping in generic profile AES-3 descriptor is used. Default is BWF Descriptor.
@details 
<dl><dt><b> Type: </b></dt><dd>VT_BOOL </dd></dl>  
<dl><dt><b> Available values:</b></dt><dd> FALSE <br> TRUE </dd></dl> 
<dl><dt><b> Default values: </b></dt><dd> FALSE</dd></dl>
@hideinitializer
*/
// {07B1342B-FE09-4579-B1C0-066EBD3220B3}
static const GUID EMXFMux_AES3_PCM = 
{ 0x7b1342b, 0xfe09, 0x4579, { 0xb1, 0xc0, 0x6, 0x6e, 0xbd, 0x32, 0x20, 0xb3 } };


/**
@brief Specifies wether for AVC wrapping in generic profile new SMPTE ST 381-3 style is used with CDCI Descriptor/AVC Subdescriptor. Default is SMPTE RP 2012 style with MPEG Descriptor.
@details 
<dl><dt><b> Type: </b></dt><dd>VT_BOOL </dd></dl>  
<dl><dt><b> Available values:</b></dt><dd> FALSE <br> TRUE </dd></dl> 
<dl><dt><b> Default values: </b></dt><dd> FALSE</dd></dl>
@hideinitializer
*/
// {0598A7B4-B338-447e-B659-29753250676F}
static const GUID EMXFMux_ST_382_3_AVC_Style = 
{ 0x598a7b4, 0xb338, 0x447e, { 0xb6, 0x59, 0x29, 0x75, 0x32, 0x50, 0x67, 0x6f } };


/**
@brief Specifies whether XAVC 4k Intra input is of constant bitrate (CBG). Default is VBR.
@details 
<dl><dt><b> Type: </b></dt><dd>VT_BOOL </dd></dl>  
<dl><dt><b> Available values:</b></dt><dd> FALSE <br> TRUE </dd></dl> 
<dl><dt><b> Default values: </b></dt><dd> FALSE</dd></dl>
@hideinitializer
*/
// {C3332034-F3C8-45f7-9186-39E445F5085D}
static const GUID EMXFMux_XAVCIntra4k_CBG = 
{ 0xc3332034, 0xf3c8, 0x45f7, { 0x91, 0x86, 0x39, 0xe4, 0x45, 0xf5, 0x8, 0x5d } };



/**
@brief Specifies the bitrate class of XAVC 4k Intra input. Class 100, 300 or 480.
@details 
<dl><dt><b> Type:             </b></dt><dd>  VT_UINT                      </dd></dl>        
<dl><dt><b> Available values: </b></dt><dd> XAVC_INTRA_CLASS_100 <br> XAVC_INTRA_CLASS_300 <br> XAVC_INTRA_CLASS_480 <br>	</dd></dl>
@hideinitializer
*/
// {8C7C7641-8084-438e-B28D-4634000752E8}
static const GUID EMXFMux_XAVCIntra4k_Class = 
{ 0x8c7c7641, 0x8084, 0x438e, { 0xb2, 0x8d, 0x46, 0x34, 0x0, 0x7, 0x52, 0xe8 } };


/**
@brief Specifies whether input ST 436 ANC or VBI frame elements are of variable size (VBE). Default is constant size (CBE).
@details 
<dl><dt><b> Type: </b></dt><dd>VT_BOOL </dd></dl>  
<dl><dt><b> Available values:</b></dt><dd> FALSE <br> TRUE </dd></dl> 
<dl><dt><b> Default values: </b></dt><dd> FALSE</dd></dl>
@hideinitializer
*/

// {944EEC05-8A21-4bfd-AC56-CB9EB3F4F57B}
static const GUID EMXFMux_AncillaryData_VBE = 
{ 0x944eec05, 0x8a21, 0x4bfd, { 0xac, 0x56, 0xcb, 0x9e, 0xb3, 0xf4, 0xf5, 0x7b } };




/**
@brief Specifies if the old XDCAM v 1.1 spec. style is used
@details 
<dl><dt><b> Type: </b></dt><dd>VT_BOOL </dd></dl>  
<dl><dt><b> Available values:</b></dt><dd> FALSE <br> TRUE </dd></dl> 
<dl><dt><b> Default values: </b></dt><dd> FALSE</dd></dl>
@hideinitializer
*/
static const GUID EMXFMux_OldStyleXDCAM = 
{ 0xec3b6a82, 0x9887, 0x4b44, { 0x8e, 0xc7, 0x74, 0x1f, 0xe0, 0x78, 0x24, 0x7d } };


/**
@brief Specifies the video stream duration in edit units. Used to preset the duration for Sony XDCAM SxS types and Sony XAVC. Mandatory.
@details 
<dl><dt><b> Type:             </b></dt><dd>  VT_UINT	</dd></dl>        
<dl><dt><b> Available values: </b></dt><dd>  Correct number of edit units	</dd></dl>
@hideinitializer
*/
static const GUID EMXFMux_UserDuration = 
{ 0x768e2379, 0x1c2a, 0x4e62, { 0xa1, 0xa6, 0x97, 0x10, 0x16, 0x16, 0x64, 0x8 } };


/**
@brief Used to specify container metadata. Only P2 AVC-LongGOP descriptive metadata (XML and thumbnail BMP) supported at this moment.
@details 
<dl><dt>Type         : </dt>    <dd>VT_PTR	</dd></dl>      
<dl><dt>Available range	: </dt>	        <dd>						</dd></dl>   
@hideinitializer
*/
static const GUID EMXFMux_ContainerMetadata = 
{ 0x30cbbfe6, 0x6ada, 0x48fc, { 0xbf, 0x20, 0xb2, 0xdd, 0xfe, 0xa3, 0x45, 0x1f } };


/**
@brief Used to provide a pointer to the callback function which will be called at the end of muxing if any container metadata is present.   
@details 
<dl><dt>Type         : </dt>    <dd>VT_PTR	</dd></dl>      
<dl><dt>Available range	: </dt>	        <dd>						</dd></dl>   
<dl><dt>Default value: </dt>         <dd>NULL    				</dd></dl>      
@hideinitializer
*/
static const GUID EMXFMux_MetadataCallback = 
{ 0x7c335922, 0x39fb, 0x439c, { 0xb1, 0x61, 0xca, 0xb3, 0x70, 0x72, 0xd0, 0x81 } };


/**
@brief Specifies if the DCI 2K 48fps should be created (Deprecated, use EMXFMux_FrameRate instead and set the framerate code)
@details 
<dl><dt><b> Type: </b></dt><dd>VT_BOOL </dd></dl>  
<dl><dt><b> Available values:</b></dt><dd> FALSE <br> TRUE </dd></dl> 
<dl><dt><b> Default values: </b></dt><dd> FALSE</dd></dl>
@hideinitializer
*/
static const GUID EMXFMux_Use48DCI2K = 
{ 0xf6914ff2, 0xa655, 0x4447, { 0x9b, 0x78, 0x92, 0x87, 0x33, 0x5a, 0x99, 0xb0 } };


#endif //__MXFMUX_HEADER__
