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
            string e = "testAdmin@test.com"; // The Default Email
            string p = "Test1!"; // The Default password
            string n = "Selenium"; // The Default App Name
            string dis = "Selenium Test";
            string org = "Selenium";
            string plt = "Selenium";
            string ver = "1.0";
            //loginTest(e,p);
            //submitAppTest(e, p, n, dis, org, plt, ver);
            //denyAppTest(e, p, n, dis, org, plt, ver);
            //acceptAppTest(e, p, n, dis, org, plt, ver);
            //addComment();
            removeComment();
        }

        static void loginTest(string email, string password)
        {
            Boolean closed = false;
            IWebDriver webDriver = new ChromeDriver();
            webDriver.Navigate().GoToUrl("http://localhost:55173/Account/Login");
            webDriver.FindElement(By.Id("MainContent_Email")).SendKeys(email);
            webDriver.FindElement(By.Id("MainContent_Password")).SendKeys(password);
            webDriver.FindElement(By.Name("ctl00$MainContent$ctl05")).Click();
            try
            {
                webDriver.FindElement(By.ClassName("text-danger"));
            }
            catch (OpenQA.Selenium.NoSuchElementException e)
            {
                Console.WriteLine("Login Test Succesfful", e);
                webDriver.Close();
                closed = true;
            }
            if (!closed)
            {
                webDriver.Close();
                Console.WriteLine("Login Test Failed");
            }
        }

        static void submitAppTest(string email, string password, string name, string dis, string org, string plt, string ver)
        {
            IWebDriver webDriver = new ChromeDriver();
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
            adminLogin.FindElement(By.Id("MainContent_Email")).SendKeys(email);
            adminLogin.FindElement(By.Id("MainContent_Password")).SendKeys(password);
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
                adminLogin.Close();
                closed = true;
            }
            if (!closed)
            {
                adminLogin.FindElement(By.Id("MainContent_GridView_DenyButton_0")).Click();
                Console.WriteLine("Submit App Test Successful");
                adminLogin.Close();
            }
        }

        static void denyAppTest(string email, string password, string name, string dis, string org, string plt, string ver)
        {
            IWebDriver webDriver = new ChromeDriver();
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
                    Console.WriteLine("Deny App Test Succesfful");
                    adminLogin.Close();
                    present = true;
                }
                if (!present)
                {
                    Console.WriteLine("Deny App Test Failed");
                    adminLogin.Close();
                }
            }
        }

        static void acceptAppTest(string email, string password, string name, string dis, string org, string plt, string ver)
        {
            IWebDriver webDriver = new ChromeDriver();
            webDriver.Navigate().GoToUrl("http://localhost:55173/Account/Login");
            webDriver.FindElement(By.Id("MainContent_Email")).SendKeys("test@test.com");
            webDriver.FindElement(By.Id("MainContent_Password")).SendKeys("Test1!");
            webDriver.FindElement(By.Name("ctl00$MainContent$ctl05")).Click();
            webDriver.Navigate().GoToUrl("http://localhost:55173/SubmitApp");
            webDriver.FindElement(By.Id("MainContent_Name")).SendKeys("Cucu");
            webDriver.FindElement(By.Id("MainContent_Description")).SendKeys("It");
            webDriver.FindElement(By.Id("MainContent_Organization")).SendKeys("Is For A");
            webDriver.FindElement(By.Id("MainContent_Platform")).SendKeys("Test");
            webDriver.FindElement(By.Id("MainContent_Version")).SendKeys(ver);
            webDriver.FindElement(By.Id("MainContent_SubmitButton")).Click();

            IWebDriver adminLogin = new ChromeDriver();
            adminLogin.Navigate().GoToUrl("http://localhost:55173/Account/Login");
            adminLogin.FindElement(By.Id("MainContent_Email")).SendKeys(email);
            adminLogin.FindElement(By.Id("MainContent_Password")).SendKeys(password);
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
                adminLogin.Close();
                closed = true;
            }
            if (!closed)
            {
                adminLogin.FindElement(By.Id("MainContent_GridView_AcceptButton_0")).Click();
                adminLogin.Navigate().GoToUrl("http://localhost:55173/");
                Boolean present = false;
                try
                {
                    adminLogin.FindElement(By.PartialLinkText("Cucu"));

                }
                catch (OpenQA.Selenium.NoSuchElementException)
                {
                    Console.WriteLine("Accept App Test Succesful");
                    adminLogin.Close();
                    present = true;
                }
                if (!present)
                {
                    Console.WriteLine("Accept App Test Failed");
                    adminLogin.Close();
                }
            }
        }

        static void addComment()
        {
            IWebDriver webDriver = new ChromeDriver();
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
                webDriver.Close();
                found = true;
            }
            if (!found)
            {
                Console.WriteLine("Add Comment Test Successful");
                webDriver.Close();
            }
        }

        static void removeComment()
        {
            IWebDriver webDriver = new ChromeDriver();
            webDriver.Navigate().GoToUrl("http://localhost:55173/Account/Login");
            webDriver.FindElement(By.Id("MainContent_Email")).SendKeys("testAdmin@test.com");
            webDriver.FindElement(By.Id("MainContent_Password")).SendKeys("Test1!");
            webDriver.FindElement(By.Name("ctl00$MainContent$ctl05")).Click();
            webDriver.Navigate().GoToUrl("http://localhost:55173/");
            webDriver.FindElement(By.PartialLinkText("View Comments")).Click();
            webDriver.FindElement(By.Id("MainContent_GridView_RemoveButton_0")).Click();
            Boolean found = false;
            try
            {
                webDriver.FindElement(By.Id("MainContent_GridView_RemoveButton_0")).Click();
            }
            catch (OpenQA.Selenium.NoSuchElementException)
            {
                Console.WriteLine("Remove Comment Test Succesfful");
                found = true;
                webDriver.Close();
            }
            if (!found)
            {
                Console.WriteLine("Remove Comment Test Failed");
                webDriver.Close();
            }
        }
    }
}
