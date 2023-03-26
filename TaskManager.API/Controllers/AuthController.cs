using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TaskManager.Business.Abstract;
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

        [HttpGet]
        [Route("test-auth")]
        [Authorize]
        public IActionResult GetTest()
        {
            return Ok("Only authenticated user can consume this endpoint");
        }
    }
}
