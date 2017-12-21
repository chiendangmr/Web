using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HDAdvertising.Datas.Permission
{
    public enum ApplicationPermissions
    {
        [DisplayText("Quản trị hệ thống")]
        Manager,
        [DisplayText("Quản lý nhóm tài khoản")]
        Manager_UserGroup,
        [DisplayText("Sửa nhóm tài khoản")]
        Manager_UserGroup_Edit,
        [DisplayText("Phân quyền nhóm tài khoản")]
        Manager_UserGroup_Permission,
        [DisplayText("Quản lý tài khoản")]
        Manager_User,
        [DisplayText("Sửa thông tin tài khoản")]
        Manager_User_Edit,
        [DisplayText("Phân nhóm tài khoản")]
        Manager_User_UserGroup
    }
}
