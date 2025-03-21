﻿// <auto-generated />
using KisiselBlog.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace KisiselBlog.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20250306134838_RemovedCreatedDate")]
    partial class RemovedCreatedDate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "9.0.0-preview.2.24128.4");

            modelBuilder.Entity("KisiselBlog.Models.Project", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Category")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("FeaturesJson")
                        .HasColumnType("TEXT");

                    b.Property<string>("GifUrl")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("ImageUrl")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<bool>("IsFeatured")
                        .HasColumnType("INTEGER");

                    b.Property<string>("ShortDescription")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("TechStack")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("TechnologiesJson")
                        .HasColumnType("TEXT");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Projects");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Category = "frontend",
                            Description = "ASP.NET Core MVC kullanılarak geliştirilen modern ve responsive bir kişisel blog sitesi.",
                            GifUrl = "/images/proje1.gif",
                            ImageUrl = "/images/proje1.png",
                            IsFeatured = true,
                            ShortDescription = "ASP.NET Core MVC ile geliştirilmiş modern blog sitesi",
                            TechStack = "ASP.NET Core MVC, Bootstrap 5, Entity Framework Core",
                            Title = "Kişisel Blog Projesi"
                        },
                        new
                        {
                            Id = 2,
                            Category = "all",
                            Description = "React ve .NET Core Web API kullanılarak geliştirilen modern bir görev yönetim uygulaması.",
                            GifUrl = "/images/proje2.gif",
                            ImageUrl = "/images/proje2.png",
                            IsFeatured = true,
                            ShortDescription = "React ve .NET Core Web API ile geliştirilmiş görev yönetim uygulaması",
                            TechStack = "React.js, .NET Core Web API, Entity Framework Core",
                            Title = "To-Do List Uygulaması"
                        },
                        new
                        {
                            Id = 3,
                            Category = "web",
                            Description = "ASP.NET Core backend ve Angular frontend ile geliştirilmiş, tam kapsamlı bir e-ticaret platformu.",
                            GifUrl = "/images/proje3.gif",
                            ImageUrl = "/images/proje3.png",
                            IsFeatured = false,
                            ShortDescription = "ASP.NET Core ve Angular ile geliştirilmiş e-ticaret platformu",
                            TechStack = "ASP.NET Core, Angular, MS SQL, Redis",
                            Title = "E-Ticaret Platformu"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
