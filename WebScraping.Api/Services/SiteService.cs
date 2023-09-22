using Microsoft.AspNetCore.Builder.Extensions;
using Microsoft.Extensions.Options;
using WebScraping.Core;
using WebScraping.Core.Options;
using WebScraping.Core.Services;

namespace WebScraping.Api.Services
{
    public class SiteService : ISiteService
    {
        private readonly SiteOptions _appOptions;

        public SiteService(IOptions<SiteOptions> appOptions)
        {
            _appOptions = appOptions.Value;
        }
        public Site GetSite(State state)
        {
            return _appOptions.Sites?.FirstOrDefault(x => x.State == state);
        }
    }
}
