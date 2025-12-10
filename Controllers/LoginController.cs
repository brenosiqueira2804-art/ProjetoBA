using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ProjetoBA.Contexts;
using ProjetoBA.Models;

namespace ProjetoBA.Controllers
{
    public class LoginController : Controller
    {
        ProjetoContext context = new ProjetoContext();

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Logar(string email, string password)
        {
            if (!string.IsNullOrEmpty(email))
            {
                // Buscar um possivel usuario com o email informado
                Usuario usuario = context.Usuarios.FirstOrDefault(x => x.Email.ToLower() == email.ToLower());

                if (usuario == null)
                {
                    TempData["ErrorMessage"] = "Usuário não encontrado";
                }
                else
                {
                    if (usuario.Senha == password)
                    {
                        HttpContext.Session.SetString("Usuario", usuario.Id.ToString());

                        return RedirectToAction("Index", "Home");
                    }
                    else
                    {
                        TempData["ErrorMessage"] = "Email ou senha inválidos";
                    }
                }
            }
            else
            {
                TempData["ErrorMessage"] = "Email inválido";
            }

            return RedirectToAction("Index");
        }
    }
}