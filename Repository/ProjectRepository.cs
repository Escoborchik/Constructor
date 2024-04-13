using Constructor.Models;

namespace Constructor.Repository
{
    public class ProjectRepository : IRepository<Project>
    {
        private readonly AppDBContext _dbContext;

        public ProjectRepository(AppDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Add(Project item)
        {
            throw new NotImplementedException();
        }

        public Project Get(int id)
        {
            throw new NotImplementedException();
        }        

        public IEnumerable<Project> GetAll()
        {
            throw new NotImplementedException();
        }

        
    }
}
