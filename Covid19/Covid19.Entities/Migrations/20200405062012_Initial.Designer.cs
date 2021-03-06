﻿// <auto-generated />
using System;
using Covid19.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Covid19.Entities.Migrations
{
    [DbContext(typeof(RepositoryContext))]
    [Migration("20200405062012_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Covid19.Entities.Models.Graph", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("GraphId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValue(new DateTime(2020, 4, 5, 15, 20, 11, 541, DateTimeKind.Local).AddTicks(1096));

                    b.Property<string>("Kazu")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Total")
                        .HasColumnType("int");

                    b.Property<DateTime>("UpdatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValue(new DateTime(2020, 4, 5, 15, 20, 11, 547, DateTimeKind.Local).AddTicks(8042));

                    b.HasKey("Id");

                    b.ToTable("Graphs");
                });

            modelBuilder.Entity("Covid19.Entities.Models.Quarantine", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("QuarantineId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("AutoKuarentena")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValue(new DateTime(2020, 4, 5, 15, 20, 11, 549, DateTimeKind.Local).AddTicks(292));

                    b.Property<int>("KuarentenaObrigatorio")
                        .HasColumnType("int");

                    b.Property<string>("Munisipio")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PassaQuarentena")
                        .HasColumnType("int");

                    b.Property<int>("Total")
                        .HasColumnType("int");

                    b.Property<DateTime>("UpdatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValue(new DateTime(2020, 4, 5, 15, 20, 11, 549, DateTimeKind.Local).AddTicks(1043));

                    b.HasKey("Id");

                    b.ToTable("Quarantines");
                });

            modelBuilder.Entity("Covid19.Entities.Models.Setting", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("SettingId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValue(new DateTime(2020, 4, 5, 15, 20, 11, 551, DateTimeKind.Local).AddTicks(3710));

                    b.Property<string>("Group")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Key")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Type")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("UpdatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValue(new DateTime(2020, 4, 5, 15, 20, 11, 551, DateTimeKind.Local).AddTicks(4487));

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Settings");

                    b.HasData(
                        new
                        {
                            Id = new Guid("f68fae5f-7046-444b-a5a8-ac9bb2147ba9"),
                            CreatedAt = new DateTime(2020, 4, 5, 15, 20, 11, 551, DateTimeKind.Local).AddTicks(6958),
                            Group = "General",
                            Key = "site_name",
                            Name = "Site Name",
                            Type = "text",
                            UpdatedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Value = "LOREM-IPSUM"
                        },
                        new
                        {
                            Id = new Guid("1cb7550e-e97c-4c72-ad83-2d25a1bff58c"),
                            CreatedAt = new DateTime(2020, 4, 5, 15, 20, 11, 552, DateTimeKind.Local).AddTicks(3673),
                            Group = "General",
                            Key = "banner",
                            Name = "Banner Image",
                            Type = "file",
                            UpdatedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = new Guid("6fe9aacd-889a-4544-874d-1b3bcdd288d3"),
                            CreatedAt = new DateTime(2020, 4, 5, 15, 20, 11, 552, DateTimeKind.Local).AddTicks(3774),
                            Group = "General",
                            Key = "contact_address",
                            Name = "Contact address",
                            Type = "text",
                            UpdatedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Value = "Rua Delta 1, Aimutin Comoro, Dili. Timor-Leste"
                        },
                        new
                        {
                            Id = new Guid("26bfb005-f63e-47fd-a908-3fe3b2930449"),
                            CreatedAt = new DateTime(2020, 4, 5, 15, 20, 11, 552, DateTimeKind.Local).AddTicks(3796),
                            Group = "General",
                            Key = "contact_phone",
                            Name = "Contact phone",
                            Type = "text",
                            UpdatedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Value = "+(670) 331 017 9"
                        },
                        new
                        {
                            Id = new Guid("7bbceb27-5420-4d99-bb16-e02d287ca31a"),
                            CreatedAt = new DateTime(2020, 4, 5, 15, 20, 11, 552, DateTimeKind.Local).AddTicks(3802),
                            Group = "General",
                            Key = "contact_email",
                            Name = "Contact email",
                            Type = "email",
                            UpdatedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Value = "helder@chebre.net"
                        },
                        new
                        {
                            Id = new Guid("0fa5b29d-78c6-434e-bee9-8bcd716316d9"),
                            CreatedAt = new DateTime(2020, 4, 5, 15, 20, 11, 552, DateTimeKind.Local).AddTicks(3814),
                            Group = "General",
                            Key = "footer_description",
                            Name = "Footer Description",
                            Type = "textarea",
                            UpdatedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Value = "In alias aperiam. Placeat tempore facere. Officiis voluptate ipsam vel eveniet est dolor et totam porro. Perspiciatis ad omnis fugit molestiae recusandae possimus. Aut consectetur id quis. In inventore consequatur ad voluptate cupiditate debitis accusamus repellat cumque.	"
                        },
                        new
                        {
                            Id = new Guid("ba3081e6-8dd3-40f0-a1cd-606c7737c58d"),
                            CreatedAt = new DateTime(2020, 4, 5, 15, 20, 11, 552, DateTimeKind.Local).AddTicks(3819),
                            Group = "General",
                            Key = "twitter",
                            Name = "Twitter",
                            Type = "text",
                            UpdatedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Value = "#!"
                        },
                        new
                        {
                            Id = new Guid("596fbb91-cf91-4ef9-942e-50500d91b3c6"),
                            CreatedAt = new DateTime(2020, 4, 5, 15, 20, 11, 552, DateTimeKind.Local).AddTicks(3824),
                            Group = "General",
                            Key = "facebook",
                            Name = "Facebook",
                            Type = "text",
                            UpdatedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Value = "#!"
                        },
                        new
                        {
                            Id = new Guid("d7889b56-3a04-4561-a66e-57983cef0c21"),
                            CreatedAt = new DateTime(2020, 4, 5, 15, 20, 11, 552, DateTimeKind.Local).AddTicks(3887),
                            Group = "General",
                            Key = "instagram",
                            Name = "Instagram",
                            Type = "text",
                            UpdatedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Value = "#!"
                        },
                        new
                        {
                            Id = new Guid("13b85cb4-107a-4eca-b1b2-038b0195b3ec"),
                            CreatedAt = new DateTime(2020, 4, 5, 15, 20, 11, 552, DateTimeKind.Local).AddTicks(3896),
                            Group = "General",
                            Key = "linkedin",
                            Name = "LinkedIn",
                            Type = "text",
                            UpdatedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Value = "#!"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
