using System;
using System.Windows.Forms;
using Unity;
using ChatLog;

namespace ChatUI
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            //SimpleInjector IOC Container!
            //SimpleInjector.Container container = new SimpleInjector.Container();
            ////container.Register<ILoggingService, LogToFile>();
            //container.Register<ILoggingService, NLogToFile>();
            //container.Verify();
            //Application.Run(container.GetInstance<ChatUI>());

            //Unity IOC Container
            UnityContainer container = new UnityContainer();
            //container.RegisterType<ILoggingService, LogToFile>();
            container.RegisterType<ILoggingService, NLogToFile>();
            Application.Run(container.Resolve<ChatUI>());
        }
    }
}
