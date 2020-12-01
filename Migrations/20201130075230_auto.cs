using Microsoft.EntityFrameworkCore.Migrations;

namespace APIforUpcomingProjects.Migrations
{
    public partial class auto : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Username",
                table: "Users",
                newName: "Team");

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Cars",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LicenceNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MileageInKm = table.Column<int>(type: "int", nullable: false),
                    MileageInKmAtRegistration = table.Column<int>(type: "int", nullable: false),
                    ManufactureYear = table.Column<int>(type: "int", nullable: false),
                    InUse = table.Column<bool>(type: "bit", nullable: false),
                    GasFor100km = table.Column<int>(type: "int", nullable: false),
                    GasTankSize = table.Column<int>(type: "int", nullable: false),
                    GasType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GasCardNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GasCardPin = table.Column<int>(type: "int", nullable: false),
                    UserTeamName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cars", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cars");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "Users");

            migrationBuilder.RenameColumn(
                name: "Team",
                table: "Users",
                newName: "Username");
        }
    }
}
