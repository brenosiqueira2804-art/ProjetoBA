using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace ProjetoBA.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

    }
}   
    // Este Controller irá lidar com as rotas de /Account/Login
public class AccountController : Controller
{
    // 1. Ação para EXIBIR a página de login (GET)
    // O usuário acessa: /Account/Login
    [HttpGet]
    public IActionResult Login()
    {
        return View(); // Retorna a View que contém o código HTML que você forneceu
    }

    // 2. Ação para PROCESSAR o formulário de login (POST)
    [HttpPost]
    public IActionResult Login(string username, string password) // Recebe os dados do formulário
    {
        // --- LÓGICA DE VALIDAÇÃO DE LOGIN ---
        // Aqui é onde você checaria o banco de dados para ver se o 'username' e 'password' são válidos.

        // Exemplo SIMPLES de validação: Se a senha for "12345", loga.
        if (username == "Andreia.35@gmail.com" && password == "12345")
        {
            // Se o login for BEM-SUCEDIDO:
            // Redireciona o usuário para a página inicial (/Home/Index)
            return RedirectToAction("Index", "Home");
        }
        else
        {
            // Se o login falhar:
            // Adiciona uma mensagem de erro para ser exibida na View.
            ViewData["ErrorMessage"] = "E-mail ou senha incorretos.";

            // Retorna à mesma View de Login para que o usuário tente novamente.
            return View();
        }
    }    
}