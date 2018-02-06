using System;

namespace ChatLib
{
    public delegate void MessageRecieveEventArgs(object sender, MessageRecieved e);
    public delegate void ServerDisconnectEventArgs(object sender, DisconnectMsg e);
}