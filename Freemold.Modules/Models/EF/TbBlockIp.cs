using System;
using System.Collections.Generic;

namespace Freemold.Modules.Models.EF;

public partial class TbBlockIp
{
    public int Idx { get; set; }

    public string? BlockIp { get; set; }

    public DateTime? RegDate { get; set; }

    public string? DelYn { get; set; }
}
