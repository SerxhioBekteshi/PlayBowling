﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Repository;

#nullable disable

namespace Repository.Migrations
{
    [DbContext(typeof(RepositoryContext))]
    [Migration("20250322225641_inDB")]
    partial class inDB
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Entities.Models.Frame", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("FrameNumber")
                        .HasColumnType("int");

                    b.Property<int>("MaxThrows")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Frames");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "Description",
                            FrameNumber = 1,
                            MaxThrows = 2
                        },
                        new
                        {
                            Id = 2,
                            Description = "Description 2",
                            FrameNumber = 2,
                            MaxThrows = 2
                        },
                        new
                        {
                            Id = 3,
                            Description = "Description 3",
                            FrameNumber = 3,
                            MaxThrows = 2
                        },
                        new
                        {
                            Id = 4,
                            Description = "Description 4",
                            FrameNumber = 4,
                            MaxThrows = 2
                        },
                        new
                        {
                            Id = 5,
                            Description = "Description 5",
                            FrameNumber = 5,
                            MaxThrows = 2
                        },
                        new
                        {
                            Id = 6,
                            Description = "Description 6",
                            FrameNumber = 6,
                            MaxThrows = 2
                        },
                        new
                        {
                            Id = 7,
                            Description = "Description 7",
                            FrameNumber = 7,
                            MaxThrows = 2
                        },
                        new
                        {
                            Id = 8,
                            Description = "Description 8",
                            FrameNumber = 8,
                            MaxThrows = 2
                        },
                        new
                        {
                            Id = 9,
                            Description = "Description 9",
                            FrameNumber = 9,
                            MaxThrows = 2
                        },
                        new
                        {
                            Id = 10,
                            Description = "Description 10",
                            FrameNumber = 10,
                            MaxThrows = 3
                        });
                });

            modelBuilder.Entity("Entities.Models.Game", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime?>("EndTime")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsCompleted")
                        .HasColumnType("bit");

                    b.Property<int>("PlayerId")
                        .HasColumnType("int");

                    b.Property<DateTime>("StartTime")
                        .HasColumnType("datetime2");

                    b.Property<int>("TotalScore")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PlayerId");

                    b.ToTable("Games");
                });

            modelBuilder.Entity("Entities.Models.GameFrame", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("FirstThrow")
                        .HasColumnType("int");

                    b.Property<int>("FrameId")
                        .HasColumnType("int");

                    b.Property<int>("GameId")
                        .HasColumnType("int");

                    b.Property<int?>("SecondThrow")
                        .HasColumnType("int");

                    b.Property<int?>("ThirdThrow")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("FrameId");

                    b.HasIndex("GameId");

                    b.ToTable("GameFrames");
                });

            modelBuilder.Entity("Entities.Models.Player", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("RegisteredDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Players");
                });

            modelBuilder.Entity("Entities.Models.Game", b =>
                {
                    b.HasOne("Entities.Models.Player", "Player")
                        .WithMany("Games")
                        .HasForeignKey("PlayerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Player");
                });

            modelBuilder.Entity("Entities.Models.GameFrame", b =>
                {
                    b.HasOne("Entities.Models.Frame", "Frame")
                        .WithMany("GameFrames")
                        .HasForeignKey("FrameId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Entities.Models.Game", "Game")
                        .WithMany("GameFrames")
                        .HasForeignKey("GameId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Frame");

                    b.Navigation("Game");
                });

            modelBuilder.Entity("Entities.Models.Frame", b =>
                {
                    b.Navigation("GameFrames");
                });

            modelBuilder.Entity("Entities.Models.Game", b =>
                {
                    b.Navigation("GameFrames");
                });

            modelBuilder.Entity("Entities.Models.Player", b =>
                {
                    b.Navigation("Games");
                });
#pragma warning restore 612, 618
        }
    }
}
