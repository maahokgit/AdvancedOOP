using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace ChatLibrary
{
    public class Server
    {
        //some global variable to make the magic happen
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
    }
}
