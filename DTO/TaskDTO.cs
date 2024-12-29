

namespace TaskManager.DTO
{
    public class TaskDto
    {
        public required String TaskName { get; set; }
        public required String TaskDescription { get; set; }
        public Boolean TaskStatus { get; set; }
    }
}