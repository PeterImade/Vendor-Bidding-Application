using Vendor_Bidding_Application.Contracts;
using Vendor_Bidding_Application.Data;
using Vendor_Bidding_Application.Models;

namespace Vendor_Bidding_Application.Repository
{
    public class ProjectRepository: GenericRepository<Project>, IProjectRepository
    {
        private readonly AppDbContext _dbContext;

        public ProjectRepository(AppDbContext dbContext): base(dbContext)
        {
            this._dbContext = dbContext;
        }
    }
}
