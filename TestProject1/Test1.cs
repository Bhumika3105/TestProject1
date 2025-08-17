using NUnit.Framework;
using Microsoft.Playwright;
using System.Threading.Tasks;

namespace TestProject1
{
    public class Tests
    {
        [Test]
        public async Task OpenGooglePage()
        {
            using var playwright = await Playwright.CreateAsync();
            var browser = await playwright.Chromium.LaunchAsync(new() { Headless = false });
            var page = await browser.NewPageAsync();
            await page.GotoAsync("https://www.google.com");
            Assert.That(await page.TitleAsync(), Does.Contain("Google"));
        }
    }
}
