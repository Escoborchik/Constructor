using Constructor.Models;
using Microsoft.EntityFrameworkCore;

namespace Constructor.Repository
{
    public class ClientRepository : IRepository<Client>
    {
        private readonly AppDBContext _dbContext;

        public ClientRepository(AppDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Add(Client item)
        {
            _dbContext.Clients.Add(item);
            _dbContext.SaveChanges();
        }

        public Client Get(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Client> GetAll()
        {
            return _dbContext.Clients.Include(p => p.Deals);
        }
    }
}
