﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using OpenRedding.Infrastructure.Persistence.Data;

namespace OpenRedding.Infrastructure.Persistence.Migrations.OpenRedding
{
    [DbContext(typeof(OpenReddingDbContext))]
    partial class OpenReddingDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("OpenRedding.Domain.Salaries.Entities.Employee", b =>
                {
                    b.Property<int>("EmployeeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<decimal>("BasePay")
                        .HasColumnType("DECIMAL(9,2)");

                    b.Property<decimal>("Benefits")
                        .HasColumnType("DECIMAL(9,2)");

                    b.Property<string>("EmployeeAgency")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EmployeeStatus")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("JobTitle")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MiddleName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Notes")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("OtherPay")
                        .HasColumnType("DECIMAL(9,2)");

                    b.Property<decimal>("OvertimePay")
                        .HasColumnType("DECIMAL(9,2)");

                    b.Property<decimal?>("PensionDebt")
                        .HasColumnType("DECIMAL(9,2)");

                    b.Property<decimal>("TotalPay")
                        .HasColumnType("DECIMAL(9,2)");

                    b.Property<decimal>("TotalPayWithBenefits")
                        .HasColumnType("DECIMAL(9,2)");

                    b.Property<int>("Year")
                        .HasColumnType("int");

                    b.HasKey("EmployeeId");

                    b.ToTable("Employees");
                });

            modelBuilder.Entity("OpenRedding.Domain.Zoning.Entities.ReddingZone", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("BaseDist")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("OverlayDisctrict")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("OverlayDistrictExtended")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("ShapeArea")
                        .HasColumnType("float");

                    b.Property<double>("ShapeLength")
                        .HasColumnType("float");

                    b.Property<int>("ZoneId")
                        .HasColumnType("int");

                    b.Property<string>("Zoning")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ZoningClass")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ZoningDescription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ZoningDescriptionExtended")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Zones");
                });
#pragma warning restore 612, 618
        }
    }
}
