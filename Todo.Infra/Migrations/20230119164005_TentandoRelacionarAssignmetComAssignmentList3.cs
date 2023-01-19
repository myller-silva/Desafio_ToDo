using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Todo.Infra.Migrations
{
    /// <inheritdoc />
    public partial class TentandoRelacionarAssignmetComAssignmentList3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Assignment_AssignmentList_AssignmentListId",
                table: "Assignment");

            migrationBuilder.DropForeignKey(
                name: "FK_Assignment_User_UserId",
                table: "Assignment");

            migrationBuilder.DropForeignKey(
                name: "FK_AssignmentList_User_UserId",
                table: "AssignmentList");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AssignmentList",
                table: "AssignmentList");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Assignment",
                table: "Assignment");

            migrationBuilder.RenameTable(
                name: "AssignmentList",
                newName: "Type");

            migrationBuilder.RenameTable(
                name: "Assignment",
                newName: "assigment");

            migrationBuilder.RenameIndex(
                name: "IX_AssignmentList_UserId",
                table: "Type",
                newName: "IX_Type_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Assignment_UserId",
                table: "assigment",
                newName: "IX_assigment_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Assignment_AssignmentListId",
                table: "assigment",
                newName: "IX_assigment_AssignmentListId");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "assigment",
                type: "VARCHAR(101)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<bool>(
                name: "Concluded",
                table: "assigment",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "tinyint(1)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Type",
                table: "Type",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_assigment",
                table: "assigment",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_assigment_Type_AssignmentListId",
                table: "assigment",
                column: "AssignmentListId",
                principalTable: "Type",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_assigment_User_UserId",
                table: "assigment",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Type_User_UserId",
                table: "Type",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_assigment_Type_AssignmentListId",
                table: "assigment");

            migrationBuilder.DropForeignKey(
                name: "FK_assigment_User_UserId",
                table: "assigment");

            migrationBuilder.DropForeignKey(
                name: "FK_Type_User_UserId",
                table: "Type");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Type",
                table: "Type");

            migrationBuilder.DropPrimaryKey(
                name: "PK_assigment",
                table: "assigment");

            migrationBuilder.RenameTable(
                name: "Type",
                newName: "AssignmentList");

            migrationBuilder.RenameTable(
                name: "assigment",
                newName: "Assignment");

            migrationBuilder.RenameIndex(
                name: "IX_Type_UserId",
                table: "AssignmentList",
                newName: "IX_AssignmentList_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_assigment_UserId",
                table: "Assignment",
                newName: "IX_Assignment_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_assigment_AssignmentListId",
                table: "Assignment",
                newName: "IX_Assignment_AssignmentListId");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Assignment",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "VARCHAR(101)")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<bool>(
                name: "Concluded",
                table: "Assignment",
                type: "tinyint(1)",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "tinyint(1)",
                oldDefaultValue: false);

            migrationBuilder.AddPrimaryKey(
                name: "PK_AssignmentList",
                table: "AssignmentList",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Assignment",
                table: "Assignment",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Assignment_AssignmentList_AssignmentListId",
                table: "Assignment",
                column: "AssignmentListId",
                principalTable: "AssignmentList",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Assignment_User_UserId",
                table: "Assignment",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AssignmentList_User_UserId",
                table: "AssignmentList",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
