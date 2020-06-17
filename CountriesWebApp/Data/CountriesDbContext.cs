using CountriesWebApp.Data.DataModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CountriesWebApp.Data
{
    public class CountriesDbContext : DbContext
    {
        public virtual DbSet<CountryDto> Countries { get; set; }
        public virtual DbSet<RegionDto> Regions { get; set; }
        public virtual DbSet<CityDto> Cities { get; set; }

        public CountriesDbContext(DbContextOptions<CountriesDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CityDto>()
                .HasOne(c => c.Country).WithOne(c => c.Capital)
                .HasForeignKey<CountryDto>(c => c.CapitalCityId);

            modelBuilder.Entity<RegionDto>()
                .HasMany(r => r.Countries)
                .WithOne(r => r.Region);

            modelBuilder.Entity<CountryDto>()
                .Property(c => c.Population)
                .HasColumnType("bigint");
        }
    }
}
