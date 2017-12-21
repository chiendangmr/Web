/**
@file   upnp_common.h
@brief  UPnP Common declaration API

@verbatim
File: upnp_device_api.h
Desc: UPnP Device API 

Copyright (c) 2015 MainConcept GmbH or its affiliates.  All rights reserved.

MainConcept and its logos are registered trademarks of MainConcept GmbH or its affiliates.  
This software is protected by copyright law and international treaties.  Unauthorized 
reproduction or distribution of any portion is prohibited by law.
@endverbatim
**/

#if !defined (__MC_UPNP_COMMON_H__)
#define __MC_UPNP_COMMON_H__

/**
* @def MC_UPNP_API
* @brief Defines calling convention
* @hideinitializer
**/
#if defined(WIN32)
#define MC_UPNP_API __cdecl
#else
#define MC_UPNP_API
#endif

#include "net_common.h"

/**
* @brief Defines the name of vendor specific attribute
* @hideinitializer
**/
#define UPNP_MCDLNA_FILEPATH    "mcdlna:filepath"
#define UPNP_MCDLNA_DATE        "mcdlna:date"
#define DIVX_CUSTOM_RESOURCE    "divx:"

/**
* @brief Defines the default DB role ID
* @hideinitializer
**/
#define DEFAULT_ROLE_ID 0

/**
  All available UPNP attributes
*/
#define UPNP_ATTR_ID_TEXT                                                       "@id"
#define UPNP_ATTR_PARENT_ID_TEXT                                                "@parentID"
#define UPNP_ATTR_REF_ID_TEXT                                                   "@refID"
#define UPNP_ATTR_RESTRICTED_TEXT                                               "@restricted"
#define UPNP_ATTR_SEARCHABLE_TEXT                                               "@searchable"
#define UPNP_ATTR_CHILDCOUNT_TEXT                                               "@childCount"
#define UPNP_ATTR_DC_TITLE_TEXT                                                 "dc:title"
#define UPNP_ATTR_DC_CREATOR_TEXT                                               "dc:creator"
#define UPNP_ATTR_UPNP_CLASS_TEXT                                               "upnp:class"
#define UPNP_ATTR_UPNP_CLASS_NAME_TEXT                                          "upnp:class@name"
#define UPNP_ATTR_UPNP_SEARCHCLASS_TEXT                                         "upnp:searchClass"
#define UPNP_ATTR_UPNP_SEARCHCLASS_NAME_TEXT                                    "upnp:searchClass@name"
#define UPNP_ATTR_UPNP_SEARCHCLASS_INCLUDEDERIVED_TEXT                          "upnp:searchClass@includeDerived"
#define UPNP_ATTR_UPNP_CREATECLASS_TEXT                                         "upnp:createClass"
#define UPNP_ATTR_UPNP_CREATECLASS_NAME_TEXT                                    "upnp:createClass@name"
#define UPNP_ATTR_UPNP_CREATECLASS_INCLUDEDERIVED_TEXT                          "upnp:createClass@includeDerived"
#define UPNP_ATTR_UPNP_WRITESTATUS_TEXT                                         "upnp:writeStatus"
#define UPNP_ATTR_RES_TEXT                                                      "res"
#define UPNP_ATTR_RES_PROTOCOLINFO_TEXT                                         "res@protocolInfo"
#define UPNP_ATTR_RES_IMPORTURI_TEXT                                            "res@importUri"
#define UPNP_ATTR_RES_SIZE_TEXT                                                 "res@size"
#define UPNP_ATTR_RES_DURATION_TEXT                                             "res@duration"
#define UPNP_ATTR_RES_PROTECTION_TEXT                                           "res@protection"
#define UPNP_ATTR_RES_BITRATE_TEXT                                              "res@bitrate"
#define UPNP_ATTR_RES_BITPERSAMPLE_TEXT                                         "res@bitsPerSample"
#define UPNP_ATTR_RES_SAMPLEFREQUENCY_TEXT                                      "res@sampleFrequency"
#define UPNP_ATTR_RES_NRAUDIOCHANNELS_TEXT                                      "res@nrAudioChannels"
#define UPNP_ATTR_RES_RESOLUTION_TEXT                                           "res@resolution"
#define UPNP_ATTR_RES_COLORDEPTH_TEXT                                           "res@colorDepth"
#define UPNP_ATTR_RES_TSPEC_TEXT                                                "res@tspec"
#define UPNP_ATTR_RES_ALLOWEDUSE_TEXT                                           "res@allowedUse"
#define UPNP_ATTR_RES_VALIDITYSTART_TEXT                                        "res@validityStart"
#define UPNP_ATTR_RES_VALIDITYEND_TEXT                                          "res@validityEnd"
#define UPNP_ATTR_RES_REMAININGTIME_TEXT                                        "res@remainingTime"
#define UPNP_ATTR_RES_USAGEINFO_TEXT                                            "res@usageInfo"
#define UPNP_ATTR_RES_RIGHTSIFOURI_TEXT                                         "res@rightsInfoURI"
#define UPNP_ATTR_RES_CONTENTIFOURI_TEXT                                        "res@contentInfoURI"
#define UPNP_ATTR_RES_RECORDQUALITY_TEXT                                        "res@recordQuality"
#define UPNP_ATTR_RES_DAYLIGHTSAVING_TEXT                                       "res@daylightSaving"
#define UPNP_ATTR_UPNP_ARTIST_TEXT                                              "upnp:artist"
#define UPNP_ATTR_UPNP_ARTIST_ROLE_TEXT                                         "upnp:artist@role"
#define UPNP_ATTR_UPNP_ACTOR_TEXT                                               "upnp:actor"
#define UPNP_ATTR_UPNP_ACTOR_ROLE_TEXT                                          "upnp:actor@role"
#define UPNP_ATTR_UPNP_AUTHOR_TEXT                                              "upnp:author"
#define UPNP_ATTR_UPNP_AUTHOR_ROLE_TEXT                                         "upnp:author@role"
#define UPNP_ATTR_UPNP_PRODUCER_TEXT                                            "upnp:producer"
#define UPNP_ATTR_UPNP_DIRECTOR_TEXT                                            "upnp:director"
#define UPNP_ATTR_DC_PUBLISHER_TEXT                                             "dc:publisher"
#define UPNP_ATTR_DC_CONTRIBUTOR_TEXT                                           "dc:contributor"
#define UPNP_ATTR_UPNP_GENRE_TEXT                                               "upnp:genre"
#define UPNP_ATTR_UPNP_GENRE_ID_TEXT                                            "upnp:genre@id"
#define UPNP_ATTR_UPNP_GENRE_EXTENDED_TEXT                                      "upnp:genre@extended"
#define UPNP_ATTR_UPNP_ALBUM_TEXT                                               "upnp:album"
#define UPNP_ATTR_UPNP_PLAYLIST_TEXT                                            "upnp:playlist"
#define UPNP_ATTR_UPNP_ALBUMARTURI_TEXT                                         "upnp:albumArtURI"
#define UPNP_ATTR_UPNP_ARTISTDISCOGRAPHYURI_TEXT                                "upnp:artistDiscographyURI"
#define UPNP_ATTR_UPNP_LYRICSURI_TEXT                                           "upnp:lyricsURI"
#define UPNP_ATTR_DC_RELATION_TEXT                                              "dc:relation"
#define UPNP_ATTR_UPNP_STORAGETOTAL_TEXT                                        "upnp:storageTotal"
#define UPNP_ATTR_UPNP_STORAGEUSED_TEXT                                         "upnp:storageUsed"
#define UPNP_ATTR_UPNP_STORAGEFREE_TEXT                                         "upnp:storageFree"
#define UPNP_ATTR_UPNP_STORAGEMAXPARTITION_TEXT                                 "upnp:storageMaxPartition"
#define UPNP_ATTR_UPNP_STORAGEMEDIUM_TEXT                                       "upnp:storageMedium"
#define UPNP_ATTR_DC_DESCRIPTION_TEXT                                           "dc:description"
#define UPNP_ATTR_DC_LONGDESCRIPTION_TEXT                                       "upnp:longDescription"
#define UPNP_ATTR_UPNP_ICON_TEXT                                                "upnp:icon"
#define UPNP_ATTR_UPNP_REGION_TEXT                                              "upnp:region"
#define UPNP_ATTR_DC_RIGHTS_TEXT                                                "dc:rights"
#define UPNP_ATTR_DC_DATE_TEXT                                                  "dc:date"
#define UPNP_ATTR_DC_DATE_UPNP_DAYLIGHTSAVING_TEXT                              "dc:date@upnp:daylightSaving"
#define UPNP_ATTR_DC_LANGUAGE_TEXT                                              "dc:language"
#define UPNP_ATTR_UPNP_PLAYBACKCOUNT_TEXT                                       "upnp:playbackCount"
#define UPNP_ATTR_UPNP_LASTPLAYBACKTIME_TEXT                                    "upnp:lastPlaybackTime"
#define UPNP_ATTR_UPNP_LASTPLAYBACKTIME_DAYLIGHTSAVING_TEXT                     "upnp:lastPlaybackTime@daylightSaving"
#define UPNP_ATTR_UPNP_LASTPLAYBACKPOSITION_TEXT                                "upnp:lastPlaybackPosition"
#define UPNP_ATTR_UPNP_RECORDEDSTARTDATETIME_TEXT                               "upnp:recordedStartDateTime"
#define UPNP_ATTR_UPNP_RECORDEDSTARTDATETIME_DAYLIGHTSAVING_TEXT                "upnp:recordedStartDateTime@daylightSaving"
#define UPNP_ATTR_UPNP_RECORDEDDURATION_TEXT                                    "upnp:recordedDuration"
#define UPNP_ATTR_UPNP_RECORDEDDAYOFWEEK_TEXT                                   "upnp:recordedDayOfWeek"
#define UPNP_ATTR_UPNP_SRSRECORDSCHEDULEID_TEXT                                 "upnp:srsRecordScheduleID"
#define UPNP_ATTR_UPNP_SRSRECORDTASKID_TEXT                                     "upnp:srsRecordTaskID"
#define UPNP_ATTR_UPNP_RECORDABLE_TEXT                                          "upnp:recordable"
#define UPNP_ATTR_UPNP_PROGRAMTITLE_TEXT                                        "upnp:programTitle"
#define UPNP_ATTR_UPNP_SERIESTITLE_TEXT                                         "upnp:seriesTitle"
#define UPNP_ATTR_UPNP_PROGRAMID_TEXT                                           "upnp:programID"
#define UPNP_ATTR_UPNP_PROGRAMID_TYPE_TEXT                                      "upnp:programID@type"
#define UPNP_ATTR_UPNP_SERIESID_TEXT                                            "upnp:seriesID"
#define UPNP_ATTR_UPNP_SERIESID_TYPE_TEXT                                       "upnp:seriesID@type"
#define UPNP_ATTR_UPNP_CHANNELID_TEXT                                           "upnp:channelID"
#define UPNP_ATTR_UPNP_CHANNELID_TYPE_TEXT                                      "upnp:channelID@type"
#define UPNP_ATTR_UPNP_CHANNELID_DISTRINETWORKNAME_TEXT                         "upnp:channelID@distriNetworkName"
#define UPNP_ATTR_UPNP_CHANNELID_DISTRINETWORKID_TEXT                           "upnp:channelID@distriNetworkID"
#define UPNP_ATTR_UPNP_EPISODECOUNT_TEXT                                        "upnp:episodeCount"
#define UPNP_ATTR_UPNP_EPISODENUMBER_TEXT                                       "upnp:episodeNumber"
#define UPNP_ATTR_UPNP_PROGRAMCODE_TEXT                                         "upnp:programCode"
#define UPNP_ATTR_UPNP_PROGRAMCODE_TYPE_TEXT                                    "upnp:programCode@type"
#define UPNP_ATTR_UPNP_RATING_TEXT                                              "upnp:rating"
#define UPNP_ATTR_UPNP_RATING_TYPE_TEXT                                         "upnp:rating@type"
#define UPNP_ATTR_UPNP_EPISODE_TYPE_TEXT                                        "upnp:episodeType"
#define UPNP_ATTR_UPNP_CHANNELGROUPNAME_TEXT                                    "upnp:channelGroupName"
#define UPNP_ATTR_UPNP_CHANNELGROUPNAME_ID_TEXT                                 "upnp:channelGroupName@id"
#define UPNP_ATTR_UPNP_CALLSIGN_TEXT                                            "upnp:callSign"
#define UPNP_ATTR_UPNP_NETWORKAFFILIATION_TEXT                                  "upnp:networkAffiliation"
#define UPNP_ATTR_UPNP_SERVICEPROVIDER_TEXT                                     "upnp:serviceProvider"
#define UPNP_ATTR_UPNP_PRICE_TEXT                                               "upnp:price"
#define UPNP_ATTR_UPNP_PRICE_CURRENCY_TEXT                                      "upnp:price@currency"
#define UPNP_ATTR_UPNP_PAYPERVIEW_TEXT                                          "upnp:payPerView"
#define UPNP_ATTR_UPNP_EPGPROVIDERNAME_TEXT                                     "upnp:epgProviderName"
#define UPNP_ATTR_UPNP_DATETIMERANGE_TEXT                                       "upnp:dateTimeRange"
#define UPNP_ATTR_UPNP_DATETIMERANGE_DAYLIGHTSAVING_TEXT                        "upnp:dateTimeRange@daylightSaving"
#define UPNP_ATTR_UPNP_RADIOCALLSIGN_TEXT                                       "upnp:radioCallSign"
#define UPNP_ATTR_UPNP_RADIOSTATIONID_TEXT                                      "upnp:radioStationID"
#define UPNP_ATTR_UPNP_RADIOBAND_TEXT                                           "upnp:radioBand"
#define UPNP_ATTR_UPNP_CHANNELNR_TEXT                                           "upnp:channelNr"
#define UPNP_ATTR_UPNP_CHANNELNAME_TEXT                                         "upnp:channelName"
#define UPNP_ATTR_UPNP_SCHEDULEDSTARTTIME_TEXT                                  "upnp:scheduledStartTime"
#define UPNP_ATTR_UPNP_SCHEDULEDSTARTTIME_USAGE_TEXT                            "upnp:scheduledStartTime@usage"
#define UPNP_ATTR_UPNP_SCHEDULEDSTARTTIME_DAYLIGHTSAVING_TEXT                   "upnp:scheduledStartTime@daylightSaving"
#define UPNP_ATTR_UPNP_SCHEDULEDENDTIME_TEXT                                    "upnp:scheduledEndTime"
#define UPNP_ATTR_UPNP_SCHEDULEDENDTIME_DAYLIGHTSAVING_TEXT                     "upnp:scheduledEndTime@daylightSaving"
#define UPNP_ATTR_UPNP_SCHEDULEDDURATION_TEXT                                   "upnp:scheduledDuration"
#define UPNP_ATTR_UPNP_SIGNALSTRENGTH_TEXT                                      "upnp:signalStrength"
#define UPNP_ATTR_UPNP_SIGNALLOCKED_TEXT                                        "upnp:signalLocked"
#define UPNP_ATTR_UPNP_TUNED_TEXT                                               "upnp:tuned"
#define UPNP_ATTR_UPNP_NEVERPLAYABLE_TEXT                                       "upnp:neverPlayable"
#define UPNP_ATTR_UPNP_BOOKMARKID_TEXT                                          "upnp:bookmarkID"
#define UPNP_ATTR_UPNP_BOOKMARKEDOBJECTID_TEXT                                  "upnp:bookmarkedObjectID"
#define UPNP_ATTR_UPNP_DEVICEUDN_TEXT                                           "upnp:deviceUDN"
#define UPNP_ATTR_UPNP_DEVICEUDN_SERVICETYPE_TEXT                               "upnp:deviceUDN@serviceType"
#define UPNP_ATTR_UPNP_DEVICEUDN_SERVICEID_TEXT                                 "upnp:deviceUDN@serviceID"
#define UPNP_ATTR_UPNP_STATEVARIABLECOLLECTION_TEXT                             "upnp:stateVariableCollection"
#define UPNP_ATTR_UPNP_STATEVARIABLECOLLECTION_SERVICENAME_TEXT                 "upnp:stateVariableCollection@serviceName"
#define UPNP_ATTR_UPNP_STATEVARIABLECOLLECTION_RCSINSTANCETYPE_TEXT             "upnp:stateVariableCollection@rcsInstanceType"
#define UPNP_ATTR_UPNP_STATEVARIABLECOLLECTION_STATEVARIABLE_TEXT               "upnp:stateVariableCollection::stateVariable"
#define UPNP_ATTR_UPNP_STATEVARIABLECOLLECTION_STATEVARIABLE_VARIABLENAME_TEXT  "upnp:stateVariableCollection::stateVariable@variableName"
#define UPNP_ATTR_UPNP_DVDREGIONCODE_TEXT                                       "upnp:DVDRegionCode"
#define UPNP_ATTR_UPNP_ORIGINALTRACKNUMBER_TEXT                                 "upnp:originalTrackNumber"
#define UPNP_ATTR_UPNP_TOC_TEXT                                                 "upnp:toc"
#define UPNP_ATTR_UPNP_USERANNOTATION_TEXT                                      "upnp:userAnnotation"
#define UPNP_ATTR_DESC_TEXT                                                     "desc"
#define UPNP_ATTR_DESC_NAMESPACE_TEXT                                           "desc@nameSpace" 
#define UPNP_ATTR_UPNP_CONTAINERUPDATEID_TEXT                                   "upnp:containerUpdateID"
#define UPNP_ATTR_UPNP_OBJECTUPDATEID_TEXT                                      "upnp:objectUpdateID"
#define UPNP_ATTR_UPNP_TOTALDELETEDCHILDCOUNT_TEXT                              "upnp:totalDeletedChildCount"
#define UPNP_ATTR_RES_UPDATECOUNT_TEXT                                          "res@updateCount"
#define UPNP_ATTR_UPNP_FOREIGNMETADATA_TEXT                                     "upnp:foreignMetadata"
#define UPNP_ATTR_UPNP_FOREIGNMETADATA_TYPE_TEXT                                "upnp:foreignMetadata@type"
#define UPNP_ATTR_UPNP_FOREIGNMETADATA_FMID_TEXT                                "upnp:foreignMetadata::fmId"
#define UPNP_ATTR_UPNP_FOREIGNMETADATA_FMCLASS_TEXT                             "upnp:foreignMetadata::fmClass"
#define UPNP_ATTR_UPNP_FOREIGNMETADATA_FMPROVIDER_TEXT                          "upnp:foreignMetadata::fmProvider"
#define UPNP_ATTR_UPNP_FOREIGNMETADATA_FMBODY_TEXT                              "upnp:foreignMetadata::fmBody"
#define UPNP_ATTR_UPNP_FOREIGNMETADATA_FMBODY_XMLFLAG_TEXT                      "upnp:foreignMetadata::fmBody@xmlFlag"
#define UPNP_ATTR_UPNP_FOREIGNMETADATA_FMBODY_MIMETYPE_TEXT                     "upnp:foreignMetadata::fmBody@mimeType"
#define UPNP_ATTR_UPNP_FOREIGNMETADATA_FMBODY_FMEMBEDDEDSTRING_TEXT             "upnp:foreignMetadata::fmBody::fmEmbeddedString"
#define UPNP_ATTR_UPNP_FOREIGNMETADATA_FMBODY_FMEMBEDDEDXML_TEXT                "upnp:foreignMetadata::fmBody::fmEmbeddedXML"
#define UPNP_ATTR_UPNP_FOREIGNMETADATA_FMBODY_FMURI_TEXT                        "upnp:foreignMetadata::fmBody::fmURI"

#define UPNP_CLASS_OBJECT                                          "object" 
#define UPNP_CLASS_OBJECT_ITEM                                     "object.item"                                    
#define UPNP_CLASS_OBJECT_ITEM_IMAGEITEM                           "object.item.imageItem"                          
#define UPNP_CLASS_OBJECT_ITEM_IMAGEITEM_PHOTO                     "object.item.imageItem.photo"                    
#define UPNP_CLASS_OBJECT_ITEM_AUDIOITEM                           "object.item.audioItem"                          
#define UPNP_CLASS_OBJECT_ITEM_AUDIOITEM_MUSICTRACK                "object.item.audioItem.musicTrack"               
#define UPNP_CLASS_OBJECT_ITEM_AUDIOITEM_AUDIOBROADCAST            "object.item.audioItem.audioBroadcast"           
#define UPNP_CLASS_OBJECT_ITEM_AUDIOITEM_AUDIOBOOK                 "object.item.audioItem.audioBook"                
#define UPNP_CLASS_OBJECT_ITEM_VIDEOITEM                           "object.item.videoItem"                          
#define UPNP_CLASS_OBJECT_ITEM_VIDEOITEM_MOVIE                     "object.item.videoItem.movie"                    
#define UPNP_CLASS_OBJECT_ITEM_VIDEOITEM_VIDEOBROADCAST            "object.item.videoItem.videoBroadcast"           
#define UPNP_CLASS_OBJECT_ITEM_VIDEOITEM_MUSICVIDEOCLIP            "object.item.videoItem.musicVideoClip"           
#define UPNP_CLASS_OBJECT_ITEM_PLAYLISTITEM                        "object.item.playlistItem"                       
#define UPNP_CLASS_OBJECT_ITEM_TEXTITEM                            "object.item.textItem"                           
#define UPNP_CLASS_OBJECT_ITEM_BOOKMARKITEM                        "object.item.bookmarkItem"                       
#define UPNP_CLASS_OBJECT_ITEM_EPGITEM                             "object.item.epgItem"                            
#define UPNP_CLASS_OBJECT_ITEM_EPGITEM_AUDIOPROGRAM                "object.item.epgItem.audioProgram"               
#define UPNP_CLASS_OBJECT_ITEM_EPGITEM_VIDEOPROGRAM                "object.item.epgItem.videoProgram"                       
#define UPNP_CLASS_OBJECT_CONTAINER                                "object.container"     
#define UPNP_CLASS_OBJECT_CONTAINER_PERSON                         "object.container.person"                        
#define UPNP_CLASS_OBJECT_CONTAINER_PERSON_MUSICARTIST             "object.container.person.musicArtist"            
#define UPNP_CLASS_OBJECT_CONTAINER_PLAYLISTCONTAINER              "object.container.playlistContainer"             
#define UPNP_CLASS_OBJECT_CONTAINER_ALBUM                          "object.container.album"                         
#define UPNP_CLASS_OBJECT_CONTAINER_ALBUM_MUSICALBUM               "object.container.album.musicAlbum"              
#define UPNP_CLASS_OBJECT_CONTAINER_ALBUM_PHOTOALBUM               "object.container.album.photoAlbum"              
#define UPNP_CLASS_OBJECT_CONTAINER_GENRE                          "object.container.genre"                         
#define UPNP_CLASS_OBJECT_CONTAINER_GENRE_MUSICGENRE               "object.container.genre.musicGenre"              
#define UPNP_CLASS_OBJECT_CONTAINER_GENRE_MOVIEGENRE               "object.container.genre.movieGenre"              
#define UPNP_CLASS_OBJECT_CONTAINER_CHANNELGROUP                   "object.container.channelGroup"                  
#define UPNP_CLASS_OBJECT_CONTAINER_CHANNELGROUP_AUDIOCHANNELGROUP "object.container.channelGroup.audioChannelGroup"
#define UPNP_CLASS_OBJECT_CONTAINER_CHANNELGROUP_VIDEOCHANNELGROUP "object.container.channelGroup.videoChannelGroup"
#define UPNP_CLASS_OBJECT_CONTAINER_EPGCONTAINER                   "object.container.epgContainer"                  
#define UPNP_CLASS_OBJECT_CONTAINER_STORAGESYSTEM                  "object.container.storageSystem"                 
#define UPNP_CLASS_OBJECT_CONTAINER_STORAGEVOLUME                  "object.container.storageVolume"                 
#define UPNP_CLASS_OBJECT_CONTAINER_STORAGEFOLDER                  "object.container.storageFolder"                 
#define UPNP_CLASS_OBJECT_CONTAINER_BOOKMARKFOLDER                 "object.container.bookmarkFolder"      

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
            * @brief Describes pair name-value                       
            **/                                                      
            typedef struct _tagUpnpValuePair{                        
                                                                     
                char* pName;                                      /**< name */
                char* pValue;                                     /**< value */
            } UpnpValuePair;                                         
                                                                     
            /**                                                      
            * @brief Describes single property                       
            **/                                                      
            typedef struct _tagUpnpProperty {                        
                                                                     
                UpnpValuePair  Property;                            /**< property */
                UpnpValuePair* pAttributes;                         /**< list of extended attributes */
                int32_t        iAttributeCount;                     /**< count of attributes */
            } UpnpProperty;

            /**
            * @brief UPnP Property Manager
            **/
            class IUpnpPropertyManager : public INetRefCounted
            {
            public:
                virtual ~IUpnpPropertyManager() {};

                /**
                 * @todo: add documentation here (will be modified after merging with PropertyManager from tests)
                 **/
                virtual bool AddAttribute( const UpnpValuePair aAttribute, bool bReplaceExisting = true ) = 0;
                virtual void AddProperty( const UpnpProperty aProperty ) = 0;
                virtual const UpnpValuePair* EnumAttributes( uint32_t i ) const = 0;
                virtual const UpnpStack::UpnpProperty* EnumProperties( uint32_t i ) const = 0;
                virtual const UpnpStack::UpnpProperty* FindProperty(const char* pPropName) const = 0;
            };

#if defined (__cplusplus)
            extern "C" {
#endif

                /**
                * @brief Creates instance of new UPnP Property Manager
                * 
                * @param[in] get_rc      Pointer to get_rc memory manager implementation or NULL to use standard allocators
                * @return                valid pointer to UPnP Property Manager or NULL
                **/
                IUpnpPropertyManager* MC_UPNP_API GetUpnpPropertyManager( void *(MC_EXPORT_API *get_rc)(const char*) );

                /**
                * @brief Serializes specified property to C string
                * 
                * @param[in] pProeprty     Property to be serialized
                * @param[in] pBuffer       Allocated buffer for result string
                * @param[in] uiBufferSize  Size of pBuffer
                * @return                  none
                **/
                void MC_UPNP_API SerializeUpnpProperty( const UpnpProperty* pProperty, uint8_t *pBuffer, const uint32_t uiBufferSize );

#if defined (__cplusplus)
            }
#endif

        };
    };
};

#endif
