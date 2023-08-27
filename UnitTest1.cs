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
using AngleSharp.Common;
using AngleSharp.Dom;
using System.Net;
using System.Drawing;

namespace Selenium.NetCore.Test
{    
        public class ChromeTests
    {
        public static IWebDriver desktopWebDriver;
        public static IWebDriver mobileWebDriver;

        private readonly ITestOutputHelper output;
        
        public ChromeTests(ITestOutputHelper output)
        {
            this.output = output;
            var directory = Directory.GetCurrentDirectory();
            var pathDrivers = "C:/Users/gluck/.nuget/packages/selenium.webdriver.chromedriver/116.0.5845.98";
                        
            desktopWebDriver = new ChromeDriver(pathDrivers);
            desktopWebDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);

            ChromeOptions chromeOptions = new ChromeOptions();

            chromeOptions.EnableMobileEmulation("iPhone 12 Pro");
            chromeOptions.AddUserProfilePreference("safebrowsing.enabled", true);
            chromeOptions.AddUserProfilePreference("credentials_enable_service", false);
            chromeOptions.AddUserProfilePreference("profile.password_manager_enabled", false);

            mobileWebDriver = new ChromeDriver(pathDrivers, chromeOptions);

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

        public void testSetupLoggedInOnDesktop(string searchTerm) {
            desktopWebDriver.Navigate().GoToUrl("https://vimeo.com/");
            desktopWebDriver.Manage().Window.Maximize();
            Thread.Sleep(1000);

            desktopWebDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);

            desktopWebDriver.FindElement(By.XPath("/html/body/div[1]/div/div[1]/div/div/div/div[1]/div/header/nav/div[2]/button[1]")).Click();

            desktopWebDriver.FindElement(By.XPath("/html/body/div[2]/div[2]/div[2]/form[1]/input[1]")).SendKeys("ggautomatedt@gmail.com");

            desktopWebDriver.FindElement(By.XPath("/html/body/div[2]/div[2]/div[2]/form[1]/input[2]")).SendKeys("Testtest123!");

            desktopWebDriver.FindElement(By.XPath("/html/body/div[2]/div[2]/div[2]/form[1]/button/div")).Click();

            desktopWebDriver.FindElement(By.XPath("/html/body/div[1]/div[1]/div[4]/div/div[1]/form/div/div[2]/div/div")).Click();

            desktopWebDriver.FindElement(By.XPath("/html/body/div[1]/div[1]/div[4]/div/div[1]/form/div/div[2]/div/div[2]/span[2]/div[1]/div")).Click();

            desktopWebDriver.FindElement(By.XPath("/html[1]/body[1]/div[1]/div[1]/div[4]/div[1]/div[1]/form[1]/div[1]/div[1]/div[1]/div[1]/input[1]")).SendKeys(searchTerm);

            desktopWebDriver.FindElement(By.XPath("/html[1]/body[1]/div[1]/div[1]/div[4]/div[1]/div[1]/form[1]/div[1]/div[1]/div[1]/div[1]/input[1]")).Submit();
        }

        public void testSetupLoggedInOnMobile(string searchTerm)
        {
            desktopWebDriver.Close();

            mobileWebDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

            Thread.Sleep(1000);

            mobileWebDriver.Manage().Window.Maximize();

            mobileWebDriver.Navigate().GoToUrl("https://vimeo.com/");

            Thread.Sleep(1000);

            mobileWebDriver.FindElement(By.XPath("/html/body/div[1]/div/div[1]/div/div/div/div[1]/div/header/nav/div[2]/button[1]")).Click();


            mobileWebDriver.FindElement(By.XPath("/html/body/div[2]/div[2]/div[2]/form[1]/input[1]")).SendKeys("ggautomatedt@gmail.com");

            mobileWebDriver.FindElement(By.XPath("/html/body/div[2]/div[2]/div[2]/form[1]/input[2]")).SendKeys("Testtest123!");

            mobileWebDriver.FindElement(By.XPath("/html/body/div[2]/div[2]/div[2]/form[1]/button/div")).Click();

            mobileWebDriver.FindElement(By.XPath("/html/body/div[1]/div[1]/nav/div[1]/a")).Click();

            Thread.Sleep(500);

            mobileWebDriver.FindElement(By.XPath("/html/body/div[1]/div[2]/div[3]/div/div[1]/form/div/div[1]/div/div[1]/div/button")).Click();

            mobileWebDriver.FindElement(By.XPath("/html/body/form/input[1]")).SendKeys(searchTerm);

            mobileWebDriver.FindElement(By.XPath("/html/body/form/input[2]")).Click();
        }

        public void testSetupAsGuest(string searchTerm)
        {
            desktopWebDriver.Navigate().GoToUrl("https://vimeo.com/336812686");
            desktopWebDriver.Manage().Window.Maximize();
            Thread.Sleep(1000);
                        
            desktopWebDriver.FindElement(By.XPath("/html/body/div[1]/div[1]/div[4]/div/div[1]/form/div[1]/div[1]/div/div[1]/input")).SendKeys(searchTerm);

            desktopWebDriver.FindElement(By.XPath("/html/body/div[1]/div[1]/div[4]/div/div[1]/form/div[1]/div[1]/div/div[1]/input")).Submit();

            desktopWebDriver.Close();
            mobileWebDriver.Close();
        }



        //If you initiate a search, and have numerous results, no more than 18 results should be listed on one page. Pagination should be used for the rest.
        //Check the results as a Logged in user as well
        [Fact]
        public void OnePageResultCount() {

            testSetupLoggedInOnDesktop("Szeged");

            //verify result count on one page
            int resultCountOnOnePageExpected = 18;
            int resultCountOnTwoPageActual = desktopWebDriver.FindElements(By.XPath("/html/body/div[1]/div[2]/div/div/div[1]/div/div[2]/div/div[*]")).Count;
            
            string text = string.Format("count = {0}", resultCountOnTwoPageActual);

            Debug.Print(text);
            Assert.Equal(resultCountOnOnePageExpected, resultCountOnTwoPageActual);

            //Verifying if total result count is more than 18 
            IWebElement totalResultCountWebElement = desktopWebDriver.FindElement(By.XPath("/html[1]/body[1]/div[1]/div[2]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[2]/p[1]"));

            int index = Convert.ToString(totalResultCountWebElement.Text).IndexOf(" ");
            String totalResultCountText = Convert.ToString(totalResultCountWebElement.Text).Substring(0, index);

            double totalResultCountDouble;

            if (totalResultCountText.Contains("K"))
            {
                totalResultCountDouble = Convert.ToDouble(totalResultCountText.Substring(0, totalResultCountText.Length - 1).Replace(".",","))*1000;
            }
            else if (totalResultCountText.Contains("M"))
            {
                totalResultCountDouble = Convert.ToDouble(totalResultCountText.Substring(0, totalResultCountText.Length - 1).Replace(".", ",")) * 1000000;
            }
            else
            {
                totalResultCountDouble = Convert.ToInt32((totalResultCountText).Replace(",", ""));
            }

            Debug.Print(Convert.ToString(totalResultCountDouble));

            Assert.True(totalResultCountDouble > 18);

            //verify if pagination was used to display results
            int numberOfPages = desktopWebDriver.FindElements(By.XPath("/html/body/div[1]/div[2]/div/div/div[1]/div/div[3]/div/ol/li[*]")).Count;
            Debug.Print(Convert.ToString(numberOfPages));
            Assert.True(numberOfPages > 1);

            desktopWebDriver.Close();
            mobileWebDriver.Close();
        }

        
        //On the First page in the Paginator no “PREV” button should be shown
        [Fact]
        public void firstPageNoPrev() {

            testSetupLoggedInOnDesktop("Szeged");

            string textofFirstButton = desktopWebDriver.FindElements(By.XPath("/html/body/div[1]/div[2]/div/div/div[1]/div/div[3]/div/ol/li[*]")).GetItemByIndex(0).Text;

            Assert.True(textofFirstButton != "Prev");

            desktopWebDriver.Close();
            mobileWebDriver.Close();
        }


        //In the Last page of the Paginator no “NEXT” button should be shown
        [Fact]
        public void lastPageNoNext() {

            testSetupLoggedInOnDesktop("Szeged");

            IWebElement totalResultCountWebElement = desktopWebDriver.FindElement(By.XPath("/html[1]/body[1]/div[1]/div[2]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[2]/p[1]"));

            int index = Convert.ToString(totalResultCountWebElement.Text).IndexOf(" ");
            String totalResultCountText = Convert.ToString(totalResultCountWebElement.Text).Substring(0, index);

            double totalResultCountDouble = Convert.ToDouble(totalResultCountText.Replace(",", ""));

            int lastPageIndexInt = Convert.ToInt32(Math.Ceiling((totalResultCountDouble / 18)));
            desktopWebDriver.Navigate().GoToUrl("https://vimeo.com/search/page:" + lastPageIndexInt + "?q=szeged");

            int numberOfButtons = desktopWebDriver.FindElements(By.XPath("/html/body/div[1]/div[2]/div/div/div[1]/div/div[3]/div/ol/li[*]/a")).Count;

            string textofLastButton = desktopWebDriver.FindElements(By.XPath("/html/body/div[1]/div[2]/div/div/div[1]/div/div[3]/div/ol/li[*]/a")).GetItemByIndex(numberOfButtons-1).Text;

            Debug.Print(Convert.ToString(textofLastButton));
            Assert.True(textofLastButton != "Last");

            desktopWebDriver.Close();
            mobileWebDriver.Close();
        }


        //In between both buttons should be displayed
        [Fact]
        public void secondPageBothPrevAndNextButtonsShow() {

            testSetupLoggedInOnDesktop("Szeged");

            desktopWebDriver.Navigate().GoToUrl("https://vimeo.com/search/page:" + 2 + "?q=szeged");

            string textofFirstButton = desktopWebDriver.FindElements(By.XPath("/html/body/div[1]/div[2]/div/div/div[1]/div/div[3]/div/ol/li[*]")).GetItemByIndex(0).Text;

            Assert.True(textofFirstButton == "Prev");

            int numberOfButtons = desktopWebDriver.FindElements(By.XPath("/html/body/div[1]/div[2]/div/div/div[1]/div/div[3]/div/ol/li[*]/a")).Count;

            string textofLastButton = desktopWebDriver.FindElements(By.XPath("/html/body/div[1]/div[2]/div/div/div[1]/div/div[3]/div/ol/li[*]/a")).GetItemByIndex(numberOfButtons - 1).Text;

            Debug.Print(Convert.ToString(textofLastButton));
            Assert.True(textofLastButton == "Next");

            desktopWebDriver.Close();
            mobileWebDriver.Close();
        }


        bool IsLinkWorking(string url)
        {
            HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(url);

            //You can set some parameters in the "request" object...
            request.AllowAutoRedirect = true;

            try
            {
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                if (response.StatusCode == HttpStatusCode.OK)
                {
                  // Releases the resources of the response.
                    response.Close();
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch
            { //TODO: Check for the right exception here
                return false;
            }
        }

        //Check if the Links for the videos are working
        [Fact]
        public void videoLinksAreWorking() {

            testSetupLoggedInOnDesktop("duna timelapse");

            IWebElement totalResultCountWebElement = desktopWebDriver.FindElement(By.XPath("/html[1]/body[1]/div[1]/div[2]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[2]/p[1]"));

            int index = Convert.ToString(totalResultCountWebElement.Text).IndexOf(" ");
            String totalResultCountText = Convert.ToString(totalResultCountWebElement.Text).Substring(0, index);

            double totalResultCountDouble = Convert.ToDouble(totalResultCountText.Replace(",", ""));

            int lastPageIndexInt = Convert.ToInt32(Math.Ceiling((totalResultCountDouble / 18)));

            var ParentElement = desktopWebDriver.FindElement(By.XPath("/html/body/div[1]/div[2]/div/div/div[1]/div/div[2]/div"));

            IList<IWebElement> links = ParentElement.FindElements(By.TagName("a")); ;
            foreach (IWebElement link in links)
            {
                var url = link.GetAttribute("href");
                IsLinkWorking(url);
            }

            desktopWebDriver.Close();
            mobileWebDriver.Close();
        }


    //Check the Results counter is displaying the correct number of videos
    [Fact]
        public void resultsCounter() {

            testSetupLoggedInOnDesktop("Duna timelapse");

            IWebElement totalResultCountWebElement = desktopWebDriver.FindElement(By.XPath("/html[1]/body[1]/div[1]/div[2]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[2]/p[1]"));

            int index = Convert.ToString(totalResultCountWebElement.Text).IndexOf(" ");
            String totalResultCountText = Convert.ToString(totalResultCountWebElement.Text).Substring(0, index);

            double totalResultCountDouble = Convert.ToDouble(totalResultCountText.Replace(",", ""));

            int lastPageIndexInt = Convert.ToInt32(Math.Ceiling((totalResultCountDouble / 18)));

            int numberOfLinksTotal = 0;

            for (int i = 1; i < lastPageIndexInt+1; i++)
            {
                desktopWebDriver.Navigate().GoToUrl("https://vimeo.com/search/page:" + i + "?q=duna%20timelapse");
                IList<IWebElement> links = desktopWebDriver.FindElements(By.XPath("/html/body/div[1]/div[2]/div/div/div[1]/div/div[2]/div/div[*]"));
                numberOfLinksTotal += links.Count;
            }

            Assert.True(numberOfLinksTotal == Convert.ToInt32(totalResultCountText.Replace(",", "")));

            desktopWebDriver.Close();
            mobileWebDriver.Close();
        }


        //Check the results for Videos, On Demand, People, Channels, Groups
        [Fact]
        public void resultsVideos() {

        testSetupLoggedInOnDesktop("Duna");
            
        Assert.True(desktopWebDriver.FindElement(By.XPath("/html/body/div[1]/div[2]/div/div/div[2]/nav/div[1]/ul/li[1]/label/div/a")).Text == "Videos (10.4K)");

        desktopWebDriver.Close();
        mobileWebDriver.Close();
        }

        [Fact]
        public void resultsOnDemand() {

            testSetupLoggedInOnDesktop("Duna");

            Assert.True(desktopWebDriver.FindElement(By.XPath("/html/body/div[1]/div[2]/div/div/div[2]/nav/div[1]/ul/li[2]/label/div/a")).Text == "On Demand (24)");

        desktopWebDriver.Close();
        mobileWebDriver.Close();
        }

        [Fact]
        public void resultsPeople() {

            testSetupLoggedInOnDesktop("Duna");

            Assert.True(desktopWebDriver.FindElement(By.XPath("/html/body/div[1]/div[2]/div/div/div[2]/nav/div[1]/ul/li[3]/label/div/a")).Text == "People (636)");

        desktopWebDriver.Close();
        mobileWebDriver.Close();
        }

        [Fact]
        public void resultsChannels() {

            testSetupLoggedInOnDesktop("Duna");

            Assert.True(desktopWebDriver.FindElement(By.XPath("/html/body/div[1]/div[2]/div/div/div[2]/nav/div[1]/ul/li[4]/label/div/a")).Text == "Channels (29)");

        desktopWebDriver.Close();
        mobileWebDriver.Close();
        }

        [Fact]
        public void resultsGroups() {

            testSetupLoggedInOnDesktop("Duna");

            Assert.True(desktopWebDriver.FindElement(By.XPath("/html/body/div[1]/div[2]/div/div/div[2]/nav/div[1]/ul/li[5]/label/div/a")).Text == "Groups (5)");

        desktopWebDriver.Close();
        mobileWebDriver.Close();
        }


        //Check the results as Guest as well
        [Fact]
        public void resultsAsGuest() {

            testSetupAsGuest("Duna");
            Assert.True(desktopWebDriver.FindElement(By.XPath("/html/body/div[1]/div[2]/div/div/div[1]/div/div[1]/div/div[2]/p")).Text == "10.4K results for Duna");

        desktopWebDriver.Close();
        mobileWebDriver.Close();
        }
        
        //Check the results on mobile view as well
        [Fact]
        public void resultsOnMobileView() {

        testSetupLoggedInOnMobile("Duna");
        Assert.True(mobileWebDriver.FindElement(By.XPath("/html/body/div[1]/div[2]/div/div/div[1]/div/div[1]/div/div[2]/p")).Text == "10.4K results for Duna");

        mobileWebDriver.Close();
        }
    }
}
