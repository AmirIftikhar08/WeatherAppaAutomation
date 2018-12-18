using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace WeatherAppAutomation
{
    [TestClass]
    public class TestCases : TestBase
    {
        //Improvement: Need to research on how to find items by test-data attribute

        [TestMethod]
        [TestCategory("MainSystem")]
        //Ensure you can check the weather for Edinburgh
        public void CheckWeatherForEdinburgh()
        {
            driver.Navigate().GoToUrl("http://localhost:3000/");
            EnterText("city", "Edinburgh");
            PressEnter("city");
            CloseDriver();

            //Improvement: Verification required to confirm weather forecast has changed to reflect Edinburgh's weather
        }

        [TestMethod]
        [TestCategory("MainSystem")]
        //Ensure you get an error message when searching for an invalid city
        public void CheckWeatherForInvalidCity()
        {
            driver.Navigate().GoToUrl("http://localhost:3000/");
            EnterText("city", "abc");
            PressEnter("city");
            FindElementByDiv("Error retrieving the forecast");
            CloseDriver();
        }

        [TestMethod]
        [TestCategory("MainSystem")]
        //Ensure you can drill down to 3 hourly forecast by clicking on the first day
        public void Open3HourView()
        {
            driver.Navigate().GoToUrl("http://localhost:3000/");
            FindElementByXPath("/html/body/div[1]/div/div[1]/div[1]/span[1]/span[1]");
            CloseDriver();

            //Improvement: Verification required to confirm 3 hourly forecast was shown
        }

        [TestMethod]
        [TestCategory("MainSystem")]
        //Ensure you can close the 3 hourly forecast drill down by clicking on the first day when it is open
        public void Close3HourView()
        {
            driver.Navigate().GoToUrl("http://localhost:3000/");
            FindElementByXPath("/html/body/div[1]/div/div[1]/div[1]/span[1]/span[1]");
            FindElementByXPath("/html/body/div[1]/div/div[1]/div[1]/span[1]/span[1]");
            CloseDriver();

            //Improvement: Verification required to confirm 3 hourly forecast is not visible
        }
    }
}
