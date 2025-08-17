using Microsoft.Playwright;
using NUnit.Framework;
using System.IO;
using System.Threading.Tasks;

namespace TestProject1
{
    [TestFixture]
    public class Setup : BaseConfig
    {
        [Test]
        public async Task Test1()
        {
            // Create directory for videos if it doesn't exist


            // Page
            var page = await context.NewPageAsync();
            await page.GotoAsync("http://eaapp.somee.com/");

            // Click login link
            await page.ClickAsync("#loginLink");

            // Wait for a few seconds (simulate some activity)

            await Task.Delay(2000);

            await page.Locator("//input[@id='UserName']").FillAsync("admin");
            await page.Locator("//input[@id='Password']").FillAsync("password");           // Close context to save video
            await page.Locator("//input[@id='loginIn']").ClickAsync();
            await page.Locator("//*[@class='nav navbar-nav navbar-right']/li[2]").ClickAsync();

            await page.WaitForTimeoutAsync(10000);
            await context.CloseAsync();
        }
    }
}
