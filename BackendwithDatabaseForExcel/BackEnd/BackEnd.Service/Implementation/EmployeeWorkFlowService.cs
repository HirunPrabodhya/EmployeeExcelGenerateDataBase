using BackEnd.Data;
using BackEnd.Model;
using BackEnd.Service.DTOS;
using BackEnd.Service.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackEnd.Service.Implementation
{
    public class EmployeeWorkFlowService : IEmployee
    {
        private readonly EmployeeWorkFlowDbContext _dbContext;

        public EmployeeWorkFlowService(EmployeeWorkFlowDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<string?> AddEmployeeWorkFlowAsync(EmployeeWorkFlowAddDtos empDto, CancellationToken cancellationToken)
        {
            if (empDto == null) 
            {
                return null;
            }
            var employee = new EmployeeWorkFlow
            {
                Date = empDto.Date,
                TotalEarning = empDto.TotalEarning,
                TotalPiecerate = empDto.TotalPiecerate,
                TotalDailypay = empDto.TotalDailypay,
                Effiency = empDto.Effiency,
                InDateTime = empDto.InDateTime,
                OutDateTime = empDto.OutDateTime,
                Shift = empDto.Shift,
                Section = empDto.Section
            };
            await _dbContext.EmployeeWorkFlow.AddAsync(employee,cancellationToken);
            var count = await _dbContext.SaveChangesAsync(cancellationToken);

            if (count <= 0) 
            {
                return "data is not saved";
            }
            return "data is saved";

        }

        public async Task<IQueryable<EmployeeWorkFlowGetDtos>?> GetAllEmployeeAsync(CancellationToken cancellationToken)
        {
            var employees = await _dbContext.EmployeeWorkFlow.ToListAsync(cancellationToken);
            if(employees.Count == 0)
            {
                return null;
            }
            var empDtos = employees.Select(x => new EmployeeWorkFlowGetDtos
            {
                Date = x.Date,
                TotalEarning = x.TotalEarning,
                TotalPiecerate = x.TotalPiecerate,
                TotalDailypay = x.TotalDailypay,
                Effiency = x.Effiency,
                InDateTime = x.InDateTime,
                OutDateTime = x.OutDateTime,
                Shift = x.Shift,
                Section = x.Section
            }).AsQueryable();

            return empDtos;

        }
    }
}
