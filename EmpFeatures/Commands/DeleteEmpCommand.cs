using CQRS_Emp_Demo.Context;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CQRS_Emp_Demo
{
    public class DeleteEmpCommand : IRequest<int>
    {
        public int Id { get; set; }
        public class DeleteEmpCommandHandler : IRequestHandler<DeleteEmpCommand, int>
        {
            public readonly IApplicationContext _context;
            public DeleteEmpCommandHandler(IApplicationContext context)
            {
                _context = context;
            }

            public async Task<int> Handle(DeleteEmpCommand request, CancellationToken cancellationToken)
            {
                var emp = await _context.Emps.Where(m => m.Id == request.Id).FirstOrDefaultAsync();
                if (emp == null) return default;
                _context.Emps.Remove(emp);
                int flag = await _context.SaveChangesAsync();
                return flag;

            }
        }
    }
}
