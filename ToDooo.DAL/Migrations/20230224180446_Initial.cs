using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ToDooo.DAL.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Goals",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    DateAddGoal = table.Column<DateTime>(type: "TEXT", nullable: false),
                    DateControlGoal = table.Column<DateTime>(type: "TEXT", nullable: false),
                    DateSuccessGoal = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Priority = table.Column<byte>(type: "INTEGER", nullable: false),
                    Note = table.Column<string>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Goals", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Goals");
        }
    }
}
