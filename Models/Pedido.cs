using System;
using System.Collections.Generic;

namespace ProjetoBA.Models;

public partial class Pedido
{
    public int Id { get; set; }

    public int UsuarioId { get; set; }

    public int ClienteId { get; set; }

    public int ProdutoId { get; set; }

    public string? Codpedido { get; set; }

    public int Quantidade { get; set; }

    public DateTime? DataPedido { get; set; }

    public decimal? Valor { get; set; }

    public string? Status { get; set; }

    public virtual Cliente Cliente { get; set; } = null!;

    public virtual Produto Produto { get; set; } = null!;

    public virtual Usuario Usuario { get; set; } = null!;
}
