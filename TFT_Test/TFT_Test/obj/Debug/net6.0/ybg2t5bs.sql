﻿CREATE TABLE IF NOT EXISTS "__EFMigrationsHistory" (
    "MigrationId" character varying(150) NOT NULL,
    "ProductVersion" character varying(32) NOT NULL,
    CONSTRAINT "PK___EFMigrationsHistory" PRIMARY KEY ("MigrationId")
);

START TRANSACTION;

CREATE TABLE "Directors" (
    "DirectorId" integer GENERATED BY DEFAULT AS IDENTITY,
    "DirectorName" text NOT NULL,
    "DirectorSurname" text NOT NULL,
    "DirectorEmail" text NOT NULL,
    "DirectorPassword" text NOT NULL,
    CONSTRAINT "PK_Directors" PRIMARY KEY ("DirectorId")
);

CREATE TABLE "Film" (
    "FilmId" integer GENERATED BY DEFAULT AS IDENTITY,
    "FilmName" text NOT NULL,
    "FilmDescription" text NOT NULL,
    "FilmLengt" interval NOT NULL,
    "StartedFilming" timestamp with time zone NULL,
    "EndedFilming" timestamp with time zone NULL,
    "FilmDirectorDirectorId" integer NOT NULL,
    CONSTRAINT "PK_Film" PRIMARY KEY ("FilmId"),
    CONSTRAINT "FK_Film_Directors_FilmDirectorDirectorId" FOREIGN KEY ("FilmDirectorDirectorId") REFERENCES "Directors" ("DirectorId") ON DELETE CASCADE
);

CREATE TABLE "Actor" (
    "ActorId" integer GENERATED BY DEFAULT AS IDENTITY,
    "ActorName" text NOT NULL,
    "ActorSurname" text NOT NULL,
    "ActorAdress" text NOT NULL,
    "ExpectedFee" integer NOT NULL,
    "ActorPassword" text NOT NULL,
    "ActorEmail" text NOT NULL,
    "FilmId" integer NULL,
    CONSTRAINT "PK_Actor" PRIMARY KEY ("ActorId"),
    CONSTRAINT "FK_Actor_Film_FilmId" FOREIGN KEY ("FilmId") REFERENCES "Film" ("FilmId")
);

CREATE TABLE "Genre" (
    "GenreId" integer GENERATED BY DEFAULT AS IDENTITY,
    "GenreName" text NOT NULL,
    "FilmId" integer NULL,
    CONSTRAINT "PK_Genre" PRIMARY KEY ("GenreId"),
    CONSTRAINT "FK_Genre_Film_FilmId" FOREIGN KEY ("FilmId") REFERENCES "Film" ("FilmId")
);

CREATE TABLE "Invitation" (
    "InvitationId" integer GENERATED BY DEFAULT AS IDENTITY,
    "InvitedActorActorId" integer NOT NULL,
    "FilmInvitedToFilmId" integer NOT NULL,
    CONSTRAINT "PK_Invitation" PRIMARY KEY ("InvitationId"),
    CONSTRAINT "FK_Invitation_Actor_InvitedActorActorId" FOREIGN KEY ("InvitedActorActorId") REFERENCES "Actor" ("ActorId") ON DELETE CASCADE,
    CONSTRAINT "FK_Invitation_Film_FilmInvitedToFilmId" FOREIGN KEY ("FilmInvitedToFilmId") REFERENCES "Film" ("FilmId") ON DELETE CASCADE
);

CREATE INDEX "IX_Actor_FilmId" ON "Actor" ("FilmId");

CREATE INDEX "IX_Film_FilmDirectorDirectorId" ON "Film" ("FilmDirectorDirectorId");

CREATE INDEX "IX_Genre_FilmId" ON "Genre" ("FilmId");

CREATE INDEX "IX_Invitation_FilmInvitedToFilmId" ON "Invitation" ("FilmInvitedToFilmId");

CREATE INDEX "IX_Invitation_InvitedActorActorId" ON "Invitation" ("InvitedActorActorId");

INSERT INTO "__EFMigrationsHistory" ("MigrationId", "ProductVersion")
VALUES ('20230414093054_init', '7.0.5');

COMMIT;

START TRANSACTION;

ALTER TABLE "Invitation" ADD "Accepted" boolean NOT NULL DEFAULT FALSE;

INSERT INTO "__EFMigrationsHistory" ("MigrationId", "ProductVersion")
VALUES ('20230414154420_addedsave', '7.0.5');

COMMIT;

START TRANSACTION;

DROP TABLE "Genre";

DROP TABLE "Invitation";

DROP TABLE "Actor";

DROP TABLE "Film";

INSERT INTO "__EFMigrationsHistory" ("MigrationId", "ProductVersion")
VALUES ('20230414160146_fixedConnections', '7.0.5');

COMMIT;

