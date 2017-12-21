/**
@file   metadata_extractor_api.h
@brief  API of Metadata extractor

@verbatim
Name: metadata_extractor_api.h
Desc: API of Metadata extractor

Copyright (c) 2015 MainConcept GmbH or its affiliates.  All rights reserved.

MainConcept and its logos are registered trademarks of MainConcept GmbH or its affiliates.  
This software is protected by copyright law and international treaties.  Unauthorized 
reproduction or distribution of any portion is prohibited by law.
@endverbatim
**/

# if !defined (__MC_META_DATA_EXTRACTOR_API_H__)
#define __MC_META_DATA_EXTRACTOR_API_H__

#include "net_common.h"
#include "upnp_common.h"

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

            class IUpnpContentDirectoryItem;

			/**
			* @brief Retrieve any metadata from media file
			**/
			class IMetaDataExtractor : public INetRefCounted
			{
			public:
				virtual ~IMetaDataExtractor() {}

				/**
				* @brief Reads file, gets metadata from it
				* 
				* @param[in] pDataSource data source valid object
				* @return    true on success
				**/
				virtual bool Extract( IDataSource *pDataSource ) = 0;

				/**
				* @brief Retrieves MIME type string of file
				* 
				* @return MIME type string or NULL if not available
				**/
                virtual const char * GetMimeType() const = 0;

				/**
				* @brief Retrieves metadata property value by name
				* 
				* @param[in] pPropertyName property name
				* @return                  property value or NULL if not found
				**/
                virtual const char * GetPropertyValue(const char *pPropertyName) const = 0;

				/**
				* @brief Enumerates all Metadata fields from file
				* 
				* @param[in] uiIndex index number of field
				* @return            pointer to metadata field or NULL if index is out of range
				**/
				virtual const UpnpValuePair * EnumMetaDataEntries( uint32_t uiIndex ) const = 0;

				/**
				* @brief Returns number of all Metadata fields generated from file
				* 
				* @return            number of metadta fields
				*/
				virtual int32_t MetadataEntryCount( ) const = 0;
			};

			/**
			* @brief Produces and saves thumbnail from media file
			**/
			class IThumbnailProducer : public INetRefCounted
			{
			public:
				virtual ~IThumbnailProducer() {}

				/**
				* @brief Generates thumbnails for media files
				* 
				* @param[in] pItem     requested item
				* @return              IDataSource reader for thumbnail
				**/
				virtual IDataSource *Extract( const IUpnpContentDirectoryItem *pItem ) = 0;

				/**
				* @brief Retrieves MIME type of generated thumbnails
				* 
				* @return MIME-type string 
				**/
                virtual const char *GetMimeType() = 0;

				/**
				* @brief Retrieves DLNA profile info
				* 
				* @return Profile string 
				**/
                virtual const char *GetProfileInfo() = 0;
			};
		};
	};
};

#endif //__MC_META_DATA_EXTRACTOR_API_H__
