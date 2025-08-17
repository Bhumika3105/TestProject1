using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestProject1;

namespace TestProject1
{
    internal class Register : BaseConfig

    {
        [Test]
        public async Task Test2()
        {
            var page = await context.NewPageAsync();
            await page.GotoAsync("http://www.eaapp.somee.com/");

            await page.ClickAsync("//a[@id='registerLink']");

            await Task.Delay(3000);

            await page.Locator("//input[@id='UserName']").FillAsync("admin123");
            await page.Locator("//input[@id='Password']").FillAsync("Bhumit_3105");
            await page.Locator("//input[@id='ConfirmPassword']").FillAsync("Bhumit_3105");
            await page.Locator("//input[@id='Email']").FillAsync("patelbhu31@gmail.com");
            await page.Locator("//input[@value='Register']").ClickAsync();

            await page.WaitForTimeoutAsync(7000);
            await context.CloseAsync();





        }
    }
}
