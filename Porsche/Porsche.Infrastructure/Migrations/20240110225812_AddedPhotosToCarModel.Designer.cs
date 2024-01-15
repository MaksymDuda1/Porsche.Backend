﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using Porsche.Infrastructure;

#nullable disable

namespace Porsche.Infrastructure.Migrations
{
    [DbContext(typeof(PorscheDbContext))]
    [Migration("20240110225812_AddedPhotosToCarModel")]
    partial class AddedPhotosToCarModel
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Porsche.Domain.Models.Car", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("BodyType")
                        .HasColumnType("integer");

                    b.Property<string>("Engine")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("IdentityCode")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Model")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int?>("PorscheCenterId")
                        .HasColumnType("integer");

                    b.Property<int>("YearOfEdition")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("PorscheCenterId");

                    b.ToTable("Car");
                });

            modelBuilder.Entity("Porsche.Domain.Models.Photo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int?>("CarEntityId")
                        .HasColumnType("integer");

                    b.Property<int>("CarId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("CarEntityId");

                    b.HasIndex("CarId");

                    b.ToTable("Photos");
                });

            modelBuilder.Entity("Porsche.Domain.Models.PorscheCenter", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("PorscheCenter");
                });

            modelBuilder.Entity("Porsche.Infrastructure.Entities.CarEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("BodyType")
                        .HasColumnType("integer");

                    b.Property<string>("Engine")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("IdentityCode")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Model")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int?>("PorscheCenterId")
                        .HasColumnType("integer");

                    b.Property<int>("YearOfEdition")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("PorscheCenterId");

                    b.ToTable("Cars");
                });

            modelBuilder.Entity("Porsche.Infrastructure.Entities.PorscheCenterEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("PorscheCenters");
                });

            modelBuilder.Entity("Porsche.Infrastructure.Entities.UserEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("Role")
                        .HasColumnType("integer");

                    b.Property<string>("SecondName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Porsche.Domain.Models.Car", b =>
                {
                    b.HasOne("Porsche.Domain.Models.PorscheCenter", "PorscheCenter")
                        .WithMany("Cars")
                        .HasForeignKey("PorscheCenterId");

                    b.Navigation("PorscheCenter");
                });

            modelBuilder.Entity("Porsche.Domain.Models.Photo", b =>
                {
                    b.HasOne("Porsche.Infrastructure.Entities.CarEntity", null)
                        .WithMany("Photos")
                        .HasForeignKey("CarEntityId");

                    b.HasOne("Porsche.Domain.Models.Car", "Car")
                        .WithMany("Photos")
                        .HasForeignKey("CarId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Car");
                });

            modelBuilder.Entity("Porsche.Infrastructure.Entities.CarEntity", b =>
                {
                    b.HasOne("Porsche.Domain.Models.PorscheCenter", "PorscheCenter")
                        .WithMany()
                        .HasForeignKey("PorscheCenterId");

                    b.Navigation("PorscheCenter");
                });

            modelBuilder.Entity("Porsche.Domain.Models.Car", b =>
                {
                    b.Navigation("Photos");
                });

            modelBuilder.Entity("Porsche.Domain.Models.PorscheCenter", b =>
                {
                    b.Navigation("Cars");
                });

            modelBuilder.Entity("Porsche.Infrastructure.Entities.CarEntity", b =>
                {
                    b.Navigation("Photos");
                });
#pragma warning restore 612, 618
        }
    }
}
