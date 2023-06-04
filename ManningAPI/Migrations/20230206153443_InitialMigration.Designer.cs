﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ManningApi.Repositories;

#nullable disable

namespace ManningApi.Migrations
{
    [DbContext(typeof(ManningDbContext))]
    [Migration("20230206153443_InitialMigration")]
    partial class InitialMigration
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ManningApi.Models.OpStation", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<string>("StationName")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<int?>("ZoneID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("ZoneID");

                    b.ToTable("OpStation");
                });

            modelBuilder.Entity("ManningApi.Models.Operator", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<int>("ClockCardNumber")
                        .HasColumnType("int");

                    b.Property<string>("OperatorName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("ID");

                    b.ToTable("Operator");
                });

            modelBuilder.Entity("ManningApi.Models.OperatorCompletedTraining", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<int?>("OperatorID")
                        .HasColumnType("int");

                    b.Property<int>("TrainerClockCardNumber")
                        .HasColumnType("int");

                    b.Property<int?>("TrainingRequirementID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("OperatorID");

                    b.HasIndex("TrainingRequirementID");

                    b.ToTable("OperatorCompletedTraining");
                });

            modelBuilder.Entity("ManningApi.Models.ShiftType", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<string>("ShiftName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("ID");

                    b.ToTable("ShiftType");
                });

            modelBuilder.Entity("ManningApi.Models.TrainingRequirement", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<int>("OpStationID")
                        .HasColumnType("int");

                    b.Property<string>("RequirementDescription")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<int?>("TypeID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("OpStationID");

                    b.HasIndex("TypeID");

                    b.ToTable("TrainingRequirement");
                });

            modelBuilder.Entity("ManningApi.Models.TrainingRequirementType", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<string>("TrainingType")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("ID");

                    b.ToTable("TrainingRequirementsType");
                });

            modelBuilder.Entity("ManningApi.Models.WorkingDayHistory", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<int?>("OpStationID")
                        .HasColumnType("int");

                    b.Property<int?>("OperatorID")
                        .HasColumnType("int");

                    b.Property<DateTime>("ShiftDate")
                        .HasColumnType("DateTime2");

                    b.Property<int?>("ShiftID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("OpStationID");

                    b.HasIndex("OperatorID");

                    b.HasIndex("ShiftID");

                    b.ToTable("WorkdayHistory");
                });

            modelBuilder.Entity("ManningApi.Models.Zone", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<string>("ZoneName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("ID");

                    b.ToTable("Zone");
                });

            modelBuilder.Entity("ManningApi.Models.OpStation", b =>
                {
                    b.HasOne("ManningApi.Models.Zone", null)
                        .WithMany("OpStations")
                        .HasForeignKey("ZoneID");
                });

            modelBuilder.Entity("ManningApi.Models.OperatorCompletedTraining", b =>
                {
                    b.HasOne("ManningApi.Models.Operator", "Operator")
                        .WithMany()
                        .HasForeignKey("OperatorID");

                    b.HasOne("ManningApi.Models.TrainingRequirement", "TrainingRequirement")
                        .WithMany()
                        .HasForeignKey("TrainingRequirementID");

                    b.Navigation("Operator");

                    b.Navigation("TrainingRequirement");
                });

            modelBuilder.Entity("ManningApi.Models.TrainingRequirement", b =>
                {
                    b.HasOne("ManningApi.Models.OpStation", "OpStation")
                        .WithMany("TrainingRequirements")
                        .HasForeignKey("OpStationID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ManningApi.Models.TrainingRequirementType", "Type")
                        .WithMany()
                        .HasForeignKey("TypeID");

                    b.Navigation("OpStation");

                    b.Navigation("Type");
                });

            modelBuilder.Entity("ManningApi.Models.WorkingDayHistory", b =>
                {
                    b.HasOne("ManningApi.Models.OpStation", "OpStation")
                        .WithMany()
                        .HasForeignKey("OpStationID");

                    b.HasOne("ManningApi.Models.Operator", "Operator")
                        .WithMany()
                        .HasForeignKey("OperatorID");

                    b.HasOne("ManningApi.Models.ShiftType", "Shift")
                        .WithMany()
                        .HasForeignKey("ShiftID");

                    b.Navigation("OpStation");

                    b.Navigation("Operator");

                    b.Navigation("Shift");
                });

            modelBuilder.Entity("ManningApi.Models.OpStation", b =>
                {
                    b.Navigation("TrainingRequirements");
                });

            modelBuilder.Entity("ManningApi.Models.Zone", b =>
                {
                    b.Navigation("OpStations");
                });
#pragma warning restore 612, 618
        }
    }
}
