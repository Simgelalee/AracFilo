using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AracFilo.Migrations
{
    /// <inheritdoc />
    public partial class deneme : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Mahmut_Rents_RentId",
                table: "Mahmut");

            migrationBuilder.DropIndex(
                name: "IX_Mahmut_RentId",
                table: "Mahmut");

            migrationBuilder.DropColumn(
                name: "RentId",
                table: "Mahmut");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "Rents",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Rents_UserId",
                table: "Rents",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Rents_Mahmut_UserId",
                table: "Rents",
                column: "UserId",
                principalTable: "Mahmut",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Rents_Mahmut_UserId",
                table: "Rents");

            migrationBuilder.DropIndex(
                name: "IX_Rents_UserId",
                table: "Rents");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Rents",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "RentId",
                table: "Mahmut",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Mahmut_RentId",
                table: "Mahmut",
                column: "RentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Mahmut_Rents_RentId",
                table: "Mahmut",
                column: "RentId",
                principalTable: "Rents",
                principalColumn: "RentId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
