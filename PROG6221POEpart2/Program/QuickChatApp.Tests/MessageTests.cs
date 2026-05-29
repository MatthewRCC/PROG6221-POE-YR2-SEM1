using Microsoft.VisualStudio.TestTools.UnitTesting;
using QuickChatApp;

namespace QuickChatApp.Tests
{
    [TestClass]
    public class MessageTests
    {
        [TestMethod]
        public void TestMessageLength()
        {
            Message msg = new Message();
            msg.MessageText = "Hello";

            Assert.IsTrue(msg.CheckMessageLength());
        }
    }
}