using System;
using System.Windows.Forms;
using Unity;
using ChatLog;
using ILog;

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
           
            UnityContainer container = new UnityContainer();

            //container.RegisterType<ILoggingService, LogToFile>();
            container.RegisterType<ILoggingService, NLog>();
            Application.Run(container.Resolve<ChatUI>());
        }
    }
}
