using System;
using System.Collections.Generic;

namespace Freemold.Modules;

public partial class VwCategorySm
{
    public string CatEng { get; set; } = null!;

    public string Cat1Eng { get; set; } = null!;

    public string Cat2Eng { get; set; } = null!;

    public int UpCat { get; set; }

    public int Cat { get; set; }

    public string CatDepth { get; set; } = null!;

    public int Seq { get; set; }

    public string? Mold { get; set; }

    public string? Oem { get; set; }

    public string? CapaUnit { get; set; }

    public string? StandardMold { get; set; }
}
