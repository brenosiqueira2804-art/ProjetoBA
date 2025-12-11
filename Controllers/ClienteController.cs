using Microsoft.AspNetCore.Mvc;
using ProjetoBA.Contexts;
using ProjetoBA.Models;
 
namespace ProjetoBA.Controllers;
 
// Este nome (Cliente) é o que corresponde à rota '/Clientes'
[Route("[controller]")]
public class ClienteController : Controller
{
    ProjetoContext context = new ProjetoContext();
 
    // Este método (Action) é o que corresponde à rota base '/Clientes'
    // A convenção no ASP.NET Core MVC é usar "Index" como a Action principal.
    public IActionResult Index()
    {
 
        // 1. **Executar a Lógica C# (Model)**:
        // Aqui você chamaria o código C# para buscar a lista de clientes no banco de dados.
        // Exemplo: List<Cliente> listaClientes = _repositorio.ObterTodosClientes();
 
        // 2. **Passar os Dados para a View**:
        // return View(listaClientes); // Se você passou dados
 
        // 3. **Retornar a View (HTML)**:
        return View(); // Isso procurará o arquivo "Index.cshtml" na pasta Views/Cliente
    }
 
    [HttpPost]
    // Exemplo de uma Action para "Cadastrar" (se o botão CadastrarClientes apontar para '/Clientes/Cadastrar')
    public IActionResult Cadastrar(Cliente cliente)
    {
 
        cliente.UsuarioId = int.Parse(HttpContext.Session.GetString("Usuario"));
 
        context.Add(cliente);
 
        context.SaveChanges();
       
        return RedirectToAction("Index"); // Isso procurará o arquivo "Cadastrar.cshtml" na pasta Views/Cliente
    }
}