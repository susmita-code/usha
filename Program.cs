using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Globalization;
using usha;
using CsvHelper;

public class FirstSelenium
{
    public static string DataCSVFile = System.IO.Directory.GetCurrentDirectory();


    static void Main()
    {
        var testDataList = ReadCsvData(DataCSVFile+ "\\UshaData\\ushaProject-1.csv");
        
        CreateReportDirectories();
        IWebDriver driver = new ChromeDriver();
        ExtentReports extentReport = new ExtentReports();
        ExtentSparkReporter reportpath = new ExtentSparkReporter(@"D:\Report Location\Report"+DateTime.Now.ToString("_ddMMyyyy_hhttss")+ ".html");

        extentReport.AttachReporter(reportpath);
        ExtentTest test = extentReport.CreateTest("Login Test", "This is our first test case");
 

        driver.Navigate().GoToUrl("https://practicetestautomation.com/practice-test-login/");

        foreach(var testaData in testDataList)
        {
            driver.FindElement(By.Id("username")).SendKeys(testaData.username);

            test.Log(Status.Info, "Provide username  "+ testaData.username);
            Console.WriteLine("Provide username " + testaData.username);

            driver.FindElement(By.Id("password")).SendKeys(testaData.password);
            test.Log(Status.Info, "Provide Password "+ testaData.password);
            Console.WriteLine("Provide Password "+ testaData.password);

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
            
        }

        test.Log(Status.Info, "Open Browser");
        Console.WriteLine("Open Browser");

        driver.Manage().Window.Maximize();
        Console.WriteLine("Browser Maximize");
        

       
        



    }


    private static void CreateReportDirectories()
    {
        string ReportPath = @"D:\Report Location\";
        if (Directory.Exists(ReportPath))
        {
            Directory.CreateDirectory(ReportPath);
        }
    }


    static List<TestData> ReadCsvData(string filePath)
    {
        using (var reader = new StreamReader(filePath))
        using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
        {
            return new List<TestData>(csv.GetRecords<TestData>());
        }
    }
}

