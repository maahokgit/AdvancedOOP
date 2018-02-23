using ILog;
using System;
using System.IO;

namespace ChatLog
{
    public class LogToFile : ILoggingService
    {
        public void Log(string message)
        {
            //throw new System.NotImplementedException();
            DateTime thisDay = DateTime.Today;
            string fileName = thisDay.ToString("D") + ".txt";
            //const string sPath = fileName;

            StreamWriter SaveFile = File.AppendText(fileName);
            //System.IO.StreamWriter SaveFile = new System.IO.StreamWriter(fileName);
            //foreach (var item in chatBox.Items)
            //{
            SaveFile.WriteLine(message);
            //}

            SaveFile.Close();

            //MessageBox.Show("Chat saved!");
        }
    }
}
