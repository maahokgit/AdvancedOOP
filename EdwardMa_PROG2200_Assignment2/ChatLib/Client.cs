using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace ChatLib
{
    public class Client
    {
        public Boolean checkConnection = true;
        TcpClient client;
        Byte[] data = new Byte[256];
        String responseData = String.Empty;

        public event MessageRecieveEventArgs EventMsg;

        /// <summary>
        ///  function to connect to server
        /// </summary>
        public void start()
        {
            client = new TcpClient("127.0.0.1", 13000);
        }


        public bool tart(out string eMessage)
        {
            try
            {
                eMessage = String.Empty;
                client = new TcpClient("127.0.0.1", 13000);
                return true;
            }
            catch (SocketException e)
            {
                eMessage = e.Message;
                return false;
            }
            
        }


        /// <summary>
        ///  function to send msg to server
        /// </summary>
        public void SentMessage(string message)
        {
            NetworkStream stream = client.GetStream();
            data = Encoding.ASCII.GetBytes(message);
            // Send the message to the connected TcpServer. 
            stream.Write(data, 0, message.Length);
        }

        /// <summary>
        /// main prog run this in 2nd while loop and wait for msg from server.
        /// </summary>
        //public string RecievedMessage()
        //{
        //    NetworkStream stream = client.GetStream();
        //    //checking for message. if data stream is available... run if... 
        //    if (stream.DataAvailable)
        //    {
        //        Int32 bytes = stream.Read(data, 0, data.Length);
        //        responseData = Encoding.ASCII.GetString(data, 0, bytes);
        //        return responseData;
        //    }
        //    return null;
        //}

        public void RecievedMessage()
        {
            NetworkStream stream = client.GetStream();
            //checking for message. if data stream is available... run if... 
            while (checkConnection == true)
            {
                if (stream.DataAvailable)
                {
                    Int32 bytes = stream.Read(data, 0, data.Length);
                    responseData = Encoding.ASCII.GetString(data, 0, bytes);
                    //run delegate 

                    if(EventMsg != null)
                    {
                        EventMsg(this, new MessageRecieved(responseData)); 
                    }
                }
            }

        }
    }
}
