﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TravelRequisition.Core.EFContext;

namespace TravelRequisition.Core.Migrations
{
    [DbContext(typeof(DataDbContext))]
    partial class DataDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.9");

            modelBuilder.Entity("TravelRequisition.Core.Entities.TravelRequest", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .UseIdentityColumn();

                    b.Property<string>("ChargeCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Country")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Destination")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("ModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("ProposedDeparture")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("RequestDate")
                        .HasColumnType("datetime2");

                    b.Property<long>("RequisitionNumber")
                        .HasColumnType("bigint");

                    b.Property<int>("RequisitionStatus")
                        .HasColumnType("int");

                    b.Property<string>("SourceCountry")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SourceLocation")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TravelClass")
                        .HasColumnType("int");

                    b.Property<int>("TripType")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("TravelRequest");
                });
#pragma warning restore 612, 618
        }
    }
}
