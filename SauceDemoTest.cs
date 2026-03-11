using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;

namespace vjezba
{
[TestClass]
    public class SauceDemoTest
    {
        [TestInitialize]
        public void Init() => Driver.Initialize();

        [TestCleanup]
        public void Cleanup() => Driver.Close();
[TestMethod]
public void Test1_Login ()
{
    Assert.IsNotNull(Driver.Instance, "Driver nije iniciliziran!");
    SauceDemoPage sauceDemo = new SauceDemoPage (Driver.Instance);
    sauceDemo.Otvori();
    sauceDemo.Login("standard_user", "secret_sauce");
    Console.WriteLine(Driver.Instance.Url);
    Assert.IsTrue(Driver.Instance.Url.Contains("inventory"), "Login nije uspio!");
}
[TestMethod]
public void Test2_pogresanLogin()
{
    Assert.IsNotNull(Driver.Instance, "Driver nije inicijaliziran!");
    SauceDemoPage sauceDemo = new SauceDemoPage(Driver.Instance);
    sauceDemo.Otvori();
    sauceDemo.Login("pogresanUser", "pogresnaLozinka");
    Assert.IsTrue(Driver.Instance.Url.Contains("saucedemo.com"), "Nešto nije u redu!");
}
}
}
