using System;
using System.Collections.Generic;

namespace Freemold.Modules.Models.EF;

public partial class TbIptable
{
    public string SDate { get; set; } = null!;

    public string CCode { get; set; } = null!;

    public string SIp { get; set; } = null!;

    public string EIp { get; set; } = null!;

    public string PreFix { get; set; } = null!;

    public string RegDate { get; set; } = null!;

    public long SNum { get; set; }

    public long ENum { get; set; }
}
