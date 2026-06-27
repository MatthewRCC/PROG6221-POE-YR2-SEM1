namespace CyberSecurityAwarenessBot.Models
{
    public class TaskModel
    {
        public int TaskID { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public System.DateTime ReminderDate { get; set; }

        public bool IsCompleted { get; set; }
    }
}