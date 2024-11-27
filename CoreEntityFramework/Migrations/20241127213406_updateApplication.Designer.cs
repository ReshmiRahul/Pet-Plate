﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PetAdoption;

#nullable disable

namespace oreEntityFramework.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20241127213406_updateApplication")]
    partial class updateApplication
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("AccountPet", b =>
                {
                    b.Property<int>("AccountsAccountId")
                        .HasColumnType("int");

                    b.Property<int>("PetsPetId")
                        .HasColumnType("int");

                    b.HasKey("AccountsAccountId", "PetsPetId");

                    b.HasIndex("PetsPetId");

                    b.ToTable("AccountPet");
                });

            modelBuilder.Entity("PetAdoption.Models.Account", b =>
                {
                    b.Property<int>("AccountId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AccountId"));

                    b.Property<string>("AccountCity")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("AccountEmail")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("AccountName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("AccountPassword")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("AccountRole")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("AccountState")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("AccountId");

                    b.ToTable("Accounts");
                });

            modelBuilder.Entity("PetAdoption.Models.Application", b =>
                {
                    b.Property<int>("ApplicationID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ApplicationID"));

                    b.Property<int>("AccountId")
                        .HasColumnType("int");

                    b.Property<string>("ApplicationComments")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("ApplicationDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("ApplicationExperience")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ApplicationReason")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ApplicationStatus")
                        .HasColumnType("int");

                    b.Property<int?>("FoodTruckId")
                        .HasColumnType("int");

                    b.Property<int>("PetId")
                        .HasColumnType("int");

                    b.HasKey("ApplicationID");

                    b.HasIndex("AccountId");

                    b.HasIndex("FoodTruckId");

                    b.HasIndex("PetId");

                    b.ToTable("Applications");
                });

            modelBuilder.Entity("PetAdoption.Models.FoodTruck", b =>
                {
                    b.Property<int>("FoodTruckId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("FoodTruckId"));

                    b.Property<string>("Contact")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("LocationId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("FoodTruckId");

                    b.HasIndex("LocationId");

                    b.ToTable("FoodTruck");
                });

            modelBuilder.Entity("PetAdoption.Models.Location", b =>
                {
                    b.Property<int>("LocationId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("LocationId"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("State")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("LocationId");

                    b.ToTable("Location");
                });

            modelBuilder.Entity("PetAdoption.Models.MenuItem", b =>
                {
                    b.Property<int>("MenuItemId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MenuItemId"));

                    b.Property<int>("FoodTruckId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("MenuItemId");

                    b.HasIndex("FoodTruckId");

                    b.ToTable("MenuItem");
                });

            modelBuilder.Entity("PetAdoption.Models.Pet", b =>
                {
                    b.Property<int>("PetId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PetId"));

                    b.Property<int>("PetAge")
                        .HasColumnType("int");

                    b.Property<string>("PetBreed")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PetDescription")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PetName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PetStatus")
                        .HasColumnType("int");

                    b.Property<string>("PetType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("PetId");

                    b.ToTable("Pets");
                });

            modelBuilder.Entity("AccountPet", b =>
                {
                    b.HasOne("PetAdoption.Models.Account", null)
                        .WithMany()
                        .HasForeignKey("AccountsAccountId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PetAdoption.Models.Pet", null)
                        .WithMany()
                        .HasForeignKey("PetsPetId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("PetAdoption.Models.Application", b =>
                {
                    b.HasOne("PetAdoption.Models.Account", "Account")
                        .WithMany("Applications")
                        .HasForeignKey("AccountId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PetAdoption.Models.FoodTruck", "FoodTruck")
                        .WithMany("Applications")
                        .HasForeignKey("FoodTruckId");

                    b.HasOne("PetAdoption.Models.Pet", "Pet")
                        .WithMany("Applications")
                        .HasForeignKey("PetId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Account");

                    b.Navigation("FoodTruck");

                    b.Navigation("Pet");
                });

            modelBuilder.Entity("PetAdoption.Models.FoodTruck", b =>
                {
                    b.HasOne("PetAdoption.Models.Location", "Location")
                        .WithMany("FoodTrucks")
                        .HasForeignKey("LocationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Location");
                });

            modelBuilder.Entity("PetAdoption.Models.MenuItem", b =>
                {
                    b.HasOne("PetAdoption.Models.FoodTruck", "FoodTruck")
                        .WithMany("MenuItems")
                        .HasForeignKey("FoodTruckId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("FoodTruck");
                });

            modelBuilder.Entity("PetAdoption.Models.Account", b =>
                {
                    b.Navigation("Applications");
                });

            modelBuilder.Entity("PetAdoption.Models.FoodTruck", b =>
                {
                    b.Navigation("Applications");

                    b.Navigation("MenuItems");
                });

            modelBuilder.Entity("PetAdoption.Models.Location", b =>
                {
                    b.Navigation("FoodTrucks");
                });

            modelBuilder.Entity("PetAdoption.Models.Pet", b =>
                {
                    b.Navigation("Applications");
                });
#pragma warning restore 612, 618
        }
    }
}
