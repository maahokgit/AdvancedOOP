using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChatUI
{
    public partial class ChatUI : Form
    {
        public ChatUI()
        {
            InitializeComponent();
        }

        private void ChatUI_Load(object sender, EventArgs e)
        {
            //connect to server
            
            //(seperate thread) and check for messages

            //if there is a message, show it on chatBox
        }

        private void sendBtn_Click(object sender, EventArgs e)
        {
            //grab text from sendBox, and sent it to server
        }
    }
}
