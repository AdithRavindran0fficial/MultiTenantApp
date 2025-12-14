using MultiTenantNoteApp.Helper;
using MultiTenantNoteApp.Repositary.GettaskRepository;

namespace MultiTenantNoteApp.Service.GetTaskService
{
    public class GetTaskService : IGetTaskService
    {
        private readonly IGetTasksRepo getTasksRepo;
        public GetTaskService(IGetTasksRepo getTasks)
        {
            getTasksRepo = getTasks; 
        }
        public async Task<ApiResponse<object>> GetTasks(int id)
        {
            try 
            {
                var result = await getTasksRepo.GetTasksByProject(id);
                return new ApiResponse<object>("success",200,result);

            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
