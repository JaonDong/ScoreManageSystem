

using System.Data.Entity;

namespace ScoreManageSystem.Core
{
    public class EfDbContext : DbContext
    {
        protected EfDbContext(string nameOrConnectionString)
            : base(nameOrConnectionString) 
        { }
    }
}