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
    class KPISchedule
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
            bool found = false;

            driver.Url = "http://google.com";
            driver.FindElement(By.CssSelector("input")).SendKeys("Розклад КПІ");
            driver.FindElement(By.CssSelector("input")).Submit();
            var site_list = driver.FindElements(By.CssSelector(".yuRUbf"));
            foreach (var item in site_list)
            {
                var site_link = item.FindElement(By.CssSelector("cite.iUh30"));
                var full_site_link = site_link.FindElements(By.CssSelector("span"));
                if (full_site_link.Count == 0)
                {
                    if (site_link.Text == "http://rozklad.kpi.ua")
                    {
                        site_link.Click();

                        driver.FindElement(By.CssSelector("a#ctl00_lBtnSchedule")).Click();
                        driver.FindElement(By.CssSelector("#ctl00_MainContent_ctl00_txtboxGroup")).SendKeys("КП-93");
                        driver.FindElement(By.CssSelector("#ctl00_MainContent_ctl00_txtboxGroup")).Submit();
                        driver.FindElement(By.CssSelector("#ctl00_MainContent_ctl00_btnShowSchedule")).Submit();

                        var tr_list = driver.FindElements(By.CssSelector("#ctl00_MainContent_FirstScheduleTable tbody tr"));
                        for (int i = 1; i < 7; i++)
                        {
                            var td_list = tr_list.ElementAt(i).FindElements(By.CssSelector("td"));
                            var span_list = td_list.ElementAt(3).FindElements(By.CssSelector("span.disLabel"));
                            if (span_list.Count > 0)
                            {
                                var a_list = span_list.ElementAt(0).FindElements(By.CssSelector("a.plainLink"));
                                var title = a_list.ElementAt(0).GetAttribute("title");
                                if (title == "Компоненти програмної інженерії 2. Якість та тестування програмного забезпечення")
                                {
                                    found = true;
                                    Console.WriteLine($"\"{title}\" is found on {i} lesson");
                                    break;
                                }
                            }
                        }

                        break;
                    }
                }
            }
            if (found == false)
            {
                Console.WriteLine($"\"Компоненти програмної інженерії 2.Якість та тестування програмного забезпечення\" is not found");
            }
        }


        [TearDown]
        public void closeBrowser()
        {
            driver.Close();
        }
    }
}
