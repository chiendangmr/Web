/**
@file   net_renderer_rtmp.h
@brief  NetRenderer/RTMP Server API

@verbatim
File: net_renderer_rtmp.h
Desc: NetRenderer/RTMP Server API 

Copyright (c) 2014 MainConcept GmbH or its affiliates.  All rights reserved.

MainConcept and its logos are registered trademarks of MainConcept GmbH or its affiliates.  
This software is protected by copyright law and international treaties.  Unauthorized 
reproduction or distribution of any portion is prohibited by law.
@endverbatim
**/

#if !defined (__NETRENDERER_RTMP_API_H__)
#define __NETRENDERER_RTMP_API_H__

#include "mctypes.h"
#include "parser_sdp.h"
#include "net_renderer.h"
#include "rtmp_object_api.h"

#include "mcapiext.h"

#if defined DEFAULT_RTMP_PORT
    #undef DEFAULT_RTMP_PORT
#endif

/**
* @brief Defines default RTMP network port
* @hideinitializer
**/
#define DEFAULT_RTMP_PORT 1935

/**
* namespace MainConcept
* @brief Global SDK namespace
**/
namespace MainConcept {

    /**
    * namespace NetworkStreaming
    * @brief Network streaming specific namespace
    **/
    namespace NetworkStreaming {

        /**
        * @brief Available RTMP server engine parameters
        **/
        typedef enum _tagRtmpServerParamID {

            RtmpEos                 = 0x00,                         /**< End of Stream reached, int64_t: client ID */
            RtmpMaxClientsCount,                                    /**< Maximum client count, int32_t: maximux count of client  */
            RtmpConnectionTimeout,                                  /**< Time for waiting before break connection, int32_t: seconds */
            RtmpHandshakeKeys,                                      /**< RTMP handshake validation keys, @ref RtmpHandshakeKeyStorage pair of memory buffers */
			RtmpStartPublishStream,                                 /**< Parameters for start publishing stream, @ref RtmpPublishDescription*/
			RtmpStopPublishStream,                                  /**< Parameters for stop publishing, @ref RtmpPublishDescription */
            RtmpUserAgent,                                          /**< User Agent, server ID string, const int8_t* : Null-terminated string */
        } RtmpServerParamID;

        /**
        * @brief Describes stream and settings for publish mode
        */
        typedef struct _tagRtmpPublishDescription {

            const char* pStream;                                  /**< Stream name for publish and playing. It will be translated to IRtmpGraphController::OnPlay(...)*/
            const char* pUrl;                                     /**< Remote server media URL for publishing */
            const char* pNIC;                                     /**< Prefferable network interface or NULL or 0.0.0.0 for system default*/
            const char* pUserName;								/**< Plain text UserName */
            const char* pPassword;								/**< Plain text Password */
        } RtmpPublishDescription;

        /**
        * @brief RTMP server result code
        **/
        typedef enum _tagRtmpServerResult {

            ServerRtmpOk                = 0x00,                     /**< Operation complete successful */
            ServerRtmpError,                                        /**< Operation failed */
            ServerRtmpInitSocketError,                              /**< Socket initialization error */
            ServerRtmpInitPortBusyError,                            /**< Socket port is busy */
            ServerRtmpServerInitError,                              /**< Common server initialization error */
            ServerRtmpNotImplemented,                               /**< Operation or property is not implemented */
			ServerRtmpAuthRequested,                                /**< Authorization requested to complete an action */
            ServerRtmpSendSocketError,                              /**< Socket sending error */
            ServerRtmpHandshakeFailedVerification                  /**< Rtmp handshake verification failed */
        } RTMPSERVERRESULT;

         /**
        * @brief CDN Authorization parameters
        **/
        typedef struct _tagRTMPAUTHINFO {

            char* pUsername;                                      /** User name for login*/
            char* pPassword;                                      /** Password*/
        } RTMPCREDENTIALS;

        /**
        * @brief Media graph builder interface
        * 
        * Used for control media playback, delivering data to sender
        **/
        class IRtmpGraphController : public INetRefCounted
        {
        public:
            virtual ~IRtmpGraphController() {}

            /**
            * @brief Sets external RTMP sender for base network renderer component from graph
            * 
            * @param[in] pSender valid pointer to data sender
            * @return            Return @ref RTMPSERVERRESULT 
            **/
            virtual RTMPSERVERRESULT OnSetSender( const IUniversalDataSender* pSender ) = 0;

            /**
            * @brief Starts playback
            * 
            * @param[in]  pStreamName name of requested stream
            * @param[in,out]  iStartTime  start position of playback
            * @param[in,out]  iStopTime   stop position of playback
            * @param[in]  bIsReset    if true - requested stream is added to new playlist, 
            *                           otherwise requested stream is added to current playlist
            *                           without immediately playback
            * @param[out] iDuration   duration requested stream in 100-nanosec units 
            * @return                 Return @ref RTMPSERVERRESULT
            **/
            virtual RTMPSERVERRESULT OnPlay( const char* pStreamName, int64_t *iStartTime, int64_t *iStopTime, bool bIsReset, int64_t* iDuration ) = 0;

            /**
            * @brief Toggles play/pause
            * 
            * @param[in] bIsPause       true - toggles to pause, false - toggle to normal play
            * @param[in] iPausePosition position of toggling mode
            * @return                   Return @ref RTMPSERVERRESULT
            **/
            virtual RTMPSERVERRESULT OnTogglePause( bool bIsPause, int64_t iPausePosition ) = 0;

            /**
            * @brief Seeks in the stream
            * 
            * @param[in]  iSeekPosition   preferable new start position
            * @param[out] iActualPosition iActualPosition actual new start position
            * @return                     Return @ref RTMPSERVERRESULT
            **/
            virtual RTMPSERVERRESULT OnSeek( int64_t iSeekPosition, int64_t* iActualPosition ) = 0;

            /**
            * @brief Used for process unknown clients command
            * 
            * @param[in]  pCommandName   command name
            * @param[in]  pCommandObject command's main argument (value depends on command)
            * @param[in]  pOptional      command's additional argument (value depends on command)
            * @param[out] pResponse      result of invoking command (depends on command)
            * @return                    Return @ref RTMPSERVERRESULT
            **/
            virtual RTMPSERVERRESULT OnCall( const char* pCommandName, const IRtmpObject* pCommandObject, const IRtmpObject* pOptional, IRtmpObject* pResponse ) = 0;

            /**
            * @brief Invokes RTMP Play2 command(switch between streams) 
            * 
            * @param[in] pOldStreamName currently playback stream
            * @param[in] pStreamName    new requested stream name
            * @param[in] pTransition    type of switching( switch or swap mode ) 
            *                           - switch:Performs multi-bitrate streaming by switching 1-bit rate
            *                               version of a stream to another.
            *                           - swap: Replaces the value in @a oldStreamName with the value in 
            *                               @a streamName, and stores the remaining playlist queue as is.)
            * @param[in] pStartTime     start position of playback
            * @param[out] pDuration     duration of stream
            * @return                   Return @ref RTMPSERVERRESULT
            **/
            virtual RTMPSERVERRESULT OnPlay2( const int8_t* pOldStreamName, const int8_t* pStreamName, const int8_t* pTransition, int64_t pStartTime, int64_t* pDuration ) = 0;

            /**
            * @brief Stops playback
            * 
            * @return Return @ref RTMPSERVERRESULT 
            **/
            virtual RTMPSERVERRESULT OnStop() = 0;

            /**
            * @brief Stops playback on close connection
            * 
            * @return Return @ref RTMPSERVERRESULT 
            **/
            virtual RTMPSERVERRESULT OnClose() = 0;

            /**
            * @brief Reached on RTMP SetBufferLength command
            * 
            * @param[in] bufferLength preferable time buffer size in milliseconds
            * @return                 Return @ref RTMPSERVERRESULT 
            **/
            virtual RTMPSERVERRESULT OnBufferLength(uint32_t bufferLength) = 0;

             /**
            * @brief Reached on remote CDN server auth request for publish mode
            * 
            * @param[in]  pUrl      publish url
            * @param[out] pAuthInfo credentials
            * @return               Return @ref RTMPSERVERRESULT 
            **/
            virtual MainConcept::NetworkStreaming::RTMPSERVERRESULT OnAuthRequest( const uint8_t* pUrl, MainConcept::NetworkStreaming::RTMPCREDENTIALS * const pAuthInfo ) = 0;
        };

        /**
        * @brief RTMP server instance interface
        **/
        class IRtmpServerEngine : public INetRefCounted
        {
        public:
            virtual ~IRtmpServerEngine() {}

            /**
            * @brief Initializes server instance
            * 
            * @param[in] aPort server's port
            * @param[in] aNIC  used local network interface
            * @return          Return @ref RTMPSERVERRESULT
            **/
            virtual RTMPSERVERRESULT Init( int32_t aPort = DEFAULT_RTMP_PORT, const char *aNIC = NULL ) = 0;

            /**
            * @brief Starts server working
            * 
            * @return Return @ref RTMPSERVERRESULT 
            **/
            virtual RTMPSERVERRESULT Start() = 0;

            /**
            * @brief  Configures engine instance
            * 
            * @param[in] uiParamId    RTMP server parameter, @ref RtmpServerParamID
            * @param[in] pParam       value of parameter, representation depends on uiParamId value
            * @param[in] uiParamSize  size of parameter value or string length
            * @return                 Return @ref RTMPSERVERRESULT
            **/
            virtual RTMPSERVERRESULT SetParameter( RtmpServerParamID uiParamId, const void *pParam, uint32_t uiParamSize ) = 0;

            /**
            * @brief Forces client disconnection 
            *  
            * @param[in] ID unique client id
            * @return       None
            **/
            virtual void ForceKillClient( int64_t ID ) = 0;
        };

        /**
        * @brief Observer for application level (for logging and etc..)
        * 
        * Observes events with clients connection
        **/
        class IRtmpClientsObserver
        {
        public:
            virtual ~IRtmpClientsObserver() {}

            /**
            * @brief Called on max clients count reached
            * 
            * @return None
            **/
            virtual void OnClientsCountOverflow() = 0;

            /**
            * @brief Called on new client connection
            * 
            * @param[in] ID              unique identifier of new client
            * @param[in] pClientsAddress client network address
            * @return                    None
            **/
            virtual void OnNewClientConnection( int64_t ID, const char *pClientsAddress ) = 0;

            /**
            * @brief Called on any client disconnect or at loss connection with
            * 
            * @param[in] ID client identifier which lost connection
            * @return       None
            **/
            virtual void OnClientDisconnect( int64_t ID ) = 0;

            /**
            * @brief Called on any commands data pass
            * 
            * @param[in] ID                peer for data
            * @param[in] pBuff             passed data
            * @param[in] iLen              size of passed data
            * @param[in] bIsServerResponse indicates data direction, true - from server to client, false - otherwise
            * @return                      None
            **/
            virtual void OnData( int64_t ID, const uint8_t *pBuff, int32_t iLen, bool bIsServerResponse ) = 0;
        };

        /**
        * @brief Listener observer (application level)
        * 
        * Observes engine events
        **/
        class IRtmpServerObserver
        {
        public:
            virtual ~IRtmpServerObserver() {}

            /**
            * @brief Server engine started successful
            * 
            * @return None
            **/
            virtual void OnServerStartup() = 0;

            /**
            * @brief Server engine stopped successful
            * 
            * @return None
            **/
            virtual void OnServerClose() = 0;

            /**
            * @brief Requests media graph controller for new arrived client
            * 
            * @param[in]  ID           unique client id
            * @param[out] ppController pointer to pointer to implementation of IRtmpMediaGraphController
            * @return                  None
            **/
            virtual void RequestRtmpControllerInterface( int64_t ID, const IRtmpGraphController **ppController ) = 0;
        };

#if defined (__cplusplus)
        extern "C" {
#endif
            /**
            * @brief Retrieves new RTMP server engine instance
            * 
            * @param[in] get_rc            Pointer to get_rc memory manager implementation or NULL to use standard allocators
            * @param[in] pListenerObserver Pointer to main server observer
            * @param[in] pObserver         Pointer to clients connection observer
            * @return                      Valid pointer to server engine
            **/
            IRtmpServerEngine  * NET_API_CALL GetRtmpServerInterface( void *(MC_EXPORT_API *get_rc)(const char*), IRtmpServerObserver *pListenerObserver, IRtmpClientsObserver *pObserver = NULL );

            /**
            * @brief Retrieves new RTMP Network Renderer component instance
            * 
            * @param[in] get_rc Pointer to get_rc memory manager implementation or NULL to use standard allocators
            * @return           Valid pointer to new instance of network renderer component or NULL
            **/
            INetRendererEngine * NET_API_CALL GetRtmpRendererInterface( void *(MC_EXPORT_API *get_rc)(const char*) );
#if defined (__cplusplus)
        }
#endif
    };
};

#endif
