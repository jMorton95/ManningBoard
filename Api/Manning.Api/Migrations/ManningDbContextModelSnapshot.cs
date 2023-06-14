﻿// <auto-generated />
using System;
using Manning.Api.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Manning.Api.Migrations
{
    [DbContext(typeof(ManningDbContext))]
    partial class ManningDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Manning.Api.Models.ClockModel", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("ID"));

                    b.Property<int?>("ClockCardNumber")
                        .IsRequired()
                        .HasColumnType("integer");

                    b.Property<DateTime?>("ClockInTime")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime?>("ClockOutTime")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("OperatorName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.HasKey("ID");

                    b.ToTable("ClockModel", (string)null);
                });

            modelBuilder.Entity("Manning.Api.Models.OpStation", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("ID"));

                    b.Property<string>("StationName")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("character varying(20)");

                    b.Property<int?>("ZoneID")
                        .HasColumnType("integer");

                    b.HasKey("ID");

                    b.HasIndex("ZoneID");

                    b.ToTable("OpStation", (string)null);
                });

            modelBuilder.Entity("Manning.Api.Models.Operator", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("ID"));

                    b.Property<int>("ClockCardNumber")
                        .HasColumnType("integer");

                    b.Property<bool>("IsAdministrator")
                        .HasColumnType("boolean");

                    b.Property<string>("OperatorName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.HasKey("ID");

                    b.ToTable("Operator", (string)null);
                });

            modelBuilder.Entity("Manning.Api.Models.OperatorCompletedTraining", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("ID"));

                    b.Property<int>("OperatorID")
                        .HasColumnType("integer");

                    b.Property<int>("TrainerClockCardNumber")
                        .HasColumnType("integer");

                    b.Property<int>("TrainingRequirementID")
                        .HasColumnType("integer");

                    b.HasKey("ID");

                    b.ToTable("OperatorCompletedTraining", (string)null);
                });

            modelBuilder.Entity("Manning.Api.Models.ShiftType", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("ID"));

                    b.Property<string>("ShiftName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.HasKey("ID");

                    b.ToTable("ShiftType", (string)null);
                });

            modelBuilder.Entity("Manning.Api.Models.TrainingRequirement", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("ID"));

                    b.Property<int>("OpStationID")
                        .HasColumnType("integer");

                    b.Property<string>("RequirementDescription")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)");

                    b.HasKey("ID");

                    b.HasIndex("OpStationID");

                    b.ToTable("TrainingRequirement", (string)null);
                });

            modelBuilder.Entity("Manning.Api.Models.WorkingDayHistory", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("ID"));

                    b.Property<int>("OpStationID")
                        .HasColumnType("integer");

                    b.Property<int>("OperatorID")
                        .HasColumnType("integer");

                    b.Property<DateTime>("ShiftDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("ShiftID")
                        .HasColumnType("integer");

                    b.HasKey("ID");

                    b.HasIndex("OpStationID");

                    b.HasIndex("OperatorID");

                    b.HasIndex("ShiftID");

                    b.ToTable("WorkdayHistory", (string)null);
                });

            modelBuilder.Entity("Manning.Api.Models.Zone", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("ID"));

                    b.Property<string>("ZoneName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.HasKey("ID");

                    b.ToTable("Zone", (string)null);
                });

            modelBuilder.Entity("Manning.Api.Models.OpStation", b =>
                {
                    b.HasOne("Manning.Api.Models.Zone", null)
                        .WithMany("OpStations")
                        .HasForeignKey("ZoneID");
                });

            modelBuilder.Entity("Manning.Api.Models.TrainingRequirement", b =>
                {
                    b.HasOne("Manning.Api.Models.OpStation", null)
                        .WithMany("TrainingRequirements")
                        .HasForeignKey("OpStationID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Manning.Api.Models.WorkingDayHistory", b =>
                {
                    b.HasOne("Manning.Api.Models.OpStation", "OpStation")
                        .WithMany()
                        .HasForeignKey("OpStationID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Manning.Api.Models.Operator", "Operator")
                        .WithMany()
                        .HasForeignKey("OperatorID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Manning.Api.Models.ShiftType", "Shift")
                        .WithMany()
                        .HasForeignKey("ShiftID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("OpStation");

                    b.Navigation("Operator");

                    b.Navigation("Shift");
                });

            modelBuilder.Entity("Manning.Api.Models.OpStation", b =>
                {
                    b.Navigation("TrainingRequirements");
                });

            modelBuilder.Entity("Manning.Api.Models.Zone", b =>
                {
                    b.Navigation("OpStations");
                });
#pragma warning restore 612, 618
        }
    }
}
