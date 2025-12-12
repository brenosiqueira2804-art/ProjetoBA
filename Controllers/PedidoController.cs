using Microsoft.AspNetCore.Mvc;
using ProjetoBA.Models;
using ProjetoBA.Contexts;
using Microsoft.EntityFrameworkCore;

namespace ProjetoBA.Controllers
{
    [Route("[controller]")]
    public class PedidoController : Controller
    {
        ProjetoContext _context = new ProjetoContext();

        [Route("Pedido")]
        public IActionResult Index()
        {
            var listaClientes = _context.Clientes.ToList();
            ViewBag.ListaClientes = listaClientes;

            var listaProdutos = _context.Produtos.ToList();
            ViewBag.ListaProdutos = listaProdutos;

            var listaPedidos = _context.Pedidos.ToList();
            ViewBag.ListaPedidos = listaPedidos;

            return View();
        }

        [HttpPost]
        public IActionResult SalvarPedido(Pedido pedido)
        {
            Produto produto = _context.Produtos.FirstOrDefault(x => x.Id == pedido.ProdutoId);
            pedido.UsuarioId = int.Parse(HttpContext.Session.GetString("Usuario"));
            pedido.DataPedido = DateTime.Now;
            pedido.Valor = produto.Preco * pedido.Quantidade;
            pedido.Status = "F";

            _context.Add(pedido);

            _context.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}