/* ----------------------------------------------------------------------------
 * File: demux_asf.h
 *
 * Desc: ASF Demuxer API
 *
 * Copyright (c) 2015 MainConcept GmbH or its affiliates.  All rights reserved.
 *
 * MainConcept and its logos are registered trademarks of MainConcept GmbH or its affiliates.  
 * This software is protected by copyright law and international treaties.  Unauthorized 
 * reproduction or distribution of any portion is prohibited by law.
 * ----------------------------------------------------------------------------
 */

//! @file demux_asf.h
//! ASF Demuxer interfaces

#if !defined (__DEMUX_ASF_API_INCLUDED__)
#define __DEMUX_ASF_API_INCLUDED__

#include "mctypes.h"
#include "mcdefs.h"
#include "bufstrm.h"
#include "mcapiext.h"
#include "mcmediatypes.h"

#define MC_NO_DECODING_VIDEO
#define MC_NO_DECODING_AUDIO
#define MS_NO_SUSPICIOUS_TIMESTAMP

#define OK      0
#define FAIL    -1
#define TRUE    1
#define FALSE   0

#define PAYLOAD_NONE     0xFFFFFFFF
#define PAYLOAD_AUDIO    0x00000001
#define PAYLOAD_VIDEO    0x00000002
#define PAYLOAD_BINARY   0x00000003

#define VC1_DATA_DEFAULT 0x00000000
#define VC1_NEW_FRAME    0x00000001


/** external i/o function prototypes
* @note these are depreciated, the \ref asfdmux_settings_t.p_external_io should be used instead
* @note if these are used, the \ref asfdmux_settings_t.file_length field MUST be filled in
*       with the correct file size by the app
* called to open a file
* and the return value will be passed back to the seek, read and close functions
* ext_app_ptr - the ext_app_ptr field in the asfdmux_settings_t structure is passed back here
* fileName - if a filename was passed to the demuxer, it is returned here
* return the file handle as a long or -1 if an error occurs
*/

typedef long (*asf_external_open_callback)(void *ext_app_ptr, char *fileName);
#if !defined(__APPLE__) && !defined(__linux__) && !defined(__vxworks)
typedef long (*asf_external_open_callbackW)(void *ext_app_ptr, wchar_t *fileName);
#else
typedef long (*asf_external_open_callbackW)(void *ext_app_ptr, uint16_t *fileName);
#endif

/** called to seek in a file
* ext_app_ptr - the ext_app_ptr field in the asfdmux_settings_t structure is passed back here
* fileHandle - a file handle returned by the asf_external_open_callback function
* position - the position to seek to
* return 0 if Ok, 1 if an error occurs
*/
typedef int32_t (*asf_external_seek_callback)(void *ext_app_ptr, long fileHandle, int64_t position);

/** called to read from a file
* ext_app_ptr - the ext_app_ptr field in the asfdmux_settings_t structure is passed back here
* fileHandle - a file handle returned by the asf_external_open_callback function
* buffer - a buffer for the data
* bufferSize - the number of bytes to read
* return the number of bytes actually read or 0 if an error occurs
*/
typedef int32_t (*asf_external_read_callback)(void *ext_app_ptr, long fileHandle, uint8_t *buffer, int32_t bufferSize);

/** called to close a file
* ext_app_ptr - the ext_app_ptr field in the asfdmux_settings_t structure is passed back here
* fileHandle - a file handle returned by the asf_external_open_callback function
*/
typedef void (*asf_external_close_callback)(void *ext_app_ptr, long fileHandle);


//! @brief Used to create an asf demuxer instance
//! @details The settings used to create a demultiplexer instance
typedef struct
{
//! @{
//! @brief External IO parameters.
    uint8_t use_external_io;                                 //!< @brief Indicates that the app will provide the I/O for the demuxer.
    asf_external_open_callback external_open_callback;       //!< @brief External open callback pointer.
    asf_external_open_callbackW external_open_callbackW;     //!< @brief UNICODE external open callback pointer.
    asf_external_seek_callback external_seek_callback;       //!< @brief External seek callback pointer.
    asf_external_read_callback external_read_callback;       //!< @brief External read callback pointer.
    asf_external_close_callback external_close_callback;     //!< @brief External close callback pointer.
    void *ext_app_ptr;                                       //!< @brief App pointer for external I/O mode, it is passed to the external callbacks.
    int64_t file_length;                                     //!< @brief Length of the input file, used for external I/O mode only.
    mc_external_io_t *p_external_io;                         //!< @brief If non NULL and use_external_io = 1, this will be used instead of the above.
//!@}

    uint8_t reserved[27];                                    //!< Reserved

} asfdmux_settings_t;


//! @brief Define the stream info
typedef struct
{
    uint32_t stream_type;                                     //!< @brief One of the PAYLOAD_xxx defines above.
    uint32_t stream_title;                                    //!< @brief The stream title number, use with the \ref asfdmux_stream_settings_t structure.
    uint32_t stream_id;                                       //!< @brief The stream ID number, use with the \ref asfdmux_stream_settings_t structure.
    wmad_input_info wmai;                                     //!< @brief WMA audio info.
    uint8_t vc1_additional_info [1024];                       //!< @brief VC1 additional info.
    int32_t vc1_additional_info_len;                          //!< @brief VC1 additional info.
    mc_stream_format_t format;                                //!< @brief Stream format information.
    int64_t duration;                                         //!< @brief The stream duration in milliseconds.

    uint8_t reserved[4];                                      //!< Reserved

} asf_stream_info_t;


//! @brief Defines the title info
typedef struct
{
    uint32_t num_streams;                                     //!< @brief The total number of streams in the title.
    uint32_t num_streams_a;                                   //!< @brief The total number of audio streams in the title.
    uint32_t num_streams_v;                                   //!< @brief The total number of video streams in the title.
    uint32_t num_streams_b;                                   //!< @brief The total number of other streams in the title.
    asf_stream_info_t **stream;                               //!< @brief An array of pointers to a asf_stream_info_t structure for each stream.
    int64_t duration;                                         //!< @brief The duration of the title in milliseconds.

    uint8_t reserved[56];                                     //!< Reserved

} asf_title_info_t;


//! @brief Defines the file info
typedef struct
{
    int32_t num_titles;                                       //!< @brief The number of titles in the file.
    asf_title_info_t **title_info;                            //!< @brief An array of pointers to a asf_title_info_t structure for each title.
    int64_t file_size;                                        //!< @brief The size of the file in bytes.
    
    uint8_t reserved[56];                                     //!< Reserved
    
    uint32_t iFramesCountVideo;                               //!< @brief Depreciated
    uint32_t iFramesCountAudio;                               //!< @brief Depreciated

} asf_file_info_t;


//! @brief Settings used when creating a parser
typedef struct
{
    uint8_t pull_mode;                                        //!< @brief Set to 1 if the app will call auxinfo to get data, otherwise the app will call asfDemuxPush.
    uint32_t requested_buffer_size;                           //!< @brief Size in bytes the app would like the parser to use for bitstream buffers.

    uint8_t reserved[59];                                     //!< Reserved

} asfdmux_parser_settings_t;


//! @brief Settings used when adding a stream to a parser
typedef struct
{
    bufstream_tt *bs_out;                                     //!< @brief Pointer to a bufstream_tt instance for the streams output.
    int32_t payload_type;                                     //!< @brief depreciated, no longer needed
    uint32_t title_num;                                       //!< @brief The title number of the stream.
    uint32_t stream_id;                                       //!< @brief The stream stream id.
    uint8_t add_annex_e;                                      //!< @brief Add headers to output video stream (annex e headers for VC1, mpeg-4 headers, etc).

    uint8_t reserved[63];                                     //!< Reserved

} asfdmux_stream_settings_t;



#ifdef __cplusplus
extern "C" {
#endif

//! call to create and initialize an demuxer instance
//!
//! @param[in]    get_rc_ex			pointer to a get_rc_ex resource function
//! @param[in]    rc_app_ptr		application supplied pointer that will be passed back with any get_rc calls
//! @param[in]    asfdmux_settings	pointer to an asfdmux_settings_t structure
//!
//! @return a pointer to a demuxer instance if successful, else NULL

void* MC_EXPORT_API asfDemuxNewEx(void *(MC_EXPORT_API*get_rc_ex)(void *rc_app_ptr, const char*name), void *rc_app_ptr, asfdmux_settings_t *asfdmux_settings);


//! call to free a demuxer instance
//!
//! @param[in]    instance		pointer to a demuxer instance
//!
//! @return    none

void MC_EXPORT_API asfDemuxFree(void *instance);


//! call to open a file for demuxing
//!
//! @param[in]    instance		pointer to a demuxer instance
//! @param[in]    reserved		reserved
//! @param[in]    infilename	pointer to a filename to open
//!
//! @return    0 if successful, else non-zero

int32_t MC_EXPORT_API asfDemuxOpen(void *instance, void* reserved, char *infilename);
#if !defined(__APPLE__) && !defined(__linux__) && !defined(__vxworks) && !defined(__QNX__)
int32_t MC_EXPORT_API asfDemuxOpenW(void *instance, void* reserved, wchar_t *infilename);
#else
// this version will currently return an error!
int32_t MC_EXPORT_API asfDemuxOpenW(void *instance, void* reserved, uint16_t *infilename);
#endif


//! call to close file
//!
//! @param[in]    instance		pointer to a demuxer instance
//!
//! @return    none

void MC_EXPORT_API asfDemuxClose(void *instance);


//! call to get information about the input file
//!
//! @param[in]    instance			pointer to a demuxer instance
//! @param[in]    asf_file_info		pointer to a asf_file_info_t structure
//!
//! @return    none

void MC_EXPORT_API asfDemuxGetFileInfo(void *instance, asf_file_info_t* asf_file_info);


//! call to create and initialize a parser instance
//!
//! @param[in]    instance					pointer to a demuxer instance
//! @param[in]    asfdmux_parser_settings	pointer to a asfdmux_parser_settings_t structure
//!
//! @return    a non-zero parser number if successful, else 0

int32_t MC_EXPORT_API asfDemuxNewParser(void *instance, asfdmux_parser_settings_t *asfdmux_parser_settings);


//! call to free a parser instance
//!
//! @param[in]    instance		pointer to a demuxer instance
//! @param[in]    parser_num	parser number
//!
//! @return   none

void MC_EXPORT_API asfDemuxFreeParser(void *instance, int32_t parser_num);


//! call to add a stream to a parser instance
//!
//! @param[in]    instance		pointer to a demuxer instance
//! @param[in]    parser_num	parser number
//! @param[in]    sinfo			pointer to an asfdmux_stream_settings_t structure
//!
//! @return    0 if successful, else non-zero

int32_t MC_EXPORT_API asfDemuxAddStream(void *instance, int32_t parser_num, asfdmux_stream_settings_t *sinfo);


//! call to seek to the specified time
//!
//! @param[in]    instance		pointer to a demuxer instance
//! @param[in]    parser_num	parser number
//! @param[in]    pTime			pointer to a int64_t that contains the seek time on entry, on exit the actual time is returned here
//!
//! @return    0 if successful, 2 if EOF, 1 if an error occurs

int32_t MC_EXPORT_API asfDemuxSeek(void *instance, int32_t parser_num, int64_t *pTime);


//! call to push data through the parser
//!
//! @param[in]    instance		pointer to a demuxer instance
//! @param[in]    parser_num	parser number
//!
//! @return   \-1 if an error occurs, 0 if EOF else the number of bytes consumed from the source

int32_t MC_EXPORT_API asfDemuxPush(void *instance, int32_t parser_num);


//! call to re-open a parser
//!
//! @param[in]    instance		pointer to a demuxer instance
//! @param[in]    parser_num	parser number
//!
//! @return   0 if successful, else non-zero

int32_t MC_EXPORT_API asfDemuxWakeParser(void *instance, int32_t parser_num);


//! call to close the actual file of a parser, the parser is left intact and can be re-opened with the wake function
//!
//! @param[in]    instance		pointer to a demuxer instance
//! @param[in]    parser_num	parser number
//!
//! @return   0 if successful, else non-zero

int32_t MC_EXPORT_API asfDemuxSleepParser(void *instance, int32_t parser_num);


//! call to get extend API functions
//!
//! @param[in]   func	ID for function a pointer to get
//!
//! @return  function pointer or NULL

APIEXTFUNC asfDemuxGetAPIExt(uint32_t func);


//! @name functions, being removed: Do not use!
//!@{
void* MC_EXPORT_API asfDemuxNew(void *(MC_EXPORT_API*get_rc)(const char* name), asfdmux_settings_t *asfdmux_settings);
int32_t MC_EXPORT_API asfDemuxFlush(void *instance, int32_t parser_num);
int32_t MC_EXPORT_API asfDemuxGetFrameCount(void *instance, asf_file_info_t* asf_file_info);
//!@}


#ifdef __cplusplus
}
#endif

#endif // #if !defined (__DEMUX_ASF_API_INCLUDED__)

