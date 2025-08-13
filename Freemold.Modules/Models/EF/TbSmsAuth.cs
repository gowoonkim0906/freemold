using System;
using System.Collections.Generic;

namespace Freemold.Modules;

public partial class TbSmsAuth
{
    public int Idx { get; set; }

    public int ConIdx { get; set; }

    public string Mobile { get; set; } = null!;

    public string AuthKey { get; set; } = null!;

    public double AuthExpire { get; set; }

    public DateTime AuthExpireDate { get; set; }

    public string AuthStatus { get; set; } = null!;

    public string RegIp { get; set; } = null!;

    public DateTime RegDate { get; set; }
}
