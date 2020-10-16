using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MultipleDatabases.DAL.Migrations.Oracle
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TestOnes",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Number = table.Column<int>(nullable: false),
                    Text = table.Column<string>(nullable: true),
                    Condition = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TestOnes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TestTwos",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Test = table.Column<string>(nullable: true),
                    TestOneId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TestTwos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TestTwos_TestOnes_TestOneId",
                        column: x => x.TestOneId,
                        principalTable: "TestOnes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TestTwos_TestOneId",
                table: "TestTwos",
                column: "TestOneId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TestTwos");

            migrationBuilder.DropTable(
                name: "TestOnes");
        }
    }
}
