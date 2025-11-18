using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Freemold.Modules.Models.Table
{
    public class ContactModel
    {
        public int idx { get; set; }
        public string fullname { get; set; } = null!;

        public string email { get; set; } = null!;

        public string country { get; set; } = null!;

        public string companyname { get; set; } = null!;

        public string typeofservice { get; set; } = null!;
        public string? productcategory { get; set; }

        public string? targetlaunchtimeline { get; set; }

        public string? estimatedorderquantity { get; set; }

        public string? budgetrange { get; set; }
        public string? formularequirements { get; set; }

        public string? packagingpreferences { get; set; }

        public string? notes { get; set; }
        public DateTime regdate { get; set; }
    }
}
