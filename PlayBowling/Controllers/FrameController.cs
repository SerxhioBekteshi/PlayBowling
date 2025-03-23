using Microsoft.AspNetCore.Mvc;
using Service.Contracts;
using Shared.DTO;
using Shared.ResponseFeatures;

namespace PlayBowling.Controllers
{
    [Route("api/frame")]
    [ApiController]
    public class FrameController : ControllerBase
    {
        private readonly IServiceManager _service;
        public FrameController(IServiceManager service)
        {
            _service = service;
        }

        [HttpGet("get-all")]
        public async Task<IActionResult> GetAllFrames()
        {

            var result = await _service.FrameService.GetAllFrames();
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
