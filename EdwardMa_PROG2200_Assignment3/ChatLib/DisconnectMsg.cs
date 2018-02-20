namespace ChatLib
{
    public class DisconnectMsgEventArgs
    {
        public DisconnectMsgEventArgs(string msg)
        {
            DisconMsg = msg;
        }

        public string DisconMsg
        {
            get;
        }
    }
}
