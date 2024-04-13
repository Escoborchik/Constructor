using Constructor.Models;

namespace Constructor.Repository
{
    public class MasterRepository : IRepository<Master>
    {
        private readonly AppDBContext _dbContext;

        public MasterRepository(AppDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Add(Master item)
        {
            throw new NotImplementedException();
        }

        public Master Get(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Master> GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
