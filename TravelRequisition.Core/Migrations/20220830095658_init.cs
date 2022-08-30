using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TravelRequisition.Core.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TravelRequest",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RequestDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SourceLocation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SourceCountry = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Destination = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProposedDeparture = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TravelClass = table.Column<int>(type: "int", nullable: false),
                    TripType = table.Column<int>(type: "int", nullable: false),
                    ChargeCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RequisitionStatus = table.Column<int>(type: "int", nullable: false),
                    RequisitionNumber = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TravelRequest", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TravelRequest");
        }
    }
}
