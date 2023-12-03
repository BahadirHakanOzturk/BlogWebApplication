using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Blog.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NameSurname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    About = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Contacts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Mail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Subject = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Message = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contacts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "NewsLetters",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Mail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NewsLetters", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Notifications",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TypeSymbol = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Details = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Color = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notifications", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<int>(type: "int", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
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
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
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
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<int>(type: "int", nullable: false)
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
                    UserId = table.Column<int>(type: "int", nullable: false),
                    RoleId = table.Column<int>(type: "int", nullable: false)
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
                    UserId = table.Column<int>(type: "int", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
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

            migrationBuilder.CreateTable(
                name: "Messages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SenderId = table.Column<int>(type: "int", nullable: false),
                    ReceiverId = table.Column<int>(type: "int", nullable: false),
                    Subject = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Details = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Messages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Messages_AspNetUsers_ReceiverId",
                        column: x => x.ReceiverId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Messages_AspNetUsers_SenderId",
                        column: x => x.SenderId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Blogs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Blogs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Blogs_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Blogs_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Comments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BlogId = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Comments_Blogs_BlogId",
                        column: x => x.BlogId,
                        principalTable: "Blogs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { 1, null, "Admin", "ADMIN" },
                    { 2, null, "Writer", "WRITER" },
                    { 3, null, "Member", "MEMBER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "About", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "ImageUrl", "LockoutEnabled", "LockoutEnd", "NameSurname", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "Title", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { 1, "Lorem ipsum dolor sit, amet consectetur adipisicing elit. Illo, adipisci!", 0, "e5bdb296-fc68-43e7-bf90-74349bdce6cc", "bahadirhakanozturk@blog.com", true, "/Admin/img/a1.jpg", true, null, "Bahadır Hakan Öztürk", "BAHADIRHAKANOZTURK@BLOG.COM", "BAHADIRHAKANOZTURK", "AQAAAAIAAYagAAAAEAcAQO9c+vNbz0xyXf8YOWTZIzq0J9ZOc5bFIVDm8kh8ankLxq16ZVYEH4YJcGWk6A==", null, true, "D2C7BG653KANTFOB6NNHCOSN2R7GM27B", ".Net Geliştiricisi", false, "bahadirhakanozturk" },
                    { 2, "Lorem ipsum dolor sit, amet Lorem ipsum dolor sit, amet consectetur adipisicing consectetur adipisicing elit. Illo, adipisci!", 0, "15b4e915-cc9a-4102-9250-782262ac0eea", "elifbetulozturk@blog.com", true, "/web/images/t2.jpg", true, null, "Elif Betül Öztürk", "ELIFBETULOZTURK@BLOG.COM", "ELIFBETULOZTURK", "AQAAAAIAAYagAAAAENV76wX++TU3XAZ6RIm/AT0bSSQTtEfbB6HlgjxgdfcqSMGx+o5git5x5iF7gfvmbA==", null, true, "D2C7BG653KANTFOB6NNHCOSN2R7GM27A", "Yazılım Geliştiricisi", false, "elifbetulozturk" },
                    { 3, "Lorem ipsum dolor consectetur adipisicing elit.  sit, amet consectetur adipisicing elit. Illo, adipisci!", 0, "3b2814ae-2b37-42cd-9c70-992a983f9da7", "cemkaya@blog.com", true, "/web/images/t3.jpg", true, null, "Cem Kaya", "CEMKAYA@BLOG.COM", "CEMKAYA", "AQAAAAIAAYagAAAAEEmeoUTVcdEes82Ob2DhNneppgvfJfJwiLfjABmcHvnusxwSC/XbkPm4784GdXu2Mw==", null, true, "D2C7BG653KANTFOB6NNHCOSN2R7GM27C", "Yazar", false, "cemkaya" },
                    { 4, "Lorem ipsum dolor sit, Lorem ipsum dolor sit, amet consectetur adipisicing elit. Illo, adipisci!", 0, "1c5f14f9-585c-49a0-9ce0-72aa330e2f10", "aysecinar@blog.com", true, "/web/images/t4.jpg", true, null, "Ayşe Çınar", "AYSECINAR@BLOG.COM", "AYSECINAR", "AQAAAAIAAYagAAAAEKLp2DsMwD/L9QCd4sfrIlNDbT5lTsXsf6q5C7PFHMn86g/WEimGN0I1lkAfqCiZOw==", null, true, "D2C7BG653KANTFOB6NNHCOSN2R7GM27D", null, false, "aysecinar" },
                    { 5, "Lorem ipsum dolor sit, amet consectetur adipisicing elit. Illo, adipisci! Illo, adipisci! Illo, adipisci!", 0, "4eb21eb4-3d42-4b63-b2b9-743c14b43664", "hakkican@blog.com", true, "/Admin/img/a4.jpg", true, null, "Hakkı Can", "HAKKICAN@BLOG.COM", "HAKKICAN", "AQAAAAIAAYagAAAAEEOI0SGNN9Ty6dtFdGSOPpaNKj/VShVJsiYis+n7bWo4aVhCC5Z+41GXGA6pfKoWmg==", null, true, "D2C7BG653KANTFOB6NNHCOSN2R7GM27S", null, false, "hakkican" }
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Description", "Name", "Status" },
                values: new object[,]
                {
                    { 1, null, "Yazılım", true },
                    { 2, null, "Oyun", true },
                    { 3, null, "Film", true },
                    { 4, null, "Teknoloji", true }
                });

            migrationBuilder.InsertData(
                table: "Notifications",
                columns: new[] { "Id", "Color", "Date", "Details", "Status", "Type", "TypeSymbol" },
                values: new object[,]
                {
                    { 1, "preview-icon bg-success", new DateTime(2022, 9, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Lorem ipsum dolor consectetur adipisicing elit.", true, "Günük Toplantı", "mdi mdi-calendar" },
                    { 2, "preview-icon bg-warning", new DateTime(2023, 1, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "Lorem ipsum dolor sit, amet consectetur adipisicing elit.Lorem ipsum dolor sit, amet consectetur adipisicing elit.", true, "Doğum Günü", "mdi mdi-settings" },
                    { 3, "preview-icon bg-info", new DateTime(2023, 11, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Illo, adipisci!", true, "Sistem Bakımı", "mdi mdi-link-variant" },
                    { 4, "preview-icon bg-primary", new DateTime(2023, 11, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "Lorem ipsum dolor sit, amet consectetur adipisicing elit. Illo, adipisci!", true, "Yeni Yazı", "mdi mdi-apple" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 2, 2 },
                    { 2, 3 },
                    { 2, 4 },
                    { 3, 5 }
                });

            migrationBuilder.InsertData(
                table: "Blogs",
                columns: new[] { "Id", "CategoryId", "Content", "CreateDate", "ImageUrl", "Status", "Title", "UserId" },
                values: new object[,]
                {
                    { 1, 4, "Lorem ipsum dolor, sit amet consectetur adipisicing elit. Architecto, rerum aliquid? Quam culpa quis inventore recusandae itaque. Quo quas tempora, voluptatibus ab, sunt quis ex quasi fugiat iusto modi explicabo quos rerum consequatur quibusdam fuga laborum iure nam architecto. Placeat qui hic porro suscipit voluptate. Placeat aliquid animi delectus perspiciatis quidem, quo illum nihil obcaecati quisquam, modi, eius unde impedit deleniti sunt eligendi voluptates reprehenderit. Nihil incidunt dolor blanditiis sequi illum, neque molestias quidem laborum dolore ea ipsam at culpa inventore facilis aperiam impedit quo nostrum atque architecto accusamus. Optio praesentium impedit eveniet deleniti atque amet aperiam ab, recusandae quaerat nihil culpa magnam eligendi sapiente ea fugit, accusantium temporibus voluptates dolorum sit aut est. Dolore dolores, consequuntur minus ipsa, eos exercitationem similique quibusdam quos inventore earum maxime molestiae, id ut omnis blanditiis alias sunt totam ad ex consequatur assumenda nihil excepturi dolorum? Molestias at, blanditiis magni libero neque recusandae suscipit voluptatem quibusdam delectus impedit earum illo reprehenderit eligendi quasi labore laudantium iure nam similique quis eum velit. Soluta unde odio explicabo est vel. Quo placeat culpa accusantium similique voluptas aliquam libero nisi saepe vero, iusto totam tenetur pariatur facere commodi, necessitatibus explicabo sapiente fugit hic quisquam modi! Nisi, impedit voluptatibus.", new DateTime(2023, 3, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "/web/images/5.jpg", true, "İphone 15 Tanıtıldı", 2 },
                    { 2, 3, "Lorem ipsum dolor sit amet consectetur adipisicing elit. Inventore, iusto reprehenderit quisquam officiis quae illo ab facere veniam, commodi consequatur corrupti aut a suscipit, nam omnis? Dolor, totam! Esse, eveniet expedita in amet necessitatibus dignissimos, asperiores optio adipisci sapiente obcaecati nam? Enim numquam soluta voluptas, ducimus ab nobis consequatur. Cumque eaque expedita voluptates minima, nostrum laborum itaque obcaecati delectus aliquam officiis illo, repudiandae alias sapiente. Ullam culpa libero perferendis id praesentium nemo autem odit illum totam! Totam quae natus aliquid sunt? Illo, at sed? Ab, id? Ut culpa eaque, in deserunt dicta corporis animi numquam repudiandae porro libero totam amet tempore non ducimus odio hic fugit! Nobis consectetur quibusdam ullam velit sapiente praesentium aspernatur voluptates omnis voluptas delectus nam quisquam magni deserunt, cumque impedit, totam quae atque optio officia esse facilis! Fuga, veritatis obcaecati. Omnis, nulla natus! Ipsam, blanditiis autem excepturi, ullam ducimus ut eligendi officiis aperiam ipsum numquam laborum sapiente doloremque consequatur placeat voluptatum quisquam at saepe dolores iure maiores. Dignissimos eos atque eligendi impedit itaque eveniet cum id quod tenetur quam illo soluta optio nihil maxime, corrupti alias fugit iusto unde officia repellat. Deleniti, veniam! Quod sed vitae rem blanditiis similique unde molestias dignissimos nisi possimus. Eum, itaque?", new DateTime(2021, 8, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "/web/images/2.jpg", true, "Kimyager: Walter White", 2 },
                    { 3, 2, "Lorem ipsum dolor sit amet consectetur adipisicing elit. Magni quos harum in! Deserunt dicta dolore, ea vero eos fugit expedita voluptatum eius pariatur error assumenda nihil, illo quaerat a alias, obcaecati animi quibusdam quam consectetur quisquam fugiat? Sequi quas eos temporibus officiis excepturi sunt vero praesentium id quibusdam! Officiis ab repellat inventore qui enim quae ipsum consequuntur, temporibus harum culpa maxime est doloribus provident a magnam unde at saepe nostrum similique eaque corrupti adipisci dolor amet commodi! Atque id aspernatur impedit molestiae autem? Impedit rerum inventore molestiae ipsa similique aliquam iste amet debitis placeat! Fugit praesentium eligendi officiis ullam, sint distinctio, neque ratione maiores consequatur in, quasi facilis nesciunt dolorem. Fugiat quibusdam harum impedit tempore ipsa, tenetur ipsum id deleniti?", new DateTime(2022, 4, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), "/web/images/3.jpg", true, "Fifa 2024 Ekim Sonunda Çıkıyor", 3 },
                    { 4, 3, "Lorem ipsum, dolor sit amet consectetur adipisicing elit. Iure corporis quasi sunt exercitationem, consequatur, optio dolores eum totam omnis nesciunt dolor veniam repudiandae atque alias veritatis iusto? Odit voluptatibus sapiente aliquid. Dicta dolores possimus harum voluptas iusto labore, mollitia atque alias id debitis dignissimos in cum illo corrupti! Doloremque quod, necessitatibus ducimus saepe optio iusto possimus quasi at sed magnam fuga perspiciatis beatae vero modi recusandae fugit! Saepe doloremque veritatis accusamus exercitationem a consequuntur natus aliquam, provident impedit iste modi nam corporis quidem minus, earum magni nesciunt, illo facere molestias dolor alias maiores! Tenetur dolores architecto numquam fugiat voluptates fugit. Rem eligendi explicabo aliquid corporis recusandae repellendus magni sit voluptatem necessitatibus quas magnam consectetur cumque accusamus placeat, ratione similique sed accusantium cum beatae, adipisci fugit nobis excepturi perferendis! Suscipit nam eius cum voluptate impedit, repudiandae, laudantium explicabo nisi molestiae eos fugiat cupiditate. Ipsam cupiditate quidem quo in cum, soluta et dolores repellendus porro ut nesciunt odit quasi necessitatibus maiores! Praesentium dolorum, doloribus porro odit laboriosam repellat. Aperiam quas hic optio provident rerum nostrum facere sit commodi eum alias, atque neque.", new DateTime(2022, 2, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "/web/images/1.jpg", true, "Into The Night", 2 },
                    { 5, 1, "Lorem ipsum dolor sit amet consectetur adipisicing elit. Itaque voluptatibus temporibus numquam iure minima quam animi sit, laudantium quia fugit ea error. Nemo itaque repellendus placeat reiciendis voluptates rerum quidem voluptatibus autem a dicta voluptas, ratione quod repellat corrupti eum veniam inventore illo natus qui animi! Id minima a temporibus voluptas modi aperiam dolore, aliquid non sapiente ullam rem nobis, repudiandae magnam qui aspernatur, quibusdam nemo saepe. Sunt exercitationem aliquid nihil ducimus vitae quam soluta, eveniet neque aspernatur praesentium aut officiis quidem totam impedit, sint voluptatem earum, veritatis cum voluptates atque iure? Quisquam vero esse nostrum architecto. Molestias soluta neque voluptas voluptates rerum velit laudantium ex in odio consectetur aut amet possimus culpa commodi natus quibusdam nam maxime tempore eveniet, nostrum cupiditate aperiam eaque. Culpa temporibus placeat officiis architecto voluptatem illo ex nam consequuntur illum fugiat nihil similique officia quidem exercitationem sapiente, tenetur minus! Labore hic, aut rem ea aspernatur nulla, magni a quaerat cupiditate laudantium error autem velit mollitia perspiciatis beatae dolor assumenda, maiores possimus voluptatibus quisquam accusamus quo doloribus alias corporis. Ex dignissimos aperiam eos qui ut sequi vel illo, voluptate voluptas ullam iste reiciendis? Tenetur at voluptas laboriosam ad dolor. Quidem id unde nemo sint consectetur consequuntur laudantium incidunt. Sit porro odio dolorum quaerat assumenda modi quo molestias vero hic, voluptas molestiae iusto quos? Facere, reiciendis a fugit architecto libero, cumque, perspiciatis reprehenderit hic earum dolor pariatur dolorem! Quia expedita architecto maxime ea fuga veritatis eius ratione. Neque quas beatae porro excepturi veniam! Ipsum dolore voluptas rerum.", new DateTime(2021, 8, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "/web/images/8.jpg", true, "Pyhton ile Veri Analizi", 3 },
                    { 6, 1, "Lorem ipsum dolor sit amet consectetur adipisicing elit. Natus porro perspiciatis, fugiat qui vel voluptatibus voluptatum molestias harum expedita quasi. Odit facere, iste excepturi qui exercitationem maxime numquam dolores, aperiam error provident commodi. Neque beatae alias necessitatibus perspiciatis aliquam molestias accusantium odio nam cumque ad ipsa, incidunt fuga quisquam. Asperiores minima tempore molestiae itaque voluptate officiis dolorum similique quas excepturi, repellat animi aliquid magni sint tempora earum amet? Dolores laudantium atque velit est corrupti dolore, vel possimus accusamus nemo, quisquam tempore repellendus id. Ducimus dolores dolor accusantium repudiandae nam esse corporis iusto vitae iure exercitationem quasi error voluptas eveniet autem sit dolorum facere, ipsa neque quaerat ipsum at rerum cum. Accusamus exercitationem harum omnis in officiis ullam quaerat. Sint necessitatibus nam illum quo neque mollitia dolores delectus, molestiae, unde doloribus ea eos inventore incidunt, quam iste magnam porro fuga a numquam assumenda? Ullam nihil illo praesentium esse facere sint. Animi dolore laudantium iste facere nobis fugit nostrum assumenda itaque praesentium. Nihil voluptate ea voluptatum, suscipit veritatis cupiditate quam vitae rem dolores omnis animi consequuntur ad magni maiores! Totam distinctio omnis saepe sunt enim ex dolorem, laborum, mollitia deleniti ducimus qui cupiditate doloribus quam architecto velit ut a, ab quisquam optio? Accusamus, ipsam eligendi. Accusantium aspernatur sit quas nemo explicabo magnam aliquam odit quisquam quasi quia odio tempore, molestiae labore est rerum mollitia dicta maxime alias perferendis soluta ratione. Earum, tempore?", new DateTime(2023, 11, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "/web/images/6.jpg", true, "C# ile Asenkron Metodlar", 2 }
                });

            migrationBuilder.InsertData(
                table: "Messages",
                columns: new[] { "Id", "Date", "Details", "ReceiverId", "SenderId", "Status", "Subject" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 6, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "Lorem ipsum dolor sit amet.", 1, 2, true, "ipsum" },
                    { 2, new DateTime(2023, 9, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Lorem ipsum dolor sit amet consectetur adipisicing elit. Dolores, quod.", 1, 3, true, "ipsum" },
                    { 3, new DateTime(2023, 9, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Similique dolorem laboriosam culpa nisi?", 2, 1, true, "Similique" },
                    { 4, new DateTime(2023, 10, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "ullam dolorem natus, incidunt ad dolore iste culpa sapiente numquam.", 3, 1, true, "ullam" },
                    { 5, new DateTime(2023, 8, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "Lorem ipsum dolor sit amet consectetur adipisicing elit. Dolores, quod.", 1, 2, true, "Lorem" },
                    { 6, new DateTime(2023, 6, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "Lorem ipsum dolor consectetur adipisicing elit. sit amet consectetur adipisicing elit. Dolores, quod.", 1, 2, true, "aliquid" },
                    { 7, new DateTime(2023, 8, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Lorem ipsum dolorametet modi aliquid maxime placeat architecto. odio quae enim! sit amet consectetur adipisicing elit. Dolores, quod.", 3, 1, true, "consectetur" },
                    { 8, new DateTime(2023, 5, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Lorem ipsum dolor sit amet consectetur adipisicing elit. Dolores, amet odio quae enim quod.", 4, 2, true, "Lorem" },
                    { 9, new DateTime(2023, 7, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), "Lorem ipsum dolor sit amet consectetur amet odio quae enim adipisicing elit. Dolores, quod.", 3, 2, true, "aliquid" },
                    { 10, new DateTime(2023, 10, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "Lorem ipsum doloret modi aliquid maxime placeat architecto. sit amet consectetur adipisicing elit. Dolores, quod.", 4, 2, true, "doloret" }
                });

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "Id", "BlogId", "Content", "Date", "Status", "Title", "UserName" },
                values: new object[,]
                {
                    { 1, 4, "Illo, adipisci! Illo, adipisci!", new DateTime(2023, 2, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Quisquam vero esse nostrum", "Ali Yıldırım" },
                    { 2, 3, "Lorem ipsum dolor sit, amet consectetur.", new DateTime(2022, 6, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "voluptas modi aperiam dolore", "Gizem Çınar" },
                    { 3, 2, "Lorem ipsum dolor sit, amet consectetur. ipsum dolor sit.", new DateTime(2023, 7, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "magnam qui aspernatur", "Aslı Yıldız" },
                    { 4, 6, "Lorem ipsum dolor sit, amet consectetur.", new DateTime(2023, 4, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Quisquam vero esse nostrum", "Mert Kaya" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

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
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Blogs_CategoryId",
                table: "Blogs",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Blogs_UserId",
                table: "Blogs",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_BlogId",
                table: "Comments",
                column: "BlogId");

            migrationBuilder.CreateIndex(
                name: "IX_Messages_ReceiverId",
                table: "Messages",
                column: "ReceiverId");

            migrationBuilder.CreateIndex(
                name: "IX_Messages_SenderId",
                table: "Messages",
                column: "SenderId");
        }

        /// <inheritdoc />
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
                name: "Comments");

            migrationBuilder.DropTable(
                name: "Contacts");

            migrationBuilder.DropTable(
                name: "Messages");

            migrationBuilder.DropTable(
                name: "NewsLetters");

            migrationBuilder.DropTable(
                name: "Notifications");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Blogs");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
