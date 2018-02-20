namespace ChatLib
{
    public class MessageRecievedEventArgs
    {
        public MessageRecievedEventArgs(string msg)
        {
            GetMsg = msg;
        }

        public string GetMsg
        {
            get;
        }
    }
}
