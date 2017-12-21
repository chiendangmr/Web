using Microsoft.EntityFrameworkCore;

using Microsoft.EntityFrameworkCore.Metadata;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HD.Station.Models.Localization
{
    public class LocalizationDbContext : DbContext
    {
        public LocalizationDbContext(DbContextOptions<LocalizationDbContext> option)
            : base(option)
        {
        }

        public DbSet<StringLocalizable> StringLocalizables { get; set; }
        public DbSet<StringLocalization> StringLocalizations { get; set; }
        public DbSet<Culture> Cultures { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
