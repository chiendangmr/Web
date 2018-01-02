using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using HD.TVAD.ApplicationCore.Entities;
using HD.TVAD.ApplicationCore.Entities.Security;
using HD.TVAD.ApplicationCore.Entities.UI;

namespace HD.TVAD.Infrastructure.Data
{
    public partial class HDAdDbContext : DbContext, IDataContext
    {
        public virtual DbSet<Database> Databases { get; set; }
        public virtual DbSet<Group_Permission> GroupPermissions { get; set; }
        public virtual DbSet<Group_User> GroupUsers { get; set; }
        public virtual DbSet<Group> Groups { get; set; }
        public virtual DbSet<Menu_Permission> Menu_Permissions { get; set; }
        public virtual DbSet<Menu> Menus { get; set; }
        public virtual DbSet<PermissionRequest> PermissionRequests { get; set; }
        public virtual DbSet<Permission> Permissions { get; set; }
        public virtual DbSet<User_Permission> UserPermissions { get; set; }
        public virtual DbSet<User> Users { get; set; }

        public HDAdDbContext(DbContextOptions<HDAdDbContext> options)
            : base(options)
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
            //    optionsBuilder.UseSqlServer(@"Data Source=hdstation.ddns.net,1433;Initial Catalog=HDAdv2017;Persist Security Info=True;User ID=sa;Password=Hd123456!DB;MultipleActiveResultSets=true;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Database>(entity =>
            {
                entity.ToTable("Databases", "System");

                entity.HasIndex(e => e.Name)
                    .HasName("IX_Databases")
                    .IsUnique();

                entity.HasIndex(e => e.StartDate)
                    .HasName("IX_Databases_1")
                    .IsUnique();

                entity.Property(e => e.Id).HasDefaultValueSql("newid()");

                entity.Property(e => e.EndDate).HasColumnType("date");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(256);

                entity.Property(e => e.StartDate)
                    .HasColumnType("date")
                    .HasDefaultValueSql("getdate()");
            });

            modelBuilder.Entity<Group_Permission>(entity =>
            {
                entity.HasKey(e => new { e.GroupId, e.PermissionId })
                    .HasName("PK_Group_Permissions");

                //entity.ToTable("Group_Permissions", "Security");

                //entity.HasOne(d => d.Group)
                //    .WithMany(p => p.GroupPermissions)
                //    .HasForeignKey(d => d.GroupId)
                //    .HasConstraintName("FK_Group_Permissions_Groups");

                //entity.HasOne(d => d.Permission)
                //    .WithMany(p => p.GroupPermissions)
                //    .HasForeignKey(d => d.PermissionId)
                //    .HasConstraintName("FK_Group_Permissions_Permissions");
            });

            modelBuilder.Entity<Group_User>(entity =>
            {
                entity.HasKey(e => new { e.GroupId, e.UserId })
                    .HasName("PK_UserGroup_Users");

                //entity.ToTable("Group_Users", "Security");

                //entity.HasOne(d => d.Group)
                //    .WithMany(p => p.GroupUsers)
                //    .HasForeignKey(d => d.GroupId)
                //    .HasConstraintName("FK_Group_Users_Groups");

                //entity.HasOne(d => d.User)
                //    .WithMany(p => p.GroupUsers)
                //    .HasForeignKey(d => d.UserId)
                //    .HasConstraintName("FK_Group_Users_Users");
            });

            modelBuilder.Entity<PermissionRequest>(entity =>
            {
                entity.HasKey(e => new { e.ParentId, e.ChildrenId })
                    .HasName("PK_Permission_ParentChildrens");

                //entity.ToTable("Permission_Requests", "Security");

                entity.HasOne(d => d.Children)
                    .WithMany(p => p.PermissionsMeRequest)
                    .HasForeignKey(d => d.ChildrenId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_Permission_ParentChildrens_Permissions1");

                entity.HasOne(d => d.Parent)
                    .WithMany(p => p.PermissionsRequestMe)
                    .HasForeignKey(d => d.ParentId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_Permission_ParentChildrens_Permissions");
            });
            modelBuilder.Entity<User_Permission>(entity =>
                     {
                         entity.HasKey(e => new { e.UserId, e.PermissionId })
                             .HasName("PK_User_Permissions");                         
                     });
            
            modelBuilder.Entity<Menu_Permission>()
                .HasKey(mp => new { mp.MenuId, mp.PermissionId });
        }

    }
}