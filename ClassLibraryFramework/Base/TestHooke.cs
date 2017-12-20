using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibraryFramework.Config;
using ClassLibraryFramework.Helper;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Chrome;

namespace ClassLibraryFramework.Base
{
    public abstract class TestHooke : ClassLibraryFramework.Base.Base
    {
        public static void InitializeSettings()
        {
            //Set all the settings for framework
            ConfigReader.SetFramework();

            //Set Log
            Log.CreateLogFile();

            //Open Browser
            OpenBrowser(Settings.Browser);

            //   DriverContext.Browser.GoToUrl(Settings.Url);


            Log.Write("Initialized framework");

        }

        private static void OpenBrowser(BrowserType browserType = BrowserType.FireFox)
        {
            switch (browserType)
            {
                case BrowserType.InternetExplorer:
                    DriverContext.Driver = new InternetExplorerDriver();
                    DriverContext.Browser = new Browser(DriverContext.Driver);
                    break;
                case BrowserType.FireFox:
                    // CHANGE PATH OF DEFAULT SERVICE TO MATCH LOCATION OF GECKO DRIVER IN YOUR MACHINE.
                  //  FirefoxDriverService service = FirefoxDriverService.CreateDefaultService(@"C:\Users\beni\Desktop\");
                   // service.FirefoxBinaryPath = (@"C:\Program Files(x86)\Mozilla Firefox\firefox.exe");
                    DriverContext.Driver = new FirefoxDriver();
                    DriverContext.Browser = new Browser(DriverContext.Driver);
                    break;
                case BrowserType.Chrome:
                    DriverContext.Driver = new ChromeDriver();
                    DriverContext.Browser = new Browser(DriverContext.Driver);
                    break;
            }



        }

        public  static void NaviateSite()
        {
            DriverContext.Browser.GoToUrl(Settings.Url);
            DriverContext.Driver.Manage().Window.Maximize();
            Log.Write("Opened the browser !!!");
        }



    }
}
