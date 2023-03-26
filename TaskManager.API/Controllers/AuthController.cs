using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TaskManager.Business.Abstract;
using TaskManager.DataAccess.Concrete.Eframework;
using TaskManager.Entities.Concrete;
using TaskManager.Entities.Dto;

namespace TaskManager.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IJwtAuthenticationService _jwtAuthenticationService;

        public AuthController(IJwtAuthenticationService jwtAuthenticationService)
        {
            _jwtAuthenticationService = jwtAuthenticationService;
        }


        [Route("Login")]
        [HttpPost]
        public async Task<IActionResult> GetToken(Login login)
        {
            var result = await _jwtAuthenticationService.GetToken(login);
            if (result != null)
            {
                return Ok(result);
            }

            return BadRequest();
        }

        //[HttpPost]
        //[Route("newRefresh-token")]
        //public async Task<IActionResult> RenewTokens(NewRefreshToken refreshToken)
        //{
        //    var tokens =  await _jwtAuthenticationService.NewRefreshToken(refreshToken);
        //    if (tokens == null)
        //    {
        //        return BadRequest();
        //    }
        //    return Ok(tokens);
        //}

        [HttpGet]
        [Route("test")]
        [Authorize]
        public IActionResult GetTest()
        {
            return Ok("Success");
        }
    }
}
