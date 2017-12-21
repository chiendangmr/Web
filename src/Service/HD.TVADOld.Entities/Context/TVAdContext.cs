using HD.TVADOld.Entities.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace HD.TVADOld.Entities.Context
{
    public class TVAdContext : DbContext
    {
        public DbSet<Block> Blocks { get; set; }

        public DbSet<Channel> Channels { get; set; }

        public DbSet<TimeBand> TimeBands { get; set; }

        public DbSet<TimeBandDescription> TimeBandDescriptions { get; set; }

        public DbSet<TimeBandSlice> TimeBandSlices { get; set; }

        public DbSet<TimeBandSliceDescription> TimeBandSliceDescriptions { get; set; }

        public DbSet<TimeBandPrice> TimeBandPrices { get; set; }

        public DbSet<PositionRate> PositionRates { get; set; }

        public DbSet<TimeBandPositionRate> TimeBandPositionRates { get; set; }

        public DbSet<PartnerCustomer> PartnerCustomers { get; set; }

        public DbSet<SponsorProgram> SponsorPrograms { get; set; }

        public DbSet<Register> Registers { get; set; }

        public DbSet<Content> Contents { get; set; }

        public DbSet<ContentTimeBandLock> ContentTimeBandLocks { get; set; }

        public DbSet<ContentChannelLock> ContentChannelLocks { get; set; }

        public DbSet<ContentChannelLock_TimeBandNoLock> ContentChannelLock_TimeBandNoLocks { get; set; }

        public DbSet<AnnexContractPartner> AnnexContractPartners { get; set; }

        public DbSet<AnnexContractPartnerContent> AnnexContractPartnerContents { get; set; }

        public DbSet<Spot> Spots { get; set; }

        public DbSet<AnnexContractPartnerSpotBooking> AnnexContractPartnerSpotBookings { get; set; }

        public DbSet<DiscountPartnerCustomer> DiscountPartnerCustomers { get; set; }

        public DbSet<DiscountSponsorProgram> DiscountSponsorPrograms { get; set; }

        public DbSet<DiscountAnnexContractPartner> DiscountAnnexContractPartners { get; set; }

        public DbSet<DiscountAnnexContractPartnerByTimeBand> DiscountAnnexContractPartnerByTimeBands { get; set; }

        public DbSet<AnnexContractPartnerPriceAtSignDate> AnnexContractPartnerPriceAtSignDates { get; set; }

        public DbSet<AnnexContractPartnerPrice> AnnexContractPartnerPrices { get; set; }

        public DbSet<AnnexContractPartnerPrice_Block> AnnexContractPartnerPrice_Blocks { get; set; }

        public DbSet<AnnexContractPartnerPrice_TimeBand> AnnexContractPartnerPrice_TimeBands { get; set; }

        public DbSet<RetailType> RetailTypies { get; set; }

        public DbSet<RetailPrice> RetailPrices { get; set; }

        public DbSet<AnnexContractRetail> AnnexContractRetails { get; set; }

        public DbSet<AnnexContractRetailContent> AnnexContractRetailContents { get; set; }

        public DbSet<AnnexContractRetailSpotBooking> AnnexContractRetailSpotBookings { get; set; }

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
            modelBuilder.Entity<TimeBandDescription>()
                .HasKey(d => new { d.TimeBandId, d.StartDate });

            modelBuilder.Entity<TimeBandSlice>()
                .HasKey(s => new { s.TimeBandId, s.SliceId });

            modelBuilder.Entity<TimeBandSliceDescription>(entity =>
            {
                entity.HasKey(d => new { d.TimeBandId, d.SliceId, d.StartDate, d.DayOfWeeks });
                entity.HasOne(d => d.Slice)
                .WithMany(s => s.Descriptions)
                .HasPrincipalKey(s => new { s.TimeBandId, s.SliceId })
                .HasForeignKey(d => new { d.TimeBandId, d.SliceId });
            });

            modelBuilder.Entity<TimeBandPrice>(entity =>
            {
                entity.HasKey(p => new { p.TimeBandId, p.BlockDuration, p.StartDate });
                entity.HasOne(p => p.Block)
                    .WithMany(b => b.TimeBandPrices)
                    .HasPrincipalKey(b => b.Duration)
                    .HasForeignKey(p => p.BlockDuration);
            });

            modelBuilder.Entity<TimeBandPositionRate>()
                .HasKey(r => new { r.TimeBandId, r.StartDate });

            modelBuilder.Entity<ContentTimeBandLock>().HasKey(t => new { t.ContentCode, t.TimeBandId });

            modelBuilder.Entity<ContentChannelLock>().HasKey(l => new { l.ContentCode, l.ChannelId });

            modelBuilder.Entity<ContentChannelLock_TimeBandNoLock>().HasKey(l => new { l.ContentCode, l.TimeBandId });

            modelBuilder.Entity<AnnexContractPartnerContent>()
                .HasKey(a => new { a.AnnexContractPartnerId, a.ContentCode });

            modelBuilder.Entity<Spot>(entity =>
            {
                entity.HasOne(s => s.TimeBandSlice)
                    .WithMany(s => s.Spots)
                    .HasPrincipalKey(s => new { s.TimeBandId, s.SliceId })
                    .HasForeignKey(s => new { s.TimeBandId, s.SliceId })
                    .OnDelete(Microsoft.EntityFrameworkCore.Metadata.DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<AnnexContractPartnerSpotBooking>()
                .HasOne(b => b.AnnexContractPartnerContent)
                .WithMany(c => c.Bookings)
                .HasPrincipalKey(c => new { c.AnnexContractPartnerId, c.ContentCode })
                .HasForeignKey(b => new { b.AnnexContractPartnerId, b.ContentCode })
                .OnDelete(Microsoft.EntityFrameworkCore.Metadata.DeleteBehavior.Cascade);

            modelBuilder.Entity<DiscountPartnerCustomer>()
                .HasKey(d => new { d.CustomerId, d.StartDate });

            modelBuilder.Entity<DiscountSponsorProgram>()
                .HasKey(d => new { d.SponsorProgramId, d.StartDate });

            modelBuilder.Entity<DiscountAnnexContractPartner>()
                .HasKey(d => new { d.AnnexContractId, d.StartDate });

            modelBuilder.Entity<DiscountAnnexContractPartnerByTimeBand>()
                .HasKey(d => new { d.AnnexContractId, d.TimeBandId, d.StartDate });

            modelBuilder.Entity<AnnexContractPartnerPriceAtSignDate>()
                .HasKey(p => new { p.AnnexContractId, p.StartDate });

            modelBuilder.Entity<AnnexContractPartnerPrice>()
                .HasKey(p => new { p.AnnexContractId, p.StartDate });

            modelBuilder.Entity<AnnexContractPartnerPrice_Block>(entity =>
           {
               entity.HasKey(e => new { e.AnnexContractId, e.StartDate, e.BlockDuration });

               entity.HasOne(e => e.AnnexContractPartnerPrice)
               .WithMany(p => p.Blocks)
               .HasPrincipalKey(p => new { p.AnnexContractId, p.StartDate })
               .HasForeignKey(e => new { e.AnnexContractId, e.StartDate });
           });

            modelBuilder.Entity<AnnexContractPartnerPrice_TimeBand>(entity =>
           {
               entity.HasKey(e => new { e.AnnexContractId, e.StartDate, e.TimeBandId });

               entity.HasOne(e => e.AnnexContractPartnerPrice)
               .WithMany(p => p.TimeBands)
               .HasPrincipalKey(p => new { p.AnnexContractId, p.StartDate })
               .HasForeignKey(e => new { e.AnnexContractId, e.StartDate });
           });

            modelBuilder.Entity<AnnexContractRetailContent>()
                .HasKey(c => new { c.AnnexContractId, c.ContentCode });

            modelBuilder.Entity<AnnexContractRetailSpotBooking>(entity =>
           {
               entity.HasOne(b => b.AnnexContractContent)
               .WithMany(c => c.Bookings)
               .HasPrincipalKey(c => new { c.AnnexContractId, c.ContentCode })
               .HasForeignKey(b => new { b.AnnexContractId, b.ContentCode });
           });

            modelBuilder.Entity<RetailPrice>()
                .HasKey(e => new { e.RetailTypeId, e.StartDate });

            base.OnModelCreating(modelBuilder);
        }
    }
}