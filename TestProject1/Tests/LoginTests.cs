using NUnit.Framework;
using TestProject1.Pages;

namespace TestProject1.Tests
{
    public class LoginTests : BaseConfig
    {
        [Test]
        public async Task SuccessfulLoginRedirectsToDashboard()
        {
            var page = await context.NewPageAsync();
            var loginPage = new LoginPage(page);

            await loginPage.GoToAsync("https://www.facebook.com/");
            await loginPage.LoginAsync("admin", "admin123");

            Assert.That(page.Url, Does.Contain("/dashboard"));
        }
    }
}
