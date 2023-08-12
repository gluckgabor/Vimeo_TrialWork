using System;
using System.Diagnostics;
using System.IO;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;
using Xunit;
using Xunit.Abstractions;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium.Edge;

namespace Selenium.NetCore.Test
{
    //public class IETests : IDisposable
    //{
    //    public static IWebDriver webDriver;
    //    public static IWebDriver IEwebDriver;

    //    private readonly ITestOutputHelper output;
    //    //private readonly ITestOutputHelper IEoutput;

    //    //public static  IEdriver;

    //    //public IETests(ITestOutputHelper output)
    //    //{
    //    //   // var driverService = InternetExplorerDriverService.CreateDefaultService(@"C:\Users\gluck\.nuget\packages\webdriver.iedriverserver.win64\3.150.1");

    //    //    var options = new InternetExplorerOptions();

    //    //    // Set the desired capabilities
    //    //    options.IgnoreZoomLevel = true;
    //    //    options.IntroduceInstabilityByIgnoringProtectedModeSettings = true;
    //    //    options.ForceCreateProcessApi = true;
            
    //    //    // Create an instance of InternetExplorerDriver            
    //    //    IEwebDriver = new InternetExplorerDriver(driverService, options);

    //    //}

    //    //public void Dispose()
    //    //{
    //    //    IEwebDriver.Dispose();
    //    //}


    //}
        public class ChromeTests
    {
        public static IWebDriver webDriver;
        //public static IWebDriver IEdriver;

        private readonly ITestOutputHelper output;
        //private readonly ITestOutputHelper IEoutput;

        //public static  IEdriver;

        
        public ChromeTests(ITestOutputHelper output)
        {
            this.output = output;
            var directory = Directory.GetCurrentDirectory();
            //var pathDrivers = directory + "";
            var pathDrivers = "C:/Users/gluck/.nuget/packages/selenium.webdriver.chromedriver/114.0.5735.1600/driver/win32";

            //"C:/Users/gluck/OneDrive/Documents/1 Structured Random Kft/elszámolás/2 OLM/selenium-cshap-sample-master/drivers
            webDriver = new ChromeDriver(pathDrivers);

            var driverService = InternetExplorerDriverService.CreateDefaultService(@"C:\Users\gluck\.nuget\packages\webdriver.iedriverserver.win64\3.150.1");

            var options = new InternetExplorerOptions();

            // Set the desired capabilities
            options.IgnoreZoomLevel = true;
            options.IntroduceInstabilityByIgnoringProtectedModeSettings = true;
            options.ForceCreateProcessApi = true;
            // Create an instance of InternetExplorerDriver            
            //IEdriver = new InternetExplorerDriver(driverService, options);
            //new DriverManager().SetUpDriver(new ChromeConfig());
            //webDriver = new ChromeDriver();

            Debug.Print("dirGG" + directory);
        }

        

        class MultiComparable : IComparable
        {
            private int Value { get; }

            public MultiComparable(int value)
            {
                Value = value;
            }

            public int CompareTo(object obj)
            {
                if (obj is int intObj)
                {
                    return Value.CompareTo(intObj);
                }
                else if (obj is MultiComparable multiObj)
                {
                    return Value.CompareTo(multiObj.Value);
                }

                throw new InvalidOperationException();
            }
        }


        [Theory]
        [InlineData("Switzerland", "/html/body/div[4]/div/div[3]/div/div[1]/div/div[1]/form/div[4]/div[2]/label[1]", "/html/body/div[4]/div/div[3]/div/div[1]/div/div[1]/form/div[6]/div[1]/label", "/html/body/div[4]/div/div[3]/div/div[1]/div/div[1]/form/div[6]/div[2]/input[1]", 100, 2.50, 102.50, "× 0.025000", "× 0.024390")]
        [InlineData("Switzerland", "/html/body/div[4]/div/div[3]/div/div[1]/div/div[1]/form/div[4]/div[2]/label[2]", "/html/body/div[4]/div/div[3]/div/div[1]/div/div[1]/form/div[6]/div[1]/label", "/html/body/div[4]/div/div[3]/div/div[1]/div/div[1]/form/div[6]/div[2]/input[1]", 100, 3.70, 103.70, "× 0.037000", "× 0.035680")]
        [InlineData("Switzerland", "/html/body/div[4]/div/div[3]/div/div[1]/div/div[1]/form/div[4]/div[2]/label[3]", "/html/body/div[4]/div/div[3]/div/div[1]/div/div[1]/form/div[6]/div[1]/label", "/html/body/div[4]/div/div[3]/div/div[1]/div/div[1]/form/div[6]/div[2]/input[1]", 100, 7.70, 107.70, "× 0.077000", "× 0.071495")]        

        public void Testcase2_Calkoo_Switzerland_PriceWithoutVAT(String Country, String xPathVATRate, String checkBox, String inputField, double inputData, double expectedResult1, double expectedResult2Gross, string multiplier1Net, string multiplier2Gross)
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)webDriver;

            webDriver.Navigate().GoToUrl("https://www.calkoo.com/en/vat-calculator");
            webDriver.Manage().Window.Maximize();
            Thread.Sleep(1000);

            webDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
            
            //click welcome pop-up
            webDriver.FindElement(By.XPath("/html/body/div[5]/div[2]/div[1]/div[2]/div[2]/button[1]/p")).Click(); 
                     
            //click cookie consent
            webDriver.FindElement(By.XPath("/html/body/div[1]/div/a")).Click();

            //Select country
            webDriver.FindElement(By.XPath("/html/body/div[4]/div/div[3]/div/div[1]/div/div[1]/form/div[2]/div[2]/select")).SendKeys("Switzerland");
            
            //Select VAT rate
            webDriver.FindElement(By.XPath(xPathVATRate)).Click();

            //Select checkbox next to desired input
            //IWebElement element = webDriver.FindElement(By.XPath("/html/body/div[4]/div/div[3]/div/div[1]/div/div[1]/form/div[4]/div[1]"));
            //js.ExecuteScript("arguments[0].scrollIntoView(true);", checkBox);            
            webDriver.FindElement(By.XPath(checkBox)).Click();

            //Select inputField and enter inputData
            webDriver.FindElement(By.XPath(inputField)).SendKeys(Convert.ToString(inputData));

            String expected = expectedResult1.ToString("0.00");
            
            

            //String actual = (string)js.ExecuteScript("return document.getElementById("VATpct1"));
            String actual = Convert.ToString(js.ExecuteScript("return document.getElementById(\"VATsum\").value;"));
            Assert.Equal(expected, actual);

            String expected2 = expectedResult2Gross.ToString("0.00");
            String actual2 = Convert.ToString(js.ExecuteScript("return document.getElementById(\"Price\").value;"));
            Assert.Equal(expected2, actual2);

            String expected3 = Convert.ToString(multiplier1Net);
            String actual3 = Convert.ToString(js.ExecuteScript("return document.getElementById(\"VATpct2\").value;"));
            Assert.Equal(expected3, actual3);

            String expected4 = Convert.ToString(multiplier2Gross);
            String actual4 = Convert.ToString(js.ExecuteScript("return document.getElementById(\"VATpct1\").value;"));
            Assert.Equal(expected4, actual4);
        }
    }
}
