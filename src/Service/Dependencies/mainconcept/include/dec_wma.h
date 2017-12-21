/** 
 @file  dec_wma.h
 @brief  WMA Decoder API
 
 @verbatim
 File: dec_wma.h
 
 Desc: WMA Decoder API
 
 Copyright (c) 2015 MainConcept GmbH or its affiliates.  All rights reserved.

 MainConcept and its logos are registered trademarks of MainConcept GmbH or its affiliates.  
 This software is protected by copyright law and international treaties.  Unauthorized 
 reproduction or distribution of any portion is prohibited by law.
 @endverbatim
 **/
#if !defined (__DEC_WMA_API_INCLUDED__)
#define __DEC_WMA_API_INCLUDED__

#include "bufstrm.h"
#include "mcapiext.h"

#ifdef __cplusplus
extern "C" {
#endif 

/** 
    * @brief Create the WMA Decoder
    * @brief Call this function to get a @ref bufstream interface for the WMA decoder
    * @return  point to a @ref bufstream interface
    **/
bufstream_tt * MC_EXPORT_API open_WMAin_Audio_stream   (void);

/** 
* @brief Create the WMA Decoder
* @brief Call this function to get a @ref bufstream interface for the WMA decoder
* @param[in] Input param is pointer to a get_rc function
* @return point to a @ref bufstream interface
**/
bufstream_tt * MC_EXPORT_API open_WMAin_Audio_stream_ex(void *(MC_EXPORT_API *get_rc)(const char* name), int32_t reserved1, int32_t reserved2);

/**
* @brief Call to get extended API function
* @param[in] func - function ID
* @return function pointer or NULL
**/
APIEXTFUNC MC_EXPORT_API WMAin_Audio_GetAPIExt(uint32_t func);


#ifdef __cplusplus
}
#endif 


#endif // #if !defined (__DEC_WMA_API_INCLUDED__)

