﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace HD.TVAD.ApplicationCore.Entities.Security
{
    public enum PermissionTypeEnum
    {
        [Display(Name = "Permission for user use system")]
        UserPermission
    }
}
