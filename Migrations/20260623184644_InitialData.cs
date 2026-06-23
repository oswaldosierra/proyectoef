using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace proyectoef.Migrations
{
    /// <inheritdoc />
    public partial class InitialData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Descipcion",
                table: "tarea",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "Descripcion",
                table: "categoria",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.InsertData(
                table: "categoria",
                columns: new[] { "CategoriaId", "Descripcion", "Nombre", "Peso" },
                values: new object[,]
                {
                    { new Guid("42bef976-8e21-43e7-b2de-d856f4dcf491"), null, "Actividades Vencidas", 50 },
                    { new Guid("eb23b083-4305-493a-a4a5-cdc10f9d3ed1"), null, "Actividades Pendientes", 20 }
                });

            migrationBuilder.InsertData(
                table: "tarea",
                columns: new[] { "TareaId", "CategoriaId", "Descipcion", "FechaCreacion", "PrioridadTarea", "Titulo" },
                values: new object[,]
                {
                    { new Guid("6cf5e8bc-31e4-4eb0-b4a3-e2b658cbabf8"), new Guid("42bef976-8e21-43e7-b2de-d856f4dcf491"), null, new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0, "Pagar Servicios" },
                    { new Guid("a982d8ee-1452-446a-aeed-41ef33719ee8"), new Guid("eb23b083-4305-493a-a4a5-cdc10f9d3ed1"), null, new DateTime(2026, 1, 2, 0, 0, 0, 0, DateTimeKind.Utc), 1, "Lavar Platos" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "tarea",
                keyColumn: "TareaId",
                keyValue: new Guid("6cf5e8bc-31e4-4eb0-b4a3-e2b658cbabf8"));

            migrationBuilder.DeleteData(
                table: "tarea",
                keyColumn: "TareaId",
                keyValue: new Guid("a982d8ee-1452-446a-aeed-41ef33719ee8"));

            migrationBuilder.DeleteData(
                table: "categoria",
                keyColumn: "CategoriaId",
                keyValue: new Guid("42bef976-8e21-43e7-b2de-d856f4dcf491"));

            migrationBuilder.DeleteData(
                table: "categoria",
                keyColumn: "CategoriaId",
                keyValue: new Guid("eb23b083-4305-493a-a4a5-cdc10f9d3ed1"));

            migrationBuilder.AlterColumn<string>(
                name: "Descipcion",
                table: "tarea",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Descripcion",
                table: "categoria",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);
        }
    }
}
