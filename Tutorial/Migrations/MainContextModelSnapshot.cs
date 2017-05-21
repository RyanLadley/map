using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Tutorial.Models.Context;

namespace Tutorial.Migrations
{
    [DbContext(typeof(MainContext))]
    partial class MainContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.1")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Tutorial.Models.Entities.Location", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<float>("Latitude");

                    b.Property<float>("Longitude");

                    b.Property<string>("Name");

                    b.Property<long>("RegionId");

                    b.Property<string>("Thumbnail");

                    b.HasKey("Id");

                    b.HasIndex("RegionId");

                    b.ToTable("Locations");
                });

            modelBuilder.Entity("Tutorial.Models.Entities.Region", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<float>("Latitude");

                    b.Property<float>("Longitude");

                    b.Property<string>("Name");

                    b.Property<string>("StateId");

                    b.HasKey("Id");

                    b.HasIndex("StateId");

                    b.ToTable("Regions");
                });

            modelBuilder.Entity("Tutorial.Models.Entities.State", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("States");
                });

            modelBuilder.Entity("Tutorial.Models.Entities.Location", b =>
                {
                    b.HasOne("Tutorial.Models.Entities.Region", "Region")
                        .WithMany("Locations")
                        .HasForeignKey("RegionId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Tutorial.Models.Entities.Region", b =>
                {
                    b.HasOne("Tutorial.Models.Entities.State", "State")
                        .WithMany("Regions")
                        .HasForeignKey("StateId");
                });
        }
    }
}
