using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace TFT_Test.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Directors",
                columns: table => new
                {
                    DirectorId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    DirectorName = table.Column<string>(type: "text", nullable: false),
                    DirectorSurname = table.Column<string>(type: "text", nullable: false),
                    DirectorEmail = table.Column<string>(type: "text", nullable: false),
                    DirectorPassword = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Directors", x => x.DirectorId);
                });

            migrationBuilder.CreateTable(
                name: "Film",
                columns: table => new
                {
                    FilmId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    FilmName = table.Column<string>(type: "text", nullable: false),
                    FilmDescription = table.Column<string>(type: "text", nullable: false),
                    FilmLengt = table.Column<TimeSpan>(type: "interval", nullable: false),
                    StartedFilming = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    EndedFilming = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    FilmDirectorDirectorId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Film", x => x.FilmId);
                    table.ForeignKey(
                        name: "FK_Film_Directors_FilmDirectorDirectorId",
                        column: x => x.FilmDirectorDirectorId,
                        principalTable: "Directors",
                        principalColumn: "DirectorId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Actor",
                columns: table => new
                {
                    ActorId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ActorName = table.Column<string>(type: "text", nullable: false),
                    ActorSurname = table.Column<string>(type: "text", nullable: false),
                    ActorAdress = table.Column<string>(type: "text", nullable: false),
                    ExpectedFee = table.Column<int>(type: "integer", nullable: false),
                    ActorPassword = table.Column<string>(type: "text", nullable: false),
                    ActorEmail = table.Column<string>(type: "text", nullable: false),
                    FilmId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Actor", x => x.ActorId);
                    table.ForeignKey(
                        name: "FK_Actor_Film_FilmId",
                        column: x => x.FilmId,
                        principalTable: "Film",
                        principalColumn: "FilmId");
                });

            migrationBuilder.CreateTable(
                name: "Genre",
                columns: table => new
                {
                    GenreId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    GenreName = table.Column<string>(type: "text", nullable: false),
                    FilmId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genre", x => x.GenreId);
                    table.ForeignKey(
                        name: "FK_Genre_Film_FilmId",
                        column: x => x.FilmId,
                        principalTable: "Film",
                        principalColumn: "FilmId");
                });

            migrationBuilder.CreateTable(
                name: "Invitation",
                columns: table => new
                {
                    InvitationId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    InvitedActorActorId = table.Column<int>(type: "integer", nullable: false),
                    FilmInvitedToFilmId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Invitation", x => x.InvitationId);
                    table.ForeignKey(
                        name: "FK_Invitation_Actor_InvitedActorActorId",
                        column: x => x.InvitedActorActorId,
                        principalTable: "Actor",
                        principalColumn: "ActorId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Invitation_Film_FilmInvitedToFilmId",
                        column: x => x.FilmInvitedToFilmId,
                        principalTable: "Film",
                        principalColumn: "FilmId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Actor_FilmId",
                table: "Actor",
                column: "FilmId");

            migrationBuilder.CreateIndex(
                name: "IX_Film_FilmDirectorDirectorId",
                table: "Film",
                column: "FilmDirectorDirectorId");

            migrationBuilder.CreateIndex(
                name: "IX_Genre_FilmId",
                table: "Genre",
                column: "FilmId");

            migrationBuilder.CreateIndex(
                name: "IX_Invitation_FilmInvitedToFilmId",
                table: "Invitation",
                column: "FilmInvitedToFilmId");

            migrationBuilder.CreateIndex(
                name: "IX_Invitation_InvitedActorActorId",
                table: "Invitation",
                column: "InvitedActorActorId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Genre");

            migrationBuilder.DropTable(
                name: "Invitation");

            migrationBuilder.DropTable(
                name: "Actor");

            migrationBuilder.DropTable(
                name: "Film");

            migrationBuilder.DropTable(
                name: "Directors");
        }
    }
}
