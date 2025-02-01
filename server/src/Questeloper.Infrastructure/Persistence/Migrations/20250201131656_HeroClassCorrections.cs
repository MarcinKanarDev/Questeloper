using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Questeloper.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class HeroClassCorrections : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "HeroClass",
                table: "Heroes");

            migrationBuilder.AddColumn<int>(
                name: "HeroClassId",
                table: "Heroes",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "HeroClasses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ClassName = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HeroClasses", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Heroes_HeroClassId",
                table: "Heroes",
                column: "HeroClassId");

            migrationBuilder.AddForeignKey(
                name: "FK_Heroes_HeroClasses_HeroClassId",
                table: "Heroes",
                column: "HeroClassId",
                principalTable: "HeroClasses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Heroes_HeroClasses_HeroClassId",
                table: "Heroes");

            migrationBuilder.DropTable(
                name: "HeroClasses");

            migrationBuilder.DropIndex(
                name: "IX_Heroes_HeroClassId",
                table: "Heroes");

            migrationBuilder.DropColumn(
                name: "HeroClassId",
                table: "Heroes");

            migrationBuilder.AddColumn<string>(
                name: "HeroClass",
                table: "Heroes",
                type: "text",
                nullable: false,
                defaultValue: "");
        }
    }
}
