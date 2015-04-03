namespace StoreWebApp.Models
{
    public class MessageModel
    {
        public string Text { get; set; }
        public MessageType Type { get; set; }
        public MessageModel(string text)
        {
            Text = text;
        }
        public MessageModel(string text, MessageType type)
            : this(text)
        {
            Type = type;
        }
    }
}