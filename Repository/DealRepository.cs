using Constructor.Models;

namespace Constructor.Repository
{
    public class DealRepository : IRepository<Deal>
    {
        private readonly AppDBContext _dbContext;

        public DealRepository(AppDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Add(Deal item)
        {
            throw new NotImplementedException();
        }

        public Deal Get(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Deal> GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
