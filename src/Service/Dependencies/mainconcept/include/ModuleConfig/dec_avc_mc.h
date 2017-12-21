 /**
\file dec_avc_mc.h
\brief Property GUIDs for MainConcept AVC decoder parameters.

\verbatim
File: dec_avc_mc.h

Desc: Property GUIDs forMainConcept AVC decoder parameters.

 Copyright (c) 2015 MainConcept GmbH or its affiliates.  All rights reserved.

 MainConcept and its logos are registered trademarks of MainConcept GmbH or its affiliates.  
 This software is protected by copyright law and international treaties.  Unauthorized 
 reproduction or distribution of any portion is prohibited by law.
\endverbatim
*/

#if !defined(__H264VD_AVCDEC_MODULECONFIG_PROPID__)
#define __H264VD_AVCDEC_MODULECONFIG_PROPID__

///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
//  GUID                                Type        Available range     Default Val     Note
// EH264VD_SkipMode                     VT_UI4      [0, 4]              [0]             Selecting skip mode(I,IP,IBP) or obey quality messages
// EH264VD_ErrorResilience              VT_UI4      [0, 2]              [0]             Specifies the way decoder recovers from stream errors
// EH264VD_Deblock                      VT_UI4      [0, 2]              [0]             Skips filtering for some frames
// EH264VD_Deinterlace                  VT_UI4      [0, 4]              [0]             Sets the deinterlacing mode
// EH264VD_HQUpsample                   VT_UI4      [0, 1]              [1]             Upsampling of chroma plane in vertical dimension
// EH264VD_DoubleRate                   VT_UI4      [0, 1]              [0]             Generation of one progressive frame from every field
// EH264VD_FieldsReordering             VT_UI4      [0, 2]              [0]             Changed ordering of fields
// EH264VD_FieldsReorderingCondition    VT_UI4      [0, 2]              [0]             Sets the condition for apply reordering
// EH264VD_MediaTimeStart               VT_I8       []                                  Media time of current frame (it may be a byte offset of current frame)
// EH264VD_MediaTimeStop                VT_I8       []
// EH264VD_FramesDisplayed              VT_UI4      []                  [0]             Amount of displayed frames
// EH264VD_FramesSkipped                VT_UI4      []                  [0]             Amount of skipped frames
// EH264VD_OSD                          VT_UI4      [0, 1]              [0]             On screen display
// EH264VD_SYNCHRONIZING                VT_UI4      [0, 2]              [0]             Sets synchronizing mode
// EH264VD_RateMode                     VT_UI4      [0, 2]              [0]             Specifies interpretation way for frame rate value
// EH264VD_FrameRate                    VT_R8       [0.01, 9999999.99]  [25.00]         Sets the frame rate value
// EH264VD_LowLatency                   VT_UI4      [0, 1]              [0]             Provides minimal output delay
// EH264VD_StreamOrder                  VT_UI4      [0, 1]              [0]             Output frames in streams order
// EH264VD_ReallocationOfOutputBuffer   VT_UI4      [0, 1]              [1]             Reallocation of output buffer even if new format does not require large buffer.
// EH264VD_MotionVectorsPrecision       VT_UI4      [0, 2]              [0]             Limits precision of motion vectors.
// EH264VD_IsSVCContent                 VT_UI4      [0, 1]              [0]
// EH264VD_CaptureSEIData               VT_BYREF    []                  [0]             Get SEI messages.
/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////


namespace EH264VD {
    
    enum ErrorResilienceMode    {
        ErrorResilienceMode_Skip_till_Intra = 0,
        ErrorResilienceMode_Skip_till_IDR,
        ErrorResilienceMode_Decode_Anyway
    };
    
    enum DeblockMode    {
        DeblockMode_Default = 0,
        DeblockMode_OnlyRef,
        DeblockMode_Off
    };

    enum FormatVideoInfo{
        FormatVideoInfo_1 = 0,
        FormatVideoInfo_2  = 1,
        FormatVideoInfo_Both  = 2
    };

    enum RateMode{
        RateMode_Field = 0,
        RateMode_Frame = 1,
        RateMode_Fixed = 2
    };

    enum FieldReorderingMode{
        FieldReordering_Off = 0,
        FieldReordering_FlagsInverting = 1,
        FieldReordering_FieldsInverting = 2,
        FieldReordering_Auto = 3
    };

    enum FieldReorderingConditionMode{
        FieldReorderingCondition_Always = 0,
        FieldReorderingCondition_TopFirst_True = 1,
        FieldReorderingCondition_TopFirst_False = 2,
    };

    enum SynchronizingMode{
        Synchronizing_PTS = 0,
        Synchronizing_IgnorePTS_NotRef = 1,
        Synchronizing_IgnorePTS_All = 2,
        Synchronizing_DirectTimestamps = 3,
        Synchronizing_IgnoreHRD = 4
    };

    enum MediaTimeMode{
        MediaTime_Off = 0,
        MediaTime_FrameNumber = 1,
        MediaTime_InputMediatime = 2
    };

    enum MVPrecisionMode {
        MVPrecision_Quarter = 0,
        MVPrecision_Half = 1,
        MVPrecision_Full = 2
    };

         /**\name user data buffer storage
     \{ */
    typedef struct _EH264VD_BufferInfo{
        VOID * pBuffer; /**< \brief the memory address to allocated buffer, which contains captured user data. \hideinitializer */
        SIZE_T szBuffer; /**< \brief the allocated buffer size \hideinitializer */
    }EH264VD_BufferInfo; /**< user data buffer storage*/
    /**\}*/
};


/**
 Specifies the way decoder recovers from bit stream errors.
\details
<dl><dt><b> Type:  </b></dt><dd>  VT_UI4 </dd></dl>
<dl><dt><b>   Available Values: </b></dt><dd> 
<b> ErrorResilienceMode_Skip_till_Intra </b>- If bit stream error is detected, skip all slices until first intra slice. May produce decoding artifacts if pictures before intra slice are used as reference for pictures after intra slice.  <br>
<b> ErrorResilienceMode_Skip_till_IDR </b>- If bit stream error is detected, skip all slices until first IDR slice.  <br>
<b> ErrorResilienceMode_Decode_Anyway </b>- Ignore bit stream errors. 
</dd></dl> \hideinitializer
*/ 
// {23E71B01-F642-4a66-8C90-9749A5C094A4}
static const GUID EH264VD_ErrorResilience = 
{ 0x23e71b01, 0xf642, 0x4a66, { 0x8c, 0x90, 0x97, 0x49, 0xa5, 0xc0, 0x94, 0xa4 } };

/**  
Controls in-loop filter operation.
\details <dl><dt><b>  Type: </b></dt><dd> 
VT_UI4 </dd></dl>
<dl><dt><b>  Available Values: </b></dt><dd>
DeblockMode_Default - Respect in-loop filter control parameters specified by bit stream. <br>
DeblockMode_OnlyRef - Run in-loop filter only for reference pictures. <br>
DeblockMode_Off - Skip in-loop filter for all pictures. May produce artifacts. <br>
</dd></dl> \hideinitializer */ // {8DE7DD1D-F577-4531-ABCD-F15BF5F0CCF7}
static const GUID EH264VD_Deblock = 
{ 0x8de7dd1d, 0xf577, 0x4531, { 0xab, 0xcd, 0xf1, 0x5b, 0xf5, 0xf0, 0xcc, 0xf7 } };

/**  
Sets the deinterlacing mode.
\details <dl><dt><b>  Type: </b></dt><dd> 
VT_UI4 </dd></dl>
<dl><dt><b>  Available Values: </b></dt><dd>
Deinterlace_Weave - Do not deinterlace - output interleaved fields.<br>
Deinterlace_VerticalFilter - Deinterlace by vertical smooth filter.<br>
Deinterlace_FieldInterpolation - Deinterlace by interpolation one field from another.<br>
Deinterlace_VMR - Deinterlace by means of VMR (Video Mixing Renderer). It is possible only if the filter is connected to VMR or OveralyMixer. Deinterlace technology can be set in renderer.<br>
Deinterlace_Auto - Automatic deinterlace if picture type is field or MBAFF. If decoder works in software mode then field interpolation deinterlace will be applied.<br>
</dd></dl> \hideinitializer */ // {9CF1A332-E72B-4a6d-BBE8-199595944546}
static const GUID EH264VD_Deinterlace = 
{0x9cf1a332, 0xe72b, 0x4a6d, {0xbb, 0xe8, 0x19, 0x95, 0x95, 0x94, 0x45, 0x46 }};

/**  \hideinitializer */ // {9CF1A333-E72B-4a6d-BBE8-199595944546}
static const GUID EH264VD_HQUpsample = 
{0x9cf1a333, 0xe72b, 0x4a6d, {0xbb, 0xe8, 0x19, 0x95, 0x95, 0x94, 0x45, 0x46 }};
// Since SDK8.6 this option has no effect.

/**  
Enables/disables the generation of one progressive frame from every field. If double rate is switched on and deinterlace mode is Deinterlace_Weave then filter will produce double number of frames in such order: fields 0 and 1 into frame 0, fields 1 and 2 into frame 1 etc. Such processing allows to solve the interlace error when interlace device is used as output. 
\details <dl><dt><b>  Type: </b></dt><dd> 
VT_UI4 </dd></dl>
<dl><dt><b>  Available Values: </b></dt><dd>
0 - Feature is disabled (default).<br>
1 - Feature is enabled.<br>
</dd></dl> \hideinitializer */ // {9CF1A339-E72B-4a6d-BBE8-199595944546}
static const GUID EH264VD_DoubleRate = 
{0x9cf1a339, 0xe72b, 0x4a6d, {0xbb, 0xe8, 0x19, 0x95, 0x95, 0x94, 0x45, 0x46 }};

/**  
Sets the fields reordering mode.
\details <dl><dt><b>  Type: </b></dt><dd> 
VT_UI4 </dd></dl>
<dl><dt><b>  Available Values: </b></dt><dd>
FieldReordering_Off - Feature is disabled (default).<br>
FieldReordering_FlagsInverting - Fields are reordered by inverting the specific media sample flags.<br>
FieldReordering_FieldsInverting - Fields are reordered by exchanging the fields in picture.<br>
</dd></dl> \hideinitializer */ // {9951682E-0F78-4924-92A4-BD7BFBA30063}
static const GUID EH264VD_FieldsReordering = 
{0x9951682e, 0xf78, 0x4924, {0x92, 0xa4, 0xbd, 0x7b, 0xfb, 0xa3, 0x0, 0x63 }};

/**  
Specifies the condition when fields must be reordered.
\details <dl><dt><b>  Type: </b></dt><dd> 
VT_UI4 </dd></dl>
<dl><dt><b>  Available Values: </b></dt><dd>
FieldReorderingCondition_Always - Always (default).<br>
FieldReorderingCondition_TopFirst_True - If TopFirst flag is TRUE.<br>
FieldReorderingCondition_TopFirst_False - If TopFirst flag is FALSE.<br>
</dd></dl> \hideinitializer */ // {8AE4A3D8-240B-427d-B845-5474965CBB48}
static const GUID EH264VD_FieldsReorderingCondition = 
{ 0x8ae4a3d8, 0x240b, 0x427d, { 0xb8, 0x45, 0x54, 0x74, 0x96, 0x5c, 0xbb, 0x48 } };

/**  
Retrieves the MediaTimeStart value of the last delivered frame (it may be a byte offset of the current frame as set by upstream demultiplexer/splitter in the media sample parameters). Typically application queries this parameter after receiving notification on parameter change from the filter (see Module Configuration Programmer Guide).
\details <dl><dt><b>  Type: </b></dt><dd> 
VT_I8 </dd></dl>
<dl><dt><b>  Available Values: </b></dt><dd>
I64_MIN - I64_MAX
</dd></dl> \hideinitializer */ // {3903A73E-6A89-4e09-8E9F-95E8A56F614D}
static const GUID EH264VD_MediaTimeStart = 
{ 0x3903a73e, 0x6a89, 0x4e09, { 0x8e, 0x9f, 0x95, 0xe8, 0xa5, 0x6f, 0x61, 0x4d } };

/**  
Retrieves the MediaTimeStop value of the last delivered frame (it may be a byte offset of the current frame as set by upstream demultiplexer/splitter in the media sample parameters). Typically application queries this parameter after receiving notification on parameter change from the filter (see Module Configuration Programmer Guide).
\details <dl><dt><b>  Type: </b></dt><dd> 
VT_I8 </dd></dl>
<dl><dt><b>  Available Values: </b></dt><dd>
I64_MIN - I64_MAX
</dd></dl> \hideinitializer */ // {BCF5D243-B80E-400a-9B60-035A1D3E5C38}
static const GUID EH264VD_MediaTimeStop = 
{ 0xbcf5d243, 0xb80e, 0x400a, { 0x9b, 0x60, 0x3, 0x5a, 0x1d, 0x3e, 0x5c, 0x38 } };

/**  
Enables/disables the option to display of the decoding statistical information.
\details <dl><dt><b>  Type: </b></dt><dd> 
VT_UI4 </dd></dl>
<dl><dt><b>  Available Values: </b></dt><dd>
0 - Feature is disabled (default).<br>
1 - Feature is enabled.<br>
</dd></dl> \hideinitializer */ // {F5C51906-ED89-4c6e-9C37-A5CCB34F5389}
static const GUID EH264VD_OSD = 
{0xf5c51906, 0xed89, 0x4c6e, {0x9c, 0x37, 0xa5, 0xcc, 0xb3, 0x4f, 0x53, 0x89 }};

/**  
The option specifies the PTS (Presentation Time Stamp) usage for calculating the output time. The option enables you to correct PTS mistakes which might occur in some streams. 
\details <dl><dt><b>  Type: </b></dt><dd> 
VT_UI4 </dd></dl>
<dl><dt><b>  Available Values: </b></dt><dd>
0 - Synchronizing_PTS.<br>
1 - Synchronizing_IgnorePTS_NotRef.<br>
2 - Synchronizing_IgnorePTS_All.<br>
3 - Synchronizing_DirectTimestamps<br>
4 - Synchronizing_IgnoreHRD<br>
</dd></dl> \hideinitializer */ // {24F62768-7740-437f-9651-9ED347C0CAD6}
static const GUID EH264VD_SYNCHRONIZING = 
{ 0x24f62768, 0x7740, 0x437f, { 0x96, 0x51, 0x9e, 0xd3, 0x47, 0xc0, 0xca, 0xd6 } };

/**  
The option specifies the format of video info header for output media types. 
\details <dl><dt><b>  Type: </b></dt><dd> 
VT_UI4 </dd></dl>
<dl><dt><b>  Available Values: </b></dt><dd>
0 - FormatVideoInfo_1.<br>
1 - FormatVideoInfo_2.<br>
2 - FormatVideoInfo_Both.<br>
</dd></dl> \hideinitializer */ // {110272F6-DA17-4162-B6BA-866CC5CB6889}
static const GUID EH264VD_FormatVideoInfo = 
{0x110272f6, 0xda17, 0x4162, {0xb6, 0xba, 0x86, 0x6c, 0xc5, 0xcb, 0x68, 0x89 }};

/**  
It specifies the way of interpretation of the frame rate value. In according with the standard this value should correspond to field rate.
\details <dl><dt><b>  Type: </b></dt><dd> 
VT_UI4 </dd></dl>
<dl><dt><b>  Available Values: </b></dt><dd>
0 - RateMode_Field.<br>
1 - RateMode_Frame.<br>
2 - RateMode_Fixed (the decoder skips rate parameters which are defined in stream and uses "Fixed frame rate" value as frame rate).<br>

</dd></dl> \hideinitializer */ // {AF65371F-7E7D-40a4-A1BA-AAFD10090ACD}
static const GUID EH264VD_RateMode = 
{ 0xaf65371f, 0x7e7d, 0x40a4, { 0xa1, 0xba, 0xaa, 0xfd, 0x10, 0x9, 0xa, 0xcd } };


/**  
It specifies the value of frame rate. The decoder uses this as frame rate if "Rate interpretation" is equal to RateMode_Fixed.
\details <dl><dt><b>  Type: </b></dt><dd> 
VT_R8 </dd></dl>
<dl><dt><b>  Available Values: </b></dt><dd>
0.01 - 99.99
</dd></dl> \hideinitializer */ // {1959B33C-DB92-47ec-B466-6308D9FBC081}
static const GUID EH264VD_FrameRate = 
{ 0x1959b33c, 0xdb92, 0x47ec, { 0xb4, 0x66, 0x63, 0x8, 0xd9, 0xfb, 0xc0, 0x81 } };


/**\hideinitializer */ // {9CF1A330-E72B-4a6d-BBE8-199595944546}
static const GUID EH264VD_SkipMode = 
{0x9cf1a330, 0xe72b, 0x4a6d, {0xbb, 0xe8, 0x19, 0x95, 0x95, 0x94, 0x45, 0x46 }};

/**  
Retrieves the number of decoded frames. (redefined global MC_FramesDecoded)
\details <dl><dt><b>  Type: </b></dt><dd> 
VT_UI4 </dd></dl>
 \hideinitializer */
#define EH264VD_FramesDisplayed MC_FramesDecoded

/**  
Retrieves the number of skipped frames.(redefined global MC_FramesSkipped)
\details <dl><dt><b>  Type: </b></dt><dd> 
VT_UI4 </dd></dl>
</dd></dl> \hideinitializer */
#define EH264VD_FramesSkipped MC_FramesSkipped

/**  
The decoder provides minimal output delay if this flag is set. It gives one output frame as this is only possible according to the standard decoding process. Otherwise, it waits for filling DPB and gives only one output frame after it receives one new frame. Smooth removing of frames from DPB provides more smooth playback at 'live' decoding and at decoding on low power machines.
\details <dl><dt><b>  Type: </b></dt><dd> 
VT_UI4 </dd></dl>
<dl><dt><b>  Available Values: </b></dt><dd>
0 - Feature is disabled (default).<br>
1 - Feature is enabled.<br>
</dd></dl> \hideinitializer */ // {4B5E5B27-8D3F-492a-8B28-1265E7E5CE51}
static const GUID EH264VD_LowLatency = 
{ 0x4b5e5b27, 0x8d3f, 0x492a, { 0x8b, 0x28, 0x12, 0x65, 0xe7, 0xe5, 0xce, 0x51 } };

/**  
Specifies whether the decoder should display the output frames in stream order or not.
\details <dl><dt><b>  Type: </b></dt><dd> 
VT_UI4 </dd></dl>
<dl><dt><b>  Available Values: </b></dt><dd>
0 - Feature is disabled (default).<br>
1 - Feature is enabled.<br>
</dd></dl> \hideinitializer */ // {938C1C39-2D34-4ee5-9789-E67C0D1ADD40}
static const GUID EH264VD_StreamOrder = 
{ 0x938c1c39, 0x2d34, 0x4ee5, { 0x97, 0x89, 0xe6, 0x7c, 0xd, 0x1a, 0xdd, 0x40 } };

/** \hideinitializer */ // {69F3278F-5643-4d25-92E1-92E13980BEE7}
static const GUID EH264VD_ReallocationOfOutputBuffer = 
{ 0x69f3278f, 0x5643, 0x4d25, { 0x92, 0xe1, 0x92, 0xe1, 0x39, 0x80, 0xbe, 0xe7 } };

/**  
Specifies the limits precision of motion vectors.
\details <dl><dt><b>  Type: </b></dt><dd> 
VT_UI4 </dd></dl>
<dl><dt><b>  Available Values: </b></dt><dd>
0 - MVPrecision_Quarter (default).<br>
1 - MVPrecision_Half.<br>
2 - MVPrecision_Full.<br>

</dd></dl> \hideinitializer */ // {0CDEC584-A8E0-45d2-AA35-72F65837DF29}
static const GUID EH264VD_MotionVectorsPrecision = 
{ 0xcdec584, 0xa8e0, 0x45d2, { 0xaa, 0x35, 0x72, 0xf6, 0x58, 0x37, 0xdf, 0x29 } };

/** \hideinitializer */ // {92B8B412-2FA6-4cda-8153-0F1150CD3AC3}
static const GUID EH264VD_MediaTimeMode = 
{ 0x92b8b412, 0x2fa6, 0x4cda, { 0x81, 0x53, 0xf, 0x11, 0x50, 0xcd, 0x3a, 0xc3 } };


/**  
Get user data.
\details <dl><dt><b>  Type: </b></dt><dd> 
VT_BYREF </dd></dl>
\note 
For the user data capturing the IModuleConfig::GetValue method must be called with the pointer to a non-initialized VARIANT variable as the second parameter.
When at capturing moment the decoder not has any decoded picture nor new user data then the E_FAIL error code is returned.
If the method call was successful then the vt field of returned VARIANT variable is set to VT_BYREF and byref field is set to memory address of sei_message_t  data structure allocated by the decoder.
When all operations with the captured user data are finished, you need to call CoTaskMemFree. 

  \code
CComPtr<IModuleConfig> spConfig;

if (SUCCEEDED(m_MPEG2VD->QueryInterface(IID_IModuleConfig, (void**)&spConfig)) && spConfig) 
{
    CComVariant var;
    var.Clear();
    static uint32_t dwSEIcnt = 0;
    static uint32_t dwDataLength = 0;
    if (spConfig->GetValue(EH264VD_CaptureSEIData, &var) == S_OK) 
    {
        if (var.vt == VT_BYREF && var.byref)
         {
            sei_message_t *pm = (sei_message_t *)var.byref;

            // some operations with captured user data
            dwSEIcnt += pm->num_messages;

            for (int i=0; i<pm->num_messages;i++)
                dwDataLength += pm->sei_payload[i].payload_size;

            // free allocated memory buffer
            CoTaskMemFree(var.byref);
        }       
    }
} \endcode
\hideinitializer */ // {635DD072-6941-4261-8082-2D037DF269E4}
static const GUID EH264VD_CaptureSEIData = 
{ 0x635dd072, 0x6941, 0x4261, { 0x80, 0x82, 0x2d, 0x3, 0x7d, 0xf2, 0x69, 0xe4 } };


#endif //#ifndef __H264VD_AVCDEC_MODULECONFIG_PROPID__
