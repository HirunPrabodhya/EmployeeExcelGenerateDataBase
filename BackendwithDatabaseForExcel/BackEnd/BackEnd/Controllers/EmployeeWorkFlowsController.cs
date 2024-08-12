using BackEnd.Service.DTOS;
using BackEnd.Service.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeWorkFlowsController : ControllerBase
    {
        private readonly IEmployee _employee;

        public EmployeeWorkFlowsController(IEmployee employee)
        {
            _employee = employee;
        }

        [HttpPost]
        public async Task<IActionResult> AddEmployee([FromBody] EmployeeWorkFlowAddDtos dataDtos, CancellationToken cancellationToken)
        {
            var message = await _employee.AddEmployeeWorkFlowAsync(dataDtos,cancellationToken);

            if(message == null)
            {
                return NotFound(new
                {
                    message = "data is incompleted"
                });
            }
            return Ok(new
            {
                message = message
            });
        }
        [HttpGet]
        public async Task<IActionResult> GetAllEmployee(CancellationToken cancellationToken)
        {
            var employees = await _employee.GetAllEmployeeAsync(cancellationToken);
            if (employees == null) 
            { 
                return NotFound(new
                {
                    message = "employee does not exist"
                });
            }
            return Ok(employees);
        }
    }
}
