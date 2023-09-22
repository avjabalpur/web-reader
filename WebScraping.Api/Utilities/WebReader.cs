using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace WebScraping.Api.Utilities
{
    public class WebReader
    {
        private IWebDriver driver;

        public WebReader()
        {
            var chromeOptions = new ChromeOptions();
            chromeOptions.AddArgument("--headless");
            driver = new ChromeDriver(chromeOptions);
        }

        public string ReadWebsite(string url, string username, string password)
        {
            try
            {
                driver.Navigate().GoToUrl(url);

                if (!string.IsNullOrEmpty(username) && !string.IsNullOrEmpty(password))
                {
                    var usernameField = driver.FindElement(By.Id("email"));
                    var passwordField = driver.FindElement(By.Id("pass"));
                    var loginButton = driver.FindElement(By.Name("login"));

                    usernameField.SendKeys(username);
                    passwordField.SendKeys(password);

                    loginButton.Click();

                    Thread.Sleep(3000);
                    if (driver.PageSource == null)
                    {
                        // Wait more becaue login is not completed yet
                        Thread.Sleep(3000);
                    }
                    var contentElement = driver.FindElement(By.Id("content_id"));
                    return contentElement.Text;
                }

                Thread.Sleep(2000);
                var pageSource = driver.PageSource;
                return pageSource;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public void Close()
        {
            driver.Quit();
        }

    }
}
