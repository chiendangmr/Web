#if !defined(__DASHINFO_H__)
#define __DASHINFO_H__

#include <auxinfo.h>

// new auxinfo messages
#define CONTAINER_INFO 0x000C0021L
#define SEGMENT_INFO   0x000C0022L
#define SEGMENT_END    0x000C0023L

struct track_info {
    uint32_t track_id;
    uint32_t width;
    uint32_t height;
    uint8_t lang[128];
    int32_t type;
    uint32_t bitrate;
    double framerate;
    uint32_t fourcc;

    uint8_t *mime_type;
    uint32_t mime_type_len;

    uint8_t *codec_private;
    uint32_t codec_private_len;

    uint32_t reserved[512];
};

struct container_info {
    uint32_t min_buffer_time;
    uint32_t track_count;
    struct track_info *tracks;
    uint8_t reserved[504];
};

struct segment_info {
    uint32_t track_id;
    uint64_t offset;
    uint32_t index_size;
    uint32_t media_size;
    uint64_t duration;
    int64_t start_time;
    uint32_t start_with_sap;
    uint8_t reserved[128];
};

struct segment_end_info
{
    uint8_t reserved[128];
};

#endif // #if !defined(__DASHINFO_H__)
