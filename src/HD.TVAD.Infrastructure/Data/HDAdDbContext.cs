using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using HD.TVAD.ApplicationCore.Entities;
using HD.TVAD.ApplicationCore.Entities.MediaAsset;
using HD.TVAD.ApplicationCore.Entities.Security;
using HD.TVAD.ApplicationCore.Entities.Storage;
using HD.TVAD.ApplicationCore.Entities.UI;

namespace HD.TVAD.Infrastructure.Data
{
    public partial class HDAdDbContext : DbContext, IDataContext
	{
		public virtual DbSet<BenefitPriceSponsorProgram> BenefitPriceSponsorPrograms { get; set; }
		public virtual DbSet<BenefitPriceTimeBand> BenefitPriceTimeBands { get; set; }
		public virtual DbSet<BenefitPrice> BenefitPrices { get; set; }
		public virtual DbSet<BenefitType> BenefitTypes { get; set; }
		public virtual DbSet<ApplicationCore.Entities.MediaAsset.AccessZone> AccessZones { get; set; }
        public virtual DbSet<AnnexContractAsset> AnnexContractAssets { get; set; }
        public virtual DbSet<AnnexContractPartnerPriceAtSignDate> AnnexContractPartnerPriceAtSignDates { get; set; }
        public virtual DbSet<AnnexContractPartner> AnnexContractPartners { get; set; }
		public virtual DbSet<RetailContract> RetailContracts { get; set; }
		public virtual DbSet<AnnexContract> AnnexContracts { get; set; }
		public virtual DbSet<AnnexContractType> AnnexContractTypes { get; set; }
		public virtual DbSet<Areas> Areas { get; set; }
        public virtual DbSet<ContentChannelLockTimeBandBaseNoLock> ContentChannelLockTimeBandBaseNoLocks { get; set; }
        public virtual DbSet<ContentChannelLock> ContentChannelLocks { get; set; }
        public virtual DbSet<AssetDocumentFile> AssetDocumentFiles { get; set; }
        public virtual DbSet<AssetDocumentLink> AssetDocumentLinks { get; set; }
        public virtual DbSet<AssetDocument> AssetDocuments { get; set; }
        public virtual DbSet<AssetLocator> AssetLocator { get; set; }
        public virtual DbSet<ContentTimeBandLock> ContentTimeBandLocks { get; set; }
        public virtual DbSet<AssetType> AssetType { get; set; }
        public virtual DbSet<ContentType> AssetTypes { get; set; }
        public virtual DbSet<Content> Assets { get; set; }
        public virtual DbSet<Asset> Asset { get; set; }
        public virtual DbSet<BookingTypePriceType> BookingTypePriceTypes { get; set; }
        public virtual DbSet<BookingType> BookingTypes { get; set; }
        public virtual DbSet<Channel> Channels { get; set; }
        public virtual DbSet<Contract> Contracts { get; set; }
        public virtual DbSet<CustomerPartner> CustomerPartners { get; set; }
		public virtual DbSet<RetailCustomer> RetailCustomers { get; set; }
		public virtual DbSet<CustomerType> CustomerTypes { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Database> Databases { get; set; }
        public virtual DbSet<DiscountAnnexContractAsset> DiscountAnnexContractAssets { get; set; }
        public virtual DbSet<DiscountAnnexContractTimeBandBase> DiscountAnnexContractTimeBandBases { get; set; }
        public virtual DbSet<DiscountAnnexContract> DiscountAnnexContracts { get; set; }
        public virtual DbSet<DiscountCustomer> DiscountCustomers { get; set; }
        public virtual DbSet<DiscountSponsorProgram> DiscountSponsorPrograms { get; set; }
        public virtual DbSet<DocumentType> DocumentTypes { get; set; }
        public virtual DbSet<Evidence> Evidences { get; set; }
        public virtual DbSet<FileContent> FileContents { get; set; }
        public virtual DbSet<FileDetailLocation> FileDetailLocations { get; set; }
        public virtual DbSet<FileDetail> FileDetails { get; set; }
        public virtual DbSet<FileInStorage> FileInStorages { get; set; }
        public virtual DbSet<FileType> FileTypes { get; set; }
        public virtual DbSet<File> Files { get; set; }
        public virtual DbSet<Group_Permission> GroupPermissions { get; set; }
        public virtual DbSet<Group_User> GroupUsers { get; set; }
		public virtual DbSet<NotificationSubscribe> NotificationSubscribes { get; set; }
		public virtual DbSet<Group> Groups { get; set; }
        public virtual DbSet<LocationAccessZone> LocationAccessZones { get; set; }
        public virtual DbSet<LocationAccessZoneUri> LocationAccessZoneUris { get; set; }
        public virtual DbSet<Location> Locations { get; set; }
        public virtual DbSet<MediaAsset> MediaAssets { get; set; }
        public virtual DbSet<MimeType> MimeTypes { get; set; }
        public virtual DbSet<Menu_Permission> Menu_Permissions { get; set; }
        public virtual DbSet<Menu> Menus { get; set; }
        public virtual DbSet<Origin> Origins { get; set; }
        public virtual DbSet<PermissionRequest> PermissionRequests { get; set; }
        public virtual DbSet<Permission> Permissions { get; set; }
        public virtual DbSet<PositionRate> PositionRates { get; set; }
        public virtual DbSet<Position> Positions { get; set; }
        public virtual DbSet<PriceType> PriceTypes { get; set; }
        public virtual DbSet<Producer> Producers { get; set; }
        public virtual DbSet<ProductGroupDocumentRequest> ProductGroupDocumentRequests { get; set; }
        public virtual DbSet<ProductGroup> ProductGroups { get; set; }
        public virtual DbSet<RateSpotBlock> RateSpotBlocks { get; set; }
        public virtual DbSet<Register> Registers { get; set; }
        public virtual DbSet<RetailPrice> RetailPrices { get; set; }
        public virtual DbSet<RetailType> RetailTypes { get; set; }
        public virtual DbSet<SceneFile> SceneFiles { get; set; }
        public virtual DbSet<ApplicationCore.Entities.Scene> Scenes { get; set; }
        public virtual DbSet<ApplicationCore.Entities.MediaAsset.Scene> Scene { get; set; }
        public virtual DbSet<SponsorProgram> SponsorPrograms { get; set; }
        public virtual DbSet<SponsorType> SponsorTypes { get; set; }
        public virtual DbSet<SpotApprove> SpotApproves { get; set; }
        public virtual DbSet<SpotBlockRate> SpotBlockRates { get; set; }
        public virtual DbSet<SpotBlock> SpotBlocks { get; set; }
        public virtual DbSet<SpotBooking> SpotBookings { get; set; }
        public virtual DbSet<Spot> Spots { get; set; }
        public virtual DbSet<ApplicationCore.Entities.Storage.Storage> Storages { get; set; }
        public virtual DbSet<ApplicationCore.Entities.MediaAsset.Storage> Storage { get; set; }
        public virtual DbSet<StorageLocation> StorageLocation { get; set; }
        public virtual DbSet<StorageLocationAccess> StorageLocationAccess { get; set; }
        public virtual DbSet<StorageLocationAccessZone> StorageLocationAccessZone { get; set; }
        public virtual DbSet<StorageLocationAccessType> StorageLocationAccessType { get; set; }
        public virtual DbSet<TimeBandBase> TimeBandBases { get; set; }
        public virtual DbSet<TimeBandDay> TimeBandDays { get; set; }
        public virtual DbSet<TimeBandDescription> TimeBandDescriptions { get; set; }
        public virtual DbSet<TimeBandPrice> TimeBandPrices { get; set; }
        public virtual DbSet<TimeBandSliceDescription> TimeBandSliceDescriptions { get; set; }
        public virtual DbSet<TimeBandSliceDurationByType> TimeBandSliceDurationByTypes { get; set; }
        public virtual DbSet<TimeBandSliceDuration> TimeBandSliceDurations { get; set; }
        public virtual DbSet<TimeBandSliceForType> TimeBandSliceForTypes { get; set; }
        public virtual DbSet<TimeBandSlice> TimeBandSlices { get; set; }
        public virtual DbSet<TimeBandTime> TimeBandTimes { get; set; }
        public virtual DbSet<TimeBand> TimeBands { get; set; }
        public virtual DbSet<TypeDetail> TypeDetails { get; set; }
        public virtual DbSet<User_Permission> UserPermissions { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<ApplicationCore.Entities.Version> Versions { get; set; }

        public virtual DbSet<FileExtension> FileExtensions { get; set; }

        public virtual DbSet<FileTypeExtension> FileTypeExtensions { get; set; }


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

            modelBuilder.Entity<Asset>(entity =>
            {
                entity.ToTable("Asset", "MediaAssets");

                entity.Property(e => e.Id).HasDefaultValueSql("newsequentialid()");

                entity.Property(e => e.FileName).HasColumnType("FileName");

                entity.Property(e => e.MimeType).HasColumnType("Name");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnType("Name");

                entity.Property(e => e.OriginFileName).HasColumnType("FileName");

                entity.Property(e => e.Revision)
                    .IsRequired()
                    .HasColumnType("timestamp")
                    .ValueGeneratedOnAddOrUpdate();

                entity.HasOne(d => d.AssetType)
                    .WithMany(p => p.Assets)
                    .HasForeignKey(d => d.AssetTypeId)
                    .HasConstraintName("FK_Asset_AssetType");

                entity.HasOne(d => d.MediaAsset)
                    .WithMany(p => p.Assets)
                    .HasForeignKey(d => d.MediaAssetId)
                    .HasConstraintName("FK_Asset_MediaAsset");

                entity.HasOne(d => d.MimeTypeObj)
                    .WithMany(p => p.Assets)
                    .HasForeignKey(d => d.MimeType)
                    .HasConstraintName("FK_Asset_MineType");
            });
            modelBuilder.Entity<AssetLocator>(entity =>
            {
                entity.ToTable("AssetLocator", "MediaAssets");

                entity.Property(e => e.Id).HasDefaultValueSql("newsequentialid()");

                entity.Property(e => e.ContainerMimeType)
                    .IsRequired()
                    .HasColumnType("Name");

                entity.Property(e => e.Path)
                    .IsRequired()
                    .HasColumnType("FileName");

                entity.Property(e => e.Revision)
                    .IsRequired()
                    .HasColumnType("timestamp")
                    .ValueGeneratedOnAddOrUpdate();

                entity.HasOne(d => d.Asset)
                    .WithMany(p => p.AssetLocators)
                    .HasForeignKey(d => d.AssetId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_AssetLocator_Asset");

                entity.HasOne(d => d.MimeType)
                    .WithMany(p => p.AssetLocators)
                    .HasForeignKey(d => d.ContainerMimeType)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_AssetLocator_MineType");

                entity.HasOne(d => d.StorageLocation)
                    .WithMany(p => p.AssetLocators)
                    .HasForeignKey(d => d.StorageLocationId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_AssetLocator_StorageLocation");
            });
            modelBuilder.Entity<BenefitPriceSponsorProgram>(entity =>
			{
				entity.HasKey(e => new { e.SponsorProgramId, e.BenefitPriceId })
					.HasName("PK_BenefitPrice_SponsorPrograms");

				entity.ToTable("BenefitPrice_SponsorPrograms", "Price");

				entity.HasOne(d => d.BenefitPrice)
					.WithMany(p => p.BenefitPriceSponsorPrograms)
					.HasForeignKey(d => d.BenefitPriceId)
					.HasConstraintName("FK_BenefitPrice_SponsorPrograms_BenefitPrices");

				entity.HasOne(d => d.SponsorProgram)
					.WithMany(p => p.BenefitPriceSponsorPrograms)
					.HasForeignKey(d => d.SponsorProgramId)
					.HasConstraintName("FK_BenefitPrice_SponsorPrograms_SponsorPrograms");
			});

			modelBuilder.Entity<BenefitPriceTimeBand>(entity =>
			{
				entity.HasKey(e => new { e.TimeBandId, e.BenefitPriceId })
					.HasName("PK_BenefitPrice_TimeBands");

				entity.ToTable("BenefitPrice_TimeBands", "Price");

				entity.HasOne(d => d.BenefitPrice)
					.WithMany(p => p.BenefitPriceTimeBands)
					.HasForeignKey(d => d.BenefitPriceId)
					.HasConstraintName("FK_BenefitPrice_TimeBands_BenefitPrices");

				entity.HasOne(d => d.TimeBand)
					.WithMany(p => p.BenefitPriceTimeBands)
					.HasForeignKey(d => d.TimeBandId)
					.HasConstraintName("FK_BenefitPrice_TimeBands_TimeBands");
			});

			modelBuilder.Entity<BenefitPrice>(entity =>
			{
				entity.ToTable("BenefitPrices", "Price");

				entity.Property(e => e.Id).HasDefaultValueSql("newid()");

				entity.Property(e => e.StartDate).HasColumnType("date");

				entity.HasOne(d => d.BenefitType)
					.WithMany(p => p.BenefitPrices)
					.HasForeignKey(d => d.BenefitTypeId)
					.HasConstraintName("FK_BenefitPrices_BenefitTypes");
			});

			modelBuilder.Entity<BenefitType>(entity =>
			{
				entity.ToTable("BenefitTypes", "Price");

				entity.HasIndex(e => e.Code)
					.HasName("IX_BenefitTypes")
					.IsUnique();

				entity.Property(e => e.Id).HasDefaultValueSql("newid()");

				entity.Property(e => e.Code)
					.IsRequired()
					.HasMaxLength(50);

				entity.HasOne(d => d.TypeDetail)
					.WithOne(p => p.BenefitType)
					.HasForeignKey<BenefitType>(d => d.Id)
					.HasConstraintName("FK_BenefitTypes_TypeDetails");
			});

            modelBuilder.Entity<ApplicationCore.Entities.MediaAsset.AccessZone>(entity =>
            {
                entity.ToTable("AccessZone", "MediaAssets");

                entity.Property(e => e.Id).HasDefaultValueSql("newid()"); ;

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(256);
            });

            modelBuilder.Entity<AnnexContractAsset>(entity =>
            {
                entity.ToTable("AnnexContractAssets", "Booking");

                entity.HasIndex(e => new { e.AnnexContractId, e.ContentId })
                    .HasName("IX_AnnexContractAssets")
                    .IsUnique();

                entity.Property(e => e.Id).HasDefaultValueSql("newid()");

                entity.Property(e => e.Price).HasColumnType("decimal");

                entity.HasOne(d => d.AnnexContract)
                    .WithMany(p => p.AnnexContractAssets)
                    .HasForeignKey(d => d.AnnexContractId)
                    .HasConstraintName("FK_AnnexContractAssets_AnnexContracts");

                entity.HasOne(d => d.Content)
                    .WithMany(p => p.AnnexContractAssets)
                    .HasForeignKey(d => d.ContentId)
                    .HasConstraintName("FK_AnnexContractAssets_Assets");

                entity.HasOne(d => d.PriceTypeDetail)
                    .WithMany(p => p.AnnexContractAssets)
                    .HasForeignKey(d => d.PriceTypeDetailId)
                    .HasConstraintName("FK_AnnexContractAssets_TypeDetails");
            });

            modelBuilder.Entity<AnnexContractPartnerPriceAtSignDate>(entity =>
            {
                entity.ToTable("AnnexContractPartnerPriceAtSignDates", "Price");

                entity.HasIndex(e => new { e.AnnexContractId, e.StartDate })
                    .HasName("IX_AnnexContractPartnerPriceAtSignDates")
                    .IsUnique();

                entity.Property(e => e.Id).HasDefaultValueSql("newid()");

                entity.Property(e => e.EndDate).HasColumnType("date");

                entity.Property(e => e.StartDate).HasColumnType("date");

                entity.HasOne(d => d.AnnexContract)
                    .WithMany(p => p.AnnexContractPartnerPriceAtSignDates)
                    .HasForeignKey(d => d.AnnexContractId)
                    .HasConstraintName("FK_AnnexContractPartnerPriceAtSignDates_AnnexContractPartners");
            });

            modelBuilder.Entity<AnnexContractPartner>(entity =>
            {
                entity.ToTable("AnnexContractPartners", "Booking");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.SignDate)
                    .HasColumnType("date")
                    .HasDefaultValueSql("getdate()");

                entity.HasOne(d => d.AnnexContract)
                    .WithOne(p => p.AnnexContractPartners)
                    .HasForeignKey<AnnexContractPartner>(d => d.Id)
                    .HasConstraintName("FK_AnnexContractPartners_AnnexContracts");

                entity.HasOne(d => d.SponsorProgram)
                    .WithMany(p => p.AnnexContractPartners)
                    .HasForeignKey(d => d.SponsorProgramId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_AnnexContractPartners_SponsorPrograms");

                entity.HasOne(d => d.SponsorType)
                    .WithMany(p => p.AnnexContractPartners)
                    .HasForeignKey(d => d.SponsorTypeId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("FK_AnnexContractPartners_SponsorTypes");
            });
			modelBuilder.Entity<RetailContract>(entity =>
			{
				entity.ToTable("RetailContracts", "Booking");

				entity.Property(e => e.Id).ValueGeneratedNever();

				entity.HasOne(d => d.AnnexContract)
					.WithOne(p => p.RetailContract)
					.HasForeignKey<RetailContract>(d => d.Id)
					.HasConstraintName("FK_RetailContracts_AnnexContracts");
				
			});

			modelBuilder.Entity<AnnexContract>(entity =>
            {
                entity.ToTable("AnnexContracts", "Booking");

                entity.HasIndex(e => e.Code)
                    .HasName("IX_AnnexContracts")
                    .IsUnique();

				entity.Property(e => e.Id).HasDefaultValueSql("newid()");

				entity.Property(e => e.Code)
                    .IsRequired()
                    .HasMaxLength(256);

                entity.Property(e => e.ReceiveDate)
                    .HasColumnType("date")
                    .HasDefaultValueSql("getdate()");

				entity.HasOne(d => d.AnnexContractType)
					.WithMany(p => p.AnnexContracts)
					.HasForeignKey(d => d.AnnexContractTypeId)
					.HasConstraintName("FK_AnnexContracts_AnnexContractTypes");

				entity.HasOne(d => d.BookingType)
                    .WithMany(p => p.AnnexContracts)
                    .HasForeignKey(d => d.BookingTypeId)
                    .HasConstraintName("FK_AnnexContracts_Types");

                entity.HasOne(d => d.Contract)
                    .WithMany(p => p.AnnexContracts)
                    .HasForeignKey(d => d.ContractId)
                    .HasConstraintName("FK_AnnexContracts_Contracts");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.AnnexContracts)
                    .HasForeignKey(d => d.CustomerId)
                    .HasConstraintName("FK_AnnexContracts_Customers");
            });

            modelBuilder.Entity<Areas>(entity =>
            {
                entity.ToTable("Areas", "Asset");

                entity.Property(e => e.Id).HasDefaultValueSql("newid()");

                entity.Property(e => e.Index).HasDefaultValueSql("99");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(256);
            });

            modelBuilder.Entity<ContentChannelLockTimeBandBaseNoLock>(entity =>
            {
                entity.HasKey(e => new { e.LockId, e.TimeBandBaseId })
                    .HasName("PK_AssetChannelLock_TimeBandBaseNoLocks");

                entity.ToTable("ContentChannelLock_TimeBandBaseNoLocks", "Booking");

                entity.HasOne(d => d.Lock)
                    .WithMany(p => p.ContentChannelLockTimeBandBaseNoLocks)
                    .HasForeignKey(d => d.LockId)
                    .HasConstraintName("FK_AssetChannelLock_TimeBandBaseNoLocks_AssetChannelLocks");

                entity.HasOne(d => d.TimeBandBase)
                    .WithMany(p => p.AssetChannelLockTimeBandBaseNoLocks)
                    .HasForeignKey(d => d.TimeBandBaseId)
                    .HasConstraintName("FK_AssetChannelLock_TimeBandBaseNoLocks_TimeBandBases");
            });

            modelBuilder.Entity<ContentChannelLock>(entity =>
            {
                entity.ToTable("ContentChannelLocks", "Booking");

                entity.HasIndex(e => new { e.ContentId, e.ChannelId, e.StartDate })
                    .HasName("IX_AssetChannelLocks")
                    .IsUnique();

                entity.Property(e => e.Id).HasDefaultValueSql("newid()");

                entity.Property(e => e.EndDate).HasColumnType("date");

                entity.Property(e => e.StartDate)
                    .IsRequired()
                    .HasColumnType("date");

                entity.HasOne(d => d.Content)
                    .WithMany(p => p.ContentChannelLocks)
                    .HasForeignKey(d => d.ContentId)
                    .HasConstraintName("FK_AssetChannelLocks_Assets");

                entity.HasOne(d => d.Channel)
                    .WithMany(p => p.AssetChannelLocks)
                    .HasForeignKey(d => d.ChannelId)
                    .HasConstraintName("FK_AssetChannelLocks_Channels");
            });

            modelBuilder.Entity<AssetDocumentFile>(entity =>
            {
                entity.ToTable("AssetDocumentFiles", "Storage");

                entity.HasIndex(e => new { e.DocumentId, e.Name })
                    .HasName("IX_AssetDocumentFiles")
                    .IsUnique();

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(256);

                entity.HasOne(d => d.Document)
                    .WithMany(p => p.AssetDocumentFiles)
                    .HasForeignKey(d => d.DocumentId)
                    .HasConstraintName("FK_AssetDocumentFiles_AssetDocuments");

                entity.HasOne(d => d.File)
                    .WithMany(p => p.AssetDocumentFiles)
                    .HasForeignKey(d => d.FileId)
                    .HasConstraintName("FK_AssetDocumentFiles_Files");
            });

            modelBuilder.Entity<AssetDocumentLink>(entity =>
            {
                entity.HasKey(e => new { e.OriginDocumentId, e.DocumentId })
                    .HasName("PK_AssetDocumentLinks");

                entity.ToTable("AssetDocumentLinks", "Document");

                entity.HasOne(d => d.Document)
                    .WithMany(p => p.AssetDocumentLinksDocument)
                    .HasForeignKey(d => d.DocumentId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_AssetDocumentLinks_AssetDocuments1");

                entity.HasOne(d => d.OriginDocument)
                    .WithMany(p => p.AssetDocumentLinksOriginDocument)
                    .HasForeignKey(d => d.OriginDocumentId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_AssetDocumentLinks_AssetDocuments");
            });

            modelBuilder.Entity<AssetDocument>(entity =>
            {
                entity.ToTable("AssetDocuments", "Document");

                entity.Property(e => e.Id).HasDefaultValueSql("newid()");

                entity.HasOne(d => d.Asset)
                    .WithMany(p => p.AssetDocuments)
                    .HasForeignKey(d => d.AssetId)
                    .HasConstraintName("FK_AssetDocuments_Assets");

                entity.HasOne(d => d.Type)
                    .WithMany(p => p.AssetDocuments)
                    .HasForeignKey(d => d.TypeId)
                    .HasConstraintName("FK_AssetDocuments_Types");
            });

            modelBuilder.Entity<ContentTimeBandLock>(entity =>
            {
                entity.ToTable("ContentTimeBandLocks", "Booking");

                entity.HasIndex(e => new { e.ContentId, e.TimeBandId, e.StartDate })
                    .HasName("IX_AssetTimeBandLocks")
                    .IsUnique();

                entity.Property(e => e.Id).HasDefaultValueSql("newid()");

                entity.Property(e => e.EndDate).HasColumnType("date");

                entity.Property(e => e.StartDate)
                    .IsRequired()
                    .HasColumnType("date");

                entity.HasOne(d => d.Content)
                    .WithMany(p => p.ContentTimeBandLocks)
                    .HasForeignKey(d => d.ContentId)
                    .HasConstraintName("FK_AssetTimeBandLocks_Assets");

                entity.HasOne(d => d.TimeBand)
                    .WithMany(p => p.ContentTimeBandLocks)
                    .HasForeignKey(d => d.TimeBandId)
                    .HasConstraintName("FK_AssetTimeBandLocks_TimeBands");
            });
            modelBuilder.Entity<AssetType>(entity =>
            {
                entity.ToTable("AssetType", "MediaAssets");

                entity.Property(e => e.Id).HasDefaultValueSql("newsequentialid()");

                entity.Property(e => e.DefaultPath).HasColumnType("FileName");

                entity.Property(e => e.Description).HasColumnType("ShortDescription");

                entity.Property(e => e.Editable)
                    .HasColumnType("Flag")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnType("Name");

                entity.Property(e => e.Revision)
                    .HasColumnType("timestamp")
                    .ValueGeneratedOnAddOrUpdate();
            });
            modelBuilder.Entity<ContentType>(entity =>
            {
                entity.ToTable("ContentTypes", "Asset");

                entity.HasIndex(e => e.Name)
                    .HasName("IX_Types")
                    .IsUnique();

                entity.Property(e => e.Id).HasDefaultValueSql("newid()");

                entity.Property(e => e.Index).HasDefaultValueSql("99");

                entity.Property(e => e.IsBroadcast).HasDefaultValueSql("1");

                entity.Property(e => e.IsIndexing).HasDefaultValueSql("1");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(256);
                entity.HasOne(d => d.FileType)
                    .WithMany(p => p.AssetTypes)
                    .HasForeignKey(d => d.FileTypeId)
                    .HasConstraintName("FK_AssetTypes_FileTypes");
            });

            modelBuilder.Entity<Content>(entity =>
            {
                entity.ToTable("Content", "MediaAssets");

                entity.Property(e => e.Id).HasDefaultValueSql("newid()");

                entity.Property(e => e.ApproveEndDate).HasColumnType("date");

                entity.Property(e => e.Code)
                    .IsRequired()
                    .HasMaxLength(256);

                entity.Property(e => e.CreateTime)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("getdate()");

                entity.Property(e => e.ProductName).IsRequired();

                //entity.HasOne(d => d.Area)
                //    .WithMany(p => p.Assets)
                //    .HasForeignKey(d => d.AreaId)
                //    .OnDelete(DeleteBehavior.Restrict)
                //    .HasConstraintName("FK_Assets_Areas");

                entity.HasOne(d => d.LastProductModelNavigation)
                    .WithMany(p => p.InverseLastProductModelNavigation)
                    .HasForeignKey(d => d.LastProductModel)
                    .HasConstraintName("FK_Assets_Assets");

                entity.HasOne(d => d.Producer)
                    .WithMany(p => p.Assets)
                    .HasForeignKey(d => d.ProducerId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("FK_Assets_Producers");

                entity.HasOne(d => d.ProductGroup)
                    .WithMany(p => p.Assets)
                    .HasForeignKey(d => d.ProductGroupId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("FK_Assets_ProductGroups");

                entity.HasOne(d => d.Register)
                    .WithMany(p => p.Assets)
                    .HasForeignKey(d => d.RegisterId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("FK_Assets_Registers");

                entity.HasOne(d => d.Type)
                    .WithMany(p => p.Assets)
                    .HasForeignKey(d => d.TypeId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_Assets_Types");                
            });

            modelBuilder.Entity<BookingTypePriceType>(entity =>
            {
                entity.HasKey(e => new { e.BookingTypeId, e.PriceTypeId })
                    .HasName("PK_BookingType_PriceTypes");

                entity.ToTable("BookingType_PriceTypes", "Booking");

                entity.Property(e => e.Index).HasDefaultValueSql("0");

                entity.HasOne(d => d.BookingType)
                    .WithMany(p => p.BookingTypePriceTypes)
                    .HasForeignKey(d => d.BookingTypeId)
                    .HasConstraintName("FK_BookingType_PriceTypes_Types");

                entity.HasOne(d => d.PriceType)
                    .WithMany(p => p.BookingTypePriceTypes)
                    .HasForeignKey(d => d.PriceTypeId)
                    .HasConstraintName("FK_BookingType_PriceTypes_Types1");
            });

            modelBuilder.Entity<BookingType>(entity =>
            {
                entity.ToTable("BookingTypes", "Booking");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(256);

                entity.HasOne(d => d.Parent)
                    .WithMany(p => p.InverseParent)
                    .HasForeignKey(d => d.ParentId)
                    .HasConstraintName("FK_Types_Types");
            });

            modelBuilder.Entity<Channel>(entity =>
            {
                entity.ToTable("Channels", "System");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.HasOne(d => d.TimeBandBase)
                    .WithOne(p => p.Channels)
                    .HasForeignKey<Channel>(d => d.Id)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_Channels_TimeBandBases");
            });

            modelBuilder.Entity<Contract>(entity =>
            {
                entity.ToTable("Contracts", "Contract");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Code)
                    .IsRequired()
                    .HasMaxLength(256);

                entity.Property(e => e.SignDate).HasColumnType("date");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.Contracts)
                    .HasForeignKey(d => d.CustomerId)
                    .HasConstraintName("FK_Contracts_CustomerPartners");
            });

            modelBuilder.Entity<CustomerPartner>(entity =>
            {
                entity.ToTable("CustomerPartners", "Contract");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.AccountNumber).HasMaxLength(50);

                entity.Property(e => e.Code)
                    .IsRequired()
                    .HasMaxLength(256);

                entity.Property(e => e.FaxNumber).HasMaxLength(50);

                entity.Property(e => e.PhoneNumber).HasMaxLength(50);

                entity.Property(e => e.TaxNumber).HasMaxLength(50);

                entity.HasOne(d => d.Customer)
                    .WithOne(p => p.CustomerPartners)
                    .HasForeignKey<CustomerPartner>(d => d.Id)
                    .HasConstraintName("FK_CustomerPartners_Customers");

                entity.HasOne(d => d.Parent)
                    .WithMany(p => p.InverseParent)
                    .HasForeignKey(d => d.ParentId)
                    .HasConstraintName("FK_CustomerPartners_CustomerPartners");
            });

			modelBuilder.Entity<RetailCustomer>(entity =>
			{
				entity.ToTable("RetailCustomers", "Contract");

				entity.Property(e => e.Id).ValueGeneratedNever();

				entity.HasOne(d => d.Customer)
					.WithOne(p => p.RetailCustomer)
					.HasForeignKey<RetailCustomer>(d => d.Id)
					.HasConstraintName("FK_RetailCustomers_Customers");				
			});

			modelBuilder.Entity<CustomerType>(entity =>
            {
                entity.ToTable("CustomerTypes", "Contract");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(256);
            });

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.ToTable("Customers", "Contract");

                entity.Property(e => e.Id).HasDefaultValueSql("newid()");

                entity.Property(e => e.Name).IsRequired();

                entity.HasOne(d => d.Type)
                    .WithMany(p => p.Customers)
                    .HasForeignKey(d => d.TypeId)
                    .HasConstraintName("FK_Customers_CustomerTypes");
            });

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

            modelBuilder.Entity<DiscountAnnexContractAsset>(entity =>
            {
                entity.HasKey(e => new { e.DiscountId, e.AssetId })
                    .HasName("PK_DiscountAnnexContract_Assets");

                entity.ToTable("DiscountAnnexContract_Assets", "Price");

                entity.HasOne(d => d.Asset)
                    .WithMany(p => p.DiscountAnnexContractAssets)
                    .HasForeignKey(d => d.AssetId)
                    .HasConstraintName("FK_DiscountAnnexContract_Assets_Assets");

                entity.HasOne(d => d.Discount)
                    .WithMany(p => p.DiscountAnnexContractAssets)
                    .HasForeignKey(d => d.DiscountId)
                    .HasConstraintName("FK_DiscountAnnexContract_Assets_DiscountAnnexContracts");
            });

            modelBuilder.Entity<DiscountAnnexContractTimeBandBase>(entity =>
            {
                entity.HasKey(e => new { e.DiscountId, e.TimeBandBaseId })
                    .HasName("PK_DiscountAnnexContract_TimeBandBases");

                entity.ToTable("DiscountAnnexContract_TimeBandBases", "Price");

                entity.HasOne(d => d.Discount)
                    .WithMany(p => p.DiscountAnnexContractTimeBandBases)
                    .HasForeignKey(d => d.DiscountId)
                    .HasConstraintName("FK_DiscountAnnexContract_TimeBandBases_DiscountAnnexContracts");

                entity.HasOne(d => d.TimeBandBase)
                    .WithMany(p => p.DiscountAnnexContractTimeBandBases)
                    .HasForeignKey(d => d.TimeBandBaseId)
                    .HasConstraintName("FK_DiscountAnnexContract_TimeBandBases_TimeBandBases");
            });

            modelBuilder.Entity<DiscountAnnexContract>(entity =>
            {
                entity.ToTable("DiscountAnnexContracts", "Price");

                entity.Property(e => e.Id).HasDefaultValueSql("newid()");

                entity.Property(e => e.EndDate).HasColumnType("date");

                entity.Property(e => e.Rate).HasColumnType("decimal");

                entity.Property(e => e.StartDate).HasColumnType("date");

                entity.HasOne(d => d.AnnexContract)
                    .WithMany(p => p.DiscountAnnexContracts)
                    .HasForeignKey(d => d.AnnexContractId)
                    .HasConstraintName("FK_DiscountAnnexContracts_AnnexContractPartners");
            });

            modelBuilder.Entity<DiscountCustomer>(entity =>
            {
                entity.ToTable("DiscountCustomers", "Price");

                entity.HasIndex(e => new { e.CustomerId, e.StartDate })
                    .HasName("IX_DiscountCustomers")
                    .IsUnique();

                entity.Property(e => e.Id).HasDefaultValueSql("newid()");

                entity.Property(e => e.EndDate).HasColumnType("date");

                entity.Property(e => e.Rate).HasColumnType("decimal");

                entity.Property(e => e.StartDate).HasColumnType("date");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.DiscountCustomers)
                    .HasForeignKey(d => d.CustomerId)
                    .HasConstraintName("FK_DiscountCustomers_Customers");
            });

            modelBuilder.Entity<DiscountSponsorProgram>(entity =>
            {
                entity.ToTable("DiscountSponsorPrograms", "Price");

                entity.Property(e => e.Id).HasDefaultValueSql("newid()");

                entity.Property(e => e.EndDate).HasColumnType("date");

                entity.Property(e => e.Rate).HasColumnType("decimal");

                entity.Property(e => e.StartDate).HasColumnType("date");

                entity.HasOne(d => d.Program)
                    .WithMany(p => p.DiscountSponsorPrograms)
                    .HasForeignKey(d => d.ProgramId)
                    .HasConstraintName("FK_DiscountSponsorPrograms_SponsorPrograms");
            });

            modelBuilder.Entity<DocumentType>(entity =>
            {
                entity.ToTable("DocumentTypes", "Document");

                entity.Property(e => e.Id).HasDefaultValueSql("newid()");

                entity.HasOne(d => d.Parent)
                    .WithMany(p => p.InverseParent)
                    .HasForeignKey(d => d.ParentId)
                    .HasConstraintName("FK_Types_Types");
            });

            modelBuilder.Entity<Evidence>(entity =>
            {
                entity.ToTable("Evidences", "System");

                entity.Property(e => e.Id).HasDefaultValueSql("newid()");

                entity.HasOne(d => d.Asset)
                    .WithMany(p => p.Evidences)
                    .HasForeignKey(d => d.AssetId)
                    .HasConstraintName("FK_Evidences_Asset");
                entity.HasOne(d => d.Channel)
                    .WithMany(p => p.Evidences)
                    .HasForeignKey(d => d.ChannelId)
                    .HasConstraintName("FK_Evidences_Channels");
            });

            modelBuilder.Entity<FileContent>(entity =>
            {
                entity.ToTable("FileContents", "Storage");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Content).IsRequired();

                entity.HasOne(d => d.IdNavigation)
                    .WithOne(p => p.FileContents)
                    .HasForeignKey<FileContent>(d => d.Id)
                    .HasConstraintName("FK_FileContents_Files");
            });

            modelBuilder.Entity<FileDetailLocation>(entity =>
            {
                entity.ToTable("FileDetailLocations", "Storage");

                entity.Property(e => e.Id).HasDefaultValueSql("newid()");

                entity.Property(e => e.FileName).IsRequired();

                entity.HasOne(d => d.FileDetail)
                    .WithMany(p => p.FileDetailLocations)
                    .HasForeignKey(d => d.FileDetailId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_FileDetailLocations_FileDetails");

                entity.HasOne(d => d.Location)
                    .WithMany(p => p.FileDetailLocations)
                    .HasForeignKey(d => d.LocationId)
                    .HasConstraintName("FK_FileDetailLocations_Locations");
            });

            modelBuilder.Entity<FileDetail>(entity =>
            {
                entity.ToTable("FileDetails", "Storage");

                entity.Property(e => e.Id).HasDefaultValueSql("newid()");

                entity.HasOne(d => d.File)
                    .WithMany(p => p.FileDetails)
                    .HasForeignKey(d => d.FileId)
                    .HasConstraintName("FK_FileDetails_FileInStorages");
            });

            modelBuilder.Entity<FileInStorage>(entity =>
            {
                entity.ToTable("FileInStorages", "Storage");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.HasOne(d => d.IdNavigation)
                    .WithOne(p => p.FileInStorages)
                    .HasForeignKey<FileInStorage>(d => d.Id)
                    .HasConstraintName("FK_FileInStorages_Files");
            });

            modelBuilder.Entity<FileType>(entity =>
            {
                entity.ToTable("FileTypes", "Storage");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(256);
            });

            modelBuilder.Entity<File>(entity =>
            {
                entity.ToTable("Files", "Storage");

                entity.Property(e => e.Id).HasDefaultValueSql("newid()");

                entity.Property(e => e.CreateTime)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("getdate()");

                entity.HasOne(d => d.FileType)
                    .WithMany(p => p.Files)
                    .HasForeignKey(d => d.FileTypeId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_Files_FileTypes");
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

            //modelBuilder.Entity<Group>(entity =>
            //{
            //    entity.ToTable("Groups", "Security");

            //    entity.HasIndex(e => e.Name)
            //        .HasName("GroupNameIndex");

            //    entity.HasIndex(e => new { e.Name, e.ParentId })
            //        .HasName("Group_ParentAndGroupNameUnique")
            //        .IsUnique();

            //    entity.Property(e => e.Id).HasDefaultValueSql("newid()");

            //    entity.Property(e => e.Name)
            //        .IsRequired()
            //        .HasMaxLength(256);

            //    entity.Property(e => e.ParentId).IsRequired();

            //    entity.HasOne(d => d.Parent)
            //        .WithMany(p => p.Childrens)
            //        .HasForeignKey(d => d.ParentId)
            //        .OnDelete(DeleteBehavior.Restrict)
            //        .HasConstraintName("FK_Groups_Groups");
            //});

            modelBuilder.Entity<LocationAccessZone>(entity =>
            {
                entity.ToTable("LocationAccessZones", "Storage");

                entity.Property(e => e.Id).HasDefaultValueSql("newid()");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(256);

                entity.HasOne(d => d.AccessZone)
                    .WithMany(p => p.LocationAccessZones)
                    .HasForeignKey(d => d.AccessZoneId)
                    .HasConstraintName("FK_LocationAccessZones_AccessZones");

                entity.HasOne(d => d.Location)
                    .WithMany(p => p.LocationAccessZones)
                    .HasForeignKey(d => d.LocationId)
                    .HasConstraintName("FK_LocationAccessZones_Locations");
            });
            modelBuilder.Entity<LocationAccessZoneUri>(entity =>
            {
                entity.ToTable("LocationAccessZoneUris", "Storage");

                entity.Property(e => e.Id).HasDefaultValueSql("newid()");

                entity.Property(e => e.Value)
                    .IsRequired()
                    .HasMaxLength(256);

                entity.HasOne(d => d.LocationAccessZone)
                    .WithMany(p => p.LocationAccessZoneUri)
                    .HasForeignKey(d => d.LocationAccessZoneId)
                    .HasConstraintName("FK_LocationAccessZoneUris_AccessZones");

                entity.HasOne(d => d.UriType)
                    .WithMany(p => p.LocationAccessZoneUri)
                    .HasForeignKey(d => d.UriTypeId)
                    .HasConstraintName("FK_LocationAccessZoneUris_Locations");
            });
            modelBuilder.Entity<Location>(entity =>
            {
                entity.ToTable("Locations", "Storage");

                entity.Property(e => e.Id).HasDefaultValueSql("newid()");

                entity.Property(e => e.CanUpload).HasDefaultValueSql("0");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(256);

                entity.HasOne(d => d.FileType)
                    .WithMany(p => p.Locations)
                    .HasForeignKey(d => d.FileTypeId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_Locations_FileTypes");

                entity.HasOne(d => d.Storage)
                    .WithMany(p => p.Locations)
                    .HasForeignKey(d => d.StorageId)
                    .HasConstraintName("FK_Locations_Storages");
            });
            modelBuilder.Entity<MediaAsset>(entity =>
            {
                entity.ToTable("MediaAsset", "MediaAssets");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.ContainerFormat).HasMaxLength(256);

                entity.Property(e => e.Framerate_Demoniator).HasColumnName("Framerate_Demoniator");

                entity.Property(e => e.Framerate_Numerator).HasColumnName("Framerate_Numerator");
            });
            modelBuilder.Entity<MimeType>(entity =>
            {
                entity.HasKey(e => e.InternetMediaType)
                    .HasName("PK_MineType");

                entity.ToTable("MimeType", "MediaAssets");

                entity.Property(e => e.InternetMediaType).HasColumnType("Name");

                entity.Property(e => e.FileExtension).HasMaxLength(256);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnType("Name");

                entity.Property(e => e.Reference).HasColumnType("URI");
            });
            //modelBuilder.Entity<MenuPermission>(entity =>
            //{
            //    entity.HasKey(e => new { e.MenuId, e.PermissionId })
            //        .HasName("PK_Menu_RolePermissions");

            //    entity.ToTable("Menu_Permissions", "UI");

            //    entity.HasOne(d => d.Menu)
            //        .WithMany(p => p.MenuPermissions)
            //        .HasForeignKey(d => d.MenuId)
            //        .HasConstraintName("FK_Menu_Permissions_Menus");

            //    entity.HasOne(d => d.Permission)
            //        .WithMany(p => p.MenuPermissions)
            //        .HasForeignKey(d => d.PermissionId)
            //        .HasConstraintName("FK_Menu_Permissions_Permissions");
            //});

            //modelBuilder.Entity<Menu>(entity =>
            //{
            //    entity.ToTable("Menus", "UI");

            //    entity.HasIndex(e => e.Index)
            //        .HasName("MenuIndexIndex");

            //    entity.HasIndex(e => new { e.ParentId, e.Name })
            //        .HasName("MenuParent_NameIndex")
            //        .IsUnique();

            //    entity.Property(e => e.Id).HasDefaultValueSql("newid()");

            //    entity.Property(e => e.GroupIndex).HasDefaultValueSql("0");

            //    entity.Property(e => e.Index).HasDefaultValueSql("0");

            //    entity.Property(e => e.Name)
            //        .IsRequired()
            //        .HasMaxLength(50);

            //    entity.Property(e => e.ParentId).IsRequired();

            //    entity.HasOne(d => d.Parent)
            //        .WithMany(p => p.Childrens)
            //        .HasForeignKey(d => d.ParentId)
            //        .OnDelete(DeleteBehavior.Restrict)
            //        .HasConstraintName("FK_Menus_Menus");
            //});

            modelBuilder.Entity<Origin>(entity =>
            {
                entity.ToTable("Origins", "Media");

                entity.Property(e => e.Id).HasDefaultValueSql("newid()");

                entity.Property(e => e.CreateTime)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("getdate()");

                entity.HasOne(d => d.File)
                    .WithMany(p => p.Origins)
                    .HasForeignKey(d => d.FileId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_Origins_Files");
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

            //modelBuilder.Entity<Permission>(entity =>
            //{
            //    entity.ToTable("Permissions", "Security");

            //    entity.HasIndex(e => e.ParentId)
            //        .HasName("IX_Permissions_1");

            //    entity.HasIndex(e => e.Type)
            //        .HasName("IX_Permissions");

            //    entity.HasIndex(e => e.Value)
            //        .HasName("IX_Permissions_2");

            //    entity.Property(e => e.Id).HasDefaultValueSql("newid()");

            //    entity.Property(e => e.Index).HasDefaultValueSql("-1");

            //    entity.Property(e => e.Type)
            //        .IsRequired()
            //        .HasMaxLength(256);

            //    entity.Property(e => e.Value)
            //        .IsRequired()
            //        .HasMaxLength(256);

            //    entity.HasOne(d => d.Parent)
            //        .WithMany(p => p.Childrens)
            //        .HasForeignKey(d => d.ParentId)
            //        .HasConstraintName("FK_Permissions_Permissions");
            //});

            modelBuilder.Entity<PositionRate>(entity =>
            {
                entity.ToTable("PositionRates", "Price");

                entity.HasIndex(e => new { e.TimeBandId, e.StartDate })
                    .HasName("IX_PositionRates")
                    .IsUnique();

                entity.Property(e => e.Id).HasDefaultValueSql("newid()");

                entity.Property(e => e.EndDate).HasColumnType("date");

                entity.Property(e => e.Rate).HasColumnType("decimal");

                entity.Property(e => e.StartDate).HasColumnType("date");

                entity.Property(e => e.TimeBandId).IsRequired();

                entity.HasOne(d => d.TimeBand)
                    .WithMany(p => p.PositionRates)
                    .HasForeignKey(d => d.TimeBandId)
                    .HasConstraintName("FK_PositionRates_TimeBands");
            });

            modelBuilder.Entity<Position>(entity =>
            {
                entity.ToTable("Positions", "Price");

                entity.HasIndex(e => e.StartDate)
                    .HasName("IX_Positions")
                    .IsUnique();

                entity.Property(e => e.Id).HasDefaultValueSql("newid()");

                entity.Property(e => e.StartDate).HasColumnType("date");
            });

            modelBuilder.Entity<PriceType>(entity =>
            {
                entity.ToTable("PriceTypes", "Price");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Name).IsRequired();
            });

            modelBuilder.Entity<Producer>(entity =>
            {
                entity.ToTable("Producers", "Asset");

                entity.Property(e => e.Id).HasDefaultValueSql("newid()");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(256);

                entity.HasOne(d => d.Parent)
                    .WithMany(p => p.InverseParent)
                    .HasForeignKey(d => d.ParentId)
                    .HasConstraintName("FK_Producers_Producers");
            });

            modelBuilder.Entity<ProductGroupDocumentRequest>(entity =>
            {
                entity.HasKey(e => new { e.ProductGroupId, e.DocumentTypeId })
                    .HasName("PK_ProductGroupDocumentRequests_1");

                entity.ToTable("ProductGroupDocumentRequests", "Document");

                entity.HasOne(d => d.DocumentType)
                    .WithMany(p => p.ProductGroupDocumentRequests)
                    .HasForeignKey(d => d.DocumentTypeId)
                    .HasConstraintName("FK_ProductGroupDocumentRequests_Types");

                entity.HasOne(d => d.ProductGroup)
                    .WithMany(p => p.ProductGroupDocumentRequests)
                    .HasForeignKey(d => d.ProductGroupId)
                    .HasConstraintName("FK_ProductGroupDocumentRequests_ProductGroups");
            });

            modelBuilder.Entity<ProductGroup>(entity =>
            {
                entity.ToTable("ProductGroups", "Asset");

                entity.HasIndex(e => e.Code)
                    .HasName("IX_ProductGroups")
                    .IsUnique();

                entity.HasIndex(e => new { e.ParentId, e.Name })
                    .HasName("IX_ProductGroups_1")
                    .IsUnique();

                entity.Property(e => e.Id).HasDefaultValueSql("newid()");

                entity.Property(e => e.Code)
                    .IsRequired()
                    .HasMaxLength(256);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(256);

                entity.Property(e => e.ParentId).IsRequired();

                entity.HasOne(d => d.Parent)
                    .WithMany(p => p.InverseParent)
                    .HasForeignKey(d => d.ParentId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_ProductGroups_ProductGroups");
            });

            modelBuilder.Entity<RateSpotBlock>(entity =>
            {
                entity.ToTable("RateSpotBlocks", "Price");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Rate).HasColumnType("decimal");

                entity.HasOne(d => d.TypeDetail)
                    .WithOne(p => p.RateSpotBlocks)
                    .HasForeignKey<RateSpotBlock>(d => d.Id)
                    .HasConstraintName("FK_RateSpotBlocks_TypeDetails");

                entity.HasOne(d => d.SpotBlock)
                    .WithMany(p => p.RateSpotBlocks)
                    .HasForeignKey(d => d.SpotBlockId)
                    .HasConstraintName("FK_RateSpotBlockTypes_SpotBlocks");
            });

            modelBuilder.Entity<Register>(entity =>
            {
                entity.ToTable("Registers", "Asset");

                entity.HasIndex(e => e.Name)
                    .HasName("IX_Registers_1")
                    .IsUnique();

                entity.Property(e => e.Id).HasDefaultValueSql("newid()");

                entity.Property(e => e.Code).HasMaxLength(10);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(256);
            });

            modelBuilder.Entity<RetailPrice>(entity =>
            {
                entity.ToTable("RetailPrices", "Price");

                entity.HasIndex(e => new { e.RetailTypeId, e.StartDate })
                    .HasName("IX_RetailPrices")
                    .IsUnique();

                entity.Property(e => e.Id).HasDefaultValueSql("newid()");

                entity.Property(e => e.Price).HasColumnType("numeric");

                entity.Property(e => e.StartDate).HasColumnType("date");

                entity.HasOne(d => d.RetailType)
                    .WithMany(p => p.RetailPrices)
                    .HasForeignKey(d => d.RetailTypeId)
                    .HasConstraintName("FK_RetailPrices_RetailTypes");
            });

            modelBuilder.Entity<RetailType>(entity =>
            {
                entity.ToTable("RetailTypes", "Price");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.HasOne(d => d.TypeDetail)
                    .WithOne(p => p.RetailTypes)
                    .HasForeignKey<RetailType>(d => d.Id)
                    .HasConstraintName("FK_Test_TypeDetails");
            });

            modelBuilder.Entity<SceneFile>(entity =>
            {
                entity.ToTable("SceneFiles", "Media");

                entity.Property(e => e.Id).HasDefaultValueSql("newid()");

                entity.HasOne(d => d.File)
                    .WithMany(p => p.SceneFiles)
                    .HasForeignKey(d => d.FileId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_BroadcastFiles_Files");

                entity.HasOne(d => d.Scene)
                    .WithMany(p => p.SceneFiles)
                    .HasForeignKey(d => d.SceneId)
                    .HasConstraintName("FK_BroadcastFiles_Broadcasts");
            });

            modelBuilder.Entity<ApplicationCore.Entities.Scene>(entity =>
            {
                entity.ToTable("Scenes", "Media");

                entity.Property(e => e.Id).HasDefaultValueSql("newid()");

                entity.Property(e => e.StartFrame).HasDefaultValueSql("0");

                entity.HasOne(d => d.Origin)
                    .WithMany(p => p.Scenes)
                    .HasForeignKey(d => d.OriginId)
                    .HasConstraintName("FK_Broadcasts_Origins");
            });
            modelBuilder.Entity<ApplicationCore.Entities.MediaAsset.Scene>(entity =>
            {
                entity.ToTable("Scene", "MediaAssets");

                entity.Property(e => e.Id).HasDefaultValueSql("newid()");

                entity.Property(e => e.LastEdited).HasDefaultValueSql("getdate()");

                entity.Property(e => e.Text)
                    .IsRequired()
                    .HasMaxLength(500);

                entity.HasOne(d => d.Asset)
                    .WithMany(p => p.Scenes)
                    .HasForeignKey(d => d.AssetId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_Scene_Asset");
            });
            modelBuilder.Entity<SponsorProgram>(entity =>
            {
                entity.ToTable("SponsorPrograms", "System");

                entity.HasIndex(e => e.Code)
                    .HasName("IX_SponsorPrograms")
                    .IsUnique();

                entity.HasIndex(e => e.Name)
                    .HasName("IX_SponsorPrograms_1");

                entity.Property(e => e.Id).HasDefaultValueSql("newid()");

                entity.Property(e => e.Code)
                    .IsRequired()
                    .HasMaxLength(256);

                entity.Property(e => e.EndDate).HasColumnType("date");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(256);

                entity.HasOne(d => d.Parent)
                    .WithMany(p => p.InverseParent)
                    .HasForeignKey(d => d.ParentId)
                    .HasConstraintName("FK_SponsorPrograms_SponsorPrograms");

				entity.HasOne(d => d.AnnexContractType)
					.WithMany(p => p.SponsorPrograms)
					.HasForeignKey(d => d.DefaultContractTypeId)
					.HasConstraintName("FK_SponsorPrograms_AnnexContractTypes");
			});

            modelBuilder.Entity<SponsorType>(entity =>
            {
                entity.ToTable("SponsorTypes", "Contract");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(256);
            });

            modelBuilder.Entity<SpotApprove>(entity =>
            {
                entity.ToTable("SpotApproves", "Booking");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.HasOne(d => d.IdNavigation)
                    .WithOne(p => p.SpotApproves)
                    .HasForeignKey<SpotApprove>(d => d.Id)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_SpotApproves_SpotBookings");
            });

            modelBuilder.Entity<SpotBlockRate>(entity =>
            {
                entity.ToTable("SpotBlockRates", "Price");

                entity.HasIndex(e => new { e.SpotBlockId, e.StartDate })
                    .HasName("IX_SpotBlockRates")
                    .IsUnique();

                entity.Property(e => e.Id).HasDefaultValueSql("newid()");

                entity.Property(e => e.Rate).HasColumnType("decimal");

                entity.Property(e => e.StartDate).HasColumnType("date");

                entity.HasOne(d => d.SpotBlock)
                    .WithMany(p => p.SpotBlockRates)
                    .HasForeignKey(d => d.SpotBlockId)
                    .HasConstraintName("FK_SpotBlockRates_SpotBlocks");
            });

            modelBuilder.Entity<SpotBlock>(entity =>
            {
                entity.ToTable("SpotBlocks", "System");

                entity.HasIndex(e => e.Duration)
                    .HasName("IX_SpotBlock")
                    .IsUnique();

                entity.Property(e => e.Id).HasDefaultValueSql("newid()");
            });

            modelBuilder.Entity<SpotBooking>(entity =>
            {
                entity.ToTable("SpotBookings", "Booking");

                entity.Property(e => e.Id).HasDefaultValueSql("newid()");

                entity.Property(e => e.BookingDate)
                    .HasColumnType("date")
                    .HasDefaultValueSql("getdate()");

                entity.Property(e => e.CalcTime).HasColumnType("datetime");

				entity.Property(e => e.IsPositionCost).HasColumnName("PositionCost")
				.HasColumnType("bit"); // TODO: Rename columnName in database to IsPositionCost

				entity.Property(e => e.CardRateCalc).HasColumnType("decimal");

                entity.Property(e => e.CardRateSet).HasColumnType("decimal");

                entity.Property(e => e.DiscountRateCalc).HasColumnType("decimal");

                entity.Property(e => e.DiscountRateSet).HasColumnType("decimal");

                entity.Property(e => e.PositionRateCalc).HasColumnType("decimal");

                entity.Property(e => e.PositionRateSet).HasColumnType("decimal");

                entity.HasOne(d => d.AnnexContractAsset)
                    .WithMany(p => p.SpotBookings)
                    .HasForeignKey(d => d.AnnexContractAssetId)
                    .HasConstraintName("FK_SpotBookings_AnnexContractAssets");

                entity.HasOne(d => d.SpotBookingRequest)
                    .WithMany(p => p.InverseSpotBookingRequest)
                    .HasForeignKey(d => d.SpotBookingRequestId)
                    .HasConstraintName("FK_SpotBookings_SpotBookings");

                entity.HasOne(d => d.Spot)
                    .WithMany(p => p.SpotBookings)
                    .HasForeignKey(d => d.SpotId)
                    .HasConstraintName("FK_SpotBookings_Spots");
            });

            modelBuilder.Entity<Spot>(entity =>
            {
                entity.ToTable("Spots", "Schedule");

                entity.HasIndex(e => new { e.BroadcastDate, e.TimeBandSliceId })
                    .HasName("IX_Spots")
                    .IsUnique();

                entity.Property(e => e.Id).HasDefaultValueSql("newid()");

                entity.Property(e => e.BroadcastDate).HasColumnType("date");

                entity.HasOne(d => d.TimeBandSlice)
                    .WithMany(p => p.Spots)
                    .HasForeignKey(d => d.TimeBandSliceId)
                    .HasConstraintName("FK_Spots_TimeBandSlices");
            });

            //modelBuilder.Entity<Storage>(entity =>
            //{
            //    entity.ToTable("Storages", "Storage");

            //    entity.Property(e => e.Id).HasDefaultValueSql("newid()");

            //    entity.Property(e => e.Name)
            //        .IsRequired()
            //        .HasMaxLength(256);
            //});
            modelBuilder.Entity<ApplicationCore.Entities.MediaAsset.Storage>(entity =>
            {
                entity.ToTable("Storage", "MediaAssets");

                entity.Property(e => e.Id).HasDefaultValueSql("newsequentialid()");

                entity.Property(e => e.Description).HasColumnType("ShortDescription");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnType("Name");
            });

            modelBuilder.Entity<StorageLocation>(entity =>
            {
                entity.ToTable("StorageLocation", "MediaAssets");

                entity.Property(e => e.Id).HasDefaultValueSql("newsequentialid()");

                entity.Property(e => e.Description).HasColumnType("ShortDescription");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnType("Name");

                entity.Property(e => e.Path).HasColumnType("URI");

                entity.Property(e => e.StorageType).HasColumnType("StorageType");

                entity.Property(e => e.StorageTypeDescription)
                    .HasMaxLength(32)
                    .HasComputedColumnSql("[MediaAssets].[FN_GetStorageTypeDescription]([StorageType])")
                    .ValueGeneratedOnAddOrUpdate();

                entity.Property(e => e.UncPath).HasColumnType("URI");

                entity.HasOne(d => d.AssetType)
                    .WithMany(p => p.StorageLocations)
                    .HasForeignKey(d => d.AssetTypeId)
                    .HasConstraintName("FK_StorageLocation_AssetType");

                entity.HasOne(d => d.Storage)
                    .WithMany(p => p.StorageLocations)
                    .HasForeignKey(d => d.StorageId)
                    .HasConstraintName("FK_StorageLocation_Storage");
            });

            modelBuilder.Entity<StorageLocationAccess>(entity =>
            {
                entity.ToTable("StorageLocationAccess", "MediaAssets");

                entity.Property(e => e.Id).HasDefaultValueSql("newsequentialid()");

                entity.Property(e => e.Description).HasColumnType("ShortDescription");

                entity.Property(e => e.Host).HasMaxLength(50);

                entity.Property(e => e.Identity)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnType("Name");

                entity.Property(e => e.Password).HasMaxLength(50);

                entity.Property(e => e.Path).HasMaxLength(500);

                entity.Property(e => e.Readable).HasDefaultValueSql("1");

                entity.Property(e => e.Writeable).HasDefaultValueSql("1");

                entity.HasOne(d => d.StorageLocation)
                    .WithMany(p => p.StorageLocationAccesses)
                    .HasForeignKey(d => d.StorageLocationId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_StorageLocationAccess_StorageLocation");
                entity.HasOne(d => d.StorageLocationAccessType)
                    .WithMany(p => p.StorageLocationAccesses)
                    .HasForeignKey(d => d.StorageLocationAccessTypeId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_StorageLocationAccess_StorageLocationAccessType");
            });
            modelBuilder.Entity<StorageLocationAccessType>(entity =>
            {
                entity.ToTable("StorageLocationAccessType", "MediaAssets");

                entity.Property(e => e.Id).HasDefaultValueSql("newsequentialid()");

            });
            modelBuilder.Entity<StorageLocationAccessZone>(entity =>
            {
                entity.ToTable("StorageLocationAccessZone", "MediaAssets");

                entity.Property(e => e.Id).HasDefaultValueSql("newsequentialid()");

                entity.HasOne(d => d.AccessZone)
                    .WithMany(p => p.StorageLocationAccessZones)
                    .HasForeignKey(d => d.AccessZoneId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_StorageLocationAccessZone_AcessZone");

                entity.HasOne(d => d.StorageLocationAccess)
                    .WithMany(p => p.StorageLocationAccessZones)
                    .HasForeignKey(d => d.StorageLocationAccessId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_StorageLocationAccessZone_StorageLocationAccess");
            });
            modelBuilder.Entity<TimeBandBase>(entity =>
            {
                entity.ToTable("TimeBandBases", "System");

                entity.HasIndex(e => e.Name)
                    .HasName("IX_Groups");

                entity.HasIndex(e => new { e.ParentId, e.Name })
                    .HasName("IX_Groups_1")
                    .IsUnique();

                entity.Property(e => e.Id).HasDefaultValueSql("newid()");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(256);

                entity.Property(e => e.ParentId).IsRequired();

                entity.HasOne(d => d.Parent)
                    .WithMany(p => p.InverseParent)
                    .HasForeignKey(d => d.ParentId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_Groups_Groups");
            });

            modelBuilder.Entity<TimeBandDay>(entity =>
            {
                entity.ToTable("TimeBandDays", "System");

                entity.HasIndex(e => new { e.TimeBandId, e.StartDate })
                    .HasName("IX_TimeBandDays");

                entity.Property(e => e.Id).HasDefaultValueSql("newid()");

                entity.Property(e => e.DayOfWeeks).HasDefaultValueSql("0");

                entity.Property(e => e.EndDate).HasColumnType("date");

                entity.Property(e => e.StartDate).HasColumnType("date");

                entity.HasOne(d => d.TimeBand)
                    .WithMany(p => p.TimeBandDays)
                    .HasForeignKey(d => d.TimeBandId)
                    .HasConstraintName("FK_TimeBandDays_TimeBands");
            });

            modelBuilder.Entity<TimeBandDescription>(entity =>
            {
                entity.ToTable("TimeBandDescriptions", "System");

                entity.HasIndex(e => new { e.TimeBandId, e.StartDate })
                    .HasName("IX_TimeBandDescriptions")
                    .IsUnique();

                entity.Property(e => e.Id).HasDefaultValueSql("newid()");

                entity.Property(e => e.Description).IsRequired();

                entity.Property(e => e.EndDate).HasColumnType("date");

                entity.Property(e => e.StartDate).HasColumnType("date");

                entity.HasOne(d => d.TimeBand)
                    .WithMany(p => p.TimeBandDescriptions)
                    .HasForeignKey(d => d.TimeBandId)
                    .HasConstraintName("FK_TimeBandDescriptions_TimeBands");
            });

            modelBuilder.Entity<TimeBandPrice>(entity =>
            {
                entity.ToTable("TimeBandPrices", "Price");

                entity.HasIndex(e => new { e.TimeBandId, e.SpotBlockId, e.StartDate })
                    .HasName("IX_TimeBandPrices")
                    .IsUnique();

                entity.Property(e => e.Id).HasDefaultValueSql("newid()");

                entity.Property(e => e.Price).HasColumnType("decimal");

                entity.Property(e => e.SpotBlockId).IsRequired();

                entity.Property(e => e.StartDate).HasColumnType("date");

                entity.HasOne(d => d.SpotBlock)
                    .WithMany(p => p.TimeBandPrices)
                    .HasForeignKey(d => d.SpotBlockId)
                    .HasConstraintName("FK_TimeBandPrices_SpotBlocks");

                entity.HasOne(d => d.TimeBand)
                    .WithMany(p => p.TimeBandPrices)
                    .HasForeignKey(d => d.TimeBandId)
                    .HasConstraintName("FK_TimeBandPrices_TimeBands");
            });

            modelBuilder.Entity<TimeBandSliceDescription>(entity =>
            {
                entity.ToTable("TimeBandSliceDescriptions", "System");

                entity.HasIndex(e => new { e.TimeBandSliceId, e.StartDate })
                    .HasName("IX_TimeBandSliceDescriptions")
                    .IsUnique();

                entity.Property(e => e.Id).HasDefaultValueSql("newid()");

                entity.Property(e => e.Description).IsRequired();

                entity.Property(e => e.EndDate).HasColumnType("date");

                entity.Property(e => e.StartDate).HasColumnType("date");

                entity.HasOne(d => d.TimeBandSlice)
                    .WithMany(p => p.TimeBandSliceDescriptions)
                    .HasForeignKey(d => d.TimeBandSliceId)
                    .HasConstraintName("FK_TimeBandSliceDescriptions_TimeBandSlices");
            });

            modelBuilder.Entity<TimeBandSliceDurationByType>(entity =>
            {
                entity.ToTable("TimeBandSliceDurationByTypes", "Booking");

                entity.HasIndex(e => new { e.TimeBandSliceDurationId, e.TypeId })
                    .HasName("IX_TimeBandSliceDurationByTypes")
                    .IsUnique();

                entity.Property(e => e.Id).HasDefaultValueSql("newid()");

                entity.Property(e => e.Duration).HasDefaultValueSql("0");

                entity.HasOne(d => d.TimeBandSliceDuration)
                    .WithMany(p => p.TimeBandSliceDurationByTypes)
                    .HasForeignKey(d => d.TimeBandSliceDurationId)
                    .HasConstraintName("FK_TimeBandSliceDurationByTypes_TimeBandSliceDurations");

                entity.HasOne(d => d.Type)
                    .WithMany(p => p.TimeBandSliceDurationByTypes)
                    .HasForeignKey(d => d.TypeId)
                    .HasConstraintName("FK_TimeBandSliceDurationByTypes_Types");
            });

            modelBuilder.Entity<TimeBandSliceDuration>(entity =>
            {
                entity.ToTable("TimeBandSliceDurations", "Booking");

                entity.HasIndex(e => new { e.TimeBandSliceId, e.StartDate })
                    .HasName("IX_TimeBandSliceDurations")
                    .IsUnique();

                entity.Property(e => e.Id).HasDefaultValueSql("newid()");

                entity.Property(e => e.Duration).HasDefaultValueSql("0");

                entity.Property(e => e.EndDate).HasColumnType("date");

                entity.Property(e => e.StartDate).HasColumnType("date");

                entity.HasOne(d => d.TimeBandSlice)
                    .WithMany(p => p.TimeBandSliceDurations)
                    .HasForeignKey(d => d.TimeBandSliceId)
                    .HasConstraintName("FK_TimeBandSliceDurations_TimeBandSlices");
            });

            modelBuilder.Entity<TimeBandSliceForType>(entity =>
            {
                entity.ToTable("TimeBandSliceForTypes", "Booking");

                entity.HasIndex(e => new { e.TimeBandSliceId, e.TypeId, e.StartDate })
                    .HasName("IX_TimeBandSliceForTypes")
                    .IsUnique();

                entity.Property(e => e.Id).HasDefaultValueSql("newid()");

                entity.Property(e => e.EndDate).HasColumnType("date");

                entity.Property(e => e.StartDate).HasColumnType("date");

                entity.HasOne(d => d.TimeBandSlice)
                    .WithMany(p => p.TimeBandSliceForTypes)
                    .HasForeignKey(d => d.TimeBandSliceId)
                    .HasConstraintName("FK_TimeBandSliceForTypes_TimeBandSlices");

                entity.HasOne(d => d.Type)
                    .WithMany(p => p.TimeBandSliceForTypes)
                    .HasForeignKey(d => d.TypeId)
                    .HasConstraintName("FK_TimeBandSliceForTypes_Types");
            });

            modelBuilder.Entity<TimeBandSlice>(entity =>
            {
                entity.ToTable("TimeBandSlices", "System");

                entity.HasIndex(e => new { e.TimeBandId, e.Name })
                    .HasName("IX_TimeBandSlices")
                    .IsUnique();

                entity.Property(e => e.Id).HasDefaultValueSql("newid()");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(256);

                entity.HasOne(d => d.TimeBand)
                    .WithMany(p => p.TimeBandSlices)
                    .HasForeignKey(d => d.TimeBandId)
                    .HasConstraintName("FK_TimeBandSlices_TimeBands");
            });

            modelBuilder.Entity<TimeBandTime>(entity =>
            {
                entity.ToTable("TimeBandTimes", "System");

                entity.HasIndex(e => new { e.TimeBandId, e.StartDate })
                    .HasName("IX_TimeBandTimes");

                entity.Property(e => e.Id).HasDefaultValueSql("newid()");

                entity.Property(e => e.EndDate).HasColumnType("date");

                entity.Property(e => e.StartDate).HasColumnType("date");

                entity.Property(e => e.StartTimeOfDay).HasColumnType("time(0)");

                entity.HasOne(d => d.TimeBand)
                    .WithMany(p => p.TimeBandTimes)
                    .HasForeignKey(d => d.TimeBandId)
                    .HasConstraintName("FK_TimeBandTimes_TimeBands");
            });

            modelBuilder.Entity<TimeBand>(entity =>
            {
                entity.ToTable("TimeBands", "System");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.HasOne(d => d.TimeBandBase)
                    .WithOne(p => p.TimeBands)
                    .HasForeignKey<TimeBand>(d => d.Id)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_TimeBands_Groups");
            });

            modelBuilder.Entity<TypeDetail>(entity =>
            {
                entity.ToTable("TypeDetails", "Price");

                entity.Property(e => e.Id).HasDefaultValueSql("newid()");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(256);

                entity.HasOne(d => d.Type)
                    .WithMany(p => p.TypeDetails)
                    .HasForeignKey(d => d.TypeId)
                    .HasConstraintName("FK_TypeDetails_Types");
            });

            modelBuilder.Entity<User_Permission>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.PermissionId })
                    .HasName("PK_User_Permissions");

                //entity.ToTable("User_Permissions", "Security");

                //entity.HasOne(d => d.Permission)
                //    .WithMany(p => p.UserPermissions)
                //    .HasForeignKey(d => d.PermissionId)
                //    .HasConstraintName("FK_User_Permissions_Permissions");

                //entity.HasOne(d => d.User)
                //    .WithMany(p => p.UserPermissions)
                //    .HasForeignKey(d => d.UserId)
                //    .HasConstraintName("FK_User_Permissions_Users");
            });

            //modelBuilder.Entity<User>(entity =>
            //{
            //    entity.ToTable("Users", "Security");

            //    entity.HasIndex(e => e.Name)
            //        .HasName("User_UserNameIndex")
            //        .IsUnique();

            //    entity.Property(e => e.Id).HasDefaultValueSql("newid()");

            //    entity.Property(e => e.Active).HasDefaultValueSql("0");

            //    entity.Property(e => e.Email).HasMaxLength(256);

            //    entity.Property(e => e.Name)
            //        .IsRequired()
            //        .HasMaxLength(256);

            //    entity.Property(e => e.PasswordHash).IsRequired();

            //    entity.Property(e => e.PhoneNumber).HasMaxLength(50);
            //});

            modelBuilder.Entity<ApplicationCore.Entities.Version>(entity =>
            {
                entity.ToTable("Versions", "Media");

                entity.HasIndex(e => new { e.AssetId, e.Active })
                    .HasName("IX_Versions_Active")
                    .IsUnique();

                entity.HasIndex(e => new { e.AssetId, e.Versions })
                    .HasName("IX_Versions")
                    .IsUnique();

                entity.Property(e => e.Id).HasDefaultValueSql("newid()");

                entity.Property(e => e.Active).HasDefaultValueSql("0");

                entity.Property(e => e.CreateTime)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("getdate()");

                entity.Property(e => e.Versions).HasDefaultValueSql("0");

                entity.HasOne(d => d.Asset)
                    .WithMany(p => p.Versions)
                    .HasForeignKey(d => d.AssetId)
                    .HasConstraintName("FK_Versions_Assets");

                entity.HasOne(d => d.Scene)
                    .WithMany(p => p.Versions)
                    .HasForeignKey(d => d.SceneId)
                    .HasConstraintName("FK_Versions_Broadcasts");
            });
			modelBuilder.Entity<Template>(entity =>
			{
				entity.ToTable("Templates", "Schedule");

				entity.Property(e => e.Id).HasDefaultValueSql("newid()");

				entity.Property(e => e.Name)
					.IsRequired()
					.HasMaxLength(256);
			});
			modelBuilder.Entity<TimeBandBaseScheduleTemplate>(entity =>
			{
				entity.ToTable("TimeBandBase_ScheduleTemplates", "Schedule");

				entity.HasIndex(e => new { e.TimeBandBaseId, e.ScheduleTemplateId, e.StartDate })
					.HasName("IX_TimeBandBase_ScheduleTemplates")
					.IsUnique();

				entity.Property(e => e.Id).HasDefaultValueSql("newid()");

				entity.Property(e => e.EndDate).HasColumnType("date");

				entity.Property(e => e.StartDate).HasColumnType("date");

				entity.HasOne(d => d.ScheduleTemplate)
					.WithMany(p => p.TimeBandBaseScheduleTemplates)
					.HasForeignKey(d => d.ScheduleTemplateId)
					.HasConstraintName("FK_TimeBandBase_ScheduleTemplates_Templates");

				entity.HasOne(d => d.TimeBandBase)
					.WithMany(p => p.TimeBandBaseScheduleTemplates)
					.HasForeignKey(d => d.TimeBandBaseId)
					.HasConstraintName("FK_TimeBandBase_ScheduleTemplates_TimeBandBases");
			});
			modelBuilder.Entity<TemplateItem>(entity =>
			{
				entity.ToTable("TemplateItems", "Schedule");

				entity.Property(e => e.Id).HasDefaultValueSql("newid()");

				entity.Property(e => e.Name)
					.IsRequired()
					.HasMaxLength(256);

				entity.HasOne(d => d.Template)
					.WithMany(p => p.TemplateItems)
					.HasForeignKey(d => d.TemplateId)
					.HasConstraintName("FK_TemplateItems_Templates");
			});
			modelBuilder.Entity<TemplateItemAssetTypeRequest>(entity =>
			{
				entity.Property(e => e.Id).HasDefaultValueSql("newid()");

				entity.HasIndex(e => new { e.TemplateItemId, e.AssetTypeId })
					.HasName("PK_TemplateItemAssetTypeRequests")
					.IsUnique();

				entity.ToTable("TemplateItemAssetTypeRequests", "Schedule");

				entity.HasOne(d => d.AssetType)
					.WithMany(p => p.TemplateItemAssetTypeRequests)
					.HasForeignKey(d => d.AssetTypeId)
					.HasConstraintName("FK_TemplateItemAssetTypeRequests_Types");

				entity.HasOne(d => d.TemplateItem)
					.WithMany(p => p.TemplateItemAssetTypeRequests)
					.HasForeignKey(d => d.TemplateItemId)
					.HasConstraintName("FK_TemplateItemAssetTypeRequests_TemplateItems");
			});
			modelBuilder.Entity<SpotAsset>(entity =>
			{
				entity.ToTable("SpotAssets", "Schedule");

				entity.Property(e => e.Id).HasDefaultValueSql("newid()");

				entity.Property(e => e.Index).HasDefaultValueSql("99");

				entity.HasOne(d => d.Spot)
					.WithMany(p => p.SpotAssets)
					.HasForeignKey(d => d.SpotId)
					.OnDelete(DeleteBehavior.Cascade)
					.HasConstraintName("FK_SpotAssets_Spots")
					.IsRequired();

			});
			modelBuilder.Entity<SpotAssetByAsset>(entity =>
			{
				entity.ToTable("SpotAssetByAssets", "Schedule");

				entity.Property(e => e.Id).ValueGeneratedNever();

				entity.HasOne(d => d.Asset)
					.WithMany(p => p.SpotAssetByAssets)
					.HasForeignKey(d => d.AssetId)
					.OnDelete(DeleteBehavior.Restrict)
					.HasConstraintName("FK_SpotAssetByAssets_Assets");

				entity.HasOne(d => d.SpotAsset)
					.WithOne(p => p.SpotAssetByAssets)
					.HasForeignKey<SpotAssetByAsset>(d => d.Id)
					.OnDelete(DeleteBehavior.Cascade)
					.HasConstraintName("FK_SpotAssetByAssets_SpotAssets")
					.IsRequired();
			});

			modelBuilder.Entity<SpotAssetByBooking>(entity =>
			{
				entity.ToTable("SpotAssetByBookings", "Schedule");

				entity.Property(e => e.Id).ValueGeneratedNever();

				entity.HasOne(d => d.SpotBooking)
					.WithOne(p => p.SpotAssetByBookings)
					.HasForeignKey<SpotAssetByBooking>(d => d.Id)
					.OnDelete(DeleteBehavior.Restrict)
					.HasConstraintName("FK_SpotAssetByBookings_SpotBookings");

				entity.HasOne(d => d.SpotAsset)
					.WithOne(p => p.SpotAssetByBookings)
					.HasForeignKey<SpotAssetByBooking>(d => d.Id)
					.OnDelete(DeleteBehavior.Cascade)
					.HasConstraintName("FK_SpotAssetByBookings_SpotAssets");
			});

            modelBuilder.Entity<Menu_Permission>()
                .HasKey(mp => new { mp.MenuId, mp.PermissionId });


			modelBuilder.Entity<AnnexContractType>(entity =>
			{
				entity.ToTable("AnnexContractTypes", "Booking");

				entity.Property(e => e.Id).HasDefaultValueSql("newid()");

				entity.Property(e => e.Name)
					.IsRequired()
					.HasMaxLength(256);

				entity.HasOne(d => d.BookingType)
					.WithMany(p => p.AnnexContractTypes)
					.HasForeignKey(d => d.BookingTypeId)
					.HasConstraintName("FK_AnnexContractTypes_BookingTypes");

				entity.HasOne(d => d.Parent)
					.WithMany(p => p.InverseParent)
					.HasForeignKey(d => d.ParentId)
					.HasConstraintName("FK_AnnexContractTypes_AnnexContractTypes");
			});
			modelBuilder.Entity<Notification>(entity =>
			{
				entity.ToTable("Notifications", "Notification");

				entity.Property(e => e.Id).HasDefaultValueSql("newid()");
				entity.Property(e => e.CreateDate).HasColumnType("datetimeoffset");
			});

			modelBuilder.Entity<Notification_User>(entity =>
			{
				entity.ToTable("NotificationsUsers", "Notification");
				entity.HasKey(e => new { e.NotificationId, e.UserId });

				entity.Property(e => e.IsRead).HasColumnType("bool");
				entity.HasOne(d => d.Notification)
					.WithMany(p => p.NotificationUsers)
					.HasForeignKey( d => d.NotificationId)
					.HasConstraintName("FK_NotificationsUsers_Notifications");

				entity.HasOne(d => d.User)
					.WithMany(p => p.NotificationUsers)
					.HasForeignKey(d => d.UserId)
						.HasConstraintName("FK_NotificationsUsers_Users");
			});
			modelBuilder.Entity<NotificationSubscribe>(entity =>
			{
				entity.ToTable("NotificationSubscribe", "Notification");

				entity.Property(e => e.Id).IsRequired();
				entity.HasOne(d => d.User)
					.WithOne(p => p.NotificationSubscribe)
					.HasForeignKey<User>(d => d.Id)
					.HasConstraintName("FK_NotificationSubscribe_Users");
			});
		}

    }
}