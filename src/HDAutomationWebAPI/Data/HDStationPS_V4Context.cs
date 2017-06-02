using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using HDAutomationWebAPI.Models;

namespace HDAutomationWebAPI.Data
{
    public partial class HDStationPS_V4Context : DbContext
    {
        public virtual DbSet<Cluster> Cluster { get; set; }
        public virtual DbSet<GroupClip> GroupClip { get; set; }
        public virtual DbSet<InforTape> InforTape { get; set; }
        public virtual DbSet<LogoSetting> LogoSetting { get; set; }
        public virtual DbSet<PlayList> PlayList { get; set; }
        public virtual DbSet<PlayListHistory> PlayListHistory { get; set; }
        public virtual DbSet<PlayListItem> PlayListItem { get; set; }
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
        public virtual DbSet<TblListCopy> TblListCopy { get; set; }
        public virtual DbSet<TblListItemCopy> TblListItemCopy { get; set; }
        public virtual DbSet<TblNasTable> TblNasTable { get; set; }
        public virtual DbSet<TblSectors> TblSectors { get; set; }
        public virtual DbSet<TblServerDeviceTypes> TblServerDeviceTypes { get; set; }
        public virtual DbSet<TblServerFactory> TblServerFactory { get; set; }
        public virtual DbSet<TblServerFactoryExtension> TblServerFactoryExtension { get; set; }
        public virtual DbSet<TblServerStatus> TblServerStatus { get; set; }
        public virtual DbSet<TblServerTypes> TblServerTypes { get; set; }
        public virtual DbSet<TblServers> TblServers { get; set; }
        public virtual DbSet<TblServicesModule> TblServicesModule { get; set; }
        public virtual DbSet<TblTapeTypes> TblTapeTypes { get; set; }
        public virtual DbSet<TempPlayListItem> TempPlayListItem { get; set; }

        public HDStationPS_V4Context(DbContextOptions<HDStationPS_V4Context> options) : base(options) { }

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

            modelBuilder.Entity<TblTapeTypes>(entity =>
            {
                entity.HasKey(e => e.TapeTypeId)
                    .HasName("PK__tblTapeT__55A0EEAE292D09F3");

                entity.ToTable("tblTapeTypes");

                entity.Property(e => e.TapeTypeId).ValueGeneratedNever();

                entity.Property(e => e.Description).HasMaxLength(50);
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
        }
    }
}