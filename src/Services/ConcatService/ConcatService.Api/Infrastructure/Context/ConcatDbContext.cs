using ConcatService.Api.Core.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace ConcatService.Api.Infrastructure.Context
{
    public class ConcatDbContext : DbContext
    {
        public ConcatDbContext(DbContextOptions<ConcatDbContext> options) : base(options)
        {

        }
        public DbSet<Person> Person { get; set; }
        public DbSet<ContactInformation> ContactInformation { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ContactInformation>().ToTable("ContactInformation");
            modelBuilder.Entity<Person>().ToTable("Person")
                                        .HasMany<ContactInformation>(x => x.ContactInformations)
                                        .WithOne(x => x.Person)
                                        .HasForeignKey(x => x.PersonId);

            base.OnModelCreating(modelBuilder);
        }
    }
}
