using Microsoft.Playwright;
using NUnit.Framework;

namespace E2ETests;

public class LoginTests
{
    [Test]
    public async Task Open_Google()
    {
        // 建立 Playwright
        using var playwright = await Playwright.CreateAsync();

        // 開啟 Chromium
        var browser = await playwright.Chromium.LaunchAsync(
            new BrowserTypeLaunchOptions
            {
                Headless = false
            });

        // 開新頁
        var page = await browser.NewPageAsync();

        // 前往 Google
        await page.GotoAsync("https://google.com");

        // 等待 3 秒方便觀察
        await page.WaitForTimeoutAsync(30000);

        // 驗證 title
        Assert.That(await page.TitleAsync(),
            Does.Contain("Google"));
    }
}