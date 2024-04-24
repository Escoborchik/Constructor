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
            _dbContext.Projects.Add(item);
            _dbContext.SaveChanges();
        }

        public Project Get(int id)
        {
            return _dbContext.Projects.FirstOrDefault(p => p.Master_Id == id);
        }        

        public IEnumerable<Project> GetAll()
        {
            throw new NotImplementedException();
        }

        public void Edit(Project item) 
        {
            _dbContext.Projects.Update(item);
            _dbContext.SaveChanges();
        }

        
    }
}
