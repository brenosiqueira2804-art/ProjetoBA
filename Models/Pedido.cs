using System;
using System.Collections.Generic;

namespace ProjetoBA.Models;

public partial class Pedido
{
    public int Id { get; set; }

    public int? UsuarioId { get; set; }

    public int? ClienteId { get; set; }

    public int? ProdutoId { get; set; }

    public int? Codpedido { get; set; }

    public string? Quantidade { get; set; }

    public virtual Cliente? Cliente { get; set; }

    public virtual Produto? Produto { get; set; }

    public virtual Usuario? Usuario { get; set; }
}
