namespace MultiTenantNoteApp.Helper
{
    public interface ITenantProvider
    {
        Task<string> GetTenantConnectionString();
    }
}
