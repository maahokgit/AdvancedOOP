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
        byte[] buffer;
        public ChatUI()
        {
            InitializeComponent();
        }

        private void ChatUI_Load(object sender, EventArgs e)
        {
            try
            {
                //connect to server
                client.start();
                chatBox.Items.Add("Connected to Server");
                //(seperate thread) and check for messages
                //if there is a message, show it on chatBox


                //(seperate thread?) log messages
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
            //make sure all thread is completed
            //and closed gracefully
        }
    }
}
