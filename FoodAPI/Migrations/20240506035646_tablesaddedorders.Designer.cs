﻿// <auto-generated />
using System;
using FoodAPI.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace FoodAPI.Migrations
{
    [DbContext(typeof(ApiDbContext))]
    [Migration("20240506035646_tablesaddedorders")]
    partial class tablesaddedorders
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("FoodAPI.Models.Dish", b =>
                {
                    b.Property<int>("dishId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("dishId"));

                    b.Property<int>("ResturantID")
                        .HasColumnType("int");

                    b.Property<string>("imageUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("orderId")
                        .HasColumnType("int");

                    b.Property<float>("price")
                        .HasColumnType("real");

                    b.Property<int>("quantity")
                        .HasColumnType("int");

                    b.HasKey("dishId");

                    b.HasIndex("ResturantID");

                    b.HasIndex("orderId");

                    b.ToTable("dishes");

                    b.HasData(
                        new
                        {
                            dishId = 1,
                            ResturantID = 1,
                            imageUrl = "image url goes here",
                            name = "Butter chicken",
                            price = 6f,
                            quantity = 0
                        },
                        new
                        {
                            dishId = 2,
                            ResturantID = 2,
                            imageUrl = "image url goes here",
                            name = "Fried Chicken",
                            price = 8f,
                            quantity = 0
                        });
                });

            modelBuilder.Entity("FoodAPI.Models.Order", b =>
                {
                    b.Property<int>("orderId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("orderId"));

                    b.Property<int>("UserID")
                        .HasColumnType("int");

                    b.Property<DateTime>("dateTime")
                        .HasColumnType("datetime2");

                    b.Property<bool>("isDone")
                        .HasColumnType("bit");

                    b.Property<bool>("isProcessed")
                        .HasColumnType("bit");

                    b.Property<float>("totalPrice")
                        .HasColumnType("real");

                    b.HasKey("orderId");

                    b.HasIndex("UserID");

                    b.ToTable("orders");
                });

            modelBuilder.Entity("FoodAPI.Models.Resturant", b =>
                {
                    b.Property<int>("resturantId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("resturantId"));

                    b.Property<string>("address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("averageReview")
                        .HasColumnType("int");

                    b.Property<string>("category")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("imageUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("phone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("postcode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("resturantName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("resturantId");

                    b.ToTable("resturants");

                    b.HasData(
                        new
                        {
                            resturantId = 1,
                            address = "Berry, NSW",
                            averageReview = 3,
                            category = "Indian",
                            imageUrl = "image goes here",
                            phone = "08615151",
                            postcode = "2541",
                            resturantName = "Indika"
                        },
                        new
                        {
                            resturantId = 2,
                            address = "Wollongong, NSW",
                            averageReview = 3,
                            category = "American",
                            imageUrl = "image goes here",
                            phone = "04156171",
                            postcode = "2541",
                            resturantName = "KFC"
                        });
                });

            modelBuilder.Entity("FoodAPI.Models.Review", b =>
                {
                    b.Property<int>("reviewId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("reviewId"));

                    b.Property<int>("ResturantID")
                        .HasColumnType("int");

                    b.Property<int>("UserID")
                        .HasColumnType("int");

                    b.Property<string>("reviewContent")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("star")
                        .HasColumnType("int");

                    b.HasKey("reviewId");

                    b.HasIndex("ResturantID");

                    b.HasIndex("UserID");

                    b.ToTable("reviews");

                    b.HasData(
                        new
                        {
                            reviewId = 1,
                            ResturantID = 1,
                            UserID = 1,
                            reviewContent = "very good",
                            star = 5
                        },
                        new
                        {
                            reviewId = 2,
                            ResturantID = 2,
                            UserID = 2,
                            reviewContent = "good",
                            star = 3
                        });
                });

            modelBuilder.Entity("FoodAPI.Models.User", b =>
                {
                    b.Property<int>("userID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("userID"));

                    b.Property<string>("address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<float>("balance")
                        .HasColumnType("real");

                    b.Property<string>("cardNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("hasSubscription")
                        .HasColumnType("bit");

                    b.Property<string>("password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("phoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("postcode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("role")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("subscreatedat")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("subscriptionExpirationDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("username")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("userID");

                    b.ToTable("users");

                    b.HasData(
                        new
                        {
                            userID = 1,
                            address = "Wollongong",
                            balance = 50f,
                            cardNumber = "1235333",
                            email = "trung@gmil.com",
                            hasSubscription = false,
                            password = "trung@123",
                            phoneNumber = "62662622",
                            postcode = "2500",
                            role = "User",
                            subscreatedat = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            subscriptionExpirationDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            username = "Trung doan"
                        },
                        new
                        {
                            userID = 2,
                            address = "Wollongong",
                            balance = 50f,
                            cardNumber = "1555333",
                            email = "spk@gmil.com",
                            hasSubscription = false,
                            password = "spk@123",
                            phoneNumber = "071116616",
                            postcode = "2500",
                            role = "User",
                            subscreatedat = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            subscriptionExpirationDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            username = "Sudarshan Khadka"
                        });
                });

            modelBuilder.Entity("FoodAPI.Models.Dish", b =>
                {
                    b.HasOne("FoodAPI.Models.Resturant", null)
                        .WithMany("dishes")
                        .HasForeignKey("ResturantID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FoodAPI.Models.Order", null)
                        .WithMany("Dishes")
                        .HasForeignKey("orderId");
                });

            modelBuilder.Entity("FoodAPI.Models.Order", b =>
                {
                    b.HasOne("FoodAPI.Models.User", null)
                        .WithMany("Orders")
                        .HasForeignKey("UserID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("FoodAPI.Models.Review", b =>
                {
                    b.HasOne("FoodAPI.Models.Resturant", null)
                        .WithMany("reviews")
                        .HasForeignKey("ResturantID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FoodAPI.Models.User", null)
                        .WithMany("Reviews")
                        .HasForeignKey("UserID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("FoodAPI.Models.Order", b =>
                {
                    b.Navigation("Dishes");
                });

            modelBuilder.Entity("FoodAPI.Models.Resturant", b =>
                {
                    b.Navigation("dishes");

                    b.Navigation("reviews");
                });

            modelBuilder.Entity("FoodAPI.Models.User", b =>
                {
                    b.Navigation("Orders");

                    b.Navigation("Reviews");
                });
#pragma warning restore 612, 618
        }
    }
}