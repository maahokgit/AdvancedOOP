using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChatLibrary;
namespace ChatConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            //check if in server mode or not
            if(args.Contains("-server"))
            {
                //server mode
                serverTest server = new serverTest();
                server.Start();
                while(true)
                {
                    Console.WriteLine("Waiting For Connection");
                    if (server.Connect() == true)
                    {
                        Console.WriteLine("Connected to Client");
                    }

                    while(true)
                    {
                        server.Sent("from server");
                    }
                }
            }
            else
            {
                //client mode
                Client client = new Client();
                client.Connect();
                //clientTest client = new clientTest();
                //client.start();

            }
        }

        static void EndApp()
        {
            Console.WriteLine("Thanks for using the Chat Console!\nPress 'anykey' to quit.");
            //keep window open
            Console.ReadKey(); //blocking call
        }
    }
}
