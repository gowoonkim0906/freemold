using System;
using System.Collections.Generic;

namespace Freemold.Modules.Models.EF;

public partial class VwCategory
{
    public int Acate { get; set; }

    public string Acatename { get; set; } = null!;

    public string Acateeng { get; set; } = null!;

    public int Bcate { get; set; }

    public string Bcatename { get; set; } = null!;

    public string Bcateeng { get; set; } = null!;

    public int Ccate { get; set; }

    public string Ccatename { get; set; } = null!;

    public string Ccateeng { get; set; } = null!;

    public int Seq { get; set; }

    public int SubSeq { get; set; }

    public string Amold { get; set; } = null!;

    public string? Bmold { get; set; }

    public string Aoem { get; set; } = null!;

    public string? Boem { get; set; }

    public string AcapaUnit { get; set; } = null!;

    public string? BcapaUnit { get; set; }

    public string Asm { get; set; } = null!;

    public string? Bsm { get; set; }
}
