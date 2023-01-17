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

            modelBuilder.Entity("BugtrackerHF.Models.IssueModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("CurrentSeverity")
                        .HasColumnType("int");

                    b.Property<int>("CurrentStatus")
                        .HasColumnType("int");

                    b.Property<string>("IssueName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("LastUpdateDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("ReportedByUserId")
                        .HasColumnType("int");

                    b.Property<int?>("UserModelId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserModelId");

                    b.ToTable("IssueModel");
                });

            modelBuilder.Entity("BugtrackerHF.Models.MessageModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("CreatedByUserId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedTime")
                        .HasColumnType("datetime2");

                    b.Property<int?>("IssueModelId")
                        .HasColumnType("int");

                    b.Property<string>("Message")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("IssueModelId");

                    b.ToTable("MessageModel");
                });

            modelBuilder.Entity("BugtrackerHF.Models.ProjectModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("ProjectManagerId")
                        .HasColumnType("int");

                    b.Property<string>("ProjectName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ProjectManagerId");

                    b.ToTable("ProjectModel");
                });

            modelBuilder.Entity("BugtrackerHF.Models.UserModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("AuthZeroId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("ProjectModelId")
                        .HasColumnType("int");

                    b.Property<string>("UserEmail")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("UserModelId")
                        .HasColumnType("int");

                    b.Property<string>("UserNickname")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserPicture")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserRole")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ProjectModelId");

                    b.HasIndex("UserModelId");

                    b.ToTable("UserModel");
                });

            modelBuilder.Entity("BugtrackerHF.Models.IssueModel", b =>
                {
                    b.HasOne("BugtrackerHF.Models.UserModel", null)
                        .WithMany("IssueList")
                        .HasForeignKey("UserModelId");
                });

            modelBuilder.Entity("BugtrackerHF.Models.MessageModel", b =>
                {
                    b.HasOne("BugtrackerHF.Models.IssueModel", null)
                        .WithMany("MessageList")
                        .HasForeignKey("IssueModelId");
                });

            modelBuilder.Entity("BugtrackerHF.Models.ProjectModel", b =>
                {
                    b.HasOne("BugtrackerHF.Models.UserModel", "ProjectManager")
                        .WithMany()
                        .HasForeignKey("ProjectManagerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ProjectManager");
                });

            modelBuilder.Entity("BugtrackerHF.Models.UserModel", b =>
                {
                    b.HasOne("BugtrackerHF.Models.ProjectModel", null)
                        .WithMany("UserList")
                        .HasForeignKey("ProjectModelId");

                    b.HasOne("BugtrackerHF.Models.UserModel", null)
                        .WithMany("SubUserList")
                        .HasForeignKey("UserModelId");
                });

            modelBuilder.Entity("BugtrackerHF.Models.IssueModel", b =>
                {
                    b.Navigation("MessageList");
                });

            modelBuilder.Entity("BugtrackerHF.Models.ProjectModel", b =>
                {
                    b.Navigation("UserList");
                });

            modelBuilder.Entity("BugtrackerHF.Models.UserModel", b =>
                {
                    b.Navigation("IssueList");

                    b.Navigation("SubUserList");
                });
#pragma warning restore 612, 618
        }
    }
}
