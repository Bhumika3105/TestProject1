using Microsoft.Playwright;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject1
{
    internal class EmployeeList : BaseConfig
    {
        [Test]
        public async Task TestEmployeeList()
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
            await page.Locator("//input[@name='searchTerm']").FillAsync("tom@gmail.com");
            await page.Locator("//input[@value='Search']").ClickAsync();

            await page.WaitForTimeoutAsync(7000);
            await context.CloseAsync();



        }
    }
}


