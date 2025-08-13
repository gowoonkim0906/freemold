using System;
using System.Collections.Generic;

namespace Freemold.Modules;

public partial class TbCount
{
    public int Idx { get; set; }

    public string Sort { get; set; } = null!;

    public int? ValueNum { get; set; }

    public string? ValueTxt { get; set; }
}
