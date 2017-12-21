using HDAdvertising.Datas.Security;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HDAdvertising.Datas
{
    public partial class HDAdvDbContext : DbContext
    {
        public DbSet<Group> Security_Groups { get; set; }

        public DbSet<User> Security_Users { get; set; }

        public DbSet<Group_User> Security_Group_Users { get; set; }

        public DbSet<Security.Permission> Security_Permissions { get; set; }

        public DbSet<Group_Permission> Security_Group_Permissions { get; set; }

        //public DbSet<User_Permission> Account_User_Permissions { get; set; }

        //public DbSet<Permission_Request> Account_Permission_Requests { get; set; }

        public DbSet<UI.Menu> UI_Menus { get; set; }

        public DbSet<UI.Menu_Permission> UI_Menu_Permissions { get; set; }

        public HDAdvDbContext(DbContextOptions<HDAdvDbContext> options)
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Group>(b =>
            {
                b.HasKey(g => g.Id);
                b.HasIndex(g => g.Name).IsUnique();
                b.ToTable("Groups", "Security");

                b.Property(g => g.Name).HasMaxLength(256);

                b.HasMany(g => g.Childrens).WithOne(g => g.Parent)
                    .HasForeignKey(g => g.ParentId);
                b.HasMany(g => g.Users).WithOne().HasForeignKey(gu => gu.GroupId).IsRequired();
                b.HasMany(g => g.Permissions).WithOne().HasForeignKey(gp => gp.GroupId).IsRequired();
            });

            modelBuilder.Entity<User>(b =>
            {
                b.HasKey(u => u.Id);
                b.HasIndex(u => u.Name).IsUnique();
                b.Property(u => u.ConcurrencyStamp).IsConcurrencyToken();
                b.ToTable("Users", "Security");

                b.Property(u => u.Name).HasMaxLength(256);
                b.Property(u => u.Email).HasMaxLength(256);

                b.HasMany(u => u.Groups).WithOne().HasForeignKey(gu => gu.UserId).IsRequired();
                //b.HasMany(u => u.Permissions).WithOne().HasForeignKey(up => up.UserId).IsRequired();
            });

            modelBuilder.Entity<Group_User>(b =>
            {
                b.HasKey(gu => new { gu.GroupId, gu.UserId });
                b.ToTable("Group_Users", "Security");
            });

            modelBuilder.Entity<Security.Permission>(b =>
            {
                b.HasKey(p => p.Id);
                b.HasIndex(p => p.Type);
                b.HasIndex(p => p.ParentId);
                b.HasIndex(p => p.Value);
                b.ToTable("Permissions", "Security");

                b.Property(p => p.Type).HasMaxLength(256);
                b.Property(p => p.Value).HasMaxLength(256);

                b.HasMany(p => p.Childrens).WithOne(p => p.Parent)
                    .HasForeignKey(p => p.ParentId);
                //b.HasMany(p => p.RequestParents).WithOne().HasForeignKey(r => r.ChildrenId).IsRequired();
                //b.HasMany(p => p.RequestChildrens).WithOne().HasForeignKey(r => r.ParentId).IsRequired();
                b.HasMany(p => p.Menus).WithOne().HasForeignKey(mp => mp.PermissionId).IsRequired();
            });

            //modelBuilder.Entity<Permission_Request>(b =>
            //{
            //    b.HasKey(r => new { r.ParentId, r.ChildrenId });
            //    b.ToTable("Permission_Requests", "Security");
            //});

            modelBuilder.Entity<Group_Permission>(b =>
            {
                b.HasKey(gp => new { gp.GroupId, gp.PermissionId});
                b.ToTable("Group_Permissions", "Security");
            });

            //modelBuilder.Entity<User_Permission>(b =>
            //{
            //    b.HasKey(up => new { up.UserId, up.PermissionId });
            //    b.ToTable("User_Permissions", "Security");
            //});

            modelBuilder.Entity<UI.Menu>(b =>
            {
                b.HasKey(m => m.Id);
                b.HasIndex(m => m.Index);
                b.HasIndex(m => new { m.ParentId, m.Name }).IsUnique();
                b.ToTable("Menus", "UI");

                b.Property(m => m.Name).HasMaxLength(50).IsRequired();
                b.HasMany(m => m.Childrens).WithOne(m=>m.Parent).HasForeignKey(m => m.ParentId);
                b.HasMany(m => m.Permissions).WithOne().HasForeignKey(mp => mp.MenuId).IsRequired();
            });

            modelBuilder.Entity<UI.Menu_Permission>(b =>
            {
                b.HasKey(mp => new { mp.MenuId, mp.PermissionId });
                b.ToTable("Menu_Permissions", "UI");
            });
        }
    }
}
