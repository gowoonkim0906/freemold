using System;
using System.Collections.Generic;

namespace Freemold.Modules.Models.EF;

public partial class VwCatprodChain
{
    public long ProdUid { get; set; }

    public string PCategory { get; set; } = null!;

    public string? Val { get; set; }
}
