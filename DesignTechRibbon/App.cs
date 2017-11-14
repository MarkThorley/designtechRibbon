using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using System.Windows.Media.Imaging;

namespace DesignTechRibbon
{
    class App : IExternalApplication
    {
        // Define a method that will create our tab and button
        static void AddRibbonPanel(UIControlledApplication application)
        {
            // Create a custom ribbon tab
            String tabName = "designtech.io";
            application.CreateRibbonTab(tabName);

            // Add a new ribbon panel
            RibbonPanel ribbonPanel = application.CreateRibbonPanel(tabName, "Tools");

            // Get dll assembly path
            string thisAssemblyPath = Assembly.GetExecutingAssembly().Location;

            //Create push buttons for split drop down
            PushButtonData bOne = new PushButtonData(
                "cmdCurveTotalLength",
                "Curve Length",
                thisAssemblyPath,
                "TotalLength.CurveTotalLength");
            bOne.LargeImage = new BitmapImage(new Uri(@"pack://application:,,,/DesignTechRibbon;component/Resources/CurveTotalLength.png"));

            PushButtonData bTwo = new PushButtonData(
                "cmdWallTotalLength",
                "Wall Length",
                thisAssemblyPath,
                "TotalLength.WallTotalLength");
            bTwo.LargeImage = new BitmapImage(new Uri(@"pack://application:,,,/DesignTechRibbon;component/Resources/WallTotalLength.png"));

            PushButtonData bThree = new PushButtonData(
                "cmdFramingTotalLength",
                "Beam Length",
                thisAssemblyPath,
                "TotalLength.FramingTotalLength");
            bThree.LargeImage = new BitmapImage(new Uri(@"pack://application:,,,/DesignTechRibbon;component/Resources/FramingTotalLength.png"));

            PushButtonData bFour = new PushButtonData(
                "cmdPipingTotalLength",
                "Pipe Length",
                thisAssemblyPath,
                 "TotalLength.PipingTotalLength");
            bFour.LargeImage = new BitmapImage(new Uri(@"pack://application:,,,/DesignTechRibbon;component/Resources/PipingTotalLength.png"));

            SplitButtonData sb1 = new SplitButtonData("splitButton1", "Split");
            SplitButton sb = ribbonPanel.AddItem(sb1) as SplitButton;
            sb.AddPushButton(bOne);
            sb.AddPushButton(bTwo);
            sb.AddPushButton(bThree);
            sb.AddPushButton(bFour);
        }

        public Result OnShutdown(UIControlledApplication application)
        {
            // Do nothing
            return Result.Succeeded;
        }

        public Result OnStartup(UIControlledApplication application)
        {
            // Call our method that will load up our toolbar
            AddRibbonPanel(application);
            return Result.Succeeded;
        }
    }
}
