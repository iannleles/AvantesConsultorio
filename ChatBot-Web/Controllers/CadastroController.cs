using ChatBot_Web.Data;
using ChatBot_Web.Models;
using ChatBot_Web.Models.ViewModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
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


        public IActionResult Agendamento()
        {                       

            ViewData["EspecialidadeId"] = new SelectList(_context.Especialidade, "Id", "Nome");           
            ViewData["UFSiglaId"] = new SelectList(_context.UF, "UFId", "Nome");           

            return View();
        }


        [HttpPost]
        public IActionResult Agendamento(AgendamentoViewModel agendamentoViewModel) 
        {
            Agendamento agendamento = new Agendamento();

            if (ModelState.IsValid)
            {              
                agendamento.EspecialidadeId = agendamentoViewModel.EspecialidadeId;
                agendamento.Data = agendamentoViewModel.Data;
                agendamento.Horario = agendamentoViewModel.Horario;
                agendamento.Paciente = new Paciente()
                {
                    Nome = agendamentoViewModel.Paciente.Nome,
                    Sobrenome = agendamentoViewModel.Paciente.Sobrenome,
                    RG = agendamentoViewModel.Paciente.RG,
                    CPF = agendamentoViewModel.Paciente.CPF,
                    DataNascimento = agendamentoViewModel.Paciente.DataNascimento,
                    Telefone = agendamentoViewModel.Paciente.Telefone,
                    Celular = agendamentoViewModel.Paciente.Celular,
                };
                agendamento.Endereco = new Endereco()
                {
                    Cep = agendamentoViewModel.Endereco.Cep,
                    Logradouro = agendamentoViewModel.Endereco.Logradouro,
                    Numero = agendamentoViewModel.Endereco.Numero,
                    Complemento = agendamentoViewModel.Endereco.Complemento,
                    Bairro = agendamentoViewModel.Endereco.Bairro,
                    Cidade = agendamentoViewModel.Endereco.Cidade,
                    UFSiglaId = agendamentoViewModel.Endereco.UFSiglaId,
                };            
            }

            _context.Agendamento.AddAsync(agendamento);
            _context.SaveChanges();

            return RedirectToAction(nameof(Listar));
        }

        // GET: Agendamentos
        public async Task<IActionResult> Listar()
        {
            var appDbContext = await _context.Agendamento.Include(a => a.Paciente).Include(a => a.Especialidade).Include(a => a.Endereco).ToListAsync();


            return View(appDbContext.OrderBy(x => x.Data).ToList());
        }


    }
}
