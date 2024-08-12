using BackEnd.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackEnd.Data
{
    public class EmployeeWorkFlowDbContext : DbContext
    {
        public DbSet<EmployeeWorkFlow> EmployeeWorkFlow { get; set; }
        public EmployeeWorkFlowDbContext(DbContextOptions<EmployeeWorkFlowDbContext> option) : base(option)
        {
            
        }
    }
}
