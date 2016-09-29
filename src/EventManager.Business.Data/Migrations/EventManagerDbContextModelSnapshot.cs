﻿using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using EventManager.Business.Data.EF;

namespace EventManager.Business.Data.Migrations
{
    [DbContext(typeof(EventManagerDbContext))]
    partial class EventManagerDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.0.1")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("EventManager.Business.Domain.AgendaItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description")
                        .HasAnnotation("MaxLength", 500);

                    b.Property<string>("EndTime")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 5);

                    b.Property<int>("EventId");

                    b.Property<int>("Order");

                    b.Property<int?>("SpeakerId");

                    b.Property<string>("StartTime")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 5);

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 200);

                    b.HasKey("Id");

                    b.HasIndex("EventId");

                    b.HasIndex("SpeakerId");

                    b.ToTable("Agenda");
                });

            modelBuilder.Entity("EventManager.Business.Domain.Event", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description");

                    b.Property<DateTime>("EndDate");

                    b.Property<string>("Location")
                        .HasAnnotation("MaxLength", 500);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 200);

                    b.Property<DateTime>("StartDate");

                    b.Property<bool>("Visible");

                    b.HasKey("Id");

                    b.ToTable("Events");
                });

            modelBuilder.Entity("EventManager.Business.Domain.Speaker", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Biography")
                        .HasAnnotation("MaxLength", 500);

                    b.Property<string>("Facebook")
                        .HasAnnotation("MaxLength", 255);

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 50);

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 50);

                    b.Property<string>("Linkedin")
                        .HasAnnotation("MaxLength", 255);

                    b.Property<string>("Photo")
                        .HasAnnotation("MaxLength", 255);

                    b.Property<string>("Twitter")
                        .HasAnnotation("MaxLength", 255);

                    b.Property<string>("WebSite")
                        .HasAnnotation("MaxLength", 255);

                    b.HasKey("Id");

                    b.ToTable("Speakers");
                });

            modelBuilder.Entity("EventManager.Business.Domain.AgendaItem", b =>
                {
                    b.HasOne("EventManager.Business.Domain.Event", "Event")
                        .WithMany()
                        .HasForeignKey("EventId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("EventManager.Business.Domain.Speaker", "Speaker")
                        .WithMany()
                        .HasForeignKey("SpeakerId");
                });
        }
    }
}