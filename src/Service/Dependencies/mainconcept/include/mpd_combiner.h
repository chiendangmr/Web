/** 
 @file  mpd_combiner.h
 @brief MPD Combiner API
 
 @verbatim
 File: mpd_combiner.h
 Desc: MPD Combiner API

 Copyright © 2015 DivX Corporation or its subsidiaries. All rights reserved.

 DivX Corporation, DivX, the DivX logo are registered trademarks of DivX Corporation.
 This software is protected by copyright law and international treaties.
 Unauthorized reproduction or distribution of any portion is prohibited by law.
 @endverbatim
 **/

#if !defined (MPD_COMBINER_INCLUDED)
#define MPD_COMBINER_INCLUDED

#include "mcdefs.h"

typedef void*  mpd_combiner_tt;			    ///<  MPD Combiner instance type

#ifdef __cplusplus
extern "C" {
#endif

/**
 * @brief Call this function to create a new MPD combiner instance.
 *
 * Call this function to create a new MPD combiner instance.
 * @return pointer to a @ref mpd_combiner_tt object if successful
 * @return NULL if unsuccessful
 */
mpd_combiner_tt * MC_EXPORT_API MPDCombinerNew(void);

/** @brief Call this function to delete the MPD combiner instance.
 *
 * Call this function to delete the MPD combiner instance.
 * @param[in] instance pointer to a @ref mpd_combiner_tt object. 
 */
void MC_EXPORT_API MPDCombinerFree(mpd_combiner_tt *instance);

/** @brief Call this function to merge of the MPD files.
 *
 * Call this function to merge the MPD files.
 * @param[in] instance pointer to a @ref mpd_combiner_tt object
 * @param[in] a @ref int32_t numInputFiles object (number of input files)
 * @param[in] a @ref const char ** inputFileNames object (input files names)
 * @param[in] a @ref const char * outputFileName object (output file name)
 * @return 0 if successful
 * @return @ref int32_t @ref MPD Combiner errors if not
 */
int32_t MC_EXPORT_API MPDCombinerMerge(mpd_combiner_tt *instance, int32_t numInputFiles, const char **inputFileNames, const char *outputFileName);

/** @brief Call this function to merge of the MPD files.
*
* Call this function to merge the MPD files.
* @param[in] instance pointer to a @ref mpd_combiner_tt object
* @param[in] a @ref uint32_t numInputMpdBufstreams - number of mpd bufstreams
* @param[in] a @ref struct bufstream ** inputMpdBufstreams - bufstream array of the input mpd informations
* @param[in] a @ref struct bufstream* combinedMpdBufstream - output bufstream for combined mpd
* @return 0 if successful
* @return @ref int32_t @ref MPD Combiner errors if not
*/
int32_t MC_EXPORT_API MPDCombinerMergeBS(mpd_combiner_tt *instance, uint32_t numInputMpdBufstreams, struct bufstream **inputMpdBufstreams, struct bufstream* combinedMpdBufstream);

#ifdef __cplusplus
}
#endif

#endif      // MPD_COMBINER_INCLUDED