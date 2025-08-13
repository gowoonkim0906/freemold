using System;
using System.Collections.Generic;

namespace Freemold.Modules;

public partial class BakMember1
{
    public int Uid { get; set; }

    public string CoId { get; set; } = null!;

    public string CompanyName { get; set; } = null!;

    public string CompanyNameE { get; set; } = null!;

    public string CompanyNameC { get; set; } = null!;

    public string Ceo { get; set; } = null!;

    public string CompNo { get; set; } = null!;

    public string Tel { get; set; } = null!;

    public string Fax { get; set; } = null!;

    public string Mobile { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string? Mainemail { get; set; }

    public string Homepage { get; set; } = null!;

    public string Zipcode { get; set; } = null!;

    public string Address1 { get; set; } = null!;

    public string Address2 { get; set; } = null!;

    public string Addtit1 { get; set; } = null!;

    public string Zipcode1 { get; set; } = null!;

    public string Address11 { get; set; } = null!;

    public string Address12 { get; set; } = null!;

    public string Addtit2 { get; set; } = null!;

    public string Zipcode2 { get; set; } = null!;

    public string Address21 { get; set; } = null!;

    public string Address22 { get; set; } = null!;

    public string Addtit3 { get; set; } = null!;

    public string Zipcode3 { get; set; } = null!;

    public string Address31 { get; set; } = null!;

    public string Address32 { get; set; } = null!;

    public string Category { get; set; } = null!;

    public string Class { get; set; } = null!;

    public string Damdang { get; set; } = null!;

    public string DamdangTel { get; set; } = null!;

    public string? DamdangDep { get; set; }

    public string? DamdangPos { get; set; }

    public string DamdangEmail { get; set; } = null!;

    public string AdminId { get; set; } = null!;

    public string CoRelation { get; set; } = null!;

    public string CoExport { get; set; } = null!;

    public string CoClient { get; set; } = null!;

    public string CoCound1 { get; set; } = null!;

    public string CoCound2 { get; set; } = null!;

    public string CoStaff { get; set; } = null!;

    public string CoCi { get; set; } = null!;

    public string CoCi2 { get; set; } = null!;

    public string CoLeftImg { get; set; } = null!;

    public string CoTopImg1 { get; set; } = null!;

    public string CoTopImg2 { get; set; } = null!;

    public string CoTopImg3 { get; set; } = null!;

    public string CoBanner { get; set; } = null!;

    public string CoBanner2 { get; set; } = null!;

    public string CoBanner3 { get; set; } = null!;

    public string CoMap { get; set; } = null!;

    public string CoXy { get; set; } = null!;

    public string CoTitle1 { get; set; } = null!;

    public string CoTitle2 { get; set; } = null!;

    public string CoTitle3 { get; set; } = null!;

    public string CoContent1 { get; set; } = null!;

    public string CoContent2 { get; set; } = null!;

    public string CoContent3 { get; set; } = null!;

    public string CoForeground { get; set; } = null!;

    public string Upfile1 { get; set; } = null!;

    public string Upfile2 { get; set; } = null!;

    public string Upfile3 { get; set; } = null!;

    public string Upfile4 { get; set; } = null!;

    public string Upfile5 { get; set; } = null!;

    public string StaffId { get; set; } = null!;

    public DateOnly? StartDate { get; set; }

    public DateOnly? EndDate { get; set; }

    public string CoUse { get; set; } = null!;

    public string Memo { get; set; } = null!;

    public string Facility1 { get; set; } = null!;

    public string Facility2 { get; set; } = null!;

    public string Facility3 { get; set; } = null!;

    public string Facility4 { get; set; } = null!;

    public string Facility5 { get; set; } = null!;

    public string Facility6 { get; set; } = null!;

    public string Facility7 { get; set; } = null!;

    public string Facility8 { get; set; } = null!;

    public string Facility9 { get; set; } = null!;

    public string FacilityMemo { get; set; } = null!;

    public string Approval { get; set; } = null!;

    public string ApprovalView { get; set; } = null!;

    public string ListAllow { get; set; } = null!;

    public DateTime? RegDate { get; set; }

    public DateTime? ModDate { get; set; }

    public string CategoryId1 { get; set; } = null!;

    public string CategoryId2 { get; set; } = null!;

    public string CategoryId3 { get; set; } = null!;

    public string CoType { get; set; } = null!;

    public int CoHit { get; set; }

    public int? CoHitOld { get; set; }

    public string CoProfile { get; set; } = null!;

    public string CoHitItem { get; set; } = null!;

    public string CoUnusual { get; set; } = null!;

    public string CoItemUse { get; set; } = null!;

    public string LeaveDate { get; set; } = null!;

    public string InterceptDate { get; set; } = null!;

    public string CeoAdd { get; set; } = null!;

    public string QnaUse { get; set; } = null!;

    public string FacilityUse { get; set; } = null!;

    public DateTime? EndLoginDate { get; set; }

    public string EndLoginIp { get; set; } = null!;

    public int? VisitCnt { get; set; }

    public string IpGubun { get; set; } = null!;

    public string BannerLogin { get; set; } = null!;

    public string BannerFree { get; set; } = null!;

    public string BannerOem { get; set; } = null!;

    public string BannerSubFree { get; set; } = null!;

    public string BannerSubCompany { get; set; } = null!;

    public string BannerSubCommunity { get; set; } = null!;

    public string BannerSubNewprod { get; set; } = null!;

    public string BannerSubListing { get; set; } = null!;

    public string BannerSubSearch { get; set; } = null!;

    public string? BannerWish { get; set; }

    public string ComType { get; set; } = null!;

    public byte ComLevel { get; set; }

    public string PayUse { get; set; } = null!;

    public string? MarketingAgree { get; set; }

    public string? UpCat { get; set; }

    public string? Cat { get; set; }

    public string? Location { get; set; }

    public string Deleted { get; set; } = null!;

    public string BregType { get; set; } = null!;

    public string BregId { get; set; } = null!;

    public string BregIp { get; set; } = null!;

    public DateTime BregDate { get; set; }

    public int Bidx { get; set; }
}
