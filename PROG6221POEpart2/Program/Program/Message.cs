using System;
using System.Security.Cryptography;
using System.Text;

namespace QuickChatApp
{
    internal class Message
    {
        public string Recipient { get; set; } = string.Empty;
        public string MessageText { get; set; } = string.Empty;
        private string? messageId;
        private string messageHash = string.Empty;

        public void GenerateMessageID()
        {
            messageId = Guid.NewGuid().ToString();
        }

        public void CreateMessageHash()
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                string rawData = $"{Recipient}{MessageText}{messageId}";
                byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(rawData));
                messageHash = BitConverter.ToString(bytes).Replace("-", "").ToLowerInvariant();
            }
        }

        public bool CheckRecipientCell()
        {

            return !string.IsNullOrEmpty(Recipient) && Recipient.Length == 10 && long.TryParse(Recipient, out _);
        }

        public bool CheckMessageLength()
        {
            return !string.IsNullOrEmpty(MessageText) && MessageText.Length <= 250;
        }

        public string PrintMessage()
        {
            return $"To: {Recipient}\nMessage: {MessageText}\nID: {messageId}\nHash: {messageHash}";
        }
    }
}