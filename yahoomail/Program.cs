using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace yahoomail
{
    class Program
    {
        static void Main(string[] args)
        {
            int time = 5000;
            FirefoxProfileManager profileManager = new FirefoxProfileManager();
            FirefoxProfile profile = profileManager.GetProfile("default");
            ChangeUAFirefox(profile);

          
            IWebDriver driver = new FirefoxDriver(profile);
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(40));
            
            driver.Navigate().GoToUrl("https://login.yahoo.com");
            driver.FindElement(By.Id("login-username")).SendKeys("EscobarxhKendall4417@yahoo.com");
            driver.FindElement(By.Id("login-username")).Submit();
            driver.FindElement(By.Id("login-passwd")).SendKeys("tai01234553435");
            driver.FindElement(By.Id("login-passwd")).Submit();

            Console.Read();
        }

        public static void ChangeUAFirefox(FirefoxProfile profile)
        {
            var userAgent = ReadRandomLineOfFile("useragentswitcher.txt");
            profile.SetPreference("general.useragent.override", userAgent);
        }

        public static string ReadRandomLineOfFile(string file)
        {
            string[] lines = File.ReadAllLines(file); //i hope that the file is not too big
            Random rand = new Random();
            return lines[rand.Next(lines.Length)];
        }
    }
}
