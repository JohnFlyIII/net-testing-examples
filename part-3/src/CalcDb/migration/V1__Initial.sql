CREATE TABLE IF NOT EXISTS "__EFMigrationsHistory" (
    "MigrationId" character varying(150) NOT NULL,
    "ProductVersion" character varying(32) NOT NULL,
    CONSTRAINT "PK___EFMigrationsHistory" PRIMARY KEY ("MigrationId")
);

START TRANSACTION;


DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20211024221055_V1__InitialCreate') THEN
    CREATE TABLE "Constants" (
        "Id" uuid NOT NULL,
        "Name" text NULL,
        "Value" text NULL,
        "ModifyDate" timestamp without time zone NOT NULL,
        CONSTRAINT "PK_Constants" PRIMARY KEY ("Id")
    );
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20211024221055_V1__InitialCreate') THEN
    INSERT INTO "__EFMigrationsHistory" ("MigrationId", "ProductVersion")
    VALUES ('20211024221055_V1__InitialCreate', '5.0.11');
    END IF;
END $EF$;
COMMIT;