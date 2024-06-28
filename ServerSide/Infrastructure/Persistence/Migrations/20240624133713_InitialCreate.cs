using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Persistence.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Meditations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Duration = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    FotoKey = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    S3UrlFoto = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Meditations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Token = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Role = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    RefreshToken = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RefreshTokenExpiryTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ResetPasswordToken = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ResetPasswordExpiry = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MeditationCategories",
                columns: table => new
                {
                    MeditationId = table.Column<int>(type: "int", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MeditationCategories", x => new { x.CategoryId, x.MeditationId });
                    table.ForeignKey(
                        name: "FK_MeditationCategories_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MeditationCategories_Meditations_MeditationId",
                        column: x => x.MeditationId,
                        principalTable: "Meditations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MeditationPrograms",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MeditationId = table.Column<int>(type: "int", nullable: false),
                    ProgramName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    FotoKey = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    S3UrlFoto = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MeditationPrograms", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MeditationPrograms_Meditations_MeditationId",
                        column: x => x.MeditationId,
                        principalTable: "Meditations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Musics",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    S3UrlAudio = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AudioKey = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Musics", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Musics_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProgramContents",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ContentName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MeditationProgramId = table.Column<int>(type: "int", nullable: false),
                    Duration = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AudioKey = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    S3UrlAudio = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProgramContents", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProgramContents_MeditationPrograms_MeditationProgramId",
                        column: x => x.MeditationProgramId,
                        principalTable: "MeditationPrograms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Ratings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    MeditationProgramId = table.Column<int>(type: "int", nullable: false),
                    Score = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ratings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Ratings_MeditationPrograms_MeditationProgramId",
                        column: x => x.MeditationProgramId,
                        principalTable: "MeditationPrograms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Ratings_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MeditationSessions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    ProgramContentId = table.Column<int>(type: "int", nullable: false),
                    AuditionDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MeditationSessions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MeditationSessions_ProgramContents_ProgramContentId",
                        column: x => x.ProgramContentId,
                        principalTable: "ProgramContents",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MeditationSessions_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CategoryName" },
                values: new object[,]
                {
                    { 1, "Relax" },
                    { 2, "Focus" },
                    { 3, "Stress Relief" },
                    { 4, "Anxiety" },
                    { 5, "Mindfulness" },
                    { 6, "Self-Awareness" },
                    { 7, "Spiritual" },
                    { 8, "Compassion" },
                    { 9, "Breathwork" }
                });

            migrationBuilder.InsertData(
                table: "Meditations",
                columns: new[] { "Id", "CreationDate", "Description", "Duration", "FotoKey", "Name", "S3UrlFoto" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 6, 24, 16, 37, 13, 132, DateTimeKind.Local).AddTicks(3114), "Focuses on being present in the moment and non-judgmentally observing your thoughts and surroundings.", "10-30 minutes", "mindfulness-meditation.jpg", "Mindfulness Meditation", "https://medi-coursework.s3.eu-west-2.amazonaws.com/mindfulness-meditation.jpg" },
                    { 2, new DateTime(2024, 6, 24, 16, 37, 13, 135, DateTimeKind.Local).AddTicks(6452), "Uses a mantra to help quiet the mind and achieve a deep state of relaxation.", "10-30 minutes", "transcendental-meditation.jpg", "Transcendental Meditation", "https://medi-coursework.s3.eu-west-2.amazonaws.com/transcendental-meditation.jpg" },
                    { 3, new DateTime(2024, 6, 24, 16, 37, 13, 135, DateTimeKind.Local).AddTicks(6476), "Involves generating feelings of love and compassion towards oneself and others.", "10-30 minutes", "loving-kindness-meditation.jpg", "Loving-Kindness Meditation", "https://medi-coursework.s3.eu-west-2.amazonaws.com/loving-kindness-meditation.jpg" },
                    { 4, new DateTime(2024, 6, 24, 16, 37, 13, 135, DateTimeKind.Local).AddTicks(6480), "Involves systematically bringing attention to different parts of the body, noticing sensations and relaxing tension.", "10-30 minutes", "body-scan-meditation.jpg", "Body Scan Meditation", "https://medi-coursework.s3.eu-west-2.amazonaws.com/body-scan-meditation.jpg" },
                    { 5, new DateTime(2024, 6, 24, 16, 37, 13, 135, DateTimeKind.Local).AddTicks(6482), "Involves observing the breath and bodily sensations to gain insight into the nature of reality.", "30-60 minutes", "vipassana-meditation.jpg", "Vipassana Meditation", "https://medi-coursework.s3.eu-west-2.amazonaws.com/vipassana-meditation.jpg" },
                    { 6, new DateTime(2024, 6, 24, 16, 37, 13, 135, DateTimeKind.Local).AddTicks(6489), "Involves sitting in silence and focusing on the breath, often with the support of a teacher or group.", "20-40 minutes", "zen-meditation.jpg", "Zen Meditation", "https://medi-coursework.s3.eu-west-2.amazonaws.com/zen-meditation.jpg" },
                    { 7, new DateTime(2024, 6, 24, 16, 37, 13, 135, DateTimeKind.Local).AddTicks(6491), "Involves focusing on each of the body's energy centers to balance and align them.", "10-30 minutes", "chakra-meditation.jpg", "Chakra Meditation", "https://medi-coursework.s3.eu-west-2.amazonaws.com/chakra-meditation.jpg" },
                    { 8, new DateTime(2024, 6, 24, 16, 37, 13, 135, DateTimeKind.Local).AddTicks(6493), "Involves repeating a word or phrase to focus the mind and achieve a calm state.", "10-30 minutes", "mantra-meditation.jpg", "Mantra Meditation", "https://medi-coursework.s3.eu-west-2.amazonaws.com/mantra-meditation.jpg" },
                    { 9, new DateTime(2024, 6, 24, 16, 37, 13, 135, DateTimeKind.Local).AddTicks(6495), "Involves counting each breath to maintain focus and concentration.", "10-30 minutes", "breath-counting-meditation.jpg", "Breath Counting Meditation", "https://medi-coursework.s3.eu-west-2.amazonaws.com/breath-counting-meditation.jpg" },
                    { 10, new DateTime(2024, 6, 24, 16, 37, 13, 135, DateTimeKind.Local).AddTicks(6498), "Involves walking slowly and mindfully, focusing on each step and the sensations in the body.", "10-30 minutes", "walking-meditation.jpg", "Walking Meditation", "https://medi-coursework.s3.eu-west-2.amazonaws.com/walking-meditation.jpg" },
                    { 11, new DateTime(2024, 6, 24, 16, 37, 13, 135, DateTimeKind.Local).AddTicks(6501), "Involves creating a mental image or scenario to promote relaxation and positive emotions.", "10-30 minutes", "visualization-meditation.jpg", "Visualization Meditation", "https://medi-coursework.s3.eu-west-2.amazonaws.com/visualization-meditation.jpg" },
                    { 12, new DateTime(2024, 6, 24, 16, 37, 13, 135, DateTimeKind.Local).AddTicks(6503), "Involves lying down and systematically relaxing different parts of the body to achieve a deep state of relaxation.", "20-40 minutes", "yoga-nidra-meditation.jpg", "Yoga Nidra Meditation", "https://medi-coursework.s3.eu-west-2.amazonaws.com/yoga-nidra-meditation.jpg" },
                    { 13, new DateTime(2024, 6, 24, 16, 37, 13, 135, DateTimeKind.Local).AddTicks(6505), "Involves focusing on a particular sound or a series of sounds to promote relaxation.", "10-30 minutes", "sound-meditation.jpg", "Sound Meditation", "https://medi-coursework.s3.eu-west-2.amazonaws.com/sound-meditation.jpg" },
                    { 14, new DateTime(2024, 6, 24, 16, 37, 13, 135, DateTimeKind.Local).AddTicks(6507), "Involves combining movement, breath, and visualization to improve physical and mental health.", "10-30 minutes", "qi-gong-meditation.jpg", "Qi Gong Meditation", "https://medi-coursework.s3.eu-west-2.amazonaws.com/qi-gong-meditation.jpg" },
                    { 15, new DateTime(2024, 6, 24, 16, 37, 13, 135, DateTimeKind.Local).AddTicks(6510), "Involves combining breathwork, movement, and mantra to awaken the energy at the base of the spine and raise it up through the chakras.", "10-30 minutes", "kundalini-meditation.jpg", "Kundalini Meditation", "https://medi-coursework.s3.eu-west-2.amazonaws.com/kundalini-meditation.jpg" },
                    { 16, new DateTime(2024, 6, 24, 16, 37, 13, 135, DateTimeKind.Local).AddTicks(6512), "Involves sitting in silence and observing the mind without judgment.", "10-60 minutes", "silent-meditation.jpeg", "Silent Meditation", "https://medi-coursework.s3.eu-west-2.amazonaws.com/silent-meditation.jpeg" },
                    { 17, new DateTime(2024, 6, 24, 16, 37, 13, 135, DateTimeKind.Local).AddTicks(6514), "Involves focusing on a specific object or sound to maintain concentration and develop awareness.", "10-30 minutes", "open-monitoring-meditation.jpg", "Open Monitoring Meditation", "https://medi-coursework.s3.eu-west-2.amazonaws.com/open-monitoring-meditation.jpg" },
                    { 18, new DateTime(2024, 6, 24, 16, 37, 13, 135, DateTimeKind.Local).AddTicks(6516), "Involves focusing on a specific object or sound to maintain concentration and develop awareness.", "10-30 minutes", "focused-attention-meditation.jpg", "Focused Attention Meditation", "https://medi-coursework.s3.eu-west-2.amazonaws.com/focused-attention-meditation.jpg" },
                    { 19, new DateTime(2024, 6, 24, 16, 37, 13, 135, DateTimeKind.Local).AddTicks(6518), "Involves cultivating feelings of loving-kindness and compassion towards oneself and others.", "10-30 minutes", "metta-meditation.jpg", "Metta Meditation", "https://medi-coursework.s3.eu-west-2.amazonaws.com/metta-meditation.jpg" },
                    { 20, new DateTime(2024, 6, 24, 16, 37, 13, 135, DateTimeKind.Local).AddTicks(6520), "Involves focusing on the sensations in the body to develop awareness and relaxation.", "10-30 minutes", "body-awareness-meditation.jpg", "Body Awareness Meditation", "https://medi-coursework.s3.eu-west-2.amazonaws.com/body-awareness-meditation.jpg" },
                    { 21, new DateTime(2024, 6, 24, 16, 37, 13, 135, DateTimeKind.Local).AddTicks(6522), "Involves cultivating feelings of empathy and compassion towards oneself and others.", "10-30 minutes", "", "Compassion Meditation", "" },
                    { 22, new DateTime(2024, 6, 24, 16, 37, 13, 135, DateTimeKind.Local).AddTicks(6524), "Involves listening to the sound of a singing bowl to promote relaxation and focus.", "10-30 minutes", "", "Singing Bowl Meditation", "" },
                    { 23, new DateTime(2024, 6, 24, 16, 37, 13, 135, DateTimeKind.Local).AddTicks(6526), "Involves tensing and relaxing different muscle groups to promote relaxation and reduce tension.", "10-30 minutes", "", "Progressive Muscle Relaxation", "" },
                    { 24, new DateTime(2024, 6, 24, 16, 37, 13, 135, DateTimeKind.Local).AddTicks(6528), "Involves following the instructions of a teacher or audio recording to promote relaxation and awareness.", "10-30 minutes", "", "Guided Meditation", "" },
                    { 25, new DateTime(2024, 6, 24, 16, 37, 13, 135, DateTimeKind.Local).AddTicks(6530), "Involves eating slowly and mindfully, focusing on the taste, texture, and sensations of the food.", "10-30 minutes", "", "Mindful Eating Meditation", "" },
                    { 26, new DateTime(2024, 6, 24, 16, 37, 13, 135, DateTimeKind.Local).AddTicks(6532), "Involves focusing on the breath to promote relaxation and develop awareness.", "10-30 minutes", "", "Mindful Breathing Meditation", "" },
                    { 27, new DateTime(2024, 6, 24, 16, 37, 13, 135, DateTimeKind.Local).AddTicks(6534), "Involves cultivating feelings of compassion and empathy towards oneself and others.", "", "", "Compassionate Mind Meditation", "" },
                    { 28, new DateTime(2024, 6, 24, 16, 37, 13, 135, DateTimeKind.Local).AddTicks(6536), "Involves connecting with a higher power or spiritual practice to promote relaxation and inner peace.", "10-30 minutes", "", "Spiritual Meditation", "" },
                    { 29, new DateTime(2024, 6, 24, 16, 37, 13, 135, DateTimeKind.Local).AddTicks(6538), "Involves repeating a sound or phrase to promote relaxation and focus.", "10-30 minutes", "", "Chanting Meditation", "" },
                    { 30, new DateTime(2024, 6, 24, 16, 37, 13, 135, DateTimeKind.Local).AddTicks(6540), "Involves focusing on the area between the eyebrows to promote relaxation and develop intuition.", "10-30 minutes", "", "Third Eye Meditation", "" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "FirstName", "LastName", "Password", "RefreshToken", "RefreshTokenExpiryTime", "ResetPasswordExpiry", "ResetPasswordToken", "Role", "Token", "UserName" },
                values: new object[,]
                {
                    { 1, "alex21@example.com", "Alex", "Verenchuk", "0+KfAo47rbIvnDWoGTjUTK0PczQ+v/Il9HBF4pDvjTNv6Adi", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Admin", null, "alex21" },
                    { 2, "asmith@example.com", "Alice", "Smith", "3aU0kBylMEB2BKDGSx9E09QRYNE2y60YZ4woVNrWhfdfjPKf", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "User", null, "asmith" },
                    { 3, "bobj@example.com", "Bob", "Johnson", "ct2emvN2Ks58RxMaQDUj4QC7w7Kh6huaaEp/gObk+CoIh+1l", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "User", null, "bobj" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "FirstName", "LastName", "Password", "RefreshToken", "RefreshTokenExpiryTime", "ResetPasswordExpiry", "ResetPasswordToken", "Role", "Token", "UserName" },
                values: new object[,]
                {
                    { 4, "emilyb@example.com", "Emily", "Brown", "LU3UCSpYJ7fx0hhq4HtYJ8ske/gaUmSVqv7gBqgBEZfTlJpA", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "User", null, "emilyb" },
                    { 5, "michaelw@example.com", "Michael", "Wilson", "FOlRhfjF9e0IRxZe40MBsI6V32WqVkdMp9rWJoQD/4nf8egi", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "User", null, "michaelw" },
                    { 6, "sophiag@example.com", "Sophia", "Garcia", "WK7sb2dakxpUeCRRcRMqCipxpPxCaDldk4H0ZHGuyRqROfoc", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "User", null, "sophiag" },
                    { 7, "davidm@example.com", "David", "Martinez", "NlRyHgfOjJPF56pcFXFBQ4+sfIVMLmuFl+9VNP3ysHJR4ZHp", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "User", null, "davidm" },
                    { 8, "olivial@example.com", "Olivia", "Lopez", "4p8UZX9oQyrigvghVYosaczLpgy5Es5/JkvpgWVOAljziu9Q", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "User", null, "olivial" },
                    { 9, "jamesh@example.com", "James", "Hernandez", "CajzHtrS59LWeJJHM2JUs2AbDpfjSFbfwaDp4uedk9UUGdon", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "User", null, "jamesh" },
                    { 10, "emmag@example.com", "Emma", "Gonzalez", "iJSGXivQ7o7AVPUavXsCQWeg3yIiaYJNd/NxsdK75lBk3hUF", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "User", null, "emmag" },
                    { 11, "olga22@example.com", "Olga", "Petrenko", "1kq9v9SnhEYxgwNUlkqq4+S1gKseUJo/Z1T5PQJffKQMkdDn", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "User", null, "olga22" },
                    { 12, "olga12@example.com", "Olga", "Ivanova", "N/3vxoQhfhl+kBqW9XYRUewRzGMq5SBxAh1ANQrl8uIuK921", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "User", null, "olga12" },
                    { 13, "ivan23@example.com", "Ivan", "Ivanov", "hYIpoEKeL7ag0b8NiInteE43SnISO9o1XbKsHFhcuvvnL5CL", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "User", null, "ivan23" },
                    { 14, "maria24@example.com", "Maria", "Shevchenko", "dOKFmiNsxG41sRYn9ePe/itSSfr/2snVhstJeTugQEKdAC1/", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "User", null, "maria24" },
                    { 15, "petro25@example.com", "Petro", "Kovalenko", "Vy8cQRLcXDueWCKOah8Wd3jfgUi3xe4d+DSLCG8e+/9aElnT", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "User", null, "petro25" },
                    { 16, "natalia26@example.com", "Natalia", "Skrypka", "N9VZWYUycuRMcvqu0hkckp6IZF36tMqUCqF9KnC0BYcqzv+g", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "User", null, "natalia26" },
                    { 17, "sergiy27@example.com", "Sergiy", "Bondarenko", "IX5FXtVeD3J7LNF7QCHoUiwrrwPgmGlcqD5+7pj8LCmuJ/8L", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "User", null, "sergiy27" },
                    { 18, "yulia28@example.com", "Yulia", "Hrytsenko", "+oO/p/XccBK44OUN6Bv6bK62N5KOK6UaWtrEPBCI4nmUsNW8", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "User", null, "yulia28" },
                    { 19, "andriy29@example.com", "Andriy", "Tkachuk", "PfOPv0yH6t5fm//tWrFEy0rGRnpnurwz5xWWP1VUeKNmCxOa", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "User", null, "andriy29" },
                    { 20, "larysa30@example.com", "Larysa", "Didenko", "61tjBLPcGZrpR7V+kkjBd80y1ZjGGhv7ZB9fHb9yGDlixCsi", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "User", null, "larysa30" },
                    { 21, "anna31@example.com", "Anna", "Kravchenko", "KVR5Vhmu7auHgwcGf7aSu398tWEzVNMuUIpzthkdInbjFKq7", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "User", null, "anna31" },
                    { 22, "viktor32@example.com", "Viktor", "Sydorenko", "JyCvyugdJxQlIB7JcO3S7PInsJmb+qVDdV30KLFl+9FjjQYM", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "User", null, "viktor32" },
                    { 23, "daria33@example.com", "Daria", "Moroz", "IrV3iCDW84iG7XumaxvKdOjdtiGFhoY5EYlk8wtrQXxf1Xid", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "User", null, "daria33" },
                    { 24, "bohdan34@example.com", "Bohdan", "Rudenko", "30Y+mdftDYz1EYQJ1poCvMPneXdhlLGu8aF8sKuHBckHdiAz", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "User", null, "bohdan34" },
                    { 25, "halyna35@example.com", "Halyna", "Zinchenko", "MgRfwNJKJAHjjgLMlz5jRfjS99GGHUb2Xg3GMReJYuYueh9r", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "User", null, "halyna35" },
                    { 26, "roman36@example.com", "Roman", "Melnyk", "qPz8aFN7tYNsW0UahMrf8VrIVI5bNff1+FLVUJBFSoXS2FYI", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "User", null, "roman36" },
                    { 27, "tetiana37@example.com", "Tetiana", "Tkachenko", "GhIJrxbRxMtfHdtznmbGTlrUjCu2kc8het+kozVvBTJ/lqmb", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "User", null, "tetiana37" },
                    { 28, "yaroslav38@example.com", "Yaroslav", "Marchenko", "J5FhEk5jC6vFSOdXnlaYqnTGpLoBaWczjENK7wa7OeGP5rHI", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "User", null, "yaroslav38" },
                    { 29, "mykola39@example.com", "Mykola", "Horodetsky", "jyetpp8JFeLtvvfV8j6pP4mWmBRe1ktwZee5SmByskABp/Nn", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "User", null, "mykola39" },
                    { 30, "valeria40@example.com", "Valeria", "Litvin", "gAO/n2et8TdOSDpQI+D0h+hlHSr6dQZz5K4HqMLwmw6aRAZz", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "User", null, "valeria40" },
                    { 31, "oksana41@example.com", "Oksana", "Poltava", "AjHIGZugI8xqfEWK3v9f9IATSF8gD+ZpiauMM35IqTQ91rZd", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "User", null, "oksana41" },
                    { 32, "vladyslav42@example.com", "Vladyslav", "Bondar", "FLqUTo7fgBv6z+yHvBcxzLi3BaLur6JD3IXVOx4pL1idXZzt", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "User", null, "vladyslav42" },
                    { 33, "svitlana43@example.com", "Svitlana", "Lysenko", "6968QQo+ZQ941drDwcNRcZIqidGNdT3Gso7uQ4FLY542or6i", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "User", null, "svitlana43" },
                    { 34, "artem44@example.com", "Artem", "Levchenko", "UrOB1MkcszaT9bqKV1QyqxBx3Fe/99EdWOJLPvTOJovZv6Yi", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "User", null, "artem44" },
                    { 35, "iryna45@example.com", "Iryna", "Sokolova", "AERnOIPei8yZRB1YrtiXjrbEI2kFcvWAjrNxcmnmJebMvZU2", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "User", null, "iryna45" },
                    { 36, "denys46@example.com", "Denys", "Chernysh", "V5lKKejUQr6AV54QZoN1fYIgg712QGBTpbCRFuRUfF4+D1WF", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "User", null, "denys46" },
                    { 37, "vasyl47@example.com", "Vasyl", "Hryhorovych", "aEwG/lmgOJ4ZRb5lqwfhca6j+137sr8ixqC4rYBN2cGHNiuL", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "User", null, "vasyl47" },
                    { 38, "hanna48@example.com", "Hanna", "Semenivna", "+dQoSoc9ChDVf722PX7VAS0AAK/i9x2wIvzsEXLn9XftSQiF", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "User", null, "hanna48" },
                    { 39, "viktor49@example.com", "Viktor", "Mykhailovych", "Y5txd2I3cFHpD0nfMQMI7mQ6sidiSeDs5uYTUrrs8UPLi+l2", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "User", null, "viktor49" },
                    { 40, "maryna50@example.com", "Maryna", "Oleksandrivna", "LG8AW3lNn+4/C6U4HzU2qEKkeB9ReS08LlsSK3+Wu5+VyxDa", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "User", null, "maryna50" }
                });

            migrationBuilder.InsertData(
                table: "MeditationCategories",
                columns: new[] { "CategoryId", "MeditationId" },
                values: new object[,]
                {
                    { 1, 2 },
                    { 1, 4 },
                    { 1, 8 },
                    { 1, 11 },
                    { 1, 12 },
                    { 1, 13 },
                    { 1, 22 },
                    { 1, 23 },
                    { 1, 24 },
                    { 1, 29 },
                    { 2, 6 },
                    { 2, 7 },
                    { 2, 8 },
                    { 2, 9 },
                    { 2, 11 },
                    { 2, 16 },
                    { 2, 18 },
                    { 2, 22 },
                    { 2, 29 },
                    { 2, 30 },
                    { 3, 4 },
                    { 3, 12 },
                    { 3, 23 },
                    { 3, 24 },
                    { 4, 26 },
                    { 5, 1 },
                    { 5, 5 },
                    { 5, 10 },
                    { 5, 17 },
                    { 5, 25 },
                    { 5, 26 },
                    { 6, 1 },
                    { 6, 4 },
                    { 6, 5 },
                    { 6, 20 },
                    { 6, 24 },
                    { 7, 15 },
                    { 7, 28 },
                    { 7, 30 },
                    { 8, 3 },
                    { 8, 19 },
                    { 8, 21 }
                });

            migrationBuilder.InsertData(
                table: "MeditationCategories",
                columns: new[] { "CategoryId", "MeditationId" },
                values: new object[,]
                {
                    { 8, 27 },
                    { 9, 7 },
                    { 9, 14 },
                    { 9, 15 },
                    { 9, 26 }
                });

            migrationBuilder.InsertData(
                table: "MeditationPrograms",
                columns: new[] { "Id", "FotoKey", "MeditationId", "ProgramName", "S3UrlFoto" },
                values: new object[,]
                {
                    { 1, "metta-meditation.jpg", 1, "Dreamy Breeze", "https://medi-coursework.s3.eu-west-2.amazonaws.com/metta-meditation.jpg" },
                    { 2, "6cd7496c-b1f0-4906-8df9-4ba5c93ba21e.png", 1, "Peace of the Lake", "https://medi-coursework.s3.eu-west-2.amazonaws.com/6cd7496c-b1f0-4906-8df9-4ba5c93ba21e.png" },
                    { 3, "zen-meditation.jpg", 2, "Silent Symphony", "https://medi-coursework.s3.eu-west-2.amazonaws.com/zen-meditation.jpg" },
                    { 4, "mantra-meditation.jpg", 2, "Calm Waters", "https://medi-coursework.s3.eu-west-2.amazonaws.com/mantra-meditation.jpg" },
                    { 5, "walking-meditation.jpg", 3, "Deep Equilibrium", "https://medi-coursework.s3.eu-west-2.amazonaws.com/walking-meditation.jpg" },
                    { 6, "yoga-nidra-meditation.jpg", 3, "Transcendental Tranquility", "https://medi-coursework.s3.eu-west-2.amazonaws.com/yoga-nidra-meditation.jpg" },
                    { 7, "kundalini-meditation.jpg", 4, "Path to Inner Peace", "https://medi-coursework.s3.eu-west-2.amazonaws.com/kundalini-meditation.jpg" },
                    { 8, "open-monitoring-meditation.jpg", 4, "Conscious Immersion", "https://medi-coursework.s3.eu-west-2.amazonaws.com/open-monitoring-meditation.jpg" },
                    { 9, "metta-meditation.jpg", 5, "Kindness Unfolding Practice", "https://medi-coursework.s3.eu-west-2.amazonaws.com/metta-meditation.jpg" },
                    { 10, "body-awareness-meditation.jpg", 5, "Radiant Love Meditation", "https://medi-coursework.s3.eu-west-2.amazonaws.com/body-awareness-meditation.jpg" },
                    { 11, "focused-attention-meditation.jpg", 6, "Meditation of Compassionate Hearts", "https://medi-coursework.s3.eu-west-2.amazonaws.com/focused-attention-meditation.jpg" },
                    { 12, "silent-meditation.jpeg", 6, "Mindful Body Unveiling", "https://medi-coursework.s3.eu-west-2.amazonaws.com/silent-meditation.jpeg" },
                    { 13, "qi-gong-meditation.jpg", 7, "Somatic Awareness Practice", "https://medi-coursework.s3.eu-west-2.amazonaws.com/qi-gong-meditation.jpg" },
                    { 14, "sound-meditation.jpg", 7, "Sensory Body Exploration", "https://medi-coursework.s3.eu-west-2.amazonaws.com/sound-meditation.jpg" },
                    { 15, "visualization-meditation.jpg", 8, "Insightful Mindfulness Practice", "https://medi-coursework.s3.eu-west-2.amazonaws.com/visualization-meditation.jpg" },
                    { 16, "visualization-meditation.jpg", 8, "Quiet Stream", "https://medi-coursework.s3.eu-west-2.amazonaws.com/visualization-meditation.jpg" },
                    { 17, "visualization-meditation.jpg", 9, "Breath count", "https://medi-coursework.s3.eu-west-2.amazonaws.com/visualization-meditation.jpg" },
                    { 18, "visualization-meditation.jpg", 9, "Breathing harmony", "https://medi-coursework.s3.eu-west-2.amazonaws.com/visualization-meditation.jpg" },
                    { 19, "visualization-meditation.jpg", 10, "The way to peace", "https://medi-coursework.s3.eu-west-2.amazonaws.com/visualization-meditation.jpg" },
                    { 20, "visualization-meditation.jpg", 10, "Calm step", "https://medi-coursework.s3.eu-west-2.amazonaws.com/visualization-meditation.jpg" },
                    { 21, "visualization-meditation.jpg", 11, "Visualization of dreams", "https://medi-coursework.s3.eu-west-2.amazonaws.com/visualization-meditation.jpg" },
                    { 22, "visualization-meditation.jpg", 12, "Conscious immersion", "https://medi-coursework.s3.eu-west-2.amazonaws.com/visualization-meditation.jpg" },
                    { 23, "visualization-meditation.jpg", 13, "Perception of sounds", "https://medi-coursework.s3.eu-west-2.amazonaws.com/visualization-meditation.jpg" },
                    { 24, "visualization-meditation.jpg", 14, "Harmony of energy", "https://medi-coursework.s3.eu-west-2.amazonaws.com/visualization-meditation.jpg" },
                    { 25, "visualization-meditation.jpg", 15, "Internal recovery", "https://medi-coursework.s3.eu-west-2.amazonaws.com/visualization-meditation.jpg" },
                    { 26, "visualization-meditation.jpg", 16, "Perception of silence", "https://medi-coursework.s3.eu-west-2.amazonaws.com/visualization-meditation.jpg" },
                    { 27, "visualization-meditation.jpg", 17, "Open observation", "https://medi-coursework.s3.eu-west-2.amazonaws.com/visualization-meditation.jpg" },
                    { 28, "visualization-meditation.jpg", 18, "Internal focus", "https://medi-coursework.s3.eu-west-2.amazonaws.com/visualization-meditation.jpg" },
                    { 29, "visualization-meditation.jpg", 19, "The perception of love", "https://medi-coursework.s3.eu-west-2.amazonaws.com/visualization-meditation.jpg" },
                    { 30, "visualization-meditation.jpg", 20, "Dive into inner space", "https://medi-coursework.s3.eu-west-2.amazonaws.com/visualization-meditation.jpg" }
                });

            migrationBuilder.InsertData(
                table: "ProgramContents",
                columns: new[] { "Id", "AudioKey", "ContentName", "Duration", "MeditationProgramId", "S3UrlAudio" },
                values: new object[,]
                {
                    { 1, "Dreamy Breeze.mp3", "Day 1", "10:35", 1, "https://medi-coursework.s3.eu-west-2.amazonaws.com/Dreamy+Breeze.mp3" },
                    { 2, "Peace of the Lake.mp3", "Day 2", "10:30", 1, "https://medi-coursework.s3.eu-west-2.amazonaws.com/Peace+of+the+Lake.mp3" },
                    { 3, "Silent Symphony.mp3", "Day 3", "10:01", 1, "https://medi-coursework.s3.eu-west-2.amazonaws.com/Silent+Symphony.mp3" },
                    { 4, "Calm Waters.mp3", "Day 4", "20:32", 1, "https://medi-coursework.s3.eu-west-2.amazonaws.com/Calm+Waters.mp3" },
                    { 5, "Deep Equilibrium.mp3", "Day 5", "13:00", 1, "https://medi-coursework.s3.eu-west-2.amazonaws.com/Deep+Equilibrium.mp3" },
                    { 6, "Transcendental Tranquility.mp3", "Day 1", "20:26", 2, "https://medi-coursework.s3.eu-west-2.amazonaws.com/Transcendental+Tranquility.mp3" },
                    { 7, "Path to Inner Peace.mp3", "Day 2", "10:21", 2, "https://medi-coursework.s3.eu-west-2.amazonaws.com/Path+to+Inner+Peace.mp3" },
                    { 8, "Conscious Immersion.mp3", "Day 3", "26:31", 2, "https://medi-coursework.s3.eu-west-2.amazonaws.com/Conscious+Immersion.mp3" },
                    { 9, "Kindness Unfolding Practice.mp3", "Day 1", "22:38", 3, "https://medi-coursework.s3.eu-west-2.amazonaws.com/Kindness+Unfolding+Practice.mp3" },
                    { 10, "Radiant Love Meditation.mp3", "Day 2", "10:10", 3, "https://medi-coursework.s3.eu-west-2.amazonaws.com/Radiant+Love+Meditation.mp3" },
                    { 11, "Meditation of Compassionate Hearts.mp3", "Day 3", "10:07", 3, "https://medi-coursework.s3.eu-west-2.amazonaws.com/Meditation+of+Compassionate+Hearts.mp3" },
                    { 12, "Mindful Body Unveiling.mp3", "Day 1", "21:26", 4, "https://medi-coursework.s3.eu-west-2.amazonaws.com/Mindful+Body+Unveiling.mp3" },
                    { 13, "Somatic Awareness Practice.mp3", "Day 2", "11:38", 4, "https://medi-coursework.s3.eu-west-2.amazonaws.com/Somatic+Awareness+Practice.mp3" },
                    { 14, "Sensory Body Exploration.mp3", "Day 3", "10:00", 4, "https://medi-coursework.s3.eu-west-2.amazonaws.com/Sensory+Body+Exploration.mp3" },
                    { 15, "Insightful Mindfulness Practice.mp3", "Day 1", "30:02", 5, "https://medi-coursework.s3.eu-west-2.amazonaws.com/Insightful+Mindfulness+Practice.mp3" }
                });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "MeditationProgramId", "Score", "UserId" },
                values: new object[] { 1, 5, 5, 2 });

            migrationBuilder.CreateIndex(
                name: "IX_MeditationCategories_MeditationId",
                table: "MeditationCategories",
                column: "MeditationId");

            migrationBuilder.CreateIndex(
                name: "IX_MeditationPrograms_MeditationId",
                table: "MeditationPrograms",
                column: "MeditationId");

            migrationBuilder.CreateIndex(
                name: "IX_MeditationSessions_ProgramContentId",
                table: "MeditationSessions",
                column: "ProgramContentId");

            migrationBuilder.CreateIndex(
                name: "IX_MeditationSessions_UserId",
                table: "MeditationSessions",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Musics_UserId",
                table: "Musics",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_ProgramContents_MeditationProgramId",
                table: "ProgramContents",
                column: "MeditationProgramId");

            migrationBuilder.CreateIndex(
                name: "IX_Ratings_MeditationProgramId",
                table: "Ratings",
                column: "MeditationProgramId");

            migrationBuilder.CreateIndex(
                name: "IX_Ratings_UserId",
                table: "Ratings",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MeditationCategories");

            migrationBuilder.DropTable(
                name: "MeditationSessions");

            migrationBuilder.DropTable(
                name: "Musics");

            migrationBuilder.DropTable(
                name: "Ratings");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "ProgramContents");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "MeditationPrograms");

            migrationBuilder.DropTable(
                name: "Meditations");
        }
    }
}
