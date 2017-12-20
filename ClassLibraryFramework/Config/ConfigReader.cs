using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.XPath;
using ClassLibraryFramework.Base;
using ClassLibraryFramework.Helper;

namespace ClassLibraryFramework.Config
{
    public class ConfigReader
    {
        // This class is responsible for reading the data from the xml file and parsing all the values in to the framework
     //   static string filename = @"C:\Users\beni\Desktop\ClassLibraryFramework\Config\Config.xml";

        private static string ConfigFilePath = GetConfigXmlPath();
         
        public static void SetFramework()
        {

            // this string file is the location of the xml file 


            
            FileStream stream = new FileStream(ConfigFilePath, FileMode.Open);
            XPathDocument document = new XPathDocument(stream);
            XPathNavigator navi = document.CreateNavigator();

            XPathItem Location = navi.SelectSingleNode("xml/AppSetting/FolderLocation");
            XPathItem Browser = navi.SelectSingleNode("xml/AppSetting/Browser");
            XPathItem Url = navi.SelectSingleNode("xml/AppSetting/Url");
            XPathItem EnableReport = navi.SelectSingleNode("xml/AppSetting/EnableReport");
            XPathItem EnableLog = navi.SelectSingleNode("xml/AppSetting/EnableLog");
            XPathItem DataBaseConnectionString = navi.SelectSingleNode("xml/AppSetting/DataBaseConnectionString");
            XPathItem AdminUsername = navi.SelectSingleNode("xml/AppSetting/AdminUsername");
            XPathItem AdminPassword = navi.SelectSingleNode("xml/AppSetting/AdminPassword");


            Settings.Location = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "/" + Location.Value;
            Settings.AdminPassword = Browser.Value;
            Settings.Url = Url.Value;
            Settings.EnableReport = EnableReport.Value;
            Settings.EnableLog = EnableLog.Value;
            Settings.DataBaseConnectionString = DataBaseConnectionString.Value;
            Settings.AdminUsername = AdminUsername.Value;
            Settings.AdminPassword = AdminPassword.Value;
            Settings.Browser = (BrowserType) Enum.Parse(typeof(BrowserType), Browser.Value.ToString());


            // This is a static method responsible for creating a folder structure for the entire framework
            FolderBuilder.BuildFolderStructure();

        }

        private static string GetConfigXmlPath()
        {
            return Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) +
                      "\\ClassLibraryFramework\\ClassLibraryFramework\\Config\\config.xml");
        }
    }
}
