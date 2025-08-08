using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Freemold.Modules.Models
{
    public class InquiryModel
    {
        public int Idx { get; set; }

        public int PIdx { get; set; }

        public string? Name { get; set; }

        public string? Email { get; set; }

        public string? Company { get; set; }

        public string? Inquiry { get; set; }

        public string? RegCountry { get; set; }

        public DateTime RegDate { get; set; }
        public string? ProductName { get; set; }
    }

    public class InquiryViewModel
    {
        public int pidx { get; set; }
        public string? name { get; set; }

        public string? company { get; set; }

        public string? inquiry { get; set; }

        public string? regCountry { get; set; }

        public string? RegDate { get; set; }
    }

    public class ProductModel
    {
        public string? pimg1 { get; set; }

        public string? pname { get; set; }

        public string? pcode { get; set; }

        public double pcapacity { get; set; }

        public string? pcapunit { get; set; }

        public string? psize { get; set; }
        public string? pquality { get; set; }
        public int memberuid { get; set; }
        public string? company_name { get; set; }
    }
}
