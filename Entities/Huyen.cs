using System;
using System.Collections.Generic;

namespace Web_CRUD.Entities;

public partial class Huyen
{
    public int IdHuyen { get; set; }

    public string Ten { get; set; } = null!;

    public string Cap { get; set; } = null!;

    public int? IdTinh { get; set; }

    public virtual Tinh? IdTinhNavigation { get; set; }

    public virtual ICollection<Xa> Xas { get; set; } = new List<Xa>();
}
