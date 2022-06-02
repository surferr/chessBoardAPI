using chessBoard.BL.ServiceInterfaces;
using chessBoard.Core.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace chessBoard.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChessBoardController : ControllerBase
    {
        private IChessBoardService _chessboardService;

        public ChessBoardController (IChessBoardService chessboardService)
        {
            _chessboardService = chessboardService;
        }

        [Route("api/[controller]/board/{boardId}")]
        [HttpGet]
        public async Task<ActionResult<ChessBoard>> GetBoard([FromRoute] int boardId, CancellationToken cancellationToken)
        {
            var chessBoard = await _chessboardService.GetChessBoard(boardId, cancellationToken);

            if ( chessBoard is null )
            {
                return NotFound();
            }

            return Ok(chessBoard);
        }

        [Route("api/[controller]/board/new")]
        [HttpPost]
        public async Task<ActionResult<ChessBoard>> NewBoard(CancellationToken cancellationToken = default)
        {
            return await _chessboardService.Create (cancellationToken);
        }
    }
}
