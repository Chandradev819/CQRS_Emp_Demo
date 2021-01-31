using CQRS_Emp_Demo.Context;
using CQRS_Emp_Demo.Model;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace CQRS_Emp_Demo
{
    public class GetAllEmpsQuery : IRequest<IEnumerable<Emp>>
    {
        public class GetAllEmpsQueryHandler : IRequestHandler<GetAllEmpsQuery, IEnumerable<Emp>>
        {
            private readonly IApplicationContext _context;
            public GetAllEmpsQueryHandler(IApplicationContext context)
            {
                _context = context;
            }
            public async Task<IEnumerable<Emp>> Handle(GetAllEmpsQuery request, CancellationToken cancellationToken)
            {
                var emplist = await _context.Emps.ToListAsync();
                if (emplist == null)
                {
                    return null;
                }
                return emplist.AsReadOnly();
            }
        }
    }
}
