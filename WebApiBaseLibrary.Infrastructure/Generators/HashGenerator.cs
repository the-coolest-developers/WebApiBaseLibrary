using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using WebApiBaseLibrary.Infrastructure.Configuration;

namespace WebApiBaseLibrary.Infrastructure.Generators
{
    public class HashGenerator : IHashGenerator
    {
        private HashConfiguration Configuration { get; }

        public HashGenerator(HashConfiguration configuration)
        {
            Configuration = configuration;
        }

        public Task<byte[]> GenerateSaltedHash(string inputText)
        {
            var bytes = Encoding.UTF8.GetBytes(inputText);

            var hash = new MD5CryptoServiceProvider().ComputeHash(bytes);

            return Task.FromResult(hash);
        }
    }
}