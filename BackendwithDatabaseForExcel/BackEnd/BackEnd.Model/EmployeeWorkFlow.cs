using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackEnd.Model
{
    public class EmployeeWorkFlow
    {
        public int Id { get; set; }
        public int Date { get; set; }
        public double TotalEarning { get; set; }
        public double TotalPiecerate { get; set; }
        public double TotalDailypay { get; set; }
        public double Effiency { get; set; }
        public int InDateTime { get; set; }
        public int OutDateTime { get; set; }
        public string Shift { get; set; }
        public string Section { get; set; }
    }
}
