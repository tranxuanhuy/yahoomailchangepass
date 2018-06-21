using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
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
            //FirefoxProfileManager profileManager = new FirefoxProfileManager();
            //FirefoxProfile profile = profileManager.GetProfile("default");
            //ChangeUAFirefox(profile);

            ChromeOptions options = new ChromeOptions();
            IWebDriver driver = new ChromeDriver(options); //<-Add your path
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(40));
            
            driver.Navigate().GoToUrl("https://login.yahoo.com");
            driver.FindElement(By.Id("login-username")).SendKeys("AndradexzBella3637@yahoo.com");
            driver.FindElement(By.Id("login-username")).Submit();
            wait.Until(ExpectedConditions.PresenceOfAllElementsLocatedBy(By.Id("login-passwd")));
            driver.FindElement(By.Id("login-passwd")).SendKeys("tai01234553435");
            driver.FindElement(By.Id("login-passwd")).SendKeys(Keys.Enter);

            //trang doi pass
            driver.Navigate().GoToUrl("https://login.yahoo.com/account/change-password?context=mc&el=1&done=https%3A%2F%2Flogin.yahoo.com%2Faccount%2Fsecurity%3Fscrumb%3Dii.8SG.bwCR&scrumb=ii.8SG.bwCR");
            driver.FindElement(By.Id("cpwd-password")).SendKeys("B1nbin!@#");
            driver.FindElement(By.Id("cpwd-confirm-password")).SendKeys("B1nbin!@#");
            driver.FindElement(By.Id("cpwd-confirm-password")).SendKeys(Keys.Enter);

            driver.FindElement(By.Name("commChannel")).SendKeys("getcryptotab.com@starbuck.cc");
            
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
