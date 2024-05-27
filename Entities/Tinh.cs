using System;
using System.Collections.Generic;

namespace Web_CRUD.Entities;

public partial class Tinh
{
    public int IdTinh { get; set; }

    public string Ten { get; set; } = null!;

    public string Cap { get; set; } = null!;

    public virtual ICollection<Huyen> Huyens { get; set; } = new List<Huyen>();
}
