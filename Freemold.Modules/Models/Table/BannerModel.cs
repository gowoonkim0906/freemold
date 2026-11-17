using Microsoft.AspNetCore.Http;
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
        public int bwaiting { get; set; }   //대기
        public int breservation { get; set; } //예약
        public int bdeadline { get; set; } //마감임박
        public int bing { get; set; } //운영중
        public int bfree { get; set; } //무료
        public int bcompanyfree { get; set; } //자사무료

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
        public int bannerprice { get; set; }
        public int ord1 { get; set; }
        public int ord2 { get; set; }
        public int bannersizex { get; set; }
        public int bannersizey { get; set; }


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

    public class  BannerResponseModel
    {
        public string? company_name { get; set; }
        public int uid { get; set; }
        public int idx { get; set; }
        public int midx { get; set; }
        public int bidx { get; set; }
        public string ? bannerimage { get; set; }
        public string? bannerlink { get; set; }
        public string? bannersubject { get; set; }
        public DateTime? sdate { get; set; }
        public DateTime? edate { get; set; }
        public string isuse { get; set; } = null!;
        public int ord { get; set; }
        public DateTime regdate { get; set; }
        public decimal? bannerprice { get; set; }
        public string? bannerwaiting { get; set; }
        public int? remaindays { get; set; }
        


    }

    public class BannerCntModel { 
    
        public int btotal { get; set; } 
        public int bwaiting { get; set; }
        public int breservation { get; set; }
        public int bend { get; set; }
        public int bdeadline { get; set; }
        public int bing { get; set; }
        public int bstop { get; set; }
        public int bvacant { get; set; }
        public int bannercnt { get; set; }
        public int bannersizex { get; set; }
        public int bannersizey { get; set; }

    }
    

    public class BannerDeleteRequestModel
    {
        public List<int> idx { get; set; } = new();
        public string? deleteyn { get; set; }
        public string? memberId { get; set; }
        public string? regIp { get; set; }

    }

    public class BannerSetRequestModel
    {
        public int bidx { get; set; }
        public int midx { get; set; }
        public int idx { get; set; }        //배너번호(수정시 이용)
        public string btype { get; set; } = null!;  //카테고리 여부
        public string bcode { get; set; } = null!;  //카테코리 코드
        public IFormFile? bannerimage { get; set; } //이미지 파일
        public string inputbannerimage { get; set; } = null!;  //저장된 이미지파일명(수정시 이용)
        public int bannerprice { get; set; } //배너가격
        public int ord { get; set; }    //배너순서
        public string deleted { get; set; } = "N";    //삭제여부
        public string? bannerlink { get; set; } //배너링크
        public string? bannersubject { get; set; } //배너내용
        public string isuse { get; set; } = "Y"; //사용여부
        public string bannerwaiting { get; set; } = "N"; //대기여부
        public DateTime? sdate { get; set; } //시작일
        public DateTime? edate { get; set; } //종료일
        public string regid { get; set; } = ""; //등록아이디
        public string regip { get; set; } = ""; //등록아이피
        public string savebannerimage { get; set; } = ""; //저장된 배너이미지 경로
        public int bcnt { get; set; } //배너사용가능 개수

        public string bregid { get; set; } = null!; //등록아이디(수정시 bak 테이블에 등록된 아이디)
        public string bregip { get; set; } = null!; //등록아이피(수정시 bak 테이블에 등록된 아이디)
    }

   
}
