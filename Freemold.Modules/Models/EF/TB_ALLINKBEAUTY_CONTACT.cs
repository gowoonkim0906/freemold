using System;
using System.Collections.Generic;

namespace Freemold.Modules;

public partial class TB_ALLINKBEAUTY_CONTACT
{
    public int Idx { get; set; }

    public string FullName { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Country { get; set; } = null!;

    public string CompanyName { get; set; } = null!;

    public string TypeofService { get; set; } = null!;

    public string? ProductCategory { get; set; }

    public string? TargetLaunchTimeline { get; set; }

    public string? EstimatedOrderQuantity { get; set; }

    public string? BudgetRange { get; set; }

    public string? FormulaRequirements { get; set; }

    public string? PackagingPreferences { get; set; }

    public string? Notes { get; set; }

    public DateTime RegDate { get; set; }

    public string RegIp { get; set; } = null!;
}
