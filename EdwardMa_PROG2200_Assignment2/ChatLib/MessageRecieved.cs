namespace ChatLib
{
    public class MessageRecieved
    {

        public MessageRecieved(string msg)
        {
            GetMsg = msg;
        }

        public string GetMsg { get; }
    }
}