using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AracFilo.Migrations
{
    /// <inheritdoc />
    public partial class dEEdfdfklkkjdfGHGHg : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Mahmut_Rents_rentsRentId",
                table: "Mahmut");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Mahmut");

            migrationBuilder.RenameColumn(
                name: "rentsRentId",
                table: "Mahmut",
                newName: "RentId");

            migrationBuilder.RenameIndex(
                name: "IX_Mahmut_rentsRentId",
                table: "Mahmut",
                newName: "IX_Mahmut_RentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Mahmut_Rents_RentId",
                table: "Mahmut",
                column: "RentId",
                principalTable: "Rents",
                principalColumn: "RentId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Mahmut_Rents_RentId",
                table: "Mahmut");

            migrationBuilder.RenameColumn(
                name: "RentId",
                table: "Mahmut",
                newName: "rentsRentId");

            migrationBuilder.RenameIndex(
                name: "IX_Mahmut_RentId",
                table: "Mahmut",
                newName: "IX_Mahmut_rentsRentId");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Mahmut",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_Mahmut_Rents_rentsRentId",
                table: "Mahmut",
                column: "rentsRentId",
                principalTable: "Rents",
                principalColumn: "RentId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
