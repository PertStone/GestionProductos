using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GestionProductos.Infraestructure.Migrations
{
    public partial class ini : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Producto",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CodigoProducto = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DescripcionProducto = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EstadoProducto = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FechaFabricacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaValidez = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CodigoProveedor = table.Column<int>(type: "int", nullable: false),
                    DescripcionProveedor = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TelefonoProveedor = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Producto", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Producto");
        }
    }
}
