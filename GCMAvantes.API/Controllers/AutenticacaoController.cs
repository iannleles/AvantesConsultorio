using GCMAvantes.Application.DTOs;
using GCMAvantes.Domain.Entities;
using GCMAvantes.Helpers;
using GCMAvantes.Infra.Repositories;
using GCMAvantes.Infra.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace GCMAvantes.API.Controllers
{
    [Route("v1/[controller]")]
    [ApiController]
    public class AutenticacaoController : ControllerBase
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly AppSettings _appSettings;


        public AutenticacaoController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager,
            IOptions<AppSettings> appSettings)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _appSettings = appSettings.Value;
        }

        [HttpPost("nova-conta")]
        public async Task<IActionResult> Register(RegisterDTO registerDTO)
        {
            var user = new IdentityUser
            {
                UserName = registerDTO.Email,
                Email = registerDTO.Email,
                EmailConfirmed = true
            };
            var result = await _userManager.CreateAsync(user, registerDTO.Senha);
            if (result.Succeeded)
                await _signInManager.SignInAsync(user, false);

            return Ok(registerDTO);
        }

        [HttpPost("entrar")]
        public async Task<IActionResult> Login(LoginDTO loginDTO)
        {
            var result = await _signInManager.PasswordSignInAsync(loginDTO.Email, loginDTO.Senha, false, false);
            if (result.Succeeded)
                return Ok(GerarJWT());
            else
                return BadRequest("Usuário e/ou senha inválidos");

        }

        private string GerarJWT()
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            var token = tokenHandler.CreateToken(new SecurityTokenDescriptor
            {
                Issuer = _appSettings.Emissor,
                Audience = _appSettings.ValidoEm,
                Expires = DateTime.UtcNow.AddHours(_appSettings.ExpiracaoHoras),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            });

            var encodedToken = tokenHandler.WriteToken(token);
            return encodedToken;
        }
        

    }
}
