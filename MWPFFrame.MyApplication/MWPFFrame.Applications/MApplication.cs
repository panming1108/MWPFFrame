using MWPFFrame.LanguageManagers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Threading;

namespace MWPFFrame.Applications
{
    public abstract class MApplication : Application
    {
        public MApplication()
        {
            Startup += App_Startup;
        }

        protected void LoadResources(Uri[] resourceUris)
        {
            LoadResources(null, null, resourceUris);
        }

        protected void LoadResources(string themeName, string languageName, Uri[] resourceUris)
        {
            if (resourceUris == null)
            {
                return;
            }
            Current.Resources.MergedDictionaries.Clear();
            if (!string.IsNullOrEmpty(languageName))
            {
                LanguageManager.InitLanguage(languageName);
            }
            if (!string.IsNullOrEmpty(themeName))
            {
                ThemeManager.InitTheme(themeName);
            }
            foreach (var resourceUri in resourceUris)
            {
                var resourceDictionary = new ResourceDictionary()
                {
                    Source = resourceUri
                };
                Current.Resources.MergedDictionaries.Add(resourceDictionary);
            }
        }

        protected virtual void RegisterGlobalException()
        {
            // Add the event handler for handling UI thread exceptions to the event.
            System.Windows.Forms.Application.SetUnhandledExceptionMode(System.Windows.Forms.UnhandledExceptionMode.CatchException);

            //Dispatcher.UnhandledException += Dispatcher_UnhandledException;

            /// <summary>
            /// main UI dispathcer thread
            /// </summary>
            Current.DispatcherUnhandledException += App_OnDispatcherUnhandledException;
            ///
            ///a single specific UI dispatcher thread
            ///
            //DispatcherUnhandledException += AppBase_DispatcherUnhandledException;

            ///
            ///within each AppDomain that uses a task scheduler for asynchrouous operations
            ///
            TaskScheduler.UnobservedTaskException += TaskScheduler_UnobservedTaskException;

            /// <summary>
            /// all threads in the AppDomain
            /// </summary>
            AppDomain.CurrentDomain.UnhandledException += CurrentDomain_UnhandledException;

            AppDomain.CurrentDomain.FirstChanceException += CurrentDomain_FirstChanceException;

            // Add the event handler for handling UI thread exceptions to the event.
            System.Windows.Forms.Application.ThreadException += WinFormApplication_ThreadException;
        }

        protected abstract void App_Startup(object sender, StartupEventArgs e);

        private void Dispatcher_UnhandledException(object sender, DispatcherUnhandledExceptionEventArgs e)
        {
            try
            {
                MessageBox.Show(e.Exception.Message, "Dispatch全局异常");
                e.Handled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "应用程序发生不可恢复的异常，将要退出！");
            }
        }

        private void App_OnDispatcherUnhandledException(object sender, DispatcherUnhandledExceptionEventArgs e)
        {
            try
            {
                ///TODO 错误以后应该还是要弹出的，不然，一脸懵逼
                ///只不过不能弹出一堆
                if (e.Exception.Message.Contains("超时") || e.Exception.Message.Contains("timed out") || e.Exception.Message.Contains("无法连接") || e.Exception.Message.Contains("Timeout")
                    || e.Exception.Message.Contains("未响应") || e.Exception.Message.Contains("was aborted")
                    || e.Exception.Message.Contains("正在中止线程") || e.Exception.Message.Contains("Thread was being aborted"))
                {

                }
                else
                {
                    MessageBox.Show(e.Exception.Message, "CurrentDispatch全局异常");
                }

                e.Handled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "应用程序发生不可恢复的异常，将要退出！");
            }
        }

        private void AppBase_DispatcherUnhandledException(object sender, DispatcherUnhandledExceptionEventArgs e)
        {
            try
            {
                MessageBox.Show(e.Exception.Message, "thisDispatch全局异常");
                e.Handled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "应用程序发生不可恢复的异常，将要退出！");
            }
        }

        private void TaskScheduler_UnobservedTaskException(object sender, UnobservedTaskExceptionEventArgs e)
        {
            try
            {
                ///TODO 错误以后应该还是要弹出的，不然，一脸懵逼
                ///只不过不能弹出一堆
                if (e.Exception.Message.Contains("超时") || e.Exception.Message.Contains("timed out") || e.Exception.Message.Contains("无法连接") || e.Exception.Message.Contains("Timeout")
                    || e.Exception.Message.Contains("未响应") || e.Exception.Message.Contains("was aborted")
                    || e.Exception.Message.Contains("正在中止线程") || e.Exception.Message.Contains("Thread was being aborted"))
                {

                }
                else
                {
                    MessageBox.Show(e.Exception.Message, "Task全局异常");
                }

                e.SetObserved();

                if (!e.Observed)
                {
                    MessageBox.Show("应用程序发生不可恢复的异常，将要退出！", "应用程序发生不可恢复的异常，将要退出！");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("应用程序发生不可恢复的异常，将要退出！", "应用程序发生不可恢复的异常，将要退出！");
            }
        }

        private void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            try
            {
                var exception = e.ExceptionObject as Exception;

                if (exception != null)
                {
                    ///TODO 错误以后应该还是要弹出的，不然，一脸懵逼
                    ///只不过不能弹出一堆

                    if (exception.Message.Contains("超时") || exception.Message.Contains("timed out") || exception.Message.Contains("无法连接") || exception.Message.Contains("Timeout")
                        || exception.Message.Contains("未响应") || exception.Message.Contains("was aborted")
                        || exception.Message.Contains("正在中止线程") || exception.Message.Contains("Thread was being aborted"))
                    {

                    }
                    else
                    {
                        MessageBox.Show(exception.Message, "AppDoamin全局异常");
                    }
                }

                if (e.IsTerminating)
                {
                    MessageBox.Show("应用程序发生不可恢复的异常，将要退出！", "应用程序发生不可恢复的异常，将要退出！");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("应用程序发生不可恢复的异常，将要退出！", "应用程序发生不可恢复的异常，将要退出！");
            }
        }

        private void CurrentDomain_FirstChanceException(object sender, System.Runtime.ExceptionServices.FirstChanceExceptionEventArgs e)
        {
            if (e.Exception == null)
            {
                return;
            }

            if (e.Exception.Message.Contains("根级别上的数据无效") || e.Exception.Message.Contains("无法从 System.String 转换")
                || e.Exception.Message.Contains("无法从文本"))
            {

            }
            else
            {
                MessageBox.Show(e.Exception.Message);
            }
        }

        private void WinFormApplication_ThreadException(object sender, ThreadExceptionEventArgs e)
        {
            MessageBox.Show(e.Exception.Message, "Winform ThreadException");
        }
    }
}
