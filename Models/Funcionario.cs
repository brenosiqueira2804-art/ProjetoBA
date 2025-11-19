using System;
using System.Collections.Generic;

namespace ProjetoBA.Models;

public partial class Funcionario
{
    public int Id { get; set; }

    public bool? Admin { get; set; }

    public int? UsuarioId { get; set; }

    public virtual Usuario? Usuario { get; set; }
}
