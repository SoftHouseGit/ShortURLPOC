using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ShortURLAPI.AppDbContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShortURLAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ShortUrlController : ControllerBase
    {

        private readonly ILogger<ShortUrlController> _logger;
        private readonly IShortLinkService _shortLinkService;
        public ShortUrlController(ILogger<ShortUrlController> logger, IShortLinkService shortLinkService)
        {
            _logger = logger;
            _shortLinkService = shortLinkService;
        }

        [HttpGet]
        [Route("GetShortURL")]
        public string GetShortURL(string longUrl)
        {
            try
            {
               return _shortLinkService.GenerateShortLink(longUrl) + "\n Copy this url and pass to the GetLongURL to get the long url";
            }
            catch (Exception ex)
            {
                throw; // This will show ReadAllLines in the stack trace
              //throw ex; This will show ReadAFile in the stack trace
            }

        }

        [HttpGet]
        [Route("GetLongURL")]
        public string GetLongURL(string shortUrl)
        {
            try
            {
                var url = _shortLinkService.GetLongLink(shortUrl);
                return url;
                // because of swagger we need to implement page to consume the api and redirect to the long url so we return url
                //if url not null
                //Response.Redirect(url); 
                //else // Redirect to not found page
            }
            catch (Exception ex)
            {
                throw; // This will show ReadAllLines in the stack trace
              //throw ex; This will show ReadAFile in the stack trace
            }

        }
    }
}
