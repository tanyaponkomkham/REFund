﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using REFund.Data;

namespace REFund.Migrations
{
    [DbContext(typeof(CoreContext))]
    [Migration("20240110024522_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.17")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("REFund.Models.Attachment", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Content")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ContentMimeType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ContentName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Created")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("RequestId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("ID");

                    b.HasIndex("RequestId");

                    b.ToTable("Attachment");
                });

            modelBuilder.Entity("REFund.Models.Category", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CategoryName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Status")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Category");
                });

            modelBuilder.Entity("REFund.Models.Communication", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<string>("Detail")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("EmployeeId")
                        .HasColumnType("int");

                    b.Property<Guid?>("RequestId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("ID");

                    b.HasIndex("RequestId");

                    b.ToTable("Communication");
                });

            modelBuilder.Entity("REFund.Models.Document", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("CategoryID")
                        .HasColumnType("int");

                    b.Property<string>("DocumentName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("WhomID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("CategoryID");

                    b.HasIndex("WhomID");

                    b.ToTable("Document");
                });

            modelBuilder.Entity("REFund.Models.History", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Amount")
                        .HasColumnType("int");

                    b.Property<int?>("CategoryID")
                        .HasColumnType("int");

                    b.Property<DateTime>("ConfirmDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("CreateAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreateBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Detail")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("EmployeeId")
                        .HasColumnType("int");

                    b.Property<DateTime>("UpdateAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("UpdateBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("WorkflowID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("CategoryID");

                    b.HasIndex("WorkflowID");

                    b.ToTable("History");
                });

            modelBuilder.Entity("REFund.Models.Request", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Amount")
                        .HasColumnType("int");

                    b.Property<int?>("CategoryID")
                        .HasColumnType("int");

                    b.Property<DateTime>("ConfirmDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("CreateAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreateBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Detail")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("EmployeeId")
                        .HasMaxLength(7)
                        .HasColumnType("int");

                    b.Property<DateTime>("UpdateAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("UpdateBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("WorkflowID")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CategoryID");

                    b.HasIndex("WorkflowID");

                    b.ToTable("Request");
                });

            modelBuilder.Entity("REFund.Models.Status", b =>
                {
                    b.Property<int>("ID")
                        .HasColumnType("int");

                    b.Property<string>("Color")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("StatusName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Status");
                });

            modelBuilder.Entity("REFund.Models.SubCategory", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Amount")
                        .HasColumnType("int");

                    b.Property<int?>("CategoryID")
                        .HasColumnType("int");

                    b.Property<int>("Level")
                        .HasColumnType("int");

                    b.Property<string>("Year")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.HasIndex("CategoryID");

                    b.ToTable("SubCategory");
                });

            modelBuilder.Entity("REFund.Models.Whom", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Status")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("WhomName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Whom");
                });

            modelBuilder.Entity("REFund.Models.Workflow", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ActionEmail")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Approve")
                        .HasColumnType("int");

                    b.Property<int>("Disapprove")
                        .HasColumnType("int");

                    b.Property<int?>("StatusID")
                        .HasColumnType("int");

                    b.Property<int>("Step")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("StatusID");

                    b.ToTable("Workflow");
                });

            modelBuilder.Entity("REFund.Models.Attachment", b =>
                {
                    b.HasOne("REFund.Models.Request", "Request")
                        .WithMany("Attachments")
                        .HasForeignKey("RequestId");

                    b.Navigation("Request");
                });

            modelBuilder.Entity("REFund.Models.Communication", b =>
                {
                    b.HasOne("REFund.Models.Request", "Request")
                        .WithMany("Communications")
                        .HasForeignKey("RequestId");

                    b.Navigation("Request");
                });

            modelBuilder.Entity("REFund.Models.Document", b =>
                {
                    b.HasOne("REFund.Models.Category", "Category")
                        .WithMany("Documents")
                        .HasForeignKey("CategoryID");

                    b.HasOne("REFund.Models.Whom", "Whom")
                        .WithMany("Documents")
                        .HasForeignKey("WhomID");

                    b.Navigation("Category");

                    b.Navigation("Whom");
                });

            modelBuilder.Entity("REFund.Models.History", b =>
                {
                    b.HasOne("REFund.Models.Category", "Category")
                        .WithMany("Historys")
                        .HasForeignKey("CategoryID");

                    b.HasOne("REFund.Models.Workflow", "Workflow")
                        .WithMany("Historys")
                        .HasForeignKey("WorkflowID");

                    b.Navigation("Category");

                    b.Navigation("Workflow");
                });

            modelBuilder.Entity("REFund.Models.Request", b =>
                {
                    b.HasOne("REFund.Models.Category", "Category")
                        .WithMany("Requests")
                        .HasForeignKey("CategoryID");

                    b.HasOne("REFund.Models.Workflow", "Workflow")
                        .WithMany("Requests")
                        .HasForeignKey("WorkflowID");

                    b.Navigation("Category");

                    b.Navigation("Workflow");
                });

            modelBuilder.Entity("REFund.Models.SubCategory", b =>
                {
                    b.HasOne("REFund.Models.Category", "Category")
                        .WithMany("SubCategorys")
                        .HasForeignKey("CategoryID");

                    b.Navigation("Category");
                });

            modelBuilder.Entity("REFund.Models.Workflow", b =>
                {
                    b.HasOne("REFund.Models.Status", "Status")
                        .WithMany("Workflows")
                        .HasForeignKey("StatusID");

                    b.Navigation("Status");
                });

            modelBuilder.Entity("REFund.Models.Category", b =>
                {
                    b.Navigation("Documents");

                    b.Navigation("Historys");

                    b.Navigation("Requests");

                    b.Navigation("SubCategorys");
                });

            modelBuilder.Entity("REFund.Models.Request", b =>
                {
                    b.Navigation("Attachments");

                    b.Navigation("Communications");
                });

            modelBuilder.Entity("REFund.Models.Status", b =>
                {
                    b.Navigation("Workflows");
                });

            modelBuilder.Entity("REFund.Models.Whom", b =>
                {
                    b.Navigation("Documents");
                });

            modelBuilder.Entity("REFund.Models.Workflow", b =>
                {
                    b.Navigation("Historys");

                    b.Navigation("Requests");
                });
#pragma warning restore 612, 618
        }
    }
}
