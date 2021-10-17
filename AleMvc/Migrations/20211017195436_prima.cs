using Microsoft.EntityFrameworkCore.Migrations;

namespace AleMvc.Migrations
{
    public partial class prima : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Utenti",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Utenti", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Lezioni",
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
                    table.PrimaryKey("PK_Lezioni", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Lezioni_Utenti_Id_Docente",
                        column: x => x.Id_Docente,
                        principalTable: "Utenti",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Lezioni_Id_Docente",
                table: "Lezioni",
                column: "Id_Docente");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Lezioni");

            migrationBuilder.DropTable(
                name: "Utenti");
        }
    }
}
