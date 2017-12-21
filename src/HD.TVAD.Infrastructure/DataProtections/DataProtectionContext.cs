using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JetBrains.Annotations;
using Microsoft.Extensions.Options;

namespace HD.TVAD.Infrastructure.DataProtections
{
    public class DataProtectionContext : DbContext
    {
        public DbSet<DataProtectionKey> DataProtectionKeys { get; set; }

        private SqlServerStorageProviderOptions SqlServerOptions { get; set; }

        public DataProtectionContext(DbContextOptions<DataProtectionContext> options, IOptions<SqlServerStorageProviderOptions> opt) : base(options)
        {
            this.SqlServerOptions = opt.Value;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<DataProtectionKey>(e =>
            {
                e.ToTable(SqlServerOptions.TableName, SqlServerOptions.Schema ?? "dbo");
                e.HasKey(x => x.FriendlyName);
                e.Property(p => p.FriendlyName).HasColumnType("nvarchar(2048)");
                e.Property(p => p.XmlData).HasColumnType("nvarchar(max)"); ;
            });
        }
    }
}
