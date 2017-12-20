using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassLibraryFramework.Base;
using ClassLibraryFramework.Helper;
using TechTalk.SpecFlow;
using OpenQA.Selenium;

namespace BDD
{
    [Binding]
    public sealed class EventsHandler : TestHooke
    {
        // For additional details on SpecFlow hooks see http://go.specflow.org/doc-hooks
        static string featurename;

        static string scenarioname;

        [BeforeStep]
        public void BeforeStep()
        {

            Console.WriteLine("BEFORE STEP");
            // TODO: implement logic that has to run before each scenario step
            // For storing and retrieving scenario-specific data, 
            // the instance fields of the class or the
            //     ScenarioContext.Current
            // collection can be used.
            // For storing and retrieving feature-specific data, the 
            //     FeatureContext.Current
            // collection can be used.
            // Use the attribute overload to specify tags. If tags are specified, the event 
            // handler will be executed only if any of the tags are specified for the 
            // feature or the scenario.
            //     [BeforeStep("mytag")]
        }

        [AfterStep]
        public void AfterStep()
        {
            Console.WriteLine("AFTER STEP");
            // TODO: implement logic that has to run after each scenario step
        }




        [BeforeScenarioBlock]
        public void BeforeScenarioBlock()
        {
            Console.WriteLine("BEFORE SCENARIO BLOCK");
            // TODO: implement logic that has to run before each scenario block (given-when-then)
        }

        [AfterScenarioBlock]
        public void AfterScenarioBlock()
        {

            // TODO: implement logic that has to run after each scenario block (given-when-then)
        }





        [BeforeScenario]
        public void BeforeScenario()
        {
            featurename = FeatureContext.Current.FeatureInfo.Title;
            scenarioname = ScenarioContext.Current.ScenarioInfo.Title;
            // Log.Write("Executing Scenario " + scenarioname);
            HtmlReports.StartHtmlReports(scenarioname, null, featurename + " Feature");

            Log.Write("SCENARIO NAME = " + ScenarioContext.Current.ScenarioInfo.Title.ToUpper());

            // TODO: implement logic that has to run before executing each scenario
        }

        [AfterScenario]
        public void AfterScenario()
        {


            if (ScenarioContext.Current.TestError != null)
            {

                HtmlReports.ProcesSpecFlowReports("fail", ReturnScreenShotPath(), scenarioname);
                Log.Write("SCENARIO ERROR = "+ ScenarioContext.Current.TestError.Message.ToUpper());
                Log.Write("SCENARIO STATUS = FAILED");


            }
            else
            {
                HtmlReports.ProcesSpecFlowReports(null, null, scenarioname);
                Log.Write("SCENARIO STATUS = PASSED");
            }

            


            // TODO: implement logic that has to run after executing each scenario
        }






        [BeforeFeature]
        public static void BeforeFeature()
        {

            Log.Write("FEATURE NAME = " + FeatureContext.Current.FeatureInfo.Title);

            // TODO: implement logic that has to run before executing each feature
        }

        [AfterFeature]
        public static void AfterFeature()
        {

            Log.Write("FEATURE STATUS = COMPLETED");
            Log.LogLineSpacing();

            DriverContext.Driver.Quit();

            // TODO: implement logic that has to run after executing each feature
        }






        [BeforeTestRun]
        public static void BeforeTestRun()
        {
            InitializeSettings();
            NaviateSite();
            HtmlReports.SetUpHtmlReport();

            // TODO: implement logic that has to run before the entire test run
        }

        [AfterTestRun]
        public static void AfterTestRun()
        {
            HtmlReports.FlushCloseHtmlReport();
            DriverContext.Driver.Quit();
            // TODO: implement logic that has to run after the entire test run
        }

        string ReturnScreenShotPath()
        {

            var capturedimage = ((ITakesScreenshot) DriverContext.Driver).GetScreenshot();
            var screenshotname = "//Failed" + scenarioname + "screenshot.png";

            capturedimage.SaveAsFile(FolderBuilder.FailedSubFolder + screenshotname,
                ScreenshotImageFormat.Png);
            return FolderBuilder.FailedSubFolder + screenshotname;

        }

    }
}
