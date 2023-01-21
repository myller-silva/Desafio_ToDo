using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Todo.Infra.Migrations
{
    /// <inheritdoc />
    public partial class TentandoRelacionarAssignmetComAssignmentList7 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_assigment_AssignmentList_AssignmentListId",
                table: "assigment");

            migrationBuilder.DropForeignKey(
                name: "FK_assigment_User_UserId",
                table: "assigment");

            migrationBuilder.DropPrimaryKey(
                name: "PK_assigment",
                table: "assigment");

            migrationBuilder.RenameTable(
                name: "assigment",
                newName: "assignment");

            migrationBuilder.RenameIndex(
                name: "IX_assigment_UserId",
                table: "assignment",
                newName: "IX_assignment_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_assigment_AssignmentListId",
                table: "assignment",
                newName: "IX_assignment_AssignmentListId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_assignment",
                table: "assignment",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_assignment_AssignmentList_AssignmentListId",
                table: "assignment",
                column: "AssignmentListId",
                principalTable: "AssignmentList",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_assignment_User_UserId",
                table: "assignment",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_assignment_AssignmentList_AssignmentListId",
                table: "assignment");

            migrationBuilder.DropForeignKey(
                name: "FK_assignment_User_UserId",
                table: "assignment");

            migrationBuilder.DropPrimaryKey(
                name: "PK_assignment",
                table: "assignment");

            migrationBuilder.RenameTable(
                name: "assignment",
                newName: "assigment");

            migrationBuilder.RenameIndex(
                name: "IX_assignment_UserId",
                table: "assigment",
                newName: "IX_assigment_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_assignment_AssignmentListId",
                table: "assigment",
                newName: "IX_assigment_AssignmentListId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_assigment",
                table: "assigment",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_assigment_AssignmentList_AssignmentListId",
                table: "assigment",
                column: "AssignmentListId",
                principalTable: "AssignmentList",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_assigment_User_UserId",
                table: "assigment",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
