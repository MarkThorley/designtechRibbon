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
            RibbonPanel ribbonPanel1 = application.CreateRibbonPanel(tabName, "Tools");
            RibbonPanel ribbonPanel2 = application.CreateRibbonPanel(tabName, "View Templates");
            RibbonPanel ribbonPanel3 = application.CreateRibbonPanel(tabName, "Filters");

            // Get dll assembly path
            string thisAssemblyPath = Assembly.GetExecutingAssembly().Location;

            //Create RemoveViewTemplates button
            CreatePushButton(ribbonPanel2, String.Format("Removes" + Environment.NewLine + "View Templates"), thisAssemblyPath, "EssentialTools.CommandRemoveTemplates",
                "Remove used or unused View Templates in bulk.", "EssentialTools/RemoveTemplatesPlaceholder.png");
            //Create RemoveFilters button
            CreatePushButton(ribbonPanel3, String.Format("Removes" + Environment.NewLine + "Filters"), thisAssemblyPath, "EssentialTools.CommandRemoveFilters",
                "Remove used or unused Filters in bulk.", "EssentialTools/RemoveFiltersPlaceholder.png");

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
            SplitButton sb = ribbonPanel1.AddItem(sb1) as SplitButton;
            sb.AddPushButton(bOne);
            sb.AddPushButton(bTwo);
            sb.AddPushButton(bThree);
            sb.AddPushButton(bFour);
        }
        /// <summary>
        /// A method that allows you to create a Push Button with greater ease
        /// </summary>
        /// <param name="ribbonPanel"></param>
        /// <param name="name"></param>
        /// <param name="path"></param>
        /// <param name="command"></param>
        /// <param name="tooltip"></param>
        /// <param name="icon"></param>
        private static void CreatePushButton(RibbonPanel ribbonPanel, string name, string path, string command, string tooltip, string icon)
        {
            PushButtonData pbData = new PushButtonData(
                name,
                name,
                path,
                command);

            PushButton pb = ribbonPanel.AddItem(pbData) as PushButton;
            pb.ToolTip = tooltip;
            BitmapImage pb2Image = new BitmapImage(new Uri(String.Format("pack://application:,,,/DesignTechRibbon;component/Resources/{0}", icon)));
            pb.LargeImage = pb2Image;
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
