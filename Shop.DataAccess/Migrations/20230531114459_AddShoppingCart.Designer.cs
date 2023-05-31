﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Shop.DataAccess;

#nullable disable

namespace Shop.DataAccess.Migrations
{
    [DbContext(typeof(ShopContext))]
    [Migration("20230531114459_AddShoppingCart")]
    partial class AddShoppingCart
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Shop.DataAccess.Entities.CartItem", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ProductId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<string>("UserEmail")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ProductId");

                    b.ToTable("ShoppingCartItems");
                });

            modelBuilder.Entity("Shop.DataAccess.Entities.Category", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("ParentCategoryId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("ParentCategoryId");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            Id = new Guid("027ab076-461c-4f42-a09b-e052b818aa57"),
                            Description = "Smartphones and Gadgets category",
                            Name = "Smartphones and Gadgets"
                        },
                        new
                        {
                            Id = new Guid("a71fe02a-a524-49ee-9f26-d156c0b62d6c"),
                            Description = "Smartphones and Accessories category",
                            Name = "Smartphones and Accessories",
                            ParentCategoryId = new Guid("027ab076-461c-4f42-a09b-e052b818aa57")
                        },
                        new
                        {
                            Id = new Guid("d4490f24-d752-458f-b324-a604e79b2f2e"),
                            Description = "Smartphone Accessories category",
                            Name = "Accessories",
                            ParentCategoryId = new Guid("a71fe02a-a524-49ee-9f26-d156c0b62d6c")
                        },
                        new
                        {
                            Id = new Guid("c4bf3a5e-5aec-417d-9a4b-efc71fe6956d"),
                            Description = "Cases and Covers category",
                            Name = "Cases and Covers",
                            ParentCategoryId = new Guid("d4490f24-d752-458f-b324-a604e79b2f2e")
                        },
                        new
                        {
                            Id = new Guid("e05ab76b-f53b-41c8-aac1-e8062ae75f54"),
                            Description = "Smartphones category",
                            Name = "Smartphones",
                            ParentCategoryId = new Guid("a71fe02a-a524-49ee-9f26-d156c0b62d6c")
                        },
                        new
                        {
                            Id = new Guid("875a71eb-231b-4f34-a628-330dc5968ee0"),
                            Description = "Tablets category",
                            Name = "Tablets",
                            ParentCategoryId = new Guid("027ab076-461c-4f42-a09b-e052b818aa57")
                        },
                        new
                        {
                            Id = new Guid("c11cdea5-b146-421b-ad27-bfe07dcb6a66"),
                            Description = "Headphones category",
                            Name = "Headphones",
                            ParentCategoryId = new Guid("027ab076-461c-4f42-a09b-e052b818aa57")
                        },
                        new
                        {
                            Id = new Guid("38f67f27-92be-4983-a8b3-bd557f36e60e"),
                            Description = "Bluetooth Headphones category",
                            Name = "Bluetooth Headphones",
                            ParentCategoryId = new Guid("c11cdea5-b146-421b-ad27-bfe07dcb6a66")
                        },
                        new
                        {
                            Id = new Guid("17365631-3b8f-4d6d-a499-c94b88531435"),
                            Description = "Earbuds category",
                            Name = "Earbuds",
                            ParentCategoryId = new Guid("c11cdea5-b146-421b-ad27-bfe07dcb6a66")
                        },
                        new
                        {
                            Id = new Guid("4022a623-2ccc-43bb-8fc6-f737875ea741"),
                            Description = "Over-Ear Headphones category",
                            Name = "Over-Ear Headphones",
                            ParentCategoryId = new Guid("c11cdea5-b146-421b-ad27-bfe07dcb6a66")
                        },
                        new
                        {
                            Id = new Guid("7bf9425a-1c6e-4078-817f-1c49b4909404"),
                            Description = "Gadgets category",
                            Name = "Gadgets",
                            ParentCategoryId = new Guid("027ab076-461c-4f42-a09b-e052b818aa57")
                        },
                        new
                        {
                            Id = new Guid("30d6b5bd-900b-4d97-b39c-befc21b4cc4a"),
                            Description = "Smart Watch category",
                            Name = "Smart Watches",
                            ParentCategoryId = new Guid("7bf9425a-1c6e-4078-817f-1c49b4909404")
                        },
                        new
                        {
                            Id = new Guid("71edade5-f485-421a-9783-cc63dce769dd"),
                            Description = "Fitness Trackers category",
                            Name = "Fitness Trackers",
                            ParentCategoryId = new Guid("7bf9425a-1c6e-4078-817f-1c49b4909404")
                        },
                        new
                        {
                            Id = new Guid("af784f4c-e8cb-458a-b313-e94619358052"),
                            Description = "TVs category",
                            Name = "TVs"
                        },
                        new
                        {
                            Id = new Guid("74345c29-4005-470d-96a3-a77996a84686"),
                            Description = "LED TVs category",
                            Name = "LED TVs",
                            ParentCategoryId = new Guid("af784f4c-e8cb-458a-b313-e94619358052")
                        },
                        new
                        {
                            Id = new Guid("11f80fdb-6ee8-4005-86d6-b59b46ff6930"),
                            Description = "OLED TVs category",
                            Name = "OLED TVs",
                            ParentCategoryId = new Guid("af784f4c-e8cb-458a-b313-e94619358052")
                        },
                        new
                        {
                            Id = new Guid("9758d768-a2d5-40fb-9f13-0eba41770a82"),
                            Description = "Smart TVs category",
                            Name = "Smart TVs",
                            ParentCategoryId = new Guid("af784f4c-e8cb-458a-b313-e94619358052")
                        },
                        new
                        {
                            Id = new Guid("07b9ad0f-6847-46dd-9609-8ccf7da201db"),
                            Description = "Laptops and computers category",
                            Name = "Laptops and computers"
                        },
                        new
                        {
                            Id = new Guid("405fc23c-aa11-47f2-828e-f721ceeceb53"),
                            Description = "Laptops and computer equipment category",
                            Name = "Laptops and computer equipment",
                            ParentCategoryId = new Guid("07b9ad0f-6847-46dd-9609-8ccf7da201db")
                        },
                        new
                        {
                            Id = new Guid("24cc7c5f-7b14-4044-82fd-bfa882a7ee95"),
                            Description = "Laptop Computers category",
                            Name = "Laptop Computers",
                            ParentCategoryId = new Guid("405fc23c-aa11-47f2-828e-f721ceeceb53")
                        },
                        new
                        {
                            Id = new Guid("d1553817-fcde-4c22-87df-b54e27e9d5c9"),
                            Description = "Desktop Computers category",
                            Name = "Desktop Computers",
                            ParentCategoryId = new Guid("405fc23c-aa11-47f2-828e-f721ceeceb53")
                        },
                        new
                        {
                            Id = new Guid("41c5ec09-6a3c-4375-867f-7952dc9df354"),
                            Description = "Input Devices and Storage category",
                            Name = "Input Devices and Storage",
                            ParentCategoryId = new Guid("07b9ad0f-6847-46dd-9609-8ccf7da201db")
                        },
                        new
                        {
                            Id = new Guid("6aafe0c5-2673-49d4-97ba-6381bf43ffdc"),
                            Description = "Keyboards category",
                            Name = "Keyboards",
                            ParentCategoryId = new Guid("41c5ec09-6a3c-4375-867f-7952dc9df354")
                        },
                        new
                        {
                            Id = new Guid("6feb32fe-afc3-4d51-90a9-5acf19b7a0da"),
                            Description = "Computer Mice category",
                            Name = "Computer Mice",
                            ParentCategoryId = new Guid("41c5ec09-6a3c-4375-867f-7952dc9df354")
                        },
                        new
                        {
                            Id = new Guid("8dec42a2-1b3b-4ebc-8816-bfb907c0840c"),
                            Description = "HDDs and SSDs category",
                            Name = "HDDs and SSDs",
                            ParentCategoryId = new Guid("41c5ec09-6a3c-4375-867f-7952dc9df354")
                        });
                });

            modelBuilder.Entity("Shop.DataAccess.Entities.Detail", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Details");

                    b.HasData(
                        new
                        {
                            Id = new Guid("f3f27ab2-e1f8-4ba4-a4f2-2e5b97bb769b"),
                            Name = "Brand",
                            Type = 0
                        },
                        new
                        {
                            Id = new Guid("0d517bcf-374b-4095-9e7c-4187bd814e27"),
                            Name = "Color",
                            Type = 0
                        },
                        new
                        {
                            Id = new Guid("fa47c781-8881-4e88-b508-6c401678fbf5"),
                            Name = "Manufacturer",
                            Type = 0
                        },
                        new
                        {
                            Id = new Guid("b1f3413e-8556-401f-8ffe-ba221b9d5e58"),
                            Name = "Memory",
                            Type = 1
                        },
                        new
                        {
                            Id = new Guid("c621e56a-5546-49f1-bb69-fd97c9a00fe1"),
                            Name = "Display",
                            Type = 1
                        },
                        new
                        {
                            Id = new Guid("fdfa2737-bf8f-4fb8-9477-bfa52cbd198c"),
                            Name = "Camera",
                            Type = 1
                        },
                        new
                        {
                            Id = new Guid("955dd108-63c3-4d6c-83da-f23991091ece"),
                            Name = "Battery",
                            Type = 1
                        },
                        new
                        {
                            Id = new Guid("6dbc33b7-8938-495d-b573-0b36dced335e"),
                            Name = "Noise Control",
                            Type = 2
                        },
                        new
                        {
                            Id = new Guid("f5c54777-d731-4e88-be25-9f653575ea5c"),
                            Name = "Smart Alarm",
                            Type = 2
                        },
                        new
                        {
                            Id = new Guid("751d6ee6-ad02-4452-a626-e6b7f625f421"),
                            Name = "Memory Card Support",
                            Type = 2
                        });
                });

            modelBuilder.Entity("Shop.DataAccess.Entities.Product", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CategoryId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhotoUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Price")
                        .HasPrecision(18, 2)
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            Id = new Guid("86ca08b6-3b59-4046-9c3f-260f0631ceb8"),
                            CategoryId = new Guid("e05ab76b-f53b-41c8-aac1-e8062ae75f54"),
                            Description = "This is a description for Apple iPhone 13.",
                            Name = "Apple iPhone 13",
                            Price = 900m
                        },
                        new
                        {
                            Id = new Guid("75ac7087-0031-4895-8a7c-60e87b96a5d7"),
                            CategoryId = new Guid("e05ab76b-f53b-41c8-aac1-e8062ae75f54"),
                            Description = "This is a description for Samsung Galaxy M32",
                            Name = "Samsung Galaxy M32",
                            Price = 300m
                        },
                        new
                        {
                            Id = new Guid("7cda37ad-0d0a-4685-8104-3f435f5eeaf6"),
                            CategoryId = new Guid("e05ab76b-f53b-41c8-aac1-e8062ae75f54"),
                            Description = "This is a description for Xiaomi Redmi Note 12",
                            Name = "Xiaomi Redmi Note 12",
                            Price = 300m
                        },
                        new
                        {
                            Id = new Guid("15fbac63-871c-4eb5-bcaa-900179d7d8e4"),
                            CategoryId = new Guid("c4bf3a5e-5aec-417d-9a4b-efc71fe6956d"),
                            Description = "This is a description for phone case.",
                            Name = "UGREEN Clear iPhone 12 Case",
                            Price = 30m
                        },
                        new
                        {
                            Id = new Guid("b06cc374-2161-474b-bd67-469ab1e757bf"),
                            CategoryId = new Guid("38f67f27-92be-4983-a8b3-bd557f36e60e"),
                            Description = "This is a description for JBL Tune 510BT Black.",
                            Name = "JBL Tune 510BT Black",
                            Price = 60m
                        },
                        new
                        {
                            Id = new Guid("d09d2c8d-87e7-465b-9364-b409233a8607"),
                            CategoryId = new Guid("71edade5-f485-421a-9783-cc63dce769dd"),
                            Description = "This is a description for Redmi Smart Band 2.",
                            Name = "Xiaomi Redmi Smart Band 2",
                            Price = 30m
                        });
                });

            modelBuilder.Entity("Shop.DataAccess.Entities.ProductDetail", b =>
                {
                    b.Property<Guid>("ProductId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("DetailId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Value")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ProductId", "DetailId");

                    b.HasIndex("DetailId");

                    b.ToTable("ProductDetails");

                    b.HasData(
                        new
                        {
                            ProductId = new Guid("86ca08b6-3b59-4046-9c3f-260f0631ceb8"),
                            DetailId = new Guid("f3f27ab2-e1f8-4ba4-a4f2-2e5b97bb769b"),
                            Value = "Apple"
                        },
                        new
                        {
                            ProductId = new Guid("86ca08b6-3b59-4046-9c3f-260f0631ceb8"),
                            DetailId = new Guid("c621e56a-5546-49f1-bb69-fd97c9a00fe1"),
                            Value = "6.1"
                        },
                        new
                        {
                            ProductId = new Guid("86ca08b6-3b59-4046-9c3f-260f0631ceb8"),
                            DetailId = new Guid("0d517bcf-374b-4095-9e7c-4187bd814e27"),
                            Value = "Midnight"
                        },
                        new
                        {
                            ProductId = new Guid("86ca08b6-3b59-4046-9c3f-260f0631ceb8"),
                            DetailId = new Guid("fdfa2737-bf8f-4fb8-9477-bfa52cbd198c"),
                            Value = "12"
                        },
                        new
                        {
                            ProductId = new Guid("75ac7087-0031-4895-8a7c-60e87b96a5d7"),
                            DetailId = new Guid("f3f27ab2-e1f8-4ba4-a4f2-2e5b97bb769b"),
                            Value = "Samsung"
                        },
                        new
                        {
                            ProductId = new Guid("75ac7087-0031-4895-8a7c-60e87b96a5d7"),
                            DetailId = new Guid("c621e56a-5546-49f1-bb69-fd97c9a00fe1"),
                            Value = "6.4"
                        },
                        new
                        {
                            ProductId = new Guid("75ac7087-0031-4895-8a7c-60e87b96a5d7"),
                            DetailId = new Guid("0d517bcf-374b-4095-9e7c-4187bd814e27"),
                            Value = "Black"
                        },
                        new
                        {
                            ProductId = new Guid("75ac7087-0031-4895-8a7c-60e87b96a5d7"),
                            DetailId = new Guid("fdfa2737-bf8f-4fb8-9477-bfa52cbd198c"),
                            Value = "64"
                        },
                        new
                        {
                            ProductId = new Guid("7cda37ad-0d0a-4685-8104-3f435f5eeaf6"),
                            DetailId = new Guid("f3f27ab2-e1f8-4ba4-a4f2-2e5b97bb769b"),
                            Value = "Xiaomi"
                        },
                        new
                        {
                            ProductId = new Guid("7cda37ad-0d0a-4685-8104-3f435f5eeaf6"),
                            DetailId = new Guid("c621e56a-5546-49f1-bb69-fd97c9a00fe1"),
                            Value = "6.67"
                        },
                        new
                        {
                            ProductId = new Guid("7cda37ad-0d0a-4685-8104-3f435f5eeaf6"),
                            DetailId = new Guid("0d517bcf-374b-4095-9e7c-4187bd814e27"),
                            Value = "Black"
                        },
                        new
                        {
                            ProductId = new Guid("7cda37ad-0d0a-4685-8104-3f435f5eeaf6"),
                            DetailId = new Guid("fdfa2737-bf8f-4fb8-9477-bfa52cbd198c"),
                            Value = "50"
                        });
                });

            modelBuilder.Entity("Shop.DataAccess.Entities.CartItem", b =>
                {
                    b.HasOne("Shop.DataAccess.Entities.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Product");
                });

            modelBuilder.Entity("Shop.DataAccess.Entities.Category", b =>
                {
                    b.HasOne("Shop.DataAccess.Entities.Category", "ParentCategory")
                        .WithMany("ChildCategories")
                        .HasForeignKey("ParentCategoryId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.Navigation("ParentCategory");
                });

            modelBuilder.Entity("Shop.DataAccess.Entities.Product", b =>
                {
                    b.HasOne("Shop.DataAccess.Entities.Category", "Category")
                        .WithMany("Products")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });

            modelBuilder.Entity("Shop.DataAccess.Entities.ProductDetail", b =>
                {
                    b.HasOne("Shop.DataAccess.Entities.Detail", "Detail")
                        .WithMany("ProductDetails")
                        .HasForeignKey("DetailId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Shop.DataAccess.Entities.Product", "Product")
                        .WithMany("ProductDetails")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Detail");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("Shop.DataAccess.Entities.Category", b =>
                {
                    b.Navigation("ChildCategories");

                    b.Navigation("Products");
                });

            modelBuilder.Entity("Shop.DataAccess.Entities.Detail", b =>
                {
                    b.Navigation("ProductDetails");
                });

            modelBuilder.Entity("Shop.DataAccess.Entities.Product", b =>
                {
                    b.Navigation("ProductDetails");
                });
#pragma warning restore 612, 618
        }
    }
}
