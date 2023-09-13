using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AracFilo.Migrations
{
    /// <inheritdoc />
    public partial class dEEdfdfklkkjdfGHGHgjhjjhhj : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Araclar_Araclar_AracId1",
                table: "Araclar");

            migrationBuilder.DropIndex(
                name: "IX_Araclar_AracId1",
                table: "Araclar");

            migrationBuilder.DropColumn(
                name: "AracId1",
                table: "Araclar");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AracId1",
                table: "Araclar",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Araclar_AracId1",
                table: "Araclar",
                column: "AracId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Araclar_Araclar_AracId1",
                table: "Araclar",
                column: "AracId1",
                principalTable: "Araclar",
                principalColumn: "AracId");
        }
    }
}
