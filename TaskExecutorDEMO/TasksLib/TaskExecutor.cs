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
        public event ProgressChangedEventHandler ProgressChanged;
        public event TaskCompletedEventHandler TaskCompleted;
        public Boolean StopExecution; //default is false
        public void DoSomethingThatTakesAWhile()
        {
            int i;
            //simulate doing something that takes a while
            for (i = 1; i <= 100; i++)
            {
                if(!StopExecution)
                {
                    //simulate something that takes a bit of time
                    Thread.Sleep(100);

                    //raise an event to broadcast that progress has been
                    //updated / changed
                    if(ProgressChanged != null)
                    {
                        ProgressChanged(i);
                    }
                }
                else
                {
                    break; //exit loop
                }
            }

            //do any clean up... close connection...before method complete


            if(TaskCompleted != null && i > 100)
            { 
                TaskCompleted();
            }
            

        }
    }
}
