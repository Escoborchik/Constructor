using Constructor.Models;

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
            throw new NotImplementedException();
        }

        public Client Get(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Client> GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
