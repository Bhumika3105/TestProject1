using Microsoft.Playwright;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject1
{
    internal class EmployeeDetails : BaseConfig
    {
        [Test]
        public async Task TestEmployeeDetails()
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
            await page.Locator("//a[@href='/EmployeeDetails']").ClickAsync();


            string[,] tableData = new string[4, 3] {
            { "Karthik", "4000", "1" },
            { "Prashanth", "7000", "2" },
            { "Ramesh", "3500", "2" },
            { "John", "2500", "3" }
        };

            int rowCount = tableData.GetLength(0);
            int colCount = tableData.GetLength(1);

            for (int row = 0; row < rowCount; row++)
            {
                for (int col = 0; col < colCount; col++)
                {
                    // XPath indexes start at 1; row+2 if your table has a header row (thead)
                    var cellLocator = page.Locator($"//table[@class='table']/tbody/tr[{row + 2}]/td[{col + 1}]");
                    string expectedText = tableData[row, col];

                    // Use Playwright's built-in assertion
                    await Assertions.Expect(cellLocator).ToContainTextAsync(expectedText);
                }
            }
            await context.CloseAsync();
            await browser.CloseAsync();




        }
    }
}
