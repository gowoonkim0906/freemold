using System;
using System.Collections.Generic;

namespace Freemold.Modules.Models.EF;

public partial class TbHelp
{
    public int Idx { get; set; }

    public string Sort { get; set; } = null!;

    public string Subject { get; set; } = null!;

    public string? Contents { get; set; }

    public string? Attach { get; set; }

    public string Deleted { get; set; } = null!;

    public short MemoCnt { get; set; }

    public string Answer { get; set; } = null!;

    public string RegId { get; set; } = null!;

    public string RegIp { get; set; } = null!;

    public DateTime RegDate { get; set; }
}
