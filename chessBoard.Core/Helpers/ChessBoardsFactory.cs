using chessBoard.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace chessBoard.Core.Helpers
{
    public static class ChessBoardsFactory
    {
        public static ChessBoard CreateDefaultChessBoard()
        {
            var pieces = new List<ChessPiece>();

            pieces.AddRange(
                Enumerable.Range(0, 16).Select(i =>
                   CreateChessPiece(
                       ChessBoardUtils.CoordToPosition(i % 8, i / 8 == 0 ? 1 : 6),
                       ChessPieceType.Pawn,
                       i / 8 == 0 ? ChessPieceColor.White : ChessPieceColor.Black)));

            return new ChessBoard
            {
                ChessPieces = pieces,
            };
        }

        public static ChessPiece CreateChessPiece( string position, ChessPieceType type, ChessPieceColor color )
        {
            return new ChessPiece
            {
                Position = position,
                Type = type,
                Color = color,
            };
        }
    }
}
