using System.Threading.Tasks;

namespace WebApiBaseLibrary.Infrastructure.Generators
{
    public interface IHashGenerator
    {
        public Task<byte[]> GenerateSaltedHash(string inputText);
    }
}