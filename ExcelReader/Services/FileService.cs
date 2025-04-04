using ExcelReader.Services.Models;
using OfficeOpenXml;
using Spectre.Console;

namespace ExcelReader.Services;

public class FileService(string filePath)
{
    private readonly string _filePath = filePath;
    
    internal List<Movie> ReadExcelFile()
    {
        AnsiConsole.MarkupLine($"[bold yellow]Reading from excel file: {_filePath}[/]");
        var movieData = new List<Movie>();
        ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
        
        if (!File.Exists(_filePath))
            throw new FileNotFoundException("File does not exist", _filePath);
        
        using var package = new ExcelPackage(new FileInfo(_filePath));
        var worksheet = package.Workbook.Worksheets[0];
        int rowCount = worksheet.Dimension.End.Row;
        

        for (int row = 2; row <= rowCount; row++)
        {
            var movie = new Movie
            {
                Name = worksheet.Cells[row, 2].Value.ToString(),
                Year = int.Parse(worksheet.Cells[row, 3].Value.ToString()),
                Runtime = int.Parse(worksheet.Cells[row, 4].Value.ToString()),
                ImdbScore = double.Parse(worksheet.Cells[row, 5].Value.ToString()),
            };
            movieData.Add(movie);
        }
        return movieData;
    }
}