using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PassBook.Migrations
{
    public partial class initialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Transactions",
                columns: table => new
                {
                    TransactionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AccountNumber = table.Column<string>(type: "nVarchar(12)", nullable: false),
                    BenificiaryName = table.Column<string>(type: "nVarchar(100)", nullable: false),
                    BankName = table.Column<string>(type: "nVarchar(100)", nullable: false),
                    SWIFTCode = table.Column<string>(type: "nVarchar(12)", nullable: false),
                    Amount = table.Column<int>(type: "int", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transactions", x => x.TransactionId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Transactions");
        }
    }
}
