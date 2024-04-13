using Constructor.Models;

namespace Constructor.Repository
{
    public class PageRepository : IRepository<Page>
    {
        private readonly AppDBContext _dbContext;

        public PageRepository(AppDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Add(Page item)
        {
            throw new NotImplementedException();
        }

        public Page Get(int id)
        {
            throw new NotImplementedException();
        }        

        public IEnumerable<Page> GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
