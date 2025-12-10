using System;
using System.Collections.Generic;

namespace ProjetoBA.Models;

public partial class Produto
{
    public int Id { get; set; }

    public string Nomeproduto { get; set; } = null!;

    public decimal Preco { get; set; }

    public int Quantidade { get; set; }

    public string? Imagem { get; set; }

    public virtual ICollection<Pedido> Pedidos { get; set; } = new List<Pedido>();
}
