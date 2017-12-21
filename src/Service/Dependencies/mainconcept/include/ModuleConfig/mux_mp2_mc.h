/*!
 * @file mux_mp2_mc.h
 * @brief Property GUIDs for MainConcept MPEG-2 muxer parameters.
 * File: mux_mp2_mc.h
 *
 * Desc: Property GUIDs for MainConcept MPEG-2 muxer parameters.
 *
 * Copyright (c) 2015 MainConcept GmbH or its affiliates.  All rights reserved.
 *
 * MainConcept and its logos are registered trademarks of MainConcept GmbH or its affiliates.  
 * This software is protected by copyright law and international treaties.  Unauthorized 
 * reproduction or distribution of any portion is prohibited by law.
 */

#ifndef __MPEG2MUX_FILTER_PROPID__
#define __MPEG2MUX_FILTER_PROPID__

/*! @brief This parameter is used to define a concrete type of IModuleConfig (Program).
 */
static const GUID MCMux_Program =
{0xbeb95059, 0xef42, 0x4599, {0x8b, 0x5e, 0x54, 0x3c, 0x31, 0xc, 0xc1, 0x5f}};

/*! @brief This parameter is used to define a concrete type of IModuleConfig (Stream).
 */
static const GUID MCMux_Stream =
{0xde798a3e, 0x5e4d, 0x484f, {0xaa, 0x3, 0x1d, 0xed, 0x84, 0x75, 0x6d, 0xdb}};

//! @name Muxer operations
//!@{

///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
//            GUID             Value Type        Range        Default        Description
///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

/*!
@brief This parameter allows receiving pointers to the IModuleConfig interfaces for all of the
programs created in the multiplexer.
@details To receive the pointer to the first program, it is necessary to clear the parameter Value
(the second parameter of the GetValue method (const GUID* pApi, VARIANT * pValue)).
Within the same parameter, the pointer to the first program will be sent.
To receive the pointer to the next program it is necessary to transfer the
Value parameter, received in the previous GetValue call. Read only.

For example:
@verbatim
HRESULT hr;
CComVariant Program;//the variable Program has a
//VT_UNKNOWN type by default
p->GetValue(&MCMux_GetNextProgram, &Program);
while ( Program.vt == VT_UNKNOWN )
{
//The pointer to the next program is returned
...//Work with the pointer
//Get the pointer to the next program
p->GetValue(&MCMux_GetNextProgram, &Program);
}
@endverbatim

@note After the parameter is used, it is necessary to clear it (call Value.punkVal->Release()). Use the
function VariantClear(VARIANT * pValue) or the class CComVariant to clear the structure VARIANT
automatically.

<dl><dt>Type:             </dt>   <dd>  VT_UNKNOWN </dd></dl>
<dl><dt>Available range:  </dt>   <dd>  [0, IUnk]  </dd></dl>
<dl><dt>Default value:    </dt>   <dd>  0          </dd></dl>
<dl><dt>Read only:        </dt>   <dd>  yes        </dd></dl>
@hideinitializer
*/
// MCMux_GetNextProgram        VT_UNKNOWN        [0, IUnk]    0              Retrieve next program. Value = 0 return the first program.
// {197745C4-A403-44de-89C3-969B127901F3}
static const GUID MCMux_GetNextProgram =
{0x197745c4, 0xa403, 0x44de, {0x89, 0xc3, 0x96, 0x9b, 0x12, 0x79, 0x1, 0xf3}};

/*!
@brief This parameter is accessible only through the SetValue method. Creates a new program and
returns the pointer to the IModuleConfig interface of this program.

@note After the parameter is used, it is necessary to clear it (call Value.punkVal->Release()). Use the
function VariantClear(VARIANT * pValue) or the class CComVariant to clear the structure VARIANT
automatically.

<dl><dt>Type:             </dt>   <dd>  VT_UNKNOWN </dd></dl>
<dl><dt>Default value:    </dt>   <dd>  0          </dd></dl>
@hideinitializer
*/
// MCMux_CreateProgram        VT_UNKNOWN         -            0              Create program.
// {1C10A3F8-98AA-45a7-8332-3E82640C64AA}
static const GUID MCMux_CreateProgram = 
{0x1c10a3f8, 0x98aa, 0x45a7, {0x83, 0x32, 0x3e, 0x82, 0x64, 0xc, 0x64, 0xaa}};

/*!
@brief This parameter is accessible only through the SetValue method. Creates a new program and
returns the pointer to the IModuleConfig interface of this program.

<dl><dt>Type:             </dt>   <dd>  VT_UNKNOWN </dd></dl>
<dl><dt>Default value:    </dt>   <dd>  0          </dd></dl>
@hideinitializer
*/
// MCMux_DestroyProgram        VT_UNKNOWN        -            0              Destroy program.
// {06250D30-F7D6-4f5c-A4B4-36170F3FE552}
static const GUID MCMux_DestroyProgram = 
{0x6250d30, 0xf7d6, 0x4f5c, {0xa4, 0xb4, 0x36, 0x17, 0xf, 0x3f, 0xe5, 0x52}};

//!@}


///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
//            GUID              Type         Range         Default     Description
///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

//! @name Muxer properties
//!@{

/*!
@brief This parameter specifies the type of the output stream.

<dl><dt>Type:             </dt>   <dd>  VT_I4     </dd></dl>
<dl><dt>Available range:  </dt>   <dd>  
 - 1 – MPEG-2 Program Stream (ISO/IEC 13818-1)
 - 2 – MPEG-2 Transport Stream (ISO/IEC 13818-1)
 - 3 – RESULT_STREAM_MPEG1_SYSTEM
 - 4 – RESULT_STREAM_VCD
 - 6 – RESULT_STREAM_SVCD
 - 7 – RESULT_STREAM_DVD
 - 8 – RESULT_STREAM_DVD_MPEG1
 - 11 – RESULT_STREAM_DVB
 - 14 – RESULT_STREAM_ATSC
 - 16 – RESULT_STREAM_HDV_HD1
 - 17 – RESULT_STREAM_HDV_HD2
 - 18 – RESULT_STREAM_AVCHD
 - 19 – RESULT_STREAM_HDMV
 - 20 – RESULT_STREAM_CABLELABS
 - 21 – RESULT_STREAM_1SEG
 - 22 - RESULT_STREAM_ATT
 - 23 - RESULT_STREAM_DTV
  </dd></dl>
<dl><dt>Default value:    </dt>   <dd>  RESULT_STREAM_TRANSPORT  </dd></dl>
@hideinitializer
*/
// MCMux_OutputStreamType       VT_I4        [enum]           2        2 = RESULT_STREAM_TRANSPORT value in OutputStreamType_t enum below
// {6E7564E3-05FA-417a-AA8E-50E474537EC3}
static const GUID MCMux_OutputStreamType = 
{0x6e7564e3, 0x5fa, 0x417a, {0xaa, 0x8e, 0x50, 0xe4, 0x74, 0x53, 0x7e, 0xc3}};

/*!
@brief This parameter is available only for Transport Stream. It specifies the value of the output
stream bit rate (bits/sec).
@details This value must exceed the total bit rate of the input streams at
least by 5%.
If 0 the bit rate is estimated automatically based on stream rates.

<dl><dt>Type:             </dt>   <dd>  VT_I4            </dd></dl>
<dl><dt>Available range:  </dt>   <dd>  [0, 1000000000]  </dd></dl>
<dl><dt>Default value:    </dt>   <dd>  0                </dd></dl>
@hideinitializer
*/
// MCMux_RequiredBitrate        VT_I4        [0 - 100M]       0        Destination mux bit rate value, bits/sec. If 0 the bit rate is estimated automatically based on stream rates
// {94E294E0-8B4C-40df-B429-B43B3F2BE4E7}
static const GUID MCMux_RequiredBitrate = 
{0x94e294e0, 0x8b4c, 0x40df, {0xb4, 0x29, 0xb4, 0x3b, 0x3f, 0x2b, 0xe4, 0xe7}};

/*!
@brief This option is available only for Transport Streams. Allows the user to specify a time distance
between two consecutive Program Clock Reference fields.
@details This value is automatically
assigned for the profiles which have strict requirements on this.

<dl><dt>Type:             </dt>   <dd>  VT_I4          </dd></dl>
<dl><dt>Available range:  </dt>   <dd>  [10, 250 ms]   </dd></dl>
<dl><dt>Default value:    </dt>   <dd>  50             </dd></dl>
@hideinitializer
*/
// MCMux_PCR_Interval           VT_I4        [10 - 250 ms]    50       Time interval between two consecutive PCR stamps. For TS only
// {4F6F3CCD-989A-4318-B9F7-FC605C7EDFED}
static const GUID MCMux_PCR_Interval = 
{0x4f6f3ccd, 0x989a, 0x4318, {0xb9, 0xf7, 0xfc, 0x60, 0x5c, 0x7e, 0xdf, 0xed}};

/*!
@brief This is a 16-bit field identifies the Transport Stream among other streams in a network.
@details The value satisfies the requirements for the transport_stream_id field (ISO/IEC 13818-1
Table 2-26, Program association section).  Set to -1 for a computed value.

<dl><dt>Type:             </dt>   <dd>  VT_I4          </dd></dl>
<dl><dt>Available range:  </dt>   <dd>  [-1, 0xFFFF]   </dd></dl>
<dl><dt>Default value:    </dt>   <dd>  0              </dd></dl>
@hideinitializer
*/
// MCMux_TransportStreamID      VT_I4        [-1-0xFFFF]      0        16-bit field that serves as a label to identify the Transport Stream among other streams in a network
// {6C376C4D-D6B9-40ea-AD1F-A70C7948A4E9}                              set to -1 for a computed value
static const GUID MCMux_TransportStreamID = 
{0x6c376c4d, 0xd6b9, 0x40ea, {0xad, 0x1f, 0xa7, 0xc, 0x79, 0x48, 0xa4, 0xe9}};

/*!
@brief This is a 16-bit field that serves as a label to identify the network.
@details Set to -1 for a computed value.

<dl><dt>Type:             </dt>   <dd>  VT_I4          </dd></dl>
<dl><dt>Available range:  </dt>   <dd>  [-1, 0xFFFF]   </dd></dl>
<dl><dt>Default value:    </dt>   <dd>  0              </dd></dl>
@hideinitializer
*/
// MCMux_NetworkID              VT_I4        [-1-0xFFFF]      0        16-bit field that serves as a label to identify the network
// {C35BAA13-C01C-4da5-A5F9-3275F4018A08}                              set to -1 for a computed value
static const GUID MCMux_NetworkID = 
{ 0xc35baa13, 0xc01c, 0x4da5, { 0xa5, 0xf9, 0x32, 0x75, 0xf4, 0x1, 0x8a, 0x8 } };

/*!
@brief This parameter specifies the output pin buffer size.

<dl><dt>Type:             </dt>   <dd>  VT_I4          </dd></dl>
<dl><dt>Available range:  </dt>   <dd>  [2K, 1MB]      </dd></dl>
<dl><dt>Default value:    </dt>   <dd>  64K            </dd></dl>
@hideinitializer
*/
// MCMux_OutputBufSize          VT_I4        [2K-1MB]         64K      The size of output buffer, bytes
// {6BB968B3-7E26-44fe-ADB2-D0C81C96E304}
static const GUID MCMux_OutputBufSize = 
{0x6bb968b3, 0x7e26, 0x44fe, {0xad, 0xb2, 0xd0, 0xc8, 0x1c, 0x96, 0xe3, 0x4}};

/*!
@brief This parameter enables (1) or disables (0) the automatic creation of free input pins.

<dl><dt>Type:             </dt>   <dd>  VT_I4          </dd></dl>
<dl><dt>Available range:  </dt>   <dd>  
 - 0 - Disabled
 - 1 - Enabled
 </dd></dl>
<dl><dt>Default value:    </dt>   <dd>  1              </dd></dl>
@hideinitializer
*/
// MCMux_AutoCreatePins         VT_I4        [0,1]            1        This flag specifies whether filter creates pins automatically, or pins are created by user's request only 
// {EFA4CA3D-E626-47f4-A045-4F717175962E}
static const GUID MCMux_AutoCreatePins = 
{0xefa4ca3d, 0xe626, 0x47f4, {0xa0, 0x45, 0x4f, 0x71, 0x71, 0x75, 0x96, 0x2e}};

/*!
@brief Enables/disables the padding packets sending to meet the STD restrictions.
@details If the padding is disabled, the bitrate of multiplexed stream is variable (VBR).
Otherwise the bitrate is constant (CBR).<br>
For Program Streams the default is 1, except for SVCD and DVD profiles. For Transport
Streams the default is 1, except for AVCHD and BluRay profiles.

<dl><dt>Type:             </dt>   <dd>  VT_I4          </dd></dl>
<dl><dt>Available range:  </dt>   <dd>  
 - 0 - Disabled
 - 1 - Enabled
 </dd></dl>
<dl><dt>Default value:    </dt>   <dd>  1              </dd></dl>
@hideinitializer
*/
// MCMux_PaddingControl         VT_I4        [0,1]            1        This flag enables / disables padding in the output stream 
// {218C3E56-54FC-43fe-87AC-39D3EE2AB3BB}
static const GUID MCMux_PaddingControl = 
{0x218c3e56, 0x54fc, 0x43fe, {0x87, 0xac, 0x39, 0xd3, 0xee, 0x2a, 0xb3, 0xbb}};

/*!
@brief This parameter is available only for Transport Stream. Specifies the number of transport
packets accumulated on the output pin in order to be sent by the single media sample.

<dl><dt>Type:             </dt>   <dd>  VT_INT         </dd></dl>
<dl><dt>Available range:  </dt>   <dd>  [1, 500]       </dd></dl>
<dl><dt>Default value:    </dt>   <dd>  5              </dd></dl>
@hideinitializer
*/
// MCMux_TS_Outpack_Size        VT_I4        [1,500]          5        Number of TS packets to combine at the output pin before being sent to a downstream filter. Valid for TS only.
// {2394EEE2-51FD-4169-96D1-74D9E45B3343}
static const GUID MCMux_TS_Outpack_Size =
{0x2394eee2, 0x51fd, 0x4169, {0x96, 0xd1, 0x74, 0xd9, 0xe4, 0x5b, 0x33, 0x43}};

/*!
@brief The TS / PS rate which is used by the multiplexer in case if Required Bitrate is not set. 
@details The value is automatically calculated by the multiplexer basing on the input streams' bitrates.
(Statistical, read only).

<dl><dt>Type:             </dt>   <dd>  VT_I4          </dd></dl>
<dl><dt>Default value:    </dt>   <dd>  0              </dd></dl>
<dl><dt>Read only:        </dt>   <dd>  yes            </dd></dl>
@hideinitializer
*/
// MCMux_OutputBitrate          VT_I4        -                0        For statistic only. Value of TS bit rate, bits/sec
// {762F0204-DB00-44e4-9928-EF7828DB9E5F}
static const GUID MCMux_OutputBitrate =
{0x762f0204, 0xdb00, 0x44e4, {0x99, 0x28, 0xef, 0x78, 0x28, 0xdb, 0x9e, 0x5f}};

/*!
@brief Retrieves the current PCR or SCR value.
@details Read-only. Updates in real-time.

<dl><dt>Type:             </dt>   <dd>  VT_I8          </dd></dl>
<dl><dt>Read only:        </dt>   <dd>  yes            </dd></dl>
@hideinitializer
*/
// MCMux_MuxTime                VT_I8        -                -        Current system stream time, read only
// {A32C0F2B-37FE-4417-B469-349C3C271E88}
static const GUID MCMux_MuxTime =
{0xa32c0f2b, 0x37fe, 0x4417, {0xb4, 0x69, 0x34, 0x9c, 0x3c, 0x27, 0x1e, 0x88}};

/*!
@brief Padding given by muxer in percents to payload data, read ony.

<dl><dt>Type:             </dt>   <dd>  VT_I8          </dd></dl>
<dl><dt>Default value:    </dt>   <dd>  0              </dd></dl>
<dl><dt>Read only:        </dt>   <dd>  yes            </dd></dl>
@hideinitializer
*/
// MCMux_PaddingStatistics      VT_I8        -                0        Padding given by muxer in percents to payload data, read ony
// {BF817BCE-199F-47d9-8641-B95D263381F0}
static const GUID MCMux_PaddingStatistics =
{0xbf817bce, 0x199f, 0x47d9, {0x86, 0x41, 0xb9, 0x5d, 0x26, 0x33, 0x81, 0xf0}};

/*!
@brief PAT / PMT repetition rate.

<dl><dt>Type:             </dt>   <dd>  VT_I4          </dd></dl>
<dl><dt>Available range:  </dt>   <dd>  [40, 36000000] </dd></dl>
<dl><dt>Default value:    </dt>   <dd>  100            </dd></dl>
@hideinitializer
*/
// MCMux_PSI_Repetition_Rate    VT_I4        [40,36000000]    100      PAT / PMT repetition rate     
static const GUID MCMux_PSI_Repetition_Rate = 
{ 0x220290c1, 0x7150, 0x4ec6, {0xb0, 0x4d, 0x2b, 0xa0, 0xdb, 0x7a, 0x61, 0xad} };

/*!
@brief Statistical value (read only). Indicates the time interval (in 100 ns units) which has left since
the multiplexing process run.
@details The value is derived using the DirectShow Graph clocks. If
clocks are unavailable, the parameter has 0 value. This value is updating in real-time each
time when data is sent to the multiplexer's output. For real-time multimedia streaming
systems, this value should go on closely to the MCMux_MuxTime value. The increasing
difference between these two values indicates that the streaming fails to achieve real-time
conditions, and the playback on the receiver's side can be faster or slower than intended.
Such effect can be observed, e.g., if the encoding PC performance is not enough and an
encoder generates less frames per second than needed.

<dl><dt>Type:             </dt>   <dd>  VT_I8          </dd></dl>
<dl><dt>Default value:    </dt>   <dd>  0              </dd></dl>
<dl><dt>Read only:        </dt>   <dd>  yes            </dd></dl>
@hideinitializer
*/
// MCMux_Graph_Time             VT_I8        -                -        Current graph time, read only
// {B2DE6A39-13B1-4cea-9A7D-F78ECA78B1F6}
static const GUID MCMux_Graph_Time = 
{ 0xb2de6a39, 0x13b1, 0x4cea, { 0x9a, 0x7d, 0xf7, 0x8e, 0xca, 0x78, 0xb1, 0xf6 } };

/*!
@brief Only connect with PES sources.

<dl><dt>Type:             </dt>   <dd>  VT_I4          </dd></dl>
<dl><dt>Available range:  </dt>   <dd>  [0, 1]         </dd></dl>
<dl><dt>Default value:    </dt>   <dd>  0              </dd></dl>
@hideinitializer
*/
// MCMux_ConnectOnlyOnPES       VT_I4        [0,1]            0        Only connect with PES sources
// {B48E5C56-CA5D-44d2-8EA3-921DE8559EB9}
static const GUID MCMux_ConnectOnlyOnPES = 
{ 0xb48e5c56, 0xca5d, 0x44d2, { 0x8e, 0xa3, 0x92, 0x1d, 0xe8, 0x55, 0x9e, 0xb9 } };

/*!
@brief This parameter is effective for PS-profiles only. Sets the sector size in bytes 
(PS pack size including PES).
@details It also affects PES lengths of all streams being multiplexed - 
they all are set to the value of this parameter minus PS pack hdr size.
0 means wrap frames in a PES packet.

<dl><dt>Type:             </dt>   <dd>  VT_I4          </dd></dl>
<dl><dt>Available range:  </dt>   <dd>  [0, 64K]       </dd></dl>
<dl><dt>Default value:    </dt>   <dd>  0              </dd></dl>
@hideinitializer
*/
// MCMux_SectorSize             VT_I4        [0,64K]          0        Sector size in bytes, 0 means wrap frames in a PES packet
// {060E9757-5FE8-4f2e-9492-570843FABAB6}
static const GUID MCMux_SectorSize = 
{ 0x60e9757, 0x5fe8, 0x4f2e, { 0x94, 0x92, 0x57, 0x8, 0x43, 0xfa, 0xba, 0xb6 } };

/*!
@brief Available for Transport Streams only. Call this parameter to add the descriptor into the target
PSI table.
@brief The VARIANT.pbVal field should be a pointer to the filled si_descriptor_struct structure
(refer to the \ref MUXMP2LL "Low-Level Multiplexer specification" for the details). The multiplexer instantly
copies the data by the pointer into the internal memory. The calling application is responsible
for memory deallocating itself.
When a set of descriptors to be loaded is configured, call the MuxerObject->SetValue()
method with the MCMux_PSICommit parameter GUID to apply the writing of the loaded
descriptors.

Here is the sample of how to write the language descriptor into PMT
loop for target program_number and PID.
@code
int PMT_TABLE_ID = 0x02;
si_descriptor_struct desc;
desc.descriptor_tag = 10; // lang desc tag
desc.descriptor_length = 4;// 4 bytes of payload
unsigned char data_buf[4] = {'e','n','g','\0'}; // English
desc.pbData = data_buf; //{}; = new
uint8_t[desc.descriptor_length];
desc.target_table_id = PMT_TABLE_ID; //specify the target table
//is PMT
desc.target_table_id_ext = program->program_number; //specify
//the target program number
desc.target_entry_id = pin->PID;
desc.target_entry_id_ext = -1;
desc.target_loop = eInner_descriptor_loop;// it goes into INNER
//descriptor loop, other words
//applied for stream's description
VARIANT Val;
Val.vt = VT_PTR;
Val.pbVal = (PBYTE)&desc; //!! pass the pointer to the
descriptor
pMuxModCfg->SetValue(&MCMux_LoadDescriptor, &Val);
// delete [] desc.pbData;//calling app is responsible for memory
//cleaning
si_commit_struct psi_struct;
psi_struct.target_time_PCR = 0; // apply immediately. To set to
be applied at 10 mins of stream (by PCR) set to 16200000000;
Val.pbVal = (PBYTE)&psi_struct; //pass the pointer to the commit
//structure
pMuxModCfg->SetValue(&MCMux_PSICommit, &Val);
@endcode

<dl><dt>Type:             </dt>   <dd>  VT_BYREF | VT_UI1  </dd></dl>
<dl><dt>Default value:    </dt>   <dd>  NULL               </dd></dl>
@hideinitializer
*/
// MCMux_LoadDescriptor         VT_BYREF | VT_UI1             NULL     Pointer to a si_descriptor_struct defined below
// {7074F9D9-8885-4220-88D0-B04E171788EF}
static const GUID MCMux_LoadDescriptor = 
{ 0x7074f9d9, 0x8885, 0x4220, { 0x88, 0xd0, 0xb0, 0x4e, 0x17, 0x17, 0x88, 0xef } };

/*!
@brief Pointer to a si_entry_struct defined below.

<dl><dt>Type:             </dt>   <dd>  VT_BYREF | VT_UI1  </dd></dl>
<dl><dt>Default value:    </dt>   <dd>  NULL               </dd></dl>
@hideinitializer
*/
// MCMux_LoadEntry              VT_BYREF | VT_UI1             NULL     Pointer to a si_entry_struct defined below
// {3EFA325B-C749-43DA-ACF8-186C71918AAF}
static const GUID MCMux_LoadEntry = 
{ 0x3efa325b, 0xc749, 0x43da, { 0xac, 0xf8, 0x18, 0x6c, 0x71, 0x91, 0x8a, 0xaf } };

/*!
@brief Pointer to a si_section_struct defined below.

<dl><dt>Type:             </dt>   <dd>  VT_BYREF | VT_UI1  </dd></dl>
<dl><dt>Default value:    </dt>   <dd>  NULL               </dd></dl>
@hideinitializer
*/
// MCMux_LoadSection            VT_BYREF | VT_UI1             NULL     Pointer to a si_section_struct defined below
// {E44CF421-A51B-4150-B4DE-645ED2CD5EEC}
static const GUID MCMux_LoadSection = 
{ 0xe44cf421, 0xa51b, 0x4150, { 0xb4, 0xde, 0x64, 0x5e, 0xd2, 0xcd, 0x5e, 0xec } };

/*!
@brief Call to commit the set of loaded descriptors into PSI.
@details The VARIANT.pbVal field should be a
pointer to the filled si_commit_struct structure (refer to the \ref MUXMP2LL "Low Level Multiplexer secification" for the details).
The multiplexer starts writing the set of the descriptors being
commited when the Muxer Time will achieve si_commit_strucr.target_time_PCR. The
multiplexer instantly copies the data by the pointer into the internal memory. The calling
application is responsible for memory deallocating itself.

<dl><dt>Type:             </dt>   <dd>  VT_BYREF | VT_UI1  </dd></dl>
<dl><dt>Default value:    </dt>   <dd>  NULL               </dd></dl>
@hideinitializer
*/
// MCMux_PSICommit              VT_BYREF | VT_UI1             NULL     Pointer to a si_commit_struct defined below
// {C8F3BEB0-8E0A-4aa8-AD7D-778E236491B9}
static const GUID MCMux_PSICommit = 
{ 0xc8f3beb0, 0x8e0a, 0x4aa8, { 0xad, 0x7d, 0x77, 0x8e, 0x23, 0x64, 0x91, 0xb9 } };

/*!
@brief Call to set discontinuity_indicator flag at the first TS packet of the generated stream. Valid for
TS profiles only.
@details Refer to 2.4.3.5 of ISO 13818-1 for more details.

<dl><dt>Type:             </dt>   <dd>  VT_UI1             </dd></dl>
<dl><dt>Available range:  </dt>   <dd>  [0, 1]             </dd></dl>
<dl><dt>Default value:    </dt>   <dd>  0                  </dd></dl>
@hideinitializer
*/
// MCMux_WriteDiscInd           VT_I1        [0,1]            0        Set discontinuity indicator in first TS packet to 1
// {3D068D14-5902-4bcf-A083-AC3F17F0B9AE}
static const GUID MCMux_WriteDiscInd = 
{ 0x3d068d14, 0x5902, 0x4bcf, { 0xa0, 0x83, 0xac, 0x3f, 0x17, 0xf0, 0xb9, 0xae } };

/*!
@brief When set to “1”, the multiplexer writes PAT / PMT only once at the beginning of the stream.
@details This option allows to save output bandwith. Please note, that in case this mode is enabled,
application should take care about delivering the stream structure and mediatypes
information to receivers.
Valid for TS only.

<dl><dt>Type:             </dt>   <dd>  VT_UI1             </dd></dl>
<dl><dt>Available range:  </dt>   <dd>  [0, 1]             </dd></dl>
<dl><dt>Default value:    </dt>   <dd>  0                  </dd></dl>
@hideinitializer
*/
// MCMuxWrite_PSI_OnceOnly      VT_I1        [0,1]            0        Write PAT/PMT only once
// {9537CDE1-E48A-4283-9E9F-50372044110A}
static const GUID MCMuxWrite_PSI_OnceOnly = 
{ 0x9537cde1, 0xe48a, 0x4283, { 0x9e, 0x9f, 0x50, 0x37, 0x20, 0x44, 0x11, 0xa } };

/*!
@brief Output samples offset in ms.

<dl><dt>Type:             </dt>   <dd>  VT_I4              </dd></dl>
<dl><dt>Default value:    </dt>   <dd>  0                  </dd></dl>
@hideinitializer
*/
// MCMux_SampleTimeDelay        VT_I4        -                0        Output samples offset in ms
// {7C5DA62A-5162-48d7-9F11-0D2203C28517}
static const GUID MCMux_SampleTimeDelay = 
{ 0x7c5da62a, 0x5162, 0x48d7, { 0x9f, 0x11, 0xd, 0x22, 0x3, 0xc2, 0x85, 0x17 } };

/*!
@brief Current video queue level, read only.

<dl><dt>Type:             </dt>   <dd>  VT_I4              </dd></dl>
<dl><dt>Read only:        </dt>   <dd>  yes                </dd></dl>
@hideinitializer
*/
// MCMux_VideoQueueFullness     VT_I4        -                -        Current video queue level, read only
// {E9B5B524-056B-4132-835C-A81DBBEDECF4}
static const GUID MCMux_VideoQueueFullness = 
{ 0xe9b5b524, 0x56b, 0x4132, { 0x83, 0x5c, 0xa8, 0x1d, 0xbb, 0xed, 0xec, 0xf4 } };

/*!
@brief Current audio queue level, read only.

<dl><dt>Type:             </dt>   <dd>  VT_I4              </dd></dl>
<dl><dt>Read only:        </dt>   <dd>  yes                </dd></dl>
@hideinitializer
*/
// MCMux_AudioQueueFullness     VT_I4        -                -        Current audio queue level, read only
// {F2B361C1-994D-4235-96B8-09922D469FCC}
static const GUID MCMux_AudioQueueFullness = 
{ 0xf2b361c1, 0x994d, 0x4235, { 0x96, 0xb8, 0x9, 0x92, 0x2d, 0x46, 0x9f, 0xcc } };

/*!
@brief Current video PTS, read only.

<dl><dt>Type:             </dt>   <dd>  VT_I8              </dd></dl>
<dl><dt>Read only:        </dt>   <dd>  yes                </dd></dl>
@hideinitializer
*/
// MCMux_VideoPTS               VT_I8        -                -        Current video PTS, read only
// {B06A4815-1058-432d-A73E-82D237721BCD}
static const GUID MCMux_VideoPTS = 
{ 0xb06a4815, 0x1058, 0x432d, { 0xa7, 0x3e, 0x82, 0xd2, 0x37, 0x72, 0x1b, 0xcd } };

/*!
@brief Current audio PTS, read only.

<dl><dt>Type:             </dt>   <dd>  VT_I8              </dd></dl>
<dl><dt>Read only:        </dt>   <dd>  yes                </dd></dl>
@hideinitializer
*/
// MCMux_AudioPTS               VT_I8        -                -        Current audio PTS, read only
// {104C579D-5B5D-4471-BA2A-1FD47732588A}
static const GUID MCMux_AudioPTS = 
{ 0x104c579d, 0x5b5d, 0x4471, { 0xba, 0x2a, 0x1f, 0xd4, 0x77, 0x32, 0x58, 0x8a } };

/*!
@brief Set to ignore the P-STD or T-STD model while muxing.

<dl><dt>Type:             </dt>   <dd>  VT_I1              </dd></dl>
<dl><dt>Available range:  </dt>   <dd>  [0, 1]             </dd></dl>
<dl><dt>Default value:    </dt>   <dd>  0                  </dd></dl>
@hideinitializer
*/
// MCMux_Ignore_STD             VT_I1        [0,1]            0        Set to ignore the P-STD or T-STD model while muxing
// {814044F9-674C-4a5e-8BE3-0692D38CDC64}
static const GUID MCMux_Ignore_STD = 
{ 0x814044f9, 0x674c, 0x4a5e, { 0x8b, 0xe3, 0x6, 0x92, 0xd3, 0x8c, 0xdc, 0x64 } };

/*!
@brief Set to ignore the incoming timestamps, the muxer generates its own.

<dl><dt>Type:             </dt>   <dd>  VT_I4              </dd></dl>
<dl><dt>Available range:  </dt>   <dd>  [0, 1]             </dd></dl>
<dl><dt>Default value:    </dt>   <dd>  0                  </dd></dl>
@hideinitializer
*/
// MCMux_IgnoreTimestamps       VT_I4        [0,1]            0        Set to ignore the incoming timestamps, the muxer generates its own
// {1464D93E-E617-471e-99D5-826F085BCCC7}
static const GUID MCMux_IgnoreTimestamps = 
{ 0x1464d93e, 0xe617, 0x471e, { 0x99, 0xd5, 0x82, 0x6f, 0x8, 0x5b, 0xcc, 0xc7 } };

/*!
@brief The number of video overflows, read only.

<dl><dt>Type:             </dt>   <dd>  VT_I4              </dd></dl>
<dl><dt>Default value:    </dt>   <dd>  0                  </dd></dl>
<dl><dt>Read only:        </dt>   <dd>  yes                </dd></dl>
@hideinitializer
*/
// MCMux_VideoUnderflows        VT_I4        -                0        The number of video overflows, read only
// {CFC049AE-02F2-409b-A9EB-9EC8DB63C416}
static const GUID MCMux_VideoUnderflows = 
{0xcfc049ae, 0x2f2, 0x409b, {0xa9, 0xeb, 0x9e, 0xc8, 0xdb, 0x63, 0xc4, 0x16}};

/*!
@brief The number of audio overflows, read only.

<dl><dt>Type:             </dt>   <dd>  VT_I4              </dd></dl>
<dl><dt>Default value:    </dt>   <dd>  0                  </dd></dl>
<dl><dt>Read only:        </dt>   <dd>  yes                </dd></dl>
@hideinitializer
*/
// MCMux_AudioUnderflows        VT_I4        -                0        The number of audio overflows, read only
// {D503FDE2-8BE6-4934-B174-3789EFF65137}
static const GUID MCMux_AudioUnderflows = 
{0xd503fde2, 0x8be6, 0x4934, {0xb1, 0x74, 0x37, 0x89, 0xef, 0xf6, 0x51, 0x37}};

//!@}

//! @name Obsolete
//!@{

/*!
@brief Compability (obsolete).

<dl><dt>Type:             </dt>   <dd>  VT_I4              </dd></dl>
<dl><dt>Available range:  </dt>   <dd>  
 - 0 - None
 - 1 - DVC
 - 2 - SVCD</dd></dl>
<dl><dt>Default value:    </dt>   <dd>  0                  </dd></dl>
@hideinitializer
*/
static const GUID MCMux_Compatibility_PS = 
{0x6165514a, 0xbf3d, 0x40b3, {0xbb, 0x2c, 0xd9, 0x7b, 0xa3, 0x44, 0x85, 0xa}};

/*!
@brief Overhead  (obsolete). Not effective in SDK 8.0 version.

<dl><dt>Type:             </dt>   <dd>  VT_I4              </dd></dl>
<dl><dt>Read only:        </dt>   <dd>  yes                </dd></dl>
@hideinitializer
*/
static const GUID MCMux_Overhead =
{0xa8f9850e, 0x68d5, 0x460c, {0xb9, 0x29, 0xfa, 0x74, 0x99, 0xbf, 0x28, 0xe8}};

/*!
@brief Sectors delay in ms (obsolete).

<dl><dt>Type:             </dt>   <dd>  VT_I8              </dd></dl>
<dl><dt>Default value:    </dt>   <dd>  0                  </dd></dl>
@hideinitializer
*/
static const GUID MCMux_SectorsDelay = 
{ 0x2bc36da2, 0xd324, 0x471a, { 0xb3, 0x5a, 0x10, 0x5f, 0xff, 0x1f, 0x66, 0xda } };

//!@}

///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
//            GUID               Value Type        Range            Default        Description
///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

//! @name Program operations
//!@{

/*!
@brief The method enumerates input pins available in the program.
@details For retrieving next stream while fetching streams of program.
Value = 0 return the first stream.
See MCMux_GetNextProgram.

<dl><dt>Type:             </dt>   <dd>  VT_UNKNOWN         </dd></dl>
<dl><dt>Available range:  </dt>   <dd>  [0, IUnk]          </dd></dl>
<dl><dt>Default value:    </dt>   <dd>  0                  </dd></dl>
@hideinitializer
*/
// MCMux_GetNextStream           VT_UNKNOWN        [0, IUnk]        0              For retrieving next stream while fetching streams of program. Value = 0 return the first stream.
// {8DB05E7F-3AE4-4738-ADB2-134175DD238C}
static const GUID MCMux_GetNextStream =
{0x8db05e7f, 0x3ae4, 0x4738, {0xad, 0xb2, 0x13, 0x41, 0x75, 0xdd, 0x23, 0x8c}};

/*!
@brief Creates a new stream in the program and returns the pointer to IModuleConfig of the
created pin. 
@details See MCMux_CreateProgram.

<dl><dt>Type:             </dt>   <dd>  VT_UNKNOWN         </dd></dl>
<dl><dt>Available range:  </dt>   <dd>  [0, IUnk]          </dd></dl>
<dl><dt>Default value:    </dt>   <dd>  0                  </dd></dl>
@hideinitializer
*/
// MCMux_CreateStream            VT_UNKNOWN        [0, IUnk]        0              Create stream.
// {C91DD135-569A-4f48-802D-B1E0BE15E1D5}
static const GUID MCMux_CreateStream = 
{0xc91dd135, 0x569a, 0x4f48, {0x80, 0x2d, 0xb1, 0xe0, 0xbe, 0x15, 0xe1, 0xd5}};

/*!
@brief Deletes the pin with the pointer to IModuleConfig that is sent in the Value parameter.
@details See MCMux_DestroyProgram.

<dl><dt>Type:             </dt>   <dd>  VT_UNKNOWN         </dd></dl>
<dl><dt>Available range:  </dt>   <dd>  [0, IUnk]          </dd></dl>
<dl><dt>Default value:    </dt>   <dd>  0                  </dd></dl>
@hideinitializer
*/
// MCMux_DestroyStream           VT_UNKNOWN        [0, IUnk]        0              Destroy stream.
// {9F420C44-CF0C-423e-AA32-BFB081F57422}
static const GUID MCMux_DestroyStream = 
{0x9f420c44, 0xcf0c, 0x423e, {0xaa, 0x32, 0xbf, 0xb0, 0x81, 0xf5, 0x74, 0x22}};

//!@}

//! @name Program properties
//!@{

/*!
@brief program_number is a 16-bit field. It specifies the program to which the program_map_PID
is applicable.
@details If the value is set to 0x0000 then the following PID reference shall be the
network PID. For all other cases, the value of this field is defined by the user. This field shall
not take any single value more than once within one version of the program association
table. The program_number may be used as a designation for a broadcast channel, for
example. (ISO/IEC 13818-1)
0 - auto compute

<dl><dt>Type:             </dt>   <dd>  VT_I4              </dd></dl>
<dl><dt>Available range:  </dt>   <dd>  [0, 0xFFFF]        </dd></dl>
<dl><dt>Default value:    </dt>   <dd>  1                  </dd></dl>
@hideinitializer
*/
// MCMux_ProgramNumber           VT_I4             [0,0xFFFF]       1              0 - auto compute
// {BFB26B95-AC4A-4d48-8F2F-7DF8D03C673F}
static const GUID MCMux_ProgramNumber =
{0xbfb26b95, 0xac4a, 0x4d48, {0x8f, 0x2f, 0x7d, 0xf8, 0xd0, 0x3c, 0x67, 0x3f}};

/*!
@brief program_map_PID is a 13-bit field specifying the PID of the Transport Stream packets,
which will contain the program_map_section applicable for the program as specified by the
program_number.
@details No program_number shall have more than one program_map_PID
assignment. The value of the program_map_PID is defined by the user, but shall take only
the values that are specified in table 2-4 on page 23. (ISO/IEC 13818-1 document).
0 - auto compute

<dl><dt>Type:             </dt>   <dd>  VT_I4              </dd></dl>
<dl><dt>Available range:  </dt>   <dd>  [0, 0x1FFF]        </dd></dl>
<dl><dt>Default value:    </dt>   <dd>  0                  </dd></dl>
@hideinitializer
*/
// MCMux_ProgramID               VT_I4             [0,0x1FFF]       0              0 - auto compute
// {F21C447B-3870-4ff1-B97E-6154067FCCE8}
static const GUID MCMux_ProgramID =
{0xf21c447b, 0x3870, 0x4ff1, {0xb9, 0x7e, 0x61, 0x54, 0x6, 0x7f, 0xcc, 0xe8}};

/*!
@brief This parameter specifies the PID of elementary stream that carries the Program Clock
Reference (PCR) timestamps for the program.
@details The PCR PID can be chosen among PIDs of
streams belonged to the program. This parameter is effective only for Transport Stream.
0 = auto compute

<dl><dt>Type:             </dt>   <dd>  VT_I4              </dd></dl>
<dl><dt>Available range:  </dt>   <dd>  [0, 0x1FFF]        </dd></dl>
<dl><dt>Default value:    </dt>   <dd>  0                  </dd></dl>
@hideinitializer
*/
// MCMux_PCR_PID                 VT_I4             [0,0x1FFF]       0              PCR PID for this program, 0 = auto compute
// {c54afa11-3172-42a6-b92f-ceac92ab3d12}
static const GUID MCMux_PCR_PID =
{0xc54afa11, 0x3172, 0x42a6, {0xb9, 0x2f, 0xce, 0xac, 0x92, 0xab, 0x3d, 0x12}};

/*!
@brief This option is only available for Transport Stream. This parameter allows specifying the
independent PID at which PCR will be carried.
@details Only PCR timestamps and no payload are carried by Transport Stream Packets with that PID.
PCR PID which is different than video / audio PIDs.
Could be also used to specify the shared PID among the programs.
The “0” value means that the parameter is not used.

<dl><dt>Type:             </dt>   <dd>  VT_I4              </dd></dl>
<dl><dt>Available range:  </dt>   <dd>  [0, 0x1FFF]        </dd></dl>
<dl><dt>Default value:    </dt>   <dd>  0                  </dd></dl>
@hideinitializer
*/
// MCMux_UserDef_PCR_PID         VT_I4             [0,0x1FFF]       0              PCR PID which is different than video / audio PIDs
// {6B914A19-555D-42c2-8638-3EF76D34436A}                                          Could be also used to specify the shared PID among the programs
static const GUID MCMux_UserDef_PCR_PID = 
{ 0x6b914a19, 0x555d, 0x42c2, {0x86, 0x38, 0x3e, 0xf7, 0x6d, 0x34, 0x43, 0x6a}};

/*!
@brief ATSC virtual source id.

<dl><dt>Type:             </dt>   <dd>  VT_UI2             </dd></dl>
<dl><dt>Available range:  </dt>   <dd>  [0, 0xFFFF]        </dd></dl>
<dl><dt>Default value:    </dt>   <dd>  0                  </dd></dl>
@hideinitializer
*/
// MCMux_ATSC_VirtualSourceId    VT_UI2            [0,0xFFFF]       0              ATSC virtual source id
// {76F18422-7F00-4505-A7BA-E8ADAC96F50E}
static const GUID MCMux_ATSC_VirtualSourceId = 
{ 0x76f18422, 0x7f00, 0x4505, { 0xa7, 0xba, 0xe8, 0xad, 0xac, 0x96, 0xf5, 0xe } };

/*!
@brief ATSC modulation mode.

<dl><dt>Type:             </dt>   <dd>  VT_I2              </dd></dl>
<dl><dt>Available range:  </dt>   <dd>  
 - 1 - Analog
 - 2 - SCTE-1
 - 3 - SCTE-2
 - 4 - 8 VSB
 - 5 - 16 VSB
</dd></dl>
<dl><dt>Default value:    </dt>   <dd>  0                  </dd></dl>
@hideinitializer
*/
// MCMux_ATSC_ModulationMode     VT_I1             enum             0              ATSC modulation mode
// {573CC8BB-63D5-4f43-8920-893E49888BD7}
static const GUID MCMux_ATSC_ModulationMode = 
{ 0x573cc8bb, 0x63d5, 0x4f43, { 0x89, 0x20, 0x89, 0x3e, 0x49, 0x88, 0x8b, 0xd7 } };

/*!
@brief Number of extra ATSC EIT tables to be used

<dl><dt>Type:             </dt>   <dd>  VT_UI2             </dd></dl>
<dl><dt>Available range:  </dt>   <dd>  [0, 124]           </dd></dl>
<dl><dt>Default value:    </dt>   <dd>  0                  </dd></dl>
@hideinitializer
*/
// MCMux_ATSC_NumOfExtraEITs       VT_UI2            [0,124]           0              Extra ATSC EIT tables count
// {A2F7AA40-DEB0-417D-943D-538BA425CF2D}
static const GUID MCMux_ATSC_NumOfExtraEITs = 
{ 0xa2f7aa40, 0xdeb0, 0x417d, { 0x94, 0x3d, 0x53, 0x8b, 0xa4, 0x25, 0xcf, 0x2d } };

//!@}

/*!
@brief ATSC major channel number.

<dl><dt>Type:             </dt>   <dd>  VT_UI1             </dd></dl>
<dl><dt>Available range:  </dt>   <dd>  [1, 99]            </dd></dl>
<dl><dt>Default value:    </dt>   <dd>  1                  </dd></dl>
@hideinitializer
*/
// MCMux_ATSC_MajorChannel       VT_UI1            [1,99]           1              ATSC major channel number
// {08743F59-8792-429e-98A9-E7C1F436FBE3}
static const GUID MCMux_ATSC_MajorChannel = 
{ 0x8743f59, 0x8792, 0x429e, { 0x98, 0xa9, 0xe7, 0xc1, 0xf4, 0x36, 0xfb, 0xe3 } };

/*!
@brief ATSC service type.

<dl><dt>Type:             </dt>   <dd>  VT_I1              </dd></dl>
<dl><dt>Available range:  </dt>   <dd>
 - 1 - Analog
 - 2 - Digital
 - 3 - Audio
 - 4 - Data Only
  </dd></dl>
<dl><dt>Default value:    </dt>   <dd>  0                  </dd></dl>
@hideinitializer
*/
// MCMux_ATSC_ServiceType        VT_I1             enum             0              ATSC service type
// {B1753796-12A6-4259-B25A-90B0A54BE6D9}
static const GUID MCMux_ATSC_ServiceType = 
{ 0xb1753796, 0x12a6, 0x4259, { 0xb2, 0x5a, 0x90, 0xb0, 0xa5, 0x4b, 0xe6, 0xd9 } };

/*!
@brief ATSC minor channel number.

<dl><dt>Type:             </dt>   <dd>  VT_UI1             </dd></dl>
<dl><dt>Available range:  </dt>   <dd>  [1, 99]            </dd></dl>
<dl><dt>Default value:    </dt>   <dd>  1                  </dd></dl>
@hideinitializer
*/
// MCMux_ATSC_MinorChannel       VT_UI1            [1,99]           1              ATSC minor channel number
// {2AFF0364-66BA-4cb2-B4DC-0DEDC9734FB5}
static const GUID MCMux_ATSC_MinorChannel = 
{ 0x2aff0364, 0x66ba, 0x4cb2, { 0xb4, 0xdc, 0xd, 0xed, 0xc9, 0x73, 0x4f, 0xb5 } };

//!@}

/*!
@brief Number of extra DVB 'actual TS, event schedule information' EIT tables to be added

<dl><dt>Type:             </dt>   <dd>  VT_UI1             </dd></dl>
<dl><dt>Available range:  </dt>   <dd>  [0, 16]            </dd></dl>
<dl><dt>Default value:    </dt>   <dd>  0                  </dd></dl>
@hideinitializer
*/
// MCMux_DVB_NumOfExtraEITs       VT_UI1            [0,16]           0              Extra DVB EIT tables count
// {C3E963A7-A730-40E9-8B7B-59CEFF969BE3}
static const GUID MCMux_DVB_NumOfExtraEITs = 
{ 0xc3e963a7, 0xa730, 0x40e9, { 0x8b, 0x7b, 0x59, 0xce, 0xff, 0x96, 0x9b, 0xe3 } };

//!@}


///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
//            GUID                 Value Type        Range             Default      Description
///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

//! @name Stream operations
//!@{

/*!
@brief This parameter is accessible only through the SetValue method. Transfers the stream into
the program with a pointer to IModuleConfig that is sent in the Value parameter.

<dl><dt>Type:             </dt>   <dd>  VT_UNKNOWN         </dd></dl>
<dl><dt>Available range:  </dt>   <dd>  [0, IUnk]          </dd></dl>
<dl><dt>Default value:    </dt>   <dd>  0                  </dd></dl>
@hideinitializer
*/
// MCMux_MoveStreamTo              VT_UNKNOWN        [0,IUnk]          0            Move stream to another program
// {F3A8774E-58F3-44e5-940D-842155353BAB}
static const GUID MCMux_MoveStreamTo =
{0xf3a8774e, 0x58f3, 0x44e5, {0x94, 0xd, 0x84, 0x21, 0x55, 0x35, 0x3b, 0xab}};

//!@}

//! @name Stream properties
//!@{

/*!
@brief The stream type is automatically established at the connection of the input pin.

<dl><dt>Type:             </dt>   <dd>  VT_I4              </dd></dl>
<dl><dt>Available range:  </dt>   <dd>  
Available Values:
 - 0 – PT_Unknown
 - 1 – PT_MPEG2V
 - 2 – PT_MPEG2A
 - 3 – PT_AC3
 - 7 – PT_MPEG1A
 - 8 – PT_MPEG1V
 - 10 – PT_H264
 - 11 – PT_AAC
 - 13 – PT_PCM
 - 15 – PT_DVDSUB
 - 17 – PT_VC1
 - 21 – PT_PES
 - 32 – PT_DVDSUB_PES
 - 55 – PT_PRIVATE
  </dd></dl>
<dl><dt>Default value:    </dt>   <dd>  PT_Unknown         </dd></dl>
@hideinitializer
*/
// MCMux_StreamType                VT_I4             enum              0            Input stream type, one of the PinType enums below
// {1811ABAA-F568-4016-A728-0A9B8E7799AE}
static const GUID MCMux_StreamType = 
{0x1811abaa, 0xf568, 0x4016, {0xa7, 0x28, 0xa, 0x9b, 0x8e, 0x77, 0x99, 0xae}};

/*!
@brief Treat a private stream as this type, currently only PT_PRIVATE or PT_DVB_TELETEXT.

<dl><dt>Type:             </dt>   <dd>  VT_I4              </dd></dl>
<dl><dt>Available range:  </dt>   <dd>  
Available Values:
 - 55 - PT_PRIVATE
 - 35 - PT_DVB_TELETEXT
  </dd></dl>
<dl><dt>Default value:    </dt>   <dd>  PT_PRIVATE         </dd></dl>
@hideinitializer
*/
// MCMux_PrivateType                VT_I4             enum              PT_PRIVATE  Treat a private stream as this type, currently only PT_PRIVATE or PT_DVB_TELETEXT
// {05F944C0-E7C6-442F-B72E-3F6BA41D9951}
static const GUID MCMux_PrivateType = 
{ 0x5f944c0, 0xe7c6, 0x442f, { 0xb7, 0x2e, 0x3f, 0x6b, 0xa4, 0x1d, 0x99, 0x51 } };

/*!
@brief Establishes the maximum possible size of the PES packet.
@details A value of 0 signifies the restriction by default
when the size of the PES packet is defined by the PES_packet_length
field (ISO/IEC 13818-1).

<dl><dt>Type:             </dt>   <dd>  VT_I4              </dd></dl>
<dl><dt>Available range:  </dt>   <dd>  [0, 0xFFFF]        </dd></dl>
<dl><dt>Default value:    </dt>   <dd>  0                  </dd></dl>
@hideinitializer
*/
// MCMux_PESPacketSize             VT_I4             [0,0xFFFF]        0            Size of PES packet in stream. 0 - variable length.
// {769E9811-5D67-472a-8846-95B355A606ED}
static const GUID MCMux_PESPacketSize =
{0x769e9811, 0x5d67, 0x472a, {0x88, 0x46, 0x95, 0xb3, 0x55, 0xa6, 0x6, 0xed}};

/*!
@brief This parameter enables/disables the small PES packets padding, if
MCMux_PESPacketSize > 0. 
@details The small PES packets are padded till the specified size.

<dl><dt>Type:             </dt>   <dd>  VT_I4              </dd></dl>
<dl><dt>Available range:  </dt>   <dd>  [0, 1]             </dd></dl>
<dl><dt>Default value:    </dt>   <dd>  0                  </dd></dl>
@hideinitializer
*/
// MCMux_PaddingOn                 VT_I4             [0,1]             0            Pad input samples if its size is less then "PES Packet Size" and "PES Packet Size" > 0
// {A8AC9943-DE6F-4c8a-881C-B7BB52353102}
static const GUID MCMux_PaddingOn = 
{0xa8ac9943, 0xde6f, 0x4c8a, {0x88, 0x1c, 0xb7, 0xbb, 0x52, 0x35, 0x31, 0x2}};

/*!
@brief This parameter specifies the input buffer size. It is corrected automatically when pin is active.
@details A value of 4MB is default.

<dl><dt>Type:             </dt>   <dd>  VT_I4              </dd></dl>
<dl><dt>Available range:  </dt>   <dd>  [10K, 100MB]       </dd></dl>
<dl><dt>Default value:    </dt>   <dd>  4MB                </dd></dl>
@hideinitializer
*/
// MCMux_InputBufSize              VT_I4             [10K,100MB]       4MB          The size of input buffer in bytes. Default values sets automatically depending on media type.
// {A4FE0D19-6AB8-4367-8124-07D45B1384DA}
static const GUID MCMux_InputBufSize = 
{0xa4fe0d19, 0x6ab8, 0x4367, {0x81, 0x24, 0x7, 0xd4, 0x5b, 0x13, 0x84, 0xda}};

/*!
@brief The specified value (in ms) will be added to all PTS / DTS in the chosen stream.
@details It is used to synchronize
audio and video (Lip Sync) when the streams from capture devices are multiplexed.

<dl><dt>Type:             </dt>   <dd>  VT_I4            </dd></dl>
<dl><dt>Available range:  </dt>   <dd>  [0, 0xFFFFFFFF]  </dd></dl>
<dl><dt>Default value:    </dt>   <dd>  0                </dd></dl>
@hideinitializer
*/
// MCMux_InitialShift              VT_I4             -                 0            The specified value in ms will be added to all PTS / DTS in chosen stream.
// {3A34CBF2-E6C4-4c84-8541-70C6961C87AD}
static const GUID MCMux_InitialShift = 
{0x3a34cbf2, 0xe6c4, 0x4c84, {0x85, 0x41, 0x70, 0xc6, 0x96, 0x1c, 0x87, 0xad}};

/*!
@brief Only for Transport Stream. The PID is a 13-bit field indicating the type of data stored in the
packet payload. 
@details A PID value of 0x0000 is reserved for the Program Association Table (table
2-26 on page 47 ISO/IEC 13818-1). A PID value of 0x0001 is reserved for the Conditional
Access Table (table 2-28 on page 49 ISO/IEC 13818-1). PID values of 0x0002-0x000F are
reserved. A PID value of 0x1FFF is reserved for null packets. (see ISO/IEC 13818-1).
0 - auto select.

<dl><dt>Type:             </dt>   <dd>  VT_I4            </dd></dl>
<dl><dt>Available range:  </dt>   <dd>  [0, 0x1FFF]      </dd></dl>
<dl><dt>Default value:    </dt>   <dd>  0                </dd></dl>
@hideinitializer
*/
// MCMux_StreamID                  VT_I4             [0,0x1FFF]        0            PID of stream, 0 - auto select
// {4F382B24-2E36-43d7-AFF3-04047B0C2F87}
static const GUID MCMux_StreamID = 
{0x4f382b24, 0x2e36, 0x43d7, {0xaf, 0xf3, 0x4, 0x4, 0x7b, 0xc, 0x2f, 0x87}};

/*!
@brief PES ID of stream.
@details In Program Streams, the stream_id specifies the type and number of the elementary stream
as defined by the stream_id table 2-19 (ISO/IEC 13818-1). In Transport Streams, the
stream_id may be set to any valid value that correctly describes the elementary stream type
as defined in table 2-19 (ISO/IEC 13818-1). In Transport Streams, the elementary stream
type is defined in the Program Specific Information as specified in 2.4.4 on page 44 (ISO/IEC
13818-1).
0 - auto select

<dl><dt>Type:             </dt>   <dd>  VT_I4            </dd></dl>
<dl><dt>Available range:  </dt>   <dd>  [0, 0xFF]        </dd></dl>
<dl><dt>Default value:    </dt>   <dd>  0                </dd></dl>
@hideinitializer
*/
// MCMux_StreamPESID               VT_I4             [0,0xFF]          0            PES ID of stream, 0 - auto select
// {474C78F4-2DC9-4ce2-9CA9-161E0C93B988}
static const GUID MCMux_StreamPESID = 
{0x474c78f4, 0x2dc9, 0x4ce2, {0x9c, 0xa9, 0x16, 0x1e, 0xc, 0x93, 0xb9, 0x88}};

/*!
@brief Stream Sub ID.
@details Only for Program Streams. The value in range from 0xA0 to 0xA7 (for LPCM audio) or from
0x80 to 0x87 (for AC-3 audio) that is set automatically depending on the audio stream
number in program.

<dl><dt>Type:             </dt>   <dd>  VT_I4            </dd></dl>
<dl><dt>Available range:  </dt>   <dd>  [0, 0xFF]        </dd></dl>
<dl><dt>Default value:    </dt>   <dd>  0                </dd></dl>
<dl><dt>Read only:        </dt>   <dd>  yes              </dd></dl>
@hideinitializer
*/
// MCMux_SubID_num                 VT_I4             [0,0xFF]          0            For program streams, types PCM & AC3 only
// {5CAED249-7594-410e-8E5C-2FA5D973BE6C}
static const GUID MCMux_SubID_num =  
{0x5caed249, 0x7594, 0x410e, {0x8e, 0x5c, 0x2f, 0xa5, 0xd9, 0x73, 0xbe, 0x6c}};

/*!
@brief Announced bit rate for stream, read only.
@details This parameter indicates the stream bitrate retrieved from the header information (preferably)
or from the pin connection information. Read only.

<dl><dt>Type:             </dt>   <dd>  VT_I4            </dd></dl>
<dl><dt>Default value:    </dt>   <dd>  0                </dd></dl>
<dl><dt>Read only:        </dt>   <dd>  yes              </dd></dl>
@hideinitializer
*/
// MCMux_StreamBitrateAnnounced    VT_I4             -                 0            Announced bit rate for stream, read only
// {D2BF1AF3-2AA6-47a9-B983-B528E042AA17}
static const GUID MCMux_StreamBitrateAnnounced = 
{0xd2bf1af3, 0x2aa6, 0x47a9, {0xb9, 0x83, 0xb5, 0x28, 0xe0, 0x42, 0xaa, 0x17}};

/*!
@brief Real bit rate for stream, read only.
@details This parameter indicates the stream bitrate calculated from the real stream data amount and
PTS values. Read only.

<dl><dt>Type:             </dt>   <dd>  VT_I4            </dd></dl>
<dl><dt>Default value:    </dt>   <dd>  0                </dd></dl>
<dl><dt>Read only:        </dt>   <dd>  yes              </dd></dl>
@hideinitializer
*/
// MCMux_StreamBitrateReal         VT_I4             -                 0            Real bit rate for stream, read only
// {D59D182B-A954-4759-81E7-7311CC58271B}
static const GUID MCMux_StreamBitrateReal = 
{0xd59d182b, 0xa954, 0x4759, {0x81, 0xe7, 0x73, 0x11, 0xcc, 0x58, 0x27, 0x1b}};

/*!
@brief Correct bit rate for stream specified by user.
@details This parameter allows the user to specify the stream bitrate, if the value for
MCMux_StreamBitrateAnnounced is not correct.

<dl><dt>Type:             </dt>   <dd>  VT_I4            </dd></dl>
<dl><dt>Available range:  </dt>   <dd>  [0, 0xFFFFFFFF]  </dd></dl>
<dl><dt>Default value:    </dt>   <dd>  0                </dd></dl>
@hideinitializer
*/
// MCMux_StreamBitrateCorrect      VT_I4             -                 0            Correct bit rate for stream specified by user. Use it if Announced bitrate is incorrect
// {2D7E6A07-0C99-47ca-99E3-E83FCA7CA058}
static const GUID MCMux_StreamBitrateCorrect = 
{0x2d7e6a07, 0xc99, 0x47ca, {0x99, 0xe3, 0xe8, 0x3f, 0xca, 0x7c, 0xa0, 0x58}};

/*!
@brief Only for video streams. The size of EB buffer that is used in the T-STD or P-STD models.

<dl><dt>Type:             </dt>   <dd>  VT_I4            </dd></dl>
<dl><dt>Available range:  </dt>   <dd>  [0, 0xFFFFFFFF]  </dd></dl>
<dl><dt>Default value:    </dt>   <dd>  0                </dd></dl>
@hideinitializer
*/
// MCMux_EB_SizeCorrect            VT_I4             -                 0            For video only. Elementary Buffer size specified by user. 0 - auto computed
// {95AC7C07-8777-4294-8F7C-0E59F84DE757}
static const GUID MCMux_EB_SizeCorrect =
{0x95ac7c07, 0x8777, 0x4294, {0x8f, 0x7c, 0xe, 0x59, 0xf8, 0x4d, 0xe7, 0x57}};

/*!
@brief Anounced audio frequency (Hz), read only.
@details This parameter indicates the sampling frequency (Hz) of audio stream. Read only.

<dl><dt>Type:             </dt>   <dd>  VT_I4            </dd></dl>
<dl><dt>Default value:    </dt>   <dd>  0                </dd></dl>
<dl><dt>Read only:        </dt>   <dd>  yes              </dd></dl>
@hideinitializer
*/
// MCMux_AudioFrequency            VT_I4             -                 0            Anounced audio frequency (Hz), read only
// {9A49DB34-8EDB-4358-9C94-CCE447954EF8}
static const GUID MCMux_AudioFrequency =
{0x9a49db34, 0x8edb, 0x4358, {0x9c, 0x94, 0xcc, 0xe4, 0x47, 0x95, 0x4e, 0xf8}};

/*!
@brief Stream is shared among programs.

<dl><dt>Type:             </dt>   <dd>  VT_BOOL          </dd></dl>
<dl><dt>Available range:  </dt>   <dd>  [0, 1]           </dd></dl>
<dl><dt>Default value:    </dt>   <dd>  0                </dd></dl>
@hideinitializer
*/
// MCMux_Shared_Stream             VT_BOOL           [0,1]             0            Stream is shared among programs
// {5550754B-9058-4b5c-90A8-825EC6038079}
static const GUID MCMux_Shared_Stream = 
{ 0x5550754b, 0x9058, 0x4b5c, { 0x90, 0xa8, 0x82, 0x5e, 0xc6, 0x3, 0x80, 0x79 } };

/*!
@brief Enable optimized AU packing.

<dl><dt>Type:             </dt>   <dd>  VT_BOOL          </dd></dl>
<dl><dt>Available range:  </dt>   <dd>  [0, 1]           </dd></dl>
<dl><dt>Default value:    </dt>   <dd>  0                </dd></dl>
@hideinitializer
*/
// MCMux_OptPacking                VT_BOOL           [0,1]             0            Enable optimized AU packing
// {BD18B8AC-7A1F-423a-88DD-5EDAF304536A}
static const GUID MCMux_OptPacking = 
{ 0xbd18b8ac, 0x7a1f, 0x423a, { 0x88, 0xdd, 0x5e, 0xda, 0xf3, 0x4, 0x53, 0x6a } };

/*!
@brief Enable enhanced parsing.

<dl><dt>Type:             </dt>   <dd>  VT_BOOL          </dd></dl>
<dl><dt>Available range:  </dt>   <dd>  [0,1]            </dd></dl>
<dl><dt>Default value:    </dt>   <dd>  0                </dd></dl>
@hideinitializer
*/
// MCMux_EnhancedParsing           VT_BOOL           [0,1]             0            Enable enhanced parsing
// {019AF90D-F080-4e60-B622-A7D67A619D65}
static const GUID MCMux_EnhancedParsing = 
{ 0x19af90d, 0xf080, 0x4e60, { 0xb6, 0x22, 0xa7, 0xd6, 0x7a, 0x61, 0x9d, 0x65 } };

/*!
@brief Maximum time difference in ms between PCR and DTS.
@details 0 - auto computed

<dl><dt>Type:             </dt>   <dd>  VT_I4           </dd></dl>
<dl><dt>Available range:  </dt>   <dd>  [0, 10000]      </dd></dl>
<dl><dt>Default value:    </dt>   <dd>  0              s </dd></dl>
@hideinitializer
*/
// MCMux_MaxStreamDelay            VT_I4             [0,10000]         0            Maximum time difference in ms between PCR and DTS, 0 - auto computed
// {54118D13-0F27-4c66-B342-CF507047CA99}
static const GUID MCMux_MaxStreamDelay = 
{ 0x54118d13, 0xf27, 0x4c66, { 0xb3, 0x42, 0xcf, 0x50, 0x70, 0x47, 0xca, 0x99 } };

/*!
@brief Maximum number of AU's that can be queued.
@details 0 - auto computed

<dl><dt>Type:             </dt>   <dd>  VT_I4           </dd></dl>
<dl><dt>Available range:  </dt>   <dd>  [0, 10000]      </dd></dl>
<dl><dt>Default value:    </dt>   <dd>  0               </dd></dl>
@hideinitializer
*/
// MCMux_AUQueueSize               VT_I4             [0,10000]         0            Maximum number of AU's that can be queued, 0 - auto computed
// {8FA03E8A-86E0-4203-AD5C-1D5AA9FC2982}
static const GUID MCMux_AUQueueSize = 
{ 0x8fa03e8a, 0x86e0, 0x4203, { 0xad, 0x5c, 0x1d, 0x5a, 0xa9, 0xfc, 0x29, 0x82 } };

/*!
@brief Stream overflow timeout in seconds
@details -1 = do not block, return an error, 0 = use computed value, else the number of seconds to wait.

<dl><dt>Type:             </dt>   <dd>  VT_I4            </dd></dl>
<dl><dt>Available range:  </dt>   <dd>  [-1, 0x7FFFFFFF]  </dd></dl>
<dl><dt>Default value:    </dt>   <dd>  0                </dd></dl>
@hideinitializer
*/
// MCMux_OverflowTimeout           VT_I4             [-1,0x7FFFFFFF]   0            Stream overflow timeout in seconds
// {03D35F0E-488F-4a46-BB50-913D9433E57E}                                           -1 = do not block, return an error, 0 = use computed value, else the number of seconds to wait
static const GUID MCMux_OverflowTimeout = 
{ 0x3d35f0e, 0x488f, 0x4a46, { 0xbb, 0x50, 0x91, 0x3d, 0x94, 0x33, 0xe5, 0x7e } };

//!@}

//! @name Obsolete
//!@{

/*!
@brief This parameter indicates the video stream frame rate retrieved from the pin connection
information (obsolete). Read only.

<dl><dt>Type:             </dt>   <dd>  VT_I4            </dd></dl>
<dl><dt>Read only:        </dt>   <dd>  yes              </dd></dl>
@hideinitializer
*/
static const GUID MCMux_FrameRateAnnounced = 
{0x2b50384b, 0x3c0, 0x4576, {0xb2, 0x8a, 0x85, 0xb0, 0xf9, 0x6a, 0x9d, 0xe2}};

/*!
@brief Current Pin PTS. Not effective in SDK 8.0 (obsolete).

<dl><dt>Type:             </dt>   <dd>  VT_I8            </dd></dl>
<dl><dt>Read only:        </dt>   <dd>  yes              </dd></dl>
@hideinitializer
*/
static const GUID MCMux_StreamTime = 
{0xe808c80b, 0x4298, 0x4dea, {0xb6, 0x4c, 0x48, 0x84, 0xbb, 0xdf, 0xfd, 0x36}};

/*!
@brief ES Info Length (obsolete).

<dl><dt>Type:             </dt>   <dd>  VT_I4            </dd></dl>
<dl><dt>Default value:    </dt>   <dd>  0                </dd></dl>
@hideinitializer
*/
static const GUID MCMux_ES_InfoLength = 
{ 0xba0b67a0, 0x6d9a, 0x4af8, { 0xac, 0xb3, 0x3a, 0x18, 0x47, 0x68, 0x1f, 0xad } };

/*!
@brief Pointer to ES info (obsolete).

<dl><dt>Type:             </dt>   <dd>  VT_PTR           </dd></dl>
<dl><dt>Default value:    </dt>   <dd>  NULL             </dd></dl>
@hideinitializer
*/
static const GUID MCMux_ES_Info = 
{ 0xc8f37a44, 0x1131, 0x4d21, { 0xae, 0xdc, 0x12, 0x5c, 0x9e, 0x83, 0x4b, 0x47 } };

//!@} Obsolete

///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
// Enums
///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

#include "mctypes.h"

/*!@brief namespace for MPEG-2 Muxer specific enums.
*/
namespace MCMuxer
{
    /*!@brief Available output stream types */
    typedef enum OutputStreamType
    {
        RESULT_STREAM_PROGRAM      = 1,  //!< MPEG-2 Program Stream (ISO/IEC 13818-1)
        RESULT_STREAM_TRANSPORT    = 2,  //!< MPEG-2 Transport Stream (ISO/IEC 13818-1)

        RESULT_STREAM_MPEG1_SYSTEM = 3,  //!< MPEG1 System
        RESULT_STREAM_VCD          = 4,  //!< VCD
        RESULT_STREAM_SVCD         = 6,  //!< SVCD
        RESULT_STREAM_DVD          = 7,  //!< DVD
        RESULT_STREAM_DVD_MPEG1    = 8,  //!< DVD_MPEG
        RESULT_STREAM_DVB          = 11, //!< DVB
        RESULT_STREAM_MMV          = 12, //!< MMV
        RESULT_STREAM_ATSC         = 14, //!< terrestrial ATSC
        RESULT_STREAM_ATSC_C       = 15, //!< ATSC cable
        RESULT_STREAM_HDV_HD1      = 16, //!< HDV_HD1
        RESULT_STREAM_HDV_HD2      = 17, //!< HDV_HD2
        RESULT_STREAM_AVCHD        = 18, //!< AVCHD
        RESULT_STREAM_HDMV         = 19, //!< BluRay
        RESULT_STREAM_CABLELABS    = 20, //!< CABLELABS
        RESULT_STREAM_1SEG         = 21, //!< SegOne
        RESULT_STREAM_ATT          = 22, //!< ATT Transport Stream
        RESULT_STREAM_DTV          = 23  //!< DTV, Networked Digital Television
    } OutputStreamType_t;

    /*!@brief Available pin types */
    typedef enum PinType
    {
        PT_Unknown       = 0,  //!< Free
        PT_MPEG2V        = 1,  //!< MPEG-2 Video
        PT_MPEG2A        = 2,  //!< MPEG-2 Audio
        PT_AC3           = 3,  //!< AC3
        PT_DIV4          = 5,  //!< MPEG-4 v4
        PT_DIV5          = 6,  //!< MPEG-4 v5
        PT_MPEG1A        = 7,  //!< MPEG-1 Audio
        PT_MPEG1V        = 8,  //!< MPEG-1 Video

        PT_HEVC		     = 9,  //!< HEVC Video
        PT_H264          = 10, //!< H264 Video
        PT_AAC           = 11, //!< AAC

        PT_PCM           = 13, //!< PCM
        PT_MPEG4         = 14, //!< MPEG-4
        PT_DVDSUB        = 15, //!< DVD Subtitles
        PT_VC1           = 17, //!< VC-1
        PT_LATM_AAC      = 18, //!< LATM AAC
        PT_PES           = 21, //!< PES Data
        PT_LPCM          = 25, //!< DVD LPCM
        PT_HDMV_PCM      = 26, //!< HDMV LPCM
        PT_AES3_302M_PCM = 27, //!< AES3-302M LPCM
        PT_DVB_TELETEXT  = 35, //!< DVB Teletext
        PT_DVB_SUB       = 36, //!< DVB Subtitles
        PT_PRIVATE       = 55, //!< Private Data
    } PinType;
}

#ifdef __GNUC__
#pragma pack(push,1)
#else
#pragma pack(push)
#pragma pack(1)
#endif

/*!@brief namespace for MPEG-2 Muxer specific enums and structures.
*/
namespace MCMuxerEx_
{
    /*!
      @brief This structure is used to commit any SI table changes made since the last commit.
      @details If all SI table changes are to start at the same time, they can all be done
      and then applied with a single commit call.
     */
    struct si_commit_struct
    {
        int64_t target_time_PCR;        //!< the PCR time at which SI config should be applied. In 27 MHz units.

                                        //!< If this field is set to 0 the new SI data is applied immediately.

        uint8_t reserved[128];          //!< reserved for future use
    };

    /*! @brief Available loop levels */
    typedef enum 
    {
        eOuter_descriptor_loop = 0,       //!< descriptor loop of a PSI section
        eInner_descriptor_loop = 1        //!< descriptor loop of entries
    } loop_level_enum;

    /*!
      @brief SI descriptor to be placed in a table or entry
      @details This structure is used to load descriptors into the SI tables for Transport Stream profiles.
               The user is responsible for the syntax of the descriptor, including the descriptor_tag and
               descriptor_length.
    */
    struct si_descriptor_struct
    {
        int32_t target_table_id;          //!< target table id for the descriptor
        int32_t target_table_id_ext;      //!< target table id extension, set to -1 if not required

                                          //!< It's excessive for such tables as PAT, since table_id = 0x0
                                          //!< is enough for distinguishing of this table;
                                          //!< But if many tables can exist with the same table_id (PMT for ex.),
                                          //!< we need to distinguish between tables using target_table_id_ext. 
                                          //!< Example: for NIT the target_table_id_ext represents network_id. 
                                          //!< For PMT specify the program_number as the target_table_id_ext.

        int32_t target_table_type;        //!< also target table type. Set to -1 if it's not required

        loop_level_enum target_loop;      //!< inner loop (1) / outer loop (0). Use loop_level_enum.

        //! @name only used for inner loop
        //!@{
        int32_t target_entry_id;          //!< target entry id
        int32_t target_entry_id_ext;      //!< target entry id extension, set to -1 if not required

                                          //!< it's excessive for most entries, such as PMT entry. But
                                          //!< NIT entry is identified by two id's - transport_id and orig_network_id

        //!@}
        
        uint8_t descriptor_tag;           //!< the tag of the descriptor
        uint8_t descriptor_length;        //!< the number of bytes pointed to by the pbData pointer
        uint8_t* pbData;                  //!< pointer to the data

                                          //!< It is copied to the muxer's internal memory
                                          //!< and can be freed after the load descriptor call

        uint8_t replace_existing;         //!< replace any existing descriptor in the entry with the same descriptor_tag

        uint8_t reserved[32];             //!< reserved for future use
    };

    /*! @brief Complete SI entry to be placed in a table.
        @details This structure is used to load entries into the SI tables for Transport Stream profiles.
                 The user is responsible for the syntax of the entry.
    */
    struct si_entry_struct
    {
        int32_t target_table_id;          //!< target table to which the entry should be loaded.
        int32_t target_table_id_ext;      //!< target table id extension. Set to -1 if it's not required
        int32_t target_table_type;        //!< target table type. Set to -1 if it's not required
        
        int32_t entry_length;             //!< the number of bytes pointed to by the pbData pointer
        uint8_t* pbData;                  //!< pointer to the data.

                                          //!< It is copied to the muxer's internal memory
                                          //!< and can be freed after the load entry call

        int32_t target_entry_id;          //!< target entry id
        int32_t target_entry_id_ext;      //!< target entry id extension

        uint8_t replace_existing;         //!< replace any existing entry with the same target_entry_id and target_entry_id_ext

        uint8_t reserved[32];             //!< reserved for future use
    };

    /*! @brief Ccomplete SI section to be placed in a table.
        @details This structure is used to load sections into the SI tables for Transport Stream profiles.
                 The user is responsible for the syntax of the section.
    */
    struct si_section_struct
    {
        int32_t target_table_id;          //!< target table of the section.
        int32_t target_table_id_ext;      //!< target table id extension. Set to -1 if it's not required
        int32_t target_table_type;        //!< target table type. Set to -1 if it's not required

        uint32_t section_length;          //!< the number of bytes pointed to by the pbData pointer
        uint8_t* pbData;                  //!< pointer to the data

                                          //!< It is copied to the muxer's internal memory
                                          //!< and can be freed after the load section call 

        uint8_t reserved[32];             //!< reserved for future use
    };
} 

#pragma pack(pop)

#endif // __MPEG2MUX_FILTER_PROPID__

