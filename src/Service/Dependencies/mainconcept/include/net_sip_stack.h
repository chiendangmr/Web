/**
@file  net_sip_stack.h
@brief SIP Stack API

@verbatim
File: net_sip_stack.h
Desc: SIP Stack API

Copyright (c) 2014 MainConcept GmbH or its affiliates.  All rights reserved.

MainConcept and its logos are registered trademarks of MainConcept GmbH or its affiliates.  
This software is protected by copyright law and international treaties.  Unauthorized 
reproduction or distribution of any portion is prohibited by law.
@endverbatim
**/

#if !defined (__MC_SIP_STACK_API_H__)
#define __MC_SIP_STACK_API_H__

#include "mctypes.h"
#include "parser_sdp.h"
#include "net_common.h"

#if defined ( __SYMBIAN32__ )
    #if defined (SIP_STACK_EXPORTS)
        #define SIP_STACK_API EXPORT_C
    #else
        #define SIP_STACK_API IMPORT_C
    #endif
#else

#include "mcapiext.h"

/**
 * @def SIP_STACK_API
 * @brief Defines calling convention
 * @hideinitializer
 **/
    #if defined(WIN32)
        #define SIP_STACK_API __cdecl
    #else
        #define SIP_STACK_API
    #endif
#endif

/**
* @brief Default SIP network port
* @hideinitializer
**/
#define STANDARD_SIP_PORT 5060

/**
* @brief Limit the number of proxies or gateways that can forward the request to the next downstream server
* @hideinitializer
**/
#define SIP_MAX_FORWARDS 70

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
         * @brief Describes SIP engines result codes
         **/
        typedef enum _tagSipEngineErrCodes {

            ESipOK              = 0,                                /**< Operation complete successful */
            ESipFailed,                                             /**< Operation failed */
            ESipNotImplemented,                                     /**< Operation is not implemented */
            ESipNotFound,                                           /**< Session is not found */
            ESipInvalidArgument                                     /**< Argument value is not allowed or NULL */
        } SIPENGINEERRCODES;                                         
                                                                     
        /**                                                          
         * @brief Standard SIP requests                              
         **/                                                         
        typedef enum _tagSipRequestTypes {                           
                                                                     
            ESipRequestUnknown  = 0,                                /**< Unknown request, invalid state */
            ESipRequestInvite,                                      /**< Initialize new session and send Invite request */
            ESipRequestAck,                                         /**< Invitation accepted */
            ESipRequestBye,                                         /**< End session */
            ESipRequestRegister,                                    /**< Register with SIP gateway */
            ESipRequestCancel                                       /**< Abort current operation */
        } SIPREQUESTTYPES;                                           
                                                                     
        /**                                                          
         * @brief Standard SIP response code                         
         **/                                                         
        typedef enum _tagSipResponseCodes {                          
                                                                     
            ESipResponseUnknown        =   0,                       /**<  Unknown code, stubs*/
            ESipResponseTrying         = 100,                       /**<  Some unspecified action is being taken on behalf of this call (e.g.,
                                                                            a database is being consulted), but the user has not yet been located*/
            ESipResponseRinging        = 180,                       /**< The called user agent has located a possible location where the user
                                                                            has registered recently and is trying to alert the user */
            ESipResponseOK             = 200,                       /**< The request has succeeded */
            ESipResponseBusy           = 486,                       /**< The callee's end system was contacted successfully but the callee is
                                                                            currently not willing or able to take additional calls. */
            ESipResponseTerminated     = 487,                       /**< The request has cancelled */
            ESipResponseNotAcceptable  = 488,                       /**< Not available gateway with matched codec */
            ESipResponseNotImplemented = 501                        /**< Peer does not implement requested operation */
        } SIPRESPONSECODES;                                          
                                                                     
        /**                                                          
         * @brief Protocol of delivery SIP messages                         
         **/                                                         
        typedef enum _tagSipTransportType {                          
                                                                     
            sipTransportUnknown = 0,                                /**< Stubs value */
            sipTransportUDP,                                        /**< SIP over UDP */
            sipTransportTCP                                         /**< SIP over TCP */
        } SIPTRANSPORTTYPE;                                          
                                                                     
        /**                                                          
         * @brief Properties of Invitation                                  
         **/                                                         
        typedef struct _tagSipInviteParams {                         
                                                                     
            SIPTRANSPORTTYPE TransportType;                         /**< Transport protocol for SIP */ 
            char*            pRecipient;                            /**< Callee contact information (optional) */
            char*            pFrom;                                 /**< Caller SIP indicator */
            char*            pTo;                                   /**< Callee SIP indicator */
            char*            pContact;                              /**< Caller contact information (optional) */
        } SIPINVITEPARAMS;                                           
                                                                     
        /**                                                          
         * @brief Describes SIP End-Point                                   
         **/                                                         
        typedef struct _tagSipEndPoint {                             
                                                                     
            char*            pRequestAddress;                       /**< host address(as last part of SIP URI) */
            char*            pViaHost;                              /**< Closest SIP host for request/response */
            char*            pBranch;                               /**< branch field value */
            char*            pLogicalAddress;                       /**< actual SIP address */
            char*            pTag;                                  /**< tag field value */
            char*            pContactAddress;                       /**< contact address for future calls */
            char*            pUserAgent;                            /**< user-agent string */
            char*            pCSeq;                                 /**< current command sequence number */
                                                                     
            SIPRESPONSECODES PreviousResponse;                      /**< previous handled response */
            SIPREQUESTTYPES  PreviousRequest;                       /**< previous handled request */
                                                                     
            SIPRESPONSECODES LastResponse;                          /**< current handling response */
            SIPREQUESTTYPES  LastRequest;                           /**< current handling request */
        } SIPENDPOINT;

        class ISipSession;

        /**
         * @brief Interface for remote client request handling (have to be implemented at application level)
         **/
        class ISipClientHandler : public INetRefCounted
        {
        public:
            virtual ~ISipClientHandler() {}

            /**
             * @brief Called on incoming SIP request 
             * 
             * @param[in] pSessionDescriptor current active session
             * @param[in] aRequestType       type of incoming request
             * @param[in] pSdp               describes current session or NULL in case of session yet established
             * @return                       Return @ref SIPENGINEERRCODES
             **/
            virtual SIPENGINEERRCODES OnSipRequest( ISipSession *pSessionDescriptor, SIPREQUESTTYPES aRequestType, const ISdpDecoder *pSdp ) = 0;

            /**
             * @brief Called on incoming remote SIP response
             * 
             * @param[in] pSessionDescriptor current active session
             * @param[in] aResponseCode      response result code
             * @param[in] pSdp               SDP document, describe new active session or NULL
             * @return                       Return @ref SIPENGINEERRCODES
             **/
            virtual SIPENGINEERRCODES OnSipResponse( ISipSession *pSessionDescriptor, SIPRESPONSECODES aResponseCode, const ISdpDecoder *pSdp ) = 0;

            /**
             * @brief Called on authentication request
             * 
             * @param[in]  pSessionDescriptor active session descriptor
             * @param[in]  pRealm             requested realm
             * @param[out] pLogin             user login
             * @param[out] pPassword          password
             * @return                        Return @ref SIPENGINEERRCODES
             **/
            virtual SIPENGINEERRCODES OnAuthentication( ISipSession *pSessionDescriptor, char *pRealm, char *pLogin, char *pPassword ) = 0;

            /**
             * @brief Called after Invite was successfully sent and new session is initialized
             * 
             * @param[in] pSessionDescriptor active session descriptor
             * @return                       Return @ref SIPENGINEERRCODES 
             **/
            virtual SIPENGINEERRCODES OnOutgoingCall( ISipSession *pSessionDescriptor ) = 0;

            /**
             * @brief Called on session destroying
             * 
             * @param[in] pSessionDescriptor active session which destroying
             * @return                       Return @ref SIPENGINEERRCODES
             **/
            virtual SIPENGINEERRCODES OnSessionDestroy( ISipSession *pSessionDescriptor ) = 0;
        };

        /**
         * @brief Declares SIP session object
         **/
        class ISipSession : public INetRefCounted
        {
        public:
            virtual ~ISipSession() {}

            /**
             * @brief Retrieves client, associated with current session
             * 
             * @return valid pointer to @ref ISipClientHandler 
             **/
            virtual ISipClientHandler *GetClientHandler() const = 0;

            /**
             * @brief Retrieves session transport protocol
             * 
             * @return Return @ref SIPTRANSPORTTYPE 
             **/
            virtual SIPTRANSPORTTYPE GetTransportType() const = 0; 

            /**
             * @brief Signals about session direction
             * 
             * @return true - if session is incoming, false - otherwise 
             **/
            virtual bool IsIncomingSession() const = 0;

            /**
             * @brief Signals about handshake state
             * 
             * @return true - if handshake finished, session established, false - handshake is in process 
             **/
            virtual bool IsHandshakeFinished() const = 0;

            /**
             * @brief Retrieves local end-point
             * 
             * @return valid pointer to @ref SIPENDPOINT 
             **/
            virtual const SIPENDPOINT* GetLocalEndPoint() const = 0;

            /**
             * @brief Retrieves remote end-point
             * 
             * @return valid pointer to @ref SIPENDPOINT 
             **/
            virtual const SIPENDPOINT *GetRemoteEndPoint() const = 0;

            /**
             * @brief Retrieves maximum forward count
             * 
             * @return maximum forward count 
             **/
             virtual uint32_t GetMaxForwards() const = 0;

            /**
             * @brief Retrieves current Call-ID
             * 
             * @return current Call-ID string
             **/
            virtual const char* GetCallID() const = 0;

            /**
             * @brief Retrieves remote peer network info
             * 
             * @return remote network peer info
             **/
            virtual const sockaddr_storage* GetPeer() const = 0;
        };

        /**
         * @brief That interface is used by ISipStack for remote client handler creation (have to be implemented at application level)
         **/
        class ISipClientHandlerFactory : public INetRefCounted
        {
        public:
            virtual ~ISipClientHandlerFactory() {}

            /**
             * @brief Creates instance of ISipClientHandler implementation
             * 
             * @param[out] pHandler pointer to new client instance
             * @return              Return @ref SIPENGINEERRCODES 
             **/
            virtual SIPENGINEERRCODES RequestSipClientHandler( ISipClientHandler **pHandler ) = 0;

            /**
             * @brief Destroys instance of client
             * 
             * @param[in] pHandler client would be destroyed
             * @return             Return @ref SIPENGINEERRCODES 
             **/
            virtual SIPENGINEERRCODES ReleaseSipClientHandler( ISipClientHandler *pHandler ) = 0;
        };

        /**
         * @brief SIP engine interface
         **/
        class ISipStack : public INetRefCounted
        {
        public:
            virtual ~ISipStack() {}

            /**
             * @brief Initializes SIP engine
             * 
             * @param[in] pClientsFactory abstract client's factory, produces client handlers
             * @param[in] pLocalIP        local network interface
             * @param[in] aLocalPort      local network port
             * @return                    Return @ref SIPENGINEERRCODES
             **/
            virtual SIPENGINEERRCODES Init( ISipClientHandlerFactory *pClientsFactory, const char *pLocalIP, uint16_t aLocalPort ) = 0;

            /**
             * @brief Specifies engine with proxy server 
             * 
             * @param[in] pProxyAddress proxy server address
             * @param[in] aProxyPort    proxy server port
             * @return                  Return @ref SIPENGINEERRCODES
             **/
            virtual SIPENGINEERRCODES SetProxy( const char *pProxyAddress, uint16_t aProxyPort ) = 0;

            /**
             * @brief Specifies custom user-agent string
             * 
             * @param[in] pUserAgent custom user-agent string
             * @return               Return @ref SIPENGINEERRCODES
             **/
            virtual SIPENGINEERRCODES SetUserAgent( const char *pUserAgent ) = 0;

            /**
             * @brief Specifies maximum forward nodes count
             * 
             * @param[in] aMaxForwards max nodes count
             * @return                 Return @ref SIPENGINEERRCODES 
             **/
            virtual SIPENGINEERRCODES SetMaxForwards( int32_t aMaxForwards ) = 0;

            /**
             * @brief Makes a call 
             * 
             * @param[in]  pParams  settings for calling
             * @param[in]  pDecoder description of supported media and network connection settings
             * @param[out] pSession new active session
             * @return              Return @ref SIPENGINEERRCODES
             **/
            virtual SIPENGINEERRCODES Invite( const SIPINVITEPARAMS *pParams, const ISdpDecoder *pDecoder, ISipSession **pSession ) = 0;

            /**
             * @brief Makes a request
             * 
             * @param[in] pSession active session
             * @param[in] aRequest type of request
             * @param[in] pDecoder session description if needed
             * @return             Return @ref SIPENGINEERRCODES
             **/
            virtual SIPENGINEERRCODES SendRequest( ISipSession *pSession, SIPREQUESTTYPES aRequest, const ISdpDecoder *pDecoder ) = 0;

            /**
             * @brief Sends response on request
             * 
             * @param[in] pSession current active session
             * @param[in] aCode    response result code
             * @param[in] pDecoder session description if needed
             * @return             Return @ref SIPENGINEERRCODES
             **/
            virtual SIPENGINEERRCODES SendResponse( ISipSession *pSession, SIPRESPONSECODES aCode, const ISdpDecoder *pDecoder ) = 0;

            /**
             * @brief Reset session for re-invite
             *
			 * Should be called on new (re-)INVITE request for existing session.
			 *
             * @param[in] pSession active session
             * @return             Return @ref SIPENGINEERRCODES
             **/
            virtual SIPENGINEERRCODES ResetSessionForReInvite( ISipSession *pSession ) = 0;
        };

#if defined ( __SYMBIAN32__ )
        /**
         * @brief Creates an instance of SIP stack engine
         * 
         * @return valid pointer to ISipStack or NULL on failed
         **/
        SIP_STACK_API ISipStack * SIP_STACK_API CreateSipStack( void );
#else
    #if defined (__cplusplus)
        extern "C" {
    #endif
            /**
            * @brief Creates an instance of SIP stack engine
            * 
            * @return valid pointer to ISipStack or NULL on failed
            **/
            ISipStack * SIP_STACK_API CreateSipStack( void *(MC_EXPORT_API *get_rc)(const char*) );

            /**
            * @brief Provides access to extended module API
            * 
            * @param[in] func id of extended module function
            * @return         valid pointer to function or NULL
            **/
            APIEXTFUNC SIP_STACK_API SipStackGetAPIExt(uint32_t func);
    #if defined (__cplusplus)
        }
    #endif
#endif
    };
};

#endif //__MC_SIP_STACK_API_H__
