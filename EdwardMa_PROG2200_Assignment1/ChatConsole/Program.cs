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

                    while (true)
                    {
                        string message = string.Empty;
                        message = server.DataResponse();
                        if (message != "quit" && message != null)
                        {
                            Console.Write("<<");
                            Console.WriteLine("{0}", message);
                        }
                        else if (message == "quit")
                        {
                            EndApp();
                        }

                        if (Console.KeyAvailable)
                        {
                            ConsoleKeyInfo pressedKey = Console.ReadKey(true);
                            if (pressedKey.Key == ConsoleKey.I)
                            {
                                Console.Write(">>");
                                //ReadLine example
                                string input = Console.ReadLine();
                                if (input == "quit")
                                {
                                    EndApp();
                                }
                                else
                                {
                                    server.Sent(input);
                                }
                            }
                        }
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
            Environment.Exit(0);
        }
    }
}
