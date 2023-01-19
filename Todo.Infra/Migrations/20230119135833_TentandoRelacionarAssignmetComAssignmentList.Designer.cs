﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Todo.Infra.Context;

#nullable disable

namespace Todo.Infra.Migrations
{
    [DbContext(typeof(TodoDbContext))]
    [Migration("20230119135833_TentandoRelacionarAssignmetComAssignmentList")]
    partial class TentandoRelacionarAssignmetComAssignmentList
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("Todo.Domain.Entities.Assignment", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    b.Property<long?>("AssignmentListId")
                        .HasColumnType("bigint");

                    b.Property<bool>("Concluded")
                        .HasColumnType("tinyint(1)");

                    b.Property<DateTime>("ConcluedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("DeadLine")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<long>("UserId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("AssignmentListId");

                    b.HasIndex("UserId");

                    b.ToTable("Assignment");
                });

            modelBuilder.Entity("Todo.Domain.Entities.AssignmentList", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<long>("UserId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AssignmentList");
                });

            modelBuilder.Entity("Todo.Domain.Entities.User", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("VARCHAR(100)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("VARCHAR(100)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("VARCHAR(100)");

                    b.HasKey("Id");

                    b.ToTable("User", (string)null);
                });

            modelBuilder.Entity("Todo.Domain.Entities.Assignment", b =>
                {
                    b.HasOne("Todo.Domain.Entities.AssignmentList", null)
                        .WithMany("Assignments")
                        .HasForeignKey("AssignmentListId");

                    b.HasOne("Todo.Domain.Entities.User", null)
                        .WithMany("Assignments")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Todo.Domain.Entities.AssignmentList", b =>
                {
                    b.HasOne("Todo.Domain.Entities.User", null)
                        .WithMany("AssignmentLists")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Todo.Domain.Entities.AssignmentList", b =>
                {
                    b.Navigation("Assignments");
                });

            modelBuilder.Entity("Todo.Domain.Entities.User", b =>
                {
                    b.Navigation("AssignmentLists");

                    b.Navigation("Assignments");
                });
#pragma warning restore 612, 618
        }
    }
}
