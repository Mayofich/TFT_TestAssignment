using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TFT_Test.Migrations
{
    /// <inheritdoc />
    public partial class addedsave : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Accepted",
                table: "Invitation",
                type: "boolean",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Accepted",
                table: "Invitation");
        }
    }
}
