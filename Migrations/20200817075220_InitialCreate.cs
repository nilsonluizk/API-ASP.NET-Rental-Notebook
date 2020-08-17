using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebAPINotebook.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Notebooks",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NoteBooks = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notebooks", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AlugarNotebooks",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomeLocador = table.Column<string>(nullable: true),
                    ValorAluguel = table.Column<decimal>(nullable: false),
                    DataLocacao = table.Column<DateTime>(nullable: false),
                    DataDevolucao = table.Column<DateTime>(nullable: false),
                    EstaAlugado = table.Column<bool>(nullable: false),
                    NotebookId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AlugarNotebooks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AlugarNotebooks_Notebooks_NotebookId",
                        column: x => x.NotebookId,
                        principalTable: "Notebooks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AlugarNotebooks_NotebookId",
                table: "AlugarNotebooks",
                column: "NotebookId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AlugarNotebooks");

            migrationBuilder.DropTable(
                name: "Notebooks");
        }
    }
}
