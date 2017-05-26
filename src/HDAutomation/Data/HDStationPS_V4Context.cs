using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using HDAutomation.Models;

namespace HDAutomation.Data
{
    public partial class HDStationPS_V4Context : DbContext
    {
        public HDStationPS_V4Context(DbContextOptions<HDStationPS_V4Context> options) : base(options) { }
        public virtual DbSet<Cluster> Cluster { get; set; }
        public virtual DbSet<GroupClip> GroupClip { get; set; }
        public virtual DbSet<Hdimport> Hdimport { get; set; }
        public virtual DbSet<HdimportLog> HdimportLog { get; set; }
        public virtual DbSet<HdimportRun> HdimportRun { get; set; }
        public virtual DbSet<HdsyncV4> HdsyncV4 { get; set; }
        public virtual DbSet<HdsyncV4InforTape> HdsyncV4InforTape { get; set; }
        public virtual DbSet<HdsyncV4TblAfdtypes> HdsyncV4TblAfdtypes { get; set; }
        public virtual DbSet<HdsyncV4TblClipTypes> HdsyncV4TblClipTypes { get; set; }
        public virtual DbSet<HdsyncV4TblSectors> HdsyncV4TblSectors { get; set; }
        public virtual DbSet<InforTape> InforTape { get; set; }
        public virtual DbSet<LogoSetting> LogoSetting { get; set; }
        public virtual DbSet<PlayList> PlayList { get; set; }
        public virtual DbSet<PlayListHistory> PlayListHistory { get; set; }
        public virtual DbSet<PlayListItem> PlayListItem { get; set; }
        public virtual DbSet<Sysdiagrams> Sysdiagrams { get; set; }
        public virtual DbSet<SystemSms> SystemSms { get; set; }
        public virtual DbSet<TblAfdtypes> TblAfdtypes { get; set; }
        public virtual DbSet<TblAsRunLog> TblAsRunLog { get; set; }
        public virtual DbSet<TblAttachments> TblAttachments { get; set; }
        public virtual DbSet<TblAuxiliaryEvents> TblAuxiliaryEvents { get; set; }
        public virtual DbSet<TblBookingStatus> TblBookingStatus { get; set; }
        public virtual DbSet<TblCgComponentProperties> TblCgComponentProperties { get; set; }
        public virtual DbSet<TblCgComponents> TblCgComponents { get; set; }
        public virtual DbSet<TblCgCounter> TblCgCounter { get; set; }
        public virtual DbSet<TblCgEvent> TblCgEvent { get; set; }
        public virtual DbSet<TblCgImage> TblCgImage { get; set; }
        public virtual DbSet<TblCgItem> TblCgItem { get; set; }
        public virtual DbSet<TblCgPlayList> TblCgPlayList { get; set; }
        public virtual DbSet<TblCgPlaylistItem> TblCgPlaylistItem { get; set; }
        public virtual DbSet<TblCgPlaylistItemPropertyValue> TblCgPlaylistItemPropertyValue { get; set; }
        public virtual DbSet<TblCgProperties> TblCgProperties { get; set; }
        public virtual DbSet<TblCgTemplate> TblCgTemplate { get; set; }
        public virtual DbSet<TblCgTemplateComponents> TblCgTemplateComponents { get; set; }
        public virtual DbSet<TblCgTemplateTemplatePropertyValue> TblCgTemplateTemplatePropertyValue { get; set; }
        public virtual DbSet<TblCgTemplateTemplates> TblCgTemplateTemplates { get; set; }
        public virtual DbSet<TblCgTemplateTemplatesDefault> TblCgTemplateTemplatesDefault { get; set; }
        public virtual DbSet<TblCgTemplates> TblCgTemplates { get; set; }
        public virtual DbSet<TblCgText> TblCgText { get; set; }
        public virtual DbSet<TblCgVideo> TblCgVideo { get; set; }
        public virtual DbSet<TblCglayer> TblCglayer { get; set; }
        public virtual DbSet<TblCgmedia> TblCgmedia { get; set; }
        public virtual DbSet<TblCgserver> TblCgserver { get; set; }
        public virtual DbSet<TblClipLiveEmployment> TblClipLiveEmployment { get; set; }
        public virtual DbSet<TblClipLiveStudioBooking> TblClipLiveStudioBooking { get; set; }
        public virtual DbSet<TblClipOnAir> TblClipOnAir { get; set; }
        public virtual DbSet<TblClipQuangCao> TblClipQuangCao { get; set; }
        public virtual DbSet<TblClipTypeCglayer> TblClipTypeCglayer { get; set; }
        public virtual DbSet<TblClipTypes> TblClipTypes { get; set; }
        public virtual DbSet<TblConfigParams> TblConfigParams { get; set; }
        public virtual DbSet<TblConnections> TblConnections { get; set; }
        public virtual DbSet<TblControllerServers> TblControllerServers { get; set; }
        public virtual DbSet<TblDeco> TblDeco { get; set; }
        public virtual DbSet<TblDecoBooking> TblDecoBooking { get; set; }
        public virtual DbSet<TblDecoStatus> TblDecoStatus { get; set; }
        public virtual DbSet<TblDegrees> TblDegrees { get; set; }
        public virtual DbSet<TblDepartments> TblDepartments { get; set; }
        public virtual DbSet<TblDeviceImages> TblDeviceImages { get; set; }
        public virtual DbSet<TblDomains> TblDomains { get; set; }
        public virtual DbSet<TblEmployees> TblEmployees { get; set; }
        public virtual DbSet<TblEmploymentGroup> TblEmploymentGroup { get; set; }
        public virtual DbSet<TblEmployments> TblEmployments { get; set; }
        public virtual DbSet<TblEquipmentAccessory> TblEquipmentAccessory { get; set; }
        public virtual DbSet<TblEquipmentBooking> TblEquipmentBooking { get; set; }
        public virtual DbSet<TblEquipmentCategories> TblEquipmentCategories { get; set; }
        public virtual DbSet<TblEquipmentRepair> TblEquipmentRepair { get; set; }
        public virtual DbSet<TblEquipmentStatus> TblEquipmentStatus { get; set; }
        public virtual DbSet<TblEquipments> TblEquipments { get; set; }
        public virtual DbSet<TblFtpServers> TblFtpServers { get; set; }
        public virtual DbSet<TblGroups> TblGroups { get; set; }
        public virtual DbSet<TblHdingestRecordList> TblHdingestRecordList { get; set; }
        public virtual DbSet<TblHdlog> TblHdlog { get; set; }
        public virtual DbSet<TblHdsatrecordList> TblHdsatrecordList { get; set; }
        public virtual DbSet<TblInfoAudio> TblInfoAudio { get; set; }
        public virtual DbSet<TblInforTapeProcess> TblInforTapeProcess { get; set; }
        public virtual DbSet<TblInforTapeWorkflow> TblInforTapeWorkflow { get; set; }
        public virtual DbSet<TblIngestUsingResource> TblIngestUsingResource { get; set; }
        public virtual DbSet<TblIntermediatePoints> TblIntermediatePoints { get; set; }
        public virtual DbSet<TblJobs> TblJobs { get; set; }
        public virtual DbSet<TblListCopy> TblListCopy { get; set; }
        public virtual DbSet<TblListItemCopy> TblListItemCopy { get; set; }
        public virtual DbSet<TblLiveNews> TblLiveNews { get; set; }
        public virtual DbSet<TblLiveSourcePorts> TblLiveSourcePorts { get; set; }
        public virtual DbSet<TblLocalMessage> TblLocalMessage { get; set; }
        public virtual DbSet<TblLocalNews> TblLocalNews { get; set; }
        public virtual DbSet<TblLocalNewsCategory> TblLocalNewsCategory { get; set; }
        public virtual DbSet<TblLocalNewsComment> TblLocalNewsComment { get; set; }
        public virtual DbSet<TblLocalNotification> TblLocalNotification { get; set; }
        public virtual DbSet<TblLto> TblLto { get; set; }
        public virtual DbSet<TblLtobackup> TblLtobackup { get; set; }
        public virtual DbSet<TblMasterClipRepeat> TblMasterClipRepeat { get; set; }
        public virtual DbSet<TblMasterClipRerun> TblMasterClipRerun { get; set; }
        public virtual DbSet<TblMasterClipStatus> TblMasterClipStatus { get; set; }
        public virtual DbSet<TblMasterClips> TblMasterClips { get; set; }
        public virtual DbSet<TblMasterPlaylistApproval> TblMasterPlaylistApproval { get; set; }
        public virtual DbSet<TblMasterPlaylistItems> TblMasterPlaylistItems { get; set; }
        public virtual DbSet<TblMasterPlaylists> TblMasterPlaylists { get; set; }
        public virtual DbSet<TblMcsservers> TblMcsservers { get; set; }
        public virtual DbSet<TblMenuItem> TblMenuItem { get; set; }
        public virtual DbSet<TblModulesInSector> TblModulesInSector { get; set; }
        public virtual DbSet<TblMonitorAttributes> TblMonitorAttributes { get; set; }
        public virtual DbSet<TblMonitorDeviceLogs> TblMonitorDeviceLogs { get; set; }
        public virtual DbSet<TblMonitorDeviceTypeAttribute> TblMonitorDeviceTypeAttribute { get; set; }
        public virtual DbSet<TblMonitorDeviceTypes> TblMonitorDeviceTypes { get; set; }
        public virtual DbSet<TblMonitorDevices> TblMonitorDevices { get; set; }
        public virtual DbSet<TblMonitorLink> TblMonitorLink { get; set; }
        public virtual DbSet<TblMonitorSectorDevices> TblMonitorSectorDevices { get; set; }
        public virtual DbSet<TblMonitorSectors> TblMonitorSectors { get; set; }
        public virtual DbSet<TblNasTable> TblNasTable { get; set; }
        public virtual DbSet<TblNascurrentConnections> TblNascurrentConnections { get; set; }
        public virtual DbSet<TblNews> TblNews { get; set; }
        public virtual DbSet<TblNewsApproveStatus> TblNewsApproveStatus { get; set; }
        public virtual DbSet<TblNewsCheck> TblNewsCheck { get; set; }
        public virtual DbSet<TblNewsContent> TblNewsContent { get; set; }
        public virtual DbSet<TblNewsDecoBooking> TblNewsDecoBooking { get; set; }
        public virtual DbSet<TblNewsProcess> TblNewsProcess { get; set; }
        public virtual DbSet<TblNewsReporters> TblNewsReporters { get; set; }
        public virtual DbSet<TblNewsSource> TblNewsSource { get; set; }
        public virtual DbSet<TblNewsTypes> TblNewsTypes { get; set; }
        public virtual DbSet<TblNewsTypesGroup> TblNewsTypesGroup { get; set; }
        public virtual DbSet<TblNewsVehicleBooking> TblNewsVehicleBooking { get; set; }
        public virtual DbSet<TblNewsVotes> TblNewsVotes { get; set; }
        public virtual DbSet<TblNewsWorkflow> TblNewsWorkflow { get; set; }
        public virtual DbSet<TblOperateServers> TblOperateServers { get; set; }
        public virtual DbSet<TblPermissionGroup> TblPermissionGroup { get; set; }
        public virtual DbSet<TblPermissions> TblPermissions { get; set; }
        public virtual DbSet<TblPlayListItemAuxiliaryEvent> TblPlayListItemAuxiliaryEvent { get; set; }
        public virtual DbSet<TblPlaylistApproval> TblPlaylistApproval { get; set; }
        public virtual DbSet<TblPreliminaryRunDown> TblPreliminaryRunDown { get; set; }
        public virtual DbSet<TblProcesses> TblProcesses { get; set; }
        public virtual DbSet<TblRecordApp> TblRecordApp { get; set; }
        public virtual DbSet<TblRecordList> TblRecordList { get; set; }
        public virtual DbSet<TblRecordLogs> TblRecordLogs { get; set; }
        public virtual DbSet<TblRecorderServers> TblRecorderServers { get; set; }
        public virtual DbSet<TblRemuneration> TblRemuneration { get; set; }
        public virtual DbSet<TblRepair> TblRepair { get; set; }
        public virtual DbSet<TblRouterConnections> TblRouterConnections { get; set; }
        public virtual DbSet<TblRouters> TblRouters { get; set; }
        public virtual DbSet<TblSalaryItem> TblSalaryItem { get; set; }
        public virtual DbSet<TblSalaryReport> TblSalaryReport { get; set; }
        public virtual DbSet<TblSaningestRecordList> TblSaningestRecordList { get; set; }
        public virtual DbSet<TblSans> TblSans { get; set; }
        public virtual DbSet<TblSectorOperateServers> TblSectorOperateServers { get; set; }
        public virtual DbSet<TblSectors> TblSectors { get; set; }
        public virtual DbSet<TblServerDeviceTypes> TblServerDeviceTypes { get; set; }
        public virtual DbSet<TblServerFactory> TblServerFactory { get; set; }
        public virtual DbSet<TblServerFactoryExtension> TblServerFactoryExtension { get; set; }
        public virtual DbSet<TblServerStatus> TblServerStatus { get; set; }
        public virtual DbSet<TblServerTypes> TblServerTypes { get; set; }
        public virtual DbSet<TblServers> TblServers { get; set; }
        public virtual DbSet<TblServicesModule> TblServicesModule { get; set; }
        public virtual DbSet<TblShapes> TblShapes { get; set; }
        public virtual DbSet<TblSpecialities> TblSpecialities { get; set; }
        public virtual DbSet<TblStudioBooking> TblStudioBooking { get; set; }
        public virtual DbSet<TblStudioDeco> TblStudioDeco { get; set; }
        public virtual DbSet<TblStudioEquipment> TblStudioEquipment { get; set; }
        public virtual DbSet<TblStudioRundown> TblStudioRundown { get; set; }
        public virtual DbSet<TblStudioStatus> TblStudioStatus { get; set; }
        public virtual DbSet<TblStudios> TblStudios { get; set; }
        public virtual DbSet<TblTapeTypes> TblTapeTypes { get; set; }
        public virtual DbSet<TblTempStorage> TblTempStorage { get; set; }
        public virtual DbSet<TblThiemLogPlayList> TblThiemLogPlayList { get; set; }
        public virtual DbSet<TblTranscodeEvent> TblTranscodeEvent { get; set; }
        public virtual DbSet<TblTranscoder> TblTranscoder { get; set; }
        public virtual DbSet<TblUserGroup> TblUserGroup { get; set; }
        public virtual DbSet<TblUsers> TblUsers { get; set; }
        public virtual DbSet<TblVehicleBooking> TblVehicleBooking { get; set; }
        public virtual DbSet<TblVehicleStatus> TblVehicleStatus { get; set; }
        public virtual DbSet<TblVehicleTypes> TblVehicleTypes { get; set; }
        public virtual DbSet<TblVehicles> TblVehicles { get; set; }
        public virtual DbSet<TblViewer> TblViewer { get; set; }
        public virtual DbSet<TblViewerNewsCategory> TblViewerNewsCategory { get; set; }
        public virtual DbSet<TblViewerVideo> TblViewerVideo { get; set; }
        public virtual DbSet<TblWorkflowProcess> TblWorkflowProcess { get; set; }
        public virtual DbSet<TblWorkflows> TblWorkflows { get; set; }
        public virtual DbSet<TempPlayListItem> TempPlayListItem { get; set; }
        public virtual DbSet<V4branch> V4branch { get; set; }
        public virtual DbSet<V4sectorBranch> V4sectorBranch { get; set; }

        // Unable to generate entity type for table 'dbo.tblHDLog_Category'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.PlayListBlockIP'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.PlayListBlockSetting'. Please see the warning messages.

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cluster>(entity =>
            {
                entity.Property(e => e.ListId).HasColumnName("ListID");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.HasOne(d => d.List)
                    .WithMany(p => p.Cluster)
                    .HasForeignKey(d => d.ListId)
                    .HasConstraintName("FK__Cluster__ListID__58DC1D15");

                entity.HasOne(d => d.ParentCluster)
                    .WithMany(p => p.InverseParentCluster)
                    .HasForeignKey(d => d.ParentClusterId)
                    .HasConstraintName("FK_Cluster_Cluster");
            });

            modelBuilder.Entity<GroupClip>(entity =>
            {
                entity.Property(e => e.GroupName)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.NumberOfClip).HasDefaultValueSql("0");
            });

            modelBuilder.Entity<Hdimport>(entity =>
            {
                entity.ToTable("HDImport");

                entity.Property(e => e.CreateTime)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("getdate()");

                entity.Property(e => e.FileCurrent).IsRequired();

                entity.Property(e => e.FileSource).IsRequired();

                entity.Property(e => e.Idclip).HasColumnName("IDClip");

                entity.Property(e => e.Message).IsRequired();

                entity.Property(e => e.Ntry)
                    .HasColumnName("NTry")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Status).HasDefaultValueSql("0");

                entity.HasOne(d => d.IdclipNavigation)
                    .WithMany(p => p.Hdimport)
                    .HasForeignKey(d => d.Idclip)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK__HDImport__IDClip__59D0414E");
            });

            modelBuilder.Entity<HdimportLog>(entity =>
            {
                entity.ToTable("HDImportLog");

                entity.Property(e => e.Idclip).HasColumnName("IDClip");

                entity.Property(e => e.LogTime)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("getdate()");

                entity.Property(e => e.MaBang).HasMaxLength(50);
            });

            modelBuilder.Entity<HdimportRun>(entity =>
            {
                entity.ToTable("HDImportRun");

                entity.HasIndex(e => e.IdImport)
                    .HasName("UQ__HDImport__0B4267F84D4A6ED8")
                    .IsUnique();

                entity.Property(e => e.StartTime)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("getdate()");

                entity.HasOne(d => d.IdImportNavigation)
                    .WithOne(p => p.HdimportRun)
                    .HasForeignKey<HdimportRun>(d => d.IdImport)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK__HDImportR__IdImp__5AC46587");
            });

            modelBuilder.Entity<HdsyncV4>(entity =>
            {
                entity.HasKey(e => e.IdDatabase)
                    .HasName("PK_HDSyncV4");

                entity.ToTable("HDSyncV4");

                entity.Property(e => e.IdDatabase).ValueGeneratedNever();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<HdsyncV4InforTape>(entity =>
            {
                entity.HasKey(e => new { e.IdDatabase, e.SyncId })
                    .HasName("PK_HDSyncV4_InforTAPE");

                entity.ToTable("HDSyncV4_InforTAPE");

                entity.Property(e => e.Changed).HasDefaultValueSql("0");

                entity.Property(e => e.ChangedStorage).HasDefaultValueSql("1");

                entity.HasOne(d => d.IdDatabaseNavigation)
                    .WithMany(p => p.HdsyncV4InforTape)
                    .HasForeignKey(d => d.IdDatabase)
                    .HasConstraintName("FK_HDSyncV4_InforTAPE_HDSyncV4");

                entity.HasOne(d => d.Sync)
                    .WithMany(p => p.HdsyncV4InforTape)
                    .HasPrincipalKey(p => p.SyncId)
                    .HasForeignKey(d => d.SyncId)
                    .HasConstraintName("FK_HDSyncV4_InforTAPE_InforTAPE");
            });

            modelBuilder.Entity<HdsyncV4TblAfdtypes>(entity =>
            {
                entity.HasKey(e => new { e.IdDatabase, e.SyncId })
                    .HasName("PK_HDSyncV4_tblAFDTypes");

                entity.ToTable("HDSyncV4_tblAFDTypes");

                entity.Property(e => e.Changed).HasDefaultValueSql("0");

                entity.HasOne(d => d.IdDatabaseNavigation)
                    .WithMany(p => p.HdsyncV4TblAfdtypes)
                    .HasForeignKey(d => d.IdDatabase)
                    .HasConstraintName("FK_HDSyncV4_tblAFDTypes_HDSyncV4");

                entity.HasOne(d => d.Sync)
                    .WithMany(p => p.HdsyncV4TblAfdtypes)
                    .HasPrincipalKey(p => p.SyncId)
                    .HasForeignKey(d => d.SyncId)
                    .HasConstraintName("FK_HDSyncV4_tblAFDTypes_tblAFDTypes");
            });

            modelBuilder.Entity<HdsyncV4TblClipTypes>(entity =>
            {
                entity.HasKey(e => new { e.IdDatabase, e.SyncId })
                    .HasName("PK_HDSyncV4_tblClipTypes");

                entity.ToTable("HDSyncV4_tblClipTypes");

                entity.Property(e => e.Changed).HasDefaultValueSql("0");

                entity.HasOne(d => d.IdDatabaseNavigation)
                    .WithMany(p => p.HdsyncV4TblClipTypes)
                    .HasForeignKey(d => d.IdDatabase)
                    .HasConstraintName("FK_HDSyncV4_tblClipTypes_HDSyncV4");

                entity.HasOne(d => d.Sync)
                    .WithMany(p => p.HdsyncV4TblClipTypes)
                    .HasPrincipalKey(p => p.SyncId)
                    .HasForeignKey(d => d.SyncId)
                    .HasConstraintName("FK_HDSyncV4_tblClipTypes_tblClipTypes");
            });

            modelBuilder.Entity<HdsyncV4TblSectors>(entity =>
            {
                entity.HasKey(e => new { e.IdDatabase, e.SyncId })
                    .HasName("PK_HDSyncV4_tblSectors");

                entity.ToTable("HDSyncV4_tblSectors");

                entity.Property(e => e.Changed).HasDefaultValueSql("0");

                entity.HasOne(d => d.IdDatabaseNavigation)
                    .WithMany(p => p.HdsyncV4TblSectors)
                    .HasForeignKey(d => d.IdDatabase)
                    .HasConstraintName("FK_HDSyncV4_tblSectors_HDSyncV4");

                entity.HasOne(d => d.Sync)
                    .WithMany(p => p.HdsyncV4TblSectors)
                    .HasPrincipalKey(p => p.SyncId)
                    .HasForeignKey(d => d.SyncId)
                    .HasConstraintName("FK_HDSyncV4_tblSectors_tblSectors");
            });

            modelBuilder.Entity<InforTape>(entity =>
            {
                entity.HasKey(e => e.Idclip)
                    .HasName("PK__InforTAP__39E0B39E727BF387");

                entity.ToTable("InforTAPE");

                entity.HasIndex(e => e.SyncId)
                    .HasName("IX_InforTAPE")
                    .IsUnique();

                entity.Property(e => e.Idclip).HasColumnName("IDClip");

                entity.Property(e => e.AfdType)
                    .HasColumnName("AFD_Type")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.AllowArchiving).HasDefaultValueSql("0");

                entity.Property(e => e.Approved).HasDefaultValueSql("0");

                entity.Property(e => e.ApproverComment).HasMaxLength(500);

                entity.Property(e => e.AspectRatio).HasMaxLength(50);

                entity.Property(e => e.AudioLevel).HasDefaultValueSql("0");

                entity.Property(e => e.CanCopy).HasDefaultValueSql("0");

                entity.Property(e => e.Cgnow).HasColumnName("CGNow");

                entity.Property(e => e.Cgnow12).HasColumnName("CGNow1_2");

                entity.Property(e => e.Cgtop).HasColumnName("CGTop");

                entity.Property(e => e.CgtopNumber).HasColumnName("CGTopNumber");

                entity.Property(e => e.ChangedPcd).HasColumnName("ChangedPCD");

                entity.Property(e => e.CheckOnServer).HasDefaultValueSql("0");

                entity.Property(e => e.ClipSourceType).HasDefaultValueSql("0");

                entity.Property(e => e.Codec).HasMaxLength(50);

                entity.Property(e => e.CreateDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("'1/1/2012'");

                entity.Property(e => e.EndRights)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("'1/1/2012'");

                entity.Property(e => e.FileName).HasMaxLength(200);

                entity.Property(e => e.FileSize).HasDefaultValueSql("0");

                entity.Property(e => e.FrameRate).HasDefaultValueSql("25");

                entity.Property(e => e.Hdclip)
                    .HasColumnName("HDClip")
                    .HasMaxLength(300);

                entity.Property(e => e.IsRaw).HasDefaultValueSql("0");

                entity.Property(e => e.Isnas).HasColumnName("ISNAS");

                entity.Property(e => e.Isserver)
                    .HasColumnName("ISSERVER")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Isvtr)
                    .HasColumnName("ISVTR")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Keywords).HasMaxLength(300);

                entity.Property(e => e.LastAccessedTime)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("'1/1/2012'");

                entity.Property(e => e.Ltoid).HasColumnName("LTOID");

                entity.Property(e => e.Mabang)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.NasId)
                    .HasColumnName("NasID")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.NasIdedit)
                    .HasColumnName("NasIDEdit")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.NasIdpreview)
                    .HasColumnName("NasIDPreview")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.NasIdtemporary)
                    .HasColumnName("NasIDTemporary")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Note).HasMaxLength(200);

                entity.Property(e => e.OriginalServiceRequest).HasDefaultValueSql("0");

                entity.Property(e => e.PostContentVstvcheck)
                    .HasColumnName("PostContentVSTVCheck")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.PostContentVstvcheckNote)
                    .HasColumnName("PostContentVSTVCheckNote")
                    .HasMaxLength(100);

                entity.Property(e => e.PostContentVtvcheck)
                    .HasColumnName("PostContentVTVCheck")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.PostContentVtvcheckNote)
                    .HasColumnName("PostContentVTVCheckNote")
                    .HasMaxLength(100);

                entity.Property(e => e.PostQualityCheck).HasDefaultValueSql("0");

                entity.Property(e => e.PostQualityCheckNote).HasMaxLength(100);

                entity.Property(e => e.RawCheck).HasDefaultValueSql("0");

                entity.Property(e => e.RawCheckNote).HasMaxLength(100);

                entity.Property(e => e.RealTcIn)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasDefaultValueSql("N'00:00:00.00'");

                entity.Property(e => e.RealTcOut)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasDefaultValueSql("N'00:00:00.00'");

                entity.Property(e => e.Recorddate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("'1/1/2012'");

                entity.Property(e => e.Rtbchecking)
                    .HasColumnName("RTBChecking")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Runs).HasMaxLength(50);

                entity.Property(e => e.ServiceLowResStatus).HasDefaultValueSql("0");

                entity.Property(e => e.ServicePriority).HasDefaultValueSql("0");

                entity.Property(e => e.ServiceRequest).HasDefaultValueSql("0");

                entity.Property(e => e.ServiceSubtitleStatus).HasDefaultValueSql("0");

                entity.Property(e => e.ServiceVoiceOverStatus).HasDefaultValueSql("0");

                entity.Property(e => e.Source)
                    .HasColumnName("SOURCE")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.StartRights)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("'1/1/2012'");

                entity.Property(e => e.SyncId).HasDefaultValueSql("newid()");

                entity.Property(e => e.TcIn)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Tcout)
                    .IsRequired()
                    .HasColumnName("TCOut")
                    .HasMaxLength(50);

                entity.Property(e => e.TemporaryFileName).HasMaxLength(200);

                entity.Property(e => e.Tenchuongtrinh).HasMaxLength(200);

                entity.Property(e => e.Timetolive)
                    .HasColumnName("timetolive")
                    .HasDefaultValueSql("3");

                entity.Property(e => e.TitleOrigin).HasMaxLength(200);

                entity.Property(e => e.Tl)
                    .HasColumnName("TL")
                    .HasMaxLength(50);

                entity.Property(e => e.Type).HasDefaultValueSql("0");

                entity.Property(e => e.UserIdPostContentVstvcheck).HasColumnName("UserIdPostContentVSTVCheck");

                entity.Property(e => e.UserIdPostContentVtvcheck).HasColumnName("UserIdPostContentVTVCheck");

                entity.Property(e => e.UserIdRtbchecking)
                    .HasColumnName("UserIdRTBChecking")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Userid)
                    .HasColumnName("userid")
                    .HasDefaultValueSql("1");

                entity.Property(e => e.Version)
                    .HasColumnName("version")
                    .HasMaxLength(50);

                entity.Property(e => e.VersionFileDate).HasMaxLength(50);

                entity.Property(e => e.VideoFormat)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasDefaultValueSql("N'SD'");
            });

            modelBuilder.Entity<LogoSetting>(entity =>
            {
                entity.HasKey(e => e.SettingId)
                    .HasName("PK__LogoSett__54372AFD7834CCDD");

                entity.Property(e => e.SettingId)
                    .HasColumnName("SettingID")
                    .ValueGeneratedNever();

                entity.Property(e => e.Comment).HasColumnType("varchar(255)");
            });

            modelBuilder.Entity<PlayList>(entity =>
            {
                entity.HasKey(e => e.ListId)
                    .HasName("PK__PlayList__E38328657CF981FA");

                entity.Property(e => e.ListId).HasColumnName("ListID");

                entity.Property(e => e.ApproverId).HasColumnName("approverID");

                entity.Property(e => e.Cueline)
                    .HasColumnName("cueline")
                    .HasDefaultValueSql("-1");

                entity.Property(e => e.DateList).HasColumnType("datetime");

                entity.Property(e => e.Islock).HasColumnName("islock");

                entity.Property(e => e.Isupdate).HasColumnName("isupdate");

                entity.Property(e => e.LastTime).HasColumnType("datetime");

                entity.Property(e => e.Playline).HasColumnName("playline");

                entity.Property(e => e.SystemId).HasColumnName("SystemID");

                entity.Property(e => e.TimeLast)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("getdate()");

                entity.Property(e => e.TimeStart).HasMaxLength(50);
            });

            modelBuilder.Entity<PlayListHistory>(entity =>
            {
                entity.ToTable("PlayList_History");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.DateList).HasColumnType("datetime");

                entity.Property(e => e.LastTime)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("getdate()");

                entity.Property(e => e.SectorName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.UserName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Value).IsRequired();
            });

            modelBuilder.Entity<PlayListItem>(entity =>
            {
                entity.ToTable("PlayList_Item");

                entity.HasIndex(e => e.SyncId)
                    .HasName("IX_PlayList_Item")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.ColorDisplay).HasMaxLength(50);

                entity.Property(e => e.Command).HasMaxLength(50);

                entity.Property(e => e.CommandAtEnd)
                    .HasMaxLength(200)
                    .HasDefaultValueSql("N'NEXT'");

                entity.Property(e => e.EventType).HasDefaultValueSql("0");

                entity.Property(e => e.Idclip).HasColumnName("IDCLip");

                entity.Property(e => e.IdclipSubstitute).HasColumnName("IDClipSubstitute");

                entity.Property(e => e.ListId).HasColumnName("ListID");

                entity.Property(e => e.PlayTcIn).HasMaxLength(50);

                entity.Property(e => e.PlayTcOut).HasMaxLength(50);

                entity.Property(e => e.PlayTime).HasMaxLength(50);

                entity.Property(e => e.RealPlayTcIn).HasMaxLength(50);

                entity.Property(e => e.RealPlayTcOut).HasMaxLength(50);

                entity.Property(e => e.RouterInput).HasDefaultValueSql("0");

                entity.Property(e => e.RowColor).HasColumnType("char(8)");

                entity.Property(e => e.Setting).HasDefaultValueSql("0");

                entity.Property(e => e.StandbyPlaylistId).HasColumnName("StandbyPlaylistID");

                entity.Property(e => e.StartTime).HasMaxLength(50);

                entity.Property(e => e.Status).HasDefaultValueSql("0");

                entity.Property(e => e.SyncId).HasDefaultValueSql("newid()");
            });

            modelBuilder.Entity<Sysdiagrams>(entity =>
            {
                entity.HasKey(e => e.DiagramId)
                    .HasName("PK__sysdiagr__C2B05B61049AA3C2");

                entity.ToTable("sysdiagrams");

                entity.HasIndex(e => new { e.PrincipalId, e.Name })
                    .HasName("UQ__sysdiagr__532EC1540777106D")
                    .IsUnique();

                entity.Property(e => e.DiagramId).HasColumnName("diagram_id");

                entity.Property(e => e.Definition).HasColumnName("definition");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasColumnType("sysname");

                entity.Property(e => e.PrincipalId).HasColumnName("principal_id");

                entity.Property(e => e.Version).HasColumnName("version");
            });

            modelBuilder.Entity<SystemSms>(entity =>
            {
                entity.ToTable("SYSTEM_SMS");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Datecreate)
                    .HasColumnName("DATECREATE")
                    .HasColumnType("datetime");

                entity.Property(e => e.Dateresponse)
                    .HasColumnName("DATERESPONSE")
                    .HasColumnType("datetime");

                entity.Property(e => e.Retry)
                    .HasColumnName("RETRY")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Sms)
                    .HasColumnName("SMS")
                    .HasMaxLength(160);

                entity.Property(e => e.Status)
                    .HasColumnName("STATUS")
                    .HasColumnType("varchar(50)")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Target)
                    .HasColumnName("TARGET")
                    .HasColumnType("varchar(50)");
            });

            modelBuilder.Entity<TblAfdtypes>(entity =>
            {
                entity.HasKey(e => e.AfdId)
                    .HasName("PK__tblAFDTy__8E44A8D212E8C319");

                entity.ToTable("tblAFDTypes");

                entity.HasIndex(e => e.SyncId)
                    .HasName("IX_tblAFDTypes")
                    .IsUnique();

                entity.Property(e => e.AfdId)
                    .HasColumnName("AfdID")
                    .ValueGeneratedNever();

                entity.Property(e => e.ChangedPcd).HasColumnName("ChangedPCD");

                entity.Property(e => e.Description).HasColumnType("varchar(255)");

                entity.Property(e => e.SyncId).HasDefaultValueSql("newid()");

                entity.Property(e => e.VideoFormat).HasColumnType("varchar(255)");
            });

            modelBuilder.Entity<TblAsRunLog>(entity =>
            {
                entity.HasKey(e => e.PlayLogsId)
                    .HasName("PK__tblAsRun__D5AFE2F716B953FD");

                entity.ToTable("tblAsRunLog");

                entity.HasIndex(e => e.IdClip)
                    .HasName("IX_tblAsRunLog");

                entity.Property(e => e.PlayLogsId).HasColumnName("PlayLogsID");

                entity.Property(e => e.FinishTime).HasColumnType("datetime");

                entity.Property(e => e.PlayTcIn)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.PlayTcOut)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.PlayTime).HasColumnType("datetime");

                entity.Property(e => e.ProgramName).HasMaxLength(200);

                entity.Property(e => e.Result).HasMaxLength(100);

                entity.Property(e => e.TapeId).HasMaxLength(50);
            });

            modelBuilder.Entity<TblAttachments>(entity =>
            {
                entity.HasKey(e => e.AttachedId)
                    .HasName("PK__tblAttac__126D6ACA1995C0A8");

                entity.ToTable("tblAttachments");

                entity.Property(e => e.AttachedId).ValueGeneratedNever();

                entity.Property(e => e.FileName).HasMaxLength(200);

                entity.Property(e => e.UploadTime).HasColumnType("datetime");
            });

            modelBuilder.Entity<TblAuxiliaryEvents>(entity =>
            {
                entity.HasKey(e => e.AuxiliaryEventTypeId)
                    .HasName("PK__tblAuxil__316F9EF31C722D53");

                entity.ToTable("tblAuxiliaryEvents");

                entity.Property(e => e.AuxiliaryEventTypeId).ValueGeneratedNever();

                entity.Property(e => e.AuxialiaryEventTypeDescription).HasMaxLength(50);
            });

            modelBuilder.Entity<TblBookingStatus>(entity =>
            {
                entity.HasKey(e => e.BookingApproveStatusId)
                    .HasName("PK__tblBooki__BEAE3E971F4E99FE");

                entity.ToTable("tblBookingStatus");

                entity.Property(e => e.BookingApproveStatusId).ValueGeneratedNever();
            });

            modelBuilder.Entity<TblCgComponentProperties>(entity =>
            {
                entity.ToTable("tblCG_Component_Properties");

                entity.Property(e => e.ComponentPropertyName).HasMaxLength(50);
            });

            modelBuilder.Entity<TblCgComponents>(entity =>
            {
                entity.HasKey(e => e.ComponentId)
                    .HasName("PK__tblCG_Co__D79CF04E25077354");

                entity.ToTable("tblCG_Components");

                entity.Property(e => e.ComponentName).HasMaxLength(50);
            });

            modelBuilder.Entity<TblCgCounter>(entity =>
            {
                entity.ToTable("tblCgCounter");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Format)
                    .HasColumnName("format")
                    .HasMaxLength(50);

                entity.Property(e => e.Increase).HasColumnName("increase");

                entity.Property(e => e.Invert).HasColumnName("invert");
            });

            modelBuilder.Entity<TblCgEvent>(entity =>
            {
                entity.ToTable("tblCgEvent");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CgitemId).HasColumnName("CGItemId");

                entity.Property(e => e.EndByPlaylistItemId).HasColumnName("endByPlaylistItemId");

                entity.Property(e => e.EndDate)
                    .HasColumnName("endDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.EndMode).HasColumnName("endMode");

                entity.Property(e => e.EndTime)
                    .HasColumnName("endTime")
                    .HasColumnType("nchar(12)");

                entity.Property(e => e.StartByPlaylistItemId).HasColumnName("startByPlaylistItemId");

                entity.Property(e => e.StartDate)
                    .HasColumnName("startDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.StartMode).HasColumnName("startMode");

                entity.Property(e => e.StartTime)
                    .HasColumnName("startTime")
                    .HasColumnType("nchar(12)");
            });

            modelBuilder.Entity<TblCgImage>(entity =>
            {
                entity.ToTable("tblCgImage");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Path)
                    .HasColumnName("path")
                    .HasColumnType("nchar(100)");
            });

            modelBuilder.Entity<TblCgItem>(entity =>
            {
                entity.ToTable("tblCgItem");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Cgcounter).HasColumnName("CGCounter");

                entity.Property(e => e.Cgimage).HasColumnName("CGImage");

                entity.Property(e => e.Cgtemplate).HasColumnName("CGTemplate");

                entity.Property(e => e.Cgtext).HasColumnName("CGText");

                entity.Property(e => e.Cgvideo).HasColumnName("CGVideo");

                entity.Property(e => e.FadeInTime).HasColumnName("fadeInTime");

                entity.Property(e => e.FadeOutTime).HasColumnName("fadeOutTime");

                entity.Property(e => e.Repeat).HasColumnName("repeat");

                entity.Property(e => e.RepeatDelay)
                    .HasColumnName("repeatDelay")
                    .HasColumnType("nchar(12)");

                entity.Property(e => e.RotateEnd).HasColumnName("rotateEnd");

                entity.Property(e => e.RotateSpeed).HasColumnName("rotateSpeed");

                entity.Property(e => e.RotateStart).HasColumnName("rotateStart");

                entity.Property(e => e.ScaleEnd)
                    .HasColumnName("scaleEnd")
                    .HasDefaultValueSql("1");

                entity.Property(e => e.ScaleSpeed).HasColumnName("scaleSpeed");

                entity.Property(e => e.ScaleStart)
                    .HasColumnName("scaleStart")
                    .HasDefaultValueSql("1");

                entity.Property(e => e.Transparent).HasColumnName("transparent");

                entity.Property(e => e.XEnd).HasColumnName("xEnd");

                entity.Property(e => e.XSpeed).HasColumnName("xSpeed");

                entity.Property(e => e.XStart).HasColumnName("xStart");

                entity.Property(e => e.YEnd).HasColumnName("yEnd");

                entity.Property(e => e.YSpeed).HasColumnName("ySpeed");

                entity.Property(e => e.YStart).HasColumnName("yStart");
            });

            modelBuilder.Entity<TblCgPlayList>(entity =>
            {
                entity.HasKey(e => e.CgplayListId)
                    .HasName("PK__tblCG_Pl__46B2529E27E3DFFF");

                entity.ToTable("tblCG_PlayList");

                entity.Property(e => e.CgplayListId).HasColumnName("CGPlayListId");

                entity.Property(e => e.DateList)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("getdate()");
            });
            modelBuilder.Entity<TblCgPlaylistItem>(entity =>
            {
                entity.HasKey(e => e.CgItemId)
                    .HasName("PK__tblCG_Pl__254FA32D2AC04CAA");

                entity.ToTable("tblCG_Playlist_Item");

                entity.Property(e => e.AnchorType).HasDefaultValueSql("0");

                entity.Property(e => e.CganchorTime)
                    .IsRequired()
                    .HasColumnName("CGAnchorTime")
                    .HasColumnType("char(11)");

                entity.Property(e => e.CglayerId).HasColumnName("CGLayerId");

                entity.Property(e => e.CgtemplateTemplateId).HasColumnName("CGTemplateTemplateId");

                entity.Property(e => e.Duration)
                    .IsRequired()
                    .HasColumnType("char(11)")
                    .HasDefaultValueSql("'00:00:00.00'");

                entity.Property(e => e.EndCommand).HasDefaultValueSql("10");

                entity.Property(e => e.FadeInDur).HasDefaultValueSql("0");

                entity.Property(e => e.FadeOutDur).HasDefaultValueSql("0");

                entity.Property(e => e.Layer).HasDefaultValueSql("0");

                entity.Property(e => e.OffWhenEndClip).HasDefaultValueSql("1");

                entity.Property(e => e.StartCommand).HasDefaultValueSql("0");

                entity.HasOne(d => d.Cglayer)
                    .WithMany(p => p.TblCgPlaylistItem)
                    .HasForeignKey(d => d.CglayerId)
                    .HasConstraintName("FK_tblCG_Playlist_Item_tblCGLayer");
            });

            modelBuilder.Entity<TblCgPlaylistItemPropertyValue>(entity =>
            {
                entity.ToTable("tblCG_Playlist_Item_PropertyValue");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.Value).IsRequired();
            });

            modelBuilder.Entity<TblCgProperties>(entity =>
            {
                entity.ToTable("tblCG_Properties");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.PropertyName).HasMaxLength(50);

                entity.Property(e => e.PropertyType).HasDefaultValueSql("1");
            });

            modelBuilder.Entity<TblCgTemplate>(entity =>
            {
                entity.ToTable("tblCgTemplate");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasColumnName("description")
                    .HasMaxLength(50);

                entity.Property(e => e.Duration)
                    .IsRequired()
                    .HasColumnName("duration")
                    .HasColumnType("nchar(12)");
            });

            modelBuilder.Entity<TblCgTemplateComponents>(entity =>
            {
                entity.ToTable("tblCG_Template_Components");
            });

            modelBuilder.Entity<TblCgTemplateTemplatePropertyValue>(entity =>
            {
                entity.ToTable("tblCG_Template_Template_PropertyValue");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Value).IsRequired();

                entity.HasOne(d => d.TemplateTemplate)
                    .WithMany(p => p.TblCgTemplateTemplatePropertyValue)
                    .HasForeignKey(d => d.TemplateTemplateId)
                    .HasConstraintName("FK_tblCG_Template_Template_PropertyValue_tblCG_Template_Templates");
            });

            modelBuilder.Entity<TblCgTemplateTemplates>(entity =>
            {
                entity.ToTable("tblCG_Template_Templates");

                entity.Property(e => e.CganchorTime)
                    .HasColumnName("CGAnchorTime")
                    .HasColumnType("char(11)");

                entity.Property(e => e.CgendAnchorTime)
                    .HasColumnName("CGEndAnchorTime")
                    .HasColumnType("char(11)");

                entity.Property(e => e.CgnumberInClip).HasColumnName("CGNumberInClip");

                entity.Property(e => e.CgspaceInClip)
                    .HasColumnName("CGSpaceInClip")
                    .HasColumnType("char(11)");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.HasOne(d => d.Template)
                    .WithMany(p => p.TblCgTemplateTemplates)
                    .HasForeignKey(d => d.TemplateId)
                    .HasConstraintName("FK_tblCG_Template_Templates_tblCG_Templates");
            });

            modelBuilder.Entity<TblCgTemplateTemplatesDefault>(entity =>
            {
                entity.ToTable("tblCG_Template_Templates_Default");

                entity.Property(e => e.CganchorTime)
                    .HasColumnName("CGAnchorTime")
                    .HasColumnType("char(11)");

                entity.Property(e => e.CgendAnchorTime)
                    .HasColumnName("CGEndAnchorTime")
                    .HasColumnType("char(11)");

                entity.Property(e => e.CgnumberInClip).HasColumnName("CGNumberInClip");

                entity.Property(e => e.CgspaceInClip)
                    .HasColumnName("CGSpaceInClip")
                    .HasColumnType("char(11)");

                entity.Property(e => e.CgtemplateTemplateId).HasColumnName("CGTemplateTemplateId");

                entity.HasOne(d => d.CgtemplateTemplate)
                    .WithMany(p => p.TblCgTemplateTemplatesDefault)
                    .HasForeignKey(d => d.CgtemplateTemplateId)
                    .HasConstraintName("FK_tblCG_Template_Templates_Default_tblCG_Template_Templates");
            });

            modelBuilder.Entity<TblCgTemplates>(entity =>
            {
                entity.HasKey(e => e.TemplateId)
                    .HasName("PK__tblCG_Te__F87ADD2741A3B202");

                entity.ToTable("tblCG_Templates");

                entity.Property(e => e.Duration).HasDefaultValueSql("0");

                entity.Property(e => e.IsServer).HasDefaultValueSql("0");

                entity.Property(e => e.NasId).HasDefaultValueSql("0");

                entity.Property(e => e.TemplateFileName).HasMaxLength(500);

                entity.Property(e => e.TemplateName).HasMaxLength(200);

                entity.Property(e => e.TemplateType).HasDefaultValueSql("0");
            });

            modelBuilder.Entity<TblCgText>(entity =>
            {
                entity.ToTable("tblCgText");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Content)
                    .HasColumnName("content")
                    .HasColumnType("ntext");
            });

            modelBuilder.Entity<TblCgVideo>(entity =>
            {
                entity.ToTable("tblCgVideo");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.PlayTcIn)
                    .IsRequired()
                    .HasColumnName("playTcIn")
                    .HasColumnType("nchar(12)");

                entity.Property(e => e.PlayTcOut)
                    .IsRequired()
                    .HasColumnName("playTcOut")
                    .HasColumnType("nchar(12)");
            });

            modelBuilder.Entity<TblCglayer>(entity =>
            {
                entity.HasKey(e => e.CglayerId)
                    .HasName("PK_tblCGLayer");

                entity.ToTable("tblCGLayer");

                entity.Property(e => e.CglayerId).HasColumnName("CGLayerId");

                entity.Property(e => e.CglayerIndex).HasColumnName("CGLayerIndex");

                entity.Property(e => e.CgtemplateTemplateId).HasColumnName("CGTemplateTemplateId");

                entity.HasOne(d => d.CgtemplateTemplate)
                    .WithMany(p => p.TblCglayer)
                    .HasForeignKey(d => d.CgtemplateTemplateId)
                    .HasConstraintName("FK_tblCGLayer_tblCG_Template_Templates");
            });

            modelBuilder.Entity<TblCgmedia>(entity =>
            {
                entity.HasKey(e => e.Cgid)
                    .HasName("PK__tblCGMed__F4E9B7B54FF1D159");

                entity.ToTable("tblCGMedia");

                entity.Property(e => e.Cgid)
                    .HasColumnName("CGId")
                    .ValueGeneratedNever();

                entity.Property(e => e.Cgdescription)
                    .HasColumnName("CGDescription")
                    .HasMaxLength(100);

                entity.Property(e => e.CgfileName)
                    .HasColumnName("CGFileName")
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<TblCgserver>(entity =>
            {
                entity.HasKey(e => e.CgserverId)
                    .HasName("PK__tblCGSer__D9353E7952CE3E04");

                entity.ToTable("tblCGServer");

                entity.Property(e => e.CgserverId).HasColumnName("CGServerId");

                entity.Property(e => e.CgclassName)
                    .HasColumnName("CGClassName")
                    .HasMaxLength(50);

                entity.Property(e => e.CgcontrolPort)
                    .HasColumnName("CGControlPort")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.CgdllName)
                    .HasColumnName("CGDllName")
                    .HasMaxLength(50);

                entity.Property(e => e.CginputPort).HasColumnName("CGInputPort");

                entity.Property(e => e.CginputRouterId).HasColumnName("CGInputRouterId");

                entity.Property(e => e.Cgipaddress)
                    .HasColumnName("CGIPAddress")
                    .HasMaxLength(50);

                entity.Property(e => e.CgoutputPort).HasColumnName("CGOutputPort");

                entity.Property(e => e.CgoutputRouterId).HasColumnName("CGOutputRouterId");

                entity.Property(e => e.CgserverDescription)
                    .HasColumnName("CGServerDescription")
                    .HasMaxLength(300);

                entity.Property(e => e.CgserverName)
                    .HasColumnName("CGServerName")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<TblClipLiveEmployment>(entity =>
            {
                entity.ToTable("tblClipLive_Employment");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.EndTime).HasColumnType("datetime");

                entity.Property(e => e.StartTime).HasColumnType("datetime");
            });

            modelBuilder.Entity<TblClipLiveStudioBooking>(entity =>
            {
                entity.HasKey(e => new { e.ClipLiveId, e.StudioBookingId })
                    .HasName("PK__tblClipL__652879B663F8CA06");

                entity.ToTable("tblClipLive_StudioBooking");
            });

            modelBuilder.Entity<TblClipOnAir>(entity =>
            {
                entity.ToTable("tblClip_OnAir");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.OnAirTime).HasColumnType("datetime");

                entity.Property(e => e.PlayTcIn).HasMaxLength(12);

                entity.Property(e => e.PlayTcOut).HasMaxLength(12);
            });

            modelBuilder.Entity<TblClipQuangCao>(entity =>
            {
                entity.HasKey(e => new { e.CutId, e.IdClip, e.ClipOrder })
                    .HasName("PK__tblClipQ__E3209A8966D536B1");

                entity.ToTable("tblClipQuangCao");

                entity.Property(e => e.IdClipTvad).HasColumnName("IdClipTVAD");
            });

            modelBuilder.Entity<TblClipTypeCglayer>(entity =>
            {
                entity.ToTable("tblClipType_CGLayer");

                entity.Property(e => e.CglayerId).HasColumnName("CGLayerId");

                entity.HasOne(d => d.Cglayer)
                    .WithMany(p => p.TblClipTypeCglayer)
                    .HasForeignKey(d => d.CglayerId)
                    .HasConstraintName("FK_tblClipType_CGLayer_tblCGLayer");

                entity.HasOne(d => d.Type)
                    .WithMany(p => p.TblClipTypeCglayer)
                    .HasForeignKey(d => d.TypeId)
                    .HasConstraintName("FK_tblClipType_CGLayer_tblClipTypes");
            });

            modelBuilder.Entity<TblClipTypes>(entity =>
            {
                entity.HasKey(e => e.TypeId)
                    .HasName("PK__tblClipT__516F039569B1A35C");

                entity.ToTable("tblClipTypes");

                entity.HasIndex(e => e.SyncId)
                    .HasName("IX_tblClipTypes")
                    .IsUnique();

                entity.Property(e => e.TypeId).HasColumnName("TypeID");

                entity.Property(e => e.ChangedPcd).HasColumnName("ChangedPCD");

                entity.Property(e => e.EvenRowColor).HasColumnType("char(8)");

                entity.Property(e => e.OddRowColor).HasColumnType("char(8)");

                entity.Property(e => e.ShortName).HasMaxLength(50);

                entity.Property(e => e.SyncId).HasDefaultValueSql("newid()");

                entity.Property(e => e.Tvad).HasColumnName("TVAD");

                entity.Property(e => e.TypeDescription).HasMaxLength(50);

                entity.HasOne(d => d.Sector)
                    .WithMany(p => p.TblClipTypes)
                    .HasForeignKey(d => d.SectorId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_tblClipTypes_tblSectors");
            });

            modelBuilder.Entity<TblConfigParams>(entity =>
            {
                entity.HasKey(e => e.ConfigId)
                    .HasName("PK__tblConfi__C3BC335C6D823440");

                entity.ToTable("tblConfigParams");

                entity.Property(e => e.ConfigId).ValueGeneratedNever();

                entity.Property(e => e.ConfigName).HasMaxLength(50);

                entity.Property(e => e.ConfigValue).HasMaxLength(50);
            });

            modelBuilder.Entity<TblConnections>(entity =>
            {
                entity.HasKey(e => e.ConnectId)
                    .HasName("PK__tblConne__BC971B9C705EA0EB");

                entity.ToTable("tblConnections");

                entity.Property(e => e.ConnectId).ValueGeneratedNever();
            });

            modelBuilder.Entity<TblControllerServers>(entity =>
            {
                entity.HasKey(e => e.ControllerServerId)
                    .HasName("PK__tblContr__53E42A73733B0D96");

                entity.ToTable("tblControllerServers");

                entity.Property(e => e.ControllerServerDescription).HasMaxLength(500);

                entity.Property(e => e.ControllerServerIpAddress).HasColumnType("char(15)");

                entity.Property(e => e.ControllerServerName).HasMaxLength(50);
            });

            modelBuilder.Entity<TblDeco>(entity =>
            {
                entity.HasKey(e => e.DecoId)
                    .HasName("PK__tblDeco__75B5942A76177A41");

                entity.ToTable("tblDeco");

                entity.Property(e => e.DecoId).ValueGeneratedNever();

                entity.Property(e => e.BuyDate).HasColumnType("datetime");

                entity.Property(e => e.DecoName).HasMaxLength(100);

                entity.Property(e => e.Price).HasColumnType("money");
            });

            modelBuilder.Entity<TblDecoBooking>(entity =>
            {
                entity.HasKey(e => e.BookingId)
                    .HasName("PK__tblDeco___73951AED78F3E6EC");

                entity.ToTable("tblDeco_Booking");

                entity.Property(e => e.BookingId).ValueGeneratedNever();

                entity.Property(e => e.Approver1Comment).HasMaxLength(500);

                entity.Property(e => e.Approver2Comment).HasMaxLength(500);

                entity.Property(e => e.BookingDate).HasColumnType("datetime");

                entity.Property(e => e.EndDate).HasColumnType("datetime");

                entity.Property(e => e.Notes).HasMaxLength(500);

                entity.Property(e => e.StartDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<TblDecoStatus>(entity =>
            {
                entity.HasKey(e => e.DecoStatusId)
                    .HasName("PK__tblDecoS__27F9E5627BD05397");

                entity.ToTable("tblDecoStatus");

                entity.Property(e => e.DecoStatusId).ValueGeneratedNever();
            });

            modelBuilder.Entity<TblDegrees>(entity =>
            {
                entity.HasKey(e => e.DegreeId)
                    .HasName("PK__tblDegre__4D94AD2E7EACC042");

                entity.ToTable("tblDegrees");

                entity.Property(e => e.DegreeDescription).HasMaxLength(200);
            });

            modelBuilder.Entity<TblDepartments>(entity =>
            {
                entity.HasKey(e => e.DepartmentId)
                    .HasName("PK__tblDepar__B2079BED01892CED");

                entity.ToTable("tblDepartments");

                entity.Property(e => e.Address).HasMaxLength(200);

                entity.Property(e => e.DepartmentName).HasMaxLength(100);

                entity.Property(e => e.Description).HasMaxLength(200);

                entity.Property(e => e.ParentDepartmentId).HasColumnName("ParentDepartmentID");

                entity.Property(e => e.PhoneNumber).HasMaxLength(20);
            });

            modelBuilder.Entity<TblDeviceImages>(entity =>
            {
                entity.HasKey(e => e.ImageId)
                    .HasName("PK__tblDevic__7516F70C04659998");

                entity.ToTable("tblDeviceImages");

                entity.Property(e => e.ImageDescription).HasMaxLength(100);

                entity.Property(e => e.ImageDisplay).HasColumnType("image");
            });

            modelBuilder.Entity<TblDomains>(entity =>
            {
                entity.HasKey(e => e.DomainId)
                    .HasName("PK__tblDomai__2498D75007420643");

                entity.ToTable("tblDomains");

                entity.Property(e => e.DomainId).ValueGeneratedNever();

                entity.Property(e => e.DomainName).HasMaxLength(100);
            });

            modelBuilder.Entity<TblEmployees>(entity =>
            {
                entity.HasKey(e => e.EmployeeId)
                    .HasName("PK__tblEmplo__7AD04F110A1E72EE");

                entity.ToTable("tblEmployees");

                entity.Property(e => e.BirthDate).HasColumnType("datetime");

                entity.Property(e => e.EmailAddress).HasMaxLength(100);

                entity.Property(e => e.ExpireDateOfContact).HasColumnType("datetime");

                entity.Property(e => e.FirstName).HasMaxLength(50);

                entity.Property(e => e.HomeAddress).HasMaxLength(200);

                entity.Property(e => e.JoinDate).HasColumnType("datetime");

                entity.Property(e => e.LastName).HasMaxLength(50);

                entity.Property(e => e.PhoneNumber).HasMaxLength(20);

                entity.Property(e => e.Ssn)
                    .HasColumnName("SSN")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<TblEmploymentGroup>(entity =>
            {
                entity.ToTable("tblEmployment_Group");

                entity.Property(e => e.Id).HasColumnName("id");
            });

            modelBuilder.Entity<TblEmployments>(entity =>
            {
                entity.HasKey(e => e.EmploymentId)
                    .HasName("PK__tblEmplo__FDC872D60FD74C44");

                entity.ToTable("tblEmployments");

                entity.Property(e => e.EmploymentId)
                    .HasColumnName("EmploymentID")
                    .ValueGeneratedNever();

                entity.Property(e => e.DepartmentId).HasColumnName("DepartmentID");

                entity.Property(e => e.EmploymentName).HasMaxLength(100);
            });

            modelBuilder.Entity<TblEquipmentAccessory>(entity =>
            {
                entity.HasKey(e => new { e.EquipmentId, e.AccessoryId })
                    .HasName("PK__tblEquip__94DB7B7012B3B8EF");

                entity.ToTable("tblEquipment_Accessory");
            });

            modelBuilder.Entity<TblEquipmentBooking>(entity =>
            {
                entity.HasKey(e => e.BookingId)
                    .HasName("PK__tblEquip__73951AED1590259A");

                entity.ToTable("tblEquipment_Booking");

                entity.Property(e => e.Approver1Comment).HasMaxLength(500);

                entity.Property(e => e.BookingDate).HasColumnType("datetime");

                entity.Property(e => e.EndDate).HasColumnType("datetime");

                entity.Property(e => e.Notes).HasMaxLength(500);

                entity.Property(e => e.StartDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<TblEquipmentCategories>(entity =>
            {
                entity.HasKey(e => e.EquipmentCategoryId)
                    .HasName("PK__tblEquip__D047AD561B48FEF0");

                entity.ToTable("tblEquipmentCategories");

                entity.Property(e => e.EquipmentCategoryId).ValueGeneratedNever();

                entity.Property(e => e.Description).HasMaxLength(200);
            });

            modelBuilder.Entity<TblEquipmentRepair>(entity =>
            {
                entity.HasKey(e => new { e.EquipmentId, e.RepairId })
                    .HasName("PK__tblEquip__F43A4FBB186C9245");

                entity.ToTable("tblEquipment_Repair");
            });

            modelBuilder.Entity<TblEquipmentStatus>(entity =>
            {
                entity.HasKey(e => e.EquipmentStatusId)
                    .HasName("PK__tblEquip__F6237F912101D846");

                entity.ToTable("tblEquipmentStatus");

                entity.Property(e => e.EquipmentStatusId).ValueGeneratedNever();
            });

            modelBuilder.Entity<TblEquipments>(entity =>
            {
                entity.HasKey(e => e.EquipmentId)
                    .HasName("PK__tblEquip__344744791E256B9B");

                entity.ToTable("tblEquipments");

                entity.Property(e => e.BookingStatus).HasMaxLength(50);

                entity.Property(e => e.BuyDate).HasColumnType("datetime");

                entity.Property(e => e.CurrentPosition).HasColumnType("ntext");

                entity.Property(e => e.EquipmentName).HasMaxLength(100);

                entity.Property(e => e.EquipmentNumber).HasMaxLength(50);

                entity.Property(e => e.Manufacturer).HasMaxLength(50);

                entity.Property(e => e.Model).HasMaxLength(50);

                entity.Property(e => e.Price).HasColumnType("money");

                entity.Property(e => e.RepairDate).HasColumnType("datetime");

                entity.Property(e => e.StatusEndDate).HasColumnType("datetime");

                entity.Property(e => e.StatusStartDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<TblFtpServers>(entity =>
            {
                entity.HasKey(e => e.FtpServerId)
                    .HasName("PK__tblFtpSe__3A7DC09323DE44F1");

                entity.ToTable("tblFtpServers");

                entity.Property(e => e.FtpServerId).ValueGeneratedNever();

                entity.Property(e => e.CanNotEdit).HasDefaultValueSql("0");

                entity.Property(e => e.FtpDataDirectory).HasMaxLength(200);

                entity.Property(e => e.FtpIpAddress).HasMaxLength(50);

                entity.Property(e => e.FtpPassword).HasMaxLength(50);

                entity.Property(e => e.FtpPort).HasDefaultValueSql("21");

                entity.Property(e => e.FtpServerName).HasMaxLength(50);

                entity.Property(e => e.FtpUserName).HasMaxLength(50);
            });

            modelBuilder.Entity<TblGroups>(entity =>
            {
                entity.HasKey(e => e.GroupId)
                    .HasName("PK__tblGroup__149AF36A26BAB19C");

                entity.ToTable("tblGroups");

                entity.Property(e => e.AllowSectorList).HasMaxLength(200);

                entity.Property(e => e.GroupDescription).HasMaxLength(100);

                entity.Property(e => e.GroupName).HasMaxLength(50);
            });

            modelBuilder.Entity<TblHdingestRecordList>(entity =>
            {
                entity.ToTable("tblHDIngestRecordList");

                entity.Property(e => e.RecordTime).HasColumnType("datetime");

                entity.Property(e => e.Vtrid).HasColumnName("VTRId");
            });

            modelBuilder.Entity<TblHdlog>(entity =>
            {
                entity.ToTable("tblHDLog");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.LogLevel).HasDefaultValueSql("0");

                entity.Property(e => e.LogMessage).HasColumnType("ntext");

                entity.Property(e => e.LogTime)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("'1/1/2012'");
            });

            modelBuilder.Entity<TblHdsatrecordList>(entity =>
            {
                entity.ToTable("tblHDSATRecordList");

                entity.Property(e => e.RecordTime).HasColumnType("datetime");
            });

            modelBuilder.Entity<TblInfoAudio>(entity =>
            {
                entity.HasKey(e => new { e.Idclip, e.AudioTrackId })
                    .HasName("PK__tblInfoA__810B530E322C6448");

                entity.ToTable("tblInfoAudio");

                entity.Property(e => e.Idclip).HasColumnName("IDClip");

                entity.Property(e => e.AudioTrackId).HasColumnName("AudioTrackID");

                entity.Property(e => e.AudioTrackLanguage).HasMaxLength(50);

                entity.Property(e => e.AudioTrackType).HasMaxLength(50);
            });

            modelBuilder.Entity<TblInforTapeProcess>(entity =>
            {
                entity.ToTable("tblInforTape_Process");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.EndTime).HasColumnType("datetime");

                entity.Property(e => e.StartTime).HasColumnType("datetime");
            });

            modelBuilder.Entity<TblInforTapeWorkflow>(entity =>
            {
                entity.HasKey(e => new { e.WorkflowId, e.IdClip })
                    .HasName("PK__tblInfor__1472CB2337E53D9E");

                entity.ToTable("tblInforTape_Workflow");
            });

            modelBuilder.Entity<TblIngestUsingResource>(entity =>
            {
                entity.ToTable("tblIngestUsingResource");

                entity.Property(e => e.UpdateTime).HasColumnType("datetime");
            });

            modelBuilder.Entity<TblIntermediatePoints>(entity =>
            {
                entity.ToTable("tblIntermediatePoints");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedNever();
            });

            modelBuilder.Entity<TblJobs>(entity =>
            {
                entity.HasKey(e => e.JobTitleId)
                    .HasName("PK__tblJobs__35382FE9407A839F");

                entity.ToTable("tblJobs");

                entity.Property(e => e.JobDescription).HasMaxLength(50);

                entity.Property(e => e.JobSalary).HasColumnType("money");

                entity.Property(e => e.Notes).HasMaxLength(100);
            });

            modelBuilder.Entity<TblListCopy>(entity =>
            {
                entity.HasKey(e => e.ListId)
                    .HasName("PK__tblListC__E38328054356F04A");

                entity.ToTable("tblListCopy");

                entity.Property(e => e.DateList).HasColumnType("datetime");
            });

            modelBuilder.Entity<TblListItemCopy>(entity =>
            {
                entity.ToTable("tblListItemCopy");

                entity.Property(e => e.MaBang)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.NoiDung).HasMaxLength(500);

                entity.Property(e => e.PlayTcIn).HasMaxLength(50);

                entity.Property(e => e.PlayTcOut).HasMaxLength(50);

                entity.Property(e => e.TcIn).HasMaxLength(50);

                entity.Property(e => e.TcOut).HasMaxLength(50);

                entity.Property(e => e.TenChuongTrinh).HasMaxLength(200);
            });

            modelBuilder.Entity<TblLiveNews>(entity =>
            {
                entity.HasKey(e => e.LiveNewsId)
                    .HasName("PK__tblLiveN__F49A9E7A490FC9A0");

                entity.ToTable("tblLiveNews");

                entity.Property(e => e.LiveNewsId).ValueGeneratedNever();

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.Duration).HasMaxLength(12);

                entity.Property(e => e.Title).HasMaxLength(500);
            });

            modelBuilder.Entity<TblLiveSourcePorts>(entity =>
            {
                entity.HasKey(e => e.LiveSourceId)
                    .HasName("PK__tblLiveS__8BFD82454BEC364B");

                entity.ToTable("tblLiveSourcePorts");

                entity.Property(e => e.LiveSourceId).ValueGeneratedNever();

                entity.Property(e => e.LiveSourceDescription).HasMaxLength(100);
            });

            modelBuilder.Entity<TblLocalMessage>(entity =>
            {
                entity.ToTable("tblLocalMessage");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Content)
                    .IsRequired()
                    .HasColumnName("content")
                    .HasColumnType("ntext");

                entity.Property(e => e.FromUser).HasColumnName("fromUser");

                entity.Property(e => e.Received)
                    .HasColumnName("received")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.SendDate)
                    .HasColumnName("sendDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.ToUser).HasColumnName("toUser");
            });

            modelBuilder.Entity<TblLocalNews>(entity =>
            {
                entity.ToTable("tblLocalNews");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Category).HasColumnName("category");

                entity.Property(e => e.Content)
                    .HasColumnName("content")
                    .HasColumnType("ntext");

                entity.Property(e => e.DeparmentId).HasColumnName("deparmentId");

                entity.Property(e => e.Enabled).HasColumnName("enabled");

                entity.Property(e => e.ExpiredDate)
                    .HasColumnName("expiredDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.ExpiredPinnedDate)
                    .HasColumnName("expiredPinnedDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.Pinned).HasColumnName("pinned");

                entity.Property(e => e.ReleaseDate)
                    .HasColumnName("releaseDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasColumnName("title")
                    .HasMaxLength(200);

                entity.Property(e => e.UserId).HasColumnName("userId");
            });

            modelBuilder.Entity<TblLocalNewsCategory>(entity =>
            {
                entity.ToTable("tblLocalNewsCategory");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Description)
                    .HasColumnName("description")
                    .HasColumnType("ntext");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<TblLocalNewsComment>(entity =>
            {
                entity.ToTable("tblLocalNewsComment");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Content)
                    .HasColumnName("content")
                    .HasColumnType("ntext");

                entity.Property(e => e.LocalNewsId).HasColumnName("localNewsId");

                entity.Property(e => e.ReleaseDate)
                    .HasColumnName("releaseDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.UserId).HasColumnName("userId");
            });

            modelBuilder.Entity<TblLocalNotification>(entity =>
            {
                entity.ToTable("tblLocalNotification");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Content)
                    .IsRequired()
                    .HasColumnName("content")
                    .HasColumnType("ntext");

                entity.Property(e => e.Received)
                    .HasColumnName("received")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.SendDate)
                    .HasColumnName("sendDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasColumnName("title")
                    .HasMaxLength(200);

                entity.Property(e => e.ToUser).HasColumnName("toUser");
            });

            modelBuilder.Entity<TblLto>(entity =>
            {
                entity.HasKey(e => e.LtoId)
                    .HasName("PK__tblLTO__EEF42CC75D16C24D");

                entity.ToTable("tblLTO");

                entity.Property(e => e.LtoId)
                    .HasColumnName("ltoID")
                    .ValueGeneratedNever();

                entity.Property(e => e.FreeSpace).HasColumnType("numeric");

                entity.Property(e => e.TapeCreatedDate).HasColumnType("datetime");

                entity.Property(e => e.TapeLocation).HasColumnType("varchar(255)");

                entity.Property(e => e.TapeName).HasColumnType("varchar(50)");

                entity.Property(e => e.TapeQuality).HasColumnType("varchar(255)");
            });

            modelBuilder.Entity<TblLtobackup>(entity =>
            {
                entity.HasKey(e => e.Idclip)
                    .HasName("PK__tblLTOBa__39E0B39E5FF32EF8");

                entity.ToTable("tblLTOBackup");

                entity.Property(e => e.Idclip)
                    .HasColumnName("IDClip")
                    .ValueGeneratedNever();

                entity.Property(e => e.LtobackupId).HasColumnName("ltobackupID");

                entity.Property(e => e.MediaModifiedDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<TblMasterClipRepeat>(entity =>
            {
                entity.ToTable("tblMasterClipRepeat");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.DefaultMasterClipStatusId).HasColumnName("defaultMasterClipStatusId");

                entity.Property(e => e.EnableRerun)
                    .HasColumnName("enableRerun")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.EndDate)
                    .HasColumnName("endDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.OnFriday).HasColumnName("onFriday");

                entity.Property(e => e.OnMonday).HasColumnName("onMonday");

                entity.Property(e => e.OnSaturday).HasColumnName("onSaturday");

                entity.Property(e => e.OnSunday).HasColumnName("onSunday");

                entity.Property(e => e.OnThursday).HasColumnName("onThursday");

                entity.Property(e => e.OnTuesday).HasColumnName("onTuesday");

                entity.Property(e => e.OnWednesday).HasColumnName("onWednesday");

                entity.Property(e => e.RepeatWeeks).HasColumnName("repeatWeeks");

                entity.Property(e => e.SectorId)
                    .HasColumnName("sectorId")
                    .HasDefaultValueSql("1");

                entity.Property(e => e.StartDate)
                    .HasColumnName("startDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.StartTime)
                    .IsRequired()
                    .HasColumnName("startTime")
                    .HasMaxLength(12);
            });

            modelBuilder.Entity<TblMasterClipRerun>(entity =>
            {
                entity.ToTable("tblMasterClipRerun");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.DaysAfter).HasColumnName("daysAfter");

                entity.Property(e => e.DefaultMasterClipStatusId).HasColumnName("defaultMasterClipStatusId");

                entity.Property(e => e.StartTime)
                    .IsRequired()
                    .HasColumnName("startTime")
                    .HasMaxLength(12);
            });

            modelBuilder.Entity<TblMasterClipStatus>(entity =>
            {
                entity.HasKey(e => e.MasterClipStatusId)
                    .HasName("PK__tblMaste__B54C888E6B64E1A4");

                entity.ToTable("tblMasterClipStatus");

                entity.Property(e => e.MasterClipStatusColor).HasMaxLength(20);

                entity.Property(e => e.MasterClipStatusDescription).HasMaxLength(100);
            });

            modelBuilder.Entity<TblMasterClips>(entity =>
            {
                entity.HasKey(e => e.MasterClipId)
                    .HasName("PK__tblMaste__14917B6A688874F9");

                entity.ToTable("tblMasterClips");

                entity.Property(e => e.MasterClipComment).HasMaxLength(200);

                entity.Property(e => e.MasterClipDuration).HasMaxLength(12);

                entity.Property(e => e.MasterClipName).HasMaxLength(100);

                entity.Property(e => e.MasterClipTypeId).HasColumnName("MasterClipTypeID");

                entity.Property(e => e.TermEnd)
                    .HasColumnName("termEnd")
                    .HasColumnType("datetime");

                entity.Property(e => e.TermRepeat)
                    .HasColumnName("termRepeat")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.TermRepeatType)
                    .HasColumnName("termRepeatType")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.TermStart)
                    .HasColumnName("termStart")
                    .HasColumnType("datetime");
            });

            modelBuilder.Entity<TblMasterPlaylistApproval>(entity =>
            {
                entity.ToTable("tblMasterPlaylist_Approval");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Date)
                    .HasColumnName("date")
                    .HasColumnType("datetime");

                entity.Property(e => e.MasterPlaylistId).HasColumnName("masterPlaylistId");

                entity.Property(e => e.Note)
                    .HasColumnName("note")
                    .HasColumnType("text");

                entity.Property(e => e.UserId).HasColumnName("userId");
            });

            modelBuilder.Entity<TblMasterPlaylistItems>(entity =>
            {
                entity.HasKey(e => e.MasterPlaylistItemId)
                    .HasName("PK__tblMaste__BFD7D4AF711DBAFA");

                entity.ToTable("tblMasterPlaylist_Items");

                entity.Property(e => e.Idclip).HasColumnName("IDCLip");

                entity.Property(e => e.MasterClipPlayTime)
                    .IsRequired()
                    .HasMaxLength(12);
            });

            modelBuilder.Entity<TblMasterPlaylists>(entity =>
            {
                entity.HasKey(e => e.MasterPlaylistId)
                    .HasName("PK__tblMaste__68818A6173FA27A5");

                entity.ToTable("tblMasterPlaylists");

                entity.Property(e => e.ApproverId).HasColumnName("approverID");

                entity.Property(e => e.DateList).HasColumnType("datetime");

                entity.Property(e => e.Islock)
                    .HasColumnName("islock")
                    .HasDefaultValueSql("0");
            });

            modelBuilder.Entity<TblMcsservers>(entity =>
            {
                entity.HasKey(e => e.Mcsid)
                    .HasName("PK__tblMCSSe__4BF1B4F276D69450");

                entity.ToTable("tblMCSServers");

                entity.Property(e => e.Mcsid)
                    .HasColumnName("MCSId")
                    .ValueGeneratedNever();

                entity.Property(e => e.McsclassName)
                    .HasColumnName("MCSClassName")
                    .HasMaxLength(50);

                entity.Property(e => e.McscontrolPort)
                    .HasColumnName("MCSControlPort")
                    .HasDefaultValueSql("9001");

                entity.Property(e => e.Mcsdescription)
                    .HasColumnName("MCSDescription")
                    .HasMaxLength(300);

                entity.Property(e => e.McsdllName)
                    .HasColumnName("MCSDllName")
                    .HasMaxLength(50);

                entity.Property(e => e.McsinputPort).HasColumnName("MCSInputPort");

                entity.Property(e => e.McsinputRouterId).HasColumnName("MCSInputRouterId");

                entity.Property(e => e.Mcsipaddress)
                    .HasColumnName("MCSIPAddress")
                    .HasMaxLength(50);

                entity.Property(e => e.Mcsname)
                    .HasColumnName("MCSName")
                    .HasMaxLength(50);

                entity.Property(e => e.McsoutputPort).HasColumnName("MCSOutputPort");

                entity.Property(e => e.McsoutputRouterId).HasColumnName("MCSOutputRouterId");

                entity.Property(e => e.Mcsstatus).HasColumnName("MCSStatus");
            });

            modelBuilder.Entity<TblMenuItem>(entity =>
            {
                entity.ToTable("tblMenuItem");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Disabled)
                    .HasColumnName("disabled")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Explanded)
                    .HasColumnName("explanded")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Href)
                    .HasColumnName("href")
                    .HasMaxLength(100);

                entity.Property(e => e.LicenceActivated).HasColumnType("binary(20)");

                entity.Property(e => e.MenuOrder)
                    .HasColumnName("menu_order")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(100);

                entity.Property(e => e.Parent).HasColumnName("parent");

                entity.Property(e => e.Rightpanel)
                    .HasColumnName("rightpanel")
                    .HasDefaultValueSql("0");
            });

            modelBuilder.Entity<TblModulesInSector>(entity =>
            {
                entity.ToTable("tblModulesInSector");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.ModuleStatus).HasDefaultValueSql("0");
            });

            modelBuilder.Entity<TblMonitorAttributes>(entity =>
            {
                entity.HasKey(e => e.AttributeId)
                    .HasName("PK__tblMonit__C18929EA7F6BDA51");

                entity.ToTable("tblMonitor_Attributes");

                entity.Property(e => e.AttributeName).HasMaxLength(50);
            });

            modelBuilder.Entity<TblMonitorDeviceLogs>(entity =>
            {
                entity.ToTable("tblMonitor_DeviceLogs");

                entity.Property(e => e.DeviceIpaddress)
                    .HasColumnName("DeviceIPAddress")
                    .HasMaxLength(50);

                entity.Property(e => e.DeviceName).HasMaxLength(50);

                entity.Property(e => e.LogMessage).HasColumnType("ntext");

                entity.Property(e => e.LogTime).HasColumnType("datetime");
            });

            modelBuilder.Entity<TblMonitorDeviceTypeAttribute>(entity =>
            {
                entity.ToTable("tblMonitor_DeviceType_Attribute");

                entity.Property(e => e.IdToGetInfo).HasMaxLength(200);
            });

            modelBuilder.Entity<TblMonitorDeviceTypes>(entity =>
            {
                entity.HasKey(e => e.DeviceTypeId)
                    .HasName("PK__tblMonit__07A6C7F60ADD8CFD");

                entity.ToTable("tblMonitor_DeviceTypes");

                entity.Property(e => e.DeviceTypeDescription).HasMaxLength(500);

                entity.Property(e => e.ErrorImageUrl).HasMaxLength(500);

                entity.Property(e => e.ErrorImg).HasColumnType("image");

                entity.Property(e => e.NormalImg).HasColumnType("image");

                entity.Property(e => e.OkimageUrl)
                    .HasColumnName("OKImageUrl")
                    .HasMaxLength(500);

                entity.Property(e => e.WarningImageUrl).HasMaxLength(500);

                entity.Property(e => e.WarningImg).HasColumnType("image");
            });

            modelBuilder.Entity<TblMonitorDevices>(entity =>
            {
                entity.HasKey(e => e.DeviceId)
                    .HasName("PK__tblMonit__49E123110524B3A7");

                entity.ToTable("tblMonitor_Devices");

                entity.Property(e => e.DeviceIpaddress)
                    .HasColumnName("DeviceIPAddress")
                    .HasMaxLength(50);

                entity.Property(e => e.DeviceName).HasMaxLength(50);

                entity.Property(e => e.DeviceStatus).HasDefaultValueSql("0");

                entity.Property(e => e.ReadCommunityString).HasMaxLength(100);
            });

            modelBuilder.Entity<TblMonitorLink>(entity =>
            {
                entity.ToTable("tblMonitor_Link");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Data).HasColumnName("DATA");

                entity.Property(e => e.DestDeviceId).HasColumnName("DEST_DEVICE_ID");

                entity.Property(e => e.DestPort).HasColumnName("DEST_PORT");

                entity.Property(e => e.SrcDeviceId).HasColumnName("SRC_DEVICE_ID");

                entity.Property(e => e.SrcPort).HasColumnName("SRC_PORT");

                entity.Property(e => e.Text)
                    .HasColumnName("TEXT")
                    .HasMaxLength(150);

                entity.Property(e => e.Type)
                    .HasColumnName("TYPE")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<TblMonitorSectorDevices>(entity =>
            {
                entity.ToTable("tblMonitor_Sector_Devices");
            });

            modelBuilder.Entity<TblMonitorSectors>(entity =>
            {
                entity.HasKey(e => e.SectorId)
                    .HasName("PK__tblMonit__755E57E91372D2FE");

                entity.ToTable("tblMonitor_Sectors");

                entity.Property(e => e.BackgroundImageUrl).HasMaxLength(500);

                entity.Property(e => e.SectorName).HasMaxLength(100);

                entity.Property(e => e.ThumbnailError).HasColumnType("image");

                entity.Property(e => e.ThumbnailImageUrlError)
                    .HasColumnName("ThumbnailImageUrl_Error")
                    .HasMaxLength(500);

                entity.Property(e => e.ThumbnailImageUrlOk)
                    .HasColumnName("ThumbnailImageUrl_OK")
                    .HasMaxLength(500);

                entity.Property(e => e.ThumbnailImageUrlWarning)
                    .HasColumnName("ThumbnailImageUrl_Warning")
                    .HasMaxLength(500);

                entity.Property(e => e.ThumbnailNormal).HasColumnType("image");

                entity.Property(e => e.ThumbnailWarning).HasColumnType("image");

                entity.Property(e => e.Visible).HasDefaultValueSql("1");
            });

            modelBuilder.Entity<TblNasTable>(entity =>
            {
                entity.HasKey(e => e.NasId)
                    .HasName("PK__tblNasTa__665C5F21192BAC54");

                entity.ToTable("tblNasTable");

                entity.Property(e => e.NasId)
                    .HasColumnName("NasID")
                    .ValueGeneratedNever();

                entity.Property(e => e.AssembleDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(1)/(1))/(2012");

                entity.Property(e => e.ConfigIpAddress).HasMaxLength(50);

                entity.Property(e => e.ConfigPassword).HasMaxLength(50);

                entity.Property(e => e.ConfigUserName).HasMaxLength(50);

                entity.Property(e => e.Data1Directory)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.Data2Directory).HasMaxLength(200);

                entity.Property(e => e.Data3Directory).HasMaxLength(200);

                entity.Property(e => e.Data4Directory).HasMaxLength(200);

                entity.Property(e => e.IsAlive).HasDefaultValueSql("1");

                entity.Property(e => e.NasDiscription).HasMaxLength(50);

                entity.Property(e => e.NasIp)
                    .IsRequired()
                    .HasColumnName("NasIP")
                    .HasMaxLength(50);

                entity.Property(e => e.Password)
                    .HasColumnName("password")
                    .HasMaxLength(50);

                entity.Property(e => e.Port).HasDefaultValueSql("21");

                entity.Property(e => e.PowerfulFactor).HasDefaultValueSql("10");

                entity.Property(e => e.SerialNumber).HasMaxLength(50);

                entity.Property(e => e.UncbasePathData1)
                    .IsRequired()
                    .HasColumnName("UNCBasePathData1")
                    .HasMaxLength(200);

                entity.Property(e => e.UncbasePathData2)
                    .HasColumnName("UNCBasePathData2")
                    .HasMaxLength(200);

                entity.Property(e => e.UncbasePathData3)
                    .HasColumnName("UNCBasePathData3")
                    .HasMaxLength(200);

                entity.Property(e => e.UncbasePathData4)
                    .HasColumnName("UNCBasePathData4")
                    .HasMaxLength(200);

                entity.Property(e => e.UseInBackup).HasDefaultValueSql("1");

                entity.Property(e => e.Username)
                    .HasColumnName("username")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<TblNascurrentConnections>(entity =>
            {
                entity.ToTable("tblNASCurrentConnections");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedNever();

                entity.Property(e => e.ClientIp)
                    .HasColumnName("ClientIP")
                    .HasColumnType("varchar(15)");

                entity.Property(e => e.StartTime).HasColumnType("datetime");
            });

            modelBuilder.Entity<TblNews>(entity =>
            {
                entity.HasKey(e => e.NewsId)
                    .HasName("PK__tblNews__954EBDF31C0818FF");

                entity.ToTable("tblNews");

                entity.Property(e => e.ApproverComment).HasMaxLength(500);

                entity.Property(e => e.ApproverId).HasColumnName("ApproverID");

                entity.Property(e => e.Cgcontent)
                    .HasColumnName("CGContent")
                    .HasMaxLength(500);

                entity.Property(e => e.ContentSummary).HasColumnType("ntext");

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.CurrentContentId).HasDefaultValueSql("0");

                entity.Property(e => e.ExpectedCompleteDate).HasColumnType("datetime");

                entity.Property(e => e.NewsDuration).HasMaxLength(12);

                entity.Property(e => e.NewsPlace).HasMaxLength(500);

                entity.Property(e => e.NewsTitle).HasMaxLength(500);

                entity.Property(e => e.NewsTypeId).HasDefaultValueSql("1");

                entity.Property(e => e.Notes).HasMaxLength(500);

                entity.Property(e => e.ReadingSpeed).HasDefaultValueSql("200");

                entity.Property(e => e.StartDate).HasColumnType("datetime");

                entity.Property(e => e.UserId).HasColumnName("UserID");
            });

            modelBuilder.Entity<TblNewsApproveStatus>(entity =>
            {
                entity.HasKey(e => e.StatusId)
                    .HasName("PK__tblNewsA__C8EE206335C7EB02");

                entity.ToTable("tblNewsApproveStatus");

                entity.Property(e => e.Description).HasColumnType("nchar(100)");
            });

            modelBuilder.Entity<TblNewsCheck>(entity =>
            {
                entity.ToTable("tblNews_Check");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedNever();

                entity.Property(e => e.CheckDate).HasColumnType("datetime");

                entity.Property(e => e.CheckerComment).HasMaxLength(500);
            });

            modelBuilder.Entity<TblNewsContent>(entity =>
            {
                entity.HasKey(e => e.ContentId)
                    .HasName("PK__tblNews___2907A81E21C0F255");

                entity.ToTable("tblNews_Content");

                entity.Property(e => e.Date).HasColumnType("datetime");

                entity.Property(e => e.PrompterText).HasColumnType("ntext");

                entity.Property(e => e.VoiceOverText).HasColumnType("ntext");
            });

            modelBuilder.Entity<TblNewsDecoBooking>(entity =>
            {
                entity.HasKey(e => new { e.NewsId, e.DecoBookingId })
                    .HasName("PK__tblNews___BA29AEF8249D5F00");

                entity.ToTable("tblNews_DecoBooking");
            });

            modelBuilder.Entity<TblNewsProcess>(entity =>
            {
                entity.ToTable("tblNews_Process");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.EndTime).HasColumnType("datetime");

                entity.Property(e => e.StartTime).HasColumnType("datetime");
            });

            modelBuilder.Entity<TblNewsReporters>(entity =>
            {
                entity.HasKey(e => e.NewsReporterId)
                    .HasName("PK__tblNews___F28C34682A563856");

                entity.ToTable("tblNews_Reporters");

                entity.Property(e => e.EndDate).HasColumnType("datetime");

                entity.Property(e => e.StartDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<TblNewsSource>(entity =>
            {
                entity.HasKey(e => e.NewsSourceId)
                    .HasName("PK__tblNewsS__267E567A38A457AD");

                entity.ToTable("tblNewsSource");

                entity.Property(e => e.Description).HasMaxLength(200);
            });

            modelBuilder.Entity<TblNewsTypes>(entity =>
            {
                entity.HasKey(e => e.NewsTypeId)
                    .HasName("PK__tblNewsT__9013FE0A3B80C458");

                entity.ToTable("tblNewsTypes");

                entity.Property(e => e.Description).HasMaxLength(50);

                entity.Property(e => e.TblNewsTypesGroup).HasColumnName("tblNewsTypesGroup");
            });

            modelBuilder.Entity<TblNewsTypesGroup>(entity =>
            {
                entity.HasKey(e => e.GroupId)
                    .HasName("PK__tblNewsT__149AF36A3E5D3103");

                entity.ToTable("tblNewsTypesGroup");

                entity.Property(e => e.Description).HasColumnType("nchar(50)");

                entity.Property(e => e.GroupName)
                    .IsRequired()
                    .HasColumnType("nchar(50)");
            });

            modelBuilder.Entity<TblNewsVehicleBooking>(entity =>
            {
                entity.HasKey(e => new { e.NewsId, e.VehicleBookingId })
                    .HasName("PK__tblNews___E4725D3A2D32A501");

                entity.ToTable("tblNews_VehicleBooking");
            });

            modelBuilder.Entity<TblNewsVotes>(entity =>
            {
                entity.ToTable("tblNews_Votes");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedNever();

                entity.Property(e => e.Comment).HasMaxLength(500);
            });

            modelBuilder.Entity<TblNewsWorkflow>(entity =>
            {
                entity.HasKey(e => new { e.WorkflowId, e.NewsId })
                    .HasName("PK__tblNews___7E504DB532EB7E57");

                entity.ToTable("tblNews_Workflow");
            });

            modelBuilder.Entity<TblOperateServers>(entity =>
            {
                entity.HasKey(e => e.OperateServerId)
                    .HasName("PK__tblOpera__03ACEB9441399DAE");

                entity.ToTable("tblOperateServers");

                entity.Property(e => e.ControlIpAddress).HasMaxLength(50);

                entity.Property(e => e.ControlName).HasMaxLength(50);

                entity.Property(e => e.ControlPassword).HasMaxLength(50);

                entity.Property(e => e.ControlUserName).HasMaxLength(50);

                entity.Property(e => e.FileExtensionOnServerForControl)
                    .HasMaxLength(50)
                    .HasDefaultValueSql("N'all'");

                entity.Property(e => e.MustIncludeExtensionWhenControl).HasDefaultValueSql("0");

                entity.Property(e => e.NativeDomain).HasMaxLength(50);

                entity.Property(e => e.NativeIp).HasMaxLength(50);

                entity.Property(e => e.NativePassword).HasMaxLength(50);

                entity.Property(e => e.NativePath).HasMaxLength(50);

                entity.Property(e => e.NativePort).HasMaxLength(50);

                entity.Property(e => e.NativeProtocol).HasMaxLength(50);

                entity.Property(e => e.NativeUserName).HasMaxLength(50);

                entity.Property(e => e.OperateServerName).HasMaxLength(50);

                entity.Property(e => e.OperateServerStatus).HasDefaultValueSql("0");
            });

            modelBuilder.Entity<TblPermissionGroup>(entity =>
            {
                entity.ToTable("tblPermission_Group");
            });

            modelBuilder.Entity<TblPermissions>(entity =>
            {
                entity.HasKey(e => e.PermissionId)
                    .HasName("PK__tblPermi__EFA6FB0F46F27704");

                entity.ToTable("tblPermissions");

                entity.Property(e => e.PermissionId)
                    .HasColumnName("PermissionID")
                    .ValueGeneratedNever();

                entity.Property(e => e.PermissionName).HasMaxLength(255);
            });

            modelBuilder.Entity<TblPlayListItemAuxiliaryEvent>(entity =>
            {
                entity.ToTable("tblPlayList_Item_AuxiliaryEvent");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedNever();

                entity.Property(e => e.AuxiliaryEventTime)
                    .IsRequired()
                    .HasMaxLength(12);

                entity.Property(e => e.Idclip).HasColumnName("IDClip");
            });

            modelBuilder.Entity<TblPlaylistApproval>(entity =>
            {
                entity.ToTable("tblPlaylist_Approval");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Date)
                    .HasColumnName("date")
                    .HasColumnType("datetime");

                entity.Property(e => e.Note)
                    .HasColumnName("note")
                    .HasColumnType("text");

                entity.Property(e => e.PlaylistId).HasColumnName("playlistId");

                entity.Property(e => e.UserId).HasColumnName("userId");
            });

            modelBuilder.Entity<TblPreliminaryRunDown>(entity =>
            {
                entity.ToTable("tblPreliminaryRunDown");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedNever();

                entity.Property(e => e.ClipDuration).HasMaxLength(12);

                entity.Property(e => e.ItemType).HasDefaultValueSql("0");

                entity.Property(e => e.Mcduration)
                    .HasColumnName("MCDuration")
                    .HasMaxLength(12);

                entity.Property(e => e.RunDownId).HasDefaultValueSql("0");
            });

            modelBuilder.Entity<TblProcesses>(entity =>
            {
                entity.HasKey(e => e.ProcessId)
                    .HasName("PK__tblProce__1B39A956526429B0");

                entity.ToTable("tblProcesses");

                entity.Property(e => e.ProcessDescription).HasMaxLength(255);

                entity.Property(e => e.ProcessName).HasMaxLength(255);
            });

            modelBuilder.Entity<TblRecordApp>(entity =>
            {
                entity.HasKey(e => e.RecordAppId)
                    .HasName("PK__tblRecor__38FC4A305540965B");

                entity.ToTable("tblRecordApp");

                entity.Property(e => e.RecordAppId).ValueGeneratedNever();

                entity.Property(e => e.RecordAppName).HasMaxLength(50);
            });

            modelBuilder.Entity<TblRecordList>(entity =>
            {
                entity.HasKey(e => e.Idclip)
                    .HasName("PK__tblRecor__39E0B39E5AF96FB1");

                entity.ToTable("tblRecordList");

                entity.Property(e => e.Idclip)
                    .HasColumnName("IDClip")
                    .ValueGeneratedNever();

                entity.Property(e => e.FtpserverId).HasColumnName("FTPServerId");

                entity.Property(e => e.IsAutoMode).HasDefaultValueSql("1");

                entity.Property(e => e.RecordFileName).HasMaxLength(200);

                entity.Property(e => e.RecordServerId).HasColumnName("RecordServerID");

                entity.Property(e => e.RecordStatus).HasDefaultValueSql("0");
            });

            modelBuilder.Entity<TblRecordLogs>(entity =>
            {
                entity.HasKey(e => e.RecordLogsId)
                    .HasName("PK__tblRecor__7821C2405DD5DC5C");

                entity.ToTable("tblRecordLogs");

                entity.Property(e => e.RecordLogsId).HasColumnName("RecordLogsID");

                entity.Property(e => e.ClipName).HasMaxLength(200);

                entity.Property(e => e.RecordDuration).HasColumnType("char(11)");

                entity.Property(e => e.RecordTcin)
                    .HasColumnName("RecordTCIn")
                    .HasColumnType("char(11)");

                entity.Property(e => e.StartTime).HasColumnType("datetime");
            });

            modelBuilder.Entity<TblRecorderServers>(entity =>
            {
                entity.HasKey(e => e.RecordServerId)
                    .HasName("PK__tblRecor__F8BE2F30581D0306");

                entity.ToTable("tblRecorderServers");

                entity.Property(e => e.RecordServerId).ValueGeneratedNever();

                entity.Property(e => e.ChannelName).HasMaxLength(50);

                entity.Property(e => e.ControlIpAddress).HasMaxLength(50);

                entity.Property(e => e.ControlName).HasMaxLength(50);

                entity.Property(e => e.ControlPassword).HasMaxLength(50);

                entity.Property(e => e.ControlUserName).HasMaxLength(50);

                entity.Property(e => e.RecorderServerStatus).HasDefaultValueSql("0");
            });

            modelBuilder.Entity<TblRemuneration>(entity =>
            {
                entity.HasKey(e => e.RemunerationId)
                    .HasName("PK__tblRemun__DAFDB71D60B24907");

                entity.ToTable("tblRemuneration");

                entity.Property(e => e.TblJobs).HasColumnName("tblJobs");

                entity.Property(e => e.TblNewType).HasColumnName("tblNewType");
            });

            modelBuilder.Entity<TblRepair>(entity =>
            {
                entity.HasKey(e => e.RepairId)
                    .HasName("PK__tblRepai__07D0BC2D638EB5B2");

                entity.ToTable("tblRepair");

                entity.Property(e => e.RepairId).ValueGeneratedNever();

                entity.Property(e => e.EndDate).HasColumnType("datetime");

                entity.Property(e => e.EquipmentId).HasColumnType("nchar(10)");

                entity.Property(e => e.RepairCode).HasColumnType("nchar(10)");

                entity.Property(e => e.RepairExpense).HasColumnType("money");

                entity.Property(e => e.StartDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<TblRouterConnections>(entity =>
            {
                entity.HasKey(e => e.ConnectionId)
                    .HasName("PK__tblRoute__404A6493666B225D");

                entity.ToTable("tblRouterConnections");
            });

            modelBuilder.Entity<TblRouters>(entity =>
            {
                entity.HasKey(e => e.RouterId)
                    .HasName("PK__tblRoute__6C9DDD0A69478F08");

                entity.ToTable("tblRouters");

                entity.Property(e => e.RouterId).ValueGeneratedNever();

                entity.Property(e => e.ClassName).HasMaxLength(50);

                entity.Property(e => e.ControlIpAddress).HasColumnType("varchar(15)");

                entity.Property(e => e.DataIpAddress).HasColumnType("varchar(15)");

                entity.Property(e => e.RouterDllName).HasMaxLength(50);

                entity.Property(e => e.RouterName).HasMaxLength(50);
            });

            modelBuilder.Entity<TblSalaryItem>(entity =>
            {
                entity.HasKey(e => e.SalaryItemId)
                    .HasName("PK__tblSalar__87E61C386F00685E");

                entity.ToTable("tblSalaryItem");
            });

            modelBuilder.Entity<TblSalaryReport>(entity =>
            {
                entity.HasKey(e => e.ReportId)
                    .HasName("PK__tblSalar__D5BD48056C23FBB3");

                entity.ToTable("tblSalary_Report");

                entity.Property(e => e.DateApproved).HasColumnType("datetime");

                entity.Property(e => e.DateCreat).HasColumnType("datetime");

                entity.Property(e => e.TblUserApproving).HasColumnName("tblUserApproving");
            });

            modelBuilder.Entity<TblSaningestRecordList>(entity =>
            {
                entity.ToTable("tblSANIngestRecordList");

                entity.Property(e => e.RecordTime).HasColumnType("datetime");

                entity.Property(e => e.Vtrid).HasColumnName("VTRId");
            });

            modelBuilder.Entity<TblSans>(entity =>
            {
                entity.HasKey(e => e.SanId)
                    .HasName("PK__tblSANS__4658869874B941B4");

                entity.ToTable("tblSANS");

                entity.Property(e => e.SanId).ValueGeneratedNever();

                entity.Property(e => e.AssembleDate).HasColumnType("datetime");

                entity.Property(e => e.Description).HasMaxLength(200);

                entity.Property(e => e.IpAddress1).HasMaxLength(50);

                entity.Property(e => e.IpAddress2).HasMaxLength(50);

                entity.Property(e => e.Sanname)
                    .HasColumnName("SANName")
                    .HasMaxLength(50);

                entity.Property(e => e.SerialNumber).HasMaxLength(50);
            });

            modelBuilder.Entity<TblSectorOperateServers>(entity =>
            {
                entity.ToTable("tblSector_OperateServers");
            });

            modelBuilder.Entity<TblSectors>(entity =>
            {
                entity.HasKey(e => e.SectorId)
                    .HasName("PK__tblSecto__755E57E97A721B0A");

                entity.ToTable("tblSectors");

                entity.HasIndex(e => e.SyncId)
                    .HasName("IX_tblSectors")
                    .IsUnique();

                entity.Property(e => e.SectorId).ValueGeneratedNever();

                entity.Property(e => e.CgipAddress)
                    .HasColumnName("CGIpAddress")
                    .HasColumnType("varchar(15)");

                entity.Property(e => e.Cgport).HasColumnName("CGPort");

                entity.Property(e => e.CurrentCgserverId).HasColumnName("CurrentCGServerId");

                entity.Property(e => e.CurrentCgserverId2).HasColumnName("CurrentCGServerId2");

                entity.Property(e => e.MasterBranchId).HasDefaultValueSql("0");

                entity.Property(e => e.Mcsid1).HasColumnName("MCSId1");

                entity.Property(e => e.Mcsid2).HasColumnName("MCSId2");

                entity.Property(e => e.PlayingState)
                    .HasColumnName("playingState")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.SectorName).HasColumnType("varchar(255)");

                entity.Property(e => e.SyncId)
                    .IsRequired()
                    .HasDefaultValueSql("newid()");
            });

            modelBuilder.Entity<TblServerDeviceTypes>(entity =>
            {
                entity.HasKey(e => e.ServerDeviceTypeId)
                    .HasName("PK__tblServe__BBA265777E42ABEE");

                entity.ToTable("tblServerDeviceTypes");

                entity.Property(e => e.ServerDeviceTypeName).HasMaxLength(50);
            });

            modelBuilder.Entity<TblServerFactory>(entity =>
            {
                entity.HasKey(e => e.ServerFactoryId)
                    .HasName("PK__tblServe__15E8331C011F1899");

                entity.ToTable("tblServerFactory");

                entity.Property(e => e.GetSizeDirectory).HasMaxLength(50);

                entity.Property(e => e.GetSizeExtension).HasMaxLength(50);

                entity.Property(e => e.GetSizeFactor).HasDefaultValueSql("1.1");

                entity.Property(e => e.GetSizePassword).HasMaxLength(50);

                entity.Property(e => e.GetSizeUserName).HasMaxLength(50);

                entity.Property(e => e.ServerFactoryName).HasMaxLength(50);
            });

            modelBuilder.Entity<TblServerFactoryExtension>(entity =>
            {
                entity.ToTable("tblServerFactoryExtension");

                entity.Property(e => e.FileDestExtension).HasMaxLength(50);

                entity.Property(e => e.FileSourceExtension).HasMaxLength(50);

                entity.Property(e => e.Password).HasMaxLength(50);

                entity.Property(e => e.ServerDirectory).HasMaxLength(50);

                entity.Property(e => e.UserName).HasMaxLength(50);
            });

            modelBuilder.Entity<TblServerStatus>(entity =>
            {
                entity.HasKey(e => e.ServerStatusId)
                    .HasName("PK__tblServe__7899C2B609B45E9A");

                entity.ToTable("tblServerStatus");

                entity.Property(e => e.ServerStatusId).ValueGeneratedNever();

                entity.Property(e => e.ServerStatusDescription).HasMaxLength(50);
            });

            modelBuilder.Entity<TblServerTypes>(entity =>
            {
                entity.HasKey(e => e.ServerTypeId)
                    .HasName("PK__tblServe__4C778FA80C90CB45");

                entity.ToTable("tblServerTypes");

                entity.Property(e => e.ServerTypeId).ValueGeneratedNever();

                entity.Property(e => e.ClassName).HasMaxLength(50);

                entity.Property(e => e.DllName).HasMaxLength(50);

                entity.Property(e => e.ServerTypeName).HasMaxLength(50);
            });

            modelBuilder.Entity<TblServers>(entity =>
            {
                entity.HasKey(e => e.ServerId)
                    .HasName("PK__tblServe__C56AC8E606D7F1EF");

                entity.ToTable("tblServers");

                entity.Property(e => e.ServerId).ValueGeneratedNever();

                entity.Property(e => e.ServerName).HasMaxLength(50);
            });

            modelBuilder.Entity<TblServicesModule>(entity =>
            {
                entity.HasKey(e => e.ModuleId)
                    .HasName("PK__tblServi__2B7477A70F6D37F0");

                entity.ToTable("tblServicesModule");

                entity.Property(e => e.ModuleName).HasMaxLength(50);
            });

            modelBuilder.Entity<TblShapes>(entity =>
            {
                entity.HasKey(e => e.ShapeId)
                    .HasName("PK__tblShape__70FC83811249A49B");

                entity.ToTable("tblShapes");

                entity.Property(e => e.ShapeId).ValueGeneratedNever();

                entity.Property(e => e.BackColor).HasColumnType("varchar(255)");

                entity.Property(e => e.Description).HasColumnType("varchar(255)");

                entity.Property(e => e.Draw2DclassName)
                    .HasColumnName("Draw2DClassName")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.ForeColor).HasColumnType("varchar(255)");

                entity.Property(e => e.ImageUrl).HasColumnType("varchar(255)");
            });

            modelBuilder.Entity<TblSpecialities>(entity =>
            {
                entity.HasKey(e => e.SpecialityId)
                    .HasName("PK__tblSpeci__67ED609B15261146");

                entity.ToTable("tblSpecialities");

                entity.Property(e => e.Description).HasMaxLength(200);
            });

            modelBuilder.Entity<TblStudioBooking>(entity =>
            {
                entity.HasKey(e => e.BookingId)
                    .HasName("PK__tblStudi__73951AED18027DF1");

                entity.ToTable("tblStudio_Booking");

                entity.Property(e => e.BookingId).ValueGeneratedNever();

                entity.Property(e => e.Approver1Comment).HasMaxLength(500);

                entity.Property(e => e.Approver2Comment).HasMaxLength(500);

                entity.Property(e => e.BookingDate).HasColumnType("datetime");

                entity.Property(e => e.EndDate).HasColumnType("datetime");

                entity.Property(e => e.Notes).HasMaxLength(500);

                entity.Property(e => e.StartDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<TblStudioDeco>(entity =>
            {
                entity.ToTable("tblStudio_Deco");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.DecoDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<TblStudioEquipment>(entity =>
            {
                entity.HasKey(e => new { e.StudioId, e.EquipmentId })
                    .HasName("PK__tblStudi__C9884F371DBB5747");

                entity.ToTable("tblStudio_Equipment");
            });

            modelBuilder.Entity<TblStudioRundown>(entity =>
            {
                entity.ToTable("tblStudioRundown");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedNever();

                entity.Property(e => e.AuxiliaryEventTime)
                    .IsRequired()
                    .HasMaxLength(12);
            });

            modelBuilder.Entity<TblStudioStatus>(entity =>
            {
                entity.HasKey(e => e.StudioStatusId)
                    .HasName("PK__tblStudi__30A1E3E126509D48");

                entity.ToTable("tblStudioStatus");

                entity.Property(e => e.StudioStatusId).ValueGeneratedNever();
            });

            modelBuilder.Entity<TblStudios>(entity =>
            {
                entity.HasKey(e => e.StudioId)
                    .HasName("PK__tblStudi__4ACC3B702374309D");

                entity.ToTable("tblStudios");

                entity.Property(e => e.EndDateStatus).HasColumnType("datetime");

                entity.Property(e => e.Price).HasColumnType("money");

                entity.Property(e => e.StartDateStatus).HasColumnType("datetime");

                entity.Property(e => e.StudioAddress).HasMaxLength(200);

                entity.Property(e => e.StudioName).HasMaxLength(100);

                entity.Property(e => e.StudioSize).HasMaxLength(50);
            });

            modelBuilder.Entity<TblTapeTypes>(entity =>
            {
                entity.HasKey(e => e.TapeTypeId)
                    .HasName("PK__tblTapeT__55A0EEAE292D09F3");

                entity.ToTable("tblTapeTypes");

                entity.Property(e => e.TapeTypeId).ValueGeneratedNever();

                entity.Property(e => e.Description).HasMaxLength(50);
            });

            modelBuilder.Entity<TblTempStorage>(entity =>
            {
                entity.HasKey(e => e.Idclip)
                    .HasName("PK__tblTempS__39E0B39E2C09769E");

                entity.ToTable("tblTempStorage");

                entity.Property(e => e.Idclip)
                    .HasColumnName("IDClip")
                    .ValueGeneratedNever();

                entity.Property(e => e.Audio1Path).HasMaxLength(300);

                entity.Property(e => e.Audio2Path).HasMaxLength(300);

                entity.Property(e => e.Audio3Path).HasMaxLength(300);

                entity.Property(e => e.Audio4Path).HasMaxLength(300);

                entity.Property(e => e.FilePath).HasMaxLength(300);

                entity.Property(e => e.HostIp)
                    .HasColumnName("HostIP")
                    .HasMaxLength(50);

                entity.Property(e => e.LowResPath).HasMaxLength(300);

                entity.Property(e => e.NewSubtitleFile).HasMaxLength(300);

                entity.Property(e => e.NewWavfile)
                    .HasColumnName("NewWAVFile")
                    .HasMaxLength(300);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");

                entity.Property(e => e.VideoPath).HasMaxLength(300);
            });

            modelBuilder.Entity<TblThiemLogPlayList>(entity =>
            {
                entity.ToTable("tblThiem_LogPlayList");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.ApproverId).HasColumnName("ApproverID");

                entity.Property(e => e.DateList).HasColumnType("datetime");

                entity.Property(e => e.SectorId).HasColumnName("SectorID");

                entity.Property(e => e.TimeUpdate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("getdate()");
            });

            modelBuilder.Entity<TblTranscodeEvent>(entity =>
            {
                entity.ToTable("tblTranscodeEvent");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.IdClip).HasColumnName("ID_CLIP");

                entity.Property(e => e.NewFileName)
                    .HasColumnName("NEW_FILE_NAME")
                    .HasMaxLength(50);

                entity.Property(e => e.OriginFileName)
                    .IsRequired()
                    .HasColumnName("ORIGIN_FILE_NAME")
                    .HasMaxLength(50);

                entity.Property(e => e.StartTime)
                    .HasColumnName("START_TIME")
                    .HasColumnType("datetime");

                entity.Property(e => e.Status)
                    .HasColumnName("STATUS")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.TranscoderId).HasColumnName("TRANSCODER_ID");
            });

            modelBuilder.Entity<TblTranscoder>(entity =>
            {
                entity.ToTable("tblTranscoder");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.Directory1)
                    .HasColumnName("DIRECTORY1")
                    .HasMaxLength(500);

                entity.Property(e => e.Directory2)
                    .HasColumnName("DIRECTORY2")
                    .HasMaxLength(500);

                entity.Property(e => e.Ip)
                    .IsRequired()
                    .HasColumnName("IP")
                    .HasMaxLength(50);

                entity.Property(e => e.Name)
                    .HasColumnName("NAME")
                    .HasMaxLength(50);

                entity.Property(e => e.Password)
                    .HasColumnName("PASSWORD")
                    .HasMaxLength(50);

                entity.Property(e => e.Port).HasColumnName("PORT");

                entity.Property(e => e.Priority)
                    .HasColumnName("PRIORITY")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Status)
                    .HasColumnName("STATUS")
                    .HasDefaultValueSql("1");

                entity.Property(e => e.User)
                    .HasColumnName("USER")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<TblUserGroup>(entity =>
            {
                entity.ToTable("tblUser_Group");
            });

            modelBuilder.Entity<TblUsers>(entity =>
            {
                entity.HasKey(e => e.UserId)
                    .HasName("PK__tblUsers__1788CCAC3A5795F5");

                entity.ToTable("tblUsers");

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.Property(e => e.Enabled).HasDefaultValueSql("1");

                entity.Property(e => e.LastActivity).HasColumnType("datetime");

                entity.Property(e => e.LastLoginTime).HasColumnType("datetime");

                entity.Property(e => e.Password).HasColumnType("binary(32)");

                entity.Property(e => e.Username).HasMaxLength(100);
            });

            modelBuilder.Entity<TblVehicleBooking>(entity =>
            {
                entity.HasKey(e => e.BookingId)
                    .HasName("PK__tblVehic__73951AED3D3402A0");

                entity.ToTable("tblVehicle_Booking");

                entity.Property(e => e.BookingId).ValueGeneratedNever();

                entity.Property(e => e.Approver1Comment).HasMaxLength(500);

                entity.Property(e => e.Approver2Comment).HasMaxLength(500);

                entity.Property(e => e.BookingDate).HasColumnType("datetime");

                entity.Property(e => e.EndDate).HasColumnType("datetime");

                entity.Property(e => e.ExpectKm).HasColumnName("ExpectKM");

                entity.Property(e => e.Notes).HasMaxLength(500);

                entity.Property(e => e.StartDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<TblVehicleStatus>(entity =>
            {
                entity.HasKey(e => e.VehicleStatusId)
                    .HasName("PK__tblVehic__D92874EF42ECDBF6");

                entity.ToTable("tblVehicleStatus");

                entity.Property(e => e.VehicleStatusId).ValueGeneratedNever();
            });

            modelBuilder.Entity<TblVehicleTypes>(entity =>
            {
                entity.HasKey(e => e.VehicleTypeId)
                    .HasName("PK__tblVehic__9F44964345C948A1");

                entity.ToTable("tblVehicleTypes");

                entity.Property(e => e.VehicleTypeId).ValueGeneratedNever();

                entity.Property(e => e.Description).HasMaxLength(50);
            });

            modelBuilder.Entity<TblVehicles>(entity =>
            {
                entity.HasKey(e => e.VehicleId)
                    .HasName("PK__tblVehic__476B549240106F4B");

                entity.ToTable("tblVehicles");

                entity.Property(e => e.BuyingDate).HasColumnType("datetime");

                entity.Property(e => e.CurrentKm).HasColumnName("CurrentKM");

                entity.Property(e => e.PlateNumber).HasMaxLength(50);

                entity.Property(e => e.Price).HasColumnType("money");

                entity.Property(e => e.ReparingDate).HasColumnType("datetime");

                entity.Property(e => e.StatusEndDate).HasColumnType("datetime");

                entity.Property(e => e.StatusStartDate).HasColumnType("datetime");

                entity.Property(e => e.TestingDate).HasColumnType("datetime");

                entity.Property(e => e.TestingExpireDate).HasColumnType("datetime");

                entity.Property(e => e.VehicleName).HasMaxLength(100);
            });

            modelBuilder.Entity<TblViewer>(entity =>
            {
                entity.ToTable("tblViewer");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.DepartmentId).HasColumnName("departmentId");

                entity.Property(e => e.UserId).HasColumnName("userId");
            });

            modelBuilder.Entity<TblViewerNewsCategory>(entity =>
            {
                entity.HasKey(e => new { e.ViewerId, e.LocalNewsCategory })
                    .HasName("PK__tblViewe__90FFA5CE4B8221F7");

                entity.ToTable("tblViewer_NewsCategory");

                entity.Property(e => e.ViewerId).HasColumnName("viewerId");

                entity.Property(e => e.LocalNewsCategory).HasColumnName("localNewsCategory");
            });

            modelBuilder.Entity<TblViewerVideo>(entity =>
            {
                entity.HasKey(e => new { e.ViewerId, e.MediaId })
                    .HasName("PK__tblViewe__8F86A23B4E5E8EA2");

                entity.ToTable("tblViewerVideo");

                entity.Property(e => e.ViewerId).HasColumnName("viewerId");

                entity.Property(e => e.MediaId).HasColumnName("mediaId");
            });

            modelBuilder.Entity<TblWorkflowProcess>(entity =>
            {
                entity.HasKey(e => e.WorkflowProcessId)
                    .HasName("PK__tblWorkf__C75E617B513AFB4D");

                entity.ToTable("tblWorkflow_Process");
            });

            modelBuilder.Entity<TblWorkflows>(entity =>
            {
                entity.HasKey(e => e.WorkflowId)
                    .HasName("PK__tblWorkf__5704A66A541767F8");

                entity.ToTable("tblWorkflows");

                entity.Property(e => e.WorkflowName).HasColumnType("varchar(255)");
            });

            modelBuilder.Entity<TempPlayListItem>(entity =>
            {
                entity.ToTable("TempPlayList_Item");

                entity.Property(e => e.Command).HasMaxLength(50);

                entity.Property(e => e.Idclip).HasColumnName("IDCLip");

                entity.Property(e => e.ListId).HasColumnName("ListID");

                entity.Property(e => e.PlayTcIn).HasMaxLength(50);

                entity.Property(e => e.PlayTcOut).HasMaxLength(50);
            });

            modelBuilder.Entity<V4branch>(entity =>
            {
                entity.HasKey(e => e.BranchId)
                    .HasName("PK_V4Branch");

                entity.ToTable("V4Branch");

                entity.Property(e => e.BranchId).ValueGeneratedNever();

                entity.Property(e => e.Cgid).HasColumnName("CGId");

                entity.Property(e => e.Mscid).HasColumnName("MSCId");

                entity.HasOne(d => d.Cg)
                    .WithMany(p => p.V4branch)
                    .HasForeignKey(d => d.Cgid)
                    .HasConstraintName("FK_V4Branch_tblCGServer");

                entity.HasOne(d => d.Msc)
                    .WithMany(p => p.V4branch)
                    .HasForeignKey(d => d.Mscid)
                    .HasConstraintName("FK_V4Branch_tblMCSServers");

                entity.HasOne(d => d.OperateServer)
                    .WithMany(p => p.V4branch)
                    .HasForeignKey(d => d.OperateServerId)
                    .HasConstraintName("FK_V4Branch_tblOperateServers");
            });

            modelBuilder.Entity<V4sectorBranch>(entity =>
            {
                entity.ToTable("V4SectorBranch");

                entity.HasOne(d => d.Branch)
                    .WithMany(p => p.V4sectorBranch)
                    .HasForeignKey(d => d.BranchId)
                    .HasConstraintName("FK_V4SectorBranch_V4Branch");

                entity.HasOne(d => d.Sector)
                    .WithMany(p => p.V4sectorBranch)
                    .HasForeignKey(d => d.SectorId)
                    .HasConstraintName("FK_V4SectorBranch_tblSectors");
            });
        }
    }
}