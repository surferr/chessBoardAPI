using System;
using System.Collections.Generic;
using System.Text;

namespace chessBoard.BL.Models
{
    public class BaseResponse
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; }

        public static BaseResponse Success(string message = null)
        {
            return new BaseResponse
            {
                IsSuccess = true,
                Message = message,
            };
        }

        public static BaseResponse Error(string message)
        {
            return new BaseResponse
            {
                IsSuccess = false,
                Message = message,
            };
        }
    }
}
