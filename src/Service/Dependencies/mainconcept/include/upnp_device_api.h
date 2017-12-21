/**
@file   upnp_device_api.h
@brief  UPnP Device API

@verbatim
File: upnp_device_api.h
Desc: UPnP Device API 

Copyright (c) 2015 MainConcept GmbH or its affiliates.  All rights reserved.

MainConcept and its logos are registered trademarks of MainConcept GmbH or its affiliates.  
This software is protected by copyright law and international treaties.  Unauthorized 
reproduction or distribution of any portion is prohibited by law.
@endverbatim
**/

#if !defined (__MC_UPNP_DEVICE_API_H__)
#define __MC_UPNP_DEVICE_API_H__

#include "mcapiext.h"
#include "net_common.h"
#include "upnp_common.h"
#include "metadata_extractor_api.h"
#include "upnp_device_descriptor.h"
#include "media_detector_api.h"
#include "http.h"

/**
* @brief Defines HTTP as transport protocol mime string
* @hideinitializer
**/
#define UPNP_TRANSPORT_NAME_HTTP "http-get"

/**
* @brief Defines RTSP/RTP/UDP as transport protocol mime string
* @hideinitializer
**/
#define UPNP_TRANSPORT_NAME_RTSP_RTP_UDP "rtsp-rtp-udp"

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
                @brief Describes UPnP content directory item change type
            */
            typedef enum _tagUpnpContentDirectoryItemChangeType {

                UpnpContentDirectoryItemUpdated = 0x00,        /* update item notify */
                UpnpContentDirectoryItemDeleted = 0x01,        /* delete item notify (deleted item parents' id is returned) */
                UpnpContentDirectoryItemAdded   = 0x02,        /* add new item notify */
            } UpnpContentDirectoryItemChangeType;

            /**
                @brief Describes UPnP transfer object type
            */
            typedef enum _tagUpnpResourceTransferObject {

                UpnpImportResourceObject = 0x00,        /* import resource object */
                UpnpExportResourceObject = 0x01         /* export resource object */
            } UpnpResourceTransferObject;

            /**
                @brief Describes resource type
            */
            typedef enum _tagUpnpSpecialResourceType {

                UpnpSpecialResourceDeviceTemplate  = 0,		/* resource type is device description template (dynamic resource) */
                UpnpSpecialResourceServiceTemplate = 1		/* resource type is service description template (dynamic resource) */
            } UpnpSpecialResourceType;

            /**
            * @brief Describes device type
            **/
            typedef enum _tagUpnpDeviceSpecType {

                UpnpDeviceSpecAV  = 0,                              /**< Audio/Video device */
                UpnpDeviceSpecAll = 1                               /**< Any device */
            } UpnpDeviceSpecType;                                    
                                                                     
            /**                                                      
            * @brief Describes device role
            **/                                                      
            typedef enum _tagUpnpFlowRole {                          
                                                                     
                EUpnpFlowClientRole     = 0,                        /**< Client role */
                EUpnpFlowServerRole     = 1,                        /**< Server role */
                EUpnpFlowEveryRole      = 2                         /**< All roles */
            } UpnpFlowRole;                                          
                                                                     
            /**                                                      
            * @brief Describes UPnP Device API result code           
            **/                                                      
            typedef enum _tagUpnpDeviceErrCodes {                    
                                                                     
                EUpnpDeviceOk             =  0,                     /**< Operation successful */
                EUpnpDeviceErr            = -1,                     /**< Operation failed */
                EUpnpDeviceInitFailed     = -2,                     /**< Initialization failed */
                EUpnpDeviceNotImplemented = -3,                     /**< Operation is not implemented */
                EUpnpDeviceNotFound       = -4,                     /**< Requested object is not found */
                EUpnpDeviceServiceFailed  = -5,                     /**< Requested service is failed or unavailable */
                EUpnpDeviceBadState       = -6,                     /**< Incorrect state, check sequence of commands */
                EUpnpDeviceBadArgument    = -7                      /**< Argument incorrect */
            } UpnpDeviceErrCodes;                                    
                                                                     
            /**                                                      
            * @brief Describes UPnP common device notifies           
            **/                                                      
            typedef enum _tagUpnpDeviceNotifies {                    
                                                                     
                EUpnpDeviceStarted          = 0,                    /**< Device started successfully */
                EUpnpDeviceStopped          = 1,                    /**< Device stopped */
                EUpnpDeviceNewClient        = 2,                    /**< New client arrived */
                EUpnpDeviceClientDisconnect = 3,                    /**< Client connection lost */
                EUpnpDeviceDataRequest      = 4,                    /**< Data request received, @deprecated */
                EUpnpDeviceItemRequest      = 5,                    /**< Content Directory Item request received */
                EUpnpDeviceClientActivate   = 6                     /**< Notify about client request */
            } UpnpDeviceNotifies;                                    
                                                                     
            /**                                                      
            * @brief Describes UPnP Control Point notifies           
            **/                                                      
            typedef enum _tagUpnpControlPointNotifies {              
                                                                     
                EUpnpControlPointNewRequest         = 0,            /**< New request received */
                EUpnpControlPointReceivedObject     = 1,            /**< Object received */
                EUpnpControlPointOperationFinished  = 2,            /**< Operation finished */
                EUpnpControlPointTimeOut            = 3,            /**< Time is out */
                EUpnpControlPointSubscribeEventData = 4,            /**< Response data arrived */
                EUpnpControlPointDeviceStateChanged = 5,            /**< Device state changed */
                EUpnpControlPointReceivedBrowseResponse     = 6,    /**< Received result of Browse request, pData is pointer to const array of UpnpValuePair DataSize count */
                EUpnpControlPointReceivedSearchResponse     = 7     /**< Received result of Browse request, pData is pointer to const array of UpnpValuePair DataSize count */
            } UpnpControlPointNotifies;                              
                                                                     
            /**                                                      
            * @brief Describes UPnP A/V Transport notifies                  
            **/                                                      
            typedef enum _tagUpnpAVTransportAction {               
                                                                     
                EUpnpAVTransportSetAVTransportURI          =  0,    /**< A/V Transport URI, required    */
                EUpnpAVTransportSetNextAVTransportURI      =  1,    /**< Next A/V Transport URI */
                EUpnpAVTransportGetMediaInfo               =  2,    /**< Requested Media Info, required */
                EUpnpAVTransportGetTransportInfo           =  3,    /**< Requested Transport Info, required */
                EUpnpAVTransportGetPositionInfo            =  4,    /**< Requested current Position Info, required */
                EUpnpAVTransportGetDeviceCapabilities      =  5,    /**< Requested UPnP Device Capabilities, required */
                EUpnpAVTransportGetTransportSettings       =  6,    /**< Requested Transport settings, required */
                EUpnpAVTransportStop                       =  7,    /**< Stop playback, required */
                EUpnpAVTransportPlay                       =  8,    /**< Start playback, required */
                EUpnpAVTransportPause                      =  9,    /**< Pause */
                EUpnpAVTransportRecord                     = 10,    /**< Start recording media */
                EUpnpAVTransportSeek                       = 11,    /**< Set new playback position, required */
                EUpnpAVTransportNext                       = 12,    /**< Switch to next item, required */
                EUpnpAVTransportPrevious                   = 13,    /**< Switch to previous item, required */
                EUpnpAVTransportSetPlayMode                = 14,    /**< Change Play Mode */
                EUpnpAVTransportSetRecordQualityMode       = 15,    /**< Change Record Quality Mode */
                EUpnpAVTransportGetCurrentTransportActions = 16,    /**< Requested Current transport action */
                EUpnpAVTransportUnknownAction              = 255    /**< Non-standard action invoked */
            } UpnpAVTransportAction;

            /**
            * @brief Describes UPnP Rendering control notifies
            **/
            typedef enum _tagUpnpRenderingControlAction {

                EUpnpRenderingControlListPresets             = 0,   /**< Requested presets, required */
                EUpnpRenderingControlSelectPreset            = 1,   /**< Selected presets, required */
                EUpnpRenderingControlGetBrightness           = 2,   /**< Requested current brightness level */
                EUpnpRenderingControlSetBrightness           = 3,   /**< Apply new brightness level */
                EUpnpRenderingControlGetContrast             = 4,   /**< Requested current contrast level */
                EUpnpRenderingControlSetContrast             = 5,   /**< Apply new contrast level */
                EUpnpRenderingControlGetSharpness            = 6,   /**< Requested current sharpness level */
                EUpnpRenderingControlSetSharpness            = 7,   /**< Apply new sharpness level */
                EUpnpRenderingControlGetRedVideoGain         = 8,   /**< Requested red channel gain */
                EUpnpRenderingControlSetRedVideoGain         = 9,   /**< Apply new red channel gain */
                EUpnpRenderingControlGetGreenVideoGain       = 10,  /**< Requested green channel gain */
                EUpnpRenderingControlSetGreenVideoGain       = 11,  /**< Apply new green channel gain */
                EUpnpRenderingControlGetBlueVideoGain        = 12,  /**< Requested blue channel gain */
                EUpnpRenderingControlSetBlueVideoGain        = 13,  /**< Apply new blue channel gain */
                EUpnpRenderingControlGetRedVideoBlackLevel   = 14,  /**< Requested red channel black level */
                EUpnpRenderingControlSetRedVideoBlackLevel   = 15,  /**< Apply new red channel black level */
                EUpnpRenderingControlGetGreenVideoBlackLevel = 16,  /**< Requested green channel black level */
                EUpnpRenderingControlSetGreenVideoBlackLevel = 17,  /**< Apply new blue channel gain */
                EUpnpRenderingControlGetBlueVideoBlackLevel  = 18,  /**< Requested blue channel gain */
                EUpnpRenderingControlSetBlueVideoBlackLevel  = 19,  /**< Apply new blue channel gain */
                EUpnpRenderingControlGetColorTemperature     = 20,  /**< Requested current color temperature value */
                EUpnpRenderingControlSetColorTemperature     = 21,  /**< Apply new color temperature */
                EUpnpRenderingControlGetHorizontalKeystone   = 22,  /**< Requested Horizontal Keystone Value */
                EUpnpRenderingControlSetHorizontalKeystone   = 23,  /**< Apply new Horizontal Keystone Value */
                EUpnpRenderingControlGetVerticalKeystone     = 24,  /**< Requested Vertical Keystone Value  */
                EUpnpRenderingControlSetVerticalKeystone     = 25,  /**< Apply new Vertical Keystone Value  */
                EUpnpRenderingControlGetMute                 = 26,  /**< Requested Mute state */
                EUpnpRenderingControlSetMute                 = 27,  /**< Apply new Mute state */
                EUpnpRenderingControlGetVolume               = 28,  /**< Requested volume level */
                EUpnpRenderingControlSetVolume               = 29,  /**< Apply new volume value */
                EUpnpRenderingControlGetVolumeDB             = 30,  /**< Requested volume level(dB) */
                EUpnpRenderingControlSetVolumeDB             = 31,  /**< Apply new volume level(dB) */
                EUpnpRenderingControlGetVolumeDBRange        = 32,  /**< Requested volume range(dB) */
                EUpnpRenderingControlGetLoudness             = 33,  /**< Requested current loudness value */
                EUpnpRenderingControlSetLoudness             = 34,  /**< Apply new loudness value */
                EUpnpRenderingControlUnknownAction           = 255  /**< Non-standard action invoked */
            } UpnpRenderingControlAction;

            /**
            * @brief Describes content type
            **/
            typedef enum _tagUpnpContentMediaType {

                ContentTypeContainer,                               /**< general container */
                ContentTypeContainerStorageFolder,                  /**< storage folder */
                ContentTypeContainerStorageVolume,                  /**< storage volume */
                ContentTypeContainerStorageSystem,                  /**< storage system */
                                                                   
                ContentTypeContainerPlaylistContainer,              /**< playlist as container*/
                                                                   
                ContentTypeAlbum,                                   /**< general album */
                ContentTypeAlbumMusic,                              /**< music album */
                ContentTypeAlbumPhoto,                              /**< photo album */
                                                                   
                ContentTypeGenre,                                   /**< general genre */
                ContentTypeGenreMusic,                              /**< music */
                ContentTypeGenreMovie,                              /**< movie */
                                                                   
                ContentTypePerson,                                  /**< general person */
                ContentTypePersonMusicArtist,                       /**< music artist */
                                                                   
                ContentTypeAudio,                                   /**< general audio */
                ContentTypeAudioMusicTrack,                         /**< music track */
                ContentTypeAudioBroadcast,                          /**< broadcast audio*/
                ContentTypeAudioBook,                               /**< audio book */
                                                                   
                ContentTypeVideo,                                   /**< general video */
                ContentTypeVideoMovie,                              /**< movie */
                ContentTypeVideoBroadcast,                          /**< broadcast video */
                ContentTypeVideoMusicVideoClip,                     /**< music video clip */
                                                                   
                ContentTypeImage,                                   /**< general image */
                ContentTypeImagePhoto,                              /**< photo */
                                                                   
                ContentTypeItem,                                    /**< general content item */
                ContentTypePlaylistItem,                            /**< playlist as single item */
                ContentTypeTextItem,                                /**< text item */
                                                                   
                ContentTypeDevice,                                  /**< general device (returned when browsing for media servers or renderers) */
                                                                   
                ContentTypeUndefined                                /**< undefined type */
            } UpnpContentMediaType;                                  
            
            /**
            * @brief Describes UPnP service error codes
            **/
            typedef enum _tagUpnpServiceErrCodes {

                EUpnpErrInvalidAction					                = 401,	/**< Invalid Action */
                EUpnpErrInvalidArgs						                = 402,	/**< Invalid Args */
                EUpnpErrInvalidVar						                = 404,	/**< Invalid State Variable */
                                                                   
                EUpnpErrActionFailed					                = 501, 	/**< Action Failed */
                                                                   
                EUpnpErrInvalidArgumentValue			                = 600, 	/**< Argument Value Invalid */
                EUpnpErrArgumentValueOutOfRange			                = 601, 	/**< Argument Value Out of Range */
                EUpnpErrActionNotImplemented				            = 602, 	/**< Optional Action Not Implemented */
                EUpnpErrOutOfMemory						                = 603,	/**< Out of Memory */
                EUpnpErrHumanInterventionRequired			            = 604,  /**< Human Intervention Required */
                EUpnpErrStringArgumentTooLong				            = 605, 	/**< String Argument Too Long */
                EUpnpErrNotAuthorized				    	            = 606, 	/**< Action not authorized */
                EUpnpErrSignatureFailure				                = 607, 	/**< Signature failure */
                EUpnpErrSignatureMissing				                = 608,  /**< Signature missing */
                EUpnpErrNotEncrypted					                = 609,  /**< Not encrypted */
                EUpnpErrInvalidSequence					                = 610,	/**< Invalid sequence */
                EUpnpErrInvalidControlUrl				  	            = 611,	/**< Invalid control URL */
                EUpnpErrNoSuchSession					                = 612,	/**< No such session */
                                                                   
                EUpnpErrAVTransportTransitionNotAvailable               = 701,
                EUpnpErrAVTransportNoContents                           = 702,
                EUpnpErrAVTransportReadError                            = 703,
                EUpnpErrAVTransportFormatNotSupportedForPlayback        = 704,
                EUpnpErrAVTransportTransportIsLocked                    = 705,
                EUpnpErrAVTransportWriteError                           = 706,
                EUpnpErrAVTransportMediaWriteProtected                  = 707,
                EUpnpErrAVTransportFormatNotSupportedForRecording       = 708,
                EUpnpErrAVTransportMediaIsFull                          = 709,
                EUpnpErrAVTransportSeekNotSupported                     = 710,
                EUpnpErrAVTransportIllegalSeekTarget                    = 711,
                EUpnpErrAVTransportPlayModeNotSupported                 = 712,
                EUpnpErrAVTransportRecordQualityNotSupported            = 713,
                EUpnpErrAVTransportIllegalMimeType                      = 714,
                EUpnpErrAVTransportContentBusy                          = 715,
                EUpnpErrAVTransportResourceNotFound                     = 716,
                EUpnpErrAVTransportPlaySpeedNotSupported                = 717,
                EUpnpErrAVTransportInvalidInstanceID                    = 718,

                EUpnpErrContentDirectoryNoSuchObject                    = 701,
                EUpnpErrContentDirectoryInvalidCurrentTagValue          = 702,
                EUpnpErrContentDirectoryInvalidNewTagValue              = 703,
                EUpnpErrContentDirectoryRequiredTag                     = 704,
                EUpnpErrContentDirectoryReadOnlyTag                     = 705,
                EUpnpErrContentDirectoryParameterMismatch               = 706,
                EUpnpErrContentDirectoryReserved                        = 707,
                EUpnpErrContentDirectoryBadSearchCriteria               = 708,
                EUpnpErrContentDirectoryBadSortCriteria                 = 709,
                EUpnpErrContentDirectoryNoSuchContainer                 = 710,
                EUpnpErrContentDirectoryRestrictedObject                = 711,
                EUpnpErrContentDirectoryBadMetadata                     = 712,
                EUpnpErrContentDirectoryRestrictedParentObject          = 713,
                EUpnpErrContentDirectoryNoSuchSourceResource            = 714,
                EUpnpErrContentDirectorySourceResourceAccessDenied      = 715,
                EUpnpErrContentDirectoryTransferBusy                    = 716,
                EUpnpErrContentDirectoryNoSuchFileTransfer              = 717,
                EUpnpErrContentDirectoryNoSuchDestinationResource       = 718,
                EUpnpErrContentDirectoryDestinationResourceAccessDenied = 719,
                EUpnpErrContentDirectoryCannotProcessRequest            = 720,
              
                EUpnpErrConnectionManagerIncompatibleProtocolInfo       = 701,
                EUpnpErrConnectionManagerIncompatibleDirection          = 702,
                EUpnpErrConnectionManagerInsufficientNetworkResources   = 703,
                EUpnpErrConnectionManagerLocalRestriction               = 704,
                EUpnpErrConnectionManagerAccessDenied                   = 705,
                EUpnpErrConnectionManagerInvalidConnectionReference     = 706,
                EUpnpErrConnectionManagerNotInNetwork                   = 707,

                EUpnpErrRenderingControlInvalidName                     = 701,
                EUpnpErrRenderingControlInvalidInstanceID               = 702,

            } UpnpServiceErrCodes;

            /**
            * @brief Describes Database specific error codes
            **/
            typedef enum _tagUpnpDBErrCodes {

                EUpnpDBOk                                = 0,
                EUpnpDBInternalError                     = -1,
                EUpnpDBNoSuchObject                      = -2,
                EUpnpDBRestrictedObject                  = -3,
                EUpnpDBRestrictedParentObject            = -4,
            } UpnpDBErrCodes;

            /**                                                      
            * @brief Describes UPnP Content Format Info              
            **/                                                      
            typedef struct _tagUpnpProtocolContentFormatInfo {       
                                                                     
                char* _pContentFormat;                            /**< content format MIME string */
                char* _pAdditionalFormatInfo;                     /**< UPnP additional info */
            } UpnpProtocolContentFormatInfo;                         
                                                                     
            /**                                                      
            * @brief Describes available protocol in Connection Manager
            **/                                                      
            typedef struct _tagUpnpDeviceProtocolInfo{               
                                                                     
                char*                        _pProto;                  /**< Protocol */
                char*                        _pNetwork;                /**< Network */
                UpnpProtocolContentFormatInfo* _pFormatInfo;             /**< Content Formats */
                uint32_t                       _uiContentFormatCount;    /**< count of supported types */
                char*                        _pAdditionalProtocolInfo; /**< Additional Info */
            } UpnpDeviceProtocolInfo;                                
                                                          
            /**                                                      
            * @brief Describes log message level             
            **/                                                      
            typedef enum _tagUpnpLogLevel {                          
                                                                     
                UpnpLogLevelDisable = 0,                            /**< Disable notifications */
                UpnpLogLevelError   = 1,                            /**< Error message */
                UpnpLogLevelWarning = 2,                            /**< Warning message */
                UpnpLogLevelNotice  = 3,                            /**< Notice message */
                UpnpLogLevelInfo    = 4,                            /**< Informational message */
                UpnpLogLevelDebug   = 5,                            /**< Debug message */
                UpnpLogLevelTrace   = 6,                            /**< Trace message, most verbose */
            } UpnpLogLevel;

            /**
              @brief Decribes IUpnpDevice parameters
             */
            typedef enum _tagUpnpDeviceParam {

                UpnpDeviceParamClientsTimeout           = 0         /**< uint32_t, Delay before disconnection on data absent, seconds*/
            } UPNPDEVICEPARAMTYPE;

            /**
            * @brief Custom resource description
            **/
            typedef struct _tagUpnpProtocolHandlerResource {

                char *pUrl;							/**< Target URL */
                UpnpValuePair *pAttributes;			/**< Attribute array that can be used to fill ContentDirectory item resource */
                uint32_t uiAttributeCount;			/**< Count of attributes in array */
            } UpnpProtocolHandlerResource;

            /**
            * @brief this is an abstraction for the data base ID fields
            **/
            class IUpnpDatabaseObjectID : public INetRefCounted
            {
            public:
                virtual ~IUpnpDatabaseObjectID() {};

                /**
                * @brief This method returns the null terminated string which represents an object's ID
                * 
                * @return null terminated string on success, NULL on fail
                **/
                virtual const char* ID() const = 0;
            };

            /**
            * @brief Interface to notify about transfer status changes
            **/
            class IUpnpTransferStatusNotifier
            {
            public:
                /**
                * @brief Notify sent when transfer was completed 
                * 
                * @param[in] uiTransferID  ID of the transfer that was completed.
                * @param[in] ppRes         list of URIs that was created  during resource import process
                * This method will update resources in CDS. All URIs except those with file:// protocol 
                * have no additional processing. file:// protocol  URIs will be processed
                * as local files and appropriate resources will be generated by CDS. Also 
                * attributes will be updated  according to file content.
                * @param[in] iCount        number  of resources.
                **/
                virtual void OnTransferCompleted(uint32_t uiTransferID, const char **ppRes, uint32_t iCount) = 0;
            };

            class IUpnpContentDirectoryItem;

            /**
            * @brief Database event observer
            **/
            class IUpnpDatabaseObserver
            {
            public:

                /**
                * @brief Issued when database System Update ID was incremented
                * 
                * @param[in] pSystemUpdateID	new value of SystemUpdateID
                **/
                virtual void OnSystemUpdate( const char *pSystemUpdateID ) = 0;

                /**
                * @brief Issued when database entry has been changed
                * 
                * @param[in] pItem the object which describes an entry @ref IUpnpContentDirectoryItem
                *
                * @param[in] aType type of the notify @ref UpnpContentDirectoryItemChangeType
                **/
                virtual void OnItemChange( const IUpnpContentDirectoryItem *pItem, UpnpContentDirectoryItemChangeType aType ) = 0;

                /**
                * @brief Issued when database is outdated
                * 
                * @param[in] iPercentDone	Progress in percents
                *
                * @return Confirmation to start DB updating
                **/
                virtual bool OnUpdateDB( const int32_t iPercentDone ) = 0;
            };

            /**
            * @brief Declares single content directory item
            **/
            class IUpnpContentDirectoryItem : public INetRefCounted
            {
            public:
                virtual ~IUpnpContentDirectoryItem() {}

                /**
                * @brief Retrieves item's ID
                * 
                * @return self ID
                **/
                virtual const IUpnpDatabaseObjectID* GetId() const = 0;

                /**
                * @brief Retrieves item's parent ID
                * 
                * @return parent ID
                **/
                virtual const IUpnpDatabaseObjectID*  GetParentId() const = 0;

                /**
                * @brief Retrieves content item type
                * 
                * @return Return @ref UpnpContentMediaType
                **/
                virtual UpnpContentMediaType GetMediaType() const = 0;

                /**
                * @brief Retrieves file system based path
                * 
                * @return path to item 
                **/
                virtual const char *GetPath() const = 0;

                /**
                * @brief Retrieves item title
                * 
                * @return title string 
                **/
                virtual const char *GetTitle() const = 0;

                /**
                * @brief Retrieves MIME type
                * 
                * @return MIME-type string
                **/
                virtual const char *GetMimeType() const = 0;

                /**
                * @brief Retrieves DLNA protocol information string
                * 
                * @return DLNA protocol information string
                **/
                virtual const char *GetDlnaProtocolInfo() const = 0;

                /**
                * @brief Retrieves properties count
                * 
                * @return Count of properties
                **/
                virtual uint32_t GetPropertiesCount() const = 0;

                /**
                * @brief Enumerates properties
                * 
                * @param[in] uiIndex         property index starting from zero
                * @return @ref UpnpProperty with property and attributes or NULL if reached end of list
                **/
                virtual const UpnpProperty *EnumProperties( uint32_t uiIndex ) const = 0;

                /**
                * @brief Returns attribute value
                * 
                * @param[in] pName    attribute name string
                * @return attribute value string or NULL if attribute not found
                **/
                virtual const char *GetAttributeValue( const char *pName ) const = 0;

                /**
                * @brief Returns i-th value of an attribute with several values
                * 
                * @param[in] pName    attribute name string
                * @param[in] iIndex  index of an attribute value
                * @return attribute value string or NULL if attribute not found
                **/
                virtual const char *GetAttributeValue( const char *pName, int32_t iIndex ) const = 0;

                /**
                * @brief Returns restriction flag value
                * 
                * @return true - when restricted, false - otherwise
                **/
                virtual const bool IsRestricted() const = 0;
            };

            /**
            * @brief UPnP File System Commander Observer
            **/
            class IUpnpFileSystemCommanderObserver
            {
            public:
                virtual ~IUpnpFileSystemCommanderObserver() {};

                /**
                * @brief This callback is called when File System Commander starts to scan the new FS item.
                * 
                * @param[in] pPath         path to FS item being scanned.
                **/
                virtual void OnScanFsItem( const char *pPath) = 0;
            };

            /**
            * @brief UPnP File System Commander
            **/
            class IUpnpFileSystemCommander : public INetRefCounted
            {
            public:
                virtual ~IUpnpFileSystemCommander() {};

                /**
                * @brief This method allows to set a filter by mime types (only items which match the given filter will be processed)
                * 
                * @param[in] pAllowedMimeTypes         a list with null terminated mime type strings, NULL - no filter is used
                * @param[in] iAllowedMimeTypesCount    a count of the list elements, 0 - no filter is used
                **/
                virtual void SetAllowedMimeTypes( const char **pAllowedMimeTypes = NULL, int32_t iAllowedMimeTypesCount = 0 ) = 0;

                /**
                * @brief This method allows to update the previously added file system content to the database
                * 
                * @param[in] pPath    a valid null terminated unicode string to the file system entry
                * @return             number of files updated
                **/
                virtual int32_t UpdatePath( const char *pPath ) = 0;

                /**
                * @brief This method allows to add the new file system content to the database
                * 
                * @param[in] pPath    a valid null terminated unicode string to the file system entry
                * @return             number of files updated
                **/
                virtual int32_t AddPath( const char *pPath ) = 0;

                /**
                * @brief This method allows to remove previously added file system content from the database
                * 
                * @param[in] pPath    a valid null terminated unicode string to the file system entry
                * @return             number of files updated
                **/
                virtual int32_t RemovePath( const char *pPath ) = 0;

                /**
                * @brief This method allows to stop update/remove/add database process
                **/
                virtual void StopUpdate() = 0;

                /**
                * @brief This method allows to remove previously added file system content from the database
                * 
                * @param[in] uiIndex    index of the entry
                * @return a valid null terminated unicode string to the file system entry which present in the database as a top level entry
                **/
                virtual const char *GetFsItems( uint32_t uiIndex ) = 0;

                /**
                * @brief This method returns the count of the top elements added to the database from the file system
                * 
                * @return count of the top entries in the database, which were added to the database
                **/
                virtual uint32_t GetFsItemCount() = 0;

                /**
                * @brief Returns file size in bytes
                * 
                * @param[in] pFileName    null terminated unicode string represents file name
                * @return file size in bytes on success, 0 or negative on failure
                **/
                virtual int64_t GetFileSize( const char *pFileName ) = 0;

                /**
                * @brief Checks whether content exists or not
                * 
                * @param[in] pFileName    null terminated unicode string represents file name
                * @return true when content is accessible, otherwise false
                **/
                virtual bool IsExist( const char *pFileName ) = 0;

                /**
                * @brief Check whether content is a directory
                * 
                * @param[in] pFileName    null terminated unicode string represents file name
                * @return true when content is a directory, otherwise false
                **/
                virtual bool IsDir( const char *pFileName ) = 0;

                /**
                * @brief Return media detector for the given file (Detector already has every field filled)
                * 
                * @param[in] pFileName    null terminated unicode string represents file name
                * @return valid pointer to @ref IMediaDetector
                **/
                virtual IMediaDetector *GetMediaDetector( const char *pFileName ) = 0;

                /**
                * @brief Returns data source for the given file
                * 
                * @param[in] pFileName    null terminated unicode string represents file name
                * @return valid pointer to @ref IDataSource on success, NULL otherwise
                **/
                virtual IDataSource * GetDataSource( const char *pFileName ) = 0;

                /**
                * @brief This method allows to advise external media data detector
                * 
                * @param[in] pMediaDetector    valid pointer to @ref IMediaDetector
                * @return 0 on success, negative on failure
                **/
                virtual int32_t AdviseMediaDetector( IMediaDetector *pMediaDetector ) = 0;

                /**
                * @brief Returns number of children under specified parent directory.
                * 
                * @param[in] pPath    parent directory which children should be counted.
                * @return number of children for specified parent directory.
                **/
                virtual int32_t GetChildFsItemCount( const char *pPath ) = 0;

                /**
                * @brief This method allows to advise observer for File System Commander events.
                * 
                * @param[in] pObserver    valid pointer to @ref IUpnpFileSystemCommanderObserver
                * @return 0 on success, negative on failure
                **/
                virtual int32_t AdviseObserver( IUpnpFileSystemCommanderObserver *pObserver ) = 0;

                /**
                * @brief This method allows to remove observer from File System Commander list.
                * 
                * @param[in] pObserver    valid pointer to @ref IUpnpFileSystemCommanderObserver
                * @return 0 on success, negative on failure
                **/
                virtual int32_t RemoveObserver( IUpnpFileSystemCommanderObserver *pObserver ) = 0;
            };

            class IUpnpResourceTransferObject;

            /**
            * @brief UPnP Static/Template resources producer
            **/
            class IUpnpResourceHandler : public INetRefCounted
            {
            public:
                virtual ~IUpnpResourceHandler() {};

                /**
                * @brief This method provides @ref IDataSource for the requested static resource
                * 
                * @param[in] pRequestedResource    valid pointer to requested static resource
                * @param[in] pUserAgent    valid pointer to string representation of user agent
                * @return valid pointer to @ref IDataSource on success, negative on failure
                **/
                virtual IDataSource * GetStaticResource( const char *pRequestedResource, const char *pUserAgent ) = 0;

                /**
                * @brief This method provides @ref IDataSource for the requested static resource
                * 
                * @param[in] aResourceType    @ref UpnpSpecialResourceType
                * @param[in] pUserAgent    valid pointer to string representation of user agent
                * @return valid pointer to @ref IDataSource on success, negative on failure
                **/
                virtual IDataSource * GetTemplateResource( UpnpSpecialResourceType aResourceType, const char *pUserAgent ) = 0;

                /**
                * @brief This method provides @ref IDataSource for the requested static resource
                * 
                * @param[in] pMimeType    valid pointer to null terminated string which represents mime type
                * @return valid pointer to null terminated DLNA profile name associated with the given mime type
                **/
                virtual const char * GetDlnaProfileName( const char * pMimeType ) = 0;

                /**
                * @brief This method provides @ref IUpnpResourceTransferObject for object importing
                * 
                * @param[in] objType         @ref UpnpResourceTransferObject
                * @param[in] pSrcUri         null terminated string with the source URI
                * @param[in] pDstUri         null terminated string with the destination URI
                * @param[in] pNotify         @ref IUpnpTransferStatusNotifier which will be notified about transfer status changes
                * @return                    valid pointer to @ref IUpnpResourceTransferObject on success, NULL pointer when failed
                **/
                virtual IUpnpResourceTransferObject * GetResourceTransferObject( UpnpResourceTransferObject objType, const char *pSrcUri, const char *pDstUri, IUpnpTransferStatusNotifier* pNotify ) = 0;

                /**
                 * @brief This method provides import URI for item being created
                 * 
                 * @param[in] pContainerID      id for container in which item is created
                 * @param[in] pAttributes       created item attributes
                 * @param[in] iAttributesCount  number of item attributes
                 * @return                      import URI which can be used later for resource import
                 */
                virtual const char * GetImportURI(const char *pFullContainerID, const UpnpProperty *pProperties, const int32_t iPropertyCount) = 0;
            };

            /**
            * @brief Database items enumerating interface
            **/
            class IUpnpContentDirectoryItemEnumerator : public INetRefCounted
            {
                public:
                    virtual ~IUpnpContentDirectoryItemEnumerator() {};

                    /**
                    * @brief This method provides the 'head' of the enumerator
                    * 
                    * @return                   a valid pointer to @ref IUpnpContentDirectoryItem object on success, NULL - otherwise
                    */
                    virtual IUpnpContentDirectoryItem *GetFirst() = 0;

                    /**
                    * @brief This method provides the next item from the enumerator
                    * 
                    * @return                   a valid pointer to @ref IUpnpContentDirectoryItem object on success, NULL - otherwise
                    */
                    virtual IUpnpContentDirectoryItem *GetNext() = 0;

                    /**
                    * @brief This method provides the enumerator item count
                    * 
                    * @return                   > 0 on Success, 0 - otherwise
                    */
                    virtual uint32_t GetItemsCount() const = 0;
            };

            /**
            * @brief Item database
            **/
            class IUpnpDatabase : public INetRefCounted
            {
                public:
                    virtual ~IUpnpDatabase() {};

                    /**
                    * @brief This method creates a new instance of @ref IUpnpDatabaseObjectID
                    * 
                    * @param[in] pData          null terminated string with the ID of CDS (Content Directory Service) object (item or container)
                    * @return                   a valid pointer to @ref IUpnpDatabaseObjectID object on success, NULL - otherwise
                    */
                    virtual IUpnpDatabaseObjectID* CreateObjectID( const char* pData ) = 0;

                    /**
                    * @brief Add new object to database. Various attributes can be specified for created object, such as protocol info or resource URI (refer to CDS spec for additional information about attributes) but the following are mandatory: dc:title and upnp:class.
                    *
                    * @param[in] pContainerID          identifier of container where new object should be placed
                    * @param[in] pAttributes           pointer to array of @ref UpnpValuePair which contains object attributes
                    * @param[in] iAttributesCount      size of attributes array
                    * @param[out] pItemID              address of a pointer to @ref IUpnpDatabaseObjectID object which receives ID of created CDS object.
                    * @param[in] RoleID                invoker role ID
                    * @return                          EUpnpDBOk on success, error code otherwise
                    */
                    virtual UpnpDBErrCodes AddItem( const IUpnpDatabaseObjectID* pContainerID, const UpnpProperty* pElements, const int32_t iElementCount, IUpnpDatabaseObjectID** pItemID, uint32_t RoleID ) = 0;
                    
                    /**
                    * @brief Alter, add or remove object attribute(s). Depending on passed attribute values this method does the following:
                    *
                    *		  If old attribute value was NULL and new one with the same name is set - attribute will be added
                    *		  If old attribute value was set and new one with the same name is set - attribute value will be updated
                    *		  If old attribute value was set and new one with the same name is NULL - attribute will be removed
                    *
                    * Both arrays should have the same size. Various attributes can be specified, such as resource URI or protocol info (refer to CDS spec for additional information about attributes) but the following are mandatory: dc:title and upnp:class.
                    *
                    * @param[in] itemID                identifier of the object
                    * @param[in] pOldAttributes        pointer to array of @ref UpnpValuePair containing object attributes which should be changed (removed)
                    * @param[in] pNewAttributes        pointer to array of @ref UpnpValuePair which contains new attributes values
                    * @param[in] iAttributesCount      size of both arrays with attributes
                    * @param[in] RoleID                invoker role ID
                    * @return                          EUpnpDBOk on success, error code otherwise
                    */
                    virtual UpnpDBErrCodes UpdateItem( const IUpnpDatabaseObjectID* itemID, const UpnpProperty *pOldElements, const UpnpProperty *pNewElements, const int32_t iElementCount, uint32_t RoleID ) = 0;

                    /**
                    * @brief Remove specified object from database.
                    *
                    * @param[in] pItem                 object to be removed
                    * @param[in] RoleID                invoker role ID
                    * @return                          EUpnpDBOk on success, error code otherwise
                    */
                    virtual UpnpDBErrCodes DeleteItem( const IUpnpContentDirectoryItem *pItem, uint32_t RoleID ) = 0;
                    
                    /**
                    * @brief Remove one or more objects that match to some set of attributes values. E.g. call to this method with single attribute with name 'dc:title' and value 'Foo' will destroy all objects with title 'Foo'.
                    *
                    * @param[in] pAttributes           pointer to array of @ref UpnpValuePair that contains attributes of object(s) which should be removed
                    * @param[in] iAttributesCount      size of attributes array
                    * @param[in] RoleID                invoker role ID
                    * @return                          EUpnpDBOk on success, error code otherwise
                    *
                    */
                    virtual UpnpDBErrCodes DeleteItemByCriteria( const UpnpValuePair *pAttributes, const int32_t iAttributesCount, uint32_t RoleID ) = 0;
                    
                    /**
                    * @brief Retrieve UPnP state variable value  
                    *
                    * @param[out] pValue                valid pointer to string buffer receiving variable value
                    * @param[out] pLen                  valid pointer to variable, that receives length of variable value
                    * @param[in] pVariableName          name of the requested variable 
                    * @param[in] RoleID                 invoker role ID
                    * @return                           EUpnpDBOk on success, error code otherwise
                    */
                    virtual UpnpDBErrCodes GetVariable( char *pValue, int32_t *pLen, const char *pVariableName, uint32_t RoleID ) = 0; // C-Style

                    /**
                    * @brief Fetch one or more objects (as pointer to @ref IUpnpContentDirectoryItemEnumerator object) that match to some set of attributes values. E.g. call to this method with single attribute with name 'dc:title' and value 'Foo' will return an enumerator of all objects with title 'Foo'.
                    *
                    * @param[in] pAttributes           pointer to array of @ref UpnpValuePair that contains attributes of object(s) which should be retrieved
                    * @param[in] iAttributesCount      size of attributes array
                    * @param[in] RoleID                invoker role ID
                    * @param[in] pSearchCriteria       DLNA search criteria string
                    * @param[in] pSortCriteria         DLNA sort criteria string
                    * @param[in] iStartingIndex        defines how many found objects should be skipped in result beginning from the first
                    * @param[in] iRequestedCount       number of objects which should be returned
                    * @param[out] matchedCount         pointer to variable that receives actually found objects count
                    * @return                          a valid pointer to @ref IUpnpContentDirectoryItemEnumerator object
                    */
                    virtual IUpnpContentDirectoryItemEnumerator *GetItem( const UpnpValuePair *pAttributes, const int32_t iAttributesCount, uint32_t RoleID, const char* pSearchCriteria, const char* pSortCriteria, int32_t iStartingIndex, int32_t iRequestedCount, int32_t *matchedCount ) = 0;


                    /**
                    * @brief Count how many objects satisfies criteria
                    *
                    * @param[in] pAttributes           pointer to array of @ref UpnpValuePair that contains attributes of object(s) which should be retrieved
                    * @param[in] iAttributesCount      size of attributes array
                    * @param[in] RoleID                invoker role ID
                    * @param[in] pSearchCriteria       DLNA search criteria string
                    * @return                          a number of matched objects
                    */
                    virtual int32_t GetObjectCount( const UpnpValuePair *pAttributes, const int32_t iAttributesCount, uint32_t RoleID, const char* pSearchCriteria) = 0;

                    /**
                    * @brief Add new role to the CDS. Roles are the simple, implementation-specific approach to control access to the CDS for different facilities. E.g. SU role allows to change everything in the storage, but other roles (like User) may confine such abilities up to the container called 'home directory'.
                    *
                    * @param[in] pRoleName             name of the new role
                    * @param[in] pHomeDir              home directory for new role
                    * @param[out] pRoleId              pointer to variable that receives identifier for created role
                    * @return                          EUpnpDBOk on success, error code otherwise
                    */
                    virtual UpnpDBErrCodes AddRole( const char *pRoleName, const char *pHomeDir, uint32_t *pRoleId ) = 0;

                    /**
                    * @brief Adds observer which will receive notifies on database changes
                    * 
                    * @param[in] pObserver  pointer to observer implementation
                    **/
                    virtual void AdviseObserver( IUpnpDatabaseObserver *pObserver ) = 0;
                    
                    /**
                    * @brief Remove observer which will receive notifies on database changes
                    * 
                    * @param[in] pObserver  pointer to observer implementation
                    **/
                    virtual void RemoveObserver( IUpnpDatabaseObserver *pObserver ) = 0;
            };

            /**
            * @brief Monitor media directories for changes
            **/
            class IUpnpFilesystemWatcher : public INetRefCounted
            {
            public:
                virtual ~IUpnpFilesystemWatcher() {}

                /**
                * @brief Start file system changes monitoring
                * 
                * @return	EUpnpDeviceOk on success, error code otherwise
                **/
                virtual UpnpDeviceErrCodes StartAutoUpdate() = 0;

                /**
                * @brief Stop file system changes monitoring
                * 
                * @return	EUpnpDeviceOk on success, error code otherwise
                **/
                virtual UpnpDeviceErrCodes StopAutoUpdate() = 0;

                /**
                 * @brief Add path to be watched.
                 *
                 * @param[in] pPath      - path to be watched.
                 * @return Number of added items.
                 **/
                virtual int32_t AddPath(const char *pPath ) = 0;

                /**
                 * @brief Remove path from watching list.
                 * 
                 * @param[in] pPath      - path to be removed from watch.
                 * @return None
                 **/
                virtual int32_t RemovePath(const char *pPath ) = 0;
            };

            /**
            * @brief Log messages from UPnP stack
            **/
            class IUpnpLogger : public INetRefCounted
            {
            public:
                virtual ~IUpnpLogger() {}

                /**
                * @brief Configures maximum log level
                *
                * Upper log level enables all lower levels
                * 
                * @param[in] iLevel max message level to log
                * @return None
                **/
                virtual void SetLogLevel(UpnpLogLevel iLevel) = 0;

                /**
                * @brief Make entry according log level
                * 
                * @param[in] pArg       custom logger instance argument
                * @param[in] iLevel     log level of message
                * @param[in] pBuffer    memory block relevant to the message
                * @param[in] iBufferLen size of memory block
                * @param[in] pFormat    format string
                * @param[in] ...        arguments for format string
                **/     
                virtual void LogString(void *pArg, UpnpLogLevel iLevel, const char *pBuffer, int32_t iBufferLen, const char *pFormat, ...) = 0;
            };

            /**
            * @brief Declares base client description interface
            **/
            class IUpnpClientDescriptor : public INetRefCounted
            {
            public:
                virtual ~IUpnpClientDescriptor() {}

                /**
                * @brief Retrieves client address
                * 
                * @return address string 
                **/
                virtual const char * GetAddress() const = 0;

                /**
                * @brief Retrieves client port
                * 
                * @return used client port 
                **/
                virtual uint16_t GetPort() const = 0;

                /**
                * @brief Retrieves client vendor
                * 
                * @param[out] pCompatibility Detected device type, optional
                * @return                    vendor string
                **/
                virtual const char * GetVendor( UpnpVendorCompatibility *pCompatibility ) const = 0;

                /**
                * @brief Retrieves requested file name
                * 
                * @return file name wide-char string  
                **/
                virtual const char * GetRequestedFileName() const = 0;
            };

            class IUpnpService;
            /**
            * @brief Declares UPnP client handler interface
            **/
            class IUpnpClientHandler : public IUpnpClientDescriptor
            {
            public:
                virtual ~IUpnpClientHandler() {}

                /**
                * @brief Starts process messages
                * 
                * @return None
                **/
                virtual int32_t Start() = 0;

                /**
                * @brief Requested stop client(async)
                * 
                * @return None
                **/
                virtual void RequestStop() = 0;

                /**
                * @brief Retrieves local network client info
                * 
                * @return Return sockaddr_storage
                **/
                virtual const sockaddr_storage * GetLocalInfo()  = 0;

                /**
                * @brief Retrieves remote network client info
                * 
                * @return Return sockaddr_storage
                **/
                virtual const sockaddr_storage * GetRemoteInfo() = 0;

                /**
                * @brief Configures HTTP connection
                * 
                * @param[in] bCloseOnResponse true - enable close network connection after response, false - keep connection alive for further requests
                * @return                     None
                **/
                virtual void SetHttpConnectionType(bool bCloseOnResponse) = 0;

                /**
                * @brief Adds extended data to client
                * 
                * @param[in] pData custom client data
                * @return          0 - if OK, negative otherwise 
                **/
                virtual int32_t SetUserData(void *pData) = 0;

                /**
                * @brief Retrieves stored custom data
                * 
                * @param[out] pData pointer to stored custom data
                * @return           0 - if OK, negative otherwise  
                **/
                virtual int32_t GetUserData(void **pData) = 0;

                /**
                * @brief Receives network request
                * 
                * @param[in,out] pData memory block for receiving
                * @param[in]           iDataLen size of memory block
                * @param[out]          pRecvRequestLen size of received data
                * @return              0 - if OK, negative otherwise
                **/
                virtual int32_t ReceiveData( uint8_t *pData, int32_t iDataLen, int32_t *pRecvRequestLen ) = 0;

                /**
                * @brief Sends HTTP response
                * 
                * @param[in] aHttpResponseCode     response code
                * @param[in] pBuffer               response body, must be NULL when bUseTimeUnits is true
                * @param[in] iBufferLen            content length
                * @param[in] pMimeType             content MIME type 
                * @param[in] iRangeStart           Start offset of send data chunk
                * @param[in] iRangeEnd             end offset of send data chunk
                * @param[in] pAdditionalHeaders    custom headers
                * @param[in] iFileTime             last modification file datetime 
                * @param[in] bIgnoreConnectionType true - do not close connection after sending data, even if set by client
                * @param[in] bUseTimeUnits         true - iBufferLen and iRangeStart and iRangeEnd represent time offsets in milliseconds
                * @return                          0 - if OK, negative otherwise
                **/
                virtual int32_t HttpSendResponse(int32_t aHttpResponseCode, const uint8_t *pBuffer, int64_t iBufferLen, const char *pMimeType, int64_t iRangeStart, int64_t iRangeEnd, const char *pAdditionalHeaders, int64_t iFileTime, bool bIgnoreConnectionType, bool bUseTimeUnits, HttpTransferEncoding TransfterEncoding = HttpTransferEncodingNone) = 0;

                /**
                * @brief Sends whole file
                * 
                * @param[in] pDataSource        data source instance to send data from
                * @param[in] bUseTimeUnits      true indicates that pDataSource and iRangeStart and iRangeEnd use milliseconds instead of bytes
                * @param[in] iRangeStart        start position for sending(bytes)
                * @param[in] iRangeEnd          end position for sending(bytes)
                * @param[in] bHeadersOnly       send headers only, not send file content
                * @param[in] pMimeType          file MIME-type
                * @param[in] pAdditionalHeaders custom headers
                * @return                       count of send bytes on success, negative on fail
                **/
                virtual int64_t HttpSendFile(IDataSource *pDataSource, bool bUseTimeUnits, int64_t iRangeStart, int64_t iRangeEnd, bool bHeadersOnly, const char *pMimeType, const char *pAdditionalHeaders, HttpTransferEncoding TransfterEncoding = HttpTransferEncodingNone) = 0;

                /**
                * @brief Sends raw buffer data
                * 
                * @param[in] pBuffer               response body, must be NULL when bUseTimeUnits is true
                * @param[in] iBufferLen            content length
                * @return                          count of bytes sent, will be less than iBufferLen in case of error
                **/
                virtual int64_t SendBuffer( const uint8_t *pBuffer, int64_t iBufferLen ) = 0;

                /**
                * @brief Sends UPnP error response
                * 
                * @param[in] pService             a pointer to @ref IUpnpService object which returned an error (to be able to generate service-specific error responses)
                * @param[in] ErrCode              response code
                * @return                         0 - if OK, negative otherwise 
                **/
                virtual int32_t SendUpnpErrorResponse( IUpnpService* pService, UpnpServiceErrCodes ErrCode ) = 0;

                /**
                * @brief Collects entire request from chunked form  
                * 
                * @param[in]  pData     first chunk of request
                * @param[in]  iDataLen  size of chunk
                * @param[out] piRealLen size of entire request
                * @return               Entire request or NULL if failed
                **/
                virtual uint8_t* HttpCollectRequestData( const uint8_t *pData, int32_t iDataLen, int32_t *piRealLen = NULL ) = 0;

                /**
                * @brief Frees collected request.
                * 
                * Use after IUpnpClientHandler::HttpCollectRequestData() and processing request to avoid memory leaks.
                * 
                * @param[in] pRequestData entire request, collected by IUpnpClientHandler::HttpCollectRequestData 
                * @return                 None
                **/
                virtual void  HttpFreeRequestData( uint8_t *pRequestData ) = 0;
            };

            /**
            * @brief Consumer that receives notifies from device discoverer
            **/
            class IUpnpFlowConsumer
            {
            public:
                virtual ~IUpnpFlowConsumer() {}

                /**
                * @brief Get consumer role. Servers are active listeners that reply to search events and Clients are passive listeners that collect notifies.
                *
                * Depending on role only specific events will trigger callbacks
                * 
                * @return Return @ref UpnpFlowRole
                **/
                virtual UpnpFlowRole GetRole() = 0;

                /**
                * @brief Called on Search event
                * 
                * @param[in] pRemoteHost  host looking for service
                * @param[in] usRemotePort remote port
                * @param[in] pST          service type
                * @param[in] pLocalAddr   define local network connection
                * @return                 None
                **/
                virtual void OnUpnpSearchEvent( const char *pRemoteHost, uint16_t usRemotePort, const char *pST, const sockaddr_storage *pLocalAddr ) = 0;

                /**
                * @brief Called on service or device changing
                * 
                * @param[in] aType   device type
                * @param[in] pDevice pointer to active device, which generate event
                * @return            None
                **/
                virtual void OnUpnpDeviceActivityEvent( UpnpDeviceSpecType aType, const IUpnpDeviceDescriptor *pDevice ) = 0;
            };

            class IUpnpServiceDescriptor;
            /**
            * @brief Declares UPnP service interface
            **/
            class IUpnpService : public INetRefCounted
            {
            public:
                virtual ~IUpnpService() {}

                /**
                * @brief Initializes service
                * 
                * @param[in] pControlUri      control URI 
                * @param[in] pEventUri        event URI
                * @param[in] pDescriptionUri  service description URI
                * @param[in] pResourceHandler describes the resource associated with the service
                * @return Return @ref UpnpDeviceErrCodes
                **/
                virtual MainConcept::NetworkStreaming::UpnpStack::UpnpDeviceErrCodes Init( const char *pControlUri, const char *pEventUri, const char *pDescriptionUri, MainConcept::NetworkStreaming::UpnpStack::IUpnpResourceHandler *pResourceHandler ) = 0;

                /**
                * @brief Runs service
                * 
                * @return Return @ref UpnpDeviceErrCodes
                **/
                virtual UpnpDeviceErrCodes Start() = 0;

                /**
                * @brief Stops service
                * 
                * @return Return @ref UpnpDeviceErrCodes
                **/
                virtual UpnpDeviceErrCodes Stop() = 0;

                /**
                * @brief Processes request
                * 
                * @param[in] pClient  source of request
                * @param[in] pData    request body
                * @param[in] iDataLen request len
                * @return Return @ref UpnpDeviceErrCodes
                **/
                virtual MainConcept::NetworkStreaming::UpnpStack::UpnpDeviceErrCodes ProcessRequest( MainConcept::NetworkStreaming::UpnpStack::IUpnpClientHandler *pClient, const uint8_t *pData, int32_t iDataLen ) = 0;

                /**
                * @brief Retrieves self-description
                * 
                * @return constant pointer to @ref IUpnpServiceDescriptor
                **/
                virtual const IUpnpServiceDescriptor *GetServiceDescription() const = 0;

                /**
                * @brief Sets external log tool
                * 
                * @param[in] pLogger    pointer to instance of IUpnpLogger implementation 
                * @param[in] pLoggerArg extended IUpnpLogger argument, may be NULL if non-exist 
                * @return               None
                **/
                virtual void SetLogger(IUpnpLogger *pLogger, void *pLoggerArg) = 0;

                 /**
                * @brief Returns service-specific error description string
                * 
                * @param[in] ErrCode    error code 
                * @return               Error description string
                **/
                virtual const char* GetUpnpErrorCodeString( UpnpServiceErrCodes ErrCode) = 0;
            };

            class IUpnpTranscoder;
            class IUpnpProtocolHandler;

            /**
            * @brief Declares Content Directory service interface
            **/
            class IUpnpContentDirectory : public IUpnpService
            {
            public:
                virtual ~IUpnpContentDirectory() {}

                /**
                * @brief Provides Thumbnail's generator(producer)
                * 
                * @param[in] pThumbNailProducer valid pointer to instance of @ref IThumbnailProducer
                * @return                       0 for success, negative on fail
                **/
                virtual int32_t AdviseThumbnailProducer( IThumbnailProducer *pThumbNailProducer ) = 0;

                /**
                * @brief Advises media data transcoder to service; multiple transcoders might be advised.
                * 
                * @param[in] pTranscoder pre-allocated valid pointer on transcoder interface
                * @return                0 for success, negative on fail
                **/
                virtual int32_t AdviseTranscoder( IUpnpTranscoder *pTranscoder ) = 0;

                /**
                * @brief Controls how internal media item resources are written to the browse response
                * 
                * @param[in] bPreferTranscoded specify true to place transcoded resources above original file and false to place original file resource first
                **/
                virtual void PreferTranscoded( bool bPreferTranscoded ) = 0;

                /**
                * @brief Advises protocol resource handler. Can be used to generate resources for specific protocol
                * 
                * @param[in] pHandler pre-allocated valid pointer on handler interface
                * @return                0 for success, negative on fail
                **/
                virtual int32_t AdviseProtocolHandler( IUpnpProtocolHandler *pHandler ) = 0;

                /**
                * @brief Controls how internal and custom media item resources are written to the browse response
                * 
                * @param[in] bPreferCustom specify true to place custom resources from IUpnpProtocolHandler above original file and transcoded versions, specify false to place original file and transcoded resources first
                **/
                virtual void PreferCustom( bool bPreferCustom ) = 0;

                /**
                * @brief Provides media uri path for the custom resources
                * 
                * @param[in] pMediaUriPath null terminated string, which represents media uri path for the custom resource (example: "my_media_content/"). Every method's call will add new path to the list.
                **/
                virtual void AdwiseCustomMediaUriPath( const char *pMediaUriPath ) = 0;
            };

            /**
            * @brief Allows insertion of custom resources into Content Directory items on Browse or Search response
            **/
            class IUpnpProtocolHandler : public INetRefCounted
            {
            public:
                virtual ~IUpnpProtocolHandler() {}

                /**
                * @brief Get list of custom resources for specified item for content directory Browse or Search response
                * 
                * @param[in] pClient			Upnp client handler instance, can be used to obtain client connection info
                * @param[in] pUrl				Original content directory request URL, can be used to obtain server address to which client is sending requests
                * @param[in] pProtocol			Protocol for which custom resources are requested
                * @param[in] pItem				Content directory item for which additional resources are requested
                * @param[out] pResources		Array with custom resources
                * @param[out] pResourceCount	Count of items in pResources array
                *
                * @return	MCNetResultOK when pResources contains valid resource array, or error code otherwise
                **/
                virtual MCNETRESULT EnumResources( IUpnpClientHandler *pClient, const char *pUrl, const char *pProtocol, const IUpnpContentDirectoryItem *pItem, UpnpProtocolHandlerResource **pResources, int32_t *pResourceCount ) = 0;
                
                /**
                * @brief Release memory allocated by EnumResources
                * 
                * @param[in] pResources	resource array returned by EnumResources
                * @param[in] iResourceCount	Count of items in pResources array
                *
                **/
                virtual void FreeEnumResources( UpnpProtocolHandlerResource *pResources, int32_t iResourceCount) = 0;

                /**
                * @brief Check if default resources should be added to content directory item
                * 
                * @param[in] pProtocol			Protocol for which custom resources are requested
                * @param[in] pItem				Content directory item for which additional resources are requested
                * @return	true if default resources should be added to item, false - to skip generating default resources
                **/
                virtual bool AllowDefaultResource( const char *pProtocol, const IUpnpContentDirectoryItem *pItem ) = 0;
            };

            /**
            * @brief Declares Connection Manager UPnP service interface
            **/
            class IUpnpConnectionManager : public IUpnpService
            {
            public:
                virtual ~IUpnpConnectionManager() {}

                /**
                * @brief Adds supported protocol
                * 
                * @param[in] protocol new protocol descriptor 
                * @return             Return @ref UpnpDeviceErrCodes 
                **/
                virtual UpnpDeviceErrCodes AddProtocol( const UpnpDeviceProtocolInfo* protocol ) = 0;

                /**
                * @brief Enumerates current active protocols
                * 
                * @param[in] idx index number of protocol
                * @return        protocol descriptor or NULL 
                **/
                virtual const UpnpDeviceProtocolInfo * GetProtocol( uint32_t idx ) const = 0;

                /**
                * @brief Retrieves count of active protocols
                * 
                * @return count of active protocols
                **/
                virtual uint32_t GetProtocolCount() const = 0;
            };

            /**
            * @brief Declares Media Receiver register service interface
            **/
            class IUpnpMediaReceiverRegistrar : public IUpnpService
            {
            public:
                virtual ~IUpnpMediaReceiverRegistrar() {}
            };

            class IUpnpAVTransportObserver;
            /**
            * @brief Declares A/V Transport service interface
            **/
            class IUpnpAVTransport : public IUpnpService
            {
            public:
                virtual ~IUpnpAVTransport() {}

                /**
                * @brief Provides external observer
                * 
                * @param[in] pObserver valid pointer to IUpnpAVTransportObserver instance
                * @return              None
                **/
                virtual void SetObserver( IUpnpAVTransportObserver *pObserver ) = 0;

                /**
                * @brief Sends last change notify
                * 
                * @param[in] pInstanceID    service instance ID
                * @param[in] pProperties    pointer to attachable properties
                * @param[in] iPropertyCount count of properties
                * @param[in] pSID           SID string
                * @return                   Return @ref UpnpDeviceErrCodes
                **/
                virtual MainConcept::NetworkStreaming::UpnpStack::UpnpDeviceErrCodes SendLastChangeNotify(const char *pInstanceID, MainConcept::NetworkStreaming::UpnpStack::UpnpProperty *pProperties, int32_t iPropertyCount, const char *pSID = NULL) = 0;

                /**
                * @brief Send response
                * 
                * @param[in] pClient        client - destination of response
                * @param[in] pAction        response action
                * @param[in] pProperties    list of properties with response
                * @param[in] iPropertyCount count of properties
                * @return                   Return @ref UpnpDeviceErrCodes
                **/
                virtual MainConcept::NetworkStreaming::UpnpStack::UpnpDeviceErrCodes SendAVTransportResponse(MainConcept::NetworkStreaming::UpnpStack::IUpnpClientHandler *pClient, const char*pAction, MainConcept::NetworkStreaming::UpnpStack::UpnpValuePair *pProperties, int32_t iPropertyCount) = 0;
            };

            class IUpnpRenderingControlObserver;
            /**
            * @brief Declares Rendering Control service interface
            **/
            class IUpnpRenderingControl : public IUpnpService
            {
            public:
                virtual ~IUpnpRenderingControl() {}

                /**
                * @brief Provides external observer
                * 
                * @param[in] pObserver valid pointer to IUpnpRenderingControlObserver implementation
                * @return              None
                **/
                virtual void SetObserver( IUpnpRenderingControlObserver *pObserver ) = 0;

                /**
                * @brief Sends last change notify
                * 
                * @param[in] pInstanceID    service instance ID
                * @param[in] pProperties    pointer to attachable properties
                * @param[in] iPropertyCount count of properties
                * @param[in] pSID           SID string
                * @return                   Return @ref UpnpDeviceErrCodes
                **/
                virtual UpnpDeviceErrCodes SendLastChangeNotify(const char *pInstanceID, UpnpProperty *pProperties, int32_t iPropertyCount, const char *pSID = NULL) = 0;

                /**
                * @brief Send response
                * 
                * @param[in] pClient        client - destination of response
                * @param[in] pAction        response action
                * @param[in] pProperties    list of properties with response
                * @param[in] iPropertyCount count of properties
                * @return                   Return UpnpDeviceErrCodes
                **/
                virtual UpnpDeviceErrCodes SendRenderingControlResponse(IUpnpClientHandler *pClient, const char *pAction, UpnpValuePair *pProperties, int32_t iPropertyCount) = 0;
            };

            class IUpnpDevice;
            /**
            * @brief Declares main service observer interface
            **/
            class IUpnpServiceObserver
            {
            public:
                virtual ~IUpnpServiceObserver() {}
                /**
                * @brief Called on client subscribing
                * 
                * @param[in] pDevice            client device descriptor
                * @param[in] pServiceDescriptor requested service descriptor
                * @param[in] pSID               SID string 
                * @param[in] pCallbackAddr      callback address
                * @param[in] pCallbackURI       callback URI
                * @return                       None
                **/
                virtual void OnClientSubscribed( IUpnpDevice *pDevice, IUpnpServiceDescriptor *pServiceDescriptor, const char *pSID, const sockaddr_storage *pCallbackAddr, const char *pCallbackURI ) = 0;

                /**
                * @brief Called on client unsubscribed from service
                * 
                * @param[in] pDevice            client device descriptor
                * @param[in] pServiceDescriptor Service description
                * @param[in] pSID               pSID
                * @return                       None
                **/
                virtual void OnClientUnSubscribed( IUpnpDevice *pDevice, IUpnpServiceDescriptor *pServiceDescriptor, const char *pSID ) = 0;
            };

            /**
            * @brief A/V Transport service observer interface
            **/
            class IUpnpAVTransportObserver : public IUpnpServiceObserver
            {
            public:
                virtual ~IUpnpAVTransportObserver() {}

                /**
                * @brief Called on A/V Transport event
                * 
                * @param[in] pDevice        device descriptor
                * @param[in] pService       A/V Transport service descriptor
                * @param[in] pClient        client descriptor
                * @param[in] aNotifyType    notify type
                * @param[in] pRequest       request body
                * @param[in] pArguments     list of arguments
                * @param[in] iArgumentCount count of arguments
                * @return                   true on success, otherwise false
                **/
                virtual bool OnUpnpAVTransportEvent( IUpnpDevice *pDevice, IUpnpAVTransport *pService, IUpnpClientHandler *pClient, UpnpAVTransportAction aNotifyType, const uint8_t *pRequest, UpnpValuePair *pArguments, int32_t iArgumentCount ) = 0;
            };

            /**
            * @brief Rendering control observer interface
            **/
            class IUpnpRenderingControlObserver : public IUpnpServiceObserver
            {
            public:
                virtual ~IUpnpRenderingControlObserver() {}

                /**
                * @brief Called on rendering control event
                * 
                * @param[in] pDevice        device descriptor
                * @param[in] pService       Rendering control service descriptor
                * @param[in] pClient        client descriptor
                * @param[in] aNotifyType    notify type
                * @param[in] pRequest       request body
                * @param[in] pArguments     list of arguments
                * @param[in] iArgumentCount count of arguments
                * @return                   true on success, otherwise false
                **/
                virtual bool OnUpnpRenderingControlEvent( IUpnpDevice *pDevice, IUpnpRenderingControl *pService, IUpnpClientHandler *pClient, UpnpRenderingControlAction aNotifyType, const uint8_t *pRequest, UpnpValuePair *pArguments, int32_t iArgumentCount ) = 0;
            };

            /**
            * @brief Declares device event observer
            **/
            class IUpnpDeviceObserver
            {
            public:
                virtual ~IUpnpDeviceObserver() {}

                /**
                * @brief Called on device event
                * 
                * @param[in] pDevice   device descriptor
                * @param[in] pClient   client descriptor
                * @param[in] eventType notify type
                * @param[in] pData     notify data
                * @param[in] DataSize  data size
                * @return              None
                **/
                virtual void OnUpnpDeviceEvent( IUpnpDevice *pDevice, IUpnpClientDescriptor *pClient, UpnpDeviceNotifies eventType, void *pData, int32_t DataSize ) = 0;
            };

            class IUpnpDeviceDescriptor;

            /**
            * @brief Main UPnP Device interface
            **/
            class IUpnpDevice : public IUpnpFlowConsumer, public INetRefCounted
            {
            public:
                virtual ~IUpnpDevice() {}

                /**
                * @brief Initializes device instance
                * 
                * @param[in] aPort                 local network port
                * @param[in] pAddress              local network address
                * @param[in] uiTTL                 TTL for multicast traffic (some system might have HW limit to 1, the default TTL value for DLNA is 4)
                * @param[in] pDeviceDescriptionUri URI of device description
                * @param[in] pResourceHandler      describes the resource associated with device instance
                * @return                          Return @ref UpnpDeviceErrCodes
                **/
                virtual MainConcept::NetworkStreaming::UpnpStack::UpnpDeviceErrCodes Init( uint16_t aPort, const char *pAddress, uint32_t uiTTL, const char *pDeviceDescriptionUri, MainConcept::NetworkStreaming::UpnpStack::IUpnpResourceHandler *pResourceHandler ) = 0;

                /**
                * @brief Starts working
                * 
                * @return Return @ref UpnpDeviceErrCodes
                **/
                virtual UpnpDeviceErrCodes Start() = 0;

                /**
                * @brief Stops working
                * 
                * @return Return @ref UpnpDeviceErrCodes
                **/
                virtual UpnpDeviceErrCodes Stop() = 0;

                /**
                * @brief Attaches service to device
                * 
                * @param pService new service 
                * @return Return @ref UpnpDeviceErrCodes
                **/
                virtual UpnpDeviceErrCodes AdviseService( IUpnpService *pService ) = 0;

                /**
                * @brief Retrieves device description
                * 
                * @return pointer to @ref IUpnpDeviceDescriptor instance associated with current device
                **/
                virtual const IUpnpDeviceDescriptor *GetDeviceDescription() const = 0;

                /**
                * @brief Enumerates device services
                * 
                * @param[in] uiIndex index number of service
                * @return            pointer to @ref IUpnpService instance
                **/
                virtual IUpnpService * EnumServices( uint32_t uiIndex ) const = 0;

                /**
                * @brief Retrieves amount of provided services
                * 
                * @return amount of services on device 
                **/
                virtual uint32_t GetServiceCount() const = 0;

                /**
                * @brief Called on service start
                * 
                * @param[in] pDescription describe started service
                * @return                 None
                **/
                virtual void OnServiceStart( const IUpnpServiceDescriptor *pDescription ) = 0;

                /**
                * @brief Called on service stop
                * 
                * @param[in] pDescription describe stopped service
                * @return                 None
                **/
                virtual void OnServiceStop( const IUpnpServiceDescriptor *pDescription ) = 0;

                /**
                * @brief Provides external device observer
                * 
                * @param[in] pObserver pointer to IUpnpDeviceObserver implementation
                * @return Return @ref UpnpDeviceErrCodes
                **/
                virtual UpnpDeviceErrCodes SetUpnpObserver( IUpnpDeviceObserver *pObserver ) = 0;

                /**
                * @brief Retrieves device observer
                * 
                * @return Return @ref IUpnpDeviceObserver or NULL when no observer was supplied from the outside
                **/
                virtual IUpnpDeviceObserver * GetUpnpObserver() const = 0;

                /**
                * @brief Retrieves active client amount
                * 
                * @return amount of client 
                **/
                virtual uint32_t GetActiveClientCount() const = 0;

                /**
                * @brief Enumerates device clients
                * 
                * @param[in] uiIndex index number of client
                * @return            pointer to @ref IUpnpClientDescriptor associated with connected client, caller should release them after using
                **/
                virtual IUpnpClientDescriptor * EnumActiveClients( uint32_t uiIndex ) const = 0;

                /**
                * @brief Provide external log interface
                * 
                * @param[in] pLogger    implementation of IUpnpLogger
                * @param[in] pLoggerArg extended argument of log object
                * @return               None
                **/
                virtual void SetLogger(IUpnpLogger *pLogger, void *pLoggerArg) = 0;

                /**
                * @brief This method allows to set device parameters
                * 
                * @param[in] aType      parameter type
                * @param[in] pValue     valid parameter value
                * @param[in] iValueSize actual parameter size
                * @return               Returns UpnpDeviceErrCodes on success and error code otherwise
                **/
                virtual UpnpDeviceErrCodes SetParameter( UPNPDEVICEPARAMTYPE aType, void *pValue, int32_t iValueSize ) = 0;
            };

            /**
            * @brief Declares content object resource
            **/
            class IUpnpContentObjectResource : public INetRefCounted
            {
            public:
                virtual ~IUpnpContentObjectResource() {}

                /**
                * @brief Retrieves resource network address or scope ID for the ipv6 resources
                * 
                * @return network address (resource ip&sub_net_mask = network address) or scope ID for the ipv6 resources
                **/
                virtual uint32_t GetNetworkAddress() const = 0;

                /**
                * @brief Retrieves resource sub network mask (for ipv6 always 0)
                * 
                * @return sub network mask for ipv6 0
                **/
                virtual uint32_t GetSubNetworkMask() const = 0;

                /**
                * @brief Retrieves resource URL 
                * 
                * @return URL associated with resource 
                **/
                virtual const char *GetUrl() const = 0;

                /**
                * @brief Retrieves protocol info
                * 
                * @return protocol info string 
                **/
                virtual const char *GetProtocolInfo() const = 0;

                /**
                * @brief Retrieves resolution
                * 
                * @return resolution string 
                **/
                virtual const char *GetResolution() const = 0;

                /**
                * @brief Retrieves duration
                * 
                * @return duration in milliseconds 
                **/
                virtual int64_t GetDuration() const = 0;

                /**
                * @brief Retrieves resource size
                * 
                * @return size in bytes 
                **/
                virtual int64_t GetSize() const = 0;

                /**
                * @brief Enumerates attributes
                * 
                * @param[in] uiAttributeIndex index number attribute
                * @return                    Returns pointer to attribute structure or NULL if uiAttributeIndex is out of bounds
                **/
                virtual const UpnpValuePair *EnumAttributes(uint32_t uiAttributeIndex) const = 0;

                /**
                * @brief Retrieves attribute by name
                * 
                * @param[in] pAttributeName attribute name
                * @return                   attribute value string or NULL if not found
                **/
                virtual const char *GetAttribute(const char *pAttributeName) const = 0;
            };

            /**
            * @brief Declares content object (control point single item description)
            **/
            class IUpnpContentObject : public INetRefCounted
            {
            public:
                virtual ~IUpnpContentObject() {}

                /**
                * @brief Retrieves object ID
                * 
                * @return String form of object identifier
                **/
                virtual const char *GetId() = 0;

                /**
                * @brief Retrieves parent ID 
                * 
                * @return String form of parent object identifier 
                **/
                virtual const char *GetParentId() = 0;

                /**
                * @brief Retrieves device ID 
                * 
                * @return String form of device identifier
                **/
                virtual const char *GetDeviceId() = 0;

                /**
                * @brief Retrieves content object type
                * 
                * @return Return @ref UpnpContentMediaType 
                **/
                virtual UpnpContentMediaType GetType() = 0;

                /**
                * @brief Retrieves update ID
                * 
                * @return Return Update identifier
                **/
                virtual int32_t GetUpdateId() = 0;

                /**
                * @brief Retrieves object name
                * 
                * @return Return object name
                **/
                virtual const char *GetName() = 0;

                /**
                * @brief Retrieves type name
                * 
                * @return Return string form type name
                **/
                virtual const char *GetTypeName() = 0;

                /**
                * @brief Retrieves control URL
                * 
                * @param[out] pServiceType if present return service type for control url
                * @param[in] uiIndex       index number control url
                * @return                  string form of control url
                **/
                virtual const char *GetControlUrl( UpnpServiceType *pServiceType = NULL, uint32_t uiIndex = 0 ) = 0;

                /**
                * @brief Retrieves eventing control url
                * 
                * @param[out] pServiceType if present return service type for eventing control url
                * @param[in]  uiIndex      index number eventing control url (if several)
                * @return                  String form eventing control url
                **/
                virtual const char *GetEventingControlUrl( UpnpServiceType *pServiceType = NULL, uint32_t uiIndex = 0 ) = 0;

                /**
                * @brief Retrieves child count
                * 
                * @return Amount of child 
                **/
                virtual int32_t GetChildCount() = 0;

                /**
                * @brief Retrieves resource count
                * 
                * @return Amount of resources  
                **/
                virtual int32_t GetResourceCount() = 0;

                /**
                * @brief Enumerates resources
                * 
                * @param[in]  uiResourceIndex index of resource
                * @return                    Constant pointer to resource or NULL if uiResourceIndex is out of bounds.
                **/
                virtual const IUpnpContentObjectResource *EnumResources(uint32_t uiResourceIndex) = 0;

                /**
                * @brief Enumerates attributes
                * 
                * @param[in] uiAttributeIndex index number attribute
                * @return                    Returns pointer to attribute structure or NULL if uiAttributeIndex is out of bounds
                **/
                virtual const UpnpValuePair *EnumAttributes(uint32_t uiAttributeIndex) = 0;

                /**
                * @brief Retrieve attribute by name
                * 
                * @param[in] pAttributeName attribute name
                * @return                   attribute value or NULL if name not found
                **/
                virtual const char *GetAttribute(const char *pAttributeName) = 0;

                /**
                * @brief Retrieves XML format object description
                * 
                * @return String form of XML document
                **/
                virtual const char *GetXml() = 0;
            };

            class IUpnpControlPoint;

            /**
            * @brief Declares external control point observer
            **/
            class IUpnpControlPointObserver
            {
            public:
                virtual ~IUpnpControlPointObserver() {}

                /**
                * @brief Called on control point event
                * 
                * @param[in] pCP             pointer to control point 
                * @param[in] pUserData       custom data
                * @param[in] eventType       event type
                * @param[in] pData           event data
                * @param[in] DataSize        event data size
                * @param[in] iErrCode        error code
                * @param[in] pAdditionalInfo additional information
                * @return                    None
                **/
                virtual void OnUpnpControlPointEvent( IUpnpControlPoint *pCP, void *pUserData, UpnpControlPointNotifies eventType, void *pData, int32_t DataSize, int32_t iErrCode = 0, void *pAdditionalInfo = NULL ) = 0;
            };

            /**
            * @brief Declares UPnP Control Point
            **/
            class IUpnpControlPoint : public IUpnpFlowConsumer, public INetRefCounted
            {
            public:
                virtual ~IUpnpControlPoint() {}

                /**
                * @brief Initializes control point
                * 
                * @param[in] pNIC         local network interface for control point operations
                * @param[in] EventingPort local port for control point events
                * @return                 Return @ref UpnpDeviceErrCodes 
                **/
                virtual MainConcept::NetworkStreaming::UpnpStack::UpnpDeviceErrCodes Init(const char* pNIC = NULL, uint16_t EventingPort = 40555) = 0;

                /**
                * @brief Start working
                * 
                * @return Return @ref UpnpDeviceErrCodes 
                **/
                virtual UpnpDeviceErrCodes Start() = 0;

                /**
                * @brief Stop working 
                * 
                * @return Return @ref UpnpDeviceErrCodes 
                **/
                virtual UpnpDeviceErrCodes Stop() = 0;

                /**
                * @brief Provides external control point observer
                * 
                * @param[in] pObserver pointer to implementation of @ref IUpnpControlPointObserver
                * @return              None
                **/
                virtual void AdviseUpnpObserver( IUpnpControlPointObserver *pObserver ) = 0;

                /**
                * @brief Browses content directory
                * 
                * @param[in] pControlUrl     control url
                * @param[in] pParentId       parent id
                * @param[in] pSearchCriteria search string
                * @param[in] pSortCriteria   sort string
                * @param[in] iStartFrom      start index
                * @param[in] iRequestedCount requested item count
                * @param[in] pUserData       additional custom data
                * @param[in] uiNetworkAddr   network address for IPv4 family or scope Id for the IPv6
                * @param[in] uiNetMask       sub network mask for IPv4 family or 0 for IPv6
                * @return                    Return @ref UpnpDeviceErrCodes
                **/
                virtual MainConcept::NetworkStreaming::UpnpStack::UpnpDeviceErrCodes BrowseContentDirectory(const char *pControlUrl, const char *pParentId, const char *pSearchCriteria, const char *pSortCriteria, uint32_t uiStartFrom, uint32_t iRequestedCount, void *pUserData, uint32_t uiNetworkAddr = 0, uint32_t uiNetMask = 0) = 0;

                /**
                * @brief Browses available Media Renderers
                * 
                * @param[in] pUserData       additional custom data
                * @param[in] uiNetworkAddr   network address for IPv4 family or scope Id for the IPv6
                * @param[in] uiNetMask       sub network mask for IPv4 family or 0 for IPv6
                * @return              Return @ref UpnpDeviceErrCodes 
                **/
                virtual UpnpDeviceErrCodes BrowseRenderers( void *pUserData, uint32_t uiNetworkAddr = 0, uint32_t uiNetMask = 0 ) = 0;

                /**
                * @brief Sends action request
                * 
                * @param[in] pRequestUserId            request object ID
                * @param[in] pControlUrl               control url
                * @param[in] pUrn                      service urn
                * @param[in] pRequestName              request name
                * @param[in] pAdditionalAttributes     list of additional attributes(if presents)
                * @param[in] iAdditionalAttributeCount amount of additional attributes
                * @return                              Return @ref UpnpDeviceErrCodes 
                **/
                virtual MainConcept::NetworkStreaming::UpnpStack::UpnpDeviceErrCodes SendActionRequest(const void *pRequestUserId, const char *pControlUrl, const char *pUrn, const char *pRequestName, MainConcept::NetworkStreaming::UpnpStack::UpnpValuePair *pAdditionalAttributes = NULL, int32_t iAdditionalAttributeCount = 0) = 0;

                /**
                * @brief Retrieves object info
                * 
                * @param[in]  pControlUrl control url
                * @param[out] pObjectId   object identifier string
                * @param[out] pInfo       object information descriptor
                * @return                 Return @ref UpnpDeviceErrCodes 
                **/
                virtual MainConcept::NetworkStreaming::UpnpStack::UpnpDeviceErrCodes GetObjectInfo(const char *pControlUrl, const char *pObjectId, MainConcept::NetworkStreaming::UpnpStack::IUpnpContentObject **pInfo) = 0;

                /**
                * @brief Subscribes on event
                * 
                * @param[in] pEventingControlUrl list of eventing control url for subscribing
                * @param[in] uiUriCount          count of urls
                * @return                        Return @ref UpnpDeviceErrCodes
                **/
                virtual MainConcept::NetworkStreaming::UpnpStack::UpnpDeviceErrCodes SubscribeForEvents(const char *pEventingControlUrl[], uint32_t uiUriCount) = 0;

                /**
                * @brief Unsubscribes from events
                * 
                * @param[in] pEventingControlUrl list of urls for unsubscribing
                * @param[in] uiUriCount          count of urls
                * @return                        Return @ref UpnpDeviceErrCodes
                **/
                virtual MainConcept::NetworkStreaming::UpnpStack::UpnpDeviceErrCodes UnSubscribeFromEvents(const char *pEventingControlUrl[], uint32_t uiUriCount) = 0;

                /**
                * @brief Provides external log system interface
                * 
                * @param[in] pLogger    pointer to implementation of IUpnpLogger
                * @param[in] pLoggerArg additional custom argument
                * @return               None
                **/
                virtual void SetLogger(IUpnpLogger *pLogger, void *pLoggerArg) = 0;

                /**
                * @brief Sets timeout for response waiting
                * 
                * @param[in] Timeout    timeout in seconds to wait response from device
                * @return               None
                **/
                virtual void SetTimeout( uint32_t Timeout ) = 0;
            };

            /**
            * @brief Declares an abstract interface for data transferring object (this interface can be used for ImportResource or ExportResource data handler)
            **/
            class IUpnpResourceTransferObject : public INetRefCounted
            {
            public:

                virtual ~IUpnpResourceTransferObject() {}

                /**
                * @brief Returns current position in stream
                * 
                * @param[out] i64Units       current position in stream; pointer must be valid
                * @return                    true when position has been retrieved successfully, false otherwise
                **/
                virtual bool GetPosition( int64_t *i64Units ) const = 0;

                /**
                * @brief Returns current transfer ID
                * 
                * @return                    Transfer ID associated with the given object
                **/
                virtual uint32_t GetTransferID() const = 0;

                /**
                * @brief Returns complete stream length
                * 
                * @return                    stream length or -1 if not available
                **/
                virtual int64_t GetLength() const = 0;

                /**
                * @brief Initializes sink object
                * 
                * @param[in] objType         @ref UpnpResourceTransferObject
                * @param[in] pSrcUri         null terminated string with the source URI
                * @param[in] pDstUri         null terminated string with the destination URI
                * @param[in] pNotify         a valid pointer to @ref IUpnpTransferStatusNotifier interface that will receive notifications about transfer status updates
                * @return                    true when stream has been opened, false otherwise
                **/
                virtual bool Init(UpnpResourceTransferObject objType, const char *pSrcUri, const char *pDstUri, IUpnpTransferStatusNotifier *pNotify) = 0;

                /**
                * @brief Starts stream transfer process
                *
                * @param[in] i64StartPos     start position (unit type depends on the implementation), when -1 or 0 stream transfer should be started from the very beginning
                * @param[in] i64StopPos      stop position (unit type depends on the implementation), when -1 stream should be transferred up to the end
                * @return                    true when stream has been opened, false otherwise
                **/
                virtual bool Start( int64_t i64StartPos, int64_t i64StopPos ) = 0;

                /**
                * @brief Stops transfer process
                * 
                * @return                    true when stream has been stopped, false otherwise
                **/
                virtual bool Stop() = 0;

                /**
                * @brief Indicates stream transfer status
                * 
                * @return                    true when stream is transferring, false otherwise
                **/
                virtual bool IsTransferring() = 0;

                /**
                * @brief Retrieves mime type for the given file
                * 
                * @return                    null terminated mime string when success, otherwise NULL
                **/
                virtual const char * GetMimeType() = 0;
            };

            class IUpnpDeviceDiscoverer;

#if defined (__cplusplus)
            extern "C" {
#endif
                /**
                * @brief Initialize UPnP stack internal objects
                * 
                * Use before any other operations and objects
                * 
                * @param[in] get_rc Pointer to get_rc memory manager implementation or NULL to use standard allocators
                * @return           None
                **/
                void MC_UPNP_API PrepareUpnpStack( void *(MC_EXPORT_API *get_rc)(const char*) );

                /**
                * @brief Cleanup UPnP stack internal objects
                * 
                * Use after operation with stack
                * 
                * @return None
                **/
                void MC_UPNP_API CleanupUpnpStack();

                /**
                * @brief Creates instance of new UPnP Media Server object
                * 
                * @param[in] get_rc Pointer to get_rc memory manager implementation or NULL to use standard allocators
                * @return           valid pointer to Media Server Device or NULL
                **/
                IUpnpDevice* MC_UPNP_API GetUpnpMediaServerInterface( void *(MC_EXPORT_API *get_rc)(const char*) );

                /**
                * @brief Creates instance of new UPnP Database object, which can be used with MediaServer (current DB implementation is not thread safe)
                * 
                * @param[in] get_rc               Pointer to get_rc memory manager implementation or NULL to use standard allocators
                * @param[in] pDataBasePath        Path to database file, will be created if not already exists
                * @return                         valid pointer to Database handler or NULL
                **/
                IUpnpDatabase * MC_UPNP_API GetUpnpDatabaseInterface( void *(MC_EXPORT_API *get_rc)(const char*), const char *pDataBasePath, IUpnpDatabaseObserver * pUpnpDatabaseObserver );

                /**
                * @brief Creates instance of new UPnP File System watcher object, which can be used with UpnpDatabase to detect file changes in media directories
                * 
                * @param[in] get_rc Pointer to get_rc memory manager implementation or NULL to use standard allocators
                * @param[in] pFileSystemCommander Pointer to valid file system commander instance @ref IUpnpFileSystemCommander
                * @return           valid pointer to Database handler or NULL
                **/
                IUpnpFilesystemWatcher * MC_UPNP_API GetUpnpFilesystemWatcherInterface( void *(MC_EXPORT_API *get_rc)(const char*), IUpnpFileSystemCommander *pFileSystemCommander );

                /**
                * @brief Creates instance of new UPnP Media Renderer object
                * 
                * @param[in] get_rc Pointer to get_rc memory manager implementation or NULL to use standard allocators
                * @return           valid pointer to Media Renderer Device or NULL
                **/
                IUpnpDevice* MC_UPNP_API GetUpnpMediaRendererInterface( void *(MC_EXPORT_API *get_rc)(const char*) );

                 /**
                * @brief Creates instance of new UPnP File System Commander object (current implementation supports only Linux, Win, OSX local file operations)
                * 
                * @param[in] get_rc Pointer to get_rc memory manager implementation or NULL to use standard allocators
                * @param[in] pDataBase Pointer to valid database instance @ref IUpnpDatabase
                * @return           valid pointer to UPnP File System Commander or NULL
                **/
                IUpnpFileSystemCommander* MC_UPNP_API GetUpnpFileSystemCommander( void *(MC_EXPORT_API *get_rc)(const char*), IUpnpDatabase *pDataBase );

                /**
                * @brief Creates instance of new UPnP Control Point object
                * 
                * @param[in] get_rc      Pointer to get_rc memory manager implementation or NULL to use standard allocators
                * @param[in] pDiscoverer pointer to @ref IUpnpDeviceDiscoverer instance
                * @return                valid pointer to Control Point or NULL
                **/
                IUpnpControlPoint* MC_UPNP_API GetUpnpControlPointInterface( void *(MC_EXPORT_API *get_rc)(const char*), IUpnpDeviceDiscoverer *pDiscoverer );

                 /**
                * @brief Creates instance of new UPnP Content Directory service object
                * 
                * @param[in] get_rc      Pointer to get_rc memory manager implementation or NULL to use standard allocators
                * @param[in] pUpnpDevice pointer to @ref IUpnpDevice instance
                * @param[in] pDataBase pointer to @ref IUpnpDatabase instance
                * @return                valid pointer to Content Directory or NULL
                **/
                IUpnpContentDirectory* MC_UPNP_API GetUpnpContentDirectoryService( void *(MC_EXPORT_API *get_rc)(const char*), IUpnpDevice *pUpnpDevice, IUpnpDatabase *pDataBase );

                 /**
                * @brief Creates instance of new UPnP Connection Manager service object
                * 
                * @param[in] get_rc      Pointer to get_rc memory manager implementation or NULL to use standard allocators
                * @param[in] pUpnpDevice pointer to @ref IUpnpDevice instance
                * @return                valid pointer to Connection Manager service or NULL
                **/
                IUpnpConnectionManager* MC_UPNP_API GetUpnpConnectionManagerService( void *(MC_EXPORT_API *get_rc)(const char*), IUpnpDevice *pUpnpDevice );

                 /**
                * @brief Creates instance of new UPnP Media Receiver Registrar service object
                * 
                * @param[in] get_rc      Pointer to get_rc memory manager implementation or NULL to use standard allocators
                * @param[in] pUpnpDevice pointer to @ref IUpnpDevice instance
                * @return                valid pointer to Media Receiver Registrar service or NULL
                **/
                IUpnpMediaReceiverRegistrar* MC_UPNP_API GetUpnpMediaReceiverRegistrarService( void *(MC_EXPORT_API *get_rc)(const char*), IUpnpDevice *pUpnpDevice );

                 /**
                * @brief Creates instance of new UPnP AV Transport service object
                * 
                * @param[in] get_rc      Pointer to get_rc memory manager implementation or NULL to use standard allocators
                * @param[in] pUpnpDevice pointer to @ref IUpnpDevice instance
                * @return                valid pointer to AV Transport service or NULL
                **/
                IUpnpAVTransport* MC_UPNP_API GetUpnpAVTransportService( void *(MC_EXPORT_API *get_rc)(const char*), IUpnpDevice *pUpnpDevice );

                 /**
                * @brief Creates instance of new UPnP Rendering Control service object
                * 
                * @param[in] get_rc      Pointer to get_rc memory manager implementation or NULL to use standard allocators
                * @param[in] pUpnpDevice pointer to @ref IUpnpDevice instance
                * @return                valid pointer to Rendering Control service or NULL
                **/
                IUpnpRenderingControl* MC_UPNP_API GetUpnpRenderingControlService( void *(MC_EXPORT_API *get_rc)(const char*), IUpnpDevice *pUpnpDevice );

                /**
                * @brief Offers extended API to module
                * 
                * @param[in] func identifier of requested function
                * @return         valid pointer to function or NULL
                **/
                APIEXTFUNC MC_UPNP_API UpnpStackGetAPIExt(uint32_t func);
#if defined (__cplusplus)
            }
#endif
        };
    };
};

/**
* @brief Checks on any container type
* @hideinitializer
**/
#define IS_CONTAINER(x) ( (x) >= MainConcept::NetworkStreaming::UpnpStack::ContentTypeContainer && (x) <= MainConcept::NetworkStreaming::UpnpStack::ContentTypePersonMusicArtist )

/**
* @brief Checks on container storage type
* @hideinitializer
**/
#define IS_CONTAINER_STORAGE(x) ( (x) >= MainConcept::NetworkStreaming::UpnpStack::ContentTypeContainerStorageFolder && (x) <= MainConcept::NetworkStreaming::UpnpStack::ContentTypeContainerStorageSystem )

/**
* @brief Checks on image type
* @hideinitializer
**/
#define IS_IMAGE(x) ( (x) >= MainConcept::NetworkStreaming::UpnpStack::ContentTypeImage && (x) <= MainConcept::NetworkStreaming::UpnpStack::ContentTypeImagePhoto )

/**
* @brief Checks on video type
* @hideinitializer
**/
#define IS_VIDEO(x) ( (x) >= MainConcept::NetworkStreaming::UpnpStack::ContentTypeVideo && (x) <= MainConcept::NetworkStreaming::UpnpStack::ContentTypeVideoMusicVideoClip )

/**
* @brief Checks on audio type
* @hideinitializer
**/
#define IS_AUDIO(x) ( (x) >= MainConcept::NetworkStreaming::UpnpStack::ContentTypeAudio && (x) <= MainConcept::NetworkStreaming::UpnpStack::ContentTypeAudioBook )

#define IS_PLAYLIST(x) ( (x) == MainConcept::NetworkStreaming::UpnpStack::ContentTypePlaylistItem )

#endif //__MC_UPNP_DEVICE_API_H__
