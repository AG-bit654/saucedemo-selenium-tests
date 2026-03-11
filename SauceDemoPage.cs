using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
namespace vjezba 
{
    public class SauceDemoPage
    {
        private IWebDriver driver;
        private WebDriverWait wait;
        public SauceDemoPage (IWebDriver driver)
        {
            this.driver = driver;
            this.wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
        }
        public void Otvori ()
        {
            
        driver.Navigate().GoToUrl("https://saucedemo.com");
        wait.Until(d =>d.FindElement(By.TagName("body")).Displayed);
        }
public void Login (string username, string password)
{
    driver.FindElement(By.Id("user-name")).SendKeys(username);
    driver.FindElement(By.Id("password")).SendKeys(password);
    driver.FindElement(By.Id("login-button")).Click();
}
}
}