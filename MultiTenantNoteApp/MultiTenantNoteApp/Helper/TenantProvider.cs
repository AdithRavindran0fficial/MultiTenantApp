
namespace MultiTenantNoteApp.Helper
{
    public class TenantProvider : ITenantProvider
    {
        private readonly IHttpContextAccessor _contextAccessor;
        public TenantProvider(IHttpContextAccessor httpContext)
        {
            _contextAccessor = httpContext; 
        }
        public async Task<string> GetTenantConnectionString()
        {
            try
            {
                var connection =  _contextAccessor.HttpContext?.Items["Connection"]?.ToString();
                return connection;
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException();
            }
        }
    }
}
