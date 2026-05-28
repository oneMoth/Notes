using System;

namespace Notes
{
    public class Note
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string Title { get; set; }
        public DateTime ReminderDate { get; set; }
        public string Priority { get; set; } // Высокий, Средний, Низкий
        public bool IsCompleted { get; set; }
        public string Text { get; set; }
    }
}
