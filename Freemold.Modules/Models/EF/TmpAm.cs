using System;
using System.Collections.Generic;

namespace Freemold.Modules;

public partial class TmpAm
{
    public int Idx { get; set; }

    public DateTime? WorkDate { get; set; }

    public TimeOnly? ChkTime { get; set; }

    public string? Name { get; set; }

    public string? Sort { get; set; }
}
