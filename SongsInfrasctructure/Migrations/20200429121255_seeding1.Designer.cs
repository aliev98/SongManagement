﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SongSystem.Data;

namespace SongsInfrasctructure.Migrations
{
    [DbContext(typeof(SongSystemContext))]
    [Migration("20200429121255_seeding1")]
    partial class seeding1
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("SongsDomain.PlaylistDetails", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Playlists");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "Songs I like",
                            Name = "Favourites"
                        },
                        new
                        {
                            Id = 2,
                            Description = "a form of popular music originating in the rural southern US. It is a mixture of ballads and dance tunes played characteristically on fiddle, banjo, guitar, and pedal steel guitar.",
                            Name = "Country music"
                        });
                });

            modelBuilder.Entity("SongsDomain.SongDetails", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ArtistName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Length")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Songs");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            ArtistName = "Avicii",
                            Length = 10,
                            Title = "Without you"
                        },
                        new
                        {
                            Id = 2,
                            ArtistName = "Avicii",
                            Length = 15,
                            Title = "The nights"
                        },
                        new
                        {
                            Id = 3,
                            ArtistName = "Avicii",
                            Length = 12,
                            Title = "Waiting for love"
                        },
                        new
                        {
                            Id = 4,
                            ArtistName = "Eminem",
                            Length = 11,
                            Title = "Beautiful"
                        },
                        new
                        {
                            Id = 5,
                            ArtistName = "Eminem",
                            Length = 19,
                            Title = "Lose Yourself"
                        },
                        new
                        {
                            Id = 6,
                            ArtistName = "Marren Morris",
                            Length = 25,
                            Title = "The Bones"
                        },
                        new
                        {
                            Id = 7,
                            ArtistName = "Randy Travis",
                            Length = 20,
                            Title = "Forever And Ever"
                        });
                });

            modelBuilder.Entity("SongsDomain.SongForPlaylist", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("PlaylistId")
                        .HasColumnType("int");

                    b.Property<int>("SongDetailsId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PlaylistId");

                    b.HasIndex("SongDetailsId");

                    b.ToTable("songForPlaylists");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            PlaylistId = 1,
                            SongDetailsId = 1
                        },
                        new
                        {
                            Id = 2,
                            PlaylistId = 1,
                            SongDetailsId = 4
                        },
                        new
                        {
                            Id = 3,
                            PlaylistId = 1,
                            SongDetailsId = 5
                        },
                        new
                        {
                            Id = 4,
                            PlaylistId = 2,
                            SongDetailsId = 6
                        },
                        new
                        {
                            Id = 5,
                            PlaylistId = 2,
                            SongDetailsId = 7
                        });
                });

            modelBuilder.Entity("SongsDomain.SongForPlaylist", b =>
                {
                    b.HasOne("SongsDomain.PlaylistDetails", "Playlist")
                        .WithMany()
                        .HasForeignKey("PlaylistId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SongsDomain.SongDetails", "SongDetails")
                        .WithMany()
                        .HasForeignKey("SongDetailsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
