using GCMAvantes.Data;
using GCMAvantes.Models.ViewModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GCMAvantes.Controllers
{
    public class UsuarioPerfilController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        public UsuarioPerfilController(UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _roleManager = roleManager;
            _userManager = userManager;
        }
        public async Task<IActionResult> Index()
        {
            var users =  _userManager.Users.ToList();
            var userRolesViewModel = new List<UsuarioPerfilViewModel>();
            foreach (IdentityUser user in users)
            {
                var thisViewModel = new UsuarioPerfilViewModel();
                thisViewModel.UsuarioId = user.Id;
                thisViewModel.Email = user.Email;
                thisViewModel.NomeUsuario = user.UserName;                
                thisViewModel.Perfis = await GetUserRoles(user);
                userRolesViewModel.Add(thisViewModel);
            }
            return View(userRolesViewModel);
        }
        private async Task<List<string>> GetUserRoles(IdentityUser user)
        {
            return new List<string>(await _userManager.GetRolesAsync(user));
        }

        public async Task<IActionResult> Gerenciar(string userId)
        {
            ViewBag.UsuarioId = userId;
            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
            {
                ViewBag.ErrorMessage = $"Usuário com Id = {userId} não foi encontrado";
                return View("NotFound");
            }
            ViewBag.UsuarioNome = user.UserName;
            var model = new List<GerenciarUsuarioPerfisViewModel>();
            foreach (var role in _roleManager.Roles)
            {
                var userRolesViewModel = new GerenciarUsuarioPerfisViewModel
                {
                    PerfilId = role.Id,
                    PerfilNome = role.Name
                };
                if (await _userManager.IsInRoleAsync(user, role.Name))
                {
                    userRolesViewModel.Selecionado = true;
                }
                else
                {
                    userRolesViewModel.Selecionado = false;
                }
                model.Add(userRolesViewModel);
            }
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> Gerenciar(List<GerenciarUsuarioPerfisViewModel> model, string userId)
        {
            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
            {
                return View();
            }
            var roles = await _userManager.GetRolesAsync(user);
            var result = await _userManager.RemoveFromRolesAsync(user, roles);
            if (!result.Succeeded)
            {
                ModelState.AddModelError("", "Cannot remove user existing roles");
                return View(model);
            }
            result = await _userManager.AddToRolesAsync(user, model.Where(x => x.Selecionado).Select(y => y.PerfilNome));
            if (!result.Succeeded)
            {
                ModelState.AddModelError("", "Cannot add selected roles to user");
                return View(model);
            }
            return RedirectToAction("Index");
        }
    }
}
