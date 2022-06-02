using chessBoard.Core.Models;
using chessBoard.DA.Data.ServiceInterfaces;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace chessBoard.DA.Data.Services
{
    public class ChessBoardContext : DbContext, IChessBoardContext
    {
        public ChessBoardContext() : base()
        {
        }
        public ChessBoardContext(DbContextOptions<ChessBoardContext> options) : base(options)
        {
        }

        public DbSet<ChessBoard> ChessBoards { get; set; }

        public async Task SaveAsync(CancellationToken cancellationToken = default)
        {
            await SaveChangesAsync(cancellationToken);
        }
    }
}