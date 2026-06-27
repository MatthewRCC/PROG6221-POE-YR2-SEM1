using MySql.Data.MySqlClient;

namespace CyberSecurityAwarenessBot.Services
{
    public class DatabaseService
    {
        private readonly string connectionString =
            "server=localhost;database=CyberSecurityBotDB;uid=root;pwd=YOURPASSWORD;";

        public void AddTask(TaskModel task)
        {
            using MySqlConnection conn = new MySqlConnection(connectionString);

            conn.Open();

            string sql =
            @"INSERT INTO Tasks
            (Title,Description,ReminderDate,IsCompleted)
            VALUES
            (@Title,@Description,@Reminder,@Completed)";

            MySqlCommand cmd = new MySqlCommand(sql, conn);

            cmd.Parameters.AddWithValue("@Title", task.Title);
            cmd.Parameters.AddWithValue("@Description", task.Description);
            cmd.Parameters.AddWithValue("@Reminder", task.ReminderDate);
            cmd.Parameters.AddWithValue("@Completed", task.IsCompleted);

            cmd.ExecuteNonQuery();
        }

        public List<TaskModel> GetTasks()
        {
            List<TaskModel> tasks = new();

            using MySqlConnection conn = new MySqlConnection(connectionString);

            conn.Open();

            string sql = "SELECT * FROM Tasks";

            MySqlCommand cmd = new MySqlCommand(sql, conn);

            MySqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                tasks.Add(new TaskModel
                {
                    TaskID = reader.GetInt32("TaskID"),
                    Title = reader.GetString("Title"),
                    Description = reader.GetString("Description"),
                    ReminderDate = reader.GetDateTime("ReminderDate"),
                    IsCompleted = reader.GetBoolean("IsCompleted")
                });
            }

            return tasks;
        }

        public void DeleteTask(int id)
        {
            using MySqlConnection conn = new MySqlConnection(connectionString);

            conn.Open();

            string sql = "DELETE FROM Tasks WHERE TaskID=@id";

            MySqlCommand cmd = new MySqlCommand(sql, conn);

            cmd.Parameters.AddWithValue("@id", id);

            cmd.ExecuteNonQuery();
        }

        public void CompleteTask(int id)
        {
            using MySqlConnection conn = new MySqlConnection(connectionString);

            conn.Open();

            string sql =
            "UPDATE Tasks SET IsCompleted=TRUE WHERE TaskID=@id";

            MySqlCommand cmd = new MySqlCommand(sql, conn);

            cmd.Parameters.AddWithValue("@id", id);

            cmd.ExecuteNonQuery();
        }
    }
}