using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            //recognize when a specific key is pressed

            //read or take in input
            string message = Console.ReadLine();

            //display output
            Console.WriteLine("Here's some output!!");
            Console.WriteLine("Here's your message: {0}", message);
                     
           //recognize flag at startup (-server)

            //keep window open
            Console.ReadKey();
        }
    }
}
