using GCMAvantes.Domain.Entities;
using GCMAvantes.Application.DTOs;
using GCMAvantes.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GCMAvantes.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class AgendamentoController : ControllerBase
    {

        private readonly IAgendamentoApplication _agendamentoApplication;

        public AgendamentoController(IAgendamentoApplication agendamentoApplication)
        {
            _agendamentoApplication = agendamentoApplication;
        }


        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_agendamentoApplication.GetAll());
        }

        [HttpPost]
        public IActionResult Insert(MateriaDTO materiaDTO)
        {
            _materiaApplication.Insert(materiaDTO);
            return Ok();
        }

        [HttpPut]
        public IActionResult Update(MateriaDTO materiaDTO)
        {
            _materiaApplication.Update(materiaDTO);
            return Ok();
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            _materiaApplication.Delete(id);
            return Ok();
        }


    }
}
