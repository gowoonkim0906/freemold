using Freemold.Modules.Common;
using Freemold.Modules.Models;
using Freemold.Modules.Models.Table;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Freemold.Modules.Repositories
{

    public class BeautyRepository : BaseRepository
    {
        public BeautyRepository(AppDbContext _appdbcontext) : base(_appdbcontext)
        { }


        public IQueryable<ProductModel> GetProductList()
        {
            try
            {
                var query = from p in _appdbcontext.ProductLists
                            join c in _appdbcontext.Member1 on p.MEMBER_UID equals c.UID
                            select new ProductModel
                            {
                                PImg1 = p.P_IMG1,
                                Uid = c.UID,
                                CompanyName = c.COMPANY_NAME,
                                CompanyNameE = c.COMPANY_NAME_E,
                                PCode = p.P_CODE,
                                PCodeEn = p.P_CODE_EN,
                                PHit = p.P_HIT,
                                PCapacity = p.P_CAPACITY,
                                PCapUnit = p.P_CAP_UNIT,
                                PQuality = p.P_QUALITY,
                                QnaUse = c.QNA_USE,
                                ProdType = p.ProdType,
                                Visit = p.Visit,
                                UpCat = p.UpCat,
                                POrigin = p.P_ORIGIN,
                                IsRefill = p.isRefill,
                                IsPcr = p.isPCR,
                                IsMove = p.isMove,
                                Deleted = p.Deleted,
                                PApproval = p.P_APPROVAL,
                                PUse = p.P_USE,
                                Approval = c.APPROVAL,
                                ApprovalView = c.APPROVAL_VIEW,
                                StartDate = c.START_DATE,
                                EndDate = c.END_DATE,
                                PRegdate = p.P_REGDATE
                            };

                return query;
            }
            catch
            {
                throw;
            }
        }


        public async Task<string> ContactInsert(TB_ALLINKBEAUTY_CONTACT input, CancellationToken ct = default)
        {
            try
            {

                var entity = new TB_ALLINKBEAUTY_CONTACT
                {
                    FullName = input.FullName,
                    Email = input.Email,
                    Country = input.Country,
                    CompanyName = input.CompanyName,
                    TypeofService = input.TypeofService,
                    ProductCategory = input.ProductCategory,
                    TargetLaunchTimeline = input.TargetLaunchTimeline,
                    EstimatedOrderQuantity = input.EstimatedOrderQuantity,
                    BudgetRange = input.BudgetRange,
                    FormulaRequirements = input.FormulaRequirements,
                    PackagingPreferences = input.PackagingPreferences,
                    Notes = input.Notes,
                    RegDate = DateTime.Now,
                    RegIp = input.RegIp                                                         
                };

                await _appdbcontext.TB_ALLINKBEAUTY_CONTACT.AddAsync(entity, ct);
                var rows = await _appdbcontext.SaveChangesAsync(ct);

                return rows > 0 ? "success" : "fail";
            }
            catch (Exception ex)
            {
                _appdbcontext.ChangeTracker.Clear();
                return "fail";
            }

        }


        public async Task<string> ContactUsInsert(TB_ALLINKBEAUTY_CONTACT_US input, CancellationToken ct = default)
        {
            try
            {

                var entity = new TB_ALLINKBEAUTY_CONTACT_US
                {
                    Name = input.Name,
                    Email = input.Email,
                    Number = input.Number,
                    Detail = input.Detail,
                    RegDate = DateTime.Now,
                    RegIp = input.RegIp
                };

                await _appdbcontext.TB_ALLINKBEAUTY_CONTACT_US.AddAsync(entity, ct);
                var rows = await _appdbcontext.SaveChangesAsync(ct);

                return rows > 0 ? "success" : "fail";
            }
            catch (Exception ex)
            {
                _appdbcontext.ChangeTracker.Clear();
                return "fail";
            }

        }

        public IQueryable<TB_ALLINKBEAUTY_CONTACT_US> GetContactUsList()
        {
            try
            {
                var query = from c in _appdbcontext.TB_ALLINKBEAUTY_CONTACT_US
                            select c;


                return query;
            }
            catch
            {
                throw;
            }
        }


        public IQueryable<ContactModel> GetContactList()
        {
            try
            {
                var query =
                    from a in _appdbcontext.TB_ALLINKBEAUTY_CONTACT
                    join b in _appdbcontext.TbCodes
                        on a.Country equals b.Code
                    join c0 in _appdbcontext.TbCodes
                        on a.ProductCategory equals c0.Code into cJoin
                    from c in cJoin.DefaultIfEmpty()
                    join d0 in _appdbcontext.TbCodes
                        on a.TargetLaunchTimeline equals d0.Code into dJoin
                    from d in dJoin.DefaultIfEmpty()
                    join e0 in _appdbcontext.TbCodes
                        on a.EstimatedOrderQuantity equals e0.Code into eJoin
                    from e in eJoin.DefaultIfEmpty()
                    join f0 in _appdbcontext.TbCodes
                        on a.BudgetRange equals f0.Code into fJoin
                    from f in fJoin.DefaultIfEmpty()
                    where b.Sort == "국가코드_영문" && b.IsUse == "Y"
                       && (c == null || (c.Sort == "p_category" && c.IsUse == "Y"))
                       && (d == null || (d.Sort == "timeline" && d.IsUse == "Y"))
                       && (e == null || (e.Sort == "o_quantity" && e.IsUse == "Y"))
                       && (f == null || (f.Sort == "b_range" && f.IsUse == "Y"))
                    orderby a.Idx descending
                    select new ContactModel
                    {
                        idx = a.Idx,
                        fullname = a.FullName,
                        email = a.Email,
                        country = b != null ? b.Name : "",
                        companyname = a.CompanyName,
                        typeofservice = a.TypeofService,
                        productcategory = c != null ? c.Name : "",
                        targetlaunchtimeline = d != null ? d.Name : "",
                        estimatedorderquantity = e != null ? e.Name : "",
                        budgetrange = f != null ? f.Name : "",
                        formularequirements = a.FormulaRequirements,
                        packagingpreferences = a.PackagingPreferences,
                        notes = a.Notes,
                        regdate = a.RegDate
                    };


                return query;
            }
            catch
            {
                throw;
            }
        }
    }
}
