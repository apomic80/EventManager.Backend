using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using EventManager.Business.Data.EF;

namespace EventManager.Business.Data.Migrations
{
    [DbContext(typeof(EventManagerDbContext))]
    [Migration("20160921170543_Speakers")]
    partial class Speakers
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.0.1")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

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
        }
    }
}
