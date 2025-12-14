using MultiTenantNoteApp.Helper;
using MultiTenantNoteApp.Repositary.GetProjectRepository;

namespace MultiTenantNoteApp.Service.GetProjectService
{
    public class GetProjectService : IGetProjectService
    {
        private readonly IGetProjectRepo projectRepo;
        public GetProjectService(IGetProjectRepo projectRepo)
        {
            this.projectRepo = projectRepo;
        }
        public async Task<ApiResponse<object>> GetProjectAsync()
        {
            try
            {
                var result = await projectRepo.GetProject();
                return new ApiResponse<object>("Success",200, result);

            }
            catch(Exception ex)
            {
                throw new Exception (ex.Message);
            }
        }
    }
}
