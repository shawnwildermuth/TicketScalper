﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TicketScalper.SalesAPI.Data;

namespace TicketScalper.SalesAPI.Migrations
{
    [DbContext(typeof(SalesContext))]
    partial class SalesContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("TicketScalper.SalesAPI.Data.Entities.Customer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AddressLine1")
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.Property<string>("AddressLine2")
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.Property<string>("AddressLine3")
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.Property<string>("CityTown")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("CompanyName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Country")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("PostalCode")
                        .HasColumnType("nvarchar(20)")
                        .HasMaxLength(20);

                    b.Property<string>("StateProvince")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.ToTable("Customers","Sales");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            AddressLine1 = "123 Main Street",
                            CityTown = "Atlanta",
                            FirstName = "Resa",
                            LastName = "Wildermuth",
                            PhoneNumber = "404-555-1212",
                            PostalCode = "12345",
                            StateProvince = "GA"
                        });
                });

            modelBuilder.Entity("TicketScalper.SalesAPI.Data.Entities.TicketInfo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Acts")
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.Property<string>("AddressLine1")
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.Property<string>("AddressLine2")
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.Property<string>("AddressLine3")
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.Property<string>("CityTown")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("Country")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("PostalCode")
                        .HasColumnType("nvarchar(20)")
                        .HasMaxLength(20);

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(9,2)");

                    b.Property<int>("SaleId")
                        .HasColumnType("int");

                    b.Property<string>("Seat")
                        .HasColumnType("nvarchar(20)")
                        .HasMaxLength(20);

                    b.Property<DateTime>("ShowDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("ShowName")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("StateProvince")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("VenueName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("SaleId");

                    b.ToTable("Tickets","Sales");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Acts = "Styx and REO Speedwagon",
                            AddressLine1 = "123 Main Street",
                            CityTown = "Atlanta",
                            PostalCode = "30307",
                            Price = 69.99m,
                            SaleId = 1,
                            Seat = "General Admission",
                            ShowDate = new DateTime(2020, 11, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            ShowName = "We're Still Alive Tour",
                            StateProvince = "GA",
                            VenueName = "Variety Playhouse"
                        },
                        new
                        {
                            Id = 2,
                            Acts = "Styx and REO Speedwagon",
                            AddressLine1 = "123 Main Street",
                            CityTown = "Atlanta",
                            PostalCode = "30307",
                            Price = 69.99m,
                            SaleId = 1,
                            Seat = "General Admission",
                            ShowDate = new DateTime(2020, 11, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            ShowName = "We're Still Alive Tour",
                            StateProvince = "GA",
                            VenueName = "Variety Playhouse"
                        },
                        new
                        {
                            Id = 3,
                            Acts = "Styx and REO Speedwagon",
                            AddressLine1 = "123 Main Street",
                            CityTown = "Atlanta",
                            PostalCode = "30307",
                            Price = 69.99m,
                            SaleId = 1,
                            Seat = "General Admission",
                            ShowDate = new DateTime(2020, 11, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            ShowName = "We're Still Alive Tour",
                            StateProvince = "GA",
                            VenueName = "Variety Playhouse"
                        },
                        new
                        {
                            Id = 4,
                            Acts = "Styx and REO Speedwagon",
                            AddressLine1 = "123 Main Street",
                            CityTown = "Atlanta",
                            PostalCode = "30307",
                            Price = 69.99m,
                            SaleId = 1,
                            Seat = "General Admission",
                            ShowDate = new DateTime(2020, 11, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            ShowName = "We're Still Alive Tour",
                            StateProvince = "GA",
                            VenueName = "Variety Playhouse"
                        });
                });

            modelBuilder.Entity("TicketScalper.SalesAPI.Data.Entities.TicketSale", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ApprovalCode")
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.Property<bool>("Completed")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(false);

                    b.Property<int>("CustomerId")
                        .HasColumnType("int");

                    b.Property<string>("PaymentType")
                        .HasColumnType("nvarchar(20)")
                        .HasMaxLength(20);

                    b.Property<string>("TransactionNumber")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<decimal>("TransactionTotal")
                        .HasColumnType("decimal(9,2)");

                    b.HasKey("Id");

                    b.HasIndex("CustomerId");

                    b.ToTable("TicketSales","Sales");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            ApprovalCode = "12345",
                            Completed = true,
                            CustomerId = 1,
                            PaymentType = "Credit Card",
                            TransactionNumber = "7287391829",
                            TransactionTotal = 0m
                        });
                });

            modelBuilder.Entity("TicketScalper.SalesAPI.Data.Entities.TicketInfo", b =>
                {
                    b.HasOne("TicketScalper.SalesAPI.Data.Entities.TicketSale", "Sale")
                        .WithMany("Tickets")
                        .HasForeignKey("SaleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("TicketScalper.SalesAPI.Data.Entities.TicketSale", b =>
                {
                    b.HasOne("TicketScalper.SalesAPI.Data.Entities.Customer", "Customer")
                        .WithMany("Sales")
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}