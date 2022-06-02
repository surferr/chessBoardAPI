using chessBoard.BL.ServiceInterfaces;
using chessBoard.Core.Helpers;
using chessBoard.Core.Models;
using chessBoard.DA.Data.ServiceInterfaces;
using chessBoard.DA.Data.Services;
using System.Threading;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using chessBoard.BL.Models;

namespace chessBoard.BL.Services
{
    public class ChessBoardService : IChessBoardService
    {
        public ChessBoardContext _chessBoardContext;

        public ChessBoardService (ChessBoardContext chessBoardContext)
        {
            _chessBoardContext = chessBoardContext;
        }

        public async Task<ChessBoard> Create(CancellationToken cancellationToken = default)
        {
            var chessBoard = ChessBoardsFactory.CreateDefaultChessBoard();
            await _chessBoardContext.ChessBoards.AddAsync(chessBoard, cancellationToken);
            await _chessBoardContext.SaveAsync(cancellationToken);
            return chessBoard;
        }

        public async Task<ChessBoard> GetChessBoard(int id, CancellationToken cancellationToken)
        {
            return await _chessBoardContext
                .ChessBoards
                .Where(board => board.ChessBoardId == id)
                .Include(board => board.ChessPieces)
                .FirstOrDefaultAsync();
        }

        public async Task<BaseResponse> MoveChessPiece(int id, string from, string to, CancellationToken cancellationToken)
        {
            var chessBoard = await GetChessBoard(id, cancellationToken);
            if ( chessBoard == null)
            {
                return BaseResponse.Error("Chessboard not found");
            }

            if (!ChessBoardUtils.IsPositionCorrect(from))
            {
                return BaseResponse.Error($"Position {from} is not correct");
            }

            if (!ChessBoardUtils.IsPositionCorrect(to))
            {
                return BaseResponse.Error($"Position {to} is not correct");
            }

            var chesspiece = chessBoard.GetChessPiece(from);
            if (chesspiece is null)
            {
                return BaseResponse.Error($"No chesspiece at position {from}");
            }

            if (!ChessBoardUtils.IsMovementCorrect(chesspiece, to))
            {
                return BaseResponse.Error($"Movement from {from} to {to} for {chesspiece.Type.ToString()} is not correct");
            }

            chessBoard.RemoveChessPiece(to);

            chesspiece.Position = to;

            await _chessBoardContext.SaveAsync(cancellationToken);

            return BaseResponse.Success();
        }
    }
}
