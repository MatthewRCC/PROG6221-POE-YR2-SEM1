using System;
using System.Threading;

public class Chatbot
{
    private string userName = string.Empty;

    private void TypeText(string message)
    {
        foreach (char c in message)
        {
            Console.Write(c);
            Thread.Sleep(20);
        }
        Console.WriteLine();
    }

    public void Start()
    {
        AudioPlayer.PlayGreeting();
        UIHelper.ShowLogo();

        Console.Write("Enter your name: ");
        userName = Console.ReadLine() ?? string.Empty;

        if (string.IsNullOrWhiteSpace(userName))
        {
            userName = "User";
        }

        Console.WriteLine($"Welcome, {userName}! I'm here to help you stay safe online.");
        UIHelper.Divider();

        RunChat();
    }

    private void Respond(string input)
    {
        Console.ForegroundColor = ConsoleColor.Green;

        if (input.Contains("how are you"))
        {
            TypeText("Bot: I'm just code, but I'm here to help you!");
        }
        else if (input.Contains("purpose"))
        {
            TypeText("Bot: I educate users about cybersecurity threats.");
        }
        else if (input.Contains("password"))
        {
            TypeText("Bot: Use strong passwords with letters, numbers, and symbols.");
        }
        else if (input.Contains("phishing"))
        {
            TypeText("Bot: Be careful of suspicious emails asking for personal info.");
        }
        else if (input.Contains("link"))
        {
            TypeText("Bot: Always verify links before clicking.");
        }
        else
        {
            TypeText("Bot: I didn’t quite understand that. Could you rephrase?");
        }

        Console.ResetColor();
    }

    private void RunChat()
    {
        while (true)
        {
            Console.Write("\nYou: ");
            string input = Console.ReadLine()?.ToLowerInvariant() ?? string.Empty;

            if (string.IsNullOrWhiteSpace(input))
            {
                Console.WriteLine("Bot: Please enter something.");
                continue;
            }

            if (input == "exit")
            {
                Console.WriteLine("Bot: Stay safe online. Goodbye!");
                break;
            }

            Respond(input);
        }
    }
}

internal static class AudioPlayer
{
    public static void PlayGreeting()
    {
        // Minimal placeholder so code compiles without external dependencies.
        Console.Beep(440, 100);
    }
}

internal static class UIHelper
{
    public static void ShowLogo()
    {
        Console.WriteLine("=== SecureChat Bot ===");
    }

    public static void Divider()
    {
        Console.WriteLine(new string('-', 30));
    }
}