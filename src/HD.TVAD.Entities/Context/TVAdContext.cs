using HD.TVAD.Entities.Entities.Security;
using HD.TVAD.Entities.Entities.UI;
using Microsoft.EntityFrameworkCore;

namespace HD.TVAD.Entities.Context
{
    public class TVAdContext : DbContext
    {
        #region Security
        public DbSet<Group> Security_Groups { get; set; }

        public DbSet<User> Security_Users { get; set; }

        public DbSet<Group_User> Security_Group_Users { get; set; }

        public DbSet<Permission> Security_Permissions { get; set; }

        public DbSet<Group_Permission> Security_Group_Permissions { get; set; }

        public DbSet<User_Permission> Security_User_Permissions { get; set; }

        public DbSet<Permission_Request> Security_Permission_Requests { get; set; }
        #endregion

        #region UI
        public DbSet<Menu> UI_Menus { get; set; }

        public DbSet<Menu_Permission> UI_Menu_Permissions { get; set; }
        #endregion        

        public TVAdContext(DbContextOptions<TVAdContext> options)
            : base(options)
        {

        }

        public TVAdContext(string connectionString)
            : this(new DbContextOptionsBuilder<TVAdContext>().UseSqlServer(connectionString).Options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region Security
            modelBuilder.Entity<Group_User>().HasKey(gu => new { gu.GroupId, gu.UserId });

            modelBuilder.Entity<Group_Permission>().HasKey(gp => new { gp.GroupId, gp.PermissionId });

            modelBuilder.Entity<User_Permission>().HasKey(up => new { up.UserId, up.PermissionId });

            modelBuilder.Entity<Permission_Request>(b =>
            {
                b.HasKey(pr => new { pr.ParentId, pr.ChildrenId });

                b.HasOne(pr => pr.Parent)
                    .WithMany(p => p.PermissionsRequestMe)
                    .HasForeignKey(pr => pr.ParentId);

                b.HasOne(pr => pr.Children)
                    .WithMany(p => p.PermissionsMeRequest)
                    .HasForeignKey(pr => pr.ChildrenId);
            });
            #endregion

            #region UI
            modelBuilder.Entity<Menu_Permission>().HasKey(mp => new { mp.MenuId, mp.PermissionId });
            #endregion           

            base.OnModelCreating(modelBuilder);
        }
    }
}
