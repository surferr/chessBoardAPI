using Microsoft.EntityFrameworkCore.Migrations;

namespace chessBoard.DA.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ChessBoards",
                columns: table => new
                {
                    ChessBoardId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChessBoards", x => x.ChessBoardId);
                });

            migrationBuilder.CreateTable(
                name: "ChessPiece",
                columns: table => new
                {
                    ChessPieceId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ChessBoardId = table.Column<int>(type: "int", nullable: false),
                    Type = table.Column<int>(type: "int", nullable: false),
                    Color = table.Column<int>(type: "int", nullable: false),
                    Position = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChessPiece", x => x.ChessPieceId);
                    table.ForeignKey(
                        name: "FK_ChessPiece_ChessBoards_ChessBoardId",
                        column: x => x.ChessBoardId,
                        principalTable: "ChessBoards",
                        principalColumn: "ChessBoardId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ChessPiece_ChessBoardId",
                table: "ChessPiece",
                column: "ChessBoardId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ChessPiece");

            migrationBuilder.DropTable(
                name: "ChessBoards");
        }
    }
}
