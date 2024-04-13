﻿// <auto-generated />
using Constructor;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Constructor.Migrations
{
    [DbContext(typeof(AppDBContext))]
    [Migration("20240413151257_First")]
    partial class First
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.18")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Constructor.Models.Client", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Clients");
                });

            modelBuilder.Entity("Constructor.Models.Deal", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Amount")
                        .HasColumnType("int");

                    b.Property<int>("Client_Id")
                        .HasColumnType("int");

                    b.Property<int>("Project_Id")
                        .HasColumnType("int");

                    b.Property<string>("Status")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("Client_Id");

                    b.HasIndex("Project_Id");

                    b.ToTable("Deals");
                });

            modelBuilder.Entity("Constructor.Models.Master", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Username")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Masters");
                });

            modelBuilder.Entity("Constructor.Models.Page", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Content")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Project_Id")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("Project_Id");

                    b.ToTable("Pages");
                });

            modelBuilder.Entity("Constructor.Models.Project", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Master_Id")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("Master_Id");

                    b.ToTable("Projects");
                });

            modelBuilder.Entity("Constructor.Models.Deal", b =>
                {
                    b.HasOne("Constructor.Models.Client", "Client")
                        .WithMany("Deals")
                        .HasForeignKey("Client_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Constructor.Models.Project", "Project")
                        .WithMany("Deals")
                        .HasForeignKey("Project_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Client");

                    b.Navigation("Project");
                });

            modelBuilder.Entity("Constructor.Models.Page", b =>
                {
                    b.HasOne("Constructor.Models.Project", "Project")
                        .WithMany("Pages")
                        .HasForeignKey("Project_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Project");
                });

            modelBuilder.Entity("Constructor.Models.Project", b =>
                {
                    b.HasOne("Constructor.Models.Master", "Master")
                        .WithMany("Projects")
                        .HasForeignKey("Master_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Master");
                });

            modelBuilder.Entity("Constructor.Models.Client", b =>
                {
                    b.Navigation("Deals");
                });

            modelBuilder.Entity("Constructor.Models.Master", b =>
                {
                    b.Navigation("Projects");
                });

            modelBuilder.Entity("Constructor.Models.Project", b =>
                {
                    b.Navigation("Deals");

                    b.Navigation("Pages");
                });
#pragma warning restore 612, 618
        }
    }
}
