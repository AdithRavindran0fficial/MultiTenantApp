using MultiTenantNoteApp.CustomAttribute;
using MultiTenantNoteApp.Helper;
using MultiTenantNoteApp.Repositary.GetConnectionStringRepository;

namespace MultiTenantNoteApp.Middleware
{
    public class TentantMiddleware : IMiddleware
    {
        private readonly IGetTenantConnectionStringRepo getTenantConnectionStringRepo;
        public TentantMiddleware(IGetTenantConnectionStringRepo getTenantConnectionString)
        {
            getTenantConnectionStringRepo = getTenantConnectionString;
        }

        public async Task InvokeAsync(HttpContext context, RequestDelegate _next)
        {
            try
            {
               if (context.GetEndpoint().Metadata.GetMetadata<AllowAnonymousAttribute>() != null)
                {
                    await _next(context);
                    return;
                }

                if (context.GetEndpoint().Metadata.GetMetadata<AllowTenantAttribute>() != null)
                {

                    if (context.Request.Headers.TryGetValue("X-Tenant", out var TenantId) || string.IsNullOrEmpty(TenantId))
                    {
                        if (!int.TryParse(TenantId.ToString(), out int tenantId))
                        {
                            var response = new ApiResponse<object>("Forbiden", 401, null, "NOt valid request");
                            context.Response.StatusCode = 401;
                            await context.Response.WriteAsJsonAsync(response);
                            return;
                        }
                        else
                        {
                            var connectionstring = await getTenantConnectionStringRepo.GetTenantConnectionStringAsync(tenantId);
                            context.Items["Connection"] = connectionstring;
                            await _next(context);
                        }
                    }
                }
                else
                {
                    await _next(context);   
                }
            }
            catch (Exception ex)
            {

            }
        }
    }
}
