using BackEnd.Service.DTOS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackEnd.Service.Interface
{
    public interface IEmployee
    {
        Task<string?> AddEmployeeWorkFlowAsync(EmployeeWorkFlowAddDtos empDto, CancellationToken cancellationToken);
        Task<IQueryable<EmployeeWorkFlowGetDtos>?> GetAllEmployeeAsync(CancellationToken cancellationToken);
    }
}
