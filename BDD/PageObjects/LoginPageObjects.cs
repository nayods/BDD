using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibraryFramework.Base;
using ClassLibraryFramework.Config;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace BDD.PageObjects
{
   public class LoginPageObjects
    {

        // constructor
        public LoginPageObjects(IWebDriver driver)
        {
            PageFactory.InitElements(driver, this);
        }

        //Driver.FindElements(By.xpath(""))
        // username textbox 
        [FindsBy(How = How.XPath, Using = ".//*[@id='userName']/p[1]/input")]
        public IWebElement UsernameTextBox { get; set; }




        // password text box 
        [FindsBy(How = How.XPath, Using = ".//*[@id='userName']/p[2]/input")]
        public IWebElement PasswordTextBox { get; set; }

        // login button 
        [FindsBy(How = How.XPath, Using = ".//*[@id='userName']/p[3]/input")]
        public IWebElement LoginBtn { get; set; }


        public void Login(string username, string password)
        {
            UsernameTextBox.SendKeys(username);
            PasswordTextBox.SendKeys(password);
            LoginBtn.Click();

        }

        public void ResetToLoginScreen()
        {
            DriverContext.Driver.Navigate().GoToUrl(Settings.Url);
        }

        public bool IsLoginPageDisplayed()
        {
            var displayed = false;

            try
            {
                if (LoginBtn.Displayed)
                    displayed = true;
            }
            catch (Exception)
            {

            }
            return displayed;

        }
    }
}
