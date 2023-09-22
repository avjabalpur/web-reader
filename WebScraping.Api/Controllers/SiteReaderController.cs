using Microsoft.AspNetCore.Mvc;
using WebScraping.Api.Services;
using WebScraping.Api.Utilities;
using WebScraping.Core;
using WebScraping.Core.Services;

namespace WebScraping.Api.Controllers
{
    [Route("api/site-reader")]
    [ApiController]
    public class SiteReaderController : ControllerBase
    {
        private readonly ILogger<SiteReaderController> _logger;
        private readonly ISiteService _siteService;
        public SiteReaderController(ILogger<SiteReaderController> logger, ISiteService siteService)
        {
            _logger = logger;
            _siteService = siteService;
        }

        [HttpGet]
        [Route("/")]
        public IActionResult GetSiteContant(State state)
        {
            _logger.LogInformation($"Getting the site contant of the state: ${state}");
            var site = _siteService.GetSite(state);
            if (site == null)
            {
                _logger.LogError($"State not configured of the state: ${state}, Plesae check to admin and retry.");

                throw new Exception("State site is not configured");
            }

            _logger.LogInformation($"Found the site of the state: ${state}");

            var webReader = new WebReader();

            _logger.LogInformation($"Reading the contant of the state: ${state}");

            string pageContent = webReader.ReadWebsite(site.SiteUrl, site.UserName, site.Password);
            Console.WriteLine(pageContent);

            webReader.Close();
            _logger.LogInformation($"Closed web reader of the state: ${state}");

            return StatusCode(StatusCodes.Status200OK, pageContent);
        }
    }
}