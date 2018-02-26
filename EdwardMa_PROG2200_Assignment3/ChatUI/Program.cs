using System;
using System.Windows.Forms;

//Comment out to use SimpleInjector
//using Unity;

//comment out ChatLog to use Stephen's ChatLogger
//using ChatLog;

//Comment out ChatLogger to use Edward's ChatLog
using ChatLogger;

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

            // Comment out to use Unity IOC Container
            // SimpleInjector IOC Container!

            SimpleInjector.Container container = new SimpleInjector.Container();

            //*** Edward's Logger ***
            //container.Register<ILoggingService, LogToFile>();

            //*** Edward's Logger ***
            //container.Register<ILoggingService, NLogToFile>();

            //*** Edward's Logger ***
            container.Register<ILoggingService, ChatLogNLog>();

            container.Verify();
            Application.Run(container.GetInstance<ChatUI>());


            // Unity IOC Container
            //UnityContainer container = new UnityContainer();

            //*** Edward's Logger ***
            //container.RegisterType<ILoggingService, LogToFile>();

            //*** Edward's Logger ***
            //container.RegisterType<ILoggingService, NLogToFile>();

            //*** Edward's Logger ***
            //container.RegisterType<ILoggingService, ChatLogNLog>();

            //Application.Run(container.Resolve<ChatUI>());
        }
    }
}
