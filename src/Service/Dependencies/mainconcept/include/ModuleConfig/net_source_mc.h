/** 
@file net_source_mc.h
@brief Property GUIDs for MainConcept Network Source parameters.
@verbatim
File: net_source_mc.h
Desc: Property GUIDs for MainConcept Network Source parameters.

Copyright (c) 2014 MainConcept GmbH or its affiliates.  All rights reserved.

MainConcept and its logos are registered trademarks of MainConcept GmbH or its affiliates.  
This software is protected by copyright law and international treaties.  Unauthorized 
reproduction or distribution of any portion is prohibited by law.
@endverbatim
*/

#if !defined(__NETWORKSOURCE_PROPID_HEADER__)
#define __NETWORKSOURCE_PROPID_HEADER__

/**
@brief Specifies RTSP method for Keep-Alive message
*/
typedef enum _tagKeepAliveMethod {

    EKeepAliveOptions  = 0,					/**< Use RTSP OPTIONS command as keep-alive request */
    EKeepAliveSetParam = 1,					/**< Use RTSP GET_PARAMETER command as keep-alive request */
    EKeepAliveGetParam = 2,					/**< Use RTSP SET_PARAMETER command as keep-alive request */
    EKeepAliveNone     = 3                  /**< Without keep-alive request */
} KeepAliveMethod;

/**
@brief Specifies initialization mode: synchronous or asynchronous
*/
typedef enum _tagEngineInitMode {

    EngineSyncInit  = 0,					/**< Wait while engine (re-)initialization to complete when changing properties via ModuleConfig */
    EngineAsyncInit = 1						/**< Return control as soon as possible, use MCNS_EngineReady to check engine initialization status */
} EngineInitMode;

/**
@brief Specifies low-level engine type
*/
typedef enum _tagReceivingMode{

    modeUndefined = 0,						/**< Unknown/uninitialized state */
    modeRTP       = 1,						/**< Use Live streaming */
    modeRTSP      = 2,						/**< Use RTSP client */
    modeSDP       = 3,						/**< Use Live streaming with configuration from SDP */
    modeHTTP      = 4,						/**< Use HTTP client */
    modeRTMP      = 5,						/**< Use RTMP client */
    modeMax       = 6						/**< Reserved */
} ReceivingMode_t;

/**
@brief Specifies internal buffering mode 
*/
typedef enum _tagBufferingMode {

    EBufferingModeLowDelay = 0,				/**< Return samples as soon as they arrive */
    EBufferingUserDefined  = 1,				/**< Collect samples until specified amount of time is buffered */
    EBufferingModeAuto     = 2				/**< Automatically adjust buffering time */
} BUFFERINGMODE;

/**
@brief Specifies location of HTTP cache
*/
typedef enum _tagHttpCacheMode {

    EHttpCacheInMemory = 0,					/**< Use memory buffer as read-ahead buffer */
    EHttpCacheInFile   = 1,					/**< Use temporary file to cache received data, cache file may be as big as source file and is valid until engine reinitialization */
} HTTPCACHEMODE;

/**
@brief Contains RTCP information
*/
typedef struct _tagNetworkQualityInfo {

    BSTR		 _pMediaName;					/**< Name of Pin */
    unsigned int _ReceiverId;					/**< Pin ID */
    long long    _RecvRate;						/**< Current data rate in bits per second */
    unsigned int _DropCount;					/**< Count of dropped packets on last gap in data */
    int          _Jitter;						/**< RTP packet jitter */
    unsigned int _SSRC;							/**< SSRC of RTP packets */
    int			 _BufferUsage;					/**< Amount of used buffer space, in percent */
    long long    _SessionContributedDataSize;   /**< Size of data downloaded within a single session for a given track */
} NETQUALITYINFO;

/**
@brief Describes quality of network
*/
typedef struct _tagNetQualityInfoStorage {

    unsigned int    _Count;						/**< Count of items in _pNetQualityInfoArray  */
    NETQUALITYINFO* _pNetQualityInfoArray;		/**< Pin/Receiver info array */
    long long		_DataSize;					/**< Full size of HTTP cache */
    long long		_CachedSize;				/**< Size of currently cached HTTP data */
} NETQUALITYINFOSTORAGE;

/**
@brief Specifies authentication credentials
*/
typedef struct _tagImcAuthParams {

    char _UserName[1024];						/**< User name */
    char _Password[1024];						/**< Password */
} IMCAUTHPARAMS;

/**
@brief Specifies RTMP handshake keys and client behavior
@details To enable private playback you should use same keys on server and client side. 
*/
typedef struct _tagImcRtmpHandshakeParams {

    char _ServerKey[128];						/**< Client key */
    char _ClientKey[128];						/**< Server key */
    bool _bRequireServerValidate;				/**< Require validation of peer's key */
} IMCRTMPHANDSHAKEPARAMS;

/**
@brief Specifies preferrable media port - random generated or user specified.
*/
typedef enum _tagMediaPortMode {

    MediaPortRandom      = 0,					/**< Choose media data port randomly */
    MediaPortUserDefined = 1					/**< Use user-specified port as base when choosing media port */
} MEDIAPORTMODE;

//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
//  IModuleConfig GUIDs
//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

/**
@var MCNS_TransportType				
@brief 	Specifies the transport type of received data
@details 
<dl><dt>Type         : </dt>    <dd>VT_UINT		</dd></dl>
<dl><dt>Available range	: </dt>	        <dd>See CLIENTPROTOCOLTYPE</dd></dl>   
<dl><dt>Default value: </dt>         <dd>	UnicastRtpAvpUdpMode</dd></dl>    
<dl><dt>Re-init: </dt>        <dd>	Yes		</dd></dl>   
@hideinitializer
*/
static const GUID MCNS_TransportType = { 0xfff0ab9b, 0x7467, 0x42e9, { 0xaa, 0x77, 0xaf, 0xfc, 0xf3, 0x14, 0x5f, 0x45 } };

/**
@var MCNS_MediaPortMode			
@brief 	Specifies the media port generation mode for RTSP
@details 
<dl><dt>Type         : </dt>    <dd>VT_UINT		</dd></dl>  
<dl><dt>Available range	: </dt>	        <dd>See MEDIAPORTMODE		</dd></dl> 
<dl><dt>Default value: </dt>         <dd>MediaPortRandom		</dd></dl>     
<dl><dt>Re-init: </dt>        	<dd>Yes		</dd></dl>    
@hideinitializer
*/
static const GUID MCNS_MediaPortMode = { 0x2829fa63, 0xda0b, 0x4113, { 0x8f, 0x4a, 0xd4, 0x3d, 0x4a, 0x29, 0x54, 0x31 } };

/**
@var MCNS_MediaPort					
@brief Specifies the media port for RTP receiver, or to request from RTSP server if media port mode is set to MediaPortUserDefined
@details 
<dl><dt>Type         : </dt>    <dd>VT_UI2		</dd></dl>   
<dl><dt>Available range	: </dt>	        <dd>[1, 65534]			</dd></dl>    
<dl><dt>Default value: </dt>         <dd>	10200				</dd></dl>   
<dl><dt>Re-init: </dt>        <dd>	Yes			</dd></dl>    
@hideinitializer
*/
static const GUID MCNS_MediaPort = { 0x632b2f86, 0xfddc, 0x428f, { 0xa5, 0x45, 0xc5, 0x0, 0x0, 0x1c, 0x2b, 0xde } };

/**
@var MCNS_RTSPServerConnectionPort
@brief Specifies the RTSP server connection port, see MCNS_URI
@details 
<dl><dt>Type         : </dt>    <dd>VT_UI2		</dd></dl>   
<dl><dt>Available range	: </dt>	        <dd>[1, 65535]			</dd></dl>    
<dl><dt>Default value: </dt>         <dd>	554 				</dd></dl>   
<dl><dt>Re-init: </dt>        <dd>	Yes			</dd></dl>    
@hideinitializer
*/

static const GUID MCNS_RTSPServerConnectionPort = { 0x3360966c, 0x917f, 0x4bc9, { 0xbf, 0x3b, 0x5f, 0xdd, 0x45, 0x19, 0x30, 0xad } };

/**
@var MCNS_DestinationAddress			
@brief 	Specifies the RTP media streaming address for Live streaming or for RTSP with multicast transport type, see MCNS_URI
@details 
<dl><dt>Type         : </dt>    <dd>VT_BSTR		</dd></dl>    
<dl><dt>Available range	: </dt>	        <dd>						</dd></dl>    
<dl><dt>Default value: </dt>         <dd>"234.6.6.5"			</dd></dl>   
<dl><dt>Re-init: </dt>        	<dd>Yes		</dd></dl>     
@hideinitializer
*/
static const GUID MCNS_DestinationAddress = { 0xc0ceec2e, 0x48ed, 0x4cfe, { 0x90, 0xfa, 0x5d, 0xc9, 0x10, 0x93, 0xc0, 0x74 } };

/**
@var MCNS_SDPMulticastAddress			
@brief 	Specifies multicast group address to receive SAP announces, deprecated
@details 
<dl><dt>Type         : </dt>    <dd>VT_BSTR		</dd></dl>   
<dl><dt>Available range	: </dt>	        <dd>						</dd></dl>    
<dl><dt>Default value: </dt>         <dd>"224.2.127.254"		</dd></dl>    
<dl><dt>Re-init: </dt>        	<dd>No		</dd></dl>    
@hideinitializer
*/
static const GUID MCNS_SDPMulticastAddress = { 0x55518f03, 0xc069, 0x433e, { 0xb4, 0xd8, 0xca, 0xcc, 0x87, 0xe3, 0x57, 0xb4 } };

/**
@var MCNS_LocalInterface				
@brief Specifies the local network interface address
@details
<dl><dt>Type         : </dt>    <dd>VT_BSTR		</dd></dl>    
<dl><dt>Available range	: </dt>	        <dd>						</dd></dl>    
<dl><dt>Default value: </dt>         <dd>"0.0.0.0"				</dd></dl>    
<dl><dt>Re-init: </dt>        <dd>Yes			</dd></dl>     
@hideinitializer
*/
static const GUID MCNS_LocalInterface = { 0xffbbb6b7, 0xce63, 0x45b3, { 0xa2, 0x48, 0x5, 0x39, 0xa9, 0x8, 0xd8, 0xcc } };

/**
@var MCNS_RTSPServerAddress			
@brief 	Specifies the RTSP server address, see MCNS_URI
@details
<dl><dt>Type         : </dt>    <dd>VT_BSTR		</dd></dl>        
<dl><dt>Available range	: </dt>	        <dd>						</dd></dl>  
<dl><dt>Default value: </dt>         <dd>""						</dd></dl>     
<dl><dt>Re-init: </dt>        <dd>Yes		</dd></dl>    
@hideinitializer
*/
static const GUID MCNS_RTSPServerAddress = { 0x8b9b6, 0x4a89, 0x4616, { 0x8a, 0x60, 0x23, 0x81, 0x98, 0xfd, 0xbb, 0xa8 } };

/**
@var MCNS_URI				
@brief Specifies the URI path for the stream, updates MCNS_RTSPServerAddress and MCNS_RTSPServerConnectionPort for RTSP or MCNS_DestinationAddress and MCNS_MediaPort for RTP
@details
<dl><dt>Type         : </dt>    <dd>VT_BSTR		</dd></dl>     
<dl><dt>Available range	: </dt>	        <dd>						</dd></dl>   
<dl><dt>Default value: </dt>         <dd>"rtsp://"				</dd></dl>     
<dl><dt>Re-init: </dt>        <dd>Yes			</dd></dl>    
@hideinitializer
*/
static const GUID MCNS_URI = { 0xa9a9e952, 0xf7ac, 0x44c8, { 0x83, 0x1d, 0x5b, 0x2d, 0xa7, 0x57, 0xab, 0x8d } };

/**
@var MCNS_StreamDuration			
@brief Retrieves the stream duration as string, either as time in "h:m:s" format or in bytes for HTTP
@details 
<dl><dt>Type         : </dt>    <dd>VT_BSTR		</dd></dl>    
<dl><dt>Available range	: </dt>	        <dd>						</dd></dl>     
<dl><dt>Default value: </dt>         <dd>Read only				</dd></dl>     
<dl><dt>Re-init: </dt>        <dd>No			</dd></dl>   
@hideinitializer
*/

static const GUID MCNS_StreamDuration = { 0xac74a444, 0xc08c, 0x4a7c, { 0x9b, 0xec, 0x5d, 0x32, 0x8c, 0xb7, 0x9f, 0x9a } };

/**
@var MCNS_ServerEMail				
@brief Retrieves the server e-mail from SDP
@details 
<dl><dt>Type         : </dt>    <dd>VT_BSTR		</dd></dl>      
<dl><dt>Available range	: </dt>	        <dd>						</dd></dl>   
<dl><dt>Default value: </dt>         <dd>Read only				</dd></dl>      
<dl><dt>Re-init: </dt>        <dd>No			</dd></dl>    
@hideinitializer
*/
static const GUID MCNS_ServerEMail = { 0xfccdee57, 0x2a27, 0x478a, { 0x83, 0x8a, 0x5e, 0xa4, 0xe3, 0x46, 0xff, 0x6a } };

/**
@var MCNS_ServerPhone				
@brief Retrieves the Server phone from SDP
@details 
<dl><dt>Type         : </dt>    <dd>VT_BSTR		</dd></dl>      
<dl><dt>Available range	: </dt>	        <dd>						</dd></dl>    
<dl><dt>Default value: </dt>         <dd>Read only				</dd></dl>    
<dl><dt>Re-init: </dt>        <dd>No			</dd></dl>    
@hideinitializer
*/
static const GUID MCNS_ServerPhone = { 0xddbd40dc, 0x545b, 0x4f4d, { 0xb1, 0x39, 0x37, 0x70, 0x4, 0xd8, 0xba, 0x93 } };

/**
@var MCNS_SessionName				
@brief Retrieves the session Name From SDP
@details
<dl><dt>Type         : </dt>    <dd>VT_BSTR		</dd></dl>       
<dl><dt>Available range	: </dt>	        <dd>						</dd></dl>    
<dl><dt>Default value: </dt>         <dd>Read only				</dd></dl>      
<dl><dt>Re-init: </dt>        <dd>No			</dd></dl>    
@hideinitializer
*/
static const GUID MCNS_SessionName = { 0xb1c1b4bd, 0x81ee, 0x42a3, { 0x82, 0x4d, 0x3c, 0x81, 0x50, 0x41, 0x56, 0x38 } };

/**
@var MCNS_ServerURI				
@brief Retrieves the server URI from SDP
@details 
<dl><dt>Type         : </dt>    <dd>VT_BSTR		</dd></dl>   
<dl><dt>Available range	: </dt>	        <dd>						</dd></dl>  
<dl><dt>Default value: </dt>         <dd>Read only				</dd></dl>      
<dl><dt>Re-init: </dt>        <dd>No			</dd></dl>    
@hideinitializer
*/
static const GUID MCNS_ServerURI = { 0xddcc0274, 0x13a6, 0x459f, { 0xb0, 0x68, 0x94, 0xe4, 0xed, 0x80, 0xc5, 0x9d } };

/**
@var MCNS_SdpDecoder			
@brief On read - retrieves the pointer to SDP decoder (must not be freed by user), on write - initializes filter with new SDP (user must free passed SDP decoder himself, because a copy will be created internally by filter)
@details
<dl><dt>Type         : </dt>    <dd>VT_UINT_PTR	</dd></dl>    
<dl><dt>Available range	: </dt>	        <dd>						</dd></dl>   
<dl><dt>Default value: </dt>         <dd>						</dd></dl>     
<dl><dt>Re-init: </dt>        <dd>Yes			</dd></dl>   
@hideinitializer
*/
static const GUID MCNS_SdpDecoder = { 0x555cf6b, 0x15ec, 0x4996, { 0x99, 0xc3, 0x86, 0x5, 0x6f, 0x9c, 0xff, 0x93 } };

/**
@var MCNS_ReceivingMode			
@brief Specifies the low level engine type
@details 
<dl><dt>Type         : </dt>    <dd>VT_UINT		</dd></dl>  
<dl><dt>Available range	: </dt>	        <dd>See ReceivingMode_t	</dd></dl>   
<dl><dt>Default value: </dt>         <dd>	modeUndefined		</dd></dl>      
<dl><dt>Re-init: </dt>        <dd>	Yes			</dd></dl>   
@hideinitializer
*/
static const GUID MCNS_ReceivingMode = { 0xbba9c00b, 0x362a, 0x4c05, { 0x83, 0x3c, 0xb5, 0x44, 0x63, 0x26, 0xb7, 0xe7 } };

/**
@var MCNS_EnableRTCPMode				
@brief Enables (true) or disables (false) RTCP receiver
@details 
<dl><dt>Type         : </dt>    <dd>VT_BOOL		</dd></dl>     
<dl><dt>Available range	: </dt>	        <dd>true, false			</dd></dl>    
<dl><dt>Default value: </dt>         <dd>	false				</dd></dl>    
<dl><dt>Re-init: </dt>        <dd>	Yes			</dd></dl>    
@hideinitializer
*/
static const GUID MCNS_EnableRTCPMode = { 0xaab1a7e9, 0xa61c, 0x40a0, { 0x97, 0x22, 0x30, 0xc3, 0x14, 0x2c, 0xfd, 0x11 } };

/**
@var MCNS_TimeOut				
@brief 	Specifies the time out value for low level engine
@details 
<dl><dt>Type         : </dt>    <dd>VT_UI4		</dd></dl>    
<dl><dt>Available range	: </dt>	        <dd>						</dd></dl>    
<dl><dt>Default value: </dt>         <dd>30						</dd></dl>     
<dl><dt>Re-init: </dt>        <dd>No		</dd></dl>  
@hideinitializer
*/
static const GUID MCNS_TimeOut = { 0x873707cf, 0x5b13, 0x4f63, { 0x88, 0x26, 0x9c, 0xdc, 0xc4, 0x4, 0x59, 0x2b } };

/**
@var MCNS_SessionInfo				
@brief Retrieves the session information from SDP
@details
<dl><dt>Type         : </dt>    <dd>VT_BSTR		</dd></dl>       
<dl><dt>Available range	: </dt>	        <dd>						</dd></dl>    
<dl><dt>Default value: </dt>         <dd>Read only				</dd></dl>      
<dl><dt>Re-init: </dt>        <dd>No			</dd></dl>    
@hideinitializer
*/
static const GUID MCNS_SessionInfo = { 0x775cca13, 0x6edf, 0x4ca0, { 0xb5, 0xb2, 0x32, 0xa1, 0x38, 0xe7, 0x24, 0x2b } };

/**
@var MCNS_RTSPServerType			
@brief Retrieves the RTSP server type (name)
@details
<dl><dt>Type         : </dt>    <dd>VT_UINT		</dd></dl>      
<dl><dt>Available range	: </dt>	        <dd>See RTSPSERVERNAME	</dd></dl>    
<dl><dt>Default value: </dt>         <dd>	Read only			</dd></dl>      
<dl><dt>Re-init: </dt>        <dd>	No			</dd></dl>   
@hideinitializer
*/
static const GUID MCNS_RTSPServerType = { 0x7fefcc7, 0xdcc5, 0x4f7d, { 0xa4, 0x48, 0xce, 0xa1, 0xc3, 0x60, 0xa2, 0xa2 } };

/**
@var MCNS_NetQualityInfoStorage	
@brief Consists of a structure that describes the network statistics, such as: incoming data rate, drops count and RTP jitter information.
@details 
<dl><dt>Type         : </dt>    <dd>VT_UINT_PTR	</dd></dl>      
<dl><dt>Available range	: </dt>	        <dd>						</dd></dl>   
<dl><dt>Default value: </dt>         <dd>Read only				</dd></dl>      
<dl><dt>Re-init: </dt>        <dd>No			</dd></dl>    
@hideinitializer
*/
static const GUID MCNS_NetQualityInfoStorage = { 0x7fefff7, 0xdcc5, 0x4f7f, { 0xa4, 0x48, 0xce, 0xa1, 0xc3, 0x60, 0xa2, 0xa2 } };

/**
@var MCNS_BufferingMode	
@brief 	Specifies the type of media data buffering
@details 
<dl><dt>Type         : </dt>    <dd>VT_UINT		</dd></dl>    
<dl><dt>Available range	: </dt>	        <dd>See BUFFERINGMODE		</dd></dl>   
<dl><dt>Default value: </dt>         <dd>EBufferingModeAuto		</dd></dl>     
<dl><dt>Re-init: </dt>        <dd>Yes		</dd></dl>   
@hideinitializer
*/
static const GUID MCNS_BufferingMode = { 0x8299e55b, 0xc3e2, 0x4f36, { 0x94, 0x9, 0xcb, 0xfe, 0xc, 0x43, 0xc2, 0x99 } };

/**
@var MCNS_UserDefinedBufferingTime
@brief Specifies time in milliseconds to buffer when user defined buffering mode is used
@details
<dl><dt>Type         : </dt>    <dd>VT_UI2		</dd></dl>    
<dl><dt>Available range	: </dt>	        <dd>[1, 10000]			</dd></dl>     
<dl><dt>Default value: </dt>         <dd>	1000				</dd></dl>    
<dl><dt>Re-init: </dt>        <dd>	Yes			</dd></dl>  
@hideinitializer
*/
static const GUID MCNS_UserDefinedBufferingTime = { 0x47244126, 0x6483, 0x483c, { 0xad, 0x56, 0xdf, 0x24, 0xf3, 0x68, 0x50, 0x46 } };

/**
@var MCNS_AuthParams					
@brief Specifies user name and password to use if authorization is requested
@details 
<dl><dt>Type         : </dt>    <dd>VT_UINT_PTR	</dd></dl>      
<dl><dt>Available range	: </dt>	        <dd>						</dd></dl>     
<dl><dt>Default value: </dt>         <dd>						</dd></dl>      
<dl><dt>Re-init: </dt>        <dd>No			</dd></dl>    
@hideinitializer
*/

static const GUID MCNS_AuthParams = { 0x7feabc4, 0xacc4, 0x4f8f, { 0xa4, 0x44, 0xce, 0xa4, 0xc4, 0x60, 0xa4, 0xa4 } };

/**
@var MCNS_EngineReady				
@brief Indicates state of the engine, applications should check this parameter before rendering any pin
@details 
<dl><dt>Type         : </dt>    <dd>VT_BOOL		</dd></dl>     
<dl><dt>Available range	: </dt>	        <dd>true, false			</dd></dl>   
<dl><dt>Default value: </dt>         <dd>	Read only			</dd></dl>    
<dl><dt>Re-init: </dt>        <dd>	No			</dd></dl>   
@hideinitializer
*/
static const GUID MCNS_EngineReady = { 0x3179306, 0xf6b2, 0x48c2, { 0xa7, 0xb0, 0xfd, 0x4, 0x9b, 0xba, 0x3d, 0x4 } };

/**
@var MCNS_SyncDeltaTime			
@brief Time in milliseconds to add to video samples timestamps to compensate permanent timestamp shift between audio and video streams
@details 
<dl><dt>Type         : </dt>    <dd>VT_UI4		</dd></dl>    
<dl><dt>Available range	: </dt>	        <dd>						</dd></dl>     
<dl><dt>Default value: </dt>         <dd>0						</dd></dl>     
<dl><dt>Re-init: </dt>        <dd>No			</dd></dl>    
@hideinitializer
*/
static const GUID MCNS_SyncDeltaTime = { 0x7428b735, 0xfd36, 0x4344, { 0xbc, 0xb1, 0xc6, 0xd3, 0x38, 0x4e, 0x79, 0x15 } };

/**
@var MCNS_EngineInitMode				
@brief Specifies engine initialization type
@details
<dl><dt>Type         : </dt>    <dd>VT_UINT		</dd></dl>     
<dl><dt>Available range	: </dt>	        <dd>See EngineInitMode	</dd></dl>   
<dl><dt>Default value: </dt>         <dd>	EngineSyncInit		</dd></dl>    
<dl><dt>Re-init: </dt>        <dd>	No			</dd></dl>    
@hideinitializer
*/
static const GUID MCNS_EngineInitMode = { 0xa025ab69, 0xa2e5, 0x4535, { 0x9f, 0xed, 0x37, 0x5e, 0xf6, 0x54, 0xf5, 0xa5 } };

/**
@var MCNS_UserAgent					
@brief Specifies RTSP User Agent string, which will be appended to each RTSP command
@details 
<dl><dt>Type         : </dt>    <dd>VT_BSTR		</dd></dl>     
<dl><dt>Available range	: </dt>	        <dd>						</dd></dl>  
<dl><dt>Default value: </dt>         <dd>"MainConcept"			</dd></dl>      
<dl><dt>Re-init: </dt>        <dd>No			</dd></dl>    
@hideinitializer
*/

static const GUID MCNS_UserAgent = { 0x102abb19, 0xa1a5, 0x4535, { 0x9f, 0xed, 0x37, 0x5e, 0xf6, 0x54, 0xf5, 0xa5 } };

/**
@var MCNS_KeepAliveMethod				
@brief Specifies which RTSP command to use as keep-alive message
@details
<dl><dt>Type         : </dt>    <dd>VT_UINT		</dd></dl>     
<dl><dt>Available range	: </dt>	        <dd>See KeepAliveMethod	</dd></dl>    
<dl><dt>Default value: </dt>         <dd>	EKeepAliveOptions	</dd></dl>      
<dl><dt>Re-init: </dt>        <dd>	No			</dd></dl>  
@hideinitializer
*/
static const GUID MCNS_KeepAliveMethod = { 0x2e959886, 0xedf5, 0x4751, { 0x91, 0x68, 0x5b, 0xde, 0x93, 0xac, 0x72, 0xa2 } };

/**
@var MCNS_ProxyURL				
@brief 	Specifies HTTP Proxy URL (default value "http://" is ignored)
@details 
<dl><dt>Type         : </dt>    <dd>VT_BSTR		</dd></dl>     
<dl><dt>Available range	: </dt>	        <dd>						</dd></dl> 
<dl><dt>Default value: </dt>         <dd>http://				</dd></dl>      
<dl><dt>Re-init: </dt>        	<dd>Yes		</dd></dl>    
@hideinitializer
*/
static const GUID MCNS_ProxyURL = { 0xc962edac, 0xb964, 0x43f7, { 0xba, 0xc1, 0x30, 0xd4, 0x67, 0xdd, 0x18, 0x4a } };

/**
@var MCNS_PlaylistItem			
@brief If MCNS_URI is set to M3U playlist video, then valid values will represent available playlist items, on write - uses specified item id to select current stream
@details
<dl><dt>Type         : </dt>    <dd>VT_UINT		</dd></dl>     
<dl><dt>Available range	: </dt>	        <dd>items in playlist		</dd></dl>   
<dl><dt>Default value: </dt>         <dd>0						</dd></dl>      
<dl><dt>Re-init: </dt>        <dd>Yes			</dd></dl>    
@hideinitializer
*/

static const GUID MCNS_PlaylistItem = { 0xb554531, 0xed37, 0x4977, { 0x8d, 0xcd, 0x86, 0x9c, 0x2, 0x87, 0x3, 0x69 } };

/**
@var MCNS_QualityItem				
@brief If MCNS_URI is set to HTTP Live streaming playlist, then valid values will represent available quality variants for program
@details 
<dl><dt>Type         : </dt>    <dd>VT_UINT		</dd></dl>     
<dl><dt>Available range	: </dt>	        <dd>quality index			</dd></dl>    
<dl><dt>Default value: </dt>         <dd>0						</dd></dl>      
<dl><dt>Re-init: </dt>        <dd>Yes			</dd></dl>    
@hideinitializer
*/
static const GUID MCNSP_QualityItem = { 0x64a484f2, 0x51ff, 0x45dc, { 0x80, 0xe0, 0x95, 0x3a, 0xdc, 0xe7, 0x4c, 0x7e } };

/**
@var MCNS_EnableAutoQualitySwithing				
@brief If MCNS_EnableAutoQualitySwithing is set to TRUE it enables autodetect bandwidth and choose stream quality adaptively
@details 
<dl><dt>Type         : </dt>    <dd>VT_BOOL		</dd></dl>     
<dl><dt>Available range	: </dt>	        <dd>quality TRUE <br> FALSE	</dd></dl>    
<dl><dt>Default value: </dt>         <dd>TRUE						</dd></dl>      
<dl><dt>Re-init: </dt>        <dd>No			</dd></dl>    
@hideinitializer
*/
static const GUID MCNS_EnableAutoQualitySwithing = { 0xee62b59, 0xee0e, 0x4696, { 0x85, 0x6a, 0x5e, 0x2b, 0xf0, 0x3, 0xb1, 0xab } };

/**
@var MCNS_HttpCacheMode			
@brief 	Specifies the type of HTTP buffering/caching when used as async file source
@details 
<dl><dt>Type         : </dt>    <dd>VT_UINT		</dd></dl>    
<dl><dt>Available range	: </dt>	        <dd>See HTTPCACHEMODE		</dd></dl>  
<dl><dt>Default value: </dt>         <dd>EHttpCacheInMemory		</dd></dl>     
<dl><dt>Re-init: </dt>        <dd>Yes		</dd></dl>  
@hideinitializer
*/
static const GUID MCNS_HttpCacheMode = { 0x74696942, 0xb93e, 0x46a3, { 0x86, 0x53, 0x3e, 0x57, 0x11, 0x91, 0xe, 0xc1 } };

/**
@var MCNS_SpecificSourceAddr		
@brief 	Specifies source/sender address to use as filter for incoming RTP packets. Set to 0.0.0.0 to disable filtering RTP packets by source address.
@details
<dl><dt>Type         : </dt>    <dd>VT_BSTR		</dd></dl>     
<dl><dt>Available range	: </dt>	        <dd>Set Source-Spec-Addr	</dd></dl>   
<dl><dt>Default value: </dt>         <dd>0.0.0.0				</dd></dl>     
<dl><dt>Re-init: </dt>        	<dd>No		</dd></dl>  
@hideinitializer
*/
static const GUID MCNS_SpecificSourceAddr = { 0x91d89b1d, 0xb259, 0x4361, { 0xaa, 0x92, 0x42, 0x94, 0x2a, 0xe, 0xe, 0x4 } };

/**
@var MCNS_SdpFileName				
@brief Writes current SDP buffer to specified file path
@details 
<dl><dt>Type         : </dt>    <dd>VT_BSTR		</dd></dl>      
<dl><dt>Available range	: </dt>	        <dd>					    </dd></dl>  
<dl><dt>Default value: </dt>         <dd>MCSdp.sdp				</dd></dl>     
<dl><dt>Re-init: </dt>        <dd>No			</dd></dl>   
@hideinitializer
*/
static const GUID MCNS_SdpFileName = { 0xd3190f70, 0xba78, 0x4857, { 0x84, 0xc5, 0x7c, 0x9d, 0x89, 0x6d, 0x29, 0x5c } };

/**
@var MCNS_SSRCChangesTracker		  
@brief Enables (true) or disables (false) RTP SSRC field changes.
@details  
When enabled - change in packet's SSRC field or big gap in RTP data will trigger graph flush and buffering restart.
When disabled - only Discontinuity flag will be set on samples.
<dl><dt>Type         : </dt>    <dd>VT_BOOL		</dd></dl>      
<dl><dt>Available range	: </dt>	        <dd>true,false			</dd></dl>      
<dl><dt>Default value: </dt>         <dd>    true				</dd></dl>     
<dl><dt>Re-init: </dt>        <dd>	No			</dd></dl> 
@hideinitializer
*/
static const GUID MCNS_SSRCChangesTracker = { 0xcf6e1333, 0xeab1, 0x49e4, { 0x82, 0x5c, 0x26, 0xf8, 0x62, 0x94, 0x7e, 0x4c } };

/**
@var MCNS_RTSPHeadersConformRFC	  
@brief Enables (true) or disables (false) RTSP headers syntax compatibility with RFC 2326.
@details  
When enabled, destination port in Transport header (in SETUP request) specified as 'port' in multicast receiving mode and 'client_port' in unicast.
When disabled - destination port specified only as 'client_port' in both modes (some buggy RTSP servers does not understand 'port').
<dl><dt>Type         : </dt>    <dd>VT_BOOL		</dd></dl>      
<dl><dt>Available range	: </dt>	        <dd>true,false			</dd></dl>      
<dl><dt>Default value: </dt>         <dd>    true				</dd></dl>     
<dl><dt>Re-init: </dt>        <dd>	No			</dd></dl> 
@hideinitializer
*/
static const GUID MCNS_RTSPHeadersConformRFC = { 0xbb067a28, 0xaad2, 0x46c6, { 0x95, 0x91, 0xe4, 0xa2, 0x4f, 0x28, 0xe4, 0xa8 } };

/**
@var MCNS_RTMPHandshakeParams			
@brief Used to set custom RTMP handshake keys and enable or disable key verification result validation
@details
<dl><dt>Type         : </dt>    <dd>VT_UINT_PTR	</dd></dl>     
<dl><dt>Available range	: </dt>	        <dd>						</dd></dl>    
<dl><dt>Default value: </dt>         <dd>NULL					</dd></dl>     
<dl><dt>Re-init: </dt>        <dd>No			</dd></dl>    
@hideinitializer
*/
static const GUID MCNS_RTMPHandshakeParams = { 0x5610cb6e, 0xf94e, 0x4fc1, { 0xb6, 0x55, 0x17, 0xfa, 0x24, 0xbc, 0x4d, 0x7a } };

/**
@var MCNS_EnableNegativeRateReporting
@brief Enables (true) or disables (false) reporting of negative rate values via new segment.
@details 
 Set it to false to avoid problems if none of downstream filters before renderer handle negative playback rates.
<dl><dt>Type         : </dt>    <dd>VT_BOOL		</dd></dl>   
<dl><dt>Available range	: </dt>	        <dd>true,false			</dd></dl>   
<dl><dt>Default value: </dt>         <dd>    true				</dd></dl>    
<dl><dt>Re-init: </dt>        <dd>	No			</dd></dl>   
@hideinitializer
*/
static const GUID MCNS_EnableNegativeRateReporting = { 0x7efd8fb0, 0x78b5, 0x415c, { 0xb6, 0xc4, 0xd3, 0x3c, 0x96, 0x3, 0xf5, 0x4e } };

/**
@var MCNS_IsStreamAvailable
@brief (true) UDP data is available (false) otherwise.
@details 
<dl><dt>Type         : </dt>    <dd>VT_BOOL		</dd></dl>   
<dl><dt>Available range	: </dt>	        <dd>true,false			</dd></dl>   
<dl><dt>Default value: </dt>         <dd>    false				</dd></dl>    
<dl><dt>Re-init: </dt>        <dd>	No			</dd></dl>   
@hideinitializer
*/
static const GUID MCNS_IsStreamAvailable = { 0xdadd7daa, 0xed31, 0x493b, { 0xb2, 0x53, 0x43, 0x77, 0x22, 0xfc, 0x1a, 0x3b } };

/**
@var MCNS_SendOptionsAfterDescribe
@brief (true) RTSP OPTIONS is sent after DESCRIBE to get the supported by the server command list (some cameras change state after DESCRIBE, others don't support OPTIONS after DESCRIBE).
@details 
<dl><dt>Type         : </dt>    <dd>VT_BOOL		</dd></dl>   
<dl><dt>Available range	: </dt>	        <dd>true,false			</dd></dl>   
<dl><dt>Default value: </dt>         <dd>    true				</dd></dl>    
<dl><dt>Re-init: </dt>        <dd>	No			</dd></dl>   
@hideinitializer
*/
static const GUID MCNS_SendOptionsAfterDescribe = { 0xe5bf869c, 0xc814, 0x4a3e, { 0x80, 0xca, 0x45, 0xff, 0x79, 0x78, 0x80, 0x2f } };

/**
@var MCNS_SharedSocketExchange
@brief Initiates socket sharing creation between Network Renderer and Network Source (components use the same socket instance). Shared socket descriptor is required to complete that (see @ref MCNS_SharedSocketInfo).
@details
<dl><dt>Type         : </dt>    <dd>VT_BOOL		</dd></dl>   
<dl><dt>Available range	: </dt>	        <dd>true,false			</dd></dl>   
<dl><dt>Default value: </dt>         <dd>    true				</dd></dl>    
<dl><dt>Re-init: </dt>        <dd>	No			</dd></dl>   
@hideinitializer
*/
static const GUID MCNS_SharedSocketExchange = { 0x9a2e1e3b, 0xbec, 0x48cf, { 0xae, 0x28, 0x6c, 0x1a, 0x9f, 0x7e, 0xe3, 0x45 } };

/**
@var MCNS_SharedSocketInfo			
@brief Returns a pointer to shared socket descriptor which required to create socket sharing 
@details
<dl><dt>Type         : </dt>    <dd>VT_UINT_PTR	</dd></dl>    
<dl><dt>Available range	: </dt>	        <dd>						</dd></dl>   
<dl><dt>Default value: </dt>         <dd>Read only				</dd></dl>     
<dl><dt>Re-init: </dt>        <dd>No			</dd></dl>   
@hideinitializer
*/
static const GUID MCNS_SharedSocketInfo = { 0xff3d2f4b, 0x3fd6, 0x46cf, { 0xa9, 0x59, 0x55, 0xf7, 0xc6, 0x5d, 0x9c, 0xb9 } };

/**
@var MCNS_EnableFLVMuxedStream
@brief Enables (true) or disables (false) receiving FLV as muxed stream.
@details 
 Set it to true to have FLV muxed stream from RTMP session instead of elementary streams. You should have FLV demultiplexer which can work Push mode.
<dl><dt>Type         : </dt>    <dd>VT_BOOL		</dd></dl>   
<dl><dt>Available range	: </dt>	        <dd>true,false			</dd></dl>   
<dl><dt>Default value: </dt>         <dd>    true				</dd></dl>    
<dl><dt>Re-init: </dt>        <dd>	Yes 	</dd></dl>   
@hideinitializer
*/
static const GUID MCNS_EnableFLVMuxedStream = { 0x6e67a235, 0xe850, 0x4eb5, { 0x8f, 0xdf, 0x38, 0xe8, 0xb7, 0x9e, 0xc0, 0x12 } };

/**
@var MCNS_RtcpPacket
@brief ReadOnly parameter for retrieving RTCP packets arriving from the RTP/RTSP server.
@details 
<dl><dt>Type         : </dt>    <dd>VT_UINT_PTR		</dd></dl>   
<dl><dt>Available range	: </dt>	        <dd>			</dd></dl>   
<dl><dt>Default value: </dt>         <dd>Read only				</dd></dl>    
<dl><dt>Re-init: </dt>        <dd>No 	</dd></dl>   
@hideinitializer
*/
static const GUID MCNS_RtcpPacket = { 0xb9a71c82, 0xf14c, 0x4c98, { 0x85, 0x66, 0xe9, 0x87, 0xdb, 0x29, 0x37, 0x8f } };

/**
@var MCNS_DecryptionKeyURI
@brief ReadOnly parameter which contains URI that specifies how to obtain the key for playback of encrypted HLS streams.
@details 
<dl><dt>Type         : </dt>    <dd>VT_BSTR		</dd></dl>       
<dl><dt>Available range	: </dt>	        <dd>						</dd></dl>    
<dl><dt>Default value: </dt>         <dd>Read only				</dd></dl>      
<dl><dt>Re-init: </dt>        <dd>No			</dd></dl>    
@hideinitializer
*/
static const GUID MCNS_DecryptionKeyURI = { 0x983aa0ae, 0xf708, 0x4a64, { 0xac, 0xd0, 0x41, 0xad, 0x6f, 0xbf, 0x1, 0xbd } };

/**
@var MCNS_DecryptionKey		
@brief 	A hex string which specifies 128-bit key for playback of encrypted HLS streams.
@details
<dl><dt>Type         : </dt>    <dd>VT_BSTR		</dd></dl>     
<dl><dt>Available range	: </dt>	        <dd>sixteen hex digits with value from 00 to FF</dd></dl>   
<dl><dt>Default value: </dt>         <dd>00000000000000000000000000000000</dd></dl>     
<dl><dt>Re-init: </dt>        	<dd>Yes		</dd></dl>  
@hideinitializer
*/
static const GUID MCNS_DecryptionKey = { 0xd6b81b22, 0xb933, 0x42ac, { 0xa0, 0x41, 0xbb, 0xee, 0x6c, 0x78, 0xe0, 0xc8 } };


#endif //__NETWORKSOURCE_PROPID_HEADER__
