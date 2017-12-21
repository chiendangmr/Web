using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HD.Station
{
    public enum Permission
    {
        Ignore,
        Access,
        Update,
        Create,
        Delete,
        //DownloadAsset,
        //UploadAsset,
        //DeleteAsset, 
        Archive,
        Restore
    }
}