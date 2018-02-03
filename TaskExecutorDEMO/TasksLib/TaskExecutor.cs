using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TasksLib
{
    public class TaskExecutor
    {
        public void DoSomethingThatTakesAWhile()
        {
            //simulate doing something that takes a while
            for (int i = 1; i <= 100; i++)
            {
                //simulate something that takes a bit of time
                Thread.Sleep(100);

                //if (taskProgressBar.InvokeRequired)
                //{
                //    MethodInvoker invoker = new MethodInvoker
                //    (
                //        //anonymous function/method
                //        delegate ()
                //        {
                //            taskProgressBar.Value = i;
                //        }
                //    );
                //    taskProgressBar.Invoke(invoker);
                //}
                //else
                //{
                //    //update the progress bar
                //    taskProgressBar.Value = i;
                //}
            }

        }
    }
}
