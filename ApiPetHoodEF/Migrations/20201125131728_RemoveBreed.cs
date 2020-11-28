using Microsoft.EntityFrameworkCore.Migrations;

namespace ApiPetHoodEF.Migrations
{
    public partial class RemoveBreed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pets_Breeds_BreedId",
                table: "Pets");

            migrationBuilder.DropColumn(
                name: "Curtidas",
                table: "Pets");

            migrationBuilder.AlterColumn<int>(
                name: "BreedId",
                table: "Pets",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Pets_Breeds_BreedId",
                table: "Pets",
                column: "BreedId",
                principalTable: "Breeds",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pets_Breeds_BreedId",
                table: "Pets");

            migrationBuilder.AlterColumn<int>(
                name: "BreedId",
                table: "Pets",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Curtidas",
                table: "Pets",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_Pets_Breeds_BreedId",
                table: "Pets",
                column: "BreedId",
                principalTable: "Breeds",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
