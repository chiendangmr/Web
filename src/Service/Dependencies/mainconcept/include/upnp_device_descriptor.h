/**
@file   upnp_device_descriptor.h
@brief  UPnP Device Descriptor API

@verbatim
File: upnp_device_descriptor.h
Desc: UPnP Device Descriptor API 

Copyright (c) 2015 MainConcept GmbH or its affiliates.  All rights reserved.

MainConcept and its logos are registered trademarks of MainConcept GmbH or its affiliates.  
This software is protected by copyright law and international treaties.  Unauthorized 
reproduction or distribution of any portion is prohibited by law.
@endverbatim
**/

#if !defined (__MC_UPNP_DEVICE_DESCRIPTOR_H__)
#define __MC_UPNP_DEVICE_DESCRIPTOR_H__

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

            /**
            * @brief Describes device type
            **/
            typedef enum _tagUpnpDeviceType {

                UpnpDeviceTypeMediaServer   = 0,                    /**< Media Server */
                UpnpDeviceTypeMediaRenderer = 1,                    /**< Media Renderer */
                UpnpDeviceTypeRoot          = 2,                    /**< Root device */
                UpnpDeviceTypeExtended      = 3,                    /**< Extended device */
                UpnpDeviceTypeLast          = 4                     /**< Last */
            } UpnpDeviceType;                                         
                                                                     
            /**                                                      
            * @brief Describes services type                                
            **/                                                      
            typedef enum _tagUpnpServiceType {                         
                                                                     
                UpnpServiceTypeContentDirectory   = 0,              /**< Content Directory */
                UpnpServiceTypeConnectionManager  = 1,              /**< Connection Manager */
                UpnpServiceTypeRenderingControl   = 2,              /**< Rendering control */
                UpnpServiceTypeAVTransport        = 3,              /**< A/V Transport */
                UpnpServiceMediaReceiverRegistrar = 4,              /**< Media Receiver Registrar */
                UpnpServiceTypeExtended           = 5,              /**< Extended */
                UpnpServiceTypeLast               = 6               /**< Last */
            } UpnpServiceType;                                         
                                                                     
            /**                                                      
            * @brief Describes device/service state                         
            **/                                                      
            typedef enum _tagUpnpState {                             
                                                                     
                UpnpStateAlive = 0,                                 /**< Active */
                UpnpStateBye   = 1                                  /**< Shutdown */
            } UpnpState;                                             
                                                                     
            /**                                                      
            * @brief Describes known device vendor                                
            **/                                                      
            typedef enum _tagUpnpVendorCompatibility {                 
                                                                     
                vendorCompatNone = 0,                               /**< None */
                vendorCompatPs3  = 1,                               /**< Sony Playstation 3 */
                vendorCompatXbox = 2                                /**< Micrisoft XBoX */
            } UpnpVendorCompatibility;

            /**
            * @brief Describes service
            **/
            class IUpnpServiceDescriptor
            {
            public:
                virtual ~IUpnpServiceDescriptor() {}

                /**
                * @brief Retrieves service type
                * 
                * @return Service type @ref UpnpServiceType 
                **/
                virtual UpnpServiceType GetType() const = 0;

                /**
                * @brief Retrieves string name
                * 
                * @return human-friendly name string
                **/
                virtual const char * GetFriendlyName() const = 0;

                /**
                * @brief Retrieves state
                * 
                * @return service state @ref UpnpState 
                **/
                virtual UpnpState GetState() const = 0;

                /**
                * @brief Retrieves control url
                * 
                * @return control url string 
                **/
                virtual const char * GetControlUrl() const = 0;

                /**
                * @brief Retrieves event url
                * 
                * @return event url string 
                **/
                virtual const char * GetEventUrl() const = 0;

                /**
                * @brief Retrieves description url
                * 
                * @return description url string 
                **/
                virtual const char * GetDescriptionUrl() const = 0;

                /**
                * @brief Retrieves service id string
                * 
                * @return service id string 
                **/
                virtual const char * GetServiceId() const = 0;

                /**
                * @brief Checks on similarity
                * 
                * @param[in] pService original
                * @return             true in case of sameness, otherwise false 
                **/
                virtual bool IsSameService( const IUpnpServiceDescriptor *pService ) const = 0;

                /**
                * @brief Checks action support availability
                * 
                * @param[in] pAction  null terminated ascii string with a complete action name 
                * @return             true when supported, otherwise false 
                **/
                virtual bool IsActionSupported(const char *pAction) const = 0;
            };

            /**
            * @brief Describes devices
            **/
            class IUpnpDeviceDescriptor
            {
            public:
                virtual ~IUpnpDeviceDescriptor() {}

                /**
                * @brief Checks on similarity with other device
                * 
                * @param[in] UUID uuid string of original device
                * @return         true if devices are identical, otherwise false 
                **/
                virtual bool IsSameDevice(const char *UUID) const = 0;

                /**
                * @brief Retrieves device type human-friendly name
                * 
                * @return device type string 
                **/
                virtual const char * GetDeviceTypeFriendlyName() const = 0;

                /**
                * @brief Retrieves device type
                * 
                * @return device type @ref UpnpDeviceType 
                **/
                virtual UpnpDeviceType GetDeviceType() const = 0;

                /**
                * @brief Retrieves vendor name
                * 
                * @param[out] pCompatibility return compatibility type
                * @return               vendor name string 
                **/
                virtual const char * GetDeviceVendorName(UpnpVendorCompatibility *pCompatibility) const = 0;

                /**
                * @brief Retrieve device UUID
                * 
                * @return UUID string 
                **/
                virtual const char * GetDeviceUUID() const = 0;

                /**
                * @brief Retrieves device location
                * 
                * @param[in] uiIndex index number among multiple device location
                * @return            device location string 
                **/
                virtual const char * GetDeviceLocation(uint32_t uiIndex) const = 0;

                /**
                * @brief Retrieves device network properties and settings
                * 
                * @param[in]  uiIndex  index number of property
                * @param[out] pDstPort actual device port
                * @return              actual network address
                * @see 
                **/
                virtual const char * GetDeviceNetworkProps(uint32_t uiIndex, uint16_t *pDstPort) const = 0;

                /**
                * @brief Enumerates available services
                * 
                * @param[in] uiIndex index number of service
                * @return            service descriptor 
                **/
                virtual const IUpnpServiceDescriptor * EnumServiceDescriptors( uint32_t uiIndex ) const = 0;

                /**
                * @brief Retrieves service count
                * 
                * @return count of available services 
                **/
                virtual uint32_t GetServiceDescriptorCount() const = 0;

                /**
                * @brief Retrieves device state
                * 
                * @return device state @ref UpnpState 
                **/
                virtual UpnpState GetState() const = 0;

                /**
                * @brief Checks if current device is alive according to device state itself and all its services:
                * If device state is set to UpnpStateAlive but all services are in UpnpStateBye state this method will 
                * return false.
                * 
                * @return device state taking into account its services states @ref UpnpState 
                **/
                virtual bool IsAlive() const = 0;
            };
        };
    };
};

#endif //__MC_UPNP_DEVICE_DESCRIPTOR_H__
