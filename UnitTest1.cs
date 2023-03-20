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

namespace Selenium.NetCore.Test
{
    public class ChromeTests : IDisposable
    {
        public static IWebDriver webDriver;
        
        private readonly ITestOutputHelper output;

        //public static  IEdriver;

        public ChromeTests(ITestOutputHelper output)
        {
            this.output = output;
            var directory = Directory.GetCurrentDirectory();
            //var pathDrivers = directory + "";
            var pathDrivers = "C:/Users/gluck/OneDrive/Documents/1 Structured Random Kft/elszámolás/2 OLM/selenium-cshap-sample-master/drivers";
            //"C:/Users/gluck/OneDrive/Documents/1 Structured Random Kft/elszámolás/2 OLM/selenium-cshap-sample-master/drivers
            webDriver = new ChromeDriver(pathDrivers);

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

        
        [Fact]
        public void OLM_0_SetToBlocked()
        {
            webDriver.Navigate().GoToUrl("https://olm.testcaselab.com/projects/OLM/test_run/68256?sort_dir=asc&sort_attr=created_at&test_case_id=1191221");
            webDriver.Manage().Window.Maximize();

            Thread.Sleep(1000);

            webDriver.FindElement(By.XPath("/html/body/div[1]/div[3]/div/div/form/div[1]/div/input")).SendKeys("gluckgabor@gmail.com");
            webDriver.FindElement(By.Name("user[password]")).SendKeys("welcometoten10REM#");
            webDriver.FindElement(By.XPath("/html/body/div[1]/div[3]/div/div/form/div[4]/input")).Click();

            Thread.Sleep(1000);

            // The minified JavaScript to execute
            const string script =
                "var timeId=setInterval(function(){window.scrollY<document.body.scrollHeight-window.screen.availHeight?window.scrollTo(0,document.body.scrollHeight):(clearInterval(timeId),window.scrollTo(0,0))},5000);";

            // Start Scrolling
            var jse = (IJavaScriptExecutor)webDriver;
            jse.ExecuteScript(script);

            WebDriverWait wait = new WebDriverWait(webDriver, TimeSpan.FromSeconds(100));

            //3
            wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//*[contains(text(), 'OLM-3')]")));

            Actions action = new Actions(webDriver);
            action.MoveToElement(webDriver.FindElement(By.XPath("//*[contains(text(), 'OLM-3')]"))).MoveByOffset(73, 8).Click().Perform();

            Thread.Sleep(1000);

            wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("/html/body/div[1]/div/test-run-page/div/div[2]/div[5]/div/test-result/div[3]/test-result-details/div[1]/statuses-on-test-result/div/div/button[2]")));
            webDriver.FindElement(By.XPath("/html/body/div[1]/div/test-run-page/div/div[2]/div[5]/div/test-result/div[3]/test-result-details/div[1]/statuses-on-test-result/div/div/button[2]")).Click();

            //6
            wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//*[contains(text(), 'OLM-6')]")));

            action.MoveToElement(webDriver.FindElement(By.XPath("//*[contains(text(), 'OLM-6')]"))).MoveByOffset(73, 8).Click().Perform();

            Thread.Sleep(1000);

            wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("/html/body/div[1]/div/test-run-page/div/div[2]/div[5]/div/test-result/div[3]/test-result-details/div[1]/statuses-on-test-result/div/div/button[2]")));
            webDriver.FindElement(By.XPath("/html/body/div[1]/div/test-run-page/div/div[2]/div[5]/div/test-result/div[3]/test-result-details/div[1]/statuses-on-test-result/div/div/button[2]")).Click();


            //24
            wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//*[contains(text(), 'OLM-24')]")));

            action.MoveToElement(webDriver.FindElement(By.XPath("//*[contains(text(), 'OLM-24')]"))).MoveByOffset(73, 8).Click().Perform();

            Thread.Sleep(1000);

            wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("/html/body/div[1]/div/test-run-page/div/div[2]/div[5]/div/test-result/div[3]/test-result-details/div[1]/statuses-on-test-result/div/div/button[2]")));
            webDriver.FindElement(By.XPath("/html/body/div[1]/div/test-run-page/div/div[2]/div[5]/div/test-result/div[3]/test-result-details/div[1]/statuses-on-test-result/div/div/button[2]")).Click();


            //29
            //wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//*[contains(text(), 'OLM-29')]")));

            //action.MoveToElement(webDriver.FindElement(By.XPath("//*[contains(text(), 'OLM-29')]"))).MoveByOffset(73, 8).Click().Perform();

            //Thread.Sleep(1000);

            //wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("/html/body/div[1]/div/test-run-page/div/div[2]/div[5]/div/test-result/div[3]/test-result-details/div[1]/statuses-on-test-result/div/div/button[2]")));
            //webDriver.FindElement(By.XPath("/html/body/div[1]/div/test-run-page/div/div[2]/div[5]/div/test-result/div[3]/test-result-details/div[1]/statuses-on-test-result/div/div/button[2]")).Click();

            //31
            wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//*[contains(text(), 'OLM-31')]")));

            action.MoveToElement(webDriver.FindElement(By.XPath("//*[contains(text(), 'OLM-31')]"))).MoveByOffset(73, 8).Click().Perform();

            Thread.Sleep(1000);

            wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("/html/body/div[1]/div/test-run-page/div/div[2]/div[5]/div/test-result/div[3]/test-result-details/div[1]/statuses-on-test-result/div/div/button[2]")));
            webDriver.FindElement(By.XPath("/html/body/div[1]/div/test-run-page/div/div[2]/div[5]/div/test-result/div[3]/test-result-details/div[1]/statuses-on-test-result/div/div/button[2]")).Click();

            //57
            wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//*[contains(text(), 'OLM-57')]")));

            action.MoveToElement(webDriver.FindElement(By.XPath("//*[contains(text(), 'OLM-57')]"))).MoveByOffset(73, 8).Click().Perform();

            Thread.Sleep(1000);

            wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("/html/body/div[1]/div/test-run-page/div/div[2]/div[5]/div/test-result/div[3]/test-result-details/div[1]/statuses-on-test-result/div/div/button[2]")));
            webDriver.FindElement(By.XPath("/html/body/div[1]/div/test-run-page/div/div[2]/div[5]/div/test-result/div[3]/test-result-details/div[1]/statuses-on-test-result/div/div/button[2]")).Click();

            //83
            wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//*[contains(text(), 'OLM-83')]")));

            action.MoveToElement(webDriver.FindElement(By.XPath("//*[contains(text(), 'OLM-83')]"))).MoveByOffset(73, 8).Click().Perform();

            Thread.Sleep(1000);

            wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("/html/body/div[1]/div/test-run-page/div/div[2]/div[5]/div/test-result/div[3]/test-result-details/div[1]/statuses-on-test-result/div/div/button[2]")));
            webDriver.FindElement(By.XPath("/html/body/div[1]/div/test-run-page/div/div[2]/div[5]/div/test-result/div[3]/test-result-details/div[1]/statuses-on-test-result/div/div/button[2]")).Click();


            //84
            wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//*[contains(text(), 'OLM-84')]")));

            action.MoveToElement(webDriver.FindElement(By.XPath("//*[contains(text(), 'OLM-84')]"))).MoveByOffset(73, 8).Click().Perform();

            Thread.Sleep(1000);

            wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("/html/body/div[1]/div/test-run-page/div/div[2]/div[5]/div/test-result/div[3]/test-result-details/div[1]/statuses-on-test-result/div/div/button[2]")));
            webDriver.FindElement(By.XPath("/html/body/div[1]/div/test-run-page/div/div[2]/div[5]/div/test-result/div[3]/test-result-details/div[1]/statuses-on-test-result/div/div/button[2]")).Click();


            //Scroll to bottom of leftmost div
            IWebElement divWithScrollbarElement = webDriver.FindElement(By.XPath("/html/body/div[1]/div/test-run-page/div/div[2]/div[1]/div[1]/test-case-run-list/div[4]"));

            IWebElement elementToScrollTo = webDriver.FindElement(By.XPath("/html/body/div[1]/div/test-run-page/div/div[2]/div[1]/div[1]/test-case-run-list/div[4]/div/div/div[42]/div[2]/div/span/test-case-label"));

            jse.ExecuteScript("arguments[0].scrollTo(0, arguments[0].scrollHeight)", divWithScrollbarElement);



            //114
            wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//*[contains(text(), 'OLM-114')]")));

            action.MoveToElement(webDriver.FindElement(By.XPath("//*[contains(text(), 'OLM-114')]"))).MoveByOffset(73, 8).Click().Perform();

            Thread.Sleep(1000);

            wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("/html/body/div[1]/div/test-run-page/div/div[2]/div[5]/div/test-result/div[3]/test-result-details/div[1]/statuses-on-test-result/div/div/button[2]")));
            webDriver.FindElement(By.XPath("/html/body/div[1]/div/test-run-page/div/div[2]/div[5]/div/test-result/div[3]/test-result-details/div[1]/statuses-on-test-result/div/div/button[2]")).Click();


            //115
            wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//*[contains(text(), 'OLM-115')]")));

            action.MoveToElement(webDriver.FindElement(By.XPath("//*[contains(text(), 'OLM-115')]"))).MoveByOffset(73, 8).Click().Perform();

            Thread.Sleep(1000);

            wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("/html/body/div[1]/div/test-run-page/div/div[2]/div[5]/div/test-result/div[3]/test-result-details/div[1]/statuses-on-test-result/div/div/button[2]")));
            webDriver.FindElement(By.XPath("/html/body/div[1]/div/test-run-page/div/div[2]/div[5]/div/test-result/div[3]/test-result-details/div[1]/statuses-on-test-result/div/div/button[2]")).Click();


            //116
            wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//*[contains(text(), 'OLM-116')]")));

            action.MoveToElement(webDriver.FindElement(By.XPath("//*[contains(text(), 'OLM-116')]"))).MoveByOffset(73, 8).Click().Perform();

            Thread.Sleep(1000);

            wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("/html/body/div[1]/div/test-run-page/div/div[2]/div[5]/div/test-result/div[3]/test-result-details/div[1]/statuses-on-test-result/div/div/button[2]")));
            webDriver.FindElement(By.XPath("/html/body/div[1]/div/test-run-page/div/div[2]/div[5]/div/test-result/div[3]/test-result-details/div[1]/statuses-on-test-result/div/div/button[2]")).Click();


            //117
            wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//*[contains(text(), 'OLM-117')]")));

            action.MoveToElement(webDriver.FindElement(By.XPath("//*[contains(text(), 'OLM-117')]"))).MoveByOffset(73, 8).Click().Perform();

            Thread.Sleep(1000);

            wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("/html/body/div[1]/div/test-run-page/div/div[2]/div[5]/div/test-result/div[3]/test-result-details/div[1]/statuses-on-test-result/div/div/button[2]")));
            webDriver.FindElement(By.XPath("/html/body/div[1]/div/test-run-page/div/div[2]/div[5]/div/test-result/div[3]/test-result-details/div[1]/statuses-on-test-result/div/div/button[2]")).Click();


            //118
            wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//*[contains(text(), 'OLM-118')]")));

            action.MoveToElement(webDriver.FindElement(By.XPath("//*[contains(text(), 'OLM-118')]"))).MoveByOffset(73, 8).Click().Perform();

            Thread.Sleep(1000);

            wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("/html/body/div[1]/div/test-run-page/div/div[2]/div[5]/div/test-result/div[3]/test-result-details/div[1]/statuses-on-test-result/div/div/button[2]")));
            webDriver.FindElement(By.XPath("/html/body/div[1]/div/test-run-page/div/div[2]/div[5]/div/test-result/div[3]/test-result-details/div[1]/statuses-on-test-result/div/div/button[2]")).Click();


            //123 Teljesítményértékelő: Tesztelői szempontból Blocked, mivel nem látjuk a teljesítményértékelést a tesztkörnyezeten.
            wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//*[contains(text(), 'OLM-123')]")));

            action.MoveToElement(webDriver.FindElement(By.XPath("//*[contains(text(), 'OLM-123')]"))).MoveByOffset(73, 8).Click().Perform();

            Thread.Sleep(1000);

            wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("/html/body/div[1]/div/test-run-page/div/div[2]/div[5]/div/test-result/div[3]/test-result-details/div[1]/statuses-on-test-result/div/div/button[2]")));
            webDriver.FindElement(By.XPath("/html/body/div[1]/div/test-run-page/div/div[2]/div[5]/div/test-result/div[3]/test-result-details/div[1]/statuses-on-test-result/div/div/button[2]")).Click();


            //133
            wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//*[contains(text(), 'OLM-133')]")));

            action.MoveToElement(webDriver.FindElement(By.XPath("//*[contains(text(), 'OLM-133')]"))).MoveByOffset(73, 8).Click().Perform();

            Thread.Sleep(1000);

            wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("/html/body/div[1]/div/test-run-page/div/div[2]/div[5]/div/test-result/div[3]/test-result-details/div[1]/statuses-on-test-result/div/div/button[2]")));
            webDriver.FindElement(By.XPath("/html/body/div[1]/div/test-run-page/div/div[2]/div[5]/div/test-result/div[3]/test-result-details/div[1]/statuses-on-test-result/div/div/button[2]")).Click();

            //147
            wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//*[contains(text(), 'OLM-147')]")));

            action.MoveToElement(webDriver.FindElement(By.XPath("//*[contains(text(), 'OLM-147')]"))).MoveByOffset(73, 8).Click().Perform();

            Thread.Sleep(1000);

            wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("/html/body/div[1]/div/test-run-page/div/div[2]/div[5]/div/test-result/div[3]/test-result-details/div[1]/statuses-on-test-result/div/div/button[2]")));
            webDriver.FindElement(By.XPath("/html/body/div[1]/div/test-run-page/div/div[2]/div[5]/div/test-result/div[3]/test-result-details/div[1]/statuses-on-test-result/div/div/button[2]")).Click();


            //498
            wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//*[contains(text(), 'OLM-498')]")));

            action.MoveToElement(webDriver.FindElement(By.XPath("//*[contains(text(), 'OLM-498')]"))).MoveByOffset(73, 8).Click().Perform();

            Thread.Sleep(1000);

            wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("/html/body/div[1]/div/test-run-page/div/div[2]/div[5]/div/test-result/div[3]/test-result-details/div[1]/statuses-on-test-result/div/div/button[2]")));
            webDriver.FindElement(By.XPath("/html/body/div[1]/div/test-run-page/div/div[2]/div[5]/div/test-result/div[3]/test-result-details/div[1]/statuses-on-test-result/div/div/button[2]")).Click();


            Thread.Sleep(1000);

            int expected = 14;
            int actual = Convert.ToInt32(webDriver.FindElement(By.XPath("/html/body/div[1]/div/test-run-page/div/div[2]/div[1]/div[1]/test-case-run-list/div[1]/div[1]/div/div/test-run-progress-bar/div[2]/span[2]/a/span[2]")).Text.Substring(0,2));

            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData("gluckgabor@gmail.com", "Asdf1234")]
        public void OLM_2_Bejelentkezes_Hun(String login_email, String login_password)
        {

            webDriver.Navigate().GoToUrl("https://olm-test.devwing.hu/login");
            webDriver.Manage().Window.Maximize();

            webDriver.FindElement(By.XPath("/html/body/div/header/div[2]/form/button[1]")).Click();
            webDriver.FindElement(By.Name("login_email")).SendKeys(login_email);
            webDriver.FindElement(By.Name("login_password")).SendKeys(login_password);

            WebDriverWait wait = new WebDriverWait(webDriver, TimeSpan.FromSeconds(10));

            webDriver.FindElement(By.CssSelector("#submit > input[type=submit]")).Click();
            IWebElement SearchResult = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.XPath("/html/body/div[2]/div[2]/div/div/div[1]/h3")));

            //Thread.Sleep(5000);

            var expected = "Köszöntjük Rendszerünkben Gábor Glück!";
            String actual = webDriver.FindElement(By.XPath("/html/body/div[2]/div[2]/div/div/div[1]/h3")).Text;

            Assert.Equal(expected, actual);
        }

        public void Dispose()
        {
            webDriver.Dispose();
        }

        [Theory]
        [InlineData("xy@gmail.com", "DummyPasswordFails1", "HUN")]
        [InlineData("xy@gmail.com", "DummyPasswordFails1", "ENG")]
        [InlineData("xy@gmail.com", "DummyPasswordFails1", "GER")]
        public void OLM_2_Bejelentkezes_negativetest1(String login_email, String login_password, String lang)
        {

            webDriver.Navigate().GoToUrl("https://olm-test.devwing.hu/login");
            webDriver.Manage().Window.Maximize();

            if (lang == "HUN")
            {
                webDriver.FindElement(By.XPath("/html/body/div/header/div[2]/form/button[1]")).Click();

                webDriver.FindElement(By.Name("login_email")).SendKeys(login_email);
                webDriver.FindElement(By.Name("login_password")).SendKeys(login_password);

                webDriver.FindElement(By.CssSelector("#submit > input[type=submit]")).Click();

                var expected = "Hibás adat!";
                String actual = webDriver.FindElement(By.XPath("/html/body/div/section/form/fieldset[1]/div[3]/span")).Text;
                Assert.Equal(expected, actual);
            }
            else if (lang == "ENG")
            {
                webDriver.FindElement(By.XPath("/html/body/div/header/div[2]/form/button[2]")).Click();

                webDriver.FindElement(By.Name("login_email")).SendKeys(login_email);
                webDriver.FindElement(By.Name("login_password")).SendKeys(login_password);

                webDriver.FindElement(By.CssSelector("#submit > input[type=submit]")).Click();

                var expected = "Incorrect login data!";
                String actual = webDriver.FindElement(By.XPath("/html/body/div/section/form/fieldset[1]/div[3]/span")).Text;
                Assert.Equal(expected, actual);
            }
            else if (lang == "GER")
            {
                webDriver.FindElement(By.XPath("/html/body/div/header/div[2]/form/button[3]")).Click();

                webDriver.FindElement(By.Name("login_email")).SendKeys(login_email);
                webDriver.FindElement(By.Name("login_password")).SendKeys(login_password);

                webDriver.FindElement(By.CssSelector("#submit > input[type=submit]")).Click();

                var expected = "Falschen Daten!";
                String actual = webDriver.FindElement(By.XPath("/html/body/div/section/form/fieldset[1]/div[3]/span")).Text;
                Assert.Equal(expected, actual);
            }
        }




        [Fact]
        public void OLM_1_Regisztracio_Hun()
        {
            
        String company_name = "SR_Kft" + (DateTime.Now.ToString("yyyy.MM.dd")); //SR_Kft_2023.01.10
            output.WriteLine(company_name);

            Debug.Print(company_name);
            String company_tax_number = Convert.ToString(RandomDigits(11));
            String user_title = "I";
            String last_name = "Glück";
            String first_name = "Gábor";
            String email = "gluckgabor+" + Convert.ToString(RandomDigits(10)) + "@gmail.com";
            output.WriteLine(email);

            TextWriter tw = new StreamWriter("C:/Users/gluck/OneDrive/Documents/2 Prealfa Szoftver Bt/elszámolás/OL Munkaidő Kft/OLM_Registered_Company.txt");

            // write lines of text to the file
            tw.WriteLine(company_name);
            tw.WriteLine(email);

            // close the stream     
            tw.Close();

            String phone_number = "+36203271897";
            String number_of_employees = "3";
            String password = "Asdf1234";  
            String password_2 = "Asdf1234";

            webDriver.Navigate().GoToUrl("https://olm-test.devwing.hu/login");
            webDriver.Manage().Window.Maximize();

            webDriver.FindElement(By.XPath("/html/body/div/section/h2/a")).Click();

            webDriver.FindElement(By.Name("company_name")).SendKeys(company_name);
            webDriver.FindElement(By.Name("company_tax_number")).SendKeys(company_tax_number);
            webDriver.FindElement(By.Name("user_title")).SendKeys(user_title);
            webDriver.FindElement(By.Name("last_name")).SendKeys(last_name);
            webDriver.FindElement(By.Name("first_name")).SendKeys(first_name);
            webDriver.FindElement(By.Name("email")).SendKeys(email);
            webDriver.FindElement(By.Name("phone_number")).SendKeys(phone_number);
            webDriver.FindElement(By.Name("number_of_employees")).SendKeys(number_of_employees);
            webDriver.FindElement(By.Name("password")).SendKeys(password);
            webDriver.FindElement(By.Name("password_2")).SendKeys(password_2);
            webDriver.FindElement(By.XPath("/html/body/div/section/form/fieldset[10]/a")).Click();

            Thread.Sleep(2000);

            webDriver.FindElement(By.XPath("/html/body/div/section/form/fieldset[11]/div/input")).Click();
            
            var expected = "Köszönjük, hogy regisztrált Rendszerünkbe!";
            String actual = webDriver.FindElement(By.XPath("/html/body/div/div[2]/section/div/p[1]")).Text;

            Assert.Equal(expected, actual);
        }

        
        [Theory]
        [InlineData("gluckgabor@gmail.com", "Asdf1234")]
        public void OLM_5_IE_kompatibilitas(String login_email, String login_password)
        {
            new DriverManager().SetUpDriver(new InternetExplorerConfig());
            IWebDriver IEdriver = new InternetExplorerDriver();

            IEdriver.Manage().Window.Maximize();

            IEdriver.Navigate().GoToUrl("https://olm-test.devwing.hu/login");
            

            TimeSpan ts = TimeSpan.FromSeconds(10);

            WebDriverWait Test_Wait = new WebDriverWait(IEdriver, ts);
            Test_Wait.Until(ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.Name("login_email")));
            
            IEdriver.FindElement(By.Name("login_email")).SendKeys(login_email);
            IEdriver.FindElement(By.Name("login_password")).SendKeys(login_password);
            IEdriver.FindElement(By.Id("submit")).Click();

            IEdriver.FindElement(By.Id("submit")).Click();

            var expected = "Nem támogatott böngésző!";
            String actual = webDriver.FindElement(By.ClassName("alert alert-danger w-100 position-fixed top-0 justify-content-center align-items-center p-0 border-0")).Text;

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void OLM_7_Szuro()
        {

        }

        public string RandomDigits(int length)
        {
            var random = new Random();
            string s = string.Empty;
            for (int i = 0; i < length; i++)
                s = String.Concat(s, random.Next(10).ToString());
            return s;
        }

    }

}