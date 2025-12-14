using MultiTenantNoteApp.Helper;
using MultiTenantNoteApp.Models;
using MultiTenantNoteApp.Repositary.AddTaskRepository;

namespace MultiTenantNoteApp.Service.AddTaskService
{
    public class AddTaskService : IAddTaskService
    {
        private readonly IAddTaskRepo addTaskRepo;

        public AddTaskService(IAddTaskRepo addTaskRepo)
        {
            this.addTaskRepo = addTaskRepo; 
        }
        public async Task<ApiResponse<object>> AddTask(AddTaskDTO addTask)
        {
            try
            {
                if(addTask==null || addTask.ProjectId==0|| string.IsNullOrEmpty(addTask.TaskName))
                {
                    return new ApiResponse<object>("BadRequest", 400, null, "Invalid Input");
                }
                var task = new TaskItem
                {
                    ProjectId = addTask.ProjectId,
                    TaskName = addTask.TaskName,
                    TaskDescription = addTask.TaskDescription,
                    TaskStatus = addTask.TaskStatus,
                };
                var result = await addTaskRepo.AddTask(task);
                if (result)
                {
                    return new ApiResponse<object>("Success", 200, null);
                }
                else
                {
                    return new ApiResponse<object>("InternalServer error", 500, "something went wrong");
                }
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
