﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using StoreServices.Api.Author.Data;

#nullable disable

namespace StoreServices.Api.Author.Migrations
{
    [DbContext(typeof(ContextAuthor))]
    [Migration("20240708235621_Tables_Author_AcademicDegree")]
    partial class Tables_Author_AcademicDegree
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("StoreServices.Api.Author.Model.AcademicDegree", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("AcademicCenter")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("AcademicDegreeGuid")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("AuthorId")
                        .HasColumnType("integer");

                    b.Property<DateTime?>("GraduationDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("Name")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("AuthorId");

                    b.ToTable("AcademicDegree");
                });

            modelBuilder.Entity("StoreServices.Api.Author.Model.AuthorBook", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Alias")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("AuthorGuid")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime?>("DateBirth")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Authors");
                });

            modelBuilder.Entity("StoreServices.Api.Author.Model.AcademicDegree", b =>
                {
                    b.HasOne("StoreServices.Api.Author.Model.AuthorBook", "Author")
                        .WithMany("ListAcademicDegree")
                        .HasForeignKey("AuthorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Author");
                });

            modelBuilder.Entity("StoreServices.Api.Author.Model.AuthorBook", b =>
                {
                    b.Navigation("ListAcademicDegree");
                });
#pragma warning restore 612, 618
        }
    }
}
