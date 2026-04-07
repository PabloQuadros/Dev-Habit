using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DevHabit.Api.Migrations.Application
{
    /// <inheritdoc />
    public partial class Add_UserId_Reference : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "ix_tags_name",
                schema: "dev_habit",
                table: "tags");

            migrationBuilder.DropPrimaryKey(
                name: "pk_user",
                schema: "dev_habit",
                table: "user");

            migrationBuilder.RenameTable(
                name: "user",
                schema: "dev_habit",
                newName: "users",
                newSchema: "dev_habit");

            migrationBuilder.RenameIndex(
                name: "ix_user_identity_id",
                schema: "dev_habit",
                table: "users",
                newName: "ix_users_identity_id");

            migrationBuilder.RenameIndex(
                name: "ix_user_email",
                schema: "dev_habit",
                table: "users",
                newName: "ix_users_email");

            migrationBuilder.AddColumn<string>(
                name: "user_id",
                schema: "dev_habit",
                table: "tags",
                type: "character varying(500)",
                maxLength: 500,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "user_id",
                schema: "dev_habit",
                table: "habits",
                type: "character varying(500)",
                maxLength: 500,
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "pk_users",
                schema: "dev_habit",
                table: "users",
                column: "id");

            migrationBuilder.CreateIndex(
                name: "ix_tags_user_id_name",
                schema: "dev_habit",
                table: "tags",
                columns: new[] { "user_id", "name" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_habits_user_id",
                schema: "dev_habit",
                table: "habits",
                column: "user_id");

            migrationBuilder.AddForeignKey(
                name: "fk_habits_users_user_id",
                schema: "dev_habit",
                table: "habits",
                column: "user_id",
                principalSchema: "dev_habit",
                principalTable: "users",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "fk_tags_users_user_id",
                schema: "dev_habit",
                table: "tags",
                column: "user_id",
                principalSchema: "dev_habit",
                principalTable: "users",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_habits_users_user_id",
                schema: "dev_habit",
                table: "habits");

            migrationBuilder.DropForeignKey(
                name: "fk_tags_users_user_id",
                schema: "dev_habit",
                table: "tags");

            migrationBuilder.DropIndex(
                name: "ix_tags_user_id_name",
                schema: "dev_habit",
                table: "tags");

            migrationBuilder.DropIndex(
                name: "ix_habits_user_id",
                schema: "dev_habit",
                table: "habits");

            migrationBuilder.DropPrimaryKey(
                name: "pk_users",
                schema: "dev_habit",
                table: "users");

            migrationBuilder.DropColumn(
                name: "user_id",
                schema: "dev_habit",
                table: "tags");

            migrationBuilder.DropColumn(
                name: "user_id",
                schema: "dev_habit",
                table: "habits");

            migrationBuilder.RenameTable(
                name: "users",
                schema: "dev_habit",
                newName: "user",
                newSchema: "dev_habit");

            migrationBuilder.RenameIndex(
                name: "ix_users_identity_id",
                schema: "dev_habit",
                table: "user",
                newName: "ix_user_identity_id");

            migrationBuilder.RenameIndex(
                name: "ix_users_email",
                schema: "dev_habit",
                table: "user",
                newName: "ix_user_email");

            migrationBuilder.AddPrimaryKey(
                name: "pk_user",
                schema: "dev_habit",
                table: "user",
                column: "id");

            migrationBuilder.CreateIndex(
                name: "ix_tags_name",
                schema: "dev_habit",
                table: "tags",
                column: "name",
                unique: true);
        }
    }
}
