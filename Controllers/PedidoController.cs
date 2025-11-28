using Microsoft.AspNetCore.Mvc;

namespace ProjetoBA.Controllers
{
    public class PedidoController : Controller
    {
        // Ação que carrega a página cliente
        public IActionResult Index()
        {
            return View();
        }
    }
}