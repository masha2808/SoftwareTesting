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
    class Epicentr
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
            driver.FindElement(By.CssSelector("input")).SendKeys("Епіцентр");
            driver.FindElement(By.CssSelector("input")).Submit();
            driver.FindElement(By.CssSelector(".iUh30")).Click();

            driver.FindElement(By.CssSelector("button._21xqYn")).Click();
            driver.FindElement(By.CssSelector(".header__info-toggle")).Click();
            driver.FindElement(By.CssSelector("a.is-red")).Click();
            var time = driver.FindElement(By.CssSelector("._3K5rGC"));
            Console.WriteLine($"Work hours: {time.Text}");
            if (time.Text == "7:30–22:00")
            {
                Console.WriteLine($"Correct work hours");
            }
            else
            {
                Console.WriteLine($"Incorrect work hours");
            }
        }


        [TearDown]
        public void closeBrowser()
        {
            driver.Close();
        }
    }
}
