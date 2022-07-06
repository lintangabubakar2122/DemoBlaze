

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace DemoBlaze.TestCase;

[TestClass]
public class TestingFlow
{
    private IWebDriver driver;

    [TestInitialize]
    public void Init()
    {
        driver = new ChromeDriver();
    }
    [TestMethod]
    public void TestCase1()
    {
        string userName = "akukuat";
        string password = "akukuat";
        Part.Part.Signin(driver, userName, password);
        Part.Part.Transaction(driver);
        Part.Part.SignOut(driver);
    }
    public TestContext TestContext { get; set; }
    [TestCleanup]
    public void Cleanup()
    {
        if (TestContext.CurrentTestOutcome == UnitTestOutcome.Failed)
        {
            var screenshotPath = $"{DateTime.Now:yyyy-MM-dd_HH-mm-ss.fffff}.png";
            Screenshot ss = ((ITakesScreenshot)driver).GetScreenshot();
            ss.SaveAsFile(screenshotPath);
            TestContext.AddResultFile(screenshotPath);
        }
        driver!.Quit();
    }

}


