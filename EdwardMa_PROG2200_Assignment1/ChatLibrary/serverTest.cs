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
        //some global variable to make the magic happen.
        TcpListener server = new TcpListener(IPAddress.Parse("127.0.0.1"), 13000);
        TcpClient client;
        Byte[] data = new Byte[256];
        String responseData = String.Empty;
        
        public void Start()
        {
            // Start listening for client requests.
            server.Start();
        }

        public bool Connect()
        {
            //connecting to client
            client = server.AcceptTcpClient();
            return true;
        }

        public void Sent(string message)
        {
            NetworkStream stream = client.GetStream();
            data = Encoding.ASCII.GetBytes(message);
            // Send the message to the connected TcpServer. 
            stream.Write(data, 0, message.Length);
        }

        public string DataResponse()
        {
            NetworkStream stream = client.GetStream();
            //checking for message. if data stream is available... run if... 
            if (stream.DataAvailable)
            {
                Int32 bytes = stream.Read(data, 0, data.Length);
                responseData = Encoding.ASCII.GetString(data, 0, bytes);
                return responseData;
            }
            return null;
        }
    }
}
