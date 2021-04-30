using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice3
{
    class Translator
    {
        IWebDriver driver;

        [SetUp]
        public void startBrowser()
        {
            driver = new ChromeDriver("D:\\chromedriver");
        }

        [Test]
        public void test()
        {
            driver.Url = "http://google.com";
            driver.FindElement(By.CssSelector("input")).SendKeys("Переводчик");
            driver.FindElement(By.CssSelector("input")).Submit();
            driver.FindElement(By.CssSelector(".iUh30")).Click();

            var element1 = driver.FindElements(By.CssSelector("button.VfPpkd-Bz112c-LgbsSe"));
            element1.ElementAt(0).Click();
            driver.FindElements(By.CssSelector("input")).ElementAt(0).SendKeys("русский");

            var languages_from = driver.FindElements(By.CssSelector(".QAJDKf"));
            if (languages_from.Count > 0)
            {
                languages_from.ElementAt(0).Click();
            }

            driver.FindElement(By.CssSelector("textarea")).SendKeys("Тестируем приложение \"Переводчик\"");

            var element2 = driver.FindElements(By.CssSelector("button.VfPpkd-Bz112c-LgbsSe"));
            element2.ElementAt(2).Click();
            driver.FindElements(By.CssSelector("input")).ElementAt(1).SendKeys("немецкий");

            var languages_to = driver.FindElements(By.CssSelector(".QAJDKf"));
            if (languages_to.Count > 0)
            {
                languages_to.ElementAt(0).Click();
            }
        }


        [TearDown]
        public void closeBrowser()
        {
            driver.Close();
        }
    }
}
