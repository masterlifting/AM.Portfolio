namespace AM.Portfolio.Core.Abstractions.ExcelService;

public interface IPortfolioExcelService
{
    IPortfolioExcelDocument GetExcelDocument(byte[] payload);
}