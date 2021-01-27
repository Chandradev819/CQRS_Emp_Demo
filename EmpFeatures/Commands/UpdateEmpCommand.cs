using CQRS_Emp_Demo.Context;
using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CQRS_Emp_Demo
{
    public class UpdateEmpCommand : IRequest<int>
    {
        public int Id { get; set; }
        public string EmpName { get; set; }
        public string EmpAddress { get; set; }
        public string Country { get; set; }
        public class UpdateEmpCommandHandler : IRequestHandler<UpdateEmpCommand, int>
        {
            private readonly IApplicationContext _context;
            public UpdateEmpCommandHandler(IApplicationContext context)
            {
                _context = context;
            }
            public async Task<int> Handle(UpdateEmpCommand request, CancellationToken cancellationToken)
            {
                var emp = _context.Emps.Where(a => a.Id == request.Id).FirstOrDefault();
                if (emp == null)
                {
                    return default;
                }
                else
                {
                    emp.Country = request.Country;
                    emp.EmpAddress = request.EmpAddress;
                    emp.EmpName = request.EmpName;
                    int flag = await _context.SaveChangesAsync();
                    return flag;
                }
            }
        }
    }
}
