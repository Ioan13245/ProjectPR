using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ivan1.Migrations
{
    /// <inheritdoc />
    public partial class UpdateV1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "GroupId",
                table: "cd_student",
                newName: "c_group_id");

            migrationBuilder.RenameColumn(
                name: "DisciplineID",
                table: "cd_group",
                newName: "c_group_id");

            migrationBuilder.RenameIndex(
                name: "IX_cd_group_DisciplineID",
                table: "cd_group",
                newName: "IX_cd_group_c_group_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "c_group_id",
                table: "cd_student",
                newName: "GroupId");

            migrationBuilder.RenameColumn(
                name: "c_group_id",
                table: "cd_group",
                newName: "DisciplineID");

            migrationBuilder.RenameIndex(
                name: "IX_cd_group_c_group_id",
                table: "cd_group",
                newName: "IX_cd_group_DisciplineID");
        }
    }
}
