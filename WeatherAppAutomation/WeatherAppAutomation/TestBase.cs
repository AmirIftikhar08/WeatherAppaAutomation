using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;


namespace WeatherAppAutomation
{
    public class TestBase
    {
        protected IWebDriver driver = new ChromeDriver();

        //Finds elements using XPath - used XPath finder Google Chrome extension to get path
        public void FindElementByXPath(string xPath)
        {
            try
            {
                var Btn = driver.FindElement(By.XPath(xPath));
                Btn.Click();
            }
            catch
            {
                Assert.Fail();
            }
        }

        //Finds the field, clears it and enters the text provided
        public void EnterText(string field, string text)
        {
            try
            {
                //Find and Update field
                var editField = driver.FindElement(By.Id(field));
                editField.Clear();

                //Check to make sure field has been cleared
                string textValue = editField.GetAttribute("value");
                Assert.AreEqual("", textValue);

                editField.SendKeys(text);
            }
            catch
            {
            }
        }

        //Finds the field and presses enter
        public void PressEnter(string field)
        {
            try
            {
                //Find field
                var editField = driver.FindElement(By.Id(field));

                editField.SendKeys(Keys.Return);
            }
            catch
            {
            }
        }

        //Closes the driver
        public void CloseDriver()
        {
            driver.Quit();
        }

        //Finds elements of type 'Div'
        public void FindElementByDiv(string divElement)
        {
            int count = 0;

            try
            {
                //Looks through all div elements for relevant text
                var allDivElements = driver.FindElements(By.TagName("div"));
                foreach (var element in allDivElements)
                {
                    count++;

                    if (element.Text == divElement)
                    {
                        element.Click();
                        break;
                    }

                    if (count == allDivElements.Count)
                    {                           
                        Assert.Fail();
                    }
                }
            }
            catch
            {
                Assert.Fail();
            }
        }
    }
}
