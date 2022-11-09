﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebShop.Infra.Repositories;

#nullable disable

namespace WebShop.Infra.Migrations
{
    [DbContext(typeof(WebShopDbContext))]
    partial class WebShopDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("WebShop.Core.Entities.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImgUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(8,3)");

                    b.Property<string>("ProductCategory")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<string>("Provider")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.HasKey("Id");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "Delicious avocado",
                            ImgUrl = "assets/imgs/shop/product-9-1.jpg",
                            Name = "Avocado",
                            Price = 34.6m,
                            ProductCategory = "Vegetables",
                            Provider = "Amazon"
                        },
                        new
                        {
                            Id = 2,
                            Description = "Delicious nuts",
                            ImgUrl = "assets/imgs/shop/product-3-1.jpg",
                            Name = "Nuts",
                            Price = 4.9m,
                            ProductCategory = "Snack",
                            Provider = "Amazon"
                        },
                        new
                        {
                            Id = 3,
                            Description = "Delicious Stake",
                            ImgUrl = "assets/imgs/shop/product-2-1.jpg",
                            Name = "Stake Meat",
                            Price = 64.6m,
                            ProductCategory = "Meats",
                            Provider = "MeatMarket"
                        },
                        new
                        {
                            Id = 4,
                            Description = "Delicious Water",
                            ImgUrl = "assets/imgs/shop/product-1-1.jpg",
                            Name = "Bottle of water",
                            Price = 0.6m,
                            ProductCategory = "All",
                            Provider = "Fuentsanta"
                        });
                });

            modelBuilder.Entity("WebShop.Core.Entities.ReviewScore", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<decimal>("Score")
                        .HasColumnType("decimal(8,3)");

                    b.HasKey("Id");

                    b.HasIndex("ProductId");

                    b.ToTable("ReviewScores");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            ProductId = 1,
                            Score = 3m
                        },
                        new
                        {
                            Id = 2,
                            ProductId = 2,
                            Score = 3.1m
                        },
                        new
                        {
                            Id = 3,
                            ProductId = 2,
                            Score = 5m
                        },
                        new
                        {
                            Id = 4,
                            ProductId = 2,
                            Score = 1m
                        },
                        new
                        {
                            Id = 5,
                            ProductId = 3,
                            Score = 3m
                        },
                        new
                        {
                            Id = 6,
                            ProductId = 3,
                            Score = 0.9m
                        },
                        new
                        {
                            Id = 7,
                            ProductId = 3,
                            Score = 3.7m
                        },
                        new
                        {
                            Id = 12,
                            ProductId = 4,
                            Score = 5m
                        });
                });

            modelBuilder.Entity("WebShop.Core.Entities.ReviewScore", b =>
                {
                    b.HasOne("WebShop.Core.Entities.Product", "Product")
                        .WithMany("ReviewsScore")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Product");
                });

            modelBuilder.Entity("WebShop.Core.Entities.Product", b =>
                {
                    b.Navigation("ReviewsScore");
                });
#pragma warning restore 612, 618
        }
    }
}
