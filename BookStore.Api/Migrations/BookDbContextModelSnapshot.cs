﻿// <auto-generated />
using System;
using BookStore.Entity.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace BookStore.Api.Migrations
{
    [DbContext(typeof(BookDbContext))]
    partial class BookDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.8-servicing-32085")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("BookStore.Entity.Models.Account", b =>
                {
                    b.Property<Guid>("ACCOUNT_ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("NAME")
                        .IsRequired()
                        .HasMaxLength(500);

                    b.Property<byte>("TYPE");

                    b.HasKey("ACCOUNT_ID");

                    b.ToTable("Account");
                });

            modelBuilder.Entity("BookStore.Entity.Models.Author", b =>
                {
                    b.Property<Guid>("AUTHOR_ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("AUTHOR_NAME")
                        .IsRequired()
                        .HasMaxLength(250);

                    b.Property<string>("BIOGRAPHY");

                    b.Property<DateTime>("BIRTH_DATE");

                    b.HasKey("AUTHOR_ID");

                    b.ToTable("Author");
                });

            modelBuilder.Entity("BookStore.Entity.Models.Book", b =>
                {
                    b.Property<Guid>("BOOK_ID")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid>("ACCOUNT_ID_FK");

                    b.Property<Guid>("AUTHOR_ID_FK");

                    b.Property<Guid?>("CATEGORY_ID");

                    b.Property<string>("NAME")
                        .IsRequired()
                        .HasMaxLength(250);

                    b.Property<Guid>("PUBLISHER_ID_FK");

                    b.Property<Guid>("SHOP_ID_FK");

                    b.Property<string>("SUMMARY")
                        .IsRequired();

                    b.HasKey("BOOK_ID");

                    b.HasIndex("ACCOUNT_ID_FK");

                    b.HasIndex("AUTHOR_ID_FK");

                    b.HasIndex("CATEGORY_ID");

                    b.HasIndex("PUBLISHER_ID_FK");

                    b.HasIndex("SHOP_ID_FK");

                    b.ToTable("Book");
                });

            modelBuilder.Entity("BookStore.Entity.Models.Category", b =>
                {
                    b.Property<Guid>("CATEGORY_ID")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("IS_MAIN_CATEGORY");

                    b.Property<string>("NAME")
                        .IsRequired()
                        .HasMaxLength(250);

                    b.Property<string>("SUMMARY")
                        .IsRequired()
                        .HasMaxLength(500);

                    b.HasKey("CATEGORY_ID");

                    b.ToTable("Category");
                });

            modelBuilder.Entity("BookStore.Entity.Models.Publisher", b =>
                {
                    b.Property<Guid>("PUBLISHER_ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("LOCATION");

                    b.Property<string>("NAME")
                        .IsRequired()
                        .HasMaxLength(250);

                    b.Property<Guid>("SUPPLIER_ID_FK");

                    b.HasKey("PUBLISHER_ID");

                    b.HasIndex("SUPPLIER_ID_FK");

                    b.ToTable("Publisher");
                });

            modelBuilder.Entity("BookStore.Entity.Models.Shop", b =>
                {
                    b.Property<Guid>("SHOP_ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("LOCATION");

                    b.Property<string>("SHOP_NAME")
                        .IsRequired()
                        .HasMaxLength(250);

                    b.Property<int>("STAFF_COUNT");

                    b.HasKey("SHOP_ID");

                    b.ToTable("Shop");
                });

            modelBuilder.Entity("BookStore.Entity.Models.Supplier", b =>
                {
                    b.Property<Guid>("SUPPLIER_ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("SUPPLIER_NAME")
                        .IsRequired()
                        .HasMaxLength(250);

                    b.Property<string>("SUPPLIER_REGION")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.HasKey("SUPPLIER_ID");

                    b.ToTable("Supplier");
                });

            modelBuilder.Entity("BookStore.Entity.Models.User", b =>
                {
                    b.Property<Guid>("USER_ID")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid>("ACCOUNT_ID_FK");

                    b.Property<DateTime?>("BIRTH_DATE");

                    b.Property<string>("CREATED_BY")
                        .IsRequired();

                    b.Property<DateTime>("CREATED_DATE");

                    b.Property<string>("EMAIL_ADDRESS")
                        .IsRequired()
                        .HasMaxLength(300);

                    b.Property<bool>("EMAIL_CONFIRMED");

                    b.Property<string>("FIRST_NAME")
                        .IsRequired()
                        .HasMaxLength(250);

                    b.Property<string>("LOCATION");

                    b.Property<string>("MODIFIED_BY");

                    b.Property<DateTime?>("MODIFIED_DATE");

                    b.Property<string>("SECOND_NAME")
                        .IsRequired()
                        .HasMaxLength(250);

                    b.HasKey("USER_ID");

                    b.ToTable("User");
                });

            modelBuilder.Entity("BookStore.Entity.Models.User_Password", b =>
                {
                    b.Property<Guid>("USER_PASS_ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CREATED_BY")
                        .IsRequired();

                    b.Property<DateTime>("CREATED_DATE");

                    b.Property<bool>("IS_ACTIVE");

                    b.Property<string>("MODIFIED_BY");

                    b.Property<DateTime?>("MODIFIED_DATE");

                    b.Property<string>("PASSWORD_HASH")
                        .IsRequired();

                    b.Property<Guid>("USER_ID_FK");

                    b.HasKey("USER_PASS_ID");

                    b.HasIndex("USER_ID_FK");

                    b.ToTable("User_Password");
                });

            modelBuilder.Entity("BookStore.Entity.Models.Book", b =>
                {
                    b.HasOne("BookStore.Entity.Models.Account", "Account")
                        .WithMany()
                        .HasForeignKey("ACCOUNT_ID_FK")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("BookStore.Entity.Models.Author", "Author")
                        .WithMany()
                        .HasForeignKey("AUTHOR_ID_FK")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("BookStore.Entity.Models.Category", "Category")
                        .WithMany("books")
                        .HasForeignKey("CATEGORY_ID");

                    b.HasOne("BookStore.Entity.Models.Publisher", "Publisher")
                        .WithMany()
                        .HasForeignKey("PUBLISHER_ID_FK")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("BookStore.Entity.Models.Shop", "Shop")
                        .WithMany("books")
                        .HasForeignKey("SHOP_ID_FK")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("BookStore.Entity.Models.Publisher", b =>
                {
                    b.HasOne("BookStore.Entity.Models.Supplier", "Supplier")
                        .WithMany("Publishers")
                        .HasForeignKey("SUPPLIER_ID_FK")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("BookStore.Entity.Models.User_Password", b =>
                {
                    b.HasOne("BookStore.Entity.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("USER_ID_FK")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
