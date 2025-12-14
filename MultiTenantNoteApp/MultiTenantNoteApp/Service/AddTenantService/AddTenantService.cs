using Microsoft.VisualBasic;
using MultiTenantNoteApp.Helper;
using MultiTenantNoteApp.Models;
using MultiTenantNoteApp.Repositary.AddTenantRepository;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;

namespace MultiTenantNoteApp.Service.AddTenantService
{
    public class AddTenantService : IAddTentantService
    {
        private readonly IAddTenantRepo addTenantRepo;
        public AddTenantService(IAddTenantRepo addTenant) 
        { 
            addTenantRepo = addTenant; 
        }

        public async Task<ApiResponse<object>> AddTentantAsync(TenantDTO tenant)
        {
            try
            {
                if (tenant == null || string.IsNullOrEmpty(tenant.TenantName))
                {
                    return new ApiResponse<object>("Bad Request", 400, null,"tenant name is empty");
                }
                var tenantObj = new Tenanats
                {
                    TenantName = tenant.TenantName,
                    IsActive = true,
                    Email = tenant.Email,
                    Password = tenant.Password,

                };
                var response = await addTenantRepo.AddTenant(tenantObj);
                if (response)
                {
                    return new ApiResponse<object>("Success", 200, null, null);
                }
                else
                {
                    return new ApiResponse<object>("Bad Request", 400, null, "Tenant Already Exist");
                }
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }

}
