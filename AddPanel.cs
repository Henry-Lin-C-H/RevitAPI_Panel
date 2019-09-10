using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autodesk.Revit.UI;
using Autodesk.Revit.DB;
using System.Windows.Media.Imaging;

namespace SinoApplication
{
    [Autodesk.Revit.Attributes.Transaction(Autodesk.Revit.Attributes.TransactionMode.Manual)]
    public class AddPanel : IExternalApplication
    {
        public Result OnStartup(UIControlledApplication application)
        {
            // 尋找檔案在電腦上的路徑
            string path = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase).ToString();
            string filepath = path.Substring(6);
            // add new ribbon panel加入新的功能區面板 
            RibbonPanel ribbonPanel = application.CreateRibbonPanel("中興工程自動化建模");
            //在“NewRibbonPanel” 功能區面板建立一按鈕 
            //當按下該按鈕，則增益集應用程式即被觸發執行
            string command_path = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase).ToString().Substring(6);

            PushButton pushButton = ribbonPanel.AddItem(new PushButtonData("Excavation", "Excavation", command_path + @"\excavation.dll", "excavation.start")) as PushButton;
            pushButton.LargeImage = new BitmapImage(new Uri(command_path + @"\images\藍灰1.png"));
            PushButton pushButton2 = ribbonPanel.AddItem(new PushButtonData("SinoPipe", "SinoPipe", command_path + @"\auto_line.dll", "auto_line.Start")) as PushButton;
            pushButton2.LargeImage = new BitmapImage(new Uri(command_path + @"\images\藍灰2.png"));
            PushButton pushButton3 = ribbonPanel.AddItem(new PushButtonData("BIM360", "BIM360", command_path + @"\BIM360Starter.dll", "BIM360Starter.Start")) as PushButton;
            pushButton3.LargeImage = new BitmapImage(new Uri(command_path + @"\images\藍灰3.png"));

            return Result.Succeeded;
        }
        public Result OnShutdown(UIControlledApplication application)
        {
            return Result.Succeeded;
        }
    }
}
