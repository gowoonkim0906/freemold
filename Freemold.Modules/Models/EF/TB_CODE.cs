using System;
using System.Collections.Generic;

namespace Freemold.Modules;

public partial class TB_CODE
{
    public int Idx { get; set; }

    public string Sort { get; set; } = null!;

    public string Code { get; set; } = null!;

    public string? Code2 { get; set; }

    public string Name { get; set; } = null!;

    public string? EngName { get; set; }

    public short Ord { get; set; }

    public string isUse { get; set; } = null!;
}
