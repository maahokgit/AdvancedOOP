using ChatLib;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChatUI
{
    public partial class ChatUI : Form
    {
        Client client = new Client();
        Thread checkingMessage;
        string eM;
        public ChatUI()
        {
            InitializeComponent();

            client.EventMsg += new ChatLib.MessageRecieveEventArgs(CheckingMessage);
        }

        private void CheckingMessage(object sender, MessageRecieved e)
        {
            if (chatBox.InvokeRequired)
            {
                //yes we are!....invoke required
                MethodInvoker invoker = new MethodInvoker(
                    //anonymous function/method
                    delegate ()
                    {
                        chatBox.Items.Add("Server: " + e.GetMsg);
                    }
                );
                //taskProgressBar.Invoke(invoker);
                chatBox.BeginInvoke(invoker); //avoid deadlock

            }
            else
            {
                //no we're not...no cross-thread scenario
                //it's business as usual
                chatBox.Items.Add("Server: " + e.GetMsg);
            }

        }

        private void ChatUI_Load(object sender, EventArgs e)
        {
            try
            {
                //connect to server
                client.start();
                chatBox.Items.Add("Connected to Server");
                //(seperate thread) and check for messages
                checkingMessage = new Thread(client.RecievedMessage);
                checkingMessage.Name = "messageThread";
                checkingMessage.Start();
                //if there is a message, show it on chatBox


                if(client.tart(out eM))
                {
                    chatBox.Items.Add("Connected to Server");
                }
                else
                {
                    chatBox.Items.Add(eM);
                }
            }
            catch
            {
                chatBox.Items.Add("Server not connected.");
                chatBox.Items.Add("Please try again later.");
            }
        }

        private void sendBtn_Click(object sender, EventArgs e)
        {
            //grab text from sendBox, and sent it to server
            client.SentMessage(sendBox.Text);

            chatBox.Items.Add("Me: " + sendBox.Text);
            sendBox.Text = "";
        }

        private void ChatUI_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(checkingMessage != null && checkingMessage.IsAlive)
            {
                client.checkConnection = false;
                checkingMessage.Join();
            }
        }
    }
}
