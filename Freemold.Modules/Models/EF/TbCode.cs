using System;
using System.Collections.Generic;

namespace Freemold.Modules.Models.EF;

public partial class TbCode
{
    public int Idx { get; set; }

    public string Sort { get; set; } = null!;

    public string Code { get; set; } = null!;

    public string? Code2 { get; set; }

    public string Name { get; set; } = null!;

    public short Ord { get; set; }

    public string IsUse { get; set; } = null!;
}
