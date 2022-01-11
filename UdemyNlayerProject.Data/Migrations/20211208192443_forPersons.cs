using Microsoft.EntityFrameworkCore.Migrations;

namespace UdemyNlayerProject.Data.Migrations
{
    public partial class forPersons : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Persons",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    SurName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Persons", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Persons",
                columns: new[] { "Id", "Name", "SurName" },
                values: new object[] { 1, "Hüseyin", "Alav" });

            migrationBuilder.InsertData(
                table: "Persons",
                columns: new[] { "Id", "Name", "SurName" },
                values: new object[] { 2, "Sedat", "Kavak" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Persons");
        }
    }
}
