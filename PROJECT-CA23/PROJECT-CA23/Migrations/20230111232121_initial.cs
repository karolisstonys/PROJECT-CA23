﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace PROJECTCA23.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Genres",
                columns: table => new
                {
                    GenreId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genres", x => x.GenreId);
                    table.UniqueConstraint("AK_Genres_Name", x => x.Name);
                });

            migrationBuilder.CreateTable(
                name: "Medias",
                columns: table => new
                {
                    MediaId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Type = table.Column<string>(type: "TEXT", nullable: true),
                    Title = table.Column<string>(type: "TEXT", maxLength: 1000, nullable: false),
                    Year = table.Column<string>(type: "TEXT", maxLength: 9, nullable: true),
                    Runtime = table.Column<string>(type: "TEXT", maxLength: 30, nullable: true),
                    Director = table.Column<string>(type: "TEXT", nullable: true),
                    Writer = table.Column<string>(type: "TEXT", nullable: true),
                    Actors = table.Column<string>(type: "TEXT", nullable: true),
                    Plot = table.Column<string>(type: "TEXT", maxLength: 2000, nullable: true),
                    Language = table.Column<string>(type: "TEXT", nullable: true),
                    Country = table.Column<string>(type: "TEXT", nullable: true),
                    Poster = table.Column<string>(type: "TEXT", nullable: true),
                    imdbId = table.Column<string>(type: "TEXT", nullable: true),
                    imdbRating = table.Column<double>(type: "REAL", nullable: true),
                    imdbVotes = table.Column<decimal>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Medias", x => x.MediaId);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Username = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    FirstName = table.Column<string>(type: "TEXT", maxLength: 200, nullable: false),
                    LastName = table.Column<string>(type: "TEXT", maxLength: 200, nullable: false),
                    Role = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    PasswordHash = table.Column<byte[]>(type: "BLOB", nullable: false),
                    PasswordSalt = table.Column<byte[]>(type: "BLOB", nullable: false),
                    Created = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Updated = table.Column<DateTime>(type: "TEXT", nullable: false),
                    LastLogin = table.Column<DateTime>(type: "TEXT", nullable: false),
                    IsDeleted = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId);
                    table.UniqueConstraint("AK_Users_Username", x => x.Username);
                });

            migrationBuilder.CreateTable(
                name: "MediaGenre",
                columns: table => new
                {
                    GenresGenreId = table.Column<int>(type: "INTEGER", nullable: false),
                    MediasMediaId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MediaGenre", x => new { x.GenresGenreId, x.MediasMediaId });
                    table.ForeignKey(
                        name: "FK_MediaGenre_Genres_GenresGenreId",
                        column: x => x.GenresGenreId,
                        principalTable: "Genres",
                        principalColumn: "GenreId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MediaGenre_Medias_MediasMediaId",
                        column: x => x.MediasMediaId,
                        principalTable: "Medias",
                        principalColumn: "MediaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Addresses",
                columns: table => new
                {
                    AddressId = table.Column<int>(type: "INTEGER", nullable: false),
                    UserId = table.Column<int>(type: "INTEGER", nullable: false),
                    Country = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    City = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    AddressText = table.Column<string>(type: "TEXT", maxLength: 500, nullable: false),
                    PostCode = table.Column<string>(type: "TEXT", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Addresses", x => x.AddressId);
                    table.ForeignKey(
                        name: "FK_Addresses_Users_AddressId",
                        column: x => x.AddressId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Notifications",
                columns: table => new
                {
                    NotificationId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    UserId = table.Column<int>(type: "INTEGER", nullable: false),
                    Title = table.Column<int>(type: "INTEGER", maxLength: 100, nullable: false),
                    Text = table.Column<int>(type: "INTEGER", maxLength: 1000, nullable: false),
                    Shown = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notifications", x => x.NotificationId);
                    table.ForeignKey(
                        name: "FK_Notifications_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Reviews",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "INTEGER", nullable: false),
                    MediaId = table.Column<int>(type: "INTEGER", nullable: false),
                    UserRating = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    ReviewText = table.Column<string>(type: "TEXT", maxLength: 1000, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reviews", x => new { x.UserId, x.MediaId });
                    table.ForeignKey(
                        name: "FK_Reviews_Medias_MediaId",
                        column: x => x.MediaId,
                        principalTable: "Medias",
                        principalColumn: "MediaId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Reviews_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserMedias",
                columns: table => new
                {
                    UserMediaId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    UserId = table.Column<int>(type: "INTEGER", nullable: false),
                    MediaId = table.Column<int>(type: "INTEGER", nullable: false),
                    MediaStatus = table.Column<int>(type: "INTEGER", nullable: false),
                    Note = table.Column<string>(type: "TEXT", maxLength: 1000, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserMedias", x => x.UserMediaId);
                    table.ForeignKey(
                        name: "FK_UserMedias_Medias_MediaId",
                        column: x => x.MediaId,
                        principalTable: "Medias",
                        principalColumn: "MediaId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserMedias_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Genres",
                columns: new[] { "GenreId", "Name" },
                values: new object[,]
                {
                    { 1, "Action" },
                    { 2, "Drama" },
                    { 3, "Sci-Fi" },
                    { 4, "Crime" },
                    { 5, "Thriller" }
                });

            migrationBuilder.InsertData(
                table: "Medias",
                columns: new[] { "MediaId", "Actors", "Country", "Director", "Language", "Plot", "Poster", "Runtime", "Title", "Type", "Writer", "Year", "imdbId", "imdbRating", "imdbVotes" },
                values: new object[,]
                {
                    { 1, "Stephen Root, Sarah Goldberg, Anthony Carrigan", "A blade runner must pursue and terminate four replicants who stole a ship in space and have returned to Earth to find their creator.", "Ridley Scott", "English", "Harrison Ford, Rutger Hauer, Sean Young", "https://m.media-amazon.com/images/M/MV5BNzQzMzJhZTEtOWM4NS00MTdhLTg0YjgtMjM4MDRkZjUwZDBlXkEyXkFqcGdeQXVyNjU0OTQ0OTY@._V1_SX300.jpg", "117 min", "Blade Runner", "movie", "Hampton Fancher, David Webb Peoples, Philip K. Dick", "2013", "tt0083658", 8.0999999999999996, 771646m },
                    { 2, "Bryan Cranston, Aaron Paul, Anna Gunn", "United States", null, "English", "A chemistry teacher diagnosed with inoperable lung cancer turns to manufacturing and selling methamphetamine with a former student in order to secure his family's future.", "https://m.media-amazon.com/images/M/MV5BYTU3NWI5OGMtZmZhNy00MjVmLTk1YzAtZjA3ZDA3NzcyNDUxXkEyXkFqcGdeQXVyODY5Njk4Njc@._V1_SX300.jpg", "49 min", "Breaking Bad", "series", "Vince Gilligan", "2008–2013", "tt0903747", 9.5, 1880303m }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "Created", "FirstName", "IsDeleted", "LastLogin", "LastName", "PasswordHash", "PasswordSalt", "Role", "Updated", "Username" },
                values: new object[] { 1, new DateTime(2023, 1, 12, 1, 21, 21, 217, DateTimeKind.Local).AddTicks(2016), "Jonas", false, new DateTime(2023, 1, 12, 1, 21, 21, 219, DateTimeKind.Local).AddTicks(5485), "Jonaitis", new byte[] { 81, 194, 178, 166, 87, 220, 172, 52, 31, 158, 181, 137, 164, 100, 124, 13, 209, 73, 122, 99, 166, 199, 128, 190, 251, 76, 252, 67, 219, 152, 144, 227 }, new byte[] { 172, 141, 58, 93, 231, 246, 35, 168, 108, 216, 246, 10, 21, 208, 36, 196, 58, 216, 29, 128, 254, 84, 118, 118, 104, 60, 201, 102, 251, 131, 246, 157, 216, 100, 156, 81, 101, 139, 200, 88, 216, 129, 211, 153, 250, 207, 18, 44, 157, 172, 103, 55, 17, 55, 98, 218, 62, 216, 106, 0, 121, 19, 213, 137 }, "admin", new DateTime(2023, 1, 12, 1, 21, 21, 219, DateTimeKind.Local).AddTicks(5069), "admin" });

            migrationBuilder.InsertData(
                table: "Addresses",
                columns: new[] { "AddressId", "AddressText", "City", "Country", "PostCode", "UserId" },
                values: new object[] { 1, "Address X1", "City X1", "Country X1", "PostCode X1", 1 });

            migrationBuilder.InsertData(
                table: "MediaGenre",
                columns: new[] { "GenresGenreId", "MediasMediaId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 2, 1 },
                    { 2, 2 },
                    { 3, 1 },
                    { 4, 2 },
                    { 5, 2 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_MediaGenre_MediasMediaId",
                table: "MediaGenre",
                column: "MediasMediaId");

            migrationBuilder.CreateIndex(
                name: "IX_Notifications_UserId",
                table: "Notifications",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_MediaId",
                table: "Reviews",
                column: "MediaId");

            migrationBuilder.CreateIndex(
                name: "IX_UserMedias_MediaId",
                table: "UserMedias",
                column: "MediaId");

            migrationBuilder.CreateIndex(
                name: "IX_UserMedias_UserId",
                table: "UserMedias",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Addresses");

            migrationBuilder.DropTable(
                name: "MediaGenre");

            migrationBuilder.DropTable(
                name: "Notifications");

            migrationBuilder.DropTable(
                name: "Reviews");

            migrationBuilder.DropTable(
                name: "UserMedias");

            migrationBuilder.DropTable(
                name: "Genres");

            migrationBuilder.DropTable(
                name: "Medias");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
