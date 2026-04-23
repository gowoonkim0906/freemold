using Microsoft.AspNetCore.Http;
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

        Task SaveWithWatermarkAsync(IFormFile inputFile,Stream outStream,string logoPath,string originalExt,double opacity = 0.35,double _scaleIgnored = 0.0,int? _padIgnored = null);
        Task SaveWithWatermarkAsync2(IFormFile inputFile,Stream outStream,string logoPath,string originalExt,double opacity = 0.30,double tileScale = 0.20,int? gapPx = null);
        Task<string> Searchfile(IFormFile searchfile, string userId);
        Task<int> DeleteVectorimg(int[] prod_uid);
        Task<int> DeleteVectorimgDev(int[] prod_uid);


    }
}
