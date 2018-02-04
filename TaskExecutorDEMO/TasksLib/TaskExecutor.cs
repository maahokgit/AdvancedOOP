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

        public void DoSomethingThatTakesAWhile()
        {
            //simulate doing something that takes a while
            for (int i = 1; i <= 100; i++)
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

        }
    }
}
