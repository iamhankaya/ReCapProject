using Business.Abstract;
using Entities.Concrete.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("Register")]

        public IActionResult Register(UserForRegister userForRegister)
        {
            var result = _authService.Register(userForRegister);
            if (!result.IsSuccess)
                return BadRequest(result.Message);
            
            var tokenResult = _authService.CreateAccessToken(result.data);
            if (!tokenResult.IsSuccess)
                return BadRequest(tokenResult.Message);

            return Ok(tokenResult);
        }

        [HttpPost("Login")]

        public IActionResult Login(UserForLoginDto userForLoginDto)
        {
            var result = _authService.Login(userForLoginDto);
            if (!result.IsSuccess)
                return BadRequest(result.Message);
            var tokenResult = _authService.CreateAccessToken(result.data);
            if(!tokenResult.IsSuccess)
                return BadRequest(tokenResult.Message);

            return Ok(tokenResult);
        }
    }
}
