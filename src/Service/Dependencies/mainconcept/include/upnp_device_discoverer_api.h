/**
@file upnp_device_discoverer_api.h
@brief UPnP Device Discoverer API

@verbatim
File: upnp_device_discoverer_api.h
Desc: UPnP Device Discoverer API

Copyright (c) 2015 MainConcept GmbH or its affiliates.  All rights reserved.

MainConcept and its logos are registered trademarks of MainConcept GmbH or its affiliates.  
This software is protected by copyright law and international treaties.  Unauthorized 
reproduction or distribution of any portion is prohibited by law.
@endverbatim
**/

#if !defined (__MC_UPNP_DEVICE_DISCOVERER_API_H__)
#define __MC_UPNP_DEVICE_DISCOVERER_API_H__

/**
* @def MC_UPNP_DEVICE_DISCOVERER_API
* @brief Calling convention
* @hideinitializer
**/
#if defined(WIN32)
    #define MC_UPNP_DEVICE_DISCOVERER_API __cdecl
#else
    #define MC_UPNP_DEVICE_DISCOVERER_API
#endif

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
        * namespace UpnpStack
        * @brief Contains DLNA interfaces
        **/
        namespace UpnpStack {

            class IUpnpDeviceDescriptor;
            class IUpnpFlowConsumer;

            /**
            * @brief Describes result codes
            **/
            typedef enum _tagUpnpDeviceDiscovererErrCodes {

                UpnpDeviceDiscovererErrOk            =  0,          /**< Operation successfull */
                UpnpDeviceDiscovererErrUnableToStart = -1,          /**< Start failed */
                UpnpDeviceDiscovererErrBadArg        = -2,          /**< Argument has incorrect value */
                UpnpDeviceDiscovererErrNotImpl       = -3           /**< Operation not implemented */
            } UpnpDeviceDiscovererErrCodes;

            /**
            * @brief Provides functionality for discovering devices in network
            **/
            class IUpnpDeviceDiscoverer	: public INetRefCounted
            {
            public:
                virtual ~IUpnpDeviceDiscoverer() {}

                /**
                * @brief Discovers network devices
                *
                * @param[in] pST service type string
                * @return        Return @ref UpnpDeviceDiscovererErrCodes
                **/
                virtual MainConcept::NetworkStreaming::UpnpStack::UpnpDeviceDiscovererErrCodes DiscoverDevices(const char *pST = NULL) = 0;

                /**
                * @brief Starts discovering
                *
                * @param[in] pNIC when NULL - all network interfaces will be used, when a valid null terminated string should represent a single network interface address
                * @param[in] uiTTL Time-to-Live of discoverer packets
                * @return          Return @ref UpnpDeviceDiscovererErrCodes
                **/
                virtual MainConcept::NetworkStreaming::UpnpStack::UpnpDeviceDiscovererErrCodes Start( const char* pNIC = NULL, uint32_t uiTTL = 4 ) = 0;

                /**
                * @brief Stops working
                *
                * @return Return @ref UpnpDeviceDiscovererErrCodes
                **/
                virtual UpnpDeviceDiscovererErrCodes Stop() = 0;

                /**
                * @brief Attaches event consumer
                *
                * @param[in] pConsumer pointer to @ref IUpnpFlowConsumer observing event entity
                * @return              Return @ref UpnpDeviceDiscovererErrCodes
                **/
                virtual UpnpDeviceDiscovererErrCodes AdviseConsumer( IUpnpFlowConsumer *pConsumer ) = 0;

                /**
                * @brief Remove event consumer from list of event receiver
                *
                * @param[in] pConsumer pointer to @ref IUpnpFlowConsumer entity for removing
                * @return              Return @ref UpnpDeviceDiscovererErrCodes
                **/
                virtual UpnpDeviceDiscovererErrCodes RemoveConsumer( IUpnpFlowConsumer *pConsumer ) = 0;

                /**
                * @brief Enumerates active devices
                *
                * @param[in] uiIndex index number devices
                * @param[in] type    device type filter
                * @return            Pointer to @ref IUpnpDeviceDescriptor
                **/
                virtual const IUpnpDeviceDescriptor * EnumDevices( uint32_t uiIndex, UpnpDeviceSpecType type = UpnpDeviceSpecAll ) = 0;

                /**
                * @brief Retrieves count of devices
                *
                * @param[in] type filter of countable device
                * @return         count of active devices
                **/
                virtual uint32_t GetDeviceCount( UpnpDeviceSpecType type = UpnpDeviceSpecAll ) = 0;

                /**
                * @brief Provides external log system interface
                *
                * @param[in] pLogger    pointer to implementation of IUpnpLogger
                * @param[in] pLoggerArg custom argument
                * @return None
                **/
                virtual void SetLogger(IUpnpLogger *pLogger, void *pLoggerArg) = 0;
            };

#if defined (__cplusplus)
            extern "C" {
#endif
                /**
                * @brief Creates instance of new UPnP Device Discoverer object
                *
                * @param[in] get_rc Pointer to get_rc memory manager implementation or NULL to use standard allocators
                * @return           valid pointer to @ref IUpnpDeviceDiscoverer instance or NULL
                **/
                IUpnpDeviceDiscoverer* MC_UPNP_DEVICE_DISCOVERER_API GetUpnpDeviceDiscovererInterface( void *(MC_EXPORT_API *get_rc)(const char*) );
#if defined (__cplusplus)
            }
#endif
        };
    };
};

#endif //__MC_UPNP_DEVICE_DISCOVERER_API_H__
