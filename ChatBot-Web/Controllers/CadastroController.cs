using ChatBot_Web.Models;
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

        public CadastroController(ILogger<CadastroController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }


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
