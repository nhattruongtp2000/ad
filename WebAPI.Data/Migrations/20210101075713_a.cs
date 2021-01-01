using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebAPI.Data.Migrations
{
    public partial class a : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "admin ",
                columns: table => new
                {
                    idAdmin = table.Column<string>(type: "VARCHAR(200)", maxLength: 200, nullable: false),
                    email = table.Column<string>(type: "VARCHAR(200)", maxLength: 200, nullable: false),
                    password = table.Column<string>(type: "VARCHAR(200)", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_admin ", x => x.idAdmin);
                });

            migrationBuilder.CreateTable(
                name: "productBrand",
                columns: table => new
                {
                    idBrand = table.Column<string>(type: "VARCHAR(200)", maxLength: 200, nullable: false),
                    brandName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    brandDetail = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_productBrand", x => x.idBrand);
                });

            migrationBuilder.CreateTable(
                name: "productCategory",
                columns: table => new
                {
                    idCategory = table.Column<string>(type: "VARCHAR(200)", maxLength: 200, nullable: false),
                    categoryName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_productCategory", x => x.idCategory);
                });

            migrationBuilder.CreateTable(
                name: "productColor",
                columns: table => new
                {
                    idColor = table.Column<string>(type: "VARCHAR(200)", maxLength: 200, nullable: false),
                    colorName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_productColor", x => x.idColor);
                });

            migrationBuilder.CreateTable(
                name: "productSize",
                columns: table => new
                {
                    idSize = table.Column<string>(type: "VARCHAR(200)", maxLength: 200, nullable: false),
                    sizeName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_productSize", x => x.idSize);
                });

            migrationBuilder.CreateTable(
                name: "productTypes",
                columns: table => new
                {
                    idType = table.Column<string>(type: "VARCHAR(200)", maxLength: 200, nullable: false),
                    typeName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_productTypes", x => x.idType);
                });

            migrationBuilder.CreateTable(
                name: "role",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_role", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "UserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserClaims", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProviderKey = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "UserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RoleId = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "users",
                columns: table => new
                {
                    idUser = table.Column<string>(type: "VARCHAR(200)", maxLength: 200, nullable: false),
                    firstName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    lastName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    birthday = table.Column<DateTime>(type: "datetime2", nullable: false),
                    note = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    province = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    interestedIn = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    address = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true),
                    lastLogin = table.Column<DateTime>(type: "datetime2", nullable: false),
                    avatar = table.Column<string>(type: "VARCHAR(200)", maxLength: 200, nullable: true),
                    Id = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                    table.PrimaryKey("PK_users", x => x.idUser);
                });

            migrationBuilder.CreateTable(
                name: "UserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LoginProvider = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "vouchers",
                columns: table => new
                {
                    idVoucher = table.Column<string>(type: "VARCHAR(200)", maxLength: 200, nullable: false),
                    price = table.Column<int>(type: "int", nullable: false),
                    expiredDate = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    isUse = table.Column<byte>(type: "tinyint", nullable: false, defaultValue: (byte)0)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_vouchers", x => x.idVoucher);
                });

            migrationBuilder.CreateTable(
                name: "products",
                columns: table => new
                {
                    idProduct = table.Column<string>(type: "VARCHAR(200)", maxLength: 200, nullable: false),
                    idSize = table.Column<string>(type: "VARCHAR(200)", maxLength: 200, nullable: false),
                    idBrand = table.Column<string>(type: "VARCHAR(200)", maxLength: 200, nullable: false),
                    idColor = table.Column<string>(type: "VARCHAR(200)", maxLength: 200, nullable: false),
                    idCategory = table.Column<string>(type: "VARCHAR(200)", maxLength: 200, nullable: false),
                    idType = table.Column<string>(type: "VARCHAR(200)", maxLength: 200, nullable: false),
                    productName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    price = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    salePrice = table.Column<string>(type: "VARCHAR(200)", maxLength: 200, nullable: false),
                    photoReview = table.Column<string>(type: "VARCHAR(200)", maxLength: 200, nullable: false),
                    detail = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: false),
                    isSaling = table.Column<byte>(type: "tinyint", nullable: false),
                    expiredSalingDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    dateAdded = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_products", x => x.idProduct);
                    table.ForeignKey(
                        name: "FK_products_productBrand_idBrand",
                        column: x => x.idBrand,
                        principalTable: "productBrand",
                        principalColumn: "idBrand",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_products_productCategory_idCategory",
                        column: x => x.idCategory,
                        principalTable: "productCategory",
                        principalColumn: "idCategory",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_products_productColor_idColor",
                        column: x => x.idColor,
                        principalTable: "productColor",
                        principalColumn: "idColor",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_products_productSize_idSize",
                        column: x => x.idSize,
                        principalTable: "productSize",
                        principalColumn: "idSize",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_products_productTypes_idType",
                        column: x => x.idType,
                        principalTable: "productTypes",
                        principalColumn: "idType",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "odersList",
                columns: table => new
                {
                    idOrderList = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    idUser = table.Column<string>(type: "VARCHAR(200)", maxLength: 200, nullable: false),
                    status = table.Column<int>(type: "int", nullable: false),
                    date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    idVoucher = table.Column<string>(type: "VARCHAR(200)", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_odersList", x => x.idOrderList);
                    table.ForeignKey(
                        name: "FK_odersList_users_idUser",
                        column: x => x.idUser,
                        principalTable: "users",
                        principalColumn: "idUser",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "productPhotos",
                columns: table => new
                {
                    IdPhoto = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    idProduct = table.Column<string>(type: "VARCHAR(200)", maxLength: 200, nullable: false),
                    link = table.Column<string>(type: "VARCHAR(200)", maxLength: 200, nullable: false),
                    uploadedTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_productPhotos", x => x.IdPhoto);
                    table.ForeignKey(
                        name: "FK_productPhotos_products_idProduct",
                        column: x => x.idProduct,
                        principalTable: "products",
                        principalColumn: "idProduct",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "rating",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    idUser = table.Column<string>(type: "VARCHAR(200)", maxLength: 200, nullable: false),
                    idProduct = table.Column<string>(type: "VARCHAR(200)", maxLength: 200, nullable: false),
                    comment = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: false),
                    rateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    rate = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_rating", x => x.Id);
                    table.ForeignKey(
                        name: "FK_rating_products_idProduct",
                        column: x => x.idProduct,
                        principalTable: "products",
                        principalColumn: "idProduct",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_rating_users_idUser",
                        column: x => x.idUser,
                        principalTable: "users",
                        principalColumn: "idUser",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "odersDetails",
                columns: table => new
                {
                    idOder = table.Column<string>(type: "VARCHAR(200)", maxLength: 200, nullable: false),
                    idOrderList = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    totalPrice = table.Column<int>(type: "int", nullable: false),
                    idProduct = table.Column<string>(type: "VARCHAR(200)", maxLength: 200, nullable: false),
                    quality = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_odersDetails", x => x.idOder);
                    table.ForeignKey(
                        name: "FK_odersDetails_odersList_idOrderList",
                        column: x => x.idOrderList,
                        principalTable: "odersList",
                        principalColumn: "idOrderList",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_odersDetails_products_idProduct",
                        column: x => x.idProduct,
                        principalTable: "products",
                        principalColumn: "idProduct",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "productSize",
                columns: new[] { "idSize", "sizeName" },
                values: new object[,]
                {
                    { "L", "L-(Chest 101-106cm)" },
                    { "M", "M-(Chest 96-101cm)" },
                    { "S", "S-(Chest 91-96cm)" },
                    { "XL", "XL-(Chest 106-111cm)" }
                });

            migrationBuilder.InsertData(
                table: "productTypes",
                columns: new[] { "idType", "typeName" },
                values: new object[,]
                {
                    { "BagsNPurses", "Bags & Purses" },
                    { "MEN", "Men Products" },
                    { "WOMEN", "Women Products" }
                });

            migrationBuilder.InsertData(
                table: "users",
                columns: new[] { "idUser", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "Id", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName", "address", "avatar", "birthday", "firstName", "interestedIn", "lastLogin", "lastName", "note", "province" },
                values: new object[] { "2", 0, "af463510-7266-4d0f-94cd-eb363135d8e3", "nhattruongtp2000@gmail.com", true, "69BD714F-9576-45BA-B5B7-F00649BE00DE", false, null, "nhattruongtp2000@gmail.com", "admin", "AQAAAAEAACcQAAAAEPU6AStYblm936kq5uekgc1NsqsSSVqJ0o9Nd0toE0EU9WCaFP4iR6+YVyFCCHB90Q==", null, false, "", false, "admin", "asd", "asd", new DateTime(2020, 10, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Nguyen", "asd", new DateTime(2020, 11, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "Truong", "asd", "asd" });

            migrationBuilder.CreateIndex(
                name: "IX_odersDetails_idOrderList",
                table: "odersDetails",
                column: "idOrderList");

            migrationBuilder.CreateIndex(
                name: "IX_odersDetails_idProduct",
                table: "odersDetails",
                column: "idProduct");

            migrationBuilder.CreateIndex(
                name: "IX_odersList_idUser",
                table: "odersList",
                column: "idUser");

            migrationBuilder.CreateIndex(
                name: "IX_productPhotos_idProduct",
                table: "productPhotos",
                column: "idProduct");

            migrationBuilder.CreateIndex(
                name: "IX_products_idBrand",
                table: "products",
                column: "idBrand");

            migrationBuilder.CreateIndex(
                name: "IX_products_idCategory",
                table: "products",
                column: "idCategory");

            migrationBuilder.CreateIndex(
                name: "IX_products_idColor",
                table: "products",
                column: "idColor");

            migrationBuilder.CreateIndex(
                name: "IX_products_idSize",
                table: "products",
                column: "idSize");

            migrationBuilder.CreateIndex(
                name: "IX_products_idType",
                table: "products",
                column: "idType");

            migrationBuilder.CreateIndex(
                name: "IX_rating_idProduct",
                table: "rating",
                column: "idProduct");

            migrationBuilder.CreateIndex(
                name: "IX_rating_idUser",
                table: "rating",
                column: "idUser");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "admin ");

            migrationBuilder.DropTable(
                name: "odersDetails");

            migrationBuilder.DropTable(
                name: "productPhotos");

            migrationBuilder.DropTable(
                name: "rating");

            migrationBuilder.DropTable(
                name: "role");

            migrationBuilder.DropTable(
                name: "RoleClaims");

            migrationBuilder.DropTable(
                name: "UserClaims");

            migrationBuilder.DropTable(
                name: "UserLogins");

            migrationBuilder.DropTable(
                name: "UserRoles");

            migrationBuilder.DropTable(
                name: "UserTokens");

            migrationBuilder.DropTable(
                name: "vouchers");

            migrationBuilder.DropTable(
                name: "odersList");

            migrationBuilder.DropTable(
                name: "products");

            migrationBuilder.DropTable(
                name: "users");

            migrationBuilder.DropTable(
                name: "productBrand");

            migrationBuilder.DropTable(
                name: "productCategory");

            migrationBuilder.DropTable(
                name: "productColor");

            migrationBuilder.DropTable(
                name: "productSize");

            migrationBuilder.DropTable(
                name: "productTypes");
        }
    }
}
