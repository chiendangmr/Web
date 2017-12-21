/**
 @file  hls_playlist_generator.h
 @brief HLS playlist generator API

 @verbatim
 File: hls_playlist_generator.h
 Desc: HLS playlist generator API

 Copyright (c) 2016 MainConcept GmbH or its affiliates.  All rights reserved.

 MainConcept and its logos are registered trademarks of MainConcept GmbH or its affiliates.
 This software is protected by copyright law and international treaties.  Unauthorized
 reproduction or distribution of any portion is prohibited by law.
 @endverbatim
 **/
#if !defined (__HLS_PLAYLIST_GENERATOR_API_INCLUDED__)
#define __HLS_PLAYLIST_GENERATOR_API_INCLUDED__

typedef void*  hls_playlist_generator_tt;			                    ///<  HLS playlist generator instance type

#ifdef __cplusplus
extern "C" {
#endif
    /**
    * @brief Playlist types
    */
    typedef enum
    {
        PLAYLIST_TYPE_VOD,                                              ///< VOD type
        PLAYLIST_TYPE_LIVE,                                             ///< LIVE type
        PLAYLIST_TYPE_EVENT                                             ///< EVENT type
    } playlist_type_t;

    /**
    * @brief HLS Media information structure
    */
    typedef struct
    {
        uint8_t *       language;                                       ///< A pointer to the primary language, which is used in the Rendition. Optional attribute. Should be UTF-8.
        uint8_t *       assoc_language;                                 ///< A pointer to a language that is associated with the Rendition. Optional attribute. Should be UTF-8.
        uint8_t *       name;                                           ///< A pointer to a human-readable description of the Rendition. Required attribute. Should be UTF-8.
        uint8_t         default_flag;                                   ///< If the value is 1, then the client SHOULD play this Rendition of the content in the absence of information from the user indicating a different choice. Optional attribute.
        uint8_t         autoselect_flag;                                ///< If the value is 1, then the client MAY choose to play this Rendition in the absence of explicit user preference. Optional attribute.
        uint8_t         forced_flag;                                    ///< A value of 1 indicates that the Rendition contains content which is considered essential to play. Optional attribute.
        uint8_t *       instream_id;                                    ///< A pointer to a string that specifies a Rendition within the segments in the Media Playlist. Required attribute for closed captions. Should be UTF-8.
        uint8_t *       characteristics;                                ///< A pointer to a string containing one or more Uniform Type Identifiers [UTI] separated by comma (,) characters. Optional attribute. Should be UTF-8.
        uint8_t         reserved[29];
        uint8_t *       p_reserved[27];
    } hls_media_t;

    /**
    * @brief HLS Stream information structure
    */
    typedef struct
    {
        uint8_t *       uri;                                            ///< A pointer to an URI to identify the Playlist file. Required attribute. Should be UTF-8.
        uint32_t        bandwidth;                                      ///< It is decimal integer which represents the peak segment bit rate of the Variant Stream. Required attribute.
        uint32_t        average_bandwidth;                              ///< It is decimal integer which represents the average segment bit rate of the Variant Stream. Optional attribute.
        uint8_t *       audio_codec;                                    ///< A pointer to a string which represents audio codec string. Required if stream contains audio. Should be UTF-8.
        uint8_t *       video_codec;                                    ///< A pointer to a string which represents video codec string. Required if stream contains video. Should be UTF-8.
        uint32_t        width;                                          ///< It is decimal integer describing the optimal pixel width resolution at which to display all the video in the Variant Stream. Optional attribute.
        uint32_t        height;                                         ///< It is decimal integer describing the optimal pixel height resolution at which to display all the video in the Variant Stream. Optional attribute.
        uint8_t *       audio_group_id;                                 ///< A pointer to a string which specifies the group to which the Rendition belongs. Required attribute for audio type. Should be UTF-8.
        uint8_t *       video_group_id;                                 ///< A pointer to a string which specifies the group to which the Rendition belongs. Required attribute for video type. Should be UTF-8.
        uint8_t *       subtitles_group_id;                             ///< A pointer to a string which specifies the group to which the Rendition belongs. Required attribute for subtitles type. Should be UTF-8.
        uint8_t *       closed_captions_group_id;                       ///< A pointer to a string which specifies the group to which the Rendition belongs. Required attribute for closed captions type. Should be UTF-8.
        uint8_t         reserved[16];
        uint8_t *       p_reserved[25];
    } hls_stream_inf_t;

    /**
    * @brief This structure is used to configure the HLS element
    */
    typedef struct
    {
        int32_t				hls_version;						        ///< A string which specifies the compatibility HLS version number for playlist file.
        playlist_type_t		media_playlist_type;				        ///< One of @ref playlist_type_t value, which specifies the type of playlist file.
        hls_media_t         media;                                      ///< @ref hls_media_t structure
        hls_stream_inf_t    stream_inf;                                 ///< @ref hls_stream_inf_t structure
        uint32_t            segment_count;                              ///< It is integer describing the maximum number of segments in the playlist file

        uint8_t             reserved[256];
        void *              p_reserved[108];
    } hls_playlist_generator_set_t;

    /**
     * @brief Call this function to create a new HLS playlist generator instance.
     * @param[in] get_rc the get_rc callback to provide an err_printf callback to get error messages that can be localized.
     * @param[in] set pointer to @ref hls_playlist_generator_set_t settings to adjust the HLS element
     * @param[in] app is reserved pointer to structure
     * @return pointer to a @ref hls_playlist_generator_tt object if successful
     * @return NULL if unsuccessful
     */
    hls_playlist_generator_tt * MC_EXPORT_API HLSPlaylistGeneratorNew(void * (MC_EXPORT_API * get_rc)(const char* name), hls_playlist_generator_set_t* set, void *app);
    
    /** @brief Call this function to initialize the HLS playlist generator for a session.
    * @param[in] instance pointer to a @ref hls_playlist_generator_tt object
    * @param[in] bs_file_for_m3u8 pointer to a HLS playlist @ref bufstream_tt object
    * @param[in] bs_file_for_meta pointer to a HLS meta information @ref bufstream_tt object
    * @param[in] bs_muxer pointer to a @ref bufstream_tt object
    * @return 0 if successful
    */
    int32_t						MC_EXPORT_API HLSPlaylistGeneratorInit(hls_playlist_generator_tt* instance, struct bufstream *bs_file_for_m3u8, struct bufstream *bs_file_for_meta, struct bufstream * bs_muxer);

    /** @brief Call this function to finish the HLS playlist generator session.
    * @param[in] instance pointer to a @ref hls_playlist_generator_tt object
    * @return 0 if successful
    */
    int32_t						MC_EXPORT_API HLSPlaylistGeneratorDone(hls_playlist_generator_tt* instance);

    /** @brief Call this function to delete the HLS playlist generator instance.
    * @param[in] instance pointer to a @ref hls_playlist_generator_tt object.
    */
    void						MC_EXPORT_API HLSPlaylistGeneratorFree(hls_playlist_generator_tt* instance);

    /**
    * @brief Fill hls_playlist_generator_set_t structure with defaults values.
    * @param[out] set destination for HLS playlist generator settings
    * @param[in] profile any from MCPROFILE_xxx
    */
    int32_t						MC_EXPORT_API HLSPlaylistGeneratorDefaults(hls_playlist_generator_set_t* set, int32_t profile);

    /**
    * @brief Checks HLS settings for any conformance invalidation.
    * @param[in] get_rc the get_rc callback to provide an err_printf callback to get error messages that can be localized.
    * @param[in] set the @ref hls_playlist_generator_set_t settings.
    * @param[in] options parameter is not used.
    * @param[in] app is reserved pointer to structure.
    * @return Returns 0 if successful
    */
    int32_t						MC_EXPORT_API HLSPlaylistGeneratorCheckSettings(void *(MC_EXPORT_API *get_rc_ex)(const char* name), hls_playlist_generator_set_t* set, uint32_t options, void *app);

    /**
    * @brief Call this function to update settings in existing HLS playlist generator instance.
    * @param[in] instance pointer to a @ref hls_playlist_generator_tt object.
    * @param[in] set pointer to @ref hls_playlist_generator_set_t settings to adjust the HLS element
    * @return Returns 0 if successful
    */
    int32_t						MC_EXPORT_API HLSPlaylistGeneratorUpdateSettings(hls_playlist_generator_tt* instance, hls_playlist_generator_set_t* set);

    /**
    * @brief Call this function to generate HLS master playlist from HLS meta information files.
    * @param[in] get_rc the get_rc callback to provide an err_printf callback to get error messages that can be localized.
    * @param[in] a @ref uint32_t meta_files_count - number of meta information files
    * @param[in] a @ref struct bufstream ** bs_for_input_meta_files - bufstream array of the input meta informations
    * @param[in] a @ref struct bufstream* bs_for_output_master_playlist - output bufstream for HLS master playlist
    * @return Returns 0 if successful
    */
    int32_t						MC_EXPORT_API HLSPlaylistGeneratorCreateMasterPlaylist(void *(MC_EXPORT_API *get_rc_ex)(const char* name), uint32_t meta_files_count, struct bufstream **bs_for_input_meta_files, struct bufstream* bs_for_output_master_playlist);

#ifdef __cplusplus
}
#endif

#endif //#if !defined (__HLS_PLAYLIST_GENERATOR_API_INCLUDED__)