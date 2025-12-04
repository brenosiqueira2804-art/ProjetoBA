
// // Não se esqueça de usar o namespace correto para os seus Models e Context

// using Microsoft.AspNetCore.Mvc;
// using ProjetoBA.Contexts;
// using ProjetoBA.Models;

// [Route("[controller]")]
// public class ProdutosController : ControllerBase
// {
//     ProjetoContext _context = new ProjetoContext();

//     // GET: api/Produtos
//     [HttpGet]
//     public ActionResult GetProdutos()
//     {

//         return View();
//         return _context.Produtos.ToList();
//     }
 
//     // GET: api/Produtos/5

//     [HttpGet("{id}")]
//     public ActionResult GetProduto(int id)

//     {
//         var produto = _context.Produtos.FindAsync(id);

//         if (produto == null)
//         {
//             return NotFound();
//         }
 
//         return produto;
//     }
 
//     // POST: api/Produtos
//     [HttpPost]
//     public ActionResult PostProduto(Produto produto)
//     {
//         _context.Produtos.Add(produto);

//         _context.SaveChangesAsync();
 
//         // Retorna 201 Created

//         return CreatedAtAction(nameof(GetProduto), new { id = produto.IdProduto }, produto);
//     }
 
//     // PUT: api/Produtos/5
//     [HttpPut("{id}")]
//     public IActionResult PutProduto(int id, Produto produto)
//     {
//         if (id != produto.IdProduto)

//         {
//             return BadRequest();
//         }
 
//         _context.Entry(produto).State = EntityState.Modified;
 
//         try
//         {
//             _context.SaveChangesAsync();
//         }
//         catch (DbUpdateConcurrencyException)
//         {
//             if (!_context.Produtos.Any(e => e.IdProduto == id))

//             {
//                 return NotFound();
//             }
//             else

//             {
//                 throw;
//             }

//         }
 
//         return NoContent(); // Retorna 204 No Content (sucesso)
//     }
 
//     // DELETE: api/Produtos/5

//     [HttpDelete("{id}")]
//     public IActionResult DeleteProduto(int id)
//     {
//         var produto = _context.Produtos.FindAsync(id);

//         if (produto == null)

//         {

//             return NotFound();

//         }
 
//         _context.Produtos.Remove(produto);

//         _context.SaveChangesAsync();
 
//         return NoContent();
//     }
// }
 