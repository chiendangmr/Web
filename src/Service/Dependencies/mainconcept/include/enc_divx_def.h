/********************************************************************
 Created: 2008/06/01 
 File name: divxvout_def.h
 Purpose: DivX Video Encoder API defines

 Copyright (c) 2008 MainConcept GmbH. All rights reserved.

 This software is the confidential and proprietary information of
 MainConcept GmbH and may be used only in accordance with the terms of
 your license from MainConcept GmbH.

*********************************************************************/

#ifndef __DIVXVOUT_DEF_H__
#define __DIVXVOUT_DEF_H__

//    General 
#define DIVXERROR_NONE             0
#define DIVXERROR_INVALID_POINTER  1
#define DIVXERROR_NOT_SUPPORTED    2
#define DIVXERROR_PARAM_UNKNOWN    3

//    Rate Control modes
#define DIVX_RC_1PASS_CONSTANT_Q       0
#define DIVX_RC_VBV_1PASS_CQ           1
#define DIVX_RC_VBV_1PASS              2
#define DIVX_RC_VBV_MULTIPASS_1ST      3
#define DIVX_RC_VBV_MULTIPASS_FAST_1ST 4 
#define DIVX_RC_VBV_MULTIPASS_NTH      5

//    Pixel aspect ratio modes
#define DIVX_PAR_1_1                   1
#define DIVX_PAR_12_11                 2
#define DIVX_PAR_10_11                 3
#define DIVX_PAR_16_11                 4
#define DIVX_PAR_40_33                 5
#define DIVX_PAR_EXT                   15
#define DIVX_PAR_AUTO                  0
#define DIVX_PAR_AUTO_NOT_EXT          20

// Performance / quality mode for "performance"
#define DIVX_PERFORMANCE_FASTEST       -3
#define DIVX_PERFORMANCE_FASTER        -2
#define DIVX_PERFORMANCE_FAST          -1
#define DIVX_PERFORMANCE_STANDARD      0
#define DIVX_PERFORMANCE_SLOW          1
#define DIVX_PERFORMANCE_VERYSLOW      2

//    Quantization modes
#define DIVX_QUANT_H263                0
#define DIVX_QUANT_MPEG                1
#define DIVX_QUANT_H263_OPT            2

//    Psychovisual modes
#define DIVX_PSYCHOVISUAL_OFF          0
#define DIVX_PSYCHOVISUAL_SHAPING      1
#define DIVX_PSYCHOVISUAL_MASKING      2

#define DIVX_PSNR_MODE_OFF                   0
#define DIVX_PSNR_MODE_LUMA                  1
#define DIVX_PSNR_MODE_LUMA_CHROMA           2
#define DIVX_PSNR_MODE_MODULATED             3

#endif // __DIVXVOUT_DEF_H__