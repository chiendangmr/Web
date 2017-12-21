/**
@file   net_source_rtmp.h 
@brief  RTMP streaming engine API

@verbatim
File: net_source_rtmp.h 
Desc: RTMP streaming engine API 

Copyright (c) 2015 MainConcept GmbH or its affiliates.  All rights reserved.

MainConcept and its logos are registered trademarks of MainConcept GmbH or its affiliates.  
This software is protected by copyright law and international treaties.  Unauthorized 
reproduction or distribution of any portion is prohibited by law.
@endverbatim
**/

#if !defined (__MC_RTMP_CLIENT_API_H__)
#define __MC_RTMP_CLIENT_API_H__

#include "net_source.h"
#include "rtmp_object_api.h"

/**
* @def DEFAULT_RTMP_PORT
* @brief Standard RTMP port
* @hideinitializer
**/
#if !defined(DEFAULT_RTMP_PORT)
    #define DEFAULT_RTMP_PORT 1935
#endif

/**
* @brief Predefined by RTMP specification v1.0 for trying first live stream, then recorded
* @hideinitializer
**/
#define RTMP_STARTTIME_LIVE_AND_RECORDED -2000.0

/**
* @brief Predefined by RTMP specification v1.0 for trying live stream only
* @hideinitializer
**/
#define RTMP_STARTTIME_LIVE_ONLY -1000.0

/**
* @brief Predefined by RTMP specification v1.0 for unlimited play duration
* @hideinitializer
**/
#define RTMP_DURATION_UNLIMITED -1000.0

/**
* @brief Predefined by RTMP specification v1.0 for play single frame only
* @hideinitializer
**/
#define RTMP_DURATION_SINGLE_FRAME 0.0

/**
* @brief Switch to other quality
* @hideinitializer
**/
#define RTMP_TRANSITION_SWITCH "switch"

/**
* @brief Switch as soon as possible to other stream
* @hideinitializer
**/
#define RTMP_SWITCH_OFFSET -1000.0

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
        * @brief Describes return code from RTMP client engine
        **/
        typedef enum _tagRtmpClientResult {

            ClientRtmpOk                = 0x00,                     /**< Operation completed successful */
            ClientRtmpError,                                        /**< Operation failed */
            ClientRtmpInitSocketError,                              /**< Socket init failed */
            ClientRtmpInitPortBusyError,                            /**< Port is busy */
            ClientRtmpBindSocketError,                              /**< Bind socket failed */
            ClientRtmpConnectError,                                 /**< Connection failed */
            ClientRtmpClientInitError,                              /**< Initialization failed */
            ClientRtmpNotImplemented,                               /**< Operation is not implemented */
            ClientRtmpBadArgument,                                  /**< NULL argument */ 
            ClientRtmpStreamUnsupported,                            /**< Stream is not supported */
            ClientRtmpInvalidState,                                 /**< Engine is in incorrect state for this operation */
            ClientRtmpSendError,                                    /**< Error during sending data */
            ClientRtmpTimeout,                                      /**< Network timeout */
            ClientRtmpUnknownResult,                                /**< Server return unknown result */
            ClientRtmpValidationError,                              /**< Handshake validation failed */
			ClientRtmpRequestedAuthorization						/**< Operation requires authorization */
        } RTMPCLIENTRESULT;                                               

        /**
        * @brief Declares RTMP callback interface
        **/
        class IRtmpObserver
        {
        public:
            virtual ~IRtmpObserver() {}

            /**
            *@brief This method is called when custom RTMP command is received from server
            *
            *@param[in]  pCommandName   name of remote procedure 
            *@param[in]  pCommandObject main argument of remote procedure
            *@param[in]  pOptional      optional parameter for remote procedure
            *@param[out] pResponse      object contains result of invoking remote procedure 
            *@return                    Return @ref RTMPCLIENTRESULT
            **/
            virtual RTMPCLIENTRESULT OnCall( const char* pCommandName, const IRtmpObject* pCommandObject, const IRtmpObject* pOptional, IRtmpObject* pResponse ) = 0;
        };

        /**
        * @brief RTMP client engine interface (Adobe Flash Streaming: AVC, AAC, MP3, FLV)
        **/
        class IRtmpClient : public INetRefCounted
        {
        public:
            virtual ~IRtmpClient() {}

            /** 
            * @brief Do RTMP handshake
			*
			* This method initializes RTMP connection
            *
            * @param[in] pStreamUrl                  Stream URL
            * @return                                Return @ref RTMPCLIENTRESULT
            **/
            virtual RTMPCLIENTRESULT Init( const char* pStreamUrl ) = 0;

            /** 
            * @brief Invoke Play command

            * @param[in] pStreamUrl                  Stream URL
            * @param[in] fStartTimeInSeconds         start position (available values: 0, any positive value, @ref RTMP_STARTTIME_LIVE_ONLY, @ref RTMP_STARTTIME_LIVE_AND_RECORDED)
            * @param[in] fRequestedDurationInSeconds duration (available values: any positive value, @ref RTMP_DURATION_SINGLE_FRAME, @ref RTMP_DURATION_UNLIMITED)
            * @return                                Return @ref RTMPCLIENTRESULT
            **/
            virtual RTMPCLIENTRESULT Play( double fStartTimeInSeconds, double fRequestedDurationInSeconds ) = 0;

            /** 
            * @brief This method represents RTMP Play2 command.
            *
            * @param[in] pStreamUrl                  specified stream name to switching
            * @param[in] pTransition                 specified switched mode: switch or swap
            * @param[in] fSwitchTimeInSeconds        specified switch time relative to current stream begin
			* @param[in] fStartTimeInSeconds         start position (available values: 0, any positive value, @ref RTMP_STARTTIME_LIVE_ONLY, @ref RTMP_STARTTIME_LIVE_AND_RECORDED)
			* @param[in] fRequestedDurationInSeconds duration (available values: any positive value, @ref RTMP_DURATION_SINGLE_FRAME, @ref RTMP_DURATION_UNLIMITED)
            * @return                                Return @ref RTMPCLIENTRESULT
            **/
            virtual RTMPCLIENTRESULT Play2( const char* pStreamUrl, const char* pTransition, double fSwitchTimeInSeconds, double fStartTimeInSeconds, double fRequestedDurationInSeconds ) = 0;

            /** 
            * @brief This method toggles pause mode
            *
            * @param[in] bIsPause                     on/off pausing
            * @param[in] fPausePositionInMilliseconds specify timestamp to resume from, pass -1 to use last sample time sent to consumer
            * @return                                 Return @ref RTMPCLIENTRESULT
            **/
            virtual RTMPCLIENTRESULT Pause( bool bIsPause, double fPausePositionInMilliseconds ) = 0;

            /** 
            * @brief This method seeks to specified time
            *
            * @param[in] fSeekPositionInMilliseconds specifies new playback position 
            * @return                                Return @ref RTMPCLIENTRESULT
            **/
            virtual RTMPCLIENTRESULT Seek( double fSeekPositionInMilliseconds ) = 0;

            /** 
            * @brief This method invokes remote procedure
            *
            * @param[in]  pCommandName   name of remote procedure
            * @param[in]  pCommandObject main argument
            * @param[in]  pOptional      optional argument
            * @param[out] pResponse      object for remote response
            * @return                    Return @ref RTMPCLIENTRESULT
            **/
            virtual RTMPCLIENTRESULT Call( const char* pCommandName, const IRtmpObject* pCommandObject, const IRtmpObject* pOptional, IRtmpObject* pResponse ) = 0;

            /** 
            * @brief This method closes connection.
            *
            * @return Return @ref RTMPCLIENTRESULT
            **/
            virtual RTMPCLIENTRESULT Close() = 0;

            /** 
            * @brief This method allows set up local network interface
            *
            * @param[in] aNIC specifies local network interface or NULL for system default
            * @return         None
            **/
            virtual void SetNIC( const char *aNIC = NULL ) = 0;

            /** 
            * @brief This method specifies waiting time for server response
            *
            * @param[in] aTimeOut value of timeout at seconds
            * @return             None
            **/
            virtual void SetTimeout( int32_t aTimeOut = 0 ) = 0;

            /** 
            * @brief This method allows to enable demultiplexing FLV packets to elementary streams
            *
            * @param[in] bDemuxFLV true/false - enable/disable elementary media
            * @return              None
            **/
            virtual void SetFLVMode( bool bDemuxFLV ) = 0;

            /** 
            * @brief This method allows to set up client buffer length, reported to server
            *
            * @param[in] uiBufferLengthInMilliseconds buffering time in milliseconds
            * @return                                 None
            **/
            virtual void SetBufferLength( uint32_t uiBufferLengthInMilliseconds ) = 0;

            /** 
            * @brief This method allows to use custom handshake validation keys
            *
            * @param[in] pKeyStorage            pair of validation keys
            * @return None
            **/
            virtual void SetHandshakeKeys(const RtmpHandshakeKeyStorage* const pKeyStorage ) = 0;

            /** 
            * @brief Setup user agent string
            * 
            * @param[in] pUserAgent pointer to zero-terminated user agent string
            * @return None
            **/
            virtual void SetUserAgent(const char* pUserAgent) = 0;

            /** 
            * @brief This method gets stream duration
            *
            * @return stream duration in milliseconds
            **/
            virtual double GetDuration() const = 0;

            /** 
            * @brief This method gets engine state
            *
            * @return @ref MCNETENGINESTATUS
            **/
            virtual MCNETENGINESTATUS GetState() const = 0;

            /** 
            * @brief This method allows to set up external observer
            *
            * @param pObserver pointer to @ref IRtmpObserver implementation
            **/
            virtual void SetRtmpObserver( const IRtmpObserver *pObserver ) = 0;

            /** 
            * This method gets time of last received packet
            * 
            * @return timestamp of last received packet 
            **/
            virtual int64_t GetLastServerTime() const = 0;

			/** 
            * @brief Setup authorization credential
            * 
            * @param[in] aParameters pointer to @ref AUTHORIZATIONFIELD
            * @return                Returns @ref MCNetResultOK on success and error code otherwise
            **/
            virtual MCNETRESULT SetAuthorization( AUTHORIZATIONFIELD *aParameters ) = 0;
        };

#if defined (__cplusplus)
        extern "C" {
#endif
            /** 
            * @brief This method creates an instance of RTMP client engine
            *
            * @param[in] pStreamCreator valid pointer on RTMP stream creator
            * @param[in] get_rc         Pointer to get_rc memory manager implementation or NULL to use standard allocators
            * @return                   Returns valid pointer to @ref IRtmpClient on success and NULL when failed
            **/
            IRtmpClient* NET_API_CALL GetRTMPClientInterface( INetStreamCreator *pStreamCreator, void *(MC_EXPORT_API *get_rc)(const char*) );
#if defined (__cplusplus)
        }
#endif
    };
};

#endif //__MC_RTMP_CLIENT_ENGINE_API_H__
