using Microsoft.EntityFrameworkCore.Migrations;

namespace AleMvc.Migrations
{
    public partial class terza : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_nuoviutentis",
                table: "nuoviutentis");

            migrationBuilder.RenameTable(
                name: "nuoviutentis",
                newName: "Nuoviutentis");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Nuoviutentis",
                table: "Nuoviutentis",
                column: "ID");

            migrationBuilder.CreateTable(
                name: "Lezionis",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Id_lezione = table.Column<int>(type: "int", nullable: false),
                    TitoloLezione = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Docente = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Id_Docente = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lezionis", x => x.ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Lezionis");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Nuoviutentis",
                table: "Nuoviutentis");

            migrationBuilder.RenameTable(
                name: "Nuoviutentis",
                newName: "nuoviutentis");

            migrationBuilder.AddPrimaryKey(
                name: "PK_nuoviutentis",
                table: "nuoviutentis",
                column: "ID");
        }
    }
}
