using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibraryFramework.Base;

namespace ClassLibraryFramework.Config
{
   public class Settings
    {
        

            // This class is just a mapping class the values from the xml file will get mapped to this values.
            public static string Location { get; set; }
            public static string EnableReport { get; set; }
            public static string AdminPassword { get; set; }
            public static string Url { get; set; }
            public static string EnableLog { get; set; }
            public static string DataBaseConnectionString { get; set; }
            public static string AdminUsername { get; set; }
            public static string ExtentReportConfig = GetConfigXmlPath();

        public static BrowserType Browser { get; set; }

        

        private static string GetConfigXmlPath()
        {
            return Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) +
                                "\\Users\\Nayods\\Downloads\\SpecFlow-20171220T231145Z-001\\SpecFlow\\Windows\\BDD\\ClassLibraryFramework\\Config\\Config.xml");
        }




    }
}
