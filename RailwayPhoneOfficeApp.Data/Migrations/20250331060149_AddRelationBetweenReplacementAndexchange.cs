using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RailwayPhoneOfficeApp.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddRelationBetweenReplacementAndexchange : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "TelephoneExchangeId",
                table: "Replacements",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                comment: "Foreign key to the TelephoneExchange entity");

            migrationBuilder.CreateIndex(
                name: "IX_Replacements_TelephoneExchangeId",
                table: "Replacements",
                column: "TelephoneExchangeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Replacements_TelephoneExchanges_TelephoneExchangeId",
                table: "Replacements",
                column: "TelephoneExchangeId",
                principalTable: "TelephoneExchanges",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Replacements_TelephoneExchanges_TelephoneExchangeId",
                table: "Replacements");

            migrationBuilder.DropIndex(
                name: "IX_Replacements_TelephoneExchangeId",
                table: "Replacements");

            migrationBuilder.DropColumn(
                name: "TelephoneExchangeId",
                table: "Replacements");
        }
    }
}
