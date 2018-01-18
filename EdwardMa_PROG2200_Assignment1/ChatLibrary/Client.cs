using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;

namespace ChatLibrary
{
    public class Client
    {
        public void Connect()
        {
            Byte[] data = new byte[256];
            //Byte[] bytes = new byte[256];
            TcpClient client = new TcpClient("127.0.0.1",13000);
            NetworkStream stream = client.GetStream();
            while (true) //endless loop
            {
                //check for messages

                // String to store the response ASCII representation.
                String responseData = String.Empty;
                /// Read the first batch of the TcpServer response bytes.
                if(stream.DataAvailable)
                {
                    Int32 bytes = stream.Read(data, 0, data.Length); //breaking point...
                    responseData = System.Text.Encoding.ASCII.GetString(data, 0, bytes);
                    if (responseData == "quit")
                    {
                        break;
                    }
                    Console.WriteLine("Received: {0}", responseData);
                }
                
                //check for key presses
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
                            data = System.Text.Encoding.ASCII.GetBytes(input);
                            // Send the message to the connected TcpServer. 
                            stream.Write(data, 0, input.Length);
                            Console.WriteLine("Sent: {0}", input);
                            break;
                        }
                        else
                        {
                            //Console.WriteLine(input);
                            data = System.Text.Encoding.ASCII.GetBytes(input);
                            // Send the message to the connected TcpServer. 
                            stream.Write(data, 0, input.Length);
                            Console.WriteLine("Sent: {0}", input);
                        }
                    }
                    else
                    {
                        Console.WriteLine("You didn't press the I key...");
                    }
                }
                
            }
             Console.WriteLine("Thanks for using the Chat Console!\nPress 'anykey' to quit.");
             //keep window open
             Console.ReadKey(); //blocking call
        }
    }
}
