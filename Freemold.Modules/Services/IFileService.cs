using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Freemold.Modules.Services
{
    public interface IFileService
    {
        string RootPath { get; }
        string WebRoot { get; }
    }
}
