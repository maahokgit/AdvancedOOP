using System;
using System.IO;

namespace ChatLog
{
    public class LogToFile : ILoggingService
    {
        /// <summary>
        /// logging service that will write the message from chatBox and 
        /// append the text to the file.
        /// had to do it this way since I'm using a ListBox...
        /// </summary>
        /// <param name="message"></param>
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
