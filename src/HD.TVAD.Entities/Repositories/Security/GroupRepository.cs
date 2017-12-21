using HD.TVAD.Entities.Context;
using HD.TVAD.Entities.Entities.Security;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HD.TVAD.Entities.Repositories.Security
{
    public class GroupRepository<TGroup> : Repository<TGroup>, IGroupRepository<TGroup> where TGroup : Group
    {
        public GroupRepository(TVAdContext context)
            : base(context)
        {

        }
        public Task<bool> IsInPermission(TGroup group, Guid permissionId)
        {
            return Task.Run(() =>
            {
                return Datas.Where(g => g.Id == group.Id).Include(g => g.Group_Permissions).First().Group_Permissions.Any(p => p.PermissionId == permissionId);
            });
        }

        void RemovePermissionAndInheritable(Permission permission, List<Permission> lstPermission)
        {
            if (lstPermission.Contains(permission))
            {
                foreach (var children in lstPermission.Where(g => g.ParentId == permission.Id).ToList())
                    RemovePermissionAndInheritable(children, lstPermission);

                lstPermission.Remove(permission);
            }
        }

        void CheckPermission(Permission permission, IList<Guid> permissionIds, List<Permission> lstPermission)
        {
            if (lstPermission.Contains(permission))
            {
                if (!permissionIds.Contains(permission.Id))
                {
                    // Xóa các quyền con cháu
                    RemovePermissionAndInheritable(permission, lstPermission);
                }
            }
        }

        public async Task<List<Permission>> GetAllPermission(Guid groupId, IList<Guid> permissionIds)
        {
            var pType = PermissionTypeEnum.UserPermission.ToString();
            var permissions = await _context.Security_Group_Permissions.Where(gp => gp.GroupId == groupId)
                .Include(gp => gp.Permission)
                .Select(gp => gp.Permission)
                .Where(p => p.Type == pType)
                .ToListAsync();

            // Xóa các quyền mà user hiện tại không có
            foreach (var permission in permissions.ToList())
                CheckPermission(permission, permissionIds, permissions);
            // Xóa các quyền không có cha
            foreach (var permission in permissions.Where(p => p.ParentId != null && !permissions.Any(pp => pp.Id == p.ParentId)).ToList())
                RemovePermissionAndInheritable(permission, permissions);

            return permissions;
        }
    }
}
