using Microsoft.AspNetCore.Mvc;
using Service.Contracts;
using Shared.DTO;
using Shared.ResponseFeatures;

namespace PlayBowling.Controllers
{
    [Route("api/game")]
    [ApiController]
    public class GameController : ControllerBase
    {
        private readonly IServiceManager _service;
        public GameController(IServiceManager service)
        {
            _service = service;
        }

        [HttpPost()]
        public async Task<IActionResult> CreateGame([FromBody] GameDTO createGameDTO)
        {

            var result = await _service.GameService.CreateRecord(createGameDTO);
            var baseResponse = new BaseResponse<object, object>
            {
                Result = true,
                Data = result,
                Errors = "",
                StatusCode = StatusCodes.Status200OK
            };
            return Ok(baseResponse);

        }

        // I DONT NEED THIS SINCE I SHIFTED THE LOGIC INSIDE THE POST GAME DIRECTLY
        //[HttpPut("{gameId}/{frameId}")]
        //public async Task<IActionResult> UpdateGameFrame(int gameId, int frameId)
        //{

        //    var result = await _service.GameService.UpdateGameFrame(frameId, frameId);
        //    var baseResponse = new BaseResponse<object, object>
        //    {
        //        Result = result,
        //        Data = result,
        //        Errors = "",
        //        StatusCode = StatusCodes.Status200OK
        //    };
        //    return Ok(baseResponse);
        //}


        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateGameStats(int id, GamePointsDTO gamePointsDTO)
        {

            var result = await _service.GameService.UpdateGameStats(id, gamePointsDTO);
            var baseResponse = new BaseResponse<object, object>
            {
                Result = true,
                Data = result,
                Errors = "",
                StatusCode = StatusCodes.Status200OK
            };
            return Ok(baseResponse);

        }

        [HttpGet("results/{gameId}/get-all")]
        public async Task<IActionResult> GetGameResults(int gameId)
        {

            var result = await _service.GameService.GetGameResults(gameId);
            var baseResponse = new BaseResponse<object, object>
            {
                Result = true,
                Data = result,
                Errors = "",
                StatusCode = StatusCodes.Status200OK
            };
            return Ok(baseResponse);

        }
    }
}
