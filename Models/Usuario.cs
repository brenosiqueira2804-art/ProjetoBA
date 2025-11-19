using System;
using System.Collections.Generic;

namespace ProjetoBA.Models;

public partial class Usuario
{
    public int Id { get; set; }

    public string? Email { get; set; }

    public string? Nome { get; set; }

    public string? Senha { get; set; }

    public virtual ICollection<Cliente> Clientes { get; set; } = new List<Cliente>();

    public virtual ICollection<Funcionario> Funcionarios { get; set; } = new List<Funcionario>();

    public virtual ICollection<Pedido> Pedidos { get; set; } = new List<Pedido>();
}
