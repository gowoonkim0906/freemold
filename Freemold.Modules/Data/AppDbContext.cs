using System;
using System.Collections.Generic;
using Freemold.Modules.Models;
using Microsoft.EntityFrameworkCore;

namespace Freemold.Modules.Data;

public partial class AppDbContext : DbContext
{
    public AppDbContext()
    {
    }

    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<BakMember1> BakMember1s { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=100.103.188.13,1502;Database=Freemold_dev;User Id=dPlanet;Password=designPLNT%%!!;Encrypt=False;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<BakMember1>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("BAK_member1");

            entity.Property(e => e.Address1)
                .HasMaxLength(200)
                .HasColumnName("ADDRESS1");
            entity.Property(e => e.Address11)
                .HasMaxLength(200)
                .HasColumnName("ADDRESS11");
            entity.Property(e => e.Address12)
                .HasMaxLength(200)
                .HasColumnName("ADDRESS12");
            entity.Property(e => e.Address2)
                .HasMaxLength(200)
                .HasColumnName("ADDRESS2");
            entity.Property(e => e.Address21)
                .HasMaxLength(200)
                .HasColumnName("ADDRESS21");
            entity.Property(e => e.Address22)
                .HasMaxLength(200)
                .HasColumnName("ADDRESS22");
            entity.Property(e => e.Address31)
                .HasMaxLength(200)
                .HasColumnName("ADDRESS31");
            entity.Property(e => e.Address32)
                .HasMaxLength(200)
                .HasColumnName("ADDRESS32");
            entity.Property(e => e.Addtit1)
                .HasMaxLength(20)
                .HasColumnName("ADDTIT1");
            entity.Property(e => e.Addtit2)
                .HasMaxLength(20)
                .HasColumnName("ADDTIT2");
            entity.Property(e => e.Addtit3)
                .HasMaxLength(20)
                .HasColumnName("ADDTIT3");
            entity.Property(e => e.AdminId)
                .HasMaxLength(50)
                .HasColumnName("ADMIN_ID");
            entity.Property(e => e.Approval)
                .HasMaxLength(1)
                .HasColumnName("APPROVAL");
            entity.Property(e => e.ApprovalView)
                .HasMaxLength(1)
                .HasColumnName("APPROVAL_VIEW");
            entity.Property(e => e.BannerFree)
                .HasMaxLength(5)
                .HasColumnName("BANNER_FREE");
            entity.Property(e => e.BannerLogin)
                .HasMaxLength(5)
                .HasColumnName("BANNER_LOGIN");
            entity.Property(e => e.BannerOem)
                .HasMaxLength(5)
                .HasColumnName("BANNER_OEM");
            entity.Property(e => e.BannerSubCommunity)
                .HasMaxLength(5)
                .HasColumnName("BANNER_SUB_COMMUNITY");
            entity.Property(e => e.BannerSubCompany)
                .HasMaxLength(5)
                .HasColumnName("BANNER_SUB_COMPANY");
            entity.Property(e => e.BannerSubFree)
                .HasMaxLength(5)
                .HasColumnName("BANNER_SUB_FREE");
            entity.Property(e => e.BannerSubListing)
                .HasMaxLength(5)
                .HasColumnName("BANNER_SUB_LISTING");
            entity.Property(e => e.BannerSubNewprod)
                .HasMaxLength(5)
                .HasColumnName("BANNER_SUB_NEWPROD");
            entity.Property(e => e.BannerSubSearch)
                .HasMaxLength(5)
                .HasColumnName("BANNER_SUB_SEARCH");
            entity.Property(e => e.BannerWish)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Bidx)
                .ValueGeneratedOnAdd()
                .HasColumnName("BIdx");
            entity.Property(e => e.BregDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("BRegDate");
            entity.Property(e => e.BregId)
                .HasMaxLength(50)
                .HasColumnName("BRegID");
            entity.Property(e => e.BregIp)
                .HasMaxLength(23)
                .IsUnicode(false)
                .HasColumnName("BRegIP");
            entity.Property(e => e.BregType)
                .HasMaxLength(50)
                .HasColumnName("BRegType");
            entity.Property(e => e.Cat)
                .HasMaxLength(1000)
                .IsUnicode(false);
            entity.Property(e => e.Category)
                .HasMaxLength(2000)
                .HasColumnName("CATEGORY");
            entity.Property(e => e.CategoryId1)
                .HasMaxLength(20)
                .HasColumnName("CATEGORY_ID1");
            entity.Property(e => e.CategoryId2)
                .HasMaxLength(20)
                .HasColumnName("CATEGORY_ID2");
            entity.Property(e => e.CategoryId3)
                .HasMaxLength(20)
                .HasColumnName("CATEGORY_ID3");
            entity.Property(e => e.Ceo)
                .HasMaxLength(30)
                .HasColumnName("CEO");
            entity.Property(e => e.CeoAdd)
                .HasMaxLength(20)
                .HasColumnName("CEO_ADD");
            entity.Property(e => e.Class)
                .HasMaxLength(5)
                .HasColumnName("CLASS");
            entity.Property(e => e.CoBanner)
                .HasMaxLength(100)
                .HasColumnName("CO_BANNER");
            entity.Property(e => e.CoBanner2)
                .HasMaxLength(100)
                .HasColumnName("CO_BANNER2");
            entity.Property(e => e.CoBanner3)
                .HasMaxLength(100)
                .HasColumnName("CO_BANNER3");
            entity.Property(e => e.CoCi)
                .HasMaxLength(100)
                .HasColumnName("CO_CI");
            entity.Property(e => e.CoCi2)
                .HasMaxLength(100)
                .HasColumnName("CO_CI2");
            entity.Property(e => e.CoClient)
                .HasMaxLength(500)
                .HasColumnName("CO_CLIENT");
            entity.Property(e => e.CoContent1).HasColumnName("CO_CONTENT1");
            entity.Property(e => e.CoContent2).HasColumnName("CO_CONTENT2");
            entity.Property(e => e.CoContent3).HasColumnName("CO_CONTENT3");
            entity.Property(e => e.CoCound1)
                .HasMaxLength(4)
                .HasColumnName("CO_COUND1");
            entity.Property(e => e.CoCound2)
                .HasMaxLength(2)
                .HasColumnName("CO_COUND2");
            entity.Property(e => e.CoExport)
                .HasMaxLength(500)
                .HasColumnName("CO_EXPORT");
            entity.Property(e => e.CoForeground)
                .HasMaxLength(100)
                .HasColumnName("CO_FOREGROUND");
            entity.Property(e => e.CoHit).HasColumnName("CO_HIT");
            entity.Property(e => e.CoHitItem).HasColumnName("CO_HIT_ITEM");
            entity.Property(e => e.CoHitOld).HasColumnName("CO_HIT_OLD");
            entity.Property(e => e.CoId)
                .HasMaxLength(15)
                .HasColumnName("CO_ID");
            entity.Property(e => e.CoItemUse)
                .HasMaxLength(1)
                .HasColumnName("CO_ITEM_USE");
            entity.Property(e => e.CoLeftImg)
                .HasMaxLength(100)
                .HasColumnName("CO_LEFT_IMG");
            entity.Property(e => e.CoMap)
                .HasMaxLength(100)
                .HasColumnName("CO_MAP");
            entity.Property(e => e.CoProfile).HasColumnName("CO_PROFILE");
            entity.Property(e => e.CoRelation)
                .HasMaxLength(500)
                .HasColumnName("CO_RELATION");
            entity.Property(e => e.CoRemove)
                .HasMaxLength(1)
                .HasColumnName("CO_REMOVE");
            entity.Property(e => e.CoRemoveDate)
                .HasColumnType("datetime")
                .HasColumnName("CO_REMOVE_DATE");
            entity.Property(e => e.CoStaff)
                .HasMaxLength(5)
                .HasColumnName("CO_STAFF");
            entity.Property(e => e.CoTitle1)
                .HasMaxLength(30)
                .HasColumnName("CO_TITLE1");
            entity.Property(e => e.CoTitle2)
                .HasMaxLength(30)
                .HasColumnName("CO_TITLE2");
            entity.Property(e => e.CoTitle3)
                .HasMaxLength(30)
                .HasColumnName("CO_TITLE3");
            entity.Property(e => e.CoTopImg1)
                .HasMaxLength(100)
                .HasColumnName("CO_TOP_IMG1");
            entity.Property(e => e.CoTopImg2)
                .HasMaxLength(100)
                .HasColumnName("CO_TOP_IMG2");
            entity.Property(e => e.CoTopImg3)
                .HasMaxLength(100)
                .HasColumnName("CO_TOP_IMG3");
            entity.Property(e => e.CoType)
                .HasMaxLength(1)
                .HasColumnName("CO_TYPE");
            entity.Property(e => e.CoUnusual).HasColumnName("CO_UNUSUAL");
            entity.Property(e => e.CoUse)
                .HasMaxLength(1)
                .HasColumnName("CO_USE");
            entity.Property(e => e.CoXy)
                .HasMaxLength(100)
                .HasColumnName("CO_XY");
            entity.Property(e => e.ComLevel).HasDefaultValue((byte)1);
            entity.Property(e => e.ComType)
                .HasMaxLength(10)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.CompNo)
                .HasMaxLength(15)
                .HasColumnName("COMP_NO");
            entity.Property(e => e.CompanyName)
                .HasMaxLength(50)
                .HasColumnName("COMPANY_NAME");
            entity.Property(e => e.CompanyNameC)
                .HasMaxLength(50)
                .HasColumnName("COMPANY_NAME_C");
            entity.Property(e => e.CompanyNameE)
                .HasMaxLength(50)
                .HasColumnName("COMPANY_NAME_E");
            entity.Property(e => e.Damdang)
                .HasMaxLength(200)
                .HasColumnName("DAMDANG");
            entity.Property(e => e.DamdangDep)
                .HasMaxLength(200)
                .HasColumnName("DAMDANG_DEP");
            entity.Property(e => e.DamdangEmail)
                .HasMaxLength(500)
                .HasColumnName("DAMDANG_EMAIL");
            entity.Property(e => e.DamdangPos)
                .HasMaxLength(200)
                .HasColumnName("DAMDANG_POS");
            entity.Property(e => e.DamdangTel)
                .HasMaxLength(200)
                .HasColumnName("DAMDANG_TEL");
            entity.Property(e => e.Deleted)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasDefaultValue("N")
                .IsFixedLength();
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .HasColumnName("EMAIL");
            entity.Property(e => e.EndDate).HasColumnName("END_DATE");
            entity.Property(e => e.EndLoginDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("END_LOGIN_DATE");
            entity.Property(e => e.EndLoginIp)
                .HasMaxLength(30)
                .HasColumnName("END_LOGIN_IP");
            entity.Property(e => e.Facility1)
                .HasMaxLength(100)
                .HasColumnName("FACILITY1");
            entity.Property(e => e.Facility2)
                .HasMaxLength(100)
                .HasColumnName("FACILITY2");
            entity.Property(e => e.Facility3)
                .HasMaxLength(100)
                .HasColumnName("FACILITY3");
            entity.Property(e => e.Facility4)
                .HasMaxLength(100)
                .HasColumnName("FACILITY4");
            entity.Property(e => e.Facility5)
                .HasMaxLength(100)
                .HasColumnName("FACILITY5");
            entity.Property(e => e.Facility6)
                .HasMaxLength(100)
                .HasColumnName("FACILITY6");
            entity.Property(e => e.Facility7)
                .HasMaxLength(100)
                .HasColumnName("FACILITY7");
            entity.Property(e => e.Facility8)
                .HasMaxLength(100)
                .HasColumnName("FACILITY8");
            entity.Property(e => e.Facility9)
                .HasMaxLength(100)
                .HasColumnName("FACILITY9");
            entity.Property(e => e.FacilityMemo).HasColumnName("FACILITY_MEMO");
            entity.Property(e => e.FacilityUse)
                .HasMaxLength(1)
                .HasColumnName("FACILITY_USE");
            entity.Property(e => e.Fax)
                .HasMaxLength(100)
                .HasColumnName("FAX");
            entity.Property(e => e.Homepage)
                .HasMaxLength(200)
                .HasColumnName("HOMEPAGE");
            entity.Property(e => e.InterceptDate)
                .HasMaxLength(8)
                .HasColumnName("INTERCEPT_DATE");
            entity.Property(e => e.IpGubun)
                .HasMaxLength(1)
                .HasColumnName("IP_GUBUN");
            entity.Property(e => e.LeaveDate)
                .HasMaxLength(8)
                .HasColumnName("LEAVE_DATE");
            entity.Property(e => e.ListAllow)
                .HasMaxLength(1)
                .HasColumnName("LIST_ALLOW");
            entity.Property(e => e.Location).HasMaxLength(4);
            entity.Property(e => e.Mainemail)
                .HasMaxLength(100)
                .HasColumnName("MAINEMAIL");
            entity.Property(e => e.MarketingAgree)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.Memo).HasColumnName("MEMO");
            entity.Property(e => e.Mobile)
                .HasMaxLength(20)
                .HasColumnName("MOBILE");
            entity.Property(e => e.ModDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("MOD_DATE");
            entity.Property(e => e.PayUse)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasDefaultValue("N")
                .IsFixedLength();
            entity.Property(e => e.QnaUse)
                .HasMaxLength(1)
                .HasColumnName("QNA_USE");
            entity.Property(e => e.RegDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("REG_DATE");
            entity.Property(e => e.StaffId)
                .HasMaxLength(100)
                .HasColumnName("STAFF_ID");
            entity.Property(e => e.StartDate).HasColumnName("START_DATE");
            entity.Property(e => e.Tel)
                .HasMaxLength(100)
                .HasColumnName("TEL");
            entity.Property(e => e.Uid).HasColumnName("UID");
            entity.Property(e => e.UpCat)
                .HasMaxLength(1000)
                .IsUnicode(false);
            entity.Property(e => e.Upfile1)
                .HasMaxLength(100)
                .HasColumnName("UPFILE1");
            entity.Property(e => e.Upfile2)
                .HasMaxLength(100)
                .HasColumnName("UPFILE2");
            entity.Property(e => e.Upfile3)
                .HasMaxLength(100)
                .HasColumnName("UPFILE3");
            entity.Property(e => e.Upfile4)
                .HasMaxLength(100)
                .HasColumnName("UPFILE4");
            entity.Property(e => e.Upfile5)
                .HasMaxLength(100)
                .HasColumnName("UPFILE5");
            entity.Property(e => e.VisitCnt).HasColumnName("VISIT_CNT");
            entity.Property(e => e.Zipcode)
                .HasMaxLength(7)
                .HasColumnName("ZIPCODE");
            entity.Property(e => e.Zipcode1)
                .HasMaxLength(7)
                .HasColumnName("ZIPCODE1");
            entity.Property(e => e.Zipcode2)
                .HasMaxLength(7)
                .HasColumnName("ZIPCODE2");
            entity.Property(e => e.Zipcode3)
                .HasMaxLength(7)
                .HasColumnName("ZIPCODE3");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
