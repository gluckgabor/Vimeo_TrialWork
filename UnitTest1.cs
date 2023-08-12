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
        public class ChromeTests
    {
        public static IWebDriver webDriver;

        private readonly ITestOutputHelper output;
        
        public ChromeTests(ITestOutputHelper output)
        {
            this.output = output;
            var directory = Directory.GetCurrentDirectory();
            var pathDrivers = "C:/Users/gluck/.nuget/packages/selenium.webdriver.chromedriver/114.0.5735.1600/driver/win32";
                        
            webDriver = new ChromeDriver(pathDrivers);

            var driverService = InternetExplorerDriverService.CreateDefaultService(@"C:\Users\gluck\.nuget\packages\webdriver.iedriverserver.win64\3.150.1");

            var options = new InternetExplorerOptions();

            // Set the desired capabilities
            options.IgnoreZoomLevel = true;
            options.IntroduceInstabilityByIgnoringProtectedModeSettings = true;
            options.ForceCreateProcessApi = true;
            
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

        [Fact]
        public void Testcase1_Calkoo_User_Interface_check()
        {
            webDriver.Navigate().GoToUrl("https://www.calkoo.com/en/vat-calculator");
            webDriver.Manage().Window.Maximize();
            Thread.Sleep(1000);

            webDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);

            //click welcome pop-up
            webDriver.FindElement(By.XPath("/html/body/div[5]/div[2]/div[1]/div[2]/div[2]/button[1]/p")).Click();

            //click cookie consent
            webDriver.FindElement(By.XPath("/html/body/div[1]/div/a")).Click();


            IWebElement mainTitle = webDriver.FindElement(By.XPath("/html/body/div[4]/div/div[3]/div/div[1]/div/div[1]/form/h2"));

            String expected = "Initial Data";
            String actual = Convert.ToString(mainTitle.Text);
            Assert.Equal(expected, actual);


            IWebElement label1 = webDriver.FindElement(By.XPath("/html/body/div[4]/div/div[3]/div/div[1]/div/div[1]/form/div[2]/div[1]"));

            String expected1 = "Country";
            String actual1 = Convert.ToString(label1.Text);
            Assert.Equal(expected1, actual1);

            IWebElement dropdown = webDriver.FindElement(By.XPath("/html/body/div[4]/div/div[3]/div/div[1]/div/div[1]/form/div[2]/div[2]/select"));
            Assert.True(dropdown.Displayed);
            

            IWebElement label2 = webDriver.FindElement(By.XPath("/html/body/div[4]/div/div[3]/div/div[1]/div/div[1]/form/div[4]/div[1]"));

            String expected2 = "VAT rate";
            String actual2 = Convert.ToString(label2.Text);
            Assert.Equal(expected2, actual2);


            IWebElement checkbox1 = webDriver.FindElement(By.XPath("/html/body/div[4]/div/div[3]/div/div[1]/div/div[1]/form/div[4]/div[2]/label[1]"));
            Assert.True(checkbox1.Displayed);

            IWebElement checkbox2 = webDriver.FindElement(By.XPath("/html/body/div[4]/div/div[3]/div/div[1]/div/div[1]/form/div[4]/div[2]/label[2]"));
            Assert.True(checkbox2.Displayed);

            IWebElement label3 = webDriver.FindElement(By.XPath("/html/body/div[4]/div/div[3]/div/div[1]/div/div[1]/form/div[6]/div[1]/label"));
            String expected3 = "Price without VAT";
            String actual3 = Convert.ToString(label3.Text);
            Assert.Equal(expected3, actual3);

            IWebElement checkbox3 = webDriver.FindElement(By.XPath("/html/body/div[4]/div/div[3]/div/div[1]/div/div[1]/form/div[6]/div[1]/input"));
            String expected33 = "radio";
            String actual33 = Convert.ToString(checkbox3.GetAttribute("type"));
            Assert.Equal(expected33, actual33);
            

            IWebElement label4 = webDriver.FindElement(By.XPath("/html/body/div[4]/div/div[3]/div/div[1]/div/div[1]/form/div[7]/div[1]/label"));

            String expected4 = "Value-Added Tax";
            String actual4 = Convert.ToString(label4.Text);
            Assert.Equal(expected4, actual4);

            IWebElement checkbox4 = webDriver.FindElement(By.XPath("/html/body/div[4]/div/div[3]/div/div[1]/div/div[1]/form/div[7]/div[1]/input"));
            String expected44 = "radio";
            String actual44 = Convert.ToString(checkbox4.GetAttribute("type"));
            Assert.Equal(expected44, actual44);

            IWebElement label5 = webDriver.FindElement(By.XPath("/html/body/div[4]/div/div[3]/div/div[1]/div/div[1]/form/div[8]/div[1]/label"));

            String expected5 = "Price incl. VAT";
            String actual5 = Convert.ToString(label5.Text);
            Assert.Equal(expected5, actual5);

            IWebElement checkbox5 = webDriver.FindElement(By.XPath("/html/body/div[4]/div/div[3]/div/div[1]/div/div[1]/form/div[8]/div[1]/input"));
            String expected55 = "radio";
            String actual55 = Convert.ToString(checkbox5.GetAttribute("type"));
            Assert.Equal(expected55, actual55);

            IWebElement inputbox3 = webDriver.FindElement(By.XPath("/html/body/div[4]/div/div[3]/div/div[1]/div/div[1]/form/div[6]/div[2]/input[1]"));
            String expected66 = "text";
            String actual66 = Convert.ToString(inputbox3.GetAttribute("type"));
            Assert.Equal(expected66, actual66);

            IWebElement inputbox4 = webDriver.FindElement(By.XPath("/html/body/div[4]/div/div[3]/div/div[1]/div/div[1]/form/div[7]/div[2]/input"));
            String expected77 = "text";
            String actual77 = Convert.ToString(inputbox4.GetAttribute("type"));
            Assert.Equal(expected77, actual77);

            IWebElement inputbox5 = webDriver.FindElement(By.XPath("/html/body/div[4]/div/div[3]/div/div[1]/div/div[1]/form/div[8]/div[2]/input[1]"));
            String expected88 = "text";
            String actual88 = Convert.ToString(inputbox5.GetAttribute("type"));
            Assert.Equal(expected88, actual88);





            IWebElement button1 = webDriver.FindElement(By.XPath("/html/body/div[4]/div/div[3]/div/div[1]/div/div[1]/form/div[10]/div[3]/input"));

            String expected6 = "Reset";
            String actual6 = Convert.ToString(button1.GetAttribute("value"));
            Assert.Equal(expected6, actual6);

            Assert.True(button1.Displayed);
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
            
            //Select checkbox next to inputField
            webDriver.FindElement(By.XPath(checkBox)).Click();

            //Select inputField and enter inputData
            webDriver.FindElement(By.XPath(inputField)).SendKeys(Convert.ToString(inputData));

            String expected = expectedResult1.ToString("0.00");
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
