namespace ExcelReader.Services.Models;

public class Movie
{
    public int Id { get; set; }
    
    public string Name { get; set; }
    public int Year { get; set; }
    public int Runtime { get; set; }
    public double ImdbScore { get; set; }
}