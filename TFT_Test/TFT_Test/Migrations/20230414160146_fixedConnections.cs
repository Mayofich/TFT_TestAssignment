using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace TFT_Test.Migrations
{
    /// <inheritdoc />
    public partial class fixedConnections : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Genre");

            migrationBuilder.DropTable(
                name: "Invitation");

            migrationBuilder.DropTable(
                name: "Actor");

            migrationBuilder.DropTable(
                name: "Film");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Film",
                columns: table => new
                {
                    FilmId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    FilmDirectorDirectorId = table.Column<int>(type: "integer", nullable: false),
                    EndedFilming = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    FilmDescription = table.Column<string>(type: "text", nullable: false),
                    FilmLengt = table.Column<TimeSpan>(type: "interval", nullable: false),
                    FilmName = table.Column<string>(type: "text", nullable: false),
                    StartedFilming = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
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
                    ActorAdress = table.Column<string>(type: "text", nullable: false),
                    ActorEmail = table.Column<string>(type: "text", nullable: false),
                    ActorName = table.Column<string>(type: "text", nullable: false),
                    ActorPassword = table.Column<string>(type: "text", nullable: false),
                    ActorSurname = table.Column<string>(type: "text", nullable: false),
                    ExpectedFee = table.Column<int>(type: "integer", nullable: false),
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
                    FilmId = table.Column<int>(type: "integer", nullable: true),
                    GenreName = table.Column<string>(type: "text", nullable: false)
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
                    FilmInvitedToFilmId = table.Column<int>(type: "integer", nullable: false),
                    InvitedActorActorId = table.Column<int>(type: "integer", nullable: false),
                    Accepted = table.Column<bool>(type: "boolean", nullable: false)
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
    }
}
