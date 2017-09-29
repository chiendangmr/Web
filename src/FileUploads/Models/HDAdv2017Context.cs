using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace FileUploads.Models
{
    public partial class HDAdv2017Context : DbContext
    {
        public virtual DbSet<AccessZones> AccessZones { get; set; }
        public virtual DbSet<AcessZone> AcessZone { get; set; }
        public virtual DbSet<AnnexContractAssets> AnnexContractAssets { get; set; }
        public virtual DbSet<AnnexContractPartnerPriceAtSignDates> AnnexContractPartnerPriceAtSignDates { get; set; }
        public virtual DbSet<AnnexContractPartners> AnnexContractPartners { get; set; }
        public virtual DbSet<AnnexContractTypes> AnnexContractTypes { get; set; }
        public virtual DbSet<AnnexContracts> AnnexContracts { get; set; }
        public virtual DbSet<Areas> Areas { get; set; }
        public virtual DbSet<Asset> Asset { get; set; }
        public virtual DbSet<AssetChannelLockTimeBandBaseNoLocks> AssetChannelLockTimeBandBaseNoLocks { get; set; }
        public virtual DbSet<AssetChannelLocks> AssetChannelLocks { get; set; }
        public virtual DbSet<AssetDocumentFiles> AssetDocumentFiles { get; set; }
        public virtual DbSet<AssetDocumentLinks> AssetDocumentLinks { get; set; }
        public virtual DbSet<AssetDocuments> AssetDocuments { get; set; }
        public virtual DbSet<AssetLocator> AssetLocator { get; set; }
        public virtual DbSet<AssetTimeBandLocks> AssetTimeBandLocks { get; set; }
        public virtual DbSet<AssetType> AssetType { get; set; }
        public virtual DbSet<AssetTypes> AssetTypes { get; set; }
        public virtual DbSet<BenefitPriceSponsorPrograms> BenefitPriceSponsorPrograms { get; set; }
        public virtual DbSet<BenefitPriceTimeBands> BenefitPriceTimeBands { get; set; }
        public virtual DbSet<BenefitPrices> BenefitPrices { get; set; }
        public virtual DbSet<BenefitTypes> BenefitTypes { get; set; }
        public virtual DbSet<BookingTypePriceTypes> BookingTypePriceTypes { get; set; }
        public virtual DbSet<BookingTypes> BookingTypes { get; set; }
        public virtual DbSet<Channels> Channels { get; set; }
        public virtual DbSet<Content> Content { get; set; }
        public virtual DbSet<ContentMetadata> ContentMetadata { get; set; }
        public virtual DbSet<ContentMetadataFieldset> ContentMetadataFieldset { get; set; }
        public virtual DbSet<ContentMetadataInfo> ContentMetadataInfo { get; set; }
        public virtual DbSet<ContentMetadataProfile> ContentMetadataProfile { get; set; }
        public virtual DbSet<ContentMetadataProfileField> ContentMetadataProfileField { get; set; }
        public virtual DbSet<ContentMetadataType> ContentMetadataType { get; set; }
        public virtual DbSet<ContentMetadataValue> ContentMetadataValue { get; set; }
        public virtual DbSet<Contracts> Contracts { get; set; }
        public virtual DbSet<Cultures> Cultures { get; set; }
        public virtual DbSet<CustomerPartners> CustomerPartners { get; set; }
        public virtual DbSet<CustomerRetails> CustomerRetails { get; set; }
        public virtual DbSet<CustomerTypes> CustomerTypes { get; set; }
        public virtual DbSet<Customers> Customers { get; set; }
        public virtual DbSet<Databases> Databases { get; set; }
        public virtual DbSet<DiscountAnnexContractAssets> DiscountAnnexContractAssets { get; set; }
        public virtual DbSet<DiscountAnnexContractTimeBandBases> DiscountAnnexContractTimeBandBases { get; set; }
        public virtual DbSet<DiscountAnnexContracts> DiscountAnnexContracts { get; set; }
        public virtual DbSet<DiscountCustomers> DiscountCustomers { get; set; }
        public virtual DbSet<DiscountSponsorPrograms> DiscountSponsorPrograms { get; set; }
        public virtual DbSet<DocumentTypes> DocumentTypes { get; set; }
        public virtual DbSet<FileContents> FileContents { get; set; }
        public virtual DbSet<FileDetailLocations> FileDetailLocations { get; set; }
        public virtual DbSet<FileDetails> FileDetails { get; set; }
        public virtual DbSet<FileExtensions> FileExtensions { get; set; }
        public virtual DbSet<FileInStorages> FileInStorages { get; set; }
        public virtual DbSet<FileTypeExtensions> FileTypeExtensions { get; set; }
        public virtual DbSet<FileTypes> FileTypes { get; set; }
        public virtual DbSet<Files> Files { get; set; }
        public virtual DbSet<GroupPermissions> GroupPermissions { get; set; }
        public virtual DbSet<GroupUsers> GroupUsers { get; set; }
        public virtual DbSet<Groups> Groups { get; set; }
        public virtual DbSet<LocalizableTexts> LocalizableTexts { get; set; }
        public virtual DbSet<LocalizedTexts> LocalizedTexts { get; set; }
        public virtual DbSet<LocationAccessZoneUris> LocationAccessZoneUris { get; set; }
        public virtual DbSet<LocationAccessZones> LocationAccessZones { get; set; }
        public virtual DbSet<Locations> Locations { get; set; }
        public virtual DbSet<Logs> Logs { get; set; }
        public virtual DbSet<MediaAsset> MediaAsset { get; set; }
        public virtual DbSet<MenuPermissions> MenuPermissions { get; set; }
        public virtual DbSet<Menus> Menus { get; set; }
        public virtual DbSet<MineType> MineType { get; set; }
        public virtual DbSet<Origins> Origins { get; set; }
        public virtual DbSet<PermissionRequests> PermissionRequests { get; set; }
        public virtual DbSet<Permissions> Permissions { get; set; }
        public virtual DbSet<PositionRates> PositionRates { get; set; }
        public virtual DbSet<Positions> Positions { get; set; }
        public virtual DbSet<PriceTypes> PriceTypes { get; set; }
        public virtual DbSet<Producers> Producers { get; set; }
        public virtual DbSet<ProductGroupDocumentRequests> ProductGroupDocumentRequests { get; set; }
        public virtual DbSet<ProductGroups> ProductGroups { get; set; }
        public virtual DbSet<RateSpotBlocks> RateSpotBlocks { get; set; }
        public virtual DbSet<Registers> Registers { get; set; }
        public virtual DbSet<RetailPrices> RetailPrices { get; set; }
        public virtual DbSet<RetailTypes> RetailTypes { get; set; }
        public virtual DbSet<Scene> Scene { get; set; }
        public virtual DbSet<SceneComment> SceneComment { get; set; }
        public virtual DbSet<SceneFiles> SceneFiles { get; set; }
        public virtual DbSet<Scenes> Scenes { get; set; }
        public virtual DbSet<SponsorPrograms> SponsorPrograms { get; set; }
        public virtual DbSet<SponsorTypes> SponsorTypes { get; set; }
        public virtual DbSet<SpotAssetByAssets> SpotAssetByAssets { get; set; }
        public virtual DbSet<SpotAssetByBookings> SpotAssetByBookings { get; set; }
        public virtual DbSet<SpotAssets> SpotAssets { get; set; }
        public virtual DbSet<SpotBlockRates> SpotBlockRates { get; set; }
        public virtual DbSet<SpotBlocks> SpotBlocks { get; set; }
        public virtual DbSet<SpotBookings> SpotBookings { get; set; }
        public virtual DbSet<Spots> Spots { get; set; }
        public virtual DbSet<Storage> Storage { get; set; }
        public virtual DbSet<StorageLocation> StorageLocation { get; set; }
        public virtual DbSet<StorageLocationAccess> StorageLocationAccess { get; set; }
        public virtual DbSet<StorageLocationAccessZone> StorageLocationAccessZone { get; set; }
        public virtual DbSet<Storages> Storages { get; set; }
        public virtual DbSet<TemplateItemAssetTypeRequests> TemplateItemAssetTypeRequests { get; set; }
        public virtual DbSet<TemplateItems> TemplateItems { get; set; }
        public virtual DbSet<Templates> Templates { get; set; }
        public virtual DbSet<TimeBandBaseScheduleTemplates> TimeBandBaseScheduleTemplates { get; set; }
        public virtual DbSet<TimeBandBases> TimeBandBases { get; set; }
        public virtual DbSet<TimeBandDays> TimeBandDays { get; set; }
        public virtual DbSet<TimeBandDescriptions> TimeBandDescriptions { get; set; }
        public virtual DbSet<TimeBandPrices> TimeBandPrices { get; set; }
        public virtual DbSet<TimeBandSliceDescriptions> TimeBandSliceDescriptions { get; set; }
        public virtual DbSet<TimeBandSliceDurationByTypes> TimeBandSliceDurationByTypes { get; set; }
        public virtual DbSet<TimeBandSliceDurations> TimeBandSliceDurations { get; set; }
        public virtual DbSet<TimeBandSliceForTypes> TimeBandSliceForTypes { get; set; }
        public virtual DbSet<TimeBandSlices> TimeBandSlices { get; set; }
        public virtual DbSet<TimeBandTimes> TimeBandTimes { get; set; }
        public virtual DbSet<TimeBands> TimeBands { get; set; }
        public virtual DbSet<TypeDetails> TypeDetails { get; set; }
        public virtual DbSet<UploadingFile> UploadingFile { get; set; }
        public virtual DbSet<UploadingPart> UploadingPart { get; set; }
        public virtual DbSet<UploadingPartTemp> UploadingPartTemp { get; set; }
        public virtual DbSet<UriTypes> UriTypes { get; set; }
        public virtual DbSet<UserPermissions> UserPermissions { get; set; }
        public virtual DbSet<Users> Users { get; set; }
        public virtual DbSet<Versions> Versions { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            #warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
            optionsBuilder.UseSqlServer(@"Data Source=hdstation.net;Initial Catalog=HDAdv2017;Persist Security Info=True;User ID=sa;Password=Hd123456!DB;MultipleActiveResultSets=true;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AccessZones>(entity =>
            {
                entity.ToTable("AccessZones", "Storage");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(256);
            });

            modelBuilder.Entity<AcessZone>(entity =>
            {
                entity.ToTable("AcessZone", "MediaAssets");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Description).HasColumnType("ShortDescription");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnType("Name");
            });

            modelBuilder.Entity<AnnexContractAssets>(entity =>
            {
                entity.ToTable("AnnexContractAssets", "Booking");

                entity.HasIndex(e => new { e.AnnexContractId, e.AssetId })
                    .HasName("IX_AnnexContractAssets")
                    .IsUnique();

                entity.Property(e => e.Id).HasDefaultValueSql("newid()");

                entity.Property(e => e.Price).HasColumnType("decimal");

                entity.HasOne(d => d.AnnexContract)
                    .WithMany(p => p.AnnexContractAssets)
                    .HasForeignKey(d => d.AnnexContractId)
                    .HasConstraintName("FK_AnnexContractAssets_AnnexContracts");

                entity.HasOne(d => d.Asset)
                    .WithMany(p => p.AnnexContractAssets)
                    .HasForeignKey(d => d.AssetId)
                    .HasConstraintName("FK_AnnexContractAssets_Assets");

                entity.HasOne(d => d.PriceTypeDetail)
                    .WithMany(p => p.AnnexContractAssets)
                    .HasForeignKey(d => d.PriceTypeDetailId)
                    .HasConstraintName("FK_AnnexContractAssets_TypeDetails");
            });

            modelBuilder.Entity<AnnexContractPartnerPriceAtSignDates>(entity =>
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

            modelBuilder.Entity<AnnexContractPartners>(entity =>
            {
                entity.ToTable("AnnexContractPartners", "Booking");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.SignDate)
                    .HasColumnType("date")
                    .HasDefaultValueSql("getdate()");

                entity.HasOne(d => d.IdNavigation)
                    .WithOne(p => p.AnnexContractPartners)
                    .HasForeignKey<AnnexContractPartners>(d => d.Id)
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

            modelBuilder.Entity<AnnexContractTypes>(entity =>
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

            modelBuilder.Entity<AnnexContracts>(entity =>
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

            modelBuilder.Entity<Asset>(entity =>
            {
                entity.ToTable("Asset", "MediaAssets");

                entity.Property(e => e.Id).HasDefaultValueSql("newsequentialid()");

                entity.Property(e => e.FileName).HasColumnType("Name");

                entity.Property(e => e.MineType).HasColumnType("Name");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnType("Name");

                entity.Property(e => e.OriginFileName).HasColumnType("Name");

                entity.Property(e => e.Revision)
                    .IsRequired()
                    .HasColumnType("timestamp")
                    .ValueGeneratedOnAddOrUpdate();

                entity.HasOne(d => d.AssetType)
                    .WithMany(p => p.Asset)
                    .HasForeignKey(d => d.AssetTypeId)
                    .HasConstraintName("FK_Asset_AssetType");

                entity.HasOne(d => d.MediaAsset)
                    .WithMany(p => p.Asset)
                    .HasForeignKey(d => d.MediaAssetId)
                    .HasConstraintName("FK_Asset_MediaAsset");

                entity.HasOne(d => d.MineTypeNavigation)
                    .WithMany(p => p.Asset)
                    .HasForeignKey(d => d.MineType)
                    .HasConstraintName("FK_Asset_MineType");
            });

            modelBuilder.Entity<AssetChannelLockTimeBandBaseNoLocks>(entity =>
            {
                entity.HasKey(e => new { e.LockId, e.TimeBandBaseId })
                    .HasName("PK_AssetChannelLock_TimeBandBaseNoLocks");

                entity.ToTable("AssetChannelLock_TimeBandBaseNoLocks", "Booking");

                entity.HasOne(d => d.Lock)
                    .WithMany(p => p.AssetChannelLockTimeBandBaseNoLocks)
                    .HasForeignKey(d => d.LockId)
                    .HasConstraintName("FK_AssetChannelLock_TimeBandBaseNoLocks_AssetChannelLocks");

                entity.HasOne(d => d.TimeBandBase)
                    .WithMany(p => p.AssetChannelLockTimeBandBaseNoLocks)
                    .HasForeignKey(d => d.TimeBandBaseId)
                    .HasConstraintName("FK_AssetChannelLock_TimeBandBaseNoLocks_TimeBandBases");
            });

            modelBuilder.Entity<AssetChannelLocks>(entity =>
            {
                entity.ToTable("AssetChannelLocks", "Booking");

                entity.HasIndex(e => new { e.AssetId, e.ChannelId, e.StartDate })
                    .HasName("IX_AssetChannelLocks")
                    .IsUnique();

                entity.Property(e => e.Id).HasDefaultValueSql("newid()");

                entity.Property(e => e.EndDate).HasColumnType("date");

                entity.Property(e => e.StartDate)
                    .IsRequired()
                    .HasColumnType("date");

                entity.HasOne(d => d.Asset)
                    .WithMany(p => p.AssetChannelLocks)
                    .HasForeignKey(d => d.AssetId)
                    .HasConstraintName("FK_AssetChannelLocks_Assets");

                entity.HasOne(d => d.Channel)
                    .WithMany(p => p.AssetChannelLocks)
                    .HasForeignKey(d => d.ChannelId)
                    .HasConstraintName("FK_AssetChannelLocks_Channels");
            });

            modelBuilder.Entity<AssetDocumentFiles>(entity =>
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

            modelBuilder.Entity<AssetDocumentLinks>(entity =>
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

            modelBuilder.Entity<AssetDocuments>(entity =>
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

            modelBuilder.Entity<AssetLocator>(entity =>
            {
                entity.ToTable("AssetLocator", "MediaAssets");

                entity.Property(e => e.Id).HasDefaultValueSql("newsequentialid()");

                entity.Property(e => e.ContainerMineType)
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
                    .WithMany(p => p.AssetLocator)
                    .HasForeignKey(d => d.AssetId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_AssetLocator_Asset");

                entity.HasOne(d => d.ContainerMineTypeNavigation)
                    .WithMany(p => p.AssetLocator)
                    .HasForeignKey(d => d.ContainerMineType)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_AssetLocator_MineType");

                entity.HasOne(d => d.StorageLocation)
                    .WithMany(p => p.AssetLocator)
                    .HasForeignKey(d => d.StorageLocationId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_AssetLocator_StorageLocation");
            });

            modelBuilder.Entity<AssetTimeBandLocks>(entity =>
            {
                entity.ToTable("AssetTimeBandLocks", "Booking");

                entity.HasIndex(e => new { e.AssetId, e.TimeBandId, e.StartDate })
                    .HasName("IX_AssetTimeBandLocks")
                    .IsUnique();

                entity.Property(e => e.Id).HasDefaultValueSql("newid()");

                entity.Property(e => e.EndDate).HasColumnType("date");

                entity.Property(e => e.StartDate)
                    .IsRequired()
                    .HasColumnType("date");

                entity.HasOne(d => d.Asset)
                    .WithMany(p => p.AssetTimeBandLocks)
                    .HasForeignKey(d => d.AssetId)
                    .HasConstraintName("FK_AssetTimeBandLocks_Assets");

                entity.HasOne(d => d.TimeBand)
                    .WithMany(p => p.AssetTimeBandLocks)
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

            modelBuilder.Entity<AssetTypes>(entity =>
            {
                entity.ToTable("AssetTypes", "Asset");

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

            modelBuilder.Entity<BenefitPriceSponsorPrograms>(entity =>
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

            modelBuilder.Entity<BenefitPriceTimeBands>(entity =>
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

            modelBuilder.Entity<BenefitPrices>(entity =>
            {
                entity.ToTable("BenefitPrices", "Price");

                entity.Property(e => e.Id).HasDefaultValueSql("newid()");

                entity.Property(e => e.StartDate).HasColumnType("date");

                entity.HasOne(d => d.BenefitType)
                    .WithMany(p => p.BenefitPrices)
                    .HasForeignKey(d => d.BenefitTypeId)
                    .HasConstraintName("FK_BenefitPrices_BenefitTypes");
            });

            modelBuilder.Entity<BenefitTypes>(entity =>
            {
                entity.ToTable("BenefitTypes", "Price");

                entity.HasIndex(e => e.Code)
                    .HasName("IX_BenefitTypes")
                    .IsUnique();

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Code)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.IdNavigation)
                    .WithOne(p => p.BenefitTypes)
                    .HasForeignKey<BenefitTypes>(d => d.Id)
                    .HasConstraintName("FK_BenefitTypes_TypeDetails");
            });

            modelBuilder.Entity<BookingTypePriceTypes>(entity =>
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

            modelBuilder.Entity<BookingTypes>(entity =>
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

            modelBuilder.Entity<Channels>(entity =>
            {
                entity.ToTable("Channels", "System");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.HasOne(d => d.IdNavigation)
                    .WithOne(p => p.Channels)
                    .HasForeignKey<Channels>(d => d.Id)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_Channels_TimeBandBases");
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

                entity.HasOne(d => d.Area)
                    .WithMany(p => p.Content)
                    .HasForeignKey(d => d.AreaId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_Assets_Areas");

                entity.HasOne(d => d.LastProductModelNavigation)
                    .WithMany(p => p.InverseLastProductModelNavigation)
                    .HasForeignKey(d => d.LastProductModel)
                    .HasConstraintName("FK_Assets_Assets");

                entity.HasOne(d => d.Producer)
                    .WithMany(p => p.Content)
                    .HasForeignKey(d => d.ProducerId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("FK_Assets_Producers");

                entity.HasOne(d => d.ProductGroup)
                    .WithMany(p => p.Content)
                    .HasForeignKey(d => d.ProductGroupId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("FK_Assets_ProductGroups");

                entity.HasOne(d => d.Register)
                    .WithMany(p => p.Content)
                    .HasForeignKey(d => d.RegisterId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("FK_Assets_Registers");

                entity.HasOne(d => d.Type)
                    .WithMany(p => p.Content)
                    .HasForeignKey(d => d.TypeId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_Assets_Types");
            });

            modelBuilder.Entity<ContentMetadata>(entity =>
            {
                entity.ToTable("ContentMetadata", "MediaAssets");

                entity.Property(e => e.Id).HasDefaultValueSql("newsequentialid()");

                entity.HasOne(d => d.ContentMetadataInfo)
                    .WithMany(p => p.ContentMetadata)
                    .HasForeignKey(d => d.ContentMetadataInfoId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_ContentMetadata_ContentMetadataInfo");

                entity.HasOne(d => d.ContentMetadataValue)
                    .WithMany(p => p.ContentMetadata)
                    .HasForeignKey(d => d.ContentMetadataValueId)
                    .HasConstraintName("FK_ContentMetadata_ContentMetadataValue");
            });

            modelBuilder.Entity<ContentMetadataFieldset>(entity =>
            {
                entity.ToTable("ContentMetadataFieldset", "MediaAssets");

                entity.Property(e => e.Id).HasDefaultValueSql("newsequentialid()");

                entity.Property(e => e.Description).HasColumnType("ShortDescription");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnType("Name");

                entity.Property(e => e.PartialName).HasColumnType("Name");

                entity.HasOne(d => d.ContentMetadataProfile)
                    .WithMany(p => p.ContentMetadataFieldset)
                    .HasForeignKey(d => d.ContentMetadataProfileId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_ContentMetadataFieldset_ContentMetadataProfile");
            });

            modelBuilder.Entity<ContentMetadataInfo>(entity =>
            {
                entity.ToTable("ContentMetadataInfo", "MediaAssets");

                entity.HasIndex(e => e.Name)
                    .HasName("UC_ContentMetadataInfo_Name")
                    .IsUnique();

                entity.Property(e => e.Id).HasDefaultValueSql("newsequentialid()");

                entity.Property(e => e.DefaultValue).HasMaxLength(50);

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasColumnType("ShortDescription");

                entity.Property(e => e.Disabled).HasColumnType("Flag");

                entity.Property(e => e.EnumType).HasColumnType("Name");

                entity.Property(e => e.IsContentField)
                    .HasColumnType("Flag")
                    .HasDefaultValueSql("1");

                entity.Property(e => e.Label).HasColumnType("Name");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnType("Name");

                entity.Property(e => e.PartialName).HasColumnType("Name");

                entity.Property(e => e.Prompt).HasColumnType("Name");

                entity.Property(e => e.TagAttributes).HasMaxLength(2500);

                entity.HasOne(d => d.ContentMetadataType)
                    .WithMany(p => p.ContentMetadataInfo)
                    .HasForeignKey(d => d.ContentMetadataTypeId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_ContentMetadataInfo_ContentMetadataType");
            });

            modelBuilder.Entity<ContentMetadataProfile>(entity =>
            {
                entity.ToTable("ContentMetadataProfile", "MediaAssets");

                entity.Property(e => e.Id).HasDefaultValueSql("newsequentialid()");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<ContentMetadataProfileField>(entity =>
            {
                entity.ToTable("ContentMetadataProfileField", "MediaAssets");

                entity.Property(e => e.Id).HasDefaultValueSql("newsequentialid()");

                entity.Property(e => e.Editable).HasColumnType("Flag");

                entity.Property(e => e.Enabled).HasColumnType("Flag");

                entity.Property(e => e.Searchable).HasColumnType("Flag");

                entity.Property(e => e.Sortable).HasColumnType("Flag");

                entity.Property(e => e.Visible).HasColumnType("Flag");

                entity.HasOne(d => d.ContentMetadataFieldset)
                    .WithMany(p => p.ContentMetadataProfileField)
                    .HasForeignKey(d => d.ContentMetadataFieldsetId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_ContentMetadataProfileField_ContentMetadataFieldset");

                entity.HasOne(d => d.ContentMetadataInfo)
                    .WithMany(p => p.ContentMetadataProfileField)
                    .HasForeignKey(d => d.ContentMetadataInfoId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_ContentMetadataProfileField_ContentMetadataField");
            });

            modelBuilder.Entity<ContentMetadataType>(entity =>
            {
                entity.ToTable("ContentMetadataType", "MediaAssets");

                entity.HasIndex(e => e.Name)
                    .HasName("UC_ContentMetadataType_Name")
                    .IsUnique();

                entity.Property(e => e.Id).HasDefaultValueSql("newid()");

                entity.Property(e => e.Description).HasColumnType("Name");

                entity.Property(e => e.HtmlTag)
                    .IsRequired()
                    .HasColumnType("nchar(20)");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnType("Name");
            });

            modelBuilder.Entity<ContentMetadataValue>(entity =>
            {
                entity.ToTable("ContentMetadataValue", "MediaAssets");

                entity.Property(e => e.Id).HasDefaultValueSql("newsequentialid()");

                entity.Property(e => e.Description).HasColumnType("ShortDescription");

                entity.Property(e => e.Label).HasColumnType("Name");

                entity.Property(e => e.Value)
                    .IsRequired()
                    .HasColumnType("Name");

                entity.HasOne(d => d.ContentMetadataInfo)
                    .WithMany(p => p.ContentMetadataValue)
                    .HasForeignKey(d => d.ContentMetadataInfoId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_ContentMetadataValue_ContentMetadataInfo");

                entity.HasOne(d => d.Parent)
                    .WithMany(p => p.InverseParent)
                    .HasForeignKey(d => d.ParentId)
                    .HasConstraintName("FK_ContentMetadataValue_ContentMetadataValue");
            });

            modelBuilder.Entity<Contracts>(entity =>
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

            modelBuilder.Entity<Cultures>(entity =>
            {
                entity.HasKey(e => e.Name)
                    .HasName("PK_Cultures");

                entity.ToTable("Cultures", "Language");

                entity.Property(e => e.Name).HasMaxLength(16);

                entity.Property(e => e.Disabled).HasDefaultValueSql("0");

                entity.Property(e => e.Parent).HasMaxLength(16);

                entity.HasOne(d => d.ParentNavigation)
                    .WithMany(p => p.InverseParentNavigation)
                    .HasForeignKey(d => d.Parent)
                    .HasConstraintName("FK_Cultures_Cultures");
            });

            modelBuilder.Entity<CustomerPartners>(entity =>
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

                entity.HasOne(d => d.IdNavigation)
                    .WithOne(p => p.CustomerPartners)
                    .HasForeignKey<CustomerPartners>(d => d.Id)
                    .HasConstraintName("FK_CustomerPartners_Customers");

                entity.HasOne(d => d.Parent)
                    .WithMany(p => p.InverseParent)
                    .HasForeignKey(d => d.ParentId)
                    .HasConstraintName("FK_CustomerPartners_CustomerPartners");
            });

            modelBuilder.Entity<CustomerRetails>(entity =>
            {
                entity.ToTable("CustomerRetails", "Contract");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.HasOne(d => d.IdNavigation)
                    .WithOne(p => p.CustomerRetails)
                    .HasForeignKey<CustomerRetails>(d => d.Id)
                    .HasConstraintName("FK_CustomerRetails_Customers");
            });

            modelBuilder.Entity<CustomerTypes>(entity =>
            {
                entity.ToTable("CustomerTypes", "Contract");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(256);
            });

            modelBuilder.Entity<Customers>(entity =>
            {
                entity.ToTable("Customers", "Contract");

                entity.Property(e => e.Id).HasDefaultValueSql("newid()");

                entity.Property(e => e.Name).IsRequired();

                entity.HasOne(d => d.Type)
                    .WithMany(p => p.Customers)
                    .HasForeignKey(d => d.TypeId)
                    .HasConstraintName("FK_Customers_CustomerTypes");
            });

            modelBuilder.Entity<Databases>(entity =>
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

            modelBuilder.Entity<DiscountAnnexContractAssets>(entity =>
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

            modelBuilder.Entity<DiscountAnnexContractTimeBandBases>(entity =>
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

            modelBuilder.Entity<DiscountAnnexContracts>(entity =>
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

            modelBuilder.Entity<DiscountCustomers>(entity =>
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

            modelBuilder.Entity<DiscountSponsorPrograms>(entity =>
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

            modelBuilder.Entity<DocumentTypes>(entity =>
            {
                entity.ToTable("DocumentTypes", "Document");

                entity.Property(e => e.Id).HasDefaultValueSql("newid()");

                entity.HasOne(d => d.Parent)
                    .WithMany(p => p.InverseParent)
                    .HasForeignKey(d => d.ParentId)
                    .HasConstraintName("FK_Types_Types");
            });

            modelBuilder.Entity<FileContents>(entity =>
            {
                entity.ToTable("FileContents", "Storage");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Content).IsRequired();

                entity.HasOne(d => d.IdNavigation)
                    .WithOne(p => p.FileContents)
                    .HasForeignKey<FileContents>(d => d.Id)
                    .HasConstraintName("FK_FileContents_Files");
            });

            modelBuilder.Entity<FileDetailLocations>(entity =>
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

            modelBuilder.Entity<FileDetails>(entity =>
            {
                entity.ToTable("FileDetails", "Storage");

                entity.Property(e => e.Id).HasDefaultValueSql("newid()");

                entity.Property(e => e.CreateTime)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("getdate()");

                entity.HasOne(d => d.File)
                    .WithMany(p => p.FileDetails)
                    .HasForeignKey(d => d.FileId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_FileDetails_FileInStorages");
            });

            modelBuilder.Entity<FileExtensions>(entity =>
            {
                entity.ToTable("FileExtensions", "Storage");

                entity.Property(e => e.Id).HasDefaultValueSql("newid()");

                entity.Property(e => e.Extension)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<FileInStorages>(entity =>
            {
                entity.ToTable("FileInStorages", "Storage");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.HasOne(d => d.IdNavigation)
                    .WithOne(p => p.FileInStorages)
                    .HasForeignKey<FileInStorages>(d => d.Id)
                    .HasConstraintName("FK_FileInStorages_Files");
            });

            modelBuilder.Entity<FileTypeExtensions>(entity =>
            {
                entity.ToTable("FileTypeExtensions", "Storage");

                entity.HasIndex(e => new { e.FileTypeId, e.FileExtensionId })
                    .HasName("IX_FileTypeExtensions")
                    .IsUnique();

                entity.Property(e => e.Id).HasDefaultValueSql("newid()");

                entity.HasOne(d => d.FileExtension)
                    .WithMany(p => p.FileTypeExtensions)
                    .HasForeignKey(d => d.FileExtensionId)
                    .HasConstraintName("FK_FileTypeExtensions_FileExtensions");

                entity.HasOne(d => d.FileType)
                    .WithMany(p => p.FileTypeExtensions)
                    .HasForeignKey(d => d.FileTypeId)
                    .HasConstraintName("FK_FileTypeExtensions_FileTypes");
            });

            modelBuilder.Entity<FileTypes>(entity =>
            {
                entity.ToTable("FileTypes", "Storage");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(256);
            });

            modelBuilder.Entity<Files>(entity =>
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

            modelBuilder.Entity<GroupPermissions>(entity =>
            {
                entity.HasKey(e => new { e.GroupId, e.PermissionId })
                    .HasName("PK_Group_Permissions");

                entity.ToTable("Group_Permissions", "Security");

                entity.HasOne(d => d.Group)
                    .WithMany(p => p.GroupPermissions)
                    .HasForeignKey(d => d.GroupId)
                    .HasConstraintName("FK_Group_Permissions_Groups");

                entity.HasOne(d => d.Permission)
                    .WithMany(p => p.GroupPermissions)
                    .HasForeignKey(d => d.PermissionId)
                    .HasConstraintName("FK_Group_Permissions_Permissions");
            });

            modelBuilder.Entity<GroupUsers>(entity =>
            {
                entity.HasKey(e => new { e.GroupId, e.UserId })
                    .HasName("PK_UserGroup_Users");

                entity.ToTable("Group_Users", "Security");

                entity.HasOne(d => d.Group)
                    .WithMany(p => p.GroupUsers)
                    .HasForeignKey(d => d.GroupId)
                    .HasConstraintName("FK_Group_Users_Groups");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.GroupUsers)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_Group_Users_Users");
            });

            modelBuilder.Entity<Groups>(entity =>
            {
                entity.ToTable("Groups", "Security");

                entity.HasIndex(e => e.Name)
                    .HasName("GroupNameIndex");

                entity.HasIndex(e => new { e.Name, e.ParentId })
                    .HasName("Group_ParentAndGroupNameUnique")
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

            modelBuilder.Entity<LocalizableTexts>(entity =>
            {
                entity.ToTable("LocalizableTexts", "Language");

                entity.HasIndex(e => new { e.Key, e.Scope })
                    .HasName("IX_LocalizableTexts")
                    .IsUnique();

                entity.Property(e => e.Key)
                    .IsRequired()
                    .HasMaxLength(256);

                entity.Property(e => e.Scope)
                    .IsRequired()
                    .HasMaxLength(190);
            });

            modelBuilder.Entity<LocalizedTexts>(entity =>
            {
                entity.ToTable("LocalizedTexts", "Language");

                entity.HasIndex(e => new { e.Disabled, e.Culture, e.Key })
                    .HasName("IX_LocalizedTexts");

                entity.HasIndex(e => new { e.Key, e.Scope, e.Culture, e.Disabled })
                    .HasName("IX_LocalizableTexts")
                    .IsUnique();

                entity.Property(e => e.Id).HasDefaultValueSql("newid()");

                entity.Property(e => e.Culture)
                    .IsRequired()
                    .HasMaxLength(16);

                entity.Property(e => e.Disabled).HasDefaultValueSql("0");

                entity.Property(e => e.Key)
                    .IsRequired()
                    .HasMaxLength(256);

                entity.Property(e => e.Scope)
                    .IsRequired()
                    .HasMaxLength(190);

                entity.Property(e => e.Value).IsRequired();
            });

            modelBuilder.Entity<LocationAccessZoneUris>(entity =>
            {
                entity.ToTable("LocationAccessZoneUris", "Storage");

                entity.Property(e => e.Id).HasDefaultValueSql("newid()");

                entity.Property(e => e.CanRead).HasDefaultValueSql("0");

                entity.Property(e => e.CanWrite).HasDefaultValueSql("0");

                entity.Property(e => e.Value).IsRequired();

                entity.HasOne(d => d.LocationAccessZone)
                    .WithMany(p => p.LocationAccessZoneUris)
                    .HasForeignKey(d => d.LocationAccessZoneId)
                    .HasConstraintName("FK_LocationAccessZoneUris_LocationAccessZones");

                entity.HasOne(d => d.UriType)
                    .WithMany(p => p.LocationAccessZoneUris)
                    .HasForeignKey(d => d.UriTypeId)
                    .HasConstraintName("FK_LocationAccessZoneUris_UriTypes");
            });

            modelBuilder.Entity<LocationAccessZones>(entity =>
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

                entity.HasOne(d => d.StorageAccess)
                    .WithMany(p => p.LocationAccessZones)
                    .HasForeignKey(d => d.StorageAccessId)
                    .HasConstraintName("FK_LocationAccessZones_Storages");
            });

            modelBuilder.Entity<Locations>(entity =>
            {
                entity.ToTable("Locations", "Storage");

                entity.HasIndex(e => new { e.StorageId, e.FileTypeId, e.Name })
                    .HasName("IX_Locations")
                    .IsUnique();

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

            modelBuilder.Entity<Logs>(entity =>
            {
                entity.ToTable("Logs", "Log");

                entity.HasIndex(e => e.DataId)
                    .HasName("IX_Logs_3");

                entity.HasIndex(e => e.DataName)
                    .HasName("IX_Logs_4");

                entity.HasIndex(e => e.Type)
                    .HasName("IX_Logs");

                entity.HasIndex(e => e.UserId)
                    .HasName("IX_Logs_1");

                entity.HasIndex(e => e.UserName)
                    .HasName("IX_Logs_2");

                entity.Property(e => e.Id).HasDefaultValueSql("newid()");

                entity.Property(e => e.Action).HasMaxLength(256);

                entity.Property(e => e.DataId).HasMaxLength(256);

                entity.Property(e => e.DataName).HasMaxLength(256);

                entity.Property(e => e.Type)
                    .IsRequired()
                    .HasMaxLength(256);

                entity.Property(e => e.UserName).HasMaxLength(256);
            });

            modelBuilder.Entity<MediaAsset>(entity =>
            {
                entity.ToTable("MediaAsset", "MediaAssets");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.ContainerFormat).HasMaxLength(256);

                entity.Property(e => e.FramerateDemoniator).HasColumnName("Framerate_Demoniator");

                entity.Property(e => e.FramerateNumerator).HasColumnName("Framerate_Numerator");
            });

            modelBuilder.Entity<MenuPermissions>(entity =>
            {
                entity.HasKey(e => new { e.MenuId, e.PermissionId })
                    .HasName("PK_Menu_RolePermissions");

                entity.ToTable("Menu_Permissions", "UI");

                entity.HasOne(d => d.Menu)
                    .WithMany(p => p.MenuPermissions)
                    .HasForeignKey(d => d.MenuId)
                    .HasConstraintName("FK_Menu_Permissions_Menus");

                entity.HasOne(d => d.Permission)
                    .WithMany(p => p.MenuPermissions)
                    .HasForeignKey(d => d.PermissionId)
                    .HasConstraintName("FK_Menu_Permissions_Permissions");
            });

            modelBuilder.Entity<Menus>(entity =>
            {
                entity.ToTable("Menus", "UI");

                entity.HasIndex(e => e.Index)
                    .HasName("MenuIndexIndex");

                entity.HasIndex(e => new { e.ParentId, e.Name })
                    .HasName("MenuParent_NameIndex")
                    .IsUnique();

                entity.Property(e => e.Id).HasDefaultValueSql("newid()");

                entity.Property(e => e.Action).HasMaxLength(50);

                entity.Property(e => e.Area).HasMaxLength(50);

                entity.Property(e => e.Controller).HasMaxLength(50);

                entity.Property(e => e.GroupIndex).HasDefaultValueSql("0");

                entity.Property(e => e.Index).HasDefaultValueSql("0");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.ParentId).IsRequired();

                entity.HasOne(d => d.Parent)
                    .WithMany(p => p.InverseParent)
                    .HasForeignKey(d => d.ParentId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_Menus_Menus");
            });

            modelBuilder.Entity<MineType>(entity =>
            {
                entity.HasKey(e => e.InternetMediaType)
                    .HasName("PK_MineType");

                entity.ToTable("MineType", "MediaAssets");

                entity.Property(e => e.InternetMediaType).HasColumnType("Name");

                entity.Property(e => e.FileExtension).HasMaxLength(256);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnType("Name");

                entity.Property(e => e.Reference).HasColumnType("URI");
            });

            modelBuilder.Entity<Origins>(entity =>
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

            modelBuilder.Entity<PermissionRequests>(entity =>
            {
                entity.HasKey(e => new { e.ParentId, e.ChildrenId })
                    .HasName("PK_Permission_ParentChildrens");

                entity.ToTable("Permission_Requests", "Security");

                entity.HasOne(d => d.Children)
                    .WithMany(p => p.PermissionRequestsChildren)
                    .HasForeignKey(d => d.ChildrenId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_Permission_ParentChildrens_Permissions1");

                entity.HasOne(d => d.Parent)
                    .WithMany(p => p.PermissionRequestsParent)
                    .HasForeignKey(d => d.ParentId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_Permission_ParentChildrens_Permissions");
            });

            modelBuilder.Entity<Permissions>(entity =>
            {
                entity.ToTable("Permissions", "Security");

                entity.HasIndex(e => e.ParentId)
                    .HasName("IX_Permissions_1");

                entity.HasIndex(e => e.Type)
                    .HasName("IX_Permissions");

                entity.HasIndex(e => e.Value)
                    .HasName("IX_Permissions_2");

                entity.Property(e => e.Id).HasDefaultValueSql("newid()");

                entity.Property(e => e.Index).HasDefaultValueSql("-1");

                entity.Property(e => e.Type)
                    .IsRequired()
                    .HasMaxLength(256);

                entity.Property(e => e.Value)
                    .IsRequired()
                    .HasMaxLength(256);

                entity.HasOne(d => d.Parent)
                    .WithMany(p => p.InverseParent)
                    .HasForeignKey(d => d.ParentId)
                    .HasConstraintName("FK_Permissions_Permissions");
            });

            modelBuilder.Entity<PositionRates>(entity =>
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

            modelBuilder.Entity<Positions>(entity =>
            {
                entity.ToTable("Positions", "Price");

                entity.HasIndex(e => e.StartDate)
                    .HasName("IX_Positions")
                    .IsUnique();

                entity.Property(e => e.Id).HasDefaultValueSql("newid()");

                entity.Property(e => e.StartDate).HasColumnType("date");
            });

            modelBuilder.Entity<PriceTypes>(entity =>
            {
                entity.ToTable("PriceTypes", "Price");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Name).IsRequired();
            });

            modelBuilder.Entity<Producers>(entity =>
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

            modelBuilder.Entity<ProductGroupDocumentRequests>(entity =>
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

            modelBuilder.Entity<ProductGroups>(entity =>
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

            modelBuilder.Entity<RateSpotBlocks>(entity =>
            {
                entity.ToTable("RateSpotBlocks", "Price");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Rate).HasColumnType("decimal");

                entity.HasOne(d => d.IdNavigation)
                    .WithOne(p => p.RateSpotBlocks)
                    .HasForeignKey<RateSpotBlocks>(d => d.Id)
                    .HasConstraintName("FK_RateSpotBlocks_TypeDetails");

                entity.HasOne(d => d.SpotBlock)
                    .WithMany(p => p.RateSpotBlocks)
                    .HasForeignKey(d => d.SpotBlockId)
                    .HasConstraintName("FK_RateSpotBlockTypes_SpotBlocks");
            });

            modelBuilder.Entity<Registers>(entity =>
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

            modelBuilder.Entity<RetailPrices>(entity =>
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

            modelBuilder.Entity<RetailTypes>(entity =>
            {
                entity.ToTable("RetailTypes", "Price");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.HasOne(d => d.IdNavigation)
                    .WithOne(p => p.RetailTypes)
                    .HasForeignKey<RetailTypes>(d => d.Id)
                    .HasConstraintName("FK_Test_TypeDetails");
            });

            modelBuilder.Entity<Scene>(entity =>
            {
                entity.ToTable("Scene", "MediaAssets");

                entity.Property(e => e.Id).HasDefaultValueSql("newid()");

                entity.Property(e => e.LastEdited).HasDefaultValueSql("getdate()");

                entity.Property(e => e.Text)
                    .IsRequired()
                    .HasMaxLength(500);

                entity.HasOne(d => d.Asset)
                    .WithMany(p => p.Scene)
                    .HasForeignKey(d => d.AssetId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_Scene_Asset");
            });

            modelBuilder.Entity<SceneComment>(entity =>
            {
                entity.ToTable("SceneComment", "MediaAssets");

                entity.Property(e => e.Id).HasDefaultValueSql("newid()");

                entity.Property(e => e.LastEdited).HasDefaultValueSql("getdate()");

                entity.Property(e => e.Text)
                    .IsRequired()
                    .HasMaxLength(500);

                entity.HasOne(d => d.Scene)
                    .WithMany(p => p.SceneComment)
                    .HasForeignKey(d => d.SceneId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_SceneComment_Scene");
            });

            modelBuilder.Entity<SceneFiles>(entity =>
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

            modelBuilder.Entity<Scenes>(entity =>
            {
                entity.ToTable("Scenes", "Media");

                entity.Property(e => e.Id).HasDefaultValueSql("newid()");

                entity.Property(e => e.StartFrame).HasDefaultValueSql("0");

                entity.HasOne(d => d.Origin)
                    .WithMany(p => p.Scenes)
                    .HasForeignKey(d => d.OriginId)
                    .HasConstraintName("FK_Broadcasts_Origins");
            });

            modelBuilder.Entity<SponsorPrograms>(entity =>
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
            });

            modelBuilder.Entity<SponsorTypes>(entity =>
            {
                entity.ToTable("SponsorTypes", "Contract");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(256);
            });

            modelBuilder.Entity<SpotAssetByAssets>(entity =>
            {
                entity.ToTable("SpotAssetByAssets", "Schedule");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.HasOne(d => d.Asset)
                    .WithMany(p => p.SpotAssetByAssets)
                    .HasForeignKey(d => d.AssetId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_SpotAssetByAssets_Assets");

                entity.HasOne(d => d.IdNavigation)
                    .WithOne(p => p.SpotAssetByAssets)
                    .HasForeignKey<SpotAssetByAssets>(d => d.Id)
                    .HasConstraintName("FK_SpotAssetByAssets_SpotAssets");
            });

            modelBuilder.Entity<SpotAssetByBookings>(entity =>
            {
                entity.ToTable("SpotAssetByBookings", "Schedule");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.HasOne(d => d.IdNavigation)
                    .WithOne(p => p.SpotAssetByBookings)
                    .HasForeignKey<SpotAssetByBookings>(d => d.Id)
                    .HasConstraintName("FK_SpotAssetByBookings_SpotAssets");

                entity.HasOne(d => d.Id1)
                    .WithOne(p => p.SpotAssetByBookings)
                    .HasForeignKey<SpotAssetByBookings>(d => d.Id)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_SpotAssetByBookings_SpotBookings");
            });

            modelBuilder.Entity<SpotAssets>(entity =>
            {
                entity.ToTable("SpotAssets", "Schedule");

                entity.Property(e => e.Id).HasDefaultValueSql("newid()");

                entity.Property(e => e.Index).HasDefaultValueSql("99");

                entity.HasOne(d => d.Spot)
                    .WithMany(p => p.SpotAssets)
                    .HasForeignKey(d => d.SpotId)
                    .HasConstraintName("FK_SpotAssets_Spots");
            });

            modelBuilder.Entity<SpotBlockRates>(entity =>
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

            modelBuilder.Entity<SpotBlocks>(entity =>
            {
                entity.ToTable("SpotBlocks", "System");

                entity.HasIndex(e => e.Duration)
                    .HasName("IX_SpotBlock")
                    .IsUnique();

                entity.Property(e => e.Id).HasDefaultValueSql("newid()");
            });

            modelBuilder.Entity<SpotBookings>(entity =>
            {
                entity.ToTable("SpotBookings", "Booking");

                entity.Property(e => e.Id).HasDefaultValueSql("newid()");

                entity.Property(e => e.BookingDate)
                    .HasColumnType("date")
                    .HasDefaultValueSql("getdate()");

                entity.Property(e => e.CalcTime).HasColumnType("datetime");

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

            modelBuilder.Entity<Spots>(entity =>
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

            modelBuilder.Entity<Storage>(entity =>
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
                    .WithMany(p => p.StorageLocation)
                    .HasForeignKey(d => d.AssetTypeId)
                    .HasConstraintName("FK_StorageLocation_AssetType");

                entity.HasOne(d => d.Storage)
                    .WithMany(p => p.StorageLocation)
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
                    .WithMany(p => p.StorageLocationAccess)
                    .HasForeignKey(d => d.StorageLocationId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_StorageLocationAccess_StorageLocation");
            });

            modelBuilder.Entity<StorageLocationAccessZone>(entity =>
            {
                entity.ToTable("StorageLocationAccessZone", "MediaAssets");

                entity.Property(e => e.Id).HasDefaultValueSql("newsequentialid()");

                entity.HasOne(d => d.AccessZone)
                    .WithMany(p => p.StorageLocationAccessZone)
                    .HasForeignKey(d => d.AccessZoneId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_StorageLocationAccessZone_AcessZone");

                entity.HasOne(d => d.StorageLocationAccess)
                    .WithMany(p => p.StorageLocationAccessZone)
                    .HasForeignKey(d => d.StorageLocationAccessId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_StorageLocationAccessZone_StorageLocationAccess");
            });

            modelBuilder.Entity<Storages>(entity =>
            {
                entity.ToTable("Storages", "Storage");

                entity.Property(e => e.Id).HasDefaultValueSql("newid()");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(256);
            });

            modelBuilder.Entity<TemplateItemAssetTypeRequests>(entity =>
            {
                entity.ToTable("TemplateItemAssetTypeRequests", "Schedule");

                entity.HasIndex(e => new { e.AssetTypeId, e.TemplateItemId })
                    .HasName("IX_TemplateItemAssetTypeRequests")
                    .IsUnique();

                entity.Property(e => e.Id).HasDefaultValueSql("newid()");

                entity.HasOne(d => d.AssetType)
                    .WithMany(p => p.TemplateItemAssetTypeRequests)
                    .HasForeignKey(d => d.AssetTypeId)
                    .HasConstraintName("FK_TemplateItemAssetTypeRequests_Types");

                entity.HasOne(d => d.TemplateItem)
                    .WithMany(p => p.TemplateItemAssetTypeRequests)
                    .HasForeignKey(d => d.TemplateItemId)
                    .HasConstraintName("FK_TemplateItemAssetTypeRequests_TemplateItems");
            });

            modelBuilder.Entity<TemplateItems>(entity =>
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

            modelBuilder.Entity<Templates>(entity =>
            {
                entity.ToTable("Templates", "Schedule");

                entity.Property(e => e.Id).HasDefaultValueSql("newid()");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(256);
            });

            modelBuilder.Entity<TimeBandBaseScheduleTemplates>(entity =>
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

            modelBuilder.Entity<TimeBandBases>(entity =>
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

            modelBuilder.Entity<TimeBandDays>(entity =>
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

            modelBuilder.Entity<TimeBandDescriptions>(entity =>
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

            modelBuilder.Entity<TimeBandPrices>(entity =>
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

            modelBuilder.Entity<TimeBandSliceDescriptions>(entity =>
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

            modelBuilder.Entity<TimeBandSliceDurationByTypes>(entity =>
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

            modelBuilder.Entity<TimeBandSliceDurations>(entity =>
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

            modelBuilder.Entity<TimeBandSliceForTypes>(entity =>
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

            modelBuilder.Entity<TimeBandSlices>(entity =>
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

            modelBuilder.Entity<TimeBandTimes>(entity =>
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

            modelBuilder.Entity<TimeBands>(entity =>
            {
                entity.ToTable("TimeBands", "System");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.HasOne(d => d.IdNavigation)
                    .WithOne(p => p.TimeBands)
                    .HasForeignKey<TimeBands>(d => d.Id)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_TimeBands_Groups");
            });

            modelBuilder.Entity<TypeDetails>(entity =>
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

            modelBuilder.Entity<UploadingFile>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(500);
            });

            modelBuilder.Entity<UploadingPart>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(500);

                entity.HasOne(d => d.UploadingFile)
                    .WithMany(p => p.UploadingPart)
                    .HasForeignKey(d => d.UploadingFileId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_UploadingPart_UploadingFile");
            });

            modelBuilder.Entity<UploadingPartTemp>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(500);

                entity.HasOne(d => d.UploadingPart)
                    .WithMany(p => p.UploadingPartTemp)
                    .HasForeignKey(d => d.UploadingPartId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_UploadingPartTemp_UploadingPart");
            });

            modelBuilder.Entity<UriTypes>(entity =>
            {
                entity.ToTable("UriTypes", "Storage");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(256);
            });

            modelBuilder.Entity<UserPermissions>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.PermissionId })
                    .HasName("PK_User_Permissions");

                entity.ToTable("User_Permissions", "Security");

                entity.HasOne(d => d.Permission)
                    .WithMany(p => p.UserPermissions)
                    .HasForeignKey(d => d.PermissionId)
                    .HasConstraintName("FK_User_Permissions_Permissions");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.UserPermissions)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_User_Permissions_Users");
            });

            modelBuilder.Entity<Users>(entity =>
            {
                entity.ToTable("Users", "Security");

                entity.HasIndex(e => e.UserName)
                    .HasName("IX_Users_UserName")
                    .IsUnique();

                entity.Property(e => e.Id).HasDefaultValueSql("newid()");

                entity.Property(e => e.Active).HasDefaultValueSql("0");

                entity.Property(e => e.Email).HasMaxLength(256);

                entity.Property(e => e.Name).HasMaxLength(256);

                entity.Property(e => e.PasswordHash).IsRequired();

                entity.Property(e => e.PhoneNumber).HasMaxLength(50);

                entity.Property(e => e.UserName)
                    .IsRequired()
                    .HasMaxLength(256);
            });

            modelBuilder.Entity<Versions>(entity =>
            {
                entity.ToTable("Versions", "Media");

                entity.HasIndex(e => new { e.AssetId, e.Active })
                    .HasName("IX_Versions_Active")
                    .IsUnique();

                entity.HasIndex(e => new { e.AssetId, e.Versions1 })
                    .HasName("IX_Versions")
                    .IsUnique();

                entity.Property(e => e.Id).HasDefaultValueSql("newid()");

                entity.Property(e => e.Active).HasDefaultValueSql("0");

                entity.Property(e => e.CreateTime)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("getdate()");

                entity.Property(e => e.Versions1)
                    .HasColumnName("Versions")
                    .HasDefaultValueSql("0");

                entity.HasOne(d => d.Asset)
                    .WithMany(p => p.Versions)
                    .HasForeignKey(d => d.AssetId)
                    .HasConstraintName("FK_Versions_Assets");

                entity.HasOne(d => d.Scene)
                    .WithMany(p => p.Versions)
                    .HasForeignKey(d => d.SceneId)
                    .HasConstraintName("FK_Versions_Broadcasts");
            });
        }
    }
}