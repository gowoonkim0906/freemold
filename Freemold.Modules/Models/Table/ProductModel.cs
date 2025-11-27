using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Freemold.Modules.Models
{
    public class ProductModel
    {
        public string PImg1 { get; set; } = null!;
        public int Uid { get; set; }
        public string CompanyName { get; set; } = null!;
        public string CompanyNameE { get; set; } = null!;
        public string PCode { get; set; } = null!;
        public string? PCodeEn { get; set; }
        public string PSize { get; set; } = null!;
        public int PHit { get; set; }
        public double PCapacity { get; set; }
        public string PCapUnit { get; set; } = null!;
        public string PQuality { get; set; } = null!;
        public string QnaUse { get; set; } = null!;
        public string ProdType { get; set; } = null!;
        public int Visit { get; set; }
        public string UpCat { get; set; } = null!;
        public string POrigin { get; set; } = null!;
        public string IsRefill { get; set; } = null!;
        public string IsPcr { get; set; } = null!;
        public string? IsMove { get; set; }
        public string Deleted { get; set; } = null!;
        public string PApproval { get; set; } = null!;
        public string PUse { get; set; } = null!;
        public string Approval { get; set; } = null!;
        public string ApprovalView { get; set; } = null!;
        public DateOnly? StartDate { get; set; }
        public DateOnly? EndDate { get; set; }
        public DateTime PRegdate { get; set; }
    }

    public class AdminProductDetailModel
    {
        public long ProdUid { get; set; }
        public string? pimg1 { get; set; }

        public string? pname { get; set; }

        public string? pcode { get; set; }
        public string? pcodeen { get; set; }

        public double pcapacity { get; set; }

        public string? pcapunit { get; set; }

        public string? psize { get; set; }
        public string? pquality { get; set; }
        public int memberuid { get; set; }
        public string? company_name { get; set; }
    }

    public class AdminProductModel() {
        public long ProdUid { get; set; }
        public string PUseSt { get; set; } = null!;
        public string PHot { get; set; } = null!;
        public string PNew { get; set; } = null!;
        public string PName { get; set; } = null!;
        public string PCategory { get; set; } = null!;
        public string PCategoryName { get; set; } = null!;
        public string PCode { get; set; } = null!;
        public string? PCodeEn { get; set; }
        public double PCapacity { get; set; }
        public string PCapUnit { get; set; } = null!;
        public string PApproval { get; set; } = null!;
        public int PSeq { get; set; }
        public DateTime PRegdate { get; set; }
        public DateTime? PModdate { get; set; }
        public DateTime? PAppdate { get; set; }
        public string PSize { get; set; } = null!;
        public int PHit { get; set; }
        public string PQuality { get; set; } = null!;
        public string POrigin { get; set; } = null!;
        public string ProdType { get; set; } = null!;
        public int Visit { get; set; }
        public string PImg1 { get; set; } = null!;
        public string PImg2 { get; set; } = null!;
        public string PImg3 { get; set; } = null!;
        public string PImg4 { get; set; } = null!;
        public string PImg5 { get; set; } = null!;
        public string PImg6 { get; set; } = null!;
        public string Deleted { get; set; } = null!;
        public int MemberUid { get; set; }
        public string CompanyName { get; set; } = null!;
        public string PayUse { get; set; } = null!;
        public string Approval { get; set; } = null!;
        public string Sort { get; set; } = null!;
        public string IsUse { get; set; } = null!;
        public int ImgCnt { get; set; }
    }

    public class KbeautyProductModel()
    {
        public long ProdUid { get; set; }
        public string? PCode { get; set; }
        public string? PCodeEn { get; set; }
        public string? UpCat { get; set; }
        public string? PName { get; set; }
        public string? PImg1 { get; set; }
        public string? PImg2 { get; set; }
        public string? PImg3 { get; set; }
        public string? PImg4 { get; set; }
        public string? PImg5 { get; set; }
        public string? PImg6 { get; set; }
        public string? PSize { get; set; }
        public string? PQuality { get; set; }
        public string? POrigin { get; set; }
        public int? PHit { get; set; }
        public double? PCapacity { get; set; }
        public string? PCapUnit { get; set; }
        public string? ProdType { get; set; }
        public string? PCategory { get; set; }
        public string? PCategoryName { get; set; }
        public string? PMemoEng { get; set; }
        public string? Deleted { get; set; }
        public string? PayUse { get; set; }
        public string? PUse { get; set; }
        public string? PUseST { get; set; }
        public string? CompanyName { get; set; }
        public string? Approval { get; set; }
        public string? ApprovalBefore { get; set; }
        public string? ApprovalView { get; set; }
        public string? PApproval { get; set; }
        public string? PApprovalBefore { get; set; }
        public DateTime PRegDate { get; set; }
        public DateOnly? StartDate { get; set; }
        public DateOnly? EndDate { get; set; }
        public int? Visit { get; set; }
        public int? ImgCnt { get; set; }
    }

    public class ProductDetailModel {

        public long ProdUid { get; set; }

        public string ItId { get; set; } = null!;

        public string CoId { get; set; } = null!;

        public string MemberGubun { get; set; } = null!;

        public int MemberUid { get; set; }

        public string PCategory { get; set; } = null!;

        public string PName { get; set; } = null!;

        public string PName2 { get; set; } = null!;

        public string PCode { get; set; } = null!;
        public string? PCodeEn { get; set; }

        public int PMoq { get; set; }

        public string PMoqDeal { get; set; } = null!;

        public string PImg1 { get; set; } = null!;

        public string PImg2 { get; set; } = null!;

        public string PImg3 { get; set; } = null!;

        public string PImg4 { get; set; } = null!;

        public string PImg5 { get; set; } = null!;

        public string PImg6 { get; set; } = null!;

        public double PCapacity { get; set; }

        public string PCapUnit { get; set; } = null!;

        public string PSize { get; set; } = null!;

        public string POrigin { get; set; } = null!;

        public string PMemo { get; set; } = null!;

        public string PMemo2 { get; set; } = null!;
        public string? PMemoEng { get; set; }

        public DateTime PRegdate { get; set; }

        public DateTime? PModdate { get; set; }

        public DateTime? PAppdate { get; set; }

        public string PUse { get; set; } = null!;

        public string PUseSt { get; set; } = null!;

        public string PNew { get; set; } = null!;

        public string PHot { get; set; } = null!;

        public string PQuality { get; set; } = null!;

        public int PSeq { get; set; }

        public int PHit { get; set; }

        public string IsRefill { get; set; } = null!;

        public string IsPcr { get; set; } = null!;

        public string? IsMove { get; set; }

        public int Visit { get; set; }

        public string PApproval { get; set; } = null!;

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
       
        //기업 정보
        public int Uid { get; set; }
        public string CompanyName { get; set; } = null!;

        public string CompanyNameE { get; set; } = null!;

        public string CompanyNameC { get; set; } = null!;

        public string Tel { get; set; } = null!;

        public string Fax { get; set; } = null!;

        public string Mobile { get; set; } = null!;

        public string Email { get; set; } = null!;

        public string? Mainemail { get; set; }
        public string Damdang { get; set; } = null!;

        public string DamdangTel { get; set; } = null!;

        public string? DamdangDep { get; set; }

        public string? DamdangPos { get; set; }

        public string DamdangEmail { get; set; } = null!;
        public string ComType { get; set; } = null!;

    }

    public class ProductSaveModel
    {
        public long produid { get; set; }
        public string p_category { get; set; } = "";
        public string p_code { get; set; } = "";
        public string p_code_en { get; set; } = "";
        public string p_name { get; set; } = "";
        public double p_capacity { get; set; }
        public string p_size { get; set; } = "";
        public string p_quality { get; set; } = "";
        public string p_origin { get; set; } = "";
        public string p_memo { get; set; } = "";
        public string p_memo_en { get; set; } = "";
        public string p_img1 { get; set; } = null!;
        public string p_img2 { get; set; } = null!;
        public string p_img3 { get; set; } = null!;
        public string p_img4 { get; set; } = null!;
        public string p_img5 { get; set; } = null!;
        public string p_img6 { get; set; } = null!;

    }

    public class ProductSearchModel {
        public string category1 { get; set; } = "";
        public string category2 { get; set; } = "";
        public string category3 { get; set; } = "";
        public string volume1 { get; set; } = "";
        public string volume2 { get; set; } = "";
        public string kview { get; set; } = "";
        public string searchval { get; set; } = "";
        public string approval { get; set; } = ""; 

    }

    public class UspKbeautyProductModel
    {
        public long PROD_UID { get; set; }
        public string? P_CODE { get; set; } 
        public string? P_CODE_EN { get; set; }
        public string? UpCat { get; set; } 
        public string? P_NAME { get; set; }
        public string? P_CATEGORY { get; set; }
        public double P_CAPACITY { get; set; }
        public string? P_CAP_UNIT { get; set; }
        public string? P_SIZE { get; set; }
        public int P_HIT { get; set; }
        public string P_QUALITY { get; set; } = null!;
        public string P_ORIGIN { get; set; } = null!;
        public string ProdType { get; set; } = null!;
        public string P_IMG1 { get; set; } = null!;
        public string? P_APPROVAL_BEFORE { get; set; }
        public string P_APPROVAL { get; set; } = null!;
        public string Deleted { get; set; } = null!;
        public string P_USE { get; set; } = null!;
        public string P_USE_ST { get; set; } = null!;
        public DateTime P_REGDATE { get; set; }
        public int Visit { get; set; }
        public string COMPANY_NAME { get; set; } = null!;
        public string PayUse { get; set; } = null!;
        public string APPROVAL { get; set; } = null!;
        public string? APPROVAL_BEFORE { get; set; }
        public string APPROVAL_VIEW { get; set; } = null!;
        public DateOnly? START_DATE { get; set; }
        public DateOnly? END_DATE { get; set; }
        public int ImgCnt { get; set; }
        }
}
