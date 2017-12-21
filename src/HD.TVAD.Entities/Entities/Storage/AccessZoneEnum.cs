using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace HD.TVAD.Entities.Entities.Storage
{
    public enum AccessZoneEnum
    {
        [Display(Name = "Access as local storage")]
        Local = 1,
        [Display(Name = "Access as local area network")]
        LAN = 2
    }
}
