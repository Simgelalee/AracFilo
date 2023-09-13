using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AracFilo.Migrations
{
    /// <inheritdoc />
    public partial class dEEdfdfklkkjdfGHGHgjhjjhhjklklkl : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Mahmut_Araclar_AracId",
                table: "Mahmut");

            migrationBuilder.DropIndex(
                name: "IX_Mahmut_AracId",
                table: "Mahmut");

            migrationBuilder.DropColumn(
                name: "AracId",
                table: "Mahmut");

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Araclar",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Araclar_UserId",
                table: "Araclar",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Araclar_Mahmut_UserId",
                table: "Araclar",
                column: "UserId",
                principalTable: "Mahmut",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Araclar_Mahmut_UserId",
                table: "Araclar");

            migrationBuilder.DropIndex(
                name: "IX_Araclar_UserId",
                table: "Araclar");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Araclar");

            migrationBuilder.AddColumn<int>(
                name: "AracId",
                table: "Mahmut",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Mahmut_AracId",
                table: "Mahmut",
                column: "AracId");

            migrationBuilder.AddForeignKey(
                name: "FK_Mahmut_Araclar_AracId",
                table: "Mahmut",
                column: "AracId",
                principalTable: "Araclar",
                principalColumn: "AracId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
