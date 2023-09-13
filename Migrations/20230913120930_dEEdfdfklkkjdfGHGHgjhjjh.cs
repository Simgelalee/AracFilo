using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AracFilo.Migrations
{
    /// <inheritdoc />
    public partial class dEEdfdfklkkjdfGHGHgjhjjh : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AracId",
                table: "Mahmut",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "AracId1",
                table: "Araclar",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Mahmut_AracId",
                table: "Mahmut",
                column: "AracId");

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

            migrationBuilder.AddForeignKey(
                name: "FK_Mahmut_Araclar_AracId",
                table: "Mahmut",
                column: "AracId",
                principalTable: "Araclar",
                principalColumn: "AracId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Araclar_Araclar_AracId1",
                table: "Araclar");

            migrationBuilder.DropForeignKey(
                name: "FK_Mahmut_Araclar_AracId",
                table: "Mahmut");

            migrationBuilder.DropIndex(
                name: "IX_Mahmut_AracId",
                table: "Mahmut");

            migrationBuilder.DropIndex(
                name: "IX_Araclar_AracId1",
                table: "Araclar");

            migrationBuilder.DropColumn(
                name: "AracId",
                table: "Mahmut");

            migrationBuilder.DropColumn(
                name: "AracId1",
                table: "Araclar");
        }
    }
}
