namespace WebApiBaseLibrary.Authorization.Readers
{
    public interface IJwtReader
    {
        string GetUserIdFromToken(string token);
        string GetUserRoleFromToken(string token);
        string GetClaimFromToken(string token, string claimType);
    }
}