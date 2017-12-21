using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace HDAdvertising.Services.Account
{
    public partial class RoleStore<TRole> : IRoleStore<TRole> where TRole : class
    {
        //
        // Summary:
        //     Creates a new role in a store as an asynchronous operation.
        //
        // Parameters:
        //   role:
        //     The role to create in the store.
        //
        //   cancellationToken:
        //     The System.Threading.CancellationToken used to propagate notifications that the
        //     operation should be canceled.
        //
        // Returns:
        //     A System.Threading.Tasks.Task`1 that represents the Microsoft.AspNetCore.Identity.IdentityResult
        //     of the asynchronous query.
        public Task<IdentityResult> CreateAsync(TRole role, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
        //
        // Summary:
        //     Deletes a role from the store as an asynchronous operation.
        //
        // Parameters:
        //   role:
        //     The role to delete from the store.
        //
        //   cancellationToken:
        //     The System.Threading.CancellationToken used to propagate notifications that the
        //     operation should be canceled.
        //
        // Returns:
        //     A System.Threading.Tasks.Task`1 that represents the Microsoft.AspNetCore.Identity.IdentityResult
        //     of the asynchronous query.
        public Task<IdentityResult> DeleteAsync(TRole role, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
        //
        // Summary:
        //     Finds the role who has the specified ID as an asynchronous operation.
        //
        // Parameters:
        //   roleId:
        //     The role ID to look for.
        //
        //   cancellationToken:
        //     The System.Threading.CancellationToken used to propagate notifications that the
        //     operation should be canceled.
        //
        // Returns:
        //     A System.Threading.Tasks.Task`1 that result of the look up.
        public Task<TRole> FindByIdAsync(string roleId, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
        //
        // Summary:
        //     Finds the role who has the specified normalized name as an asynchronous operation.
        //
        // Parameters:
        //   normalizedRoleName:
        //     The normalized role name to look for.
        //
        //   cancellationToken:
        //     The System.Threading.CancellationToken used to propagate notifications that the
        //     operation should be canceled.
        //
        // Returns:
        //     A System.Threading.Tasks.Task`1 that result of the look up.
        public Task<TRole> FindByNameAsync(string normalizedRoleName, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
        //
        // Summary:
        //     Get a role's normalized name as an asynchronous operation.
        //
        // Parameters:
        //   role:
        //     The role whose normalized name should be retrieved.
        //
        //   cancellationToken:
        //     The System.Threading.CancellationToken used to propagate notifications that the
        //     operation should be canceled.
        //
        // Returns:
        //     A System.Threading.Tasks.Task`1 that contains the name of the role.
        public Task<string> GetNormalizedRoleNameAsync(TRole role, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
        //
        // Summary:
        //     Gets the ID for a role from the store as an asynchronous operation.
        //
        // Parameters:
        //   role:
        //     The role whose ID should be returned.
        //
        //   cancellationToken:
        //     The System.Threading.CancellationToken used to propagate notifications that the
        //     operation should be canceled.
        //
        // Returns:
        //     A System.Threading.Tasks.Task`1 that contains the ID of the role.
        public Task<string> GetRoleIdAsync(TRole role, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
        //
        // Summary:
        //     Gets the name of a role from the store as an asynchronous operation.
        //
        // Parameters:
        //   role:
        //     The role whose name should be returned.
        //
        //   cancellationToken:
        //     The System.Threading.CancellationToken used to propagate notifications that the
        //     operation should be canceled.
        //
        // Returns:
        //     A System.Threading.Tasks.Task`1 that contains the name of the role.
        public Task<string> GetRoleNameAsync(TRole role, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
        //
        // Summary:
        //     Set a role's normalized name as an asynchronous operation.
        //
        // Parameters:
        //   role:
        //     The role whose normalized name should be set.
        //
        //   normalizedName:
        //     The normalized name to set
        //
        //   cancellationToken:
        //     The System.Threading.CancellationToken used to propagate notifications that the
        //     operation should be canceled.
        //
        // Returns:
        //     The System.Threading.Tasks.Task that represents the asynchronous operation.
        public Task SetNormalizedRoleNameAsync(TRole role, string normalizedName, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
        //
        // Summary:
        //     Sets the name of a role in the store as an asynchronous operation.
        //
        // Parameters:
        //   role:
        //     The role whose name should be set.
        //
        //   roleName:
        //     The name of the role.
        //
        //   cancellationToken:
        //     The System.Threading.CancellationToken used to propagate notifications that the
        //     operation should be canceled.
        //
        // Returns:
        //     The System.Threading.Tasks.Task that represents the asynchronous operation.
        public Task SetRoleNameAsync(TRole role, string roleName, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
        //
        // Summary:
        //     Updates a role in a store as an asynchronous operation.
        //
        // Parameters:
        //   role:
        //     The role to update in the store.
        //
        //   cancellationToken:
        //     The System.Threading.CancellationToken used to propagate notifications that the
        //     operation should be canceled.
        //
        // Returns:
        //     A System.Threading.Tasks.Task`1 that represents the Microsoft.AspNetCore.Identity.IdentityResult
        //     of the asynchronous query.
        public Task<IdentityResult> UpdateAsync(TRole role, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {

        }
    }
}
