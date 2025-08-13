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
        public List<string> idxs { get; set; } = new List<string>();

    }
}
