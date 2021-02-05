using EsportsProphetAPI.Data;
using EsportsProphetAPI.Dtos;
using EsportsProphetAPI.Models;
using Microsoft.AspNetCore.Mvc;
using EsportsProphetAPI.Security;
using System.Threading.Tasks;

namespace ep.Controllers
{
    [Route("api/[controller]")]
    public class AuthController : Controller
    {
        private readonly IAuthRepository _repo;
        private readonly ITokenGenerator _tokenGenerator;
        public AuthController(IAuthRepository repo, ITokenGenerator tokenGenerator)
        {
            _repo = repo;
            _tokenGenerator = tokenGenerator;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody]UserRegisterDto userRegisterDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if(await _repo.UserExists(userRegisterDto.Username))
            {
                ModelState.AddModelError("username", "Username already exists.");
                return BadRequest(ModelState);
            }

            User newUser = new User()
            {
                Username = userRegisterDto.Username
            };

            await _repo.Register(newUser, userRegisterDto.Password);

            return StatusCode(201);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody]UserLoginDto userLoginDto)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            User userFromRepo = await _repo.Login(userLoginDto.Username, userLoginDto.Password);

            if(userFromRepo == null)
            {
                return Unauthorized();
            }

            string token = _tokenGenerator.GetTokenString(userFromRepo);

            return Ok(new {token});
        }
    }
}
