using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Example.Infra.Data.Migrations
{
    public partial class init2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Person_City_id_cityid",
                schema: "dbo",
                table: "Person");

            migrationBuilder.RenameColumn(
                name: "id_cityid",
                schema: "dbo",
                table: "Person",
                newName: "cityid");

            migrationBuilder.RenameIndex(
                name: "IX_Person_id_cityid",
                schema: "dbo",
                table: "Person",
                newName: "IX_Person_cityid");

            migrationBuilder.AddForeignKey(
                name: "FK_Person_City_cityid",
                schema: "dbo",
                table: "Person",
                column: "cityid",
                principalSchema: "dbo",
                principalTable: "City",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Person_City_cityid",
                schema: "dbo",
                table: "Person");

            migrationBuilder.RenameColumn(
                name: "cityid",
                schema: "dbo",
                table: "Person",
                newName: "id_cityid");

            migrationBuilder.RenameIndex(
                name: "IX_Person_cityid",
                schema: "dbo",
                table: "Person",
                newName: "IX_Person_id_cityid");

            migrationBuilder.AddForeignKey(
                name: "FK_Person_City_id_cityid",
                schema: "dbo",
                table: "Person",
                column: "id_cityid",
                principalSchema: "dbo",
                principalTable: "City",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
