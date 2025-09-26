using System;
using System.Collections.Generic;

namespace Freemold.Modules;

public partial class BakProductList
{
    public long? PROD_UID { get; set; }

    public string? it_id { get; set; }

    public string? CO_ID { get; set; }

    public string? MEMBER_GUBUN { get; set; }

    public int? MEMBER_UID { get; set; }

    public string? P_CATEGORY { get; set; }

    public string? P_NAME { get; set; }

    public string? P_NAME2 { get; set; }

    public string? P_CODE { get; set; }

    public int? P_MOQ { get; set; }

    public string? P_MOQ_DEAL { get; set; }

    public string? P_IMG1 { get; set; }

    public string? P_IMG2 { get; set; }

    public string? P_IMG3 { get; set; }

    public string? P_IMG4 { get; set; }

    public string? P_IMG5 { get; set; }

    public string? P_IMG6 { get; set; }

    public string? P_CAPACITY { get; set; }

    public string? P_CAP_UNIT { get; set; }

    public string? P_SIZE { get; set; }

    public string? P_ORIGIN { get; set; }

    public string? P_MEMO { get; set; }

    public string? P_MEMO2 { get; set; }

    public DateTime? P_REGDATE { get; set; }

    public DateTime? P_MODDATE { get; set; }

    public DateTime? P_APPDATE { get; set; }

    public DateTime? P_APPDATE_BEFORE { get; set; }

    public string? P_USE { get; set; }

    public string? P_USE_ST { get; set; }

    public string? P_NEW { get; set; }

    public string? P_HOT { get; set; }

    public string? P_QUALITY { get; set; }

    public int? P_SEQ { get; set; }

    public int? P_HIT { get; set; }

    public string? isRefill { get; set; }

    public string? isPCR { get; set; }

    public string? isMove { get; set; }

    public int? Visit { get; set; }

    public string? P_APPROVAL_BEFORE { get; set; }

    public string? P_APPROVAL { get; set; }

    public string? P_APPRUSER_BEFORE { get; set; }

    public string? P_APPRUSER { get; set; }

    public string? ProdType { get; set; }

    public string? Deleted { get; set; }

    public string? UpCat { get; set; }

    public string? Cat { get; set; }

    public string? Tag0 { get; set; }

    public string? Tag1 { get; set; }

    public string? Tag2 { get; set; }

    public string? Tag3 { get; set; }

    public string? Tag4 { get; set; }

    public string? Tag5 { get; set; }

    public string? Tag6 { get; set; }

    public string? Tag7 { get; set; }

    public string? Tag8 { get; set; }

    public string? Tag9 { get; set; }

    public string BRegType { get; set; } = null!;

    public string BRegID { get; set; } = null!;

    public string BRegIP { get; set; } = null!;

    public DateTime BRegDate { get; set; }

    public int BIdx { get; set; }
}
