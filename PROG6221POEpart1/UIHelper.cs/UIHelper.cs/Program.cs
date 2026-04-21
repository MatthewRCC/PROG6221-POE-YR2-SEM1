using System;

public class UIHelper
{
    public static void ShowLogo()
    {
        Console.ForegroundColor = ConsoleColor.Cyan;

        Console.WriteLine(@"
   _____           _           ____        _   
  / ____|         | |         |  _ \      | |  
 | |     _ __ ___ | |__   ___ | |_) | ___ | |_ 
 | |    | '_ ` _ \| '_ \ / _ \|  _ < / _ \| __|
 | |____| | | | | | |_) | (_) | |_) | (_) | |_ 
  \_____|_| |_| |_|_.__/ \___/|____/ \___/ \__|
        CYBER SECURITY BOT
        ");

        Console.ResetColor();
    }

    public static void Divider()
    {
        Console.WriteLine("=====================================");
    }
}