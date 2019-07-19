﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MyBlog.Persistence;

namespace MyBlog.Persistence.Migrations
{
    [DbContext(typeof(MyBlogDbContext))]
    [Migration("20190719100444_InitialContext")]
    partial class InitialContext
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.4-servicing-10062")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("MyBlog.Domain.Entities.Blog", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CategoryId")
                        .HasColumnName("CategoryID");

                    b.Property<string>("Description")
                        .IsRequired();

                    b.Property<bool>("IsDraft");

                    b.Property<DateTime?>("PostedDate");

                    b.Property<string>("ShortDescription")
                        .IsRequired()
                        .HasMaxLength(350);

                    b.Property<string>("Tags");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(200);

                    b.Property<string>("UserName")
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.HasIndex("UserName");

                    b.ToTable("Blogs");
                });

            modelBuilder.Entity("MyBlog.Domain.Entities.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("MyBlog.Domain.Entities.UserDetail", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address")
                        .HasMaxLength(50);

                    b.Property<DateTime?>("DeleteDateTime");

                    b.Property<int>("DeletedBy");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(75);

                    b.Property<string>("FacebookUrl");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("GithubUrl");

                    b.Property<bool>("IsDeleted");

                    b.Property<string>("LastName")
                        .HasMaxLength(50);

                    b.Property<string>("LinkedinUrl");

                    b.Property<string>("TwitterUrl");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.ToTable("UserDetails");
                });

            modelBuilder.Entity("MyBlog.Domain.Entities.Blog", b =>
                {
                    b.HasOne("MyBlog.Domain.Entities.Category", "Category")
                        .WithMany("Blogs")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("MyBlog.Domain.Entities.UserDetail", "Author")
                        .WithMany("Blogs")
                        .HasForeignKey("UserName")
                        .HasPrincipalKey("UserName");
                });
#pragma warning restore 612, 618
        }
    }
}