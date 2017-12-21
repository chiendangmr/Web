/** 
 @file  render_fileindex_mc.h
 @brief  Property GUIDs for MainConcept Sink Filter parameters.
 
 @verbatim
 File: render_fileindex_mc.h

 Desc: Property GUIDs for MainConcept Sink Filter parameters.
 
 Copyright (c) 2015 MainConcept GmbH or its affiliates.  All rights reserved.

 MainConcept and its logos are registered trademarks of MainConcept GmbH or its affiliates.  
 This software is protected by copyright law and international treaties.  Unauthorized 
 reproduction or distribution of any portion is prohibited by law.
 @endverbatim
 **/
 
#if !defined(__PROPID_SINKFILTER_HEADER__)
#define __PROPID_SINKFILTER_HEADER__

/**
* namespace ESF
* @brief Sink Filter namespace
**/
namespace ESF 
{
	///@brief Index file mode
	typedef enum IndexFileMode 
	{
		IndexFileMode_None		= 0,		///< Don't create
		IndexFileMode_Write		= 1,		///< Create
		IndexFileMode_NotWrite	= 2,		///< GOP-accurate trimming
	} IndexFileMode_t, *pIndexFileMode_t;

	///@brief Output write mode
	typedef enum WriteMode 
	{
		WriteMode_SinkToNull	= 0,		///< Sink to Null
		WriteMode_Overwrite		= 1,		///< Overwrite File
		WriteMode_Append		= 2,		///< Append File
		WriteMode_NoBuffering	= 3,		///< Overwrite (no buffering)
	} WriteMode_t, *pWriteMode_t;

	///@brief Crop mode
	typedef enum CropMode 
	{
		CropMode_None	= 0,		///< Don't Crop
		CropMode_BySize	= 1,		///< Crop by Size(KB)
		CropMode_ByTime	= 2			///< Crop by Time(msec)
	} CropMode_t, *pCropMode_t;

	///@brief Stream type
	typedef enum StreamType 
	{
		StreamType_VES	= 0,		///< MPEG-2 VES
		StreamType_PS	= 1,		///< MPEG-2 Program Stream
		StreamType_TS	= 2,		///< MPEG-2 Transport Stream
		StreamType_H264	= 3 		///< H264 VES
	} StreamType_t, *pStreamType_t; 
};

//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
//	GUID								Type		Available range			  Default Val		Note
// ESF_FileName							VT_BSTR									[0]				Name of the output file
// ESF_IndexExtension					VT_BSTR									["index"]		Extension of the index file
// ESF_IndexFileMode					VT_UINT		see IndexFileMode_t			[0]				Enable/disable writing of the index file (only for MPEG-2 VES and Program Stream) (see IndexFileMode_t)
// ESF_CropMode							VT_UINT		see CropMode_t				[0]				Switching between crop modes (none, by time or by size)
// ESF_CropSize							VT_UI8		[100, limit of ULONGLONG]	[0]				Crop size
// ESF_EnableOutput						VT_UINT		see WriteMode_t				[1]				Output mode (Sink To Null, Overwrite file, Append File)
// ESF_StreamType						VT_UINT		see StreamType_t			[0]				Type of the input file (available only in indexing mode)
// ESF_StreamId							VT_UINT		[0, 255]					[0]				Stream ID if Program Stream type selected, otherwise ignored (available only in indexing mode)
// ESF_FilesToWrite						VT_UINT		[0, limit of UINT]			[0]				Maximum count of output files (0 by default, no limit)
// ESF_StartTime						VT_I8		[0, limit of LONGLONG]		[0]				Start time in the index file (available only in indexing mode)
// ESF_CurrentFileFrameCount			VT_UI8		[0, limit of ULONGLONG]		Read-only		Number of processed frames in the current file (available only in indexing mode)
// ESF_TotalFrameCount					VT_UI8		[0, limit of ULONGLONG]		Read-only		Total number of processed frames (available only in indexing mode)
// ESF_BytesPerFile						VT_UI8		[0, limit of ULONGLONG]		Read-only		Number of bytes saved in the current file 
// ESF_ReceivedBytes					VT_UI8		[0, limit of ULONGLONG]		Read-only		Total number of received bytes 
// ESF_CurrentFileTime					VT_I8		[0, limit of LONGLONG]		Read-only		Time of the last saved frame
// ESF_TotalTime						VT_I8		[0, limit of LONGLONG]		Read-only		Overall time of the dumped video stream 

//////////////////////////////////////////////////////////////////////////
//	Parameters GUIDs
//////////////////////////////////////////////////////////////////////////

///@brief Sets the output file name.
// {4CA841F6-9677-4d23-B0BC-D033BB96D8A4}
static const GUID ESF_FileName =
{0x4ca841f6, 0x9677, 0x4d23, { 0xb0, 0xbc, 0xd0, 0x33, 0xbb, 0x96, 0xd8, 0xa4 } };

///@brief The index file extension.
// {AA05A157-2850-4b89-8008-183A2CFE1D67}
static const GUID ESF_IndexExtension = 
{0xaa05a157, 0x2850, 0x4b89, { 0x80, 0x8, 0x18, 0x3a, 0x2c, 0xfe, 0x1d, 0x67 } };

///@brief Enables/disables writing the index file (only for H.264/AVC, MPEG-2 VES, TS and PS).
// {A47BFA66-6F8D-4b22-8017-CA778272F625}
static const GUID ESF_IndexFileMode = 
{0xa47bfa66, 0x6f8d, 0x4b22, { 0x80, 0x17, 0xca, 0x77, 0x82, 0x72, 0xf6, 0x25 } };

///@brief Switches between cutting modes (none, by time or by size).
// {4CA841F3-9677-4d23-B0BC-D033BB96D8A4}
static const GUID ESF_CropMode =
{0x4ca841f3, 0x9677, 0x4d23, { 0xb0, 0xbc, 0xd0, 0x33, 0xbb, 0x96, 0xd8, 0xa4 } };

/**
 * @brief Specifies the cutting size: the duration of the output files (Crop by time) 
 * or the size of the output files (Crop by size).
 */
// {4CA841F5-9677-4d23-B0BC-D033BB96D8A4}
static const GUID ESF_CropSize =
{0x4ca841f5, 0x9677, 0x4d23, { 0xb0, 0xbc, 0xd0, 0x33, 0xbb, 0x96, 0xd8, 0xa4 } };

///@brief Specifies the output mode (Sink To Null, Overwrite file, Append File).
// {4CA841F8-9677-4d23-B0BC-D033BB96D8A4}
static const GUID ESF_EnableOutput =
{0x4ca841f8, 0x9677, 0x4d23, { 0xb0, 0xbc, 0xd0, 0x33, 0xbb, 0x96, 0xd8, 0xa4 } };

///@brief Specifies the stream type (available only in indexing mode).
// {3EEB22F8-3D86-47d3-850B-B3E0B80C7D54}
static const GUID ESF_StreamType = 
{0x3eeb22f8, 0x3d86, 0x47d3, { 0x85, 0xb, 0xb3, 0xe0, 0xb8, 0xc, 0x7d, 0x54 } };

///@brief Specifies the VES ID (only when indexing H.264/AVC or MPEG-2 PS).
// {6A88B2EB-C306-4110-A482-D4AFE22228AA}
static const GUID ESF_StreamId = 
{0x6a88b2eb, 0xc306, 0x4110, { 0xa4, 0x82, 0xd4, 0xaf, 0xe2, 0x22, 0x28, 0xaa } };

///@brief Specifies the program stream ID (only when indexing H.264/AVC or MPEG-2 TS).
// {B1A3A917-5662-44d6-989D-02AD891B8430}
static const GUID ESF_StreamPID = 
{ 0xb1a3a917, 0x5662, 0x44d6, { 0x98, 0x9d, 0x2, 0xad, 0x89, 0x1b, 0x84, 0x30 } };

///@brief Specifies maximum number of output files (zero value - no limit).
// {E6E87F33-1504-4ed5-86E4-3D1A80984171}
static const GUID ESF_FilesToWrite = 
{0xe6e87f33, 0x1504, 0x4ed5, { 0x86, 0xe4, 0x3d, 0x1a, 0x80, 0x98, 0x41, 0x71 } };

///@brief Specifies Start time in the index file (available only in indexing mode).
// {C036EE4E-7F1E-4e3c-9904-A20E6BCFA4BB}
static const GUID ESF_StartTime = 
{0xc036ee4e, 0x7f1e, 0x4e3c, { 0x99, 0x4, 0xa2, 0xe, 0x6b, 0xcf, 0xa4, 0xbb } };

///@brief Indicates number of processed frames in the current file (available only in indexing mode).
// {3601951D-D32A-40fa-AB01-B171679AF810}
static const GUID ESF_CurrentFileFrameCount = 
{0x3601951d, 0xd32a, 0x40fa, { 0xab, 0x1, 0xb1, 0x71, 0x67, 0x9a, 0xf8, 0x10 } };

///@brief Indicates total number of processed frames (available only in indexing mode).
// {8847F6DC-DF05-434a-B64F-545E711F573C}
static const GUID ESF_TotalFrameCount = 
{0x8847f6dc, 0xdf05, 0x434a, { 0xb6, 0x4f, 0x54, 0x5e, 0x71, 0x1f, 0x57, 0x3c } };

///@brief Indicates number of bytes saved in the current file.
// {4CA841FB-9677-4d23-B0BC-D033BB96D8A4}
static const GUID ESF_BytesPerFile =
{0x4ca841fB, 0x9677, 0x4d23, { 0xb0, 0xbc, 0xd0, 0x33, 0xbb, 0x96, 0xd8, 0xa4 } };

///@brief Indicates total number of received bytes.
// {4CA841FC-9677-4d23-B0BC-D033BB96D8A4}
static const GUID ESF_ReceivedBytes =
{0x4ca841fC, 0x9677, 0x4d23, { 0xb0, 0xbc, 0xd0, 0x33, 0xbb, 0x96, 0xd8, 0xa4 } };

///@brief Indicates time of the last saved frame.
// {4D5D7108-3390-4e3f-ADAE-2EBED8294691}
static const GUID ESF_CurrentFileTime = 
{0x4d5d7108, 0x3390, 0x4e3f, { 0xad, 0xae, 0x2e, 0xbe, 0xd8, 0x29, 0x46, 0x91 } };

///@brief Indicates total dumped stream duration.
// {4E74F2DF-3D8B-41b9-99FB-52F243314C0C}
static const GUID ESF_TotalTime = 
{0x4e74f2df, 0x3d8b, 0x41b9, { 0x99, 0xfb, 0x52, 0xf2, 0x43, 0x31, 0x4c, 0xc } };



#endif // __PROPID_SINKFILTER_HEADER__