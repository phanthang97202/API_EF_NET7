using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API_EF_NET7.Migrations
{
    /// <inheritdoc />
    public partial class InitialDNB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Confederation",
                columns: table => new
                {
                    ConfederationId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ConfederationName = table.Column<string>(type: "nchar(255)", fixedLength: true, maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Confederation", x => x.ConfederationId);
                });

            migrationBuilder.CreateTable(
                name: "Team",
                columns: table => new
                {
                    TeamId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CountryName = table.Column<string>(type: "nchar(255)", fixedLength: true, maxLength: 255, nullable: false),
                    ConfederationId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Team", x => x.TeamId);
                    table.ForeignKey(
                        name: "FK_Team_Confederation_ConfederationId",
                        column: x => x.ConfederationId,
                        principalTable: "Confederation",
                        principalColumn: "ConfederationId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Team_ConfederationId",
                table: "Team",
                column: "ConfederationId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Team");

            migrationBuilder.DropTable(
                name: "Confederation");
        }
    }
}
