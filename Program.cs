using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

public class FirstSelenium
{

    static void Main()
    {
        IWebDriver driver = new ChromeDriver();
        ExtentReports extentReport = new ExtentReports();
        ExtentSparkReporter reportpath = new ExtentSparkReporter(@"C:\Report Location"+DateTime .Now+ ".+ html");
        extentReport.AttachReporter(reportpath);
        ExtentTest test = extentReport.CreateTest("Login Test", "This is our first test case");
 

        driver.Navigate().GoToUrl("https://practicetestautomation.com/practice-test-login/");

        test.Log(Status.Info, "Open Browser");
        Console.WriteLine("Open Browser");

        driver.Manage().Window.Maximize();
        Console.WriteLine("Browser Maximize");

        driver.FindElement(By.Id("username")).SendKeys("students");
        Console.WriteLine("Provide username");

        driver.FindElement(By.Id("password")).SendKeys("Password123");
        Console.WriteLine("Provide Password");

        driver.FindElement(By.Id("submit")).Click();
        Console.WriteLine("Hit Submit button");
        try
        {
            driver.FindElement(By.CssSelector(".wp-block-button__link")).Click();
        }
        catch
        {
            Console.WriteLine("Failed Login");
        }
        driver.Quit();
        extentReport.Flush();



    }
}

