namespace MultiTenantNoteApp.Repositary.GetConnectionStringRepository
{
    public interface IGetTenantConnectionStringRepo
    {
        Task<string> GetTenantConnectionStringAsync(int Id);  
    }
}

