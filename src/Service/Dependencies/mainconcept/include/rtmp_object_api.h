/**
@file  rtmp_object_api.h
@brief RTMP Object API

@verbatim
File: rtmp_object_api.h
Desc: RTMP Object API

Copyright (c) 2015 MainConcept GmbH or its affiliates.  All rights reserved.

MainConcept and its logos are registered trademarks of MainConcept GmbH or its affiliates.  
This software is protected by copyright law and international treaties.  Unauthorized 
reproduction or distribution of any portion is prohibited by law.
@endverbatim
**/

#if !defined (__MC_RTMP_OBJECT_API_H__)
#define __MC_RTMP_OBJECT_API_H__

#include "mctypes.h"
#include "parser_sdp.h"

/**
* @brief Maximum length of handshake validation key
* @hideinitializer
**/
#define MAX_RTMP_KEY_LEN 128

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
        * @brief Stores handshake validation keys
        **/
        typedef struct _tagRtmpHandshakeKeyStorage {

            uint8_t pServerKey[MAX_RTMP_KEY_LEN];                   /**< server-side key*/
            uint8_t pClientKey[MAX_RTMP_KEY_LEN];                   /**< client-side key*/
            bool    bRequiredValidation;                            /**< enables\\disabled mandatory validation*/
        } RtmpHandshakeKeyStorage;

        /**
        * Describes internal type of IRtmpObject
        **/
        typedef enum _tagRtmpObjectType {

            RtmpObjectTypeUndefined = 0x00,                         /**< Undefined */
            RtmpObjectTypeNull,                                     /**< Object is NULL */
            RtmpObjectTypeBoolean,                                  /**< Object contains boolean value */
            RtmpObjectTypeInteger,                                  /**< Object contains integer(up to 32 bits size) value */
            RtmpObjectTypeDouble,                                   /**< Object contains floating point value */
            RtmpObjectTypeString,                                   /**< Object contains utf8 string */
            RtmpObjectTypeObject                                    /**< Object contains IRtmpObject* value*/
        } RtmpObjectType;

        /**
        * @brief Describes decoder config
        **/
        typedef struct _tagRtmpDecoderConfig {

            uint8_t* pConfig;                                       /**< points to decoder config data */
            uint32_t uiConfigLen;                                   /**< size of decoder config */
        } RtmpDecoderConfig;

        /**
        * @brief Describes video stream data
        **/
        typedef struct _tagRtmpVideoConfig {

            STREAMTYPE codec;                                       /**< type of elementary stream */
            int64_t    time_per_frame;                              /**< nanosecond per frame */
            uint32_t   width;                                       /**< width in pixels */
            uint32_t   height;                                      /**< height in pixels */
            uint8_t    avcPrefixLen;                                /**< size of AVC NALU header */
        } RtmpVideoConfig;

        /**
        * @brief Describes audio stream data
        **/
        typedef struct _tagRtmpAudioConfig {

            STREAMTYPE codec;                                       /**< type of elementary stream */
            uint32_t   sample_rate;                                 /**< audio sample rate in Hz */
            uint32_t   bit_per_sample;                              /**< bits per sample */
            uint32_t   bit_rate;                                    /**< bits per seconds */
            uint8_t    channels_count;                              /**< audio channels count */
        } RtmpAudioConfig;

        /**
        * @brief Contains media stream description
        **/
        typedef struct _tagRtmpMetadata {

            MEDIATYPE         _mediaType;                           /**< media type*/
            RtmpDecoderConfig _config;                              /**< specific decoder config*/
            void*             _pData;                               /**< pointer to elementary stream descriptor @see RtmpVideoConfig @see RtmpAudioConfig */
        } RtmpMetadata;

        /**
        * @brief Declares main RTMP data type
        **/
        class IRtmpObject
        {
        public:
            virtual ~IRtmpObject() {}

            /**
            * @brief Retrieves count of internal attributes if object has RtmpObjectTypeObject type
            * 
            * @return count of attributes 
            **/
            virtual uint32_t GetAttributeCount() const = 0;

            /**
            * @brief Enumerates internal attributes by index
            * 
            * @param[in]  uiIndex index number of attribute
            * @param[out] type    type of extracting attribute
            * @param[out] name    name of extracting attribute
            * @return             pointer to value of attribute (may be NULL)
            **/
            virtual const void* EnumAttributes( uint32_t uiIndex, RtmpObjectType* type, const char** name = NULL ) const = 0;        

            /**
            * @brief Adds attribute to internal structure object
            * 
            * @param[in] pValue       pointer to value of attribute
            * @param[in] type         type of attribute
            * @param[in] pName        name of attribute(if exists)
            * @param[in] iValueLen    size of value if it isn't elementary data
            * @return                 None
            **/
            virtual void AddAttribute( const void* pValue, RtmpObjectType type, const char* pName = NULL, int32_t iValueLen = -1 ) = 0;

            /**
            * @brief Retrieves name of current object
            * 
            * @return name of object or NULL if anonymous object
            **/
            virtual const char* GetName() const = 0;

            /**
            * @brief Retrieves stored value
            * 
            * @return pointer to stored value 
            **/
            virtual const void* GetValue() const = 0;

            /**
            * @brief Retrieves type of stored value
            * 
            * @return Return @ref RtmpObjectType
            **/
            virtual RtmpObjectType GetType() const = 0;
        };
    };
};

#endif //__MC_RTMP_OBJECT_API_H__
