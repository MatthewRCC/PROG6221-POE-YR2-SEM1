namespace QuickChatApp
{
    internal class Message
    {
        public string Recipient { get; set; }
        public string MessageText { get; set; }

        public bool CheckRecipientCell()
        {
            return !string.IsNullOrEmpty(Recipient);
        }

        public bool CheckMessageLength()
        {
            return MessageText != null && MessageText.Length <= 250;
        }

        public void GenerateMessageID()
        {
        }

        public void CreateMessageHash()
        {
        }

        public string PrintMessage()
        {
            return $"To: {Recipient}\nMessage: {MessageText}";
        }
    }
}