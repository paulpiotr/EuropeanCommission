﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Vies.Core.Database.Data;

namespace Vies.Core.Database.Migrations
{
    [DbContext(typeof(ViesCoreDatabaseContext))]
    [Migration("20210114120706_4")]
    partial class _4
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.2");

            modelBuilder.Entity("Vies.Core.Models.CheckVat", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValueSql("(newsequentialid())");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)")
                        .HasColumnName("Address");

                    b.Property<string>("CountryCode")
                        .IsRequired()
                        .HasMaxLength(8)
                        .HasColumnType("varchar(8)")
                        .HasColumnName("CountryCode");

                    b.Property<DateTime>("DateOfCreate")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("datetime")
                        .HasColumnName("DateOfCreate")
                        .HasDefaultValueSql("(getdate())");

                    b.Property<DateTime?>("DateOfModification")
                        .HasColumnType("datetime")
                        .HasColumnName("DateOfModification");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("varchar(128)")
                        .HasColumnName("Name");

                    b.Property<DateTime>("RequestDate")
                        .HasColumnType("datetime")
                        .HasColumnName("RequestDate");

                    b.Property<string>("UniqueIdentifierOfTheLoggedInUser")
                        .IsRequired()
                        .HasMaxLength(512)
                        .HasColumnType("varchar(512)")
                        .HasColumnName("UniqueIdentifierOfTheLoggedInUser");

                    b.Property<bool>("Valid")
                        .HasColumnType("bit")
                        .HasColumnName("Valid");

                    b.Property<string>("VatNumber")
                        .IsRequired()
                        .HasMaxLength(16)
                        .HasColumnType("varchar(16)")
                        .HasColumnName("VatNumber");

                    b.HasKey("Id");

                    b.HasIndex("DateOfCreate")
                        .HasDatabaseName("IX_CheckVatDateOfCreate");

                    b.HasIndex("DateOfModification")
                        .HasDatabaseName("IX_CheckVatDateOfModification");

                    b.HasIndex("Id")
                        .IsUnique()
                        .HasDatabaseName("IX_CheckVatId");

                    b.HasIndex("Name")
                        .HasDatabaseName("IX_CheckVatName");

                    b.HasIndex("RequestDate")
                        .HasDatabaseName("IX_CheckVatRequestDate");

                    b.HasIndex("UniqueIdentifierOfTheLoggedInUser")
                        .HasDatabaseName("IX_CheckVatUniqueIdentifierOfTheLoggedInUser");

                    b.HasIndex("VatNumber")
                        .HasDatabaseName("IX_CheckVatNumber");

                    b.ToTable("CheckVat", "etvc");
                });

            modelBuilder.Entity("Vies.Core.Models.CheckVatApprox", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValueSql("(newsequentialid())");

                    b.Property<string>("CountryCode")
                        .IsRequired()
                        .HasMaxLength(8)
                        .HasColumnType("varchar(8)")
                        .HasColumnName("CountryCode");

                    b.Property<DateTime>("DateOfCreate")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("datetime")
                        .HasColumnName("DateOfCreate")
                        .HasDefaultValueSql("(getdate())");

                    b.Property<DateTime?>("DateOfModification")
                        .HasColumnType("datetime")
                        .HasColumnName("DateOfModification");

                    b.Property<DateTime>("RequestDate")
                        .HasColumnType("datetime")
                        .HasColumnName("RequestDate");

                    b.Property<string>("RequestIdentifier")
                        .IsRequired()
                        .HasMaxLength(16)
                        .HasColumnType("varchar(16)")
                        .HasColumnName("RequestIdentifier");

                    b.Property<string>("TraderAddress")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)")
                        .HasColumnName("TraderAddress");

                    b.Property<string>("TraderCity")
                        .HasMaxLength(64)
                        .HasColumnType("varchar(64)")
                        .HasColumnName("TraderCity");

                    b.Property<short>("TraderCityMatch")
                        .HasColumnType("smallint")
                        .HasColumnName("TraderCityMatch");

                    b.Property<string>("TraderCompanyType")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)")
                        .HasColumnName("TraderCompanyType");

                    b.Property<short>("TraderCompanyTypeMatch")
                        .HasColumnType("smallint")
                        .HasColumnName("TraderCompanyTypeMatch");

                    b.Property<string>("TraderName")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)")
                        .HasColumnName("TraderName");

                    b.Property<short>("TraderNameMatch")
                        .HasColumnType("smallint")
                        .HasColumnName("TraderNameMatch");

                    b.Property<string>("TraderPostcode")
                        .HasMaxLength(32)
                        .HasColumnType("varchar(32)")
                        .HasColumnName("TraderPostcode");

                    b.Property<short>("TraderPostcodeMatch")
                        .HasColumnType("smallint")
                        .HasColumnName("TraderPostcodeMatch");

                    b.Property<string>("TraderStreet")
                        .HasMaxLength(64)
                        .HasColumnType("varchar(64)")
                        .HasColumnName("TraderStreet");

                    b.Property<short>("TraderStreetMatch")
                        .HasColumnType("smallint")
                        .HasColumnName("TraderStreetMatch");

                    b.Property<string>("UniqueIdentifierOfTheLoggedInUser")
                        .IsRequired()
                        .HasMaxLength(512)
                        .HasColumnType("varchar(512)")
                        .HasColumnName("UniqueIdentifierOfTheLoggedInUser");

                    b.Property<bool>("Valid")
                        .HasColumnType("bit")
                        .HasColumnName("Valid");

                    b.Property<string>("VatNumber")
                        .IsRequired()
                        .HasMaxLength(16)
                        .HasColumnType("varchar(16)")
                        .HasColumnName("VatNumber");

                    b.HasKey("Id");

                    b.HasIndex("DateOfCreate")
                        .HasDatabaseName("IX_CheckVatApproxDateOfCreate");

                    b.HasIndex("DateOfModification")
                        .HasDatabaseName("IX_CheckVatApproxDateOfModification");

                    b.HasIndex("Id")
                        .IsUnique()
                        .HasDatabaseName("IX_CheckVatApproxId");

                    b.HasIndex("RequestDate")
                        .HasDatabaseName("IX_CheckVatApproxRequestDate");

                    b.HasIndex("TraderName")
                        .HasDatabaseName("IX_CheckVatApproxTraderName");

                    b.HasIndex("UniqueIdentifierOfTheLoggedInUser")
                        .HasDatabaseName("IX_CheckVatApproxUniqueIdentifierOfTheLoggedInUser");

                    b.HasIndex("VatNumber")
                        .HasDatabaseName("IX_CheckVatApproxNumber");

                    b.ToTable("CheckVatApprox", "etvc");
                });
#pragma warning restore 612, 618
        }
    }
}
