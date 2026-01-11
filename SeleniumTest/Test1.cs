using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using System.Collections.ObjectModel;

namespace SeleniumTest
{
    [TestClass]
    public class Test1
    {
        private static IWebDriver driver;

        [ClassInitialize]
        public static void Setup(TestContext context)
        {
            // Initialize the Firefox driver - Can be changed to other browsers
            // ChromeDriver, EdgeDriver, etc.
            driver = new FirefoxDriver();
            // Change the URL to the location where your web application is hosted
            driver.Navigate().GoToUrl(@"http://127.0.0.1:5500/index.html");
        }

        [ClassCleanup]
        public static void Teardown()
        {
            driver.Quit();
        }

        [TestMethod]
        public void TestGetById()
        {
            // Find the input field for ID and enter a value
            var idInput = driver.FindElement(By.Id("idInput"));
            idInput.Clear();
            idInput.SendKeys("1");
            // Find and click the button to get art by ID
            var getByIdButton = driver.FindElement(By.Id("getIdButton"));
            getByIdButton.Click();
            // Wait for the result to be displayed
            System.Threading.Thread.Sleep(1000); // Simple wait, consider using WebDriverWait for better practice
            // Verify the result
            var resultLi = driver.FindElement(By.Id("list"));
            string resultText = resultLi.Text;
            Assert.IsTrue(resultText.Contains("Mona Lisa"), "The art with ID 1 should be Mona Lisa.");
        }

        [TestMethod]
        public void TestGetAll()
        {
            var clearBtn = driver.FindElement(By.Id("clean"));
            clearBtn.Click();
            System.Threading.Thread.Sleep(500);
            // Find and click the button to get all arts
            var getAllButton = driver.FindElement(By.Id("getAllButton"));
            getAllButton.Click();
            // Wait for the results to be displayed
            System.Threading.Thread.Sleep(1000); // Simple wait, consider using WebDriverWait for better practice
            // Verify the results
            var resultLi = driver.FindElement(By.Id("FullList"));
            string resultText = resultLi.Text;
            Assert.IsTrue(resultText.Contains("Mona Lisa"), "The list should contain Mona Lisa.");
            Assert.IsTrue(resultText.Contains("The Starry Night"), "The list should contain The Starry Night.");
            Assert.IsTrue(resultText.Contains("The Thinker"), "The list should contain The Thinker.");
        }

    }
}
