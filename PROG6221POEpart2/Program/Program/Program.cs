using QuickChatApp;
using System;
using System.IO;

Login login = new Login();

Console.WriteLine("===== QUICKCHAT LOGIN =====");

Console.Write("Enter Username: ");
string? username = Console.ReadLine() ?? string.Empty;

Console.Write("Enter Password: ");
string password = Console.ReadLine() ?? string.Empty;

if (login.LoginUser(username, password))
{
    Console.WriteLine("\nLogin Successful!");
    Console.WriteLine("\nWelcome to QuickChat.");

    Console.Write("\nHow many messages would you like to send? ");
    int totalMessages = int.Parse(Console.ReadLine() ?? "0");

    Message[] messages = new Message[totalMessages];

    int sentCount = 0;
    int option = 0;

    while (option != 3)
    {
        Console.WriteLine("\n===== MENU =====");
        Console.WriteLine("1. Send Messages");
        Console.WriteLine("2. Show recently sent messages");
        Console.WriteLine("3. Quit");

        Console.Write("Choose an option: ");
        option = int.Parse(Console.ReadLine());

        switch (option)
        {
            case 1:

                if (sentCount >= totalMessages)
                {
                    Console.WriteLine("Message limit reached.");
                    break;
                }

                Message msg = new Message();

                Console.Write("Enter recipient cell number: ");
                msg.Recipient = Console.ReadLine();

                Console.Write("Enter message: ");
                msg.MessageText = Console.ReadLine();

                if (!msg.CheckRecipientCell())
                {
                    Console.WriteLine("Cell number incorrectly formatted.");
                    break;
                }

                if (!msg.CheckMessageLength())
                {
                    Console.WriteLine("Message exceeds 250 characters.");
                    break;
                }

                Console.WriteLine("\nChoose message option:");
                Console.WriteLine("1. Send Message");
                Console.WriteLine("2. Disregard Message");
                Console.WriteLine("3. Store Message");

                int messageChoice = int.Parse(Console.ReadLine());

                switch (messageChoice)
                {
                    case 1:
                        msg.GenerateMessageID();
                        msg.CreateMessageHash();

                        messages[sentCount] = msg;
                        sentCount++;

                        Console.WriteLine(msg.PrintMessage());
                        File.AppendAllText("messages.txt", msg.PrintMessage() + Environment.NewLine);

                        break;

                    case 2:
                        Console.WriteLine("Message disregarded.");
                        break;

                    case 3:
                        msg.GenerateMessageID();
                        msg.CreateMessageHash();
                        File.AppendAllText("messages.txt", msg.PrintMessage() + Environment.NewLine);

                        Console.WriteLine("Message stored successfully.");
                        break;

                    default:
                        Console.WriteLine("Invalid choice.");
                        break;
                }

                break;

            case 2:
                Console.WriteLine("Coming Soon.");
                break;

            case 3:
                Console.WriteLine("Exiting QuickChat...");
                break;

            default:
                Console.WriteLine("Invalid option.");
                break;
        }
    }

    Console.WriteLine($"\nTotal messages sent: {sentCount}");
}
else
{
    Console.WriteLine("Login Failed.");
}

Console.ReadKey();
