using DemoBlaze.Tools;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoBlaze.Part;

public class Part
{
    public static void Signin(IWebDriver driver, string userName, string password)
    {
        string url = $"https://www.demoblaze.com/";
        driver.Navigate().GoToUrl(url);
        driver.Manage().Window.Maximize();
        ElementWait.Click(driver, By.Id("login2"));
        ElementWait.Click(driver, By.Id("loginusername"));
        ElementWait.SendKeys(driver, By.Id("loginusername"), userName);
        ElementWait.Click(driver, By.Id("loginpassword"));
        ElementWait.SendKeys(driver, By.Id("loginpassword"), password);
        ElementWait.Click(driver, By.XPath("//div[@id='logInModal']/div/div/div[3]/button[2]"));
        Thread.Sleep(500);
    }


    public static void Transaction(IWebDriver driver)
    {
        ElementWait.Click(driver, By.LinkText("Laptops"));
        ElementWait.Click(driver, By.Id("next2"));
        ElementWait.Click(driver, By.LinkText("Dell i7 8gb"));
        driver.Navigate().GoToUrl("https://www.demoblaze.com/prod.html?idp_=12");
        ElementWait.Click(driver, By.LinkText("Add to cart"));
        Thread.Sleep(1000);
        driver.SwitchTo().Alert().Dismiss();
        ElementWait.Click(driver, By.LinkText("Contact"));
        ElementWait.Click(driver, By.Id("recipient-email"));
        driver.FindElement(By.Id("recipient-email")).SendKeys("akukuat@mailinator.com");
        ElementWait.Click(driver, By.Id("recipient-name"));
        driver.FindElement(By.Id("recipient-name")).SendKeys("akukuat");
        ElementWait.Click(driver, By.Id("message-text"));
        driver.FindElement(By.Id("message-text")).SendKeys("akukuat");
        ElementWait.Click(driver, By.XPath("//div[@id='exampleModal']/div/div/div[3]/button[2]"));
        driver.SwitchTo().Alert().Accept();
        Thread.Sleep(1000);
        driver.Navigate().GoToUrl("https://www.demoblaze.com/cart.html");
        ElementWait.Click(driver, By.XPath("//div[@id='page-wrapper']/div/div[2]/button"));
        ElementWait.Click(driver, By.Id("name"));
        driver.FindElement(By.Id("name")).SendKeys("aku kuat");
        ElementWait.Click(driver, By.Id("country"));
        driver.FindElement(By.Id("country")).SendKeys("Indonesia");
        ElementWait.Click(driver, By.Id("city"));
        driver.FindElement(By.Id("city")).SendKeys("Banjar");
        ElementWait.Click(driver, By.Id("card"));
        driver.FindElement(By.Id("card")).SendKeys("INDBJR");
        ElementWait.Click(driver, By.Id("month"));
        driver.FindElement(By.Id("month")).SendKeys("July");
        ElementWait.Click(driver, By.Id("year"));
        driver.FindElement(By.Id("year")).SendKeys("2022");
        ElementWait.Click(driver, By.XPath("//div[@id='orderModal']/div/div/div[3]/button[2]"));
        ElementWait.Click(driver, By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='Cancel'])[1]/following::button[1]"));
        driver.Navigate().GoToUrl("https://www.demoblaze.com/index.html");
        Thread.Sleep(500);
    }

    public static void SignOut(IWebDriver driver)
    {
        ElementWait.Click(driver, By.Id("logout2"));
    }
}
