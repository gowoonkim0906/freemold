using Freemold.Modules.Models;
using Freemold.Modules.Services;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using System.Text;
using System.Text.Json;

namespace Freemold.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [EnableCors("PublicCors")]
    public class ProductController : Controller
    {
        
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IFileService _fileService;

        public ProductController(IHttpClientFactory httpClientFactory, IFileService fileService)
        {
            _httpClientFactory = httpClientFactory;
            this._fileService = fileService;    
        }


        [HttpPost("fileInsertdirVector")]
        public async Task<IActionResult> FileInsertDirVector([FromBody] FileInsertVectorRequest req)
        {
            if (req == null || req.uid == null || req.uid.Length == 0)
                return BadRequest(new { ok = false, message = "UID 데이터가 없습니다." });

            var payload = new { prod_uids = req.uid };
            const string pythonApiUrl = "http://127.0.0.1:8060/sync-vectors/";

            var client = _httpClientFactory.CreateClient();
            client.Timeout = TimeSpan.FromSeconds(60);

            HttpResponseMessage resp;
            string respText;

            try
            {
                // prod_uids 키가 그대로 나가도록 (혹시 정책 때문에 바뀌는 경우 방지)
                var jsonOpt = new JsonSerializerOptions
                {
                    PropertyNamingPolicy = null
                };

                resp = await client.PostAsJsonAsync(pythonApiUrl, payload, jsonOpt);
                respText = await resp.Content.ReadAsStringAsync();
            }
            catch (TaskCanceledException ex)
            {
                return StatusCode(StatusCodes.Status504GatewayTimeout, new
                {
                    ok = false,
                    message = "Python API timeout.",
                    error = ex.Message
                });
            }
            catch (HttpRequestException ex)
            {
                return StatusCode(StatusCodes.Status502BadGateway, new
                {
                    ok = false,
                    message = "Python API request failed.",
                    error = ex.Message
                });
            }

            if (resp.IsSuccessStatusCode)
            {
                return Ok(new
                {
                    ok = true,
                    message = "Python sync-vectors called.",
                    uid = req.uid,
                    pythonStatus = (int)resp.StatusCode,
                    pythonBody = respText
                });
            }

            return StatusCode(StatusCodes.Status502BadGateway, new
            {
                ok = false,
                message = "Python API returned error.",
                uid = req.uid,
                pythonStatus = (int)resp.StatusCode,
                pythonBody = respText
            });
        }

        [HttpPost("fileInserturlVector")]
        public async Task<IActionResult> FileInsertUrlVector([FromBody] FileInsertVectorRequest req)
        {
            if (req == null || req.uid == null || req.uid.Length == 0)
                return BadRequest(new { ok = false, message = "UID 데이터가 없습니다." });

            var payload = new { prod_uids = req.uid };
            const string pythonApiUrl = "http://211.233.64.26:8060/sync-vectors/";

            var client = _httpClientFactory.CreateClient();
            client.Timeout = TimeSpan.FromSeconds(60);

            HttpResponseMessage resp;
            string respText;

            try
            {
                // prod_uids 키가 그대로 나가도록 (혹시 정책 때문에 바뀌는 경우 방지)
                var jsonOpt = new JsonSerializerOptions
                {
                    PropertyNamingPolicy = null
                };

                resp = await client.PostAsJsonAsync(pythonApiUrl, payload, jsonOpt);
                respText = await resp.Content.ReadAsStringAsync();
            }
            catch (TaskCanceledException ex)
            {
                return StatusCode(StatusCodes.Status504GatewayTimeout, new
                {
                    ok = false,
                    message = "Python API timeout.",
                    error = ex.Message
                });
            }
            catch (HttpRequestException ex)
            {
                return StatusCode(StatusCodes.Status502BadGateway, new
                {
                    ok = false,
                    message = "Python API request failed.",
                    error = ex.Message
                });
            }

            if (resp.IsSuccessStatusCode)
            {
                return Ok(new
                {
                    ok = true,
                    message = "Python sync-vectors called.",
                    uid = req.uid,
                    pythonStatus = (int)resp.StatusCode,
                    pythonBody = respText
                });
            }

            return StatusCode(StatusCodes.Status502BadGateway, new
            {
                ok = false,
                message = "Python API returned error.",
                uid = req.uid,
                pythonStatus = (int)resp.StatusCode,
                pythonBody = respText
            });
        }

        [HttpPost("fileInserturlVectorDev")]
        public async Task<IActionResult> FileInsertUrlVectorDev([FromBody] FileInsertVectorRequest req)
        {
            if (req == null || req.uid == null || req.uid.Length == 0)
                return BadRequest(new { ok = false, message = "UID 데이터가 없습니다." });

            var payload = new { prod_uids = req.uid };
            const string pythonApiUrl = "http://211.233.64.26:8060/sync-vectors_dev/";

            var client = _httpClientFactory.CreateClient();
            client.Timeout = TimeSpan.FromSeconds(60);

            HttpResponseMessage resp;
            string respText;

            try
            {
                // prod_uids 키가 그대로 나가도록 (혹시 정책 때문에 바뀌는 경우 방지)
                var jsonOpt = new JsonSerializerOptions
                {
                    PropertyNamingPolicy = null
                };

                resp = await client.PostAsJsonAsync(pythonApiUrl, payload, jsonOpt);
                respText = await resp.Content.ReadAsStringAsync();
            }
            catch (TaskCanceledException ex)
            {
                return StatusCode(StatusCodes.Status504GatewayTimeout, new
                {
                    ok = false,
                    message = "Python API timeout.",
                    error = ex.Message
                });
            }
            catch (HttpRequestException ex)
            {
                return StatusCode(StatusCodes.Status502BadGateway, new
                {
                    ok = false,
                    message = "Python API request failed.",
                    error = ex.Message
                });
            }

            if (resp.IsSuccessStatusCode)
            {
                return Ok(new
                {
                    ok = true,
                    message = "Python sync-vectors called.",
                    uid = req.uid,
                    pythonStatus = (int)resp.StatusCode,
                    pythonBody = respText
                });
            }

            return StatusCode(StatusCodes.Status502BadGateway, new
            {
                ok = false,
                message = "Python API returned error.",
                uid = req.uid,
                pythonStatus = (int)resp.StatusCode,
                pythonBody = respText
            });
        }


        [HttpPost("fileDeleteVector")]
        public async Task<IActionResult> FileDeleteVector([FromBody] FileDeleteVectorRequest req)
        {
            try
            {
                int result = await _fileService.DeleteVectorimg(req.prod_uid);

                if (result > 0)
                {
                    return Ok(new
                    {
                        ok = true,
                        message = "success"
                    });
                }
                else
                {
                    return StatusCode(StatusCodes.Status502BadGateway, new
                    {
                        ok = false,
                        message = "Python API returned error."
                    });
                }
            }
            catch (Exception ex) {
                return StatusCode(StatusCodes.Status502BadGateway, new
                {
                    ok = false,
                    message = ex.Message
                });
            }
            
        }

        [HttpPost("fileDeleteVectorDev")]
        public async Task<IActionResult> FileDeleteVectorDev([FromBody] FileDeleteVectorRequest req)
        {
            try
            {
                int result = await _fileService.DeleteVectorimgDev(req.prod_uid);

                if (result > 0)
                {
                    return Ok(new
                    {
                        ok = true,
                        message = "success"
                    });
                }
                else
                {
                    return StatusCode(StatusCodes.Status502BadGateway, new
                    {
                        ok = false,
                        message = "Python API returned error."
                    });
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status502BadGateway, new
                {
                    ok = false,
                    message = ex.Message
                });
            }

        }

        [HttpPost("fileSearchVector")]
        public async Task<IActionResult> fileSearchVector([FromForm] FileSearchVectionRequest req)
        {
            string rcode = "fail";
            string msg = string.Empty;
            string fileName = string.Empty;
            const string pythonApiUrl = "http://127.0.0.1:8060/search/path";

            var client = _httpClientFactory.CreateClient();
            client.Timeout = TimeSpan.FromSeconds(60);

            HttpResponseMessage resp;
            string respText;

            fileName = await _fileService.Searchfile(req.searchfile, req.userId);

            if (fileName == "No")
            {
                return StatusCode(StatusCodes.Status502BadGateway, new
                {
                    ok = false,
                    message = "파일저장에 실패하였습니다."
                });
            }
            else {

                try
                {
                    var payload = new { image_url = @"D:\img\save\"+fileName };

                    // prod_uids 키가 그대로 나가도록 (혹시 정책 때문에 바뀌는 경우 방지)
                    var jsonOpt = new JsonSerializerOptions
                    {
                        PropertyNamingPolicy = null
                    };

                    resp = await client.PostAsJsonAsync(pythonApiUrl, payload, jsonOpt);
                    respText = await resp.Content.ReadAsStringAsync();
                }
                catch (TaskCanceledException ex)
                {
                    return StatusCode(StatusCodes.Status504GatewayTimeout, new
                    {
                        ok = false,
                        message = "Python API timeout.",
                        error = ex.Message
                    });
                }
                catch (HttpRequestException ex)
                {
                    return StatusCode(StatusCodes.Status502BadGateway, new
                    {
                        ok = false,
                        message = "Python API request failed.",
                        error = ex.Message
                    });
                }

            }

            return Ok(new
            {
                ok = true,
                message = "업로드 완료"
            });
        }
    }
}
