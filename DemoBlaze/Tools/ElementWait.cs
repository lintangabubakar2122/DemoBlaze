using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoBlaze.Tools;

public class ElementWait
{
    private const int PoolingRefreshRate = 250;
    private const int TimeOut = 60 * 1000;

    private const int CountTimeOut = TimeOut / PoolingRefreshRate;

    public static void Click(IWebDriver driver, By by)
    {
        int count = 0;
        while (count < CountTimeOut)
        {
            try
            {
                count++;
                driver.FindElement(by).Click();
                break;
            }
            catch (ElementClickInterceptedException)
            {
                Thread.Sleep(PoolingRefreshRate);
            }
            catch (NoSuchElementException)
            {
                Thread.Sleep(PoolingRefreshRate);
            }
            catch (ElementNotInteractableException)
            {
                Thread.Sleep(PoolingRefreshRate);
            }
            catch (StaleElementReferenceException)
            {
                Thread.Sleep(PoolingRefreshRate);
            }
        }

        if (count == CountTimeOut) throw new ElementClickInterceptedException();
    }
    public static void SendKeys(IWebDriver driver, By by, string textToSend)
    {
        int count = 0;
        while (count < CountTimeOut)
        {
            try
            {
                count++;
                driver.FindElement(by).Clear();
                driver.FindElement(by).SendKeys(textToSend);
                break;
            }
            catch (ElementClickInterceptedException)
            {
                Thread.Sleep(PoolingRefreshRate);
            }
            catch (NoSuchElementException)
            {
                Thread.Sleep(PoolingRefreshRate);
            }
            catch (ElementNotInteractableException)
            {
                Thread.Sleep(PoolingRefreshRate);
            }
            catch (StaleElementReferenceException)
            {
                Thread.Sleep(PoolingRefreshRate);
            }
        }

        if (count == CountTimeOut) throw new ElementClickInterceptedException();
    }
    public static void UntilExists(IWebDriver driver, By by)
    {
        int count = 0;
        while (count < CountTimeOut)
        {
            try
            {
                count++;
                driver.FindElement(by);
                break;
            }
            catch (NotFoundException)
            {
                Thread.Sleep(PoolingRefreshRate);
            }
            catch (StaleElementReferenceException)
            {
                Thread.Sleep(PoolingRefreshRate);
            }
        }
        if (count == CountTimeOut) throw new NotFoundException();
    }
    public static string GetText(IWebDriver driver, By by)
    {
        int count = 0;
        string result = "";
        while (count < CountTimeOut)
        {
            try
            {
                count++;
                result = driver.FindElement(by).Text;
                break;
            }
            catch (NotFoundException)
            {
                Thread.Sleep(PoolingRefreshRate);
            }
            catch (StaleElementReferenceException)
            {
                Thread.Sleep(PoolingRefreshRate);
            }
        }
        if (count == CountTimeOut) throw new NotFoundException();
        return result;
    }
}
