using GCMAvantes.Domain.Entities;
using GCMAvantes.Infra.Repositories;
using GCMAvantes.Infra.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GCMAvantes.API.Controllers
{
    [Route("v1/account")]
    public class HomeController : ControllerBase
    {
        [HttpPost("login")]
        [AllowAnonymous]
        public async Task<ActionResult<dynamic>> Authenticate([FromBody] User model)
        {           
            ;
            var user = UserRepository.Get(model.Username, model.Password);

                if (user == null)
                    return BadRequest(new { message = "Usuário ou senha inválidos" });

            var token = TokenService.GenerateToken(user);
            user.Password = "";

            return new
            {
                user = user,
                token = token
            };

        }

        [HttpGet]
        [Route("anonymous")]
        [AllowAnonymous]
        public string Anonymous() => "Anonimo";

        [HttpGet]
        [Route("authenticated")]
        [Authorize]

        public string Authenticated() => String.Format("Autenticado - {0}", User.Identity.Name);

        [HttpGet]
        [Route("employee")]
        [Authorize(Roles = "employee,manager")]

        public string Employee() => "Funcionário";


        [HttpGet]
        [Route("manager")]
        [Authorize(Roles = "manager")]

        public string Manager() => "Gerente";

    }
}
