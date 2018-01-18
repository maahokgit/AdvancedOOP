using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace ChatLibrary
{
    public class clientTest
    {
        
        public void start()
        {
            TcpClient client = new TcpClient("127.0.0.1", 13000);
        }
    }
}
