using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using System.Threading.Tasks;


namespace CQRS_Emp_Demo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmpController : ControllerBase
    {
        private IMediator _mediator;
        protected IMediator Mediator => _mediator ??= HttpContext.RequestServices.GetService<IMediator>();

        // GET: api/<EmpController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await Mediator.Send(new GetAllEmpsQuery()));
        }

        // GET api/<EmpController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetEmpById(int id)
        {
            return Ok(await Mediator.Send(new GetEmpByIdQuery { Id = id }));
        }

        // POST api/<EmpController>
        [HttpPost]
        public async Task<IActionResult> SaveEmp(CreateEmpCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        // PUT api/<EmpController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateEmpById(int id, UpdateEmpCommand command)
        {
            if (id != command.Id)
            {
                return BadRequest();
            }
            return Ok(await Mediator.Send(command));
        }

        // DELETE api/<EmpController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok(await Mediator.Send(new DeleteEmpCommand { Id = id }));
        }
    }
}
