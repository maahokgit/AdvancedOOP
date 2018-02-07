﻿using System;
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
        public event ServerDisconnectEventArgs DisconEventMsg;

        /// <summary>
        ///  function to connect to server
        /// </summary>
        public bool start(out string eMessage)
        {
            try
            {
                eMessage = "Connected to Server";
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
        /// Function to close the connection
        /// </summary>
        /// <param name="eMessage"></param>
        /// <returns></returns>
        public bool close(out string eMessage)
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
            catch(NullReferenceException e)
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
                    DisconEventMsg(this, new DisconnectMsg(e.Message));
                }
            }
            catch (InvalidOperationException e)
            {
                DisconEventMsg(this, new DisconnectMsg(e.Message));
            }
            catch (NullReferenceException e)
            {
                DisconEventMsg(this, new DisconnectMsg(e.Message));
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

                        if(EventMsg != null)
                        {
                            EventMsg(this, new MessageRecieved(responseData)); 
                        }
                    }
                }
            }
            catch(InvalidOperationException e)
            {
                DisconEventMsg(this, new DisconnectMsg(e.Message));
            }
        }
    }
}
