using Microsoft.EntityFrameworkCore;
using ReportService.Api.Core.Domain.Entities;
using System;

namespace ReportService.Api.Infrastructure.Context
{
    public class ReportDbContext : DbContext
    {
        public ReportDbContext(DbContextOptions<ReportDbContext> options) : base(options)
        {
            
        }
        public DbSet<Report> Report { get; set; }
        public DbSet<ReportDetail> ReportDetail { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ReportDetail>().ToTable("ReportDetail");
            modelBuilder.Entity<Report>().ToTable("Report")
                                        .HasMany<ReportDetail>(x => x.Detail)
                                        .WithOne(x => x.Report)
                                        .HasForeignKey(x => x.ReportId);

            base.OnModelCreating(modelBuilder);
        }
    }
}
