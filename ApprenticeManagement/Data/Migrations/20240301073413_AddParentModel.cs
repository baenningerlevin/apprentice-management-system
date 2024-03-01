using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApprenticeManagement.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddParentModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Parents",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Parents", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Apprentice_Parents",
                columns: table => new
                {
                    ParentId = table.Column<int>(type: "int", nullable: false),
                    ApprenticeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Apprentice_Parents", x => new { x.ParentId, x.ApprenticeId });
                    table.ForeignKey(
                        name: "FK_Apprentice_Parents_Apprentices_ApprenticeId",
                        column: x => x.ApprenticeId,
                        principalTable: "Apprentices",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Apprentice_Parents_Parents_ParentId",
                        column: x => x.ParentId,
                        principalTable: "Parents",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Apprentice_Parents_ApprenticeId",
                table: "Apprentice_Parents",
                column: "ApprenticeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Apprentice_Parents");

            migrationBuilder.DropTable(
                name: "Parents");
        }
    }
}
