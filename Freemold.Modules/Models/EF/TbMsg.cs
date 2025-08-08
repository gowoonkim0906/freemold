using System;
using System.Collections.Generic;

namespace Freemold.Modules.Models.EF;

public partial class TbMsg
{
    public int Idx { get; set; }

    public string SendUser { get; set; } = null!;

    public string RecvUser { get; set; } = null!;

    public DateTime SendTime { get; set; }

    public DateTime? RecvTime { get; set; }

    public string SendFrom { get; set; } = null!;

    public int? PIdx { get; set; }

    public string? Contents { get; set; }

    public string Deleted { get; set; } = null!;

    public string RegIp { get; set; } = null!;

    public DateTime RegDate { get; set; }
}
