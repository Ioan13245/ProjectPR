using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ivan1.Migrations
{
    /// <inheritdoc />
    public partial class UpDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_f_discipline_id",
                table: "cd_student");

            migrationBuilder.DropIndex(
                name: "idx_cd_student_fk_f_discipline_id",
                table: "cd_student");

            migrationBuilder.DropColumn(
                name: "DisciplineID",
                table: "cd_student");

            migrationBuilder.RenameTable(
                name: "Groups",
                newName: "cd_group");

            migrationBuilder.RenameTable(
                name: "Disciplines",
                newName: "cd_discipline");

            migrationBuilder.AddColumn<int>(
                name: "DisciplineID",
                table: "cd_group",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "idx_cd_group_fk_f_discipline_id",
                table: "cd_group",
                column: "group_id");

            migrationBuilder.CreateIndex(
                name: "IX_cd_group_DisciplineID",
                table: "cd_group",
                column: "DisciplineID");

            migrationBuilder.AddForeignKey(
                name: "fk_f_group_id",
                table: "cd_group",
                column: "DisciplineID",
                principalTable: "cd_discipline",
                principalColumn: "discipline_id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_f_group_id",
                table: "cd_group");

            migrationBuilder.DropIndex(
                name: "idx_cd_group_fk_f_discipline_id",
                table: "cd_group");

            migrationBuilder.DropIndex(
                name: "IX_cd_group_DisciplineID",
                table: "cd_group");

            migrationBuilder.DropColumn(
                name: "DisciplineID",
                table: "cd_group");

            migrationBuilder.RenameTable(
                name: "cd_group",
                newName: "Groups");

            migrationBuilder.RenameTable(
                name: "cd_discipline",
                newName: "Disciplines");

            migrationBuilder.AddColumn<int>(
                name: "DisciplineID",
                table: "cd_student",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "idx_cd_student_fk_f_discipline_id",
                table: "cd_student",
                column: "DisciplineID");

            migrationBuilder.AddForeignKey(
                name: "fk_f_discipline_id",
                table: "cd_student",
                column: "DisciplineID",
                principalTable: "Disciplines",
                principalColumn: "discipline_id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
