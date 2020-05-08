﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ReconciliationApp.EntityFrameworkCore;

namespace ReconciliationApp.EntityFrameworkCore.Migrations
{
    [DbContext(typeof(ReconciliationDbContext))]
    [Migration("20200508141329_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ReconciliationApp.EntityFrameworkCore.IncomeOrExpenseTypes.IncomeOrExpenseType", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("CreationTime")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DeletionTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("DeviceInfo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DisplayName")
                        .HasColumnType("nvarchar(128)")
                        .HasMaxLength(128);

                    b.Property<int>("Flag")
                        .HasColumnType("int");

                    b.Property<string>("IncomeOrExpenseTypeId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("IpAddress")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<bool>("IsSystem")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("ModificationTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("SystemName")
                        .HasColumnType("nvarchar(128)")
                        .HasMaxLength(128);

                    b.HasKey("Id");

                    b.HasIndex("IncomeOrExpenseTypeId");

                    b.ToTable("IncomeOrExpenseTypes");
                });

            modelBuilder.Entity("ReconciliationApp.EntityFrameworkCore.IncomeOrExpenses.IncomeOrExpense", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<decimal>("Amount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime>("CreationTime")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DeletionTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("DeviceInfo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("IncomeOrExpenseTypeId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("IpAddress")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("ModificationTime")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("IncomeOrExpenseTypeId");

                    b.ToTable("IncomeOrExpenses");
                });

            modelBuilder.Entity("ReconciliationApp.EntityFrameworkCore.Reconciliations.Reconciliation", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<decimal>("Amount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime>("CreationTime")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DeletionTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("DeviceInfo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("IncomeOrExpenseTypeId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("IpAddress")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("ModificationTime")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("IncomeOrExpenseTypeId");

                    b.ToTable("Reconciliations");
                });

            modelBuilder.Entity("ReconciliationApp.EntityFrameworkCore.IncomeOrExpenseTypes.IncomeOrExpenseType", b =>
                {
                    b.HasOne("ReconciliationApp.EntityFrameworkCore.IncomeOrExpenseTypes.IncomeOrExpenseType", null)
                        .WithMany("IncomeOrExpenseTypes")
                        .HasForeignKey("IncomeOrExpenseTypeId");
                });

            modelBuilder.Entity("ReconciliationApp.EntityFrameworkCore.IncomeOrExpenses.IncomeOrExpense", b =>
                {
                    b.HasOne("ReconciliationApp.EntityFrameworkCore.IncomeOrExpenseTypes.IncomeOrExpenseType", "IncomeOrExpenseType")
                        .WithMany()
                        .HasForeignKey("IncomeOrExpenseTypeId");
                });

            modelBuilder.Entity("ReconciliationApp.EntityFrameworkCore.Reconciliations.Reconciliation", b =>
                {
                    b.HasOne("ReconciliationApp.EntityFrameworkCore.IncomeOrExpenseTypes.IncomeOrExpenseType", "IncomeOrExpenseType")
                        .WithMany("Reconciliations")
                        .HasForeignKey("IncomeOrExpenseTypeId");
                });
#pragma warning restore 612, 618
        }
    }
}