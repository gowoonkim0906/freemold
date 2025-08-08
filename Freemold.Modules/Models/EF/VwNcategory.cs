using System;
using System.Collections.Generic;

namespace Freemold.Modules.Models.EF;

public partial class VwNcategory
{
    public string Acode { get; set; } = null!;

    public string Aname { get; set; } = null!;

    public string? Bcode { get; set; }

    public string? Bname { get; set; }

    public string? Ccode { get; set; }

    public string? Cname { get; set; }

    public byte Aord { get; set; }

    public byte Bord { get; set; }

    public byte Cord { get; set; }

    public byte Adepth { get; set; }

    public byte Bdepth { get; set; }

    public byte Cdepth { get; set; }

    public string? Name { get; set; }
}
