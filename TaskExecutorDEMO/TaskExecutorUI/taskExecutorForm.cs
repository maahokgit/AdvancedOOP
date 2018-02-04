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
        Thread workerThread;
        TaskExecutor executor = new TaskExecutor();

        public taskExecutorForm()
        {
            executor.ProgressChanged 
                += new TasksLib.ProgressChangedEventHandler(Executor_ProgressChanged);

            executor.TaskCompleted 
                += new TasksLib.TaskCompletedEventHandler(Executor_TaskCompleted);

            InitializeComponent();
        }

        private void Executor_TaskCompleted()
        {
            //re-enable the button
            if (startBtn.InvokeRequired)
            {
                MethodInvoker invoker = new MethodInvoker
                (
                    //anonymous function/method
                    delegate ()
                    {
                        startBtn.Enabled = true;
                    }
                );
                startBtn.Invoke(invoker);
            }
            else
            {
                startBtn.Enabled = true;
            }
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
            workerThread = new Thread(executor.DoSomethingThatTakesAWhile);
            workerThread.Name = "ProgressTread";
            workerThread.Start();

            //disable the button
            startBtn.Enabled = false;

            cancelBtn.Enabled = true;

            //Call the method
            //DoSomethingThatTakesAWhile();  //run on main (background, worker) thread
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            //prematurely cancel the worker thread, that stops running before it finishes
            //workerThread.Abort(); <-- don't do this
            executor.StopExecution = true;
            cancelBtn.Enabled = false;
        }

        private void taskExecutorForm_Load(object sender, EventArgs e)
        {

        }

        private void taskExecutorForm_FormClosing(object sender, FormClosingEventArgs e)
        {

        }
    }
}
