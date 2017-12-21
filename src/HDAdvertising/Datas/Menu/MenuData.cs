using HDAdvertising.Datas.Permission;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HDAdvertising.Datas.Menu
{
    public static class MenuData
    {
        public static List<MenuExample> Menus = new List<MenuExample>()
        {
            new MenuExample()
            {
                Name = "Quản trị",
                PermissionNames = ApplicationPermissions.Manager.ToString(),
                Items = new List<MenuExample>()
                {
                    new MenuExample()
                    {
                        Name = "Quản lý nhóm tài khoản",
                        Icon = "group",
                        PermissionNames = ApplicationPermissions.Manager_UserGroup.ToString(),
                        Url="/Manager/UserGroup"
                    },
                    new MenuExample()
                    {
                        Name = "Quản lý tài khoản",
                        Icon = "user",
                        PermissionNames = ApplicationPermissions.Manager_User.ToString(),
                        Url="/Manager/User"
                    }
                }
            }
        };
    }
}
