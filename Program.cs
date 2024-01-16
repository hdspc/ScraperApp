using System;
using System.IO;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Collections.Generic;


namespace SeleniumDocs.Hello;

public static class HelloSelenium
{
    public static void Main()
    {

        var service = ChromeDriverService.CreateDefaultService();

        int pageNum = 1;

       


        var chromeOptions = new ChromeOptions();
        chromeOptions.AddArgument("--test-type");
        chromeOptions.AddExcludedArguments("excludeSwitches", "enable-logging");

        IWebDriver driver = new ChromeDriver(chromeOptions);
        driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);


        string title = driver.Title;

        driver.Manage().Window.Minimize();
        driver.Navigate().GoToUrl("https://www.retrojunk.com/commercials?page=1&sortColumn=DateAdded&sortOrder=Desc&decade=1990");
       
        IList<IWebElement> imageLinks = driver.FindElements(By.ClassName("img-wrap"));


        try

        {
            loopMethod(imageLinks);
            //pageNum++;
        }

            catch (StaleElementReferenceException ex)
       
        {
            Console.WriteLine("exception caught"+ ex.ToString());
        }

        Console.WriteLine(title.ToString());
        Console.WriteLine("Test");

        // driver.Quit();

         void loopMethod(IList<IWebElement> elementList)
       
                {
          


            // Create a StreamWriter to write to a text file
            using (StreamWriter writer = new StreamWriter("image_urls.txt", true)) // Open the file in append mode
                    {
                        writer.WriteLine(DateTime.Now.ToString());

                        foreach (IWebElement e in elementList)
                        {
                    System.Console.WriteLine("page number = " + pageNum.ToString());
                           // System.Console.WriteLine(e.GetAttribute("href"));
                           writer.WriteLine(e.GetAttribute("href"));
                        }
                        Console.WriteLine("Image URLs from page " + driver.Url + " have been saved to image_urls.txt");
                    }


               }

    }


}
