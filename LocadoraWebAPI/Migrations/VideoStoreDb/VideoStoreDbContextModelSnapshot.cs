﻿// <auto-generated />
using System;
using LocadoraWebAPI.Domain.VideoStoreContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace LocadoraWebAPI.Migrations.VideoStoreDb
{
    [DbContext(typeof(VideoStoreDbContext))]
    partial class VideoStoreDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.17")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("LocadoraWebAPI.Domain.Category", b =>
                {
                    b.Property<int>("CategoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Status")
                        .HasColumnType("bit");

                    b.HasKey("CategoryId");

                    b.ToTable("MovieCategory");
                });

            modelBuilder.Entity("LocadoraWebAPI.Domain.DashboardMovie", b =>
                {
                    b.Property<int>("DashBoardMoviesId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("StockMoviesCount")
                        .HasColumnType("int");

                    b.HasKey("DashBoardMoviesId");

                    b.ToTable("DashboardMovie");
                });

            modelBuilder.Entity("LocadoraWebAPI.Domain.VideoStoreItens", b =>
                {
                    b.Property<int>("VideoStoreID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<int?>("DashBoardMoviesId")
                        .HasColumnType("int");

                    b.Property<int>("NumberRegister")
                        .HasColumnType("int");

                    b.Property<int>("QuantityStock")
                        .HasColumnType("int");

                    b.HasKey("VideoStoreID");

                    b.HasIndex("CategoryId")
                        .IsUnique();

                    b.HasIndex("DashBoardMoviesId");

                    b.ToTable("VideoStoreItens");
                });

            modelBuilder.Entity("LocadoraWebAPI.Domain.VideoStoreItens", b =>
                {
                    b.HasOne("LocadoraWebAPI.Domain.Category", "CategoryID")
                        .WithOne("VideoStoreItens")
                        .HasForeignKey("LocadoraWebAPI.Domain.VideoStoreItens", "CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("LocadoraWebAPI.Domain.DashboardMovie", null)
                        .WithMany("VideoStoreId")
                        .HasForeignKey("DashBoardMoviesId");

                    b.Navigation("CategoryID");
                });

            modelBuilder.Entity("LocadoraWebAPI.Domain.Category", b =>
                {
                    b.Navigation("VideoStoreItens");
                });

            modelBuilder.Entity("LocadoraWebAPI.Domain.DashboardMovie", b =>
                {
                    b.Navigation("VideoStoreId");
                });
#pragma warning restore 612, 618
        }
    }
}
