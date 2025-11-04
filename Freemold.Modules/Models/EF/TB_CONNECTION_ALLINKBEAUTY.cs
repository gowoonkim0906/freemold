using System;
using System.Collections.Generic;

namespace Freemold.Modules;

public partial class TB_CONNECTION_ALLINKBEAUTY
{
    public long Idx { get; set; }

    public int mTimeStamp { get; set; }

    public string Domain { get; set; } = null!;

    public string UserAgent { get; set; } = null!;

    public string RegIP { get; set; } = null!;

    public DateTime RegDate { get; set; }

    public string? HttpReferer { get; set; }

    public DateTime InDate { get; set; }

    public long IPNum { get; set; }

    public string cCode { get; set; } = null!;
}
