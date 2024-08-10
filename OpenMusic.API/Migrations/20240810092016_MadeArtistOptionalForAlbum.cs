using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OpenMusic.API.Migrations
{
    /// <inheritdoc />
    public partial class MadeArtistOptionalForAlbum : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "ArtistId",
                table: "Albums",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0017d7fe-f844-47fa-96b1-f6f3f280db0f",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "8d120153-dff5-4614-9d3b-029577074e67", "AQAAAAIAAYagAAAAENwzkZuBtTMfxrKg+TeHuNTZw9ZQAWzgX9PPCOvNwiGZyTfiRfK2J3n7/1KmdjA5DQ==", "1fc3b37a-d3f5-45cc-9b01-2a4bcfa46c51" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9f86d912-6254-44e6-aa64-d4da31c8a999",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "6fc0f174-5f5a-410b-a0e8-3bbc088d4e47", "AQAAAAIAAYagAAAAEPhoi/6SGZA1FHkKRIlNtrS2yVl4lRUOajCmZI+jqkJyPJE7twiEJJ1O297qFyoy5Q==", "68fc1b9c-44b7-440c-930a-23a5942c1667" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "ArtistId",
                table: "Albums",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0017d7fe-f844-47fa-96b1-f6f3f280db0f",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "495c3340-1474-4e8e-9f15-87d16ebea91e", "AQAAAAIAAYagAAAAEBl/lW/HLE0u8OsGumsIAXZVG/+5FjXfD7RI054QO335y4imXt6M1XBpltWReSDPlA==", "2f4e8edb-f4bf-4b06-941b-26c92e045a81" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9f86d912-6254-44e6-aa64-d4da31c8a999",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "9d133d8e-cc89-46b8-9c8c-a0aaa94e74e5", "AQAAAAIAAYagAAAAEE0QUhzE7HOT6SF3WdLAJxwRhJuujO0GaTexWQB5N/c0D4lAxHqxpUm1MI54j5cMRQ==", "4d3b93d4-f509-478d-ab51-a586c16c57bc" });
        }
    }
}
