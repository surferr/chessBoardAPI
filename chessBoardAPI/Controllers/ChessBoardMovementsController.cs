using chessBoard.BL.Models;
using chessBoard.BL.ServiceInterfaces;
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
    public class ChessBoardMovementsController : ControllerBase
    {
        private IChessBoardService _chessboardService;

        public ChessBoardMovementsController(IChessBoardService chessboardService)
        {
            _chessboardService = chessboardService;
        }

        [Route("api/[controller]/board/{boardId}/{from}/{to}")]
        [HttpGet]
        public async Task<ActionResult<BaseResponse>> Move([FromRoute] int boardId, string from, string to, CancellationToken cancellationToken)
        {
            var response = await _chessboardService.MoveChessPiece(boardId, from, to, cancellationToken);

            if (!response.IsSuccess)
            {
                return BadRequest(response);
            }

            return Ok(response);
        }
    }
}
