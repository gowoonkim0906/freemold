using System;
using System.Collections.Generic;

namespace Freemold.Modules.Models.EF;

public partial class BakCategory
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

    public string Btype { get; set; } = null!;

    public string BregId { get; set; } = null!;

    public string BregIp { get; set; } = null!;

    public DateTime BregDate { get; set; }

    public int Bidx { get; set; }
}
