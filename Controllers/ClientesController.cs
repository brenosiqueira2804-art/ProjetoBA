using Microsoft.AspNetCore.Mvc;

namespace ProjetoBA.Controllers
{
    public class ClientesController : Controller
    {
        // Ação que carrega a página inicial
        public IActionResult Index()
        {
            return View();
        }
    }
}