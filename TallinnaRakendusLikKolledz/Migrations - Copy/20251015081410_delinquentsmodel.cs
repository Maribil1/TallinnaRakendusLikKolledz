using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TallinnaRakendusLikKolledz.Migrations
{
    /// <inheritdoc />
    public partial class delinquentsmodel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Delinquent",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Violation = table.Column<int>(type: "int", nullable: true),
                    Position = table.Column<int>(type: "int", nullable: true),
                    InCourt = table.Column<bool>(type: "bit", nullable: true),
                    Solved = table.Column<bool>(type: "bit", nullable: true),
                    Dropped = table.Column<bool>(type: "bit", nullable: true),
                    Solving = table.Column<bool>(type: "bit", nullable: true),
                    PoliceInvolved = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Delinquent", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Delinquent");
        }
    }
}
