using System;
using System.Collections.Generic;
using System.Text;

namespace chessBoard.Core.Models
{
    public class ChessPiece
    {
        public int ChessPieceId { get; private set; }

        public int ChessBoardId { get; private set; }

        public ChessPieceType Type { get; set; }

        public ChessPieceColor Color { get; set; }

        public string Position { get; set; }
    }
}
