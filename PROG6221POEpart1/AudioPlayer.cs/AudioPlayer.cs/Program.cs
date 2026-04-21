using System.Media;

public class AudioPlayer
{
    public static void PlayGreeting()
    {
        try
        {
            SoundPlayer player = new SoundPlayer("Assets/greeting.wav");
            player.PlaySync();
        }
        catch
        {
            Console.WriteLine("Audio could not be played.");
        }
    }
}