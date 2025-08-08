
using Freemold.Modules.Models.EF;
using Freemold.Modules.Models.EntityConfigs;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Freemold.Modules.Common
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options) { }


        public virtual DbSet<BakBanner> BakBanners { get; set; }

        public virtual DbSet<BakBannerKeyword> BakBannerKeywords { get; set; }

        public virtual DbSet<BakBoardDatum> BakBoardData { get; set; }

        public virtual DbSet<BakBoardRegcontent> BakBoardRegcontents { get; set; }

        public virtual DbSet<BakCategory> BakCategories { get; set; }

        public virtual DbSet<BakFavorite> BakFavorites { get; set; }

        public virtual DbSet<BakFavoriteUser> BakFavoriteUsers { get; set; }

        public virtual DbSet<BakMember1> BakMember1s { get; set; }

        public virtual DbSet<BakMember4> BakMember4s { get; set; }

        public virtual DbSet<BakMemberLogin> BakMemberLogins { get; set; }

        public virtual DbSet<BakNaverimgUpload> BakNaverimgUploads { get; set; }

        public virtual DbSet<BakProductList> BakProductLists { get; set; }

        public virtual DbSet<BakProductUser> BakProductUsers { get; set; }

        public virtual DbSet<BakQna> BakQnas { get; set; }

        public virtual DbSet<Category> Categories { get; set; }

        public virtual DbSet<Category1> Categories1 { get; set; }

        public virtual DbSet<CategoryOri> CategoryOris { get; set; }

        public virtual DbSet<Httpreferer> Httpreferers { get; set; }

        public virtual DbSet<Member1> Member1s { get; set; }

        public virtual DbSet<Member4> Member4s { get; set; }

        public virtual DbSet<MemberLogin> MemberLogins { get; set; }

        public virtual DbSet<ProductList> ProductLists { get; set; }

        public virtual DbSet<Qna> Qnas { get; set; }

        public virtual DbSet<TbAdminLog> TbAdminLogs { get; set; }

        public virtual DbSet<TbBanner> TbBanners { get; set; }

        public virtual DbSet<TbBannerClick> TbBannerClicks { get; set; }

        public virtual DbSet<TbBannerKeyword> TbBannerKeywords { get; set; }

        public virtual DbSet<TbBannerType> TbBannerTypes { get; set; }

        public virtual DbSet<TbBannerTypeCat> TbBannerTypeCats { get; set; }

        public virtual DbSet<TbBlockIp> TbBlockIps { get; set; }

        public virtual DbSet<TbBoardDatum> TbBoardData { get; set; }

        public virtual DbSet<TbBoardWview> TbBoardWviews { get; set; }

        public virtual DbSet<TbCategory> TbCategories { get; set; }

        public virtual DbSet<TbCode> TbCodes { get; set; }

        public virtual DbSet<TbCompareChain> TbCompareChains { get; set; }

        public virtual DbSet<TbCompareFolder> TbCompareFolders { get; set; }

        public virtual DbSet<TbCompareIng> TbCompareIngs { get; set; }

        public virtual DbSet<TbConnection> TbConnections { get; set; }

        public virtual DbSet<TbConnectionSm> TbConnectionSms { get; set; }

        public virtual DbSet<TbCount> TbCounts { get; set; }

        public virtual DbSet<TbError> TbErrors { get; set; }

        public virtual DbSet<TbFavorite> TbFavorites { get; set; }

        public virtual DbSet<TbFavoriteChain> TbFavoriteChains { get; set; }

        public virtual DbSet<TbFavoriteFolder> TbFavoriteFolders { get; set; }

        public virtual DbSet<TbFavoriteUser> TbFavoriteUsers { get; set; }

        public virtual DbSet<TbFindidpwLog> TbFindidpwLogs { get; set; }

        public virtual DbSet<TbHelp> TbHelps { get; set; }

        public virtual DbSet<TbHelpClick> TbHelpClicks { get; set; }

        public virtual DbSet<TbHelpMemo> TbHelpMemos { get; set; }

        public virtual DbSet<TbHomepage> TbHomepages { get; set; }

        public virtual DbSet<TbIptable> TbIptables { get; set; }

        public virtual DbSet<TbMailMReport> TbMailMReports { get; set; }

        public virtual DbSet<TbMsg> TbMsgs { get; set; }

        public virtual DbSet<TbProductUser> TbProductUsers { get; set; }

        public virtual DbSet<TbQuickmenu> TbQuickmenus { get; set; }

        public virtual DbSet<TbRecentView> TbRecentViews { get; set; }

        public virtual DbSet<TbSmInquiry> TbSmInquiries { get; set; }

        public virtual DbSet<TbSmsAuth> TbSmsAuths { get; set; }

        public virtual DbSet<TbStandardProdMain> TbStandardProdMains { get; set; }

        public virtual DbSet<TbSubmenu> TbSubmenus { get; set; }

        public virtual DbSet<TbSuggest> TbSuggests { get; set; }

        public virtual DbSet<TbUserSearch> TbUserSearches { get; set; }

        public virtual DbSet<TbUserSearchRaw> TbUserSearchRaws { get; set; }

        public virtual DbSet<TmList> TmLists { get; set; }

        public virtual DbSet<TmpAm> TmpAms { get; set; }

        public virtual DbSet<VwCategory> VwCategories { get; set; }

        public virtual DbSet<VwCategoryList> VwCategoryLists { get; set; }

        public virtual DbSet<VwCategorySm> VwCategorySms { get; set; }

        public virtual DbSet<VwCatprodChain> VwCatprodChains { get; set; }

        public virtual DbSet<VwMemberList> VwMemberLists { get; set; }

        public virtual DbSet<VwNcategory> VwNcategories { get; set; }

        public virtual DbSet<VwNcategoryList> VwNcategoryLists { get; set; }

        public virtual DbSet<VwProductList> VwProductLists { get; set; }

        public virtual DbSet<VwProductListSm> VwProductListSms { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            TbConfig.Configure(builder);
        }
    }
}
