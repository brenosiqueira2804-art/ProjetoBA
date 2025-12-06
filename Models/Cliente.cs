using System;
using System.Collections.Generic;

namespace ProjetoBA.Models;

public partial class Cliente
{
    public int Id { get; set; }

    public int UsuarioId { get; set; }

    public string Email { get; set; } = null!;

    public string? Codcliente { get; set; }

    public string? Razaosocial { get; set; }

    public string? Cnpj { get; set; }

    public virtual ICollection<Pedido> Pedidos { get; set; } = new List<Pedido>();

    public virtual Usuario Usuario { get; set; } = null!;
}
