using System;
using System.Collections.Generic;

namespace Freemold.Modules;

public partial class TbSmInquiry
{
    public int Idx { get; set; }

    public int PIdx { get; set; }

    public string Name { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Company { get; set; } = null!;

    public string Inquiry { get; set; } = null!;

    public string ReCaptchaMsg { get; set; } = null!;

    public string ReCaptchaPass { get; set; } = null!;

    public string Deleted { get; set; } = null!;

    public string RegIp { get; set; } = null!;

    public string RegCountry { get; set; } = null!;

    public DateTime RegDate { get; set; }
}
