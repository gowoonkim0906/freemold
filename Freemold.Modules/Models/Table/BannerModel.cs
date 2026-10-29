using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Freemold.Modules.Models
{
    public class BannerModel
    {
        public int Id { get; set; }
    }


    public class PopupModel
    {
        public List<int> idxs { get; set; } = new List<int>();

    }


    public class BannerSettingModel {


        public string? bccode { get; set; }
        public string ? bcname { get; set; }
        public int bcord { get; set; }
        public int banneridx { get; set; }
        public string? bannertype { get; set; }
        public string? bannername { get; set; }
        public int bannercnt { get; set; }
        public string? bannersize { get; set; }
        public int bannersizex { get; set; }
        public int bannersizey { get; set; }
        public int bannerprice { get; set; }
        public string? bannermode { get; set; }
        public int bannermonths { get; set; }
        public string? memo { get; set; }
        public int ord1 { get; set; }
        public int ord2 { get; set; }

    }

    public class BannerSettingCategoryModel
    {


        public string? catname { get; set; }
        public string? code { get; set; }
        public int aord { get; set; }
        public string? acode { get; set; }
        public int bord { get; set; }
        public string? bcode { get; set; }
        public int cord { get; set; }
        public string? ccode { get; set; }
        public int banneridx { get; set; }
        public int bannerprice { get; set; }
        public int bannercnt { get; set; }
        public int bannersizex { get; set; }
        public int bannersizey { get; set; }
        public string? bannermode { get; set; }
        public int bannermonths { get; set; }
        public string? memo { get; set; }

    }

    public class BannerManagementModel
    {


        public string? bccode { get; set; }
        public string? bcname { get; set; }
        public int bcord { get; set; }
        public int banneridx { get; set; }
        public string? bannertype { get; set; }
        public string? bannername { get; set; }
        public int bannercnt { get; set; }
        public int ord1 { get; set; }
        public int ord2 { get; set; }
        public int cnt1 { get; set; }
        public int cnt2 { get; set; }
        public int cnt3 { get; set; }

    }

    public class  BannerSetSettingModel
    {
        public int bidx { get; set; }
        public int bprice { get; set; }
        public int bmonths { get; set; }
        public int bsizex { get; set; }
        public int bsizey { get; set; }
        public string? bmode { get; set; }
        public string? bmemo { get; set; }
        public string? bbcode { get; set; }
        public string? bgubun { get; set; }
    }


    public class BannerSearchDataModel
    {
        public int idx { get; set; }
        public int bidx { get; set; }
        public string? bannerposition { get; set; }
        public string? bannername { get; set; }
        public string? companyname { get; set; }
        public string? bannerimage { get; set; }
        public string? bannersubject { get; set; }
        public int ord { get; set; }
        public string? bannerunlimit { get; set; }
        public string? sdate { get; set; }
        public string? edate { get; set; }
        public string? isuse { get; set; }
        public string? btype { get; set; }
        public string? regdate { get; set; }
        public string? sortcode { get; set; }
        public int bannertypeidx { get; set; }
    }


    public class BannerSearchModel
    {
        public int page { get; set; }
        public int pagesize { get; set; }
        
    }
}
