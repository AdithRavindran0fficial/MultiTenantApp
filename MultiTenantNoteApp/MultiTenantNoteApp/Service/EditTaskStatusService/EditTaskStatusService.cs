using MultiTenantNoteApp.Helper;
using MultiTenantNoteApp.Models;
using MultiTenantNoteApp.Repositary.ChangeTaskRepo;

namespace MultiTenantNoteApp.Service.EditTaskStatusService
{
    public class EditTaskStatusService : IEditTaskStatusService 
    {
        private readonly IEditTaskStatusRepo editTaskStatusRepo;
        public EditTaskStatusService(IEditTaskStatusRepo editTaskStatus) 
        { 
                    editTaskStatusRepo = editTaskStatus;    
        }

         public async Task<ApiResponse<object>> EditTaskStatus(UpdateTaskStatusDTO updateTaskStatus)
        {
            try
            {
                if(updateTaskStatus == null || updateTaskStatus.TaskStatus==0 )
                {
                    return new ApiResponse<object>("Bad Request", 400, null, "Invalid Input");
                }
                var result = await editTaskStatusRepo.EditStatus(updateTaskStatus);
                if (result)
                {
                    return new ApiResponse<object>("Success", 200, null);
                }
                else
                {
                    return new ApiResponse<object>("Internal Server Error", 500, null,"Something Went Wrong");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
