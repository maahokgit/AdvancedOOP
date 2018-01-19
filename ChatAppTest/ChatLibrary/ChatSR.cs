using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace ChatLibrary //trying to seperate but didn't work
{
    public class ChatSR //SR for Sending and Recieving
    {
        TcpClient client;
        Byte[] data = new Byte[256];
        String responseData = String.Empty;
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
