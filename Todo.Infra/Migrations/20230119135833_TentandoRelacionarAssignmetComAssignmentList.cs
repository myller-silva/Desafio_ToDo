using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Todo.Infra.Migrations
{
    /// <inheritdoc />
    public partial class TentandoRelacionarAssignmetComAssignmentList : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Assignment_AssignmentListId",
                table: "Assignment",
                column: "AssignmentListId");

            migrationBuilder.AddForeignKey(
                name: "FK_Assignment_AssignmentList_AssignmentListId",
                table: "Assignment",
                column: "AssignmentListId",
                principalTable: "AssignmentList",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Assignment_AssignmentList_AssignmentListId",
                table: "Assignment");

            migrationBuilder.DropIndex(
                name: "IX_Assignment_AssignmentListId",
                table: "Assignment");
        }
    }
}
