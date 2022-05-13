using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace NetFlex.DAL.Migrations
{
    public partial class initialMigrate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    Avatar = table.Column<string>(type: "text", nullable: true),
                    UserName = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "boolean", nullable: false),
                    PasswordHash = table.Column<string>(type: "text", nullable: true),
                    SecurityStamp = table.Column<string>(type: "text", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "text", nullable: true),
                    PhoneNumber = table.Column<string>(type: "text", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "boolean", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "boolean", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "boolean", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Episodes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Title = table.Column<string>(type: "text", nullable: true),
                    SerialId = table.Column<Guid>(type: "uuid", nullable: false),
                    Duration = table.Column<int>(type: "integer", nullable: false),
                    Number = table.Column<int>(type: "integer", nullable: false),
                    VideoLink = table.Column<string>(type: "text", nullable: true),
                    PreviewVideo = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Episodes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Films",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Title = table.Column<string>(type: "text", nullable: true),
                    Poster = table.Column<string>(type: "text", nullable: true),
                    Duration = table.Column<int>(type: "integer", nullable: false),
                    AgeRating = table.Column<int>(type: "integer", nullable: false),
                    UserRating = table.Column<float>(type: "real", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: true),
                    VideoLink = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Films", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Genres",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    GenreName = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genres", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GenreVideos",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    GenreName = table.Column<string>(type: "text", nullable: true),
                    ContentId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GenreVideos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Ratings",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    ContentId = table.Column<Guid>(type: "uuid", nullable: false),
                    UserRating = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ratings", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Reviews",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    UserName = table.Column<string>(type: "text", nullable: true),
                    ContentId = table.Column<Guid>(type: "uuid", nullable: false),
                    Text = table.Column<string>(type: "text", nullable: true),
                    Rating = table.Column<float>(type: "real", nullable: false),
                    PublishTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reviews", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Serials",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Poster = table.Column<string>(type: "text", nullable: true),
                    Title = table.Column<string>(type: "text", nullable: true),
                    NumEpisodes = table.Column<int>(type: "integer", nullable: false),
                    AgeRating = table.Column<int>(type: "integer", nullable: false),
                    UserRating = table.Column<float>(type: "real", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Serials", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Subscriptions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<int>(type: "integer", nullable: false),
                    Cost = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subscriptions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserFavorites",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    ContentId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserFavorites", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserSubscriptions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    SubscriptionId = table.Column<Guid>(type: "uuid", nullable: false),
                    StartDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    FinishDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserSubscriptions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    RoleId = table.Column<string>(type: "text", nullable: false),
                    ClaimType = table.Column<string>(type: "text", nullable: true),
                    ClaimValue = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<string>(type: "text", nullable: false),
                    ClaimType = table.Column<string>(type: "text", nullable: true),
                    ClaimValue = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "text", nullable: false),
                    ProviderKey = table.Column<string>(type: "text", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "text", nullable: true),
                    UserId = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "text", nullable: false),
                    RoleId = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "text", nullable: false),
                    LoginProvider = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Value = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Episodes",
                columns: new[] { "Id", "Duration", "Number", "PreviewVideo", "SerialId", "Title", "VideoLink" },
                values: new object[,]
                {
                    { new Guid("013e23c9-90bb-4ac2-b860-e3e5bdfe34e7"), 24, 3, "https://raw.githubusercontent.com/1dxrpz/video-player-test-js/main/Netflix%20icon.svg", new Guid("2235d369-639d-4858-9c0c-abd8588c3f0a"), "Красный эпизод", "https://raw.githubusercontent.com/1dxrpz/video-player-test-js/main/videos/Blend%20S%20OP%20Opening%E3%80%8CUHD%2060FPS%E3%80%8D.mp4" },
                    { new Guid("0a371828-6959-46a5-addd-6ba375363bbb"), 24, 1, "https://raw.githubusercontent.com/1dxrpz/video-player-test-js/main/Netflix%20icon.svg", new Guid("af3f94c6-348d-439d-a649-06e8f35db631"), "Красный эпизод", "https://raw.githubusercontent.com/1dxrpz/video-player-test-js/main/videos/Blend%20S%20OP%20Opening%E3%80%8CUHD%2060FPS%E3%80%8D.mp4" },
                    { new Guid("158f67a7-6d9b-4211-99e3-e4a0c1ccd52a"), 24, 1, "https://raw.githubusercontent.com/1dxrpz/video-player-test-js/main/Netflix%20icon.svg", new Guid("f997d15f-db67-4d76-8004-83d129f2b234"), "Красный эпизод", "https://raw.githubusercontent.com/1dxrpz/video-player-test-js/main/videos/Blend%20S%20OP%20Opening%E3%80%8CUHD%2060FPS%E3%80%8D.mp4" },
                    { new Guid("1801fd09-6bfe-48aa-a5b8-48cd412b8a42"), 24, 2, "https://raw.githubusercontent.com/1dxrpz/video-player-test-js/main/Netflix%20icon.svg", new Guid("af3f94c6-348d-439d-a649-06e8f35db631"), "Красный эпизод", "https://raw.githubusercontent.com/1dxrpz/video-player-test-js/main/videos/Blend%20S%20OP%20Opening%E3%80%8CUHD%2060FPS%E3%80%8D.mp4" },
                    { new Guid("2f33d4de-9677-4a39-ae1b-c721c8359d20"), 24, 1, "https://raw.githubusercontent.com/1dxrpz/video-player-test-js/main/Netflix%20icon.svg", new Guid("2235d369-639d-4858-9c0c-abd8588c3f0a"), "Красный эпизод", "https://raw.githubusercontent.com/1dxrpz/video-player-test-js/main/videos/Blend%20S%20OP%20Opening%E3%80%8CUHD%2060FPS%E3%80%8D.mp4" },
                    { new Guid("37619272-5108-459c-b083-63033645acae"), 24, 2, "https://raw.githubusercontent.com/1dxrpz/video-player-test-js/main/Netflix%20icon.svg", new Guid("7e1e4355-2766-4341-a7a5-ad1d97d2f143"), "Красный эпизод", "https://raw.githubusercontent.com/1dxrpz/video-player-test-js/main/videos/Blend%20S%20OP%20Opening%E3%80%8CUHD%2060FPS%E3%80%8D.mp4" },
                    { new Guid("3c8b2096-de30-4458-a8e3-c29c90bd0da9"), 24, 1, "https://raw.githubusercontent.com/1dxrpz/video-player-test-js/main/Netflix%20icon.svg", new Guid("74d03f01-8ae1-4c6f-be51-8c5d0a435958"), "Красный эпизод", "https://raw.githubusercontent.com/1dxrpz/video-player-test-js/main/videos/Blend%20S%20OP%20Opening%E3%80%8CUHD%2060FPS%E3%80%8D.mp4" },
                    { new Guid("413d1adb-1398-4dac-ad19-7fe314388e6f"), 24, 3, "https://raw.githubusercontent.com/1dxrpz/video-player-test-js/main/Netflix%20icon.svg", new Guid("08c98868-37c3-47c2-95cd-e94b39871ec4"), "Красный эпизод", "https://raw.githubusercontent.com/1dxrpz/video-player-test-js/main/videos/Blend%20S%20OP%20Opening%E3%80%8CUHD%2060FPS%E3%80%8D.mp4" },
                    { new Guid("553cf3e5-80cc-4f0b-b548-1c10adc8063a"), 24, 3, "https://raw.githubusercontent.com/1dxrpz/video-player-test-js/main/Netflix%20icon.svg", new Guid("7e1e4355-2766-4341-a7a5-ad1d97d2f143"), "Красный эпизод", "https://raw.githubusercontent.com/1dxrpz/video-player-test-js/main/videos/Blend%20S%20OP%20Opening%E3%80%8CUHD%2060FPS%E3%80%8D.mp4" },
                    { new Guid("5a9289ee-e67e-439c-9900-78dc9ce01602"), 24, 3, "https://raw.githubusercontent.com/1dxrpz/video-player-test-js/main/Netflix%20icon.svg", new Guid("af3f94c6-348d-439d-a649-06e8f35db631"), "Красный эпизод", "https://raw.githubusercontent.com/1dxrpz/video-player-test-js/main/videos/Blend%20S%20OP%20Opening%E3%80%8CUHD%2060FPS%E3%80%8D.mp4" },
                    { new Guid("5cd884d6-98ca-4bcc-97ff-2a8f5c177fc7"), 24, 1, "https://raw.githubusercontent.com/1dxrpz/video-player-test-js/main/Netflix%20icon.svg", new Guid("08c98868-37c3-47c2-95cd-e94b39871ec4"), "Красный эпизод", "https://raw.githubusercontent.com/1dxrpz/video-player-test-js/main/videos/Blend%20S%20OP%20Opening%E3%80%8CUHD%2060FPS%E3%80%8D.mp4" },
                    { new Guid("63c51cae-b49c-4403-aa9a-495004306360"), 24, 2, "https://raw.githubusercontent.com/1dxrpz/video-player-test-js/main/Netflix%20icon.svg", new Guid("0c4003ae-7668-4785-9da0-e0c983e35975"), "Красный эпизод", "https://raw.githubusercontent.com/1dxrpz/video-player-test-js/main/videos/Blend%20S%20OP%20Opening%E3%80%8CUHD%2060FPS%E3%80%8D.mp4" },
                    { new Guid("7d8bbc2d-7004-4d85-99c9-0466dfa07c61"), 24, 2, "https://raw.githubusercontent.com/1dxrpz/video-player-test-js/main/Netflix%20icon.svg", new Guid("f997d15f-db67-4d76-8004-83d129f2b234"), "Красный эпизод", "https://raw.githubusercontent.com/1dxrpz/video-player-test-js/main/videos/Blend%20S%20OP%20Opening%E3%80%8CUHD%2060FPS%E3%80%8D.mp4" },
                    { new Guid("903abe10-1a8f-4aef-9137-4f975145d290"), 24, 3, "https://raw.githubusercontent.com/1dxrpz/video-player-test-js/main/Netflix%20icon.svg", new Guid("f997d15f-db67-4d76-8004-83d129f2b234"), "Красный эпизод", "https://raw.githubusercontent.com/1dxrpz/video-player-test-js/main/videos/Blend%20S%20OP%20Opening%E3%80%8CUHD%2060FPS%E3%80%8D.mp4" },
                    { new Guid("94ec60aa-b071-4f24-93d7-544339a7806f"), 24, 3, "https://raw.githubusercontent.com/1dxrpz/video-player-test-js/main/Netflix%20icon.svg", new Guid("0c4003ae-7668-4785-9da0-e0c983e35975"), "Красный эпизод", "https://raw.githubusercontent.com/1dxrpz/video-player-test-js/main/videos/Blend%20S%20OP%20Opening%E3%80%8CUHD%2060FPS%E3%80%8D.mp4" },
                    { new Guid("956a7fa2-75c8-41ef-97a8-79771b1478bc"), 24, 1, "https://raw.githubusercontent.com/1dxrpz/video-player-test-js/main/Netflix%20icon.svg", new Guid("7e1e4355-2766-4341-a7a5-ad1d97d2f143"), "Красный эпизод", "https://raw.githubusercontent.com/1dxrpz/video-player-test-js/main/videos/Blend%20S%20OP%20Opening%E3%80%8CUHD%2060FPS%E3%80%8D.mp4" },
                    { new Guid("96f3abfd-3426-4330-a09f-3f34a6a10970"), 24, 3, "https://raw.githubusercontent.com/1dxrpz/video-player-test-js/main/Netflix%20icon.svg", new Guid("83f8384a-fc2c-4d98-b3a8-5a867f931361"), "Красный эпизод", "https://raw.githubusercontent.com/1dxrpz/video-player-test-js/main/videos/Blend%20S%20OP%20Opening%E3%80%8CUHD%2060FPS%E3%80%8D.mp4" },
                    { new Guid("a1445f1b-ee36-41fc-a24d-46895895cc4e"), 24, 3, "https://raw.githubusercontent.com/1dxrpz/video-player-test-js/main/Netflix%20icon.svg", new Guid("74d03f01-8ae1-4c6f-be51-8c5d0a435958"), "Красный эпизод", "https://raw.githubusercontent.com/1dxrpz/video-player-test-js/main/videos/Blend%20S%20OP%20Opening%E3%80%8CUHD%2060FPS%E3%80%8D.mp4" },
                    { new Guid("a69f5ebb-389f-4f5f-90e0-2f27f944a847"), 24, 2, "https://raw.githubusercontent.com/1dxrpz/video-player-test-js/main/Netflix%20icon.svg", new Guid("2235d369-639d-4858-9c0c-abd8588c3f0a"), "Красный эпизод", "https://raw.githubusercontent.com/1dxrpz/video-player-test-js/main/videos/Blend%20S%20OP%20Opening%E3%80%8CUHD%2060FPS%E3%80%8D.mp4" },
                    { new Guid("ad0d23ba-e27c-454d-bf76-d4162a6b7787"), 24, 1, "https://raw.githubusercontent.com/1dxrpz/video-player-test-js/main/Netflix%20icon.svg", new Guid("83f8384a-fc2c-4d98-b3a8-5a867f931361"), "Красный эпизод", "https://raw.githubusercontent.com/1dxrpz/video-player-test-js/main/videos/Blend%20S%20OP%20Opening%E3%80%8CUHD%2060FPS%E3%80%8D.mp4" },
                    { new Guid("b693afc9-9269-414c-80a2-622bad630d29"), 24, 2, "https://raw.githubusercontent.com/1dxrpz/video-player-test-js/main/Netflix%20icon.svg", new Guid("83f8384a-fc2c-4d98-b3a8-5a867f931361"), "Красный эпизод", "https://raw.githubusercontent.com/1dxrpz/video-player-test-js/main/videos/Blend%20S%20OP%20Opening%E3%80%8CUHD%2060FPS%E3%80%8D.mp4" },
                    { new Guid("b711d1dc-c731-4c0d-ab34-c634366f9822"), 24, 2, "https://raw.githubusercontent.com/1dxrpz/video-player-test-js/main/Netflix%20icon.svg", new Guid("08c98868-37c3-47c2-95cd-e94b39871ec4"), "Красный эпизод", "https://raw.githubusercontent.com/1dxrpz/video-player-test-js/main/videos/Blend%20S%20OP%20Opening%E3%80%8CUHD%2060FPS%E3%80%8D.mp4" },
                    { new Guid("c380a445-d389-4235-8940-fa06beb5fba5"), 24, 2, "https://raw.githubusercontent.com/1dxrpz/video-player-test-js/main/Netflix%20icon.svg", new Guid("74d03f01-8ae1-4c6f-be51-8c5d0a435958"), "Красный эпизод", "https://raw.githubusercontent.com/1dxrpz/video-player-test-js/main/videos/Blend%20S%20OP%20Opening%E3%80%8CUHD%2060FPS%E3%80%8D.mp4" },
                    { new Guid("ffc51f51-931b-401f-a542-c0851bdbecc9"), 24, 1, "https://raw.githubusercontent.com/1dxrpz/video-player-test-js/main/Netflix%20icon.svg", new Guid("0c4003ae-7668-4785-9da0-e0c983e35975"), "Красный эпизод", "https://raw.githubusercontent.com/1dxrpz/video-player-test-js/main/videos/Blend%20S%20OP%20Opening%E3%80%8CUHD%2060FPS%E3%80%8D.mp4" }
                });

            migrationBuilder.InsertData(
                table: "Films",
                columns: new[] { "Id", "AgeRating", "Description", "Duration", "Poster", "Title", "UserRating", "VideoLink" },
                values: new object[,]
                {
                    { new Guid("3a82b37b-7a41-4c94-ab89-f2a6d1647981"), 16, "Отец Акио, мать Юко и их десятилетняя дочь Тихиро переезжают в новый дом, расположенный где-то в глубинке Японии. Перепутав дорогу к новому дому и проехав через странный лес, они попадают в тупик: останавливаются перед высокой стеной, в которой темнеет вход. Войдя туда и проследовав по длинному тёмному туннелю, они попадают в здание, похожее на вокзал, выйдя из которого, оказываются в пустующем городке, почти полностью состоящем из пустующих ресторанов. Нигде нет ни души.", 163, "https://upload.wikimedia.org/wikipedia/ru/6/61/Spirited_away.jpg", "Унесённые призраками", 0f, "https://raw.githubusercontent.com/1dxrpz/video-player-test-js/main/videos/Blend%20S%20OP%20Opening%E3%80%8CUHD%2060FPS%E3%80%8D.mp4" },
                    { new Guid("4e58585b-4581-4737-908c-7fcc5765c5d5"), 18, "Во время комендантского часа поздним вечером 4 ноября неизвестного года человек, носящий маску Гая Фокса и называющий себя «V» («Ви»), спасает из рук Службы Безопасности Norsefire (в фильме её сотрудники именуются Пальцами) ассистентку британского телеканала British Television Network (BTN) Иви Хэммонд. V сообщает Иви, что он «музыкант» и приглашает её послушать его «выступление» на крышу здания около центрального уголовного суда Лондона — Олд-Бейли.", 132, "https://upload.wikimedia.org/wikipedia/ru/a/ae/V_For_Vendetta_2006_Poster_01.jpg", "V — значит вендетта", 0f, "https://raw.githubusercontent.com/1dxrpz/video-player-test-js/main/videos/Blend%20S%20OP%20Opening%E3%80%8CUHD%2060FPS%E3%80%8D.mp4" },
                    { new Guid("5c7e4f35-7ca4-4f04-9d5a-5f68b176556d"), 16, "Aмериканский художественный фильм-драма 1994 года, снятый режиссёром Фрэнком Дарабонтом по его же сценарию, и рассказывающий историю Энди Дюфрейна, незаслуженно приговорённого к пожизненному заключению и пробывшего в заключении почти 20 лет. Основой сюжета послужила повесть Стивена Кинга «Рита Хейуорт и спасение из Шоушенка». Главные роли сыграли Тим Роббинс и Морган Фримен", 142, "https://upload.wikimedia.org/wikipedia/ru/thumb/d/de/Movie_poster_the_shawshank_redemption.jpg/317px-Movie_poster_the_shawshank_redemption.jpg", "Побег из Шоушенка", 0f, "https://raw.githubusercontent.com/1dxrpz/video-player-test-js/main/videos/Blend%20S%20OP%20Opening%E3%80%8CUHD%2060FPS%E3%80%8D.mp4" },
                    { new Guid("5de968e8-e920-4814-91d3-e67450f0f66b"), 16, "Парализованный богатый аристократ Филипп, ставший инвалидом после того, как разбился на параплане, ищет себе помощника, который должен за ним ухаживать. Одного из кандидатов, чернокожего Дрисса, работа не интересует — ему нужен формальный письменный отказ, чтобы продолжать получать пособие по безработице.", 112, "https://upload.wikimedia.org/wikipedia/ru/b/b9/Intouchables.jpg", "1+1", 0f, "https://raw.githubusercontent.com/1dxrpz/video-player-test-js/main/videos/Blend%20S%20OP%20Opening%E3%80%8CUHD%2060FPS%E3%80%8D.mp4" },
                    { new Guid("62fc461a-83e9-496e-a6b5-fab6cc1b8adf"), 16, "Действие фильма происходит в футуристическом Лос-Анджелесе, где рядом с обычными людьми сосуществуют искусственные создания — «репликанты». Главный герой, полицейский-репликант Кей, случайно вскрывает старый секрет, способный нарушить существующий порядок, и вынужден разыскивать Рика Декарда, героя первого фильма. ", 163, "https://upload.wikimedia.org/wikipedia/ru/thumb/9/9b/%D0%91%D0%B5%D0%B3%D1%83%D1%89%D0%B8%D0%B9_%D0%BF%D0%BE_%D0%BB%D0%B5%D0%B7%D0%B2%D0%B8%D1%8E_2049.jpg/300px-%D0%91%D0%B5%D0%B3%D1%83%D1%89%D0%B8%D0%B9_%D0%BF%D0%BE_%D0%BB%D0%B5%D0%B7%D0%B2%D0%B8%D1%8E_2049.jpg", "Бегущий по лезвию 2049", 0f, "https://raw.githubusercontent.com/1dxrpz/video-player-test-js/main/videos/Blend%20S%20OP%20Opening%E3%80%8CUHD%2060FPS%E3%80%8D.mp4" },
                    { new Guid("84951f4c-e4f6-4b3f-af74-ca0acdd17e47"), 12, "Труман Бёрбанк — обычный человек, работающий страховым агентом и живущий обычной жизнью. Однако он не знает, что за каждым его движением наблюдают многочисленные скрытые камеры, а его жизнь круглосуточно передаётся в прямом эфире по всему миру. Родина Трумана — город Сихэвэн (Seahaven, дословно – «Морская гавань») на острове вблизи материка — на самом деле искусно выполненные декорации, а всё население — нанятые актёры. Исполнительный продюсер «Шоу Трумана», Кристоф, с помощью своей команды может даже изменять погоду в городе с помощью технологий под огромным куполом киностудии. ", 103, "https://upload.wikimedia.org/wikipedia/ru/c/cd/Trumanshow.jpg", "Шоу Трумана", 0f, "https://raw.githubusercontent.com/1dxrpz/video-player-test-js/main/videos/Blend%20S%20OP%20Opening%E3%80%8CUHD%2060FPS%E3%80%8D.mp4" },
                    { new Guid("8dc46d99-c504-4654-919b-baa2e1c92df4"), 12, "Фродо с Сэмом продолжают путь в Мордор. Фродо видит в ночных кошмарах Гэндальфа, упавшего вместе с Балрогом на дно бездны. Хоббиты заблудились в скалистой местности. Ночью они захватывают в плен преследовавшего их Голлума. Он соглашается отвести героев в Мордор. Саруман после общения с Сауроном посредством палантира посылает отряды урук-хай и горцев Дунланда на земли Рохана.", 235, "https://upload.wikimedia.org/wikipedia/ru/f/f0/The_Lord_of_the_Rings._The_Two_Towers_%E2%80%94_movie.jpg", "Властелин колец: Две крепости", 0f, "https://raw.githubusercontent.com/1dxrpz/video-player-test-js/main/videos/Blend%20S%20OP%20Opening%E3%80%8CUHD%2060FPS%E3%80%8D.mp4" },
                    { new Guid("cf259f11-44f1-405f-99af-8f759f83c387"), 16, "Гражданская война продолжается. Несмотря на уничтожение «Звезды смерти», Галактическая Империя захватила базу повстанцев на планете Явин IV и продолжает поиски мятежников. Альянс повстанцев устраивает новую базу на далёкой замёрзшей планете Хот, на самом краю Галактики. Дарт Вейдер лично руководит поиском повстанцев. По его приказу во все уголки Галактики рассылаются зонды-разведчики. ", 124, "https://upload.wikimedia.org/wikipedia/ru/thumb/e/e0/Empire20strikes20back_old.jpg/345px-Empire20strikes20back_old.jpg", "Звёздные войны. Эпизод V: Империя наносит ответный удар", 0f, "https://raw.githubusercontent.com/1dxrpz/video-player-test-js/main/videos/Blend%20S%20OP%20Opening%E3%80%8CUHD%2060FPS%E3%80%8D.mp4" },
                    { new Guid("d07b4bf0-dc65-4370-9b75-7beae106e40c"), 12, "Марти Макфлай — обычный семнадцатилетний американский подросток, живущий в 1985 году в неблагополучной семье Макфлаев в городке Хилл-Вэлли (штат Калифорния). Его отец Джордж постоянно терпит издевательства и насмешки своего шефа Биффа Таннена, а мать Лоррейн — алкоголичка с избыточным весом. Утром 25 октября 1985 года Марти по дороге в школу заходит домой к своему другу-учёному, доктору Эмметту Брауну по прозвищу Док, но самого его не застаёт. Док звонит Марти и просит встретиться в 1:15 ночи на автостоянке у торгового центра «Две сосны», дабы показать ему нечто удивительное.", 116, "https://upload.wikimedia.org/wikipedia/ru/thumb/9/90/BTTF_DVD_rus.jpg/300px-BTTF_DVD_rus.jpg", "Назад в будущее", 0f, "https://raw.githubusercontent.com/1dxrpz/video-player-test-js/main/videos/Blend%20S%20OP%20Opening%E3%80%8CUHD%2060FPS%E3%80%8D.mp4" },
                    { new Guid("e2cb3d51-4e41-46b7-98da-1fe17e83ee40"), 16, "Доминик Кобб и Артур — «извлекатели»: они занимаются корпоративным шпионажем, используя экспериментальные военные технологии, чтобы проникнуть в подсознание своих «целей» и извлечь информацию через общий мир снов. Их последняя цель, Сайто, рассказывает, что устроил встречу, чтобы проверить: сможет ли Кобб выполнить кажущуюся невозможной работу — внедрение идеи в подсознание человека, или «начало». Сайто хочет, чтобы Кобб убедил Роберта Фишера, сына больного конкурента Сайто, Мориса Фишера, развалить компанию его отца. Взамен Сайто обещает «всего одним звонком» помочь Коббу, над которым «висит» ложное обвинение в убийстве жены, легально вернуться в США, где остались его дети. ", 148, "https://upload.wikimedia.org/wikipedia/ru/thumb/b/bc/Poster_Inception_film_2010.jpg/318px-Poster_Inception_film_2010.jpg", "Начало", 0f, "https://raw.githubusercontent.com/1dxrpz/video-player-test-js/main/videos/Blend%20S%20OP%20Opening%E3%80%8CUHD%2060FPS%E3%80%8D.mp4" }
                });

            migrationBuilder.InsertData(
                table: "GenreVideos",
                columns: new[] { "Id", "ContentId", "GenreName" },
                values: new object[,]
                {
                    { new Guid("00bcbb4d-a3c6-4ffa-be6f-04ffd52fcf35"), new Guid("8dc46d99-c504-4654-919b-baa2e1c92df4"), "Драма" },
                    { new Guid("0232d776-8b71-42ae-b391-bf217512fb79"), new Guid("08c98868-37c3-47c2-95cd-e94b39871ec4"), "Драма" },
                    { new Guid("06177805-6391-4a60-a0bf-48c3198c9a97"), new Guid("af3f94c6-348d-439d-a649-06e8f35db631"), "Триллер" },
                    { new Guid("06aba487-412a-4494-b33d-1ba7689e634a"), new Guid("7e1e4355-2766-4341-a7a5-ad1d97d2f143"), "Драма" },
                    { new Guid("06cd8527-33a1-4770-8182-b00b3f98e961"), new Guid("2235d369-639d-4858-9c0c-abd8588c3f0a"), "Ужасы" },
                    { new Guid("09a330df-9bed-4b86-be67-13d45e7d4468"), new Guid("5c7e4f35-7ca4-4f04-9d5a-5f68b176556d"), "Детектив" },
                    { new Guid("09df3bff-a2e1-4c5e-90bd-a7a65f92aa88"), new Guid("5c7e4f35-7ca4-4f04-9d5a-5f68b176556d"), "Триллер" },
                    { new Guid("0b7a9f6a-1fee-4b12-80af-c8e0ea1ece82"), new Guid("4e58585b-4581-4737-908c-7fcc5765c5d5"), "Ужасы" },
                    { new Guid("0e712110-4d8d-4bac-a0dc-759049498666"), new Guid("08c98868-37c3-47c2-95cd-e94b39871ec4"), "Детектив" },
                    { new Guid("1034a4f2-05cd-48d8-9646-ce9e2017d0a8"), new Guid("62fc461a-83e9-496e-a6b5-fab6cc1b8adf"), "Триллер" },
                    { new Guid("10e40fca-c269-4434-9e26-d426c989506e"), new Guid("83f8384a-fc2c-4d98-b3a8-5a867f931361"), "Драма" },
                    { new Guid("119d2f74-a0a2-45e9-8e45-548e99f4547c"), new Guid("84951f4c-e4f6-4b3f-af74-ca0acdd17e47"), "Детектив" },
                    { new Guid("15aba693-5e0e-4291-938b-9afb6ecc7d26"), new Guid("f997d15f-db67-4d76-8004-83d129f2b234"), "Триллер" },
                    { new Guid("198ba5d8-5590-4be1-96d7-6c44d1e67c3e"), new Guid("4e58585b-4581-4737-908c-7fcc5765c5d5"), "Драма" },
                    { new Guid("1d43e88d-43e8-4d4c-ae72-7bff11cefb93"), new Guid("3a82b37b-7a41-4c94-ab89-f2a6d1647981"), "Триллер" },
                    { new Guid("1e2f8ca1-d067-434f-a63c-e48d6f37a873"), new Guid("74d03f01-8ae1-4c6f-be51-8c5d0a435958"), "Триллер" },
                    { new Guid("2118a74a-6a87-4111-b26a-1fc20fe28d1d"), new Guid("e2cb3d51-4e41-46b7-98da-1fe17e83ee40"), "Драма" },
                    { new Guid("22c5169e-37ce-4302-9d53-3325b61827e7"), new Guid("62fc461a-83e9-496e-a6b5-fab6cc1b8adf"), "Ужасы" },
                    { new Guid("25289b9c-8782-4355-9378-8e4488825d94"), new Guid("d07b4bf0-dc65-4370-9b75-7beae106e40c"), "Ужасы" },
                    { new Guid("26e65086-72ec-4147-85b2-64c533b25728"), new Guid("f997d15f-db67-4d76-8004-83d129f2b234"), "Фантастика" },
                    { new Guid("2bb6eaca-0c7d-4fb6-9f24-4f71a46e54cc"), new Guid("62fc461a-83e9-496e-a6b5-fab6cc1b8adf"), "Детектив" },
                    { new Guid("2fc4b1d4-e91e-4dc1-9c0c-ee172b9b9b4b"), new Guid("8dc46d99-c504-4654-919b-baa2e1c92df4"), "Триллер" },
                    { new Guid("33632db3-30b1-46a1-86ae-1124935d45d7"), new Guid("d07b4bf0-dc65-4370-9b75-7beae106e40c"), "Детектив" },
                    { new Guid("39488a3a-130b-4dd0-83b3-f7961ebb528a"), new Guid("e2cb3d51-4e41-46b7-98da-1fe17e83ee40"), "Триллер" },
                    { new Guid("39c74f4f-0782-4ec2-8f68-fab7ce76eecb"), new Guid("3a82b37b-7a41-4c94-ab89-f2a6d1647981"), "Детектив" },
                    { new Guid("3ac0c6f8-9470-4ff2-a84e-dbe0e6367c0e"), new Guid("d07b4bf0-dc65-4370-9b75-7beae106e40c"), "Триллер" },
                    { new Guid("3d044f84-365f-40fe-89cb-ae5384712191"), new Guid("5de968e8-e920-4814-91d3-e67450f0f66b"), "Детектив" },
                    { new Guid("438c84f0-995e-4f9b-b3b7-726078792b09"), new Guid("7e1e4355-2766-4341-a7a5-ad1d97d2f143"), "Фантастика" },
                    { new Guid("44736b79-6057-40f1-9c01-169f5d5d923e"), new Guid("cf259f11-44f1-405f-99af-8f759f83c387"), "Детектив" },
                    { new Guid("45b588ba-2572-4e5e-9cf4-0dbdfad6f77d"), new Guid("f997d15f-db67-4d76-8004-83d129f2b234"), "Детектив" },
                    { new Guid("461b9176-d10e-490a-9138-9700acd64039"), new Guid("83f8384a-fc2c-4d98-b3a8-5a867f931361"), "Детектив" },
                    { new Guid("481cf384-6811-4d2a-84fd-f333753d5753"), new Guid("0c4003ae-7668-4785-9da0-e0c983e35975"), "Драма" },
                    { new Guid("4ab6745f-464b-4dd5-81dc-47b1cdc065ae"), new Guid("5de968e8-e920-4814-91d3-e67450f0f66b"), "Фантастика" },
                    { new Guid("4cbf4e13-b35b-44ae-8a1a-40e9051843e4"), new Guid("74d03f01-8ae1-4c6f-be51-8c5d0a435958"), "Детектив" },
                    { new Guid("523e3301-3ddc-48f7-8357-dc3683eaf86c"), new Guid("f997d15f-db67-4d76-8004-83d129f2b234"), "Ужасы" },
                    { new Guid("67baf5d3-c06a-4215-b28c-5aaae9824a41"), new Guid("af3f94c6-348d-439d-a649-06e8f35db631"), "Фантастика" },
                    { new Guid("68b1217f-d627-4481-bfbf-c709767e3eae"), new Guid("08c98868-37c3-47c2-95cd-e94b39871ec4"), "Фантастика" },
                    { new Guid("6ed2d786-4967-4ddf-b296-ac140e2324be"), new Guid("84951f4c-e4f6-4b3f-af74-ca0acdd17e47"), "Триллер" },
                    { new Guid("6ef25aa5-329d-424e-a2ce-c205a184ae9d"), new Guid("d07b4bf0-dc65-4370-9b75-7beae106e40c"), "Фантастика" },
                    { new Guid("7add3790-cc5d-4deb-ab68-6732b0f582c1"), new Guid("83f8384a-fc2c-4d98-b3a8-5a867f931361"), "Триллер" },
                    { new Guid("7cd4200b-a4e0-40d6-b9fa-65439a6cfcb5"), new Guid("83f8384a-fc2c-4d98-b3a8-5a867f931361"), "Фантастика" },
                    { new Guid("7d44a080-ada3-4ae8-a186-138c4fca1245"), new Guid("cf259f11-44f1-405f-99af-8f759f83c387"), "Триллер" },
                    { new Guid("7e15f7f1-ed98-4bf3-ba4c-b4ff2d8dcbb8"), new Guid("74d03f01-8ae1-4c6f-be51-8c5d0a435958"), "Фантастика" },
                    { new Guid("7e5a9472-84cb-4c1b-8a30-77b8595ec4e5"), new Guid("62fc461a-83e9-496e-a6b5-fab6cc1b8adf"), "Драма" },
                    { new Guid("8347a4be-4f82-4d66-9959-e400c4134748"), new Guid("4e58585b-4581-4737-908c-7fcc5765c5d5"), "Триллер" },
                    { new Guid("86d59150-cff1-4cb7-b54b-7ccafc989aa4"), new Guid("8dc46d99-c504-4654-919b-baa2e1c92df4"), "Детектив" },
                    { new Guid("8a286a51-6754-4c44-b211-62c75d9c217b"), new Guid("2235d369-639d-4858-9c0c-abd8588c3f0a"), "Фантастика" },
                    { new Guid("8a825fde-fcc0-4927-8a64-d677957b1216"), new Guid("84951f4c-e4f6-4b3f-af74-ca0acdd17e47"), "Ужасы" },
                    { new Guid("8a9fef42-509f-4450-99d4-6dd469b623ce"), new Guid("2235d369-639d-4858-9c0c-abd8588c3f0a"), "Триллер" },
                    { new Guid("8d8b0177-e8a0-4296-af4b-a80a8815740a"), new Guid("5de968e8-e920-4814-91d3-e67450f0f66b"), "Триллер" },
                    { new Guid("8f13d5a9-4b0d-47d2-9d52-250d69ac6fe2"), new Guid("cf259f11-44f1-405f-99af-8f759f83c387"), "Ужасы" },
                    { new Guid("90d3ecff-2095-4916-8a01-43e736c08b2e"), new Guid("e2cb3d51-4e41-46b7-98da-1fe17e83ee40"), "Фантастика" },
                    { new Guid("a05fdaf4-4aab-4e0b-be6c-3430ce6d1c30"), new Guid("3a82b37b-7a41-4c94-ab89-f2a6d1647981"), "Драма" },
                    { new Guid("a608f33e-02ab-4acf-86fb-4d8bd727a34b"), new Guid("84951f4c-e4f6-4b3f-af74-ca0acdd17e47"), "Драма" },
                    { new Guid("a9567e11-6250-4990-8922-3bed4e7a95a1"), new Guid("e2cb3d51-4e41-46b7-98da-1fe17e83ee40"), "Детектив" },
                    { new Guid("aa22573e-6b46-48fe-a66b-38bde7d2b162"), new Guid("e2cb3d51-4e41-46b7-98da-1fe17e83ee40"), "Ужасы" },
                    { new Guid("aa55c76c-d9a7-42c0-a902-44485d46eaf1"), new Guid("2235d369-639d-4858-9c0c-abd8588c3f0a"), "Драма" },
                    { new Guid("ab4bcacd-f666-4dd8-a101-a71f86af3edc"), new Guid("5c7e4f35-7ca4-4f04-9d5a-5f68b176556d"), "Драма" },
                    { new Guid("ac6f12f8-35f6-43dc-a9bf-1babc0191cf8"), new Guid("5c7e4f35-7ca4-4f04-9d5a-5f68b176556d"), "Фантастика" },
                    { new Guid("ae65ab34-6f02-4c60-9d72-fca7ecc73d93"), new Guid("5de968e8-e920-4814-91d3-e67450f0f66b"), "Ужасы" },
                    { new Guid("b019d121-49bb-4c35-9658-dfc6f281b022"), new Guid("74d03f01-8ae1-4c6f-be51-8c5d0a435958"), "Драма" },
                    { new Guid("b0dc3b2f-e3e4-48b7-b01a-c835f32c556d"), new Guid("3a82b37b-7a41-4c94-ab89-f2a6d1647981"), "Фантастика" },
                    { new Guid("b56d4bb7-379d-458a-9f00-e15582d2bdf1"), new Guid("f997d15f-db67-4d76-8004-83d129f2b234"), "Драма" },
                    { new Guid("b8e483f5-9e54-478b-b124-86c6af0e3c94"), new Guid("0c4003ae-7668-4785-9da0-e0c983e35975"), "Ужасы" },
                    { new Guid("bb6445c5-0b30-49be-9560-cfa46fe02752"), new Guid("62fc461a-83e9-496e-a6b5-fab6cc1b8adf"), "Фантастика" },
                    { new Guid("bd592100-7a37-493f-9e72-b3fddb009a08"), new Guid("5c7e4f35-7ca4-4f04-9d5a-5f68b176556d"), "Ужасы" },
                    { new Guid("bfc6960c-ace4-45e3-a541-ca526bc3fc19"), new Guid("4e58585b-4581-4737-908c-7fcc5765c5d5"), "Фантастика" },
                    { new Guid("c0c0cf21-da71-4342-9b4a-3f588240ad2d"), new Guid("84951f4c-e4f6-4b3f-af74-ca0acdd17e47"), "Фантастика" },
                    { new Guid("c1cf8948-4901-4c1d-b0df-661b546c544e"), new Guid("7e1e4355-2766-4341-a7a5-ad1d97d2f143"), "Триллер" },
                    { new Guid("c300b5e3-4987-43cb-ae46-82a5f7f6e369"), new Guid("af3f94c6-348d-439d-a649-06e8f35db631"), "Драма" },
                    { new Guid("c413c51c-5457-4771-bdc4-f045ba0d7403"), new Guid("8dc46d99-c504-4654-919b-baa2e1c92df4"), "Ужасы" },
                    { new Guid("c5bfb88c-1ce4-4de6-9f68-30ba4410d71e"), new Guid("cf259f11-44f1-405f-99af-8f759f83c387"), "Фантастика" },
                    { new Guid("c77cd68f-5aa5-418b-bc9b-10f23fcc20dd"), new Guid("af3f94c6-348d-439d-a649-06e8f35db631"), "Ужасы" },
                    { new Guid("c873ba28-0785-4df0-b2a0-5422ef064173"), new Guid("3a82b37b-7a41-4c94-ab89-f2a6d1647981"), "Ужасы" },
                    { new Guid("cbf55b83-fdad-4b4b-a669-7df61247a9cf"), new Guid("af3f94c6-348d-439d-a649-06e8f35db631"), "Детектив" },
                    { new Guid("ccd99489-c418-4470-a5b0-1ba7bfc4c868"), new Guid("5de968e8-e920-4814-91d3-e67450f0f66b"), "Драма" },
                    { new Guid("d367a978-f0e1-42e0-8c78-460ff833f439"), new Guid("83f8384a-fc2c-4d98-b3a8-5a867f931361"), "Ужасы" },
                    { new Guid("d78c421b-d935-454a-a9a7-960e786a44f7"), new Guid("0c4003ae-7668-4785-9da0-e0c983e35975"), "Триллер" },
                    { new Guid("d8e3dd1d-e10b-46c5-9f34-4a4c2482097d"), new Guid("74d03f01-8ae1-4c6f-be51-8c5d0a435958"), "Ужасы" },
                    { new Guid("df69a0b9-2be4-4a8f-ae05-2f9c03705e5a"), new Guid("2235d369-639d-4858-9c0c-abd8588c3f0a"), "Детектив" },
                    { new Guid("e02263df-06d2-4013-b711-dc2ff0439db9"), new Guid("0c4003ae-7668-4785-9da0-e0c983e35975"), "Детектив" },
                    { new Guid("e3a579c7-9b2e-41f5-9a83-d0b8fc7fb93f"), new Guid("4e58585b-4581-4737-908c-7fcc5765c5d5"), "Детектив" },
                    { new Guid("ea74bb1b-b22d-4c2a-864e-e3e299f14ec9"), new Guid("af3f94c6-348d-439d-a649-06e8f35db631"), "Фантастика" },
                    { new Guid("eae1d646-1517-48bb-b8bd-dee390ba6f29"), new Guid("cf259f11-44f1-405f-99af-8f759f83c387"), "Драма" },
                    { new Guid("ee8d8cf3-d331-437a-a60c-792418c6c66e"), new Guid("8dc46d99-c504-4654-919b-baa2e1c92df4"), "Фантастика" },
                    { new Guid("f2a8f0ac-5454-4dad-a8eb-1b205c264769"), new Guid("7e1e4355-2766-4341-a7a5-ad1d97d2f143"), "Детектив" },
                    { new Guid("f6315bf4-9aac-42e2-82a2-cc99753e7649"), new Guid("08c98868-37c3-47c2-95cd-e94b39871ec4"), "Триллер" },
                    { new Guid("f86c8451-febf-49dc-be1f-6303df264f98"), new Guid("08c98868-37c3-47c2-95cd-e94b39871ec4"), "Ужасы" },
                    { new Guid("fc1c2a86-3eb6-4698-acd5-ebe99a74aefd"), new Guid("7e1e4355-2766-4341-a7a5-ad1d97d2f143"), "Ужасы" },
                    { new Guid("fc3ded5b-cd77-4acd-91a9-d9426d0a2504"), new Guid("d07b4bf0-dc65-4370-9b75-7beae106e40c"), "Драма" }
                });

            migrationBuilder.InsertData(
                table: "Genres",
                columns: new[] { "Id", "GenreName" },
                values: new object[,]
                {
                    { new Guid("3ff8af45-a075-45dd-a1e8-de9147c04310"), "Фантастика" },
                    { new Guid("49d63065-6584-44fb-b464-508914e01321"), "Триллер" },
                    { new Guid("5d4dd301-06c5-4946-ae14-1b835e54ec3c"), "Детектив" },
                    { new Guid("7a1fb135-382f-48d2-a510-a1629f28eb7a"), "Мелодрама" },
                    { new Guid("89e89743-533e-4ba6-b1d0-a482744f2f52"), "Приключение" },
                    { new Guid("8b709613-41ac-444b-a8dd-ad08e2c7ac08"), "Мультфильм" },
                    { new Guid("ae19bdc1-0be5-414b-adfd-8918917c8539"), "Аниме" },
                    { new Guid("c4e281d3-6e31-4fb0-bd55-857bd85cea39"), "Комедия" },
                    { new Guid("e1150fa6-22a4-444e-b083-2bce3daf88e4"), "Боевик" },
                    { new Guid("f40501bc-7bfd-4deb-9c3c-f8bc7ce6a341"), "Ужасы" }
                });

            migrationBuilder.InsertData(
                table: "Serials",
                columns: new[] { "Id", "AgeRating", "Description", "NumEpisodes", "Poster", "Title", "UserRating" },
                values: new object[,]
                {
                    { new Guid("08c98868-37c3-47c2-95cd-e94b39871ec4"), 12, "Адаптация книг Артура Конан Дойля о детективе Шерлоке Холмсе и его напарнике Джоне Ватсоне, в которой действие перенесено в XXI век", 64, "https://avatars.mds.yandex.net/get-kinopoisk-image/1629390/f28c1ea2-47b0-49d5-b11c-9608744f0233/300x450", "Шерлок", 0f },
                    { new Guid("0c4003ae-7668-4785-9da0-e0c983e35975"), 18, "Семь Королевств борются за Железный трон. Самый масштабный и обсуждаемый сериал 2010-х годов", 1000, "https://avatars.mds.yandex.net/get-kinopoisk-image/1777765/dd78edfd-6a1f-486c-9a86-6acbca940418/300x450", "Игра престолов", 0f },
                    { new Guid("2235d369-639d-4858-9c0c-abd8588c3f0a"), 18, "Умирающий учитель химии начинает варить мет ради благополучия семьи. Выдающийся драматический сериал 2010-х", 34, "https://avatars.mds.yandex.net/get-kinopoisk-image/1900788/fb35416f-3b0d-4b96-bc65-cf6923f9e329/300x450", "Во все тяжкие", 0f },
                    { new Guid("74d03f01-8ae1-4c6f-be51-8c5d0a435958"), 16, "Братья Винчестеры стараются не выпустить демонов. Фантастический сериал, вдохновленный «Сумеречной зоной»", 24, "https://avatars.mds.yandex.net/get-kinopoisk-image/4303601/c2c45ca9-0270-4bb2-bb82-5de3f01effbc/300x450", "Сверхъестественное", 0f },
                    { new Guid("7e1e4355-2766-4341-a7a5-ad1d97d2f143"), 12, "Близнецы проводят каникулы у странного прадядюшки. Тайны и аномалии в захватывающем мультсериале Алекса Хирша", 48, "https://avatars.mds.yandex.net/get-kinopoisk-image/1599028/04954219-061a-4646-a7d6-054fdc34b053/300x450", "Гравити Фолз", 0f },
                    { new Guid("83f8384a-fc2c-4d98-b3a8-5a867f931361"), 16, "1980-е годы, тихий провинциальный американский городок. Благоприятное течение местной жизни нарушает загадочное исчезновение подростка по имени Уилл.", 12, "https://avatars.mds.yandex.net/get-kinopoisk-image/4303601/4639b97f-1ff6-4f63-b7f6-02ea1a14f553/300x450", "Очень странные дела", 0f },
                    { new Guid("af3f94c6-348d-439d-a649-06e8f35db631"), 16, "История данного сериала пойдет про гулей и борьбу с ними. Гуль – это некое животное, которое питается людьми, и сейчас все Токио просто кишит ними.", 12, "https://animego.org/media/cache/thumbs_250x350/upload/anime/images/5a662e7da753f.jpg", "Токийский гуль", 0f },
                    { new Guid("f997d15f-db67-4d76-8004-83d129f2b234"), 16, "Друзья пытаются оживить окаменевшее человечество, но у них есть противник. Сай-фай-аниме о борьбе идеологий", 24, "https://avatars.mds.yandex.net/get-kinopoisk-image/1773646/54aae4e5-62b8-4572-8f97-3761743be082/300x450", "Доктор Стоун", 0f }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Episodes");

            migrationBuilder.DropTable(
                name: "Films");

            migrationBuilder.DropTable(
                name: "Genres");

            migrationBuilder.DropTable(
                name: "GenreVideos");

            migrationBuilder.DropTable(
                name: "Ratings");

            migrationBuilder.DropTable(
                name: "Reviews");

            migrationBuilder.DropTable(
                name: "Serials");

            migrationBuilder.DropTable(
                name: "Subscriptions");

            migrationBuilder.DropTable(
                name: "UserFavorites");

            migrationBuilder.DropTable(
                name: "UserSubscriptions");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");
        }
    }
}
