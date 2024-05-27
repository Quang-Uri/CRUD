using System;
using System.Collections.Generic;

namespace Web_CRUD.Entities;

public partial class Xa
{
    public int IdXa { get; set; }

    public string Ten { get; set; } = null!;

    public string Cap { get; set; } = null!;

    public int? IdHuyen { get; set; }

    public virtual Huyen? IdHuyenNavigation { get; set; } = null!;
}
