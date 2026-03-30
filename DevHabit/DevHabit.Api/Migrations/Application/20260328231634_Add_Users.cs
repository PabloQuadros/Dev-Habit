#nullable disable

using Microsoft.EntityFrameworkCore.Migrations;

namespace DevHabit.Api.Migrations.Application;

/// <inheritdoc />
public partial class Add_Users : Migration
{
    /// <inheritdoc />
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.CreateTable(
            name: "habit_tags",
            schema: "dev_habit",
            columns: table => new
            {
                habit_id = table.Column<string>(type: "character varying(500)", nullable: false),
                tag_id = table.Column<string>(type: "character varying(500)", nullable: false),
                created_at_utc = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("pk_habit_tags", x => new { x.habit_id, x.tag_id });
                table.ForeignKey(
                    name: "fk_habit_tags_habits_habit_id",
                    column: x => x.habit_id,
                    principalSchema: "dev_habit",
                    principalTable: "habits",
                    principalColumn: "id",
                    onDelete: ReferentialAction.Cascade);
                table.ForeignKey(
                    name: "fk_habit_tags_tags_tag_id",
                    column: x => x.tag_id,
                    principalSchema: "dev_habit",
                    principalTable: "tags",
                    principalColumn: "id",
                    onDelete: ReferentialAction.Cascade);
            });

        migrationBuilder.CreateTable(
            name: "user",
            schema: "dev_habit",
            columns: table => new
            {
                id = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                email = table.Column<string>(type: "character varying(300)", maxLength: 300, nullable: false),
                name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                created_at_utc = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                updated_at_utc = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                identity_id = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("pk_user", x => x.id);
            });

        migrationBuilder.CreateIndex(
            name: "ix_habit_tags_tag_id",
            schema: "dev_habit",
            table: "habit_tags",
            column: "tag_id");

        migrationBuilder.CreateIndex(
            name: "ix_user_email",
            schema: "dev_habit",
            table: "user",
            column: "email",
            unique: true);

        migrationBuilder.CreateIndex(
            name: "ix_user_identity_id",
            schema: "dev_habit",
            table: "user",
            column: "identity_id",
            unique: true);
    }

    /// <inheritdoc />
    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropTable(
            name: "habit_tags",
            schema: "dev_habit");

        migrationBuilder.DropTable(
            name: "user",
            schema: "dev_habit");
    }
}
