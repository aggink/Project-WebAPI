﻿// <auto-generated />
using System;
using Company.Data.DbContexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Company.Data.Migrations.CatalogDbMigration
{
    [DbContext(typeof(CatalogDbContext))]
    [Migration("20220903222632_InitDataBase")]
    partial class InitDataBase
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Company.Entity.ParseValuesProduct", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("AvailabilityProductOffice")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("AvailabilityProductStock")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("InfoURLId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Price")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Price10")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Price5")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Text")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("UpdatedBy")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("InfoURLId");

                    b.ToTable("ParseValuesProduct", (string)null);
                });

            modelBuilder.Entity("Company.Entity.Product", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("AnalogProduct")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Article")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Availability")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("AvailabilityType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CartridgeCompatibility")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Category")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CodeProduct")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CodeTN")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Color")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Compatibility")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LengthWidthHeight")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Manufacturer")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Model")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("OriginallyProduct")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Price")
                        .HasPrecision(38, 18)
                        .HasColumnType("decimal(38,18)");

                    b.Property<decimal>("PriceFrom10")
                        .HasPrecision(38, 18)
                        .HasColumnType("decimal(38,18)");

                    b.Property<decimal>("PriceFrom5")
                        .HasPrecision(38, 18)
                        .HasColumnType("decimal(38,18)");

                    b.Property<string>("PrinterCompatibility")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("QuantityPackage")
                        .HasColumnType("int");

                    b.Property<double>("Resource")
                        .HasColumnType("float");

                    b.Property<string>("SeriesProduct")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("TextProductId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("TrademarkAndPN")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TypeEquipment")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TypeProduct")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("UpdatedBy")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("Vendor")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Weight")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("TextProductId")
                        .IsUnique();

                    b.ToTable("Product", (string)null);
                });

            modelBuilder.Entity("Company.Parser.Entities.ConfigurationParser", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CompanyDescription")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CompanyName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ComparatorLink")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("ParserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("SiteName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("URL")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("UpdatedBy")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ParserId");

                    b.ToTable("ConfigurationParsers");
                });

            modelBuilder.Entity("Company.Parser.Entities.FieldConfiguration", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ConfigurationId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PropertyName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("StringParse")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("UpdatedBy")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ConfigurationId");

                    b.ToTable("FieldConfigurations");
                });

            modelBuilder.Entity("Company.Parser.Entities.InfoParser", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CompletionTime")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ExceptionMessage")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsCompleted")
                        .HasColumnType("bit");

                    b.Property<bool>("IsQueue")
                        .HasColumnType("bit");

                    b.Property<bool>("IsStart")
                        .HasColumnType("bit");

                    b.Property<bool>("IsStartUpdate")
                        .HasColumnType("bit");

                    b.Property<DateTime>("StartTime")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("UpdatedBy")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("InfoParsers");
                });

            modelBuilder.Entity("Company.Parser.Entities.InfoURL", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ElapsedMilliseconds")
                        .HasColumnType("int");

                    b.Property<string>("ExceptionMessage")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("HasBeenProcessed")
                        .HasColumnType("bit");

                    b.Property<bool>("IsSuccess")
                        .HasColumnType("bit");

                    b.Property<Guid>("ParserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("UpdatedBy")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Url")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ParserId");

                    b.ToTable("URLs");
                });

            modelBuilder.Entity("Company.Entity.ParseValuesProduct", b =>
                {
                    b.HasOne("Company.Parser.Entities.InfoURL", "InfoURL")
                        .WithMany()
                        .HasForeignKey("InfoURLId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("InfoURL");
                });

            modelBuilder.Entity("Company.Entity.Product", b =>
                {
                    b.HasOne("Company.Entity.ParseValuesProduct", "ParseValuesProduct")
                        .WithOne()
                        .HasForeignKey("Company.Entity.Product", "TextProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ParseValuesProduct");
                });

            modelBuilder.Entity("Company.Parser.Entities.ConfigurationParser", b =>
                {
                    b.HasOne("Company.Parser.Entities.InfoParser", "Parser")
                        .WithMany("Configurations")
                        .HasForeignKey("ParserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Parser");
                });

            modelBuilder.Entity("Company.Parser.Entities.FieldConfiguration", b =>
                {
                    b.HasOne("Company.Parser.Entities.ConfigurationParser", "Configuration")
                        .WithMany("Fields")
                        .HasForeignKey("ConfigurationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Configuration");
                });

            modelBuilder.Entity("Company.Parser.Entities.InfoURL", b =>
                {
                    b.HasOne("Company.Parser.Entities.InfoParser", "Parser")
                        .WithMany()
                        .HasForeignKey("ParserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Parser");
                });

            modelBuilder.Entity("Company.Parser.Entities.ConfigurationParser", b =>
                {
                    b.Navigation("Fields");
                });

            modelBuilder.Entity("Company.Parser.Entities.InfoParser", b =>
                {
                    b.Navigation("Configurations");
                });
#pragma warning restore 612, 618
        }
    }
}
