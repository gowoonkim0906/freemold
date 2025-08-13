using System;
using System.Collections.Generic;

namespace Freemold.Modules;

public partial class Category
{
    public int Cate { get; set; }

    public string CateName { get; set; } = null!;

    public string CateEng { get; set; } = null!;

    public string CateLink { get; set; } = null!;

    public int PCate { get; set; }

    public string Mold { get; set; } = null!;

    public string Company { get; set; } = null!;

    public string OemOdm { get; set; } = null!;

    public int Seq { get; set; }

    public int SubSeq { get; set; }

    public string CapaUnit { get; set; } = null!;

    public string StandardMold { get; set; } = null!;
}
