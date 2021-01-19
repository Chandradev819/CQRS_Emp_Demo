using CQRS_Emp_Demo.Model;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace CQRS_Emp_Demo.Context
{
    public interface IApplicationContext
    {
        DbSet<Emp> Emps { get; set; }

        Task<int> SaveChangesAsync();
    }
}