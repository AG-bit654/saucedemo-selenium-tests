#nullable enable
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace vjezba
{
    public static class Driver
    {
        public static IWebDriver? Instance { get; set; }

        public static void Initialize()
        {
            var options = new ChromeOptions();
            // Dodajemo ove dvije linije da zaobiđemo probleme sa sistemom
            options.AddArgument("--remote-allow-origins=*");
            options.AddArgument("--disable-notifications");
            options.AddArgument("--blink-settings=imagesEnabled=false");
            options.AddArgument("--no-sandbox");
            options.AddArgument("--disable-dev-shm-usage");

            if (Environment.GetEnvironmentVariable("CI") == "true")
{
            options.AddArgument("--headless");
}
            
            
            // Inicijalizacija bez ikakvih putanja - Selenium 4.24 će sam uraditi ostalo
            Instance = new ChromeDriver(options);
            Instance.Manage().Window.Maximize();
            Instance.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(60);
            Instance.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
        }

        public static void Close()
        {
            if (Instance != null)
            {
                Instance.Quit();
                Instance.Dispose();
            }
        }

        
    }
}