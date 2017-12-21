using HD.TVAD.Entities.Entities.Security;
using HD.TVAD.Entities.Entities.Storage;
using HD.TVAD.Entities.Entities.UI;
using HD.TVAD.Entities.Repositories.Security;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HD.TVAD.Entities.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected readonly Context.TVAdContext _context;
        public Repository(Context.TVAdContext context)
        {
            _context = context;
        }

        public DbSet<TEntity> Datas => _context.Set<TEntity>();

        public Task<int> InsertAsync(TEntity entry)
        {
            Datas.Add(entry);
            return SaveChangesAsync();
        }

        public Task<int> UpdateAsync(TEntity entry)
        {
            return SaveChangesAsync();
        }

        public Task<int> DeleteAsync(TEntity entry)
        {
            Datas.Remove(entry);
            return SaveChangesAsync();
        }

        public Task<int> DeleteAsync(IEnumerable<TEntity> entries)
        {
            Datas.RemoveRange(entries);
            return SaveChangesAsync();
        }

        public Task<int> SaveChangesAsync()
        {
            return _context.SaveChangesAsync();
        }

        public int SaveChanges()
        {
            return _context.SaveChanges();
        }

        public IDbContextTransaction BeginTransaction()
        {
            return _context.Database.BeginTransaction();
        }
    }

    public static class RepositoryExtensions
    {
        public static void RegisterRepositories(IServiceCollection services)
        {
            #region Security
            services.AddScoped<IGroupRepository<Group>, GroupRepository<Group>>();
            services.AddScoped<IUserRepository<User>, UserRepository<User>>();
            services.AddScoped<IRepository<Permission>, Repository<Permission>>();
            services.AddScoped<IRepository<Group_User>, Repository<Group_User>>();
            services.AddScoped<IRepository<Group_Permission>, Repository<Group_Permission>>();
            services.AddScoped<IRepository<User_Permission>, Repository<User_Permission>>();
            services.AddScoped<IRepository<Permission_Request>, Repository<Permission_Request>>();
            #endregion

            #region UI
            services.AddScoped<IRepository<Menu>, Repository<Menu>>();
            services.AddScoped<IRepository<Menu_Permission>, Repository<Menu_Permission>>();
            #endregion

            #region Storage
            services.AddScoped<IRepository<FileType>, Repository<FileType>>();
            services.AddScoped<IRepository<FileExtension>, Repository<FileExtension>>();
            services.AddScoped<IRepository<FileTypeExtension>, Repository<FileTypeExtension>>();

            services.AddScoped<IRepository<Storage>, Repository<Storage>>();
            services.AddScoped<IRepository<Location>, Repository<Location>>();
            services.AddScoped<IRepository<LocationAccessZone>, Repository<LocationAccessZone>>();

            services.AddScoped<IRepository<AccessZone>, Repository<AccessZone>>();
            services.AddScoped<IRepository<UriType>, Repository<UriType>>();
            services.AddScoped<IRepository<LocationAccessZoneUri>, Repository<LocationAccessZoneUri>>();
            #endregion
        }
    }
}
