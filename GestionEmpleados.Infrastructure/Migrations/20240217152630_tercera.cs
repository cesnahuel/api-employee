using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GestionEmpleados.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class tercera : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Estado",
                table: "Employee");

            migrationBuilder.AddColumn<int>(
                name: "EstadoId",
                table: "Employee",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Status",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombre = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Status", x => x.id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Employee_EstadoId",
                table: "Employee",
                column: "EstadoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Employee_Status_EstadoId",
                table: "Employee",
                column: "EstadoId",
                principalTable: "Status",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employee_Status_EstadoId",
                table: "Employee");

            migrationBuilder.DropTable(
                name: "Status");

            migrationBuilder.DropIndex(
                name: "IX_Employee_EstadoId",
                table: "Employee");

            migrationBuilder.DropColumn(
                name: "EstadoId",
                table: "Employee");

            migrationBuilder.AddColumn<string>(
                name: "Estado",
                table: "Employee",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
