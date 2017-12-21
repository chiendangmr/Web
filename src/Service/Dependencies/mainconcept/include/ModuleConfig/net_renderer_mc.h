/**
@file net_renderer_mc.h
@brief Property GUIDs for MainConcept Network Renderer parameters.

@verbatim
File: net_renderer_mc.h

Desc: Property GUIDs for MainConcept Network Renderer parameters.

Copyright (c) 2014 MainConcept GmbH or its affiliates.  All rights reserved.

MainConcept and its logos are registered trademarks of MainConcept GmbH or its affiliates.  
This software is protected by copyright law and international treaties.  Unauthorized 
reproduction or distribution of any portion is prohibited by law.
@endverbatim
*/

#ifndef __NETWORK_RENDERER_PROPID_MAINCONCEPT__
#define __NETWORK_RENDERER_PROPID_MAINCONCEPT__


namespace MainConcept {

    /**
    namespace NetworkStreaming
    */
    namespace NetworkStreaming {

        /**
        @brief Kind of data speed control
        */
        typedef enum _tagDataTransferControl {

            EWorkWithoutRateControl = 0x00,						/**< Send data as fast as possible */
            EUseSamplesTime			= 0x01,						/**< Send packets according to sample timestamps */
            EUseBitrate				= 0x02						/**< Use user-defined bitrate value */
        } RATECONTROLTYPE;

        /**
        @brief Describes bitrate information on sender
        */
        typedef struct _tagBitrateInfo {

            BSTR			_pMediaName;						/**< Sender/Pin name */
            long long       _Bitrate;							/**< Current bitrate in bits per second */
            unsigned int	_SSRC;								/**< RTP SSRC of packets */
            unsigned int	_ID;								/**< Pin ID */
        } BITRATEINFO;

        /**
        @brief RTP info after RTSP SETUP processing
        */
        typedef struct _tagPublicRtpInfo {

            unsigned int   _ID;									/**< Sender/Pin ID */
            unsigned int   _TS;									/**< RTP Timestamp of next packet */
            unsigned short _SeqNum;								/**< RTP Sequence number of next packet */
        } PUBLICRTPINFO;	

        /**
        @brief Contains RTP info of all active senders
        */
        typedef struct _tagPublicRtpInfoStorage {

            unsigned int   _Count;								/**< Count of senders */
            PUBLICRTPINFO* _pMediaArray;						/**< Array of RTP Info structures for senders */
        } PUBLICRTPINFOSTORAGE;

        /**
        @brief Describes some sending information on each senders
        */
        typedef struct _tagBitrateInfoStorage {

            unsigned int _Count;								/**< Count of senders */
            BITRATEINFO* _pMediaArray;							/**< Array of bitrate info structures for senders */
        } BITRATEINFOSTORAGE;

        /**
        @brief Server working mode
        */
        typedef enum _tagServerWorkMode {

            RTPmode			= 0x00,								/**< RTP Mode - use SAP announces */
            RTSPmode		= 0x01,								/**< RTSP Mode - use RTP Info */
            InterleavedMode	= 0x02,								/**< Use interleaving channel to send data */
            RtmpMode		= 0x03								/**< Use RTMP channel to send data */
        } SERVERWORKMODE;

        /**
        @brief Describes behavior on network errors
        */
        typedef enum _tagNetworkErrorHandlerType {

            EWaitForRepairing = 0x00,							/**< Wait for recovery on network cable/signal loss */
            ESkipWhileFailure = 0x01							/**< Drop packets on network cable/signal loss */
        } NETWORKERRORHANDLERTYPE;
    };
};

/**
@brief Specifies SDP sender's network type
@details 
<dl><dt><b> Type:             </b></dt><dd>  VT_UINT                      </dd></dl>        
<dl><dt><b> Available values: </b></dt><dd>  networkInternet              </dd></dl>       
<dl><dt><b> Default values:   </b></dt><dd>  Not applicable, read only    </dd></dl>

@see NETWORKTYPE
@hideinitializer
*/
static const GUID MCNR_OriginNetworkType = { 0x6E726F48, 0x2C00, 0x4493, { 0xAE, 0xE8, 0x26, 0x15, 0xEB, 0xC1, 0x11, 0x88 } };

/**
@brief Specifies SDP sender's interface address type
@details 
<dl><dt><b> Type:             </b></dt><dd>  VT_UINT                   </dd></dl>
<dl><dt><b> Available values: </b></dt><dd>  addressTypeIP4,<br>
addressTypeIP6            </dd></dl>
<dl><dt><b> Default values:   </b></dt><dd>  Not applicable, read only </dd></dl>

@see ADDRESSTYPE
@hideinitializer
*/			
static const GUID MCNR_OriginAddressType = { 0x6E726F48, 0x2C01, 0x4493, { 0xAE, 0xE8, 0x26, 0x15, 0xEB, 0xC1, 0x11, 0x88 } };

/**
@brief Specifies server's network type
@details 
<dl><dt><b> Type:             </b></dt><dd>  VT_UINT                   </dd></dl>
<dl><dt><b> Available values: </b></dt><dd>  networkInternet           </dd></dl>
<dl><dt><b> Default values:   </b></dt><dd>  Not applicable, read only </dd></dl>

@see NETWORKTYPE
@hideinitializer
*/			
static const GUID MCNR_ConnectionNetworkType = { 0x6E726F48, 0x2C02, 0x4493, { 0xAE, 0xE8, 0x26, 0x15, 0xEB, 0xC1, 0x11, 0x88 } };


/**
@brief 	Specifies server's address type
@details 
<dl><dt><b> Type:             </b></dt><dd>  VT_UINT                   </dd></dl>
<dl><dt><b> Available values: </b></dt><dd>  addressTypeIP4,<br>
addressTypeIP6            </dd></dl>
<dl><dt><b> Default values:   </b></dt><dd>  Not applicable, read only </dd></dl>

@see ADDRESSTYPE
@hideinitializer
*/			
static const GUID MCNR_ConnectionAddressType = { 0x6E726F48, 0x2C03, 0x4493, { 0xAE, 0xE8, 0x26, 0x15, 0xEB, 0xC1, 0x11, 0x88 } };

/**
@brief Specifies the transport type
@details
<dl><dt><b> Type:             </b></dt><dd>  VT_UINT                   </dd></dl> 
<dl><dt><b> Available values: </b></dt><dd>  protocolRtpAvp <br> protocolUdp    <br> protocolTcp </dd></dl>
<dl><dt><b> Default values:   </b></dt><dd>  protocolRtpAvp            </dd></dl>

@see PROTOCOL
@hideinitializer
*/			
static const GUID MCNR_StreamingProtocol = { 0x6E726F48, 0x2C04, 0x4493, { 0xAE, 0xE8, 0x26, 0x15, 0xEB, 0xC1, 0x11, 0x88 } };

/**
@brief Indicates which kind of media is currently streamed (muxed or elementary stream)
@details 
<dl><dt><b> Type:             </b></dt><dd> VT_UINT                    </dd></dl> 
<dl><dt><b> Available values: </b></dt><dd> streamingTypeMultiplexedStream <br> streamingTypeElementaryStream </dd></dl>
<dl><dt><b> Default values:   </b></dt><dd> Not applicable, Read Only   </dd></dl>

@see STREAMINGTYPE
@hideinitializer
*/	
static const GUID MCNR_StreamingType = { 0x6E726F48, 0x2C05, 0x4493, { 0xAE, 0xE8, 0x26, 0x15, 0xEB, 0xC1, 0x11, 0x88 } };

/**
@brief   Specifies first available local port for sending media data
@details 0 value means use random source port. A Real port number will be evaluate as 
Initial Source port + Pin number*2, and should be even. Odd value will be incremented.
<dl><dt><b> Type:             </b></dt><dd> VT_UI2                     </dd></dl> 
<dl><dt><b> Available values: </b></dt><dd> 1024 .. 65535              </dd></dl>
<dl><dt><b> Default values:   </b></dt><dd> 0                       </dd></dl>

@hideinitializer
*/	
static const GUID MCNR_RtpInitialSourcePort = { 0x88126fd, 0x73e9, 0x4e5c, { 0x93, 0x7e, 0x32, 0x3e, 0x60, 0x8c, 0x82, 0x67 } };

/**
@brief Specifies first available port for sending media data
@details 
<dl><dt><b> Type:             </b></dt><dd> VT_UI2                     </dd></dl> 
<dl><dt><b> Available values: </b></dt><dd> 1024 .. 65535              </dd></dl>
<dl><dt><b> Default values:   </b></dt><dd> 1100                       </dd></dl>

@hideinitializer
*/	
static const GUID MCNR_StreamingPort = { 0x6E726F48, 0x2C06, 0x4493, { 0xAE, 0xE8, 0x26, 0x15, 0xEB, 0xC1, 0x11, 0x88 } };

/**
@brief Specifies Time To Live for the packets
@details 
<dl><dt><b> Type:             </b></dt><dd> VT_U8    </dd></dl>  
<dl><dt><b> Available values: </b></dt><dd> 1...255  </dd></dl> 
<dl><dt><b> Default values:     </b></dt><dd> 64       </dd></dl> 

@hideinitializer
*/	
static const GUID MCNR_ConnectionTTL = { 0x6E726F48, 0x2C07, 0x4493, { 0xAE, 0xE8, 0x26, 0x15, 0xEB, 0xC1, 0x11, 0x88 } };

/**
@brief Specifies SDP bandwidth field value
@details
<dl><dt><b> Type: </b></dt><dd> VT_UINT</dd></dl>  
<dl><dt><b>Default values:</b></dt><dd>4000 </dd></dl> 

@hideinitializer
*/	

static const GUID MCNR_BandWidthValue = { 0x6E726F48, 0x2C08, 0x4493, { 0xAE, 0xE8, 0x26, 0x15, 0xEB, 0xC1, 0x11, 0x88 } };

/**
@brief  Specifies current SDP session identifier
@details 
<dl><dt><b> Type: </b></dt><dd>VT_I8 </dd></dl>  
<dl><dt><b>Default values:</b></dt><dd>Not applicable, read only </dd></dl>    

@hideinitializer
*/	
static const GUID MCNR_OriginSessionID = { 0x6E726F48, 0x2C09, 0x4493, { 0xAE, 0xE8, 0x26, 0x15, 0xEB, 0xC1, 0x11, 0x88 } };

/**
@brief  Specifies server's local network interface
@details 
<dl><dt><b>Type: </b></dt><dd> VT_BSTR</dd></dl>  
<dl><dt><b>Available values:</b></dt><dd> Valid IPv4 address <br> Valid IPv6 address </dd></dl> 
<dl><dt><b>Default values:</b></dt><dd>System default network interface</dd></dl> 

@hideinitializer
*/	
static const GUID MCNR_OutgoingNetworkInterface = { 0x6E726F48, 0x2C0A, 0x4493, { 0xAE, 0xE8, 0x26, 0x15, 0xEB, 0xC1, 0x11, 0x88 } };

/**
@brief Specifies destination address to send media data to
@details 
<dl><dt><b> Type: </b></dt><dd> VT_BSTR</dd></dl>  
<dl><dt><b> Available values:</b></dt><dd> Valid IPv4 address <br> Valid IPv6 address</dd></dl> 
<dl><dt><b>Default values:</b></dt><dd>  234.5.5.5 </dd></dl> 

@hideinitializer
*/	
static const GUID MCNR_DestinationAddress = { 0x6E726F48, 0x2C0B, 0x4493, { 0xAE, 0xE8, 0x26, 0x15, 0xEB, 0xC1, 0x11, 0x88 } };

/**
@brief  Specifies email address of sender
@details 
<dl><dt><b> Type: </b></dt><dd> VT_BSTR</dd></dl>  
<dl><dt><b> Available values:</b></dt><dd> Any text </dd></dl> 

@hideinitializer
*/	
static const GUID MCNR_EmailField = { 0x6E726F48, 0x2C0C, 0x4493, { 0xAE, 0xE8, 0x26, 0x15, 0xEB, 0xC1, 0x11, 0x88 } };

/**
@brief  Specifies sender's phone number
@details 
<dl><dt><b> Type: </b></dt><dd> VT_BSTR </dd></dl>  
<dl><dt><b> Available values:</b></dt><dd>  Any text </dd></dl> 

@hideinitializer
*/	
static const GUID MCNR_PhoneField = { 0x6E726F48, 0x2C0D, 0x4493, { 0xAE, 0xE8, 0x26, 0x15, 0xEB, 0xC1, 0x11, 0x88 } };

/**
@brief Specifies SDP bandwidth modifier described in RFC2327
@details
<dl><dt><b> Type: </b></dt><dd>VT_BSTR </dd></dl>  
<dl><dt><b> Available values:</b></dt><dd> "AS" <br> "CT" <br> "RS"<br> "RR"</dd></dl> 
<dl><dt><b> Default values: </b></dt><dd> "AS" </dd></dl>

@hideinitializer
*/	
static const GUID MCNR_BandWidthModifier = { 0x6E726F48, 0x2C0E, 0x4493, { 0xAE, 0xE8, 0x26, 0x15, 0xEB, 0xC1, 0x11, 0x88 } };

/**
@brief  Specifies SAP session name
@details
<dl><dt><b> Type: </b></dt><dd> VT_BSTR </dd></dl>  
<dl><dt><b> Available values:</b></dt><dd>Any text  </dd></dl> 

@hideinitializer
*/	
static const GUID MCNR_SessionName = { 0x6E726F48, 0x2C0F, 0x4493, { 0xAE, 0xE8, 0x26, 0x15, 0xEB, 0xC1, 0x11, 0x88 } };

/**
@brief Specifies name of the announce creator
@details 
<dl><dt><b> Type: </b></dt><dd> VT_BSTR </dd></dl>  
<dl><dt><b> Available values:</b></dt><dd>Any text </dd></dl> 

@hideinitializer
*/	
static const GUID MCNR_OriginCreatorName = { 0x6E726F48, 0x2C10, 0x4493, { 0xAE, 0xE8, 0x26, 0x15, 0xEB, 0xC1, 0x11, 0x88 } };

/**
@brief  Specifies SAP additional information
@details 
<dl><dt><b> Type: </b></dt><dd> VT_BSTR </dd></dl>  
<dl><dt><b> Available values:</b></dt><dd> Any text</dd></dl> 

@hideinitializer
*/	
static const GUID MCNR_SessionInfo = { 0x6E726F48, 0x2C11, 0x4493, { 0xAE, 0xE8, 0x26, 0x15, 0xEB, 0xC1, 0x11, 0x88 } };

/**
@brief Specifies Universal Resource Identifier as used by WWW clients
@details 
<dl><dt><b> Type: </b></dt><dd> VT_BSTR</dd></dl>  
<dl><dt><b> Available values:</b></dt><dd> URI text representation</dd></dl> 

@hideinitializer
*/	
static const GUID MCNR_SessionDescriptionURI = { 0x6E726F48, 0x2C12, 0x4493, { 0xAE, 0xE8, 0x26, 0x15, 0xEB, 0xC1, 0x11, 0x88 } };

/**
@brief  Specifies current SDP document version
@details 
<dl><dt><b> Type: </b></dt><dd> VT_I8</dd></dl>  
<dl><dt><b> Default values: </b></dt><dd> Not applicable, Read only</dd></dl>    

@hideinitializer
*/	
static const GUID MCNR_OriginSessionVersion = { 0x6E726F48, 0x2C14, 0x4493, { 0xAE, 0xE8, 0x26, 0x15, 0xEB, 0xC1, 0x11, 0x88 } };

/**
@brief Specifies max transfer unit size (MTU)
@details 
<dl><dt><b> Type: </b></dt><dd> VT_UI2 </dd></dl>  
<dl><dt><b> Available values:</b></dt><dd> 320 ... 65535 </dd></dl> 
<dl><dt><b> Default values:</b></dt><dd>  1500</dd></dl> 

@hideinitializer
*/	
static const GUID MCNR_MaxTransferUnit = { 0x6E726F48, 0x2C15, 0x4493, { 0xAE, 0xE8, 0x26, 0x15, 0xEB, 0xC1, 0x11, 0x88 } };

/**
@brief Specifies address for the SAP announcements group
@details
<dl><dt><b> Type: </b></dt><dd> VT_BSTR</dd></dl>  
<dl><dt><b> Available values:</b></dt><dd> IPv4 address <br> IPv6 address </dd></dl> 
<dl><dt><b> Default values:</b></dt><dd>   224.2.127.254  </dd></dl>

@hideinitializer
*/	
static const GUID MCNR_SapMulticastGroup = { 0x6E726F48, 0x2C16, 0x4493, { 0xAE, 0xE8, 0x26, 0x15, 0xEB, 0xC1, 0x11, 0x88 } };

/**
@brief Specifies rate control (send rate control) type.
@details 
If EUseBitrate mode was choosen, but bitrate is not present on the pin, or user not define
own bitrate for the VES/AES/RAW/Multiplexed stream, then EUseSamplesTime will be used.
<dl><dt><b> Type: </b></dt><dd> VT_UINT </dd></dl>  
<dl><dt><b> Available values:</b></dt><dd> EUseSamplesTime <br> EUseBitrate <br> EWorkWithoutRateControl</dd></dl> 
<dl><dt><b> Default values: </b></dt><dd>   EUseSamplesTime </dd></dl>

@see RATECONTROLTYPE
@hideinitializer
*/	
static const GUID MCNR_RateControl = { 0x6E726F48, 0x2C18, 0x4493, { 0xAE, 0xE8, 0x26, 0x15, 0xEB, 0xC1, 0x11, 0x88 } };

/**
@brief Pointer to the current ISdpDecoder interface
@details 
<dl><dt><b> Type: </b></dt><dd> VT_UINT_PTR </dd></dl>  
<dl><dt><b> Default values: </b></dt><dd> Not applicable, Read only </dd></dl>   

@hideinitializer
*/	
static const GUID MCNR_SdpDecoder = { 0x6E726F48, 0x2C19, 0x4493, { 0xAE, 0xE8, 0x26, 0x15, 0xEB, 0xC1, 0x11, 0x88 } };

/**
@brief Specifies current server work mode
@details 
<dl><dt><b> Type: </b></dt><dd> VT_UINT</dd></dl>  
<dl><dt><b> Available values:</b></dt><dd> RTPmode <br>    RTSPmode<br>     InterleavedMode<br>     RtmpMode </dd></dl> 
<dl><dt><b> Default values: </b></dt><dd> RTPmode </dd></dl>

@see SERVERWORKMODE
@hideinitializer
*/	
static const GUID MCNR_ServerWorkMode = { 0x6E726F48, 0x2C20, 0x4493, { 0xAE, 0xE8, 0x26, 0x15, 0xEB, 0xC1, 0x11, 0x88 } };

/**
@brief Specifies unique pins properties (suitable only for RTSP and Interleaving modes).
@details 
- first 32 bits consist of unique media ID
- next  16 bits consist of unique client media port
- last  16 bits consist of unique server media port
<dl><dt><b> Type: </b></dt><dd> VT_I8 </dd></dl>  
<dl><dt><b> Default values: </b></dt><dd>-1 </dd></dl>

@hideinitializer
*/	
static const GUID MCNR_NetworkPinProperties = { 0x6E726F48, 0x2C21, 0x4493, { 0xAE, 0xE8, 0x26, 0x15, 0xEB, 0xC1, 0x11, 0x88 } };

/**
@brief  Enable/Disable saving current SSRC and Sequence Number values at EOS and restoring them at subsequent playback start
@details 
<dl><dt><b> Type: </b></dt><dd>VT_BOOL </dd></dl>  
<dl><dt><b> Available values:</b></dt><dd> FALSE <br> TRUE </dd></dl> 
<dl><dt><b> Default values: </b></dt><dd> FALSE</dd></dl>

@hideinitializer
*/	
static const GUID MCNR_RtpContinuityOnEOS = { 0x2308711B, 0x8E95, 0x4616, { 0x9F, 0x59, 0xCD, 0xE6, 0xAC, 0xC8, 0x25, 0x56 } };

/**
@brief  On write  saves current SDP to specified file path
@details 
<dl><dt><b> Type: </b></dt><dd>VT_BSTR </dd></dl>  
<dl><dt><b> Available values:</b></dt><dd> Correct filepath </dd></dl> 
<dl><dt><b> Default values: </b></dt><dd> MCSdp.sdp </dd></dl>

@hideinitializer
*/	
static const GUID MCNR_SdpFileName = { 0x6E726F48, 0x2C22, 0x4493, { 0xAE, 0xE8, 0x26, 0x15, 0xEB, 0xC1, 0x11, 0x88 } };

/**
@brief Enable/Disable announces broadcasting
@details 
<dl><dt><b> Type: </b></dt><dd>VT_BOOL </dd></dl>  
<dl><dt><b> Available values:</b></dt><dd> FALSE <br> TRUE </dd></dl> 
<dl><dt><b> Default values: </b></dt><dd> TRUE</dd></dl>

@hideinitializer
*/	
static const GUID MCNR_UseSAP = { 0x6E726F48, 0x2C24, 0x4493, { 0xAE, 0xE8, 0x26, 0x15, 0xEB, 0xC1, 0x11, 0x88 } };

/**
@brief  Enables (true) or disables (false) RTCP sender
@details  
<dl><dt><b> Type: </b></dt><dd> VT_BOOL </dd></dl>  

<dl><dt><b> Available values:</b></dt><dd> FALSE <br> TRUE </dd></dl> 
<dl><dt><b> Default values: </b></dt><dd> FALSE</dd></dl>

@hideinitializer
*/	
static const GUID MCNR_UseRTCP = { 0x6E726F48, 0x2C25, 0x4493, { 0xAE, 0xE8, 0x26, 0x15, 0xEB, 0xC1, 0x11, 0x88 } };

/**
@brief  Specifies bitrate (in Kbits) for the multiplexed streams and for VES/AES/RAW, for other streams it's wouldn't be used
@details  
<dl><dt><b> Type: </b></dt><dd>VT_R8 </dd></dl>  
<dl><dt><b> Default values: </b></dt><dd> 0</dd></dl>

@hideinitializer
*/	
// {6E726F48-2C26-4493-AEE8-2615EBC11188}
static const GUID MCNR_StreamBitrate = { 0x6E726F48, 0x2C26, 0x4493, { 0xAE, 0xE8, 0x26, 0x15, 0xEB, 0xC1, 0x11, 0x88 } };

/**
@brief Contains current bitrate information
@details Contains current bitrate information
<dl><dt><b> Type: </b></dt><dd>VT_UINT_PTR </dd></dl>  
<dl><dt><b> Default values: </b></dt><dd>Not applicable, Read only </dd></dl>

@hideinitializer
*/	
static const GUID MCNR_BitrateInfoStorage = { 0x6E726F48, 0x2C27, 0x4493, { 0xAE, 0xE8, 0x26, 0x15, 0xEB, 0xC1, 0x11, 0x88 } };

/**
@brief Consists of: first 32 bit  ID, next 32 bit  SSRC (only for RTSP unicast mode)
@details 
<dl><dt><b> Type: </b></dt><dd>VT_I8 </dd></dl>  
<dl><dt><b> Default values: </b></dt><dd>Not applicable, Read only </dd></dl>    

@hideinitializer
*/	
static const GUID MCNR_NetworkMediaSSRC = { 0x6E726F48, 0x2C28, 0x4493, { 0xAE, 0xE8, 0x26, 0x15, 0xEB, 0xC1, 0x11, 0x88 } };

/**
@brief Consists of RTP info (only for RTSP unicast mode)
@details 
<dl><dt><b> Type: </b></dt><dd> VT_UINT_PTR</dd></dl>  
<dl><dt><b> Default values: </b></dt><dd>Not applicable, Read only </dd></dl>    

@hideinitializer
*/	
static const GUID MCNR_PublicRtpInfo = { 0x6E726F48, 0x2C29, 0x4493, { 0xAE, 0xE8, 0x26, 0x15, 0xEB, 0xC1, 0x11, 0x88 } };

/**
@brief  Turn on/off Loss tolerant mode for mpeg audio (RFC3119)
@details 
<dl><dt><b> Type: </b></dt><dd>VT_BOOL </dd></dl>  
<dl><dt><b> Available values:</b></dt><dd> TRUE <br> FALSE</dd></dl> 
<dl><dt><b> Default values:</b></dt><dd>FALSE </dd></dl> 

@hideinitializer
*/	
static const GUID MCNR_UseLossTollerantMP3 = { 0x6E726F48, 0x2C30, 0x4493, { 0xAE, 0xE8, 0x26, 0x15, 0xEB, 0xC1, 0x11, 0x88 } };

/**
@brief Set up the max SVC dependency layer Id
@details 
<dl><dt><b> Type: </b></dt><dd> VT_UINT</dd></dl>  
<dl><dt><b> Available values:</b></dt><dd>0..7  </dd></dl> 
<dl><dt><b> Default:</b></dt><dd>7  </dd></dl> 

@hideinitializer
*/	
static const GUID MCNR_SvcDependencyId = { 0x6E726F48, 0x2C31, 0x4493, { 0xAE, 0xE8, 0x26, 0x15, 0xEB, 0xC1, 0x11, 0x88 } };

/**
@brief Set up the max SVC quality layer Id
@details 
<dl><dt><b> Type: </b></dt><dd> VT_UINT</dd></dl>  
<dl><dt><b> Available values:</b></dt><dd> 0 .. 15   </dd></dl> 
<dl><dt><b> Default:</b></dt><dd> 15</dd></dl> 

@hideinitializer
*/	

static const GUID MCNR_SvcQualityId = { 0x6E726F48, 0x2C33, 0x4493, { 0xAE, 0xE8, 0x26, 0x15, 0xEB, 0xC1, 0x11, 0x88 } };

/**
@brief  Set up burstness value in mS
@details  Set up burstness value in mS
<dl><dt><b> Type: </b></dt><dd> VT_UINT</dd></dl>  
<dl><dt><b> Available values:</b></dt><dd>  0..1000</dd></dl> 
<dl><dt><b> Default:</b></dt><dd>0 </dd></dl>  

@hideinitializer
*/	
static const GUID MCNR_BurstnessValue = { 0x6E726F48, 0x2C32, 0x4493, { 0xAE, 0xE8, 0x26, 0x15, 0xEB, 0xC1, 0x11, 0x88 } };

/**
@brief Set type of network errors handling
@details 
<dl><dt><b> Type: </b></dt><dd> VT_UINT </dd></dl>  
<dl><dt><b> Available values:</b></dt><dd> EWaitForRepairing <br> ESkipWhileFailure </dd></dl> 
<dl><dt><b> Default:</b></dt><dd> EWaitForRepairing</dd></dl>  

@see NETWORKERRORHANDLERTYPE
@hideinitializer
*/	
static const GUID MCNR_NetworkErrorHandling = { 0x9451777a, 0x18cb, 0x49ce, { 0xbe, 0xa9, 0x21, 0xcb, 0xc6, 0xc5, 0x15, 0x9b } };

/**
@brief Pointer to IUniversalDataSender to use for RTMP transport
@details 
<dl><dt><b> Type: </b></dt><dd>VT_UINT_PTR </dd></dl>  
<dl><dt><b> Available values:</b></dt><dd>Valid pointer to IUniversalDataSender </dd></dl> 
<dl><dt><b> Default:</b></dt><dd> NULL</dd></dl>  


@see IUniversalDataSender, IRtmpServerEngine
@hideinitializer
*/	
static const GUID MCNR_ExternalDataConsumer = { 0x7ea40832, 0xe62b, 0x4d18, { 0xa4, 0x30, 0xfd, 0x6d, 0x90, 0xc6, 0x52, 0x78 } };

/**
@brief  Set client buffer length value in milliseconds for RTMP mode           
@details  Set client buffer length value in milliseconds for RTMP mode           
<dl><dt><b> Type: </b></dt><dd> VT_UINT</dd></dl>  
<dl><dt><b> Default:</b></dt><dd> 0</dd></dl>  

@hideinitializer
*/	
static const GUID MCNR_RtmpBufferingTime = { 0xb9e94ce9, 0x6338, 0x4792, { 0x91, 0x3e, 0x2e, 0xeb, 0x53, 0x95, 0x2a, 0x64 } };

/**
@brief    Pointer to interleaving IUniversalDataSender acquired from RTSP engine for interleaving transport
@details   
<dl><dt><b> Type: </b></dt><dd> VT_UINT_PTR</dd></dl>  
<dl><dt><b> Available values:</b></dt><dd> Valid pointer to IUniversalDataSender implementation </dd></dl> 
<dl><dt><b> Default:</b></dt><dd> NULL</dd></dl>  

@see IUniversalDataSender, IRtspServerEngine
@hideinitializer
*/	
static const GUID MCNR_InterleavingSender = { 0x400edf3b, 0x4971, 0x4edf, { 0x9d, 0xa3, 0x77, 0x98, 0xbd, 0xdc, 0xb6, 0x5e } };
  
/**
@brief    Pointer to ISharedSocketInfo acquired from application where NetSource is used. 
@details   
<dl><dt><b> Type: </b></dt><dd> VT_UINT_PTR</dd></dl>  
<dl><dt><b> Available values:</b></dt><dd> Valid pointer to ISharedSocketInfo implementation. 
<It is got from NetSource instance. It may be in another application, you may use for exchange ISharedSocketInfo::Serialize in source application and CreateSharedSocketInfo in render application </dd></dl> 
<dl><dt><b> Default:</b></dt><dd> NULL</dd></dl>  

@see ISharedSocketInfo
@hideinitializer
*/	
static const GUID MCNR_SharedSocketInfo = { 0xb7f0003b, 0xb9a2, 0x48b3, { 0x93, 0x75, 0xe4, 0x68, 0x7e, 0x36, 0x57, 0x82 } };

#endif //__NETWORK_RENDERER_PROPID_MAINCONCEPT__
