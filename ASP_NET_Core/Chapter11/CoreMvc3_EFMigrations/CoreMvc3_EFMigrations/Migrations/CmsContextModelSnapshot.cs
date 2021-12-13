﻿// <auto-generated />
using CoreMvc3_EFMigrations.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CoreMvc3_EFMigrations.Migrations
{
    [DbContext(typeof(CmsContext))]
    partial class CmsContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("CoreMvc3_EFMigrations.Models.Employee", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Department")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Mobile")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Employees");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Department = "總經理室",
                            Email = "david@gmail.com",
                            Mobile = "0935-155222",
                            Name = "David",
                            Title = "CEO"
                        },
                        new
                        {
                            Id = 2,
                            Department = "人事部",
                            Email = "mary@gmail.com",
                            Mobile = "0938-456889",
                            Name = "Mary",
                            Title = "管理師"
                        },
                        new
                        {
                            Id = 3,
                            Department = "財務部",
                            Email = "joe@gmail.com",
                            Mobile = "0925-331225",
                            Name = "Joe",
                            Title = "經理"
                        },
                        new
                        {
                            Id = 4,
                            Department = "業務部",
                            Email = "mark@gmail.com",
                            Mobile = "0935-863991",
                            Name = "Mark",
                            Title = "業務員"
                        },
                        new
                        {
                            Id = 5,
                            Department = "資訊部",
                            Email = "rose@gmail.com",
                            Mobile = "0987-335668",
                            Name = "Rose",
                            Title = "工程師"
                        });
                });

            modelBuilder.Entity("CoreMvc3_EFMigrations.Models.Register", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("City")
                        .HasColumnType("int");

                    b.Property<string>("Comment")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Commutermode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Gender")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nickname")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Terms")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.ToTable("Registers");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            City = 4,
                            Comment = "Nothing",
                            Commutermode = "1",
                            Email = "dotnetcool@gmail.com",
                            Gender = 1,
                            Name = "奚江華",
                            Nickname = "聖殿祭司",
                            Password = "myPassword*",
                            Terms = true
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
