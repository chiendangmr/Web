using HDAdvertising.Datas.Security;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace HDAdvertising.Services.Account
{
    public partial class UserStore<TUser>:
        IUserStore<TUser>,
        IUserPasswordStore<TUser>,
        IUserRoleStore<TUser>
        where TUser : Datas.Security.User
    {
        private bool _disposed;

        readonly IService<Group> _GroupService;
        readonly IService<User> _UserService;
        readonly IService<Group_User> _Group_UserService;
        readonly IService<Permission> _PermissionService;
        readonly IService<Group_Permission> _Group_PermissionService;
        //readonly IService<User_Permission> _User_PermissionService;
        //readonly IService<Permission_Request> _Permission_RequestService;

        public UserStore(IService<Group> groupService,
            IService<User> userService,
            IService<Group_User> group_UserService,
            IService<Permission> permissionService,
            IService<Group_Permission> group_PermissionService)
            //IService<User_Permission> user_PermissionService)
            //IService<Permission_Request> permission_RequestService)
        {
            _GroupService = groupService;
            _UserService = userService;
            _Group_UserService = group_UserService;
            _PermissionService = permissionService;
            _Group_PermissionService = group_PermissionService;
            //_User_PermissionService = user_PermissionService;
            //_Permission_RequestService = permission_RequestService;
        }

        #region IUserStore
        //
        // Summary:
        //     Creates the specified user in the user store.
        //
        // Parameters:
        //   user:
        //     The user to create.
        //
        //   cancellationToken:
        //     The System.Threading.CancellationToken used to propagate notifications that the
        //     operation should be canceled.
        //
        // Returns:
        //     The System.Threading.Tasks.Task that represents the asynchronous operation, containing
        //     the Microsoft.AspNetCore.Identity.IdentityResult of the creation operation.
        public Task<IdentityResult> CreateAsync(TUser user, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
        //
        // Summary:
        //     Deletes the specified user from the user store.
        //
        // Parameters:
        //   user:
        //     The user to delete.
        //
        //   cancellationToken:
        //     The System.Threading.CancellationToken used to propagate notifications that the
        //     operation should be canceled.
        //
        // Returns:
        //     The System.Threading.Tasks.Task that represents the asynchronous operation, containing
        //     the Microsoft.AspNetCore.Identity.IdentityResult of the update operation.
        public Task<IdentityResult> DeleteAsync(TUser user, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
        //
        // Summary:
        //     Finds and returns a user, if any, who has the specified userId.
        //
        // Parameters:
        //   userId:
        //     The user ID to search for.
        //
        //   cancellationToken:
        //     The System.Threading.CancellationToken used to propagate notifications that the
        //     operation should be canceled.
        //
        // Returns:
        //     The System.Threading.Tasks.Task that represents the asynchronous operation, containing
        //     the user matching the specified userId if it exists.
        public Task<TUser> FindByIdAsync(string userId, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            ThrowIfDisposed();
            var id = Guid.Parse(userId);
            return (_UserService.Datas as IQueryable<TUser>).FirstOrDefaultAsync(u => u.Id.Equals(id), cancellationToken);
        }

        //
        // Summary:
        //     Finds and returns a user, if any, who has the specified normalized user name.
        //
        // Parameters:
        //   normalizedUserName:
        //     The normalized user name to search for.
        //
        //   cancellationToken:
        //     The System.Threading.CancellationToken used to propagate notifications that the
        //     operation should be canceled.
        //
        // Returns:
        //     The System.Threading.Tasks.Task that represents the asynchronous operation, containing
        //     the user matching the specified normalizedUserName if it exists.
        public Task<TUser> FindByNameAsync(string normalizedUserName, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            ThrowIfDisposed();
            return (_UserService.Datas as IQueryable<TUser>).FirstOrDefaultAsync(u => u.Name == normalizedUserName, cancellationToken);
        }
        
        //
        // Summary:
        //     Gets the normalized user name for the specified user.
        //
        // Parameters:
        //   user:
        //     The user whose normalized name should be retrieved.
        //
        //   cancellationToken:
        //     The System.Threading.CancellationToken used to propagate notifications that the
        //     operation should be canceled.
        //
        // Returns:
        //     The System.Threading.Tasks.Task that represents the asynchronous operation, containing
        //     the normalized user name for the specified user.
        public Task<string> GetNormalizedUserNameAsync(TUser user, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
        //
        // Summary:
        //     Gets the user identifier for the specified user.
        //
        // Parameters:
        //   user:
        //     The user whose identifier should be retrieved.
        //
        //   cancellationToken:
        //     The System.Threading.CancellationToken used to propagate notifications that the
        //     operation should be canceled.
        //
        // Returns:
        //     The System.Threading.Tasks.Task that represents the asynchronous operation, containing
        //     the identifier for the specified user.
        public Task<string> GetUserIdAsync(TUser user, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            ThrowIfDisposed();
            if (user == null)
            {
                throw new ArgumentNullException(nameof(user));
            }
            return Task.FromResult(user.Id.ToString());
        }
        //
        // Summary:
        //     Gets the user name for the specified user.
        //
        // Parameters:
        //   user:
        //     The user whose name should be retrieved.
        //
        //   cancellationToken:
        //     The System.Threading.CancellationToken used to propagate notifications that the
        //     operation should be canceled.
        //
        // Returns:
        //     The System.Threading.Tasks.Task that represents the asynchronous operation, containing
        //     the name for the specified user.
        public Task<string> GetUserNameAsync(TUser user, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            ThrowIfDisposed();
            if (user == null)
            {
                throw new ArgumentNullException(nameof(user));
            }
            return Task.FromResult(user.Name);
        }
        //
        // Summary:
        //     Sets the given normalized name for the specified user.
        //
        // Parameters:
        //   user:
        //     The user whose name should be set.
        //
        //   normalizedName:
        //     The normalized name to set.
        //
        //   cancellationToken:
        //     The System.Threading.CancellationToken used to propagate notifications that the
        //     operation should be canceled.
        //
        // Returns:
        //     The System.Threading.Tasks.Task that represents the asynchronous operation.
        public Task SetNormalizedUserNameAsync(TUser user, string normalizedName, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
        //
        // Summary:
        //     Sets the given userName for the specified user.
        //
        // Parameters:
        //   user:
        //     The user whose name should be set.
        //
        //   userName:
        //     The user name to set.
        //
        //   cancellationToken:
        //     The System.Threading.CancellationToken used to propagate notifications that the
        //     operation should be canceled.
        //
        // Returns:
        //     The System.Threading.Tasks.Task that represents the asynchronous operation.
        public Task SetUserNameAsync(TUser user, string userName, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
        //
        // Summary:
        //     Updates the specified user in the user store.
        //
        // Parameters:
        //   user:
        //     The user to update.
        //
        //   cancellationToken:
        //     The System.Threading.CancellationToken used to propagate notifications that the
        //     operation should be canceled.
        //
        // Returns:
        //     The System.Threading.Tasks.Task that represents the asynchronous operation, containing
        //     the Microsoft.AspNetCore.Identity.IdentityResult of the update operation.
        public Task<IdentityResult> UpdateAsync(TUser user, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region IUserPasswordStore
        //
        // Summary:
        //     Gets the password hash for the specified user.
        //
        // Parameters:
        //   user:
        //     The user whose password hash to retrieve.
        //
        //   cancellationToken:
        //     The System.Threading.CancellationToken used to propagate notifications that the
        //     operation should be canceled.
        //
        // Returns:
        //     The System.Threading.Tasks.Task that represents the asynchronous operation, returning
        //     the password hash for the specified user.
        public Task<string> GetPasswordHashAsync(TUser user, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            ThrowIfDisposed();
            if (user == null)
            {
                throw new ArgumentNullException(nameof(user));
            }
            return Task.FromResult(user.PasswordHash);
        }
        //
        // Summary:
        //     Gets a flag indicating whether the specified user has a password.
        //
        // Parameters:
        //   user:
        //     The user to return a flag for, indicating whether they have a password or not.
        //
        //   cancellationToken:
        //     The System.Threading.CancellationToken used to propagate notifications that the
        //     operation should be canceled.
        //
        // Returns:
        //     The System.Threading.Tasks.Task that represents the asynchronous operation, returning
        //     true if the specified user has a password otherwise false.
        public Task<bool> HasPasswordAsync(TUser user, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            return Task.FromResult(user.PasswordHash != null);
        }
        //
        // Summary:
        //     Sets the password hash for the specified user.
        //
        // Parameters:
        //   user:
        //     The user whose password hash to set.
        //
        //   passwordHash:
        //     The password hash to set.
        //
        //   cancellationToken:
        //     The System.Threading.CancellationToken used to propagate notifications that the
        //     operation should be canceled.
        //
        // Returns:
        //     The System.Threading.Tasks.Task that represents the asynchronous operation.
        public Task SetPasswordHashAsync(TUser user, string passwordHash, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region IUserRoleStore
        //
        // Summary:
        //     Add a the specified user to the named role.
        //
        // Parameters:
        //   user:
        //     The user to add to the named role.
        //
        //   roleName:
        //     The name of the role to add the user to.
        //
        //   cancellationToken:
        //     The System.Threading.CancellationToken used to propagate notifications that the
        //     operation should be canceled.
        //
        // Returns:
        //     The System.Threading.Tasks.Task that represents the asynchronous operation.
        public Task AddToRoleAsync(TUser user, string roleName, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public bool IsGroupInRole(Group group, Permission permission)
        {
            var groupId = group.Id;
            var permissionId = permission.Id;

            var hasPermission = _Group_PermissionService.Datas
                .FirstOrDefault(gp => gp.GroupId == groupId && gp.PermissionId == permissionId) != null;

            return hasPermission;
        }

        //
        // Summary:
        //     Gets a list of role names the specified user belongs to.
        //
        // Parameters:
        //   user:
        //     The user whose role names to retrieve.
        //
        //   cancellationToken:
        //     The System.Threading.CancellationToken used to propagate notifications that the
        //     operation should be canceled.
        //
        // Returns:
        //     The System.Threading.Tasks.Task that represents the asynchronous operation, containing
        //     a list of role names.
        public async Task<IList<string>> GetRolesAsync(TUser user, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            ThrowIfDisposed();
            if (user == null)
            {
                throw new ArgumentNullException(nameof(user));
            }
            var userId = user.Id;

            // Chỉ lấy các quyền hệ thống
            var permissions = await _PermissionService.Datas.Where(p => p.Type == PermissionType.Manager.ToString()).ToListAsync();
            var groups = await _GroupService.Datas
                .Join(_Group_UserService.Datas,
                    g => g.Id,
                    gu => gu.GroupId,
                    (g, gu) => new { Group = g, User = gu })
                .Where(gu => gu.User.UserId == userId)
                .Select(gu => gu.Group)
                .ToListAsync();

            // Bỏ các nhóm trong đi
            foreach (var group in groups.Where(g => groups.Any(gg => gg.Id == g.ParentId)).ToList())
                groups.Remove(group);

            permissions = permissions.Where(r =>
            {
                foreach (var group in groups)
                {
                    if (IsGroupInRole(group, r))
                        return true;
                }
                return false;
            }).ToList();

            //// Lấy các quyền set riêng cho user
            //permissions.AddRange(_User_PermissionService.Datas
            //    .Where(up => up.UserId == userId)
            //    .Join(_PermissionService.Datas.Where(p => p.Type == PermissionType.System.ToString()),
            //        up => up.PermissionId,
            //        p => p.Id,
            //        (up, p) => new { Permission = p, UserPermission = up })
            //    .Select(up => up.Permission).ToList()
            //    .Where(p => !permissions.Any(pp => pp.Id == p.Id))
            //    .ToList());

            //// Lấy các permission yêu cầu
            //var permissionIds = permissions.Select(p => p.Id).ToList();
            //var permissionRequests = _Permission_RequestService.Datas.Where(p => permissionIds.Contains(p.ChildrenId)).ToList();
            //foreach (var permission in permissions.Where(p => !permissions.Any(pp => !permissionRequests.Any(pr=>pr.ChildrenId == pp.Id) || pp.Id == permissionRequests.First(pr => pr.ChildrenId == p.Id).ParentId)).ToList())
            //    permissions.Remove(permission);

            // Bỏ các quyền mà không có quyền cha
            foreach (var permission in permissions.Where(p => p.ParentId != null && !permissions.Any(pp => pp.Id == p.ParentId)).ToList())
                permissions.Remove(permission);

            return permissions.Select(r => r.Value)
                .ToList();
        }
        //
        // Summary:
        //     Returns a list of Users who are members of the named role.
        //
        // Parameters:
        //   roleName:
        //     The name of the role whose membership should be returned.
        //
        //   cancellationToken:
        //     The System.Threading.CancellationToken used to propagate notifications that the
        //     operation should be canceled.
        //
        // Returns:
        //     The System.Threading.Tasks.Task that represents the asynchronous operation, containing
        //     a list of users who are in the named role.
        public Task<IList<TUser>> GetUsersInRoleAsync(string roleName, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
        //
        // Summary:
        //     Returns a flag indicating whether the specified user is a member of the give
        //     named role.
        //
        // Parameters:
        //   user:
        //     The user whose role membership should be checked.
        //
        //   roleName:
        //     The name of the role to be checked.
        //
        //   cancellationToken:
        //     The System.Threading.CancellationToken used to propagate notifications that the
        //     operation should be canceled.
        //
        // Returns:
        //     The System.Threading.Tasks.Task that represents the asynchronous operation, containing
        //     a flag indicating whether the specified user is a member of the named role.
        public Task<bool> IsInRoleAsync(TUser user, string roleName, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
        //
        // Summary:
        //     Add a the specified user from the named role.
        //
        // Parameters:
        //   user:
        //     The user to remove the named role from.
        //
        //   roleName:
        //     The name of the role to remove.
        //
        //   cancellationToken:
        //     The System.Threading.CancellationToken used to propagate notifications that the
        //     operation should be canceled.
        //
        // Returns:
        //     The System.Threading.Tasks.Task that represents the asynchronous operation.
        public Task RemoveFromRoleAsync(TUser user, string roleName, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
        #endregion

        //#region IUserLockoutStore
        ////
        //// Summary:
        ////     Retrieves the current failed access count for the specified user..
        ////
        //// Parameters:
        ////   user:
        ////     The user whose failed access count should be retrieved.
        ////
        ////   cancellationToken:
        ////     The System.Threading.CancellationToken used to propagate notifications that the
        ////     operation should be canceled.
        ////
        //// Returns:
        ////     The System.Threading.Tasks.Task that represents the asynchronous operation, containing
        ////     the failed access count.
        //public Task<int> GetAccessFailedCountAsync(TUser user, CancellationToken cancellationToken)
        //{
        //    cancellationToken.ThrowIfCancellationRequested();
        //    ThrowIfDisposed();
        //    if (user == null)
        //    {
        //        throw new ArgumentNullException(nameof(user));
        //    }
        //    return Task.FromResult(user.AccessFailedCount);
        //}
        ////
        //// Summary:
        ////     Retrieves a flag indicating whether user lockout can enabled for the specified
        ////     user.
        ////
        //// Parameters:
        ////   user:
        ////     The user whose ability to be locked out should be returned.
        ////
        ////   cancellationToken:
        ////     The System.Threading.CancellationToken used to propagate notifications that the
        ////     operation should be canceled.
        ////
        //// Returns:
        ////     The System.Threading.Tasks.Task that represents the asynchronous operation, true
        ////     if a user can be locked out, otherwise false.
        //public Task<bool> GetLockoutEnabledAsync(TUser user, CancellationToken cancellationToken)
        //{
        //    cancellationToken.ThrowIfCancellationRequested();
        //    ThrowIfDisposed();
        //    if (user == null)
        //    {
        //        throw new ArgumentNullException(nameof(user));
        //    }
        //    return Task.FromResult(user.LockoutEnabled);
        //}
        ////
        //// Summary:
        ////     Gets the last System.DateTimeOffset a user's last lockout expired, if any. Any
        ////     time in the past should be indicates a user is not locked out.
        ////
        //// Parameters:
        ////   user:
        ////     The user whose lockout date should be retrieved.
        ////
        ////   cancellationToken:
        ////     The System.Threading.CancellationToken used to propagate notifications that the
        ////     operation should be canceled.
        ////
        //// Returns:
        ////     A System.Threading.Tasks.Task`1 that represents the result of the asynchronous
        ////     query, a System.DateTimeOffset containing the last time a user's lockout expired,
        ////     if any.
        //public Task<DateTimeOffset?> GetLockoutEndDateAsync(TUser user, CancellationToken cancellationToken)
        //{
        //    cancellationToken.ThrowIfCancellationRequested();
        //    ThrowIfDisposed();
        //    if (user == null)
        //    {
        //        throw new ArgumentNullException(nameof(user));
        //    }
        //    return Task.FromResult(user.LockoutEnd);
        //}
        ////
        //// Summary:
        ////     Records that a failed access has occurred, incrementing the failed access count.
        ////
        //// Parameters:
        ////   user:
        ////     The user whose cancellation count should be incremented.
        ////
        ////   cancellationToken:
        ////     The System.Threading.CancellationToken used to propagate notifications that the
        ////     operation should be canceled.
        ////
        //// Returns:
        ////     The System.Threading.Tasks.Task that represents the asynchronous operation, containing
        ////     the incremented failed access count.
        //public Task<int> IncrementAccessFailedCountAsync(TUser user, CancellationToken cancellationToken)
        //{
        //    cancellationToken.ThrowIfCancellationRequested();
        //    ThrowIfDisposed();
        //    if (user == null)
        //    {
        //        throw new ArgumentNullException(nameof(user));
        //    }
        //    user.AccessFailedCount++;

        //    return Task.FromResult(user.AccessFailedCount);
        //}
        ////
        //// Summary:
        ////     Resets a user's failed access count.
        ////
        //// Parameters:
        ////   user:
        ////     The user whose failed access count should be reset.
        ////
        ////   cancellationToken:
        ////     The System.Threading.CancellationToken used to propagate notifications that the
        ////     operation should be canceled.
        ////
        //// Returns:
        ////     The System.Threading.Tasks.Task that represents the asynchronous operation.
        ////
        //// Remarks:
        ////     This is typically called after the account is successfully accessed.
        //public Task ResetAccessFailedCountAsync(TUser user, CancellationToken cancellationToken)
        //{
        //    cancellationToken.ThrowIfCancellationRequested();
        //    ThrowIfDisposed();
        //    if (user == null)
        //    {
        //        throw new ArgumentNullException(nameof(user));
        //    }
        //    user.AccessFailedCount = 0;
        //    return Task.FromResult(0);
        //}
        ////
        //// Summary:
        ////     Set the flag indicating if the specified user can be locked out..
        ////
        //// Parameters:
        ////   user:
        ////     The user whose ability to be locked out should be set.
        ////
        ////   enabled:
        ////     A flag indicating if lock out can be enabled for the specified user.
        ////
        ////   cancellationToken:
        ////     The System.Threading.CancellationToken used to propagate notifications that the
        ////     operation should be canceled.
        ////
        //// Returns:
        ////     The System.Threading.Tasks.Task that represents the asynchronous operation.
        //public Task SetLockoutEnabledAsync(TUser user, bool enabled, CancellationToken cancellationToken)
        //{
        //    throw new NotImplementedException();
        //}
        ////
        //// Summary:
        ////     Locks out a user until the specified end date has passed. Setting a end date
        ////     in the past immediately unlocks a user.
        ////
        //// Parameters:
        ////   user:
        ////     The user whose lockout date should be set.
        ////
        ////   lockoutEnd:
        ////     The System.DateTimeOffset after which the user's lockout should end.
        ////
        ////   cancellationToken:
        ////     The System.Threading.CancellationToken used to propagate notifications that the
        ////     operation should be canceled.
        ////
        //// Returns:
        ////     The System.Threading.Tasks.Task that represents the asynchronous operation.
        //public Task SetLockoutEndDateAsync(TUser user, DateTimeOffset? lockoutEnd, CancellationToken cancellationToken)
        //{
        //    throw new NotImplementedException();
        //}
        //#endregion

        protected void ThrowIfDisposed()
        {
            if (_disposed)
            {
                throw new ObjectDisposedException(GetType().Name);
            }
        }

        public void Dispose()
        {
            _disposed = true;
        }
    }
}
