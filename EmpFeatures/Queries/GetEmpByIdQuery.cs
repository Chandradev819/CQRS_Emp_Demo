using CQRS_Emp_Demo.Context;
using CQRS_Emp_Demo.Model;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CQRS_Emp_Demo
{
    public class GetEmpByIdQuery : IRequest<Emp>
    {
        public int Id { get; set; }
        public class GetEmpByIdQueryHandler : IRequestHandler<GetEmpByIdQuery, Emp>
        {
            private readonly IApplicationContext _context;
            public GetEmpByIdQueryHandler(IApplicationContext context)
            {
                _context = context;
            }

            public async Task<Emp> Handle(GetEmpByIdQuery request, CancellationToken cancellationToken)
            {
                var emp = await _context.Emps.Where(m => m.Id == request.Id).FirstOrDefaultAsync();
                if (emp == null) return null;
                return emp;
            }
        }
    }
}
