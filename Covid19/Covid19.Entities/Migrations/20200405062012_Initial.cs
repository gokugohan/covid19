using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Covid19.Entities.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Graphs",
                columns: table => new
                {
                    GraphId = table.Column<Guid>(nullable: false),
                    Kazu = table.Column<string>(nullable: true),
                    Total = table.Column<int>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false, defaultValue: new DateTime(2020, 4, 5, 15, 20, 11, 541, DateTimeKind.Local).AddTicks(1096)),
                    UpdatedAt = table.Column<DateTime>(nullable: false, defaultValue: new DateTime(2020, 4, 5, 15, 20, 11, 547, DateTimeKind.Local).AddTicks(8042))
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Graphs", x => x.GraphId);
                });

            migrationBuilder.CreateTable(
                name: "Quarantines",
                columns: table => new
                {
                    QuarantineId = table.Column<Guid>(nullable: false),
                    Munisipio = table.Column<string>(nullable: true),
                    KuarentenaObrigatorio = table.Column<int>(nullable: false),
                    AutoKuarentena = table.Column<int>(nullable: false),
                    PassaQuarentena = table.Column<int>(nullable: false),
                    Total = table.Column<int>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false, defaultValue: new DateTime(2020, 4, 5, 15, 20, 11, 549, DateTimeKind.Local).AddTicks(292)),
                    UpdatedAt = table.Column<DateTime>(nullable: false, defaultValue: new DateTime(2020, 4, 5, 15, 20, 11, 549, DateTimeKind.Local).AddTicks(1043))
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Quarantines", x => x.QuarantineId);
                });

            migrationBuilder.CreateTable(
                name: "Settings",
                columns: table => new
                {
                    SettingId = table.Column<Guid>(nullable: false),
                    Key = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Value = table.Column<string>(nullable: true),
                    Type = table.Column<string>(nullable: true),
                    Group = table.Column<string>(nullable: true),
                    CreatedAt = table.Column<DateTime>(nullable: false, defaultValue: new DateTime(2020, 4, 5, 15, 20, 11, 551, DateTimeKind.Local).AddTicks(3710)),
                    UpdatedAt = table.Column<DateTime>(nullable: false, defaultValue: new DateTime(2020, 4, 5, 15, 20, 11, 551, DateTimeKind.Local).AddTicks(4487))
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Settings", x => x.SettingId);
                });

            migrationBuilder.InsertData(
                table: "Settings",
                columns: new[] { "SettingId", "CreatedAt", "Group", "Key", "Name", "Type", "Value" },
                values: new object[,]
                {
                    { new Guid("f68fae5f-7046-444b-a5a8-ac9bb2147ba9"), new DateTime(2020, 4, 5, 15, 20, 11, 551, DateTimeKind.Local).AddTicks(6958), "General", "site_name", "Site Name", "text", "LOREM-IPSUM" },
                    { new Guid("1cb7550e-e97c-4c72-ad83-2d25a1bff58c"), new DateTime(2020, 4, 5, 15, 20, 11, 552, DateTimeKind.Local).AddTicks(3673), "General", "banner", "Banner Image", "file", null },
                    { new Guid("6fe9aacd-889a-4544-874d-1b3bcdd288d3"), new DateTime(2020, 4, 5, 15, 20, 11, 552, DateTimeKind.Local).AddTicks(3774), "General", "contact_address", "Contact address", "text", "Rua Delta 1, Aimutin Comoro, Dili. Timor-Leste" },
                    { new Guid("26bfb005-f63e-47fd-a908-3fe3b2930449"), new DateTime(2020, 4, 5, 15, 20, 11, 552, DateTimeKind.Local).AddTicks(3796), "General", "contact_phone", "Contact phone", "text", "+(670) 331 017 9" },
                    { new Guid("7bbceb27-5420-4d99-bb16-e02d287ca31a"), new DateTime(2020, 4, 5, 15, 20, 11, 552, DateTimeKind.Local).AddTicks(3802), "General", "contact_email", "Contact email", "email", "helder@chebre.net" },
                    { new Guid("0fa5b29d-78c6-434e-bee9-8bcd716316d9"), new DateTime(2020, 4, 5, 15, 20, 11, 552, DateTimeKind.Local).AddTicks(3814), "General", "footer_description", "Footer Description", "textarea", "In alias aperiam. Placeat tempore facere. Officiis voluptate ipsam vel eveniet est dolor et totam porro. Perspiciatis ad omnis fugit molestiae recusandae possimus. Aut consectetur id quis. In inventore consequatur ad voluptate cupiditate debitis accusamus repellat cumque.	" },
                    { new Guid("ba3081e6-8dd3-40f0-a1cd-606c7737c58d"), new DateTime(2020, 4, 5, 15, 20, 11, 552, DateTimeKind.Local).AddTicks(3819), "General", "twitter", "Twitter", "text", "#!" },
                    { new Guid("596fbb91-cf91-4ef9-942e-50500d91b3c6"), new DateTime(2020, 4, 5, 15, 20, 11, 552, DateTimeKind.Local).AddTicks(3824), "General", "facebook", "Facebook", "text", "#!" },
                    { new Guid("d7889b56-3a04-4561-a66e-57983cef0c21"), new DateTime(2020, 4, 5, 15, 20, 11, 552, DateTimeKind.Local).AddTicks(3887), "General", "instagram", "Instagram", "text", "#!" },
                    { new Guid("13b85cb4-107a-4eca-b1b2-038b0195b3ec"), new DateTime(2020, 4, 5, 15, 20, 11, 552, DateTimeKind.Local).AddTicks(3896), "General", "linkedin", "LinkedIn", "text", "#!" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Graphs");

            migrationBuilder.DropTable(
                name: "Quarantines");

            migrationBuilder.DropTable(
                name: "Settings");
        }
    }
}
