using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class addlocationopinion2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Opinion_Location_Locationid",
                table: "Opinion");

            migrationBuilder.DropTable(
                name: "Location");

            migrationBuilder.DropIndex(
                name: "IX_Opinion_Locationid",
                table: "Opinion");

            migrationBuilder.DropColumn(
                name: "ClientID",
                table: "Opinion");

            migrationBuilder.DropColumn(
                name: "Locationid",
                table: "Opinion");

            migrationBuilder.RenameColumn(
                name: "Content",
                table: "Opinion",
                newName: "name");

            migrationBuilder.CreateTable(
                name: "Opinions",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClientID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Locationid = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Opinions", x => x.id);
                    table.ForeignKey(
                        name: "FK_Opinions_Opinion_Locationid",
                        column: x => x.Locationid,
                        principalTable: "Opinion",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Opinions_Locationid",
                table: "Opinions",
                column: "Locationid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Opinions");

            migrationBuilder.RenameColumn(
                name: "name",
                table: "Opinion",
                newName: "Content");

            migrationBuilder.AddColumn<string>(
                name: "ClientID",
                table: "Opinion",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Locationid",
                table: "Opinion",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Location",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Location", x => x.id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Opinion_Locationid",
                table: "Opinion",
                column: "Locationid");

            migrationBuilder.AddForeignKey(
                name: "FK_Opinion_Location_Locationid",
                table: "Opinion",
                column: "Locationid",
                principalTable: "Location",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
