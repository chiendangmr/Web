using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace HD.Localization
{
    public class LocalizationDbContext : DbContext
    {
        public DbSet<Culture> Cultures { get; set; }

        /// <summary>
        /// Nội dung được dịch
        /// </summary>
        public DbSet<LocalizedText> LocalizedTexts { get; set; }

        /// <summary>
        /// Nội dung gốc
        /// </summary>
        public DbSet<LocalizableText> LocalizableTexts { get; set; }

        //public DbSet<TranslatorView> TranslatorViews { get; set; }

        public LocalizationDbContext(DbContextOptions<LocalizationDbContext> options)
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Ignore<TranslatorView>();
            //modelBuilder.Entity<TranslatorView>();

            base.OnModelCreating(modelBuilder);
        }
    }
}
