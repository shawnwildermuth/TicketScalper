﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketScalper.SalesAPI.Data.Entities;

namespace TicketScalper.SalesAPI.Data
{
  /// <summary>
  /// Context object for accessing Database information
  /// </summary>
  /// <seealso cref="Microsoft.EntityFrameworkCore.DbContext" />
  public class SalesContext : DbContext
  {
    /// <summary>
    /// Initializes a new instance of the <see cref="SalesContext"/> class.
    /// </summary>
    /// <param name="options">The options for this context.</param>
    public SalesContext([NotNullAttribute] DbContextOptions options) : base(options)
    {
    }

    /// <summary>
    /// Gets or sets the customers.
    /// </summary>
    /// <value>
    /// The customers.
    /// </value>
    public DbSet<Customer>  Customers { get; set; }
    /// <summary>
    /// Gets or sets the ticket sales.
    /// </summary>
    /// <value>
    /// The ticket sales.
    /// </value>
    public DbSet<TicketSale> TicketSales { get; set; }

    /// <summary>
    /// Called when [model creating].
    /// </summary>
    /// <param name="bldr">The BLDR.</param>
    protected override void OnModelCreating(ModelBuilder bldr)
    {
      base.OnModelCreating(bldr);

      BindModel(bldr.Entity<Customer>());
      BindModel(bldr.Entity<TicketInfo>());
      BindModel(bldr.Entity<TicketSale>());
    }

    private void BindModel(EntityTypeBuilder<TicketSale> bldr)
    {
      bldr.ToTable("TicketSales", "Sales");
      bldr.Property(p => p.ApprovalCode).HasMaxLength(100);
      bldr.Property(p => p.Completed).HasDefaultValue(false);
      bldr.Property(p => p.PaymentType).HasMaxLength(20);
      bldr.Property(p => p.TransactionNumber).HasMaxLength(50);
      bldr.Property(p => p.TransactionTotal).HasColumnType("decimal(9,2)");
      bldr.HasData(SalesSeedProvider.GenerateSales());
    }

    private void BindModel(EntityTypeBuilder<TicketInfo> bldr)
    {
      bldr.ToTable("Tickets", "Sales");
      bldr.Property(t => t.Seat).HasMaxLength(20);
      bldr.Property(t => t.ShowName).HasMaxLength(50);
      bldr.Property(t => t.Acts).HasMaxLength(100);
      bldr.Property(t => t.AddressLine1)
        .HasMaxLength(100);
      bldr.Property(t => t.AddressLine2)
        .HasMaxLength(100);
      bldr.Property(t => t.AddressLine3)
        .HasMaxLength(100);
      bldr.Property(t => t.CityTown)
        .HasMaxLength(50);
      bldr.Property(t => t.StateProvince)
        .HasMaxLength(50);
      bldr.Property(t => t.PostalCode)
        .HasMaxLength(20);
      bldr.Property(t => t.Country)
        .HasMaxLength(50);
      bldr.Property(t => t.PhoneNumber)
        .HasMaxLength(50);
      bldr.Property(t => t.Price).HasColumnType("decimal(9,2)");
      bldr.HasData(SalesSeedProvider.GenerateTicketInfos());
    }

    private void BindModel(EntityTypeBuilder<Customer> bldr)
    {
      bldr.ToTable("Customers", "Sales");
      bldr.Property(c => c.FirstName)
        .HasMaxLength(50);
      bldr.Property(c => c.LastName)
        .HasMaxLength(50);
      bldr.Property(c => c.AddressLine1)
        .HasMaxLength(100);
      bldr.Property(c => c.AddressLine2)
        .HasMaxLength(100);
      bldr.Property(c => c.AddressLine3)
        .HasMaxLength(100);
      bldr.Property(c => c.CityTown)
        .HasMaxLength(50);
      bldr.Property(c => c.StateProvince)
        .HasMaxLength(50);
      bldr.Property(c => c.PostalCode)
        .HasMaxLength(20);
      bldr.Property(c => c.Country)
        .HasMaxLength(50);
      bldr.Property(c => c.PhoneNumber)
        .HasMaxLength(50);

      bldr.HasData(SalesSeedProvider.GenerateCustomers());
    }
  }
}
