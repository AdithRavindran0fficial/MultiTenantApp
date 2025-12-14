namespace MultiTenantNoteApp.Models
{
    public class Tenanats
    {
        public int Id { get; set; } 

        public string? ConnectionString { get; set; }
        public bool IsActive { get; set; }    
        public string ? TenantName {  get; set; }
        public string? Password { get; set; }    
        public string ? Email { get; set; }

        public string ? Role {  get; set; }
    }
}
