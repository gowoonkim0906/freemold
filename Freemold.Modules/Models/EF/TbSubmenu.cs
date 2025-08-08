using System;
using System.Collections.Generic;

namespace Freemold.Modules.Models.EF;

public partial class TbSubmenu
{
    public int Idx { get; set; }

    public string Sort { get; set; } = null!;

    public string? UpCode { get; set; }

    public string? Code { get; set; }

    public string Name { get; set; } = null!;

    public string? BoardId { get; set; }

    public byte Ord { get; set; }
}
