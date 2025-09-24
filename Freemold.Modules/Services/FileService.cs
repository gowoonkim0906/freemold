using Freemold.Modules.Models;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.Hosting;

namespace Freemold.Modules.Services
{
    public class FileService : IFileService
    {
        private readonly string _root;
        private IHostEnvironment _env;

        public FileService(IOptions<StorageOptions> opts, IHostEnvironment env) {

            var raw = opts.Value.RootPath;
            _root = Path.GetFullPath(string.IsNullOrWhiteSpace(raw)
                ? Path.Combine(env.ContentRootPath, "Data")   // 폴백
                : raw);

            Directory.CreateDirectory(_root); // 경로 보장



            _env = env;
        }


        public string RootPath => _root;

        public string WebRoot => Path.Combine(_env.ContentRootPath, "wwwroot");
    }
}
