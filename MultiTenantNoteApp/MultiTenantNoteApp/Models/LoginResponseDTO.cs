namespace MultiTenantNoteApp.Models
{
    public class LoginResponseDTO
    {
        public int TenantId { get; set; }   
        public string? TenantName { get; set; }
        public string Token { get; set; }   
    }
}
