using Microsoft.Playwright;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject1
{
    internal class CreateNewEmployee : BaseConfig
    {
        [Test]
        public async Task TestCreate()
        {
            var page = await context.NewPageAsync();
            await page.GotoAsync("http://www.eaapp.somee.com/");

            // Click login link
            await page.ClickAsync("//a[@id='loginLink']");

            // Wait for a few seconds (simulate some activity)

            await Task.Delay(2000);

            await page.Locator("//input[@id='UserName']").FillAsync("admin");
            await page.Locator("//input[@id='Password']").FillAsync("password");           // Close context to save video
            await page.Locator("//input[@id='loginIn']").ClickAsync();
            await page.Locator("//a[@href='/Employee']").ClickAsync();
            await page.Locator("//a[@class='btn btn-primary']").ClickAsync();
            await page.Locator("//input[@id='Name']").FillAsync("Bhumi");
            await page.Locator("//input[@id='Salary']").FillAsync("20000");
            await page.Locator("//input[@name='DurationWorked']").FillAsync("2");

            var dropdown = page.Locator("//select[@id='Grade']");
            await dropdown.SelectOptionAsync(new SelectOptionValue { Value = "3" });
            await Assertions.Expect(dropdown).ToHaveValueAsync("3");

            await page.Locator("//input[@id='Email']").FillAsync("bhumikapatel31@gmail.com");
            await page.Locator("//input[@value='Create']").ClickAsync();
            await page.Locator("//ul[@class='nav navbar-nav']/li[3]").ClickAsync();

            await page.WaitForTimeoutAsync(7000);
            await context.CloseAsync();






        }
    }
}
