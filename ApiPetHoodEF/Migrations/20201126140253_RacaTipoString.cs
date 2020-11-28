using Microsoft.EntityFrameworkCore.Migrations;

namespace ApiPetHoodEF.Migrations
{
    public partial class RacaTipoString : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Raca",
                table: "Pets",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Raca",
                table: "Pets");
        }
    }
}
