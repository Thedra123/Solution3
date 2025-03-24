using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Concat.API.Infraction.Migrations.HospitalNo
{
    /// <inheritdoc />
    public partial class InitialCreate_HospitalNo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "HospitalNo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Hospitalno = table.Column<int>(type: "int", nullable: false),
                    Hospitalname = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HospitalNo", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HospitalNo");
        }
    }
}
