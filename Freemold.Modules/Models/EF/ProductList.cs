using System;
using System.Collections.Generic;

namespace Freemold.Modules;

public partial class ProductList
{
    public long PROD_UID { get; set; }

    public string it_id { get; set; } = null!;

    public string CO_ID { get; set; } = null!;

    public string MEMBER_GUBUN { get; set; } = null!;

    public int MEMBER_UID { get; set; }

    public string P_CATEGORY { get; set; } = null!;

    public string P_NAME { get; set; } = null!;

    public string P_NAME2 { get; set; } = null!;

    public string P_CODE { get; set; } = null!;
    public string P_CODE_EN { get; set; } = null!;

    public int P_MOQ { get; set; }

    public string P_MOQ_DEAL { get; set; } = null!;

    public string P_IMG1 { get; set; } = null!;

    public string P_IMG2 { get; set; } = null!;

    public string P_IMG3 { get; set; } = null!;

    public string P_IMG4 { get; set; } = null!;

    public string P_IMG5 { get; set; } = null!;

    public string P_IMG6 { get; set; } = null!;

    public double P_CAPACITY { get; set; }

    public string P_CAP_UNIT { get; set; } = null!;

    public string P_SIZE { get; set; } = null!;

    public string P_ORIGIN { get; set; } = null!;

    public string P_MEMO { get; set; } = null!;

    public string P_MEMO2 { get; set; } = null!;
    public string? P_MEMO_ENG { get; set; }

    public DateTime P_REGDATE { get; set; }

    public DateTime? P_MODDATE { get; set; }

    public DateTime? P_APPDATE { get; set; }

    public DateTime? P_APPDATE_BEFORE { get; set; }

    public string P_USE { get; set; } = null!;

    public string P_USE_ST { get; set; } = null!;

    public string P_NEW { get; set; } = null!;

    public string P_HOT { get; set; } = null!;

    public string P_QUALITY { get; set; } = null!;

    public int P_SEQ { get; set; }

    public int P_HIT { get; set; }

    public string isRefill { get; set; } = null!;

    public string isPCR { get; set; } = null!;

    public string? isMove { get; set; }

    public int Visit { get; set; }

    public string? P_APPROVAL_BEFORE { get; set; }

    public string P_APPROVAL { get; set; } = null!;

    public string? P_APPRUSER_BEFORE { get; set; }

    public string? P_APPRUSER { get; set; }

    public string ProdType { get; set; } = null!;

    public string Deleted { get; set; } = null!;

    public string UpCat { get; set; } = null!;

    public string Cat { get; set; } = null!;

    public string Tag0 { get; set; } = null!;

    public string Tag1 { get; set; } = null!;

    public string Tag2 { get; set; } = null!;

    public string Tag3 { get; set; } = null!;

    public string Tag4 { get; set; } = null!;

    public string Tag5 { get; set; } = null!;

    public string Tag6 { get; set; } = null!;

    public string Tag7 { get; set; } = null!;

    public string Tag8 { get; set; } = null!;

    public string Tag9 { get; set; } = null!;
}
