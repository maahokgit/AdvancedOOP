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
                Server server = new Server();
                server.start();
            }
            else
            {
                //client mode
                Client client = new Client();
                client.Connect();
            }
        }
    }
}
