namespace WebScraping.Core
{
    public class Site
    {
        public State State { get; set; }
        public string SiteUrl { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string BodyIdentifier { get; set; }
    }
}