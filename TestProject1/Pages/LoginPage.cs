using Microsoft.Playwright;
using System.Threading.Tasks;

namespace TestProject1.Pages
{
    public class LoginPage
    {
        private readonly IPage _page;

        public LoginPage(IPage page)
        {
            _page = page;
        }

        public async Task GoToAsync(string url)
        {
            await _page.GotoAsync(url);
        }

        public async Task LoginAsync(string username, string password)
        {
            await _page.Locator("//input[@id='email']").FillAsync("patelbhu31@gmail.com");
            await _page.Locator("//input[@id='pass']").FillAsync("password");
            await _page.Locator("//button[@name='login']").ClickAsync();
        }
    }
}
