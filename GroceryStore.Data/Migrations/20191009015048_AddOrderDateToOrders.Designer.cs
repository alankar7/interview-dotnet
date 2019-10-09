﻿// <auto-generated />
using System;
using GroceryStore.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace GroceryStore.Data.Migrations
{
    [DbContext(typeof(GroceryStoreContext))]
    [Migration("20191009015048_AddOrderDateToOrders")]
    partial class AddOrderDateToOrders
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.0.0");

            modelBuilder.Entity("GroceryStore.Data.Customer", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("name")
                        .HasColumnType("TEXT");

                    b.HasKey("id");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("GroceryStore.Data.Item", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int?>("Orderid")
                        .HasColumnType("INTEGER");

                    b.Property<int>("productId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("quantity")
                        .HasColumnType("INTEGER");

                    b.HasKey("id");

                    b.HasIndex("Orderid");

                    b.ToTable("Items");
                });

            modelBuilder.Entity("GroceryStore.Data.Order", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("customerId")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("orderDate")
                        .HasColumnType("TEXT");

                    b.HasKey("id");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("GroceryStore.Data.Product", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("description")
                        .HasColumnType("TEXT");

                    b.Property<double>("price")
                        .HasColumnType("REAL");

                    b.HasKey("id");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("GroceryStore.Data.Item", b =>
                {
                    b.HasOne("GroceryStore.Data.Order", null)
                        .WithMany("items")
                        .HasForeignKey("Orderid");
                });
#pragma warning restore 612, 618
        }
    }
}
