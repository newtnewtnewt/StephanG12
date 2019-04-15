using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
namespace SeleniumTester
{
    class Program
    {
        static void Main(string[] args)
        {
            string e = "test@test.com"; // The Default Email
            string p = "Test1!"; // The Default password
            string n = "Selenium"; // The Default App Name
            string dis = "Selenium Test";
            string org = "Selenium";
            string plt = "Selenium";
            string ver = "1.0";
            bool t1 = loginTest(e, p);
            bool t2 = submitAppTest(n, dis, org, plt, ver);
            bool t3 = denyAppTest(n, dis, org, plt, ver);
            bool t4 = acceptAppTest(n, dis, org, plt, ver);
            bool t5 = addComment();
            bool t6 = removeComment();
            Console.WriteLine("---------------------------------------------------------------\nTest Results:");
            if (t1)
            {
                Console.WriteLine("Login Test Passed");
            }
            else
            {
                Console.WriteLine("Login Test Failed");
            }
            if (t2)
            {
                Console.WriteLine("Submit App Test Passed");
            }
            else
            {
                Console.WriteLine("Submit App Test Failed");
            }
            if (t3)
            {
                Console.WriteLine("Deny App Test Passed");
            }
            else
            {
                Console.WriteLine("Deny App Test Failed");
            }
            if (t4)
            {
                Console.WriteLine("Accept App Test Passed");
            }
            else
            {
                Console.WriteLine("Accept App Test Failed");
            }
            if (t5)
            {
                Console.WriteLine("Add Comment Test Passed");
            }
            else
            {
                Console.WriteLine("Add Comment Test Failed");
            }
            if (t6)
            {
                Console.WriteLine("Remove Comment Test Passed");
            }
            else
            {
                Console.WriteLine("Remove Comment Test Failed");
            }
        }

        static bool loginTest(string email, string password)
        {
            bool result = false;
            Boolean closed = false;
            IWebDriver webDriver = new ChromeDriver();
            try
            {
                webDriver.Navigate().GoToUrl("http://localhost:55173/Account/Login");
                webDriver.FindElement(By.Id("MainContent_Email")).SendKeys(email);
                webDriver.FindElement(By.Id("MainContent_Password")).SendKeys(password);
                webDriver.FindElement(By.Name("ctl00$MainContent$ctl05")).Click();
                Task.Delay(1000).Wait();
                try
                {
                    webDriver.FindElement(By.PartialLinkText("Log off")).Click();
                }
                catch (OpenQA.Selenium.NoSuchElementException e)
                {
                    Console.WriteLine("Login Test Failed", e);
                    closed = true;
                }
                if (!closed)
                {
                    result = true;
                }
            }
            catch
            {

            }
            webDriver.Close();
            return result;
        }

        static bool submitAppTest(string name, string dis, string org, string plt, string ver)
        {
            bool result = false;
            IWebDriver webDriver = new ChromeDriver();
            try
            {
                webDriver.Navigate().GoToUrl("http://localhost:55173/Account/Login");
                webDriver.FindElement(By.Id("MainContent_Email")).SendKeys("test@test.com");
                webDriver.FindElement(By.Id("MainContent_Password")).SendKeys("Test1!");
                webDriver.FindElement(By.Name("ctl00$MainContent$ctl05")).Click();
                webDriver.Navigate().GoToUrl("http://localhost:55173/SubmitApp");
                webDriver.FindElement(By.Id("MainContent_Name")).SendKeys(name);
                webDriver.FindElement(By.Id("MainContent_Description")).SendKeys(dis);
                webDriver.FindElement(By.Id("MainContent_Organization")).SendKeys(org);
                webDriver.FindElement(By.Id("MainContent_Platform")).SendKeys(plt);
                webDriver.FindElement(By.Id("MainContent_Version")).SendKeys(ver);
                webDriver.FindElement(By.Id("MainContent_SubmitButton")).Click();

                IWebDriver adminLogin = new ChromeDriver();
                adminLogin.Navigate().GoToUrl("http://localhost:55173/Account/Login");
                adminLogin.FindElement(By.Id("MainContent_Email")).SendKeys("testAdmin@test.com");
                adminLogin.FindElement(By.Id("MainContent_Password")).SendKeys("Test1!");
                adminLogin.FindElement(By.Name("ctl00$MainContent$ctl05")).Click();
                adminLogin.Navigate().GoToUrl("http://localhost:55173/ModerateApps");
                Boolean closed = false;
                try
                {
                    adminLogin.FindElement(By.Id("MainContent_GridView_DenyButton_0"));
                }
                catch (OpenQA.Selenium.NoSuchElementException)
                {
                    Console.WriteLine("Submit App Test Failed");
                    closed = true;
                }
                if (!closed)
                {
                    adminLogin.FindElement(By.Id("MainContent_GridView_DenyButton_0")).Click();
                    result = true;
                }
                webDriver.FindElement(By.PartialLinkText("Log off")).Click();
                adminLogin.FindElement(By.PartialLinkText("Log off")).Click();
                adminLogin.Close();
            }
            catch { }
            webDriver.Close();
            return result;
        }

        static bool denyAppTest(string name, string dis, string org, string plt, string ver)
        {
            bool result = false;
            IWebDriver webDriver = new ChromeDriver();
            try
            {
                webDriver.Navigate().GoToUrl("http://localhost:55173/Account/Login");
                webDriver.FindElement(By.Id("MainContent_Email")).SendKeys("test@test.com");
                webDriver.FindElement(By.Id("MainContent_Password")).SendKeys("Test1!");
                webDriver.FindElement(By.Name("ctl00$MainContent$ctl05")).Click();
                webDriver.Navigate().GoToUrl("http://localhost:55173/SubmitApp");
                webDriver.FindElement(By.Id("MainContent_Name")).SendKeys(name);
                webDriver.FindElement(By.Id("MainContent_Description")).SendKeys(dis);
                webDriver.FindElement(By.Id("MainContent_Organization")).SendKeys(org);
                webDriver.FindElement(By.Id("MainContent_Platform")).SendKeys(plt);
                webDriver.FindElement(By.Id("MainContent_Version")).SendKeys(ver);
                webDriver.FindElement(By.Id("MainContent_SubmitButton")).Click();

                IWebDriver adminLogin = new ChromeDriver();
                adminLogin.Navigate().GoToUrl("http://localhost:55173/Account/Login");
                adminLogin.FindElement(By.Id("MainContent_Email")).SendKeys("testAdmin@test.com");
                adminLogin.FindElement(By.Id("MainContent_Password")).SendKeys("Test1!");
                adminLogin.FindElement(By.Name("ctl00$MainContent$ctl05")).Click();
                adminLogin.Navigate().GoToUrl("http://localhost:55173/ModerateApps");
                Boolean closed = false;
                try
                {
                    adminLogin.FindElement(By.Id("MainContent_GridView_DenyButton_0"));
                }
                catch (OpenQA.Selenium.NoSuchElementException)
                {
                    Console.WriteLine("Deny App Test failed to submit the app");
                    webDriver.FindElement(By.PartialLinkText("Log off")).Click();
                    adminLogin.Close();
                    closed = true;
                }
                if (!closed)
                {
                    adminLogin.FindElement(By.Id("MainContent_GridView_DenyButton_0")).Click();
                    adminLogin.Navigate().GoToUrl("http://localhost:55173/");
                    Boolean present = false;
                    try
                    {
                        adminLogin.FindElement(By.PartialLinkText("Selenium"));

                    }
                    catch (OpenQA.Selenium.NoSuchElementException)
                    {
                        present = true;
                        result = true;
                    }
                    if (!present)
                    {
                        Console.WriteLine("Deny App Test Failed");
                    }
                }
                adminLogin.FindElement(By.PartialLinkText("Log off")).Click();
                webDriver.FindElement(By.PartialLinkText("Log off")).Click();
                Task.Delay(1000).Wait();
                adminLogin.Close();
            }
            catch { }
            webDriver.Close();
            return result;
        }

        static bool acceptAppTest(string name, string dis, string org, string plt, string ver)
        {
            bool result = false;
            name = "DangerZone";
            IWebDriver webDriver = new ChromeDriver();
            try
            {
                webDriver.Navigate().GoToUrl("http://localhost:55173/Account/Login");
                webDriver.FindElement(By.Id("MainContent_Email")).SendKeys("test@test.com");
                webDriver.FindElement(By.Id("MainContent_Password")).SendKeys("Test1!");
                webDriver.FindElement(By.Name("ctl00$MainContent$ctl05")).Click();
                webDriver.Navigate().GoToUrl("http://localhost:55173/SubmitApp");
                webDriver.FindElement(By.Id("MainContent_Name")).SendKeys(name);
                webDriver.FindElement(By.Id("MainContent_Description")).SendKeys("It");
                webDriver.FindElement(By.Id("MainContent_Organization")).SendKeys("Is For A");
                webDriver.FindElement(By.Id("MainContent_Platform")).SendKeys("Test");
                webDriver.FindElement(By.Id("MainContent_Version")).SendKeys(ver);
                webDriver.FindElement(By.Id("MainContent_SubmitButton")).Click();

                IWebDriver adminLogin = new ChromeDriver();
                adminLogin.Navigate().GoToUrl("http://localhost:55173/Account/Login");
                adminLogin.FindElement(By.Id("MainContent_Email")).SendKeys("testAdmin@test.com");
                adminLogin.FindElement(By.Id("MainContent_Password")).SendKeys("Test1!");
                adminLogin.FindElement(By.Name("ctl00$MainContent$ctl05")).Click();
                adminLogin.Navigate().GoToUrl("http://localhost:55173/ModerateApps");
                Boolean closed = false;
                try
                {
                    adminLogin.FindElement(By.Id("MainContent_GridView_DenyButton_0"));
                }
                catch (OpenQA.Selenium.NoSuchElementException)
                {
                    Console.WriteLine("Deny App Test failed to submit the app");
                    webDriver.FindElement(By.PartialLinkText("Log off")).Click();
                    closed = true;
                }
                if (!closed)
                {
                    adminLogin.FindElement(By.Id("MainContent_GridView_AcceptButton_0")).Click();
                    adminLogin.Navigate().GoToUrl("http://localhost:55173/");
                    Boolean present = false;
                    try
                    {
                        adminLogin.FindElement(By.PartialLinkText(name));

                    }
                    catch (OpenQA.Selenium.NoSuchElementException)
                    {
                        present = true;
                        result = true;
                    }
                    if (!present)
                    {
                        Console.WriteLine("Accept App Test Failed");
                    }
                }
                adminLogin.FindElement(By.PartialLinkText("Log off")).Click();
                webDriver.FindElement(By.PartialLinkText("Log off")).Click();
                adminLogin.Close();
            }
            catch { }
            webDriver.Close();
            return result;
        }

        static bool addComment()
        {
            bool result = false;
            IWebDriver webDriver = new ChromeDriver();
            try
            {
                webDriver.Navigate().GoToUrl("http://localhost:55173/Account/Login");
                webDriver.FindElement(By.Id("MainContent_Email")).SendKeys("testAdmin@test.com");
                webDriver.FindElement(By.Id("MainContent_Password")).SendKeys("Test1!");
                webDriver.FindElement(By.Name("ctl00$MainContent$ctl05")).Click();
                webDriver.Navigate().GoToUrl("http://localhost:55173/");
                webDriver.FindElement(By.PartialLinkText("View Comments")).Click();
                var rating = webDriver.FindElement(By.Id("MainContent_ratingDrop"));
                var selectElement = new SelectElement(rating);
                selectElement.SelectByValue("5");
                webDriver.FindElement(By.Id("MainContent_SubmitComment")).Click();
                Boolean found = false;
                try
                {
                    webDriver.FindElement(By.Id("MainContent_GridView_RemoveButton_0"));
                }
                catch (OpenQA.Selenium.NoSuchElementException)
                {
                    Console.WriteLine("Add Comment Test Failed");
                    found = true;
                }
                if (!found)
                {
                    result = true;
                }
                webDriver.FindElement(By.PartialLinkText("Log off")).Click();
                Task.Delay(1000).Wait();
            }
            catch { }
            webDriver.Close();
            return result;
        }

        static bool removeComment()
        {
            bool result = false;
            IWebDriver webDriver = new ChromeDriver();
            try
            {
                webDriver.Navigate().GoToUrl("http://localhost:55173/Account/Login");
                webDriver.FindElement(By.Id("MainContent_Email")).SendKeys("testAdmin@test.com");
                webDriver.FindElement(By.Id("MainContent_Password")).SendKeys("Test1!");
                webDriver.FindElement(By.Name("ctl00$MainContent$ctl05")).Click();
                Task.Delay(1000).Wait();
                webDriver.Navigate().GoToUrl("http://localhost:55173/");
                webDriver.FindElement(By.PartialLinkText("View Comments")).Click();
                webDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
                webDriver.FindElement(By.Id("MainContent_GridView_RemoveButton_0")).Click();
                Boolean found = false;
                try
                {
                    webDriver.FindElement(By.Id("MainContent_GridView_RemoveButton_0")).Click();
                }
                catch (OpenQA.Selenium.NoSuchElementException)
                {
                    found = true;
                    webDriver.FindElement(By.PartialLinkText("Log off")).Click();
                    webDriver.Close();
                    result = true;
                }
                if (!found)
                {
                    Console.WriteLine("Remove Comment Test Failed");

                }
                webDriver.FindElement(By.PartialLinkText("Log off")).Click();
            }
            catch
            {

            }
            webDriver.Close();
            return result;
        }
    }
}
