using Microsoft.Playwright;
using NUnit.Framework;
using System;
using System.IO;
using System.Threading.Tasks;

namespace TestProject1
{
    public class BaseConfig
    {
        protected IPlaywright playwright;
        protected IBrowser browser;
        protected IBrowserContext context;

        [SetUp]
        public async Task Setup()
        {
            var videoDir = Path.Combine(Directory.GetCurrentDirectory(), "videos");
            Directory.CreateDirectory(videoDir);

            playwright = await Playwright.CreateAsync();

            browser = await playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions
            {
                Headless = false
            });

            context = await browser.NewContextAsync(new BrowserNewContextOptions
            {
                RecordVideoDir = videoDir,
                RecordVideoSize = new RecordVideoSize
                {
                    Width = 1280,
                    Height = 720
                }
            });
        }

        [TearDown]
        public async Task Teardown()
        {
            // Log errors if test failed
            if (TestContext.CurrentContext.Result.Outcome.Status == NUnit.Framework.Interfaces.TestStatus.Failed)
            {
                var testName = TestContext.CurrentContext.Test.Name;
                var message = TestContext.CurrentContext.Result.Message;
                var stackTrace = TestContext.CurrentContext.Result.StackTrace;
                var logPath = Path.Combine(Directory.GetCurrentDirectory(), "ErrorLogs");

                Directory.CreateDirectory(logPath);
                var logFile = Path.Combine(logPath, $"{testName}_ErrorLog.txt");

                await File.WriteAllTextAsync(logFile,
                    $"Test: {testName}{Environment.NewLine}" +
                    $"Time: {DateTime.Now}{Environment.NewLine}" +
                    $"Message: {message}{Environment.NewLine}" +
                    $"StackTrace:{Environment.NewLine}{stackTrace}");
            }

            // Cleanup
            if (context != null)
                await context.CloseAsync();

            if (browser != null)
                await browser.CloseAsync();

            playwright?.Dispose();
        }
    }
}
