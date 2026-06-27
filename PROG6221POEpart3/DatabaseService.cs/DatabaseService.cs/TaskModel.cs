
namespace CyberSecurityAwarenessBot.Services
{
    public class TaskModel
    {
        public DateTime ReminderDate { get; internal set; }
        public string Description { get; internal set; }
        public string Title { get; internal set; }
        public bool IsCompleted { get; internal set; }
        public int TaskID { get; internal set; }
    }
}