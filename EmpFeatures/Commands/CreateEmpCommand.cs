using CQRS_Emp_Demo.Context;
using CQRS_Emp_Demo.Model;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace CQRS_Emp_Demo
{
    public class CreateEmpCommand : IRequest<int>
    {
        public int Id { get; set; }
        public string EmpName { get; set; }
        public string EmpAddress { get; set; }
        public string Country { get; set; }

        public class CreateEmpCommandHandler : IRequestHandler<CreateEmpCommand, int>
        {
            private readonly IApplicationContext _context;
            public CreateEmpCommandHandler(IApplicationContext context)
            {
                _context = context;
            }
            public async Task<int> Handle(CreateEmpCommand request, CancellationToken cancellationToken)
            {
                var emp = new Emp();
                emp.EmpName = request.EmpName;
                emp.EmpAddress = request.EmpAddress;
                emp.Country = request.Country;
                _context.Emps.Add(emp);
                int flag = await _context.SaveChangesAsync();
                return flag;
            }
        }
    }
}
