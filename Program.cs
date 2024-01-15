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
        IWebDriver driver = new ChromeDriver();


        driver.Navigate().GoToUrl("https://www.retrojunk.com/commercials?page=1&sortColumn=DateAdded&sortOrder=Desc&decade=1990");


        string title = driver.Title;

        IList<IWebElement> elements = driver.FindElements(By.ClassName("grid-item"));
        IList<IWebElement> imageLinks = driver.FindElements(By.ClassName("img-wrap"));



 

            try
        {
            // Create a StreamWriter to write to a text file
            using (StreamWriter writer = new StreamWriter("image_urls.txt", true)) // Open the file in append mode
            {

                /* foreach (IWebElement e in elements)
                 {
                     driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);

                     System.Console.WriteLine(e.Text);

                 }
                */
                foreach (IWebElement e in imageLinks)
                {
                    driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);

                    System.Console.WriteLine(e.GetAttribute("href"));
                    writer.WriteLine(e.GetAttribute("href"));
                }
                Console.WriteLine("Image URLs from page " + driver.Url + " have been saved to image_urls.txt");
            }
        }
        catch (StaleElementReferenceException ex) {

            Console.WriteLine("exception caught");

        }

        Console.WriteLine(title.ToString());
        Console.WriteLine("Test");

        // driver.Quit();
    }
}
