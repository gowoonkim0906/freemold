using Freemold.Modules.Models;
using Freemold.Modules.Models.EF;
using Freemold.Modules.Models.Table;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Freemold.Modules.Models.EntityConfigs
{
    public static class TbConfig
    {
        public static void Configure(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BakBanner>(entity =>
            {
                entity
                    .HasNoKey()
                    .ToTable("BAK_BANNER");

                entity.Property(e => e.BCode)
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasColumnName("bCode");
                entity.Property(e => e.BIdx)
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .HasColumnName("bIdx");
                entity.Property(e => e.BType)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasColumnName("bType");
                entity.Property(e => e.BakIdx).ValueGeneratedOnAdd();
                entity.Property(e => e.BannerImage).HasMaxLength(50);
                entity.Property(e => e.BannerLink)
                    .HasMaxLength(200)
                    .IsUnicode(false);
                entity.Property(e => e.BannerSubject).HasMaxLength(200);
                entity.Property(e => e.BannerType)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();
                entity.Property(e => e.BannerUnlimit)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();
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
                entity.Property(e => e.Deleted)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();
                entity.Property(e => e.EDate)
                    .HasColumnType("datetime")
                    .HasColumnName("eDate");
                entity.Property(e => e.IsUse)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasColumnName("isUse");
                entity.Property(e => e.MIdx).HasColumnName("mIdx");
                entity.Property(e => e.MType)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasColumnName("mType");
                entity.Property(e => e.RegDate).HasColumnType("datetime");
                entity.Property(e => e.RegId)
                    .HasMaxLength(50)
                    .HasColumnName("RegID");
                entity.Property(e => e.RegIp)
                    .HasMaxLength(23)
                    .IsUnicode(false)
                    .HasColumnName("RegIP");
                entity.Property(e => e.SDate)
                    .HasColumnType("datetime")
                    .HasColumnName("sDate");
                entity.Property(e => e.StartDateWithUse).HasColumnType("datetime");
            });

            modelBuilder.Entity<BakBannerKeyword>(entity =>
            {
                entity
                    .HasNoKey()
                    .ToTable("BAK_BANNER_KEYWORD");

                entity.Property(e => e.Amount)
                    .HasMaxLength(10)
                    .HasColumnName("AMOUNT");
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
                entity.Property(e => e.ChargeDate).HasColumnName("CHARGE_DATE");
                entity.Property(e => e.Deleted)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();
                entity.Property(e => e.Gubun)
                    .HasMaxLength(10)
                    .HasColumnName("GUBUN");
                entity.Property(e => e.KeyWord1)
                    .HasMaxLength(200)
                    .HasColumnName("KEY_WORD1");
                entity.Property(e => e.KeyWord2)
                    .HasMaxLength(200)
                    .HasColumnName("KEY_WORD2");
                entity.Property(e => e.KeyWord3)
                    .HasMaxLength(200)
                    .HasColumnName("KEY_WORD3");
                entity.Property(e => e.KeyWord4)
                    .HasMaxLength(200)
                    .HasColumnName("KEY_WORD4");
                entity.Property(e => e.MemberGubun)
                    .HasMaxLength(5)
                    .HasColumnName("MEMBER_GUBUN");
                entity.Property(e => e.MemberUid).HasColumnName("MEMBER_UID");
                entity.Property(e => e.Memo).HasColumnName("MEMO");
                entity.Property(e => e.RegDate).HasColumnType("datetime");
                entity.Property(e => e.RegId)
                    .HasMaxLength(50)
                    .HasColumnName("RegID");
                entity.Property(e => e.RegIp)
                    .HasMaxLength(23)
                    .IsUnicode(false)
                    .HasColumnName("RegIP");
                entity.Property(e => e.Uid).HasColumnName("UID");
                entity.Property(e => e.WordsEnd).HasColumnName("WORDS_END");
                entity.Property(e => e.WordsLink)
                    .HasMaxLength(200)
                    .HasColumnName("WORDS_LINK");
                entity.Property(e => e.WordsStart).HasColumnName("WORDS_START");
            });

            modelBuilder.Entity<BakBoardDatum>(entity =>
            {
                entity
                    .HasNoKey()
                    .ToTable("BAK_BOARD_DATA");

                entity.Property(e => e.APPR).HasMaxLength(1);
                entity.Property(e => e.BIdx).ValueGeneratedOnAdd();
                entity.Property(e => e.BOARD_CODE).HasMaxLength(20);
                entity.Property(e => e.BRegDate)
                    .HasDefaultValueSql("(getdate())")
                    .HasColumnType("datetime");
                entity.Property(e => e.BRegID).HasMaxLength(50);
                entity.Property(e => e.BRegIP)
                    .HasMaxLength(23)
                    .IsUnicode(false);
                entity.Property(e => e.BType).HasMaxLength(20);
                entity.Property(e => e.Cat).HasMaxLength(20);
                entity.Property(e => e.Deleted)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();
                entity.Property(e => e.FIRST_WORD).HasMaxLength(50);
                entity.Property(e => e.LINK1).HasMaxLength(200);
                entity.Property(e => e.LINK2).HasMaxLength(200);
                entity.Property(e => e.LIST_IMAGE_NAME).HasMaxLength(200);
                entity.Property(e => e.LIST_IMAGE_RENAME).HasMaxLength(200);
                entity.Property(e => e.MOD_DATE).HasColumnType("datetime");
                entity.Property(e => e.MOD_ID).HasMaxLength(200);
                entity.Property(e => e.NOTICE).HasMaxLength(5);
                entity.Property(e => e.N_DATE1).HasMaxLength(10);
                entity.Property(e => e.N_DATE2).HasMaxLength(10);
                entity.Property(e => e.REG_DATE).HasColumnType("smalldatetime");
                entity.Property(e => e.REG_EMAIL).HasMaxLength(100);
                entity.Property(e => e.REG_FILE_NAME).HasMaxLength(1000);
                entity.Property(e => e.REG_FILE_RENAME).HasMaxLength(1000);
                entity.Property(e => e.REG_HP).HasMaxLength(20);
                entity.Property(e => e.REG_ID).HasMaxLength(200);
                entity.Property(e => e.REG_IP).HasMaxLength(30);
                entity.Property(e => e.REG_NAME).HasMaxLength(30);
                entity.Property(e => e.REG_PW).HasMaxLength(100);
                entity.Property(e => e.REG_SUBJECT).HasMaxLength(100);
                entity.Property(e => e.Read_ID).HasMaxLength(50);
                entity.Property(e => e.SECRET).HasMaxLength(1);
                entity.Property(e => e.Tag0).HasMaxLength(10);
                entity.Property(e => e.Tag1).HasMaxLength(10);
                entity.Property(e => e.Tag2).HasMaxLength(10);
                entity.Property(e => e.UpCat).HasMaxLength(20);
                entity.Property(e => e.YOUTUBE_URL).HasMaxLength(200);
                entity.Property(e => e.dEmail).HasMaxLength(100);
                entity.Property(e => e.dName).HasMaxLength(30);
                entity.Property(e => e.dPhone).HasMaxLength(20);
                entity.Property(e => e.wEmail).HasMaxLength(100);
                entity.Property(e => e.wKakaoID).HasMaxLength(100);
                entity.Property(e => e.wName).HasMaxLength(30);
                entity.Property(e => e.wPhone).HasMaxLength(20);
                entity.Property(e => e.wType)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();
            });

            modelBuilder.Entity<BakBoardRegcontent>(entity =>
            {
                entity
                    .HasNoKey()
                    .ToTable("BAK_BOARD_REGCONTENT");

                entity.Property(e => e.RegContent).HasColumnName("REG_CONTENT");
                entity.Property(e => e.Uid).HasColumnName("UID");
            });

            modelBuilder.Entity<BakCategory>(entity =>
            {
                entity
                    .HasNoKey()
                    .ToTable("BAK_category");

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
                entity.Property(e => e.Btype)
                    .HasMaxLength(20)
                    .HasColumnName("BType");
                entity.Property(e => e.CapaUnit).HasMaxLength(10);
                entity.Property(e => e.Cate).HasColumnName("CATE");
                entity.Property(e => e.CateEng)
                    .HasMaxLength(50)
                    .HasColumnName("CATE_ENG");
                entity.Property(e => e.CateLink)
                    .HasMaxLength(50)
                    .HasColumnName("CATE_LINK");
                entity.Property(e => e.CateName)
                    .HasMaxLength(50)
                    .HasColumnName("CATE_NAME");
                entity.Property(e => e.Company)
                    .HasMaxLength(1)
                    .IsUnicode(false);
                entity.Property(e => e.Mold)
                    .HasMaxLength(1)
                    .IsUnicode(false);
                entity.Property(e => e.OemOdm)
                    .HasMaxLength(1)
                    .IsUnicode(false);
                entity.Property(e => e.PCate).HasColumnName("P_CATE");
                entity.Property(e => e.StandardMold)
                    .HasMaxLength(1)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<BakFavorite>(entity =>
            {
                entity
                    .HasNoKey()
                    .ToTable("BAK_FAVORITE");

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
                entity.Property(e => e.Deleted)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();
                entity.Property(e => e.FavoriteType)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();
                entity.Property(e => e.MType).HasColumnName("mType");
                entity.Property(e => e.MemberId)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("MemberID");
                entity.Property(e => e.PIdx).HasColumnName("pIdx");
                entity.Property(e => e.RegDate).HasColumnType("datetime");
                entity.Property(e => e.RegIp)
                    .HasMaxLength(23)
                    .IsUnicode(false)
                    .HasColumnName("RegIP");
            });

            modelBuilder.Entity<BakFavoriteUser>(entity =>
            {
                entity
                    .HasNoKey()
                    .ToTable("BAK_FAVORITE_USER");

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
                entity.Property(e => e.Deleted)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();
                entity.Property(e => e.FavoriteType)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();
                entity.Property(e => e.MType).HasColumnName("mType");
                entity.Property(e => e.MemberId)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("MemberID");
                entity.Property(e => e.PIdx).HasColumnName("pIdx");
                entity.Property(e => e.RegDate).HasColumnType("datetime");
                entity.Property(e => e.RegIp)
                    .HasMaxLength(23)
                    .IsUnicode(false)
                    .HasColumnName("RegIP");
            });

            modelBuilder.Entity<BakMember1>(entity =>
            {
                entity
                    .HasNoKey()
                    .ToTable("BAK_member1");

                entity.Property(e => e.ADDRESS1).HasMaxLength(200);
                entity.Property(e => e.ADDRESS11).HasMaxLength(200);
                entity.Property(e => e.ADDRESS12).HasMaxLength(200);
                entity.Property(e => e.ADDRESS2).HasMaxLength(200);
                entity.Property(e => e.ADDRESS21).HasMaxLength(200);
                entity.Property(e => e.ADDRESS22).HasMaxLength(200);
                entity.Property(e => e.ADDRESS31).HasMaxLength(200);
                entity.Property(e => e.ADDRESS32).HasMaxLength(200);
                entity.Property(e => e.ADDTIT1).HasMaxLength(20);
                entity.Property(e => e.ADDTIT2).HasMaxLength(20);
                entity.Property(e => e.ADDTIT3).HasMaxLength(20);
                entity.Property(e => e.ADMIN_ID).HasMaxLength(50);
                entity.Property(e => e.APPDATE).HasColumnType("smalldatetime");
                entity.Property(e => e.APPDATE_BEFORE).HasColumnType("smalldatetime");
                entity.Property(e => e.APPROVAL).HasMaxLength(1);
                entity.Property(e => e.APPROVAL_BEFORE).HasMaxLength(1);
                entity.Property(e => e.APPROVAL_VIEW).HasMaxLength(1);
                entity.Property(e => e.APPRUSER).HasMaxLength(100);
                entity.Property(e => e.APPRUSER_BEFORE).HasMaxLength(100);
                entity.Property(e => e.BANNER_FREE).HasMaxLength(5);
                entity.Property(e => e.BANNER_LOGIN).HasMaxLength(5);
                entity.Property(e => e.BANNER_OEM).HasMaxLength(5);
                entity.Property(e => e.BANNER_SUB_COMMUNITY).HasMaxLength(5);
                entity.Property(e => e.BANNER_SUB_COMPANY).HasMaxLength(5);
                entity.Property(e => e.BANNER_SUB_FREE).HasMaxLength(5);
                entity.Property(e => e.BANNER_SUB_LISTING).HasMaxLength(5);
                entity.Property(e => e.BANNER_SUB_NEWPROD).HasMaxLength(5);
                entity.Property(e => e.BANNER_SUB_SEARCH).HasMaxLength(5);
                entity.Property(e => e.BIdx).ValueGeneratedOnAdd();
                entity.Property(e => e.BRegDate)
                    .HasDefaultValueSql("(getdate())")
                    .HasColumnType("datetime");
                entity.Property(e => e.BRegID).HasMaxLength(50);
                entity.Property(e => e.BRegIP)
                    .HasMaxLength(23)
                    .IsUnicode(false);
                entity.Property(e => e.BRegType).HasMaxLength(50);
                entity.Property(e => e.BannerWish)
                    .HasMaxLength(100)
                    .IsUnicode(false);
                entity.Property(e => e.CATEGORY).HasMaxLength(2000);
                entity.Property(e => e.CATEGORY_ID1).HasMaxLength(20);
                entity.Property(e => e.CATEGORY_ID2).HasMaxLength(20);
                entity.Property(e => e.CATEGORY_ID3).HasMaxLength(20);
                entity.Property(e => e.CEO).HasMaxLength(30);
                entity.Property(e => e.CEO_ADD).HasMaxLength(20);
                entity.Property(e => e.CLASS).HasMaxLength(5);
                entity.Property(e => e.COMPANY_NAME).HasMaxLength(50);
                entity.Property(e => e.COMPANY_NAME_C).HasMaxLength(50);
                entity.Property(e => e.COMPANY_NAME_E).HasMaxLength(50);
                entity.Property(e => e.COMP_NO).HasMaxLength(15);
                entity.Property(e => e.CO_BANNER).HasMaxLength(100);
                entity.Property(e => e.CO_BANNER2).HasMaxLength(100);
                entity.Property(e => e.CO_BANNER3).HasMaxLength(100);
                entity.Property(e => e.CO_CI).HasMaxLength(100);
                entity.Property(e => e.CO_CI2).HasMaxLength(100);
                entity.Property(e => e.CO_CLIENT).HasMaxLength(500);
                entity.Property(e => e.CO_COUND1).HasMaxLength(4);
                entity.Property(e => e.CO_COUND2).HasMaxLength(2);
                entity.Property(e => e.CO_EXPORT).HasMaxLength(500);
                entity.Property(e => e.CO_FOREGROUND).HasMaxLength(100);
                entity.Property(e => e.CO_ID).HasMaxLength(15);
                entity.Property(e => e.CO_ITEM_USE).HasMaxLength(1);
                entity.Property(e => e.CO_LEFT_IMG).HasMaxLength(100);
                entity.Property(e => e.CO_MAP).HasMaxLength(100);
                entity.Property(e => e.CO_RELATION).HasMaxLength(500);
                entity.Property(e => e.CO_REMOVE).HasMaxLength(1);
                entity.Property(e => e.CO_REMOVE_DATE).HasColumnType("datetime");
                entity.Property(e => e.CO_STAFF).HasMaxLength(5);
                entity.Property(e => e.CO_TITLE1).HasMaxLength(30);
                entity.Property(e => e.CO_TITLE2).HasMaxLength(30);
                entity.Property(e => e.CO_TITLE3).HasMaxLength(30);
                entity.Property(e => e.CO_TOP_IMG1).HasMaxLength(100);
                entity.Property(e => e.CO_TOP_IMG2).HasMaxLength(100);
                entity.Property(e => e.CO_TOP_IMG3).HasMaxLength(100);
                entity.Property(e => e.CO_TYPE).HasMaxLength(1);
                entity.Property(e => e.CO_USE).HasMaxLength(1);
                entity.Property(e => e.CO_XY).HasMaxLength(100);
                entity.Property(e => e.Cat)
                    .HasMaxLength(1000)
                    .IsUnicode(false);
                entity.Property(e => e.ComLevel).HasDefaultValue((byte)1);
                entity.Property(e => e.ComType)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .IsFixedLength();
                entity.Property(e => e.DAMDANG).HasMaxLength(200);
                entity.Property(e => e.DAMDANG_DEP).HasMaxLength(200);
                entity.Property(e => e.DAMDANG_EMAIL).HasMaxLength(500);
                entity.Property(e => e.DAMDANG_POS).HasMaxLength(200);
                entity.Property(e => e.DAMDANG_TEL).HasMaxLength(200);
                entity.Property(e => e.Deleted)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasDefaultValue("N")
                    .IsFixedLength();
                entity.Property(e => e.EMAIL).HasMaxLength(100);
                entity.Property(e => e.END_LOGIN_DATE).HasColumnType("smalldatetime");
                entity.Property(e => e.END_LOGIN_IP).HasMaxLength(30);
                entity.Property(e => e.FACILITY1).HasMaxLength(100);
                entity.Property(e => e.FACILITY2).HasMaxLength(100);
                entity.Property(e => e.FACILITY3).HasMaxLength(100);
                entity.Property(e => e.FACILITY4).HasMaxLength(100);
                entity.Property(e => e.FACILITY5).HasMaxLength(100);
                entity.Property(e => e.FACILITY6).HasMaxLength(100);
                entity.Property(e => e.FACILITY7).HasMaxLength(100);
                entity.Property(e => e.FACILITY8).HasMaxLength(100);
                entity.Property(e => e.FACILITY9).HasMaxLength(100);
                entity.Property(e => e.FACILITY_USE).HasMaxLength(1);
                entity.Property(e => e.FAX).HasMaxLength(100);
                entity.Property(e => e.HOMEPAGE).HasMaxLength(200);
                entity.Property(e => e.INTERCEPT_DATE).HasMaxLength(8);
                entity.Property(e => e.IP_GUBUN).HasMaxLength(1);
                entity.Property(e => e.LEAVE_DATE).HasMaxLength(8);
                entity.Property(e => e.LIST_ALLOW).HasMaxLength(1);
                entity.Property(e => e.Location).HasMaxLength(4);
                entity.Property(e => e.MAINEMAIL).HasMaxLength(100);
                entity.Property(e => e.MOBILE).HasMaxLength(20);
                entity.Property(e => e.MOD_DATE).HasColumnType("smalldatetime");
                entity.Property(e => e.MarketingAgree)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();
                entity.Property(e => e.PayUse)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasDefaultValue("N")
                    .IsFixedLength();
                entity.Property(e => e.QNA_USE).HasMaxLength(1);
                entity.Property(e => e.REG_DATE).HasColumnType("smalldatetime");
                entity.Property(e => e.STAFF_ID).HasMaxLength(100);
                entity.Property(e => e.TEL).HasMaxLength(100);
                entity.Property(e => e.UPFILE1).HasMaxLength(100);
                entity.Property(e => e.UPFILE2).HasMaxLength(100);
                entity.Property(e => e.UPFILE3).HasMaxLength(100);
                entity.Property(e => e.UPFILE4).HasMaxLength(100);
                entity.Property(e => e.UPFILE5).HasMaxLength(100);
                entity.Property(e => e.UpCat)
                    .HasMaxLength(1000)
                    .IsUnicode(false);
                entity.Property(e => e.ZIPCODE).HasMaxLength(7);
                entity.Property(e => e.ZIPCODE1).HasMaxLength(7);
                entity.Property(e => e.ZIPCODE2).HasMaxLength(7);
                entity.Property(e => e.ZIPCODE3).HasMaxLength(7);
            });

            modelBuilder.Entity<BakMember4>(entity =>
            {
                entity
                    .HasNoKey()
                    .ToTable("BAK_member4");

                entity.Property(e => e.Address1)
                    .HasMaxLength(200)
                    .HasColumnName("ADDRESS1");
                entity.Property(e => e.Address2)
                    .HasMaxLength(200)
                    .HasColumnName("ADDRESS2");
                entity.Property(e => e.Approval)
                    .HasMaxLength(1)
                    .HasColumnName("APPROVAL");
                entity.Property(e => e.AttrId)
                    .HasMaxLength(50)
                    .HasColumnName("AttrID");
                entity.Property(e => e.Bidx)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("BIdx");
                entity.Property(e => e.Birthday)
                    .HasMaxLength(10)
                    .HasColumnName("BIRTHDAY");
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
                entity.Property(e => e.CompDept)
                    .HasMaxLength(50)
                    .HasColumnName("COMP_DEPT");
                entity.Property(e => e.CompName)
                    .HasMaxLength(50)
                    .HasColumnName("COMP_NAME");
                entity.Property(e => e.Country)
                    .HasMaxLength(50)
                    .HasColumnName("COUNTRY");
                entity.Property(e => e.Deleted)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();
                entity.Property(e => e.Email)
                    .HasMaxLength(100)
                    .HasColumnName("EMAIL");
                entity.Property(e => e.EmailAuth)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();
                entity.Property(e => e.EmailAuthDate).HasColumnType("smalldatetime");
                entity.Property(e => e.EndLoginDate)
                    .HasColumnType("smalldatetime")
                    .HasColumnName("END_LOGIN_DATE");
                entity.Property(e => e.EndLoginIp)
                    .HasMaxLength(30)
                    .HasColumnName("END_LOGIN_IP");
                entity.Property(e => e.FavoriteBusiness)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .IsFixedLength();
                entity.Property(e => e.Fax)
                    .HasMaxLength(20)
                    .HasColumnName("FAX");
                entity.Property(e => e.FirstName)
                    .HasMaxLength(50)
                    .HasColumnName("FIRST_NAME");
                entity.Property(e => e.Homepage)
                    .HasMaxLength(200)
                    .HasColumnName("HOMEPAGE");
                entity.Property(e => e.InterceptDate)
                    .HasMaxLength(8)
                    .HasColumnName("INTERCEPT_DATE");
                entity.Property(e => e.LeaveDate)
                    .HasMaxLength(8)
                    .HasColumnName("LEAVE_DATE");
                entity.Property(e => e.Lunar)
                    .HasMaxLength(1)
                    .HasColumnName("LUNAR");
                entity.Property(e => e.Mailing)
                    .HasMaxLength(1)
                    .HasColumnName("MAILING");
                entity.Property(e => e.MarketingAgree)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();
                entity.Property(e => e.MemberClass)
                    .HasMaxLength(50)
                    .HasColumnName("MEMBER_CLASS");
                entity.Property(e => e.MemberLevel).HasColumnName("MEMBER_LEVEL");
                entity.Property(e => e.MemberName)
                    .HasMaxLength(20)
                    .HasColumnName("MEMBER_NAME");
                entity.Property(e => e.MemberOpen)
                    .HasMaxLength(1)
                    .HasColumnName("MEMBER_OPEN");
                entity.Property(e => e.MemberOpenDate)
                    .HasColumnType("smalldatetime")
                    .HasColumnName("MEMBER_OPEN_DATE");
                entity.Property(e => e.MemberType)
                    .HasMaxLength(1)
                    .HasColumnName("MEMBER_TYPE");
                entity.Property(e => e.Memo).HasColumnName("MEMO");
                entity.Property(e => e.Mobile)
                    .HasMaxLength(20)
                    .HasColumnName("MOBILE");
                entity.Property(e => e.MobileAuth)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();
                entity.Property(e => e.MobileAuthDate).HasColumnType("smalldatetime");
                entity.Property(e => e.ModDate)
                    .HasColumnType("smalldatetime")
                    .HasColumnName("MOD_DATE");
                entity.Property(e => e.NickName)
                    .HasMaxLength(20)
                    .HasColumnName("NICK_NAME");
                entity.Property(e => e.Point).HasColumnName("POINT");
                entity.Property(e => e.RegDate)
                    .HasColumnType("smalldatetime")
                    .HasColumnName("REG_DATE");
                entity.Property(e => e.RegIp)
                    .HasMaxLength(30)
                    .HasColumnName("REG_IP");
                entity.Property(e => e.Sex)
                    .HasMaxLength(1)
                    .HasColumnName("SEX");
                entity.Property(e => e.Sms)
                    .HasMaxLength(1)
                    .HasColumnName("SMS");
                entity.Property(e => e.Tel)
                    .HasMaxLength(20)
                    .HasColumnName("TEL");
                entity.Property(e => e.Uid).HasColumnName("UID");
                entity.Property(e => e.VisitCnt).HasColumnName("VISIT_CNT");
                entity.Property(e => e.Zipcode)
                    .HasMaxLength(7)
                    .HasColumnName("ZIPCODE");
            });

            modelBuilder.Entity<BakMemberLogin>(entity =>
            {
                entity
                    .HasNoKey()
                    .ToTable("BAK_member_login");

                entity.Property(e => e.AdminYn)
                    .HasMaxLength(1)
                    .HasColumnName("ADMIN_YN");
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
                entity.Property(e => e.ChkPassword)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();
                entity.Property(e => e.ChkPasswordDate).HasColumnType("datetime");
                entity.Property(e => e.HomeApproval)
                    .HasMaxLength(1)
                    .HasColumnName("HOME_APPROVAL");
                entity.Property(e => e.HomeColor)
                    .HasMaxLength(5)
                    .HasColumnName("HOME_COLOR");
                entity.Property(e => e.HomeLayout)
                    .HasMaxLength(6)
                    .HasColumnName("HOME_LAYOUT");
                entity.Property(e => e.HomeLevel)
                    .HasMaxLength(1)
                    .HasColumnName("HOME_LEVEL");
                entity.Property(e => e.HomeType)
                    .HasMaxLength(1)
                    .HasColumnName("HOME_TYPE");
                entity.Property(e => e.HomeUrl)
                    .HasMaxLength(20)
                    .HasColumnName("HOME_URL");
                entity.Property(e => e.LastDate).HasColumnType("datetime");
                entity.Property(e => e.MemberApproval)
                    .HasMaxLength(1)
                    .HasColumnName("MEMBER_APPROVAL");
                entity.Property(e => e.MemberGubun)
                    .HasMaxLength(1)
                    .HasColumnName("MEMBER_GUBUN");
                entity.Property(e => e.MemberId)
                    .HasMaxLength(50)
                    .HasColumnName("MEMBER_ID");
                entity.Property(e => e.MemberPw)
                    .HasMaxLength(200)
                    .HasColumnName("MEMBER_PW");
                entity.Property(e => e.MemberUid).HasColumnName("MEMBER_UID");
                entity.Property(e => e.TmpData)
                    .HasMaxLength(100)
                    .IsUnicode(false);
                entity.Property(e => e.Uid).HasColumnName("UID");
            });

            modelBuilder.Entity<BakNaverimgUpload>(entity =>
            {
                entity
                    .HasNoKey()
                    .ToTable("BAK_NAVERIMG_UPLOAD");

                entity.Property(e => e.Filename).HasMaxLength(100);
                entity.Property(e => e.HasError)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("hasError");
                entity.Property(e => e.Idx).ValueGeneratedOnAdd();
                entity.Property(e => e.RegDate)
                    .HasDefaultValueSql("(getdate())")
                    .HasColumnType("datetime");
                entity.Property(e => e.RegId)
                    .HasMaxLength(50)
                    .HasColumnName("RegID");
                entity.Property(e => e.RegIp)
                    .HasMaxLength(23)
                    .IsUnicode(false)
                    .HasColumnName("RegIP");
            });

            modelBuilder.Entity<BakProductList>(entity =>
            {
                entity
                    .ToTable("BAK_product_list");

                entity.HasKey(e => e.BIdx);

                entity.Property(e => e.BIdx).ValueGeneratedOnAdd();
                entity.Property(e => e.BRegDate)
                    .HasDefaultValueSql("(getdate())")
                    .HasColumnType("datetime");
                entity.Property(e => e.BRegID).HasMaxLength(50);
                entity.Property(e => e.BRegIP)
                    .HasMaxLength(23)
                    .IsUnicode(false);
                entity.Property(e => e.BRegType).HasMaxLength(50);
                entity.Property(e => e.CO_ID).HasMaxLength(20);
                entity.Property(e => e.Cat)
                    .HasMaxLength(100)
                    .IsUnicode(false);
                entity.Property(e => e.Deleted)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();
                entity.Property(e => e.MEMBER_GUBUN).HasMaxLength(1);
                entity.Property(e => e.P_APPDATE).HasColumnType("smalldatetime");
                entity.Property(e => e.P_APPDATE_BEFORE).HasColumnType("smalldatetime");
                entity.Property(e => e.P_APPROVAL).HasMaxLength(1);
                entity.Property(e => e.P_APPROVAL_BEFORE).HasMaxLength(1);
                entity.Property(e => e.P_APPRUSER).HasMaxLength(100);
                entity.Property(e => e.P_APPRUSER_BEFORE).HasMaxLength(100);
                entity.Property(e => e.P_CAPACITY).HasMaxLength(30);
                entity.Property(e => e.P_CAP_UNIT).HasMaxLength(10);
                entity.Property(e => e.P_CATEGORY).HasMaxLength(100);
                entity.Property(e => e.P_CODE).HasMaxLength(100);
                entity.Property(e => e.P_HOT).HasMaxLength(1);
                entity.Property(e => e.P_IMG1).HasMaxLength(100);
                entity.Property(e => e.P_IMG2).HasMaxLength(100);
                entity.Property(e => e.P_IMG3).HasMaxLength(100);
                entity.Property(e => e.P_IMG4).HasMaxLength(100);
                entity.Property(e => e.P_IMG5).HasMaxLength(100);
                entity.Property(e => e.P_IMG6).HasMaxLength(100);
                entity.Property(e => e.P_MODDATE).HasColumnType("smalldatetime");
                entity.Property(e => e.P_MOQ_DEAL)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();
                entity.Property(e => e.P_NAME).HasMaxLength(100);
                entity.Property(e => e.P_NAME2).HasMaxLength(100);
                entity.Property(e => e.P_NEW).HasMaxLength(1);
                entity.Property(e => e.P_ORIGIN).HasMaxLength(50);
                entity.Property(e => e.P_QUALITY).HasMaxLength(100);
                entity.Property(e => e.P_REGDATE).HasColumnType("smalldatetime");
                entity.Property(e => e.P_SIZE).HasMaxLength(100);
                entity.Property(e => e.P_USE).HasMaxLength(1);
                entity.Property(e => e.P_USE_ST)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();
                entity.Property(e => e.ProdType)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();
                entity.Property(e => e.Tag0).HasMaxLength(20);
                entity.Property(e => e.Tag1).HasMaxLength(20);
                entity.Property(e => e.Tag2).HasMaxLength(20);
                entity.Property(e => e.Tag3).HasMaxLength(20);
                entity.Property(e => e.Tag4).HasMaxLength(20);
                entity.Property(e => e.Tag5).HasMaxLength(20);
                entity.Property(e => e.Tag6).HasMaxLength(20);
                entity.Property(e => e.Tag7).HasMaxLength(20);
                entity.Property(e => e.Tag8).HasMaxLength(20);
                entity.Property(e => e.Tag9).HasMaxLength(20);
                entity.Property(e => e.UpCat)
                    .HasMaxLength(100)
                    .IsUnicode(false);
                entity.Property(e => e.isMove)
                    .HasMaxLength(1)
                    .IsFixedLength();
                entity.Property(e => e.isPCR)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();
                entity.Property(e => e.isRefill)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();
                entity.Property(e => e.it_id).HasMaxLength(20);

            });

            modelBuilder.Entity<BakProductUser>(entity =>
            {
                entity
                    .HasNoKey()
                    .ToTable("BAK_PRODUCT_USER");

                entity.Property(e => e.Approval)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();
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
                entity.Property(e => e.Category).HasMaxLength(10);
                entity.Property(e => e.Deleted)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();
                entity.Property(e => e.MemberId)
                    .HasMaxLength(50)
                    .HasColumnName("Member_ID");
                entity.Property(e => e.PImg1)
                    .HasMaxLength(100)
                    .HasColumnName("P_IMG1");
                entity.Property(e => e.PImg2)
                    .HasMaxLength(100)
                    .HasColumnName("P_IMG2");
                entity.Property(e => e.PImg3)
                    .HasMaxLength(100)
                    .HasColumnName("P_IMG3");
                entity.Property(e => e.PImg4)
                    .HasMaxLength(100)
                    .HasColumnName("P_IMG4");
                entity.Property(e => e.PImg5)
                    .HasMaxLength(100)
                    .HasColumnName("P_IMG5");
                entity.Property(e => e.PImg6)
                    .HasMaxLength(100)
                    .HasColumnName("P_IMG6");
                entity.Property(e => e.ProdName).HasMaxLength(100);
                entity.Property(e => e.RegDate).HasColumnType("datetime");
                entity.Property(e => e.RegIp)
                    .HasMaxLength(23)
                    .IsUnicode(false)
                    .HasColumnName("RegIP");
                entity.Property(e => e.Status)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();
            });

            modelBuilder.Entity<BakQna>(entity =>
            {
                entity
                    .HasNoKey()
                    .ToTable("BAK_qna");

                entity.Property(e => e.Appr)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasColumnName("APPR");
                entity.Property(e => e.Bidx)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("BIdx");
                entity.Property(e => e.BregDate)
                    .HasMaxLength(10)
                    .HasDefaultValueSql("(getdate())")
                    .IsFixedLength()
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
                entity.Property(e => e.ComContact)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();
                entity.Property(e => e.CompName)
                    .HasMaxLength(50)
                    .HasColumnName("COMP_NAME");
                entity.Property(e => e.CompUid).HasColumnName("COMP_UID");
                entity.Property(e => e.DamdangName)
                    .HasMaxLength(20)
                    .HasColumnName("DAMDANG_NAME");
                entity.Property(e => e.DamdangTel)
                    .HasMaxLength(20)
                    .HasColumnName("DAMDANG_TEL");
                entity.Property(e => e.Deleted)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();
                entity.Property(e => e.Depth).HasColumnName("DEPTH");
                entity.Property(e => e.DlvCond)
                    .HasMaxLength(20)
                    .HasColumnName("DLV_COND");
                entity.Property(e => e.DlvDate)
                    .HasMaxLength(10)
                    .HasColumnName("DLV_DATE");
                entity.Property(e => e.DlvWay)
                    .HasMaxLength(20)
                    .HasColumnName("DLV_WAY");
                entity.Property(e => e.Email)
                    .HasMaxLength(100)
                    .HasColumnName("EMAIL");
                entity.Property(e => e.EstiRequest)
                    .HasMaxLength(1)
                    .HasColumnName("ESTI_REQUEST");
                entity.Property(e => e.Grp).HasColumnName("GRP");
                entity.Property(e => e.Gubun)
                    .HasMaxLength(5)
                    .HasColumnName("GUBUN");
                entity.Property(e => e.Hits).HasColumnName("HITS");
                entity.Property(e => e.MemberGubun)
                    .HasMaxLength(1)
                    .HasColumnName("MEMBER_GUBUN");
                entity.Property(e => e.MemberName)
                    .HasMaxLength(50)
                    .HasColumnName("MEMBER_NAME");
                entity.Property(e => e.MemberUid).HasColumnName("MEMBER_UID");
                entity.Property(e => e.Memo).HasColumnName("MEMO");
                entity.Property(e => e.NameCard).HasMaxLength(100);
                entity.Property(e => e.PCode)
                    .HasMaxLength(30)
                    .HasColumnName("P_CODE");
                entity.Property(e => e.PIdx).HasColumnName("pIdx");
                entity.Property(e => e.PQty).HasColumnName("P_QTY");
                entity.Property(e => e.PayJan)
                    .HasMaxLength(5)
                    .HasColumnName("PAY_JAN");
                entity.Property(e => e.PaySunsu)
                    .HasMaxLength(5)
                    .HasColumnName("PAY_SUNSU");
                entity.Property(e => e.Phone)
                    .HasMaxLength(30)
                    .HasColumnName("PHONE");
                entity.Property(e => e.QnaUid).HasColumnName("QNA_UID");
                entity.Property(e => e.ReadId)
                    .HasMaxLength(100)
                    .HasColumnName("READ_ID");
                entity.Property(e => e.RecvAddr1).HasMaxLength(100);
                entity.Property(e => e.RecvAddr2).HasMaxLength(50);
                entity.Property(e => e.RecvZip)
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .IsFixedLength();
                entity.Property(e => e.Regdate)
                    .HasColumnType("datetime")
                    .HasColumnName("REGDATE");
                entity.Property(e => e.Reply)
                    .HasMaxLength(1)
                    .HasColumnName("REPLY");
                entity.Property(e => e.SampleFee)
                    .HasMaxLength(1)
                    .HasColumnName("SAMPLE_FEE");
                entity.Property(e => e.SampleYn)
                    .HasMaxLength(1)
                    .HasColumnName("SAMPLE_YN");
                entity.Property(e => e.Smssend)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasColumnName("SMSsend");
                entity.Property(e => e.Upfile)
                    .HasMaxLength(100)
                    .HasColumnName("UPFILE");
                entity.Property(e => e.Upfile2)
                    .HasMaxLength(100)
                    .HasColumnName("UPFILE2");
                entity.Property(e => e.Upfile3)
                    .HasMaxLength(100)
                    .HasColumnName("UPFILE3");
                entity.Property(e => e.Upfilename)
                    .HasMaxLength(100)
                    .HasColumnName("UPFILENAME");
                entity.Property(e => e.Upfilename2)
                    .HasMaxLength(100)
                    .HasColumnName("UPFILENAME2");
                entity.Property(e => e.Upfilename3)
                    .HasMaxLength(100)
                    .HasColumnName("UPFILENAME3");
                entity.Property(e => e.WriterRead)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();
            });

            modelBuilder.Entity<Category>(entity =>
            {
                entity
                    .HasNoKey()
                    .ToTable("_CATEGORY");

                entity.Property(e => e.CapaUnit).HasMaxLength(10);
                entity.Property(e => e.Cate).HasColumnName("CATE");
                entity.Property(e => e.CateEng)
                    .HasMaxLength(50)
                    .HasColumnName("CATE_ENG");
                entity.Property(e => e.CateLink)
                    .HasMaxLength(50)
                    .HasColumnName("CATE_LINK");
                entity.Property(e => e.CateName)
                    .HasMaxLength(50)
                    .HasColumnName("CATE_NAME");
                entity.Property(e => e.Company)
                    .HasMaxLength(1)
                    .IsUnicode(false);
                entity.Property(e => e.Mold)
                    .HasMaxLength(1)
                    .IsUnicode(false);
                entity.Property(e => e.OemOdm)
                    .HasMaxLength(1)
                    .IsUnicode(false);
                entity.Property(e => e.PCate).HasColumnName("P_CATE");
                entity.Property(e => e.StandardMold)
                    .HasMaxLength(1)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Category1>(entity =>
            {
                entity
                    .HasNoKey()
                    .ToTable("category");

                entity.HasIndex(e => e.Cate, "IX_category_CATE").HasFillFactor(90);

                entity.HasIndex(e => e.PCate, "IX_category_P_CATE").HasFillFactor(90);

                entity.HasIndex(e => e.SubSeq, "IX_category_SubSeq").HasFillFactor(90);

                entity.Property(e => e.CapaUnit)
                    .HasMaxLength(10)
                    .HasDefaultValue("");
                entity.Property(e => e.Cate).HasColumnName("CATE");
                entity.Property(e => e.CateEng)
                    .HasMaxLength(50)
                    .HasDefaultValue("")
                    .HasColumnName("CATE_ENG");
                entity.Property(e => e.CateLink)
                    .HasMaxLength(50)
                    .HasColumnName("CATE_LINK");
                entity.Property(e => e.CateName)
                    .HasMaxLength(50)
                    .HasColumnName("CATE_NAME");
                entity.Property(e => e.Company)
                    .HasMaxLength(1)
                    .IsUnicode(false);
                entity.Property(e => e.Mold)
                    .HasMaxLength(1)
                    .IsUnicode(false);
                entity.Property(e => e.OemOdm)
                    .HasMaxLength(1)
                    .IsUnicode(false);
                entity.Property(e => e.PCate).HasColumnName("P_CATE");
                entity.Property(e => e.StandardMold)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasDefaultValue("N");
            });

            modelBuilder.Entity<CategoryOri>(entity =>
            {
                entity
                    .HasNoKey()
                    .ToTable("CATEGORY_ORI");

                entity.Property(e => e.CapaUnit).HasMaxLength(10);
                entity.Property(e => e.Cate).HasColumnName("CATE");
                entity.Property(e => e.CateEng)
                    .HasMaxLength(50)
                    .HasColumnName("CATE_ENG");
                entity.Property(e => e.CateLink)
                    .HasMaxLength(50)
                    .HasColumnName("CATE_LINK");
                entity.Property(e => e.CateName)
                    .HasMaxLength(50)
                    .HasColumnName("CATE_NAME");
                entity.Property(e => e.Company)
                    .HasMaxLength(1)
                    .IsUnicode(false);
                entity.Property(e => e.Mold)
                    .HasMaxLength(1)
                    .IsUnicode(false);
                entity.Property(e => e.OemOdm)
                    .HasMaxLength(1)
                    .IsUnicode(false);
                entity.Property(e => e.PCate).HasColumnName("P_CATE");
                entity.Property(e => e.StandardMold)
                    .HasMaxLength(1)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Httpreferer>(entity =>
            {
                entity
                    .HasNoKey()
                    .ToTable("_HTTPREFERER");

                entity.Property(e => e.HttpReferer)
                    .HasMaxLength(1000)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Member1>(entity =>
            {
                entity.HasKey(e => e.UID).HasFillFactor(90);

                entity.HasIndex(e => e.ADDRESS1, "IX_member1_ADDRESS1").HasFillFactor(90);

                entity.HasIndex(e => e.APPROVAL, "IX_member1_APPROVAL")
                    .IsDescending()
                    .HasFillFactor(90);

                entity.HasIndex(e => e.APPROVAL_VIEW, "IX_member1_APPROVAL_VIEW")
                    .IsDescending()
                    .HasFillFactor(90);

                entity.HasIndex(e => e.COMPANY_NAME, "IX_member1_COMPANY_NAME").HasFillFactor(90);

                entity.HasIndex(e => e.Deleted, "IX_member1_Deleted").HasFillFactor(90);

                entity.HasIndex(e => e.END_DATE, "IX_member1_END_DATE")
                    .IsDescending()
                    .HasFillFactor(90);

                entity.HasIndex(e => e.Location, "IX_member1_Location").HasFillFactor(90);

                entity.HasIndex(e => e.START_DATE, "IX_member1_START_DATE")
                    .IsDescending()
                    .HasFillFactor(90);

                entity.Property(e => e.ADDRESS1).HasMaxLength(200);
                entity.Property(e => e.ADDRESS11).HasMaxLength(200);
                entity.Property(e => e.ADDRESS12).HasMaxLength(200);
                entity.Property(e => e.ADDRESS2).HasMaxLength(200);
                entity.Property(e => e.ADDRESS21).HasMaxLength(200);
                entity.Property(e => e.ADDRESS22).HasMaxLength(200);
                entity.Property(e => e.ADDRESS31).HasMaxLength(200);
                entity.Property(e => e.ADDRESS32).HasMaxLength(200);
                entity.Property(e => e.ADDTIT1).HasMaxLength(20);
                entity.Property(e => e.ADDTIT2).HasMaxLength(20);
                entity.Property(e => e.ADDTIT3).HasMaxLength(20);
                entity.Property(e => e.ADMIN_ID).HasMaxLength(50);
                entity.Property(e => e.APPDATE).HasColumnType("smalldatetime");
                entity.Property(e => e.APPDATE_BEFORE).HasColumnType("smalldatetime");
                entity.Property(e => e.APPROVAL).HasMaxLength(1);
                entity.Property(e => e.APPROVAL_BEFORE).HasMaxLength(1);
                entity.Property(e => e.APPROVAL_VIEW).HasMaxLength(1);
                entity.Property(e => e.APPRUSER).HasMaxLength(100);
                entity.Property(e => e.APPRUSER_BEFORE).HasMaxLength(100);
                entity.Property(e => e.BANNER_FREE).HasMaxLength(5);
                entity.Property(e => e.BANNER_LOGIN).HasMaxLength(5);
                entity.Property(e => e.BANNER_OEM).HasMaxLength(5);
                entity.Property(e => e.BANNER_SUB_COMMUNITY).HasMaxLength(5);
                entity.Property(e => e.BANNER_SUB_COMPANY).HasMaxLength(5);
                entity.Property(e => e.BANNER_SUB_FREE).HasMaxLength(5);
                entity.Property(e => e.BANNER_SUB_LISTING).HasMaxLength(5);
                entity.Property(e => e.BANNER_SUB_NEWPROD).HasMaxLength(5);
                entity.Property(e => e.BANNER_SUB_SEARCH).HasMaxLength(5);
                entity.Property(e => e.BannerWish)
                    .HasMaxLength(100)
                    .IsUnicode(false);
                entity.Property(e => e.CATEGORY).HasMaxLength(2000);
                entity.Property(e => e.CATEGORY_ID1).HasMaxLength(20);
                entity.Property(e => e.CATEGORY_ID2).HasMaxLength(20);
                entity.Property(e => e.CATEGORY_ID3).HasMaxLength(20);
                entity.Property(e => e.CEO).HasMaxLength(30);
                entity.Property(e => e.CEO_ADD).HasMaxLength(20);
                entity.Property(e => e.CLASS).HasMaxLength(5);
                entity.Property(e => e.COMPANY_NAME).HasMaxLength(50);
                entity.Property(e => e.COMPANY_NAME_C).HasMaxLength(50);
                entity.Property(e => e.COMPANY_NAME_E).HasMaxLength(50);
                entity.Property(e => e.COMP_NO).HasMaxLength(15);
                entity.Property(e => e.CO_BANNER).HasMaxLength(100);
                entity.Property(e => e.CO_BANNER2).HasMaxLength(100);
                entity.Property(e => e.CO_BANNER3).HasMaxLength(100);
                entity.Property(e => e.CO_CI).HasMaxLength(100);
                entity.Property(e => e.CO_CI2).HasMaxLength(100);
                entity.Property(e => e.CO_CLIENT).HasMaxLength(500);
                entity.Property(e => e.CO_COUND1).HasMaxLength(4);
                entity.Property(e => e.CO_COUND2).HasMaxLength(2);
                entity.Property(e => e.CO_EXPORT).HasMaxLength(500);
                entity.Property(e => e.CO_FOREGROUND).HasMaxLength(100);
                entity.Property(e => e.CO_ID).HasMaxLength(15);
                entity.Property(e => e.CO_ITEM_USE).HasMaxLength(1);
                entity.Property(e => e.CO_LEFT_IMG).HasMaxLength(100);
                entity.Property(e => e.CO_MAP).HasMaxLength(100);
                entity.Property(e => e.CO_RELATION).HasMaxLength(500);
                entity.Property(e => e.CO_REMOVE).HasMaxLength(1);
                entity.Property(e => e.CO_REMOVE_DATE).HasColumnType("datetime");
                entity.Property(e => e.CO_STAFF).HasMaxLength(5);
                entity.Property(e => e.CO_TITLE1)
                    .HasMaxLength(30)
                    .HasDefaultValue("회사소개");
                entity.Property(e => e.CO_TITLE2)
                    .HasMaxLength(30)
                    .HasDefaultValue("회사특징");
                entity.Property(e => e.CO_TITLE3)
                    .HasMaxLength(30)
                    .HasDefaultValue("회사전경");
                entity.Property(e => e.CO_TOP_IMG1).HasMaxLength(100);
                entity.Property(e => e.CO_TOP_IMG2).HasMaxLength(100);
                entity.Property(e => e.CO_TOP_IMG3).HasMaxLength(100);
                entity.Property(e => e.CO_TYPE).HasMaxLength(1);
                entity.Property(e => e.CO_USE).HasMaxLength(1);
                entity.Property(e => e.CO_XY).HasMaxLength(100);
                entity.Property(e => e.Cat)
                    .HasMaxLength(1000)
                    .IsUnicode(false)
                    .HasDefaultValue("");
                entity.Property(e => e.ComLevel).HasDefaultValue((byte)1);
                entity.Property(e => e.ComType)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasDefaultValue("N")
                    .IsFixedLength();
                entity.Property(e => e.DAMDANG).HasMaxLength(200);
                entity.Property(e => e.DAMDANG_DEP).HasMaxLength(200);
                entity.Property(e => e.DAMDANG_EMAIL).HasMaxLength(500);
                entity.Property(e => e.DAMDANG_POS).HasMaxLength(200);
                entity.Property(e => e.DAMDANG_TEL).HasMaxLength(200);
                entity.Property(e => e.Deleted)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasDefaultValue("N")
                    .IsFixedLength();
                entity.Property(e => e.EMAIL).HasMaxLength(100);
                entity.Property(e => e.END_LOGIN_DATE).HasColumnType("smalldatetime");
                entity.Property(e => e.END_LOGIN_IP).HasMaxLength(30);
                entity.Property(e => e.FACILITY1).HasMaxLength(100);
                entity.Property(e => e.FACILITY2).HasMaxLength(100);
                entity.Property(e => e.FACILITY3).HasMaxLength(100);
                entity.Property(e => e.FACILITY4).HasMaxLength(100);
                entity.Property(e => e.FACILITY5).HasMaxLength(100);
                entity.Property(e => e.FACILITY6).HasMaxLength(100);
                entity.Property(e => e.FACILITY7).HasMaxLength(100);
                entity.Property(e => e.FACILITY8).HasMaxLength(100);
                entity.Property(e => e.FACILITY9).HasMaxLength(100);
                entity.Property(e => e.FACILITY_USE).HasMaxLength(1);
                entity.Property(e => e.FAX).HasMaxLength(100);
                entity.Property(e => e.HOMEPAGE).HasMaxLength(200);
                entity.Property(e => e.INTERCEPT_DATE).HasMaxLength(8);
                entity.Property(e => e.IP_GUBUN).HasMaxLength(1);
                entity.Property(e => e.LEAVE_DATE).HasMaxLength(8);
                entity.Property(e => e.LIST_ALLOW).HasMaxLength(1);
                entity.Property(e => e.Location).HasMaxLength(4);
                entity.Property(e => e.MAINEMAIL).HasMaxLength(100);
                entity.Property(e => e.MOBILE).HasMaxLength(20);
                entity.Property(e => e.MOD_DATE).HasColumnType("smalldatetime");
                entity.Property(e => e.MarketingAgree)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasDefaultValue("N")
                    .IsFixedLength();
                entity.Property(e => e.PayUse)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasDefaultValue("N")
                    .IsFixedLength();
                entity.Property(e => e.QNA_USE).HasMaxLength(1);
                entity.Property(e => e.REG_DATE).HasColumnType("smalldatetime");
                entity.Property(e => e.STAFF_ID).HasMaxLength(100);
                entity.Property(e => e.TEL).HasMaxLength(100);
                entity.Property(e => e.UPFILE1).HasMaxLength(100);
                entity.Property(e => e.UPFILE2).HasMaxLength(100);
                entity.Property(e => e.UPFILE3).HasMaxLength(100);
                entity.Property(e => e.UPFILE4).HasMaxLength(100);
                entity.Property(e => e.UPFILE5).HasMaxLength(100);
                entity.Property(e => e.UpCat)
                    .HasMaxLength(1000)
                    .IsUnicode(false)
                    .HasDefaultValue("");
                entity.Property(e => e.ZIPCODE).HasMaxLength(7);
                entity.Property(e => e.ZIPCODE1).HasMaxLength(7);
                entity.Property(e => e.ZIPCODE2).HasMaxLength(7);
                entity.Property(e => e.ZIPCODE3).HasMaxLength(7);
            });

            modelBuilder.Entity<Member4>(entity =>
            {
                entity.HasKey(e => e.Uid).HasFillFactor(90);

                entity.ToTable("member4");

                entity.HasIndex(e => e.Birthday, "IX_member4_BIRTHDAY")
                    .IsDescending()
                    .HasFillFactor(90);

                entity.HasIndex(e => e.Deleted, "IX_member4_Deleted").HasFillFactor(90);

                entity.HasIndex(e => e.FavoriteBusiness, "IX_member4_FavoriteBusiness").HasFillFactor(90);

                entity.HasIndex(e => e.LeaveDate, "IX_member4_LEAVE_DATE")
                    .IsDescending()
                    .HasFillFactor(90);

                entity.HasIndex(e => e.RegDate, "IX_member4_REG_DATE")
                    .IsDescending()
                    .HasFillFactor(90);

                entity.HasIndex(e => e.Sex, "IX_member4_SEX").HasFillFactor(90);

                entity.Property(e => e.Uid).HasColumnName("UID");
                entity.Property(e => e.Address1)
                    .HasMaxLength(200)
                    .HasColumnName("ADDRESS1");
                entity.Property(e => e.Address2)
                    .HasMaxLength(200)
                    .HasColumnName("ADDRESS2");
                entity.Property(e => e.Approval)
                    .HasMaxLength(1)
                    .HasColumnName("APPROVAL");
                entity.Property(e => e.AttrId)
                    .HasMaxLength(50)
                    .HasColumnName("AttrID");
                entity.Property(e => e.Birthday)
                    .HasMaxLength(10)
                    .HasColumnName("BIRTHDAY");
                entity.Property(e => e.CompDept)
                    .HasMaxLength(50)
                    .HasColumnName("COMP_DEPT");
                entity.Property(e => e.CompName)
                    .HasMaxLength(50)
                    .HasColumnName("COMP_NAME");
                entity.Property(e => e.Country)
                    .HasMaxLength(50)
                    .HasColumnName("COUNTRY");
                entity.Property(e => e.Deleted)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasDefaultValue("N")
                    .IsFixedLength();
                entity.Property(e => e.Email)
                    .HasMaxLength(100)
                    .HasColumnName("EMAIL");
                entity.Property(e => e.EmailAuth)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasDefaultValue("N")
                    .IsFixedLength();
                entity.Property(e => e.EmailAuthDate).HasColumnType("smalldatetime");
                entity.Property(e => e.EndLoginDate)
                    .HasColumnType("smalldatetime")
                    .HasColumnName("END_LOGIN_DATE");
                entity.Property(e => e.EndLoginIp)
                    .HasMaxLength(30)
                    .HasColumnName("END_LOGIN_IP");
                entity.Property(e => e.FavoriteBusiness)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasDefaultValue("000000")
                    .IsFixedLength();
                entity.Property(e => e.Fax)
                    .HasMaxLength(20)
                    .HasColumnName("FAX");
                entity.Property(e => e.FirstName)
                    .HasMaxLength(50)
                    .HasColumnName("FIRST_NAME");
                entity.Property(e => e.Homepage)
                    .HasMaxLength(200)
                    .HasColumnName("HOMEPAGE");
                entity.Property(e => e.InterceptDate)
                    .HasMaxLength(8)
                    .HasColumnName("INTERCEPT_DATE");
                entity.Property(e => e.LeaveDate)
                    .HasMaxLength(8)
                    .HasColumnName("LEAVE_DATE");
                entity.Property(e => e.Lunar)
                    .HasMaxLength(1)
                    .HasColumnName("LUNAR");
                entity.Property(e => e.Mailing)
                    .HasMaxLength(1)
                    .HasColumnName("MAILING");
                entity.Property(e => e.MarketingAgree)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasDefaultValue("N")
                    .IsFixedLength();
                entity.Property(e => e.MemberClass)
                    .HasMaxLength(50)
                    .HasColumnName("MEMBER_CLASS");
                entity.Property(e => e.MemberLevel).HasColumnName("MEMBER_LEVEL");
                entity.Property(e => e.MemberName)
                    .HasMaxLength(20)
                    .HasColumnName("MEMBER_NAME");
                entity.Property(e => e.MemberOpen)
                    .HasMaxLength(1)
                    .HasColumnName("MEMBER_OPEN");
                entity.Property(e => e.MemberOpenDate)
                    .HasColumnType("smalldatetime")
                    .HasColumnName("MEMBER_OPEN_DATE");
                entity.Property(e => e.MemberType)
                    .HasMaxLength(1)
                    .HasColumnName("MEMBER_TYPE");
                entity.Property(e => e.Memo).HasColumnName("MEMO");
                entity.Property(e => e.Mobile)
                    .HasMaxLength(20)
                    .HasColumnName("MOBILE");
                entity.Property(e => e.MobileAuth)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasDefaultValue("N")
                    .IsFixedLength();
                entity.Property(e => e.MobileAuthDate).HasColumnType("smalldatetime");
                entity.Property(e => e.ModDate)
                    .HasColumnType("smalldatetime")
                    .HasColumnName("MOD_DATE");
                entity.Property(e => e.NickName)
                    .HasMaxLength(20)
                    .HasColumnName("NICK_NAME");
                entity.Property(e => e.Point).HasColumnName("POINT");
                entity.Property(e => e.RegDate)
                    .HasColumnType("smalldatetime")
                    .HasColumnName("REG_DATE");
                entity.Property(e => e.RegIp)
                    .HasMaxLength(30)
                    .HasColumnName("REG_IP");
                entity.Property(e => e.Sex)
                    .HasMaxLength(1)
                    .HasColumnName("SEX");
                entity.Property(e => e.Sms)
                    .HasMaxLength(1)
                    .HasColumnName("SMS");
                entity.Property(e => e.Tel)
                    .HasMaxLength(20)
                    .HasColumnName("TEL");
                entity.Property(e => e.VisitCnt).HasColumnName("VISIT_CNT");
                entity.Property(e => e.Zipcode)
                    .HasMaxLength(7)
                    .HasColumnName("ZIPCODE");
            });

            modelBuilder.Entity<MemberLogin>(entity =>
            {
                entity.ToTable("member_login");

                entity.HasKey(e => e.Uid).HasFillFactor(90);

                entity.HasIndex(e => e.MemberGubun, "IX_member_login_MEMBER_GUBUN").HasFillFactor(90);

                entity.HasIndex(e => e.MemberId, "IX_member_login_MEMBER_ID").HasFillFactor(90);

                entity.HasIndex(e => e.MemberUid, "IX_member_login_MEMBER_UID").HasFillFactor(90);

                entity.HasIndex(e => e.TmpData, "IX_member_login_TmpData").HasFillFactor(90);

                entity.HasIndex(e => e.Uid, "IX_member_login_UID").HasFillFactor(90);

                entity.Property(e => e.Uid).HasColumnName("UID");
                entity.Property(e => e.AdminYn)
                    .HasMaxLength(1)
                    .HasColumnName("ADMIN_YN");
                entity.Property(e => e.ChkPassword)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasDefaultValue("N")
                    .IsFixedLength();
                entity.Property(e => e.ChkPasswordDate).HasColumnType("datetime");
                entity.Property(e => e.HomeApproval)
                    .HasMaxLength(1)
                    .HasColumnName("HOME_APPROVAL");
                entity.Property(e => e.HomeColor)
                    .HasMaxLength(5)
                    .HasColumnName("HOME_COLOR");
                entity.Property(e => e.HomeLayout)
                    .HasMaxLength(6)
                    .HasColumnName("HOME_LAYOUT");
                entity.Property(e => e.HomeLevel)
                    .HasMaxLength(1)
                    .HasColumnName("HOME_LEVEL");
                entity.Property(e => e.HomeType)
                    .HasMaxLength(1)
                    .HasColumnName("HOME_TYPE");
                entity.Property(e => e.HomeUrl)
                    .HasMaxLength(20)
                    .HasColumnName("HOME_URL");
                entity.Property(e => e.LastDate).HasColumnType("datetime");
                entity.Property(e => e.MemberApproval)
                    .HasMaxLength(1)
                    .HasColumnName("MEMBER_APPROVAL");
                entity.Property(e => e.MemberGubun)
                    .HasMaxLength(1)
                    .HasColumnName("MEMBER_GUBUN");
                entity.Property(e => e.MemberId)
                    .HasMaxLength(50)
                    .HasColumnName("MEMBER_ID");
                entity.Property(e => e.MemberPw)
                    .HasMaxLength(200)
                    .HasColumnName("MEMBER_PW");
                entity.Property(e => e.MemberUid).HasColumnName("MEMBER_UID");
                entity.Property(e => e.TmpData)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<ProductList>(entity =>
            {
                entity.ToTable("product_list");

                entity.HasKey(e => e.PROD_UID).HasFillFactor(90);

                entity.HasIndex(e => e.Cat, "IX_product_list_Cat").HasFillFactor(90);

                entity.HasIndex(e => e.Deleted, "IX_product_list_Deleted").HasFillFactor(90);

                entity.HasIndex(e => e.MEMBER_UID, "IX_product_list_MEMBER_UID").HasFillFactor(90);

                entity.HasIndex(e => e.PROD_UID, "IX_product_list_PROD_UID")
                    .IsDescending()
                    .HasFillFactor(90);

                entity.HasIndex(e => e.P_APPROVAL, "IX_product_list_P_APPROVAL")
                    .IsDescending()
                    .HasFillFactor(90);

                entity.HasIndex(e => e.P_CAPACITY, "IX_product_list_P_CAPACITY").HasFillFactor(90);

                entity.HasIndex(e => e.P_CATEGORY, "IX_product_list_P_CATEGORY").HasFillFactor(90);

                entity.HasIndex(e => e.P_HIT, "IX_product_list_P_HIT")
                    .IsDescending()
                    .HasFillFactor(90);

                entity.HasIndex(e => e.P_ORIGIN, "IX_product_list_P_ORIGIN").HasFillFactor(90);

                entity.HasIndex(e => e.P_REGDATE, "IX_product_list_P_REGDATE")
                    .IsDescending()
                    .HasFillFactor(90);

                entity.HasIndex(e => e.P_USE, "IX_product_list_P_USE")
                    .IsDescending()
                    .HasFillFactor(90);

                entity.HasIndex(e => e.P_USE_ST, "IX_product_list_P_USE_ST")
                    .IsDescending()
                    .HasFillFactor(90);

                entity.HasIndex(e => e.ProdType, "IX_product_list_ProdType").HasFillFactor(90);

                entity.HasIndex(e => e.UpCat, "IX_product_list_UpCat").HasFillFactor(90);

                entity.HasIndex(e => e.Visit, "IX_product_list_Visit")
                    .IsDescending()
                    .HasFillFactor(90);

                entity.HasIndex(e => e.Tag0, "IX_product_list_tag0");

                entity.HasIndex(e => e.Tag1, "IX_product_list_tag1");

                entity.HasIndex(e => e.Tag2, "IX_product_list_tag2");

                entity.HasIndex(e => e.Tag3, "IX_product_list_tag3");

                entity.HasIndex(e => e.Tag4, "IX_product_list_tag4");

                entity.HasIndex(e => e.Tag5, "IX_product_list_tag5");

                entity.HasIndex(e => e.Tag6, "IX_product_list_tag6");

                entity.HasIndex(e => e.Tag7, "IX_product_list_tag7");

                entity.HasIndex(e => e.Tag8, "IX_product_list_tag8");

                entity.HasIndex(e => e.Tag9, "IX_product_list_tag9");

                entity.Property(e => e.CO_ID).HasMaxLength(20);
                entity.Property(e => e.Cat)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasDefaultValue("");
                entity.Property(e => e.Deleted)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasDefaultValue("N")
                    .IsFixedLength();
                entity.Property(e => e.MEMBER_GUBUN).HasMaxLength(1);
                entity.Property(e => e.P_APPDATE).HasColumnType("smalldatetime");
                entity.Property(e => e.P_APPDATE_BEFORE).HasColumnType("smalldatetime");
                entity.Property(e => e.P_APPROVAL)
                    .HasMaxLength(1)
                    .HasDefaultValue("N");
                entity.Property(e => e.P_APPROVAL_BEFORE).HasMaxLength(1);
                entity.Property(e => e.P_APPRUSER).HasMaxLength(100);
                entity.Property(e => e.P_APPRUSER_BEFORE).HasMaxLength(100);
                entity.Property(e => e.P_CAP_UNIT).HasMaxLength(10);
                entity.Property(e => e.P_CATEGORY).HasMaxLength(100);
                entity.Property(e => e.P_CODE).HasMaxLength(100);
                entity.Property(e => e.P_CODE_EN).HasMaxLength(100);
                entity.Property(e => e.P_HOT)
                    .HasMaxLength(1)
                    .HasDefaultValue("0");
                entity.Property(e => e.P_IMG1).HasMaxLength(100);
                entity.Property(e => e.P_IMG2).HasMaxLength(100);
                entity.Property(e => e.P_IMG3).HasMaxLength(100);
                entity.Property(e => e.P_IMG4).HasMaxLength(100);
                entity.Property(e => e.P_IMG5).HasMaxLength(100);
                entity.Property(e => e.P_IMG6).HasMaxLength(100);
                entity.Property(e => e.P_MODDATE)
                    .HasDefaultValueSql("(getdate())")
                    .HasColumnType("smalldatetime");
                entity.Property(e => e.P_MOQ_DEAL)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasDefaultValue("N")
                    .IsFixedLength();
                entity.Property(e => e.P_NAME).HasMaxLength(100);
                entity.Property(e => e.P_NAME2).HasMaxLength(100);
                entity.Property(e => e.P_NEW)
                    .HasMaxLength(1)
                    .HasDefaultValue("0");
                entity.Property(e => e.P_ORIGIN).HasMaxLength(50);
                entity.Property(e => e.P_QUALITY).HasMaxLength(100);
                entity.Property(e => e.P_REGDATE)
                    .HasDefaultValueSql("(getdate())")
                    .HasColumnType("smalldatetime");
                entity.Property(e => e.P_SIZE).HasMaxLength(100);
                entity.Property(e => e.P_USE)
                    .HasMaxLength(1)
                    .HasDefaultValue("1");
                entity.Property(e => e.P_USE_ST)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasDefaultValue("Y")
                    .IsFixedLength();
                entity.Property(e => e.ProdType)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasDefaultValue("P")
                    .IsFixedLength();
                entity.Property(e => e.Tag0)
                    .HasMaxLength(20)
                    .HasDefaultValue("");
                entity.Property(e => e.Tag1)
                    .HasMaxLength(20)
                    .HasDefaultValue("");
                entity.Property(e => e.Tag2)
                    .HasMaxLength(20)
                    .HasDefaultValue("");
                entity.Property(e => e.Tag3)
                    .HasMaxLength(20)
                    .HasDefaultValue("");
                entity.Property(e => e.Tag4)
                    .HasMaxLength(20)
                    .HasDefaultValue("");
                entity.Property(e => e.Tag5)
                    .HasMaxLength(20)
                    .HasDefaultValue("");
                entity.Property(e => e.Tag6)
                    .HasMaxLength(20)
                    .HasDefaultValue("");
                entity.Property(e => e.Tag7)
                    .HasMaxLength(20)
                    .HasDefaultValue("");
                entity.Property(e => e.Tag8)
                    .HasMaxLength(20)
                    .HasDefaultValue("");
                entity.Property(e => e.Tag9)
                    .HasMaxLength(20)
                    .HasDefaultValue("");
                entity.Property(e => e.UpCat)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasDefaultValue("");
                entity.Property(e => e.isMove)
                    .HasMaxLength(1)
                    .IsFixedLength();
                entity.Property(e => e.isPCR)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasDefaultValue("N")
                    .IsFixedLength();
                entity.Property(e => e.isRefill)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasDefaultValue("N")
                    .IsFixedLength();
                entity.Property(e => e.it_id).HasMaxLength(20);
            });

            modelBuilder.Entity<Qna>(entity =>
            {
                entity.HasKey(e => e.QnaUid).HasFillFactor(90);

                entity.ToTable("qna");

                entity.HasIndex(e => e.Appr, "IX_qna_APPR").HasFillFactor(90);

                entity.HasIndex(e => e.CompUid, "IX_qna_COMP_UID").HasFillFactor(90);

                entity.HasIndex(e => e.Depth, "IX_qna_DEPTH").HasFillFactor(90);

                entity.HasIndex(e => e.Deleted, "IX_qna_Deleted").HasFillFactor(90);

                entity.HasIndex(e => e.Grp, "IX_qna_GRP").HasFillFactor(90);

                entity.HasIndex(e => e.Gubun, "IX_qna_GUBUN").HasFillFactor(90);

                entity.HasIndex(e => e.MemberGubun, "IX_qna_MEMBER_GUBUN").HasFillFactor(90);

                entity.HasIndex(e => e.MemberUid, "IX_qna_MEMBER_UID").HasFillFactor(90);

                entity.HasIndex(e => e.PCode, "IX_qna_P_CODE").HasFillFactor(90);

                entity.HasIndex(e => e.Regdate, "IX_qna_REGDATE")
                    .IsDescending()
                    .HasFillFactor(90);

                entity.HasIndex(e => e.PIdx, "IX_qna_pIdx").HasFillFactor(90);

                entity.Property(e => e.QnaUid).HasColumnName("QNA_UID");
                entity.Property(e => e.Appr)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasDefaultValue("Y")
                    .IsFixedLength()
                    .HasColumnName("APPR");
                entity.Property(e => e.ComContact)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasDefaultValue("N")
                    .IsFixedLength();
                entity.Property(e => e.CompName)
                    .HasMaxLength(50)
                    .HasDefaultValue("")
                    .HasColumnName("COMP_NAME");
                entity.Property(e => e.CompUid).HasColumnName("COMP_UID");
                entity.Property(e => e.DamdangName)
                    .HasMaxLength(20)
                    .HasDefaultValue("")
                    .HasColumnName("DAMDANG_NAME");
                entity.Property(e => e.DamdangTel)
                    .HasMaxLength(20)
                    .HasDefaultValue("")
                    .HasColumnName("DAMDANG_TEL");
                entity.Property(e => e.Deleted)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasDefaultValue("N")
                    .IsFixedLength();
                entity.Property(e => e.Depth).HasColumnName("DEPTH");
                entity.Property(e => e.DlvCond)
                    .HasMaxLength(20)
                    .HasDefaultValue("")
                    .HasColumnName("DLV_COND");
                entity.Property(e => e.DlvDate)
                    .HasMaxLength(10)
                    .HasDefaultValue("")
                    .HasColumnName("DLV_DATE");
                entity.Property(e => e.DlvWay)
                    .HasMaxLength(20)
                    .HasDefaultValue("")
                    .HasColumnName("DLV_WAY");
                entity.Property(e => e.Email)
                    .HasMaxLength(100)
                    .HasDefaultValue("")
                    .HasColumnName("EMAIL");
                entity.Property(e => e.EstiRequest)
                    .HasMaxLength(1)
                    .HasDefaultValue("")
                    .HasColumnName("ESTI_REQUEST");
                entity.Property(e => e.Grp).HasColumnName("GRP");
                entity.Property(e => e.Gubun)
                    .HasMaxLength(5)
                    .HasColumnName("GUBUN");
                entity.Property(e => e.Hits).HasColumnName("HITS");
                entity.Property(e => e.MemberGubun)
                    .HasMaxLength(1)
                    .HasColumnName("MEMBER_GUBUN");
                entity.Property(e => e.MemberName)
                    .HasMaxLength(50)
                    .HasColumnName("MEMBER_NAME");
                entity.Property(e => e.MemberUid).HasColumnName("MEMBER_UID");
                entity.Property(e => e.Memo)
                    .HasDefaultValue("")
                    .HasColumnName("MEMO");
                entity.Property(e => e.NameCard).HasMaxLength(100);
                entity.Property(e => e.PCode)
                    .HasMaxLength(30)
                    .HasDefaultValue("")
                    .HasColumnName("P_CODE");
                entity.Property(e => e.PIdx).HasColumnName("pIdx");
                entity.Property(e => e.PQty).HasColumnName("P_QTY");
                entity.Property(e => e.PayJan)
                    .HasMaxLength(5)
                    .HasDefaultValue("")
                    .HasColumnName("PAY_JAN");
                entity.Property(e => e.PaySunsu)
                    .HasMaxLength(5)
                    .HasDefaultValue("")
                    .HasColumnName("PAY_SUNSU");
                entity.Property(e => e.Phone)
                    .HasMaxLength(30)
                    .HasDefaultValue("")
                    .HasColumnName("PHONE");
                entity.Property(e => e.ReadId)
                    .HasMaxLength(100)
                    .HasDefaultValue("")
                    .HasColumnName("READ_ID");
                entity.Property(e => e.RecvAddr1).HasMaxLength(100);
                entity.Property(e => e.RecvAddr2).HasMaxLength(50);
                entity.Property(e => e.RecvZip)
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .IsFixedLength();
                entity.Property(e => e.Regdate)
                    .HasDefaultValueSql("(getdate())")
                    .HasColumnType("datetime")
                    .HasColumnName("REGDATE");
                entity.Property(e => e.Reply)
                    .HasMaxLength(1)
                    .HasDefaultValue("")
                    .HasColumnName("REPLY");
                entity.Property(e => e.SampleFee)
                    .HasMaxLength(1)
                    .HasDefaultValue("")
                    .HasColumnName("SAMPLE_FEE");
                entity.Property(e => e.SampleYn)
                    .HasMaxLength(1)
                    .HasDefaultValue("")
                    .HasColumnName("SAMPLE_YN");
                entity.Property(e => e.Smssend)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasDefaultValue("N")
                    .IsFixedLength()
                    .HasColumnName("SMSsend");
                entity.Property(e => e.Upfile)
                    .HasMaxLength(100)
                    .HasDefaultValue("")
                    .HasColumnName("UPFILE");
                entity.Property(e => e.Upfile2)
                    .HasMaxLength(100)
                    .HasColumnName("UPFILE2");
                entity.Property(e => e.Upfile3)
                    .HasMaxLength(100)
                    .HasColumnName("UPFILE3");
                entity.Property(e => e.Upfilename)
                    .HasMaxLength(100)
                    .HasDefaultValue("")
                    .HasColumnName("UPFILENAME");
                entity.Property(e => e.Upfilename2)
                    .HasMaxLength(100)
                    .HasColumnName("UPFILENAME2");
                entity.Property(e => e.Upfilename3)
                    .HasMaxLength(100)
                    .HasColumnName("UPFILENAME3");
                entity.Property(e => e.WriterRead)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasDefaultValue("N")
                    .IsFixedLength();
            });

            modelBuilder.Entity<TbAdminLog>(entity =>
            {
                entity.HasKey(e => e.Idx).HasFillFactor(90);

                entity.ToTable("TB_ADMIN_LOG");

                entity.Property(e => e.Domain).HasMaxLength(50);
                entity.Property(e => e.LoginStatus)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();
                entity.Property(e => e.MemberId)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("MemberID");
                entity.Property(e => e.Referer).IsUnicode(false);
                entity.Property(e => e.RegDate)
                    .HasDefaultValueSql("(getdate())")
                    .HasColumnType("datetime");
                entity.Property(e => e.RegIp)
                    .HasMaxLength(23)
                    .IsUnicode(false)
                    .HasColumnName("RegIP");
                entity.Property(e => e.UserAgent).IsUnicode(false);
            });

            modelBuilder.Entity<TbBanner>(entity =>
            {
                entity.HasKey(e => e.Idx).HasFillFactor(90);

                entity.ToTable("TB_BANNER");

                entity.HasIndex(e => e.BannerUnlimit, "IX_TB_BANNER_BannerUnlimit").HasFillFactor(90);

                entity.HasIndex(e => e.Deleted, "IX_TB_BANNER_Deleted").HasFillFactor(90);

                entity.HasIndex(e => e.Ord, "IX_TB_BANNER_Ord").HasFillFactor(90);

                entity.HasIndex(e => e.BIdx, "IX_TB_BANNER_bIdx").HasFillFactor(90);

                entity.HasIndex(e => e.BType, "IX_TB_BANNER_bType").HasFillFactor(90);

                entity.HasIndex(e => e.EDate, "IX_TB_BANNER_eDate")
                    .IsDescending()
                    .HasFillFactor(90);

                entity.HasIndex(e => e.IsUse, "IX_TB_BANNER_isUse").HasFillFactor(90);

                entity.HasIndex(e => e.SDate, "IX_TB_BANNER_sDate")
                    .IsDescending()
                    .HasFillFactor(90);

                entity.Property(e => e.BCode)
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasColumnName("bCode");
                entity.Property(e => e.BIdx)
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .HasComment("배너타입Idx")
                    .HasColumnName("bIdx");
                entity.Property(e => e.BType)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasDefaultValue("N")
                    .IsFixedLength()
                    .HasComment("배너타입(N:일반, C:카테고리)")
                    .HasColumnName("bType");
                entity.Property(e => e.BannerImage)
                    .HasMaxLength(50)
                    .HasComment("배너이미지");
                entity.Property(e => e.BannerLink)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasComment("배너링크(입력시에만)");
                entity.Property(e => e.BannerSubject)
                    .HasMaxLength(1000)
                    .HasComment("간단설명");
                entity.Property(e => e.BannerType)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasDefaultValue("A")
                    .IsFixedLength()
                    .HasComment("메인배너종류(A,B)-메인O형, 메인A형에만 적용");
                entity.Property(e => e.BannerUnlimit)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasDefaultValue("Y")
                    .IsFixedLength()
                    .HasComment("무제한");
                entity.Property(e => e.Deleted)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasDefaultValue("N")
                    .IsFixedLength();
                entity.Property(e => e.EDate)
                    .HasColumnType("datetime")
                    .HasColumnName("eDate");
                entity.Property(e => e.IsUse)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasDefaultValue("Y")
                    .IsFixedLength()
                    .HasColumnName("isUse");
                entity.Property(e => e.MIdx)
                    .HasComment("회원UID")
                    .HasColumnName("mIdx");
                entity.Property(e => e.MType)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasDefaultValueSql("((1))")
                    .IsFixedLength()
                    .HasComment("회원구분(기업:1)")
                    .HasColumnName("mType");
                entity.Property(e => e.Ord).HasDefaultValue(99);
                entity.Property(e => e.RegDate)
                    .HasDefaultValueSql("(getdate())")
                    .HasColumnType("datetime");
                entity.Property(e => e.RegId)
                    .HasMaxLength(50)
                    .HasColumnName("RegID");
                entity.Property(e => e.RegIp)
                    .HasMaxLength(23)
                    .IsUnicode(false)
                    .HasColumnName("RegIP");
                entity.Property(e => e.SDate)
                    .HasColumnType("datetime")
                    .HasColumnName("sDate");
                entity.Property(e => e.StartDateWithUse).HasColumnType("datetime");
            });

            modelBuilder.Entity<TbBannerClick>(entity =>
            {
                entity.HasKey(e => e.Idx).HasFillFactor(90);

                entity.ToTable("TB_BANNER_CLICK");

                entity.HasIndex(e => e.InDate, "IX_TB_BANNER_CLICK_InDate")
                    .IsDescending()
                    .HasFillFactor(90);

                entity.HasIndex(e => e.RegId, "IX_TB_BANNER_CLICK_RegID").HasFillFactor(90);

                entity.Property(e => e.BannerLink)
                    .HasMaxLength(200)
                    .IsUnicode(false);
                entity.Property(e => e.BannerLocationType)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();
                entity.Property(e => e.BannerName1).HasMaxLength(20);
                entity.Property(e => e.BannerName2).HasMaxLength(20);
                entity.Property(e => e.CompanyName).HasMaxLength(50);
                entity.Property(e => e.InDate).HasDefaultValueSql("(getdate())");
                entity.Property(e => e.RegDate)
                    .HasDefaultValueSql("(getdate())")
                    .HasColumnType("datetime");
                entity.Property(e => e.RegId)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("RegID");
                entity.Property(e => e.RegIp)
                    .HasMaxLength(23)
                    .IsUnicode(false)
                    .HasColumnName("RegIP");
            });

            modelBuilder.Entity<TbBannerKeyword>(entity =>
            {
                entity.HasKey(e => e.Uid).HasFillFactor(90);

                entity.ToTable("TB_BANNER_KEYWORD");

                entity.HasIndex(e => e.Deleted, "IX_TB_BANNER_KEYWORD_Deleted").HasFillFactor(90);

                entity.HasIndex(e => e.KeyWord1, "IX_TB_BANNER_KEYWORD_KEY_WORD1").HasFillFactor(90);

                entity.HasIndex(e => e.KeyWord2, "IX_TB_BANNER_KEYWORD_KEY_WORD2").HasFillFactor(90);

                entity.HasIndex(e => e.KeyWord3, "IX_TB_BANNER_KEYWORD_KEY_WORD3").HasFillFactor(90);

                entity.HasIndex(e => e.KeyWord4, "IX_TB_BANNER_KEYWORD_KEY_WORD4").HasFillFactor(90);

                entity.HasIndex(e => e.MemberUid, "IX_TB_BANNER_KEYWORD_MEMBER_UID").HasFillFactor(90);

                entity.Property(e => e.Uid).HasColumnName("UID");
                entity.Property(e => e.Amount)
                    .HasMaxLength(10)
                    .HasDefaultValue("")
                    .HasColumnName("AMOUNT");
                entity.Property(e => e.ChargeDate).HasColumnName("CHARGE_DATE");
                entity.Property(e => e.Deleted)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasDefaultValue("N")
                    .IsFixedLength();
                entity.Property(e => e.Gubun)
                    .HasMaxLength(10)
                    .HasColumnName("GUBUN");
                entity.Property(e => e.KeyWord1)
                    .HasMaxLength(200)
                    .HasColumnName("KEY_WORD1");
                entity.Property(e => e.KeyWord2)
                    .HasMaxLength(200)
                    .HasColumnName("KEY_WORD2");
                entity.Property(e => e.KeyWord3)
                    .HasMaxLength(200)
                    .HasColumnName("KEY_WORD3");
                entity.Property(e => e.KeyWord4)
                    .HasMaxLength(200)
                    .HasColumnName("KEY_WORD4");
                entity.Property(e => e.MemberGubun)
                    .HasMaxLength(5)
                    .HasDefaultValue("1")
                    .HasColumnName("MEMBER_GUBUN");
                entity.Property(e => e.MemberUid).HasColumnName("MEMBER_UID");
                entity.Property(e => e.Memo).HasColumnName("MEMO");
                entity.Property(e => e.RegDate)
                    .HasDefaultValueSql("(getdate())")
                    .HasColumnType("datetime");
                entity.Property(e => e.RegId)
                    .HasMaxLength(50)
                    .HasColumnName("RegID");
                entity.Property(e => e.RegIp)
                    .HasMaxLength(23)
                    .IsUnicode(false)
                    .HasColumnName("RegIP");
                entity.Property(e => e.WordsEnd).HasColumnName("WORDS_END");
                entity.Property(e => e.WordsLink)
                    .HasMaxLength(200)
                    .HasDefaultValue("")
                    .HasColumnName("WORDS_LINK");
                entity.Property(e => e.WordsStart).HasColumnName("WORDS_START");
            });

            modelBuilder.Entity<TbBannerType>(entity =>
            {
                entity.HasKey(e => e.Idx).HasFillFactor(90);

                entity.ToTable("TB_BANNER_TYPE");

                entity.HasIndex(e => e.BannerPosition, "IX_TB_BANNER_TYPE_BannerPosition").HasFillFactor(90);

                entity.HasIndex(e => e.Ord1, "IX_TB_BANNER_TYPE_Ord1").HasFillFactor(90);

                entity.HasIndex(e => e.Ord2, "IX_TB_BANNER_TYPE_Ord2").HasFillFactor(90);

                entity.Property(e => e.BannerName1).HasMaxLength(20);
                entity.Property(e => e.BannerName2).HasMaxLength(20);
                entity.Property(e => e.BannerPosition)
                    .HasMaxLength(10)
                    .IsUnicode(false);
                entity.Property(e => e.BannerSize)
                    .HasMaxLength(50)
                    .IsUnicode(false);
                entity.Property(e => e.BannerType)
                    .HasMaxLength(10)
                    .IsUnicode(false);
                entity.Property(e => e.Memo).HasMaxLength(50);
                entity.Property(e => e.Ord1).HasDefaultValue(99);
                entity.Property(e => e.Ord2).HasDefaultValue(99);
                entity.Property(e => e.RegDate)
                    .HasDefaultValueSql("(getdate())")
                    .HasColumnType("datetime");
                entity.Property(e => e.RegIp)
                    .HasMaxLength(23)
                    .IsUnicode(false)
                    .HasColumnName("RegIP");
            });

            modelBuilder.Entity<TbBannerTypeCat>(entity =>
            {
                entity.HasKey(e => e.Idx).HasFillFactor(90);

                entity.ToTable("TB_BANNER_TYPE_CAT");

                entity.HasIndex(e => e.Code, "IX_TB_BANNER_TYPE_CAT_Code").HasFillFactor(90);

                entity.Property(e => e.Cat)
                    .HasMaxLength(5)
                    .IsUnicode(false);
                entity.Property(e => e.CatName).HasMaxLength(50);
                entity.Property(e => e.Code)
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .IsFixedLength();
            });

            modelBuilder.Entity<TbBlockIp>(entity =>
            {
                entity.HasKey(e => e.Idx);

                entity.ToTable("TB_BLOCK_IP");

                entity.Property(e => e.BlockIp)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("Block_IP");
                entity.Property(e => e.DelYn)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("Del_YN");
                entity.Property(e => e.RegDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<TbBoardWview>(entity =>
            {
                entity.HasKey(e => e.Idx).HasFillFactor(90);

                entity.ToTable("TB_BOARD_WVIEW");

                entity.HasIndex(e => e.BoardIdx, "IX_TB_BOARD_WVIEW_BoardIdx")
                    .IsDescending()
                    .HasFillFactor(90);

                entity.HasIndex(e => e.MemberId, "IX_TB_BOARD_WVIEW_MemberID").HasFillFactor(90);

                entity.Property(e => e.MemberId)
                    .HasMaxLength(50)
                    .HasColumnName("MemberID");
                entity.Property(e => e.RegDate)
                    .HasDefaultValueSql("(getdate())")
                    .HasColumnType("datetime");
                entity.Property(e => e.RegIp)
                    .HasMaxLength(23)
                    .IsUnicode(false)
                    .HasColumnName("RegIP");
            });

            modelBuilder.Entity<TbCategory>(entity =>
            {
                entity.HasKey(e => e.Idx).HasFillFactor(90);

                entity.ToTable("TB_CATEGORY");

                entity.HasIndex(e => e.Code, "IX_TB_CATEGORY_Code").HasFillFactor(90);

                entity.HasIndex(e => e.Depth, "IX_TB_CATEGORY_Depth").HasFillFactor(90);

                entity.HasIndex(e => e.NameKor, "IX_TB_CATEGORY_Name_Kor").HasFillFactor(90);

                entity.HasIndex(e => e.Ord, "IX_TB_CATEGORY_Ord").HasFillFactor(90);

                entity.HasIndex(e => e.StdMld, "IX_TB_CATEGORY_StdMld").HasFillFactor(90);

                entity.HasIndex(e => e.UpCode, "IX_TB_CATEGORY_UpCode").HasFillFactor(90);

                entity.Property(e => e.Code)
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .IsFixedLength();
                entity.Property(e => e.Memo).HasMaxLength(100);
                entity.Property(e => e.NameEng)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("Name_Eng");
                entity.Property(e => e.NameKor)
                    .HasMaxLength(50)
                    .HasColumnName("Name_Kor");
                entity.Property(e => e.StdMld)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();
                entity.Property(e => e.UpCode)
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .IsFixedLength();
            });

            modelBuilder.Entity<TbCode>(entity =>
            {
                entity.HasKey(e => e.Idx).HasFillFactor(90);

                entity.ToTable("TB_CODE");

                entity.HasIndex(e => e.Code, "IX_TB_CODE_Code").HasFillFactor(90);

                entity.HasIndex(e => e.Code2, "IX_TB_CODE_Code2").HasFillFactor(90);

                entity.HasIndex(e => e.Name, "IX_TB_CODE_Name").HasFillFactor(90);

                entity.HasIndex(e => e.Ord, "IX_TB_CODE_Ord").HasFillFactor(90);

                entity.HasIndex(e => e.Sort, "IX_TB_CODE_Sort").HasFillFactor(90);

                entity.HasIndex(e => e.IsUse, "IX_TB_CODE_isUse").HasFillFactor(90);

                entity.Property(e => e.Code).HasMaxLength(20);
                entity.Property(e => e.Code2).HasMaxLength(20);
                entity.Property(e => e.IsUse)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasDefaultValue("Y")
                    .IsFixedLength()
                    .HasColumnName("isUse");
                entity.Property(e => e.Name).HasMaxLength(20);
                entity.Property(e => e.Sort).HasMaxLength(10);
            });

            modelBuilder.Entity<TbCompareChain>(entity =>
            {
                entity.HasKey(e => e.Idx).HasFillFactor(90);

                entity.ToTable("TB_COMPARE_CHAIN");

                entity.HasIndex(e => e.Deleted, "IX_TB_COMPARE_CHAIN_Deleted").HasFillFactor(90);

                entity.HasIndex(e => e.FolderIdx, "IX_TB_COMPARE_CHAIN_FolderIdx").HasFillFactor(90);

                entity.HasIndex(e => e.MemberId, "IX_TB_COMPARE_CHAIN_MemberID").HasFillFactor(90);

                entity.HasIndex(e => e.PIdx, "IX_TB_COMPARE_CHAIN_pIdx").HasFillFactor(90);

                entity.Property(e => e.Deleted)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasDefaultValue("N")
                    .IsFixedLength();
                entity.Property(e => e.MemberId)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("MemberID");
                entity.Property(e => e.PIdx).HasColumnName("pIdx");
                entity.Property(e => e.RegDate)
                    .HasDefaultValueSql("(getdate())")
                    .HasColumnType("datetime");
                entity.Property(e => e.RegIp)
                    .HasMaxLength(23)
                    .IsUnicode(false)
                    .HasColumnName("RegIP");
            });

            modelBuilder.Entity<TbCompareFolder>(entity =>
            {
                entity.HasKey(e => e.Idx).HasFillFactor(90);

                entity.ToTable("TB_COMPARE_FOLDER");

                entity.HasIndex(e => e.Deleted, "IX_TB_COMPARE_FOLDER_Deleted").HasFillFactor(90);

                entity.HasIndex(e => e.FolderName, "IX_TB_COMPARE_FOLDER_FolderName").HasFillFactor(90);

                entity.HasIndex(e => e.MemberId, "IX_TB_COMPARE_FOLDER_MemberID").HasFillFactor(90);

                entity.HasIndex(e => e.UpdateDate, "IX_TB_COMPARE_FOLDER_UpdateDate").HasFillFactor(90);

                entity.Property(e => e.CompareType)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();
                entity.Property(e => e.Deleted)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasDefaultValue("N")
                    .IsFixedLength();
                entity.Property(e => e.FolderName).HasMaxLength(20);
                entity.Property(e => e.MemberId)
                    .HasMaxLength(50)
                    .HasColumnName("MemberID");
                entity.Property(e => e.RegDate)
                    .HasDefaultValueSql("(getdate())")
                    .HasColumnType("datetime");
                entity.Property(e => e.RegIp)
                    .HasMaxLength(23)
                    .IsUnicode(false)
                    .HasColumnName("RegIP");
                entity.Property(e => e.UpdateDate)
                    .HasDefaultValueSql("(getdate())")
                    .HasColumnType("datetime");
            });

            modelBuilder.Entity<TbCompareIng>(entity =>
            {
                entity.HasKey(e => e.Idx).HasFillFactor(90);

                entity.ToTable("TB_COMPARE_ING");

                entity.HasIndex(e => e.Deleted, "IX_TB_COMPARE_ING_Deleted").HasFillFactor(90);

                entity.HasIndex(e => e.MemberId, "IX_TB_COMPARE_ING_MemberID").HasFillFactor(90);

                entity.HasIndex(e => e.RegDate, "IX_TB_COMPARE_ING_RegDate")
                    .IsDescending()
                    .HasFillFactor(90);

                entity.HasIndex(e => e.ViewType, "IX_TB_COMPARE_ING_ViewType").HasFillFactor(90);

                entity.HasIndex(e => e.PIdx, "IX_TB_COMPARE_ING_pIdx")
                    .IsDescending()
                    .HasFillFactor(90);

                entity.Property(e => e.Deleted)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasDefaultValue("N")
                    .IsFixedLength();
                entity.Property(e => e.MIdx).HasColumnName("mIdx");
                entity.Property(e => e.MTimeStamp).HasColumnName("mTimeStamp");
                entity.Property(e => e.MType).HasColumnName("mType");
                entity.Property(e => e.MemberId)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("MemberID");
                entity.Property(e => e.PIdx).HasColumnName("pIdx");
                entity.Property(e => e.RegDate)
                    .HasDefaultValueSql("(getdate())")
                    .HasColumnType("datetime");
                entity.Property(e => e.RegIp)
                    .HasMaxLength(23)
                    .IsUnicode(false)
                    .HasColumnName("RegIP");
                entity.Property(e => e.ViewType)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasDefaultValue("P")
                    .IsFixedLength();
            });

            modelBuilder.Entity<TbConnection>(entity =>
            {
                entity
                    .HasNoKey()
                    .ToTable("TB_CONNECTION");

                entity.HasIndex(e => e.Idx, "IX_TB_CONNECTION_Idx")
                    .IsDescending()
                    .HasFillFactor(90);

                entity.HasIndex(e => e.InDate, "IX_TB_CONNECTION_InDate")
                    .IsDescending()
                    .HasFillFactor(90);

                entity.HasIndex(e => e.MemberId, "IX_TB_CONNECTION_MemberID").HasFillFactor(90);

                entity.HasIndex(e => e.RegDate, "IX_TB_CONNECTION_RegDate")
                    .IsDescending()
                    .HasFillFactor(90);

                entity.Property(e => e.CCode)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasColumnName("cCode");
                entity.Property(e => e.Domain).HasMaxLength(50);
                entity.Property(e => e.HttpReferer).IsUnicode(false);
                entity.Property(e => e.Idx).ValueGeneratedOnAdd();
                entity.Property(e => e.InDate).HasDefaultValueSql("(getdate())");
                entity.Property(e => e.Ipnum).HasColumnName("IPNum");
                entity.Property(e => e.MTimeStamp).HasColumnName("mTimeStamp");
                entity.Property(e => e.MType)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasColumnName("mType");
                entity.Property(e => e.MemberId)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("MemberID");
                entity.Property(e => e.MemberName).HasMaxLength(50);
                entity.Property(e => e.RegDate)
                    .HasDefaultValueSql("(getdate())")
                    .HasColumnType("datetime");
                entity.Property(e => e.RegIp)
                    .HasMaxLength(23)
                    .IsUnicode(false)
                    .HasColumnName("RegIP");
                entity.Property(e => e.UserAgent).IsUnicode(false);
            });

            modelBuilder.Entity<TbConnectionSm>(entity =>
            {
                entity
                    .HasNoKey()
                    .ToTable("TB_CONNECTION_SM");

                entity.HasIndex(e => e.Idx, "IX_TB_CONNECTION_SM_Idx")
                    .IsDescending()
                    .HasFillFactor(90);

                entity.HasIndex(e => e.InDate, "IX_TB_CONNECTION_SM_InDate")
                    .IsDescending()
                    .HasFillFactor(90);

                entity.HasIndex(e => e.RegDate, "IX_TB_CONNECTION_SM_RegDate")
                    .IsDescending()
                    .HasFillFactor(90);

                entity.HasIndex(e => e.CCode, "IX_TB_CONNECTION_SM_cCode").HasFillFactor(90);

                entity.Property(e => e.CCode)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasColumnName("cCode");
                entity.Property(e => e.Domain).HasMaxLength(50);
                entity.Property(e => e.HttpReferer).IsUnicode(false);
                entity.Property(e => e.Idx).ValueGeneratedOnAdd();
                entity.Property(e => e.InDate).HasDefaultValueSql("(getdate())");
                entity.Property(e => e.Ipnum).HasColumnName("IPNum");
                entity.Property(e => e.MTimeStamp).HasColumnName("mTimeStamp");
                entity.Property(e => e.RegDate)
                    .HasDefaultValueSql("(getdate())")
                    .HasColumnType("datetime");
                entity.Property(e => e.RegIp)
                    .HasMaxLength(23)
                    .IsUnicode(false)
                    .HasColumnName("RegIP");
                entity.Property(e => e.UserAgent).IsUnicode(false);
            });

            modelBuilder.Entity<TB_CONNECTION_ALLINKBEAUTY>(entity =>
            {
                entity.HasKey(e => e.Idx);

                entity.HasIndex(e => e.cCode, "IX_TB_CONNECTION_ALLINKBEAUTY");

                entity.HasIndex(e => e.Idx, "IX_TB_CONNECTION_ALLINKBEAUTY_1").IsDescending();

                entity.HasIndex(e => e.InDate, "IX_TB_CONNECTION_ALLINKBEAUTY_2").IsDescending();

                entity.HasIndex(e => e.RegDate, "IX_TB_CONNECTION_ALLINKBEAUTY_3").IsDescending();

                entity.Property(e => e.Domain).HasMaxLength(50);
                entity.Property(e => e.HttpReferer).IsUnicode(false);
                entity.Property(e => e.InDate)
                    .HasDefaultValueSql("(getdate())")
                    .HasColumnType("datetime");
                entity.Property(e => e.RegDate)
                    .HasDefaultValueSql("(getdate())")
                    .HasColumnType("datetime");
                entity.Property(e => e.RegIP)
                    .HasMaxLength(23)
                    .IsUnicode(false);
                entity.Property(e => e.UserAgent).IsUnicode(false);
                entity.Property(e => e.cCode)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .IsFixedLength();
            });

            modelBuilder.Entity<TbCount>(entity =>
            {
                entity.HasKey(e => e.Idx).HasFillFactor(90);

                entity.ToTable("TB_COUNT");

                entity.HasIndex(e => e.Sort, "IX_TB_COUNT_Sort").HasFillFactor(90);

                entity.Property(e => e.Sort).HasMaxLength(10);
                entity.Property(e => e.ValueTxt).HasMaxLength(50);
            });

            modelBuilder.Entity<TbError>(entity =>
            {
                entity
                    .HasNoKey()
                    .ToTable("TB_ERROR");

                entity.Property(e => e.ErrNumber)
                    .HasMaxLength(100)
                    .IsUnicode(false);
                entity.Property(e => e.ErrUrl)
                    .HasMaxLength(1000)
                    .IsUnicode(false);
                entity.Property(e => e.Idx).ValueGeneratedOnAdd();
                entity.Property(e => e.RegDate)
                    .HasDefaultValueSql("(getdate())")
                    .HasColumnType("datetime");
                entity.Property(e => e.RegId)
                    .HasMaxLength(50)
                    .HasColumnName("RegID");
                entity.Property(e => e.RegIp)
                    .HasMaxLength(23)
                    .IsUnicode(false)
                    .HasColumnName("RegIP");
            });

            modelBuilder.Entity<TbFavorite>(entity =>
            {
                entity.HasKey(e => e.Idx).HasFillFactor(90);

                entity.ToTable("TB_FAVORITE");

                entity.HasIndex(e => e.Deleted, "IX_TB_FAVORITE_Deleted").HasFillFactor(90);

                entity.HasIndex(e => e.FavoriteType, "IX_TB_FAVORITE_FavoriteType").HasFillFactor(90);

                entity.HasIndex(e => e.MemberId, "IX_TB_FAVORITE_MemberID").HasFillFactor(90);

                entity.HasIndex(e => e.PIdx, "IX_TB_FAVORITE_pIdx").HasFillFactor(90);

                entity.Property(e => e.Deleted)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasDefaultValue("N")
                    .IsFixedLength();
                entity.Property(e => e.FavoriteType)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();
                entity.Property(e => e.MType).HasColumnName("mType");
                entity.Property(e => e.MemberId)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("MemberID");
                entity.Property(e => e.PIdx).HasColumnName("pIdx");
                entity.Property(e => e.RegDate)
                    .HasDefaultValueSql("(getdate())")
                    .HasColumnType("datetime");
                entity.Property(e => e.RegIp)
                    .HasMaxLength(23)
                    .IsUnicode(false)
                    .HasColumnName("RegIP");
            });

            modelBuilder.Entity<TbFavoriteChain>(entity =>
            {
                entity.HasKey(e => e.Idx).HasFillFactor(90);

                entity.ToTable("TB_FAVORITE_CHAIN");

                entity.HasIndex(e => e.Deleted, "IX_TB_FAVORITE_CHAIN_Deleted").HasFillFactor(90);

                entity.HasIndex(e => e.FolderIdx, "IX_TB_FAVORITE_CHAIN_FolderIdx").HasFillFactor(90);

                entity.HasIndex(e => e.ItemIdx, "IX_TB_FAVORITE_CHAIN_ItemIdx").HasFillFactor(90);

                entity.HasIndex(e => e.MemberId, "IX_TB_FAVORITE_CHAIN_MemberID").HasFillFactor(90);

                entity.Property(e => e.Deleted)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasDefaultValue("N")
                    .IsFixedLength();
                entity.Property(e => e.MemberId)
                    .HasMaxLength(20)
                    .HasColumnName("MemberID");
                entity.Property(e => e.RegDate)
                    .HasDefaultValueSql("(getdate())")
                    .HasColumnType("datetime");
                entity.Property(e => e.RegIp)
                    .HasMaxLength(23)
                    .IsUnicode(false)
                    .HasColumnName("RegIP");
            });

            modelBuilder.Entity<TbFavoriteFolder>(entity =>
            {
                entity.HasKey(e => e.Idx).HasFillFactor(90);

                entity.ToTable("TB_FAVORITE_FOLDER");

                entity.HasIndex(e => e.Deleted, "IX_TB_FAVORITE_FOLDER_Deleted").HasFillFactor(90);

                entity.HasIndex(e => e.FavoriteType, "IX_TB_FAVORITE_FOLDER_FavoriteType").HasFillFactor(90);

                entity.HasIndex(e => e.FolderName, "IX_TB_FAVORITE_FOLDER_FolderName").HasFillFactor(90);

                entity.HasIndex(e => e.MemberId, "IX_TB_FAVORITE_FOLDER_MemberID").HasFillFactor(90);

                entity.HasIndex(e => e.UpdateDate, "IX_TB_FAVORITE_FOLDER_UpdateDate").HasFillFactor(90);

                entity.Property(e => e.Deleted)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasDefaultValue("N")
                    .IsFixedLength();
                entity.Property(e => e.FavoriteType)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();
                entity.Property(e => e.FolderName).HasMaxLength(20);
                entity.Property(e => e.MemberId)
                    .HasMaxLength(50)
                    .HasColumnName("MemberID");
                entity.Property(e => e.RegDate)
                    .HasDefaultValueSql("(getdate())")
                    .HasColumnType("datetime");
                entity.Property(e => e.RegIp)
                    .HasMaxLength(23)
                    .IsUnicode(false)
                    .HasColumnName("RegIP");
                entity.Property(e => e.UpdateDate)
                    .HasDefaultValueSql("(getdate())")
                    .HasColumnType("datetime");
            });

            modelBuilder.Entity<TbFavoriteUser>(entity =>
            {
                entity.HasKey(e => e.Idx).HasFillFactor(90);

                entity.ToTable("TB_FAVORITE_USER");

                entity.HasIndex(e => e.Deleted, "IX_TB_FAVORITE_USER_Deleted").HasFillFactor(90);

                entity.HasIndex(e => e.FavoriteType, "IX_TB_FAVORITE_USER_FavoriteType").HasFillFactor(90);

                entity.HasIndex(e => e.MemberId, "IX_TB_FAVORITE_USER_MemberID").HasFillFactor(90);

                entity.HasIndex(e => e.PIdx, "IX_TB_FAVORITE_USER_pIdx").HasFillFactor(90);

                entity.Property(e => e.Deleted)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasDefaultValue("N")
                    .IsFixedLength();
                entity.Property(e => e.FavoriteType)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasDefaultValue("U")
                    .IsFixedLength();
                entity.Property(e => e.MType).HasColumnName("mType");
                entity.Property(e => e.MemberId)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("MemberID");
                entity.Property(e => e.PIdx).HasColumnName("pIdx");
                entity.Property(e => e.RegDate)
                    .HasDefaultValueSql("(getdate())")
                    .HasColumnType("datetime");
                entity.Property(e => e.RegIp)
                    .HasMaxLength(23)
                    .IsUnicode(false)
                    .HasColumnName("RegIP");
            });

            modelBuilder.Entity<TbFindidpwLog>(entity =>
            {
                entity
                    .HasNoKey()
                    .ToTable("TB_FINDIDPW_LOG");

                entity.Property(e => e.AddInfo)
                    .HasMaxLength(100)
                    .IsUnicode(false);
                entity.Property(e => e.FindType)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .IsFixedLength();
                entity.Property(e => e.Idx).ValueGeneratedOnAdd();
                entity.Property(e => e.MId)
                    .HasMaxLength(50)
                    .HasColumnName("mID");
                entity.Property(e => e.MName)
                    .HasMaxLength(50)
                    .HasColumnName("mName");
                entity.Property(e => e.RegDate)
                    .HasDefaultValueSql("(getdate())")
                    .HasColumnType("datetime");
                entity.Property(e => e.RegIp)
                    .HasMaxLength(23)
                    .IsUnicode(false)
                    .HasColumnName("RegIP");
            });

            modelBuilder.Entity<TbHelp>(entity =>
            {
                entity.HasKey(e => e.Idx).HasFillFactor(90);

                entity.ToTable("TB_HELP");

                entity.HasIndex(e => e.Answer, "IX_TB_HELP_Answer").HasFillFactor(90);

                entity.HasIndex(e => e.Deleted, "IX_TB_HELP_Deleted").HasFillFactor(90);

                entity.HasIndex(e => e.RegId, "IX_TB_HELP_RegID").HasFillFactor(90);

                entity.Property(e => e.Answer)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasDefaultValue("N")
                    .IsFixedLength();
                entity.Property(e => e.Attach).HasMaxLength(100);
                entity.Property(e => e.Deleted)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasDefaultValue("N")
                    .IsFixedLength();
                entity.Property(e => e.RegDate)
                    .HasDefaultValueSql("(getdate())")
                    .HasColumnType("datetime");
                entity.Property(e => e.RegId)
                    .HasMaxLength(50)
                    .HasColumnName("RegID");
                entity.Property(e => e.RegIp)
                    .HasMaxLength(23)
                    .IsUnicode(false)
                    .HasColumnName("RegIP");
                entity.Property(e => e.Sort)
                    .HasMaxLength(10)
                    .HasDefaultValue("일반");
                entity.Property(e => e.Subject).HasMaxLength(100);
            });

            modelBuilder.Entity<TbHelpClick>(entity =>
            {
                entity.HasKey(e => e.Idx).HasFillFactor(90);

                entity.ToTable("TB_HELP_CLICK");

                entity.HasIndex(e => e.MemberId, "IX_TB_HELP_CLICK_MemberID").HasFillFactor(90);

                entity.Property(e => e.MemberId)
                    .HasMaxLength(50)
                    .HasColumnName("MemberID");
                entity.Property(e => e.RegDate)
                    .HasDefaultValueSql("(getdate())")
                    .HasColumnType("datetime");
                entity.Property(e => e.RegIp)
                    .HasMaxLength(23)
                    .IsUnicode(false)
                    .HasColumnName("RegIP");
            });

            modelBuilder.Entity<TbHelpMemo>(entity =>
            {
                entity.HasKey(e => e.Idx).HasFillFactor(90);

                entity.ToTable("TB_HELP_MEMO");

                entity.HasIndex(e => e.BoardIdx, "IX_TB_HELP_MEMO_BoardIdx").HasFillFactor(90);

                entity.HasIndex(e => e.Deleted, "IX_TB_HELP_MEMO_Deleted").HasFillFactor(90);

                entity.HasIndex(e => e.IsAdmin, "IX_TB_HELP_MEMO_isAdmin").HasFillFactor(90);

                entity.HasIndex(e => e.IsRead, "IX_TB_HELP_MEMO_isRead").HasFillFactor(90);

                entity.Property(e => e.Deleted)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasDefaultValue("N")
                    .IsFixedLength();
                entity.Property(e => e.IsAdmin)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasDefaultValue("N")
                    .IsFixedLength()
                    .HasColumnName("isAdmin");
                entity.Property(e => e.IsRead)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasDefaultValue("N")
                    .IsFixedLength()
                    .HasColumnName("isRead");
                entity.Property(e => e.IsReadDate)
                    .HasColumnType("datetime")
                    .HasColumnName("isReadDate");
                entity.Property(e => e.RegDate)
                    .HasDefaultValueSql("(getdate())")
                    .HasColumnType("datetime");
                entity.Property(e => e.RegId)
                    .HasMaxLength(50)
                    .HasColumnName("RegID");
                entity.Property(e => e.RegIp)
                    .HasMaxLength(23)
                    .IsUnicode(false)
                    .HasColumnName("RegIP");
            });

            modelBuilder.Entity<TbHomepage>(entity =>
            {
                entity.HasKey(e => e.Idx).HasFillFactor(90);

                entity.ToTable("TB_HOMEPAGE");

                entity.HasIndex(e => e.Deleted, "IX_TB_HOMEPAGE_Deleted").HasFillFactor(90);

                entity.HasIndex(e => e.MemberUid, "IX_TB_HOMEPAGE_MEMBER_UID").HasFillFactor(90);

                entity.HasIndex(e => e.MemberId, "IX_TB_HOMEPAGE_MemberID").HasFillFactor(90);

                entity.HasIndex(e => e.IsUse, "IX_TB_HOMEPAGE_isUse").HasFillFactor(90);

                entity.Property(e => e.Deleted)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasDefaultValue("N")
                    .IsFixedLength();
                entity.Property(e => e.HomeCenterMemo)
                    .HasMaxLength(200)
                    .HasColumnName("HOME_CENTER_MEMO");
                entity.Property(e => e.HomeCenterTel)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("HOME_CENTER_TEL");
                entity.Property(e => e.HomeCompanyIntro)
                    .HasMaxLength(100)
                    .HasColumnName("HOME_COMPANY_INTRO");
                entity.Property(e => e.HomeLogo)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("HOME_LOGO");
                entity.Property(e => e.HomeMainImage)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("HOME_MAIN_IMAGE");
                entity.Property(e => e.HomeSimpleIntro).HasColumnName("HOME_SIMPLE_INTRO");
                entity.Property(e => e.HomeSubImage)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("HOME_SUB_IMAGE");
                entity.Property(e => e.HomeUrl)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("HOME_URL");
                entity.Property(e => e.IsUse)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasDefaultValue("Y")
                    .IsFixedLength()
                    .HasColumnName("isUse");
                entity.Property(e => e.MemberGubun)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasColumnName("MEMBER_GUBUN");
                entity.Property(e => e.MemberId)
                    .HasMaxLength(50)
                    .HasColumnName("MemberID");
                entity.Property(e => e.MemberUid).HasColumnName("MEMBER_UID");
                entity.Property(e => e.RegDate)
                    .HasDefaultValueSql("(getdate())")
                    .HasColumnType("datetime");
                entity.Property(e => e.RegId)
                    .HasMaxLength(50)
                    .HasColumnName("RegID");
                entity.Property(e => e.RegIp)
                    .HasMaxLength(23)
                    .IsUnicode(false)
                    .HasColumnName("RegIP");
            });

            modelBuilder.Entity<TbIptable>(entity =>
            {
                entity
                    .HasNoKey()
                    .ToTable("TB_IPTABLES");

                entity.HasIndex(e => e.CCode, "IX_TB_IPTABLES_cCode").HasFillFactor(90);

                entity.HasIndex(e => e.ENum, "IX_TB_IPTABLES_eNum")
                    .IsUnique()
                    .HasFillFactor(90);

                entity.HasIndex(e => e.SNum, "IX_TB_IPTABLES_sNum")
                    .IsUnique()
                    .HasFillFactor(90);

                entity.Property(e => e.CCode)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasColumnName("cCode");
                entity.Property(e => e.EIp)
                    .HasMaxLength(23)
                    .IsUnicode(false)
                    .HasColumnName("eIP");
                entity.Property(e => e.ENum).HasColumnName("eNum");
                entity.Property(e => e.PreFix)
                    .HasMaxLength(30)
                    .IsUnicode(false);
                entity.Property(e => e.RegDate)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .IsFixedLength();
                entity.Property(e => e.SDate)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasColumnName("sDate");
                entity.Property(e => e.SIp)
                    .HasMaxLength(23)
                    .IsUnicode(false)
                    .HasColumnName("sIP");
                entity.Property(e => e.SNum).HasColumnName("sNum");
            });

            modelBuilder.Entity<TbMailMReport>(entity =>
            {
                entity.HasKey(e => e.Idx).HasFillFactor(90);

                entity.ToTable("TB_MAIL_mREPORT");

                entity.HasIndex(e => e.Sort, "IX_TB_MAIL_mREPORT_Sort").HasFillFactor(90);

                entity.HasIndex(e => e.SMonth, "IX_TB_MAIL_mREPORT_sMonth")
                    .IsDescending()
                    .HasFillFactor(90);

                entity.Property(e => e.Name).HasMaxLength(50);
                entity.Property(e => e.SMonth)
                    .HasMaxLength(7)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasColumnName("sMonth");
                entity.Property(e => e.Sort)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TbMsg>(entity =>
            {
                entity.HasKey(e => e.Idx).HasFillFactor(90);

                entity.ToTable("TB_MSG");

                entity.HasIndex(e => e.Deleted, "IX_TB_MSG_Deleted").HasFillFactor(90);

                entity.HasIndex(e => e.RecvUser, "IX_TB_MSG_RecvUser").HasFillFactor(90);

                entity.HasIndex(e => e.SendFrom, "IX_TB_MSG_SendFrom").HasFillFactor(90);

                entity.HasIndex(e => e.SendUser, "IX_TB_MSG_SendUser").HasFillFactor(90);

                entity.HasIndex(e => e.PIdx, "IX_TB_MSG_pIdx").HasFillFactor(90);

                entity.Property(e => e.Deleted)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasDefaultValue("N")
                    .IsFixedLength();
                entity.Property(e => e.PIdx).HasColumnName("pIdx");
                entity.Property(e => e.RecvTime).HasColumnType("datetime");
                entity.Property(e => e.RecvUser).HasMaxLength(50);
                entity.Property(e => e.RegDate)
                    .HasDefaultValueSql("(getdate())")
                    .HasColumnType("datetime");
                entity.Property(e => e.RegIp)
                    .HasMaxLength(23)
                    .IsUnicode(false)
                    .HasColumnName("RegIP");
                entity.Property(e => e.SendFrom).HasMaxLength(10);
                entity.Property(e => e.SendTime)
                    .HasDefaultValueSql("(getdate())")
                    .HasColumnType("datetime");
                entity.Property(e => e.SendUser).HasMaxLength(50);
            });

            modelBuilder.Entity<TbProductUser>(entity =>
            {
                entity.HasKey(e => e.Idx).HasFillFactor(90);

                entity.ToTable("TB_PRODUCT_USER");

                entity.HasIndex(e => e.Approval, "IX_TB_PRODUCT_USER_Approval").HasFillFactor(90);

                entity.HasIndex(e => e.Deleted, "IX_TB_PRODUCT_USER_Deleted").HasFillFactor(90);

                entity.HasIndex(e => e.MemberId, "IX_TB_PRODUCT_USER_Member_ID").HasFillFactor(90);

                entity.Property(e => e.Approval)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasDefaultValue("N")
                    .IsFixedLength();
                entity.Property(e => e.Category).HasMaxLength(10);
                entity.Property(e => e.Deleted)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasDefaultValue("N")
                    .IsFixedLength();
                entity.Property(e => e.MemberId)
                    .HasMaxLength(50)
                    .HasColumnName("Member_ID");
                entity.Property(e => e.PImg1)
                    .HasMaxLength(100)
                    .HasColumnName("P_IMG1");
                entity.Property(e => e.PImg2)
                    .HasMaxLength(100)
                    .HasColumnName("P_IMG2");
                entity.Property(e => e.PImg3)
                    .HasMaxLength(100)
                    .HasColumnName("P_IMG3");
                entity.Property(e => e.PImg4)
                    .HasMaxLength(100)
                    .HasColumnName("P_IMG4");
                entity.Property(e => e.PImg5)
                    .HasMaxLength(100)
                    .HasColumnName("P_IMG5");
                entity.Property(e => e.PImg6)
                    .HasMaxLength(100)
                    .HasColumnName("P_IMG6");
                entity.Property(e => e.ProdName).HasMaxLength(100);
                entity.Property(e => e.RegDate)
                    .HasDefaultValueSql("(getdate())")
                    .HasColumnType("datetime");
                entity.Property(e => e.RegIp)
                    .HasMaxLength(23)
                    .IsUnicode(false)
                    .HasColumnName("RegIP");
                entity.Property(e => e.Status)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();
            });

            modelBuilder.Entity<TbQuickmenu>(entity =>
            {
                entity.HasKey(e => e.Idx).HasFillFactor(90);

                entity.ToTable("TB_QUICKMENU");

                entity.HasIndex(e => e.Deleted, "IX_TB_QUICKMENU_Deleted").HasFillFactor(90);

                entity.HasIndex(e => e.MemberId, "IX_TB_QUICKMENU_MemberID").HasFillFactor(90);

                entity.HasIndex(e => e.QuickName, "IX_TB_QUICKMENU_QuickName").HasFillFactor(90);

                entity.Property(e => e.Deleted)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasDefaultValue("N")
                    .IsFixedLength();
                entity.Property(e => e.MIdx).HasColumnName("mIdx");
                entity.Property(e => e.MType)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasColumnName("mType");
                entity.Property(e => e.MemberId)
                    .HasMaxLength(50)
                    .HasColumnName("MemberID");
                entity.Property(e => e.QuickName).HasMaxLength(100);
                entity.Property(e => e.QuickUrl)
                    .HasMaxLength(1000)
                    .IsUnicode(false)
                    .HasColumnName("QuickURL");
                entity.Property(e => e.RegDate)
                    .HasDefaultValueSql("(getdate())")
                    .HasColumnType("datetime");
                entity.Property(e => e.RegIp)
                    .HasMaxLength(23)
                    .IsUnicode(false)
                    .HasColumnName("RegIP");
            });

            modelBuilder.Entity<TbRecentView>(entity =>
            {
                entity.HasKey(e => e.Idx).HasFillFactor(90);

                entity.ToTable("TB_RECENT_VIEW");

                entity.HasIndex(e => e.Deleted, "IX_TB_RECENT_VIEW_Deleted").HasFillFactor(90);

                entity.HasIndex(e => e.MemberId, "IX_TB_RECENT_VIEW_MemberID").HasFillFactor(90);

                entity.HasIndex(e => e.RegDate, "IX_TB_RECENT_VIEW_RegDate")
                    .IsDescending()
                    .HasFillFactor(90);

                entity.HasIndex(e => e.ViewType, "IX_TB_RECENT_VIEW_ViewType").HasFillFactor(90);

                entity.HasIndex(e => e.MTimeStamp, "IX_TB_RECENT_VIEW_mTimeStamp")
                    .IsDescending()
                    .HasFillFactor(90);

                entity.HasIndex(e => e.PIdx, "IX_TB_RECENT_VIEW_pIdx")
                    .IsDescending()
                    .HasFillFactor(90);

                entity.Property(e => e.Deleted)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasDefaultValue("N")
                    .IsFixedLength();
                entity.Property(e => e.MIdx)
                    .HasComment("회원UID")
                    .HasColumnName("mIdx");
                entity.Property(e => e.MTimeStamp)
                    .HasComment("Session TimeStamp")
                    .HasColumnName("mTimeStamp");
                entity.Property(e => e.MType)
                    .HasComment("회원구분")
                    .HasColumnName("mType");
                entity.Property(e => e.MemberId)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasComment("회원ID")
                    .HasColumnName("MemberID");
                entity.Property(e => e.PIdx)
                    .HasComment("상품UID")
                    .HasColumnName("pIdx");
                entity.Property(e => e.RegDate)
                    .HasDefaultValueSql("(getdate())")
                    .HasComment("방문일시")
                    .HasColumnType("datetime");
                entity.Property(e => e.RegIp)
                    .HasMaxLength(23)
                    .IsUnicode(false)
                    .HasComment("접속IP")
                    .HasColumnName("RegIP");
                entity.Property(e => e.ViewCnt).HasDefaultValue(1);
                entity.Property(e => e.ViewType)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasDefaultValue("P")
                    .IsFixedLength();
            });

            modelBuilder.Entity<TbSmInquiry>(entity =>
            {
                entity.HasKey(e => e.Idx).HasFillFactor(90);

                entity.ToTable("TB_SM_INQUIRY");

                entity.Property(e => e.Company).HasMaxLength(100);
                entity.Property(e => e.Deleted)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasDefaultValue("N")
                    .IsFixedLength();
                entity.Property(e => e.Email).HasMaxLength(100);
                entity.Property(e => e.Inquiry).HasMaxLength(1200);
                entity.Property(e => e.Name).HasMaxLength(100);
                entity.Property(e => e.PIdx).HasColumnName("pIdx");
                entity.Property(e => e.ReCaptchaMsg)
                    .HasMaxLength(1000)
                    .IsUnicode(false)
                    .HasColumnName("reCaptchaMsg");
                entity.Property(e => e.ReCaptchaPass)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasDefaultValue("Y")
                    .IsFixedLength()
                    .HasColumnName("reCaptchaPass");
                entity.Property(e => e.RegCountry).HasMaxLength(50);
                entity.Property(e => e.RegDate).HasColumnType("datetime");
                entity.Property(e => e.RegIp)
                    .HasMaxLength(23)
                    .IsUnicode(false)
                    .HasColumnName("RegIP");
            });

            modelBuilder.Entity<TbSmsAuth>(entity =>
            {
                entity
                    .HasNoKey()
                    .ToTable("TB_SMS_AUTH");

                entity.Property(e => e.AuthExpireDate).HasColumnType("datetime");
                entity.Property(e => e.AuthKey)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .IsFixedLength();
                entity.Property(e => e.AuthStatus)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasDefaultValue("N")
                    .IsFixedLength();
                entity.Property(e => e.Idx).ValueGeneratedOnAdd();
                entity.Property(e => e.Mobile)
                    .HasMaxLength(11)
                    .IsUnicode(false);
                entity.Property(e => e.RegDate)
                    .HasDefaultValueSql("(getdate())")
                    .HasColumnType("datetime");
                entity.Property(e => e.RegIp)
                    .HasMaxLength(23)
                    .IsUnicode(false)
                    .HasColumnName("RegIP");
            });

            modelBuilder.Entity<TbStandardProdMain>(entity =>
            {
                entity.HasKey(e => e.Idx).HasFillFactor(90);

                entity.ToTable("TB_STANDARD_PROD_MAIN");

                entity.HasIndex(e => e.Sort, "IX_TB_STANDARD_PROD_MAIN_Sort").HasFillFactor(90);

                entity.HasIndex(e => e.IsUse, "IX_TB_STANDARD_PROD_MAIN_isUse").HasFillFactor(90);

                entity.HasIndex(e => e.PIdx, "IX_TB_STANDARD_PROD_MAIN_pIdx").HasFillFactor(90);

                entity.Property(e => e.IsUse)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasDefaultValue("Y")
                    .IsFixedLength()
                    .HasColumnName("isUse");
                entity.Property(e => e.PIdx).HasColumnName("pIdx");
                entity.Property(e => e.Sort)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .IsFixedLength();
            });

            modelBuilder.Entity<TbSubmenu>(entity =>
            {
                entity.HasKey(e => e.Idx).HasFillFactor(90);

                entity.ToTable("TB_SUBMENU");

                entity.HasIndex(e => e.BoardId, "IX_TB_SUBMENU_BoardID").HasFillFactor(90);

                entity.HasIndex(e => e.Code, "IX_TB_SUBMENU_Code").HasFillFactor(90);

                entity.HasIndex(e => e.Name, "IX_TB_SUBMENU_Name").HasFillFactor(90);

                entity.HasIndex(e => e.Ord, "IX_TB_SUBMENU_Ord").HasFillFactor(90);

                entity.HasIndex(e => e.Sort, "IX_TB_SUBMENU_Sort").HasFillFactor(90);

                entity.HasIndex(e => e.UpCode, "IX_TB_SUBMENU_UpCode").HasFillFactor(90);

                entity.Property(e => e.BoardId)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("BoardID");
                entity.Property(e => e.Code).HasMaxLength(20);
                entity.Property(e => e.Name).HasMaxLength(50);
                entity.Property(e => e.Sort)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .IsFixedLength();
                entity.Property(e => e.UpCode).HasMaxLength(20);
            });

            modelBuilder.Entity<TbSuggest>(entity =>
            {
                entity.HasKey(e => e.Idx).HasFillFactor(90);

                entity.ToTable("TB_SUGGEST");

                entity.HasIndex(e => e.Deleted, "IX_TB_SUGGEST_Deleted").HasFillFactor(90);

                entity.Property(e => e.Deleted)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasDefaultValue("N")
                    .IsFixedLength();
                entity.Property(e => e.MIdx).HasColumnName("mIdx");
                entity.Property(e => e.MType)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasColumnName("mType");
                entity.Property(e => e.MemberId)
                    .HasMaxLength(50)
                    .HasColumnName("MemberID");
                entity.Property(e => e.Mobile)
                    .HasMaxLength(20)
                    .IsUnicode(false);
                entity.Property(e => e.Name).HasMaxLength(20);
                entity.Property(e => e.RegDate)
                    .HasDefaultValueSql("(getdate())")
                    .HasColumnType("datetime");
                entity.Property(e => e.RegIp)
                    .HasMaxLength(23)
                    .IsUnicode(false)
                    .HasColumnName("RegIP");
            });

            modelBuilder.Entity<TbUserSearch>(entity =>
            {
                entity
                    .HasNoKey()
                    .ToTable("TB_USER_SEARCH");

                entity.HasIndex(e => e.InDate, "IX_TB_USER_SEARCH_InDate")
                    .IsDescending()
                    .HasFillFactor(90);

                entity.HasIndex(e => e.LogIdx, "IX_TB_USER_SEARCH_LogIdx")
                    .IsDescending()
                    .HasFillFactor(90);

                entity.Property(e => e.Cat).HasMaxLength(20);
                entity.Property(e => e.Cat1Name).HasMaxLength(30);
                entity.Property(e => e.Cat2Name).HasMaxLength(30);
                entity.Property(e => e.CatA)
                    .HasMaxLength(50)
                    .IsUnicode(false);
                entity.Property(e => e.CatB)
                    .HasMaxLength(50)
                    .IsUnicode(false);
                entity.Property(e => e.CatC)
                    .HasMaxLength(50)
                    .IsUnicode(false);
                entity.Property(e => e.ComSortName).HasMaxLength(30);
                entity.Property(e => e.CompanyName).HasMaxLength(30);
                entity.Property(e => e.ErrNum)
                    .HasMaxLength(100)
                    .IsUnicode(false);
                entity.Property(e => e.FactoryLoc).HasMaxLength(10);
                entity.Property(e => e.FullUrl)
                    .HasMaxLength(1000)
                    .IsUnicode(false);
                entity.Property(e => e.InCompany).HasMaxLength(50);
                entity.Property(e => e.InDate).HasDefaultValueSql("(getdate())");
                entity.Property(e => e.InSearch).HasMaxLength(30);
                entity.Property(e => e.Location)
                    .HasMaxLength(100)
                    .IsUnicode(false);
                entity.Property(e => e.LocationName).HasMaxLength(20);
                entity.Property(e => e.LogIdx).ValueGeneratedOnAdd();
                entity.Property(e => e.MIdx).HasColumnName("mIdx");
                entity.Property(e => e.Origin).HasMaxLength(30);
                entity.Property(e => e.PIdx).HasColumnName("pIdx");
                entity.Property(e => e.PageOrderBy)
                    .HasMaxLength(10)
                    .IsUnicode(false);
                entity.Property(e => e.ProductCode).HasMaxLength(30);
                entity.Property(e => e.RegDate)
                    .HasDefaultValueSql("(getdate())")
                    .HasColumnType("datetime");
                entity.Property(e => e.RegId)
                    .HasMaxLength(50)
                    .HasColumnName("RegID");
                entity.Property(e => e.RegIp)
                    .HasMaxLength(23)
                    .IsUnicode(false)
                    .HasColumnName("RegIP");
                entity.Property(e => e.RegmType)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();
                entity.Property(e => e.SItem)
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .HasColumnName("sItem");
                entity.Property(e => e.SItemName)
                    .HasMaxLength(30)
                    .HasColumnName("sItemName");
                entity.Property(e => e.SKeyword)
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .HasColumnName("sKeyword");
                entity.Property(e => e.SKeywordName)
                    .HasMaxLength(30)
                    .HasColumnName("sKeywordName");
                entity.Property(e => e.SMyArticle)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("sMyArticle");
                entity.Property(e => e.SearchTopKeyword).HasMaxLength(30);
                entity.Property(e => e.Tp)
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .HasColumnName("tp");
                entity.Property(e => e.TpName)
                    .HasMaxLength(30)
                    .HasColumnName("tpName");
                entity.Property(e => e.UpCat).HasMaxLength(20);
            });

            modelBuilder.Entity<TbUserSearchRaw>(entity =>
            {
                entity
                    .HasNoKey()
                    .ToTable("TB_USER_SEARCH_RAW");

                entity.Property(e => e.Idx).ValueGeneratedOnAdd();
                entity.Property(e => e.RegDate)
                    .HasDefaultValueSql("(getdate())")
                    .HasColumnType("datetime");
                entity.Property(e => e.RegId)
                    .HasMaxLength(50)
                    .HasColumnName("RegID");
                entity.Property(e => e.RegIp)
                    .HasMaxLength(23)
                    .IsUnicode(false)
                    .HasColumnName("RegIP");
                entity.Property(e => e.Url)
                    .HasMaxLength(1000)
                    .IsUnicode(false)
                    .HasColumnName("URL");
                entity.Property(e => e.UserAgent).IsUnicode(false);
            });

            modelBuilder.Entity<TmList>(entity =>
            {
                entity
                    .HasNoKey()
                    .ToTable("tm_list");

                entity.Property(e => e.CompanyName)
                    .HasMaxLength(30)
                    .HasColumnName("COMPANY_NAME");
                entity.Property(e => e.Contact)
                    .HasMaxLength(30)
                    .HasColumnName("CONTACT");
                entity.Property(e => e.Deleted)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasDefaultValue("N")
                    .IsFixedLength();
                entity.Property(e => e.MemberGubun)
                    .HasMaxLength(5)
                    .HasDefaultValue("1")
                    .HasColumnName("MEMBER_GUBUN");
                entity.Property(e => e.MemberUid).HasColumnName("MEMBER_UID");
                entity.Property(e => e.Memo).HasColumnName("MEMO");
                entity.Property(e => e.ModDate)
                    .HasColumnType("smalldatetime")
                    .HasColumnName("MOD_DATE");
                entity.Property(e => e.ModManageId)
                    .HasMaxLength(20)
                    .HasColumnName("MOD_MANAGE_ID");
                entity.Property(e => e.RegDate)
                    .HasColumnType("smalldatetime")
                    .HasColumnName("REG_DATE");
                entity.Property(e => e.RegIp)
                    .HasMaxLength(23)
                    .IsUnicode(false)
                    .HasColumnName("RegIP");
                entity.Property(e => e.RegManageId)
                    .HasMaxLength(20)
                    .HasColumnName("REG_MANAGE_ID");
                entity.Property(e => e.Reservation)
                    .HasMaxLength(10)
                    .HasColumnName("RESERVATION");
                entity.Property(e => e.TmDate)
                    .HasColumnType("smalldatetime")
                    .HasColumnName("TM_DATE");
                entity.Property(e => e.Uid)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("UID");
            });

            modelBuilder.Entity<TmpAm>(entity =>
            {
                entity
                    .HasNoKey()
                    .ToTable("TMP_AM");

                entity.Property(e => e.Idx).ValueGeneratedOnAdd();
                entity.Property(e => e.Name).HasMaxLength(10);
                entity.Property(e => e.Sort).HasMaxLength(2);
                entity.Property(e => e.WorkDate).HasColumnType("smalldatetime");
            });

            modelBuilder.Entity<TB_ALLINKBEAUTY_CONTACT>(entity =>
            {
                entity.HasKey(e => e.Idx);

                entity.Property(e => e.BudgetRange).HasMaxLength(50);
                entity.Property(e => e.CompanyName).HasMaxLength(200);
                entity.Property(e => e.Country).HasMaxLength(2);
                entity.Property(e => e.Email).HasMaxLength(200);
                entity.Property(e => e.EstimatedOrderQuantity).HasMaxLength(50);
                entity.Property(e => e.Notes).HasColumnType("text");
                entity.Property(e => e.FormulaRequirements).HasMaxLength(50);
                entity.Property(e => e.FullName).HasMaxLength(150);
                entity.Property(e => e.PackagingPreferences).HasMaxLength(50);
                entity.Property(e => e.ProductCategory).HasMaxLength(50);
                entity.Property(e => e.RegDate).HasColumnType("datetime");
                entity.Property(e => e.RegIp).HasMaxLength(100);
                entity.Property(e => e.TargetLaunchTimeline).HasMaxLength(50);
                entity.Property(e => e.TypeofService).HasMaxLength(20);
            });

            modelBuilder.Entity<TB_ALLINKBEAUTY_CONTACT_US>(entity =>
            {
                entity.HasKey(e => e.idx);

                entity.Property(e => e.Detail).IsUnicode(false);
                entity.Property(e => e.Email).HasMaxLength(200);
                entity.Property(e => e.Name).HasMaxLength(100);
                entity.Property(e => e.Number).HasMaxLength(200);
                entity.Property(e => e.RegDate)
                    .HasDefaultValueSql("(getdate())")
                    .HasColumnType("datetime");
                entity.Property(e => e.RegIp).HasMaxLength(100);
            });

            modelBuilder.Entity<TB_BOARD_DATA>(entity =>
            {
                entity.HasKey(e => e.UID).HasFillFactor(90);

                entity.HasIndex(e => e.APPR, "IX_TB_BOARD_DATA_APPR").HasFillFactor(90);

                entity.HasIndex(e => e.BOARD_CODE, "IX_TB_BOARD_DATA_BOARD_CODE").HasFillFactor(90);

                entity.HasIndex(e => e.Cat, "IX_TB_BOARD_DATA_Cat").HasFillFactor(90);

                entity.HasIndex(e => e.DEPTH, "IX_TB_BOARD_DATA_DEPTH").HasFillFactor(90);

                entity.HasIndex(e => e.Deleted, "IX_TB_BOARD_DATA_Deleted").HasFillFactor(90);

                entity.HasIndex(e => e.GRP, "IX_TB_BOARD_DATA_GRP")
                    .IsDescending()
                    .HasFillFactor(90);

                entity.HasIndex(e => e.NOTICE, "IX_TB_BOARD_DATA_NOTICE").HasFillFactor(90);

                entity.HasIndex(e => e.N_DATE1, "IX_TB_BOARD_DATA_N_DATE1")
                    .IsDescending()
                    .HasFillFactor(90);

                entity.HasIndex(e => e.N_DATE2, "IX_TB_BOARD_DATA_N_DATE2")
                    .IsDescending()
                    .HasFillFactor(90);

                entity.HasIndex(e => e.REG_DATE, "IX_TB_BOARD_DATA_REG_DATE")
                    .IsDescending()
                    .HasFillFactor(90);

                entity.HasIndex(e => e.REG_ID, "IX_TB_BOARD_DATA_REG_ID").HasFillFactor(90);

                entity.HasIndex(e => e.SEQ, "IX_TB_BOARD_DATA_SEQ").HasFillFactor(90);

                entity.HasIndex(e => e.UpCat, "IX_TB_BOARD_DATA_UpCat").HasFillFactor(90);

                entity.Property(e => e.APPR).HasMaxLength(1);
                entity.Property(e => e.APPR_USER).HasMaxLength(100);
                entity.Property(e => e.Admin_YN).HasMaxLength(1);
                entity.Property(e => e.BOARD_CODE).HasMaxLength(20);
                entity.Property(e => e.Cat).HasMaxLength(20);
                entity.Property(e => e.Deleted)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasDefaultValue("N")
                    .IsFixedLength();
                entity.Property(e => e.FIRST_WORD).HasMaxLength(50);
                entity.Property(e => e.LINK1).HasMaxLength(200);
                entity.Property(e => e.LINK2).HasMaxLength(200);
                entity.Property(e => e.LIST_IMAGE_NAME).HasMaxLength(200);
                entity.Property(e => e.LIST_IMAGE_RENAME).HasMaxLength(200);
                entity.Property(e => e.MOD_DATE).HasColumnType("smalldatetime");
                entity.Property(e => e.MOD_ID).HasMaxLength(200);
                entity.Property(e => e.NOTICE).HasMaxLength(5);
                entity.Property(e => e.N_DATE1).HasMaxLength(10);
                entity.Property(e => e.N_DATE2).HasMaxLength(10);
                entity.Property(e => e.REG_DATE).HasColumnType("smalldatetime");
                entity.Property(e => e.REG_EMAIL).HasMaxLength(100);
                entity.Property(e => e.REG_FILE_NAME).HasMaxLength(1000);
                entity.Property(e => e.REG_FILE_RENAME).HasMaxLength(1000);
                entity.Property(e => e.REG_HP).HasMaxLength(20);
                entity.Property(e => e.REG_ID).HasMaxLength(200);
                entity.Property(e => e.REG_IP).HasMaxLength(30);
                entity.Property(e => e.REG_NAME).HasMaxLength(30);
                entity.Property(e => e.REG_PW).HasMaxLength(100);
                entity.Property(e => e.REG_SUBJECT).HasMaxLength(100);
                entity.Property(e => e.Read_ID).HasMaxLength(50);
                entity.Property(e => e.SECRET).HasMaxLength(1);
                entity.Property(e => e.Tag0)
                    .HasMaxLength(10)
                    .HasDefaultValue("");
                entity.Property(e => e.Tag1)
                    .HasMaxLength(10)
                    .HasDefaultValue("");
                entity.Property(e => e.Tag2)
                    .HasMaxLength(10)
                    .HasDefaultValue("");
                entity.Property(e => e.UpCat).HasMaxLength(20);
                entity.Property(e => e.YOUTUBE_URL).HasMaxLength(200);
                entity.Property(e => e.dEmail)
                    .HasMaxLength(100)
                    .HasComment("리플_담당자이메일");
                entity.Property(e => e.dName)
                    .HasMaxLength(30)
                    .HasComment("리플_담당자이름");
                entity.Property(e => e.dPhone)
                    .HasMaxLength(20)
                    .HasComment("리플_담당자연락처");
                entity.Property(e => e.wEmail).HasMaxLength(100);
                entity.Property(e => e.wKakaoID).HasMaxLength(100);
                entity.Property(e => e.wName).HasMaxLength(30);
                entity.Property(e => e.wPhone).HasMaxLength(20);
                entity.Property(e => e.wType)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasDefaultValue("0")
                    .IsFixedLength();
            });

            modelBuilder.Entity<VwCategory>(entity =>
            {
                entity
                    .HasNoKey()
                    .ToView("VW_CATEGORY");

                entity.Property(e => e.AcapaUnit)
                    .HasMaxLength(10)
                    .HasColumnName("ACapaUnit");
                entity.Property(e => e.Acate).HasColumnName("ACATE");
                entity.Property(e => e.Acateeng)
                    .HasMaxLength(50)
                    .HasColumnName("ACATEENG");
                entity.Property(e => e.Acatename)
                    .HasMaxLength(50)
                    .HasColumnName("ACATENAME");
                entity.Property(e => e.Amold)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("AMold");
                entity.Property(e => e.Aoem)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("AOEM");
                entity.Property(e => e.Asm)
                    .HasMaxLength(1)
                    .IsUnicode(false);
                entity.Property(e => e.BcapaUnit)
                    .HasMaxLength(10)
                    .HasColumnName("BCapaUnit");
                entity.Property(e => e.Bcate).HasColumnName("BCATE");
                entity.Property(e => e.Bcateeng)
                    .HasMaxLength(50)
                    .HasColumnName("BCATEENG");
                entity.Property(e => e.Bcatename)
                    .HasMaxLength(50)
                    .HasColumnName("BCATENAME");
                entity.Property(e => e.Bmold)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("BMold");
                entity.Property(e => e.Boem)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("BOEM");
                entity.Property(e => e.Bsm)
                    .HasMaxLength(1)
                    .IsUnicode(false);
                entity.Property(e => e.Ccate).HasColumnName("CCATE");
                entity.Property(e => e.Ccateeng)
                    .HasMaxLength(50)
                    .HasColumnName("CCATEENG");
                entity.Property(e => e.Ccatename)
                    .HasMaxLength(50)
                    .HasColumnName("CCATENAME");
            });

            modelBuilder.Entity<VwCategoryList>(entity =>
            {
                entity
                    .HasNoKey()
                    .ToView("VW_CATEGORY_LIST");

                entity.Property(e => e.CapaUnit).HasMaxLength(10);
                entity.Property(e => e.Cat1Eng).HasMaxLength(50);
                entity.Property(e => e.Cat1Name).HasMaxLength(50);
                entity.Property(e => e.Cat2Eng).HasMaxLength(50);
                entity.Property(e => e.Cat2Name).HasMaxLength(50);
                entity.Property(e => e.CatDepth)
                    .HasMaxLength(1)
                    .IsUnicode(false);
                entity.Property(e => e.CatName).HasMaxLength(103);
                entity.Property(e => e.Mold)
                    .HasMaxLength(2)
                    .IsUnicode(false);
                entity.Property(e => e.Oem)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasColumnName("OEM");
                entity.Property(e => e.StandardMold)
                    .HasMaxLength(1)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<VwCategorySm>(entity =>
            {
                entity
                    .HasNoKey()
                    .ToView("VW_CATEGORY_SM");

                entity.Property(e => e.CapaUnit).HasMaxLength(1);
                entity.Property(e => e.Cat1Eng).HasMaxLength(50);
                entity.Property(e => e.Cat2Eng).HasMaxLength(50);
                entity.Property(e => e.CatDepth)
                    .HasMaxLength(1)
                    .IsUnicode(false);
                entity.Property(e => e.CatEng).HasMaxLength(103);
                entity.Property(e => e.Mold)
                    .HasMaxLength(2)
                    .IsUnicode(false);
                entity.Property(e => e.Oem)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasColumnName("OEM");
                entity.Property(e => e.StandardMold)
                    .HasMaxLength(2)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<VwCatprodChain>(entity =>
            {
                entity
                    .HasNoKey()
                    .ToView("VW_CATPROD_CHAIN");

                entity.Property(e => e.PCategory)
                    .HasMaxLength(100)
                    .HasColumnName("P_CATEGORY");
                entity.Property(e => e.ProdUid).HasColumnName("PROD_UID");
                entity.Property(e => e.Val).HasMaxLength(100);
            });

            modelBuilder.Entity<VwMemberList>(entity =>
            {
                entity
                    .HasNoKey()
                    .ToView("VW_MEMBER_LIST");

                entity.Property(e => e.Approval)
                    .HasMaxLength(1)
                    .HasColumnName("APPROVAL");
                entity.Property(e => e.ApprovalView)
                    .HasMaxLength(1)
                    .HasColumnName("APPROVAL_VIEW");
                entity.Property(e => e.ArrName)
                    .HasMaxLength(200)
                    .HasColumnName("arrNAME");
                entity.Property(e => e.Email)
                    .HasMaxLength(500)
                    .HasColumnName("EMAIL");
                entity.Property(e => e.EndLoginDate)
                    .HasColumnType("smalldatetime")
                    .HasColumnName("END_LOGIN_DATE");
                entity.Property(e => e.Gubun).HasColumnName("GUBUN");
                entity.Property(e => e.MemberId)
                    .HasMaxLength(50)
                    .HasColumnName("MEMBER_ID");
                entity.Property(e => e.Mobile)
                    .HasMaxLength(200)
                    .HasColumnName("MOBILE");
                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .HasColumnName("NAME");
                entity.Property(e => e.RegDate)
                    .HasColumnType("smalldatetime")
                    .HasColumnName("REG_DATE");
                entity.Property(e => e.Uid).HasColumnName("UID");
                entity.Property(e => e.VisitCnt).HasColumnName("VISIT_CNT");
            });

            modelBuilder.Entity<VwNcategory>(entity =>
            {
                entity
                    .HasNoKey()
                    .ToView("VW_NCATEGORY");

                entity.Property(e => e.Acode)
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasColumnName("ACode");
                entity.Property(e => e.Adepth).HasColumnName("ADepth");
                entity.Property(e => e.Aname)
                    .HasMaxLength(50)
                    .HasColumnName("AName");
                entity.Property(e => e.Aord).HasColumnName("AOrd");
                entity.Property(e => e.Bcode)
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasColumnName("BCode");
                entity.Property(e => e.Bdepth).HasColumnName("BDepth");
                entity.Property(e => e.Bname)
                    .HasMaxLength(50)
                    .HasColumnName("BName");
                entity.Property(e => e.Bord).HasColumnName("BOrd");
                entity.Property(e => e.Ccode)
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasColumnName("CCode");
                entity.Property(e => e.Cdepth).HasColumnName("CDepth");
                entity.Property(e => e.Cname)
                    .HasMaxLength(50)
                    .HasColumnName("CName");
                entity.Property(e => e.Cord).HasColumnName("COrd");
                entity.Property(e => e.Name).HasMaxLength(156);
            });

            modelBuilder.Entity<VwNcategoryList>(entity =>
            {
                entity
                    .HasNoKey()
                    .ToView("VW_NCATEGORY_LIST");

                entity.Property(e => e.Acode)
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasColumnName("ACode");
                entity.Property(e => e.Aeng)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("AEng");
                entity.Property(e => e.Akor)
                    .HasMaxLength(50)
                    .HasColumnName("AKor");
                entity.Property(e => e.Aord).HasColumnName("AOrd");
                entity.Property(e => e.Bcode)
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasColumnName("BCode");
                entity.Property(e => e.Beng)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("BEng");
                entity.Property(e => e.Bkor)
                    .HasMaxLength(50)
                    .HasColumnName("BKor");
                entity.Property(e => e.Bord).HasColumnName("BOrd");
                entity.Property(e => e.CatName).HasMaxLength(156);
                entity.Property(e => e.Ccode)
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasColumnName("CCode");
                entity.Property(e => e.Ceng)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("CEng");
                entity.Property(e => e.Ckor)
                    .HasMaxLength(50)
                    .HasColumnName("CKor");
                entity.Property(e => e.Code)
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .IsFixedLength();
                entity.Property(e => e.Cord).HasColumnName("COrd");
                entity.Property(e => e.StdMld)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();
                entity.Property(e => e.UpCode)
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .IsFixedLength();
            });

            modelBuilder.Entity<VwProductList>(entity =>
            {
                entity
                    .HasNoKey()
                    .ToView("VW_PRODUCT_LIST");

                entity.Property(e => e.Cat)
                    .HasMaxLength(100)
                    .IsUnicode(false);
                entity.Property(e => e.CoId)
                    .HasMaxLength(20)
                    .HasColumnName("CO_ID");
                entity.Property(e => e.Deleted)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();
                entity.Property(e => e.ItId)
                    .HasMaxLength(20)
                    .HasColumnName("it_id");
                entity.Property(e => e.MemberGubun)
                    .HasMaxLength(1)
                    .HasColumnName("MEMBER_GUBUN");
                entity.Property(e => e.MemberUid).HasColumnName("MEMBER_UID");
                entity.Property(e => e.PAppdate)
                    .HasColumnType("smalldatetime")
                    .HasColumnName("P_APPDATE");
                entity.Property(e => e.PApproval)
                    .HasMaxLength(1)
                    .HasColumnName("P_APPROVAL");
                entity.Property(e => e.PCapUnit)
                    .HasMaxLength(10)
                    .HasColumnName("P_CAP_UNIT");
                entity.Property(e => e.PCapacity).HasColumnName("P_CAPACITY");
                entity.Property(e => e.PCategory)
                    .HasMaxLength(100)
                    .HasColumnName("P_CATEGORY");
                entity.Property(e => e.PCode)
                    .HasMaxLength(100)
                    .HasColumnName("P_CODE");
                entity.Property(e => e.PCodeEn)
                    .HasMaxLength(100)
                    .HasColumnName("P_CODE_EN");
                entity.Property(e => e.PHit).HasColumnName("P_HIT");
                entity.Property(e => e.PHot)
                    .HasMaxLength(1)
                    .HasColumnName("P_HOT");
                entity.Property(e => e.PImg1)
                    .HasMaxLength(100)
                    .HasColumnName("P_IMG1");
                entity.Property(e => e.PImg2)
                    .HasMaxLength(100)
                    .HasColumnName("P_IMG2");
                entity.Property(e => e.PImg3)
                    .HasMaxLength(100)
                    .HasColumnName("P_IMG3");
                entity.Property(e => e.PImg4)
                    .HasMaxLength(100)
                    .HasColumnName("P_IMG4");
                entity.Property(e => e.PImg5)
                    .HasMaxLength(100)
                    .HasColumnName("P_IMG5");
                entity.Property(e => e.PImg6)
                    .HasMaxLength(100)
                    .HasColumnName("P_IMG6");
                entity.Property(e => e.PMemo).HasColumnName("P_MEMO");
                entity.Property(e => e.PMemo2).HasColumnName("P_MEMO2");
                entity.Property(e => e.PMemoEng).HasColumnName("P_MEMO_ENG");
                entity.Property(e => e.PModdate)
                    .HasColumnType("smalldatetime")
                    .HasColumnName("P_MODDATE");
                entity.Property(e => e.PMoq).HasColumnName("P_MOQ");
                entity.Property(e => e.PMoqDeal)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasColumnName("P_MOQ_DEAL");
                entity.Property(e => e.PName)
                    .HasMaxLength(100)
                    .HasColumnName("P_NAME");
                entity.Property(e => e.PName2)
                    .HasMaxLength(100)
                    .HasColumnName("P_NAME2");
                entity.Property(e => e.PNew)
                    .HasMaxLength(1)
                    .HasColumnName("P_NEW");
                entity.Property(e => e.POrigin)
                    .HasMaxLength(50)
                    .HasColumnName("P_ORIGIN");
                entity.Property(e => e.PQuality)
                    .HasMaxLength(100)
                    .HasColumnName("P_QUALITY");
                entity.Property(e => e.PRegdate)
                    .HasColumnType("smalldatetime")
                    .HasColumnName("P_REGDATE");
                entity.Property(e => e.PSeq).HasColumnName("P_SEQ");
                entity.Property(e => e.PSize)
                    .HasMaxLength(100)
                    .HasColumnName("P_SIZE");
                entity.Property(e => e.PUse)
                    .HasMaxLength(1)
                    .HasColumnName("P_USE");
                entity.Property(e => e.PUseSt)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasColumnName("P_USE_ST");
                entity.Property(e => e.ProdType)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();
                entity.Property(e => e.ProdUid)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("PROD_UID");
                entity.Property(e => e.UpCat)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<VwProductListSm>(entity =>
            {
                entity
                    .HasNoKey()
                    .ToView("VW_PRODUCT_LIST_SM");

                entity.Property(e => e.Cat)
                    .HasMaxLength(100)
                    .IsUnicode(false);
                entity.Property(e => e.CoId)
                    .HasMaxLength(20)
                    .HasColumnName("CO_ID");
                entity.Property(e => e.Deleted)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();
                entity.Property(e => e.IsPcr)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasColumnName("isPCR");
                entity.Property(e => e.IsRefill)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasColumnName("isRefill");
                entity.Property(e => e.ItId)
                    .HasMaxLength(20)
                    .HasColumnName("it_id");
                entity.Property(e => e.MemberGubun)
                    .HasMaxLength(1)
                    .HasColumnName("MEMBER_GUBUN");
                entity.Property(e => e.MemberUid).HasColumnName("MEMBER_UID");
                entity.Property(e => e.PAppdate)
                    .HasColumnType("smalldatetime")
                    .HasColumnName("P_APPDATE");
                entity.Property(e => e.PApproval)
                    .HasMaxLength(1)
                    .HasColumnName("P_APPROVAL");
                entity.Property(e => e.PCapUnit)
                    .HasMaxLength(10)
                    .HasColumnName("P_CAP_UNIT");
                entity.Property(e => e.PCapacity).HasColumnName("P_CAPACITY");
                entity.Property(e => e.PCategory)
                    .HasMaxLength(100)
                    .HasColumnName("P_CATEGORY");
                entity.Property(e => e.PCode)
                    .HasMaxLength(100)
                    .HasColumnName("P_CODE");
                entity.Property(e => e.PCodeEn)
                    .HasMaxLength(100)
                    .HasColumnName("P_CODE_EN");
                entity.Property(e => e.PHit).HasColumnName("P_HIT");
                entity.Property(e => e.PHot)
                    .HasMaxLength(1)
                    .HasColumnName("P_HOT");
                entity.Property(e => e.PImg1)
                    .HasMaxLength(100)
                    .HasColumnName("P_IMG1");
                entity.Property(e => e.PImg2)
                    .HasMaxLength(100)
                    .HasColumnName("P_IMG2");
                entity.Property(e => e.PImg3)
                    .HasMaxLength(100)
                    .HasColumnName("P_IMG3");
                entity.Property(e => e.PImg4)
                    .HasMaxLength(100)
                    .HasColumnName("P_IMG4");
                entity.Property(e => e.PImg5)
                    .HasMaxLength(100)
                    .HasColumnName("P_IMG5");
                entity.Property(e => e.PImg6)
                    .HasMaxLength(100)
                    .HasColumnName("P_IMG6");
                entity.Property(e => e.PMemo).HasColumnName("P_MEMO");
                entity.Property(e => e.PMemo2).HasColumnName("P_MEMO2");
                entity.Property(e => e.PMemoEng).HasColumnName("P_MEMO_ENG");
                entity.Property(e => e.PModdate)
                    .HasColumnType("smalldatetime")
                    .HasColumnName("P_MODDATE");
                entity.Property(e => e.PMoq).HasColumnName("P_MOQ");
                entity.Property(e => e.PMoqDeal)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasColumnName("P_MOQ_DEAL");
                entity.Property(e => e.PName)
                    .HasMaxLength(100)
                    .HasColumnName("P_NAME");
                entity.Property(e => e.PName2)
                    .HasMaxLength(100)
                    .HasColumnName("P_NAME2");
                entity.Property(e => e.PNew)
                    .HasMaxLength(1)
                    .HasColumnName("P_NEW");
                entity.Property(e => e.POrigin)
                    .HasMaxLength(50)
                    .HasColumnName("P_ORIGIN");
                entity.Property(e => e.PQuality)
                    .HasMaxLength(100)
                    .HasColumnName("P_QUALITY");
                entity.Property(e => e.PRegdate)
                    .HasColumnType("smalldatetime")
                    .HasColumnName("P_REGDATE");
                entity.Property(e => e.PSeq).HasColumnName("P_SEQ");
                entity.Property(e => e.PSize)
                    .HasMaxLength(100)
                    .HasColumnName("P_SIZE");
                entity.Property(e => e.PUse)
                    .HasMaxLength(1)
                    .HasColumnName("P_USE");
                entity.Property(e => e.PUseSt)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasColumnName("P_USE_ST");
                entity.Property(e => e.ProdType)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();
                entity.Property(e => e.ProdUid).HasColumnName("PROD_UID");
                entity.Property(e => e.UpCat)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<UspKbeautyProductModel>(entity =>
            {
                entity.HasNoKey();   // 필수
                entity.ToView(null); // 실제 뷰 연결 없음 (Stored Procedure 결과 전용)
            });


            //Stored Procedure 결과 매핑용 DTO 등록
            modelBuilder.Entity<UspconnectionModel>(entity =>
            {
                entity.HasNoKey();
                entity.ToView(null); 
            });
        }
    }
}
