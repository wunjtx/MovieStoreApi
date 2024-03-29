﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MovieStore.Data;

namespace MovieStore.Data.Migrations
{
    [DbContext(typeof(MovieStoreDbContext))]
    partial class MovieStoreDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("MovieStore.Entities.Cast", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Gender");

                    b.Property<string>("Name")
                        .HasMaxLength(128);

                    b.Property<string>("ProfilePath")
                        .HasMaxLength(2084);

                    b.Property<string>("TmdbUrl");

                    b.HasKey("Id");

                    b.HasIndex("Name");

                    b.ToTable("Cast");
                });

            modelBuilder.Entity("MovieStore.Entities.Crew", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Gender");

                    b.Property<string>("Name")
                        .HasMaxLength(128);

                    b.Property<string>("ProfilePath")
                        .HasMaxLength(2084);

                    b.Property<string>("TmdbUrl");

                    b.HasKey("Id");

                    b.HasIndex("Name");

                    b.ToTable("Crew");
                });

            modelBuilder.Entity("MovieStore.Entities.Favorite", b =>
                {
                    b.Property<int>("MovieId");

                    b.Property<int>("UserId");

                    b.HasKey("MovieId", "UserId");

                    b.HasIndex("UserId");

                    b.ToTable("Favorites");
                });

            modelBuilder.Entity("MovieStore.Entities.Genre", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(64);

                    b.HasKey("ID");

                    b.ToTable("Genre");
                });

            modelBuilder.Entity("MovieStore.Entities.Movie", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("BackdropUrl")
                        .HasMaxLength(2084);

                    b.Property<decimal?>("Budget");

                    b.Property<string>("ImdbUrl")
                        .HasMaxLength(2084);

                    b.Property<string>("OriginalLanguage")
                        .HasMaxLength(64);

                    b.Property<string>("Overview")
                        .HasMaxLength(4096);

                    b.Property<string>("PosterUrl")
                        .HasMaxLength(2084);

                    b.Property<decimal?>("Price")
                        .HasColumnType("decimal(5, 2)");

                    b.Property<DateTime?>("ReleaseDate");

                    b.Property<decimal?>("Revenue");

                    b.Property<int?>("RunTime");

                    b.Property<string>("Tagline")
                        .HasMaxLength(512);

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(256);

                    b.Property<string>("TmdbUrl")
                        .HasMaxLength(2084);

                    b.HasKey("Id");

                    b.HasIndex("Title");

                    b.ToTable("Movie");
                });

            modelBuilder.Entity("MovieStore.Entities.MovieCast", b =>
                {
                    b.Property<int>("CastId");

                    b.Property<int>("MovieId");

                    b.Property<string>("Character");

                    b.HasKey("CastId", "MovieId", "Character");

                    b.HasIndex("MovieId");

                    b.ToTable("MovieCast");
                });

            modelBuilder.Entity("MovieStore.Entities.MovieCrew", b =>
                {
                    b.Property<int>("MovieId");

                    b.Property<int>("CrewId");

                    b.Property<string>("Department")
                        .HasMaxLength(128);

                    b.Property<string>("Job")
                        .HasMaxLength(128);

                    b.HasKey("MovieId", "CrewId", "Department", "Job");

                    b.HasIndex("CrewId");

                    b.ToTable("MovieCrew");
                });

            modelBuilder.Entity("MovieStore.Entities.MovieGenre", b =>
                {
                    b.Property<int>("MovieId");

                    b.Property<int>("GenreId");

                    b.HasKey("MovieId", "GenreId");

                    b.HasIndex("GenreId");

                    b.ToTable("MovieGenre");
                });

            modelBuilder.Entity("MovieStore.Entities.Purchase", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("MovieId");

                    b.Property<DateTime>("PurchaseDateTime");

                    b.Property<Guid>("PurchaseNumber")
                        .ValueGeneratedOnAdd();

                    b.Property<decimal>("TotalPrice");

                    b.Property<int>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("MovieId");

                    b.HasIndex("UserId", "MovieId")
                        .IsUnique();

                    b.ToTable("Purchase");
                });

            modelBuilder.Entity("MovieStore.Entities.Review", b =>
                {
                    b.Property<int>("MovieId");

                    b.Property<int>("UserId");

                    b.Property<decimal>("Rating")
                        .HasColumnType("decimal(3, 2)");

                    b.Property<string>("ReviewText");

                    b.HasKey("MovieId", "UserId");

                    b.HasIndex("UserId");

                    b.ToTable("Review");
                });

            modelBuilder.Entity("MovieStore.Entities.Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasMaxLength(20);

                    b.HasKey("Id");

                    b.ToTable("Role");
                });

            modelBuilder.Entity("MovieStore.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("AccessFailedCount");

                    b.Property<DateTime?>("DateOfBirth");

                    b.Property<string>("Email")
                        .HasMaxLength(256);

                    b.Property<string>("FirstName")
                        .HasMaxLength(128);

                    b.Property<string>("HashedPassword")
                        .HasMaxLength(1024);

                    b.Property<bool?>("IsLocked")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValue(false);

                    b.Property<DateTime?>("LastLoginDateTime");

                    b.Property<string>("LastName")
                        .HasMaxLength(128);

                    b.Property<DateTime?>("LockoutEndDate");

                    b.Property<string>("PhoneNumber")
                        .HasMaxLength(16);

                    b.Property<string>("Salt")
                        .HasMaxLength(1024);

                    b.Property<bool?>("TwoFactorEnabled");

                    b.HasKey("Id");

                    b.HasIndex("Email")
                        .IsUnique()
                        .HasFilter("[Email] IS NOT NULL");

                    b.ToTable("User");
                });

            modelBuilder.Entity("MovieStore.Entities.UserRole", b =>
                {
                    b.Property<int>("UserId");

                    b.Property<int>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("UserRole");
                });

            modelBuilder.Entity("MovieStore.Entities.Favorite", b =>
                {
                    b.HasOne("MovieStore.Entities.Movie", "Movie")
                        .WithMany()
                        .HasForeignKey("MovieId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("MovieStore.Entities.User", "User")
                        .WithMany("Favorites")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("MovieStore.Entities.MovieCast", b =>
                {
                    b.HasOne("MovieStore.Entities.Cast", "Cast")
                        .WithMany("MovieCast")
                        .HasForeignKey("CastId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("MovieStore.Entities.Movie", "Movie")
                        .WithMany("MovieCast")
                        .HasForeignKey("MovieId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("MovieStore.Entities.MovieCrew", b =>
                {
                    b.HasOne("MovieStore.Entities.Crew", "Crew")
                        .WithMany("MovieCrew")
                        .HasForeignKey("CrewId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("MovieStore.Entities.Movie", "Movie")
                        .WithMany("MovieCrew")
                        .HasForeignKey("MovieId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("MovieStore.Entities.MovieGenre", b =>
                {
                    b.HasOne("MovieStore.Entities.Genre", "Genre")
                        .WithMany("MovieGenres")
                        .HasForeignKey("GenreId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("MovieStore.Entities.Movie", "Movie")
                        .WithMany("MovieGenres")
                        .HasForeignKey("MovieId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("MovieStore.Entities.Purchase", b =>
                {
                    b.HasOne("MovieStore.Entities.Movie", "Movie")
                        .WithMany()
                        .HasForeignKey("MovieId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("MovieStore.Entities.User", "Customer")
                        .WithMany("Purchases")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("MovieStore.Entities.Review", b =>
                {
                    b.HasOne("MovieStore.Entities.Movie", "Movie")
                        .WithMany()
                        .HasForeignKey("MovieId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("MovieStore.Entities.User", "User")
                        .WithMany("Reviews")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("MovieStore.Entities.UserRole", b =>
                {
                    b.HasOne("MovieStore.Entities.Role", "Role")
                        .WithMany("UserRoles")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("MovieStore.Entities.User", "User")
                        .WithMany("UserRoles")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
