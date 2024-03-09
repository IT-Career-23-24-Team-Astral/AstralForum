﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AstralForum.Migrations
{
    /// <inheritdoc />
<<<<<<<< HEAD:Migrations/20240223155120_Inital create.cs
    public partial class Initalcreate : Migration
========
    public partial class Initial : Migration
>>>>>>>> 08aa2d3331c8e3f81d0a8537ca3cc50e586d735e:AstralForum/Migrations/20240302142827_Initial.cs
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
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateOfCreation = table.Column<DateTime>(type: "datetime2", nullable: false),
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
<<<<<<<< HEAD:Migrations/20240223155120_Inital create.cs
                name: "NotificationModel",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Text = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NotificationId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NotificationModel", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tags",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tags", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ThreadModel",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Text = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ThreadCategory = table.Column<int>(type: "int", nullable: false),
                    CreatedById = table.Column<int>(type: "int", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ThreadModel", x => x.Id);
========
                name: "TagType",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TagType", x => x.Id);
>>>>>>>> 08aa2d3331c8e3f81d0a8537ca3cc50e586d735e:AstralForum/Migrations/20240302142827_Initial.cs
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
                    LoginProvider = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
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
                    LoginProvider = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
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
                name: "Bans",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Reason = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BanEnd = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AffectedUserId = table.Column<int>(type: "int", nullable: false),
                    CreatedById = table.Column<int>(type: "int", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bans", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Bans_AspNetUsers_AffectedUserId",
                        column: x => x.AffectedUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Bans_AspNetUsers_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Notifications",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Text = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NotificationId = table.Column<int>(type: "int", nullable: false),
                    CreatedById = table.Column<int>(type: "int", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notifications", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Notifications_AspNetUsers_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ReactionsType",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ReactionId = table.Column<int>(type: "int", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedById = table.Column<int>(type: "int", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReactionsType", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ReactionsType_AspNetUsers_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Replies",
<<<<<<<< HEAD:Migrations/20240223155120_Inital create.cs
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ReplyId = table.Column<int>(type: "int", nullable: false),
                    ThreadId = table.Column<int>(type: "int", nullable: false),
                    CommentId = table.Column<int>(type: "int", nullable: false),
                    Text = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedById = table.Column<int>(type: "int", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Replies", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Replies_AspNetUsers_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ThreadCategory",
========
>>>>>>>> 08aa2d3331c8e3f81d0a8537ca3cc50e586d735e:AstralForum/Migrations/20240302142827_Initial.cs
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ReplyId = table.Column<int>(type: "int", nullable: false),
                    ThreadId = table.Column<int>(type: "int", nullable: false),
                    CommentId = table.Column<int>(type: "int", nullable: false),
                    Text = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedById = table.Column<int>(type: "int", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Replies", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Replies_AspNetUsers_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
<<<<<<<< HEAD:Migrations/20240223155120_Inital create.cs
                name: "UserNotifications",
========
                name: "ThreadCategories",
>>>>>>>> 08aa2d3331c8e3f81d0a8537ca3cc50e586d735e:AstralForum/Migrations/20240302142827_Initial.cs
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
<<<<<<<< HEAD:Migrations/20240223155120_Inital create.cs
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsRead = table.Column<bool>(type: "bit", nullable: false),
                    NotificationId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserNotifications", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserNotifications_NotificationModel_NotificationId",
                        column: x => x.NotificationId,
                        principalTable: "NotificationModel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
========
                    CategoryName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedById = table.Column<int>(type: "int", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                  
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ThreadCategories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ThreadCategories_AspNetUsers_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
>>>>>>>> 08aa2d3331c8e3f81d0a8537ca3cc50e586d735e:AstralForum/Migrations/20240302142827_Initial.cs
                });

            migrationBuilder.CreateTable(
                name: "ReplyReactions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ReactionTypeId = table.Column<int>(type: "int", nullable: false),
                    ReplyId = table.Column<int>(type: "int", nullable: false),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedById = table.Column<int>(type: "int", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReplyReactions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ReplyReactions_AspNetUsers_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ReplyReactions_ReactionsType_ReactionTypeId",
                        column: x => x.ReactionTypeId,
                        principalTable: "ReactionsType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ReplyReactions_Replies_ReplyId",
                        column: x => x.ReplyId,
                        principalTable: "Replies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ReplyReports",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Text = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ReplyId = table.Column<int>(type: "int", nullable: false),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedById = table.Column<int>(type: "int", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReplyReports", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ReplyReports_AspNetUsers_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ReplyReports_Replies_ReplyId",
                        column: x => x.ReplyId,
                        principalTable: "Replies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Threads",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Text = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ThreadCategoryId = table.Column<int>(type: "int", nullable: false),
                    CreatedById = table.Column<int>(type: "int", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Threads", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Threads_AspNetUsers_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Threads_ThreadCategories_ThreadCategoryId",
                        column: x => x.ThreadCategoryId,
                        principalTable: "ThreadCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Comments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ThreadId = table.Column<int>(type: "int", nullable: false),
                    Text = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CommentId = table.Column<int>(type: "int", nullable: true),
<<<<<<<< HEAD:Migrations/20240223155120_Inital create.cs
========
                    AuthorId = table.Column<int>(type: "int", nullable: false),
>>>>>>>> 08aa2d3331c8e3f81d0a8537ca3cc50e586d735e:AstralForum/Migrations/20240302142827_Initial.cs
                    CreatedById = table.Column<int>(type: "int", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Comments_AspNetUsers_AuthorId",
                        column: x => x.AuthorId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Comments_AspNetUsers_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Comments_Comments_CommentId",
                        column: x => x.CommentId,
                        principalTable: "Comments",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Comments_Threads_ThreadId",
                        column: x => x.ThreadId,
<<<<<<<< HEAD:Migrations/20240223155120_Inital create.cs
========
                        principalTable: "Threads",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PostReactions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ReactionTypeId = table.Column<int>(type: "int", nullable: false),
                    PostId = table.Column<int>(type: "int", nullable: false),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PostReactions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PostReactions_ReactionsType_ReactionTypeId",
                        column: x => x.ReactionTypeId,
                        principalTable: "ReactionsType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PostReactions_Threads_PostId",
                        column: x => x.PostId,
>>>>>>>> 08aa2d3331c8e3f81d0a8537ca3cc50e586d735e:AstralForum/Migrations/20240302142827_Initial.cs
                        principalTable: "Threads",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
<<<<<<<< HEAD:Migrations/20240223155120_Inital create.cs
                name: "PostReactions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ReactionTypeId = table.Column<int>(type: "int", nullable: false),
                    ThreadId = table.Column<int>(type: "int", nullable: false),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedById = table.Column<int>(type: "int", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PostReactions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PostReactions_AspNetUsers_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PostReactions_ReactionsType_ReactionTypeId",
                        column: x => x.ReactionTypeId,
                        principalTable: "ReactionsType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PostReactions_Threads_ThreadId",
                        column: x => x.ThreadId,
                        principalTable: "Threads",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
========
>>>>>>>> 08aa2d3331c8e3f81d0a8537ca3cc50e586d735e:AstralForum/Migrations/20240302142827_Initial.cs
                name: "PostReports",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Text = table.Column<string>(type: "nvarchar(max)", nullable: false),
<<<<<<<< HEAD:Migrations/20240223155120_Inital create.cs
                    ThreadId = table.Column<int>(type: "int", nullable: false),
========
                    PostId = table.Column<int>(type: "int", nullable: false),
>>>>>>>> 08aa2d3331c8e3f81d0a8537ca3cc50e586d735e:AstralForum/Migrations/20240302142827_Initial.cs
                    CreatedById = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedById1 = table.Column<int>(type: "int", nullable: false),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PostReports", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PostReports_AspNetUsers_CreatedById1",
                        column: x => x.CreatedById1,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
<<<<<<<< HEAD:Migrations/20240223155120_Inital create.cs
                        name: "FK_PostReports_Threads_ThreadId",
                        column: x => x.ThreadId,
========
                        name: "FK_PostReports_Threads_PostId",
                        column: x => x.PostId,
>>>>>>>> 08aa2d3331c8e3f81d0a8537ca3cc50e586d735e:AstralForum/Migrations/20240302142827_Initial.cs
                        principalTable: "Threads",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PostsTags",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
<<<<<<<< HEAD:Migrations/20240223155120_Inital create.cs
                    ThreadId = table.Column<int>(type: "int", nullable: false),
========
                    PostId = table.Column<int>(type: "int", nullable: false),
>>>>>>>> 08aa2d3331c8e3f81d0a8537ca3cc50e586d735e:AstralForum/Migrations/20240302142827_Initial.cs
                    TagId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PostsTags", x => x.Id);
                    table.ForeignKey(
<<<<<<<< HEAD:Migrations/20240223155120_Inital create.cs
                        name: "FK_PostsTags_Tags_TagId",
                        column: x => x.TagId,
                        principalTable: "Tags",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PostsTags_Threads_ThreadId",
                        column: x => x.ThreadId,
========
                        name: "FK_PostsTags_Threads_PostId",
                        column: x => x.PostId,
>>>>>>>> 08aa2d3331c8e3f81d0a8537ca3cc50e586d735e:AstralForum/Migrations/20240302142827_Initial.cs
                        principalTable: "Threads",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ThreadsAttachment",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ThreadId = table.Column<int>(type: "int", nullable: false),
                    AttachmentUrl = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ThreadsAttachment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ThreadsAttachment_Threads_ThreadId",
                        column: x => x.ThreadId,
                        principalTable: "Threads",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CommentsAttachment",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CommentId = table.Column<int>(type: "int", nullable: false),
                    AttachmentUrl = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CommentsAttachment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CommentsAttachment_Comments_CommentId",
                        column: x => x.CommentId,
                        principalTable: "Comments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Reactions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ThreadId = table.Column<int>(type: "int", nullable: false),
                    CommentId = table.Column<int>(type: "int", nullable: false),
                    ReactionTypeId = table.Column<int>(type: "int", nullable: false),
<<<<<<<< HEAD:Migrations/20240223155120_Inital create.cs
========
                    ReactionTypeId1 = table.Column<int>(type: "int", nullable: false),
>>>>>>>> 08aa2d3331c8e3f81d0a8537ca3cc50e586d735e:AstralForum/Migrations/20240302142827_Initial.cs
                    CreatedById = table.Column<int>(type: "int", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reactions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Reactions_AspNetUsers_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Reactions_Comments_CommentId",
                        column: x => x.CommentId,
                        principalTable: "Comments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Reactions_ReactionsType_ReactionTypeId1",
                        column: x => x.ReactionTypeId1,
                        principalTable: "ReactionsType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Reactions_Threads_ThreadId",
                        column: x => x.ThreadId,
<<<<<<<< HEAD:Migrations/20240223155120_Inital create.cs
========
                        principalTable: "Threads",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Tags",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    CommentId = table.Column<int>(type: "int", nullable: false),
                    ThreadId = table.Column<int>(type: "int", nullable: false),
                    TagTypeId = table.Column<int>(type: "int", nullable: false),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    TagId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tags", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tags_Comments_CommentId",
                        column: x => x.CommentId,
                        principalTable: "Comments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Tags_TagType_TagTypeId",
                        column: x => x.TagTypeId,
                        principalTable: "TagType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Tags_Tags_TagId",
                        column: x => x.TagId,
                        principalTable: "Tags",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Tags_Threads_ThreadId",
                        column: x => x.ThreadId,
                        principalTable: "Threads",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Notifications",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    NotificationId = table.Column<int>(type: "int", nullable: false),
                    Text = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NotificationType = table.Column<int>(type: "int", nullable: false),
                    IsRead = table.Column<bool>(type: "bit", nullable: false),
                    CommentId = table.Column<int>(type: "int", nullable: true),
                    ReactionId = table.Column<int>(type: "int", nullable: true),
                    TagId = table.Column<int>(type: "int", nullable: true),
                    ThreadId = table.Column<int>(type: "int", nullable: true),
                    CreatedById = table.Column<int>(type: "int", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notifications", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Notifications_AspNetUsers_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Notifications_Comments_CommentId",
                        column: x => x.CommentId,
                        principalTable: "Comments",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Notifications_Notifications_NotificationId",
                        column: x => x.NotificationId,
                        principalTable: "Notifications",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Notifications_Reactions_ReactionId",
                        column: x => x.ReactionId,
                        principalTable: "Reactions",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Notifications_Tags_TagId",
                        column: x => x.TagId,
                        principalTable: "Tags",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Notifications_Threads_ThreadId",
                        column: x => x.ThreadId,
>>>>>>>> 08aa2d3331c8e3f81d0a8537ca3cc50e586d735e:AstralForum/Migrations/20240302142827_Initial.cs
                        principalTable: "Threads",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
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
                name: "IX_Bans_AffectedUserId",
                table: "Bans",
                column: "AffectedUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Bans_CreatedById",
                table: "Bans",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_AuthorId",
                table: "Comments",
                column: "AuthorId");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_CommentId",
                table: "Comments",
                column: "CommentId");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_CreatedById",
                table: "Comments",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_ThreadId",
                table: "Comments",
                column: "ThreadId");

            migrationBuilder.CreateIndex(
                name: "IX_CommentsAttachment_CommentId",
                table: "CommentsAttachment",
                column: "CommentId");

            migrationBuilder.CreateIndex(
<<<<<<<< HEAD:Migrations/20240223155120_Inital create.cs
========
                name: "IX_Notifications_CommentId",
                table: "Notifications",
                column: "CommentId");

            migrationBuilder.CreateIndex(
>>>>>>>> 08aa2d3331c8e3f81d0a8537ca3cc50e586d735e:AstralForum/Migrations/20240302142827_Initial.cs
                name: "IX_Notifications_CreatedById",
                table: "Notifications",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
<<<<<<<< HEAD:Migrations/20240223155120_Inital create.cs
                name: "IX_PostReactions_CreatedById",
                table: "PostReactions",
                column: "CreatedById");
========
                name: "IX_Notifications_NotificationId",
                table: "Notifications",
                column: "NotificationId");

            migrationBuilder.CreateIndex(
                name: "IX_Notifications_ReactionId",
                table: "Notifications",
                column: "ReactionId");

            migrationBuilder.CreateIndex(
                name: "IX_Notifications_TagId",
                table: "Notifications",
                column: "TagId");

            migrationBuilder.CreateIndex(
                name: "IX_Notifications_ThreadId",
                table: "Notifications",
                column: "ThreadId");

            migrationBuilder.CreateIndex(
                name: "IX_PostReactions_PostId",
                table: "PostReactions",
                column: "PostId");
>>>>>>>> 08aa2d3331c8e3f81d0a8537ca3cc50e586d735e:AstralForum/Migrations/20240302142827_Initial.cs

            migrationBuilder.CreateIndex(
                name: "IX_PostReactions_ReactionTypeId",
                table: "PostReactions",
                column: "ReactionTypeId");

            migrationBuilder.CreateIndex(
<<<<<<<< HEAD:Migrations/20240223155120_Inital create.cs
                name: "IX_PostReactions_ThreadId",
                table: "PostReactions",
                column: "ThreadId");

            migrationBuilder.CreateIndex(
========
>>>>>>>> 08aa2d3331c8e3f81d0a8537ca3cc50e586d735e:AstralForum/Migrations/20240302142827_Initial.cs
                name: "IX_PostReports_CreatedById1",
                table: "PostReports",
                column: "CreatedById1");

            migrationBuilder.CreateIndex(
<<<<<<<< HEAD:Migrations/20240223155120_Inital create.cs
                name: "IX_PostReports_ThreadId",
                table: "PostReports",
                column: "ThreadId");

            migrationBuilder.CreateIndex(
                name: "IX_PostsTags_TagId",
                table: "PostsTags",
                column: "TagId");

            migrationBuilder.CreateIndex(
                name: "IX_PostsTags_ThreadId",
                table: "PostsTags",
                column: "ThreadId");
========
                name: "IX_PostReports_PostId",
                table: "PostReports",
                column: "PostId");

            migrationBuilder.CreateIndex(
                name: "IX_PostsTags_PostId",
                table: "PostsTags",
                column: "PostId");
>>>>>>>> 08aa2d3331c8e3f81d0a8537ca3cc50e586d735e:AstralForum/Migrations/20240302142827_Initial.cs

            migrationBuilder.CreateIndex(
                name: "IX_Reactions_CommentId",
                table: "Reactions",
                column: "CommentId");

            migrationBuilder.CreateIndex(
                name: "IX_Reactions_CreatedById",
                table: "Reactions",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
<<<<<<<< HEAD:Migrations/20240223155120_Inital create.cs
                name: "IX_Reactions_ReactionTypeId",
========
                name: "IX_Reactions_ReactionTypeId1",
                table: "Reactions",
                column: "ReactionTypeId1");

            migrationBuilder.CreateIndex(
                name: "IX_Reactions_ThreadId",
>>>>>>>> 08aa2d3331c8e3f81d0a8537ca3cc50e586d735e:AstralForum/Migrations/20240302142827_Initial.cs
                table: "Reactions",
                column: "ThreadId");

            migrationBuilder.CreateIndex(
                name: "IX_Reactions_ThreadId",
                table: "Reactions",
                column: "ThreadId");

            migrationBuilder.CreateIndex(
                name: "IX_ReactionsType_CreatedById",
                table: "ReactionsType",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_Replies_CreatedById",
                table: "Replies",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_ReplyReactions_CreatedById",
                table: "ReplyReactions",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_ReplyReactions_ReactionTypeId",
                table: "ReplyReactions",
                column: "ReactionTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_ReplyReactions_ReplyId",
                table: "ReplyReactions",
                column: "ReplyId");

            migrationBuilder.CreateIndex(
                name: "IX_ReplyReports_CreatedById",
                table: "ReplyReports",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_ReplyReports_ReplyId",
                table: "ReplyReports",
                column: "ReplyId");

            migrationBuilder.CreateIndex(
<<<<<<<< HEAD:Migrations/20240223155120_Inital create.cs
                name: "IX_ThreadCategory_CreatedById",
                table: "ThreadCategory",
========
                name: "IX_Tags_CommentId",
                table: "Tags",
                column: "CommentId");

            migrationBuilder.CreateIndex(
                name: "IX_Tags_TagId",
                table: "Tags",
                column: "TagId");

            migrationBuilder.CreateIndex(
                name: "IX_Tags_TagTypeId",
                table: "Tags",
                column: "TagTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Tags_ThreadId",
                table: "Tags",
                column: "ThreadId");

            migrationBuilder.CreateIndex(
                name: "IX_ThreadCategories_CreatedById",
                table: "ThreadCategories",
>>>>>>>> 08aa2d3331c8e3f81d0a8537ca3cc50e586d735e:AstralForum/Migrations/20240302142827_Initial.cs
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_Threads_CreatedById",
                table: "Threads",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_Threads_ThreadCategoryId",
                table: "Threads",
                column: "ThreadCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_ThreadsAttachment_ThreadId",
                table: "ThreadsAttachment",
                column: "ThreadId");

            migrationBuilder.CreateIndex(
                name: "IX_UserNotifications_NotificationId",
                table: "UserNotifications",
                column: "NotificationId");
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
                name: "Bans");

            migrationBuilder.DropTable(
                name: "CommentsAttachment");

            migrationBuilder.DropTable(
                name: "Notifications");

            migrationBuilder.DropTable(
                name: "PostReactions");

            migrationBuilder.DropTable(
                name: "PostReports");

            migrationBuilder.DropTable(
                name: "PostsTags");

            migrationBuilder.DropTable(
<<<<<<<< HEAD:Migrations/20240223155120_Inital create.cs
                name: "Reactions");
========
                name: "ReplyReactions");

            migrationBuilder.DropTable(
                name: "ReplyReports");
>>>>>>>> 08aa2d3331c8e3f81d0a8537ca3cc50e586d735e:AstralForum/Migrations/20240302142827_Initial.cs

            migrationBuilder.DropTable(
                name: "ReplyReactions");

            migrationBuilder.DropTable(
                name: "ReplyReports");

            migrationBuilder.DropTable(
                name: "ThreadModel");

            migrationBuilder.DropTable(
                name: "ThreadsAttachment");

            migrationBuilder.DropTable(
                name: "UserNotifications");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
<<<<<<<< HEAD:Migrations/20240223155120_Inital create.cs
                name: "Tags");

            migrationBuilder.DropTable(
                name: "Comments");
========
                name: "Reactions");

            migrationBuilder.DropTable(
                name: "Tags");

            migrationBuilder.DropTable(
                name: "Replies");
>>>>>>>> 08aa2d3331c8e3f81d0a8537ca3cc50e586d735e:AstralForum/Migrations/20240302142827_Initial.cs

            migrationBuilder.DropTable(
                name: "ReactionsType");

            migrationBuilder.DropTable(
<<<<<<<< HEAD:Migrations/20240223155120_Inital create.cs
                name: "Replies");

            migrationBuilder.DropTable(
                name: "NotificationModel");
========
                name: "Comments");

            migrationBuilder.DropTable(
                name: "TagType");
>>>>>>>> 08aa2d3331c8e3f81d0a8537ca3cc50e586d735e:AstralForum/Migrations/20240302142827_Initial.cs

            migrationBuilder.DropTable(
                name: "Threads");

            migrationBuilder.DropTable(
                name: "ThreadCategories");

            migrationBuilder.DropTable(
                name: "AspNetUsers");
        }
    }
}