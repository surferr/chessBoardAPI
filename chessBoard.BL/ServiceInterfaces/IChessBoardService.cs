using chessBoard.BL.Models;
using chessBoard.Core.Models;
using System.Threading;
using System.Threading.Tasks;

namespace chessBoard.BL.ServiceInterfaces
{
    public interface IChessBoardService
    {
        Task<ChessBoard> Create(CancellationToken cancellationToken = default);

        Task<ChessBoard> GetChessBoard(int id, CancellationToken cancellationToken = default);

        Task<BaseResponse> MoveChessPiece(int id, string from, string to, CancellationToken cancellationToken = default);
    }
}
