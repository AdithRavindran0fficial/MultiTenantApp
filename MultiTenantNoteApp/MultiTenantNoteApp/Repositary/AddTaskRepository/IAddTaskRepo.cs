using MultiTenantNoteApp.Models;

namespace MultiTenantNoteApp.Repositary.AddTaskRepository
{
    public interface IAddTaskRepo
    {
        Task<bool> AddTask(TaskItem task);  
    }
}
