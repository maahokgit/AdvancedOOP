using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TaskExecutorUI
{
    public partial class taskExecutorForm : Form
    {
        public taskExecutorForm()
        {
            InitializeComponent();
        }

        private void startBtn_Click(object sender, EventArgs e)
        {
            //define a worker thread for our Do Something method
            Thread workerThread = new Thread(DoSomethingThatTakesAWhile);
            workerThread.Name = "ProgressTread";
            workerThread.Start();

            //Call the method
            DoSomethingThatTakesAWhile();  //run on main (background, worker) thread
        }

        private void taskProgressBar_Click(object sender, EventArgs e)
        {
            
        }

        public void DoSomethingThatTakesAWhile()
        {
            //simulate doing something that takes a while
            for (int i=1; i<=100; i++)
            {
                //simulate something that takes a bit of time
                Thread.Sleep(100);
            }
        }
    }
}
