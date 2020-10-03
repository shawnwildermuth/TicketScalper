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
  /// <summary>
  /// The Context class for Shows
  /// </summary>
  /// <seealso cref="Microsoft.EntityFrameworkCore.DbContext" />
  public class ShowContext : DbContext
  {
    /// <summary>
    /// Initializes a new instance of the <see cref="ShowContext"/> class.
    /// </summary>
    /// <param name="options">The options for this context.</param>
    public ShowContext(DbContextOptions options) : base(options)
    {
    }

    /// <summary>
    /// Gets or sets the shows.
    /// </summary>
    /// <value>
    /// The shows.
    /// </value>
    public DbSet<Show> Shows { get; set; }
    /// <summary>
    /// Gets or sets the acts.
    /// </summary>
    /// <value>
    /// The acts.
    /// </value>
    public DbSet<Act> Acts { get; set; }
    /// <summary>
    /// Gets or sets the tickets.
    /// </summary>
    /// <value>
    /// The tickets.
    /// </value>
    public DbSet<Ticket> Tickets { get; set; }
    /// <summary>
    /// Gets or sets the venues.
    /// </summary>
    /// <value>
    /// The venues.
    /// </value>
    public DbSet<Venue> Venues { get; set; }

    /// <summary>
    /// Called when [model creating].
    /// </summary>
    /// <param name="bldr">The BLDR.</param>
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
      bldr.ToTable("Tickets", "TicketScalper");
      bldr.Property(t => t.Seat).HasMaxLength(20);
      bldr.Property(t => t.OriginalPrice).HasColumnType("decimal(9,2)");
      bldr.Property(t => t.CurrentPrice).HasColumnType("decimal(9,2)");
      bldr.HasData(SeedDataProvider.GenerateTickets());
    }

    private void BindModel(EntityTypeBuilder<Show> bldr)
    {
      bldr.ToTable("Shows", "TicketScalper");
      bldr.Property(s => s.IsGeneralAdmission).HasDefaultValue(false);
      bldr.Property(s => s.Name).HasMaxLength(100);
      bldr.HasData(SeedDataProvider.GenerateShows());
    }

    private void BindModel(EntityTypeBuilder<Act> bldr)
    {
      bldr.ToTable("Acts", "TicketScalper");
      bldr.Property(s => s.Description).HasMaxLength(4000);
      bldr.Property(s => s.Name).HasMaxLength(100);
      bldr.HasData(SeedDataProvider.GenerateActs());
    }

    private void BindModel(EntityTypeBuilder<ActShow> bldr)
    {
      bldr.ToTable("ActShows", "TicketScalper");
      bldr.Property("ActId");
      bldr.Property("ShowId");
      bldr.HasKey("ActId", "ShowId");

      bldr.HasOne(a => a.Act)
       .WithMany(a => a.ActShows)
       .HasForeignKey("ActId");
      bldr.HasOne(a => a.Show)
       .WithMany(s => s.ActShows)
       .HasForeignKey("ShowId");

      bldr.HasData(SeedDataProvider.GenerateActShows());

    }

    private void BindModel(EntityTypeBuilder<Venue> bldr)
    {
      bldr.ToTable("Venues", "TicketScalper");

      var addr = bldr.OwnsOne(v => v.Address);
      bldr.Property(v => v.Name).HasMaxLength(100);
      bldr.Property(v => v.Phone).HasMaxLength(20);

      addr.Property(a => a.Address1).HasMaxLength(100).HasDefaultValue("");
      addr.Property(a => a.Address2).HasMaxLength(100).HasDefaultValue("");
      addr.Property(a => a.Address3).HasMaxLength(100).HasDefaultValue("");
      addr.Property(a => a.CityTown).HasMaxLength(50).HasDefaultValue("");
      addr.Property(a => a.StateProvince).HasMaxLength(50).HasDefaultValue("");
      addr.Property(a => a.PostalCode).HasMaxLength(50).HasDefaultValue("");
      addr.Property(a => a.Country).HasMaxLength(50).HasDefaultValue("");
      addr.HasData(SeedDataProvider.GenerateAddresses());

      bldr.HasData(SeedDataProvider.GenerateVenues());
    }
  }
}
