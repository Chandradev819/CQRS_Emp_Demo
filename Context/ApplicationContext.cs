using CQRS_Emp_Demo.Model;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace CQRS_Emp_Demo.Context
{
    public class ApplicationContext : DbContext, IApplicationContext
    {
        public DbSet<Emp> Emps { get; set; }
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {

        }
        public async Task<int> SaveChangesAsync()
        {
            return await base.SaveChangesAsync();
        }
    }
}
