using BackEnd.Service.DTOS;
using BackEnd.Service.Interface;
using ClosedXML.Excel;
using DocumentFormat.OpenXml.Spreadsheet;

namespace BackEnd.StaticClass
{
    public class ExcelSheetGenerator
    {
        internal static IXLWorksheet CreateExcelHeader(XLWorkbook wb) 
        {
            var workSheet = wb.AddWorksheet("Sheet1");
            workSheet.Cell("A1").Value = "Date";
            workSheet.Cell("B1").Value = "Total Earning";
            workSheet.Cell("C1").Value = "Total Piecerate" + Environment.NewLine + "(A)";
            workSheet.Cell("D1").Value = "Total Dailypay" + Environment.NewLine + "B = (K+G+H)";
            workSheet.Cell("E1").Value = "Effiency" + Environment.NewLine + "C = (A-B)";
            workSheet.Range("F1:G1").Merge().Value = "In Date & " + Environment.NewLine + "Time";
            workSheet.Range("H1:I1").Merge().Value = "Out Date" + Environment.NewLine + "& Time";
            workSheet.Cell("J1").Value = "Shift";
            workSheet.Cell("K1").Value = "Section";
            return workSheet;
        }
        internal static IXLWorksheet CreateExcelContent(IXLWorksheet xLWorksheet, IQueryable<EmployeeWorkFlowGetDtos>? employees) 
        {
            var rowSpan = 0;
            var nextRowSpan = 0;
            var i = 1;
                foreach (var employee in employees)
                {
                     
                     rowSpan = 2 * i;   
                     nextRowSpan = rowSpan + 1;

                    xLWorksheet.Range($"A{rowSpan}:A{nextRowSpan}").Merge().Value = employee.Date;
                    xLWorksheet.Range($"B{rowSpan}:B{nextRowSpan}").Merge().Value = employee.TotalEarning;
                    xLWorksheet.Range($"C{rowSpan}:C{nextRowSpan}").Merge().Value = employee.TotalPiecerate;
                    xLWorksheet.Range($"D{rowSpan}:D{nextRowSpan}").Merge().Value = employee.TotalDailypay;
                    xLWorksheet.Range($"E{rowSpan}:E{nextRowSpan}").Merge().Value = employee.Effiency;

                    xLWorksheet.Cell($"F{rowSpan}").Value = employee.Date;
                    xLWorksheet.Cell($"G{rowSpan}").Value = employee.InDateTime;
                    xLWorksheet.Cell($"H{rowSpan}").Value = employee.Date;
                    xLWorksheet.Cell($"I{rowSpan}").Value = employee.OutDateTime;
                    xLWorksheet.Cell($"J{rowSpan}").Value= employee.Shift;
                    xLWorksheet.Cell($"K{rowSpan}").Value = employee.Section;

                    xLWorksheet.Cell($"F{nextRowSpan}").Value = employee.Date;
                    xLWorksheet.Cell($"G{nextRowSpan}").Value = employee.InDateTime;
                    xLWorksheet.Cell($"H{nextRowSpan}").Value = employee.Date;
                    xLWorksheet.Cell($"I{nextRowSpan}").Value = employee.OutDateTime;
                    xLWorksheet.Cell($"J{nextRowSpan}").Value = "";
                    xLWorksheet.Cell($"K{nextRowSpan}").Value = "";

                    i++;

                }
                return xLWorksheet;
        }
        internal static IXLWorksheet StyleExcelWoorkSheet(IXLWorksheet xLWorksheet,int count)
        {
            xLWorksheet.Columns().AdjustToContents();
            xLWorksheet.Range($"A1:K{(count + 1) * 2}").Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
            xLWorksheet.Range($"A1:K{(count + 1) * 2}").Style.Border.InsideBorder = XLBorderStyleValues.Thin;
            xLWorksheet.Range($"A1:K{(count + 1) * 2}").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
            xLWorksheet.Range($"A1:K{(count + 1) * 2}").Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;

            return xLWorksheet;
        }
    }
}
