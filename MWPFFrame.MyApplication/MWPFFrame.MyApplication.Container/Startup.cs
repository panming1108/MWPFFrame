using MWPFFrame.Applications;
using MWPFFrame.LanguageManagers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Resources;
using System.Text;
using System.Windows;

namespace MWPFFrame.MyApplication.Container
{
    public class Startup : MApplication
    {
        protected override void App_Startup(object sender, StartupEventArgs e)
        {
            //注册全局异常
            RegisterGlobalException();

            //注册语言
            var zhCnLanguage = new Uri("/MWPFFrame.UIControls;component/Languages/zh-Hans.xaml", UriKind.RelativeOrAbsolute);
            var enUsLanguage = new Uri("/MWPFFrame.UIControls;component/Languages/en-Us.xaml", UriKind.RelativeOrAbsolute);
            LanguageManager.RegisterLanguage("zh-cn", new Uri[] { zhCnLanguage });
            LanguageManager.RegisterLanguage("en-Us", new Uri[] { enUsLanguage });

            //注册风格
            var darkBlackTheme = new Uri("/MWPFFrame.UIControls;component/Themes/DarkBlackTheme.xaml", UriKind.RelativeOrAbsolute);
            var lightBlueTheme = new Uri("/MWPFFrame.UIControls;component/Themes/LightBlueTheme.xaml", UriKind.RelativeOrAbsolute);
            ThemeManager.RegisterTheme("DarkBlackTheme", new Uri[] { darkBlackTheme });
            ThemeManager.RegisterTheme("LightBlueTheme", new Uri[] { lightBlueTheme });

            //加载样式
            var commonResource = new Uri("/MWPFFrame.UIControls;component/Generics/Style.xaml", UriKind.RelativeOrAbsolute);
            var sysResource = new Uri("/MWPFFrame.MyApplication.CustomControls;component/Generic/Style.xaml", UriKind.RelativeOrAbsolute);
            LoadResources("LightBlueTheme", "zh-cn", new Uri[] { sysResource, commonResource });

            MainWindow window = new MainWindow();
            window.ShowDialog();
        }
    }
}
