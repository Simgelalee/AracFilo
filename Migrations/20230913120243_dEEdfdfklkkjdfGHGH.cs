using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AracFilo.Migrations
{
    /// <inheritdoc />
    public partial class dEEdfdfklkkjdfGHGH : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Mahmut_Rents_rentsId",
                table: "Mahmut");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Rents",
                newName: "RentId");

            migrationBuilder.RenameColumn(
                name: "rentsId",
                table: "Mahmut",
                newName: "rentsRentId");

            migrationBuilder.RenameIndex(
                name: "IX_Mahmut_rentsId",
                table: "Mahmut",
                newName: "IX_Mahmut_rentsRentId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Araclar",
                newName: "AracId");

            migrationBuilder.AddForeignKey(
                name: "FK_Mahmut_Rents_rentsRentId",
                table: "Mahmut",
                column: "rentsRentId",
                principalTable: "Rents",
                principalColumn: "RentId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Mahmut_Rents_rentsRentId",
                table: "Mahmut");

            migrationBuilder.RenameColumn(
                name: "RentId",
                table: "Rents",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "rentsRentId",
                table: "Mahmut",
                newName: "rentsId");

            migrationBuilder.RenameIndex(
                name: "IX_Mahmut_rentsRentId",
                table: "Mahmut",
                newName: "IX_Mahmut_rentsId");

            migrationBuilder.RenameColumn(
                name: "AracId",
                table: "Araclar",
                newName: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Mahmut_Rents_rentsId",
                table: "Mahmut",
                column: "rentsId",
                principalTable: "Rents",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
