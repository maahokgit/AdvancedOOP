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
using TasksLib;

namespace TaskExecutorUI
{
    public partial class taskExecutorForm : Form
    {
        TaskExecutor executor = new TaskExecutor();
        public taskExecutorForm()
        {
            executor.ProgressChanged 
                += new TasksLib.ProgressChangedEventHandler(Executor_ProgressChanged);

            InitializeComponent();
        }

        private void Executor_ProgressChanged(int progress)
        {
            if (taskProgressBar.InvokeRequired)
            {
                MethodInvoker invoker = new MethodInvoker
                (
                    //anonymous function/method
                    delegate ()
                    {
                        taskProgressBar.Value = progress;
                    }
                );
                taskProgressBar.Invoke(invoker);
            }
            else
            {
                //update the progress bar
                taskProgressBar.Value = progress;
            }
        }

        private void startBtn_Click(object sender, EventArgs e)
        {
            //define a worker thread for our Do Something method
            Thread workerThread = new Thread(executor.DoSomethingThatTakesAWhile);
            workerThread.Name = "ProgressTread";
            workerThread.Start();

            //Call the method
            //DoSomethingThatTakesAWhile();  //run on main (background, worker) thread
        }

        private void taskProgressBar_Click(object sender, EventArgs e)
        {
            
        }

        public void ExecuteSomeMethod()
        {
            //code in here to execute...
        }
    }
}
