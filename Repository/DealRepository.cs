using Constructor.Models;
using Microsoft.EntityFrameworkCore;

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
            _dbContext.Deals.Add(item);
            _dbContext.SaveChanges();
        }

        public void Update(Deal item)
        {
            _dbContext.Deals.Update(item);
            _dbContext.SaveChanges();
        }

        public Deal Get(int id)
        {
            return _dbContext.Deals.Where(d => d.Id == id).Include(p => p.Client).FirstOrDefault();
        }

        public IEnumerable<Deal> GetAll(int projectId)
        {
            return _dbContext.Deals.Where(d=> d.Project_Id == projectId).Include(p => p.Client);
        }

        public IEnumerable<Deal> GetAllArchive(int projectId)
        {
            return _dbContext.Deals.Where(d => d.Project_Id == projectId && d.IsArchive == true).Include(p => p.Client);
        }



        public IEnumerable<Deal> GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
