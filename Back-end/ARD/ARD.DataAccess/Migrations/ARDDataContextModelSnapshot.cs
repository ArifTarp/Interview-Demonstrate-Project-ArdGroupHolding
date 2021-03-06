﻿// <auto-generated />
using ARD.DataAccess.Concrete.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace ARD.DataAccess.Migrations
{
    [DbContext(typeof(ARDDataContext))]
    partial class ARDDataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.2");

            modelBuilder.Entity("ARD.Entity.Concrete.Address", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("AddressDetail")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("DistrictId")
                        .HasColumnType("int");

                    b.Property<int>("ProvinceId")
                        .HasColumnType("int");

                    b.Property<int>("StudentId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("DistrictId");

                    b.HasIndex("ProvinceId");

                    b.HasIndex("StudentId")
                        .IsUnique();

                    b.ToTable("Addresses");
                });

            modelBuilder.Entity("ARD.Entity.Concrete.District", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("provinceId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("provinceId");

                    b.HasIndex("Name", "provinceId")
                        .IsUnique()
                        .HasFilter("[Name] IS NOT NULL");

                    b.ToTable("Districts");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Yenimahalle",
                            provinceId = 1
                        },
                        new
                        {
                            Id = 2,
                            Name = "Çankaya",
                            provinceId = 1
                        },
                        new
                        {
                            Id = 3,
                            Name = "Bahçeşehir",
                            provinceId = 2
                        },
                        new
                        {
                            Id = 4,
                            Name = "Beyoğlu",
                            provinceId = 2
                        },
                        new
                        {
                            Id = 5,
                            Name = "Osmangazi",
                            provinceId = 3
                        },
                        new
                        {
                            Id = 6,
                            Name = "İnegöl",
                            provinceId = 3
                        },
                        new
                        {
                            Id = 7,
                            Name = "Selçuk",
                            provinceId = 4
                        },
                        new
                        {
                            Id = 8,
                            Name = "Seferihisar",
                            provinceId = 4
                        });
                });

            modelBuilder.Entity("ARD.Entity.Concrete.Province", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Provinces");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Ankara"
                        },
                        new
                        {
                            Id = 2,
                            Name = "İstanbul"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Bursa"
                        },
                        new
                        {
                            Id = 4,
                            Name = "İzmir"
                        });
                });

            modelBuilder.Entity("ARD.Entity.Concrete.Student", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SchoolIdentity")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Students");
                });

            modelBuilder.Entity("ARD.Entity.Concrete.Address", b =>
                {
                    b.HasOne("ARD.Entity.Concrete.District", "District")
                        .WithMany("Addresses")
                        .HasForeignKey("DistrictId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("ARD.Entity.Concrete.Province", "Province")
                        .WithMany("Addresses")
                        .HasForeignKey("ProvinceId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("ARD.Entity.Concrete.Student", "Student")
                        .WithOne("Address")
                        .HasForeignKey("ARD.Entity.Concrete.Address", "StudentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("District");

                    b.Navigation("Province");

                    b.Navigation("Student");
                });

            modelBuilder.Entity("ARD.Entity.Concrete.District", b =>
                {
                    b.HasOne("ARD.Entity.Concrete.Province", "Province")
                        .WithMany("Districts")
                        .HasForeignKey("provinceId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Province");
                });

            modelBuilder.Entity("ARD.Entity.Concrete.District", b =>
                {
                    b.Navigation("Addresses");
                });

            modelBuilder.Entity("ARD.Entity.Concrete.Province", b =>
                {
                    b.Navigation("Addresses");

                    b.Navigation("Districts");
                });

            modelBuilder.Entity("ARD.Entity.Concrete.Student", b =>
                {
                    b.Navigation("Address");
                });
#pragma warning restore 612, 618
        }
    }
}
