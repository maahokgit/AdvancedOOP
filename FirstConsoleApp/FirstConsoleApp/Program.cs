﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FirstConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            //recognized flag at startup (-server)
            if(args.Contains("-server"))
            {
                Console.WriteLine("Running as Server");
            }
            else
            {
                Console.WriteLine("Running as Client");
            }

            //recognize when a specific key is pressed
            while (true) //endless loop
            {
                //check for messages
                //Console.WriteLine("Checking Messages");
               
                //check for key presses
                if(Console.KeyAvailable)
                {
                    ConsoleKeyInfo pressedKey = Console.ReadKey(true);
                    if (pressedKey.Key == ConsoleKey.I)
                    {
                        Console.WriteLine("You Pressed the I Key!!");
                        Console.WriteLine("Please enter a string >>");
                        //ReadLine example
                        string input = Console.ReadLine();
                        if (input == "quit")
                        {
                            break;
                        }
                        else
                        {
                            Console.WriteLine(input);
                        }
                        
                    }
                    else
                    {
                        Console.WriteLine("You didn't press the I key...");
                    }
                }

                Thread.Sleep(250);
            }

            Console.WriteLine("Thanks for using the Chat Console!");

            //read or take in input
            //string message = Console.ReadLine(); //blocking call

            //display output
            //Console.WriteLine("Here's some output!!");
            //Console.WriteLine("Here's your message: {0}", message);
                     
           //recognize flag at startup (-server)

            //keep window open
            Console.ReadKey(); //blocking call
        }
    }
}
