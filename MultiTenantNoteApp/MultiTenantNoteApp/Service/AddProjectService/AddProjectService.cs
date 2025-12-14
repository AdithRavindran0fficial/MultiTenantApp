using MultiTenantNoteApp.Helper;
using MultiTenantNoteApp.Models;
using MultiTenantNoteApp.Repositary.AddProjectRepository;

namespace MultiTenantNoteApp.Service.AddProjectService
{
    public class AddProjectService : IAddProjectService
    {
        private readonly IAddProjectRepo addProjectRepo;
        public AddProjectService(IAddProjectRepo addProject)
        {
            addProjectRepo = addProject;    
        }
        public async Task<ApiResponse<object>> AddprojectAsync(AddProjectDTO projectDTO)
        {
            try
            {
                if(projectDTO==null || string.IsNullOrEmpty(projectDTO.Name))
                {
                    return  new ApiResponse<object>("Bad Request", 400, null, "Invalid Input");
                }
                var project = new Project
                {
                    Name = projectDTO.Name,
                    Description = projectDTO.Description,
                };
                var result = await addProjectRepo.AddProject(project);
                if (result)
                {
                    return new ApiResponse<object>("Success", 200, null);
                }
                else
                {
                    return new ApiResponse<object>("Cannot add project", 200, null);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
