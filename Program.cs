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

        for (int pageNum = 1; pageNum < 719; pageNum++)
        {
            driver.Navigate().GoToUrl($"https://www.retrojunk.com/commercials?page={pageNum}&sortColumn=DateAdded&sortOrder=Desc&decade=1990");

            try

            {
                IList<IWebElement> imageLinks = driver.FindElements(By.ClassName("img-wrap"));
               
                loopMethod(imageLinks, pageNum);

            }

            catch (StaleElementReferenceException ex)

            {
                Console.WriteLine("exception caughtttttttttttttttttttttttttttttttttttttt" + ex);
                      
            }

            
        }

        driver.Close();

        static void loopMethod(IList<IWebElement> elementList, int pageNumber)

        {
            using StreamWriter writer = new("image_urls.txt", true);

            foreach (IWebElement e in elementList)
            {

                Console.WriteLine(pageNumber.ToString() + e.GetAttribute("href"));
                writer.WriteLine(e.GetAttribute("href"));


            }

        }

    }


}
