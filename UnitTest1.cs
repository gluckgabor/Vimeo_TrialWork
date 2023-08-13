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

            String expectedMainTitle = "Initial Data";
            String actualMainTitle = Convert.ToString(mainTitle.Text);
            Assert.Equal(expectedMainTitle, actualMainTitle);


            IWebElement labelCountry = webDriver.FindElement(By.XPath("/html/body/div[4]/div/div[3]/div/div[1]/div/div[1]/form/div[2]/div[1]"));

            String expectedCountry = "Country";
            String actualCountry = Convert.ToString(labelCountry.Text);
            Assert.Equal(expectedCountry, actualCountry);

            IWebElement dropdownCountry = webDriver.FindElement(By.XPath("/html/body/div[4]/div/div[3]/div/div[1]/div/div[1]/form/div[2]/div[2]/select"));
            Assert.True(dropdownCountry.Displayed);
            

            IWebElement labelVATRate = webDriver.FindElement(By.XPath("/html/body/div[4]/div/div[3]/div/div[1]/div/div[1]/form/div[4]/div[1]"));

            String expectedVATRate = "VAT rate";
            String actualVATRate = Convert.ToString(labelVATRate.Text);
            Assert.Equal(expectedVATRate, actualVATRate);


            IWebElement checkboxVATRate1 = webDriver.FindElement(By.XPath("/html/body/div[4]/div/div[3]/div/div[1]/div/div[1]/form/div[4]/div[2]/label[1]"));
            Assert.True(checkboxVATRate1.Displayed);

            IWebElement checkboxVATRate2 = webDriver.FindElement(By.XPath("/html/body/div[4]/div/div[3]/div/div[1]/div/div[1]/form/div[4]/div[2]/label[2]"));
            Assert.True(checkboxVATRate2.Displayed);

            IWebElement labelPriceWithoutVAT = webDriver.FindElement(By.XPath("/html/body/div[4]/div/div[3]/div/div[1]/div/div[1]/form/div[6]/div[1]/label"));
            String expectedPriceWithoutVAT = "Price without VAT";
            String actualPriceWithoutVAT = Convert.ToString(labelPriceWithoutVAT.Text);
            Assert.Equal(expectedPriceWithoutVAT, actualPriceWithoutVAT);

            IWebElement checkboxPriceWithoutVAT = webDriver.FindElement(By.XPath("/html/body/div[4]/div/div[3]/div/div[1]/div/div[1]/form/div[6]/div[1]/input"));
            String expectedPriceWithoutVATCheckbox = "radio";
            String actualPriceWithoutVATCheckbox = Convert.ToString(checkboxPriceWithoutVAT.GetAttribute("type"));
            Assert.Equal(expectedPriceWithoutVAT, actualPriceWithoutVAT);
            

            IWebElement labelValueAddedTax = webDriver.FindElement(By.XPath("/html/body/div[4]/div/div[3]/div/div[1]/div/div[1]/form/div[7]/div[1]/label"));

            String expectedValueAddedTax = "Value-Added Tax";
            String actualValueAddedTax = Convert.ToString(labelValueAddedTax.Text);
            Assert.Equal(expectedValueAddedTax, actualValueAddedTax);

            IWebElement checkboxValueAddedTax = webDriver.FindElement(By.XPath("/html/body/div[4]/div/div[3]/div/div[1]/div/div[1]/form/div[7]/div[1]/input"));
            String expectedValueAddedTaxCheckbox = "radio";
            String actualValueAddedTaxCheckbox = Convert.ToString(checkboxValueAddedTax.GetAttribute("type"));
            Assert.Equal(expectedValueAddedTaxCheckbox, actualValueAddedTaxCheckbox);

            IWebElement labelPriceInclVAT = webDriver.FindElement(By.XPath("/html/body/div[4]/div/div[3]/div/div[1]/div/div[1]/form/div[8]/div[1]/label"));

            String expectedPriceInclVAT = "Price incl. VAT";
            String actualPriceInclVAT = Convert.ToString(labelPriceInclVAT.Text);
            Assert.Equal(expectedPriceInclVAT, actualPriceInclVAT);

            IWebElement checkboxPriceInclVAT = webDriver.FindElement(By.XPath("/html/body/div[4]/div/div[3]/div/div[1]/div/div[1]/form/div[8]/div[1]/input"));
            String expectedPriceInclVATCheckbox = "radio";
            String actualPriceInclVATCheckbox = Convert.ToString(checkboxPriceInclVAT.GetAttribute("type"));
            Assert.Equal(expectedPriceInclVATCheckbox, actualPriceInclVATCheckbox);

            IWebElement inputboxPriceWithoutVAT = webDriver.FindElement(By.XPath("/html/body/div[4]/div/div[3]/div/div[1]/div/div[1]/form/div[6]/div[2]/input[1]"));
            String expectedPriceWithoutVATInputbox = "text";
            String actualPriceWithoutVATInputbox = Convert.ToString(inputboxPriceWithoutVAT.GetAttribute("type"));
            Assert.Equal(expectedPriceWithoutVAT, actualPriceWithoutVAT);

            IWebElement inputboxVAT = webDriver.FindElement(By.XPath("/html/body/div[4]/div/div[3]/div/div[1]/div/div[1]/form/div[7]/div[2]/input"));
            String expectedVATInputbox = "text";
            String actualVATInputbox = Convert.ToString(inputboxVAT.GetAttribute("type"));
            Assert.Equal(expectedVATInputbox, actualVATInputbox);

            IWebElement inputboxPriceInclVAT = webDriver.FindElement(By.XPath("/html/body/div[4]/div/div[3]/div/div[1]/div/div[1]/form/div[8]/div[2]/input[1]"));
            String expectedPriceInclVATInputbox = "text";
            String actualPriceInclVATInputbox = Convert.ToString(inputboxPriceInclVAT.GetAttribute("type"));
            Assert.Equal(expectedPriceInclVATInputbox, actualPriceInclVATInputbox);





            IWebElement buttonReset = webDriver.FindElement(By.XPath("/html/body/div[4]/div/div[3]/div/div[1]/div/div[1]/form/div[10]/div[3]/input"));

            String expectedButtonReset = "Reset";
            String actualButtonReset = Convert.ToString(buttonReset.GetAttribute("value"));
            Assert.Equal(expectedButtonReset, actualButtonReset);

            Assert.True(buttonReset.Displayed);
        }


        [Theory]
        [InlineData("Switzerland", "/html/body/div[4]/div/div[3]/div/div[1]/div/div[1]/form/div[4]/div[2]/label[1]", "/html/body/div[4]/div/div[3]/div/div[1]/div/div[1]/form/div[6]/div[1]/label", "/html/body/div[4]/div/div[3]/div/div[1]/div/div[1]/form/div[6]/div[2]/input[1]", 100, 2.50, 102.50, "× 0.025000", "× 0.024390")]
        [InlineData("Switzerland", "/html/body/div[4]/div/div[3]/div/div[1]/div/div[1]/form/div[4]/div[2]/label[2]", "/html/body/div[4]/div/div[3]/div/div[1]/div/div[1]/form/div[6]/div[1]/label", "/html/body/div[4]/div/div[3]/div/div[1]/div/div[1]/form/div[6]/div[2]/input[1]", 100, 3.70, 103.70, "× 0.037000", "× 0.035680")]
        [InlineData("Switzerland", "/html/body/div[4]/div/div[3]/div/div[1]/div/div[1]/form/div[4]/div[2]/label[3]", "/html/body/div[4]/div/div[3]/div/div[1]/div/div[1]/form/div[6]/div[1]/label", "/html/body/div[4]/div/div[3]/div/div[1]/div/div[1]/form/div[6]/div[2]/input[1]", 100, 7.70, 107.70, "× 0.077000", "× 0.071495")]        

        public void Testcase2_Calkoo_Switzerland_PriceWithoutVAT(String Country, String xPathVATRate, String checkBoxInputvalue, String inputField, double inputData, double expectedResult1, double expectedResult2Gross, string multiplier1Net, string multiplier2Gross)
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
            webDriver.FindElement(By.XPath(checkBoxInputvalue)).Click();

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
