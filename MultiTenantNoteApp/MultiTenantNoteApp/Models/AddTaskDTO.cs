namespace MultiTenantNoteApp.Models
{
    public class AddTaskDTO
    {
        public int ProjectId { get; set; }
        public string TaskName { get; set; }
        public string TaskDescription { get; set; }
        public string TaskStatus { get; set; }
    }
}
