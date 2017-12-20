using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibraryFramework.Config;

namespace ClassLibraryFramework.Helper
{
    public  class FolderBuilder
    {
       

        // This are the list of names of folders that will get built
        public static string MainFolder;

        public static string ReportSubFolder;
        public static string ScreenShotSubFolder;
        public static string FailedSubFolder;
        public static string LogsSubFolder;
        public static string Mobile;
        public static string Ios;
        public static string Andriod;


      

        //FolderBuilder.BuildFolderStructure();
        public static void BuildFolderStructure()
        {

            // This is the method that actually does the building

            MainFolder = Settings.Location;
            ReportSubFolder = MainFolder + "/Reports";
            Mobile = MainFolder + "/Mobile";
            Ios = Mobile + "/Ios";
            Andriod = Mobile + "/Android";
            ScreenShotSubFolder = MainFolder + "/screenshot";
            FailedSubFolder = MainFolder + "/failed";
            LogsSubFolder = MainFolder + "/Logs";


            CreateFolder(MainFolder);
            CreateFolder(ReportSubFolder);
            CreateFolder(ScreenShotSubFolder);
            CreateFolder(FailedSubFolder);
            CreateFolder(LogsSubFolder);

        }



        public static void Delete(string _directortytoDelete)
        {

            Directory.Delete(_directortytoDelete, true);
        }

        static void CreateFolder(string _name)
        {
            if (!Directory.Exists(_name))

                Directory.CreateDirectory(_name).Create();
            File.SetAttributes(_name, FileAttributes.Normal);
        }


        public static void DeleteFolder(string _name)
        {
            if (Directory.Exists(_name))
                Directory.Delete(_name, true);
            Directory.Delete(_name, true);
        }


    }
}
