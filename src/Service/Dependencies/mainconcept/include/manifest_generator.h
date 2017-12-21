/** 
 @file  manifest_generator.h
 @brief Manifest Generator API
 
 @verbatim
 File: manifest_generator.h
 Desc: Manifest Generator API
 
 Copyright (c) 2015 MainConcept GmbH or its affiliates.  All rights reserved.

 MainConcept and its logos are registered trademarks of MainConcept GmbH or its affiliates.  
 This software is protected by copyright law and international treaties.  Unauthorized 
 reproduction or distribution of any portion is prohibited by law.
 @endverbatim
 **/
 
#if !defined (__MANIFEST_GENERATOR_API_INCLUDED__)
#define __MANIFEST_GENERATOR_API_INCLUDED__

#include "mctypes.h"

///  manifest generator instance type
typedef struct manifest_generator  manifest_generator_tt;

/// These parameters are used to configure the generator.
typedef struct manifest_api_settings_s
{
	char *out_filename;			///< Name of output files.

	int32_t	max_quality_levels;		///< Maximum number of quality levels.
    int32_t file_access_mode;
	int32_t reserved[19];
} manifest_api_settings_t;

#ifdef __cplusplus
extern "C" {
#endif

/**
 * @brief Initializes manifest generator library.
 * Initializes manifest generator library. 
 * It should be called one time before the Manifest Generator usage.
 *
 */
void MC_EXPORT_API ManifestGeneratorLibraryInit();

/**
 * @brief Creates a new manifest generator instance.
 *
 * Creates a new manifest generator instance.
 * @param[in] set pointer to settings to adjust
 * @return pointer to a @ref manifest_generator_tt object if succesful
 * @return NULL if unsuccesful
 */
manifest_generator_tt * MC_EXPORT_API ManifestGeneratorNew(manifest_api_settings_t * set);

/** @brief Call this function to initialize the manifest generator for a session.
 *
 * Call this function to initialize the manifest generator for a session.
 * @param[in] instance a pointer to a @ref manifest_generator_tt object 
 * @param[in] bsServer a pointer to a @ref bufstream_tt object for server manifest file
 * @param[in] bsClient a pointer to a @ref bufstream_tt object for client manifest file
 * @return 0 if successful
 * @return 1 if not
 */
int32_t MC_EXPORT_API ManifestGeneratorInit(manifest_generator_tt * instance, struct bufstream *bsServer, struct bufstream *bsClient);

/** @brief Call this function to put ismv file to generated server and client manifest files.
 *
 * Call this function to put ismv file to generated server and client manifest files.
 * @param[in] instance a pointer to a @ref manifest_generator_tt object
 * @param[in] filename a pointer to a name of input video file 
 * @return 0 if successful
 * @return 1 if not
 */
int32_t MC_EXPORT_API ManifestGeneratorPutIsmvFile(manifest_generator_tt * instance, char *filename);

/** @brief Call to finish a manifest generator session
 *
 * Call to finish a manifest generator session
 * @param[in] instance a pointer to a @ref manifest_generator_tt object
 * @return 0 if successful
 * @return 1 if not
 */
int32_t MC_EXPORT_API ManifestGeneratorDone(manifest_generator_tt * instance);

/** @brief Call this function to free an @ref manifest_generator_tt object 
 *
 * Call this function to free an @ref manifest_generator_tt object 
 * @param[in] instance a pointer to a @ref manifest_generator_tt object 
 */
void MC_EXPORT_API ManifestGeneratorFree(manifest_generator_tt * instance);

/**
 * @brief Close Manifest Generator Library.
 * Call this function to close Manifest Generator Library.
 * It should be called one time after the Manifest Generator usage.
 *
 */
void MC_EXPORT_API ManifestGeneratorLibraryClose();
#ifdef __cplusplus
}
#endif


#endif // #if !defined (__MANIFEST_GENERATOR_API_INCLUDED__)

