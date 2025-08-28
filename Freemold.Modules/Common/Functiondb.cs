
using Microsoft.EntityFrameworkCore;

namespace Freemold.Modules.Common
{
    public  class Functiondb
    {
        private readonly AppDbContext _appdbcontext;

        public Functiondb(AppDbContext appdbcontext)
        {
            _appdbcontext = appdbcontext;
        }

        public  async Task<string> GetCategoryFullname(string catagory)
        {

            if (string.IsNullOrWhiteSpace(catagory))
                return string.Empty;

            string result = string.Empty;

            catagory = catagory.Replace(";;", ",");
            catagory = catagory.Replace(";", "");

            string[] arrCatNameList = Util.strSplit(catagory, ',');
            if (arrCatNameList.Length == 0) return string.Empty;


            var parts = new List<string>(arrCatNameList.Length);

            foreach (var item in arrCatNameList)
            {
                var value = await _appdbcontext.Database
                .SqlQuery<string>($"SELECT dbo.FN_NCATEGORY_FULLNAME({item})")
                .SingleAsync();

                if (!string.IsNullOrEmpty(value))
                    parts.Add(value);
            }

            return string.Join("|", parts);
        }
    }
}
