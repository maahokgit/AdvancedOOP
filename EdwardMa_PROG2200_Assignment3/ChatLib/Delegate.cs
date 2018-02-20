using System;

namespace ChatLib
{
    public delegate void MessageRecieveEventArgs(object sender, MessageRecievedEventArgs e);
    public delegate void ServerDisconnectEventArgs(object sender, DisconnectMsgEventArgs e);
}