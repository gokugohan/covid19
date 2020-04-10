using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Covid19.Entities.Migrations
{
    public partial class RemoveTotalQuarantine : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Settings",
                keyColumn: "SettingId",
                keyValue: new Guid("0fa5b29d-78c6-434e-bee9-8bcd716316d9"));

            migrationBuilder.DeleteData(
                table: "Settings",
                keyColumn: "SettingId",
                keyValue: new Guid("13b85cb4-107a-4eca-b1b2-038b0195b3ec"));

            migrationBuilder.DeleteData(
                table: "Settings",
                keyColumn: "SettingId",
                keyValue: new Guid("1cb7550e-e97c-4c72-ad83-2d25a1bff58c"));

            migrationBuilder.DeleteData(
                table: "Settings",
                keyColumn: "SettingId",
                keyValue: new Guid("26bfb005-f63e-47fd-a908-3fe3b2930449"));

            migrationBuilder.DeleteData(
                table: "Settings",
                keyColumn: "SettingId",
                keyValue: new Guid("596fbb91-cf91-4ef9-942e-50500d91b3c6"));

            migrationBuilder.DeleteData(
                table: "Settings",
                keyColumn: "SettingId",
                keyValue: new Guid("6fe9aacd-889a-4544-874d-1b3bcdd288d3"));

            migrationBuilder.DeleteData(
                table: "Settings",
                keyColumn: "SettingId",
                keyValue: new Guid("7bbceb27-5420-4d99-bb16-e02d287ca31a"));

            migrationBuilder.DeleteData(
                table: "Settings",
                keyColumn: "SettingId",
                keyValue: new Guid("ba3081e6-8dd3-40f0-a1cd-606c7737c58d"));

            migrationBuilder.DeleteData(
                table: "Settings",
                keyColumn: "SettingId",
                keyValue: new Guid("d7889b56-3a04-4561-a66e-57983cef0c21"));

            migrationBuilder.DeleteData(
                table: "Settings",
                keyColumn: "SettingId",
                keyValue: new Guid("f68fae5f-7046-444b-a5a8-ac9bb2147ba9"));

            migrationBuilder.DropColumn(
                name: "Total",
                table: "Quarantines");

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "Settings",
                nullable: false,
                defaultValue: new DateTime(2020, 4, 5, 21, 50, 12, 867, DateTimeKind.Local).AddTicks(2102),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2020, 4, 5, 15, 20, 11, 551, DateTimeKind.Local).AddTicks(4487));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Settings",
                nullable: false,
                defaultValue: new DateTime(2020, 4, 5, 21, 50, 12, 867, DateTimeKind.Local).AddTicks(814),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2020, 4, 5, 15, 20, 11, 551, DateTimeKind.Local).AddTicks(3710));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "Quarantines",
                nullable: false,
                defaultValue: new DateTime(2020, 4, 5, 21, 50, 12, 863, DateTimeKind.Local).AddTicks(9209),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2020, 4, 5, 15, 20, 11, 549, DateTimeKind.Local).AddTicks(1043));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Quarantines",
                nullable: false,
                defaultValue: new DateTime(2020, 4, 5, 21, 50, 12, 863, DateTimeKind.Local).AddTicks(8325),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2020, 4, 5, 15, 20, 11, 549, DateTimeKind.Local).AddTicks(292));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "Graphs",
                nullable: false,
                defaultValue: new DateTime(2020, 4, 5, 21, 50, 12, 862, DateTimeKind.Local).AddTicks(5625),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2020, 4, 5, 15, 20, 11, 547, DateTimeKind.Local).AddTicks(8042));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Graphs",
                nullable: false,
                defaultValue: new DateTime(2020, 4, 5, 21, 50, 12, 852, DateTimeKind.Local).AddTicks(6618),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2020, 4, 5, 15, 20, 11, 541, DateTimeKind.Local).AddTicks(1096));

            migrationBuilder.InsertData(
                table: "Settings",
                columns: new[] { "SettingId", "CreatedAt", "Group", "Key", "Name", "Type", "Value" },
                values: new object[,]
                {
                    { new Guid("1b115ba1-fc7d-4205-acc0-6ec229c236d3"), new DateTime(2020, 4, 5, 21, 50, 12, 867, DateTimeKind.Local).AddTicks(5712), "General", "site_name", "Site Name", "text", "LOREM-IPSUM" },
                    { new Guid("89517199-a73b-4b6a-ab73-8e471dde804d"), new DateTime(2020, 4, 5, 21, 50, 12, 868, DateTimeKind.Local).AddTicks(5692), "General", "banner", "Banner Image", "file", null },
                    { new Guid("e966513d-aa31-4795-991a-6806d63d0c0f"), new DateTime(2020, 4, 5, 21, 50, 12, 868, DateTimeKind.Local).AddTicks(5816), "General", "contact_address", "Contact address", "text", "Rua Delta 1, Aimutin Comoro, Dili. Timor-Leste" },
                    { new Guid("b4e5bf4e-597d-4fb7-94e4-00a65009e4d2"), new DateTime(2020, 4, 5, 21, 50, 12, 868, DateTimeKind.Local).AddTicks(5851), "General", "contact_phone", "Contact phone", "text", "+(670) 331 017 9" },
                    { new Guid("1e401920-ce4d-4167-92ef-d7f5400c60ee"), new DateTime(2020, 4, 5, 21, 50, 12, 868, DateTimeKind.Local).AddTicks(5858), "General", "contact_email", "Contact email", "email", "helder@chebre.net" },
                    { new Guid("fdf65263-ea66-45a7-b732-638a36998170"), new DateTime(2020, 4, 5, 21, 50, 12, 868, DateTimeKind.Local).AddTicks(5872), "General", "footer_description", "Footer Description", "textarea", "In alias aperiam. Placeat tempore facere. Officiis voluptate ipsam vel eveniet est dolor et totam porro. Perspiciatis ad omnis fugit molestiae recusandae possimus. Aut consectetur id quis. In inventore consequatur ad voluptate cupiditate debitis accusamus repellat cumque.	" },
                    { new Guid("a3fe951c-7178-4626-84ac-d2d948662089"), new DateTime(2020, 4, 5, 21, 50, 12, 868, DateTimeKind.Local).AddTicks(5878), "General", "twitter", "Twitter", "text", "#!" },
                    { new Guid("7fe8e36c-c1c4-4a77-af9a-868570a49107"), new DateTime(2020, 4, 5, 21, 50, 12, 868, DateTimeKind.Local).AddTicks(5942), "General", "facebook", "Facebook", "text", "#!" },
                    { new Guid("04871f27-a277-4672-aa23-8ba40c2957e7"), new DateTime(2020, 4, 5, 21, 50, 12, 868, DateTimeKind.Local).AddTicks(5949), "General", "instagram", "Instagram", "text", "#!" },
                    { new Guid("53ada9a5-fb30-4d3e-a464-8bb974510681"), new DateTime(2020, 4, 5, 21, 50, 12, 868, DateTimeKind.Local).AddTicks(5958), "General", "linkedin", "LinkedIn", "text", "#!" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Settings",
                keyColumn: "SettingId",
                keyValue: new Guid("04871f27-a277-4672-aa23-8ba40c2957e7"));

            migrationBuilder.DeleteData(
                table: "Settings",
                keyColumn: "SettingId",
                keyValue: new Guid("1b115ba1-fc7d-4205-acc0-6ec229c236d3"));

            migrationBuilder.DeleteData(
                table: "Settings",
                keyColumn: "SettingId",
                keyValue: new Guid("1e401920-ce4d-4167-92ef-d7f5400c60ee"));

            migrationBuilder.DeleteData(
                table: "Settings",
                keyColumn: "SettingId",
                keyValue: new Guid("53ada9a5-fb30-4d3e-a464-8bb974510681"));

            migrationBuilder.DeleteData(
                table: "Settings",
                keyColumn: "SettingId",
                keyValue: new Guid("7fe8e36c-c1c4-4a77-af9a-868570a49107"));

            migrationBuilder.DeleteData(
                table: "Settings",
                keyColumn: "SettingId",
                keyValue: new Guid("89517199-a73b-4b6a-ab73-8e471dde804d"));

            migrationBuilder.DeleteData(
                table: "Settings",
                keyColumn: "SettingId",
                keyValue: new Guid("a3fe951c-7178-4626-84ac-d2d948662089"));

            migrationBuilder.DeleteData(
                table: "Settings",
                keyColumn: "SettingId",
                keyValue: new Guid("b4e5bf4e-597d-4fb7-94e4-00a65009e4d2"));

            migrationBuilder.DeleteData(
                table: "Settings",
                keyColumn: "SettingId",
                keyValue: new Guid("e966513d-aa31-4795-991a-6806d63d0c0f"));

            migrationBuilder.DeleteData(
                table: "Settings",
                keyColumn: "SettingId",
                keyValue: new Guid("fdf65263-ea66-45a7-b732-638a36998170"));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "Settings",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2020, 4, 5, 15, 20, 11, 551, DateTimeKind.Local).AddTicks(4487),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2020, 4, 5, 21, 50, 12, 867, DateTimeKind.Local).AddTicks(2102));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Settings",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2020, 4, 5, 15, 20, 11, 551, DateTimeKind.Local).AddTicks(3710),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2020, 4, 5, 21, 50, 12, 867, DateTimeKind.Local).AddTicks(814));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "Quarantines",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2020, 4, 5, 15, 20, 11, 549, DateTimeKind.Local).AddTicks(1043),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2020, 4, 5, 21, 50, 12, 863, DateTimeKind.Local).AddTicks(9209));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Quarantines",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2020, 4, 5, 15, 20, 11, 549, DateTimeKind.Local).AddTicks(292),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2020, 4, 5, 21, 50, 12, 863, DateTimeKind.Local).AddTicks(8325));

            migrationBuilder.AddColumn<int>(
                name: "Total",
                table: "Quarantines",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "Graphs",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2020, 4, 5, 15, 20, 11, 547, DateTimeKind.Local).AddTicks(8042),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2020, 4, 5, 21, 50, 12, 862, DateTimeKind.Local).AddTicks(5625));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Graphs",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2020, 4, 5, 15, 20, 11, 541, DateTimeKind.Local).AddTicks(1096),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2020, 4, 5, 21, 50, 12, 852, DateTimeKind.Local).AddTicks(6618));

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
    }
}
