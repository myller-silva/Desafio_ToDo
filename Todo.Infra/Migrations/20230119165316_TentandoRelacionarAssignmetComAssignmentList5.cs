using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Todo.Infra.Migrations
{
    /// <inheritdoc />
    public partial class TentandoRelacionarAssignmetComAssignmentList5 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_assigment_Type_AssignmentListId",
                table: "assigment");

            migrationBuilder.DropForeignKey(
                name: "FK_Type_User_UserId",
                table: "Type");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Type",
                table: "Type");

            migrationBuilder.RenameTable(
                name: "Type",
                newName: "AssignmentList");

            migrationBuilder.RenameIndex(
                name: "IX_Type_UserId",
                table: "AssignmentList",
                newName: "IX_AssignmentList_UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AssignmentList",
                table: "AssignmentList",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_assigment_AssignmentList_AssignmentListId",
                table: "assigment",
                column: "AssignmentListId",
                principalTable: "AssignmentList",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AssignmentList_User_UserId",
                table: "AssignmentList",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_assigment_AssignmentList_AssignmentListId",
                table: "assigment");

            migrationBuilder.DropForeignKey(
                name: "FK_AssignmentList_User_UserId",
                table: "AssignmentList");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AssignmentList",
                table: "AssignmentList");

            migrationBuilder.RenameTable(
                name: "AssignmentList",
                newName: "Type");

            migrationBuilder.RenameIndex(
                name: "IX_AssignmentList_UserId",
                table: "Type",
                newName: "IX_Type_UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Type",
                table: "Type",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_assigment_Type_AssignmentListId",
                table: "assigment",
                column: "AssignmentListId",
                principalTable: "Type",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Type_User_UserId",
                table: "Type",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
