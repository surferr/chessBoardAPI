using chessBoard.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace chessBoard.Core.Helpers
{
    public static class ChessBoardMovements
    {
        private static Dictionary<ChessPieceType, Func<ChessPiece, string, bool>> movements =
            new Dictionary<ChessPieceType, Func<ChessPiece, string, bool>>
            {
                { ChessPieceType.King, IsMovementCorrectForKing },
                { ChessPieceType.Queen, IsMovementCorrectForQueen },
                { ChessPieceType.Rook, IsMovementCorrectForRook },
                { ChessPieceType.Bishop, IsMovementCorrectForBishop },
                { ChessPieceType.Knight, IsMovementCorrectForKnight },
                { ChessPieceType.Pawn, IsMovementCorrectForPawn },
            };

        public static bool IsMovementCorrect(ChessPiece chesspiece, string toPosition)
        {
            return  movements.ContainsKey(chesspiece.Type) &&
                    movements[chesspiece.Type](chesspiece, toPosition);
        }

        private static (bool, int, int, int, int) CheckCoordinates(ChessPiece chesspiece, string toPosition)
        {
            if (!ChessBoardUtils.IsPositionCorrect(chesspiece.Position) ||
                !ChessBoardUtils.IsPositionCorrect(toPosition))
            {
                return (false,0,0,0,0);
            }

            var (fromX, fromY) = ChessBoardUtils.PositionToCoord(chesspiece.Position);
            var (toX, toY) = ChessBoardUtils.PositionToCoord(toPosition);

            return (true, fromX, fromY, toX, toY);
        }

        private static bool IsMovementCorrectForKing(ChessPiece chesspiece, string toPosition)
        {
            var (correct, fromX, fromY, toX, toY) = CheckCoordinates(chesspiece, toPosition);

            return  correct &&
                    (Math.Abs(toX - fromX) == 1 && (toY - fromY) == 0) ||
                    ((toX - fromX) == 0 && Math.Abs(toY - fromY) == 1);
        }

        private static bool IsMovementCorrectForQueen(ChessPiece chesspiece, string toPosition)
        {
            var (correct, fromX, fromY, toX, toY) = CheckCoordinates(chesspiece, toPosition);

            return  correct &&
                    (Math.Abs(toX - fromX) > 1 && toY - fromY == 0) ||
                    ((toX - fromX) == 0 && Math.Abs(toY - fromY) > 1) ||
                    (Math.Abs(toX - fromX) == Math.Abs(toY - fromY));
        }

        private static bool IsMovementCorrectForRook(ChessPiece chesspiece, string toPosition)
        {
            var (correct, fromX, fromY, toX, toY) = CheckCoordinates(chesspiece, toPosition);

            return correct &&
                    (Math.Abs(toX - fromX) > 1 && toY - fromY == 0) ||
                    ((toX - fromX) == 0 && Math.Abs(toY - fromY) > 1);
        }

        private static bool IsMovementCorrectForBishop(ChessPiece chesspiece, string toPosition)
        {
            var (correct, fromX, fromY, toX, toY) = CheckCoordinates(chesspiece, toPosition);

            return correct && (Math.Abs(toX - fromX) == Math.Abs(toY - fromY));
        }

        private static bool IsMovementCorrectForKnight(ChessPiece chesspiece, string toPosition)
        {
            var (correct, fromX, fromY, toX, toY) = CheckCoordinates(chesspiece, toPosition);

            return correct &&
                    (Math.Abs(toX - fromX) == 1 && Math.Abs(toY - fromY) == 2) ||
                    (Math.Abs(toX - fromX) == 2 && Math.Abs(toY - fromY) == 1);
        }

        private static bool IsMovementCorrectForPawn(ChessPiece chesspiece, string toPosition)
        {
            var (correct, fromX, fromY, toX, toY) = CheckCoordinates(chesspiece, toPosition);

            return correct && 
                ((toX - fromX) == 0 && (Math.Abs(toY - fromY) > 0 && Math.Abs(toY - fromY) <= 2) );
        }


        
    }
}
