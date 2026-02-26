using System;
using System.Collections.Generic;

namespace Freemold.Modules;

public partial class member4
{
    public int UID { get; set; }

    public string MEMBER_NAME { get; set; } = null!;

    public string NICK_NAME { get; set; } = null!;

    public string BIRTHDAY { get; set; } = null!;

    public string SEX { get; set; } = null!;

    public string LUNAR { get; set; } = null!;

    public string EMAIL { get; set; } = null!;

    public string HOMEPAGE { get; set; } = null!;

    public string MOBILE { get; set; } = null!;

    public string TEL { get; set; } = null!;

    public string ZIPCODE { get; set; } = null!;

    public string ADDRESS1 { get; set; } = null!;

    public string ADDRESS2 { get; set; } = null!;

    public string COMP_NAME { get; set; } = null!;

    public string COMP_DEPT { get; set; } = null!;

    public string MAILING { get; set; } = null!;

    public string SMS { get; set; } = null!;

    public string APPROVAL { get; set; } = null!;

    public string MEMO { get; set; } = null!;

    public DateTime? REG_DATE { get; set; }

    public DateTime? MOD_DATE { get; set; }

    public int MEMBER_LEVEL { get; set; }

    public int POINT { get; set; }

    public DateTime? END_LOGIN_DATE { get; set; }

    public string END_LOGIN_IP { get; set; } = null!;

    public int VISIT_CNT { get; set; }

    public string REG_IP { get; set; } = null!;

    public string MEMBER_OPEN { get; set; } = null!;

    public DateTime? MEMBER_OPEN_DATE { get; set; }

    public string COUNTRY { get; set; } = null!;

    public string FIRST_NAME { get; set; } = null!;

    public string FAX { get; set; } = null!;

    public string MEMBER_CLASS { get; set; } = null!;

    public string MEMBER_TYPE { get; set; } = null!;

    public string LEAVE_DATE { get; set; } = null!;

    public string INTERCEPT_DATE { get; set; } = null!;

    public string FavoriteBusiness { get; set; } = null!;

    public string MobileAuth { get; set; } = null!;

    public DateTime? MobileAuthDate { get; set; }

    public string EmailAuth { get; set; } = null!;

    public DateTime? EmailAuthDate { get; set; }

    public string MarketingAgree { get; set; } = null!;

    public string? AttrID { get; set; }

    public string Deleted { get; set; } = null!;
}
