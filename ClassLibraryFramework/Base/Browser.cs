﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace ClassLibraryFramework.Base
{
    public class Browser
    {
        private readonly IWebDriver _driver;

        public Browser(IWebDriver driver)
        {
            _driver = driver;
        }

        public BrowserType Type { get; set; }

        public void GoToUrl(string url)
        {
            DriverContext.Driver.Url = url;
        }

    }

    public enum BrowserType
    {
        InternetExplorer,
        FireFox,
        Chrome
    }
}
