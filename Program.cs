using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;


namespace SeleniumDocs.Hello;

public static class HelloSelenium
{
    public static void Main()
    {

        var chromeOptions = new ChromeOptions();
        chromeOptions.AddArgument("--test-type");
        chromeOptions.AddExcludedArguments("excludeSwitches", "enable-logging");
        IWebDriver driver = new ChromeDriver(chromeOptions);
        driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);


        string title = driver.Title;


        for (int pageNum = 1; pageNum < 10; pageNum++)
        {
            driver.Navigate().GoToUrl($"https://www.retrojunk.com/commercials?page={pageNum}&sortColumn=DateAdded&sortOrder=Desc&decade=1990");

            try

            {
                IList<IWebElement> imageLinks = driver.FindElements(By.ClassName("img-wrap"));

                loopMethod(imageLinks, pageNum);


            }

            catch (StaleElementReferenceException ex)

            {
                Console.WriteLine("exception caught" + ex.ToString());
            }

            Console.WriteLine("Test");
            
        }

        driver.Close();

        void loopMethod(IList<IWebElement> elementList, int pageNumber)

        {
            // Create a StreamWriter to write to a text file
            using (StreamWriter writer = new StreamWriter("image_urls.txt", true)) // Open the file in append mode
            {
                Console.WriteLine("page number = " + pageNumber.ToString());

                foreach (IWebElement e in elementList)
                {
                    Console.WriteLine(title.ToString());

                    Console.WriteLine(e.GetAttribute("href"));
                    writer.WriteLine(e.GetAttribute("href"));
                }
                Console.WriteLine("Image URLs from page " + driver.Url + " have been saved to image_urls.txt");
            }


        }

    }


}
