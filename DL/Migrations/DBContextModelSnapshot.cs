﻿// <auto-generated />
using DL;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace DL.Migrations
{
    [DbContext(typeof(DBContext))]
    partial class DBContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Models.Category", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("ID"));

                    b.Property<string>("CategoryName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("ID");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("Models.Comment", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("ID"));

                    b.Property<string>("Date")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("DrawingID")
                        .HasColumnType("integer");

                    b.Property<string>("Message")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("UserID")
                        .HasColumnType("integer");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<bool>("isLiked")
                        .HasColumnType("boolean");

                    b.HasKey("ID");

                    b.ToTable("Comments");
                });

            modelBuilder.Entity("Models.Drawing", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("ID"));

                    b.Property<string>("BucketImage")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Date")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("GoogleResponse")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<decimal>("GoogleScore")
                        .HasColumnType("numeric");

                    b.Property<bool>("Guess")
                        .HasColumnType("boolean");

                    b.Property<string>("Keyword")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("PlayerID")
                        .HasColumnType("integer");

                    b.Property<string>("PlayerName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("WallPostID")
                        .HasColumnType("integer");

                    b.Property<bool>("isLiked")
                        .HasColumnType("boolean");

                    b.HasKey("ID");

                    b.HasIndex("PlayerID");

                    b.HasIndex("WallPostID");

                    b.ToTable("Drawings");
                });

            modelBuilder.Entity("Models.Like", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("ID"));

                    b.Property<int>("CommentID")
                        .HasColumnType("integer");

                    b.Property<int>("DrawingID")
                        .HasColumnType("integer");

                    b.Property<int>("PlayerID")
                        .HasColumnType("integer");

                    b.HasKey("ID");

                    b.HasIndex("CommentID");

                    b.HasIndex("DrawingID");

                    b.ToTable("Likes");
                });

            modelBuilder.Entity("Models.Player", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("ID"));

                    b.Property<decimal>("AverageResult")
                        .HasColumnType("numeric");

                    b.Property<decimal>("AverageScore")
                        .HasColumnType("numeric");

                    b.Property<int>("CorrectGuesses")
                        .HasColumnType("integer");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("TotalGuesses")
                        .HasColumnType("integer");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("ID");

                    b.ToTable("Players");
                });

            modelBuilder.Entity("Models.WallPost", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("ID"));

                    b.Property<int>("CategoryID")
                        .HasColumnType("integer");

                    b.Property<string>("Keyword")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("ID");

                    b.HasIndex("CategoryID");

                    b.ToTable("WallPosts");
                });

            modelBuilder.Entity("Models.Drawing", b =>
                {
                    b.HasOne("Models.Player", null)
                        .WithMany("Drawings")
                        .HasForeignKey("PlayerID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Models.WallPost", null)
                        .WithMany("Drawings")
                        .HasForeignKey("WallPostID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Models.Like", b =>
                {
                    b.HasOne("Models.Comment", null)
                        .WithMany("Likes")
                        .HasForeignKey("CommentID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Models.Drawing", null)
                        .WithMany("Likes")
                        .HasForeignKey("DrawingID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Models.WallPost", b =>
                {
                    b.HasOne("Models.Category", null)
                        .WithMany("WallPosts")
                        .HasForeignKey("CategoryID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Models.Category", b =>
                {
                    b.Navigation("WallPosts");
                });

            modelBuilder.Entity("Models.Comment", b =>
                {
                    b.Navigation("Likes");
                });

            modelBuilder.Entity("Models.Drawing", b =>
                {
                    b.Navigation("Likes");
                });

            modelBuilder.Entity("Models.Player", b =>
                {
                    b.Navigation("Drawings");
                });

            modelBuilder.Entity("Models.WallPost", b =>
                {
                    b.Navigation("Drawings");
                });
#pragma warning restore 612, 618
        }
    }
}
