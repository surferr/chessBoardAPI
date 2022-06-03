using chessBoard.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace chessBoard.Core.Helpers
{
    public static class ChessBoardUtils
    {
        public static bool IsCoordCorrect(int x, int y)
        {
            return x >= 0 && x < 8 && y >= 0 && y < 8;
        }

        public static bool IsPositionCorrect(string position)
        {
            position = position.ToUpper();
            return position.Length == 2 &&
                    position[0] >= 'A' && position[0] <= 'H' &&
                    position[1] >= '1' && position[1] <= '8';
        }

        public static string CoordToPosition (int x, int y)
        {
            if (!IsCoordCorrect(x, y))
            {
                throw new ArgumentException($"Coordinates {x}:{y} is not correct");
            }

            return (char)('A' + x) + (y+1).ToString();
        }

        public static (int, int) PositionToCoord(string position)
        {
            if (!IsPositionCorrect(position))
            {
                throw new ArgumentException($"Position {position} is not correct");
            }

            position = position.ToUpper();
            return (position[0] - 'A', position[1] - '1');
        }
    }
}
