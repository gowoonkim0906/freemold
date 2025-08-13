using System;
using System.Collections.Generic;

namespace Freemold.Modules;

public partial class TbHelpMemo
{
    public int Idx { get; set; }

    public int BoardIdx { get; set; }

    public string Contents { get; set; } = null!;

    public string Deleted { get; set; } = null!;

    public string IsAdmin { get; set; } = null!;

    public string IsRead { get; set; } = null!;

    public DateTime? IsReadDate { get; set; }

    public string RegId { get; set; } = null!;

    public string RegIp { get; set; } = null!;

    public DateTime RegDate { get; set; }
}
