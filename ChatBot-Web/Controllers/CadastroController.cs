using ChatBot_Web.Data;
using ChatBot_Web.Models;
using ChatBot_Web.Models.ViewModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace ChatBot_Web.Controllers
{
    public class CadastroController : Controller
    {
        private readonly ILogger<CadastroController> _logger;
        private readonly ApplicationDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;      


        public CadastroController(ApplicationDbContext context, UserManager<IdentityUser> userManager, ILogger<CadastroController> logger)

        {
            _userManager = userManager;
            _context = context;
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Perfil()
        {

            return View();
        }        


        public IActionResult Agendamento()
        {

            return View();
        }


    }
}
