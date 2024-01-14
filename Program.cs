
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
        driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);


        string title = driver.Title;

        IList<IWebElement> elements = driver.FindElements(By.ClassName("grid-item"));
        foreach (IWebElement e in elements)
        {
            System.Console.WriteLine(e.Text);
            //e.Click();

        }
        driver.SwitchTo().NewWindow(WindowType.Tab);

        Console.WriteLine(title.ToString());
        Console.WriteLine("boner");

        //gridBox.Click();
        // driver.Quit();
    }
}
