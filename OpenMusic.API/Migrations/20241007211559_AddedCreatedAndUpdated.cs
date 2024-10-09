using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OpenMusic.API.Migrations
{
    /// <inheritdoc />
    public partial class AddedCreatedAndUpdated : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ReleaseDate",
                table: "Songs");

            migrationBuilder.DropColumn(
                name: "Created",
                table: "Playlists");

            migrationBuilder.DropColumn(
                name: "Ended",
                table: "Artists");

            migrationBuilder.DropColumn(
                name: "Started",
                table: "Artists");

            migrationBuilder.AddColumn<DateOnly>(
                name: "CreatedAt",
                table: "Songs",
                type: "date",
                nullable: false,
                defaultValue: new DateOnly(1, 1, 1));

            migrationBuilder.AddColumn<DateOnly>(
                name: "LastUpdatedAt",
                table: "Songs",
                type: "date",
                nullable: false,
                defaultValue: new DateOnly(1, 1, 1));

            migrationBuilder.AddColumn<int>(
                name: "Year",
                table: "Songs",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateOnly>(
                name: "CreatedAt",
                table: "Playlists",
                type: "date",
                nullable: false,
                defaultValue: new DateOnly(1, 1, 1));

            migrationBuilder.AddColumn<DateOnly>(
                name: "LastUpdatedAt",
                table: "Playlists",
                type: "date",
                nullable: false,
                defaultValue: new DateOnly(1, 1, 1));

            migrationBuilder.AddColumn<DateOnly>(
                name: "CreatedAt",
                table: "Artists",
                type: "date",
                nullable: false,
                defaultValue: new DateOnly(1, 1, 1));

            migrationBuilder.AddColumn<DateOnly>(
                name: "LastUpdatedAt",
                table: "Artists",
                type: "date",
                nullable: false,
                defaultValue: new DateOnly(1, 1, 1));

            migrationBuilder.AddColumn<DateOnly>(
                name: "CreatedAt",
                table: "Albums",
                type: "date",
                nullable: false,
                defaultValue: new DateOnly(1, 1, 1));

            migrationBuilder.AddColumn<DateOnly>(
                name: "LastUpdatedAt",
                table: "Albums",
                type: "date",
                nullable: false,
                defaultValue: new DateOnly(1, 1, 1));

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0017d7fe-f844-47fa-96b1-f6f3f280db0f",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "0d093ab9-577a-43e2-8b8c-9aea79077988", "AQAAAAIAAYagAAAAEFvKUB+60TUc9+nsXgLseH9HmMJ06AShQZ53pxV7yozF7/5dG8EPjrohqHZCCQIp0w==", "31bc4fa4-4ecc-4049-bc4a-5bb84196da94" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9f86d912-6254-44e6-aa64-d4da31c8a999",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "5a1980ee-fe36-44df-beda-078406a6e005", "AQAAAAIAAYagAAAAEHF/oVNdBvKw4agoGHfPC6pM5Ml4XWYHugfLdN5juB3kBjwfG92JpGtjs7BT3Vp1YA==", "34da094e-0bc2-486a-b8b2-0b9a981f7548" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ec33c752-f80d-4230-beee-2cbaccdb9a5d",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c5d72700-1c17-4366-ac31-715254aeef5b", "AQAAAAIAAYagAAAAEF8ijXQLXl4CNCGoD/xIJCff+kfXnK+WTVsbmjxykw7WevUF5SCXcHDW7jRPeRu8rg==", "26509615-ab94-4884-85cd-57dbdd85ebd5" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "Songs");

            migrationBuilder.DropColumn(
                name: "LastUpdatedAt",
                table: "Songs");

            migrationBuilder.DropColumn(
                name: "Year",
                table: "Songs");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "Playlists");

            migrationBuilder.DropColumn(
                name: "LastUpdatedAt",
                table: "Playlists");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "Artists");

            migrationBuilder.DropColumn(
                name: "LastUpdatedAt",
                table: "Artists");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "Albums");

            migrationBuilder.DropColumn(
                name: "LastUpdatedAt",
                table: "Albums");

            migrationBuilder.AddColumn<DateOnly>(
                name: "ReleaseDate",
                table: "Songs",
                type: "date",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Created",
                table: "Playlists",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "Ended",
                table: "Artists",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "Started",
                table: "Artists",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0017d7fe-f844-47fa-96b1-f6f3f280db0f",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e73ebfa6-6ce1-48a2-a59c-53af5bdd6581", "AQAAAAIAAYagAAAAEH4Eao3R7rMJSacXU220fk5rOdFlSH9kKnnyIWVB0/wWNrMhZOaXzqx5ufu580RQog==", "a95a9a40-dcf8-410f-86c1-e7aa58b0682a" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9f86d912-6254-44e6-aa64-d4da31c8a999",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "02a028ec-f1b6-4495-92d9-ffd690e7c1dd", "AQAAAAIAAYagAAAAEHmB7/SF/uLwj9nLqmKCo/IHiHQ7D/FLcIMfOwaf6Dsq3STxo1+Wa5f2GCHfFDxuog==", "8543a11b-d3ad-410c-9606-2746b9e49a59" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ec33c752-f80d-4230-beee-2cbaccdb9a5d",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "fe0e6f57-7bc7-4bf7-a462-c3c8ab5d4cd0", "AQAAAAIAAYagAAAAEMq+knlAr2cCF8MELZB41lYV0nzQ3l2gbSiG9i8805ik4Db2Ne6tZZ1i/oNE9H/frA==", "fbab741d-6649-4c55-ae5c-b0c1825a3b5d" });
        }
    }
}
