using System;
using System.Collections.Generic;

namespace Freemold.Modules;

public partial class TB_EMAIL_SEND
{
    public int Idx { get; set; }

    public string ToEmail { get; set; } = null!;

    public string FromEmail { get; set; } = null!;

    public string EmailSubject { get; set; } = null!;

    public string EmailState { get; set; } = null!;

    public DateTime SendDate { get; set; }

    public string RegIp { get; set; } = null!;
}
