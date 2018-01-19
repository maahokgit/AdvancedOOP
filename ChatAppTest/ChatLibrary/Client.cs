using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace ChatLibrary
{
    public class Client
    {
        TcpClient client;
        Byte[] data = new Byte[256];
        String responseData = String.Empty;
        public bool start()
        {
            try
            {
                client = new TcpClient("127.0.0.1", 13000);
                if (client.Connected == true)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (SocketException)
            {
                return false;
            }
        }
    }
}

