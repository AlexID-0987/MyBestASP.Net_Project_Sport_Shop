﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MysportShop.Models;

namespace MysportShop.Migrations
{
    [DbContext(typeof(ProductDbContext))]
    [Migration("20231031202953_My class Ses5547799")]
    partial class MyclassSes5547799
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.14-servicing-32113")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("MysportShop.Models.MyOrder", b =>
                {
                    b.Property<int>("MyOrderId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<string>("Phone")
                        .IsRequired();

                    b.HasKey("MyOrderId");

                    b.ToTable("myOrders");
                });

            modelBuilder.Entity("MysportShop.Models.MyProduct", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Categories");

                    b.Property<string>("Discriminator")
                        .IsRequired();

                    b.Property<string>("InfoWithProduct");

                    b.Property<string>("NameProduct");

                    b.Property<decimal>("Price");

                    b.HasKey("Id");

                    b.ToTable("Products");

                    b.HasDiscriminator<string>("Discriminator").HasValue("MyProduct");
                });

            modelBuilder.Entity("MysportShop.Models.BuyProduct", b =>
                {
                    b.HasBaseType("MysportShop.Models.MyProduct");

                    b.Property<int?>("MyOrderId");

                    b.Property<int?>("MyProductId");

                    b.Property<int>("Quantity");

                    b.Property<decimal>("SummaOnsetProduct");

                    b.HasIndex("MyOrderId");

                    b.HasIndex("MyProductId");

                    b.ToTable("BuyProduct");

                    b.HasDiscriminator().HasValue("BuyProduct");
                });

            modelBuilder.Entity("MysportShop.Models.BuyProduct", b =>
                {
                    b.HasOne("MysportShop.Models.MyOrder")
                        .WithMany("Buys")
                        .HasForeignKey("MyOrderId");

                    b.HasOne("MysportShop.Models.MyProduct", "MyProduct")
                        .WithMany()
                        .HasForeignKey("MyProductId");
                });
#pragma warning restore 612, 618
        }
    }
}
