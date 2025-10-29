using System;
using System.Collections.Generic;

namespace Freemold.Modules;

public partial class Member1
{
    public int UID { get; set; }

    public string CO_ID { get; set; } = null!;

    public string COMPANY_NAME { get; set; } = null!;

    public string COMPANY_NAME_E { get; set; } = null!;

    public string COMPANY_NAME_C { get; set; } = null!;

    public string CEO { get; set; } = null!;

    public string COMP_NO { get; set; } = null!;

    public string TEL { get; set; } = null!;

    public string FAX { get; set; } = null!;

    public string MOBILE { get; set; } = null!;

    public string EMAIL { get; set; } = null!;

    public string? MAINEMAIL { get; set; }

    public string HOMEPAGE { get; set; } = null!;

    public string ZIPCODE { get; set; } = null!;

    public string ADDRESS1 { get; set; } = null!;

    public string ADDRESS2 { get; set; } = null!;

    public string ADDTIT1 { get; set; } = null!;

    public string ZIPCODE1 { get; set; } = null!;

    public string ADDRESS11 { get; set; } = null!;

    public string ADDRESS12 { get; set; } = null!;

    public string ADDTIT2 { get; set; } = null!;

    public string ZIPCODE2 { get; set; } = null!;

    public string ADDRESS21 { get; set; } = null!;

    public string ADDRESS22 { get; set; } = null!;

    public string ADDTIT3 { get; set; } = null!;

    public string ZIPCODE3 { get; set; } = null!;

    public string ADDRESS31 { get; set; } = null!;

    public string ADDRESS32 { get; set; } = null!;

    public string CATEGORY { get; set; } = null!;

    public string CLASS { get; set; } = null!;

    public string DAMDANG { get; set; } = null!;

    public string DAMDANG_TEL { get; set; } = null!;

    public string? DAMDANG_DEP { get; set; }

    public string? DAMDANG_POS { get; set; }

    public string DAMDANG_EMAIL { get; set; } = null!;

    public string ADMIN_ID { get; set; } = null!;

    public string CO_RELATION { get; set; } = null!;

    public string CO_EXPORT { get; set; } = null!;

    public string CO_CLIENT { get; set; } = null!;

    public string CO_COUND1 { get; set; } = null!;

    public string CO_COUND2 { get; set; } = null!;

    public string CO_STAFF { get; set; } = null!;

    public string CO_CI { get; set; } = null!;

    public string CO_CI2 { get; set; } = null!;

    public string CO_LEFT_IMG { get; set; } = null!;

    public string CO_TOP_IMG1 { get; set; } = null!;

    public string CO_TOP_IMG2 { get; set; } = null!;

    public string CO_TOP_IMG3 { get; set; } = null!;

    public string CO_BANNER { get; set; } = null!;

    public string CO_BANNER2 { get; set; } = null!;

    public string CO_BANNER3 { get; set; } = null!;

    public string CO_MAP { get; set; } = null!;

    public string CO_XY { get; set; } = null!;

    public string CO_TITLE1 { get; set; } = null!;

    public string CO_TITLE2 { get; set; } = null!;

    public string CO_TITLE3 { get; set; } = null!;

    public string CO_CONTENT1 { get; set; } = null!;

    public string CO_CONTENT2 { get; set; } = null!;

    public string CO_CONTENT3 { get; set; } = null!;

    public string CO_FOREGROUND { get; set; } = null!;

    public string UPFILE1 { get; set; } = null!;

    public string UPFILE2 { get; set; } = null!;

    public string UPFILE3 { get; set; } = null!;

    public string UPFILE4 { get; set; } = null!;

    public string UPFILE5 { get; set; } = null!;

    public string STAFF_ID { get; set; } = null!;

    public DateOnly? START_DATE { get; set; }

    public DateOnly? END_DATE { get; set; }

    public string CO_USE { get; set; } = null!;

    public string MEMO { get; set; } = null!;

    public string FACILITY1 { get; set; } = null!;

    public string FACILITY2 { get; set; } = null!;

    public string FACILITY3 { get; set; } = null!;

    public string FACILITY4 { get; set; } = null!;

    public string FACILITY5 { get; set; } = null!;

    public string FACILITY6 { get; set; } = null!;

    public string FACILITY7 { get; set; } = null!;

    public string FACILITY8 { get; set; } = null!;

    public string FACILITY9 { get; set; } = null!;

    public string FACILITY_MEMO { get; set; } = null!;

    public string APPROVAL { get; set; } = null!;

    public string? APPROVAL_BEFORE { get; set; }

    public DateTime? APPDATE { get; set; }

    public DateTime? APPDATE_BEFORE { get; set; }

    public string? APPRUSER_BEFORE { get; set; }

    public string? APPRUSER { get; set; }

    public string APPROVAL_VIEW { get; set; } = null!;

    public string LIST_ALLOW { get; set; } = null!;

    public DateTime? REG_DATE { get; set; }

    public DateTime? MOD_DATE { get; set; }

    public string CATEGORY_ID1 { get; set; } = null!;

    public string CATEGORY_ID2 { get; set; } = null!;

    public string CATEGORY_ID3 { get; set; } = null!;

    public string CO_TYPE { get; set; } = null!;

    public int CO_HIT { get; set; }

    public int CO_HIT_OLD { get; set; }

    public string CO_PROFILE { get; set; } = null!;

    public string CO_HIT_ITEM { get; set; } = null!;

    public string CO_UNUSUAL { get; set; } = null!;

    public string CO_ITEM_USE { get; set; } = null!;

    public string? CO_REMOVE { get; set; } = null;

    public DateTime? CO_REMOVE_DATE { get; set; }

    public string LEAVE_DATE { get; set; } = null!;

    public string INTERCEPT_DATE { get; set; } = null!;

    public string CEO_ADD { get; set; } = null!;

    public string QNA_USE { get; set; } = null!;

    public string FACILITY_USE { get; set; } = null!;

    public DateTime? END_LOGIN_DATE { get; set; }

    public string END_LOGIN_IP { get; set; } = null!;

    public int VISIT_CNT { get; set; }

    public string IP_GUBUN { get; set; } = null!;

    public string BANNER_LOGIN { get; set; } = null!;

    public string BANNER_FREE { get; set; } = null!;

    public string BANNER_OEM { get; set; } = null!;

    public string BANNER_SUB_FREE { get; set; } = null!;

    public string BANNER_SUB_COMPANY { get; set; } = null!;

    public string BANNER_SUB_COMMUNITY { get; set; } = null!;

    public string BANNER_SUB_NEWPROD { get; set; } = null!;

    public string BANNER_SUB_LISTING { get; set; } = null!;

    public string BANNER_SUB_SEARCH { get; set; } = null!;

    public string? BannerWish { get; set; }

    public string ComType { get; set; } = null!;

    public byte ComLevel { get; set; }

    public string PayUse { get; set; } = null!;

    public string MarketingAgree { get; set; } = null!;

    public string UpCat { get; set; } = null!;

    public string Cat { get; set; } = null!;

    public string? Location { get; set; }

    public string Deleted { get; set; } = null!;
}
