using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketScalper.ShowsAPI.Data.Entities;

namespace TicketScalper.ShowsAPI.Data
{
  public class ShowContext : DbContext
  {
    private readonly IConfiguration _config;

    public ShowContext(IConfiguration config)
    {
      _config = config;
    }

    public DbSet<Show> Shows { get; set; }
    public DbSet<Act> Acts { get; set; }
    public DbSet<Ticket> Tickets { get; set; }
    public DbSet<Venue> Venues { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder bldr)
    {
      base.OnConfiguring(bldr);

      bldr.UseSqlServer(_config.GetConnectionString("ShowDb"));
    }

    protected override void OnModelCreating(ModelBuilder bldr)
    {
      base.OnModelCreating(bldr);

      BindModel(bldr.Entity<Venue>());
      BindModel(bldr.Entity<Act>());
      BindModel(bldr.Entity<Show>());
      BindModel(bldr.Entity<ActShow>());
      BindModel(bldr.Entity<Ticket>());
    }

    private void BindModel(EntityTypeBuilder<Ticket> bldr)
    {
      bldr.Property(t => t.Seat).HasMaxLength(20);
    }

    private void BindModel(EntityTypeBuilder<Show> bldr)
    {
      bldr.Property(s => s.IsGeneralAdmission).HasDefaultValue(false);
      bldr.Property(s => s.Name).HasMaxLength(100);
    }

    private void BindModel(EntityTypeBuilder<Act> bldr)
    {
      bldr.Property(s => s.Description).HasMaxLength(4000);
      bldr.Property(s => s.Name).HasMaxLength(100);
    }

    private void BindModel(EntityTypeBuilder<ActShow> bldr)
    {
      bldr.Property("ActId");
      bldr.Property("ShowId");
      bldr.HasKey("ActId", "ShowId");

      bldr.HasOne(a => a.Act)
       .WithMany(a => a.ActShows)
       .HasForeignKey("ActId");
      bldr.HasOne(a => a.Show)
       .WithMany(s => s.ActShows)
       .HasForeignKey("ShowId");
    }

    private void BindModel(EntityTypeBuilder<Venue> bldr)
    {
      var addr = bldr.OwnsOne(v => v.Address);
      bldr.Property(v => v.Name).HasMaxLength(100);
      bldr.Property(v => v.Phone).HasMaxLength(20);

      addr.Property(a => a.Address1).HasMaxLength(100);
      addr.Property(a => a.Address2).HasMaxLength(100);
      addr.Property(a => a.Address3).HasMaxLength(100);
      addr.Property(a => a.CityTown).HasMaxLength(50);
      addr.Property(a => a.StateProvince).HasMaxLength(50);
      addr.Property(a => a.PostalCode).HasMaxLength(50);
      addr.Property(a => a.Country).HasMaxLength(50);


    }
  }
}
