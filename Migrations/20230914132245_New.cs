using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AracFilo.Migrations
{
    /// <inheritdoc />
    public partial class New : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ResimUrl",
                table: "Araclar");

            migrationBuilder.AddColumn<bool>(
                name: "Status",
                table: "Rents",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status",
                table: "Rents");

            migrationBuilder.AddColumn<string>(
                name: "ResimUrl",
                table: "Araclar",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
