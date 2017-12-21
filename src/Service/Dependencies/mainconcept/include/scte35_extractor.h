/**
 @file: scte35_extractor.h
 @brief SCTE-35 Extractor API

 @verbatim
 File: scte35_extractor.h.h
 Desc: SCTE-35 Extractor API

 Copyright (c) 2016 MainConcept GmbH or its affiliates.  All rights reserved.

 MainConcept and its logos are registered trademarks of MainConcept GmbH or its affiliates.
 This software is protected by copyright law and international treaties.  Unauthorized
 reproduction or distribution of any portion is prohibited by law.
 @endverbatim
 **/

#ifndef __SCTE35_EXTRACTOR_H__
#define __SCTE35_EXTRACTOR_H__

#include "demux_mp2.h"


//! \file scte35_extractor.h
//! SCTE-35 Extractor interfaces

//! extractor instance
typedef void * scte35_extractor_t;

/*!
@brief Callback definition

@param app_ptr      the app_ptr field in the scte35ext_settings_t structure is passed back here
@param pSection     a pointer to an mc_scte35_splice_info_t structure defined in mcmediatypes.h
@return             0 = continue extracting, non-zero = abort extracting
*/
typedef int32_t (*pfn_scte35_extractor_callback)(void *app_ptr, mc_scte35_splice_info_t *pSection);

/**
 * @brief opaque decryption applier instance pointer
 */
typedef void * decryption_applier_t;

/**
 * @brief decryption applier callback, either scte35DecryptionApplierApply, or user-supplied

 * @param app opaque pointer to the decryption applier object
 * @param data pointer to the actual data to be decrypted (decryption is applied in-place to the same memory)
 * @param length length of data block to be decrypted, must be padded according to the encryption algorithm (8 bytes for DES)

 * @return 0 if successful, non-zero otherwise
 */
typedef int32_t (MC_EXPORT_API *decryption_applier_callback_t)(void * app, uint8_t * data, uint32_t length);

#ifdef __GNUC__
#pragma pack(push,1)
#else
#pragma pack(push)
#pragma pack(1)
#endif

/*!
@brief This structure is used install an SCTE-35 callback for a specified PID.
*/
typedef struct scte35ext_callback_settings_s
{
    uint16_t PID;                       ///< PID for the callback
    int32_t parser_num;                 ///< demuxer parser number to use for the callback
    void *app_ptr;                      ///< user defined pointer passed back to the callback function
    pfn_scte35_extractor_callback pCallback;    ///< pointer to a pfn_scte35_extractor_callback style function
    void *decryptor_ptr;                ///< optional, user defined pointer passed back to the decryption callback function
    decryption_applier_callback_t pDecryptionCallback; ///< optional, pointer to a decryption_applier_callback_t style function
}
scte35ext_callback_settings_t;

#pragma pack(pop)

/**
 * @brief get resource function (extended version)

 * @param get_rc pointer to the resource function
 * @param rc_app_ptr application-specific opaque instance
 * @param name resource name

 * @return pointer to the resource if successful, NULL otherwise
 */
typedef void *(MC_EXPORT_API *get_rc_ex_t)(void * rc_app_ptr, const char * name);

#ifdef __cplusplus
extern "C" {
#endif


//! @name general functions
//!@{

/**
 * @brief allocates SCTE-35 encryption applier instance

 * @param get_rc pointer to the resource function
 * @param buffer NULL-terminated Unicode (UTF-8 encoded) string containing XML representation of SCTE-35 splice info

 * @param algorithm encryption algorithm according to the SCTE-35 specification (1 - DES ECB, 2 - DES CBC, 3 - DES EDE3 ECB)
 * @param keys group of keys to be used for encryption

 * @return non-NULL pointer to encryption applier instance on success, or NULL pointer on failure
 */
decryption_applier_t MC_EXPORT_API scte35DecryptionApplierNew(get_rc_ex_t get_rc_ex, void * rc_app_ptr, uint8_t algorithm, mc_scte35_key_group_t * keys);

/**
 * @brief cleanup decryption applier instance allocated via scte35DecryptionApplierNew API

 * @param instance pointer to decryption applier nstance allocated via scte35DecryptionApplierNew API

 * @return none
 */
void MC_EXPORT_API scte35DecryptionApplierFree(decryption_applier_t instance);

/**
 * @brief performs actual decryption on data block (such as SCTE-35 splice info section part)

 * @param instance pointer to decryption applier instance allocated via scte35DecryptionApplierNew API
 * @param data pointer to the actual data to be decrypted (decryption is applied in-place to the same memory)
 * @param length length of data block to be decrypted, must be padded according to the encryption algorithm (8 bytes for DES)

 * @return 0 if successful, non-zero otherwise
 */
int32_t MC_EXPORT_API scte35DecryptionApplierApply(decryption_applier_t instance, uint8_t * data, uint32_t length);

/*!
@brief Call to create and initialize an extractor instance. This function will install a callback in
the demuxer instance passed in the scte35ext_settings_t structure.

@param [in] get_rc_ex     a pointer to a get_rc_ex resource function, can be NULL
@param [in] rc_app_ptr    an application supplied pointer that will be passed back with any get_rc_ex calls
@param [in] demuxer       a pointer to a MPEG-2 demultiplexer instance

@return                   a pointer to an scte35ext_tt instance if successful, NULL if unsuccessful
*/
scte35_extractor_t MC_EXPORT_API scte35ExtractorNew(get_rc_ex_t get_rc_ex, void * rc_app_ptr, mp2dmux_tt * demuxer);


/*!
@brief Call to free an extractor instance. Should be called before the demuxer instance pass to 
scte35ExtractorNew is freed, if not set bNoDeinstall parameter to 1.

@param [in] extractor     a pointer to an scte35ext_tt object created with an scte35ExtractorNew call
@return                   none
*/
void MC_EXPORT_API scte35ExtractorFree(scte35_extractor_t extractor);


/*!
@brief Call to add a callback for a specfied PID.

@param [in] extractor     a pointer to an scte35ext_tt object created with an scte35ExtractorNew call
@param [in] set           a pointer to a filled in scte35ext_callback_settings_t structure

@return                   0 if successful, else non-zero
*/
int32_t MC_EXPORT_API scte35ExtractorAddCallback(scte35_extractor_t, scte35ext_callback_settings_t *set);


/*!
@brief Call to convert an mc_scte35_splice_info_t structure to an XML representation

@param [in] splice_info   a pointer to an initialized mc_scte35_splice_info_t structure
@param [in] bs            a pointer to a bufstream object to receive the XML data

@return                   0 if successful, else non-zero
*/
int32_t MC_EXPORT_API scte35ConvertSpliceInfoToXML(mc_scte35_splice_info_t *splice_info, bufstream_tt *bs);


#ifdef __cplusplus
}
#endif

#endif // __SCTE35_EXTRACTOR_H__
