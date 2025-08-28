using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Freemold.Modules.Common
{
    public static class Util
    {

        public static string[] strSplit(string str , char type)
        {
            string[] result = str.Split(type, StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);

            return result;
        }


    }
}
