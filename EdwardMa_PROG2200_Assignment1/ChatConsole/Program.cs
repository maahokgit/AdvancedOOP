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
                while(true) //first while
                {
                    //waiting for connection
                    Console.WriteLine("Waiting For Connection");
                    if (server.Connect() == true)
                    {
                        //connected!
                        Console.WriteLine("Connected to Client");
                    }

                    while (true) //second while
                    {
                        //checking for message...
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

                        //waiting for user to press something... and hoping it's I.
                        if (Console.KeyAvailable)
                        {
                            ConsoleKeyInfo pressedKey = Console.ReadKey(true);
                            if (pressedKey.Key == ConsoleKey.I)
                            {
                                Console.Write(">>");
                                //prompt user to enter something.... if it's quit, it will jump to EndApp()
                                string input = Console.ReadLine();
                                if (input == "quit")
                                {
                                    server.Sent(input);
                                    EndApp();
                                }
                                else
                                {
                                    //sending message client... 
                                    server.Sent(input);
                                }
                            }
                        }
                        //from good old stackoverflow...
                        //https://stackoverflow.com/questions/177856/how-do-i-trap-ctrl-c-in-a-c-sharp-console-app
                        Console.CancelKeyPress += delegate (object sender, ConsoleCancelEventArgs e)
                        {
                            server.Sent("quit");
                            EndApp();
                        };
                    } //end second while loop
                } //end first while loop
            }
            else
            {
                //client mode
                clientTest client = new clientTest();
                if (client.start() == true)
                {
                    Console.WriteLine("Connected to Server");
                }
                else
                {
                    Console.WriteLine("Not Server to Connect");
                }

                while (true) //second while
                {
                    //checking for message...
                    string message = string.Empty;
                    message = client.DataResponse();
                    if (message != "quit" && message != null)
                    {
                        Console.Write("<<");
                        Console.WriteLine("{0}", message);
                    }
                    else if (message == "quit")
                    {
                        EndApp();
                    }

                    //waiting for user to press something... and hoping it's I.
                    if (Console.KeyAvailable)
                    {
                        ConsoleKeyInfo pressedKey = Console.ReadKey(true);
                        if (pressedKey.Key == ConsoleKey.I)
                        {
                            Console.Write(">>");
                            //prompt user to enter something.... if it's quit, it will jump to EndApp()
                            string input = Console.ReadLine();
                            if (input == "quit")
                            {
                                client.Sent(input);
                                EndApp();
                            }
                            else
                            {
                                //sending message client... 
                                client.Sent(input);
                            }
                        }
                    }
                    //from good old stackoverflow...
                    //https://stackoverflow.com/questions/177856/how-do-i-trap-ctrl-c-in-a-c-sharp-console-app
                    Console.CancelKeyPress += delegate (object sender, ConsoleCancelEventArgs e)
                    {
                        client.Sent("quit");
                        EndApp();
                    };
                } //end second while loop
            } //end first while loop
        }

        //a little method to end the program nicely...
        static void EndApp()
        {
            Console.WriteLine("Thanks for using the Chat Console!\nPress 'anykey' to quit.");
            //keep window open
            Console.ReadKey(); //blocking call
            Environment.Exit(0);
        }
    }
}
