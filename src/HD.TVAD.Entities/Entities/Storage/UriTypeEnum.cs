using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace HD.TVAD.Entities.Entities.Storage
{
    public enum UriTypeEnum
    {
        [Display(Name = "Virtual directory")]
        VirtualDirectory = 1,
        [Display(Name = "Local")]
        LocalDisk = 2,
        [Display(Name = "Smb")]
        SmbPath = 3,
        [Display(Name = "Ftp")]
        FtpUri = 4
    }
}
