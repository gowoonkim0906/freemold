using System;
using System.Collections.Generic;

namespace Freemold.Modules.Models.EF;

public partial class TbMailMReport
{
    public int Idx { get; set; }

    public string SMonth { get; set; } = null!;

    public string Sort { get; set; } = null!;

    public string? Name { get; set; }

    public int Val { get; set; }
}
