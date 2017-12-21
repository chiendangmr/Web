using HD.TVAD.Entities.Context;
using HD.TVAD.Entities.Entities.Security;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HD.TVAD.Entities.Repositories.Security
{
    public class UserRepository<TUser> : Repository<TUser>, IUserRepository<TUser> where TUser : User
    {
        IGroupRepository<Group> _groupRepository;
        IRepository<Permission> _permissionRepository;
        IRepository<Group_User> _group_userRepository;
        IRepository<Group_Permission> _group_permissionRepository;
        IRepository<User_Permission> _user_permissionRepository;

        public UserRepository(TVAdContext context,
            IGroupRepository<Group> groupRepository,
            IRepository<Permission> permissionRepository,
            IRepository<Group_User> group_userRepository,
            IRepository<Group_Permission> group_permissionRepository,
            IRepository<User_Permission> user_permissionRepository)
            : base(context)
        {
            _groupRepository = groupRepository;
            _permissionRepository = permissionRepository;
            _group_userRepository = group_userRepository;
            _group_permissionRepository = group_permissionRepository;
            _user_permissionRepository = user_permissionRepository;
        }

        async Task<IList<Permission>> GetUserPermissions(TUser user, CancellationToken cancellationToken = default(CancellationToken))
        {
            var userId = user.Id;
            // Lấy các quyền hệ thống
            var permissions = _permissionRepository.Datas.Where(p => p.Type == PermissionTypeEnum.UserPermission.ToString())
                .Include(p => p.Parent)
                .ToList();
            // Các group của user
            var groups = _groupRepository.Datas.Where(g => g.Group_Users.Any(gu => gu.UserId == userId)).ToList();
            // Chỉ cần kiểm tra các group cha
            foreach (var group in groups.Where(g => g.Parent != null).ToList())
                groups.Remove(group);
            // Giữ lại các quyền hệ thống mà các group của user có
            foreach (var permission in permissions.ToList())
            {
                bool hasPermission = false;
                foreach (var group in groups)
                {
                    hasPermission = await _groupRepository.IsInPermission(group, permission.Id);
                    if (hasPermission)
                        break;
                }
                if (!hasPermission)
                    permissions.Remove(permission);
            }
            // Lấy các quyền của riêng user
            var usr = Datas.Where(u => u.Id == userId).Include(u => u.User_Permissions).First();
            if (usr.User_Permissions.Count > 0)
            {
                foreach (var userPermission in usr.User_Permissions)
                    if (!permissions.Any(p => p.Id == userPermission.PermissionId))
                        permissions.Add(_permissionRepository.Datas.First(p => p.Id == userPermission.PermissionId));
            }

            // Xóa các quyền không có cha đi
            foreach (var permission in permissions.Where(p => p.Parent != null && !permissions.Any(pp => pp == p.Parent)).ToList())
                permissions.Remove(permission);

            return permissions;
        }

        public async Task<IList<Guid>> GetUserPermissionIdsAsync(TUser user, CancellationToken cancellationToken = default(CancellationToken))
        {
            var permissions = await GetUserPermissions(user, cancellationToken);
            return permissions.Select(p => p.Id).ToList() as IList<Guid>;
        }

        public async Task<IList<string>> GetUserPermissionNamesAsync(TUser user, CancellationToken cancellationToken = default(CancellationToken))
        {
            var permissions = await GetUserPermissions(user, cancellationToken);
            return permissions.Select(p => p.Value).ToList() as IList<string>;
        }

        void GetGroupInheritable(Group group, List<Group> lstResult)
        {
            if (!lstResult.Any(g => g.Id == group.Id))
            {
                lstResult.Add(group);

                foreach (var children in _groupRepository.Datas.Where(g => g.Id == group.Id).Include(g => g.Childrens).First().Childrens.ToList())
                {
                    GetGroupInheritable(children, lstResult);
                }
            }
        }

        public Task<IEnumerable<Group>> GetGroupAndInheritableOfUser(Guid userId)
        {
            // Lấy các nhóm tài khoản quản lý
            var user = Datas.Where(u => u.Id == userId)
                .Include(u => u.Group_Users)
                .FirstOrDefault();

            if (user == null)
                return Task.FromResult(new List<Group>() as IEnumerable<Group>);

            List<Group> groups = new List<Group>();
            var groupIds = user.Group_Users.Select(g => g.GroupId).ToList();
            foreach (var group in _groupRepository.Datas.Where(g => groupIds.Contains(g.Id)).ToList())
                GetGroupInheritable(group, groups);

            return Task.FromResult(groups as IEnumerable<Group>);
        }
    }
}
