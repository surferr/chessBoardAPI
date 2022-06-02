using System.Collections.Generic;
using System.Linq;

namespace chessBoard.Core.Models
{
    public class ChessBoard
    {
        public int ChessBoardId { get; protected set; }

        public string Name { get; set; }

        public List<ChessPiece> ChessPieces { get; set; }

        public bool ContainsChessPieceAtPosition (string position)
        {
            return ChessPieces is null ? 
                false : 
                ChessPieces.Any(pieces => pieces.Position == position);
        }

        public ChessPiece GetChessPiece (string position)
        {
            return ChessPieces?.Where(pieces => pieces.Position == position).FirstOrDefault();
        }

        public bool RemoveChessPiece(string position)
        {
            var chesspiece = GetChessPiece(position);
            return chesspiece is null ? false : ChessPieces.Remove(chesspiece);            
        }
    }
}
