using Microsoft.AspNetCore.Mvc;
using Service.Contracts;
using Shared.DTO;
using Shared.ResponseFeatures;

namespace PlayBowling.Controllers
{
    [Route("api/player")]
    [ApiController]
    public class PlayerController : ControllerBase
    {
        private readonly IServiceManager _service;
        public PlayerController(IServiceManager service)
        {
            _service = service;
        }

        [HttpPost()]
        public async Task<IActionResult> CreatePlayer([FromBody] PlayerDTO playerDTO)
        {

            var result = await _service.PlayerService.CreateRecord(playerDTO);
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
