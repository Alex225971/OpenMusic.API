using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OpenMusic.API.Migrations
{
    /// <inheritdoc />
    public partial class ReworkedPlaylistEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SongId",
                table: "Playlists",
                type: "int",
                nullable: true);

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

            migrationBuilder.CreateIndex(
                name: "IX_Playlists_SongId",
                table: "Playlists",
                column: "SongId");

            migrationBuilder.AddForeignKey(
                name: "FK_Playlists_Songs_SongId",
                table: "Playlists",
                column: "SongId",
                principalTable: "Songs",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Playlists_Songs_SongId",
                table: "Playlists");

            migrationBuilder.DropIndex(
                name: "IX_Playlists_SongId",
                table: "Playlists");

            migrationBuilder.DropColumn(
                name: "SongId",
                table: "Playlists");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0017d7fe-f844-47fa-96b1-f6f3f280db0f",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "649a89ed-efd3-49a0-9be1-ddaafe9d22af", "AQAAAAIAAYagAAAAEO0vb8tCK3E2YonwkNKuKqWYmlKLcE5eSTTMBnRMQy7/zRL390DawrL48aSec1+Ilg==", "9b43d9ea-1f03-4427-a8df-eff616b51755" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9f86d912-6254-44e6-aa64-d4da31c8a999",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c1056b50-558f-4424-b208-48d50e2c22e3", "AQAAAAIAAYagAAAAEEatGHoMO3W56+IIja7z3MDMZvUiLlxHq42elPHYXoH6SDYw/ftNzez97ZENTB5HLA==", "3e5d25f9-351e-4e1c-8622-634b3ecaf6c2" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ec33c752-f80d-4230-beee-2cbaccdb9a5d",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f80a0ae6-3222-4c42-8289-4a5b930bc1d4", "AQAAAAIAAYagAAAAEHSOiuPTHQOe3qSZGMbsvp7lcuY+QbiHLevdSACCwyF0k32w5zSOCX4bH5bd/aBuSg==", "6b6b8f7b-6c5c-49d3-936a-09481852737a" });
        }
    }
}
