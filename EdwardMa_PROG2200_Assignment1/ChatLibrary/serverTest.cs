using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace ChatLibrary
{
    public class serverTest
    {
        TcpListener server = new TcpListener(IPAddress.Parse("127.0.0.1"), 13000);
        TcpClient client;
        Byte[] data = new Byte[256];
        String responseData = String.Empty;
        
        public void Start()
        {
            // TcpListener server = new TcpListener(port);
            // Start listening for client requests.
            server.Start();

            // Buffer for reading data
            //Byte[] data = new Byte[256];
            //String responseData = String.Empty;
            //string input = null;
        }

        public bool Connect()
        {
            // Perform a blocking call to accept requests.
            // You could also user server.AcceptSocket() here.
            client = server.AcceptTcpClient();
            return true;
        }

        public void Sent(string message)
        {
            NetworkStream stream = client.GetStream();
            //Console.WriteLine(input);
            data = System.Text.Encoding.ASCII.GetBytes(message);
            // Send the message to the connected TcpServer. 
            stream.Write(data, 0, message.Length);
        }

        public string DataResponse()
        {
            NetworkStream stream = client.GetStream();
            if (stream.DataAvailable)
            {
                Int32 bytes = stream.Read(data, 0, data.Length); //breaking point...
                responseData = System.Text.Encoding.ASCII.GetString(data, 0, bytes);
                return responseData;
            }
            return null;
        }
    }
}
