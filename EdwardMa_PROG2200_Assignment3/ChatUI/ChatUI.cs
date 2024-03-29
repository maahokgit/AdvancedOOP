﻿using ChatLib;

// Stephen's Logger
using ChatLogger;

// Edward's Logger
//using ChatLog;

using System;
using System.Threading;
using System.Windows.Forms;

namespace ChatUI
{
    public partial class ChatUI : Form
    {
        private readonly ILoggingService log;
        Client client = new Client();

        Thread checkingMessage;
        string eM;

        public ChatUI(ILoggingService log)
        {
            this.log = log;
            InitializeComponent();

            client.EventMsg += new MessageRecieveEventArgs(CheckingMessage);
            client.DisconEventMsg += new ServerDisconnectEventArgs(ServerDisconnect);
        }

        private void ServerDisconnect(object sender, DisconnectMsgEventArgs e)
        {
            if (chatBox.InvokeRequired)
            {
                //yes we are!....invoke required
                MethodInvoker invoker = new MethodInvoker(
                    //anonymous function/method
                    delegate ()
                    {
                        chatBox.Items.Add(e.DisconMsg);
                    }
                );
                chatBox.BeginInvoke(invoker); //avoid deadlock
            }
            else
            {
                //no we're not...no cross-thread scenario
                //it's business as usual
                chatBox.Items.Add(e.DisconMsg);
            }
        }

        private void CheckingMessage(object sender, MessageRecievedEventArgs e)
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

        }

        private void sendBtn_Click(object sender, EventArgs e)
        {
            //grab text from sendBox, sent it to server, and add it to chatBox
            client.SentMessage(sendBox.Text);
            chatBox.Items.Add("Me: " + sendBox.Text);
            sendBox.Text = "";
        }

        private void ChatUI_FormClosing(object sender, FormClosingEventArgs e)
        {
            foreach (var item in chatBox.Items)
            {
                //ILoggingService(item.ToString());
                log.Log(DateTime.Now.ToString() + ": "+ item.ToString());
            }


            if (checkingMessage != null && checkingMessage.IsAlive)
            {
                client.checkConnection = false;
                checkingMessage.Join();
            }
        }

        //network menu item to connect to server
        private void connectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (client.Start(out eM))
            {
                chatBox.Items.Add(eM);
                checkingMessage = new Thread(client.RecievedMessage);
                checkingMessage.Name = "messageThread";
                checkingMessage.Start();
            }
            else
            {
                chatBox.Items.Add(eM);
            }
        }

        //network menu item to disconnect
        private void disconnectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (client.Close(out eM))
            {
                chatBox.Items.Add(eM);
            }
            else
            {
                chatBox.Items.Add(eM);
            }
        }
    }
}
