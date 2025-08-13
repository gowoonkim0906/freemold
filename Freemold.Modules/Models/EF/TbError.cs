using System;
using System.Collections.Generic;

namespace Freemold.Modules;

public partial class TbError
{
    public int Idx { get; set; }

    public string? ErrNumber { get; set; }

    public string? ErrDescription { get; set; }

    public string? ErrSource { get; set; }

    public string? ErrUrl { get; set; }

    public string RegId { get; set; } = null!;

    public string RegIp { get; set; } = null!;

    public DateTime RegDate { get; set; }
}
