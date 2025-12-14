namespace MultiTenantNoteApp.CustomAttribute
{
    [AttributeUsage(AttributeTargets.Method|AttributeTargets.Class)]
    public class AllowAnonymousAttribute : Attribute
    {

    }
}
