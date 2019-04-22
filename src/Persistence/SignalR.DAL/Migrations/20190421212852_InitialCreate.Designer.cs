﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SignalR.DAL;

namespace SignalR.DAL.Migrations
{
    [DbContext(typeof(SignalRContext))]
    [Migration("20190421212852_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.4-servicing-10062")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("SignalR.Entities.Area", b =>
                {
                    b.Property<int>("AreaID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasMaxLength(30);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(8000);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(60);

                    b.HasKey("AreaID");

                    b.ToTable("Areas");
                });

            modelBuilder.Entity("SignalR.Entities.Comment", b =>
                {
                    b.Property<int>("CommentID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CommentTypeID");

                    b.Property<DateTime>("CreationDate")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("GETDATE()");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(8000);

                    b.Property<DateTime>("ModifDate")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("GETDATE()");

                    b.Property<int>("RequestID");

                    b.Property<int>("UserID");

                    b.HasKey("CommentID");

                    b.HasIndex("CommentTypeID");

                    b.HasIndex("RequestID");

                    b.HasIndex("UserID");

                    b.ToTable("Comments");
                });

            modelBuilder.Entity("SignalR.Entities.CommentType", b =>
                {
                    b.Property<int>("CommentTypeID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(400);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(120);

                    b.HasKey("CommentTypeID");

                    b.ToTable("CommentType");
                });

            modelBuilder.Entity("SignalR.Entities.File", b =>
                {
                    b.Property<int>("FileID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Extension")
                        .IsRequired()
                        .HasMaxLength(3);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(120);

                    b.Property<string>("Path")
                        .IsRequired()
                        .HasMaxLength(600);

                    b.Property<int>("RequestID");

                    b.Property<DateTime>("UploadDate")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("GETDATE()");

                    b.HasKey("FileID");

                    b.HasIndex("RequestID");

                    b.ToTable("Files");
                });

            modelBuilder.Entity("SignalR.Entities.Request", b =>
                {
                    b.Property<int>("RequestID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AreaID");

                    b.Property<DateTime>("CreationDate")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("GETDATE()");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(8000);

                    b.Property<string>("InternalCode")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<int>("RequestTypeID");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(120);

                    b.Property<int>("UserID");

                    b.HasKey("RequestID");

                    b.HasIndex("AreaID");

                    b.HasIndex("RequestTypeID");

                    b.HasIndex("UserID");

                    b.ToTable("Requests");
                });

            modelBuilder.Entity("SignalR.Entities.RequestType", b =>
                {
                    b.Property<int>("RequestTypeID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(8000);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(120);

                    b.HasKey("RequestTypeID");

                    b.ToTable("RequestTypes");
                });

            modelBuilder.Entity("SignalR.Entities.User", b =>
                {
                    b.Property<int>("UserID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasMaxLength(30);

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(60);

                    b.Property<decimal>("LastName")
                        .HasMaxLength(60);

                    b.HasKey("UserID");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("SignalR.Entities.Comment", b =>
                {
                    b.HasOne("SignalR.Entities.CommentType", "CommentType")
                        .WithMany("Comments")
                        .HasForeignKey("CommentTypeID")
                        .HasConstraintName("FK_COMMENT_COMMENTTYPE_01")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("SignalR.Entities.Request", "Request")
                        .WithMany("Comments")
                        .HasForeignKey("RequestID")
                        .HasConstraintName("FK_COMMENT_REQUEST_01")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("SignalR.Entities.User", "User")
                        .WithMany("Comments")
                        .HasForeignKey("UserID")
                        .HasConstraintName("FK_COMMENT_USER_01")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("SignalR.Entities.File", b =>
                {
                    b.HasOne("SignalR.Entities.Request", "Request")
                        .WithMany("Files")
                        .HasForeignKey("RequestID")
                        .HasConstraintName("FK_REQUEST_FILE_01")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("SignalR.Entities.Request", b =>
                {
                    b.HasOne("SignalR.Entities.Area", "Area")
                        .WithMany("Requests")
                        .HasForeignKey("AreaID")
                        .HasConstraintName("FK_REQUEST_AREA_01")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("SignalR.Entities.RequestType", "RequestType")
                        .WithMany("Requests")
                        .HasForeignKey("RequestTypeID")
                        .HasConstraintName("FK_REQUEST_REQUESTTYPE_01")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("SignalR.Entities.User", "User")
                        .WithMany("Requests")
                        .HasForeignKey("UserID")
                        .HasConstraintName("FK_REQUEST_USER_01")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}