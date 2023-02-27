﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MovieCharactersAPI.Models;

#nullable disable

namespace MovieCharactersAPI.Migrations
{
    [DbContext(typeof(MovieCharactersDbContext))]
    partial class MovieCharactersDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("CharacterMovie", b =>
                {
                    b.Property<int>("CharactersId")
                        .HasColumnType("int");

                    b.Property<int>("MoviesId")
                        .HasColumnType("int");

                    b.HasKey("CharactersId", "MoviesId");

                    b.HasIndex("MoviesId");

                    b.ToTable("CharacterMovie");
                });

            modelBuilder.Entity("MovieCharactersAPI.Models.Character", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Alias")
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)");

                    b.Property<int>("Gender")
                        .HasColumnType("int");

                    b.Property<string>("Photo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Characters");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Alias = "FillePille",
                            FullName = "Filip",
                            Gender = 2,
                            Photo = "https://i.ytimg.com/vi/OMGBIQHODhw/maxresdefault.jpg"
                        },
                        new
                        {
                            Id = 2,
                            Alias = "TommyBoy",
                            FullName = "Tommy",
                            Gender = 0,
                            Photo = "https://i.ytimg.com/vi/OMGBIQHODhw/maxresdefault.jpg"
                        },
                        new
                        {
                            Id = 3,
                            Alias = "mr100",
                            FullName = "Tintin",
                            Gender = 1,
                            Photo = "https://i.ytimg.com/vi/OMGBIQHODhw/maxresdefault.jpg"
                        });
                });

            modelBuilder.Entity("MovieCharactersAPI.Models.Franchise", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)");

                    b.HasKey("Id");

                    b.ToTable("Franchises");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "Big Universe with Big ideas.",
                            Name = "Experis Cinematic Universe"
                        },
                        new
                        {
                            Id = 2,
                            Description = "Tintins Yh adventures",
                            Name = "Yh Cinematic Universe"
                        });
                });

            modelBuilder.Entity("MovieCharactersAPI.Models.Movie", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Director")
                        .IsRequired()
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)");

                    b.Property<int>("FranchiseId")
                        .HasColumnType("int");

                    b.Property<string>("Genre")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Picture")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ReleaseYear")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)");

                    b.Property<string>("Trailer")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("FranchiseId");

                    b.ToTable("Movies");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Director = "Tintin The Big",
                            FranchiseId = 1,
                            Genre = "Action, Adventure",
                            Picture = "https://i.ytimg.com/vi/OMGBIQHODhw/maxresdefault.jpg",
                            ReleaseYear = 2001,
                            Title = "Filips Adventure",
                            Trailer = "https://www.youtube.com/watch?v=OMGBIQHODhw"
                        },
                        new
                        {
                            Id = 2,
                            Director = "Tintin The Big",
                            FranchiseId = 1,
                            Genre = "Drama, Comedy",
                            Picture = "https://i.ytimg.com/vi/OMGBIQHODhw/maxresdefault.jpg",
                            ReleaseYear = 2010,
                            Title = "Tommy's Wedding",
                            Trailer = "https://www.youtube.com/watch?v=OMGBIQHODhw"
                        },
                        new
                        {
                            Id = 3,
                            Director = "Albert Einstein",
                            FranchiseId = 2,
                            Genre = "Action, Comedy",
                            Picture = "https://i.ytimg.com/vi/OMGBIQHODhw/maxresdefault.jpg",
                            ReleaseYear = 2012,
                            Title = "Tintin",
                            Trailer = "https://www.youtube.com/watch?v=OMGBIQHODhw"
                        });
                });

            modelBuilder.Entity("CharacterMovie", b =>
                {
                    b.HasOne("MovieCharactersAPI.Models.Character", null)
                        .WithMany()
                        .HasForeignKey("CharactersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MovieCharactersAPI.Models.Movie", null)
                        .WithMany()
                        .HasForeignKey("MoviesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("MovieCharactersAPI.Models.Movie", b =>
                {
                    b.HasOne("MovieCharactersAPI.Models.Franchise", "Franchise")
                        .WithMany("Movies")
                        .HasForeignKey("FranchiseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Franchise");
                });

            modelBuilder.Entity("MovieCharactersAPI.Models.Franchise", b =>
                {
                    b.Navigation("Movies");
                });
#pragma warning restore 612, 618
        }
    }
}
