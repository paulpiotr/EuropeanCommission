using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Vies.Core.Database.Migrations
{
    public partial class _3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CheckVatApprox",
                schema: "etvc",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "(newsequentialid())"),
                    CountryCode = table.Column<string>(type: "varchar(8)", maxLength: 8, nullable: false),
                    VatNumber = table.Column<string>(type: "varchar(16)", maxLength: 16, nullable: false),
                    RequestDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    Valid = table.Column<bool>(type: "bit", nullable: false),
                    TraderName = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: false),
                    TraderCompanyType = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: false),
                    TraderAddress = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: false),
                    TraderStreet = table.Column<string>(type: "varchar(64)", maxLength: 64, nullable: true),
                    TraderPostcode = table.Column<string>(type: "varchar(32)", maxLength: 32, nullable: true),
                    TraderCity = table.Column<string>(type: "varchar(64)", maxLength: 64, nullable: true),
                    TraderNameMatch = table.Column<short>(type: "smallint", nullable: false),
                    TraderCompanyTypeMatch = table.Column<short>(type: "smallint", nullable: false),
                    TraderStreetMatch = table.Column<short>(type: "smallint", nullable: false),
                    TraderPostcodeMatch = table.Column<short>(type: "smallint", nullable: false),
                    TraderCityMatch = table.Column<short>(type: "smallint", nullable: false),
                    RequestIdentifier = table.Column<string>(type: "varchar(16)", maxLength: 16, nullable: false),
                    UniqueIdentifierOfTheLoggedInUser = table.Column<string>(type: "varchar(512)", maxLength: 512, nullable: false),
                    DateOfCreate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
                    DateOfModification = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CheckVatApprox", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CheckVatApproxDateOfCreate",
                schema: "etvc",
                table: "CheckVatApprox",
                column: "DateOfCreate");

            migrationBuilder.CreateIndex(
                name: "IX_CheckVatApproxDateOfModification",
                schema: "etvc",
                table: "CheckVatApprox",
                column: "DateOfModification");

            migrationBuilder.CreateIndex(
                name: "IX_CheckVatApproxId",
                schema: "etvc",
                table: "CheckVatApprox",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CheckVatApproxNumber",
                schema: "etvc",
                table: "CheckVatApprox",
                column: "VatNumber");

            migrationBuilder.CreateIndex(
                name: "IX_CheckVatApproxRequestDate",
                schema: "etvc",
                table: "CheckVatApprox",
                column: "RequestDate");

            migrationBuilder.CreateIndex(
                name: "IX_CheckVatApproxTraderName",
                schema: "etvc",
                table: "CheckVatApprox",
                column: "TraderName");

            migrationBuilder.CreateIndex(
                name: "IX_CheckVatApproxUniqueIdentifierOfTheLoggedInUser",
                schema: "etvc",
                table: "CheckVatApprox",
                column: "UniqueIdentifierOfTheLoggedInUser");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CheckVatApprox",
                schema: "etvc");
        }
    }
}
