using System.Threading.Tasks;

namespace WebApiBaseLibrary.DataAccess.Repositories
{
    public interface IDatabaseRepository
    {
        public void SaveChanges();
        public Task SaveChangesAsync();
    }
}