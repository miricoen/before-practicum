using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Mng.Data.Migrations
{
    /// <inheritdoc />
    public partial class addkeys : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Roles_Employees_EmployeeId",
                table: "Roles");

            migrationBuilder.DropForeignKey(
                name: "FK_Roles_TypesOfRoles_RoleId",
                table: "Roles");

            migrationBuilder.RenameColumn(
                name: "RoleId",
                table: "Roles",
                newName: "TypesOfRolesId");

            migrationBuilder.RenameIndex(
                name: "IX_Roles_RoleId",
                table: "Roles",
                newName: "IX_Roles_TypesOfRolesId");

            migrationBuilder.AlterColumn<int>(
                name: "EmployeeId",
                table: "Roles",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Roles_Employees_EmployeeId",
                table: "Roles",
                column: "EmployeeId",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Roles_TypesOfRoles_TypesOfRolesId",
                table: "Roles",
                column: "TypesOfRolesId",
                principalTable: "TypesOfRoles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Roles_Employees_EmployeeId",
                table: "Roles");

            migrationBuilder.DropForeignKey(
                name: "FK_Roles_TypesOfRoles_TypesOfRolesId",
                table: "Roles");

            migrationBuilder.RenameColumn(
                name: "TypesOfRolesId",
                table: "Roles",
                newName: "RoleId");

            migrationBuilder.RenameIndex(
                name: "IX_Roles_TypesOfRolesId",
                table: "Roles",
                newName: "IX_Roles_RoleId");

            migrationBuilder.AlterColumn<int>(
                name: "EmployeeId",
                table: "Roles",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Roles_Employees_EmployeeId",
                table: "Roles",
                column: "EmployeeId",
                principalTable: "Employees",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Roles_TypesOfRoles_RoleId",
                table: "Roles",
                column: "RoleId",
                principalTable: "TypesOfRoles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
