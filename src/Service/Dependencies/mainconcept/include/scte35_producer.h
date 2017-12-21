/**
@file: scte35_producer.h
@brief SCTE-35 Producer API

@verbatim
File: scte35_producer.h.h
Desc: SCTE-35 Producer API

Copyright (c) 2016 MainConcept GmbH or its affiliates.  All rights reserved.

MainConcept and its logos are registered trademarks of MainConcept GmbH or its affiliates.
This software is protected by copyright law and international treaties.  Unauthorized
reproduction or distribution of any portion is prohibited by law.
@endverbatim
 **/

#pragma once
#ifndef __SCTE35_H__
#define __SCTE35_H__

#include "mctypes.h"
#include "mcmediatypes.h"

#ifdef __GNUC__
#pragma pack(push, 1)
#else
#pragma pack(push)
#pragma pack(1)
#endif

/**
 * @brief opaque encryption applier instance pointer
 */
typedef void * encryption_applier_t;

/**
 * @brief encryption applier callback, either scte35EncryptionApplierApply, or user-supplied
 
 * @param app opaque pointer to the encryption applier object
 * @param data pointer to the actual data to be encrypted (encryption is applied in-place to the same memory)
 * @param length length of data block to be encrypted, must be padded according to the encryption algorithm (8 bytes for DES)

 * @return 0 if successful, non-zero otherwise
 */
typedef int32_t (MC_EXPORT_API *encryption_applier_callback_t)(void * app, uint8_t * data, uint32_t length);

/**
 * @brief get resource function

 * @param get_rc pointer to the resource function
 * @param name resource name

 * @return pointer to the resource if successful, NULL otherwise
 */
typedef void *(MC_EXPORT_API *get_rc_t)(const char* name);

#pragma pack(pop)

#ifdef __cplusplus
extern "C" {
#endif

/**
 * @brief allocates SCTE-35 encryption applier instance

* @param get_rc pointer to the resource function
 * @param buffer NULL-terminated Unicode (UTF-8 encoded) string containing XML representation of SCTE-35 splice info

 * @param algorithm encryption algorithm according to the SCTE-35 specification (1 - DES ECB, 2 - DES CBC, 3 - DES EDE3 ECB)
 * @param keys group of keys to be used for encryption

 * @return non-NULL pointer to encryption applier instance on success, or NULL pointer on failure
 */
encryption_applier_t MC_EXPORT_API scte35EncryptionApplierNew(get_rc_t get_rc, uint8_t algorithm, mc_scte35_key_group_t * keys);

/**
 * @brief cleanup encryption applier instance allocated via scte35EncryptionApplierNew API

 * @param instance pointer to encryption applier nstance allocated via scte35EncryptionApplierNew API

 * @return none
 */
void MC_EXPORT_API scte35EncryptionApplierFree(encryption_applier_t instance);

/**
 * @brief performs actual encryption on data block (such as SCTE-35 splice info section part)
 
 * @param instance pointer to encryption applier instance allocated via scte35EncryptionApplierNew API
 * @param data pointer to the actual data to be encrypted (encryption is applied in-place to the same memory)
 * @param length length of data block to be encrypted, must be padded according to the encryption algorithm (8 bytes for DES)
 
 * @return 0 if successful, non-zero otherwise
 */
int32_t MC_EXPORT_API scte35EncryptionApplierApply(encryption_applier_t instance, uint8_t * data, uint32_t length);

/**
 * @brief convert XML representation of SCTE-35 splice info into the mc_scte35_splice_info_t structure
 
 * @param get_rc pointer to the resource function
 
 * @param buffer NULL-terminated Unicode (UTF-8 encoded) string containing XML representation of SCTE-35 splice info
 
 * @param info output SCTE-35 values parsed from XML, valid only if function returns 0, in that case must be free by calling scte35FreeSpliceInfo
 
 * @return 0 if successful, non-zero otherwise
 */
int32_t MC_EXPORT_API scte35ConvertXMLtoSpliceInfo(get_rc_t get_rc, const char * buffer, mc_scte35_splice_info_t * info);

/**
 * @brief cleanup mc_scte35_splice_info_t structure data allocated by @ref scte35ConvertXMLtoSpliceInfo
 
 * @param info SCTE-35 structure allocated by scte35ConvertXMLtoSpliceInfo, all fields are no longer valid after this call
 
 * @return none
 */
void MC_EXPORT_API scte35FreeSpliceInfo(mc_scte35_splice_info_t * info);

/**
 * @brief converts SCTE-35 structure allocated by @ref scte35ConvertXMLtoSpliceInfo into binary represenation (MPEG-2 TS packet)
 
 * @param info SCTE-35 structure allocated by scte35ConvertXMLtoSpliceInfo
 * @param get_rc pointer to the resource function
 * @param packet output binary representation of SCTE-35 splice info, can be written into the MPEG-2 TS file
 * @param enc_applier user-defined encryption applier object instance
 * @param enc_callback user-defined encryption applier method
 * @param enc_padding number of padding bytes required for encryption algorithm (alignment stuffing)
 
 * @return 0 if successful, non-zero otherwise
 */
int32_t MC_EXPORT_API scte35SerializeSpliceInfo(get_rc_t get_rc, mc_scte35_splice_info_t * info, mc_scte35_packet_t * packet, encryption_applier_t enc_applier, encryption_applier_callback_t enc_callback, uint16_t enc_padding);

typedef void * scte35_producer_t;
typedef struct MP2Muxer mp2muxer_tt;

/**
 * @brief allocates new user-friendly SCTE-35 producer instance
 
 * @param get_rc pointer to the resource function
 * @param muxer MPEG-2 muxer instance, created via mpegOutMP2MuxNew API
 
 * @return user-friendly SCTE-35 producer instance on success, or NULL pointer on failure
 */
scte35_producer_t MC_EXPORT_API scte35ProducerNew(get_rc_t get_rc, mp2muxer_tt * muxer);

/**
 * @brief cleanup user-friendly SCTE-35 producer instance allocated via scte35ProducerNew API
 
 * @param instance pointer to user-friendly SCTE-35 producer instance allocated via scte35ProducerNew API
 
 * @return none
 */
void MC_EXPORT_API scte35ProducerFree(scte35_producer_t instance);

/**
 * @brief registers SCTE-35 stream in program, this effectively adds new PMT entry as well as required descriptors
 
 * @param instance pointer to user-friendly SCTE-35 producer instance allocated via scte35ProducerNew API
 * @param PID new PID to be used for SCTE-35 data
 * @param program_number program SCTE-35 to be added to
 * @param repetition_rate repetition rate in milliseconds
 
 * @return 0 if successful, non-zero otherwise
 */
int32_t MC_EXPORT_API scte35ProducerRegister(scte35_producer_t instance, uint16_t PID, int32_t program_number, uint32_t repetition_rate);

/**
 * @brief adds splice information specified by SCTE-35 packet

 * @param instance pointer to user-friendly SCTE-35 producer instance allocated via scte35ProducerNew API
 * @param packet SCTE-35 packet - binary splice info section structure
 * @param target_time_PCR - target time to apply splice information (zero to apply immediately)

 * @return 0 if successful, non-zero otherwise
 */
int32_t MC_EXPORT_API scte35ProducerAddSpliceInfo(scte35_producer_t instance, mc_scte35_packet * packet, int64_t target_time_PCR);

#ifdef __cplusplus
}
#endif

#endif /* __SCTE35_H__ */
