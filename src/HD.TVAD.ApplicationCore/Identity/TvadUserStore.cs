using HD.TVAD.ApplicationCore.Entities.Security;
using HD.TVAD.ApplicationCore.Repositories.Security;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Internal;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace HD.TVAD.Infrastructure.Identity
{
    public class TvadUserStore<TUser>:
        IUserStore<TUser>,
        IUserPasswordStore<TUser>,
        IUserRoleStore<TUser>
        where TUser : User
    {
        private bool _disposed;

        IUserRepository _userRepository;
        IGroupRepository _groupRepository;
        IPermissionRepository _permissionRepository;
        IGroup_UserRepository _group_userRepository;
        IGroup_PermissionRepository _group_permissionRepository;
        IUser_PermissionRepository _user_permissionRepository;

        public TvadUserStore(IUserRepository userRepository,
            IGroupRepository groupRepository,
            IPermissionRepository permissionRepository,
            IGroup_UserRepository group_userRepository,
            IGroup_PermissionRepository group_permissionRepository,
            IUser_PermissionRepository user_permissionRepository)
        {
            _userRepository = userRepository;
            _groupRepository = groupRepository;
            _permissionRepository = permissionRepository;
            _group_userRepository = group_userRepository;
            _group_permissionRepository = group_permissionRepository;
            _user_permissionRepository = user_permissionRepository;
        }

        #region IUserStore
        IQueryable<TUser> UserTable => _userRepository.List() as IQueryable<TUser>;

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
        public async Task<IdentityResult> CreateAsync(TUser user, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            ThrowIfDisposed();
            await _userRepository.Create(user);

            return IdentityResult.Success;
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
            return UserTable.FirstOrDefaultAsync(u => u.Id.Equals(id), cancellationToken);
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
            return UserTable.FirstOrDefaultAsync(u => u.UserName == normalizedUserName, cancellationToken);
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
            return Task.FromResult(user.UserName);
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
            cancellationToken.ThrowIfCancellationRequested();
            ThrowIfDisposed();
            if (user == null)
            {
                throw new ArgumentNullException(nameof(user));
            }
            return TaskCache.CompletedTask;
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
            cancellationToken.ThrowIfCancellationRequested();
            ThrowIfDisposed();
            if (user == null)
            {
                throw new ArgumentNullException(nameof(user));
            }
            return Task.Run(() => user.PasswordHash = passwordHash);
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
            // Lấy các quyền hệ thống
            // Lấy các quyền hệ thống
            var permissions = _permissionRepository.List().Where(p => p.Type ==  PermissionTypeEnum.UserPermission.ToString())
                .Include(p => p.Parent)
                .ToList();
            // Các group của user
            var groups = _groupRepository.List().Where(g => g.GroupUsers.Any(gu => gu.UserId == userId)).ToList();
            // Chỉ cần kiểm tra các group cha
            foreach (var group in groups.Where(g => g.Parent != null).ToList())
                groups.Remove(group);
            // Giữ lại các quyền hệ thống mà các group của user có
            foreach (var permission in permissions.ToList())
            {
                bool hasPermission = false;
                foreach (var group in groups)
                {
                    hasPermission = await _groupRepository.IsInRole(group, permission.Id);
                    if (hasPermission)
                        break;
                }
                if (!hasPermission)
                    permissions.Remove(permission);
            }
            // Lấy các quyền của riêng user
            var usr = _userRepository.List().Where(u => u.Id == userId).Include(u => u.UserPermissions).First();
            if (usr.UserPermissions.Count > 0)
            {
                foreach (var userPermission in usr.UserPermissions)
                    if (!permissions.Any(p => p.Id == userPermission.PermissionId))
                        permissions.Add(_permissionRepository.List().First(p => p.Id == userPermission.PermissionId));
            }

            // Xóa các quyền không có cha đi
            foreach (var permission in permissions.Where(p => p.Parent != null && !permissions.Any(pp => pp == p.Parent)).ToList())
                permissions.Remove(permission);

            return permissions.Select(p => p.Value).ToList() as IList<string>;
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
