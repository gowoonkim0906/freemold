using System;
using System.Collections.Generic;

namespace Freemold.Modules;

public partial class VwCategoryList
{
    public string? CatName { get; set; }

    public string? Cat1Name { get; set; }

    public string Cat2Name { get; set; } = null!;

    public string? Cat1Eng { get; set; }

    public string Cat2Eng { get; set; } = null!;

    public int UpCat { get; set; }

    public int Cat { get; set; }

    public string CatDepth { get; set; } = null!;

    public int? Seq { get; set; }

    public int SubSeq { get; set; }

    public string? Mold { get; set; }

    public string? Oem { get; set; }

    public string CapaUnit { get; set; } = null!;

    public string StandardMold { get; set; } = null!;
}
