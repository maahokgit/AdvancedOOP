using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestApp
{
    class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine(SimpleLibrary.displayString.showInt());'
            SimpleLibrary.displayString simLib = new SimpleLibrary.displayString();
            Console.WriteLine(simLib.showInt());
            simLib.showStrWithConsole();
            while (true) { }
        }
    }
}
