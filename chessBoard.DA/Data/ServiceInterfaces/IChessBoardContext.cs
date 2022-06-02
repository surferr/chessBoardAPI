using chessBoard.Core.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace chessBoard.DA.Data.ServiceInterfaces
{
    public interface IChessBoardContext
    {
        DbSet<ChessBoard> ChessBoards { get; }

        Task SaveAsync(CancellationToken cancellationToken = default);
    }
}
