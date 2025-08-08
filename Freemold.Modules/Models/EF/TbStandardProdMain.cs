using System;
using System.Collections.Generic;

namespace Freemold.Modules.Models.EF;

public partial class TbStandardProdMain
{
    public int Idx { get; set; }

    public string Sort { get; set; } = null!;

    public int PIdx { get; set; }

    public string IsUse { get; set; } = null!;
}
