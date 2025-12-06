using Microsoft.AspNetCore.Mvc;
using ProjetoBA.Contexts;

namespace ProjetoBA.Controllers
{
    [Route("[controller]")]
    public class ProdutoController : Controller
    {
        ProjetoContext _context = new ProjetoContext();

        // Ação que carrega a página cliente
        public IActionResult Index()
        {
            var listaProduto = _context.Produtos.ToList();

            ViewBag.ListaProdutos = listaProduto;
            
            return View();
        }
    }
}



