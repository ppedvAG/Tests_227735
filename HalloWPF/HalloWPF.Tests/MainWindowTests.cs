using FlaUI.Core.AutomationElements;
using FlaUI.UIA3;

namespace HalloWPF.Tests
{
    public class MainWindowTests
    {
        [Fact]
        public void Click_on_KlickMich_should_show_Hallo_in_textbox()
        {
            //var appPath = @"C:\Users\Fred\source\repos\ppedvAG\Tests_227735\HalloWPF\HalloWPF\bin\Debug\net7.0-windows\HalloWPF.exe";
            var appPath = typeof(MainWindow).Assembly.Location.Replace(".dll", ".exe");

            var app = FlaUI.Core.Application.Launch(appPath);

            using (var auto = new UIA3Automation())
            {
                var win = app.GetMainWindow(auto);
                win.WaitUntilClickable();
                win.WaitUntilEnabled();

                var btn = win.FindFirstDescendant(x => x.ByAutomationId("btn1")).AsButton();
                btn.Click();

                var tb = win.FindFirstDescendant(x => x.ByAutomationId("tb1")).AsTextBox();
                Assert.Equal("Hallo", tb.Text);
            }

            app.Close();
        }
    }
}