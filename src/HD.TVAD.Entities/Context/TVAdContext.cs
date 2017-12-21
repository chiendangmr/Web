using HD.TVAD.Entities.Entities.Booking;
using HD.TVAD.Entities.Entities.Contract;
using HD.TVAD.Entities.Entities.MediaAsset;
using HD.TVAD.Entities.Entities.Price;
using HD.TVAD.Entities.Entities.Schedule;
using HD.TVAD.Entities.Entities.Security;
using HD.TVAD.Entities.Entities.Storage;
using HD.TVAD.Entities.Entities.System;
using HD.TVAD.Entities.Entities.UI;
using HD.TVAD.Entities.Entities.Workflow;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

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

        #region Storage

        public DbSet<FileExtension> Storage_FileExtensions { get; set; }

        public DbSet<FileType> Storage_FileTypes { get; set; }

        public DbSet<FileTypeExtension> Storage_FileTypeExtensions { get; set; }

        public DbSet<AccessZone> Storage_AccessZones { get; set; }

        public DbSet<Storage> Storage_Storages { get; set; }

        public DbSet<UriType> Storage_UriTypes { get; set; }

        public DbSet<Location> Storage_Locations { get; set; }

        public DbSet<LocationAccessZone> Storage_LocationAccessZones { get; set; }


        public DbSet<LocationAccessZoneUri> Storage_LocationAccessZoneUris { get; set; }
        #endregion

        #region System
        public DbSet<SpotBlock> System_SpotBlocks { get; set; }

        public DbSet<TimeBandBase> System_TimeBandBases { get; set; }

        public DbSet<Channel> System_Channels { get; set; }

        public DbSet<TimeBand> System_TimeBands { get; set; }

        public DbSet<TimeBandTime> System_TimeBandTimes { get; set; }

        public DbSet<TimeBandDescription> System_TimeBandDescriptions { get; set; }

        public DbSet<TimeBandDay> System_TimeBandDays { get; set; }

        public DbSet<TimeBandSlice> System_TimeBandSlices { get; set; }

        public DbSet<TimeBandSliceDescription> System_TimeBandSliceDescriptions { get; set; }

        public DbSet<SponsorProgram> System_SponsorPrograms { get; set; }
        #endregion

        #region Contract
        public DbSet<CustomerType> Contract_CustomerTypes { get; set; }

        public DbSet<Customer> Contract_Customers { get; set; }

        public DbSet<PartnerCustomer> Contract_PartnerCustomers { get; set; }

        public DbSet<RetailCustomer> Contract_RetailCustomers { get; set; }

        public DbSet<SponsorType> Contract_SponsorTypes { get; set; }

        public DbSet<Contract> Contract_Contracts { get; set; }
        #endregion

        #region Booking
        public DbSet<BookingType> Booking_Types { get; set; }

        public DbSet<TimeBandSliceDuration> Booking_TimeBandSliceDurations { get; set; }

        public DbSet<TimeBandSliceDurationByType> Booking_TimeBandSliceDurationByTypes { get; set; }

        public DbSet<AnnexContractType> Booking_AnnextContractTypes { get; set; }

        public DbSet<ContentTimeBandLock> Booking_ContentTimeBandLocks { get; set; }

        public DbSet<ContentChannelLock> Booking_ContentChannelLocks { get; set; }

        public DbSet<ContentChannelLock_TimeBandBaseNoLock> Booking_ContentChannelLock_TimeBandBaseNoLocks { get; set; }

        public DbSet<BookingType_PriceType> Booking_BookingType_PriceTypes { get; set; }

        public DbSet<AnnexContract> Booking_AnnexContracts { get; set; }

        public DbSet<AnnexContractPartner> Booking_AnnexContractPartners { get; set; }

        public DbSet<AnnexContractRetail> Booking_AnnexContractRetails { get; set; }

        public DbSet<AnnexContractContent> Booking_AnnexContractContents { get; set; }

        public DbSet<SpotBooking> Booking_SpotBookings { get; set; }
        #endregion

        #region Price
        public DbSet<TimeBandPrice> Price_TimeBandPrices { get; set; }

        public DbSet<PositionRate> Price_PositionRates { get; set; }

        public DbSet<PriceType> Price_PriceTypes { get; set; }

        public DbSet<PriceTypeDetail> Price_TypeDetails { get; set; }

        public DbSet<RetailType> Price_RetailTypes { get; set; }

        public DbSet<RetailPrice> Price_RetailPrices { get; set; }

        public DbSet<RateSpotBlock> Price_RateSpotBlocks { get; set; }

        public DbSet<BenefitType> Price_BenefitTypes { get; set; }

        public DbSet<BenefitPrice> Price_BenefitPrices { get; set; }

        public DbSet<BenefitPrice_SponsorProgram> Price_BenefitPrice_SponsorPrograms { get; set; }

        public DbSet<BenefitPrice_TimeBand> Price_BenefitPrice_TimeBands { get; set; }

        public DbSet<DiscountCustomer> Price_DiscountCustomers { get; set; }

        public DbSet<DiscountSponsorProgram> Price_DiscountSponsorPrograms { get; set; }

        public DbSet<DiscountAnnexContract> Price_DiscountAnnexContracts { get; set; }

        public DbSet<DiscountAnnexContract_TimeBandBase> Price_DiscountAnnexContract_TimeBandBases { get; set; }

        public DbSet<AnnexContractPartnerPriceAtSignDate> Price_AnnexContractPartnerPriceAtSignDates { get; set; }

        public DbSet<AnnexContractPrice> Price_AnnexContractPrices { get; set; }

        public DbSet<AnnexContractPrice_TimeBand> Price_AnnexContractPrice_TimeBands { get; set; }

        public DbSet<AnnexContractPrice_SpotBlock> Price_AnnexContractPrice_SpotBlocks { get; set; }
        #endregion

        #region Workflow
        public DbSet<Diagram> Workflow_Diagrams { get; set; }

        public DbSet<DiagramVersion> Workflow_DiagramVersions { get; set; }

        public DbSet<Workflow> Workflow_Workflows { get; set; }

        public DbSet<ActivityProvider> Workflow_ActivityProviders { get; set; }

        public DbSet<Activity> Workflow_Activities { get; set; }

        public DbSet<ActivityRunningState> Workflow_ActivityRunningStates { get; set; }

        public DbSet<ActivityRunning> Workflow_ActivityRunnings { get; set; }
        #endregion

        #region Media asset
        public DbSet<ContentType> MediaAsset_ContentTypes { get; set; }

        public DbSet<Register> MediaAsset_Registers { get; set; }

        public DbSet<Producer> MediaAsset_Producers { get; set; }

        public DbSet<ProductGroup> MediaAsset_ProductGroups { get; set; }

        public DbSet<Content> MediaAsset_Contents { get; set; }
        #endregion

        #region Schedule
        public DbSet<Spot> Schedule_Spots { get; set; }

        public DbSet<SpotContent> Schedule_SpotContents { get; set; }

        public DbSet<SpotContentByContent> Schedule_SpotContentByContents { get; set; }

        public DbSet<SpotContentByBooking> Schedule_SpotContentByBookings { get; set; }
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

            #region System
            modelBuilder.Entity<Channel>()
                .HasOne(c => c.TimeBandBase)
                .WithOne(c => c.Channel)
                .HasPrincipalKey<TimeBandBase>(b => b.Id)
                .HasForeignKey<Channel>(c => c.Id)
                .OnDelete(Microsoft.EntityFrameworkCore.Metadata.DeleteBehavior.Cascade);

            modelBuilder.Entity<TimeBand>()
                .HasOne(t => t.TimeBandBase)
                .WithOne(b => b.TimeBand)
                .HasPrincipalKey<TimeBandBase>(b => b.Id)
                .HasForeignKey<TimeBand>(t => t.Id)
                .OnDelete(Microsoft.EntityFrameworkCore.Metadata.DeleteBehavior.Cascade);
            #endregion

            #region Contract
            modelBuilder.Entity<RetailCustomer>()
                .HasOne(r => r.BaseCustomer)
                .WithOne(b => b.RetailCustomer)
                .HasPrincipalKey<Customer>(b => b.Id)
                .HasForeignKey<RetailCustomer>(r => r.Id)
                .OnDelete(Microsoft.EntityFrameworkCore.Metadata.DeleteBehavior.Cascade);

            modelBuilder.Entity<PartnerCustomer>()
                .HasOne(c => c.BaseCustomer)
                .WithOne(b => b.PartnerCustomer)
                .HasPrincipalKey<Customer>(b => b.Id)
                .HasForeignKey<PartnerCustomer>(c => c.Id)
                .OnDelete(Microsoft.EntityFrameworkCore.Metadata.DeleteBehavior.Cascade);
            #endregion

            #region Workflow
            modelBuilder.Entity<Diagram>()
                .HasOne(d => d.CurrentVersion)
                .WithMany(v => v.Diagrams)
                .HasForeignKey(d => d.WorkflowDiagramVersionId);

            modelBuilder.Entity<DiagramVersion>()
                .HasOne(v => v.Diagram)
                .WithMany(d => d.Versions)
                .HasForeignKey(v => v.WorkflowDiagramId);

            modelBuilder.Entity<ActivityRunning>()
                .HasOne(r => r.CurrentState)
                .WithMany(s => s.IsCurrentOfActivityRunnings)
                .HasPrincipalKey(s => s.Id)
                .HasForeignKey(a => a.ActivityRunningStateId);

            modelBuilder.Entity<ActivityRunningState>()
                .HasOne(s => s.ActivityRunning)
                .WithMany(r => r.States)
                .HasPrincipalKey(r => r.Id)
                .HasForeignKey(s=>s.ActivityRunningId);
            #endregion

            #region Booking
            modelBuilder.Entity<ContentChannelLock_TimeBandBaseNoLock>()
                .HasKey(l => new { l.ChannelLockId, l.TimeBandBaseId });

            modelBuilder.Entity<BookingType_PriceType>()
                .HasKey(o => new { o.BookingTypeId, o.PriceTypeId });

            modelBuilder.Entity<AnnexContractPartner>()
                .HasOne(c => c.AnnexContractBase)
                .WithOne(c => c.AnnexContractPartner)
                .HasPrincipalKey<AnnexContract>(c => c.Id)
                .HasForeignKey<AnnexContractPartner>(c => c.Id)
                .OnDelete(Microsoft.EntityFrameworkCore.Metadata.DeleteBehavior.Cascade);

            modelBuilder.Entity<AnnexContractRetail>()
                .HasOne(c => c.AnnexContractBase)
                .WithOne(c => c.AnnexContractRetail)
                .HasPrincipalKey<AnnexContract>(c => c.Id)
                .HasForeignKey<AnnexContractRetail>(c => c.Id)
                .OnDelete(Microsoft.EntityFrameworkCore.Metadata.DeleteBehavior.Cascade);
            #endregion

            #region Price
            modelBuilder.Entity<RetailType>()
                .HasOne(r => r.BaseType)
                .WithOne(d => d.Retail)
                .HasPrincipalKey<PriceTypeDetail>(d => d.Id)
                .HasForeignKey<RetailType>(r => r.Id)
                .OnDelete(Microsoft.EntityFrameworkCore.Metadata.DeleteBehavior.Cascade);

            modelBuilder.Entity<RateSpotBlock>()
                .HasOne(r => r.BaseType)
                .WithOne(d => d.RateSpotBlock)
                .HasPrincipalKey<PriceTypeDetail>(d => d.Id)
                .HasForeignKey<RateSpotBlock>(r => r.Id)
                .OnDelete(Microsoft.EntityFrameworkCore.Metadata.DeleteBehavior.Cascade);

            modelBuilder.Entity<BenefitType>()
                .HasOne(b => b.BaseType)
                .WithOne(d => d.BenefitType)
                .HasPrincipalKey<PriceTypeDetail>(d => d.Id)
                .HasForeignKey<BenefitType>(b => b.Id)
                .OnDelete(Microsoft.EntityFrameworkCore.Metadata.DeleteBehavior.Cascade);

            modelBuilder.Entity<BenefitPrice_SponsorProgram>()
                .HasKey(o => new { o.SponsorProgramId, o.BenefitPriceId });

            modelBuilder.Entity<BenefitPrice_TimeBand>()
                .HasKey(o => new { o.TimeBandId, o.BenefitPriceId });
            #endregion

            #region Schedule
            modelBuilder.Entity<SpotContentByContent>()
                .HasOne(s => s.BaseSpotContent)
                .WithOne(b => b.ByContent)
                .HasPrincipalKey<SpotContent>(b => b.Id)
                .HasForeignKey<SpotContentByContent>(s => s.Id)
                .OnDelete(Microsoft.EntityFrameworkCore.Metadata.DeleteBehavior.Restrict);

            modelBuilder.Entity<SpotContentByBooking>(entity =>
           {
               entity.HasOne(s => s.BaseSpotContent)
               .WithOne(b => b.ByBooking)
               .HasPrincipalKey<SpotContent>(b => b.Id)
               .HasForeignKey<SpotContentByBooking>(s => s.Id)
               .OnDelete(Microsoft.EntityFrameworkCore.Metadata.DeleteBehavior.Restrict);

               entity.HasOne(s => s.Booking)
               .WithOne(b => b.SpotContent)
               .HasPrincipalKey<SpotBooking>(b => b.Id)
               .HasForeignKey<SpotContentByBooking>(s => s.Id)
               .OnDelete(Microsoft.EntityFrameworkCore.Metadata.DeleteBehavior.Restrict);
           });
            #endregion

            base.OnModelCreating(modelBuilder);
        }
    }
}
