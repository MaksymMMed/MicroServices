using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddUnit : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UnitId",
                table: "Issue",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Unit",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Unit", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Issue_UnitId",
                table: "Issue",
                column: "UnitId");

            migrationBuilder.AddForeignKey(
                name: "FK_Issue_Unit_UnitId",
                table: "Issue",
                column: "UnitId",
                principalTable: "Unit",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Issue_Unit_UnitId",
                table: "Issue");

            migrationBuilder.DropTable(
                name: "Unit");

            migrationBuilder.DropIndex(
                name: "IX_Issue_UnitId",
                table: "Issue");

            migrationBuilder.DropColumn(
                name: "UnitId",
                table: "Issue");
        }
    }
}
