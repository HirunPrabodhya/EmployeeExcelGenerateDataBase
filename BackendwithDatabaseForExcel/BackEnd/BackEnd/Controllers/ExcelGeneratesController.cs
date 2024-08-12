using BackEnd.Service.Interface;
using BackEnd.StaticClass;
using ClosedXML.Excel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExcelGeneratesController : ControllerBase
    {
        private readonly IEmployee _employee;

        public ExcelGeneratesController(IEmployee employee)
        {
            _employee = employee;
        }

        [HttpGet]
        public async Task<IActionResult> DownloadExcelSheet(CancellationToken cancellationToken)
        {
            var employees = await _employee.GetAllEmployeeAsync(cancellationToken);
            if (employees == null) 
            { 
                return NotFound();
            }
            var count = employees.Count();
            IXLWorksheet workSheet = null;

            using (var workbook = new XLWorkbook())
            {
                    workSheet = ExcelSheetGenerator.CreateExcelHeader(workbook);
                    workSheet = ExcelSheetGenerator.CreateExcelContent(workSheet,employees);
                    workSheet = ExcelSheetGenerator.StyleExcelWoorkSheet(workSheet, count);

                using (var stream = new MemoryStream())
                {
                    workbook.SaveAs(stream);
                    stream.Position = 0;

                    
                    return File(
                        stream.ToArray(),
                        "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet",
                        "practical.xlsx"
                    );
                }
            }
            
        }
    }
}
