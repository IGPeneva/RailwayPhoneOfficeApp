using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RailwayPhoneOfficeApp.Data.Migrations
{
    /// <inheritdoc />
    public partial class CreateDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsEmployee",
                table: "AspNetUsers",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateTable(
                name: "Actions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "Action identifier"),
                    ActionType = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false, comment: "Type of action")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Actions", x => x.Id);
                },
                comment: "Action taken by the employee");

            migrationBuilder.CreateTable(
                name: "Replacements",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "Replacement part identifier"),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false, comment: "Replacement part name"),
                    Status = table.Column<bool>(type: "bit", nullable: false, defaultValue: false, comment: "Replacement part works or not")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Replacements", x => x.Id);
                },
                comment: "Replacement part for equipment");

            migrationBuilder.CreateTable(
                name: "TelephoneExchanges",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "Telephone exchange identifier"),
                    Name = table.Column<string>(type: "nvarchar(22)", maxLength: 22, nullable: false, comment: "Telephone exchange name"),
                    Capacity = table.Column<int>(type: "int", maxLength: 500, nullable: false, comment: "Count of subscribers")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TelephoneExchanges", x => x.Id);
                },
                comment: "Phone Office in the system");

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "Employee identifier"),
                    FullName = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false, comment: "Employee name"),
                    Position = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false, comment: "Position of employee"),
                    TelephoneExchangeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "Foreign key to the TelephoneExchange entity, workplace"),
                    ApplicationUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Employees_AspNetUsers_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Employees_TelephoneExchanges_TelephoneExchangeId",
                        column: x => x.TelephoneExchangeId,
                        principalTable: "TelephoneExchanges",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                },
                comment: "Employee in the system");

            migrationBuilder.CreateTable(
                name: "Equipments",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "Equipment identifier"),
                    EquipmentName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false, comment: "Equipment name"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true, comment: "Additional information/schema"),
                    TelephoneExchangeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "Foreign key to the TelephoneExchange entity")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Equipments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Equipments_TelephoneExchanges_TelephoneExchangeId",
                        column: x => x.TelephoneExchangeId,
                        principalTable: "TelephoneExchanges",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                },
                comment: "Equipment in the system");

            migrationBuilder.CreateTable(
                name: "Tasks",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "Task identifier"),
                    TaskDescription = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false, comment: "Task description"),
                    IsDamage = table.Column<bool>(type: "bit", nullable: false, defaultValue: false, comment: "Failure pointer"),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false, comment: "Start of the task"),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false, comment: "End of the task"),
                    Notes = table.Column<string>(type: "nvarchar(400)", maxLength: 400, nullable: true, comment: "Notes for additional information"),
                    EquipmentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "Foreign key to the Equipment entity"),
                    ActionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "Foreign key to the Action entity")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tasks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tasks_Actions_ActionId",
                        column: x => x.ActionId,
                        principalTable: "Actions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Tasks_Equipments_EquipmentId",
                        column: x => x.EquipmentId,
                        principalTable: "Equipments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                },
                comment: "Task in the system");

            migrationBuilder.CreateTable(
                name: "EmployeesTasks",
                columns: table => new
                {
                    EmployeeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "Foreign key to the employee"),
                    TaskId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "Foreign key to the task")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeesTasks", x => new { x.EmployeeId, x.TaskId });
                    table.ForeignKey(
                        name: "FK_EmployeesTasks_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_EmployeesTasks_Tasks_TaskId",
                        column: x => x.TaskId,
                        principalTable: "Tasks",
                        principalColumn: "Id");
                },
                comment: "Tasks for employees");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_ApplicationUserId",
                table: "Employees",
                column: "ApplicationUserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Employees_TelephoneExchangeId",
                table: "Employees",
                column: "TelephoneExchangeId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeesTasks_TaskId",
                table: "EmployeesTasks",
                column: "TaskId");

            migrationBuilder.CreateIndex(
                name: "IX_Equipments_TelephoneExchangeId",
                table: "Equipments",
                column: "TelephoneExchangeId");

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_ActionId",
                table: "Tasks",
                column: "ActionId");

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_EquipmentId",
                table: "Tasks",
                column: "EquipmentId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EmployeesTasks");

            migrationBuilder.DropTable(
                name: "Replacements");

            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "Tasks");

            migrationBuilder.DropTable(
                name: "Actions");

            migrationBuilder.DropTable(
                name: "Equipments");

            migrationBuilder.DropTable(
                name: "TelephoneExchanges");

            migrationBuilder.DropColumn(
                name: "IsEmployee",
                table: "AspNetUsers");
        }
    }
}
