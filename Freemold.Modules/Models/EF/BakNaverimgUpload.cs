using System;
using System.Collections.Generic;

namespace Freemold.Modules.Models.EF;

public partial class BakNaverimgUpload
{
    public int Idx { get; set; }

    public string Filename { get; set; } = null!;

    public string HasError { get; set; } = null!;

    public string RegId { get; set; } = null!;

    public string RegIp { get; set; } = null!;

    public DateTime RegDate { get; set; }
}
