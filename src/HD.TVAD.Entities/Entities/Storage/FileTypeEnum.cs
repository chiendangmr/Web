using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace HD.TVAD.Entities.Entities.Storage
{
    public enum FileTypeEnum
    {
        [Display(Name = "Broadcast file")]
        TVC = 1,

        [Display(Name = "Popup file")]
        Popup = 2,

        [Display(Name = "Document file")]
        Document = 3,

        [Display(Name = "Raw text")]
        Text = 4,

        [Display(Name = "Lowres file")]
        Lowres = 5
    }
}
