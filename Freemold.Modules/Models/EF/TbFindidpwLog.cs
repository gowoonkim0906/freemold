using System;
using System.Collections.Generic;

namespace Freemold.Modules.Models.EF;

public partial class TbFindidpwLog
{
    public int Idx { get; set; }

    public int ConIdx { get; set; }

    public string FindType { get; set; } = null!;

    public string? MName { get; set; }

    public string? MId { get; set; }

    public string? AddInfo { get; set; }

    public string RegIp { get; set; } = null!;

    public DateTime RegDate { get; set; }
}
