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

        public IActionResult Index()
        {
            var listaClientes = _context.Clientes.ToList();
            ViewBag.ListaClientes = listaClientes;

            var listaProdutos = _context.Produtos.ToList();
            ViewBag.ListaProdutos = listaProdutos;

            var listaPedidos = _context.Pedidos.ToList();
            ViewBag.ListaEquipes = listaPedidos;

            return View();
        }

        [HttpPost]
        public IActionResult SalvarPedido(Pedido pedido)
        {
            if (ModelState.IsValid)
            {
                pedido.DataPedido = DateTime.Now;
                pedido.Status = "F";

                _context.Pedidos.Add(pedido);
                _context.SaveChanges();
            }

            return RedirectToAction("Index");
        }

        // ← ESTE MÉTODO PRECISA ESTAR AQUI DENTRO DA CLASSE
        [HttpPost]
        public IActionResult Cadastrar(Pedido pedido)
        {
            pedido.UsuarioId = int.Parse(HttpContext.Session.GetString("Usuario"));
            _context.Add(pedido);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}