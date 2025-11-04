using System;
using System.Collections.Generic;

namespace Freemold.Modules;

public partial class TB_ALLINKBEAUTY_CONTACT_US
{
    public int idx { get; set; }

    public string? Name { get; set; }

    public string? Email { get; set; }

    public string? Number { get; set; }

    public string? Detail { get; set; }

    public DateTime RegDate { get; set; }

    public string RegIp { get; set; } = null!;
}
