using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

public class FirstSelenium
{


    static void Main()
    {
        CreateReportDirectories();
        IWebDriver driver = new ChromeDriver();
        ExtentReports extentReport = new ExtentReports();
        ExtentSparkReporter reportpath = new ExtentSparkReporter(@"D:\Report Location\Report"+DateTime.Now.ToString("_ddMMyyyy_hhttss")+ ".html");

        extentReport.AttachReporter(reportpath);
        ExtentTest test = extentReport.CreateTest("Login Test", "This is our first test case");
 

        driver.Navigate().GoToUrl("https://practicetestautomation.com/practice-test-login/");

        test.Log(Status.Info, "Open Browser");
        Console.WriteLine("Open Browser");

        driver.Manage().Window.Maximize();
        Console.WriteLine("Browser Maximize");

        driver.FindElement(By.Id("username")).SendKeys("students");
        test.Log(Status.Info, "Provide username");
        Console.WriteLine("Provide username");

        driver.FindElement(By.Id("password")).SendKeys("Password123");
        test.Log(Status.Info, "Provide Password");
        Console.WriteLine("Provide Password");

        driver.FindElement(By.Id("submit")).Click();
        test.Log(Status.Info, "Hit Submit button");
        Console.WriteLine("Hit Submit button");
        try
        {
            driver.FindElement(By.CssSelector(".wp-block-button__link")).Click();
            test.Log(Status.Info, "LOgin Successfully");
        }
        catch
        {
            Console.WriteLine("Failed Login");
            test.Log(Status.Info, "LOgin failed");
        }
        driver.Quit();
        extentReport.Flush();



    }


    private static void CreateReportDirectories()
    {
        string ReportPath = @"D:\Report Location\";
        if (Directory.Exists(ReportPath))
        {
            Directory.CreateDirectory(ReportPath);
        }
    }
}

