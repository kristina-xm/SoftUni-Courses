﻿// <auto-generated />
using ASP_ForumApp.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;

#nullable disable

namespace Forum.Data.Migrations
{
    [DbContext(typeof(ForumDbContext))]
    partial class ForumDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {

            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.16")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("ASP_ForumApp.Data.Models.Post", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasMaxLength(1500)
                        .HasColumnType("nvarchar(1500)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Posts");

                    b.HasData(
                        new
                        {
                            Id = new Guid("e400d0c0-fabf-45dd-9941-3bf2d122fcd7"),
                            Content = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed tempor mattis quam, at porttitor metus.",
                            Title = "Title 1"
                        },
                        new
                        {
                            Id = new Guid("3c5c5aa8-8351-4c01-9753-646fc896efa7"),
                            Content = "Lorem ipsum dolor sit amet, con.",
                            Title = "Title 2"
                        },
                        new
                        {
                            Id = new Guid("87422e12-19b4-4e1e-984e-3b70cbb0cbd8"),
                            Content = "Lorem ipsum dolor sit amet, con.rem ipsum dolor si piscing el ed tempor mattis quam, at porttit",
                            Title = "Title 3"
                        });
                });
        
        }
    }
}
