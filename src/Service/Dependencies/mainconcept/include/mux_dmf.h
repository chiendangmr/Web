/********************************************************************
 Created:   2008/05/21
 File name: mux_dmf.h
 Purpose:   DMF muxer API declaration

 Copyright (c) 2008 MainConcept GmbH. All rights reserved.

 This software is the confidential and proprietary information of
 MainConcept GmbH and may be used only in accordance with the terms of
 your license from MainConcept GmbH.

*********************************************************************/

#ifndef __MUX_DMF_H__
#define __MUX_DMF_H__

#include "mctypes.h"
#include "mcdefs.h"
#include "mcmediatypes.h" 
#include "bufstrm.h"
#include "mcapiext.h"

/////////////////////////////////////////////////////////////////////////////
// API structures
/////////////////////////////////////////////////////////////////////////////

typedef struct _dmf_muxer dmf_muxer_tt;          // muxer object


#ifdef __GNUC__
#pragma pack(push,1)
#else
#pragma pack(push)
#pragma pack(1)
#endif

// this flag is a common flag used in the flags field of several structures. If
// present it indicates the string pointers in the structure or API parameters are
// unicode strings instead of char strings, valid for windows platforms only
// this define can be used in all the flags field in place of the specific named
// flags
#define MUX_DMF_STRINGS_ARE_UNICODE             0x80000000


// multiplexer settings
struct dmf_m_settings
{   
    int32_t module_id;                          // module ID, one of the DMF_xxx defines in mcdefs.h

    uint32_t max_titles;                        // maximum amount of titles per container
    uint32_t max_streams;                       // maximum amount of streams per title

    uint8_t reserved[244];                      // reserved for future use
};


// init settings

// indicates the dmfMuxInitFile output filename parameter is a unicode string
#define MUX_DMF_INIT_STRINGS_ARE_UNICODE        0x80000000

struct dmf_init_settings
{   
    uint32_t flags;                             // 0 or more of the MUX_DMF_INIT_XXX constants

    uint8_t reserved[256];                      // reserved for future use
};


// chapter item settings

// indicates the pointer fields in the structure are unicode strings
#define MUX_DMF_CHAPTER_STRINGS_ARE_UNICODE     0x80000000

struct dmf_chapter_settings
{
    uint32_t flags;                             // 0 or more of the MUX_DMF_CHAPTER_xxx constants

    uint64_t start_time;                        // starting time of the chapter in 10MHz units, required
    uint64_t end_time;                          // ending time of the chapter in 10MHz units, optional

    uint8_t *locale;                            // pointer to a locale string, AVI and MKV, optional
    uint8_t *country_code;                      // pointer to a country code string, AVI only, optional
    uint8_t *name;                              // pointer to a descriptive chapter name string, MKV only, optional
    
    uint8_t reserved[32];                       // reserved for future use
};


// title settings
struct dmf_title_settings
{
    uint32_t flags;                             // reserved for future use

    int32_t chapter_count;                      // the number of items in the chapter_list
    dmf_chapter_settings *chapter_list;         // pointer to an array of dmf_chapter_settings structures in
                                                // time ascending order

    uint8_t reserved[244];                      // reserved for future use
};


// stream settings

// the preferred stream identification is to use the mc_stream_format_t structure,
// if the specific input stream type is not known, use these flags to identify the basic type
#define MUX_DMF_STREAM_VIDEO                    0x00000001  // use to identify a stream as video
#define MUX_DMF_STREAM_AUDIO                    0x00000002  // use to identify a stream as audio
#define MUX_DMF_STREAM_SUBTITLE                 0x00000004  // use to identify a stream as subtitle
#define MUX_DMF_STREAM_LEAVE_VIDEO_HEADERS      0x00000010  // leave video headers (sps/pps etc) in stream
#define MUX_DMF_STREAM_STRINGS_ARE_UNICODE      0x80000000  // the dmfMuxAddFile 'input' parameter and the font_filename field are unicode strings

struct dmf_stream_settings
{
    mc_stream_format_t format;                  // mc_mediatype and format structure: video, audio or subtitle 
    
    uint8_t title_num;                          // the title number (0 based) that owns this stream
    
    uint32_t flags;                             // 0 or more of the MUX_DMF_STREAM_xxx constants

    uint8_t *locale;                            // pointer to a locale string, AVI and MKV, optional
    uint8_t *country_code;                      // pointer to a country code string, AVI only, optional
    uint8_t *media_desc;                        // pointer to a media description string, AVI only, optional
    uint8_t *stream_name;                       // pointer to a descriptive stream name string, MKV only optional

    // MKV subtitle only
    uint8_t *font_filename;                     // pointer to a filename that contains a True Type font to use with the subtitle
    uint32_t max_font_size;                     // maximum size in bytes of the final font sub-set, 0 means no maximum

    uint8_t reserved[175];                      // reserved for future use
};

#pragma pack(pop)


/////////////////////////////////////////////////////////////////////////////
// API functions
/////////////////////////////////////////////////////////////////////////////

#ifdef __cplusplus
extern "C" {
#endif

// call to fill an dmf_m_settings structure with defaults values
// based on one of the SDK profile ID's
// 
//    inputs:
//        set - pointer to an dmf_m_settings structure
//        profile - one of the MCPROFILE_* constants
//    output:
//        dmf_m_settings structure
//    return:
//        pointer to a profile string or NULL

char *dmfMuxDefaults(struct dmf_m_settings* set, int32_t profile);


// call to get the setting errors/warnings in an dmf_m_settings structure
// use with the get_rc callback to provide an err_printf callback to get
// error messages
//
//    inputs:
//        get_rc - pointer to a get_rc function
//        set - pointer to an dmf_m_settings structure
//        options - check options, one or more of the CHECK_* defines in mcdefs.h
//        app - reserved
//    outputs:
//        none
//    return:
//        INV_DMF_NO_ERROR if no errors found
//        one of the INV_* error codes if an error is found

int32_t dmfMuxChkSettings(void* (*get_rc)(const char* name),
                          const struct dmf_m_settings* set,
                          uint32_t options,
                          void* app);


// call to get the setting errors/warnings in an dmf_m_settings structure
// use with the get_rc_ex callback to provide an err_printf_ex callback to get
// error messages
//
//    inputs:
//        get_rc_ex - pointer to a get_rc_ex function
//        rc_app_ptr - user defined pointer pass back to the err_printf_ex function
//        set - pointer to an dmf_m_settings structure
//        options - check options, one or more of the CHECK_* defines in mcdefs.h
//    outputs:
//        none
//    return:
//        INV_DMF_NO_ERROR if no errors found
//        one of the INV_* error codes if an error is found

int32_t dmfMuxChkSettingsEx(void* (*get_rc_ex)(void *rc_app_ptr, const char* name),
                            void *rc_app_ptr,
                            const struct dmf_m_settings* set,
                            uint32_t options);


// call to create an DMF muxer object
//
//    inputs:
//        get_rc - pointer to a get resource function 
//        set - pointer to a filled in dmf_m_settings structure
//    outputs:
//        none
//    return:
//        pointer to a dmf_muxer_tt object if succesful
//        NULL if unsuccesful

dmf_muxer_tt* dmfMuxNew(void* (*get_rc)(const char* name),
                        const struct dmf_m_settings* set);


// call to create an DMF muxer object, get_rc_ex version
//
//    inputs:
//        get_rc_ex - pointer to a get_rc_ex resource function 
//        rc_app_ptr - user defined pointer passed back to the get_rc_ex functions
//        set - pointer to a filled in dmf_m_settings structure
//    outputs:
//        none
//    return:
//        pointer to a dmf_muxer_tt object if succesful
//        NULL if unsuccesful

dmf_muxer_tt* dmfMuxNewEx(void* (*get_rc_ex)(void *rc_app_ptr, const char* name),
                          void *rc_app_ptr,
                          const struct dmf_m_settings* set);


// call to initialize the muxer for a streaming mode muxing session
// the audio/video data comes from audio and video bufstream objects 
//
// NOTE: The output parameter must be a pointer to a bufstream
//       created with open_file_buf_rw in buf_rw.h/c or equivalent!.
//
//    inputs:
//        muxer - pointer to an dmf muxer object
//        set - pointer to a dmf_init_settings structure, can be null
//        output - pointer to a buf_rw bufstream_tt object for the output muxed data
//    outputs:
//        none
//    return:
//        0 if successful
//        non-zero if unsuccesful

int32_t dmfMuxInitStream(dmf_muxer_tt* muxer,
                         struct dmf_init_settings* set,
                         bufstream_tt* output);


// call to initialize the muxer for a file mode muxing session
// the audio/video data comes from existing files 
//
//    inputs:
//        muxer - pointer to an dmf muxer object
//        set - pointer to a dmf_init_settings structure, can be null
//        output - pointer to an output filename
//    outputs:
//        none
//    return:
//        0 if successful
//        non-zero if unsuccesful

int32_t dmfMuxInitFile(dmf_muxer_tt* muxer,
                       struct dmf_init_settings* set,
                       char *output);


// call to add a title. A default title (title 0) is created when
// dmfMuxInitStream is called. This function is called if additional
// titles are needed.
//
//    inputs:
//        muxer - pointer to an dmf muxer object
//        set   - pointer to a filled in dmf_title_settings structure, can be NULL
//    outputs:
//        none
//    return:
//        0 based title number if successful
//        less than zero if unsuccesful

int32_t dmfMuxAddTitle(dmf_muxer_tt* muxer,
                       const struct dmf_title_settings* set);


// call to add a stream to a title
//
//    inputs:
//        muxer - pointer to an dmf muxer object
//        set   - pointer to a filled in dmf_stream_settings structure
//        input - pointer to a bufstream_tt object for the input data
//    outputs:
//        none
//    return:
//        0 if successful
//        non-zero if unsuccesful

int32_t dmfMuxAddStream(dmf_muxer_tt* muxer,
                        const struct dmf_stream_settings* set,
                        bufstream_tt* input);


// call to add a file to a title
//
//    inputs:
//        muxer - pointer to an dmf muxer object
//        set   - pointer to a filled in dmf_stream_settings structure
//        input - pointer to an input filename
//    outputs:
//        none
//    return:
//        0 if successful
//        non-zero if unsuccesful

int32_t dmfMuxAddFile(dmf_muxer_tt* muxer,
                      const struct dmf_stream_settings* set,
                      char* input);


// call to mux input files
//
//    inputs:
//        muxer - pointer to an dmf muxer object
//    outputs:
//        none
//    return:
//        0 if successful
//        non-zero if unsuccesful

int32_t dmfMuxFileMux(dmf_muxer_tt* muxer);


// call to finish a muxing session, set abort to non-zero if muxing is being
// aborted.
//
//    inputs:
//        muxer - pointer to an dmf muxer object
//        abort - set to 0 to finish any leftover muxing and clean up,
//                else just clean up
//    outputs:
//        muxed data to output file
//    return:
//        0 if successful
//        non-zero if unsuccesful

int32_t dmfMuxDone(dmf_muxer_tt* muxer,
                   int32_t abort);


// call to free an dmf muxer object
//
//    inputs:
//        muxer - muxer object to free
//    outputs:
//        none
//    return:
//        none

void dmfMuxFree(dmf_muxer_tt* muxer);


APIEXTFUNC dmfMuxGetAPIExt(uint32_t func);


#ifdef __cplusplus
}
#endif

#endif // __MUX_DMF_H__
