

using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using ScoreManageSystem.Core.Domain;
using ScoreManageSystem.Core.Domain.Students;
using ScoreManageSystem.Core.Domain.Teachers;

namespace ScoreManageSystem.Core
{
    public class EfDbContext : DbContext
    {
        public  DbSet<Student> Students { get; set; }
        public  DbSet<Teacher> Teachers { get; set; }
        public  DbSet<School> Schools { get; set; }

        public EfDbContext()
            : base("name=Default")
        {
            
        }
        public EfDbContext(string nameOrConnectionString)
            : base(nameOrConnectionString) 
        { }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}