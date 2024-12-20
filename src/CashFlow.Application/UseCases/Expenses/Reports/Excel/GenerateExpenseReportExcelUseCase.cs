﻿
using CashFlow.Domain.Reports;
using CashFlow.Domain.Repositories.Expenses;
using ClosedXML.Excel;

namespace CashFlow.Application.UseCases.Expenses.Reports.Excel;
public class GenerateExpenseReportExcelUseCase : IGenerateExpenseReportExcelUseCase
{
    private readonly IExpensesReadOnlyRepository _repository;
    public GenerateExpenseReportExcelUseCase(IExpensesReadOnlyRepository repository)
    {
        _repository = repository;
    }
    public async Task<byte[]> Execute(DateOnly month)
    {
        var expenses = await _repository.FilterByMonth(month);

        if (expenses.Count == 0) return [];

        var workbook = new XLWorkbook();
        workbook.Author = "Milton Soares";
        workbook.Style.Font.FontSize = 11;

        var worksheet = workbook.Worksheets.Add(month.ToString("Y"));

        InsertHeader(worksheet);

        var file = new MemoryStream();

        workbook.SaveAs(file);

        return file.ToArray();
    }


    private void InsertHeader(IXLWorksheet worksheet)
    {
        worksheet.Cell("A1").Value = ResourceReportGenerationMessages.TITLE;
        worksheet.Cell("B1").Value = ResourceReportGenerationMessages.CREATED_DATE;
        worksheet.Cell("C1").Value = ResourceReportGenerationMessages.PAYMENT_TYPE;
        worksheet.Cell("D1").Value = ResourceReportGenerationMessages.AMOUNT;
        worksheet.Cell("E1").Value = ResourceReportGenerationMessages.DESCRIPTION;

        worksheet.Cells("A1:E1").Style.Font.Bold = true;
        worksheet.Cells("A1:E1").Style.Font.FontColor = XLColor.White;
        worksheet.Cells("A1:E1").Style.Fill.BackgroundColor = XLColor.FromHtml("#222222");
        worksheet.Cells("A1:E1").Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);
    }
}
