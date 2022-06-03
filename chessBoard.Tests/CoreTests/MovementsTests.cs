using chessBoard.Core.Helpers;
using chessBoard.Core.Models;
using System;
using Xunit;

namespace chessBoard.Tests.CoreTests
{
    public class MovementsTests
    {
        [Fact]
        public void TestPawnMovements()
        {
            ChessPiece pawn = new ChessPiece
            {
                Position = "E4",
                Type = ChessPieceType.Pawn,
                Color = ChessPieceColor.White,
            };

            Assert.True(ChessBoardMovements.IsMovementCorrect(pawn, "E5"));
            Assert.True(ChessBoardMovements.IsMovementCorrect(pawn, "E6"));

            Assert.False(ChessBoardMovements.IsMovementCorrect(pawn, "E7"));
            Assert.False(ChessBoardMovements.IsMovementCorrect(pawn, "E1"));
            Assert.False(ChessBoardMovements.IsMovementCorrect(pawn, "D4"));
            Assert.False(ChessBoardMovements.IsMovementCorrect(pawn, "F4"));
            Assert.False(ChessBoardMovements.IsMovementCorrect(pawn, "D5"));
            Assert.False(ChessBoardMovements.IsMovementCorrect(pawn, "D3"));
            Assert.False(ChessBoardMovements.IsMovementCorrect(pawn, "F5"));
            Assert.False(ChessBoardMovements.IsMovementCorrect(pawn, "F3"));
            Assert.False(ChessBoardMovements.IsMovementCorrect(pawn, "J9"));
        }

        [Fact]
        public void TestKingMovements()
        {
            ChessPiece king = new ChessPiece
            {
                Position = "E4",
                Type = ChessPieceType.King,
                Color = ChessPieceColor.White,
            };

            Assert.True(ChessBoardMovements.IsMovementCorrect(king, "E5"));
            Assert.True(ChessBoardMovements.IsMovementCorrect(king, "E3"));
            Assert.True(ChessBoardMovements.IsMovementCorrect(king, "D4"));
            Assert.True(ChessBoardMovements.IsMovementCorrect(king, "F4"));

            Assert.False(ChessBoardMovements.IsMovementCorrect(king, "E6"));
            Assert.False(ChessBoardMovements.IsMovementCorrect(king, "E7"));
            Assert.False(ChessBoardMovements.IsMovementCorrect(king, "E2"));
            Assert.False(ChessBoardMovements.IsMovementCorrect(king, "D2"));
            Assert.False(ChessBoardMovements.IsMovementCorrect(king, "G4"));
        }

        [Fact]
        public void TestKnightMovements()
        {
            ChessPiece knight = new ChessPiece
            {
                Position = "E4",
                Type = ChessPieceType.Knight,
                Color = ChessPieceColor.White,
            };

            Assert.True(ChessBoardMovements.IsMovementCorrect(knight, "D6"));
            Assert.True(ChessBoardMovements.IsMovementCorrect(knight, "D2"));
            Assert.True(ChessBoardMovements.IsMovementCorrect(knight, "F6"));
            Assert.True(ChessBoardMovements.IsMovementCorrect(knight, "F2"));
            Assert.True(ChessBoardMovements.IsMovementCorrect(knight, "C3"));
            Assert.True(ChessBoardMovements.IsMovementCorrect(knight, "C5"));
            Assert.True(ChessBoardMovements.IsMovementCorrect(knight, "G3"));
            Assert.True(ChessBoardMovements.IsMovementCorrect(knight, "G5"));

            Assert.False(ChessBoardMovements.IsMovementCorrect(knight, "E5"));
            Assert.False(ChessBoardMovements.IsMovementCorrect(knight, "E3"));
            Assert.False(ChessBoardMovements.IsMovementCorrect(knight, "D4"));
            Assert.False(ChessBoardMovements.IsMovementCorrect(knight, "F4"));
            Assert.False(ChessBoardMovements.IsMovementCorrect(knight, "E7"));
            Assert.False(ChessBoardMovements.IsMovementCorrect(knight, "E1"));
            Assert.False(ChessBoardMovements.IsMovementCorrect(knight, "A1"));
            Assert.False(ChessBoardMovements.IsMovementCorrect(knight, "G7"));
        }
    }
}
