/** 
 @file  mpd_generator.h
 @brief MPD Generator API
 
 @verbatim
 File: mpd_generator.h
 Desc: MPD Generator API
 
 Copyright (c) 2015 MainConcept GmbH or its affiliates.  All rights reserved.

 MainConcept and its logos are registered trademarks of MainConcept GmbH or its affiliates.  
 This software is protected by copyright law and international treaties.  Unauthorized 
 reproduction or distribution of any portion is prohibited by law.
 @endverbatim
 **/

typedef void*  mpd_generator_tt;			///<  MPD Generator instance type

/**
 * @name Profiles
 * @{
 **/
#define MPD_PROFILE_FULL 0					///< Full profile
#define MPD_PROFILE_ISOFF_ON_DEMAND 1		///< ISO Base media file format On Demand profile
#define MPD_PROFILE_ISOFF_LIVE 2			///< ISO Base media file format live profile
#define MPD_PROFILE_ISOFF_MAIN 3			///< ISO Base media file format main profile
#define MPD_PROFILE_DPS             4       ///< DPS profile
#define MPD_PROFILE_DPS_LIVE        5       ///< DPS Live profile
/** @} */

/**
 * @name MPD types
 * @{
 **/
#define MPD_TYPE_STATIC 0					///< Static MPD
#define MPD_TYPE_DYNAMIC 1		            ///< Dynamic MPD
/** @} */


#ifdef __cplusplus
extern "C" {
#endif

#ifdef __GNUC__
#pragma pack(push,1)
#else
#pragma pack(push)
#pragma pack(1)
#endif


/**
 * @name MPD generator settings structure
 * @{
 **/

typedef struct name_value_map_set_t
{
	int8_t * pName;
	int8_t * pValue;
} name_value_map_t;

typedef struct content_protection_set_t
{
	int8_t	*	pSchemeIdUri;
	int8_t	*	pValue;
	uint32_t	nElements;
	name_value_map_t	* pElements;
} content_protection_t;

typedef struct segment_timeline_t
{
    typedef struct {
        int64_t repeat; /**<@brief SegmentTimeline/S@r */
        int64_t duration; /**<@brief SegmentTimeline/S@d */
        int64_t time; /**<@brief SegmentTimeline/S@t, not implemented */
    } S;
    S* pSegment;
    uint32_t nSegment;
} segment_timeline_t;

/**<@brief This structure is used to configure the MPD element */
typedef struct mpd_generator_set_t
{
	int32_t profiles;		    /**<@brief Media Presentation profile. Available values are @ref MPD_PROFILE_FULL .. @ref MPD_PROFILE_DPS_LIVE.*/
    int32_t mpd_type;           /**<@brief Media presentation type. Available values are @ref MPD_TYPE_STATIC , @ref MPD_TYPE_DYNAMIC.*/
    int64_t adaptation_set_id;  /**<@brief Identifier for current adaptation set.*/
    int8_t * pBaseURL;		    /**<@brief A pointer to Base URL that can be used to specify common locations for Segments and other resources. Should be UTF-8.*/
    int8_t * pFileURL;		    /**<@brief A pointer to file URL. Should be UTF-8.*/
    int32_t segmentAlignment;   /**<@brief Specifies value segmentAlignment in output MPD file. For more details see ISO/IEC 23009-1.2014. */
    int32_t bitstreamSwitching; /**<@brief Specifies value bitstreamSwitching in output MPD file. For more details see ISO/IEC 23009-1.2014. */
    int64_t availabilityStartTime; /**<@brief Specifies value availabilityStartTime in output MPD file. For more details see ISO/IEC DIS 23009-1.2014. */
    int64_t availabilityEndTime; /**<@brief Specifies value availabilityEndTime in output MPD file. For more details see ISO/IEC DIS 23009-1.2014. */
    uint32_t bandwidth;

    uint32_t segmentStartNumber;
    int64_t timeShiftBufferDepth;
    int32_t useLocalAvailabilityStartTime;     /**<@brief If set to 1, than mpd_generator ignores availabilityStartTime parameter and uses local time for that (in UTC timezone). */
    int64_t minimumUpdatePeriod;

	uint32_t nExtraNamespaces;                 /**<@brief Number of extra namespaces. */
	name_value_map_t * pExtraNamespaces;       /**<@brief Use this field to specify extra namespaces in MPD root element. Should be UTF-8.*/

	uint32_t nContentProtection;               /**<@brief Number of content protection tags. */
	content_protection_t * pContentProtection; /**<@brief Content protection information. For more details see ISO/IEC 23009-1.2014. */

    int8_t * numberFormatTag;                  /**<@brief Format tag for $Number$ template following this prototype: %0[width]d where [width] is the minimum number of characters to be printed. 
                                                        For more details see ISO/IEC 23009-1.2014 and IEEE 23009-1.2014. Should be UTF-8. */
    uint64_t minBufferTime;                    /**<@brief Specifies a common duration used in the definition of the Representation data rate (in 100 ns). For more details see ISO/IEC 23009-1.2014.*/

    int64_t periodStart;                       /**<@brief Specifies a period start time (in 100 ns).*/

    int8_t* initSegmentName;                   /**<@brief Specifies name of initialization segment. Should be UTF-8. Optional*/

    int64_t publishingDelay;                   /**<@brief Specifies publishing delay in seconds affects on availabilityStart time and publishTime fields. If useLocalAvailabilityStartTime is set to 1, then availabilityStartTime will be calculated as LocalTime + publishingDelay*/ 
                                               
    int64_t publishTime;                       /**<@brief Specifies value publishTime in output MPD file. For more details see ISO/IEC 23009-1.2014. */
    int32_t useLocalPublishTime;               /**<@brief If set to 1, than mpd_generator ignores publishTime parameter and uses local time for that (in UTC timezone). */

    int8_t ** pAlternateBaseUrls;              /**<@brief A pointer to Base URLs that can be used to specify alternate baseUrls. Should be UTF-8.*/
    uint32_t  nAlternateBaseUrls;              /**<@brief Number of pAlternateBaseUrls elements */

    int32_t useSegmentTimeline;                /**<@brief This flag indicates to use SegmentTimeline instead of 'duration' attribute in SegmentTemplate. Default is 0. */
    segment_timeline_t* pSegmentTimeline;      /**<@brief This pointer represents initial state of SegmentTimeline element. It will be used when useSegmentTimeline is 1. Default is NULL. */
    int32_t nonNegativeMode;                   /**<@brief This flag indicates the condition of non-negative mode for "repeatCount" parameter. Default value is "0" that means "disabled". <br/>
                                                * Some kinds of players don't support negative "r" values in segmentTimeline. Therefore there is a need to enable non-negative mode for this parameter.*/
    
    uint32_t periodId;                         /**<@brief Specifies a period ID.*/

    int64_t suggestedPresentationDelay;       /**<@brief When mpd_type is 'MPD_TYPE_DYNAMIC', it specifies a fixed delay offset in time from the presentation (in 100ns). Default value is -1, it means no value is provided. For more details see ISO/IEC 23009-1.2014.*/

    int32_t reserved[44];
    int32_t * p_reserved[59];
}mpd_generator_set_t;
/** @} */

#pragma pack(pop)

/**
 * @brief Call this function to create a new MPD generator instance.
 *
 * Call this function to create a new MPD generator instance.
 * @param[in] get_rc the get_rc callback to provide an err_printf callback to get error messages that can be localized.
 * @param[in] set pointer to @ref mpd_settings_tt settings to adjust the MPD element
 * @return pointer to a @ref mpd_generator_tt object if successful
 * @return NULL if unsuccessful
 */
mpd_generator_tt * MC_EXPORT_API MPDGeneratorNew(
    void * (MC_EXPORT_API * get_rc)(const char* name),
    mpd_generator_set_t * set);

/** @brief Call this function to initialize the MPD generator for a session.
 *
 * Call this function to initialize the MPD generator for a session.
 * @param[in] instance pointer to a @ref mpd_generator_tt object 
 * @param[in] bsMPD pointer to a @ref bufstream_tt object
 * @return 0 if successful
 * @return 1 if not
 */
int32_t MC_EXPORT_API MPDGeneratorInit(mpd_generator_tt * instance, struct bufstream *bsMPD, struct bufstream * bsInfo);

/** @brief Call this function to finish the MPD generator session.
 *
 * Call this function to finish the MPD generator session.
 * @param[in] instance pointer to a @ref mpd_generator_tt object
 * @return 0 if successful
 * @return 1 if not
 */
int32_t MC_EXPORT_API MPDGeneratorDone(mpd_generator_tt * instance);

/** @brief Call this function to delete the MPD generator instance.
 *
 * Call this function to delete the MPD generator instance.
 * @param[in] instance pointer to a @ref mpd_generator_tt object. 
 */
void MC_EXPORT_API MPDGeneratorFree(mpd_generator_tt * instance);

/**
 * @brief Fill mpd_generator_set_t-structure with defaults values.
 * @param[out] set destination for mpd generator settings
 * @param[in] profile - any from MCPROFILE_xxx
 */
int32_t MC_EXPORT_API MPDGeneratorDefaults(mpd_generator_set_t * set, int32_t profile);

/**
 * @brief Checks mpd generator settings for any conformance invalidation.
 * @param[in] get_rc the get_rc callback to provide an err_printf callback to get error messages that can be localized.
 * @param[in] mpd generator settings.
 * @param[in] options, not used.
 * @param[in] app, not used.
 */
int32_t MC_EXPORT_API MPDGeneratorCheckSettings(
    void *(MC_EXPORT_API *get_rc)(const char* name),
    mpd_generator_set_t * set, uint32_t options, void *app);

/**
 * @brief Call this function to update settings in existing MPD generator instance.
 *
 * Call this function to update settings in existing MPD generator instance.
 * @param[in] instance pointer to a @ref mpd_generator_tt object.
 * @param[in] set pointer to @ref mpd_settings_tt settings to adjust the MPD element
 */
int32_t MC_EXPORT_API MPDGeneratorUpdateSettings(
    mpd_generator_tt * instance,
    mpd_generator_set_t * set);

#ifdef __cplusplus
}
#endif