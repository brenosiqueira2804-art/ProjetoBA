
using Microsoft.AspNetCore.Mvc;
using ProjetoBA.Models;
using ProjetoBA.Contexts;
using Microsoft.EntityFrameworkCore; // se sua pasta do Context se chama Data

namespace ProjetoBA.Controllers
{
    [Route("[controller]")]
    public class PedidoController : Controller
    {
        ProjetoContext _context = new ProjetoContext();

        // Ação que carrega a página cliente
        public IActionResult Index()
        {
            // Carregar a lista de clientes para cadastro
            var listaClientes = _context.Clientes.ToList();

            ViewBag.ListaClientes = listaClientes;

            // Carregando a lista de produtos
            var listaProdutos = _context.Produtos.ToList();

            ViewBag.ListaProdutos = listaProdutos;

            // Carregando a lista de pedidos original
            // var listaPedidos = _context.Pedidos.Include("Produto").Include("Usuario").ToList();
            // var listaPedidos = _context.Pedidos.ToList();

            // ViewBag.ListaPedidos = listaPedidos;
            // Passando também a lista de equipes para montar o meu select
            var listaPedidos = _context.Pedidos.ToList();

            ViewBag.ListaEquipes = listaPedidos;

            return View();
        }

        [HttpPost]
        public IActionResult SalvarPedido(Pedido pedido)
        {
            if (ModelState.IsValid)
            {
                pedido.DataPedido = new DateTime();
                pedido.Status = "F";

                _context.Pedidos.Add(pedido);

                _context.SaveChanges();
            }

            return RedirectToAction("Index");
        }
    }

    [HttpPost]
        // Exemplo de uma Action para "Cadastrar" (se o botão CadastrarClientes apontar para '/Clientes/Cadastrar')
        public IActionResult Cadastrar(Pedido pedido)
        {

            pedido.UsuarioId = int.Parse(HttpContext.Session.GetString("Usuario"));

            _context.Add(pedido);

            _context.SaveChanges();

            return RedirectToAction("Index"); // Isso procurará o arquivo "Cadastrar.cshtml" na pasta Views/Cliente
        }
    }
}