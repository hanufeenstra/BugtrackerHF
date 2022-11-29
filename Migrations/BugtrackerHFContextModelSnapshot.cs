﻿// <auto-generated />
using System;
using BugtrackerHF.DAL.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BugtrackerHF.Migrations
{
    [DbContext(typeof(BugtrackerHFContext))]
    partial class BugtrackerHFContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("BugtrackerHF.Models.AdminViewModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("AuthZeroId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("ParentId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("AdminViewModel");
                });

            modelBuilder.Entity("BugtrackerHF.Models.IssueViewModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("AssignedToUserId")
                        .HasColumnType("int");

                    b.Property<int>("CurrentSeverity")
                        .HasColumnType("int");

                    b.Property<int>("CurrentStatus")
                        .HasColumnType("int");

                    b.Property<DateTime>("LastUpdateDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("IssueViewModel");
                });

            modelBuilder.Entity("BugtrackerHF.Models.MessageViewModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<bool>("Viewed")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.ToTable("MessageViewModel");
                });

            modelBuilder.Entity("BugtrackerHF.Models.NotificationViewModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.HasKey("Id");

                    b.ToTable("NotificationViewModels");
                });

            modelBuilder.Entity("BugtrackerHF.Models.ProjectViewModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int?>("ProjectAdminId")
                        .HasColumnType("int");

                    b.Property<string>("ProjectName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ProjectAdminId");

                    b.ToTable("ProjectViewModel");
                });

            modelBuilder.Entity("BugtrackerHF.Models.UserViewModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int?>("AdminViewModelId")
                        .HasColumnType("int");

                    b.Property<string>("AuthZeroId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserEmail")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserNickname")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserRole")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AdminViewModelId");

                    b.ToTable("UserViewModel");
                });

            modelBuilder.Entity("BugtrackerHF.Models.ProjectViewModel", b =>
                {
                    b.HasOne("BugtrackerHF.Models.AdminViewModel", "ProjectAdmin")
                        .WithMany()
                        .HasForeignKey("ProjectAdminId");

                    b.Navigation("ProjectAdmin");
                });

            modelBuilder.Entity("BugtrackerHF.Models.UserViewModel", b =>
                {
                    b.HasOne("BugtrackerHF.Models.AdminViewModel", null)
                        .WithMany("Users")
                        .HasForeignKey("AdminViewModelId");
                });

            modelBuilder.Entity("BugtrackerHF.Models.AdminViewModel", b =>
                {
                    b.Navigation("Users");
                });
#pragma warning restore 612, 618
        }
    }
}
