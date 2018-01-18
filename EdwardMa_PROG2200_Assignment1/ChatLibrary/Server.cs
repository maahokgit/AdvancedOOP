using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;

namespace ChatLibrary
{
    public class Server
    {
        public void start()
        {
            // TcpListener server = new TcpListener(port);
            TcpListener server = new TcpListener(IPAddress.Parse("127.0.0.1"), 13000);

            // Start listening for client requests.
            server.Start();

            // Buffer for reading data
            Byte[] data = new Byte[256];
            String responseData = String.Empty;
            string input = null;

            while (true)
            {
                Console.Write("Waiting for a connection... ");

                // Perform a blocking call to accept requests.
                // You could also user server.AcceptSocket() here.
                TcpClient client = server.AcceptTcpClient();
                Console.WriteLine("Connected!");
                // Get a stream object for reading and writing
                NetworkStream stream = client.GetStream();

                //int i;

                // Loop to receive all the data sent by the client.
                while (true)
                {
                    if (stream.DataAvailable)
                    {
                        Int32 bytes = stream.Read(data, 0, data.Length); //breaking point...
                        responseData = System.Text.Encoding.ASCII.GetString(data, 0, bytes);
                        if (responseData == "quit")
                        {
                            break;
                        }
                        Console.WriteLine("Received: {0}", responseData);
                    }
                    else if (client.d)

                    if (Console.KeyAvailable)
                    {
                        ConsoleKeyInfo pressedKey = Console.ReadKey(true);
                        if (pressedKey.Key == ConsoleKey.I)
                        {
                            Console.Write(">>");
                            //ReadLine example
                            input = Console.ReadLine();
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
                
                // Shutdown and end connection
                if (input == "quit")
                {
                    client.Close();
                    break;
                }
            }
            Console.WriteLine("Thanks for using the Chat Console!\nPress 'anykey' to quit.");
            //keep window open
            Console.ReadKey(); //blocking call
        }
    }
}
