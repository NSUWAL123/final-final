
using ApplicationDevelopment.Application.Common.Interfaces;
using ApplicationDevelopment.Application.DTOS;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ApplicationDevelopment.WebApi.Controllers
{
    [ApiController]
    public class AuthenticateController:ControllerBase
    {

        private readonly IAuthentication _authenticationManager;

        public AuthenticateController(IAuthentication authenticationManager)
        {
            _authenticationManager = authenticationManager;
        }

        [HttpPost]
        [Route("/api/authenticate/register")]
        public async Task<ResponseDTO> Register([FromBody] RegisterDTO model)
        {
            var result = await _authenticationManager.Register(model);
            return result;
        }

        [HttpPost]
        [AllowAnonymous]
        [Route("/api/authenticate/login")]
        public async Task<ResponseDTO> Login([FromBody] LoginDTO user)
        {
            var result = await _authenticationManager.Login(user);
            return result;
        }

        [HttpGet]
        [Route("/api/authenticate/getUserDetails")]
        public async Task<IEnumerable<UserDetailsDTO>> GetUserDetails()
        {
            var result = await _authenticationManager.GetUserDetails();
            return result;
        }
    }
}
