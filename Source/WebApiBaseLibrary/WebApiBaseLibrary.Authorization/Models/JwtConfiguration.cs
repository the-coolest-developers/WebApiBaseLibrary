namespace WebApiBaseLibrary.Authorization.Models
{
    public class JwtConfiguration
    {
        public string Issuer { get; set; }
        public string Audience { get; set; }
        public int TokenLifetime { get; set; }
        public string SecretKey { get; set; }
    }
}