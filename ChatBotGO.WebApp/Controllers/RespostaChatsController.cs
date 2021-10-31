using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ChatBotGO.WebApp.Data;
using ChatBotGO.WebApp.Models;

namespace ChatBotGO.WebApp.Controllers
{
    public class RespostaChatsController : Controller
    {
        private readonly Contexto _context;

        public RespostaChatsController(Contexto context)
        {
            _context = context;
        }

        // GET: RespostaChats
        public async Task<IActionResult> Index()
        {
            return View(await _context.RespostaChat.ToListAsync());
        }

        // GET: RespostaChats/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var respostaChat = await _context.RespostaChat
                .FirstOrDefaultAsync(m => m.Id == id);
            if (respostaChat == null)
            {
                return NotFound();
            }

            return View(respostaChat);
        }

        // GET: RespostaChats/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: RespostaChats/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Resposta,Mensagem")] RespostaChat respostaChat)
        {
            if (ModelState.IsValid)
            {
                _context.Add(respostaChat);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(respostaChat);
        }

        // GET: RespostaChats/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var respostaChat = await _context.RespostaChat.FindAsync(id);
            if (respostaChat == null)
            {
                return NotFound();
            }
            return View(respostaChat);
        }

        // POST: RespostaChats/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Resposta,Mensagem")] RespostaChat respostaChat)
        {
            if (id != respostaChat.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(respostaChat);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RespostaChatExists(respostaChat.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(respostaChat);
        }

        // GET: RespostaChats/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var respostaChat = await _context.RespostaChat
                .FirstOrDefaultAsync(m => m.Id == id);
            if (respostaChat == null)
            {
                return NotFound();
            }

            return View(respostaChat);
        }

        // POST: RespostaChats/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var respostaChat = await _context.RespostaChat.FindAsync(id);
            _context.RespostaChat.Remove(respostaChat);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RespostaChatExists(int id)
        {
            return _context.RespostaChat.Any(e => e.Id == id);
        }
        [HttpPost("api/Chat")]
        public async Task<JsonResult> Chat(RequestApi request)
        {
            var respostaChat = await _context.RespostaChat.Where(m => m.Mensagem.ToUpper().Contains(request.mensagem.ToUpper())).FirstOrDefaultAsync();

            if (respostaChat != null)
            {
                var resposta = new ResponseApi { resposta = respostaChat.Resposta };

                return Json(resposta);
            }
            else
            {
                var resposta = new ResponseApi { resposta = "Não entedemos sua pergunta. Poderia reformular?" };
                return Json(resposta);
            }
        }
    }
}
