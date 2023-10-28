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
    [Migration("20231022170808_My9")]
    partial class My9
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

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

            modelBuilder.Entity("MysportShop.Models.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<string>("Phone")
                        .IsRequired();

                    b.HasKey("Id");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("MysportShop.Models.BuyProduct", b =>
                {
                    b.HasBaseType("MysportShop.Models.MyProduct");

                    b.Property<int?>("OrderId");

                    b.Property<int>("Quantity");

                    b.Property<decimal>("SummaOnsetProduct");

                    b.HasIndex("OrderId");

                    b.HasDiscriminator().HasValue("BuyProduct");
                });

            modelBuilder.Entity("MysportShop.Models.BuyProduct", b =>
                {
                    b.HasOne("MysportShop.Models.Order")
                        .WithMany("buyProducts")
                        .HasForeignKey("OrderId");
                });
#pragma warning restore 612, 618
        }
    }
}
