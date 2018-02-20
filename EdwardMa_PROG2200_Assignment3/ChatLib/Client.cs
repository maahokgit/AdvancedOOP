using System;
using System.Net.Sockets;
using System.Text;

namespace ChatLib
{
    public class Client
    {
        public Boolean checkConnection = true;
        TcpClient client;
        Byte[] data = new Byte[256];
        String responseData = String.Empty;
        public event MessageRecieveEventArgs EventMsg;
        public event ServerDisconnectEventArgs DisconEventMsg;

        /// <summary>
        ///  function to connect to server
        /// </summary>
        public bool Start(out string eMessage)
        {
            try
            {
                eMessage = "Connected to Server";
                client = new TcpClient("127.0.0.1", 1234);
                return true;
            }
            catch (SocketException e)
            {
                eMessage = e.Message;
                return false;
            }
        }

        /// <summary>
        /// Function to close the connection
        /// </summary>
        /// <param name="eMessage"></param>
        /// <returns></returns>
        public bool Close(out string eMessage)
        {
            try
            {
                eMessage = "Disconnected from Server";
                client.Close();
                return true;
            }
            catch (SocketException e)
            {
                eMessage = e.Message;
                return false;
            }
            catch (NullReferenceException e)
            {
                eMessage = e.Message;
                return false;
            }


        }

        /// <summary>
        /// Function that send message to the server
        /// </summary>
        /// <param name="message"></param>
        public void SentMessage(string message)
        {
            try
            {
                NetworkStream stream = client.GetStream();
                data = Encoding.ASCII.GetBytes(message);
                // Send the message to the connected TcpServer. 
                try
                {
                    stream.Write(data, 0, message.Length);
                }
                catch (System.IO.IOException e)
                {
                    DisconEventMsg(this, new DisconnectMsgEventArgs(e.Message));
                }
            }
            catch (InvalidOperationException e)
            {
                DisconEventMsg(this, new DisconnectMsgEventArgs(e.Message));
            }
            catch (NullReferenceException e)
            {
                DisconEventMsg(this, new DisconnectMsgEventArgs(e.Message));
            }
        }

        /// <summary>
        /// multi thread method to check message.
        /// </summary>
        public void RecievedMessage()
        {
            try
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

                        if (EventMsg != null)
                        {
                            EventMsg(this, new MessageRecievedEventArgs(responseData));
                        }
                    }
                }
            }
            catch (InvalidOperationException e)
            {
                DisconEventMsg(this, new DisconnectMsgEventArgs(e.Message));
            }
        }
    }
}
